namespace Agora.Rtc
{
    /* class_iaudiospectrumobserver */
    public abstract class IAudioSpectrumObserver
    {
        /* callback_iaudiospectrumobserver_onlocalaudiospectrum */
        public virtual bool OnLocalAudioSpectrum(AudioSpectrumData data)
        {
            return true;
        }

        /* callback_iaudiospectrumobserver_onremoteaudiospectrum */
        public virtual bool OnRemoteAudioSpectrum(UserAudioSpectrumInfo[] spectrums, uint spectrumNumber)
        {
            return true;
        }
    }
}