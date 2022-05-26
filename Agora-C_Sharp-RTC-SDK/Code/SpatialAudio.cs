namespace agora.rtc
{
    public sealed class CloudSpatialAudioEngine : ICloudSpatialAudioEngine
    {
        private static ICloudSpatialAudioEngine instance = null;
        private CloudSpatialAudioEngineImpl _cloudSpatialAudioEngineImpl = null;
        private const string ErrorMsgLog = "[CloudSpatialAudioEngine]:ICloudSpatialAudioEngine has not been created yet!";
        private const int ErrorCode = -1;

        private CloudSpatialAudioEngine(CloudSpatialAudioEngineImpl impl)
        {
            _cloudSpatialAudioEngineImpl = impl;
        }

        internal static ICloudSpatialAudioEngine GetInstance(CloudSpatialAudioEngineImpl impl)
        {
            return instance ?? (instance = new CloudSpatialAudioEngine(impl));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }

        public override CloudSpatialAudioEventHandler GetCloudSpatialAudioEventHandler()
        {
            if (_cloudSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return null;
            }
            return _cloudSpatialAudioEngineImpl.GetCloudSpatialAudioEventHandler();
        }
        
        public override void InitEventHandler(ICloudSpatialAudioEventHandler engineEventHandler)
        {
            if (_cloudSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return;
            }
            _cloudSpatialAudioEngineImpl.InitEventHandler(engineEventHandler);
        }

        public override void RemoveEventHandler()
        {
            if (_cloudSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return;
            }
            _cloudSpatialAudioEngineImpl.RemoveEventHandler();
        }

        public override int Initialize(CloudSpatialAudioConfig config)
        {
            if (_cloudSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _cloudSpatialAudioEngineImpl.Initialize(config);
        }

        public override void Dispose()
        {
            if (_cloudSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return;
            }
            _cloudSpatialAudioEngineImpl.Dispose();
        }

        public override int SetMaxAudioRecvCount(int maxCount)
        {
            if (_cloudSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _cloudSpatialAudioEngineImpl.SetMaxAudioRecvCount(maxCount);
        }

        public override int SetAudioRecvRange(float range)
        {
            if (_cloudSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _cloudSpatialAudioEngineImpl.SetAudioRecvRange(range);
        }

        public override int SetDistanceUnit(float unit)
        {
            if (_cloudSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _cloudSpatialAudioEngineImpl.SetDistanceUnit(unit);
        }

        public override int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp)
        {
            if (_cloudSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _cloudSpatialAudioEngineImpl.UpdateSelfPosition(position, axisForward, axisRight, axisUp);
        }

        public override int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection)
        {
            if (_cloudSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _cloudSpatialAudioEngineImpl.UpdateSelfPositionEx(position, axisForward, axisRight, axisUp, connection);
        }

        public override int UpdatePlayerPositionInfo(int playerId, float[] position, float[] forward)
        {
            if (_cloudSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _cloudSpatialAudioEngineImpl.UpdatePlayerPositionInfo(playerId, position, forward);
        }

        public override int SetParameters(string @params)
        {
            if (_cloudSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _cloudSpatialAudioEngineImpl.SetParameters(@params);
        }

        public override int MuteLocalAudioStream(bool mute)
        {
            if (_cloudSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _cloudSpatialAudioEngineImpl.MuteLocalAudioStream(mute);
        }

        public override int MuteAllRemoteAudioStreams(bool mute)
        {
            if (_cloudSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _cloudSpatialAudioEngineImpl.MuteAllRemoteAudioStreams(mute);
        }

        public override int EnableSpatializer(bool enable, bool applyToTeam)
        {
            if (_cloudSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _cloudSpatialAudioEngineImpl.EnableSpatializer(enable, applyToTeam);
        }

        public override int SetTeamId(int teamId)
        {
            if (_cloudSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _cloudSpatialAudioEngineImpl.SetTeamId(teamId);
        }
  
        public override int SetAudioRangeMode(AUDIO_RANGE_MODE_TYPE rangeMode)
        {
            if (_cloudSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _cloudSpatialAudioEngineImpl.SetAudioRangeMode(rangeMode);
        }

        public override int EnterRoom(string token, string roomName, uint uid)
        {
            if (_cloudSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _cloudSpatialAudioEngineImpl.EnterRoom(token, roomName, uid);
        }

        public override int ExitRoom()
        {
            if (_cloudSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _cloudSpatialAudioEngineImpl.ExitRoom();
        }

        public override int GetTeammates(ref uint[] uids, ref int userCount)
        {
            if (_cloudSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _cloudSpatialAudioEngineImpl.GetTeammates(ref uids, ref userCount);
        }

        public override int RenewToken(string token)
        {
            if (_cloudSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _cloudSpatialAudioEngineImpl.RenewToken(token);
        }
    }

    public sealed class LocalSpatialAudioEngine : ILocalSpatialAudioEngine
    {
        private static LocalSpatialAudioEngine instance = null;
        private LocalSpatialAudioEngineImpl _localSpatialAudioEngineImpl = null;
        private const string ErrorMsgLog = "[LocalSpatialAudioEngine]:ILocalSpatialAudioEngine has not been created yet!";
        private const int ErrorCode = -1;

        private LocalSpatialAudioEngine(LocalSpatialAudioEngineImpl impl)
        {
            _localSpatialAudioEngineImpl = impl;
        }

        internal static ILocalSpatialAudioEngine GetInstance(LocalSpatialAudioEngineImpl impl)
        {
            return instance ?? (instance = new LocalSpatialAudioEngine(impl));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }

        public override void Dispose()
        {
            if (_localSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return;
            }
            _localSpatialAudioEngineImpl.Dispose();
        }

        public override int Initialize()
        {
            if (_localSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.Initialize();
        }

        public override int SetMaxAudioRecvCount(int maxCount)
        {
            if (_localSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.SetMaxAudioRecvCount(maxCount);
        }

        public override int SetAudioRecvRange(float range)
        {
            if (_localSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.SetAudioRecvRange(range);
        }

        public override int SetDistanceUnit(float unit)
        {
            if (_localSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.SetDistanceUnit(unit);
        }

        public override int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp)
        {
            if (_localSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.UpdateSelfPosition(position, axisForward, axisRight, axisUp);
        }

        public override int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection)
        {
            if (_localSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.UpdateSelfPositionEx(position, axisForward, axisRight, axisUp, connection);
        }

        public override int UpdatePlayerPositionInfo(int playerId, float[] position, float[] forward)
        {
            if (_localSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.UpdatePlayerPositionInfo(playerId, position, forward);
        }

        public override int SetParameters(string @params)
        {
            if (_localSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.SetParameters(@params);
        }

        public override int MuteLocalAudioStream(bool mute)
        {
            if (_localSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.MuteLocalAudioStream(mute);
        }

        public override int MuteAllRemoteAudioStreams(bool mute)
        {
            if (_localSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.MuteAllRemoteAudioStreams(mute);
        }

        public override int UpdateRemotePosition(uint uid, float[] position, float[] forward)
        {
            if (_localSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.UpdateRemotePosition(uid, position, forward);
        }

        public override int UpdateRemotePositionEx(uint uid, float[] position, float[] forward, RtcConnection connection)
        {
            if (_localSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.UpdateRemotePositionEx(uid, position, forward, connection);
        }

        public override int RemoveRemotePosition(uint uid)
        {
            if (_localSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.RemoveRemotePosition(uid);
        }

        public override int RemoveRemotePositionEx(uint uid, RtcConnection connection)
        {
            if (_localSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.RemoveRemotePositionEx(uid, connection);
        }

        public override int ClearRemotePositions()
        {
            if (_localSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.ClearRemotePositions();
        }

        public override int ClearRemotePositionsEx(RtcConnection connection)
        {
            if (_localSpatialAudioEngineImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _localSpatialAudioEngineImpl.ClearRemotePositionsEx(connection);
        }
    }
}