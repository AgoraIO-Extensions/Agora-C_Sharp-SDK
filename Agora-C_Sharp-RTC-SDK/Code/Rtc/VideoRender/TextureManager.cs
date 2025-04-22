#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using System;
using System.Runtime.InteropServices;

#if USE_UNSAFE_CODE && UNITY_2018_1_OR_NEWER
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
#endif

using UnityEngine;
using UnityEngine.UIElements;

namespace Agora.Rtc
{
    public class TextureManager : MonoBehaviour
    {
        protected class TextureVideoFrame
        {
            public int type;
            public int width;
            public int height;
            public int yStride;
            public int uStride;
            public int vStride;
            public byte[] yBuffer;
            public byte[] uBuffer;
            public byte[] vBuffer;
            public byte[] alphaBuffer;
        }

        // texture identity
        protected int _videoPixelWidth = 2;
        protected int _videoPixelHeight = 2;
        //texture width and height
        public int Width
        {
            get
            {
                return _videoPixelWidth;
            }
        }
        public int Height
        {
            get
            {
                return _videoPixelHeight;
            }
        }

        protected uint _uid = 0;
        protected string _channelId = "";
        protected VIDEO_SOURCE_TYPE _sourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
        protected VIDEO_OBSERVER_FRAME_TYPE _frameType = VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA;

        protected bool _needResize = false;
        protected bool _needUpdateInfo = true;
        protected bool _isFresh = false;

        protected IVideoStreamManager _videoStreamManager;
        protected TextureVideoFrame _cachedVideoFrame;
        internal IrisRtcVideoFrameConfig _videoFrameConfig;
        protected System.Object _videoFrameLock = new System.Object();

        // reference count
        protected int _refCount = 0;
        protected bool _canAttach = false;


        protected Texture2D _texture;
        public Texture2D Texture
        {
            get
            {
                return _texture;
            }
        }

        protected virtual void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            InitTexture();
            InitIrisVideoFrame();
        }

        protected virtual void Update()
        {
            if (_needUpdateInfo) return;
            ReFreshTexture();
        }

        protected virtual void OnDestroy()
        {
            AgoraLog.Log(string.Format("VideoSurface channel: ${0}, user:{1} destroy", _channelId, _uid));

            if (_videoStreamManager != null)
            {
                _videoStreamManager.RemoveVideoFrameObserverDelegate();
                _videoStreamManager.Dispose();
                _videoStreamManager = null;
            }
            FreeMemory();
            DestroyTexture();
        }

        internal virtual void InitTexture()
        {
            try
            {
                _texture = new Texture2D(_videoPixelWidth, _videoPixelHeight, TextureFormat.RGBA32, false);
                _texture.Apply();
            }
            catch (Exception e)
            {
                AgoraLog.LogError("Exception e = " + e);
            }
        }

        internal virtual void InitIrisVideoFrame()
        {
            _cachedVideoFrame = new TextureVideoFrame
            {
                type = (int)VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA,
                yStride = _videoPixelWidth * 4,
                uStride = 0,
                vStride = 0,
                height = _videoPixelHeight,
                width = _videoPixelWidth
            };
        }

        internal int GetRefCount()
        {
            return _refCount;
        }

        internal bool CanTextureAttach()
        {
            return _canAttach;
        }

        internal void EnableVideoFrameWithIdentity()
        {
            var engine = RtcEngineImpl.Get();
            if (engine != null)
            {
                if (_videoStreamManager == null)
                {
                    _videoStreamManager = ((RtcEngineImpl)engine).GetVideoStreamManager(this);
                }

                if (_videoStreamManager != null)
                {
                    _videoFrameConfig = new IrisRtcVideoFrameConfig()
                    {
                        video_view_setup_mode = 0,
                        observed_frame_position = (uint)(VideoStreamManager.position | VIDEO_MODULE_POSITION.POSITION_PRE_RENDERER),
                        video_source_type = (int)_sourceType,
                        video_frame_format = (int)_frameType,
                        uid = _uid,
                        channelId = _channelId,
                    };
                    _videoStreamManager.AddVideoFrameObserverDelegate(ref _videoFrameConfig);
                    _needUpdateInfo = false;
                }
            }
        }

        internal virtual void ReFreshTexture()
        {
            TimeConsuming.End(1, "TextureRGBA onVideoFame_finsih -> refresh start");
            TimeConsuming.Start(2);
            TextureVideoFrame tempVideoFrame = null;

            lock (_videoFrameLock)
            {
                if (_isFresh)
                {
                    tempVideoFrame = _cachedVideoFrame;
                    _isFresh = false;
                }
                else
                {
                    return;
                }
            }

            _canAttach = true;
            if (tempVideoFrame.width != _videoPixelWidth || tempVideoFrame.height != _videoPixelHeight)
            {
                _videoPixelWidth = tempVideoFrame.width;
                _videoPixelHeight = tempVideoFrame.height;
#if UNITY_2021_2_OR_NEWER
                _texture.Reinitialize(_videoPixelWidth, _videoPixelHeight);
#else
                _texture.Resize(_videoPixelWidth, _videoPixelHeight);
#endif
            }
            _texture.LoadRawTextureData(tempVideoFrame.yBuffer);
            _texture.Apply();
            TimeConsuming.End(2, "TextureRGBA: refresh start -> refresh end");
        }

        internal void SetVideoStreamIdentity(uint uid = 0, string channelId = "",
            VIDEO_SOURCE_TYPE source_type = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY,
            VIDEO_OBSERVER_FRAME_TYPE frameType = VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA)
        {
            _uid = uid;
            _channelId = channelId;
            _sourceType = source_type;
            _frameType = frameType;
        }


        virtual internal void Attach()
        {
            _refCount++;
            AgoraLog.Log("TextureManager RGBA refCount Add, Now is: " + _refCount);
        }

        virtual internal void Detach()
        {
            if (_refCount > 0)
            {
                _refCount--;
                AgoraLog.Log("TextureManager RGBA refCount Minus, Now is: " + _refCount);
            }
            return;
        }

        protected virtual void DestroyTexture()
        {
            if (_texture != null)
            {
                GameObject.Destroy(_texture);
                _texture = null;
            }
        }

        private void FreeMemory()
        {

        }

        internal virtual void OnVideoFameEvent(ref IrisCVideoFrame videoFrame, ref IrisRtcVideoFrameConfig config, bool resize)
        {
            if (_videoFrameConfig.video_source_type != config.video_source_type)
                return;
            if (_videoFrameConfig.video_frame_format != config.video_frame_format)
                return;
            if (_videoFrameConfig.uid != config.uid)
                return;
            if (_videoFrameConfig.channelId != config.channelId)
                return;


            TextureVideoFrame tempVideoFrame = new TextureVideoFrame()
            {
                type = (int)videoFrame.type,
                width = videoFrame.width,
                height = videoFrame.height,
                yStride = videoFrame.yStride,
                uStride = videoFrame.uStride,
                vStride = videoFrame.vStride
            };
            int length = videoFrame.width * videoFrame.height * 4;
            tempVideoFrame.yBuffer = new byte[length];
            Marshal.Copy(videoFrame.yBuffer, tempVideoFrame.yBuffer, 0, length);
            lock (_videoFrameLock)
            {
                _cachedVideoFrame = tempVideoFrame;
                _isFresh = true;
            }

            TimeConsuming.Start(1);
        }

    }
}

#endif