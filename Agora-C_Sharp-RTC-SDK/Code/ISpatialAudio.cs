namespace agora.rtc
{
    public abstract class ICloudSpatialAudioEngine
    {
        public abstract CloudSpatialAudioEventHandler GetCloudSpatialAudioEventHandler();
        
        public abstract void InitEventHandler(ICloudSpatialAudioEventHandler engineEventHandler);

        public abstract void RemoveEventHandler();

        public abstract int Initialize(CloudSpatialAudioConfig config);

        public abstract void Dispose();

        public abstract int SetMaxAudioRecvCount(int maxCount);

        public abstract int SetAudioRecvRange(float range);

        public abstract int SetDistanceUnit(float unit);

        public abstract int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp);

        public abstract int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection);

        public abstract int UpdatePlayerPositionInfo(int playerId, float[] position, float[] forward);

        public abstract int SetParameters(string @params);

        public abstract int MuteLocalAudioStream(bool mute);

        public abstract int MuteAllRemoteAudioStreams(bool mute);

        public abstract int EnableSpatializer(bool enable, bool applyToTeam);

        public abstract int SetTeamId(int teamId);
  
        public abstract int SetAudioRangeMode(AUDIO_RANGE_MODE_TYPE rangeMode);

        public abstract int EnterRoom(string token, string roomName, uint uid);

        public abstract int ExitRoom();

        public abstract int GetTeammates(ref uint[] uids, ref int userCount);

        public abstract int RenewToken(string token);
    }

    public abstract class ILocalSpatialAudioEngine
    {
        public abstract void Dispose();

        public abstract int Initialize();

        public abstract int SetMaxAudioRecvCount(int maxCount);

        public abstract int SetAudioRecvRange(float range);

        public abstract int SetDistanceUnit(float unit);

        public abstract int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp);

        public abstract int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection);

        public abstract int UpdatePlayerPositionInfo(int playerId, float[] position, float[] forward);

        public abstract int SetParameters(string @params);

        public abstract int MuteLocalAudioStream(bool mute);

        public abstract int MuteAllRemoteAudioStreams(bool mute);

        public abstract int UpdateRemotePosition(uint uid, float[] position, float[] forward);

        public abstract int UpdateRemotePositionEx(uint uid, float[] position, float[] forward, RtcConnection connection);

        public abstract int RemoveRemotePosition(uint uid);

        public abstract int RemoveRemotePositionEx(uint uid, RtcConnection connection);

        public abstract int ClearRemotePositions();

        public abstract int ClearRemotePositionsEx(RtcConnection connection);
    }

    public abstract class ICloudSpatialAudioEventHandler
    {
        public virtual void OnTokenWillExpire() {}
  
        public virtual void OnConnectionStateChange(SAE_CONNECTION_STATE_TYPE state, SAE_CONNECTION_CHANGED_REASON_TYPE reason) {}

        public virtual void OnTeammateLeft(uint uid) {}

        public virtual void OnTeammateJoined(uint uid) {}
    }
}