using System;

namespace Agora.Rtc
{
    public sealed class MusicPlayer : IMusicPlayer
    {
        private MusicPlayerImpl _musicPlayerImpl = null;
        private const int ErrorCode = -7;
        private int playerId;

        internal MusicPlayer(MusicPlayerImpl impl, int id)
        {

            this._musicPlayerImpl = impl;
            this.playerId = id;
        }

        public override void Dispose()
        {
            AgoraLog.LogError("Please use IMusicContentCenter.DestroyMusicPlayer to instead of");
        }

        ~MusicPlayer()
        {
            _musicPlayerImpl = null;
        }

        public override int GetId()
        {
            return playerId;
        }

        public override int InitEventHandler(IMediaPlayerSourceObserver engineEventHandler)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.InitEventHandler(playerId, engineEventHandler);
        }

        public override int RegisterAudioFrameObserver(IMediaPlayerAudioFrameObserver observer)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.RegisterAudioFrameObserver(playerId, observer);
        }

        public override int RegisterAudioFrameObserver(IMediaPlayerAudioFrameObserver observer, RAW_AUDIO_FRAME_OP_MODE_TYPE mode)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.RegisterAudioFrameObserver(playerId, observer, mode);
        }

        public override int UnregisterAudioFrameObserver()
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.UnregisterAudioFrameObserver(playerId);
        }

        public override int RegisterMediaPlayerAudioSpectrumObserver(IAudioSpectrumObserver observer, int intervalInMS)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.RegisterMediaPlayerAudioSpectrumObserver(playerId, observer, intervalInMS);
        }

        public override int UnregisterMediaPlayerAudioSpectrumObserver()
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.UnregisterMediaPlayerAudioSpectrumObserver(playerId);
        }

        public override int Open(string url, Int64 startPos)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.Open(playerId, url, startPos);
        }

        public override int Play()
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.Play(playerId);
        }

        public override int Pause()
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.Pause(playerId);
        }

        public override int Stop()
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.Stop(playerId);
        }

        public override int Resume()
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.Resume(playerId);
        }

        public override int Seek(Int64 newPos)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.Seek(playerId, newPos);
        }

        public override int GetDuration(ref Int64 duration)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.GetDuration(playerId, ref duration);
        }

        public override int GetPlayPosition(ref Int64 pos)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.GetPlayPosition(playerId, ref pos);
        }

        public override int GetStreamCount(ref Int64 count)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.GetStreamCount(playerId, ref count);
        }

        public override int GetStreamInfo(Int64 index, ref PlayerStreamInfo info)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.GetStreamInfo(playerId, index, ref info);
        }

        public override int SetLoopCount(int loopCount)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.SetLoopCount(playerId, loopCount);
        }

        public override int Mute(bool muted)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.Mute(playerId, muted);
        }

        public override int GetMute(ref bool muted)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.GetMute(playerId, ref muted);
        }

        public override int SetPlaybackSpeed(int speed)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.SetPlaybackSpeed(playerId, speed);
        }

        public override int SelectAudioTrack(int index)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.SelectAudioTrack(playerId, index);
        }

        public override int SetPlayerOption(string key, int value)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.SetPlayerOption(playerId, key, value);
        }

        public override int SetPlayerOption(string key, string value)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.SetPlayerOption(playerId, key, value);
        }

        public override int TakeScreenshot(string filename)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.TakeScreenshot(playerId, filename);
        }

        public override int SelectInternalSubtitle(int index)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.SelectInternalSubtitle(playerId, index);
        }

        public override int SetExternalSubtitle(string url)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.SetExternalSubtitle(playerId, url);
        }

        public override MEDIA_PLAYER_STATE GetState()
        {
            if (_musicPlayerImpl == null)
            {
                return MEDIA_PLAYER_STATE.PLAYER_STATE_DO_NOTHING_INTERNAL;
            }
            return _musicPlayerImpl.GetState(playerId);
        }

        public override int AdjustPlayoutVolume(int volume)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.AdjustPlayoutVolume(playerId, volume);
        }

        public override int GetPlayoutVolume(ref int volume)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.GetPlayoutVolume(playerId, ref volume);
        }

        public override int AdjustPublishSignalVolume(int volume)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.AdjustPublishSignalVolume(playerId, volume);
        }

        public override int GetPublishSignalVolume(ref int volume)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.GetPublishSignalVolume(playerId, ref volume);
        }

        public override int SetView()
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.SetView(playerId);
        }

        public override int SetRenderMode(RENDER_MODE_TYPE renderMode)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.SetRenderMode(playerId, renderMode);
        }

        public override int SetAudioDualMonoMode(AUDIO_DUAL_MONO_MODE mode)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.SetAudioDualMonoMode(playerId, mode);
        }

        public override string GetPlayerSdkVersion()
        {
            if (_musicPlayerImpl == null)
            {
                return null;
            }
            return _musicPlayerImpl.GetPlayerSdkVersion(playerId);
        }

        public override string GetPlaySrc()
        {
            if (_musicPlayerImpl == null)
            {
                return null;
            }
            return _musicPlayerImpl.GetPlaySrc(playerId);
        }

        public override int SetAudioPitch(int pitch)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.SetAudioPitch(playerId, pitch);
        }

        public override int SetSpatialAudioParams(SpatialAudioParams spatial_audio_params)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.SetSpatialAudioParams(playerId, spatial_audio_params);
        }

        public override int OpenWithAgoraCDNSrc(string src, Int64 startPos)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.OpenWithAgoraCDNSrc(playerId, src, startPos);
        }

        public override int GetAgoraCDNLineCount()
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.GetAgoraCDNLineCount(playerId);
        }

        public override int SwitchAgoraCDNLineByIndex(int index)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.SwitchAgoraCDNLineByIndex(playerId, index);
        }

        public override int GetCurrentAgoraCDNIndex()
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.GetCurrentAgoraCDNIndex(playerId);
        }

        public override int EnableAutoSwitchAgoraCDN(bool enable)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.EnableAutoSwitchAgoraCDN(playerId, enable);
        }

        public override int RenewAgoraCDNSrcToken(string token, Int64 ts)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.RenewAgoraCDNSrcToken(playerId, token, ts);
        }

        public override int SwitchAgoraCDNSrc(string src, bool syncPts = false)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.SwitchAgoraCDNSrc(playerId, src, syncPts);
        }

        public override int SwitchSrc(string src, bool syncPts = true)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.SwitchSrc(playerId, src, syncPts);
        }

        public override int PreloadSrc(string src, Int64 startPos)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.PreloadSrc(playerId, src, startPos);
        }

        public override int PlayPreloadedSrc(string src)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.PlayPreloadedSrc(playerId, src);
        }

        public override int UnloadSrc(string src)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.UnloadSrc(playerId, src);
        }

        public override int Open(long songCode, long startPos)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.Open(this.playerId, songCode, startPos);
        }

        public override int OpenWithCustomSource(Int64 startPos, IMediaPlayerCustomDataProvider provider)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.OpenWithCustomSource(this.playerId, startPos, provider);
        }

        public override int OpenWithMediaSource(MediaSource source)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.OpenWithMediaSource(this.playerId, source);
        }

        public override int SetSoundPositionParams(float pan, float gain)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _musicPlayerImpl.SetSoundPositionParams(this.playerId, pan, gain);
        }
    }
}