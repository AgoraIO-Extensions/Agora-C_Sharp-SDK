namespace Agora.Rtc
{
    ///
    /// TODO(doc)
    ///
    public abstract class IMediaPlayerAudioFrameObserver
    {
        ///
        /// TODO(doc)
        ///
        public virtual bool OnFrame(AudioPcmFrame videoFrame)
        {
            return true;
        }
    }
}