namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The audio frame observer.
    /// </summary>
    ///
    public abstract class IAudioFrameObserver
    {
        ///
        /// <summary>
        /// Gets the captured audio frame.
        /// To ensure that the format of the cpatured audio frame is as expected, you can choose one of the following two methods to set the audio data format:Method 1: After calling SetRecordingAudioFrameParameters to set the audio data format and RegisterAudioFrameObserver to register the audio frame observer object, the SDK calculates the sampling interval according to the parameters set in the methods, and triggers the OnRecordAudioFrame callback according to the sampling interval.Method 2: After calling RegisterAudioFrameObserver to register the audio frame observer object, set the audio data format in the return value of the GetObservedAudioFramePosition callback. The SDK then calculates the sampling interval according to the return value of the GetRecordAudioParams callback, and triggers the OnRecordAudioFrame callback according to the sampling interval.The priority of method 1 is higher than that of method 2. If method 1 is used to set the audio data format, the setting of method 2 is invalid.
        /// </summary>
        ///
        /// <param name="audioFrame"> The raw audio data. See AudioFrame .</param>
        ///
        /// <param name="channelId"> The channel ID.</param>
        ///
        /// <returns>
        /// Reserved for future use.
        /// </returns>
        ///
        public virtual bool OnRecordAudioFrame(string channelId, AudioFrame audioFrame)
        {
            return true;
        }

        ///
        /// <summary>
        /// Gets the raw audio frame for playback.
        /// To ensure that the data format of audio frame for playback is as expected, Agora recommends that you choose one of the following two methods to set the audio data format:Method 1: After calling SetPlaybackAudioFrameParameters to set the audio data format and RegisterAudioFrameObserver to register the audio frame observer object, the SDK calculates the sampling interval according to the parameters set in the methods, and triggers the OnPlaybackAudioFrame callback according to the sampling interval.Method 2: After calling RegisterAudioFrameObserver to register the audio frame observer object, set the audio data format in the return value of the GetObservedAudioFramePosition callback. The SDK then calculates the sampling interval according to the return value of the GetPlaybackAudioParams callback, and triggers the OnPlaybackAudioFrame callback according to the sampling interval.The priority of method 1 is higher than that of method 2. If method 1 is used to set the audio data format, the setting of method 2 is invalid.
        /// </summary>
        ///
        /// <param name="audio_Frame"> The raw audio data. See AudioFrame .</param>
        ///
        /// <param name="channelId"> The channel ID.</param>
        ///
        /// <returns>
        /// Reserved for future use.
        /// </returns>
        ///
        public virtual bool OnPlaybackAudioFrame(string channelId, AudioFrame audio_frame)
        {
            return true;
        }

        ///
        /// <summary>
        /// Retrieves the mixed captured and playback audio frame.
        /// To ensure that the data format of mixed captured and playback audio frame meets the expectations, Agora recommends that you choose one of the following two ways to set the data format:Method 1: After calling SetMixedAudioFrameParameters to set the audio data format and RegisterAudioFrameObserver to register the audio frame observer object, the SDK calculates the sampling interval according to the parameters set in the methods, and triggers the OnMixedAudioFrame callback according to the sampling interval.Method 2: After calling RegisterAudioFrameObserver to register the audio frame observer object, set the audio data format in the return value of the GetObservedAudioFramePosition callback. The SDK then calculates the sampling interval according to the return value of the GetMixedAudioParams callback, and triggers the OnMixedAudioFrame callback according to the sampling interval.The priority of method 1 is higher than that of method 2. If method 1 is used to set the audio data format, the setting of method 2 is invalid.
        /// </summary>
        ///
        /// <param name="audio_Frame"> The raw audio data. See AudioFrame .</param>
        ///
        /// <param name="channelId"> The channel ID.</param>
        ///
        /// <returns>
        /// Reserved for future use.
        /// </returns>
        ///
        public virtual bool OnMixedAudioFrame(string channelId, AudioFrame audio_frame)
        {
            return true;
        }


        ///
        /// <summary>
        /// Gets the in-ear monitoring audio frame.
        /// In order to ensure that the obtained in-ear audio data meets the expectations, Agora recommends that you choose one of the following two methods to set the in-ear monitoring-ear audio data format:Method 1: After calling SetEarMonitoringAudioFrameParameters to set the audio data format and RegisterAudioFrameObserver to register the audio frame observer object, the SDK calculates the sampling interval according to the parameters set in the methods, and triggers the OnEarMonitoringAudioFrame callback according to the sampling interval.Method 2: After calling RegisterAudioFrameObserver to register the audio frame observer object, set the audio data format in the return value of the GetObservedAudioFramePosition callback. The SDK then calculates the sampling interval according to the return value of the GetEarMonitoringAudioParams callback, and triggers the OnEarMonitoringAudioFrame callback according to the sampling interval.The priority of method 1 is higher than that of method 2. If method 1 is used to set the audio data format, the setting of method 2 is invalid.
        /// </summary>
        ///
        /// <param name="audioFrame"> The raw audio data. See AudioFrame .</param>
        ///
        /// <returns>
        /// Reserved for future use.
        /// </returns>
        ///
        public virtual bool OnEarMonitoringAudioFrame(AudioFrame audioFrame)
        {
            return true;
        }
        ///
        /// <summary>
        /// Sets the frame position for the video observer.
        /// After successfully registering the audio data observer, the SDK uses this callback for each specific audio frame processing node to determine whether to trigger the following callbacks: OnRecordAudioFrame OnPlaybackAudioFrame OnPlaybackAudioFrameBeforeMixing [1/2] OnMixedAudioFrame OnEarMonitoringAudioFrame You can set one or more positions you need to observe by modifying the return value of GetObservedAudioFramePosition based on your scenario requirements:When the annotation observes multiple locations, the | (or operator) is required. To conserve system resources, you can reduce the number of frame positions that you want to observe.
        /// </summary>
        ///
        /// <returns>
        /// Returns a bitmask that sets the observation position, with the following values:AUDIO_FRAME_POSITION_PLAYBACK(0x0001): This position can observe the playback audio mixed by all remote users, corresponding to the OnPlaybackAudioFrame callback.AUDIO_FRAME_POSITION_RECORD(0x0002): This position can observe the collected local user's audio, corresponding to the OnRecordAudioFrame callback.AUDIO_FRAME_POSITION_MIXED(0x0004): This position can observe the playback audio mixed by the loacl user and all remote users, corresponding to the OnMixedAudioFrame callback.AUDIO_FRAME_POSITION_BEFORE_MIXING(0x0008): This position can observe the audio of a single remote user before mixing, corresponding to the OnPlaybackAudioFrameBeforeMixing [1/2] callback.AUDIO_FRAME_POSITION_EAR_MONITORING(0x0010): This position can observe the audio of a single remote user before mixing, corresponding to the OnEarMonitoringAudioFrame callback.
        /// </returns>
        ///
        public virtual int GetObservedAudioFramePosition()
        {
            return (int)AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_NONE;
        }

        ///
        /// <summary>
        /// Sets the audio format for the OnPlaybackAudioFrame callback.
        /// You need to register the callback when calling the RegisterAudioFrameObserver method. After you successfully register the audio observer, the SDK triggers this callback, and you can set the audio format in the return value of this callback.The SDK triggers the OnPlaybackAudioFrame callback with the AudioParams calculated sampling interval you set in the return value. The calculation formula is Sample interval (sec) = samplePerCall/(sampleRate × channel).Ensure that the sample interval ≥ 0.01 (s).
        /// </summary>
        ///
        /// <returns>
        /// The audio data for playback, see AudioParams .
        /// </returns>
        ///
        public virtual AudioParams GetPlaybackAudioParams()
        {
            return new AudioParams();
        }

        ///
        /// <summary>
        /// Sets the audio format for the OnRecordAudioFrame callback.
        /// You need to register the callback when calling the RegisterAudioFrameObserver method. After you successfully register the audio observer, the SDK triggers this callback, and you can set the audio format in the return value of this callback.The SDK triggers the OnRecordAudioFrame callback with the AudioParams calculated sampling interval you set in the return value. The calculation formula is Sample interval (sec) = samplePerCall/(sampleRate × channel).Ensure that the sample interval ≥ 0.01 (s).
        /// </summary>
        ///
        /// <returns>
        /// The captured audio data, see AudioParams .
        /// </returns>
        ///
        public virtual AudioParams GetRecordAudioParams()
        {
            return new AudioParams();
        }

        ///
        /// <summary>
        /// Sets the audio format for the OnMixedAudioFrame callback.
        /// You need to register the callback when calling the RegisterAudioFrameObserver method. After you successfully register the audio observer, the SDK triggers this callback, and you can set the audio format in the return value of this callback.The SDK triggers the OnMixedAudioFrame callback with the AudioParams calculated sampling interval you set in the return value. The calculation formula is Sample interval (sec) = samplePerCall/(sampleRate × channel).Ensure that the sample interval ≥ 0.01 (s).
        /// </summary>
        ///
        /// <returns>
        /// The mixed captured and playback audio data. See AudioParams .
        /// </returns>
        ///
        public virtual AudioParams GetMixedAudioParams()
        {
            return new AudioParams();
        }


        ///
        /// <summary>
        /// Sets the audio format for the OnEarMonitoringAudioFrame callback.
        /// You need to register the callback when calling the RegisterAudioFrameObserver method. After you successfully register the audio observer, the SDK triggers this callback, and you can set the audio format in the return value of this callback.The SDK triggers the OnEarMonitoringAudioFrame callback with the AudioParams calculated sampling interval you set in the return value. The calculation formula is Sample interval (sec) = samplePerCall/(sampleRate × channel).Ensure that the sample interval ≥ 0.01 (s).
        /// </summary>
        ///
        /// <returns>
        /// The audio data of in-ear monitoring, see AudioParams .
        /// </returns>
        ///
        public virtual AudioParams GetEarMonitoringAudioParams()
        {
            return new AudioParams();
        }
        ///
        /// <summary>
        /// Retrieves the audio frame of a specified user before mixing.
        /// </summary>
        ///
        /// <param name="channel_id"> The channel ID.</param>
        ///
        /// <param name="uid"> The user ID of the specified user.</param>
        ///
        /// <param name="audio_Frame"> The raw audio data. See AudioFrame .</param>
        ///
        /// <returns>
        /// Reserved for future use.
        /// </returns>
        ///
        public virtual bool OnPlaybackAudioFrameBeforeMixing(string channel_id,
                                                        uint uid,
                                                        AudioFrame audio_frame)
        {
            return false;
        }

        ///
        /// <summary>
        /// Retrieves the audio frame of a specified user before mixing.
        /// </summary>
        ///
        /// <param name="channel_id"> The channel name that the audio frame came from.</param>
        ///
        /// <param name="uid"> The ID of the user sending the audio frame.</param>
        ///
        /// <param name="audio_Frame"> The raw audio data. See AudioFrame .</param>
        ///
        /// <returns>
        /// Reserved for future use.
        /// </returns>
        ///
        public virtual bool OnPlaybackAudioFrameBeforeMixing(string channel_id,
                                                        string userId,
                                                        AudioFrame audio_frame)
        {
            return false;
        }
    }


}