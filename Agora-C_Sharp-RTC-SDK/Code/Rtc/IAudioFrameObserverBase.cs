namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The audio frame observer.
    /// </summary>
    ///
    public abstract class IAudioFrameObserverBase
    {

        #region terra IAudioFrameObserverBase


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


        #endregion terra IAudioFrameObserverBase
    }

}