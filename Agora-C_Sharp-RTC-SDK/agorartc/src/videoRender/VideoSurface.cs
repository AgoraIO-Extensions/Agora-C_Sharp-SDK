#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 

using UnityEngine;
using UnityEngine.UI;

namespace agora.rtc
{
    public enum AgoraVideoSurfaceType
    {
        Renderer = 0,
        RawImage = 1,
    };

    public sealed class AgoraVideoSurface : MonoBehaviour
    {
        [SerializeField] private AgoraVideoSurfaceType VideoSurfaceType = AgoraVideoSurfaceType.Renderer;
        [SerializeField] private bool Enable = true;
        [SerializeField] private bool FlipX = false;
        [SerializeField] private bool FlipY = false;
        [SerializeField] private int VideoPixelWidth = 0;
        [SerializeField] private int VideoPixelHeight = 0;
        [SerializeField] private uint Uid = 0;
        [SerializeField] private string ChannelId = "";
        [SerializeField] private VIDEO_SOURCE_TYPE sourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;

        private Component _renderer;
        private bool _needUpdateInfo = true;

        private GameObject _TextureManagerGameObject;
        private TextureManager _textureManager;
        private Texture2D _texture;


        void Start()
        {
            CheckVideoSurfaceType();
        }

        void Update()
        {
            if (_renderer == null || _needUpdateInfo) return;

            if (Enable)
            {
                if (IsBlankTexture())
                {
                    _TextureManagerGameObject = GameObject.Find("TextureManager" + Uid.ToString() + ChannelId + sourceType.ToString());

                    if (_TextureManagerGameObject == null)
                    {
                        _TextureManagerGameObject = new GameObject("TextureManager" + Uid.ToString() + ChannelId + sourceType.ToString());
                        _TextureManagerGameObject.hideFlags = HideFlags.HideInHierarchy;

                        _textureManager = _TextureManagerGameObject.AddComponent<TextureManager>();
                        _texture = GetTexture();
                    }
                    else
                    {
                        _textureManager = _TextureManagerGameObject.GetComponent<TextureManager>();
                        _texture = _textureManager.texture;
                    }
                    ApplyTexture(_texture);
                }
            }
            else
            {
                if (!IsBlankTexture())
                {
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
            if (VideoSurfaceType == AgoraVideoSurfaceType.Renderer)
            {
                _renderer = GetComponent<Renderer>();
            }

            if (_renderer == null || VideoSurfaceType == AgoraVideoSurfaceType.RawImage)
            {
                _renderer = GetComponent<RawImage>();
                if (_renderer != null)
                {
                    VideoSurfaceType = AgoraVideoSurfaceType.RawImage;
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

        private Texture2D GetTexture()
        {
            _textureManager.SetVideoStreamIdentity(Uid, ChannelId, sourceType);
            _textureManager.EnableVideoFrameWithIdentity();
            return _textureManager.texture;
        }

        private void DestroyTextureManager()
        {
            if (_textureManager == null) return;
            _textureManager.Destroy();
            if (_textureManager.GetRefCount() == 0)
            {
                Destroy(_TextureManagerGameObject);
            }
            _textureManager = null;
        }

        private bool IsBlankTexture()
        {
            if (VideoSurfaceType == AgoraVideoSurfaceType.Renderer)
            {
                var rd = (_renderer as Renderer);
                return rd.material.mainTexture == null || !(rd.material.mainTexture is Texture2D);
            }
            else if (VideoSurfaceType == AgoraVideoSurfaceType.RawImage)
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
            if (VideoSurfaceType == AgoraVideoSurfaceType.Renderer)
            {
                var rd = _renderer as Renderer;
                rd.material.mainTexture = texture;
            }
            else if (VideoSurfaceType == AgoraVideoSurfaceType.RawImage)
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
            sourceType = source_type;
            _needUpdateInfo = false;
        }

        public void EnableFilpTextureApply(bool flipX, bool flipY)
        {
            if (FlipX != flipX)
            {
                transform.localScale =
                    new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                FlipX = flipX;
            }

            if (FlipY != flipY)
            {
                transform.localScale =
                    new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
                FlipY = flipY;
            }
        }

        public void SetEnable(bool enable)
        {
            Enable = enable;
        }
    }
}

#endif
