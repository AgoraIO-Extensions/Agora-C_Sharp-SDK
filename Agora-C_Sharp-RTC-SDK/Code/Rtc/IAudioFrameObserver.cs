namespace Agora.Rtc
{
    /* class_iaudioframeobserver */
    public abstract class IAudioFrameObserver
    {

#region terra IAudioFrameObserver

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

        public virtual bool OnEarMonitoringAudioFrame(AudioFrame audioFrame)
        {
            return true;
        }

        public virtual bool OnPlaybackAudioFrameBeforeMixing(string channelId, string userId, AudioFrame audioFrame)
        {
            return true;
        }

        public virtual bool OnPlaybackAudioFrameBeforeMixing(string channelId, uint uid, AudioFrame audioFrame)
        {
            return true;
        }
#endregion terra IAudioFrameObserver
    }

}