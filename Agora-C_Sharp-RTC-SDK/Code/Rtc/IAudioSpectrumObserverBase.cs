namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The audio spectrum observer.
    /// </summary>
    ///
    public abstract class IAudioSpectrumObserverBase
    {

        #region terra IAudioSpectrumObserverBase

        public virtual bool OnLocalAudioSpectrum(AudioSpectrumData data)
        {
            return true;
        }
        #endregion terra IAudioSpectrumObserverBase
    }
}