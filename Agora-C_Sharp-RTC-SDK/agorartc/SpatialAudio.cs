namespace agora.rtc
{
    public sealed class CloudSpatialAudioEngine : ICloudSpatialAudioEngine
    {
        private static ICloudSpatialAudioEngine instance = null;
        private CloudSpatialAudioEngineImpl _cloudSpatialAudioEngineImpl = null;

        private CloudSpatialAudioEngine(CloudSpatialAudioEngineImpl impl)
        {
            _cloudSpatialAudioEngineImpl = impl;
        }

        internal static ICloudSpatialAudioEngine GetInstance(CloudSpatialAudioEngineImpl impl)
        {
            return instance ?? (instance = new CloudSpatialAudioEngine(impl));
        }

        public override CloudSpatialAudioEventHandler GetCloudSpatialAudioEventHandler()
        {
            return _cloudSpatialAudioEngineImpl.GetCloudSpatialAudioEventHandler();
        }
        
        public override void InitEventHandler(ICloudSpatialAudioEventHandler engineEventHandler)
        {
            _cloudSpatialAudioEngineImpl.InitEventHandler(engineEventHandler);
        }

        public override void RemoveEventHandler()
        {
            _cloudSpatialAudioEngineImpl.RemoveEventHandler();
        }

        public override int Initialize(CloudSpatialAudioConfig config)
        {
            return _cloudSpatialAudioEngineImpl.Initialize(config);
        }

        public override void Dispose()
        {
            _cloudSpatialAudioEngineImpl.Dispose();
        }

        public override int SetMaxAudioRecvCount(int maxCount)
        {
            return _cloudSpatialAudioEngineImpl.SetMaxAudioRecvCount(maxCount);
        }

        public override int SetAudioRecvRange(float range)
        {
            return _cloudSpatialAudioEngineImpl.SetAudioRecvRange(range);
        }

        public override int SetDistanceUnit(float unit)
        {
            return _cloudSpatialAudioEngineImpl.SetDistanceUnit(unit);
        }

        public override int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp)
        {
            return _cloudSpatialAudioEngineImpl.UpdateSelfPosition(position, axisForward, axisRight, axisUp);
        }

        public override int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection)
        {
            return _cloudSpatialAudioEngineImpl.UpdateSelfPositionEx(position, axisForward, axisRight, axisUp, connection);
        }

        public override int UpdatePlayerPositionInfo(int playerId, float[] position, float[] forward)
        {
            return _cloudSpatialAudioEngineImpl.UpdatePlayerPositionInfo(playerId, position, forward);
        }

        public override int SetParameters(string @params)
        {
            return _cloudSpatialAudioEngineImpl.SetParameters(@params);
        }

        public override int MuteLocalAudioStream(bool mute)
        {
            return _cloudSpatialAudioEngineImpl.MuteLocalAudioStream(mute);
        }

        public override int MuteAllRemoteAudioStreams(bool mute)
        {
            return _cloudSpatialAudioEngineImpl.MuteAllRemoteAudioStreams(mute);
        }

        public override int EnableSpatializer(bool enable, bool applyToTeam)
        {
            return _cloudSpatialAudioEngineImpl.EnableSpatializer(enable, applyToTeam);
        }

        public override int SetTeamId(int teamId)
        {
            return _cloudSpatialAudioEngineImpl.SetTeamId(teamId);
        }
  
        public override int SetAudioRangeMode(AUDIO_RANGE_MODE_TYPE rangeMode)
        {
            return _cloudSpatialAudioEngineImpl.SetAudioRangeMode(rangeMode);
        }

        public override int EnterRoom(string token, string roomName, uint uid)
        {
            return _cloudSpatialAudioEngineImpl.EnterRoom(token, roomName, uid);
        }

        public override int ExitRoom()
        {
            return _cloudSpatialAudioEngineImpl.ExitRoom();
        }

        public override int GetTeammates(ref uint[] uids, ref int userCount)
        {
            return _cloudSpatialAudioEngineImpl.GetTeammates(ref uids, ref userCount);
        }

        public override int RenewToken(string token)
        {
            return _cloudSpatialAudioEngineImpl.RenewToken(token);
        }
    }

    public sealed class LocalSpatialAudioEngine : ILocalSpatialAudioEngine
    {
        private static LocalSpatialAudioEngine instance = null;
        private LocalSpatialAudioEngineImpl _localSpatialAudioEngineImpl = null;

        private LocalSpatialAudioEngine(LocalSpatialAudioEngineImpl impl)
        {
            _localSpatialAudioEngineImpl = impl;
        }

        internal static ILocalSpatialAudioEngine GetInstance(LocalSpatialAudioEngineImpl impl)
        {
            return instance ?? (instance = new LocalSpatialAudioEngine(impl));
        }

        public override void Dispose()
        {
            _localSpatialAudioEngineImpl.Dispose();
        }

        public override int Initialize()
        {
            return _localSpatialAudioEngineImpl.Initialize();
        }

        public override int SetMaxAudioRecvCount(int maxCount)
        {
            return _localSpatialAudioEngineImpl.SetMaxAudioRecvCount(maxCount);
        }

        public override int SetAudioRecvRange(float range)
        {
            return _localSpatialAudioEngineImpl.SetAudioRecvRange(range);
        }

        public override int SetDistanceUnit(float unit)
        {
            return _localSpatialAudioEngineImpl.SetDistanceUnit(unit);
        }

        public override int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp)
        {
            return _localSpatialAudioEngineImpl.UpdateSelfPosition(position, axisForward, axisRight, axisUp);
        }

        public override int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection)
        {
            return _localSpatialAudioEngineImpl.UpdateSelfPositionEx(position, axisForward, axisRight, axisUp, connection);
        }

        public override int UpdatePlayerPositionInfo(int playerId, float[] position, float[] forward)
        {
            return _localSpatialAudioEngineImpl.UpdatePlayerPositionInfo(playerId, position, forward);
        }

        public override int SetParameters(string @params)
        {
            return _localSpatialAudioEngineImpl.SetParameters(@params);
        }

        public override int MuteLocalAudioStream(bool mute)
        {
            return _localSpatialAudioEngineImpl.MuteLocalAudioStream(mute);
        }

        public override int MuteAllRemoteAudioStreams(bool mute)
        {
            return _localSpatialAudioEngineImpl.MuteAllRemoteAudioStreams(mute);
        }

        public override int UpdateRemotePosition(uint uid, float[] position, float[] forward)
        {
            return _localSpatialAudioEngineImpl.UpdateRemotePosition(uid, position, forward);
        }

        public override int UpdateRemotePositionEx(uint uid, float[] position, float[] forward, RtcConnection connection)
        {
            return _localSpatialAudioEngineImpl.UpdateRemotePositionEx(uid, position, forward, connection);
        }

        public override int RemoveRemotePosition(uint uid)
        {
            return _localSpatialAudioEngineImpl.RemoveRemotePosition(uid);
        }

        public override int RemoveRemotePositionEx(uint uid, RtcConnection connection)
        {
            return _localSpatialAudioEngineImpl.RemoveRemotePositionEx(uid, connection);
        }

        public override int ClearRemotePositions()
        {
            return _localSpatialAudioEngineImpl.ClearRemotePositions();
        }

        public override int ClearRemotePositionsEx(RtcConnection connection)
        {
            return _localSpatialAudioEngineImpl.ClearRemotePositionsEx(connection);
        }
    }
}