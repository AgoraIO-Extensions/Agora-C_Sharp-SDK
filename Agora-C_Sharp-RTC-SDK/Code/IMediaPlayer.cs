using System;

namespace agora.rtc
{
    public abstract class IMediaPlayer
    {
        public abstract void Dispose();

        public abstract int CreateMediaPlayer();

        public abstract int DestroyMediaPlayer(int playerId);

        public abstract MediaPlayerSourceObserver GetAgoraRtcMediaPlayerSourceObserver();

        public abstract void InitEventHandler(IMediaPlayerSourceObserver engineEventHandler);

        public abstract void RemoveEventHandler(IMediaPlayerSourceObserver engineEventHandler);

        public abstract void RegisterAudioFrameObserver(IMediaPlayerAudioFrameObserver observer);

        public abstract void RegisterAudioFrameObserver(IMediaPlayerAudioFrameObserver observer, RAW_AUDIO_FRAME_OP_MODE_TYPE mode);

        public abstract void UnregisterAudioFrameObserver();

        public abstract void RegisterMediaPlayerAudioSpectrumObserver(IAudioSpectrumObserver observer, int intervalInMS);

        public abstract void UnregisterMediaPlayerAudioSpectrumObserver();

        public abstract int Open(int playerId, string url, Int64 startPos);

        public abstract int OpenWithCustomSource(int playerId, Int64 startPos, IMediaPlayerCustomDataProvider provider);

        public abstract int Play(int playerId);

        public abstract int Pause(int playerId);

        public abstract int Stop(int playerId);

        public abstract int Resume(int playerId);

        public abstract int Seek(int playerId, Int64 newPos);

        public abstract int GetDuration(int playerId, ref Int64 duration);

        public abstract int GetPlayPosition(int playerId, ref Int64 pos);

        public abstract int GetStreamCount(int playerId, ref Int64 count);

        public abstract int GetStreamInfo(int playerId, Int64 index, ref PlayerStreamInfo info);

        public abstract int SetLoopCount(int playerId, int loopCount);

        public abstract int MuteAudio(int playerId, bool audio_mute);

        public abstract bool IsAudioMuted(int playerId);

        public abstract int MuteVideo(int playerId, bool video_mute);

        public abstract bool IsVideoMuted(int playerId);

        public abstract int SetPlaybackSpeed(int speed);

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

        public abstract int SetAudioPitch(int pitch);

        public abstract int SetSpatialAudioParams(int playerId, SpatialAudioParams spatial_audio_params);

        public abstract int OpenWithAgoraCDNSrc(string src, Int64 startPos);

        public abstract int GetAgoraCDNLineCount();

        public abstract int SwitchAgoraCDNLineByIndex(int index);

        public abstract int GetCurrentAgoraCDNIndex();

        public abstract int EnableAutoSwitchAgoraCDN(bool enable);

        public abstract int RenewAgoraCDNSrcToken(string token, Int64 ts);

        public abstract int SwitchAgoraCDNSrc(string src, bool syncPts = false);

        public abstract int SwitchSrc(string src, bool syncPts = true);

        public abstract int PreloadSrc(string src, Int64 startPos);

        public abstract int PlayPreloadedSrc(string src);

        public abstract int UnloadSrc(string src);
    }
}