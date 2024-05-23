using System;

namespace Agora.Rtc
{
    using view_t = UInt64;
    public sealed class MusicPlayer : IMusicPlayer
    {
        private MusicPlayerImpl _musicPlayerImpl = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;
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

        #region terra IMusicPlayer
        public override int Open(string url, long startPos)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.Open(playerId, url, startPos);
        }

        [Obsolete("")]
        public override int OpenWithCustomSource(long startPos, IMediaPlayerCustomDataProvider provider)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.OpenWithCustomSource(playerId, startPos, provider);
        }

        public override int OpenWithMediaSource(MediaSource source)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.OpenWithMediaSource(playerId, source);
        }

        public override int Play()
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.Play(playerId);
        }

        public override int Pause()
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.Pause(playerId);
        }

        public override int Stop()
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.Stop(playerId);
        }

        public override int Resume()
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.Resume(playerId);
        }

        public override int Seek(long newPos)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.Seek(playerId, newPos);
        }

        public override int SetAudioPitch(int pitch)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.SetAudioPitch(playerId, pitch);
        }

        public override int GetDuration(ref long duration)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.GetDuration(playerId, ref duration);
        }

        public override int GetPlayPosition(ref long pos)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.GetPlayPosition(playerId, ref pos);
        }

        public override int GetStreamCount(ref long count)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.GetStreamCount(playerId, ref count);
        }

        public override int GetStreamInfo(long index, ref PlayerStreamInfo info)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.GetStreamInfo(playerId, index, ref info);
        }

        public override int SetLoopCount(int loopCount)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.SetLoopCount(playerId, loopCount);
        }

        public override int SetPlaybackSpeed(int speed)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.SetPlaybackSpeed(playerId, speed);
        }

        public override int SelectAudioTrack(int index)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.SelectAudioTrack(playerId, index);
        }

        public override int SelectMultiAudioTrack(int playoutTrackIndex, int publishTrackIndex)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.SelectMultiAudioTrack(playerId, playoutTrackIndex, publishTrackIndex);
        }

        public override int SetPlayerOption(string key, int value)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.SetPlayerOption(playerId, key, value);
        }

        public override int SetPlayerOption(string key, string value)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.SetPlayerOption(playerId, key, value);
        }

        public override int TakeScreenshot(string filename)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.TakeScreenshot(playerId, filename);
        }

        public override int SelectInternalSubtitle(int index)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.SelectInternalSubtitle(playerId, index);
        }

        public override int SetExternalSubtitle(string url)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.SetExternalSubtitle(playerId, url);
        }

        public override MEDIA_PLAYER_STATE GetState()
        {
            if (_musicPlayerImpl == null)
            {
                return MEDIA_PLAYER_STATE.PLAYER_STATE_DO_NOTHING_INTERNAL;
            }
            return this._musicPlayerImpl.GetState(playerId);
        }

        public override int Mute(bool muted)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.Mute(playerId, muted);
        }

        public override int GetMute(ref bool muted)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.GetMute(playerId, ref muted);
        }

        public override int AdjustPlayoutVolume(int volume)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.AdjustPlayoutVolume(playerId, volume);
        }

        public override int GetPlayoutVolume(ref int volume)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.GetPlayoutVolume(playerId, ref volume);
        }

        public override int AdjustPublishSignalVolume(int volume)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.AdjustPublishSignalVolume(playerId, volume);
        }

        public override int GetPublishSignalVolume(ref int volume)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.GetPublishSignalVolume(playerId, ref volume);
        }

        public override int SetView(view_t view)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.SetView(playerId, view);
        }

        public override int SetRenderMode(RENDER_MODE_TYPE renderMode)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.SetRenderMode(playerId, renderMode);
        }

        public override int RegisterAudioFrameObserver(IAudioPcmFrameSink observer)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.RegisterAudioFrameObserver(playerId, observer);
        }

        public override int RegisterAudioFrameObserver(IAudioPcmFrameSink observer, RAW_AUDIO_FRAME_OP_MODE_TYPE mode)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.RegisterAudioFrameObserver(playerId, observer, mode);
        }

        public override int UnregisterAudioFrameObserver()
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.UnregisterAudioFrameObserver(playerId);
        }

        public override int RegisterMediaPlayerAudioSpectrumObserver(IAudioSpectrumObserver observer, int intervalInMS)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.RegisterMediaPlayerAudioSpectrumObserver(playerId, observer, intervalInMS);
        }

        public override int UnregisterMediaPlayerAudioSpectrumObserver()
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.UnregisterMediaPlayerAudioSpectrumObserver(playerId);
        }

        public override int SetAudioDualMonoMode(AUDIO_DUAL_MONO_MODE mode)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.SetAudioDualMonoMode(playerId, mode);
        }

        [Obsolete("This method is deprecated.")]
        public override string GetPlayerSdkVersion()
        {
            if (_musicPlayerImpl == null)
            {
                return "";
            }
            return this._musicPlayerImpl.GetPlayerSdkVersion(playerId);
        }

        public override string GetPlaySrc()
        {
            if (_musicPlayerImpl == null)
            {
                return "";
            }
            return this._musicPlayerImpl.GetPlaySrc(playerId);
        }

        public override int OpenWithAgoraCDNSrc(string src, long startPos)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.OpenWithAgoraCDNSrc(playerId, src, startPos);
        }

        public override int GetAgoraCDNLineCount()
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.GetAgoraCDNLineCount(playerId);
        }

        public override int SwitchAgoraCDNLineByIndex(int index)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.SwitchAgoraCDNLineByIndex(playerId, index);
        }

        public override int GetCurrentAgoraCDNIndex()
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.GetCurrentAgoraCDNIndex(playerId);
        }

        public override int EnableAutoSwitchAgoraCDN(bool enable)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.EnableAutoSwitchAgoraCDN(playerId, enable);
        }

        public override int RenewAgoraCDNSrcToken(string token, long ts)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.RenewAgoraCDNSrcToken(playerId, token, ts);
        }

        public override int SwitchAgoraCDNSrc(string src, bool syncPts = false)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.SwitchAgoraCDNSrc(playerId, src, syncPts);
        }

        public override int SwitchSrc(string src, bool syncPts = true)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.SwitchSrc(playerId, src, syncPts);
        }

        public override int PreloadSrc(string src, long startPos)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.PreloadSrc(playerId, src, startPos);
        }

        public override int PlayPreloadedSrc(string src)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.PlayPreloadedSrc(playerId, src);
        }

        public override int UnloadSrc(string src)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.UnloadSrc(playerId, src);
        }

        public override int SetSpatialAudioParams(SpatialAudioParams @params)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.SetSpatialAudioParams(playerId, @params);
        }

        public override int SetSoundPositionParams(float pan, float gain)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.SetSoundPositionParams(playerId, pan, gain);
        }
        public override int Open(long songCode, long startPos = 0)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.Open(playerId, songCode, startPos);
        }

        public override int SetPlayMode(MusicPlayMode mode)
        {
            if (_musicPlayerImpl == null)
            {
                return ErrorCode;
            }
            return this._musicPlayerImpl.SetPlayMode(playerId, mode);
        }
        #endregion terra IMusicPlayer
    }
}