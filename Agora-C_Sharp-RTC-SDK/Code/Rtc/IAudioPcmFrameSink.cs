namespace Agora.Rtc
{
    public abstract class IAudioPcmFrameSink
    {
        public virtual void OnFrame(AudioPcmFrame frame)
        {
        }
    }
}