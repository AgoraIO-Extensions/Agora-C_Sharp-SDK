namespace Agora.Rtc
{
    public sealed class LocalSpatialAudioEngine : ILocalSpatialAudioEngine
    {
        private IRtcEngine _rtcEngineInstance = null;
        private LocalSpatialAudioEngineImpl _localSpatialAudioEngineImpl = null;
        private const int ErrorCode = -7;
        private static System.Object rtcLock = new System.Object();

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
                lock (rtcLock)
                {
                    return instance;
                }
            }
        }

        public override void Dispose()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
                {
                    return;
                }
                _localSpatialAudioEngineImpl.Dispose();
            }
        }

        public override int Initialize()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _localSpatialAudioEngineImpl.Initialize();
            }
        }

        public override int SetMaxAudioRecvCount(int maxCount)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _localSpatialAudioEngineImpl.SetMaxAudioRecvCount(maxCount);
            }
        }

        public override int SetAudioRecvRange(float range)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _localSpatialAudioEngineImpl.SetAudioRecvRange(range);
            }
        }

        public override int SetDistanceUnit(float unit)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _localSpatialAudioEngineImpl.SetDistanceUnit(unit);
            }
        }

        public override int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _localSpatialAudioEngineImpl.UpdateSelfPosition(position, axisForward, axisRight, axisUp);
            }
        }

        public override int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _localSpatialAudioEngineImpl.UpdateSelfPositionEx(position, axisForward, axisRight, axisUp, connection);
            }
        }

        public override int UpdatePlayerPositionInfo(int playerId, RemoteVoicePositionInfo positionInfo)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _localSpatialAudioEngineImpl.UpdatePlayerPositionInfo(playerId, positionInfo);
            }
        }

        public override int SetParameters(string @params)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _localSpatialAudioEngineImpl.SetParameters(@params);
            }
        }

        public override int MuteLocalAudioStream(bool mute)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _localSpatialAudioEngineImpl.MuteLocalAudioStream(mute);
            }
        }

        public override int MuteAllRemoteAudioStreams(bool mute)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _localSpatialAudioEngineImpl.MuteAllRemoteAudioStreams(mute);
            }
        }

        public override int UpdateRemotePosition(uint uid, RemoteVoicePositionInfo posInfo)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _localSpatialAudioEngineImpl.UpdateRemotePosition(uid, posInfo);
            }
        }

        public override int UpdateRemotePositionEx(uint uid, RemoteVoicePositionInfo posInfo, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _localSpatialAudioEngineImpl.UpdateRemotePositionEx(uid, posInfo, connection);
            }
        }

        public override int RemoveRemotePosition(uint uid)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _localSpatialAudioEngineImpl.RemoveRemotePosition(uid);
            }
        }

        public override int RemoveRemotePositionEx(uint uid, RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _localSpatialAudioEngineImpl.RemoveRemotePositionEx(uid, connection);
            }
        }

        public override int ClearRemotePositions()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _localSpatialAudioEngineImpl.ClearRemotePositions();
            }
        }

        public override int ClearRemotePositionsEx(RtcConnection connection)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _localSpatialAudioEngineImpl.ClearRemotePositionsEx(connection);
            }
        }

        public override int SetZones(SpatialAudioZone[] zones, uint zoneCount)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _localSpatialAudioEngineImpl.SetZones(zones, zoneCount);
            }
        }

        public override int SetPlayerAttenuation(int playerId, double attenuation, bool forceSet)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _localSpatialAudioEngineImpl.SetPlayerAttenuation(playerId, attenuation, forceSet);
            }
        }

        public override int MuteRemoteAudioStream(uint uid, bool mute)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _localSpatialAudioEngineImpl.MuteRemoteAudioStream(uid, mute);
            }
        }

        public override int SetRemoteAudioAttenuation(uint uid, double attenuation, bool forceSet)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _localSpatialAudioEngineImpl == null)
                {
                    return ErrorCode;
                }
                return _localSpatialAudioEngineImpl.SetRemoteAudioAttenuation(uid, attenuation, forceSet);
            }
        }

        internal static ILocalSpatialAudioEngine GetInstance(IRtcEngine rtcEngine, LocalSpatialAudioEngineImpl impl)
        {
            lock (rtcLock)
            {
                return instance ?? (instance = new LocalSpatialAudioEngine(rtcEngine, impl));
            }
        }

        internal static void ReleaseInstance()
        {
            lock (rtcLock)
            {
                instance = null;
            }
        }


    }
}