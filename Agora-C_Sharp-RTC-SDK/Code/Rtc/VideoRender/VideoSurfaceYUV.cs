#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS

using UnityEngine;
using UnityEngine.UI;

namespace Agora.Rtc
{
    ///
    /// <summary>
    /// Porivdes APIs for rendering videos. This class inherits all APIs from the VideoSurface class, but enables you to render video images with high resolutions (such as 4K) faster and at higher frame rates. As of v4.2.0, Agora Unity SDK does not support rendering different video sources with both VideoSurface and VideoSurfaceYUV at the same time. Specifically, after successfully creating IRtcEngine, if the first view is rendered with VideoSurfaceYUV, then only VideoSurfaceYUV can be used for rendering throughout the entire lifecycle of IRtcEngine.
    /// </summary>
    ///
    public class VideoSurfaceYUV : VideoSurface
    {
        protected Material _material = null;
        protected float YStrideScale = 1.0f;

        void Start()
        {
            FrameType = VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_YUV420;
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

                        _textureManager = _TextureManagerGameObject.AddComponent<TextureManagerYUV>();
                        _textureManager.SetVideoStreamIdentity(Uid, ChannelId, SourceType, FrameType);
                        _textureManager.EnableVideoFrameWithIdentity();
                    }
                    else
                    {
                        _textureManager = _TextureManagerGameObject.GetComponent<TextureManagerYUV>();
                    }
                }
                else
                {
                    if (this._textureWidth != _textureManager.Width || this._textureHeight != _textureManager.Height)
                    {
                        this._textureWidth = _textureManager.Width;
                        this._textureHeight = _textureManager.Height;

                        if (this._textureWidth != 0 && this._textureHeight != 0)
                        {
                            this.InvokeOnTextureSizeModify();
                        }
                    }

                    if (this._textureWidth != 0 && this._textureHeight != 0 && this.YStrideScale != ((TextureManagerYUV)_textureManager).YStrideScale)
                    {
                        if (_material != null)
                        {
                            _material.SetFloat("_yStrideScale", ((TextureManagerYUV)_textureManager).YStrideScale);
                        }
                        this.YStrideScale = ((TextureManagerYUV)_textureManager).YStrideScale;
                    }

                    if (!_hasAttach && _textureManager.CanTextureAttach())
                    {
                        // Only update shader if not using external materials
                        if (!_useExternalTargets || _externalMaterial == null)
                        {
                            UpdateShader();
                        }
                        ApplyTexture(((TextureManagerYUV)_textureManager).YTexture, ((TextureManagerYUV)_textureManager).UTexture, ((TextureManagerYUV)_textureManager).VTexture);
                        _textureManager.Attach();
                        _hasAttach = true;
                    }
                }

                if (_persistentBlitRT != null && _externalMaterial != null)
                {
                    // 每帧都使用Graphics.Blit应用材质效果到持久的RenderTexture
                    Graphics.Blit(_textureManager.Texture, _persistentBlitRT, _externalMaterial);
                }
            }
            else
            {
                if (_hasAttach && !IsBlankTexture())
                {
                    DestroyTextureManager();
                    ApplyTexture(null, null, null);
                }
            }
        }

        void OnDestroy()
        {
            AgoraLog.Log(string.Format("VideoSurface YUV channel: ${0}, user:{1} destroy", ChannelId, Uid));
            DestroyTextureManager();
        }

        protected override void CheckVideoSurfaceType()
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
                AgoraLog.LogError("Unable to find surface render in VideoSurfaceYUV component.");
            }
        }

        protected override bool IsBlankTexture()
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

        protected void ApplyTexture(Texture2D texture, Texture2D uTexture, Texture2D vTexture)
        {
            // Handle external rendering targets
            if (_useExternalTargets)
            {
                HandleExternalRendering(texture, uTexture, vTexture);
                // When using external targets, skip default rendering to avoid unnecessary overhead
                return;
            }

            // Default rendering behavior only when not using external targets
            if (VideoSurfaceType == VideoSurfaceType.Renderer)
            {
                var rd = _renderer as Renderer;
                rd.material.mainTexture = texture;
                rd.material.SetTexture("_UTex", uTexture);
                rd.material.SetTexture("_VTex", vTexture);
            }
            else if (VideoSurfaceType == VideoSurfaceType.RawImage)
            {
                var rd = _renderer as RawImage;
                rd.texture = texture;
                rd.material.SetTexture("_UTex", uTexture);
                rd.material.SetTexture("_VTex", vTexture);
            }
        }

        ///
        /// <summary>
        /// Handles rendering to external targets for YUV format (Y, U, V textures).
        /// </summary>
        ///
        /// <param name="yTexture"> The Y (luminance) texture. </param>
        /// <param name="uTexture"> The U (chrominance) texture. </param>
        /// <param name="vTexture"> The V (chrominance) texture. </param>
        ///
        protected virtual void HandleExternalRendering(Texture2D yTexture, Texture2D uTexture, Texture2D vTexture)
        {
            HandleExternalRenderingInternal(yTexture, (material) =>
            {
                // Set up U and V textures for YUV rendering
                if (uTexture != null) material.SetTexture("_UTex", uTexture);
                if (vTexture != null) material.SetTexture("_VTex", vTexture);
                if (_textureManager != null) material.SetFloat("_yStrideScale", ((TextureManagerYUV)_textureManager).YStrideScale);
            });
        }

        protected override void DestroyTextureManager()
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

        protected override void UpdateShader()
        {
            if (VideoSurfaceType == VideoSurfaceType.Renderer)
            {
                var rd = _renderer as Renderer;
                rd.material = new Material(Shader.Find("Unlit/RendererShader601"));
                _material = rd.material;
            }
            else if (VideoSurfaceType == VideoSurfaceType.RawImage)
            {
                var rd = _renderer as RawImage;
                rd.material = new Material(Shader.Find("UI/RendererShader601"));
                _material = rd.material;
            }

            _material.SetFloat("_yStrideScale", ((TextureManagerYUV)_textureManager).YStrideScale);
        }

        protected override void InvokeOnTextureSizeModify()
        {
            base.InvokeOnTextureSizeModify();

            // 创建或更新持久的RenderTexture
            EnsurePersistentBlitRT(_textureWidth, _textureHeight);
        }
    }
}

#endif
