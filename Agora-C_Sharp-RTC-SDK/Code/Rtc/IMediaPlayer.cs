using System;

namespace Agora.Rtc
{
    using view_t = Int64;
    ///
    /// <summary>
    /// This class provides media player functions and supports multiple instances.
    /// </summary>
    ///
    public abstract class IMediaPlayer
    {
        ///
        /// <summary>
        /// Releases all the resources occupied by the media player.
        /// </summary>
        ///
        public abstract void Dispose();

        ///
        /// @ignore
        ///
        public abstract int GetId();

        ///
        /// <summary>
        /// Adds callback event for media player.
        /// </summary>
        ///
        /// <param name="engineEventHandler"> Callback events to be added. See IMediaPlayerSourceObserver. </param>
        ///
        public abstract int InitEventHandler(IMediaPlayerSourceObserver engineEventHandler);

        #region terra IMediaPlayer


        public abstract int Open(string url, long startPos);

        [Obsolete("")]
        public abstract int OpenWithCustomSource(long startPos, IMediaPlayerCustomDataProvider provider);


        public abstract int OpenWithMediaSource(MediaSource source);


        public abstract int Play();


        public abstract int Pause();


        public abstract int Stop();


        public abstract int Resume();


        public abstract int Seek(long newPos);


        public abstract int SetAudioPitch(int pitch);


        public abstract int GetDuration(ref long duration);


        public abstract int GetPlayPosition(ref long pos);


        public abstract int GetStreamCount(ref long count);


        public abstract int GetStreamInfo(long index, ref PlayerStreamInfo info);


        public abstract int SetLoopCount(int loopCount);


        public abstract int SetPlaybackSpeed(int speed);


        public abstract int SelectAudioTrack(int index);


        public abstract int SelectMultiAudioTrack(int playoutTrackIndex, int publishTrackIndex);


        public abstract int SetPlayerOption(string key, int value);


        public abstract int SetPlayerOption(string key, string value);


        public abstract int TakeScreenshot(string filename);


        public abstract int SelectInternalSubtitle(int index);


        public abstract int SetExternalSubtitle(string url);


        public abstract MEDIA_PLAYER_STATE GetState();


        public abstract int Mute(bool muted);


        public abstract int GetMute(ref bool muted);


        public abstract int AdjustPlayoutVolume(int volume);


        public abstract int GetPlayoutVolume(ref int volume);


        public abstract int AdjustPublishSignalVolume(int volume);


        public abstract int GetPublishSignalVolume(ref int volume);


        public abstract int SetView(view_t view);


        public abstract int SetRenderMode(RENDER_MODE_TYPE renderMode);


        public abstract int RegisterAudioFrameObserver(IAudioPcmFrameSink observer);


        public abstract int RegisterAudioFrameObserver(IAudioPcmFrameSink observer, RAW_AUDIO_FRAME_OP_MODE_TYPE mode);


        public abstract int UnregisterAudioFrameObserver();


        public abstract int RegisterMediaPlayerAudioSpectrumObserver(IAudioSpectrumObserver observer, int intervalInMS);


        public abstract int UnregisterMediaPlayerAudioSpectrumObserver();


        public abstract int SetAudioDualMonoMode(AUDIO_DUAL_MONO_MODE mode);

        [Obsolete("This method is deprecated.")]
        public abstract string GetPlayerSdkVersion();


        public abstract string GetPlaySrc();


        public abstract int OpenWithAgoraCDNSrc(string src, long startPos);


        public abstract int GetAgoraCDNLineCount();


        public abstract int SwitchAgoraCDNLineByIndex(int index);


        public abstract int GetCurrentAgoraCDNIndex();


        public abstract int EnableAutoSwitchAgoraCDN(bool enable);


        public abstract int RenewAgoraCDNSrcToken(string token, long ts);


        public abstract int SwitchAgoraCDNSrc(string src, bool syncPts = false);


        public abstract int SwitchSrc(string src, bool syncPts = true);


        public abstract int PreloadSrc(string src, long startPos);


        public abstract int PlayPreloadedSrc(string src);


        public abstract int UnloadSrc(string src);


        public abstract int SetSpatialAudioParams(SpatialAudioParams @params);


        public abstract int SetSoundPositionParams(float pan, float gain);
        #endregion terra IMediaPlayer
    }
}