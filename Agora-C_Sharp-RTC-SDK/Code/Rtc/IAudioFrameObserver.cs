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
        /// If you want to set the format of the captured audio frame, Agora recommends that you call the RegisterAudioFrameObserver method to set the format of the audio frame after calling the GetRecordAudioParams method to register an audio frame observer. The SDK calculates the sampling interval according to the AudioParams set in the GetRecordAudioParams callback return value, and triggers the OnRecordAudioFrame callback according to the sampling interval.
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
        public virtual bool OnRecordAudioFrame(string channelId ,AudioFrame audioFrame)
        {
            return true;
        }

        ///
        /// <summary>
        /// Gets the audio frame for playback.
        /// If you want to set the format of the audio frame for playback, Agora recommends that you call the RegisterAudioFrameObserver method to set the format of the audio frame after calling the SetPlaybackAudioFrameParameters method to register an audio frame observer.
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
        /// This callback only returns the single-channel data.If you want to set the format of the mixed captured and playback audio frame, Agora recommends you call the RegisterAudioFrameObserver method to set the format of the audio frames after calling the SetMixedAudioFrameParameters method to register an audio frame observer.
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
        /// @ignore
        ///
        public virtual int GetObservedAudioFramePosition()
        {
            return (int)AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_NONE; 
        }

        ///
        /// <summary>
        /// Sets the audio format for the OnPlaybackAudioFrame callback.
        /// You need to register the callback when calling the RegisterAudioFrameObserver method. After you successfully register the audio observer, the SDK triggers this callback, and you can set the audio format in the return value of this callback.The SDK calculates the sample interval according to the AudioParams you set in the return value of this callback.Sample interval = samplePerCall/(sampleRate × channel).Ensure that the sample interval ≥ 0.01 (s).The SDK triggers the OnPlaybackAudioFrame callback according to the sampling interval.
        /// </summary>
        ///
        /// <returns>
        /// Sets the audio format. See AudioParams .
        /// </returns>
        ///
        public virtual AudioParams GetPlaybackAudioParams()
        {
            return new AudioParams();
        }

        ///
        /// <summary>
        /// Sets the audio format for the OnRecordAudioFrame callback.
        /// You need to register the callback when calling the RegisterAudioFrameObserver method. After you successfully register the audio observer, the SDK triggers this callback, and you can set the audio format in the return value of this callback.The SDK calculates the sample interval according to the AudioParams you set in the return value of this callback.Sample interval = samplePerCall/(sampleRate × channel).Ensure that the sample interval ≥ 0.01 (s).The SDK triggers the OnRecordAudioFrame callback according to the sampling interval.
        /// </summary>
        ///
        /// <returns>
        /// Sets the audio format. See AudioParams .
        /// </returns>
        ///
        public virtual AudioParams GetRecordAudioParams()
        {
            return new AudioParams();
        }

        ///
        /// <summary>
        /// Sets the audio format for the OnMixedAudioFrame callback.
        /// You need to register the callback when calling the RegisterAudioFrameObserver method. After you successfully register the audio observer, the SDK triggers this callback, and you can set the audio format in the return value of this callback.The SDK calculates the sample interval according to the AudioParams you set in the return value of this callback.Sample interval = samplePerCall/(sampleRate × channel).Ensure that the sample interval ≥ 0.01 (s).The SDK triggers the OnMixedAudioFrame callback according to the sampling interval.
        /// </summary>
        ///
        /// <returns>
        /// Sets the audio format. See AudioParams .
        /// </returns>
        ///
        public virtual AudioParams GetMixedAudioParams()
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
                                                        string uid,
                                                        AudioFrame audio_frame)
        {
            return false;
        }
    }


}