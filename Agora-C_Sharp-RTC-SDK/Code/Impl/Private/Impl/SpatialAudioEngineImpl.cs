using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;
    using IrisEventHandlerHandleNative = IntPtr;

//    internal class CloudSpatialAudioEngineImpl
//    {
//        private bool _disposed = false;
//        private static readonly string identifier = "AgoraRtcSpatialAudioEngine";

//        private IrisApiEnginePtr _irisApiEngine;
//        private CloudSpatialAudioEventHandler _AgoraRtcCloudSpatialAudioEngineEventHandlerInstance;

//        private CharAssistant _result;

//        private IrisEventHandlerHandleNative _irisEngineEventHandlerHandleNative;
//        private IrisCEventHandler _irisCEventHandler;
//        private IrisEventHandlerHandleNative _irisCEngineEventHandlerNative;

//#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
//        private AgoraCallbackObject _callbackObject;
//#endif

//        internal CloudSpatialAudioEngineImpl(IrisApiEnginePtr irisApiEngine)
//        {
//            _result = new CharAssistant();
//            _irisApiEngine = irisApiEngine;
//            CreateEventHandler();
//        }

//        ~CloudSpatialAudioEngineImpl()
//        {
//            Dispose(false);
//        }

//        private void Dispose(bool disposing)
//        {
//            if (_disposed) return;

//            if (disposing)
//            {
//                ReleaseEventHandler();
//            }

//            _irisApiEngine = IntPtr.Zero;
//            _result = new CharAssistant();

//            _disposed = true;
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }

//        private void CreateEventHandler()
//        {
//            if (_irisEngineEventHandlerHandleNative == IntPtr.Zero)
//            {
//                _irisCEventHandler = new IrisCEventHandler
//                {
//                    OnEvent = CloudSpatialAudioEngineEventHandlerNative.OnEvent
//                };

//                var cEventHandlerNativeLocal = new IrisCEventHandlerNative
//                {
//                    onEvent = Marshal.GetFunctionPointerForDelegate(_irisCEventHandler.OnEvent)
//                };

//                _irisCEngineEventHandlerNative = Marshal.AllocHGlobal(Marshal.SizeOf(cEventHandlerNativeLocal));
//                Marshal.StructureToPtr(cEventHandlerNativeLocal, _irisCEngineEventHandlerNative, true);
//                _irisEngineEventHandlerHandleNative =
//                    AgoraRtcNative.SetIrisCloudAudioEngineEventHandler(_irisApiEngine, _irisCEngineEventHandlerNative);

//#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
//                _callbackObject = new AgoraCallbackObject(identifier);
//                CloudSpatialAudioEngineEventHandlerNative.CallbackObject = _callbackObject;
//#endif
//            }
//            _AgoraRtcCloudSpatialAudioEngineEventHandlerInstance = CloudSpatialAudioEventHandler.GetInstance();
//            CloudSpatialAudioEngineEventHandlerNative.CloudSpatialAudioEngineEventHandler = _AgoraRtcCloudSpatialAudioEngineEventHandlerInstance;
//        }

//        private void ReleaseEventHandler()
//        {
//            CloudSpatialAudioEngineEventHandlerNative.CloudSpatialAudioEngineEventHandler = null;
//#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
//            CloudSpatialAudioEngineEventHandlerNative.CallbackObject = null;
//            if (_callbackObject != null) _callbackObject.Release();
//            _callbackObject = null;
//#endif
//            AgoraRtcNative.UnsetIrisCloudAudioEngineEventHandler(_irisApiEngine, _irisEngineEventHandlerHandleNative);
//            Marshal.FreeHGlobal(_irisCEngineEventHandlerNative);
//            _irisEngineEventHandlerHandleNative = IntPtr.Zero;
//        }

//        public CloudSpatialAudioEventHandler GetCloudSpatialAudioEventHandler()
//        {
//            return _AgoraRtcCloudSpatialAudioEngineEventHandlerInstance;
//        }

//        public void InitEventHandler(ICloudSpatialAudioEventHandler engineEventHandler)
//        {
//            CloudSpatialAudioEngineEventHandlerNative.CloudSpatialAudioEngineEventHandler = engineEventHandler;
//        }
        
