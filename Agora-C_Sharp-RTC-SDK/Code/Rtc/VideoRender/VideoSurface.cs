#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS

using UnityEngine;
using UnityEngine.UI;

namespace Agora.Rtc
{
    ///
    /// <summary>
    /// This class contains Unity native methods related to video rendering.
    /// </summary>
    ///
    public class VideoSurface : MonoBehaviour
    {
        [SerializeField] protected VideoSurfaceType VideoSurfaceType = VideoSurfaceType.Renderer;
        [SerializeField] protected bool Enable = true;

        [SerializeField] protected uint Uid = 0;
        [SerializeField] protected string ChannelId = "";
        [SerializeField] protected VIDEO_SOURCE_TYPE SourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
        protected VIDEO_OBSERVER_FRAME_TYPE FrameType = VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA;

        protected Component _renderer;
        protected bool _needUpdateInfo = true;
        protected bool _hasAttach = false;

        protected GameObject _TextureManagerGameObject;
        protected TextureManager _textureManager;
        protected int _textureWidth = 2;
        protected int _textureHeight = 2;

        // External targets for custom rendering
        protected RenderTexture _externalRenderTexture = null;
        protected Material _externalMaterial = null;
        protected bool _useExternalTargets = false;
        
        // Persistent RenderTexture for material blit operations
        protected RenderTexture _persistentBlitRT = null;

        ///
        /// <summary>
        /// This callback is triggered when the width and height of Texture are changed.
        /// 
        /// When the width and height of Texture are changed, the SDK triggers this callback.
        /// </summary>
        ///
        public event OnTextureSizeModifyHandler OnTextureSizeModify;

        void Start()
        {
            FrameType = VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA;
            CheckVideoSurfaceType();
        }

        void Update()
        {
            if (_renderer == null || _needUpdateInfo) return;

            if (Enable)
            {
                if (_textureManager == null)
                {
                    string textureManagerName = this.GenerateTextureManagerUniqueName();
                    _TextureManagerGameObject = GameObject.Find(textureManagerName);

                    if (_TextureManagerGameObject == null)
                    {
                        _TextureManagerGameObject = new GameObject(textureManagerName);
                        _TextureManagerGameObject.hideFlags = HideFlags.HideInHierarchy;

                        _textureManager = _TextureManagerGameObject.AddComponent<TextureManager>();
                        _textureManager.SetVideoStreamIdentity(Uid, ChannelId, SourceType, FrameType);
                        _textureManager.EnableVideoFrameWithIdentity();
                    }
                    else
                    {
                        _textureManager = _TextureManagerGameObject.GetComponent<TextureManager>();
                    }
                }
                else if (_textureManager && !_hasAttach && _textureManager.CanTextureAttach())
                {
                    ApplyTexture(_textureManager.Texture);
                    _textureManager.Attach();
                    _hasAttach = true;
                }

                if (_textureManager && (this._textureWidth != _textureManager.Width || this._textureHeight != _textureManager.Height))
                {
                    this._textureWidth = _textureManager.Width;
                    this._textureHeight = _textureManager.Height;
                    if (this._textureWidth != 0 && this._textureHeight != 0 && this.OnTextureSizeModify != null)
                    {
                        this.OnTextureSizeModify.Invoke(this._textureWidth, this._textureHeight);
                    }
                }
            }
            else
            {
                if (_hasAttach && !IsBlankTexture())
                {
                    DestroyTextureManager();
                    ApplyTexture(null);
                    
                    // Clear external targets when disabling
                    if (_useExternalTargets && _externalRenderTexture != null)
                    {
                        Graphics.Blit(Texture2D.blackTexture, _externalRenderTexture);
                    }
                    // Clear persistent blit RT when disabling
                    ReleasePersistentBlitRT();
                }
            }
        }

        protected virtual void InvokeOnTextureSizeModify()
        {
            if (this.OnTextureSizeModify != null)
            {
                this.OnTextureSizeModify.Invoke(this._textureWidth, this._textureHeight);
            }
        }

        void OnDestroy()
        {
            AgoraLog.Log(string.Format("VideoSurface RGBA channel: ${0}, user:{1} destroy", ChannelId, Uid));
            DestroyTextureManager();
            ClearExternalTargets();
            ReleasePersistentBlitRT();
        }

        protected virtual void CheckVideoSurfaceType()
        {
            if (VideoSurfaceType == VideoSurfaceType.Renderer)
            {
                _renderer = GetComponent<Renderer>();
            }

            if (_renderer == null || VideoSurfaceType == VideoSurfaceType.RawImage)
            {
                _renderer = GetComponent<RawImage>();
                if (_renderer != null)
                {
                    VideoSurfaceType = VideoSurfaceType.RawImage;
                }
            }

            if (_renderer == null)
            {
                AgoraLog.LogError("Unable to find surface render in VideoSurface component.");
            }
            else
            {
#if UNITY_EDITOR
                // Only update shader if not using external materials
                if (!_useExternalTargets || _externalMaterial == null)
                {
                    UpdateShader();
                }
#endif
            }
        }

