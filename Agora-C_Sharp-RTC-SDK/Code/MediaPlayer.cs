using System;

namespace agora.rtc
{
    public sealed class MediaPlayer : IMediaPlayer
    {
        private static IMediaPlayer instance = null;
        private MediaPlayerImpl _mediaPlayerImpl = null;
        private const string ErrorMsgLog = "[MediaPlayer]:IMediaPlayer has not been created yet!";
        private const int ErrorCode = -1;

        private MediaPlayer(MediaPlayerImpl impl)
        {
            _mediaPlayerImpl = impl;
        }

        internal static IMediaPlayer GetInstance(MediaPlayerImpl impl)
        {
            return instance ?? (instance = new MediaPlayer(impl));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }

        public override void Dispose()
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return;
            }
            _mediaPlayerImpl.Dispose();
        }

        public override int CreateMediaPlayer()
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.CreateMediaPlayer();
        }

        public override int DestroyMediaPlayer(int playerId)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.DestroyMediaPlayer(playerId);
        }

        public override MediaPlayerSourceObserver GetAgoraRtcMediaPlayerSourceObserver()
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return null;
            }
            return _mediaPlayerImpl.GetAgoraRtcMediaPlayerSourceObserver();
        }

        public override void InitEventHandler(IMediaPlayerSourceObserver engineEventHandler)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return;
            }
            _mediaPlayerImpl.InitEventHandler(engineEventHandler);
        }

        public override void RemoveEventHandler(IMediaPlayerSourceObserver engineEventHandler)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return;
            }
            _mediaPlayerImpl.RemoveEventHandler(engineEventHandler);
        }

        public override void RegisterAudioFrameObserver(IMediaPlayerAudioFrameObserver observer)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return;
            }
            _mediaPlayerImpl.RegisterAudioFrameObserver(observer);
        }

        public override void RegisterAudioFrameObserver(IMediaPlayerAudioFrameObserver observer, RAW_AUDIO_FRAME_OP_MODE_TYPE mode)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return;
            }
            _mediaPlayerImpl.RegisterAudioFrameObserver(observer, mode);
        }

        public override void UnregisterAudioFrameObserver()
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return;
            }
            _mediaPlayerImpl.UnregisterAudioFrameObserver();
        }

        public override void RegisterMediaPlayerAudioSpectrumObserver(IAudioSpectrumObserver observer, int intervalInMS)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return;
            }
            _mediaPlayerImpl.RegisterMediaPlayerAudioSpectrumObserver(observer, intervalInMS);
        }

        public override void UnregisterMediaPlayerAudioSpectrumObserver()
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return;
            }
            _mediaPlayerImpl.UnregisterMediaPlayerAudioSpectrumObserver();
        }

        public override int Open(int playerId, string url, Int64 startPos)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.Open(playerId, url, startPos);
        }

        public override int OpenWithCustomSource(int playerId, Int64 startPos, IMediaPlayerCustomDataProvider provider)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.OpenWithCustomSource(playerId, startPos, provider);
        }

        public override int Play(int playerId)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.Play(playerId);
        }

        public override int Pause(int playerId)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.Pause(playerId);
        }

        public override int Stop(int playerId)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.Stop(playerId);
        }

        public override int Resume(int playerId)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.Resume(playerId);
        }

        public override int Seek(int playerId, Int64 newPos)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.Seek(playerId, newPos);
        }

        public override int GetDuration(int playerId, ref Int64 duration)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.GetDuration(playerId, ref duration);
        }

        public override int GetPlayPosition(int playerId, ref Int64 pos)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.GetPlayPosition(playerId, ref pos);
        }

        public override int GetStreamCount(int playerId, ref Int64 count)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.GetStreamCount(playerId, ref count);
        }

        public override int GetStreamInfo(int playerId, Int64 index, ref PlayerStreamInfo info)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.GetStreamInfo(playerId, index, ref info);
        }

        public override int SetLoopCount(int playerId, int loopCount)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.SetLoopCount(playerId, loopCount);
        }

        public override int MuteAudio(int playerId, bool audio_mute)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.MuteAudio(playerId, audio_mute);
        }

        public override bool IsAudioMuted(int playerId)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return false;
            }
            return _mediaPlayerImpl.IsAudioMuted(playerId);
        }

        public override int MuteVideo(int playerId, bool video_mute)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.MuteVideo(playerId, video_mute);
        }

        public override bool IsVideoMuted(int playerId)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return false;
            }
            return _mediaPlayerImpl.IsVideoMuted(playerId);
        }

        public override int SetPlaybackSpeed(int speed)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.SetPlaybackSpeed(speed);
        }

        public override int SelectAudioTrack(int playerId, int index)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.SelectAudioTrack(playerId, index);
        }

        public override int SetPlayerOption(int playerId, string key, int value)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.SetPlayerOption(playerId, key, value);
        }

        public override int SetPlayerOption(int playerId, string key, string value)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.SetPlayerOption(playerId, key, value);
        }

        public override int TakeScreenshot(int playerId, string filename)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.TakeScreenshot(playerId, filename);
        }

        public override int SelectInternalSubtitle(int playerId, int index)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.SelectInternalSubtitle(playerId, index);
        }

        public override int SetExternalSubtitle(int playerId, string url)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.SetExternalSubtitle(playerId, url);
        }

        public override MEDIA_PLAYER_STATE GetState(int playerId)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return MEDIA_PLAYER_STATE.PLAYER_STATE_DO_NOTHING_INTERNAL;
            }
            return _mediaPlayerImpl.GetState(playerId);
        }

        public override int Mute(int playerId, bool mute)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.Mute(playerId, mute);
        }

        public override int GetMute(int playerId, ref bool mute)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.GetMute(playerId, ref mute);
        }

        public override int AdjustPlayoutVolume(int playerId, int volume)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.AdjustPlayoutVolume(playerId, volume);
        }

        public override int GetPlayoutVolume(int playerId, ref int volume)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.GetPlayoutVolume(playerId, ref volume);
        }

        public override int AdjustPublishSignalVolume(int playerId, int volume)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.AdjustPublishSignalVolume(playerId, volume);
        }

        public override int GetPublishSignalVolume(int playerId, ref int volume)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.GetPublishSignalVolume(playerId, ref volume);
        }

        public override int SetView(int playerId)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.SetView(playerId);
        }

        public override int SetRenderMode(int playerId, RENDER_MODE_TYPE renderMode)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.SetRenderMode(playerId, renderMode);
        }

        public override int SetAudioDualMonoMode(int playerId, AUDIO_DUAL_MONO_MODE mode)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.SetAudioDualMonoMode(playerId, mode);
        }

        public override string GetPlayerSdkVersion(int playerId)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return null;
            }
            return _mediaPlayerImpl.GetPlayerSdkVersion(playerId);
        }

        public override string GetPlaySrc(int playerId)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return null;
            }
            return _mediaPlayerImpl.GetPlaySrc(playerId);
        }

        public override int SetAudioPitch(int pitch)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.SetAudioPitch(pitch);
        }

        public override int SetSpatialAudioParams(int playerId, SpatialAudioParams spatial_audio_params)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.SetSpatialAudioParams(playerId, spatial_audio_params);
        }

        public override int OpenWithAgoraCDNSrc(string src, Int64 startPos)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.OpenWithAgoraCDNSrc(src, startPos);
        }

        public override int GetAgoraCDNLineCount()
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.GetAgoraCDNLineCount();
        }

        public override int SwitchAgoraCDNLineByIndex(int index)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.SwitchAgoraCDNLineByIndex(index);
        }

        public override int GetCurrentAgoraCDNIndex()
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.GetCurrentAgoraCDNIndex();
        }

        public override int EnableAutoSwitchAgoraCDN(bool enable)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.EnableAutoSwitchAgoraCDN(enable);
        }

        public override int RenewAgoraCDNSrcToken(string token, Int64 ts)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.RenewAgoraCDNSrcToken(token, ts);
        }

        public override int SwitchAgoraCDNSrc(string src, bool syncPts = false)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.SwitchAgoraCDNSrc(src, syncPts);
        }

        public override int SwitchSrc(string src, bool syncPts = true)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.SwitchSrc(src, syncPts);
        }

        public override int PreloadSrc(string src, Int64 startPos)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.PreloadSrc(src, startPos);
        }

        public override int PlayPreloadedSrc(string src)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.PlayPreloadedSrc(src);
        }

        public override int UnloadSrc(string src)
        {
            if (_mediaPlayerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _mediaPlayerImpl.UnloadSrc(src);
        }
    }
}