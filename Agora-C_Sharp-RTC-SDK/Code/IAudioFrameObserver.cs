namespace Agora.Rtc
{
    public class IAudioFrameObserver
    {
        public virtual bool OnRecordAudioFrame(string channelId ,AudioFrame audioFrame)
        {
            return true;
        }

        public virtual bool OnPlaybackAudioFrame(string channelId, AudioFrame audio_frame)
        {
            return true;
        }

        public virtual bool OnMixedAudioFrame(string channelId, AudioFrame audio_frame)
        {
            return true;
        }

     
        public virtual int GetObservedAudioFramePosition()
        {
            return (int)AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_NONE; 
        }

        public virtual AudioParams GetPlaybackAudioParams()
        {
            return new AudioParams();
        }

        public virtual AudioParams GetRecordAudioParams()
        {
            return new AudioParams();
        }

        public virtual AudioParams GetMixedAudioParams()
        {
            return new AudioParams();
        }

     
        public virtual bool OnPlaybackAudioFrameBeforeMixing(string channel_id,
                                                        uint uid,
                                                        AudioFrame audio_frame)
        {
            return false;
        }

        public virtual bool OnPlaybackAudioFrameBeforeMixing(string channel_id,
                                                        string uid,
                                                        AudioFrame audio_frame)
        {
            return false;
        }
    }


}