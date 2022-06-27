namespace Agora.Rtc
{
    public abstract class IAudioFrameObserver
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

        public virtual bool OnPlaybackAudioFrameBeforeMixing(string channelId, uint uid, AudioFrame audioFrame)
        {
            return true;
        }

        public virtual bool IsMultipleChannelFrameWanted()
        { 
            return true; 
        }

        public virtual bool OnPlaybackAudioFrameBeforeMixingEx(string channelId,
                                                        uint uid,
                                                        AudioFrame audioFrame)
        {
            return false;
        }
    }
}