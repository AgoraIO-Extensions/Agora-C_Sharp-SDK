using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;
    using IrisEventHandlerHandleNative = IntPtr;

    public class MediaRecorderImpl
    {
        private IrisApiEnginePtr _irisApiEngine;
        private CharAssistant _result;
        private bool _disposed = false;

        private IrisEventHandlerHandleNative _irisEngineEventHandlerHandleNative;
        private IrisCEventHandler _irisCEventHandler;
        private IrisEventHandlerHandleNative _irisCEngineEventHandlerNative;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        private AgoraCallbackObject _callbackObject;
        private static readonly string identifier = "AgoraMediaRecorder";
#endif

        internal MediaRecorderImpl(IrisApiEnginePtr irisApiEngine)
        {
            _result = new CharAssistant();
            _irisApiEngine = irisApiEngine;
            CreateEventHandler();
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
            _result = new CharAssistant();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void CreateEventHandler()
        {
            if (_irisEngineEventHandlerHandleNative == IntPtr.Zero)
            {
                _irisCEventHandler = new IrisCEventHandler
                {
                    OnEvent = MediaRecorderObserverNative.OnEvent,
                };

                var cEventHandlerNativeLocal = new IrisCEventHandlerNative
                {
                    onEvent = Marshal.GetFunctionPointerForDelegate(_irisCEventHandler.OnEvent)
                };

                _irisCEngineEventHandlerNative = Marshal.AllocHGlobal(Marshal.SizeOf(cEventHandlerNativeLocal));
                Marshal.StructureToPtr(cEventHandlerNativeLocal, _irisCEngineEventHandlerNative, true);
                _irisEngineEventHandlerHandleNative =
                    AgoraRtcNative.SetIrisMediaRecorderEventHandler(_irisApiEngine, _irisCEngineEventHandlerNative);

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                _callbackObject = new AgoraCallbackObject(identifier);
                MediaRecorderObserverNative.CallbackObject = _callbackObject;
#endif
            }
        }

        private void ReleaseEventHandler()
        {
            MediaRecorderObserverNative.MediaRecorderObserverDic.Clear();
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            MediaRecorderObserverNative.CallbackObject = null;
            if (_callbackObject != null) _callbackObject.Release();
            _callbackObject = null;
#endif
            AgoraRtcNative.UnsetIrisMediaRecorderEventHandler(_irisApiEngine, _irisEngineEventHandlerHandleNative);
            Marshal.FreeHGlobal(_irisCEngineEventHandlerNative);
            _irisEngineEventHandlerHandleNative = IntPtr.Zero;
        }

        #region IMediaRecorder
        public int SetMediaRecorderObserver(RtcConnection connection, IMediaRecorderObserver callback)
        {
            string key = connection.localUid.ToString() + connection.channelId;
            if (!MediaRecorderObserverNative.MediaRecorderObserverDic.ContainsKey(key))
            {
                MediaRecorderObserverNative.MediaRecorderObserverDic.Add(key, callback);

                var param = new
                {
                    connection
                };

                var json = AgoraJson.ToJson(param);
                int nRet = AgoraRtcNative.CallIrisApi(_irisApiEngine, AgoraApiType.FUNC_MEDIARECORDER_SETMEDIARECORDEROBSERVER,
                    json, (UInt32)json.Length,
                    IntPtr.Zero, 0,
                    out _result);

                return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
            }
            
            if (callback == null && MediaRecorderObserverNative.MediaRecorderObserverDic.ContainsKey(key))
            {
                MediaRecorderObserverNative.MediaRecorderObserverDic.Remove(key);
            }

            return 0;
        }

        public int StartRecording(RtcConnection connection, MediaRecorderConfiguration config)
        {
            var param = new
            {
                connection,
                config
            };

            var json = AgoraJson.ToJson(param);
            int nRet = AgoraRtcNative.CallIrisApi(_irisApiEngine, AgoraApiType.FUNC_MEDIARECORDER_STARTRECORDING,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int StopRecording(RtcConnection connection)
        {
            var param = new
            {
                connection,
            };

            var json = AgoraJson.ToJson(param);
            int nRet = AgoraRtcNative.CallIrisApi(_irisApiEngine, AgoraApiType.FUNC_MEDIARECORDER_STOPRECORDING,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                out _result);

            return nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        #endregion
    }
}