namespace Agora.Rtc
{
    ///
    /// <summary>
    /// This class calculates user positions through the SDK to implement the spatial audio effect.
    /// Before calling other APIs in this class, you need to call the Initialize method to initialize this class.
    /// </summary>
    ///
    public abstract class ILocalSpatialAudioEngine
    {
        ///
        /// <summary>
        /// Destroys ILocalSpatialAudioEngine.
        /// This method releases all resources under ILocalSpatialAudioEngine. When the user does not need to use the spatial audio effect, you can call this method to release resources for other operations. After calling this method, you can no longer use any of the APIs under ILocalSpatialAudioEngine. To use the spatial audio effect again, you need to wait until the Dispose method execution to complete before calling Initialize to create a new ILocalSpatialAudioEngine. Call this method before the Dispose method under IRtcEngine.
        /// </summary>
        ///
        public abstract void Dispose();

#region terra ILocalSpatialAudioEngine

        public abstract int SetMaxAudioRecvCount(int maxCount);

        public abstract int SetAudioRecvRange(float range);

        public abstract int SetDistanceUnit(float unit);

        public abstract int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp);

        public abstract int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection);

        public abstract int UpdatePlayerPositionInfo(int playerId, RemoteVoicePositionInfo positionInfo);

        public abstract int SetParameters(string @params);

        public abstract int MuteLocalAudioStream(bool mute);

        public abstract int MuteAllRemoteAudioStreams(bool mute);

        public abstract int SetZones(SpatialAudioZone[] zones, uint zoneCount);

        public abstract int SetPlayerAttenuation(int playerId, double attenuation, bool forceSet);

        public abstract int MuteRemoteAudioStream(uint uid, bool mute);

        public abstract int Initialize();

        public abstract int UpdateRemotePosition(uint uid, RemoteVoicePositionInfo posInfo);

        public abstract int UpdateRemotePositionEx(uint uid, RemoteVoicePositionInfo posInfo, RtcConnection connection);

        public abstract int RemoveRemotePosition(uint uid);

        public abstract int RemoveRemotePositionEx(uint uid, RtcConnection connection);

        public abstract int ClearRemotePositions();

        public abstract int ClearRemotePositionsEx(RtcConnection connection);

        public abstract int SetRemoteAudioAttenuation(uint uid, double attenuation, bool forceSet);
#endregion terra ILocalSpatialAudioEngine
    }
}