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
    public abstract class ILocalSpatialAudioEngine
    {

        #region terra ILocalSpatialAudioEngine
        public abstract int Initialize();

        public abstract int UpdateRemotePosition(uint uid, RemoteVoicePositionInfo posInfo);

        public abstract int UpdateRemotePositionEx(uint uid, RemoteVoicePositionInfo posInfo, RtcConnection connection);

        public abstract int RemoveRemotePosition(uint uid);

        public abstract int RemoveRemotePositionEx(uint uid, RtcConnection connection);

        public abstract int ClearRemotePositionsEx(RtcConnection connection);

        public abstract int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection);

        public abstract int SetMaxAudioRecvCount(int maxCount);

        public abstract int SetAudioRecvRange(float range);

        public abstract int SetDistanceUnit(float unit);

        public abstract int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp);

        public abstract int UpdatePlayerPositionInfo(int playerId, RemoteVoicePositionInfo positionInfo);

        public abstract int SetParameters(string @params);

        public abstract int MuteLocalAudioStream(bool mute);

        public abstract int MuteAllRemoteAudioStreams(bool mute);

        public abstract int MuteRemoteAudioStream(uint uid, bool mute);

        public abstract int SetRemoteAudioAttenuation(uint uid, double attenuation, bool forceSet);

        public abstract int SetZones(SpatialAudioZone[] zones, uint zoneCount);

        public abstract int SetPlayerAttenuation(int playerId, double attenuation, bool forceSet);

        public abstract int ClearRemotePositions();
        #endregion terra ILocalSpatialAudioEngine
    }
}