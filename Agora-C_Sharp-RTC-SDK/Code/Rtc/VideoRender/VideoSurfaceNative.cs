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
        public TextureManagerNative _textureManagerNative;
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
                if (_textureManagerNative == null)
                {
                    string textureManagerName = this.GenerateTextureManagerUniqueName();
                    _TextureManagerGameObject = GameObject.Find(textureManagerName);

                    if (_TextureManagerGameObject == null)
                    {
                        _TextureManagerGameObject = new GameObject(textureManagerName);
                        _TextureManagerGameObject.hideFlags = HideFlags.HideInHierarchy;

                        _textureManagerNative = _TextureManagerGameObject.AddComponent<TextureManagerNative>();
                        _textureManagerNative.SetVideoStreamIdentity(Uid, ChannelId, SourceType, FrameType);
                        _textureManagerNative.EnableVideoFrameWithIdentity();
                    }
                    else
                    {
                        _textureManagerNative = _TextureManagerGameObject.GetComponent<TextureManagerNative>();
                    }
                }
                else if (_textureManagerNative && !_hasAttach && _textureManagerNative.CanTextureAttach())
                {
                    ApplyTexture(_textureManagerNative.Texture);
                    _textureManagerNative.Attach();
                    _hasAttach = true;
                }

                if (_textureManagerNative)
                {
                    if (this._textureWidth != _textureManagerNative.Width || this._textureHeight != _textureManagerNative.Height)
                    {
                        this._textureWidth = _textureManagerNative.Width*2;
                        this._textureHeight = _textureManagerNative.Height*2;

                        if (this._textureWidth != 0 && this._textureHeight != 0)
                        {
                            AgoraLog.Log($"原生纹理尺寸已更新: {_textureWidth}x{_textureHeight}");
                            this.InvokeOnTextureSizeModify();
                        }
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
            else
            {
                UpdateShader();
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

        protected virtual void ApplyTexture(Texture2D texture)
        {
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
            if (_textureManagerNative == null) return;

            if (_hasAttach == true)
            {
                _textureManagerNative.Detach();
                _hasAttach = false;
            }

            if (_textureManagerNative.GetRefCount() <= 0)
            {
                Destroy(_TextureManagerGameObject);
            }
            _textureManagerNative = null;
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

        protected override string GenerateTextureManagerUniqueName()
        {
            return "TextureManagerNative" + "_" + Uid.ToString() + "_" + ChannelId + "_" + SourceType.ToString() + "_" + FrameType.ToString();
        }
    }
}

#endif
