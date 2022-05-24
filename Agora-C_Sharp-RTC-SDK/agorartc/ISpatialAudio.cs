using System;

namespace agora.rtc
{
    public class ICloudSpatialAudioEngine
    {
        private static ICloudSpatialAudioEngine instance = null;
        private CloudSpatialAudioEngineImpl _cloudSpatialAudioEngineImpl = null;

        private ICloudSpatialAudioEngine(CloudSpatialAudioEngineImpl impl)
        {
            _cloudSpatialAudioEngineImpl = impl;
        }

        internal static ICloudSpatialAudioEngine GetInstance(CloudSpatialAudioEngineImpl impl)
        {
            return instance ?? (instance = new ICloudSpatialAudioEngine(impl));
        }

        public CloudSpatialAudioEventHandler GetCloudSpatialAudioEventHandler()
        {
            return _cloudSpatialAudioEngineImpl.GetCloudSpatialAudioEventHandler();
        }
        
        public void InitEventHandler(ICloudSpatialAudioEventHandler engineEventHandler)
        {
            _cloudSpatialAudioEngineImpl.InitEventHandler(engineEventHandler);
        }

        public void RemoveEventHandler()
        {
            _cloudSpatialAudioEngineImpl.RemoveEventHandler();
        }

        public int Initialize(CloudSpatialAudioConfig config)
        {
            return _cloudSpatialAudioEngineImpl.Initialize(config);
        }

        public void Dispose()
        {
            _cloudSpatialAudioEngineImpl.Dispose();
        }

        public int SetMaxAudioRecvCount(int maxCount)
        {
            return _cloudSpatialAudioEngineImpl.SetMaxAudioRecvCount(maxCount);
        }

        public int SetAudioRecvRange(float range)
        {
            return _cloudSpatialAudioEngineImpl.SetAudioRecvRange(range);
        }

        public int SetDistanceUnit(float unit)
        {
            return _cloudSpatialAudioEngineImpl.SetDistanceUnit(unit);
        }

        public int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp)
        {
            return _cloudSpatialAudioEngineImpl.UpdateSelfPosition(position, axisForward, axisRight, axisUp);
        }

