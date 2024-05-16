using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using AOT;
#endif

namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;
    // get from alloc, need to free
    using IrisEventHandlerMarshal = IntPtr;
    // get from C++, no need to free
    using IrisEventHandlerHandle = IntPtr;

    public class MediaRecorderImpl
    {
        private IrisApiEnginePtr _irisApiEngine;
        private IrisRtcCApiParam _apiParam;
        private bool _disposed = false;

        private Dictionary<string, RtcEventHandlerHandle> _mediaRecorderEventHandlerHandles = new Dictionary<string, RtcEventHandlerHandle>();
        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        private AgoraCallbackObject _callbackObject;
        private static readonly string identifier = "AgoraMediaRecorder";
#endif

        internal MediaRecorderImpl(IrisApiEnginePtr irisApiEngine)
        {
            _apiParam = new IrisRtcCApiParam();
            _apiParam.AllocResult();
            _irisApiEngine = irisApiEngine;
        }

        ~MediaRecorderImpl()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                UnregisterAndReleasAllEventHandler();
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

        private RtcEventHandlerHandle CreateEventHandler(string nativeHandle)
        {
            if (_mediaRecorderEventHandlerHandles.ContainsKey(nativeHandle))
                return _mediaRecorderEventHandlerHandles[nativeHandle];

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            if (_callbackObject == null)
            {
                _callbackObject = new AgoraCallbackObject(identifier);
                MediaRecorderObserverNative.CallbackObject = _callbackObject;
            }
#endif

            RtcEventHandlerHandle handle = new RtcEventHandlerHandle();
            AgoraRtcNative.AllocEventHandlerHandle(ref handle, MediaRecorderObserverNative.OnEvent);
            _mediaRecorderEventHandlerHandles.Add(nativeHandle, handle);

            return handle;
        }

        private void ReleaseEventHandler(string nativeHandle)
        {
            if (!_mediaRecorderEventHandlerHandles.ContainsKey(nativeHandle))
                return;

            RtcEventHandlerHandle handle = _mediaRecorderEventHandlerHandles[nativeHandle];
            AgoraRtcNative.FreeEventHandlerHandle(ref handle);

            _mediaRecorderEventHandlerHandles.Remove(nativeHandle);
        }

        private void UnregisterAndReleasAllEventHandler()
        {
            List<string> keys = AgoraUtil.GetDicKeys<string, RtcEventHandlerHandle>(_mediaRecorderEventHandlerHandles);
            foreach (var key in keys)
            {
                _param.Clear();
                _param.Add("nativeHandle", key);
                RtcEventHandlerHandle handle = _mediaRecorderEventHandlerHandles[key];

                IntPtr[] arrayPtr = new IntPtr[] { handle.handle };
                var json = AgoraJson.ToJson(_param);
                int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIARECORDER_UNSETMEDIARECORDEROBSERVER,
                                                              json, (UInt32)json.Length,
                                                              Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                              ref _apiParam);

                int ret = nRet == 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

                AgoraRtcNative.FreeEventHandlerHandle(ref handle);
            }
            _mediaRecorderEventHandlerHandles.Clear();

            /// You must release callbackObject after you release eventhandler.
            /// Otherwise may be agcallback and unity main loop can will both access callback object. make crash
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
            if (_callbackObject != null)
            {
                _callbackObject.Release();
                _callbackObject = null;
                MediaRecorderObserverNative.CallbackObject = null;
            }
#endif
        }

        public int SetMediaRecorderObserver(string nativeHandle, IMediaRecorderObserver callback)
        {
            if (callback != null)
            {
                // you must Set Observerr first and then SetIrisAudioEncodedFrameObserver second
                // because if you SetIrisAudioEncodedFrameObserver first, some call back will be trigger immediately
                // and this time you dont have observer be trigger

                MediaRecorderObserverNative.AddMediaRecorderObserver(nativeHandle, callback);

                _param.Clear();
                _param.Add("nativeHandle", nativeHandle);

                RtcEventHandlerHandle handler = CreateEventHandler(nativeHandle);

                IntPtr[] arrayPtr = new IntPtr[] { handler.handle };
                var json = AgoraJson.ToJson(_param);
                int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIARECORDER_SETMEDIARECORDEROBSERVER,
                                                              json, (UInt32)json.Length,
                                                              Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                              ref _apiParam);

                return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            }
            else
            {
                // you must Set(null) lately. because maybe some callback will trigger when unregister,
                // you set null first, some callback will never triggered
                if (_mediaRecorderEventHandlerHandles.ContainsKey(nativeHandle))
                {
                    _param.Clear();
                    _param.Add("nativeHandle", nativeHandle);

                    RtcEventHandlerHandle handler = _mediaRecorderEventHandlerHandles[nativeHandle];

                    IntPtr[] arrayPtr = new IntPtr[] { handler.handle };
                    var json = AgoraJson.ToJson(_param);
                    int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIARECORDER_UNSETMEDIARECORDEROBSERVER,
                                                                  json, (UInt32)json.Length,
                                                                  Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                                                                  ref _apiParam);

                    int ret = nRet == 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

                    if (ret == 0)
                    {
                        ReleaseEventHandler(nativeHandle);
                    }

                    return ret;
                }

                MediaRecorderObserverNative.RemoveMediaRecorderObserver(nativeHandle);

                return 0;
            }
        }

        public string CreateMediaRecorder(RecorderStreamInfo info)
        {

            _param.Clear();
            _param.Add("info", info);

            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_RTCENGINE_CREATEMEDIARECORDER,
                                                          json, (UInt32)json.Length,
                                                          IntPtr.Zero, 0,
                                                          ref _apiParam);

            if (nRet == 0)
            {
                return (string)AgoraJson.GetData<string>(_apiParam.Result, "result");
            }
            else
            {
                return null;
            }
        }

        public int DestroyMediaRecorder(string nativeHandle)
        {

            _param.Clear();
            _param.Add("nativeHandle", nativeHandle);

            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_RTCENGINE_DESTROYMEDIARECORDER,
                                                          json, (UInt32)json.Length,
                                                          IntPtr.Zero, 0,
                                                          ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        #region terra IMediaRecorder
        public int StartRecording(string nativeHandle, MediaRecorderConfiguration config)
        {
            _param.Clear();
            _param.Add("nativeHandle", nativeHandle);
            _param.Add("config", config);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIARECORDER_STARTRECORDING,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopRecording(string nativeHandle)
        {
            _param.Clear();
            _param.Add("nativeHandle", nativeHandle);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIARECORDER_STOPRECORDING,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }
        #endregion terra IMediaRecorder
    }
}