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
        /// <param name="userId"> The ID of the user sending the audio frame.</param>
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