namespace agora.rtc
{
    public class IMediaPlayerAudioFrameObserver
    {
        public virtual bool OnFrame(AudioPcmFrame videoFrame, int mediaPlayerId)
        {
            return true;
        }
    }
}