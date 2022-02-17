//  VideoRender.cs
//
//  Created by Yiqing Huang on June 2, 2021.
//  Modified by Yiqing Huang on June 24, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 

using System;

namespace agora.rtc
{
    using IrisVideoFrameBufferHandle = IntPtr;
    using VideoFrameBufferManagerPtr = IntPtr;

    internal abstract class IVideoStreamManager
    {
        internal abstract int EnableVideoFrameCache(int width, int height, uint uid, string channel_id = "");

        internal abstract void DisableVideoFrameCache(uint uid = 0, string channel_id = "");

        internal abstract bool GetVideoFrame(ref IrisVideoFrame video_frame,
            ref bool is_new_frame, uint uid, string channel_id = "");
    }

    internal class VideoStreamManager : IVideoStreamManager, IDisposable
    {
        private IAgoraRtcEngine _agoraRtcEngine;
        private IrisCVideoFrameBufferNative _videoFrameBuffer;
        private IrisVideoFrameBufferHandle _irisVideoFrameBufferHandle;
        private VideoFrameBufferManagerPtr videoFrameBufferManagerPtr;
        private bool _disposed;

        public VideoStreamManager(IAgoraRtcEngine agoraRtcEngine)
        {
            this._agoraRtcEngine = agoraRtcEngine;
        }

        ~VideoStreamManager()
        {
            Dispose();
        }

        internal override int EnableVideoFrameCache(int width, int height, uint uid, string channel_id = "")
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

                _videoFrameBuffer = new IrisCVideoFrameBufferNative {
                    type = (int)VIDEO_FRAME_TYPE.FRAME_TYPE_RGBA,
                    OnVideoFrameReceived = IntPtr.Zero,
                    resize_width = width,
                    resize_height = height
                };
                _irisVideoFrameBufferHandle = AgoraRtcNative.EnableVideoFrameBuffer(videoFrameBufferManagerPtr, ref _videoFrameBuffer, uid, channel_id);
                return (int)ERROR_CODE_TYPE.ERR_OK;
            }
            return (int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;
        }

        internal override void DisableVideoFrameCache(uint uid = 0, string channel_id = "")
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
                AgoraRtcNative.DisableVideoFrameBufferByUid(videoFrameBufferManagerPtr, uid, channel_id);
            }
        }

        internal override bool GetVideoFrame(ref IrisVideoFrame video_frame,
            ref bool is_new_frame, uint uid, string channel_id = "")
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
                var rawDataPtr = AgoraRtcNative.GetIrisRtcRawData(irisEngine);

                return AgoraRtcNative.GetVideoFrame(videoFrameBufferManagerPtr, ref video_frame, out is_new_frame, uid, channel_id);
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