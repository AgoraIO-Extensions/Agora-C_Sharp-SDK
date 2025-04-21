#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS

using System;
using System.Collections.Generic;
using AOT;

namespace Agora.Rtc
{
    using IrisVideoFrameBufferHandle = IntPtr;

    ///
    /// @ignore
    ///
    public enum VideoSurfaceType
    {
        ///
        /// @ignore
        ///
        Renderer = 0,
        ///
        /// @ignore
        ///
        RawImage = 1,
    };

    public delegate void OnTextureSizeModifyHandler(int width, int height);


    public abstract class IVideoStreamManager : IDisposable
    {
        //internal abstract int EnableVideoFrameBuffer(VIDEO_SOURCE_TYPE sourceType, uint uid, string key,
        //    VIDEO_OBSERVER_FRAME_TYPE frameType);

        //internal abstract void DisableVideoFrameBuffer(VIDEO_SOURCE_TYPE sourceType, uint uid, string key,
        //    VIDEO_OBSERVER_FRAME_TYPE frameType);

        //internal abstract IRIS_VIDEO_PROCESS_ERR GetVideoFrame(ref IrisCVideoFrame video_frame,
        //    ref bool is_new_frame, VIDEO_SOURCE_TYPE sourceType, uint uid, string key, VIDEO_OBSERVER_FRAME_TYPE frameType);


        internal abstract int AddVideoFrameObserverDelegate(ref IrisRtcVideoFrameConfig config);

        internal abstract void RemoveVideoFrameObserverDelegate();

        public abstract void Dispose();
    }

    internal class VideoStreamManager : IVideoStreamManager
    {

        private RtcEngineImpl _agoraRtcEngine;
        private IrisRtcVideoFrameConfig _videoFrameConfig;
        private TextureManager _textureManager;
        private VideoFrameEventHandlerHandler _videoFrameEventHandlerHandler = new VideoFrameEventHandlerHandler();
        private bool _disposed;
        private int _delegateID = INVALID_DELEGATE_ID;

        public static VIDEO_MODULE_POSITION position = VIDEO_MODULE_POSITION.POSITION_PRE_ENCODER;
        private static List<TextureManager> _textureManagers = new List<TextureManager>();
        private static System.Object _textureManagerLock = new System.Object();
        private static int INVALID_DELEGATE_ID = -1;

        public VideoStreamManager(RtcEngineImpl agoraRtcEngine, TextureManager textureManager)
        {
            _agoraRtcEngine = agoraRtcEngine;
            _textureManager = textureManager;
            _agoraRtcEngine.OnRtcEngineImpleWillDispose += RtcEngineImplWillDispose;
            //    _videoFrameConfig = new IrisRtcVideoFrameConfig();
            //    _videoFrameConfig.video_view_setup_mode = 0;
            //    _videoFrameConfig.observed_frame_position = (uint)(position | VIDEO_MODULE_POSITION.POSITION_PRE_RENDERER);
        }

        ~VideoStreamManager()
        {
            Dispose();
        }

        //internal override int EnableVideoFrameBuffer(VIDEO_SOURCE_TYPE sourceType, uint uid, string channel_id,
        //    VIDEO_OBSERVER_FRAME_TYPE frameType)
        //{
        //    if (_agoraRtcEngine == null)
        //    {
        //        AgoraLog.LogError(string.Format("EnableVideoFrameCache ret: ${0}", ERROR_CODE_TYPE.ERR_NOT_INITIALIZED));
        //        return (int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;
        //    }

        //    IntPtr irisEngine = (_agoraRtcEngine as RtcEngineImpl).GetIrisHandler();
        //    IntPtr rtcRenderingHandle = (_agoraRtcEngine as RtcEngineImpl).GetRtcRenderingHandle();

        //    if (irisEngine != IntPtr.Zero)
        //    {
        //        _videoFrameConfig.video_source_type = (int)sourceType;
        //        _videoFrameConfig.video_frame_format = (int)frameType;
        //        _videoFrameConfig.uid = uid;
        //        _videoFrameConfig.channelId = channel_id;
        //        AgoraRtcNative.AddVideoFrameCacheKey(rtcRenderingHandle, ref _videoFrameConfig);
        //        return (int)ERROR_CODE_TYPE.ERR_OK;
        //    }
        //    return (int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;
        //}

        //internal override void DisableVideoFrameBuffer(VIDEO_SOURCE_TYPE sourceType, uint uid, string channel_id,
        //    VIDEO_OBSERVER_FRAME_TYPE frameType)
        //{
        //    if (_agoraRtcEngine == null)
        //    {
        //        AgoraLog.LogError(string.Format("EnableVideoFrameCache ret: ${0}", ERROR_CODE_TYPE.ERR_NOT_INITIALIZED));
        //        return;
        //    }

        //    IntPtr irisEngine = (_agoraRtcEngine as RtcEngineImpl).GetIrisHandler();
        //    IntPtr rtcRenderingHandle = (_agoraRtcEngine as RtcEngineImpl).GetRtcRenderingHandle();

        //    if (irisEngine != IntPtr.Zero)
        //    {
        //        _videoFrameConfig.video_source_type = (int)sourceType;
        //        _videoFrameConfig.video_frame_format = (int)frameType;
        //        _videoFrameConfig.uid = uid;
        //        _videoFrameConfig.channelId = channel_id;
        //        AgoraRtcNative.RemoveVideoFrameCacheKey(rtcRenderingHandle, ref _videoFrameConfig);
        //    }
        //}

