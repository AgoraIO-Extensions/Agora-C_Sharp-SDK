namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The audio spectrum observer.
    /// </summary>
    ///
    public abstract class IAudioSpectrumObserverS : IAudioSpectrumObserverBase
    {
        #region terra IAudioSpectrumObserverS
        public virtual bool OnRemoteAudioSpectrum(UserAudioSpectrumInfoS[] spectrumsS, uint spectrumNumber)
        {
            return true;
        }
        #endregion terra IAudioSpectrumObserverS
    }
}