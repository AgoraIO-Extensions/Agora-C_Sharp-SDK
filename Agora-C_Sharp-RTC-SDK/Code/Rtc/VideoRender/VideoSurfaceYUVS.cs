#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID

using UnityEngine;
using UnityEngine.UI;

namespace Agora.Rtc
{

    ///
    /// <summary>
    /// Porivdes APIs for rendering videos. This class inherits all APIs from the VideoSurface class, but enables you to render video images with high resolutions (such as 4K) faster and at higher frame rates. The SDK supports using different VideoSurface to render different video sources; for example, using VideoSurface to render the video images of user A and VideoSurfaceYUV for user B. Note that video images from the same video source can only be rendered either through VideoSurface or VideoSurfaceYUV.
    /// </summary>
    ///
    public class VideoSurfaceYUVS : VideoSurfaceS
    {
        protected TextureManagerYUVS _textureManagerYUV;
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
                if (_textureManagerYUV == null)
                {
                    string textureManagerName = this.GenerateTextureManagerUniqueName();
                    _TextureManagerGameObject = GameObject.Find(textureManagerName);

                    if (_TextureManagerGameObject == null)
                    {
                        _TextureManagerGameObject = new GameObject(textureManagerName);
                        _TextureManagerGameObject.hideFlags = HideFlags.HideInHierarchy;

                        _textureManagerYUV = _TextureManagerGameObject.AddComponent<TextureManagerYUVS>();
                        _textureManagerYUV.SetVideoStreamIdentity(UserAccount, ChannelId, SourceType, FrameType);
                        _textureManagerYUV.EnableVideoFrameWithIdentity();
                    }
                    else
                    {
                        _textureManagerYUV = _TextureManagerGameObject.GetComponent<TextureManagerYUVS>();
                    }
                }
                else if (_textureManagerYUV && !_hasAttach && _textureManagerYUV.CanTextureAttach())
                {
                    UpdateShader();
                    ApplyTexture(_textureManagerYUV.YTexture, _textureManagerYUV.UTexture, _textureManagerYUV.VTexture);
                    _textureManagerYUV.Attach();
                    _hasAttach = true;
                }

                if (_textureManagerYUV)
                {
                    if (this._textureWidth != _textureManagerYUV.Width || this._textureHeight != _textureManagerYUV.Height)
                    {
                        this._textureWidth = _textureManagerYUV.Width;
                        this._textureHeight = _textureManagerYUV.Height;

                        if (this._textureWidth != 0 && this._textureHeight != 0)
                        {
                            this.InvokeOnTextureSizeModify();
                        }
                    }

                    if (this._textureWidth != 0 && this._textureHeight != 0 && this.YStrideScale != this._textureManagerYUV.YStrideScale)
                    {
                        _material.SetFloat("_yStrideScale", _textureManagerYUV.YStrideScale);
                        //AgoraLog.Log("_yStrideScale" + _textureManagerYUV.YStrideScale);
                        this.YStrideScale = this._textureManagerYUV.YStrideScale;
                    }

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
            AgoraLog.Log(string.Format("VideoSurface YUV channel: ${0}, userAccount:{1} destroy", ChannelId, UserAccount));
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
                AgoraLog.LogError("Unable to find surface render in VideoSurfaceYUVS component.");
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

        protected override void DestroyTextureManager()
        {
            if (_textureManagerYUV == null) return;

            if (_hasAttach == true)
            {
                _textureManagerYUV.Detach();
                _hasAttach = false;
            }

            if (_textureManagerYUV.GetRefCount() <= 0)
            {
                Destroy(_TextureManagerGameObject);
            }
            _textureManagerYUV = null;
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
        }

    }
}

#endif