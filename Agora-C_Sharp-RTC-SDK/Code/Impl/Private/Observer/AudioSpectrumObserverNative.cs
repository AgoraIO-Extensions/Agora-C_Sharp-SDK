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
        internal static IAudioSpectrumObserver AgoraRtcAudioSpectrumObserver = null;
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
        internal static bool OnLocalAudioSpectrum(int playerId, IntPtr data)
        {
            if (!AgoraRtcAudioSpectrumObserverDic.ContainsKey(playerId) && AgoraRtcAudioSpectrumObserver == null) return false;
            var irisAudioSpectrumData = (IrisAudioSpectrumData)Marshal.PtrToStructure(data, typeof(IrisAudioSpectrumData));

            if (playerId == 0)
            {
                return AgoraRtcAudioSpectrumObserver.OnLocalAudioSpectrum(ProcessAudioSpectrumData(irisAudioSpectrumData.audioSpectrumData, irisAudioSpectrumData.dataLength));
            }

            return AgoraRtcAudioSpectrumObserverDic[playerId].OnLocalAudioSpectrum(ProcessAudioSpectrumData(irisAudioSpectrumData.audioSpectrumData, irisAudioSpectrumData.dataLength));
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_RemoteAudioSpectrum_Native))]
#endif
        internal static bool OnRemoteAudioSpectrum(int playerId, IntPtr dataspectrums, uint spectrumNumber)
        {
            if (!AgoraRtcAudioSpectrumObserverDic.ContainsKey(playerId) && AgoraRtcAudioSpectrumObserver == null) return false;

            UserAudioSpectrumInfo[] SpectrumInfos = new UserAudioSpectrumInfo[spectrumNumber];
            for (int i = 0; i < spectrumNumber; i++)
            {
                IntPtr p = new IntPtr(dataspectrums.ToInt64() + Marshal.SizeOf(typeof(IrisUserAudioSpectrumInfo)) * i);
                var dataspectrum = (IrisUserAudioSpectrumInfo)Marshal.PtrToStructure(p, typeof(IrisUserAudioSpectrumInfo));
                SpectrumInfos[i].uid = dataspectrum.uid;
                SpectrumInfos[i].spectrumData = ProcessAudioSpectrumData(dataspectrum.spectrumData.audioSpectrumData, dataspectrum.spectrumData.dataLength);
            }

            if (playerId == 0)
            {
                return AgoraRtcAudioSpectrumObserver.OnRemoteAudioSpectrum(SpectrumInfos, spectrumNumber);
            }

            return AgoraRtcAudioSpectrumObserverDic[playerId].OnRemoteAudioSpectrum(SpectrumInfos, spectrumNumber);
        }
    }
}
