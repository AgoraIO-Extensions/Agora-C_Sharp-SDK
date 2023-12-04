using System;

namespace Agora.Rtc
{
    public sealed class LocalSpatialAudioEngine : ILocalSpatialAudioEngine
    {
        private IRtcEngine _rtcEngineInstance = null;
        private LocalSpatialAudioEngineImpl _localSpatialAudioEngineImpl = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;

        private LocalSpatialAudioEngine(IRtcEngine rtcEngine, LocalSpatialAudioEngineImpl impl)
        {
            _rtcEngineInstance = rtcEngine;
            _localSpatialAudioEngineImpl = impl;
        }

        ~LocalSpatialAudioEngine()
        {
            _rtcEngineInstance = null;
        }

        private static ILocalSpatialAudioEngine instance = null;
        public static ILocalSpatialAudioEngine Instance
        {
            get
            {
                return instance;
            }
        }

        internal static ILocalSpatialAudioEngine GetInstance(IRtcEngine rtcEngine, LocalSpatialAudioEngineImpl impl)
        {
            return instance ?? (instance = new LocalSpatialAudioEngine(rtcEngine, impl));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }

        public override void Dispose()
        {
            if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
            {
                return;
            }
            _localSpatialAudioEngineImpl.Dispose();
        }

        #region terra ILocalSpatialAudioEngine
        public override int Initialize()
        {
            if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
            {
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.Initialize();
        }

        public override int UpdateRemotePosition(uint uid, RemoteVoicePositionInfo posInfo)
        {
            if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
            {
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.UpdateRemotePosition(uid, posInfo);
        }

        public override int UpdateRemotePositionEx(uint uid, RemoteVoicePositionInfo posInfo, RtcConnection connection)
        {
            if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
            {
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.UpdateRemotePositionEx(uid, posInfo, connection);
        }

        public override int RemoveRemotePosition(uint uid)
        {
            if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
            {
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.RemoveRemotePosition(uid);
        }

        public override int RemoveRemotePositionEx(uint uid, RtcConnection connection)
        {
            if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
            {
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.RemoveRemotePositionEx(uid, connection);
        }

        public override int ClearRemotePositionsEx(RtcConnection connection)
        {
            if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
            {
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.ClearRemotePositionsEx(connection);
        }

        public override int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection)
        {
            if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
            {
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.UpdateSelfPositionEx(position, axisForward, axisRight, axisUp, connection);
        }

        public override int SetMaxAudioRecvCount(int maxCount)
        {
            if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
            {
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.SetMaxAudioRecvCount(maxCount);
        }

        public override int SetAudioRecvRange(float range)
        {
            if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
            {
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.SetAudioRecvRange(range);
        }

        public override int SetDistanceUnit(float unit)
        {
            if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
            {
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.SetDistanceUnit(unit);
        }

        public override int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp)
        {
            if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
            {
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.UpdateSelfPosition(position, axisForward, axisRight, axisUp);
        }

        public override int UpdatePlayerPositionInfo(int playerId, RemoteVoicePositionInfo positionInfo)
        {
            if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
            {
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.UpdatePlayerPositionInfo(playerId, positionInfo);
        }

        public override int SetParameters(string @params)
        {
            if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
            {
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.SetParameters(@params);
        }

        public override int MuteLocalAudioStream(bool mute)
        {
            if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
            {
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.MuteLocalAudioStream(mute);
        }

        public override int MuteAllRemoteAudioStreams(bool mute)
        {
            if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
            {
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.MuteAllRemoteAudioStreams(mute);
        }

        public override int MuteRemoteAudioStream(uint uid, bool mute)
        {
            if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
            {
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.MuteRemoteAudioStream(uid, mute);
        }

        public override int SetRemoteAudioAttenuation(uint uid, double attenuation, bool forceSet)
        {
            if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
            {
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.SetRemoteAudioAttenuation(uid, attenuation, forceSet);
        }

        public override int SetZones(SpatialAudioZone[] zones, uint zoneCount)
        {
            if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
            {
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.SetZones(zones, zoneCount);
        }

        public override int SetPlayerAttenuation(int playerId, double attenuation, bool forceSet)
        {
            if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
            {
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.SetPlayerAttenuation(playerId, attenuation, forceSet);
        }

        public override int ClearRemotePositions()
        {
            if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
            {
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.ClearRemotePositions();
        }
        #endregion terra ILocalSpatialAudioEngine
    }
}