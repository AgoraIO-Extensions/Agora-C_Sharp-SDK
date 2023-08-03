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
        /// To ensure that the data format of captured audio frame is as expected, Agora recommends that you set the audio data format as follows: After calling SetRecordingAudioFrameParameters to set the audio data format and  RegisterAudioFrameObserver to register the audio observer object, the SDK will calculate the sampling interval according to the parameters set in this method, and triggers the OnRecordAudioFrame callback according to the sampling interval.
        /// </summary>
        ///
        /// <param name="audioFrame"> The raw audio data. See AudioFrame.</param>
        ///
        /// <param name="channelId"> The channel ID.</param>
        ///
        /// <returns>
        /// Without practical meaning.
        /// </returns>
        ///
        public virtual bool OnRecordAudioFrame(string channelId, AudioFrame audioFrame)
        {
            return true;
        }

        ///
        /// <summary>
        /// Gets the raw audio frame for playback.
        /// To ensure that the data format of audio frame for playback is as expected, Agora recommends that you set the audio data format as follows: After calling SetPlaybackAudioFrameParameters to set the audio data format and RegisterAudioFrameObserver to register audio frame observer object, the SDK calculates the sampling interval according to the parameters set in the methods, and triggers the callback according to the sampling interval OnPlaybackAudioFrame.
        /// </summary>
        ///
        /// <param name="audio_Frame"> The raw audio data. See AudioFrame.</param>
        ///
        /// <param name="channelId"> The channel ID.</param>
        ///
        /// <returns>
        /// Without practical meaning.
        /// </returns>
        ///
        public virtual bool OnPlaybackAudioFrame(string channelId, AudioFrame audio_frame)
        {
            return true;
        }

        ///
        /// <summary>
        /// Retrieves the mixed captured and playback audio frame.
        /// To ensure that the data format of mixed captured and playback audio frame meets the expectations, Agora recommends that you set the data format as follows: After calling SetMixedAudioFrameParameters to set the audio data format and RegisterAudioFrameObserver to register the audio frame observer object, the SDK calculates the sampling interval according to the parameters set in the methods, and triggers the callback according to the sampling interval OnMixedAudioFrame.
        /// </summary>
        ///
        /// <param name="audio_Frame"> The raw audio data. See AudioFrame.</param>
        ///
        /// <param name="channelId"> The channel ID.</param>
        ///
        /// <returns>
        /// Without practical meaning.
        /// </returns>
        ///
        public virtual bool OnMixedAudioFrame(string channelId, AudioFrame audio_frame)
        {
            return true;
        }


        ///
        /// <summary>
        /// Gets the in-ear monitoring audio frame.
        /// In order to ensure that the obtained in-ear audio data meets the expectations, Agora recommends that you set the in-ear monitoring-ear audio data format as follows: After calling SetEarMonitoringAudioFrameParameters to set the audio data format and RegisterAudioFrameObserver to register the audio frame observer object, the SDK calculates the sampling interval according to the parameters set in the methods, and triggers the OnEarMonitoringAudioFrame callback according to the sampling interval.
        /// </summary>
        ///
        /// <param name="audioFrame"> The raw audio data. See AudioFrame.</param>
        ///
        /// <returns>
        /// Without practical meaning.
        /// </returns>
        ///
        public virtual bool OnEarMonitoringAudioFrame(AudioFrame audioFrame)
        {
            return true;
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
        /// <param name="audio_Frame"> The raw audio data. See AudioFrame.</param>
        ///
        /// <returns>
        /// Without practical meaning.
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
        /// <param name="channel_id"> The channel ID.</param>
        ///
        /// <param name="userId"> The user ID of the specified user.</param>
        ///
        /// <param name="audio_Frame"> The raw audio data. See AudioFrame.</param>
        ///
        /// <returns>
        /// Without practical meaning.
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