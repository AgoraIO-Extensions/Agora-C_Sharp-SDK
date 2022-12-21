using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;

    public class MusicPlayerImpl
    {
        private bool _disposed = false;
        private IrisApiEnginePtr _irisApiEngine;
        private IrisCApiParam _apiParam;
        private MediaPlayerImpl _mediaPlayerImpl;
        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

        internal MusicPlayerImpl(IrisApiEnginePtr irisApiEngine, MediaPlayerImpl impl)
        {
            _apiParam = new IrisCApiParam();
            _apiParam.AllocResult();
            _irisApiEngine = irisApiEngine;
            _mediaPlayerImpl = impl;
        }

        ~MusicPlayerImpl()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {

            }

            _irisApiEngine = IntPtr.Zero;
            _apiParam.FreeResult();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public int InitEventHandler(int playerId, IMediaPlayerSourceObserver engineEventHandler)
        {
            return _mediaPlayerImpl.InitEventHandler(playerId, engineEventHandler);
        }

        public int RegisterAudioFrameObserver(int playerId, IMediaPlayerAudioFrameObserver observer)
        {
            return _mediaPlayerImpl.RegisterAudioFrameObserver(playerId, observer);
        }

        public int RegisterAudioFrameObserver(int playerId, IMediaPlayerAudioFrameObserver observer, RAW_AUDIO_FRAME_OP_MODE_TYPE mode)
        {
            return _mediaPlayerImpl.RegisterAudioFrameObserver(playerId, observer, mode);
        }

        public int UnregisterAudioFrameObserver(int playerId)
        {
            return _mediaPlayerImpl.UnregisterAudioFrameObserver(playerId);
        }


        public int RegisterMediaPlayerAudioSpectrumObserver(int playerId, IAudioSpectrumObserver observer, int intervalInMS)
        {
            return _mediaPlayerImpl.RegisterMediaPlayerAudioSpectrumObserver(playerId, observer, intervalInMS);
        }

        public int UnregisterMediaPlayerAudioSpectrumObserver(int playerId)
        {
            return _mediaPlayerImpl.UnregisterMediaPlayerAudioSpectrumObserver(playerId);
        }

        //normal feature

        public int Open(int playerId, string url, Int64 startPos)
        {
            return _mediaPlayerImpl.Open(playerId, url, startPos);
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

        public int GetStreamInfo(int playerId, Int64 index, ref PlayerStreamInfo info)
        {
            return _mediaPlayerImpl.GetStreamInfo(playerId, index, ref info);
        }

        public int SetLoopCount(int playerId, int loopCount)
        {
            return _mediaPlayerImpl.SetLoopCount(playerId, loopCount);
        }

        public int SetPlaybackSpeed(int playerId, int speed)
        {
            return _mediaPlayerImpl.SetPlaybackSpeed(playerId, speed);
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

        public int SetAudioPitch(int playerId, int pitch)
        {
            return _mediaPlayerImpl.SetAudioPitch(playerId, pitch);
        }

        public int SetSpatialAudioParams(int playerId, SpatialAudioParams spatial_audio_params)
        {
            return _mediaPlayerImpl.SetSpatialAudioParams(playerId, spatial_audio_params);
        }

        public int OpenWithAgoraCDNSrc(int playerId, string src, Int64 startPos)
        {
            return _mediaPlayerImpl.OpenWithAgoraCDNSrc(playerId, src, startPos);
        }

        public int GetAgoraCDNLineCount(int playerId)
        {
            return _mediaPlayerImpl.GetAgoraCDNLineCount(playerId);
        }

        public int SwitchAgoraCDNLineByIndex(int playerId, int index)
        {
            return _mediaPlayerImpl.SwitchAgoraCDNLineByIndex(playerId, index);
        }

        public int GetCurrentAgoraCDNIndex(int playerId)
        {
            return _mediaPlayerImpl.GetCurrentAgoraCDNIndex(playerId);
        }

        public int EnableAutoSwitchAgoraCDN(int playerId, bool enable)
        {
            return _mediaPlayerImpl.EnableAutoSwitchAgoraCDN(playerId, enable);
        }

        public int RenewAgoraCDNSrcToken(int playerId, string token, Int64 ts)
        {
            return _mediaPlayerImpl.RenewAgoraCDNSrcToken(playerId, token, ts);
        }

        public int SwitchAgoraCDNSrc(int playerId, string src, bool syncPts = false)
        {
            return _mediaPlayerImpl.SwitchAgoraCDNSrc(playerId, src, syncPts);
        }

        public int SwitchSrc(int playerId, string src, bool syncPts = true)
        {
            return _mediaPlayerImpl.SwitchSrc(playerId, src, syncPts);
        }

        public int PreloadSrc(int playerId, string src, Int64 startPos)
        {
            return _mediaPlayerImpl.PreloadSrc(playerId, src, startPos);
        }

        public int PlayPreloadedSrc(int playerId, string src)
        {
            return _mediaPlayerImpl.PlayPreloadedSrc(playerId, src);
        }

        public int UnloadSrc(int playerId, string src)
        {
            return _mediaPlayerImpl.PlayPreloadedSrc(playerId, src);
        }

        public int OpenWithCustomSource(int playerId, Int64 startPos, IMediaPlayerCustomDataProvider provider)
        {
            return _mediaPlayerImpl.OpenWithCustomSource(playerId, startPos, provider);
        }

        public int OpenWithMediaSource(int playerId, MediaSource source)
        {
            return _mediaPlayerImpl.OpenWithMediaSource(playerId, source);
        }

        public int SetSoundPositionParams(int playerId, float pan, float gain)
        {
            return _mediaPlayerImpl.SetSoundPositionParams(playerId, pan, gain);
        }

        public int Open(int playerId, Int64 songCode, Int64 startPos = 0)
        {
            _param.Clear();
            _param.Add("playerId", playerId);
            _param.Add("songCode", songCode);
            _param.Add("startPos", startPos);

            string jsonParam = AgoraJson.ToJson(_param);

            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_MUSICPLAYER_OPEN,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }
    }
}