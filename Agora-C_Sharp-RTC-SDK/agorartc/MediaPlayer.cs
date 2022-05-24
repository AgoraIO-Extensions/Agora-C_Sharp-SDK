using System;

namespace agora.rtc
{
    public sealed class MediaPlayer : IMediaPlayer
    {
        private static IMediaPlayer instance = null;
        private MediaPlayerImpl _mediaPlayerImpl = null;

        private MediaPlayer(MediaPlayerImpl impl)
        {
            _mediaPlayerImpl = impl;
        }

        internal static IMediaPlayer GetInstance(MediaPlayerImpl impl)
        {
            return instance ?? (instance = new MediaPlayer(impl));
        }

        public override void Dispose()
        {
            _mediaPlayerImpl.Dispose();
        }

        public override int CreateMediaPlayer()
        {
            return _mediaPlayerImpl.CreateMediaPlayer();
        }

        public override int DestroyMediaPlayer(int playerId)
        {
            return _mediaPlayerImpl.DestroyMediaPlayer(playerId);
        }

        public override MediaPlayerSourceObserver GetAgoraRtcMediaPlayerSourceObserver()
        {
            return _mediaPlayerImpl.GetAgoraRtcMediaPlayerSourceObserver();
        }

        public override void InitEventHandler(IMediaPlayerSourceObserver engineEventHandler)
        {
            _mediaPlayerImpl.InitEventHandler(engineEventHandler);
        }

        public override void RemoveEventHandler(IMediaPlayerSourceObserver engineEventHandler)
        {
            _mediaPlayerImpl.RemoveEventHandler(engineEventHandler);
        }

        public override void RegisterAudioFrameObserver(IMediaPlayerAudioFrameObserver observer)
        {
            _mediaPlayerImpl.RegisterAudioFrameObserver(observer);
        }

        public override void RegisterAudioFrameObserver(IMediaPlayerAudioFrameObserver observer, RAW_AUDIO_FRAME_OP_MODE_TYPE mode)
        {
            _mediaPlayerImpl.RegisterAudioFrameObserver(observer, mode);
        }

        public override void UnregisterAudioFrameObserver()
        {
            _mediaPlayerImpl.UnregisterAudioFrameObserver();
        }

        public override void RegisterMediaPlayerAudioSpectrumObserver(IAudioSpectrumObserver observer, int intervalInMS)
        {
            _mediaPlayerImpl.RegisterMediaPlayerAudioSpectrumObserver(observer, intervalInMS);
        }

        public override void UnregisterMediaPlayerAudioSpectrumObserver()
        {
            _mediaPlayerImpl.UnregisterMediaPlayerAudioSpectrumObserver();
        }

        public override int Open(int playerId, string url, Int64 startPos)
        {
            return _mediaPlayerImpl.Open(playerId, url, startPos);
        }

        public override int OpenWithCustomSource(int playerId, Int64 startPos, IMediaPlayerCustomDataProvider provider)
        {
            return _mediaPlayerImpl.OpenWithCustomSource(playerId, startPos, provider);
        }

        public override int Play(int playerId)
        {
            return _mediaPlayerImpl.Play(playerId);
        }

        public override int Pause(int playerId)
        {
            return _mediaPlayerImpl.Pause(playerId);
        }

        public override int Stop(int playerId)
        {
            return _mediaPlayerImpl.Stop(playerId);
        }

        public override int Resume(int playerId)
        {
            return _mediaPlayerImpl.Resume(playerId);
        }

        public override int Seek(int playerId, Int64 newPos)
        {
            return _mediaPlayerImpl.Seek(playerId, newPos);
        }

        public override int GetDuration(int playerId, ref Int64 duration)
        {
            return _mediaPlayerImpl.GetDuration(playerId, ref duration);
        }

        public override int GetPlayPosition(int playerId, ref Int64 pos)
        {
            return _mediaPlayerImpl.GetPlayPosition(playerId, ref pos);
        }

        public override int GetStreamCount(int playerId, ref Int64 count)
        {
            return _mediaPlayerImpl.GetStreamCount(playerId, ref count);
        }

        public override int GetStreamInfo(int playerId, Int64 index, out PlayerStreamInfo info)
        {
            return _mediaPlayerImpl.GetStreamInfo(playerId, index, out info);
        }

        public override int SetLoopCount(int playerId, int loopCount)
        {
            return _mediaPlayerImpl.SetLoopCount(playerId, loopCount);
        }

        public override int MuteAudio(int playerId, bool audio_mute)
        {
            return _mediaPlayerImpl.MuteAudio(playerId, audio_mute);
        }

        public override bool IsAudioMuted(int playerId)
        {
            return _mediaPlayerImpl.IsAudioMuted(playerId);
        }

        public override int MuteVideo(int playerId, bool video_mute)
        {
            return _mediaPlayerImpl.MuteVideo(playerId, video_mute);
        }

        public override bool IsVideoMuted(int playerId)
        {
            return _mediaPlayerImpl.IsVideoMuted(playerId);
        }

