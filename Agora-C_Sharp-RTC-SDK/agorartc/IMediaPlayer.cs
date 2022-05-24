using System;

namespace agora.rtc
{
    public class IMediaPlayer
    {
        private static IMediaPlayer instance = null;
        private MediaPlayerImpl _mediaPlayerImpl = null;

        private IMediaPlayer(MediaPlayerImpl impl)
        {
            _mediaPlayerImpl = impl;
        }

        internal static IMediaPlayer GetInstance(MediaPlayerImpl impl)
        {
            return instance ?? (instance = new IMediaPlayer(impl));
        }

        public void Dispose()
        {
            _mediaPlayerImpl.Dispose();
        }

        public int CreateMediaPlayer()
        {
            return _mediaPlayerImpl.CreateMediaPlayer();
        }

        public int DestroyMediaPlayer(int playerId)
        {
            return _mediaPlayerImpl.DestroyMediaPlayer(playerId);
        }

        public MediaPlayerSourceObserver GetAgoraRtcMediaPlayerSourceObserver()
        {
            return _mediaPlayerImpl.GetAgoraRtcMediaPlayerSourceObserver();
        }

        public void InitEventHandler(IMediaPlayerSourceObserver engineEventHandler)
        {
            _mediaPlayerImpl.Dispose();
        }

        public void RemoveEventHandler(IMediaPlayerSourceObserver engineEventHandler)
        {
            _mediaPlayerImpl.Dispose();
        }

        public void RegisterAudioFrameObserver(IMediaPlayerAudioFrameObserver observer)
        {
            _mediaPlayerImpl.Dispose();
        }

        public void RegisterAudioFrameObserver(IMediaPlayerAudioFrameObserver observer, RAW_AUDIO_FRAME_OP_MODE_TYPE mode)
        {
            _mediaPlayerImpl.Dispose();
        }

        public void UnregisterAudioFrameObserver(IMediaPlayerAudioFrameObserver observer)
        {
            _mediaPlayerImpl.Dispose();
        }

        public void RegisterMediaPlayerAudioSpectrumObserver(IAudioSpectrumObserver observer, int intervalInMS)
        {
            _mediaPlayerImpl.Dispose();
        }

        public void UnregisterMediaPlayerAudioSpectrumObserver(IAudioSpectrumObserver observer)
        {
            _mediaPlayerImpl.Dispose();
        }

        public int Open(int playerId, string url, Int64 startPos)
        {
            return _mediaPlayerImpl.Open(playerId, url, startPos);
        }

        public int OpenWithCustomSource(int playerId, Int64 startPos, IMediaPlayerCustomDataProvider provider)
        {
            return _mediaPlayerImpl.OpenWithCustomSource(playerId, startPos, provider);
        }

        public int Play(int playerId)
        {
            return _mediaPlayerImpl.Play(playerId);
        }

        public int Pause(int playerId)
        {
            return _mediaPlayerImpl.Pause(playerId);
        }

        public int Stop(int playerId)
        {
            return _mediaPlayerImpl.Stop(playerId);
        }

        public int Resume(int playerId)
        {
            return _mediaPlayerImpl.Resume(playerId);
        }

        public int Seek(int playerId, Int64 newPos)
        {
            return _mediaPlayerImpl.Seek(playerId, newPos);
        }

        public int GetDuration(int playerId, ref Int64 duration)
        {
            return _mediaPlayerImpl.GetDuration(playerId, ref duration);
        }

        public int GetPlayPosition(int playerId, ref Int64 pos)
        {
            return _mediaPlayerImpl.GetPlayPosition(playerId, ref pos);
        }

        public int GetStreamCount(int playerId, ref Int64 count)
        {
            return _mediaPlayerImpl.GetStreamCount(playerId, ref count);
        }

        public int GetStreamInfo(int playerId, Int64 index, out PlayerStreamInfo info)
        {
            return _mediaPlayerImpl.GetStreamInfo(playerId, index, out info);
        }

        public int SetLoopCount(int playerId, int loopCount)
        {
            return _mediaPlayerImpl.SetLoopCount(playerId, loopCount);
        }

        public int MuteAudio(int playerId, bool audio_mute)
        {
            return _mediaPlayerImpl.MuteAudio(playerId, audio_mute);
        }

        public bool IsAudioMuted(int playerId)
        {
            return _mediaPlayerImpl.IsAudioMuted(playerId);
        }

        public int MuteVideo(int playerId, bool video_mute)
        {
            return _mediaPlayerImpl.MuteVideo(playerId, video_mute);
        }

        public bool IsVideoMuted(int playerId)
        {
            return _mediaPlayerImpl.IsVideoMuted(playerId);
        }

        public int SetPlaybackSpeed(int speed)
        {
            return _mediaPlayerImpl.SetPlaybackSpeed(speed);
        }