        public int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection)
        {
            return _cloudSpatialAudioEngineImpl.UpdateSelfPositionEx(position, axisForward, axisRight, axisUp, connection);
        }

        public int UpdatePlayerPositionInfo(int playerId, float[] position, float[] forward)
        {
            return _cloudSpatialAudioEngineImpl.UpdatePlayerPositionInfo(playerId, position, forward);
        }

        public int SetParameters(string @params)
        {
            return _cloudSpatialAudioEngineImpl.SetParameters(@params);
        }

        public int MuteLocalAudioStream(bool mute)
        {
            return _cloudSpatialAudioEngineImpl.MuteLocalAudioStream(mute);
        }

        public int MuteAllRemoteAudioStreams(bool mute)
        {
            return _cloudSpatialAudioEngineImpl.MuteAllRemoteAudioStreams(mute);
        }

        public int EnableSpatializer(bool enable, bool applyToTeam)
        {
            return _cloudSpatialAudioEngineImpl.EnableSpatializer(enable, applyToTeam);
        }

        public int SetTeamId(int teamId)
        {
            return _cloudSpatialAudioEngineImpl.SetTeamId(teamId);
        }
  
        public int SetAudioRangeMode(AUDIO_RANGE_MODE_TYPE rangeMode)
        {
            return _cloudSpatialAudioEngineImpl.SetAudioRangeMode(rangeMode);
        }

        public int EnterRoom(string token, string roomName, uint uid)
        {
            return _cloudSpatialAudioEngineImpl.EnterRoom(token, roomName, uid);
        }

        public int ExitRoom()
        {
            return _cloudSpatialAudioEngineImpl.ExitRoom();
        }

        public int GetTeammates(ref uint[] uids, ref int userCount)
        {
            return _cloudSpatialAudioEngineImpl.GetTeammates(ref uids, ref userCount);
        }

        public int RenewToken(string token)
        {
            return _cloudSpatialAudioEngineImpl.RenewToken(token);
        }
    }

    public class ILocalSpatialAudioEngine
    {
        private static ILocalSpatialAudioEngine instance = null;
        private LocalSpatialAudioEngineImpl _localSpatialAudioEngineImpl = null;

        private ILocalSpatialAudioEngine(LocalSpatialAudioEngineImpl impl)
        {
            _localSpatialAudioEngineImpl = impl;
        }

        internal static ILocalSpatialAudioEngine GetInstance(LocalSpatialAudioEngineImpl impl)
        {
            return instance ?? (instance = new ILocalSpatialAudioEngine(impl));
        }

        public void Dispose()
        {
            _localSpatialAudioEngineImpl.Dispose();
        }

        public int Initialize()
        {
            return _localSpatialAudioEngineImpl.Initialize();
        }

        public int SetMaxAudioRecvCount(int maxCount)
        {
            return _localSpatialAudioEngineImpl.SetMaxAudioRecvCount(maxCount);
        }

        public int SetAudioRecvRange(float range)
        {
            return _localSpatialAudioEngineImpl.SetAudioRecvRange(range);
        }

        public int SetDistanceUnit(float unit)
        {
            return _localSpatialAudioEngineImpl.SetDistanceUnit(unit);
        }

        public int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp)
        {
            return _localSpatialAudioEngineImpl.UpdateSelfPosition(position, axisForward, axisRight, axisUp);
        }

        public int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection)
        {
            return _localSpatialAudioEngineImpl.UpdateSelfPositionEx(position, axisForward, axisRight, axisUp, connection);
        }

        public int UpdatePlayerPositionInfo(int playerId, float[] position, float[] forward)
        {
            return _localSpatialAudioEngineImpl.UpdatePlayerPositionInfo(playerId, position, forward);
        }

        public int SetParameters(string @params)
        {
            return _localSpatialAudioEngineImpl.SetParameters(@params);
        }

        public int MuteLocalAudioStream(bool mute)
        {
            return _localSpatialAudioEngineImpl.MuteLocalAudioStream(mute);
        }

        public int MuteAllRemoteAudioStreams(bool mute)
        {
            return _localSpatialAudioEngineImpl.MuteAllRemoteAudioStreams(mute);
        }

        public int UpdateRemotePosition(uint uid, float[] position, float[] forward)
        {
            return _localSpatialAudioEngineImpl.UpdateRemotePosition(uid, position, forward);
        }

        public int UpdateRemotePositionEx(uint uid, float[] position, float[] forward, RtcConnection connection)
        {
            return _localSpatialAudioEngineImpl.UpdateRemotePositionEx(uid, position, forward, connection);
        }

        public int RemoveRemotePosition(uint uid)
        {
            return _localSpatialAudioEngineImpl.RemoveRemotePosition(uid);
        }

        public int RemoveRemotePositionEx(uint uid, RtcConnection connection)
        {
            return _localSpatialAudioEngineImpl.RemoveRemotePositionEx(uid, connection);
        }

        public int ClearRemotePositions()
        {
            return _localSpatialAudioEngineImpl.ClearRemotePositions();
        }

        public int ClearRemotePositionsEx(RtcConnection connection)
        {
            return _localSpatialAudioEngineImpl.ClearRemotePositionsEx(connection);
        }
    }

    public class ICloudSpatialAudioEventHandler
    {
        public virtual void OnTokenWillExpire() {}
  
        public virtual void OnConnectionStateChange(SAE_CONNECTION_STATE_TYPE state, SAE_CONNECTION_CHANGED_REASON_TYPE reason) {}

        public virtual void OnTeammateLeft(uint uid) {}

        public virtual void OnTeammateJoined(uint uid) {}
    }
}