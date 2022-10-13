#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Agora.Rtc
{
    internal class TextureManager : MonoBehaviour
    {
        // texture identity
        private int _videoPixelWidth = 0;
        private int _videoPixelHeight = 0;
        private uint _uid = 0;
        private string _channelId = "";
        private VIDEO_SOURCE_TYPE _sourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;

        private bool _needResize = false;
        private bool _needUpdateInfo = true;
        private bool isFresh = false;

        private IVideoStreamManager _videoStreamManager;
        private IrisVideoFrame _cachedVideoFrame = new IrisVideoFrame();

        // reference count
        private int _refCount = 0;
        private bool _canAttach = false;

        //texture width and height
        public int Width = 0;
        public int Height = 0;

        private Texture2D _texture;
        public Texture2D Texture
        {
            get
            {
                _refCount++;
                AgoraLog.Log("TextureManager refCount Add, Now is: " + _refCount);
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
            AgoraLog.Log(string.Format("VideoSurface channel: ${0}, user:{1} destroy", _channelId, _uid));

            if (_videoStreamManager != null)
            {
                _videoStreamManager.DisableVideoFrameBuffer(_sourceType, _uid, _channelId);
                _videoStreamManager.Dispose();
                _videoStreamManager = null;
            }

            FreeMemory();
            DestroyTexture();
        }

        private void InitTexture()
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

        private void InitIrisVideoFrame()
        {
            _cachedVideoFrame = new IrisVideoFrame
            {
                type = VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA,
                y_stride = _videoPixelWidth * 4,
                height = _videoPixelHeight,
                width = _videoPixelWidth,
                y_buffer = Marshal.AllocHGlobal(_videoPixelWidth * _videoPixelHeight * 4)
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
                    _videoStreamManager = ((RtcEngineImpl)engine).GetVideoStreamManager();
                }

                if (_videoStreamManager != null)
                {
                    _videoStreamManager.EnableVideoFrameBuffer(_sourceType, _uid, _channelId);
                    _needUpdateInfo = false;
                }
            }
        }

        internal void ReFreshTexture()
        {
            var ret = _videoStreamManager.GetVideoFrame(ref _cachedVideoFrame, ref isFresh, _sourceType, _uid, _channelId);
            this.Width = _cachedVideoFrame.width;
            this.Height = _cachedVideoFrame.height;

            if (ret == IRIS_VIDEO_PROCESS_ERR.ERR_BUFFER_EMPTY || ret == IRIS_VIDEO_PROCESS_ERR.ERR_NULL_POINTER)
            {
                _canAttach = false;
                //AgoraLog.LogWarning(string.Format("no video frame for user channel: {0} uid: {1}", _channelId, _uid));
                return;
            }
            else if (ret == IRIS_VIDEO_PROCESS_ERR.ERR_SIZE_NOT_MATCHING)
            {
                _needResize = true;
                _videoPixelWidth = _cachedVideoFrame.width;
                _videoPixelHeight = _cachedVideoFrame.height;
                FreeMemory();

                _cachedVideoFrame.type = VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA;
                _cachedVideoFrame.y_stride = _videoPixelWidth * 4;
                _cachedVideoFrame.height = _videoPixelHeight;
                _cachedVideoFrame.width = _videoPixelWidth;
                _cachedVideoFrame.y_buffer = Marshal.AllocHGlobal(_videoPixelWidth * _videoPixelHeight * 4);
            }
            else
            {
                _canAttach = true;
            }

            if (isFresh)
            {
                try
                {
                    if (_needResize)
                    {
                        _texture.Resize(_videoPixelWidth, _videoPixelHeight);
                        _texture.Apply();
                        _needResize = false;
                    }
                    else
                    {
                        _texture.LoadRawTextureData(_cachedVideoFrame.y_buffer,
                            (int)_videoPixelWidth * (int)_videoPixelHeight * 4);
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
            _uid = uid;
            _channelId = channelId;
            _sourceType = source_type;
        }

        internal void Detach()
        {
            if (_refCount > 0)
            {
                _refCount--;
                AgoraLog.Log("TextureManager refCount Minus, Now is: " + _refCount);
            }
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