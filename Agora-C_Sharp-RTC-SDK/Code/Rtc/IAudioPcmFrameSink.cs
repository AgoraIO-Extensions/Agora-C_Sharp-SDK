namespace Agora.Rtc
{
    ///
    /// <summary>
    /// This class is used to get raw PCM audio. 
    /// You can inherit this class and implement the OnFrame callback to get raw PCM audio.
    /// </summary>
    ///
    public abstract class IAudioPcmFrameSink
    {
        ///
        /// <summary>
        /// Occurs each time the player receives an audio frame.
        /// After registering the audio frame observer, the callback occurs every time the player receives an audio frame, reporting the detailed information of the audio frame.
        /// </summary>
        ///
        /// <param name="frame"> Audio frame information. See AudioPcmFrame .</param>
        ///
        /// <returns>
        /// Reserved for future use.
        /// </returns>
        ///
        public virtual bool OnFrame(AudioPcmFrame frame)
        {
            return true;
        }
    }
}