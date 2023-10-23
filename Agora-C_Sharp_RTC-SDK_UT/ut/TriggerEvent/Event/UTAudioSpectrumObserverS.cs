using System;
using Agora.Rtc;
namespace Agora.Rtc
{
    public class UTAudioSpectrumObserverS : IAudioSpectrumObserverS
    {
        public string TAG;

        #region terra IAudioSpectrumObserverS

        public bool OnLocalAudioSpectrum_be_trigger = false;
        public AudioSpectrumData OnLocalAudioSpectrum_data;

        public override bool OnLocalAudioSpectrum(AudioSpectrumData data)
        {
            OnLocalAudioSpectrum_be_trigger = true;
            OnLocalAudioSpectrum_data = data;
            return true;

        }

        public bool OnLocalAudioSpectrumPassed(AudioSpectrumData data)
        {

            if (OnLocalAudioSpectrum_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<AudioSpectrumData>(OnLocalAudioSpectrum_data, data) == false)
                return false;

            return true;
        }

        /////////////////////////////////
        public bool OnRemoteAudioSpectrum_be_trigger = false;
        public UserAudioSpectrumInfoS[] OnRemoteAudioSpectrum_spectrumsS;
        public uint OnRemoteAudioSpectrum_spectrumNumber;

        public override bool OnRemoteAudioSpectrum(UserAudioSpectrumInfoS[] spectrumsS, uint spectrumNumber)
        {
            OnRemoteAudioSpectrum_be_trigger = true;
            OnRemoteAudioSpectrum_spectrumsS = spectrumsS;
            OnRemoteAudioSpectrum_spectrumNumber = spectrumNumber;
            return true;

        }

        public bool OnRemoteAudioSpectrumPassed(UserAudioSpectrumInfoS[] spectrumsS, uint spectrumNumber)
        {

            if (OnRemoteAudioSpectrum_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<UserAudioSpectrumInfoS[]>(OnRemoteAudioSpectrum_spectrumsS, spectrumsS) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnRemoteAudioSpectrum_spectrumNumber, spectrumNumber) == false)
                return false;

            return true;
        }

        /////////////////////////////////
        #endregion terra IAudioSpectrumObserverS
    }
}