        public override int SetPlaybackSpeed(int speed)
        {
            return _mediaPlayerImpl.SetPlaybackSpeed(speed);
        }

        public override int SelectAudioTrack(int playerId, int index)
        {
            return _mediaPlayerImpl.SelectAudioTrack(playerId, index);
        }

        public override int SetPlayerOption(int playerId, string key, int value)
        {
            return _mediaPlayerImpl.SetPlayerOption(playerId, key, value);
        }

        public override int SetPlayerOption(int playerId, string key, string value)
        {
            return _mediaPlayerImpl.SetPlayerOption(playerId, key, value);
        }

        public override int TakeScreenshot(int playerId, string filename)
        {
            return _mediaPlayerImpl.TakeScreenshot(playerId, filename);
        }

        public override int SelectInternalSubtitle(int playerId, int index)
        {
            return _mediaPlayerImpl.SelectInternalSubtitle(playerId, index);
        }

        public override int SetExternalSubtitle(int playerId, string url)
        {
            return _mediaPlayerImpl.SetExternalSubtitle(playerId, url);
        }

        public override MEDIA_PLAYER_STATE GetState(int playerId)
        {
            return _mediaPlayerImpl.GetState(playerId);
        }

        public override int Mute(int playerId, bool mute)
        {
            return _mediaPlayerImpl.Mute(playerId, mute);
        }

        public override int GetMute(int playerId, ref bool mute)
        {
            return _mediaPlayerImpl.GetMute(playerId, ref mute);
        }

        public override int AdjustPlayoutVolume(int playerId, int volume)
        {
            return _mediaPlayerImpl.AdjustPlayoutVolume(playerId, volume);
        }

        public override int GetPlayoutVolume(int playerId, ref int volume)
        {
            return _mediaPlayerImpl.GetPlayoutVolume(playerId, ref volume);
        }

        public override int AdjustPublishSignalVolume(int playerId, int volume)
        {
            return _mediaPlayerImpl.AdjustPublishSignalVolume(playerId, volume);
        }

        public override int GetPublishSignalVolume(int playerId, ref int volume)
        {
            return _mediaPlayerImpl.GetPublishSignalVolume(playerId, ref volume);
        }

        public override int SetView(int playerId)
        {
            return _mediaPlayerImpl.SetView(playerId);
        }

        public override int SetRenderMode(int playerId, RENDER_MODE_TYPE renderMode)
        {
            return _mediaPlayerImpl.SetRenderMode(playerId, renderMode);
        }

        public override int SetAudioDualMonoMode(int playerId, AUDIO_DUAL_MONO_MODE mode)
        {
            return _mediaPlayerImpl.SetAudioDualMonoMode(playerId, mode);
        }

        public override string GetPlayerSdkVersion(int playerId)
        {
            return _mediaPlayerImpl.GetPlayerSdkVersion(playerId);
        }

        public override string GetPlaySrc(int playerId)
        {
            return _mediaPlayerImpl.GetPlaySrc(playerId);
        }

        public override int SetAudioPitch(int pitch)
        {
            return _mediaPlayerImpl.SetAudioPitch(pitch);
        }

        public override int SetSpatialAudioParams(int playerId, SpatialAudioParams spatial_audio_params)
        {
            return _mediaPlayerImpl.SetSpatialAudioParams(playerId, spatial_audio_params);
        }

        public override int OpenWithAgoraCDNSrc(string src, Int64 startPos)
        {
            return _mediaPlayerImpl.OpenWithAgoraCDNSrc(src, startPos);
        }

        public override int GetAgoraCDNLineCount()
        {
            return _mediaPlayerImpl.GetAgoraCDNLineCount();
        }

        public override int SwitchAgoraCDNLineByIndex(int index)
        {
            return _mediaPlayerImpl.SwitchAgoraCDNLineByIndex(index);
        }

        public override int GetCurrentAgoraCDNIndex()
        {
            return _mediaPlayerImpl.GetCurrentAgoraCDNIndex();
        }

        public override int EnableAutoSwitchAgoraCDN(bool enable)
        {
            return _mediaPlayerImpl.EnableAutoSwitchAgoraCDN(enable);
        }

        public override int RenewAgoraCDNSrcToken(string token, Int64 ts)
        {
            return _mediaPlayerImpl.RenewAgoraCDNSrcToken(token, ts);
        }

        public override int SwitchAgoraCDNSrc(string src, bool syncPts = false)
        {
            return _mediaPlayerImpl.SwitchAgoraCDNSrc(src, syncPts);
        }

        public override int SwitchSrc(string src, bool syncPts = true)
        {
            return _mediaPlayerImpl.SwitchSrc(src, syncPts);
        }

        public override int PreloadSrc(string src, Int64 startPos)
        {
            return _mediaPlayerImpl.PreloadSrc(src, startPos);
        }

        public override int PlayPreloadedSrc(string src)
        {
            return _mediaPlayerImpl.PlayPreloadedSrc(src);
        }

        public override int UnloadSrc(string src)
        {
            return _mediaPlayerImpl.UnloadSrc(src);
        }
    }
}