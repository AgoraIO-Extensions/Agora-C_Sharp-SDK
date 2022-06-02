using System;

namespace agora.rtc
{
    public abstract class IMediaPlayer
    {
        public abstract void Dispose();

        public abstract int GetId();

        public abstract MediaPlayerSourceObserver GetAgoraRtcMediaPlayerSourceObserver();

        public abstract void InitEventHandler(IMediaPlayerSourceObserver engineEventHandler);

        public abstract void RemoveEventHandler();

        public abstract void RegisterAudioFrameObserver(IMediaPlayerAudioFrameObserver observer);

        public abstract void RegisterAudioFrameObserver(IMediaPlayerAudioFrameObserver observer, RAW_AUDIO_FRAME_OP_MODE_TYPE mode);

        public abstract void UnregisterAudioFrameObserver();

        public abstract void RegisterMediaPlayerAudioSpectrumObserver(IAudioSpectrumObserver observer, int intervalInMS);

        public abstract void UnregisterMediaPlayerAudioSpectrumObserver();

        public abstract int Open(string url, Int64 startPos);

        public abstract int OpenWithCustomSource(Int64 startPos, IMediaPlayerCustomDataProvider provider);

        public abstract int Play();

        public abstract int Pause();

        public abstract int Stop();

        public abstract int Resume();

        public abstract int Seek(Int64 newPos);

        public abstract int GetDuration(ref Int64 duration);

        public abstract int GetPlayPosition(ref Int64 pos);

        public abstract int GetStreamCount(ref Int64 count);

        public abstract int GetStreamInfo(Int64 index, ref PlayerStreamInfo info);

        public abstract int SetLoopCount(int loopCount);

        public abstract int MuteAudio(bool audio_mute);

        public abstract bool IsAudioMuted();

        public abstract int MuteVideo(bool video_mute);

        public abstract bool IsVideoMuted();

        public abstract int SetPlaybackSpeed(int speed);

        public abstract int SelectAudioTrack(int index);

        public abstract int SetPlayerOption(string key, int value);

        public abstract int SetPlayerOption(string key, string value);

        public abstract int TakeScreenshot(string filename);

        public abstract int SelectInternalSubtitle(int index);

        public abstract int SetExternalSubtitle(string url);

        public abstract MEDIA_PLAYER_STATE GetState();

        public abstract int Mute(bool mute);

        public abstract int GetMute(ref bool mute);

        public abstract int AdjustPlayoutVolume(int volume);

        public abstract int GetPlayoutVolume(ref int volume);

        public abstract int AdjustPublishSignalVolume(int volume);

        public abstract int GetPublishSignalVolume(ref int volume);

        public abstract int SetView();

        public abstract int SetRenderMode(RENDER_MODE_TYPE renderMode);

        public abstract int SetAudioDualMonoMode(AUDIO_DUAL_MONO_MODE mode);

        public abstract string GetPlayerSdkVersion();

        public abstract string GetPlaySrc();

        public abstract int SetAudioPitch(int pitch);

        public abstract int SetSpatialAudioParams(SpatialAudioParams spatial_audio_params);

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