namespace Agora.Rtc
{
    public abstract class IMediaPlayerAudioFrameObserver
    {
        public virtual bool OnFrame(AudioPcmFrame videoFrame)
        {
            return true;
        }
    }
}