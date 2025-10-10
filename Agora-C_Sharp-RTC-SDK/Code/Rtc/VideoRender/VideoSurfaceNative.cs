#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS

using UnityEngine;
using UnityEngine.UI;
using System;

namespace Agora.Rtc
{
    ///
    /// <summary>
    /// 专门用于处理原生纹理渲染的VideoSurface组件
    /// VideoSurface component specifically for handling native texture rendering
    /// </summary>
    ///
    public class VideoSurfaceNative : VideoSurface
    {
        public Material _material = null;

        void Start()
        {
            FrameType = VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_TEXTURE_2D;
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

                        _textureManager = _TextureManagerGameObject.AddComponent<TextureManagerNative>();
                        _textureManager.SetVideoStreamIdentity(Uid, ChannelId, SourceType, FrameType);
                        _textureManager.EnableVideoFrameWithIdentity();
                    }
                    else
                    {
                        _textureManager = _TextureManagerGameObject.GetComponent<TextureManagerNative>();
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

                    if (!_hasAttach && _textureManager.CanTextureAttach())
                    {
                        // Only update shader if not using external materials
                        if (!_useExternalTargets || _externalMaterial == null)
                        {
                            UpdateShader();
                        }
                        ApplyTexture(_textureManager.Texture);
                        _textureManager.Attach();
                        _hasAttach = true;
                    }
                }
            }
            else
            {
                if (_hasAttach && !IsBlankTexture())
                {
                    DestroyTextureManager();
                    ApplyTexture(null);
                }
            }
        }

        void OnDestroy()
        {
            AgoraLog.Log(string.Format("VideoSurface Native channel: ${0}, user:{1} destroy", ChannelId, Uid));
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
                AgoraLog.LogError("Unable to find surface render in VideoSurfaceNative component.");
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

        protected override void ApplyTexture(Texture2D texture)
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
                rd.material = new Material(Shader.Find("Unlit/Texture"));
                _material = rd.material;
            }
            else if (VideoSurfaceType == VideoSurfaceType.RawImage)
            {
                var rd = _renderer as RawImage;
                // RawImage通常不需要特殊的shader
                _material = rd.material;
            }
        }
    }
}

#endif