        public int SelectAudioTrack(int playerId, int index)
        {
            return _mediaPlayerImpl.SelectAudioTrack(playerId, index);
        }

        public int SetPlayerOption(int playerId, string key, int value)
        {
            return _mediaPlayerImpl.SetPlayerOption(playerId, key, value);
        }

        public int SetPlayerOption(int playerId, string key, string value)
        {
            return _mediaPlayerImpl.SetPlayerOption(playerId, key, value);
        }

        public int TakeScreenshot(int playerId, string filename)
        {
            return _mediaPlayerImpl.TakeScreenshot(playerId, filename);
        }

        public int SelectInternalSubtitle(int playerId, int index)
        {
            return _mediaPlayerImpl.SelectInternalSubtitle(playerId, index);
        }

        public int SetExternalSubtitle(int playerId, string url)
        {
            return _mediaPlayerImpl.SetExternalSubtitle(playerId, url);
        }

        public MEDIA_PLAYER_STATE GetState(int playerId)
        {
            return _mediaPlayerImpl.GetState(playerId);
        }

        public int Mute(int playerId, bool mute)
        {
            return _mediaPlayerImpl.Mute(playerId, mute);
        }

        public int GetMute(int playerId, ref bool mute)
        {
            return _mediaPlayerImpl.GetMute(playerId, ref mute);
        }

        public int AdjustPlayoutVolume(int playerId, int volume)
        {
            return _mediaPlayerImpl.AdjustPlayoutVolume(playerId, volume);
        }

        public int GetPlayoutVolume(int playerId, ref int volume)
        {
            return _mediaPlayerImpl.GetPlayoutVolume(playerId, ref volume);
        }

        public int AdjustPublishSignalVolume(int playerId, int volume)
        {
            return _mediaPlayerImpl.AdjustPublishSignalVolume(playerId, volume);
        }

        public int GetPublishSignalVolume(int playerId, ref int volume)
        {
            return _mediaPlayerImpl.GetPublishSignalVolume(playerId, ref volume);
        }

        public int SetView(int playerId)
        {
            return _mediaPlayerImpl.SetView(playerId);
        }

        public int SetRenderMode(int playerId, RENDER_MODE_TYPE renderMode)
        {
            return _mediaPlayerImpl.SetRenderMode(playerId, renderMode);
        }

        public int SetAudioDualMonoMode(int playerId, AUDIO_DUAL_MONO_MODE mode)
        {
            return _mediaPlayerImpl.SetAudioDualMonoMode(playerId, mode);
        }

        public string GetPlayerSdkVersion(int playerId)
        {
            return _mediaPlayerImpl.GetPlayerSdkVersion(playerId);
        }

        public string GetPlaySrc(int playerId)
        {
            return _mediaPlayerImpl.GetPlaySrc(playerId);
        }

        public int SetAudioPitch(int pitch)
        {
            return _mediaPlayerImpl.SetAudioPitch(pitch);
        }

        public int SetSpatialAudioParams(int playerId, SpatialAudioParams spatial_audio_params)
        {
            return _mediaPlayerImpl.SetSpatialAudioParams(playerId, spatial_audio_params);
        }

        public int OpenWithAgoraCDNSrc(string src, Int64 startPos)
        {
            return _mediaPlayerImpl.OpenWithAgoraCDNSrc(src, startPos);
        }

        public int GetAgoraCDNLineCount()
        {
            return _mediaPlayerImpl.GetAgoraCDNLineCount();
        }

        public int SwitchAgoraCDNLineByIndex(int index)
        {
            return _mediaPlayerImpl.SwitchAgoraCDNLineByIndex(index);
        }

        public int GetCurrentAgoraCDNIndex()
        {
            return _mediaPlayerImpl.GetCurrentAgoraCDNIndex();
        }

        public int EnableAutoSwitchAgoraCDN(bool enable)
        {
            return _mediaPlayerImpl.EnableAutoSwitchAgoraCDN(enable);
        }

        public int RenewAgoraCDNSrcToken(string token, Int64 ts)
        {
            return _mediaPlayerImpl.RenewAgoraCDNSrcToken(token, ts);
        }

        public int SwitchAgoraCDNSrc(string src, bool syncPts = false)
        {
            return _mediaPlayerImpl.SwitchAgoraCDNSrc(src, syncPts);
        }

        public int SwitchSrc(string src, bool syncPts = true)
        {
            return _mediaPlayerImpl.SwitchSrc(src, syncPts);
        }

        public int PreloadSrc(string src, Int64 startPos)
        {
            return _mediaPlayerImpl.PreloadSrc(src, startPos);
        }

        public int PlayPreloadedSrc(string src)
        {
            return _mediaPlayerImpl.PlayPreloadedSrc(src);
        }

        public int UnloadSrc(string src)
        {
            return _mediaPlayerImpl.UnloadSrc(src);
        }
    }
}