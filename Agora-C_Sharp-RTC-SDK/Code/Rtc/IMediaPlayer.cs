using System;
using view_t = System.UInt64;
namespace Agora.Rtc
{

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
        ///
        /// <summary>
        /// Opens the media resource.
        /// 
        /// This method is called asynchronously. If you need to play a media file, make sure you receive the OnPlayerSourceStateChanged callback reporting PLAYER_STATE_OPEN_COMPLETED before calling the Play method to play the file.
        /// </summary>
        ///
        /// <param name="url"> The path of the media file. Both local path and online path are supported. </param>
        ///
        /// <param name="startPos"> The starting position (ms) for playback. Default value is 0. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int Open(string url, long startPos);

        ///
        /// <summary>
        /// Opens the custom media resource file.
        /// 
        /// Deprecated: This method is deprecated, use OpenWithMediaSource instead. This method allows you to open custom media resource files. For example, you can call this method to open encrypted media resources.
        /// </summary>
        ///
        /// <param name="startPos"> The starting position (ms) for playback. Default value is 0. </param>
        ///
        /// <param name="provider"> The callback for custom media resource files. See IMediaPlayerCustomDataProvider. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        [Obsolete("")]
        public abstract int OpenWithCustomSource(long startPos, IMediaPlayerCustomDataProvider provider);

        ///
        /// <summary>
        /// Opens a media file and configures the playback scenarios.
        /// 
        /// This method supports opening media files of different sources, including a custom media source, and allows you to configure the playback scenarios.
        /// </summary>
        ///
        /// <param name="source"> Media resources. See MediaSource. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int OpenWithMediaSource(MediaSource source);

        ///
        /// <summary>
        /// Plays the media file.
        /// 
        /// After calling Open or Seek, you can call this method to play the media file.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int Play();

        ///
        /// <summary>
        /// Pauses the playback.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int Pause();

        ///
        /// <summary>
        /// Stops playing the media track.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int Stop();

        ///
        /// <summary>
        /// Resumes playing the media file.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int Resume();

        ///
        /// <summary>
        /// Seeks to a new playback position.
        /// 
        /// After successfully calling this method, you will receive the OnPlayerEvent callback, reporting the result of the seek operation to the new playback position. To play the media file from a specific position, do the following:
        /// Call this method to seek to the position you want to begin playback.
        /// Call the Play method to play the media file.
        /// </summary>
        ///
        /// <param name="newPos"> The new playback position (ms). </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int Seek(long newPos);

        ///
        /// <summary>
        /// Sets the pitch of the current media resource.
        /// 
        /// Call this method after calling Open.
        /// </summary>
        ///
        /// <param name="pitch"> Sets the pitch of the local music file by the chromatic scale. The default value is 0, which means keeping the original pitch. The value ranges from -12 to 12, and the pitch value between consecutive values is a chromatic value. The greater the absolute value of this parameter, the higher or lower the pitch of the local music file. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioPitch(int pitch);

        ///
        /// <summary>
        /// Gets the duration of the media resource.
        /// </summary>
        ///
        /// <param name="duration"> An output parameter. The total duration (ms) of the media file. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetDuration(ref long duration);

        ///
        /// <summary>
        /// Gets current local playback progress.
        /// </summary>
        ///
        /// <param name="pos"> The playback position (ms) of the audio effect file. </param>
        ///
        /// <returns>
        /// Returns the current playback progress (ms) if the call succeeds.
        /// &lt; 0: Failure. See MEDIA_PLAYER_REASON.
        /// </returns>
        ///
        public abstract int GetPlayPosition(ref long pos);

        ///
        /// <summary>
        /// Gets the number of the media streams in the media resource.
        /// 
        /// Call this method after you call Open and receive the OnPlayerSourceStateChanged callback reporting the state PLAYER_STATE_OPEN_COMPLETED.
        /// </summary>
        ///
        /// <param name="count"> An output parameter. The number of the media streams in the media resource. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure. See MEDIA_PLAYER_REASON.
        /// </returns>
        ///
        public abstract int GetStreamCount(ref long count);

        ///
        /// <summary>
        /// Gets the detailed information of the media stream.
        /// 
        /// Call this method after calling GetStreamCount.
        /// </summary>
        ///
        /// <param name="index"> The index of the media stream. This parameter needs to be less than the count parameter of GetStreamCount. </param>
        ///
        /// <param name="info"> An output parameter. The detailed information of the media stream. See PlayerStreamInfo. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetStreamInfo(long index, ref PlayerStreamInfo info);

