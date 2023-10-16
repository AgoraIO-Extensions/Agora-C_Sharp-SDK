namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The audio spectrum observer.
    /// </summary>
    ///
    public abstract class IAudioSpectrumObserver : IAudioSpectrumObserverBase
    {
        #region terra IAudioSpectrumObserver


        public virtual bool OnRemoteAudioSpectrum(UserAudioSpectrumInfo[] spectrums, uint spectrumNumber)
        {
            return true;
        }
        #endregion terra IAudioSpectrumObserver
    }
}