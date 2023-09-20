namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The audio frame observer.
    /// </summary>
    ///
    public abstract class IAudioFrameObserver
    {

#region terra IAudioFrameObserver

        ///
        /// @ignore
        ///
        public virtual bool OnRecordAudioFrame(string channelId, AudioFrame audioFrame)
        {
            return true;
        }

        ///
        /// @ignore
        ///
        public virtual bool OnPlaybackAudioFrame(string channelId, AudioFrame audioFrame)
        {
            return true;
        }

        ///
        /// @ignore
        ///
        public virtual bool OnMixedAudioFrame(string channelId, AudioFrame audioFrame)
        {
            return true;
        }

        ///
        /// @ignore
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
        /// <param name="channel_id"> The channel ID. </param>
        ///
        /// <param name="uid"> The user ID of the specified user. </param>
        ///
        /// <param name="audio_Frame"> The raw audio data. See AudioFrame. </param>
        ///
        /// <returns>
        /// Without practical meaning.
        /// </returns>
        ///
        public virtual bool OnPlaybackAudioFrameBeforeMixing(string channelId, string userId, AudioFrame audioFrame)
        {
            return true;
        }

        ///
        /// @ignore
        ///
        public virtual bool OnPlaybackAudioFrameBeforeMixing(string channelId, uint uid, AudioFrame audioFrame)
        {
            return true;
        }
#endregion terra IAudioFrameObserver
    }

}