        //internal override IRIS_VIDEO_PROCESS_ERR GetVideoFrame(ref IrisCVideoFrame video_frame, ref bool is_new_frame, VIDEO_SOURCE_TYPE sourceType, uint uid, string key, VIDEO_OBSERVER_FRAME_TYPE frameType)
        //{
        //    if (_agoraRtcEngine == null)
        //    {
        //        AgoraLog.LogError(string.Format("EnableVideoFrameCache ret: ${0}", ERROR_CODE_TYPE.ERR_NOT_INITIALIZED));
        //        return IRIS_VIDEO_PROCESS_ERR.ERR_NULL_POINTER;
        //    }

        //    IntPtr irisEngine = (_agoraRtcEngine as RtcEngineImpl).GetIrisHandler();
        //    IntPtr rtcRenderingHandle = (_agoraRtcEngine as RtcEngineImpl).GetRtcRenderingHandle();

        //    if (irisEngine != IntPtr.Zero)
        //    {
        //        _videoFrameConfig.video_source_type = (int)sourceType;
        //        _videoFrameConfig.video_frame_format = (int)frameType;
        //        _videoFrameConfig.uid = uid;
        //        _videoFrameConfig.channelId = key;
        //        return AgoraRtcNative.GetVideoFrameCache(rtcRenderingHandle, ref _videoFrameConfig, ref video_frame, out is_new_frame);
        //    }
        //    return IRIS_VIDEO_PROCESS_ERR.ERR_NULL_POINTER;
        //}

        internal override int AddVideoFrameObserverDelegate(ref IrisRtcVideoFrameConfig config)
        {
            if (_agoraRtcEngine == null)
            {
                AgoraLog.LogError(string.Format("AddVideoFrameObserverDelegate ret: ${0}", ERROR_CODE_TYPE.ERR_NOT_INITIALIZED));
                return INVALID_DELEGATE_ID;
            }

            IntPtr irisEngine = (_agoraRtcEngine as RtcEngineImpl).GetIrisHandler();
            IntPtr rtcRenderingHandle = (_agoraRtcEngine as RtcEngineImpl).GetRtcRenderingHandle();

            if (irisEngine != IntPtr.Zero)
            {
                if (_videoFrameEventHandlerHandler.handle == IntPtr.Zero)
                {
                    AgoraRtcNative.AllocVideoFrameHandlerHandle(ref _videoFrameEventHandlerHandler, VideoStreamManager.OnVideoFameEvent);
                }

                lock (_textureManagerLock)
                {
                    _textureManagers.Add(_textureManager);
                    _delegateID = AgoraRtcNative.AddVideoFrameObserverDelegate(rtcRenderingHandle, ref config, _videoFrameEventHandlerHandler.handle);
                    return _delegateID;
                }
            }
            return INVALID_DELEGATE_ID;
        }

        internal override void RemoveVideoFrameObserverDelegate()
        {
            if (_delegateID == INVALID_DELEGATE_ID)
            {
                AgoraLog.LogError("RemoveVideoFrameObserverDelegate INVALID_DELEGATE_ID");
                return;
            }

            if (_agoraRtcEngine == null)
            {
                AgoraLog.LogError("RemoveVideoFrameObserverDelegate ERROR_CODE_TYPE.ERR_NOT_INITIALIZED");
                return;
            }

            IntPtr irisEngine = (_agoraRtcEngine as RtcEngineImpl).GetIrisHandler();
            IntPtr rtcRenderingHandle = (_agoraRtcEngine as RtcEngineImpl).GetRtcRenderingHandle();

            if (irisEngine != IntPtr.Zero)
            {
                lock (_textureManagerLock)
                {
                    _textureManagers.Remove(_textureManager);
                    AgoraRtcNative.RemoveVideoFrameObserverDelegate(rtcRenderingHandle, _delegateID);
                    _delegateID = INVALID_DELEGATE_ID;
                }

                if (_videoFrameEventHandlerHandler.handle != IntPtr.Zero)
                {
                    AgoraRtcNative.FreeVideoFrameHandlerHandle(ref _videoFrameEventHandlerHandler);
                }
            }
        }


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        [MonoPInvokeCallback(typeof(Video_Frame_Event_Native))]
#endif
        internal static void OnVideoFameEvent(ref IrisCVideoFrame videoFrame, ref IrisRtcVideoFrameConfig config, bool resize)
        {
            lock (_textureManagerLock)
            {
                foreach (var e in _textureManagers)
                {
                    e.OnVideoFameEvent(ref videoFrame, ref config, resize);
                }
            }
        }


        internal void RtcEngineImplWillDispose(RtcEngineImpl impl)
        {
            IntPtr irisEngine = (_agoraRtcEngine as RtcEngineImpl).GetIrisHandler();
            IntPtr rtcRenderingHandle = (_agoraRtcEngine as RtcEngineImpl).GetRtcRenderingHandle();

            if (irisEngine != IntPtr.Zero)
            {
                if (_videoFrameEventHandlerHandler.handle != IntPtr.Zero)
                {
                    AgoraRtcNative.FreeVideoFrameHandlerHandle(ref _videoFrameEventHandlerHandler);
                }

                AgoraLog.Log("DisableVideoFrameBufferByConfig on RtcEngineImplWillDispose");
            }

            lock (_textureManagerLock)
            {
                _textureManagers.Clear();
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