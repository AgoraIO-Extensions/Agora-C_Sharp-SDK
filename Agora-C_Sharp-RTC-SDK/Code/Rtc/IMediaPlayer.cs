using System;

namespace Agora.Rtc
{
    using view_t = Int64;
    /* class_imediaplayer */
    public abstract class IMediaPlayer
    {
        /* api_imediaplayer_dispose */
        public abstract void Dispose();

        /* api_imediaplayer_getid */
        public abstract int GetId();

        /* api_imediaplayer_initeventhandler */
        public abstract int InitEventHandler(IMediaPlayerSourceObserver engineEventHandler);

#region terra IMediaPlayer

        /* api_imediaplayer_open */
        public abstract int Open(string url, long startPos);

        [Obsolete("")]
        /* api_imediaplayer_openwithcustomsource */
        public abstract int OpenWithCustomSource(long startPos, IMediaPlayerCustomDataProvider provider);

        /* api_imediaplayer_openwithmediasource */
        public abstract int OpenWithMediaSource(MediaSource source);

        /* api_imediaplayer_play */
        public abstract int Play();

        /* api_imediaplayer_pause */
        public abstract int Pause();

        /* api_imediaplayer_stop */
        public abstract int Stop();

        /* api_imediaplayer_resume */
        public abstract int Resume();

        /* api_imediaplayer_seek */
        public abstract int Seek(long newPos);

        /* api_imediaplayer_setaudiopitch */
        public abstract int SetAudioPitch(int pitch);

        /* api_imediaplayer_getduration */
        public abstract int GetDuration(ref long duration);

        /* api_imediaplayer_getplayposition */
        public abstract int GetPlayPosition(ref long pos);

        /* api_imediaplayer_getstreamcount */
        public abstract int GetStreamCount(ref long count);

        /* api_imediaplayer_getstreaminfo */
        public abstract int GetStreamInfo(long index, ref PlayerStreamInfo info);

        /* api_imediaplayer_setloopcount */
        public abstract int SetLoopCount(int loopCount);

        /* api_imediaplayer_setplaybackspeed */
        public abstract int SetPlaybackSpeed(int speed);

        /* api_imediaplayer_selectaudiotrack */
        public abstract int SelectAudioTrack(int index);

        /* api_imediaplayer_setplayeroption */
        public abstract int SetPlayerOption(string key, int value);

        /* api_imediaplayer_setplayeroption */
        public abstract int SetPlayerOption(string key, string value);

        /* api_imediaplayer_takescreenshot */
        public abstract int TakeScreenshot(string filename);

        /* api_imediaplayer_selectinternalsubtitle */
        public abstract int SelectInternalSubtitle(int index);

        /* api_imediaplayer_setexternalsubtitle */
        public abstract int SetExternalSubtitle(string url);

        /* api_imediaplayer_getstate */
        public abstract MEDIA_PLAYER_STATE GetState();

        /* api_imediaplayer_mute */
        public abstract int Mute(bool muted);

        /* api_imediaplayer_getmute */
        public abstract int GetMute(ref bool muted);

        /* api_imediaplayer_adjustplayoutvolume */
        public abstract int AdjustPlayoutVolume(int volume);

        /* api_imediaplayer_getplayoutvolume */
        public abstract int GetPlayoutVolume(ref int volume);

        /* api_imediaplayer_adjustpublishsignalvolume */
        public abstract int AdjustPublishSignalVolume(int volume);

        /* api_imediaplayer_getpublishsignalvolume */
        public abstract int GetPublishSignalVolume(ref int volume);

        /* api_imediaplayer_setview */
        public abstract int SetView(view_t view);

        /* api_imediaplayer_setrendermode */
        public abstract int SetRenderMode(RENDER_MODE_TYPE renderMode);

        /* api_imediaplayer_registeraudioframeobserver */
        public abstract int RegisterAudioFrameObserver(IAudioPcmFrameSink observer);

        /* api_imediaplayer_registeraudioframeobserver */
        public abstract int RegisterAudioFrameObserver(IAudioPcmFrameSink observer, RAW_AUDIO_FRAME_OP_MODE_TYPE mode);

        /* api_imediaplayer_unregisteraudioframeobserver */
        public abstract int UnregisterAudioFrameObserver();

        /* api_imediaplayer_registermediaplayeraudiospectrumobserver */
        public abstract int RegisterMediaPlayerAudioSpectrumObserver(IAudioSpectrumObserver observer, int intervalInMS);

        /* api_imediaplayer_unregistermediaplayeraudiospectrumobserver */
        public abstract int UnregisterMediaPlayerAudioSpectrumObserver();

        /* api_imediaplayer_setaudiodualmonomode */
        public abstract int SetAudioDualMonoMode(AUDIO_DUAL_MONO_MODE mode);

        [Obsolete("This method is deprecated.")]
        /* api_imediaplayer_getplayersdkversion */
        public abstract string GetPlayerSdkVersion();

        /* api_imediaplayer_getplaysrc */
        public abstract string GetPlaySrc();

        /* api_imediaplayer_openwithagoracdnsrc */
        public abstract int OpenWithAgoraCDNSrc(string src, long startPos);

        /* api_imediaplayer_getagoracdnlinecount */
        public abstract int GetAgoraCDNLineCount();

        /* api_imediaplayer_switchagoracdnlinebyindex */
        public abstract int SwitchAgoraCDNLineByIndex(int index);

        /* api_imediaplayer_getcurrentagoracdnindex */
        public abstract int GetCurrentAgoraCDNIndex();

        /* api_imediaplayer_enableautoswitchagoracdn */
        public abstract int EnableAutoSwitchAgoraCDN(bool enable);

        /* api_imediaplayer_renewagoracdnsrctoken */
        public abstract int RenewAgoraCDNSrcToken(string token, long ts);

        /* api_imediaplayer_switchagoracdnsrc */
        public abstract int SwitchAgoraCDNSrc(string src, bool syncPts = false);

        /* api_imediaplayer_switchsrc */
        public abstract int SwitchSrc(string src, bool syncPts = true);

        /* api_imediaplayer_preloadsrc */
        public abstract int PreloadSrc(string src, long startPos);

        /* api_imediaplayer_playpreloadedsrc */
        public abstract int PlayPreloadedSrc(string src);

        /* api_imediaplayer_unloadsrc */
        public abstract int UnloadSrc(string src);

        /* api_imediaplayer_setspatialaudioparams */
        public abstract int SetSpatialAudioParams(SpatialAudioParams @params);

        /* api_imediaplayer_setsoundpositionparams */
        public abstract int SetSoundPositionParams(float pan, float gain);
#endregion terra IMediaPlayer
    }
}