//  IAgoraRtcSpatialAudioEngine.cs
//
//  Created by YuGuo Chen on December 12, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;

namespace agora.rtc
{
    public abstract class IAgoraRtcCloudSpatialAudioEngine
    {
        public abstract void InitEventHandler(IAgoraRtcCloudSpatialAudioEngineEventHandler eh);

        public abstract int Initialize(CloudSpatialAudioConfig config);

        public abstract void Dispose();

        public abstract int SetMaxAudioRecvCount(int maxCount);

        public abstract int SetAudioRecvRange(float range);

        public abstract int SetDistanceUnit(float unit);

        public abstract int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp);

        public abstract int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection);

        public abstract int UpdatePlayerPositionInfo(int playerId, float[] position, float[] forward);

        public abstract int SetParameters(string @params);

        public abstract int EnableMic(bool enable);

        public abstract int EnableSpeaker(bool enable);

        public abstract int EnableSpatializer(bool enable, bool applyToTeam);

        public abstract int SetTeamId(int teamId);
  
        public abstract int SetRangeAudioMode(RANGE_AUDIO_MODE_TYPE rangeAudioMode);

        public abstract int EnterRoom(string token, string roomName, uint uid);

        public abstract int ExitRoom();

        public abstract int GetTeammates(ref uint[] uids, int[] userCount);
    }

    public abstract class IAgoraRtcSpatialAudioEngine
    {
        public abstract void Dispose();

        public abstract int SetMaxAudioRecvCount(int maxCount);

        public abstract int SetAudioRecvRange(float range);

        public abstract int SetDistanceUnit(float unit);

        public abstract int UpdateSelfPosition(float[] position, float[] axisForward, float[] axisRight, float[] axisUp);

        public abstract int UpdateSelfPositionEx(float[] position, float[] axisForward, float[] axisRight, float[] axisUp, RtcConnection connection);

        public abstract int UpdatePlayerPositionInfo(int playerId, float[] position, float[] forward);

        public abstract int SetParameters(string @params);

        public abstract int EnableMic(bool enable);

        public abstract int EnableSpeaker(bool enable);

        public abstract int UpdateRemotePosition(uint uid, float[] position, float[] forward);

        public abstract int UpdateRemotePositionEx(uint uid, float[] position, float[] forward, RtcConnection connection);

        public abstract int RemoveRemotePosition(uint uid);

        public abstract int RemoveRemotePositionEx(uint uid, RtcConnection connection);

        public abstract int ClearRemotePositions();

        public abstract int ClearRemotePositionsEx(RtcConnection connection);
    }

    public abstract class IAgoraRtcCloudSpatialAudioEngineEventHandler
    {
        public virtual void OnTokenWillExpire() {}
  
        public virtual void OnConnectionStateChange(SAE_CONNECTION_STATE_TYPE state, SAE_CONNECTION_CHANGED_REASON_TYPE reason) {}

        public virtual void OnTeammateLeft(uint uid) {}

        public virtual void OnTeammateJoined(uint uid) {}
    }
}