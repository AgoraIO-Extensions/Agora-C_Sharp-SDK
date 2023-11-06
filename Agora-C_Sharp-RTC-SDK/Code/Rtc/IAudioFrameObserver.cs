namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The audio frame observer.
    /// </summary>
    ///
    public abstract class IAudioFrameObserver : IAudioFrameObserverBase
    {

        #region terra IAudioFrameObserver
        public virtual bool OnPlaybackAudioFrameBeforeMixing(string channelId, uint uid, AudioFrame audioFrame)
        {
            return true;
        }
        #endregion terra IAudioFrameObserver
    }

}