#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 

using System;

namespace agora.rtc
{
    using IrisVideoFrameBufferHandle = IntPtr;
    
    internal abstract class IVideoStreamManager
    {
        internal abstract int EnableVideoFrameBuffer(VIDEO_SOURCE_TYPE sourceType, uint uid, string key = "");

        internal abstract void DisableVideoFrameBuffer(VIDEO_SOURCE_TYPE sourceType, uint uid = 0, string key = "");

        internal abstract IRIS_VIDEO_PROCESS_ERR GetVideoFrame(ref IrisVideoFrame video_frame,
            ref bool is_new_frame, VIDEO_SOURCE_TYPE sourceType, uint uid, string key = "");
    }

    internal class VideoStreamManager : IVideoStreamManager, IDisposable
    {
        private IRtcEngine _agoraRtcEngine;
        private IrisCVideoFrameBufferNative _videoFrameBuffer;
        private IrisVideoFrameBufferHandle _irisVideoFrameBufferHandle;
        private IrisVideoFrameBufferConfig _videoFrameBufferConfig;

        private bool _disposed;

        public VideoStreamManager(IAgoraRtcEngine agoraRtcEngine)
        {
            _agoraRtcEngine = agoraRtcEngine;
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

            IntPtr irisEngine = (_agoraRtcEngine as RtcEngineImpl).GetNativeHandler();
            IntPtr videoFrameBufferManagerPtr = (_agoraRtcEngine as RtcEngineImpl).GetVideoFrameBufferManager();

            if (irisEngine != IntPtr.Zero)
            {
                _videoFrameBuffer = new IrisCVideoFrameBufferNative {
                    type = (int)VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA,
                    OnVideoFrameReceived = IntPtr.Zero,
                    resize_width = 0,
                    resize_height = 0
                };

                _videoFrameBufferConfig = new IrisVideoFrameBufferConfig
                {
                  type = (int)sourceType,
                  id = uid,
                  key = channel_id
                };
                _irisVideoFrameBufferHandle = AgoraRtcNative.EnableVideoFrameBufferByConfig(videoFrameBufferManagerPtr, ref _videoFrameBuffer, ref _videoFrameBufferConfig);

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

            IntPtr irisEngine = (_agoraRtcEngine as RtcEngineImpl).GetNativeHandler();
            IntPtr videoFrameBufferManagerPtr = (_agoraRtcEngine as RtcEngineImpl).GetVideoFrameBufferManager();

            if (irisEngine != IntPtr.Zero)
            {
                _videoFrameBufferConfig = new IrisVideoFrameBufferConfig
                {
                    type = (int)sourceType,
                    id = uid,
                    key = key
                };
                AgoraRtcNative.DisableVideoFrameBufferByConfig(videoFrameBufferManagerPtr, ref _videoFrameBufferConfig);
            }
        }

        internal override IRIS_VIDEO_PROCESS_ERR GetVideoFrame(ref IrisVideoFrame video_frame, ref bool is_new_frame, VIDEO_SOURCE_TYPE sourceType, uint uid, string key = "")
        {
            if (_agoraRtcEngine == null)
            {
                AgoraLog.LogError(string.Format("EnableVideoFrameCache ret: ${0}", ERROR_CODE_TYPE.ERR_NOT_INITIALIZED));
                return IRIS_VIDEO_PROCESS_ERR.ERR_NULL_POINTER;
            }

            IntPtr irisEngine = (_agoraRtcEngine as RtcEngineImpl).GetNativeHandler();
            IntPtr videoFrameBufferManagerPtr = (_agoraRtcEngine as RtcEngineImpl).GetVideoFrameBufferManager();

            if (irisEngine != IntPtr.Zero)
            {

                _videoFrameBufferConfig = new IrisVideoFrameBufferConfig
                 {
                     type = (int)sourceType,
                     id = uid,
                     key = key
                 };
                return AgoraRtcNative.GetVideoFrameByConfig(videoFrameBufferManagerPtr, ref video_frame, out is_new_frame, ref _videoFrameBufferConfig);
            }
            return IRIS_VIDEO_PROCESS_ERR.ERR_NULL_POINTER;
        }

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