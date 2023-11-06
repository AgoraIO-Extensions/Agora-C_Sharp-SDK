using System;

namespace Agora.Rtc
{
    ///
    /// <summary>
    /// This class calculates user positions through the SDK to implement the spatial audio effect.
    /// 
    /// Before calling other APIs in this class, you need to call the Initialize method to initialize this class.
    /// </summary>
    ///
    public abstract class ILocalSpatialAudioEngine : ISpatialAudioEngineBase
    {

        #region terra ILocalSpatialAudioEngine
        [Obsolete("config The pointer to the LocalSpatialAudioConfig. See #LocalSpatialAudioConfig.")]
        public abstract int Initialize();


        public abstract int UpdateRemotePosition(uint uid, RemoteVoicePositionInfo posInfo);


        public abstract int UpdateRemotePositionEx(uint uid, RemoteVoicePositionInfo posInfo, RtcConnection connection);


        public abstract int RemoveRemotePosition(uint uid);


        public abstract int RemoveRemotePositionEx(uint uid, RtcConnection connection);


        public abstract int ClearRemotePositionsEx(RtcConnection connection);


        public abstract int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection);


        public abstract int MuteRemoteAudioStream(uint uid, bool mute);


        public abstract int SetRemoteAudioAttenuation(uint uid, double attenuation, bool forceSet);
        #endregion terra ILocalSpatialAudioEngine
    }
}