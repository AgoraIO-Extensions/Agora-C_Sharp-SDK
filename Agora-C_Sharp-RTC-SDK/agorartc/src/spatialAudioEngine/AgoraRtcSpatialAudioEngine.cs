using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace agora.rtc
{
    using LitJson;

    using IrisApiEnginePtr = IntPtr;

    using IrisEventHandlerHandleNative = IntPtr;

    public sealed class AgoraRtcCloudSpatialAudioEngine : IAgoraRtcCloudSpatialAudioEngine
    {
        private bool _disposed = false;
        private static readonly string identifier = "AgoraRtcSpatialAudioEngine";

        private IrisApiEnginePtr _irisApiEngine;
        private AgoraRtcCloudSpatialAudioEngineEventHandler _AgoraRtcCloudSpatialAudioEngineEventHandlerInstance;

        private CharAssistant _result;

        private IrisEventHandlerHandleNative _irisEngineEventHandlerHandleNative;
        private IrisCEventHandler _irisCEventHandler;
        private IrisEventHandlerHandleNative _irisCEngineEventHandlerNative;
            
    #if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        private AgoraCallbackObject _callbackObject;
    #endif

        internal AgoraRtcCloudSpatialAudioEngine(IrisApiEnginePtr irisApiEngine)
        {
            _result = new CharAssistant();
            _irisApiEngine = irisApiEngine;
            CreateEventHandler();
        }

        ~AgoraRtcCloudSpatialAudioEngine()
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

        public override void Dispose()
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
                    OnEvent = RtcCloudSpatialAudioEngineEventHandlerNative.OnEvent,
                    OnEventWithBuffer = RtcCloudSpatialAudioEngineEventHandlerNative.OnEventWithBuffer
                };

                var cEventHandlerNativeLocal = new IrisCEventHandlerNative
                {
                    onEvent = Marshal.GetFunctionPointerForDelegate(_irisCEventHandler.OnEvent),
                    onEventWithBuffer =
                        Marshal.GetFunctionPointerForDelegate(_irisCEventHandler.OnEventWithBuffer)
                };

                _irisCEngineEventHandlerNative = Marshal.AllocHGlobal(Marshal.SizeOf(cEventHandlerNativeLocal));
                Marshal.StructureToPtr(cEventHandlerNativeLocal, _irisCEngineEventHandlerNative, true);
                _irisEngineEventHandlerHandleNative =
                    AgoraRtcNative.SetIrisCloudAudioEngineEventHandler(_irisApiEngine, _irisCEngineEventHandlerNative);

    #if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
                _callbackObject = new AgoraCallbackObject("Agora" + GetHashCode());
                RtcCloudSpatialAudioEngineEventHandlerNative.CallbackObject = _callbackObject;
    #endif
            }
            _AgoraRtcCloudSpatialAudioEngineEventHandlerInstance = AgoraRtcCloudSpatialAudioEngineEventHandler.GetInstance();
            RtcCloudSpatialAudioEngineEventHandlerNative.CloudSpatialAudioEngineEventHandler = _AgoraRtcCloudSpatialAudioEngineEventHandlerInstance;
        }

        private void ReleaseEventHandler()
        {
            RtcCloudSpatialAudioEngineEventHandlerNative.CloudSpatialAudioEngineEventHandler = null;
    #if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            RtcCloudSpatialAudioEngineEventHandlerNative.CallbackObject = null;
            if (_callbackObject != null) _callbackObject.Release();
            _callbackObject = null;
    #endif
            AgoraRtcNative.UnsetIrisCloudAudioEngineEventHandler(_irisApiEngine, _irisEngineEventHandlerHandleNative);
            Marshal.FreeHGlobal(_irisCEngineEventHandlerNative);
            _irisEngineEventHandlerHandleNative = IntPtr.Zero;
        }

        public override AgoraRtcCloudSpatialAudioEngineEventHandler GetAgoraRtcCloudSpatialAudioEngineEventHandler()
        {
            return _AgoraRtcCloudSpatialAudioEngineEventHandlerInstance;
        }

        public override void InitEventHandler(IAgoraRtcCloudSpatialAudioEngineEventHandler engineEventHandler)
        {
            RtcCloudSpatialAudioEngineEventHandlerNative.CloudSpatialAudioEngineEventHandler = engineEventHandler;
        }

        public override void RemoveEventHandler(IAgoraRtcCloudSpatialAudioEngineEventHandler engineEventHandler)
        {
            RtcCloudSpatialAudioEngineEventHandlerNative.CloudSpatialAudioEngineEventHandler = null;
        }

        public override int SetMaxAudioRecvCount(int maxCount)
        {
            var param = new
            {
                maxCount
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_SETMAXAUDIORECVCOUNT,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetAudioRecvRange(float range)
        {
            var param = new
            {
                range
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_SETAUDIORECVRANGE,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetDistanceUnit(float unit)
        {
            var param = new
            {
                unit
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_SETDISTANCEUNIT,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp)
        {
            var param = new
            {
                position,
                axisForward,
                axisRight,
                axisUp
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_UPDATESELFPOSITION,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection)
        {
            var param = new
            {
                position,
                axisForward,
                axisRight,
                axisUp,
                connection
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_UPDATESELFPOSITIONEX,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int UpdatePlayerPositionInfo(int playerId, float[] position, float[] forward)
        {
            RemoteVoicePositionInfo positionInfo = new RemoteVoicePositionInfo(position, forward);
            var param = new
            {
                playerId,
                positionInfo
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_UPDATEPLAYERPOSITIONINFO,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetParameters(string @params)
        {
            var param = new
            {
                @params
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_SETPARAMETERS,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int Initialize(CloudSpatialAudioConfig config)
        {
            var param = new
            {
                config
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_INITIALIZE,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnableSpatializer(bool enable, bool applyToTeam)
        {
            var param = new
            {
                enable,
                applyToTeam
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_ENABLESPATIALIZER,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetTeamId(int teamId)
        {
            var param = new
            {
                teamId
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_SETTEAMID,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetAudioRangeMode(RANGE_AUDIO_MODE_TYPE rangeMode)
        {
            var param = new
            {
                rangeMode
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_SETAUDIORANGEMODE,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int EnterRoom(string token, string roomName, uint uid)
        {
            var param = new
            {
                token,
                roomName,
                uid
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_ENTERROOM,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int ExitRoom()
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_EXITROOM,
                "", 0, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int GetTeammates(ref uint[] uids, ref int userCount)
        {
            //TODO
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_GETTEAMMATES,
                "", 0, null, 0, out _result);
            userCount = (int) AgoraJson.GetData<int>(_result.Result, "userCount");
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int RenewToken(string token)
        {
            var param = new
            {
                token
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_RENEWTOKEN,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int MuteLocalAudioStream(bool mute)
        {
            var param = new
            {
                mute
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_MUTELOCALAUDIOSTREAM,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int MuteAllRemoteAudioStreams(bool mute)
        {
            var param = new
            {
                mute
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_CLOUDSPATIALAUDIOENGINE_MUTEALLREMOTEAUDIOSTREAMS,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }
    }

    public sealed class AgoraRtcSpatialAudioEngine : IAgoraRtcSpatialAudioEngine
    {
        private IrisApiEnginePtr _irisApiEngine;
        private CharAssistant _result;
        private bool _disposed = false;
        private bool _initialized = false;
        private const int UNINITIALIZED = -99;
            
        internal AgoraRtcSpatialAudioEngine(IrisApiEnginePtr irisApiEngine)
        {
            _result = new CharAssistant();
            _irisApiEngine = irisApiEngine;
        }
            
        ~AgoraRtcSpatialAudioEngine()
        {
            Dispose();
        }
            
        public override void Dispose()
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

        public override int SetMaxAudioRecvCount(int maxCount)
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new
            {
                maxCount
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_SETMAXAUDIORECVCOUNT,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetAudioRecvRange(float range)
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new
            {
                range
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_SETAUDIORECVRANGE,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetDistanceUnit(float unit)
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new
            {
                unit
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_SETDISTANCEUNIT,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp)
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new
            {
                position,
                axisForward,
                axisRight,
                axisUp
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_UPDATESELFPOSITION,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection)
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
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_UPDATESELFPOSITIONEX,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int UpdatePlayerPositionInfo(int playerId, float[] position, float[] forward)
        {
            if (!_initialized) return UNINITIALIZED;
            RemoteVoicePositionInfo positionInfo = new RemoteVoicePositionInfo(position, forward);
            var param = new
            {
                playerId,
                positionInfo
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_UPDATEPLAYERPOSITIONINFO,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int SetParameters(string @params)
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new
            {
                @params
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_SETPARAMETERS,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int MuteLocalAudioStream(bool mute)
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new
            {
                mute
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_MUTELOCALAUDIOSTREAM,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int MuteAllRemoteAudioStreams(bool mute)
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new
            {
                mute
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_MUTEALLREMOTEAUDIOSTREAMS,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int UpdateRemotePosition(uint uid, float[] position, float[] forward)
        {
            if (!_initialized) return UNINITIALIZED;
            RemoteVoicePositionInfo posInfo = new RemoteVoicePositionInfo(position, forward);
            var param = new
            {
                uid,
                posInfo
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_UPDATEREMOTEPOSITION,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int UpdateRemotePositionEx(uint uid, float[] position, float[] forward, RtcConnection connection)
        {
            if (!_initialized) return UNINITIALIZED;
            RemoteVoicePositionInfo posInfo = new RemoteVoicePositionInfo(position, forward);
            var param = new
            {
                uid,
                posInfo,
                connection
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_UPDATEREMOTEPOSITIONEX,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int RemoveRemotePosition(uint uid)
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new
            {
                uid
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_REMOVEREMOTEPOSITION,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int RemoveRemotePositionEx(uint uid, RtcConnection connection)
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new
            {
                uid,
                connection
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_REMOVEREMOTEPOSITIONEX,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int ClearRemotePositions()
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new { };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_CLEARREMOTEPOSITIONS,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int ClearRemotePositionsEx(RtcConnection connection)
        {
            if (!_initialized) return UNINITIALIZED;
            var param = new
            {
                connection
            };
            string jsonParam = JsonMapper.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_CLEARREMOTEPOSITIONSEX,
                jsonParam, (UInt64)jsonParam.Length, null, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public override int Initialize()
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_INITIALIZE,
                "", 0, null, 0, out _result);
            var init = (int) AgoraJson.GetData<int>(_result.Result, "result");
                
            if (init == 0) _initialized = true;
            return ret != 0 ? ret : init;
        }

        // private int Release()
        // {
        //     var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
        //         AgoraApiType.Release,
        //         "", 0, null, 0, out _result);
        //     return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        // }
    }

    internal static class RtcCloudSpatialAudioEngineEventHandlerNative
    {
        internal static IAgoraRtcCloudSpatialAudioEngineEventHandler CloudSpatialAudioEngineEventHandler = null;
        internal static AgoraCallbackObject CallbackObject = null;

        [MonoPInvokeCallback(typeof(Func_Event_Native))]
        internal static void OnEvent(string @event, string data)
        {
            if (CloudSpatialAudioEngineEventHandler == null) return;
    #if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
            CallbackObject._CallbackQueue.EnQueue(() =>
            {
    #endif
                // switch(@event)
                // {
                // }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            });
#endif
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_EventWithBuffer_Native))]
#endif
        internal static void OnEventWithBuffer(string @event, string data, IntPtr buffer, uint length)
        {
            var byteData = new byte[length];
            if (buffer != IntPtr.Zero) Marshal.Copy(buffer, byteData, 0, (int) length);
    #if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
            CallbackObject._CallbackQueue.EnQueue(() =>
            {
    #endif
                switch(@event)
                {
                    case "onTokenWillExpire":
                        CloudSpatialAudioEngineEventHandler.OnTokenWillExpire();
                        break;
                    case "onConnectionStateChange":
                        CloudSpatialAudioEngineEventHandler.OnConnectionStateChange(
                            (SAE_CONNECTION_STATE_TYPE) AgoraJson.GetData<int>(data, "state"),
                            (SAE_CONNECTION_CHANGED_REASON_TYPE) AgoraJson.GetData<int>(data, "reason")
                        );
                        break;
                    case "onTeammateLeft":
                        CloudSpatialAudioEngineEventHandler.OnTeammateLeft(
                            (uint) AgoraJson.GetData<uint>(data, "uid")
                        );
                        break;
                    case "onTeammateJoined":
                        CloudSpatialAudioEngineEventHandler.OnTeammateJoined(
                            (uint) AgoraJson.GetData<uint>(data, "uid")
                        );
                        break;
                }
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
            });
#endif
        }
    }
}