        ///
        /// <summary>
        /// Sets the loop playback.
        /// 
        /// If you want to loop, call this method and set the number of the loops. When the loop finishes, the SDK triggers OnPlayerSourceStateChanged and reports the playback state as PLAYER_STATE_PLAYBACK_ALL_LOOPS_COMPLETED.
        /// </summary>
        ///
        /// <param name="loopCount"> The number of times the audio effect loops: </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLoopCount(int loopCount);

        ///
        /// <summary>
        /// Sets the channel mode of the current audio file.
        /// 
        /// Call this method after calling Open.
        /// </summary>
        ///
        /// <param name="speed">
        /// The playback speed. Agora recommends that you limit this value to a range between 50 and 400, which is defined as follows:
        /// 50: Half the original speed.
        /// 100: The original speed.
        /// 400: 4 times the original speed.
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetPlaybackSpeed(int speed);

        ///
        /// <summary>
        /// Selects the audio track used during playback.
        /// 
        /// After getting the track index of the audio file, you can call this method to specify any track to play. For example, if different tracks of a multi-track file store songs in different languages, you can call this method to set the playback language. You need to call this method after calling GetStreamInfo to get the audio stream index value.
        /// </summary>
        ///
        /// <param name="index"> The index of the audio track. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SelectAudioTrack(int index);

        ///
        /// <summary>
        /// Selects the audio tracks that you want to play on your local device and publish to the channel respectively.
        /// 
        /// You can call this method to determine the audio track to be played on your local device and published to the channel. Before calling this method, you need to open the media file with the OpenWithMediaSource method and set enableMultiAudioTrack in MediaSource as true.
        /// </summary>
        ///
        /// <param name="playoutTrackIndex"> The index of audio tracks for local playback. You can obtain the index through GetStreamInfo. </param>
        ///
        /// <param name="publishTrackIndex"> The index of audio tracks to be published in the channel. You can obtain the index through GetStreamInfo. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SelectMultiAudioTrack(int playoutTrackIndex, int publishTrackIndex);

        ///
        /// <summary>
        /// Set media player options for providing technical previews or special customization features.
        /// 
        /// The media player supports setting options through key and value. In general, you don't need to know about the option settings. You can use the default option settings of the media player. The difference between this method and setPlayerOption [2/2] is that the value parameter of this method is of type Int, while the value of setPlayerOption [2/2] is of type String. These two methods cannot be used together. Ensure that you call this method before Open or OpenWithMediaSource.
        /// </summary>
        ///
        /// <param name="key"> The key of the option. </param>
        ///
        /// <param name="value"> The value of the key. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetPlayerOption(string key, int value);

        ///
        /// <summary>
        /// Set media player options for providing technical previews or special customization features.
        /// 
        /// Ensure that you call this method before Open or OpenWithMediaSource. The media player supports setting options through key and value. In general, you don't need to know about the option settings. You can use the default option settings of the media player. The difference between this method and SetPlayerOption [1/2] is that the value parameter of this method is of type String, while the value of SetPlayerOption [1/2] is of type String. These two methods cannot be used together.
        /// </summary>
        ///
        /// <param name="key"> The key of the option. </param>
        ///
        /// <param name="value"> The value of the key. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetPlayerOption(string key, string value);

        ///
        /// @ignore
        ///
        public abstract int TakeScreenshot(string filename);

        ///
        /// @ignore
        ///
        public abstract int SelectInternalSubtitle(int index);

        ///
        /// @ignore
        ///
        public abstract int SetExternalSubtitle(string url);

        ///
        /// <summary>
        /// Gets current playback state.
        /// </summary>
        ///
        /// <returns>
        /// The current playback state. See MEDIA_PLAYER_STATE.
        /// </returns>
        ///
        public abstract MEDIA_PLAYER_STATE GetState();

        ///
        /// <summary>
        /// Sets whether to mute the media file.
        /// </summary>
        ///
        /// <param name="muted"> Whether to mute the media file: true : Mute the media file. false : (Default) Unmute the media file. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int Mute(bool muted);

        ///
        /// <summary>
        /// Reports whether the media resource is muted.
        /// </summary>
        ///
        /// <param name="muted"> An output parameter. Whether the media file is muted: true : The media file is muted. false : The media file is unmuted. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetMute(ref bool muted);

