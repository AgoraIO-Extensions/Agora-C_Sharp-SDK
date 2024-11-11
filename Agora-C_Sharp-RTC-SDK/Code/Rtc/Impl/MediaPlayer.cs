using System;

namespace Agora.Rtc
{
    public sealed class MediaPlayer : IMediaPlayer
    {
        private IRtcEngine _rtcEngineInstance = null;
        private MediaPlayerImpl _mediaPlayerImpl = null;
        private const int ErrorCode = -7;
        private int playerId;
        private static System.Object rtcLock = new System.Object();

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
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return;
                }
                _mediaPlayerImpl.DestroyMediaPlayer(playerId);
                playerId = 0;
            }
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
            lock (rtcLock)
            {
                return playerId;
            }
        }

        public override int InitEventHandler(IMediaPlayerSourceObserver engineEventHandler)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.InitEventHandler(playerId, engineEventHandler);
            }
        }

        public override int RegisterAudioFrameObserver(IMediaPlayerAudioFrameObserver observer)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.RegisterAudioFrameObserver(playerId, observer);
            }
        }

        public override int RegisterAudioFrameObserver(IMediaPlayerAudioFrameObserver observer, RAW_AUDIO_FRAME_OP_MODE_TYPE mode)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.RegisterAudioFrameObserver(playerId, observer, mode);
            }
        }

        public override int UnregisterAudioFrameObserver()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.UnregisterAudioFrameObserver(playerId);
            }
        }

        public override int RegisterMediaPlayerAudioSpectrumObserver(IAudioSpectrumObserver observer, int intervalInMS)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.RegisterMediaPlayerAudioSpectrumObserver(playerId, observer, intervalInMS);
            }
        }

        public override int UnregisterMediaPlayerAudioSpectrumObserver()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.UnregisterMediaPlayerAudioSpectrumObserver(playerId);
            }
        }

        public override int Open(string url, Int64 startPos)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.Open(playerId, url, startPos);
            }
        }

        public override int OpenWithCustomSource(Int64 startPos, IMediaPlayerCustomDataProvider provider)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.OpenWithCustomSource(playerId, startPos, provider);
            }
        }

        public override int OpenWithMediaSource(MediaSource source)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.OpenWithMediaSource(playerId, source);
            }
        }

        public override int SetSoundPositionParams(float pan, float gain)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.SetSoundPositionParams(playerId, pan, gain);
            }
        }

        public override int Play()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.Play(playerId);
            }
        }

        public override int Pause()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.Pause(playerId);
            }
        }

        public override int Stop()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.Stop(playerId);
            }
        }

        public override int Resume()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.Resume(playerId);
            }
        }

        public override int Seek(Int64 newPos)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.Seek(playerId, newPos);
            }
        }

        public override int GetDuration(ref Int64 duration)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.GetDuration(playerId, ref duration);
            }
        }

        public override int GetPlayPosition(ref Int64 pos)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.GetPlayPosition(playerId, ref pos);
            }
        }

        public override int GetStreamCount(ref Int64 count)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.GetStreamCount(playerId, ref count);
            }
        }

        public override int GetStreamInfo(Int64 index, ref PlayerStreamInfo info)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.GetStreamInfo(playerId, index, ref info);
            }
        }

        public override int SetLoopCount(int loopCount)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.SetLoopCount(playerId, loopCount);
            }
        }

        public override int SetPlaybackSpeed(int speed)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.SetPlaybackSpeed(playerId, speed);
            }
        }

        public override int SelectAudioTrack(int index)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.SelectAudioTrack(playerId, index);
            }
        }

        public override int SelectMultiAudioTrack(int playoutTrackIndex, int publishTrackIndex)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.SelectMultiAudioTrack(playerId, playoutTrackIndex, publishTrackIndex);
            }
        }

        public override int SetPlayerOption(string key, int value)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.SetPlayerOption(playerId, key, value);
            }
        }

        public override int SetPlayerOption(string key, string value)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.SetPlayerOption(playerId, key, value);
            }
        }

        public override int TakeScreenshot(string filename)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.TakeScreenshot(playerId, filename);
            }
        }

        public override int SelectInternalSubtitle(int index)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.SelectInternalSubtitle(playerId, index);
            }
        }

        public override int SetExternalSubtitle(string url)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.SetExternalSubtitle(playerId, url);
            }
        }

        public override MEDIA_PLAYER_STATE GetState()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return MEDIA_PLAYER_STATE.PLAYER_STATE_DO_NOTHING_INTERNAL;
                }

                return _mediaPlayerImpl.GetState(playerId);
            }
        }

        public override int Mute(bool muted)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.Mute(playerId, muted);
            }
        }

        public override int GetMute(ref bool muted)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.GetMute(playerId, ref muted);
            }
        }

        public override int AdjustPlayoutVolume(int volume)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.AdjustPlayoutVolume(playerId, volume);
            }
        }

        public override int GetPlayoutVolume(ref int volume)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.GetPlayoutVolume(playerId, ref volume);
            }
        }

        public override int AdjustPublishSignalVolume(int volume)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.AdjustPublishSignalVolume(playerId, volume);
            }
        }

        public override int GetPublishSignalVolume(ref int volume)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.GetPublishSignalVolume(playerId, ref volume);
            }
        }

        public override int SetView()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.SetView(playerId);
            }
        }

        public override int SetRenderMode(RENDER_MODE_TYPE renderMode)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.SetRenderMode(playerId, renderMode);
            }
        }

        public override int SetAudioDualMonoMode(AUDIO_DUAL_MONO_MODE mode)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.SetAudioDualMonoMode(playerId, mode);
            }
        }

        public override string GetPlayerSdkVersion()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return null;
                }
                return _mediaPlayerImpl.GetPlayerSdkVersion(playerId);
            }
        }

        public override string GetPlaySrc()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return null;
                }
                return _mediaPlayerImpl.GetPlaySrc(playerId);
            }
        }

        public override int SetAudioPitch(int pitch)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.SetAudioPitch(playerId, pitch);
            }
        }

        public override int SetSpatialAudioParams(SpatialAudioParams spatial_audio_params)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.SetSpatialAudioParams(playerId, spatial_audio_params);
            }
        }

        public override int OpenWithAgoraCDNSrc(string src, Int64 startPos)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.OpenWithAgoraCDNSrc(playerId, src, startPos);
            }
        }

        public override int GetAgoraCDNLineCount()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.GetAgoraCDNLineCount(playerId);
            }
        }

        public override int SwitchAgoraCDNLineByIndex(int index)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.SwitchAgoraCDNLineByIndex(playerId, index);
            }
        }

        public override int GetCurrentAgoraCDNIndex()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.GetCurrentAgoraCDNIndex(playerId);
            }
        }

        public override int EnableAutoSwitchAgoraCDN(bool enable)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.EnableAutoSwitchAgoraCDN(playerId, enable);
            }
        }

        public override int RenewAgoraCDNSrcToken(string token, Int64 ts)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.RenewAgoraCDNSrcToken(playerId, token, ts);
            }
        }

        public override int SwitchAgoraCDNSrc(string src, bool syncPts = false)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.SwitchAgoraCDNSrc(playerId, src, syncPts);
            }
        }

        public override int SwitchSrc(string src, bool syncPts = true)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.SwitchSrc(playerId, src, syncPts);
            }
        }

        public override int PreloadSrc(string src, Int64 startPos)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.PreloadSrc(playerId, src, startPos);
            }
        }

        public override int PlayPreloadedSrc(string src)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.PlayPreloadedSrc(playerId, src);
            }
        }

        public override int UnloadSrc(string src)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.UnloadSrc(playerId, src);
            }
        }

        public override int SetAudioPlaybackDelay(int delay_ms)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerImpl.SetAudioPlaybackDelay(this.playerId, delay_ms);
            }
        }
    }
}