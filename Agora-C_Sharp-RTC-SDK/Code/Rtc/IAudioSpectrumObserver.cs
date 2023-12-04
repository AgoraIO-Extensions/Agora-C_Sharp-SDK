namespace Agora.Rtc
{
    ///
    /// <summary>
    /// The audio spectrum observer.
    /// </summary>
    ///
    public abstract class IAudioSpectrumObserver
    {
        #region terra IAudioSpectrumObserver
        public virtual bool OnLocalAudioSpectrum(AudioSpectrumData data)
        {
            return true;
        }

        public virtual bool OnRemoteAudioSpectrum(UserAudioSpectrumInfo[] spectrums, uint spectrumNumber)
        {
            return true;
        }
        #endregion terra IAudioSpectrumObserver
    }
}