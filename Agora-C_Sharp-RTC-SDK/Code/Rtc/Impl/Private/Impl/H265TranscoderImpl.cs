﻿using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using AOT;
#endif

namespace Agora.Rtc
{
    // get from alloc, need to free
    using IrisEventHandlerMarshal = IntPtr;
    // get from C++, no need to free
    using IrisEventHandlerHandle = IntPtr;

    using IrisApiEnginePtr = IntPtr;

    public partial class H265TranscoderImpl
    {
        private bool _disposed = false;

        private IrisApiEnginePtr _irisApiEngine;

        private IrisRtcCApiParam _apiParam;

        private RtcEventHandlerHandle _h265TranscoderObserverHandle = new RtcEventHandlerHandle();

        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        private AgoraCallbackObject _callbackObject;
        private static readonly string identifier = "AgoraH265Transoder";
#endif

        internal H265TranscoderImpl(IrisApiEnginePtr irisApiEngine)
        {
            _apiParam = new IrisRtcCApiParam();
            _apiParam.AllocResult();
            _irisApiEngine = irisApiEngine;
        }

        ~H265TranscoderImpl()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                ReleaseEventHandler();
            }

            _irisApiEngine = IntPtr.Zero;
            _apiParam.FreeResult();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private int CreateEventHandler()
        {
            if (_h265TranscoderObserverHandle.handle != IntPtr.Zero)
                return 0;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            if (_callbackObject == null)
            {
                _callbackObject = new AgoraCallbackObject(identifier);
                H265TranscoderObserverNative.CallbackObject = _callbackObject;
            }
#endif

            AgoraRtcNative.AllocEventHandlerHandle(ref _h265TranscoderObserverHandle, H265TranscoderObserverNative.OnEvent);
            IntPtr[] arrayPtr = new IntPtr[] { _h265TranscoderObserverHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IH265TRANSCODER_REGISTERTRANSCODEROBSERVER_e1ee996,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("IH265TRANSCODER_REGISTERTRANSCODEROBSERVER failed: " + nRet);
            }
            arrayPtrHandle.Free();
            return nRet;
        }

        private int ReleaseEventHandler()
        {
            if (_h265TranscoderObserverHandle.handle == IntPtr.Zero)
                return -1;

            IntPtr[] arrayPtr = new IntPtr[] { _h265TranscoderObserverHandle.handle };
            GCHandle arrayPtrHandle = GCHandle.Alloc(arrayPtr, GCHandleType.Pinned);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.IH265TRANSCODER_UNREGISTERTRANSCODEROBSERVER_e1ee996,
                                                          "{}", 2,
                                                          Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                          ref _apiParam);

            if (nRet != 0)
            {
                AgoraLog.LogError("IH265TRANSCODER_UNREGISTERTRANSCODEROBSERVER failed: " + nRet);
            }

            AgoraRtcNative.FreeEventHandlerHandle(ref _h265TranscoderObserverHandle);

            /// You must release callbackObject after you release eventhandler.
            /// Otherwise may be agcallback and unity main loop can will both access callback object. make crash
            H265TranscoderObserverNative.SetH265TranscoderObserver(null);

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            H265TranscoderObserverNative.CallbackObject = null;
            if (_callbackObject != null)
                _callbackObject.Release();
            _callbackObject = null;
#endif
            arrayPtrHandle.Free();
            return nRet;
        }

        public int RegisterTranscoderObserver(IH265TranscoderObserver observer)
        {
            H265TranscoderObserverNative.SetH265TranscoderObserver(observer);
            int nRet = CreateEventHandler();
            return nRet;
        }

        public int UnregisterTranscoderObserver()
        {
            int nRet = ReleaseEventHandler();
            H265TranscoderObserverNative.SetH265TranscoderObserver(null);
            return nRet;
        }
    }
}