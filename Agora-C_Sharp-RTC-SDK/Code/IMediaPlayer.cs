using System;

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
        /// <summary>
        /// Gets the ID of the media player.
        /// </summary>
        ///
        /// <returns>
        /// >= 0: Success. The ID of the media player.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetId();

        ///
        /// <summary>
        /// Adds callback event for media player.
        /// </summary>
        ///
        /// <param name="engineEventHandler"> Callback events to be added. </param>
        ///
        public abstract void InitEventHandler(IMediaPlayerSourceObserver engineEventHandler);

        ///
        /// <summary>
        /// Registers an audio frame observer object.
        /// You need to implement the IMediaPlayerAudioFrameObserver class in this method and register callbacks according to your scenarios. After you successfully register the video frame observer, the SDK triggers the registered callbacks each time a video frame is received.
        /// </summary>
        ///
        /// <param name="observer"> The audio frame observer, reporting the reception of each audio frame. See IMediaPlayerAudioFrameObserver .</param>
        ///
        public abstract void RegisterAudioFrameObserver(IMediaPlayerAudioFrameObserver observer);

        ///
        /// <summary>
        /// Registers an audio frame observer object.
        /// </summary>
        ///
        /// <param name="observer"> The audio frame observer, reporting the reception of each audio frame. See IAudioFrameObserver .</param>
        ///
        /// <param name="mode"> The use mode of the audio frame. See RAW_AUDIO_FRAME_OP_MODE_TYPE .</param>
        ///
        public abstract void RegisterAudioFrameObserver(IMediaPlayerAudioFrameObserver observer, RAW_AUDIO_FRAME_OP_MODE_TYPE mode);

        ///
        /// <summary>
        /// Unregisters an audio frame observer.
        /// </summary>
        ///
        public abstract void UnregisterAudioFrameObserver();

        ///
        /// @ignore
        ///
        public abstract void RegisterMediaPlayerAudioSpectrumObserver(IAudioSpectrumObserver observer, int intervalInMS);

        ///
        /// @ignore
        ///
        public abstract void UnregisterMediaPlayerAudioSpectrumObserver();

        ///
        /// <summary>
        /// Opens the media resource.
        /// This method is called asynchronously. If you need to play a media file, make sure you receive the OnPlayerSourceStateChanged callback reporting PLAYER_STATE_OPEN_COMPLETED before calling the Play method to play the file.
        /// </summary>
        ///
        /// <param name="url"> The path of the media file. Both local path and online path are supported.On the Android platform, if you need to open a file in URI format, use Open .</param>
        ///
        /// <param name="startPos"> The starting position (ms) for playback. Default value is 0.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int Open(string url, Int64 startPos);

        ///
        /// <summary>
        /// Opens the custom media resource file.
        /// Deprecated:This method is deprecated. This method allows you to open custom media resource files. For example, you can call this method to open encrypted media resources.
        /// </summary>
        ///
        /// <param name="playerId"> The ID of the media player.</param>
        ///
        /// <param name="startPos"> The starting position (ms) for playback. The default value is 0.</param>
        ///
        /// <param name="provider"> The callback for custom media resource files. See IMediaPlayerCustomDataProvider .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int OpenWithCustomSource(Int64 startPos, IMediaPlayerCustomDataProvider provider);

        ///
        /// <summary>
        /// Opens a media file and configures the playback scenarios.
        /// This method supports opening media files of different sources, including a custom media source, and allows you to configure the playback scenarios.
        /// </summary>
        ///
        /// <param name="source"> Media resources. See MediaSource .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int OpenWithMediaSource(MediaSource source);

        ///
        /// @ignore
        ///
        public abstract int SetSoundPositionParams(float pan, float gain);

        ///
        /// <summary>
        /// Plays the media file.
        /// After calling Open or Seek, you can call this method to play the media file.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int Play();

        ///
        /// <summary>
        /// Pauses the playback.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int Pause();

        ///
        /// <summary>
        /// Stops playing the media track.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int Stop();

        ///
        /// <summary>
        /// Resumes playing the media file.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int Resume();

        ///
        /// <summary>
        /// Seeks to a new playback position.
        /// After successfully calling this method, you will receive the OnPlayerEvent callback, reporting the result of the seek operation to the new playback position.To play the media file from a specific position, do the following:Call this method to seek to the position you want to begin playback.Call the Play method to play the media file.
        /// </summary>
        ///
        /// <param name="newPos"> The new playback position (ms).</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int Seek(Int64 newPos);

        ///
        /// <summary>
        /// Gets the duration of the media resource.
        /// </summary>
        ///
        /// <param name="duration"> Output parameter. The total duration (ms) of the media file.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetDuration(ref Int64 duration);

        ///
        /// <summary>
        /// Gets current local playback progress.
        /// </summary>
        ///
        /// <param name="pos"> The playback position (ms) of the audio effect file.</param>
        ///
        /// <returns>
        /// Returns the current playback progress (ms) if the call succeeds.&lt; 0: Failure. See MEDIA_PLAYER_ERROR .
        /// </returns>
        ///
        public abstract int GetPlayPosition(ref Int64 pos);

        ///
        /// <summary>
        /// Gets the number of the media streams in the media resource.
        /// Call this method after calling Open .
        /// </summary>
        ///
        /// <param name="count"> Output parameter. The number of the media streams in the media resource.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure. See MEDIA_PLAYER_ERROR .
        /// </returns>
        ///
        public abstract int GetStreamCount(ref Int64 count);

        ///
        /// <summary>
        /// Gets the detailed information of the media stream.
        /// Call this method after calling GetStreamCount .
        /// </summary>
        ///
        /// <param name="index"> The index of the media stream.</param>
        ///
        /// <param name="info"> An output parameter. The detailed information of the media stream. See PlayerStreamInfo .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetStreamInfo(Int64 index, ref PlayerStreamInfo info);

        ///
        /// <summary>
        /// Sets the loop playback.
        /// If you want to loop, call this method and set the number of the loops.When the loop finishes, the SDK triggers OnPlayerSourceStateChanged and reports the playback state as PLAYER_STATE_PLAYBACK_ALL_LOOPS_COMPLETED.
        /// </summary>
        ///
        /// <param name="loopCount"> The number of times the audio effect loops:</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetLoopCount(int loopCount);

        ///
        /// <summary>
        /// Sets the channel mode of the current audio file.
        /// Call this method after calling Open .
        /// </summary>
        ///
        /// <param name="speed"> The playback speed. Agora recommends that you limit this value to between 50 and 400, defined as follows:50: Half the original speed.100: The original speed.400: 4 times the original speed.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetPlaybackSpeed(int speed);

        ///
        /// <summary>
        /// Selects the audio track used during playback.
        /// After getting the track index of the audio file, you can call this method to specify any track to play. For example, if different tracks of a multi-track file store songs in different languages, you can call this method to set the playback language.You need to call this method after calling GetStreamInfo to get the audio stream index value.
        /// </summary>
        ///
        /// <param name="index"> The index of the audio track.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SelectAudioTrack(int index);

        ///
        /// <summary>
        /// Sets the private options for the media player.
        /// The media player supports setting private options by key and value. Under normal circumstances, you do not need to know the private option settings, and just use the default option settings.Ensure that you call this method before Open .If you need to push streams with SEI into the CDN, callSetPlayerOption [1/2] ("sei_data_with_uuid", 1); otherwise, the loss of SEI might occurs.
        /// </summary>
        ///
        /// <param name="key"> The key of the option.</param>
        ///
        /// <param name="value"> The value of the key.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetPlayerOption(string key, int value);

        ///
        /// <summary>
        /// Sets the private options for the media player.
        /// The media player supports setting private options by key and value. Under normal circumstances, you do not need to know the private option settings, and just use the default option settings. Ensure that you call this method before Open .
        /// If you need to push streams with SEI into the CDN, callSetPlayerOption [1/2] ("sei_data_with_uuid", 1); otherwise, the loss of SEI might occurs.
        /// </summary>
        ///
        /// <param name="key"> The key of the option.</param>
        ///
        /// <param name="value"> The value of the key.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
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
        /// The current playback state. See MEDIA_PLAYER_STATE .
        /// </returns>
        ///
        public abstract MEDIA_PLAYER_STATE GetState();

        ///
        /// <summary>
        /// Sets whether to mute the media file.
        /// </summary>
        ///
        /// <param name="muted"> Whether to mute the media file:true: Mute the media file.false: (Default) Unmute the media file.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int Mute(bool muted);

        ///
        /// <summary>
        /// Reports whether the media resource is muted.
        /// </summary>
        ///
        /// <param name="muted"> Output parameter. Whether the media file is muted:true: Mute the media file.false: The media file is unmuted.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetMute(ref bool muted);

        ///
        /// <summary>
        /// Adjusts the local playback volume.
        /// </summary>
        ///
        /// <param name="volume"> The local playback volume, which ranges from 0 to 100:0: Mute.100: (Default) The original volume.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustPlayoutVolume(int volume);

        ///
        /// <summary>
        /// Gets the local playback volume.
        /// </summary>
        ///
        /// <param name="volume"> Output parameter. The local playback volume, which ranges from 0 to 100:0: Mute.100: (Default) The original volume.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetPlayoutVolume(ref int volume);

        ///
        /// <summary>
        /// Adjusts the volume of the media file for publishing.
        /// After connected to the Agora server, you can call this method to adjust the volume of the media file heard by the remote user.
        /// </summary>
        ///
        /// <param name="volume"> The volume, which ranges from 0 to 400:0: Mute.100: (Default) The original volume.400: Four times the original volume (amplifying the audio signals by four times).</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int AdjustPublishSignalVolume(int volume);

        ///
        /// <summary>
        /// Gets the volume of the media file for publishing.
        /// </summary>
        ///
        /// <param name="volume"> Output parameter. The remote playback volume.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetPublishSignalVolume(ref int volume);

        ///
        /// <summary>
        /// Sets the view.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetView();

        ///
        /// <summary>
        /// Sets the render mode of the media player.
        /// </summary>
        ///
        /// <param name="renderMode"> Sets the render mode of the view. See RENDER_MODE_TYPE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetRenderMode(RENDER_MODE_TYPE renderMode);

        ///
        /// <summary>
        /// Sets the channel mode of the current audio file.
        /// In a stereo music file, the left and right channels can store different audio data. According to your needs, you can set the channel mode to original mode, left channel mode, right channel mode, or mixed channel mode. For example, in the KTV scenario, the left channel of the music file stores the musical accompaniment, and the right channel stores the singing voice. If you only need to listen to the accompaniment, call this method to set the channel mode of the music file to left channel mode; if you need to listen to the accompaniment and the singing voice at the same time, call this method to set the channel mode to mixed channel mode.Call this method after calling Open .This method only applies to stereo audio files.
        /// </summary>
        ///
        /// <param name="mode"> The channel mode. See AUDIO_DUAL_MONO_MODE .</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioDualMonoMode(AUDIO_DUAL_MONO_MODE mode);

        ///
        /// @ignore
        ///
        public abstract string GetPlayerSdkVersion();

        ///
        /// @ignore
        ///
        public abstract string GetPlaySrc();

        ///
        /// <summary>
        /// Sets the pitch of the current media resource.
        /// Call this method after calling Open .
        /// </summary>
        ///
        /// <param name="pitch"> Sets the pitch of the local music file by the chromatic scale. The default value is 0, which means keeping the original pitch. The value ranges from -12 to 12, and the pitch value between consecutive values is a chromatic value. The greater the absolute value of this parameter, the higher or lower the pitch of the local music file.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SetAudioPitch(int pitch);

        ///
        /// @ignore
        ///
        public abstract int SetSpatialAudioParams(SpatialAudioParams spatial_audio_params);

        ///
        /// <summary>
        /// Opens a media resource and requests all the CDN routes of the media resources through the self-developed scheduling center.
        /// This method is called asynchronously. If you need to play a media file, make sure you receive the OnPlayerSourceStateChanged callback reporting PLAYER_STATE_OPEN_COMPLETED before calling the Play method to play the file.After you call this method, Agora opens the media resources and tries to obtain all the CDN routes for playing the media resource. By default, Agora uses the first CDN route for playing, and you can call the SwitchAgoraCDNLineByIndex method to switch routes.If you want to ensure the security of the connection and media files, to determine the sign and the ts fields for authentication. Once the fields are determined, use them as the query parameter of the URL to update the URL of the media resource. For example:The URL of the media file to be opened: rtmp://$domain/$appName/$streamNameThe URL updated by the authentication of the media file to be opened: rtmp://$domain/$appName/$streamName?ts=$ts&sign=$signAuthentication information:sign: An encrypted string calculated according to the MD5 algorithm based on authKey, appName, streamName, and ts. You need to for your authKey.ts: The timestamp when the authentication information expires. You can set the validity period of the authentication information according to your scenarios. For example, 24h or 1h30m20s.
        /// </summary>
        ///
        /// <param name="src"> The URL of the media resource.</param>
        ///
        /// <param name="startPos"> The starting position (ms) for playback. The default value is 0. This value can be empty if the media resource to be played is live streams.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int OpenWithAgoraCDNSrc(string src, Int64 startPos);

        ///
        /// <summary>
        /// Gets the number of CDN routes for the media resource.
        /// </summary>
        ///
        /// <returns>
        /// Returns the number of CDN routes for the media resource, if the method call succeeds.≤ 0: Failure.
        /// </returns>
        ///
        public abstract int GetAgoraCDNLineCount();

        ///
        /// <summary>
        /// Changes the CDN route for playing the media resource.
        /// After calling OpenWithAgoraCDNSrc to open the media resource, you can call this method if you want to change the CDN routes for playing the media resource.Call this method after calling OpenWithAgoraCDNSrc .You can call this method either before or after Play . If you call this method before Play, the switch does not take effect immediately. The SDK waits for the playback to complete before switching the CDN line of the media resource.
        /// </summary>
        ///
        /// <param name="index"> The index of the CDN routes.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SwitchAgoraCDNLineByIndex(int index);

        ///
        /// <summary>
        /// Gets the CDN routes index of the current media resource.
        /// </summary>
        ///
        /// <returns>
        /// The number of CDN routes for the media resource, if the method call succeeds. The value range is [0, GetAgoraCDNLineCount()).&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int GetCurrentAgoraCDNIndex();

        ///
        /// <summary>
        /// Enables/Disables the automatic switch of the CDN routes for playing the media resource.
        /// You can call this method if you want the SDK to automatically switch the CDN routes according to your network conditions.Call this method before OpenWithAgoraCDNSrc .
        /// </summary>
        ///
        /// <param name="enable"> Whether to enable the automatic switch of the CDN routes for playing the media resource:true: Enables the automatic switch of the CDN routes.false: (Default) Disables the automatic switch of the CDN routes.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int EnableAutoSwitchAgoraCDN(bool enable);

        ///
        /// <summary>
        /// Renew the authentication information for the URL of the media resource to be played.
        /// When the authentication information expires (exceeds the ts field), you can call the OpenWithAgoraCDNSrc method to reopen the media resource or the SwitchAgoraCDNSrc method to switch the media resource, and then pass in the authenticated URL (with the ts field updated) of the media resource.If your authentication information expires when you call the SwitchAgoraCDNLineByIndex to switch the CDN route for playing the media resource, you need to call this method to pass in the updated authentication information to update the authentication information of the media resource URL. After updating the authentication information, you need to call SwitchAgoraCDNLineByIndex to complete the route switching.To avoid frequent expiration of authentication information, ensure that you set the ts field appropriately or according to the scenario requirements.
        /// </summary>
        ///
        /// <param name="token"> The authentication field. See the sign field of the authentication information.</param>
        ///
        /// <param name="ts"> The timestamp when the authentication information expires. See the ts field of the authentication information.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int RenewAgoraCDNSrcToken(string token, Int64 ts);

        ///
        /// <summary>
        /// Switches the media resource being played.
        /// If you want to ensure the security of the connection and media files, to determine the sign and the ts fields for authentication. Once the fields are determined, use them as the query parameter of the URL to update the URL of the media resource. For example:The URL of the media file to be opened: rtmp://$domain/$appName/$streamNameThe URL updated by the authentication of the media file to be opened: rtmp://$domain/$appName/$streamName?ts=$ts&sign=$signAuthentication information:sign: An encrypted string calculated according to the MD5 algorithm based on authKey, appName, streamName, and ts. You need to for your authKey.ts: The timestamp when the authentication information expires. You can set the validity period of the authentication information according to your scenarios. For example, 24h or 1h30m20s.If you want to customize the CDN routes for playing the media resource, call this method to switch media resources. Agora changes the CDN route through the self-developed scheduling center to improve the viewing experience. If you do not need to customize CDN routes for playing the media resource, call the SwitchSrc method to switch media resources.
        /// Call this method after calling OpenWithAgoraCDNSrc .You can call this method either before or after Play . If you call this method before Play, the SDK waits for you to call Play before completing the route switch.
        /// </summary>
        ///
        /// <param name="src"> The URL of the media resource.</param>
        ///
        /// <param name="syncPts"> Whether to synchronize the playback position (ms) before and after the switch:true: Synchronize the playback position before and after the switch.false: (Default) Do not synchronize the playback position before and after the switch.falseMake sure to set this parameter as if you need to play live streams, or the switch fails. If you need to play on-demand streams, you can set the value of this parameter according to your scenarios.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SwitchAgoraCDNSrc(string src, bool syncPts = false);

        ///
        /// <summary>
        /// Switches the media resource being played.
        /// You can call this method to switch the media resource to be played according to the current network status. For example:When the network is poor, the media resource to be played is switched to a media resource address with a lower bitrate.When the network is good, the media resource to be played is switched to a media resource address with a higher bitrate.After calling this method, if you receive the OnPlayerEvent event in the PLAYER_EVENT_SWITCH_COMPLETE callback, the switch is successful; If you receive the OnPlayerEvent event in the PLAYER_EVENT_SWITCH_ERROR callback, the switch fails.Ensure that you call this method after Open .To ensure normal playback, pay attention to the following when calling this method:Do not call this method when playback is paused.Do not call the Seek method during switching.Before switching the media resource, make sure that the playback position does not exceed the total duration of the media resource to be switched.
        /// </summary>
        ///
        /// <param name="src"> The URL of the media resource.</param>
        ///
        /// <param name="syncPts"> Whether to synchronize the playback position (ms) before and after the switch:true: Synchronize the playback position before and after the switch.false: (Default) Do not synchronize the playback position before and after the switch.Make sure to set this parameter as false if you need to play live streams, or the switch fails. If you need to play on-demand streams, you can set the value of this parameter according to your scenarios.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int SwitchSrc(string src, bool syncPts = true);

        ///
        /// <summary>
        /// Preloads a media resource.
        /// You can call this method to preload a media resource into the playlist. If you need to preload multiple media resources, you can call this method multiple times.If the preload is successful and you want to play the media resource, call PlayPreloadedSrc ; if you want to clear the playlist, call Stop .Agora does not support preloading duplicate media resources to the playlist. However, you can preload the media resources that are being played to the playlist again.
        /// </summary>
        ///
        /// <param name="src"> The URL of the media resource.</param>
        ///
        /// <param name="startPos"> The starting position (ms) for playing after the media resource is preloaded to the playlist. When preloading a live stream, set this parameter to 0.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PreloadSrc(string src, Int64 startPos);

        ///
        /// <summary>
        /// Plays preloaded media resources.
        /// After calling the PreloadSrc method to preload the media resource into the playlist, you can call this method to play the preloaded media resource. After calling this method, if you receive the OnPlayerSourceStateChanged callback which reports the PLAYER_STATE_PLAYING state, the playback is successful.If you want to change the preloaded media resource to be played, you can call this method again and specify the URL of the new media resource that you want to preload. If you want to replay the media resource, you need to call PreloadSrc to preload the media resource to the playlist again before playing. If you want to clear the playlist, call the Stop method.If you call this method when playback is paused, this method does not take effect until playback is resumed.
        /// </summary>
        ///
        /// <param name="src"> The URL of the media resource in the playlist must be consistent with the src set by the PreloadSrc method; otherwise, the media resource cannot be played.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int PlayPreloadedSrc(string src);

        ///
        /// <summary>
        /// Unloads media resources that are preloaded.
        /// This method cannot release the media resource being played.
        /// </summary>
        ///
        /// <param name="src"> The URL of the media resource.</param>
        ///
        /// <returns>
        /// 0: Success.&lt; 0: Failure.
        /// </returns>
        ///
        public abstract int UnloadSrc(string src);
    }
}