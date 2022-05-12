using System;

namespace agora.rtc
{
    internal static class AgoraRtcMediaPlayerAudioSpectrumObserverNative
    {
        internal static IAgoraRtcMediaPlayerAudioSpectrumObserver AudioSpectrumObserver;

#if __UNITY__
        [MonoPInvokeCallback(typeof(Func_LocalAudioSpectrum_Native))]
#endif
        internal static bool OnLocalAudioSpectrum(AudioSpectrumData data)
        {
            return AudioSpectrumObserver == null ? false : 
                AudioSpectrumObserver.OnLocalAudioSpectrum(data);
        }

#if __UNITY__
        [MonoPInvokeCallback(typeof(Func_RemoteAudioSpectrum_Native))]
#endif
        internal static bool OnRemoteAudioSpectrum(UserAudioSpectrumInfo[] spectrums, uint spectrumNumber)
        {
            return AudioSpectrumObserver == null ? false :
                AudioSpectrumObserver.OnRemoteAudioSpectrum(spectrums, spectrumNumber);
        }
    }
}