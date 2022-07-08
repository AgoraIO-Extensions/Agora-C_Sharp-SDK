namespace Agora.Rtc
{
    public abstract class IMediaPlayerAudioFrameObserver
    {
        ///
        /// <summary>
        /// Occurs each time the player receives an audio frame.
        /// After registering the audio frame observer, the callback occurs every time the player receives an audio frame, reporting the detailed information of the audio frame.
        /// </summary>
        ///
        /// <param name="audioFrame"> Audio frame information.See </param>
        ///
        public virtual bool OnFrame(AudioPcmFrame audioFrame)
        {
            return true;
        }
    }
}