//        public int SetMaxAudioRecvCount(int maxCount)
//        {
//            var param = new
//            {
//                maxCount
//            };
//            string jsonParam = AgoraJson.ToJson(param);
//            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
//                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_SETMAXAUDIORECVCOUNT,
//                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
//            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
//        }

//        public int SetAudioRecvRange(float range)
//        {
//            var param = new
//            {
//                range
//            };
//            string jsonParam = AgoraJson.ToJson(param);
//            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
//                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_SETAUDIORECVRANGE,
//                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
//            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
//        }

//        public int SetDistanceUnit(float unit)
//        {
//            var param = new
//            {
//                unit
//            };
//            string jsonParam = AgoraJson.ToJson(param);
//            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
//                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_SETDISTANCEUNIT,
//                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
//            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
//        }

//        public int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp)
//        {
//            var param = new
//            {
//                position,
//                axisForward,
//                axisRight,
//                axisUp
//            };
//            string jsonParam = AgoraJson.ToJson(param);
//            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
//                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_UPDATESELFPOSITION,
//                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
//            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
//        }

//        public int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection)
//        {
//            var param = new
//            {
//                position,
//                axisForward,
//                axisRight,
//                axisUp,
//                connection
//            };
//            string jsonParam = AgoraJson.ToJson(param);
//            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
//                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_UPDATESELFPOSITIONEX,
//                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
//            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
//        }

//        public int UpdatePlayerPositionInfo(int playerId, float[] position, float[] forward)
//        {
//            RemoteVoicePositionInfo positionInfo = new RemoteVoicePositionInfo(position, forward);
//            var param = new
//            {
//                playerId,
//                positionInfo
//            };
//            string jsonParam = AgoraJson.ToJson(param);
//            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
//                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_UPDATEPLAYERPOSITIONINFO,
//                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
//            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
//        }

//        public int SetParameters(string @params)
//        {
//            var param = new
//            {
//                @params
//            };
//            string jsonParam = AgoraJson.ToJson(param);
//            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
//                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_SETPARAMETERS,
//                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
//            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
//        }

//        public int Initialize(CloudSpatialAudioConfig config)
//        {
//            var param = new
//            {
//                config
//            };
//            string jsonParam = AgoraJson.ToJson(param);
//            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
//                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_INITIALIZE,
//                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
//            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
//        }

//        public int EnableSpatializer(bool enable, bool applyToTeam)
//        {
//            var param = new
//            {
//                enable,
//                applyToTeam
//            };
//            string jsonParam = AgoraJson.ToJson(param);
//            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
//                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_ENABLESPATIALIZER,
//                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
//            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
//        }

//        public int SetTeamId(int teamId)
//        {
//            var param = new
//            {
//                teamId
//            };
//            string jsonParam = AgoraJson.ToJson(param);
//            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
//                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_SETTEAMID,
//                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
//            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
//        }

//        public int SetAudioRangeMode(AUDIO_RANGE_MODE_TYPE rangeMode)
//        {
//            var param = new
//            {
//                rangeMode
//            };
//            string jsonParam = AgoraJson.ToJson(param);
//            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
//                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_SETAUDIORANGEMODE,
//                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
//            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
//        }

//        public int EnterRoom(string token, string roomName, uint uid)
//        {
//            var param = new
//            {
//                token,
//                roomName,
//                uid
//            };
//            string jsonParam = AgoraJson.ToJson(param);
//            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
//                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_ENTERROOM,
//                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
//            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
//        }

//        public int ExitRoom()
//        {
//            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
//                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_EXITROOM,
//                "", 0, IntPtr.Zero, 0, out _result);
//            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
//        }

//        public int GetTeammates(ref uint[] uids, ref int userCount)
//        {
//            //TODO
//            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
//                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_GETTEAMMATES,
//                "", 0, IntPtr.Zero, 0, out _result);
//            userCount = (int)AgoraJson.GetData<int>(_result.Result, "userCount");
//            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
//        }

//        public int RenewToken(string token)
//        {
//            var param = new
//            {
//                token
//            };
//            string jsonParam = AgoraJson.ToJson(param);
//            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
//                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_RENEWTOKEN,
//                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
//            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
//        }