        ///
        /// <summary>
        /// Adjusts the local playback volume.
        /// </summary>
        ///
        /// <param name="volume">
        /// The local playback volume, which ranges from 0 to 100:
        /// 0: Mute.
        /// 100: (Default) The original volume.
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustPlayoutVolume(int volume);

        ///
        /// <summary>
        /// Gets the local playback volume.
        /// </summary>
        ///
        /// <param name="volume">
        /// An output parameter. The local playback volume, which ranges from 0 to 100:
        /// 0: Mute.
        /// 100: (Default) The original volume.
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetPlayoutVolume(ref int volume);

        ///
        /// <summary>
        /// Adjusts the volume of the media file for publishing.
        /// 
        /// After connected to the Agora server, you can call this method to adjust the volume of the media file heard by the remote user.
        /// </summary>
        ///
        /// <param name="volume">
        /// The volume, which ranges from 0 to 400:
        /// 0: Mute.
        /// 100: (Default) The original volume.
        /// 400: Four times the original volume (amplifying the audio signals by four times).
        /// </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustPublishSignalVolume(int volume);

        ///
        /// <summary>
        /// Gets the volume of the media file for publishing.
        /// </summary>
        ///
        /// <param name="volume"> An output parameter. The remote playback volume. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetPublishSignalVolume(ref int volume);

        ///
        /// <summary>
        /// Sets the view.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetView(view_t view);

        ///
        /// <summary>
        /// Sets the render mode of the media player.
        /// </summary>
        ///
        /// <param name="renderMode"> Sets the render mode of the view. See RENDER_MODE_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRenderMode(RENDER_MODE_TYPE renderMode);

        ///
        /// <summary>
        /// Registers a PCM audio frame observer object.
        /// 
        /// You need to implement the IAudioPcmFrameSink class in this method and register callbacks according to your scenarios. After you successfully register the video frame observer, the SDK triggers the registered callbacks each time a video frame is received.
        /// </summary>
        ///
        /// <param name="observer"> The audio frame observer, reporting the reception of each audio frame. See IAudioPcmFrameSink. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RegisterAudioFrameObserver(IAudioPcmFrameSink observer);

        ///
        /// <summary>
        /// Registers an audio frame observer object.
        /// </summary>
        ///
        /// <param name="observer"> The audio frame observer, reporting the reception of each audio frame. See IAudioPcmFrameSink. </param>
        ///
        /// <param name="mode"> The use mode of the audio frame. See RAW_AUDIO_FRAME_OP_MODE_TYPE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RegisterAudioFrameObserver(IAudioPcmFrameSink observer, RAW_AUDIO_FRAME_OP_MODE_TYPE mode);

        ///
        /// <summary>
        /// Unregisters an audio frame observer.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UnregisterAudioFrameObserver();

        ///
        /// @ignore
        ///
        public abstract int RegisterMediaPlayerAudioSpectrumObserver(IAudioSpectrumObserver observer, int intervalInMS);

        ///
        /// @ignore
        ///
        public abstract int UnregisterMediaPlayerAudioSpectrumObserver();

        ///
        /// <summary>
        /// Sets the channel mode of the current audio file.
        /// 
        /// In a stereo music file, the left and right channels can store different audio data. According to your needs, you can set the channel mode to original mode, left channel mode, right channel mode, or mixed channel mode. For example, in the KTV scenario, the left channel of the music file stores the musical accompaniment, and the right channel stores the singing voice. If you only need to listen to the accompaniment, call this method to set the channel mode of the music file to left channel mode; if you need to listen to the accompaniment and the singing voice at the same time, call this method to set the channel mode to mixed channel mode.
        /// Call this method after calling Open.
        /// This method only applies to stereo audio files.
        /// </summary>
        ///
        /// <param name="mode"> The channel mode. See AUDIO_DUAL_MONO_MODE. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioDualMonoMode(AUDIO_DUAL_MONO_MODE mode);

        ///
        /// @ignore
        ///
        [Obsolete("This method is deprecated.")]
        public abstract string GetPlayerSdkVersion();

        ///
        /// <summary>
        /// Gets the path of the media resource being played.
        /// </summary>
        ///
        /// <returns>
        /// The path of the media resource being played.
        /// </returns>
        ///
        public abstract string GetPlaySrc();

        ///
        /// @ignore
        ///
        public abstract int OpenWithAgoraCDNSrc(string src, long startPos);

        ///
        /// @ignore
        ///
        public abstract int GetAgoraCDNLineCount();

