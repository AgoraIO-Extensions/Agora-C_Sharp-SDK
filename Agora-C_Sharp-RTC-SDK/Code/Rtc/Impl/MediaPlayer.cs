using System;
using view_t = System.UInt64;
namespace Agora.Rtc
{

    public sealed class MediaPlayer : IMediaPlayer
    {
        private IRtcEngine _rtcEngineInstance = null;
        private MediaPlayerImpl _mediaPlayerImpl = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;
        private int playerId;

        internal MediaPlayer(IRtcEngine rtcEngine, MediaPlayerImpl impl)
        {
            _rtcEngineInstance = rtcEngine;
            _mediaPlayerImpl = impl;

            playerId = _mediaPlayerImpl.CreateMediaPlayer();
        }

        ~MediaPlayer()
        {
            _mediaPlayerImpl = null;
            _rtcEngineInstance = null;
        }

        public override void Dispose()
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return;
            }
            _mediaPlayerImpl.DestroyMediaPlayer(playerId);
            playerId = 0;
        }

        public int Destroy()
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            var ret = _mediaPlayerImpl.DestroyMediaPlayer(playerId);
            playerId = 0;
            return ret;
        }

        public override int GetId()
        {
            return playerId;
        }

        public override int InitEventHandler(IMediaPlayerSourceObserver engineEventHandler)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.InitEventHandler(playerId, engineEventHandler);
        }

        #region terra IMediaPlayer
        public override int Open(string url, long startPos)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.Open(playerId, url, startPos);
        }

        [Obsolete("")]
        public override int OpenWithCustomSource(long startPos, IMediaPlayerCustomDataProvider provider)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.OpenWithCustomSource(playerId, startPos, provider);
        }

        public override int OpenWithMediaSource(MediaSource source)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.OpenWithMediaSource(playerId, source);
        }

        public override int Play()
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.Play(playerId);
        }

        public override int Pause()
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.Pause(playerId);
        }

        public override int Stop()
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.Stop(playerId);
        }

        public override int Resume()
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.Resume(playerId);
        }

        public override int Seek(long newPos)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.Seek(playerId, newPos);
        }

        public override int SetAudioPitch(int pitch)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.SetAudioPitch(playerId, pitch);
        }

        public override int GetDuration(ref long duration)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.GetDuration(playerId, ref duration);
        }

        public override int GetPlayPosition(ref long pos)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.GetPlayPosition(playerId, ref pos);
        }

        public override int GetStreamCount(ref long count)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.GetStreamCount(playerId, ref count);
        }

        public override int GetStreamInfo(long index, ref PlayerStreamInfo info)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.GetStreamInfo(playerId, index, ref info);
        }

        public override int SetLoopCount(int loopCount)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.SetLoopCount(playerId, loopCount);
        }

        public override int SetPlaybackSpeed(int speed)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.SetPlaybackSpeed(playerId, speed);
        }

        public override int SelectAudioTrack(int index)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.SelectAudioTrack(playerId, index);
        }

        public override int SelectMultiAudioTrack(int playoutTrackIndex, int publishTrackIndex)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.SelectMultiAudioTrack(playerId, playoutTrackIndex, publishTrackIndex);
        }

        public override int SetPlayerOption(string key, int value)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.SetPlayerOption(playerId, key, value);
        }

        public override int SetPlayerOption(string key, string value)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.SetPlayerOption(playerId, key, value);
        }

        public override int TakeScreenshot(string filename)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.TakeScreenshot(playerId, filename);
        }

        public override int SelectInternalSubtitle(int index)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.SelectInternalSubtitle(playerId, index);
        }

        public override int SetExternalSubtitle(string url)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.SetExternalSubtitle(playerId, url);
        }

        public override MEDIA_PLAYER_STATE GetState()
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return MEDIA_PLAYER_STATE.PLAYER_STATE_DO_NOTHING_INTERNAL;
            }
            return _mediaPlayerImpl.GetState(playerId);
        }

        public override int Mute(bool muted)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.Mute(playerId, muted);
        }

        public override int GetMute(ref bool muted)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.GetMute(playerId, ref muted);
        }

        public override int AdjustPlayoutVolume(int volume)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.AdjustPlayoutVolume(playerId, volume);
        }

        public override int GetPlayoutVolume(ref int volume)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.GetPlayoutVolume(playerId, ref volume);
        }

        public override int AdjustPublishSignalVolume(int volume)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.AdjustPublishSignalVolume(playerId, volume);
        }

        public override int GetPublishSignalVolume(ref int volume)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.GetPublishSignalVolume(playerId, ref volume);
        }

        public override int SetView(view_t view)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.SetView(playerId, view);
        }

        public override int SetRenderMode(RENDER_MODE_TYPE renderMode)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.SetRenderMode(playerId, renderMode);
        }

        public override int RegisterAudioFrameObserver(IAudioPcmFrameSink observer)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.RegisterAudioFrameObserver(playerId, observer);
        }

        public override int RegisterAudioFrameObserver(IAudioPcmFrameSink observer, RAW_AUDIO_FRAME_OP_MODE_TYPE mode)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.RegisterAudioFrameObserver(playerId, observer, mode);
        }

        public override int UnregisterAudioFrameObserver()
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.UnregisterAudioFrameObserver(playerId);
        }

        public override int RegisterMediaPlayerAudioSpectrumObserver(IAudioSpectrumObserver observer, int intervalInMS)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.RegisterMediaPlayerAudioSpectrumObserver(playerId, observer, intervalInMS);
        }

        public override int UnregisterMediaPlayerAudioSpectrumObserver()
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.UnregisterMediaPlayerAudioSpectrumObserver(playerId);
        }

        public override int SetAudioDualMonoMode(AUDIO_DUAL_MONO_MODE mode)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.SetAudioDualMonoMode(playerId, mode);
        }

        [Obsolete("This method is deprecated.")]
        public override string GetPlayerSdkVersion()
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return "";
            }
            return _mediaPlayerImpl.GetPlayerSdkVersion(playerId);
        }

        public override string GetPlaySrc()
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return "";
            }
            return _mediaPlayerImpl.GetPlaySrc(playerId);
        }

        public override int OpenWithAgoraCDNSrc(string src, long startPos)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.OpenWithAgoraCDNSrc(playerId, src, startPos);
        }

        public override int GetAgoraCDNLineCount()
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.GetAgoraCDNLineCount(playerId);
        }

        public override int SwitchAgoraCDNLineByIndex(int index)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.SwitchAgoraCDNLineByIndex(playerId, index);
        }

        public override int GetCurrentAgoraCDNIndex()
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.GetCurrentAgoraCDNIndex(playerId);
        }

        public override int EnableAutoSwitchAgoraCDN(bool enable)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.EnableAutoSwitchAgoraCDN(playerId, enable);
        }

        public override int RenewAgoraCDNSrcToken(string token, long ts)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.RenewAgoraCDNSrcToken(playerId, token, ts);
        }

        public override int SwitchAgoraCDNSrc(string src, bool syncPts = false)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.SwitchAgoraCDNSrc(playerId, src, syncPts);
        }

        public override int SwitchSrc(string src, bool syncPts = true)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.SwitchSrc(playerId, src, syncPts);
        }

        public override int PreloadSrc(string src, long startPos)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.PreloadSrc(playerId, src, startPos);
        }

        public override int PlayPreloadedSrc(string src)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.PlayPreloadedSrc(playerId, src);
        }

        public override int UnloadSrc(string src)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.UnloadSrc(playerId, src);
        }

        public override int SetSpatialAudioParams(SpatialAudioParams @params)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.SetSpatialAudioParams(playerId, @params);
        }

        public override int SetSoundPositionParams(float pan, float gain)
        {
            if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerImpl.SetSoundPositionParams(playerId, pan, gain);
        }
        #endregion terra IMediaPlayer
    }
}