//        public int MuteLocalAudioStream(bool mute)
//        {
//            var param = new
//            {
//                mute
//            };
//            string jsonParam = AgoraJson.ToJson(param);
//            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
//                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_MUTELOCALAUDIOSTREAM,
//                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
//            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
//        }

//        public int MuteAllRemoteAudioStreams(bool mute)
//        {
//            var param = new
//            {
//                mute
//            };
//            string jsonParam = AgoraJson.ToJson(param);
//            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
//                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_MUTEALLREMOTEAUDIOSTREAMS,
//                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
//            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
//        }
//    }

    public class LocalSpatialAudioEngineImpl
    {
        private IrisApiEnginePtr _irisApiEngine;
        private CharAssistant _result;
        private bool _disposed = false;
        private bool _initialized = false;
        private const int UNINITIALIZED = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;

        internal LocalSpatialAudioEngineImpl(IrisApiEnginePtr irisApiEngine)
        {
            _result = new CharAssistant();
            _irisApiEngine = irisApiEngine;
        }

        ~LocalSpatialAudioEngineImpl()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                //Release();
                _disposed = true;
            }

            _irisApiEngine = IntPtr.Zero;
            _result = new CharAssistant();
            GC.SuppressFinalize(this);
        }

        public int SetMaxAudioRecvCount(int maxCount)
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new
            {
                maxCount
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_SETMAXAUDIORECVCOUNT,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SetAudioRecvRange(float range)
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new
            {
                range
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_SETAUDIORECVRANGE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SetDistanceUnit(float unit)
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new
            {
                unit
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_SETDISTANCEUNIT,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp)
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new
            {
                position,
                axisForward,
                axisRight,
                axisUp
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_UPDATESELFPOSITION,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection)
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new
            {
                position,
                axisForward,
                axisRight,
                axisUp,
                connection
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_UPDATESELFPOSITIONEX,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int UpdatePlayerPositionInfo(int playerId, float[] position, float[] forward)
        {
            if (!_initialized) return UNINITIALIZED;
            RemoteVoicePositionInfo positionInfo = new RemoteVoicePositionInfo(position, forward);
            var param = new
            {
                playerId,
                positionInfo
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_UPDATEPLAYERPOSITIONINFO,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SetParameters(string @params)
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new
            {
                @params
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_SETPARAMETERS,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int MuteLocalAudioStream(bool mute)
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new
            {
                mute
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_MUTELOCALAUDIOSTREAM,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int MuteAllRemoteAudioStreams(bool mute)
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new
            {
                mute
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_MUTEALLREMOTEAUDIOSTREAMS,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int UpdateRemotePosition(uint uid, float[] position, float[] forward)
        {
            if (!_initialized) return UNINITIALIZED;
            RemoteVoicePositionInfo posInfo = new RemoteVoicePositionInfo(position, forward);
            var param = new
            {
                uid,
                posInfo
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_UPDATEREMOTEPOSITION,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int UpdateRemotePositionEx(uint uid, float[] position, float[] forward, RtcConnection connection)
        {
            if (!_initialized) return UNINITIALIZED;
            RemoteVoicePositionInfo posInfo = new RemoteVoicePositionInfo(position, forward);
            var param = new
            {
                uid,
                posInfo,
                connection
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_UPDATEREMOTEPOSITIONEX,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int RemoveRemotePosition(uint uid)
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new
            {
                uid
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_REMOVEREMOTEPOSITION,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int RemoveRemotePositionEx(uint uid, RtcConnection connection)
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new
            {
                uid,
                connection
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_REMOVEREMOTEPOSITIONEX,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int ClearRemotePositions()
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new { };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_CLEARREMOTEPOSITIONS,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int ClearRemotePositionsEx(RtcConnection connection)
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new
            {
                connection
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_CLEARREMOTEPOSITIONSEX,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int Initialize()
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_INITIALIZE,
                "", 0, IntPtr.Zero, 0, out _result);
            var init = (int)AgoraJson.GetData<int>(_result.Result, "result");
            if (init == 0)
            {
                _initialized = true;
            }
            return init;
        }
    }
}