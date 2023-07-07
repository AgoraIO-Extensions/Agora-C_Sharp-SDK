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
        private IrisRtcCApiParam _apiParam;
        private bool _disposed = false;

        private RtcEventHandlerHandle _mediaRecorderEventHandlerHandle = new RtcEventHandlerHandle();

        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
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
            if (_disposed) return;

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


        private void CreateEventHandler()
        {
            if (_mediaRecorderEventHandlerHandle.handle != IntPtr.Zero) return;

            AgoraRtcNative.AllocEventHandlerHandle(ref _mediaRecorderEventHandlerHandle, MediaRecorderObserverNative.OnEvent);




#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            _callbackObject = new AgoraCallbackObject(identifier);
            MediaRecorderObserverNative.CallbackObject = _callbackObject;
#endif
        }

        private void ReleaseEventHandler()
        {
            if (_mediaRecorderEventHandlerHandle.handle == IntPtr.Zero) return;

            AgoraRtcNative.FreeEventHandlerHandle(ref _mediaRecorderEventHandlerHandle);
            MediaRecorderObserverNative.ClearMediaRecorderObserver();

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            MediaRecorderObserverNative.CallbackObject = null;
            if (_callbackObject != null) _callbackObject.Release();
            _callbackObject = null;
#endif
        }

        #region IMediaRecorder
        public int SetMediaRecorderObserver(RtcConnection connection, IMediaRecorderObserver callback)
        {
            CreateEventHandler();

            if (callback == null)
            {
                MediaRecorderObserverNative.RemoveMediaRecorderObserver(connection);

                _param.Clear();
                _param.Add("connection", connection);

                IntPtr[] arrayPtr = new IntPtr[] { _mediaRecorderEventHandlerHandle.handle };
                var json = AgoraJson.ToJson(_param);
                int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIARECORDER_UNSETMEDIARECORDEROBSERVER,
                    json, (UInt32)json.Length,
                    Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                    ref _apiParam);

                return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            }
            else
            {
                MediaRecorderObserverNative.AddMediaRecorderObserver(connection, callback);

                _param.Clear();
                _param.Add("connection", connection);

                IntPtr[] arrayPtr = new IntPtr[] { _mediaRecorderEventHandlerHandle.handle };
                var json = AgoraJson.ToJson(_param);
                int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIARECORDER_SETMEDIARECORDEROBSERVER,
                    json, (UInt32)json.Length,
                    Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                    ref _apiParam);

                return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            }
        }

        public int StartRecording(RtcConnection connection, MediaRecorderConfiguration config)
        {
            _param.Clear();
            _param.Add("connection", connection);
            _param.Add("config", config);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIARECORDER_STARTRECORDING,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopRecording(RtcConnection connection)
        {
            _param.Clear();
            _param.Add("connection", connection);


            var json = AgoraJson.ToJson(_param);
            int nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIARECORDER_STOPRECORDING,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        #endregion
    }
}