        ///
        /// @ignore
        ///
        public abstract int SwitchAgoraCDNLineByIndex(int index);

        ///
        /// @ignore
        ///
        public abstract int GetCurrentAgoraCDNIndex();

        ///
        /// @ignore
        ///
        public abstract int EnableAutoSwitchAgoraCDN(bool enable);

        ///
        /// @ignore
        ///
        public abstract int RenewAgoraCDNSrcToken(string token, long ts);

        ///
        /// @ignore
        ///
        public abstract int SwitchAgoraCDNSrc(string src, bool syncPts = false);

        ///
        /// <summary>
        /// Switches the media resource being played.
        /// 
        /// You can call this method to switch the media resource to be played according to the current network status. For example:
        /// When the network is poor, the media resource to be played is switched to a media resource address with a lower bitrate.
        /// When the network is good, the media resource to be played is switched to a media resource address with a higher bitrate. After calling this method, if you receive the PLAYER_EVENT_SWITCH_COMPLETE event in the OnPlayerEvent callback, the switch is successful; If you receive the PLAYER_EVENT_SWITCH_ERROR event in the OnPlayerEvent callback, the switch fails.
        /// Ensure that you call this method after Open.
        /// To ensure normal playback, pay attention to the following when calling this method:
        /// Do not call this method when playback is paused.
        /// Do not call the Seek method during switching.
        /// Before switching the media resource, make sure that the playback position does not exceed the total duration of the media resource to be switched.
        /// </summary>
        ///
        /// <param name="src"> The URL of the media resource. </param>
        ///
        /// <param name="syncPts"> Whether to synchronize the playback position (ms) before and after the switch: true : Synchronize the playback position before and after the switch. false : (Default) Do not synchronize the playback position before and after the switch. Make sure to set this parameter as false if you need to play live streams, or the switch fails. If you need to play on-demand streams, you can set the value of this parameter according to your scenarios. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SwitchSrc(string src, bool syncPts = true);

        ///
        /// <summary>
        /// Preloads a media resource.
        /// 
        /// You can call this method to preload a media resource into the playlist. If you need to preload multiple media resources, you can call this method multiple times. If the preload is successful and you want to play the media resource, call PlayPreloadedSrc; if you want to clear the playlist, call Stop. Agora does not support preloading duplicate media resources to the playlist. However, you can preload the media resources that are being played to the playlist again.
        /// </summary>
        ///
        /// <param name="src"> The URL of the media resource. </param>
        ///
        /// <param name="startPos"> The starting position (ms) for playing after the media resource is preloaded to the playlist. When preloading a live stream, set this parameter to 0. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PreloadSrc(string src, long startPos);

        ///
        /// <summary>
        /// Plays preloaded media resources.
        /// 
        /// After calling the PreloadSrc method to preload the media resource into the playlist, you can call this method to play the preloaded media resource. After calling this method, if you receive the OnPlayerSourceStateChanged callback which reports the PLAYER_STATE_PLAYING state, the playback is successful. If you want to change the preloaded media resource to be played, you can call this method again and specify the URL of the new media resource that you want to preload. If you want to replay the media resource, you need to call PreloadSrc to preload the media resource to the playlist again before playing. If you want to clear the playlist, call the Stop method. If you call this method when playback is paused, this method does not take effect until playback is resumed.
        /// </summary>
        ///
        /// <param name="src"> The URL of the media resource in the playlist must be consistent with the src set by the PreloadSrc method; otherwise, the media resource cannot be played. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PlayPreloadedSrc(string src);

        ///
        /// <summary>
        /// Unloads media resources that are preloaded.
        /// 
        /// This method cannot release the media resource being played.
        /// </summary>
        ///
        /// <param name="src"> The URL of the media resource. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UnloadSrc(string src);

        ///
        /// <summary>
        /// Enables or disables the spatial audio effect for the media player.
        /// 
        /// After successfully setting the spatial audio effect parameters of the media player, the SDK enables the spatial audio effect for the media player, and the local user can hear the media resources with a sense of space. If you need to disable the spatial audio effect for the media player, set the params parameter to null.
        /// </summary>
        ///
        /// <param name="spatial_audio_params"> The spatial audio effect parameters of the media player. See SpatialAudioParams. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetSpatialAudioParams(SpatialAudioParams @params);

        ///
        /// @ignore
        ///
        public abstract int SetSoundPositionParams(float pan, float gain);
        #endregion terra IMediaPlayer
    }
}