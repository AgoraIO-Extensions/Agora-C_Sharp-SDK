#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID

using System;

namespace Agora.Rtc
{
    using IrisVideoFrameBufferHandle = IntPtr;

    public abstract class IVideoStreamManager : IDisposable
    {
        internal abstract int EnableVideoFrameBuffer(VIDEO_SOURCE_TYPE sourceType, uint uid, string key,
            VIDEO_OBSERVER_FRAME_TYPE frameType);

        internal abstract void DisableVideoFrameBuffer(VIDEO_SOURCE_TYPE sourceType, uint uid, string key,
            VIDEO_OBSERVER_FRAME_TYPE frameType);

        internal abstract IRIS_VIDEO_PROCESS_ERR GetVideoFrame(ref IrisCVideoFrame video_frame,
            ref bool is_new_frame, VIDEO_SOURCE_TYPE sourceType, uint uid, string key, VIDEO_OBSERVER_FRAME_TYPE frameType);

        public abstract void Dispose();
    }

    internal class VideoStreamManager : IVideoStreamManager
    {
        private RtcEngineImpl _agoraRtcEngine;
        private IrisRtcVideoFrameConfig _videoFrameConfig;

        private bool _disposed;

        public VideoStreamManager(RtcEngineImpl agoraRtcEngine)
        {
            _agoraRtcEngine = agoraRtcEngine;
            _agoraRtcEngine.OnRtcEngineImpleWillDispose += RtcEngineImplWillDispose;
            _videoFrameConfig = new IrisRtcVideoFrameConfig();
            _videoFrameConfig.video_view_setup_mode = 0;
        }

        ~VideoStreamManager()
        {
            Dispose();
        }

        internal override int EnableVideoFrameBuffer(VIDEO_SOURCE_TYPE sourceType, uint uid, string channel_id,
            VIDEO_OBSERVER_FRAME_TYPE frameType)
        {
            if (_agoraRtcEngine == null)
            {
                AgoraLog.LogError(string.Format("EnableVideoFrameCache ret: ${0}", ERROR_CODE_TYPE.ERR_NOT_INITIALIZED));
                return (int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;
            }

            IntPtr irisEngine = (_agoraRtcEngine as RtcEngineImpl).GetNativeHandler();
            IntPtr rtcRenderingHandle = (_agoraRtcEngine as RtcEngineImpl).GetRtcRenderingHandle();

            if (irisEngine != IntPtr.Zero)
            {
                _videoFrameConfig.video_source_type = (int)sourceType;
                _videoFrameConfig.video_frame_format = (int)frameType;
                _videoFrameConfig.uid = uid;
                _videoFrameConfig.channelId = channel_id;
                AgoraRtcNative.AddVideoFrameCacheKey(rtcRenderingHandle, ref _videoFrameConfig);
                return (int)ERROR_CODE_TYPE.ERR_OK;
            }
            return (int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;
        }

        internal override void DisableVideoFrameBuffer(VIDEO_SOURCE_TYPE sourceType, uint uid, string channel_id,
            VIDEO_OBSERVER_FRAME_TYPE frameType)
        {
            if (_agoraRtcEngine == null)
            {
                AgoraLog.LogError(string.Format("EnableVideoFrameCache ret: ${0}", ERROR_CODE_TYPE.ERR_NOT_INITIALIZED));
                return;
            }

            IntPtr irisEngine = (_agoraRtcEngine as RtcEngineImpl).GetNativeHandler();
            IntPtr rtcRenderingHandle = (_agoraRtcEngine as RtcEngineImpl).GetRtcRenderingHandle();

            if (irisEngine != IntPtr.Zero)
            {
                _videoFrameConfig.video_source_type = (int)sourceType;
                _videoFrameConfig.video_frame_format = (int)frameType;
                _videoFrameConfig.uid = uid;
                _videoFrameConfig.channelId = channel_id;
                AgoraRtcNative.RemoveVideoFrameCacheKey(rtcRenderingHandle, ref _videoFrameConfig);
            }
        }

        internal override IRIS_VIDEO_PROCESS_ERR GetVideoFrame(ref IrisCVideoFrame video_frame, ref bool is_new_frame, VIDEO_SOURCE_TYPE sourceType, uint uid, string key, VIDEO_OBSERVER_FRAME_TYPE frameType)
        {
            if (_agoraRtcEngine == null)
            {
                AgoraLog.LogError(string.Format("EnableVideoFrameCache ret: ${0}", ERROR_CODE_TYPE.ERR_NOT_INITIALIZED));
                return IRIS_VIDEO_PROCESS_ERR.ERR_NULL_POINTER;
            }

            IntPtr irisEngine = (_agoraRtcEngine as RtcEngineImpl).GetNativeHandler();
            IntPtr rtcRenderingHandle = (_agoraRtcEngine as RtcEngineImpl).GetRtcRenderingHandle();

            if (irisEngine != IntPtr.Zero)
            {
                _videoFrameConfig.video_source_type = (int)sourceType;
                _videoFrameConfig.video_frame_format = (int)frameType;
                _videoFrameConfig.uid = uid;
                _videoFrameConfig.channelId = key;
                return AgoraRtcNative.GetVideoFrameCache(rtcRenderingHandle,  ref _videoFrameConfig, ref video_frame, out is_new_frame);
            }
            return IRIS_VIDEO_PROCESS_ERR.ERR_NULL_POINTER;
        }

        internal void RtcEngineImplWillDispose(RtcEngineImpl impl)
        {
            IntPtr irisEngine = (_agoraRtcEngine as RtcEngineImpl).GetNativeHandler();
            IntPtr rtcRenderingHandle = (_agoraRtcEngine as RtcEngineImpl).GetRtcRenderingHandle();

            if (irisEngine != IntPtr.Zero)
            {
                AgoraRtcNative.RemoveVideoFrameCacheKey(rtcRenderingHandle, ref _videoFrameConfig);
                AgoraLog.Log("DisableVideoFrameBufferByConfig on RtcEngineImplWillDispose");
            }
        }

        internal void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _agoraRtcEngine.OnRtcEngineImpleWillDispose -= RtcEngineImplWillDispose;
                _agoraRtcEngine = null;
                _disposed = true;
            }
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

#endif