namespace agora.rtc
{
    public class IAudioFrameObserver
    {
        public virtual bool OnRecordAudioFrame(AudioFrame audioFrame)
        {
            return true;
        }

        public virtual bool OnPlaybackAudioFrame(AudioFrame audio_frame)
        {
            return true;
        }

        public virtual bool OnMixedAudioFrame(AudioFrame audio_frame)
        {
            return true;
        }

        public virtual bool OnPlaybackAudioFrameBeforeMixing(uint uid, AudioFrame audio_frame)
        {
            return true;
        }

        public virtual bool IsMultipleChannelFrameWanted()
        { 
            return true; 
        }

        public virtual bool OnPlaybackAudioFrameBeforeMixingEx(string channel_id,
                                                        uint uid,
                                                        AudioFrame audio_frame)
        {
            return false;
        }
    }
}