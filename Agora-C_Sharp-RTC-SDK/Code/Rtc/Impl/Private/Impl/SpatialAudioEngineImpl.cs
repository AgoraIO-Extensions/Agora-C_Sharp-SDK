using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS 
using AOT;
#endif

namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;
    using IrisEventHandlerHandleNative = IntPtr;

    public class LocalSpatialAudioEngineImpl
    {
        private IrisApiEnginePtr _irisApiEngine;
        private IrisRtcCApiParam _apiParam;
        private bool _disposed = false;
        private bool _initialized = false;
        private const int UNINITIALIZED = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;

        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

        internal LocalSpatialAudioEngineImpl(IrisApiEnginePtr irisApiEngine)
        {
            _apiParam = new IrisRtcCApiParam();
            _apiParam.AllocResult();
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
                _disposed = true;
            }

            _irisApiEngine = IntPtr.Zero;
            _apiParam.FreeResult();
            GC.SuppressFinalize(this);
        }

        public int SetMaxAudioRecvCount(int maxCount)
        {
            if (!_initialized) return UNINITIALIZED;

            return AgoraRtcNative.ILocalSpatialAudioEngine_SetMaxAudioRecvCount(_irisApiEngine, maxCount);
        }

        public int SetAudioRecvRange(float range)
        {
            if (!_initialized) return UNINITIALIZED;

            return AgoraRtcNative.ILocalSpatialAudioEngine_SetAudioRecvRange(_irisApiEngine, range);
        }

        public int SetDistanceUnit(float unit)
        {
            if (!_initialized) return UNINITIALIZED;

            return AgoraRtcNative.ILocalSpatialAudioEngine_SetDistanceUnit(_irisApiEngine, unit);
        }

        public int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp)
        {
            if (!_initialized) return UNINITIALIZED;

            return AgoraRtcNative.ILocalSpatialAudioEngine_UpdateSelfPosition(_irisApiEngine,
                    position[0], position[1], position[2],
                    axisForward[0], axisForward[1], axisForward[2],
                    axisRight[0], axisRight[1], axisRight[2],
                    axisUp[0], axisUp[1], axisUp[2]
                );
        }

        public int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection)
        {
            if (!_initialized) return UNINITIALIZED;

            return AgoraRtcNative.ILocalSpatialAudioEngine_UpdateSelfPositionEx(_irisApiEngine,
                    position[0], position[1], position[2],
                    axisForward[0], axisForward[1], axisForward[2],
                    axisRight[0], axisRight[1], axisRight[2],
                    axisUp[0], axisUp[1], axisUp[2],
                    connection.channelId, connection.localUid
                );
        }

        public int UpdatePlayerPositionInfo(int playerId, RemoteVoicePositionInfo positionInfo)
        {
            if (!_initialized) return UNINITIALIZED;

            return AgoraRtcNative.ILocalSpatialAudioEngine_UpdatePlayerPositionInfo(_irisApiEngine, playerId,
                positionInfo.position[0], positionInfo.position[1], positionInfo.position[2],
                positionInfo.forward[0], positionInfo.forward[1], positionInfo.forward[2]);
        }

        public int SetParameters(string @params)
        {
            if (!_initialized) return UNINITIALIZED;
            _param.Clear();
            _param.Add("params", @params);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_SETPARAMETERS,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int MuteLocalAudioStream(bool mute)
        {
            if (!_initialized) return UNINITIALIZED;

            return AgoraRtcNative.ILocalSpatialAudioEngine_MuteLocalAudioStream(_irisApiEngine, mute);
        }

        public int MuteAllRemoteAudioStreams(bool mute)
        {
            if (!_initialized) return UNINITIALIZED;

            return AgoraRtcNative.ILocalSpatialAudioEngine_MuteAllRemoteAudioStreams(_irisApiEngine, mute);
        }


        public int SetZones(SpatialAudioZone[] zones, uint zoneCount)
        {
            if (!_initialized) return UNINITIALIZED;

            IrisSpatialAudioZone[] irisSpatialAudioZones = new IrisSpatialAudioZone[zoneCount];
            for (int i = 0; i < zoneCount; i++)
            {
                irisSpatialAudioZones[i] = new IrisSpatialAudioZone(zones[i]);
            }

            return AgoraRtcNative.ILocalSpatialAudioEngine_SetZones(_irisApiEngine, irisSpatialAudioZones, zoneCount);
        }

        public int SetPlayerAttenuation(int playerId, double attenuation, bool forceSet)
        {
            if (!_initialized) return UNINITIALIZED;

            return AgoraRtcNative.ILocalSpatialAudioEngine_SetPlayerAttenuation(_irisApiEngine, playerId, attenuation, forceSet);
        }

        public int MuteRemoteAudioStream(uint uid, bool mute)
        {
            if (!_initialized) return UNINITIALIZED;

            return AgoraRtcNative.ILocalSpatialAudioEngine_MuteRemoteAudioStream(_irisApiEngine, uid, mute);
        }

        public int UpdateRemotePosition(uint uid, RemoteVoicePositionInfo posInfo)
        {
            if (!_initialized) return UNINITIALIZED;

            return AgoraRtcNative.ILocalSpatialAudioEngine_UpdateRemotePosition(_irisApiEngine, uid,
                posInfo.position[0], posInfo.position[1], posInfo.position[2],
                posInfo.forward[0], posInfo.forward[1], posInfo.forward[2]);
        }

        public int UpdateRemotePositionEx(uint uid, RemoteVoicePositionInfo posInfo, RtcConnection connection)
        {
            if (!_initialized) return UNINITIALIZED;

            return AgoraRtcNative.ILocalSpatialAudioEngine_UpdateRemotePositionEx(_irisApiEngine, uid,
                posInfo.position[0], posInfo.position[1], posInfo.position[2],
                posInfo.forward[0], posInfo.forward[1], posInfo.forward[2],
                connection.channelId, connection.localUid);
        }

        public int RemoveRemotePosition(uint uid)
        {
            if (!_initialized) return UNINITIALIZED;

            return AgoraRtcNative.ILocalSpatialAudioEngine_RemoveRemotePosition(_irisApiEngine, uid);
        }

        public int RemoveRemotePositionEx(uint uid, RtcConnection connection)
        {
            if (!_initialized) return UNINITIALIZED;

            return AgoraRtcNative.ILocalSpatialAudioEngine_RemoveRemotePositionEx(_irisApiEngine, uid, connection.channelId, connection.localUid);
        }

        public int ClearRemotePositions()
        {
            if (!_initialized) return UNINITIALIZED;

            return AgoraRtcNative.ILocalSpatialAudioEngine_ClearRemotePositions(_irisApiEngine);
        }

        public int ClearRemotePositionsEx(RtcConnection connection)
        {
            if (!_initialized) return UNINITIALIZED;

            return AgoraRtcNative.ILocalSpatialAudioEngine_ClearRemotePositionsEx(_irisApiEngine, connection.channelId, connection.localUid);
        }

        public int SetRemoteAudioAttenuation(uint uid, double attenuation, bool forceSet)
        {
            if (!_initialized) return UNINITIALIZED;

            return AgoraRtcNative.ILocalSpatialAudioEngine_SetRemoteAudioAttenuation(_irisApiEngine, uid, attenuation, forceSet);
        }


        public int Initialize()
        {
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_LOCALSPATIALAUDIOENGINE_INITIALIZE,
                "", 0, IntPtr.Zero, 0, ref _apiParam);

            if (ret != 0)
            {
                return ret;
            }

            var init = (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (init == 0)
            {
                _initialized = true;
            }
            return init;
        }
    }
}