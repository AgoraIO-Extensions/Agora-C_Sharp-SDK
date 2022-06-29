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

    public sealed class VideoSurface : MonoBehaviour
    {
        [SerializeField] private VideoSurfaceType VideoSurfaceType = VideoSurfaceType.Renderer;
        [SerializeField] private bool Enable = true;
   
        [SerializeField] private uint Uid = 0;
        [SerializeField] private string ChannelId = "";
        [SerializeField] private VIDEO_SOURCE_TYPE SourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;

        private Component _renderer;
        private bool _needUpdateInfo = true;
        private bool _hasAttach = false;

        private GameObject _TextureManagerGameObject;
        private TextureManager _textureManager;
        private int _textureWidth = 0;
        private int _textureHeight = 0;

        public event OnTextureSizeModifyHandler OnTextureSizeModify;

        void Start()
        {
            CheckVideoSurfaceType();
        }

        void Update()
        {
            if (_renderer == null || _needUpdateInfo) return;

            if (Enable)
            {
                if (_textureManager == null)
                {
                    _TextureManagerGameObject = GameObject.Find("TextureManager" + Uid.ToString() + ChannelId + SourceType.ToString());

                    if (_TextureManagerGameObject == null)
                    {
                        _TextureManagerGameObject = new GameObject("TextureManager" + Uid.ToString() + ChannelId + SourceType.ToString());
                        _TextureManagerGameObject.hideFlags = HideFlags.HideInHierarchy;

                        _textureManager = _TextureManagerGameObject.AddComponent<TextureManager>();
                        _textureManager.SetVideoStreamIdentity(Uid, ChannelId, SourceType);
                        _textureManager.EnableVideoFrameWithIdentity();
                    }
                    else
                    {
                        _textureManager = _TextureManagerGameObject.GetComponent<TextureManager>();
                    }
                }
                else if(_textureManager && !_hasAttach && _textureManager.CanTextureAttach())
                {
                    ApplyTexture(_textureManager.Texture);
                    _hasAttach = true;
                }

                if (_textureManager && (this._textureWidth != _textureManager.Width || this._textureHeight != _textureManager.Height))
                {
                    this._textureWidth = _textureManager.Width;
                    this._textureHeight = _textureManager.Height;
                    if (this._textureWidth != 0 && this._textureHeight != 0 && this.OnTextureSizeModify!= null)
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

        void OnDestroy()
        {
            AgoraLog.Log(string.Format("VideoSurface channel: ${0}, user:{1} destroy", ChannelId, Uid));
            DestroyTextureManager();
        }

        private void CheckVideoSurfaceType()
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
                // this only applies to Editor, in case of material is too dark
                UpdateShader();
#endif
            }
        }

        private void DestroyTextureManager()
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

        private bool IsBlankTexture()
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

        private void ApplyTexture(Texture2D texture)
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

        private void UpdateShader()
        {
            var mesh = GetComponent<MeshRenderer>();
            if (mesh != null)
            {
                mesh.material = new Material(Shader.Find("Unlit/Texture"));
            }
        }

        public void SetForUser(uint uid = 0, string channelId = "",
            VIDEO_SOURCE_TYPE source_type = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY)
        {
            Uid = uid;
            ChannelId = channelId;
            SourceType = source_type;
            _needUpdateInfo = false;
        }

        public void SetEnable(bool enable)
        {
            Enable = enable;
        }
    }
}

#endif
