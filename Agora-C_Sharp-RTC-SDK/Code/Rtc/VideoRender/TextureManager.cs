#define USE_UNSAFE_CODE
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using System;
using System.Runtime.InteropServices;

#if USE_UNSAFE_CODE && UNITY_2018_1_OR_NEWER
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
#endif

using UnityEngine;

namespace Agora.Rtc
{
    public class TextureManager : MonoBehaviour
    {
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
        protected bool isFresh = false;

        protected IVideoStreamManager _videoStreamManager;
        protected IrisCVideoFrame _cachedVideoFrame;

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

#if USE_UNSAFE_CODE && UNITY_2018_1_OR_NEWER
        protected NativeArray<byte> _textureNative;
#endif

        protected virtual void Awake()
        {
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
                _videoStreamManager.DisableVideoFrameBuffer(_sourceType, _uid, _channelId, _frameType);
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
            _cachedVideoFrame = new IrisCVideoFrame
            {
                type = (int)VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA,
                yStride = _videoPixelWidth * 4,
                uStride = 0,
                vStride = 0,
                height = _videoPixelHeight,
                width = _videoPixelWidth
            };
#if USE_UNSAFE_CODE && UNITY_2018_1_OR_NEWER

            _textureNative = _texture.GetRawTextureData<byte>();
            unsafe
            {
                _cachedVideoFrame.yBuffer = (IntPtr)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(_textureNative);
            }
#else

            _cachedVideoFrame.yBuffer = Marshal.AllocHGlobal(_videoPixelWidth * _videoPixelHeight * 4);
           
#endif
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
                    _videoStreamManager.EnableVideoFrameBuffer(_sourceType, _uid, _channelId, _frameType);
                    _needUpdateInfo = false;
                }
            }
        }

        internal virtual void ReFreshTexture()
        {
            var ret = _videoStreamManager.GetVideoFrame(ref _cachedVideoFrame, ref isFresh, _sourceType, _uid, _channelId, _frameType);

            if (ret == IRIS_VIDEO_PROCESS_ERR.ERR_NO_CACHE)
            {
                _canAttach = false;
                return;
            }

            else if (ret == IRIS_VIDEO_PROCESS_ERR.ERR_RESIZED)
            {
                _videoPixelWidth = _cachedVideoFrame.width;
                _videoPixelHeight = _cachedVideoFrame.height;

#if USE_UNSAFE_CODE && UNITY_2018_1_OR_NEWER
                _cachedVideoFrame.type = (int)VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA;
#if UNITY_2021_2_OR_NEWER
                _texture.Reinitialize(_videoPixelWidth, _videoPixelHeight);
#else
                _texture.Resize(_videoPixelWidth, _videoPixelHeight);
#endif
                _texture.Apply();
                _textureNative = _texture.GetRawTextureData<byte>();
                unsafe
                {
                    _cachedVideoFrame.yBuffer = (IntPtr)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(_textureNative);
                }
#else

                _needResize = true;
                FreeMemory();
                _cachedVideoFrame.type = (int)VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA;
                _cachedVideoFrame.yBuffer = Marshal.AllocHGlobal(_videoPixelWidth * _videoPixelHeight * 4);
                return;
#endif
            }
            else
            {
                _canAttach = true;
            }


            if (isFresh == false)
            {
                return;
            }

            try
            {
#if USE_UNSAFE_CODE && UNITY_2018_1_OR_NEWER
                _texture.Apply();
#else
                if (_needResize)
                {
#if UNITY_2021_2_OR_NEWER
                    _texture.Reinitialize(_videoPixelWidth, _videoPixelHeight);
#else
                    _texture.Resize(_videoPixelWidth, _videoPixelHeight);
#endif
                    _texture.Apply();
                    _needResize = false;
                }

                _texture.LoadRawTextureData(_cachedVideoFrame.yBuffer,
                    (int)_videoPixelWidth * (int)_videoPixelHeight * 4);
                _texture.Apply();
#endif


            }
            catch (Exception e)
            {
                AgoraLog.Log("Exception e = " + e);
            }

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
#if USE_UNSAFE_CODE && UNITY_2018_1_OR_NEWER
            _cachedVideoFrame.yBuffer = IntPtr.Zero;
#else
            if (_cachedVideoFrame.yBuffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_cachedVideoFrame.yBuffer);
                _cachedVideoFrame.yBuffer = IntPtr.Zero;
            }
#endif
        }

    }
}

#endif