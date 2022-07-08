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
        /// If you want to set the format of the captured audio frame, Agora recommends that you call the SetRecordingAudioFrameParameters method to set the format of the audio frame after calling RegisterAudioFrameObserver method to register an audio frame observer.
        /// </summary>
        ///
        /// <param name="audioFrame"> The raw audio data. See AudioFrame .</param>
        ///
        /// <param name="channelId"> The ID of the channel.</param>
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
        /// Gets the audio frame for playback.
        /// If you want to set the format of the audio frame for playback, Agora recommends that you call the RegisterAudioFrameObserver method to set the format of the audio frame after calling the SetPlaybackAudioFrameParameters method to register an audio frame observer.
        /// </summary>
        ///
        /// <param name="audioFrame"> The raw audio data. See AudioFrame .</param>
        ///
        /// <param name="channelId"> The ID of the channel.</param>
        ///
        /// <returns>
        /// Reserved for future use.
        /// </returns>
        ///
        public virtual bool OnPlaybackAudioFrame(string channelId, AudioFrame audioFrame)
        {
            return true;
        }

        ///
        /// <summary>
        /// Retrieves the mixed captured and playback audio frame.
        /// This callback only returns the single-channel data.
        /// If you want to set the format of the mixed captured and playback audio frame, Agora recommends you call the SetMixedAudioFrameParameters method to set the format of the audio frames after calling the RegisterAudioFrameObserver method to register an audio frame observer.
        /// </summary>
        ///
        /// <param name="audioFrame"> The raw audio data. See AudioFrame .</param>
        ///
        /// <param name="channelId"> The ID of the channel.</param>
        ///
        /// <returns>
        /// Reserved for future use.
        /// </returns>
        ///
        public virtual bool OnMixedAudioFrame(string channelId, AudioFrame audioFrame)
        {
            return true;
        }

        ///
        /// <summary>
        /// Retrieves the audio frame of a specified user before mixing.
        /// </summary>
        ///
        /// <param name="channelId"> The ID of the channel.</param>
        ///
        /// <param name="uid"> The user ID of the specified user.</param>
        ///
        /// <param name="audioFrame"> The raw audio data. See AudioFrame .</param>
        ///
        /// <returns>
        /// Reserved for future use.
        /// </returns>
        ///
        public virtual bool OnPlaybackAudioFrameBeforeMixing(string channelId, uint uid, AudioFrame audioFrame)
        {
            return true;
        }

        ///
        /// <summary>
        /// Sets whether to receives remote video data in multiple channels.
        /// After you successfully register the audio frame observer, the SDK triggers this callback each time it receives a video frame.
        /// If you want to get the remote video data received in multiple channels, you need to set the return value of this callback as true. After that, the SDK triggers the OnPlaybackAudioFrameBeforeMixingEx callback and sends you the audio data before mixing and reports which channel the audio frame came from. Once you set te return value of this callback as true, the SDK only triggers the OnPlaybackAudioFrameBeforeMixingEx and sends you the audio frames before mixing, and OnPlaybackAudioFrameBeforeMixing is not to be triggered. In a multi-channeel scenario, Agora recommends you setting the return value of this callback as true.
        /// If you set the return value of this callback as false, the SDK only triggers the OnPlaybackAudioFrameBeforeMixing callback and sends you the audio data received.
        /// </summary>
        ///
        /// <returns>
        /// true: Receive audio data from multiple channels.
        /// false: Do not receive audio data from multiple channels.
        /// </returns>
        ///
        public virtual bool IsMultipleChannelFrameWanted()
        { 
            return true; 
        }

        public virtual bool OnPlaybackAudioFrameBeforeMixingEx(string channelId,
                                                        uint uid,
                                                        AudioFrame audioFrame)
        {
            return false;
        }
    }
}