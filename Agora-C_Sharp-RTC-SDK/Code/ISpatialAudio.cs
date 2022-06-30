namespace Agora.Rtc
{
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
}