        protected virtual void DestroyTextureManager()
        {
            if (_textureManager == null) return;

            if (_hasAttach == true)
            {
                _textureManager.Detach();
                _hasAttach = false;
            }

            if (_textureManager.GetRefCount() <= 0)
            {
                Destroy(_TextureManagerGameObject);
            }
            _textureManager = null;
        }

        virtual protected bool IsBlankTexture()
        {
            if (VideoSurfaceType == VideoSurfaceType.Renderer)
            {
                var rd = (_renderer as Renderer);
                return rd.material.mainTexture == null || !(rd.material.mainTexture is Texture2D);
            }
            else if (VideoSurfaceType == VideoSurfaceType.RawImage)
            {
                var rd = (_renderer as RawImage);
                return (rd.texture == null);
            }
            else
            {
                return true;
            }
        }

        protected virtual void ApplyTexture(Texture2D texture)
        {
            // Handle external rendering targets
            if (_useExternalTargets)
            {
                HandleExternalRendering(texture);
                // When using external targets, skip default rendering to avoid unnecessary overhead
                return;
            }

            // Default rendering behavior only when not using external targets
            if (VideoSurfaceType == VideoSurfaceType.Renderer)
            {
                var rd = _renderer as Renderer;
                rd.material.mainTexture = texture;
            }
            else if (VideoSurfaceType == VideoSurfaceType.RawImage)
            {
                var rd = _renderer as RawImage;
                rd.texture = texture;
            }
        }

        ///
        /// <summary>
        /// Handles rendering to external targets (RenderTexture and/or Material).
        /// Base implementation for single texture (RGBA). Derived classes should override for multi-texture support.
        /// </summary>
        ///
        /// <param name="sourceTexture"> The source texture to render from. </param>
        ///
        protected virtual void HandleExternalRendering(Texture2D sourceTexture)
        {
            HandleExternalRenderingInternal(sourceTexture, null);
        }

        ///
        /// <summary>
        /// Internal method to handle external rendering with optional material setup callback.
        /// This allows derived classes to configure additional textures before rendering.
        /// </summary>
        ///
        /// <param name="sourceTexture"> The main source texture. </param>
        /// <param name="materialSetupCallback"> Optional callback to configure additional material properties. </param>
        ///
        protected void HandleExternalRenderingInternal(Texture2D sourceTexture, System.Action<Material> materialSetupCallback)
        {
            // If external RenderTexture is set, render to it
            if (_externalRenderTexture != null)
            {
                if (sourceTexture != null)
                {
                    // Use external material if available, otherwise use default blit
                    if (_externalMaterial != null)
                    {
                        // Allow derived classes to set up additional textures
                        materialSetupCallback?.Invoke(_externalMaterial);
                        Graphics.Blit(sourceTexture, _externalRenderTexture, _externalMaterial);
                    }
                    else
                    {
                        Graphics.Blit(sourceTexture, _externalRenderTexture);
                    }
                }
                else
                {
                    // Clear external render texture when source is null
                    Graphics.Blit(Texture2D.blackTexture, _externalRenderTexture);
                }
            }
            // If only external material is set (without RenderTexture), apply it to the current renderer
            else if (_externalMaterial != null && sourceTexture != null)
            {
                _externalMaterial.mainTexture = sourceTexture;
                // Allow derived classes to set up additional textures
                materialSetupCallback?.Invoke(_externalMaterial);

                if (VideoSurfaceType == VideoSurfaceType.Renderer)
                {
                    var rd = _renderer as Renderer;
                    if (_persistentBlitRT != null)
                    {
                        rd.material.mainTexture = _persistentBlitRT;
                    }
                    else
                    {
                        rd.material.mainTexture = _externalMaterial.mainTexture;
                    }
                }
                else if (VideoSurfaceType == VideoSurfaceType.RawImage)
                {
                    var rd = _renderer as RawImage;
                    if (_persistentBlitRT != null)
                    {
                        rd.texture = _persistentBlitRT;
                    }
                    else {
                        rd.texture = _externalMaterial.mainTexture;
                    }
                }
            }
        }

