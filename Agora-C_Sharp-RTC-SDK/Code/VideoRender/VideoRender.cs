#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_WEBGL

using System;

namespace Agora.Rtc
{
#if UNITY_WEBGL
    using IrisVideoFrameBufferHandle = System.Int32;
#else
    using IrisVideoFrameBufferHandle = IntPtr;
#endif
    internal abstract class IVideoStreamManager
    {
        internal abstract int EnableVideoFrameBuffer(VIDEO_SOURCE_TYPE sourceType, uint uid, string key = "");

        internal abstract void DisableVideoFrameBuffer(VIDEO_SOURCE_TYPE sourceType, uint uid = 0, string key = "");

#if UNITY_WEBGL
        internal abstract IRIS_VIDEO_PROCESS_ERR GetVideoFrame(IntPtr nativeTexturePtr, int[] size, VIDEO_SOURCE_TYPE sourceType, uint uid, string key = "");
#else
        internal abstract IRIS_VIDEO_PROCESS_ERR GetVideoFrame(ref IrisVideoFrame video_frame,
            ref bool is_new_frame, VIDEO_SOURCE_TYPE sourceType, uint uid, string key = "");
#endif
      

    }

    internal class VideoStreamManager : IVideoStreamManager, IDisposable
    {
        private RtcEngineImpl _agoraRtcEngine;
        private IrisCVideoFrameBufferNative _videoFrameBuffer;
        private IrisVideoFrameBufferHandle _irisVideoFrameBufferHandle;
        private IrisVideoFrameBufferConfig _videoFrameBufferConfig;

        private bool _disposed;

        public VideoStreamManager(RtcEngineImpl agoraRtcEngine)
        {
            _agoraRtcEngine = agoraRtcEngine;
            _videoFrameBufferConfig = new IrisVideoFrameBufferConfig();
        }

        ~VideoStreamManager()
        {
            Dispose();
        }

        internal override int EnableVideoFrameBuffer(VIDEO_SOURCE_TYPE sourceType, uint uid, string channel_id = "")
        {
            if (_agoraRtcEngine == null)
            {
                AgoraLog.LogError(string.Format("EnableVideoFrameCache ret: ${0}", ERROR_CODE_TYPE.ERR_NOT_INITIALIZED));
                return (int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;
            }



            var irisEngine = (_agoraRtcEngine as RtcEngineImpl).GetNativeHandler();
            var videoFrameBufferManagerPtr = (_agoraRtcEngine as RtcEngineImpl).GetVideoFrameBufferManager();

#if UNITY_WEBGL
            if (irisEngine != 0)
#else
            if (irisEngine != IntPtr.Zero)
#endif
            {
#if UNITY_WEBGL
                _irisVideoFrameBufferHandle = AgoraRtcNative.EnableVideoFrameBufferByConfig(videoFrameBufferManagerPtr,
                    (int)VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA, null, 2,
                    _videoFrameBufferConfig.type, _videoFrameBufferConfig.id, _videoFrameBufferConfig.key);
#else
                _videoFrameBuffer = new IrisCVideoFrameBufferNative {
                    type = (int)VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA,
                    OnVideoFrameReceived = IntPtr.Zero,
                    bytes_per_row_alignment = 2
                };

                _videoFrameBufferConfig.type = (int)sourceType;
                _videoFrameBufferConfig.id = uid;
                _videoFrameBufferConfig.key = channel_id;
                _irisVideoFrameBufferHandle = AgoraRtcNative.EnableVideoFrameBufferByConfig(videoFrameBufferManagerPtr, ref _videoFrameBuffer, ref _videoFrameBufferConfig);
#endif
                return (int)ERROR_CODE_TYPE.ERR_OK;
            }
            return (int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;
        }

        internal override void DisableVideoFrameBuffer(VIDEO_SOURCE_TYPE sourceType, uint uid = 0, string key = "")
        {
            if (_agoraRtcEngine == null)
            {
                AgoraLog.LogError(string.Format("EnableVideoFrameCache ret: ${0}", ERROR_CODE_TYPE.ERR_NOT_INITIALIZED));
                return;
            }

            var irisEngine = (_agoraRtcEngine as RtcEngineImpl).GetNativeHandler();
            var videoFrameBufferManagerPtr = (_agoraRtcEngine as RtcEngineImpl).GetVideoFrameBufferManager();

#if UNITY_WEBGL
            if (irisEngine != 0)
#else
            if (irisEngine != IntPtr.Zero)
#endif
            {
#if UNITY_WEBGL
                AgoraRtcNative.DisableVideoFrameBufferByConfig(videoFrameBufferManagerPtr, (int)sourceType, uid, key);
#else
                _videoFrameBufferConfig.type = (int)sourceType;
                _videoFrameBufferConfig.id = uid;
                _videoFrameBufferConfig.key = key;
                AgoraRtcNative.DisableVideoFrameBufferByConfig(videoFrameBufferManagerPtr, ref _videoFrameBufferConfig);
#endif
            }
        }


#if UNITY_WEBGL
        internal override IRIS_VIDEO_PROCESS_ERR GetVideoFrame(IntPtr nativeTexturePtr, int[] size, VIDEO_SOURCE_TYPE sourceType, uint uid, string key = "")
        {
            var irisEngine = (_agoraRtcEngine as RtcEngineImpl).GetNativeHandler();
            var videoFrameBufferManagerPtr = (_agoraRtcEngine as RtcEngineImpl).GetVideoFrameBufferManager();
            if (irisEngine != 0) {
                bool sucess= AgoraRtcNative.UpdateTextureRawData(videoFrameBufferManagerPtr, nativeTexturePtr, (int)sourceType, uid, key, size);
                if (sucess)
                {
                    return IRIS_VIDEO_PROCESS_ERR.ERR_OK;
                }
                else {
                    return IRIS_VIDEO_PROCESS_ERR.ERR_BUFFER_EMPTY;
                }
            }
            return IRIS_VIDEO_PROCESS_ERR.ERR_NULL_POINTER;
        }
#else


        internal override IRIS_VIDEO_PROCESS_ERR GetVideoFrame(ref IrisVideoFrame video_frame, ref bool is_new_frame, VIDEO_SOURCE_TYPE sourceType, uint uid, string key = "")
        {
            if (_agoraRtcEngine == null)
            {
                AgoraLog.LogError(string.Format("EnableVideoFrameCache ret: ${0}", ERROR_CODE_TYPE.ERR_NOT_INITIALIZED));
                return IRIS_VIDEO_PROCESS_ERR.ERR_NULL_POINTER;
            }

            var irisEngine = (_agoraRtcEngine as RtcEngineImpl).GetNativeHandler();
            var videoFrameBufferManagerPtr = (_agoraRtcEngine as RtcEngineImpl).GetVideoFrameBufferManager();

            if (irisEngine != IntPtr.Zero)
            {
                _videoFrameBufferConfig.type = (int)sourceType;
                _videoFrameBufferConfig.id = uid;
                _videoFrameBufferConfig.key = key;
                return AgoraRtcNative.GetVideoFrameByConfig(videoFrameBufferManagerPtr, ref video_frame, out is_new_frame, ref _videoFrameBufferConfig);
            }
            return IRIS_VIDEO_PROCESS_ERR.ERR_NULL_POINTER;
        }
#endif

        internal void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _agoraRtcEngine = null;
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

#endif