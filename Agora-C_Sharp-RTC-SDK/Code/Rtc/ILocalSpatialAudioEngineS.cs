namespace Agora.Rtc
{
    ///
    /// <summary>
    /// This class calculates user positions through the SDK to implement the spatial audio effect.
    /// 
    /// Before calling other APIs in this class, you need to call the Initialize method to initialize this class.
    /// </summary>
    ///
    public abstract class ILocalSpatialAudioEngineS : ISpatialAudioEngineBase
    {

        #region terra ILocalSpatialAudioEngineS
        public abstract int Initialize();

        public abstract int UpdateRemotePosition(string userAccount, RemoteVoicePositionInfo posInfo);

        public abstract int UpdateRemotePositionEx(string userAccount, RemoteVoicePositionInfo posInfo, RtcConnectionS connection);

        public abstract int RemoveRemotePosition(string userAccount);

        public abstract int RemoveRemotePositionEx(string userAccount, RtcConnectionS connection);

        public abstract int ClearRemotePositionsEx(RtcConnectionS connection);

        public abstract int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnectionS connection);

        public abstract int MuteRemoteAudioStream(string userAccount, bool mute);

        public abstract int SetRemoteAudioAttenuation(string userAccount, double attenuation, bool forceSet);
        #endregion terra ILocalSpatialAudioEngineS
    }
}