using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class AudioSpectrumObserverNative
    {
        internal static IAudioSpectrumObserver AgoraRtcAudioSpectrumObserver;
        internal static Dictionary<int, IAudioSpectrumObserver> AgoraRtcAudioSpectrumObserverDic = new Dictionary<int, IAudioSpectrumObserver>();

        private static AudioSpectrumData ProcessAudioSpectrumData(IntPtr bufferPtr, int length)
        {
            AudioSpectrumData spectrumData = new AudioSpectrumData();
            spectrumData.dataLength = length;

            spectrumData.audioSpectrumData = new float[length];
            if (bufferPtr != IntPtr.Zero)
            {
                Marshal.Copy(bufferPtr, spectrumData.audioSpectrumData, 0, length);
            }
            return spectrumData;
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_LocalAudioSpectrum_Native))]
#endif
        internal static bool OnLocalAudioSpectrum(IntPtr data)
        {
            if (AgoraRtcAudioSpectrumObserver == null) return false;

            var irisAudioSpectrumData = (IrisAudioSpectrumData)Marshal.PtrToStructure(data, typeof(IrisAudioSpectrumData));

            return AgoraRtcAudioSpectrumObserver.OnLocalAudioSpectrum(ProcessAudioSpectrumData(irisAudioSpectrumData.audioSpectrumData, irisAudioSpectrumData.dataLength));
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
                var dataspectrum = (IrisUserAudioSpectrumInfo)Marshal.PtrToStructure(p, typeof(IrisUserAudioSpectrumInfo));
                SpectrumInfos[i].uid = dataspectrum.uid;
                SpectrumInfos[i].spectrumData = ProcessAudioSpectrumData(dataspectrum.spectrumData.audioSpectrumData, dataspectrum.spectrumData.dataLength);
            }

            return AgoraRtcAudioSpectrumObserver.OnRemoteAudioSpectrum(SpectrumInfos, spectrumNumber);
        }
    }
}
