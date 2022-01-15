//  IAgoraRtcMediaPlayer.cs
//
//  Created by YuGuo Chen on December 12, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;

namespace agora.rtc
{

    public abstract class IAgoraRtcMediaPlayer : IRtcMediaPlayer
    {
    }

    public abstract class IRtcMediaPlayer
    {
        public abstract void Dispose();
        public abstract int CreateMediaPlayer();

        public abstract int DestroyMediaPlayer(int playerId);

        public abstract void InitEventHandler(IAgoraRtcMediaPlayerEventHandler engineEventHandler);

        public abstract void RegisterAudioFrameObserver(IAgoraRtcMediaPlayerAudioFrameObserver observer);

        public abstract void RegisterAudioFrameObserver(IAgoraRtcMediaPlayerAudioFrameObserver observer, RAW_AUDIO_FRAME_OP_MODE_TYPE mode);

        public abstract void UnregisterAudioFrameObserver(IAgoraRtcMediaPlayerAudioFrameObserver observer);

        public abstract void RegisterVideoFrameObserver(IAgoraRtcMediaPlayerVideoFrameObserver observer);

        public abstract void UnregisterVideoFrameObserver(IAgoraRtcMediaPlayerVideoFrameObserver observer);

        public abstract int Open(int playerId, string url, Int64 startPos);

        public abstract int OpenWithCustomSource(int playerId, Int64 startPos, IAgoraRtcMediaPlayerCustomDataProvider provider);

        public abstract int Play(int playerId);

        public abstract int Pause(int playerId);

        public abstract int Stop(int playerId);

        public abstract int Resume(int playerId);

        public abstract int Seek(int playerId, Int64 newPos);

        public abstract int GetDuration(int playerId, ref Int64 duration);

        public abstract int GetPlayPosition(int playerId, ref Int64 pos);

        public abstract int GetStreamCount(int playerId, ref Int64 count);

        public abstract int GetStreamInfo(int playerId, Int64 index, out PlayerStreamInfo info);

        public abstract int SetLoopCount(int playerId, int loopCount);

        public abstract int MuteAudio(int playerId, bool audio_mute);

        public abstract bool IsAudioMuted(int playerId);

        public abstract int MuteVideo(int playerId, bool video_mute);

        public abstract bool IsVideoMuted(int playerId);

        public abstract int ChangePlaybackSpeed(int playerId, MEDIA_PLAYER_PLAYBACK_SPEED speed);

        public abstract int SelectAudioTrack(int playerId, int index);

        public abstract int SetPlayerOption(int playerId, string key, int value);

        public abstract int SetPlayerOption(int playerId, string key, string value);

        public abstract int TakeScreenshot(int playerId, string filename);

        public abstract int SelectInternalSubtitle(int playerId, int index);

        public abstract int SetExternalSubtitle(int playerId, string url);

        public abstract MEDIA_PLAYER_STATE GetState(int playerId);

        public abstract int Mute(int playerId, bool mute);

        public abstract int GetMute(int playerId, ref bool mute);

        public abstract int AdjustPlayoutVolume(int playerId, int volume);

        public abstract int GetPlayoutVolume(int playerId, ref int volume);

        public abstract int AdjustPublishSignalVolume(int playerId, int volume);

        public abstract int GetPublishSignalVolume(int playerId, ref int volume);

        public abstract int SetView(int playerId);

        public abstract int SetRenderMode(int playerId, RENDER_MODE_TYPE renderMode);

        public abstract int SetAudioDualMonoMode(int playerId, AUDIO_DUAL_MONO_MODE mode);

        public abstract string GetPlayerSdkVersion(int playerId);

        public abstract string GetPlaySrc(int playerId);

        public abstract int SetAudioMixingPitch(int pitch);

        public abstract int SetSpatialAudioParams(int playerId, SpatialAudioParams spatial_audio_params);
    }

    public abstract class IAgoraRtcMediaPlayerEventHandler
    {
        public virtual void OnPlayerSourceStateChanged(int playerId, MEDIA_PLAYER_STATE state, MEDIA_PLAYER_ERROR ec) {}

        public virtual void OnPositionChanged(int playerId, Int64 position) {}

        public virtual void OnPlayerEvent(int playerId, MEDIA_PLAYER_EVENT @event) {}

        public virtual void OnMetaData(int playerId, byte[] data, int length) {}

        public virtual void OnPlayBufferUpdated(int playerId, Int64 playCachedBuffer) {}

        public virtual void OnCompleted(int playerId) {}
    }
}