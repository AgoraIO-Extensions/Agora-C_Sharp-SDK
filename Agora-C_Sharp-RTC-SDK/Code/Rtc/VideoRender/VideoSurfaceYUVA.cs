#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS

using UnityEngine;
using UnityEngine.UI;

namespace Agora.Rtc
{

    ///
    /// @ignore
    ///
    public class VideoSurfaceYUVA : VideoSurfaceYUV
    {
        protected TextureManagerYUVA _textureManagerYUVA;

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
                if (_textureManagerYUVA == null)
                {
                    string textureManagerName = this.GenerateTextureManagerUniqueName();
                    _TextureManagerGameObject = GameObject.Find(textureManagerName);

                    if (_TextureManagerGameObject == null)
                    {
                        _TextureManagerGameObject = new GameObject(textureManagerName);
                        _TextureManagerGameObject.hideFlags = HideFlags.HideInHierarchy;

                        _textureManagerYUVA = _TextureManagerGameObject.AddComponent<TextureManagerYUVA>();
                        _textureManagerYUVA.SetVideoStreamIdentity(Uid, ChannelId, SourceType, FrameType);
                        _textureManagerYUVA.EnableVideoFrameWithIdentity();
                    }
                    else
                    {
                        _textureManagerYUVA = _TextureManagerGameObject.GetComponent<TextureManagerYUVA>();
                    }
                }
                else if (_textureManagerYUVA && !_hasAttach && _textureManagerYUVA.CanTextureAttach())
                {
                    UpdateShader();
                    ApplyTexture(_textureManagerYUVA.YTexture, _textureManagerYUVA.UTexture, _textureManagerYUVA.VTexture, _textureManagerYUVA.ATexture);
                    _textureManagerYUVA.Attach();
                    _hasAttach = true;
                }

                if (_textureManagerYUVA)
                {
                    if (this._textureWidth != _textureManagerYUVA.Width || this._textureHeight != _textureManagerYUVA.Height)
                    {
                        this._textureWidth = _textureManagerYUVA.Width;
                        this._textureHeight = _textureManagerYUVA.Height;

                        if (this._textureWidth != 0 && this._textureHeight != 0)
                        {
                            this.InvokeOnTextureSizeModify();
                        }
                    }

                    if (this._textureWidth != 0 && this._textureHeight != 0 && this.YStrideScale != this._textureManagerYUVA.YStrideScale)
                    {
                        if (_material != null)
                        {
                            _material.SetFloat("_yStrideScale", _textureManagerYUVA.YStrideScale);
                        }
                        this.YStrideScale = this._textureManagerYUVA.YStrideScale;
                    }

                }
            }
            else
            {
                if (_hasAttach && !IsBlankTexture())
                {
                    DestroyTextureManager();
                    ApplyTexture(null, null, null, null);
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

        protected void ApplyTexture(Texture2D texture, Texture2D uTexture, Texture2D vTexture, Texture2D aTexture)
        {
            if (VideoSurfaceType == VideoSurfaceType.Renderer)
            {
                var rd = _renderer as Renderer;
                rd.material.mainTexture = texture;
                rd.material.SetTexture("_UTex", uTexture);
                rd.material.SetTexture("_VTex", vTexture);
                rd.material.SetTexture("_ATex", aTexture);
            }
            else if (VideoSurfaceType == VideoSurfaceType.RawImage)
            {
                var rd = _renderer as RawImage;
                rd.texture = texture;
                rd.material.SetTexture("_UTex", uTexture);
                rd.material.SetTexture("_VTex", vTexture);
                rd.material.SetTexture("_ATex", aTexture);
            }
        }

        protected override void DestroyTextureManager()
        {
            if (_textureManagerYUVA == null) return;

            if (_hasAttach == true)
            {
                _textureManagerYUVA.Detach();
                _hasAttach = false;
            }

            if (_textureManagerYUVA.GetRefCount() <= 0)
            {
                Destroy(_TextureManagerGameObject);
            }
            _textureManagerYUVA = null;
        }

        protected override void UpdateShader()
        {

            if (VideoSurfaceType == VideoSurfaceType.Renderer)
            {
                var rd = _renderer as Renderer;
                rd.material = new Material(Shader.Find("Unlit/RendererShader601WithAlpha"));
                _material = rd.material;
            }
            else if (VideoSurfaceType == VideoSurfaceType.RawImage)
            {
                var rd = _renderer as RawImage;
                rd.material = new Material(Shader.Find("UI/RendererShader601WithAlpha"));
                _material = rd.material;
            }

            _material.SetFloat("_yStrideScale", _textureManagerYUVA.YStrideScale);
        }

    }
}

#endif