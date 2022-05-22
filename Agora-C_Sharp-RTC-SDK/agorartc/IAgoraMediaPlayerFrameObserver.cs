namespace agora.rtc
{
    public class IAgoraMediaPlayerAudioFrameObserver
    {
        public virtual bool OnFrame(AudioPcmFrame videoFrame, int mediaPlayerId)
        {
            return true;
        }
    }
}