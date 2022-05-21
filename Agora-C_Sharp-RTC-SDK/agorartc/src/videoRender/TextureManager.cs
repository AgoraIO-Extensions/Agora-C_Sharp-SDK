#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace agora.rtc
{
    internal class TextureManager : MonoBehaviour
    {
        // texture identity
        private int VideoPixelWidth = 1280;
        private int VideoPixelHeight = 720;
        private uint Uid = 0;
        private string ChannelId = "";
        private VIDEO_SOURCE_TYPE sourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;

        private bool _needResize = false;
        private bool _needUpdateInfo = true;
        private bool isFresh = false;

        private IVideoStreamManager _videoStreamManager;
        private IrisVideoFrame _cachedVideoFrame = new IrisVideoFrame();

        // reference count
        private int refCount = 0;

        private Texture2D _texture;
        public Texture2D texture
        {
            get 
            {
                refCount++;
                AgoraLog.Log("TextureManager refCount Add, Now is: " + refCount);
                return _texture;
            }
        }

        private void Awake()
        {
            InitTexture();
            InitIrisVideoFrame();
        }

        private void Update()
        {
            if (_needUpdateInfo) return;
            ReFreshTexture();
        }

        private void OnDestroy()
        {
            AgoraLog.Log(string.Format("VideoSurface channel: ${0}, user:{1} destroy", ChannelId, Uid));

            if (_videoStreamManager != null)
            {
                _videoStreamManager.DisableVideoFrameBuffer(sourceType, Uid, ChannelId);
                _videoStreamManager = null;
            }

            FreeMemory();
            DestroyTexture();
        }

        private void InitTexture()
        {
            try
            {
                _texture = new Texture2D(VideoPixelWidth, VideoPixelHeight, TextureFormat.RGBA32, false);
                _texture.Apply();
            }
            catch (Exception e)
            {
                AgoraLog.LogError("Exception e = " + e);
            }
        }

        private void InitIrisVideoFrame()
        {
            _cachedVideoFrame = new IrisVideoFrame
            {
                type = VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA,
                y_stride = VideoPixelWidth * 4,
                height = VideoPixelHeight,
                width = VideoPixelWidth,
                y_buffer = Marshal.AllocHGlobal(VideoPixelWidth * VideoPixelHeight * 4)
            };
            _cachedVideoFrame.y_buffer = IntPtr.Zero;
            _cachedVideoFrame.u_buffer = IntPtr.Zero;
            _cachedVideoFrame.v_buffer = IntPtr.Zero;
        }

        internal int GetRefCount()
        {
            return refCount;
        }

        internal void EnableVideoFrameWithIdentity()
        {
            var engine = AgoraRtcEngine.Get();
            if (engine != null)
            {
                if (_videoStreamManager == null)
                {
                    _videoStreamManager = ((AgoraRtcEngine) engine).GetVideoStreamManager();
                }

                if (_videoStreamManager != null)
                {
                    _videoStreamManager.EnableVideoFrameBuffer(sourceType, Uid, ChannelId);
                    _needUpdateInfo = false;
                }
            }
        }

        internal void ReFreshTexture()
        {
            var ret = _videoStreamManager.GetVideoFrame(ref _cachedVideoFrame, ref isFresh, sourceType, Uid, ChannelId);
            AgoraLog.LogWarning("GetVideoFrame" + ret + " width:" + _cachedVideoFrame.width + " height:" + _cachedVideoFrame.height);
            if (ret == IRIS_VIDEO_PROCESS_ERR.ERR_BUFFER_EMPTY)
            {
                AgoraLog.LogWarning(string.Format("no video frame for user channel: {0} uid: {1}", ChannelId, Uid));
                return;
            }
            else if (ret == IRIS_VIDEO_PROCESS_ERR.ERR_SIZE_NOT_MATCHING)
            {
                _needResize = true;
                VideoPixelWidth = _cachedVideoFrame.width;
                VideoPixelHeight = _cachedVideoFrame.height;
                FreeMemory();
                _cachedVideoFrame = new IrisVideoFrame
                {
                    type = VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA,
                    y_stride = VideoPixelWidth * 4,
                    height = VideoPixelHeight,
                    width = VideoPixelWidth,
                    y_buffer = Marshal.AllocHGlobal(VideoPixelWidth * VideoPixelHeight * 4)
                };
            }

            if (isFresh)
            {
                try
                {
                    if (_needResize)
                    {
                        _texture.Resize(VideoPixelWidth, VideoPixelHeight);
                        _texture.Apply();
                        _needResize = false;
                    }
                    else
                    {
                        _texture.LoadRawTextureData(_cachedVideoFrame.y_buffer,
                            (int) VideoPixelWidth * (int) VideoPixelHeight * 4);
                        _texture.Apply();
                    }
                }
                catch (Exception e)
                {
                    AgoraLog.Log("Exception e = " + e);
                }
            }
        }

        internal void SetVideoStreamIdentity(uint uid = 0, string channelId = "",
            VIDEO_SOURCE_TYPE source_type = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY)
        {
            Uid = uid;
            ChannelId = channelId;
            sourceType = source_type;
        }

        internal void Destroy()
        {
            AgoraLog.Log(string.Format("VideoSurface channel: ${0}, user:{1} destroy", ChannelId, Uid));

            refCount --;
            AgoraLog.Log("TextureManager refCount Minus, Now is: " + refCount);
            return;
        }

        private void DestroyTexture()
        {
            if (_texture != null)
            {
                GameObject.Destroy(_texture);
                _texture = null;
            }
        }

        private void FreeMemory()
        {
            if (_cachedVideoFrame.y_buffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_cachedVideoFrame.y_buffer);
            }
        }

    }
}
#endif