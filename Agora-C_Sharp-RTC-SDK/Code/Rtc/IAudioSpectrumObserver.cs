﻿namespace Agora.Rtc
{
    /* class_iaudiospectrumobserver */
    public abstract class IAudioSpectrumObserver
    {
        public virtual bool OnLocalAudioSpectrum(AudioSpectrumData data)
        {
            return true;
        }

        public virtual bool OnRemoteAudioSpectrum(UserAudioSpectrumInfo[] spectrums, uint spectrumNumber)
        {
            return true;
        }
    }
}