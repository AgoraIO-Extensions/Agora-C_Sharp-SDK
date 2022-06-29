namespace Agora.Rtc
{
    public class IMediaPlayerAudioFrameObserver
    {
        public virtual bool OnFrame(AudioPcmFrame videoFrame)
        {
            return true;
        }
    }
}