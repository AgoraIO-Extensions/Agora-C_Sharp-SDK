namespace Agora.Rtc
{
    /* class_ilocalspatialaudioengine */
    public abstract class ILocalSpatialAudioEngine
    {
        /* api_ilocalspatialaudioengine_dispose */
        public abstract void Dispose();

#region terra ILocalSpatialAudioEngine

        /* api_ilocalspatialaudioengine_setmaxaudiorecvcount */
        public abstract int SetMaxAudioRecvCount(int maxCount);

        /* api_ilocalspatialaudioengine_setaudiorecvrange */
        public abstract int SetAudioRecvRange(float range);

        /* api_ilocalspatialaudioengine_setdistanceunit */
        public abstract int SetDistanceUnit(float unit);

        /* api_ilocalspatialaudioengine_updateselfposition */
        public abstract int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp);

        /* api_ilocalspatialaudioengine_updateselfpositionex */
        public abstract int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection);

        /* api_ilocalspatialaudioengine_updateplayerpositioninfo */
        public abstract int UpdatePlayerPositionInfo(int playerId, RemoteVoicePositionInfo positionInfo);

        /* api_ilocalspatialaudioengine_setparameters */
        public abstract int SetParameters(string @params);

        /* api_ilocalspatialaudioengine_mutelocalaudiostream */
        public abstract int MuteLocalAudioStream(bool mute);

        /* api_ilocalspatialaudioengine_muteallremoteaudiostreams */
        public abstract int MuteAllRemoteAudioStreams(bool mute);

        /* api_ilocalspatialaudioengine_setzones */
        public abstract int SetZones(SpatialAudioZone[] zones, uint zoneCount);

        /* api_ilocalspatialaudioengine_setplayerattenuation */
        public abstract int SetPlayerAttenuation(int playerId, double attenuation, bool forceSet);

        /* api_ilocalspatialaudioengine_muteremoteaudiostream */
        public abstract int MuteRemoteAudioStream(uint uid, bool mute);

        /* api_ilocalspatialaudioengine_initialize */
        public abstract int Initialize();

        /* api_ilocalspatialaudioengine_updateremoteposition */
        public abstract int UpdateRemotePosition(uint uid, RemoteVoicePositionInfo posInfo);

        /* api_ilocalspatialaudioengine_updateremotepositionex */
        public abstract int UpdateRemotePositionEx(uint uid, RemoteVoicePositionInfo posInfo, RtcConnection connection);

        /* api_ilocalspatialaudioengine_removeremoteposition */
        public abstract int RemoveRemotePosition(uint uid);

        /* api_ilocalspatialaudioengine_removeremotepositionex */
        public abstract int RemoveRemotePositionEx(uint uid, RtcConnection connection);

        /* api_ilocalspatialaudioengine_clearremotepositions */
        public abstract int ClearRemotePositions();

        /* api_ilocalspatialaudioengine_clearremotepositionsex */
        public abstract int ClearRemotePositionsEx(RtcConnection connection);

        /* api_ilocalspatialaudioengine_setremoteaudioattenuation */
        public abstract int SetRemoteAudioAttenuation(uint uid, double attenuation, bool forceSet);
#endregion terra ILocalSpatialAudioEngine
    }
}