﻿using System;
using Agora.Rtc;
namespace Agora.Rtc
{
    public class UTAudioSpectrumObserver : IAudioSpectrumObserver
    {

        public string TAG;

        public bool OnLocalAudioSpectrum_be_trigger = false;
        public AudioSpectrumData OnLocalAudioSpectrum_data = null;

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

            if (ParamsHelper.compareAudioSpectrumData(OnLocalAudioSpectrum_data, data) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnRemoteAudioSpectrum_be_trigger = false;
        public UserAudioSpectrumInfo[] OnRemoteAudioSpectrum_spectrums = null;
        public uint OnRemoteAudioSpectrum_spectrumNumber = 0;

        public override bool OnRemoteAudioSpectrum(UserAudioSpectrumInfo[] spectrums, uint spectrumNumber)
        {
            OnRemoteAudioSpectrum_be_trigger = true;
            OnRemoteAudioSpectrum_spectrums = spectrums;
            OnRemoteAudioSpectrum_spectrumNumber = spectrumNumber;
            return true;
        }

        public bool OnRemoteAudioSpectrumPassed(UserAudioSpectrumInfo[]  spectrums, uint spectrumNumber)
    {
        if (OnRemoteAudioSpectrum_be_trigger == false)
            return false;

        if (ParamsHelper.compareUserAudioSpectrumInfoArray(OnRemoteAudioSpectrum_spectrums, spectrums) == false)
            return false;
        if (ParamsHelper.compareUint(OnRemoteAudioSpectrum_spectrumNumber, spectrumNumber) == false)
            return false;

        return true;
    }

    ///////////////////////////////////

}
}
