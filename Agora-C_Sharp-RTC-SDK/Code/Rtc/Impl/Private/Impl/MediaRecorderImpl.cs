using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;
    //get from alloc, need to free
    using IrisEventHandlerMarshal = IntPtr;
    //get from C++, no need to free
    using IrisEventHandlerHandle = IntPtr;

    public class MediaRecorderImpl
    {
        private IrisApiEnginePtr _irisApiEngine;
        private IrisCApiParam _apiParam;
        private bool _disposed = false;

        private Dictionary<string, EventHandlerHandle> _mediaRecorderEventHandlerHandles = new Dictionary<string, EventHandlerHandle>();

        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        private AgoraCallbackObject _callbackObject;
        private static readonly string identifier = "AgoraMediaRecorder";
#endif

        internal MediaRecorderImpl(IrisApiEnginePtr irisApiEngine)
        {
            _apiParam = new IrisCApiParam();
            _apiParam.AllocResult();
            _irisApiEngine = irisApiEngine;
        }

        ~MediaRecorderImpl()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                ReleasAllEventHandler();
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


        private EventHandlerHandle CreateEventHandler(string nativeHandler)
        {
            if (_mediaRecorderEventHandlerHandles.ContainsKey(nativeHandler))
                return _mediaRecorderEventHandlerHandles[nativeHandler];

            EventHandlerHandle handle = new EventHandlerHandle();
            AgoraUtil.AllocEventHandlerHandle(ref handle, MediaRecorderObserverNative.OnEvent);
            _mediaRecorderEventHandlerHandles.Add(nativeHandler, handle);



#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            if(_callbackObject == null)
            {
                _callbackObject = new AgoraCallbackObject(identifier);
                MediaRecorderObserverNative.CallbackObject = _callbackObject;
            }
#endif

            return handle;
        }

        private void ReleaseEventHandler(string nativeHandler)
        {
            if (!_mediaRecorderEventHandlerHandles.ContainsKey(nativeHandler))
                return;

            EventHandlerHandle handle = _mediaRecorderEventHandlerHandles[nativeHandler];
            AgoraUtil.FreeEventHandlerHandle(ref handle);

            _mediaRecorderEventHandlerHandles.Remove(nativeHandler);


        }

        private void ReleasAllEventHandler()
        {
            List<string> keys = AgoraUtil.GetDicKeys<string, EventHandlerHandle>(_mediaRecorderEventHandlerHandles);
            foreach (var key in keys)
            {
                EventHandlerHandle handle = _mediaRecorderEventHandlerHandles[key];
                AgoraUtil.FreeEventHandlerHandle(ref handle);
            }
            _mediaRecorderEventHandlerHandles.Clear();

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            if (_callbackObject != null)
            {
                _callbackObject.Release();
                _callbackObject = null;
                MediaRecorderObserverNative.CallbackObject = null;
            }
#endif
        }

        #region IMediaRecorder
        public int SetMediaRecorderObserver(string nativeHandler, IMediaRecorderObserver callback)
        {
            if (callback != null)
            {
                //you must Set Observerr first and then SetIrisAudioEncodedFrameObserver second
                //because if you SetIrisAudioEncodedFrameObserver first, some call back will be trigger immediately
                //and this time you dont have observer be trigger

                MediaRecorderObserverNative.AddMediaRecorderObserver(nativeHandler, callback);

                _param.Clear();
                _param.Add("nativeHandler", nativeHandler);

                EventHandlerHandle handler = CreateEventHandler(nativeHandler);

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
                //you must Set(null) lately. because maybe some callback will trigger when unregister,
                //you set null first, some callback will never triggered 
                if (_mediaRecorderEventHandlerHandles.ContainsKey(nativeHandler))
                {
                    _param.Clear();
                    _param.Add("nativeHandler", nativeHandler);

                    EventHandlerHandle handler = _mediaRecorderEventHandlerHandles[nativeHandler];

                    IntPtr[] arrayPtr = new IntPtr[] { handler.handle };
                    var json = AgoraJson.ToJson(_param);
                    int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIARECORDER_UNSETMEDIARECORDEROBSERVER,
                        json, (UInt32)json.Length,
                        Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                        ref _apiParam);

                    int ret = nRet == 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

                    if (ret == 0)
                    {
                        ReleaseEventHandler(nativeHandler);
                    }

                    return ret;
                }

                MediaRecorderObserverNative.RemoveMediaRecorderObserver(nativeHandler);

                return 0;
            }


        }

        public int StartRecording(string nativeHandler, MediaRecorderConfiguration config)
        {
            _param.Clear();
            _param.Add("nativeHandler", nativeHandler);
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIARECORDER_STARTRECORDING,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopRecording(string nativeHandler)
        {
            _param.Clear();
            _param.Add("nativeHandler", nativeHandler);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIARECORDER_STOPRECORDING,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public string CreateLocalMediaRecorder(RtcConnection connection)
        {

            _param.Clear();
            _param.Add("connection", connection);

            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_RTCENGINE_CREATELOCALMEDIARECORDER,
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

        public string CreateRemoteMediaRecorder(string channelId, uint uid)
        {
            _param.Clear();
            _param.Add("channelId", channelId);
            _param.Add("uid", uid);

            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_RTCENGINE_CREATEREMOTEMEDIARECORDER,
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


        public int DestroyMediaRecorder(string nativeHandler) {

            _param.Clear();
            _param.Add("nativeHandler", nativeHandler);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_RTCENGINE_DESTROYMEDIARECORDER,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        #endregion
    }
}