        ///
        /// <summary>
        /// 确保持久的RenderTexture存在且尺寸正确，用于材质效果渲染
        /// </summary>
        ///
        /// <param name="width"> 目标宽度 </param>
        /// <param name="height"> 目标高度 </param>
        ///
        protected virtual void EnsurePersistentBlitRT(int width, int height)
        {
            // 检查是否需要创建或重新创建RenderTexture
            if (_persistentBlitRT == null || 
                _persistentBlitRT.width != width || 
                _persistentBlitRT.height != height ||
                !_persistentBlitRT.IsCreated())
            {
                // 清理旧的RenderTexture
                ReleasePersistentBlitRT();
                
                // 创建新的RenderTexture
                _persistentBlitRT = new RenderTexture(width, height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
                _persistentBlitRT.Create();
            }
        }

        ///
        /// <summary>
        /// 释放持久的RenderTexture
        /// </summary>
        ///
        protected virtual void ReleasePersistentBlitRT()
        {
            if (_persistentBlitRT != null)
            {
                if (_persistentBlitRT.IsCreated())
                {
                    _persistentBlitRT.Release();
                }
                DestroyImmediate(_persistentBlitRT);
                _persistentBlitRT = null;
            }
        }

        protected virtual void UpdateShader()
        {
            var mesh = GetComponent<MeshRenderer>();
            if (mesh != null)
            {
                Debug.LogWarning("VideoSureface update shader");
                mesh.material = new Material(Shader.Find("Unlit/Texture"));
            }
        }

        ///
        /// <summary>
        /// Sets the local or remote video display.
        /// 
        /// Ensure that you call this method in the main thread.
        /// Ensure that you call this method before binding VideoSurface.cs.
        /// </summary>
        ///
        /// <param name="uid"> The ID of remote users, obtained through OnUserJoined. The default value is 0, which means you can see the local video. </param>
        ///
        /// <param name="channelId"> The ID of the channel. </param>
        ///
        /// <param name="source_type"> The type of the video source. See VIDEO_SOURCE_TYPE. </param>
        ///
        public virtual void SetForUser(uint uid = 0, string channelId = "", VIDEO_SOURCE_TYPE source_type = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY)
        {
            Uid = uid;
            ChannelId = uid == 0 ? "" : channelId;
            SourceType = source_type;
            _needUpdateInfo = false;
        }

        ///
        /// <summary>
        /// Sets whether to enable the video rendering.
        /// </summary>
        ///
        /// <param name="enable"> Whether to enable the video rendering: true : (Default) Enable the video rendering. false : Disable the video rendering. </param>
        ///
        public virtual void SetEnable(bool enable)
        {
            Enable = enable;
        }

        ///
        /// <summary>
        /// Sets an external RenderTexture as the render target for video content.
        /// When set, video content will be drawn to this RenderTexture instead of the default renderer.
        /// </summary>
        ///
        /// <param name="renderTexture"> The external RenderTexture to draw video content to. Set to null to disable external rendering. </param>
        ///
        public virtual void SetExternalRenderTexture(RenderTexture renderTexture)
        {
            _externalRenderTexture = renderTexture;
            _useExternalTargets = (_externalRenderTexture != null || _externalMaterial != null);
        }

        ///
        /// <summary>
        /// Sets an external Material for custom video rendering.
        /// When set, video content will be processed with this Material before rendering.
        /// </summary>
        ///
        /// <param name="material"> The external Material to use for video rendering. Set to null to disable external material. </param>
        ///
        public virtual void SetExternalMaterial(Material material)
        {
            _externalMaterial = material;
            _useExternalTargets = (_externalRenderTexture != null || _externalMaterial != null);
        }

        ///
        /// <summary>
        /// Sets both external RenderTexture and Material for custom video rendering.
        /// </summary>
        ///
        /// <param name="renderTexture"> The external RenderTexture to draw video content to. </param>
        /// <param name="material"> The external Material to use for video rendering. </param>
        ///
        public virtual void SetExternalTargets(RenderTexture renderTexture, Material material)
        {
            _externalRenderTexture = renderTexture;
            _externalMaterial = material;
            _useExternalTargets = (_externalRenderTexture != null || _externalMaterial != null);
        }

        ///
        /// <summary>
        /// Clears all external rendering targets and returns to default rendering behavior.
        /// </summary>
        ///
        public virtual void ClearExternalTargets()
        {
            _externalRenderTexture = null;
            _externalMaterial = null;
            _useExternalTargets = false;
            ReleasePersistentBlitRT();
        }

        ///
        /// <summary>
        /// Gets the current external RenderTexture.
        /// </summary>
        ///
        /// <returns> The current external RenderTexture, or null if not set. </returns>
        ///
        public virtual RenderTexture GetExternalRenderTexture()
        {
            return _externalRenderTexture;
        }

        ///
        /// <summary>
        /// Gets the current external Material.
        /// </summary>
        ///
        /// <returns> The current external Material, or null if not set. </returns>
        ///
        public virtual Material GetExternalMaterial()
        {
            return _externalMaterial;
        }

        ///
        /// <summary>
        /// Checks if external targets are currently being used for rendering.
        /// </summary>
        ///
        /// <returns> True if external targets are active, false otherwise. </returns>
        ///
        public virtual bool IsUsingExternalTargets()
        {
            return _useExternalTargets;
        }

        virtual protected string GenerateTextureManagerUniqueName()
        {
            return "TextureManager" + "_" + Uid.ToString() + "_" + ChannelId + "_" + SourceType.ToString() + "_" + FrameType.ToString();
        }

    }
}

#endif