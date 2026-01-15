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

        // Per-instance render stat tracker
        protected RenderStatTracker _renderStatTracker;

        protected Texture2D _texture;
        public Texture2D Texture
        {
            get
            {
                return _texture;
            }
        }

        public IrisColorSpace ColorSpace
        {
            get
            {
                return _cachedVideoFrame.colorSpace;
            }
        }

        /// <summary>
        /// Gets the color space information as a C# ColorSpace object
        /// </summary>
        public ColorSpace GetColorSpaceInfo()
        {
            return _cachedVideoFrame.colorSpace.ToColorSpace();
        }

#if USE_UNSAFE_CODE && UNITY_2018_1_OR_NEWER
        protected NativeArray<byte> _textureNative;
#endif

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

            // Tick the render stat tracker to check and report metrics
            if (_renderStatTracker != null)
            {
                _renderStatTracker.Tick();
            }
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

                    // Initialize render stat tracker
                    if (_renderStatTracker == null)
                    {
                        _renderStatTracker = new RenderStatTracker(_uid, _channelId, _sourceType);
                    }
                }
            }
        }

        internal virtual void ReFreshTexture()
        {
            float getFrameStartTime;
            var ret = _videoStreamManager.GetVideoFrame(ref _cachedVideoFrame, ref isFresh, _sourceType, _uid, _channelId, _frameType, out getFrameStartTime);

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
                // ✅ Use the start time from GetVideoFrame instead of measuring here
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
                // ✅ Calculate draw cost from GetVideoFrame start time to now
                var endTime = Time.realtimeSinceStartup;
                var cost = (endTime - getFrameStartTime) * 1000.0f;

                // Log to per-instance tracker only
                if (_renderStatTracker != null)
                {
                    _renderStatTracker.LogDrawCost(cost);
                    _renderStatTracker.LogOutFrame();
                }

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

        /// <summary>
        /// Update connection information and propagate to RenderStatTracker
        /// This is useful when OnLocalVideoStats or other callbacks provide updated connection info
        /// </summary>
        /// <param name="uid">User ID</param>
        /// <param name="channelId">Channel ID</param>
        /// <param name="sourceType">Video source type</param>
        public void UpdateConnectionInfo(uint uid, string channelId, VIDEO_SOURCE_TYPE sourceType)
        {
            // ?? IMPORTANT: Do NOT update _uid, _channelId, _sourceType here!
            // These values are used as keys to fetch video frames from VideoStreamManager.
            // Changing them will cause ERR_NO_CACHE because the cache keys won't match.

            // Only propagate the updated info to RenderStatTracker for reporting purposes
            if (_renderStatTracker != null)
            {
                _renderStatTracker.UpdateConnectionInfo(uid, channelId, sourceType);
            }
        }

        /// <summary>
        /// Enable or disable metric reporting for this TextureManager instance
        /// </summary>
        /// <param name="enable">True to enable reporting, false to disable</param>
        public void SetEnableMetricReporting(bool enable)
        {
            if (_renderStatTracker != null)
            {
                _renderStatTracker.SetEnableReporting(enable);
                AgoraLog.Log($"TextureManager (UID: {_uid}): Metric reporting {(enable ? "enabled" : "disabled")}");
            }
        }

        /// <summary>
        /// Check if metric reporting is enabled for this instance
        /// </summary>
        public bool IsMetricReportingEnabled()
        {
            return _renderStatTracker != null && _renderStatTracker.IsReportingEnabled();
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