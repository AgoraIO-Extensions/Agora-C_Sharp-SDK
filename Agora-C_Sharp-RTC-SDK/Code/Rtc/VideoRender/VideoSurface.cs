#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID

using UnityEngine;
using UnityEngine.UI;

namespace Agora.Rtc
{
    public enum VideoSurfaceType
    {
        Renderer = 0,
        RawImage = 1,
    };

    public delegate void OnTextureSizeModifyHandler(int width, int height);

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
        protected int _textureWidth = 0;
        protected int _textureHeight = 0;

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
                UpdateShader();
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

        protected virtual void UpdateShader()
        {
            var mesh = GetComponent<MeshRenderer>();
            if (mesh != null)
            {
                Debug.LogWarning("VideoSureface update shader");
                mesh.material = new Material(Shader.Find("Unlit/Texture"));
            }
        }

        public virtual void SetForUser(uint uid = 0, string channelId = "", VIDEO_SOURCE_TYPE source_type = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY)
        {
            Uid = uid;
            ChannelId = uid == 0 ? "" : channelId;
            SourceType = source_type;
            _needUpdateInfo = false;
        }

        public virtual void SetEnable(bool enable)
        {
            Enable = enable;
        }

        virtual protected string GenerateTextureManagerUniqueName()
        {
            return "TextureManager" + "_" + Uid.ToString() + "_" + ChannelId + "_" + SourceType.ToString() + "_" + FrameType.ToString();
        }

    }
}

#endif