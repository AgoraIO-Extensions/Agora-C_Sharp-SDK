namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The audio frame observer for the media player.
    /// </summary>
    ///
    public abstract class IMediaPlayerAudioFrameObserver
    {
        ///
        /// <summary>
        /// Occurs each time the player receives an audio frame.
        /// After registering the audio frame observer, the callback occurs every time the player receives an audio frame, reporting the detailed information of the audio frame.
        /// </summary>
        ///
        /// <param name="videoFrame"> Audio frame information. See AudioPcmFrame .</param>
        ///
        /// <returns>
        /// Reserved for future use.
        /// </returns>
        ///
        public virtual bool OnFrame(AudioPcmFrame videoFrame)
        {
            return true;
        }
    }
}