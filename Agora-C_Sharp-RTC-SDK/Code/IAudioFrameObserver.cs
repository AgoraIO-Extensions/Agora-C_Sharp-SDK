namespace Agora.Rtc
{
    public class IAudioFrameObserver
    {
        public virtual bool OnRecordAudioFrame(string channelId, AudioFrame audioFrame)
        {
            return true;
        }

        public virtual bool OnPlaybackAudioFrame(string channelId, AudioFrame audioFrame)
        {
            return true;
        }

        public virtual bool OnMixedAudioFrame(string channelId, AudioFrame audioFrame)
        {
            return true;
        }

        public virtual bool OnPlaybackAudioFrameBeforeMixing(string channelId,
                                                        uint uid,
                                                        AudioFrame audioFrame)
        {
            return false;
        }

        public virtual bool OnEarMonitoringAudioFrame(AudioFrame audioFrame)
        {
            return true;
        }

        public virtual bool IsMultipleChannelFrameWanted()
        {
           return true;
        }
    }


}