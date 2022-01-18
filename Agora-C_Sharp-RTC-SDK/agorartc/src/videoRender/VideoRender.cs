//  VideoRender.cs
//
//  Created by YuGuo Chen on October 9, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 

using System;
using System.Runtime.InteropServices;

namespace agora.rtc
{
    using IrisVideoFrameBufferHandle = IntPtr;
    
    internal abstract class IVideoStreamManager
    {
        internal abstract int EnableVideoFrameBuffer(int width, int height, VIDEO_SOURCE_TYPE sourceType, uint uid, string key = "");

        internal abstract void DisableVideoFrameBuffer(VIDEO_SOURCE_TYPE sourceType, uint uid = 0, string key = "");

        internal abstract bool GetVideoFrame(ref IrisVideoFrame video_frame,
            ref bool is_new_frame, VIDEO_SOURCE_TYPE sourceType, uint uid, string key = "");
    }

    internal class VideoStreamManager : IVideoStreamManager, IDisposable
    {
        private IAgoraRtcEngine _agoraRtcEngine;
        private IrisCVideoFrameBufferNative _videoFrameBuffer;
        private IrisVideoFrameBufferHandle _irisVideoFrameBufferHandle;
        private IrisVideoFrameBufferConfig _videoFrameBufferConfig;
        private IntPtr videoFrameBufferConfigPtr;

        //private IntPtr videoFrameBufferManagerPtr;

        private bool _disposed;

        public VideoStreamManager(IAgoraRtcEngine agoraRtcEngine)
        {
            _agoraRtcEngine = agoraRtcEngine;
        }

        ~VideoStreamManager()
        {
            Dispose();
        }

        internal override int EnableVideoFrameBuffer(int width, int height, VIDEO_SOURCE_TYPE sourceType, uint uid, string channel_id = "")
        {
            if (_agoraRtcEngine == null)
            {
                AgoraLog.LogError(string.Format("EnableVideoFrameCache ret: ${0}", ERROR_CODE_TYPE.ERR_NOT_INITIALIZED));
                return (int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;
            }

            IntPtr irisEngine = (_agoraRtcEngine as AgoraRtcEngine).GetNativeHandler();
            IntPtr videoFrameBufferManagerPtr = (_agoraRtcEngine as AgoraRtcEngine).GetVideoFrameBufferManager();

            if (irisEngine != IntPtr.Zero)
            {
                var rawDataPtr = AgoraRtcNative.GetIrisRtcRawData(irisEngine);

                //AgoraRtcNative.Attach(rawDataPtr, videoFrameBufferManagerPtr);
                _videoFrameBuffer = new IrisCVideoFrameBufferNative {
                    type = (int)VIDEO_FRAME_TYPE.FRAME_TYPE_RGBA,
                    OnVideoFrameReceived = IntPtr.Zero,
                    resize_width = width,
                    resize_height = height
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

            IntPtr irisEngine = (_agoraRtcEngine as AgoraRtcEngine).GetNativeHandler();
            IntPtr videoFrameBufferManagerPtr = (_agoraRtcEngine as AgoraRtcEngine).GetVideoFrameBufferManager();

            if (irisEngine != IntPtr.Zero)
            {
                var rawDataPtr = AgoraRtcNative.GetIrisRtcRawData(irisEngine);
                _videoFrameBufferConfig = new IrisVideoFrameBufferConfig
                {
                    type = (int)sourceType,
                    id = uid,
                    key = key
                };
                AgoraRtcNative.DisableVideoFrameBufferByConfig(videoFrameBufferManagerPtr, ref _videoFrameBufferConfig);
            }
        }

        internal override bool GetVideoFrame(ref IrisVideoFrame video_frame, ref bool is_new_frame, VIDEO_SOURCE_TYPE sourceType, uint uid, string key = "")
        {
            if (_agoraRtcEngine == null)
            {
                AgoraLog.LogError(string.Format("EnableVideoFrameCache ret: ${0}", ERROR_CODE_TYPE.ERR_NOT_INITIALIZED));
                return false;
            }

            IntPtr irisEngine = (_agoraRtcEngine as AgoraRtcEngine).GetNativeHandler();
            IntPtr videoFrameBufferManagerPtr = (_agoraRtcEngine as AgoraRtcEngine).GetVideoFrameBufferManager();

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
            return false;
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