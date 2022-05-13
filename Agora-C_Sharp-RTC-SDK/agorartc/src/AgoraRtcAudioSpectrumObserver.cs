using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace agora.rtc
{
    internal static class AgoraRtcAudioSpectrumObserverNative
    {
        internal static IAgoraRtcAudioSpectrumObserver AgoraRtcAudioSpectrumObserver;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_LocalAudioSpectrum_Native))]
#endif
        internal static bool OnLocalAudioSpectrum(IntPtr data)
        {
            if (AgoraRtcAudioSpectrumObserver == null) return false;

            var AudioSpectrumData = Marshal.PtrToStructure<IrisAudioSpectrumData>(data);
            AudioSpectrumData spectrumData = new AudioSpectrumData();
            spectrumData.audioSpectrumData = AudioSpectrumData.audioSpectrumData;
            spectrumData.dataLength = AudioSpectrumData.dataLength;

            return AgoraRtcAudioSpectrumObserver.OnLocalAudioSpectrum(spectrumData);
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_RemoteAudioSpectrum_Native))]
#endif
        internal static bool OnRemoteAudioSpectrum(IntPtr dataspectrums, uint spectrumNumber)
        {
            if (AgoraRtcAudioSpectrumObserver == null) return false;

            UserAudioSpectrumInfo[] SpectrumInfos = new UserAudioSpectrumInfo[spectrumNumber];
            for (int i = 0; i < spectrumNumber; i++)
            {
                IntPtr p = new IntPtr(dataspectrums.ToInt64() + Marshal.SizeOf(typeof(IrisUserAudioSpectrumInfo)) * i);
                var dataspectrum = (UserAudioSpectrumInfo)Marshal.PtrToStructure(p, typeof(IrisUserAudioSpectrumInfo));
                SpectrumInfos[i].uid = dataspectrum.uid;
                SpectrumInfos[i].spectrumData = dataspectrum.spectrumData;
            }

            return AgoraRtcAudioSpectrumObserver.OnRemoteAudioSpectrum(SpectrumInfos, spectrumNumber);
        }
    }
}
