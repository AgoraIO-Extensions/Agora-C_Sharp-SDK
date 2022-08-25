namespace Agora.Rtc
{
    public class IAudioFrameObserver
    {
        public virtual bool OnRecordAudioFrame(string channelId ,AudioFrame audioFrame)
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

        public virtual bool OnPlaybackAudioFrameBeforeMixing(string channelId, uint uid, AudioFrame audioFrame)
        {
            return false;
        }

        public virtual bool OnPlaybackAudioFrameBeforeMixing(string channelId, string uid, AudioFrame audioFrame)
        {
            return false;
        }
    }
}