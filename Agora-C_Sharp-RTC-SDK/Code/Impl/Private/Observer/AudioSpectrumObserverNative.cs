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
            if (playerId == 0)
            {
                if (AgoraRtcAudioSpectrumObserver == null) return true;
                var irisAudioSpectrumData = (IrisAudioSpectrumData)Marshal.PtrToStructure(data, typeof(IrisAudioSpectrumData));
                return AgoraRtcAudioSpectrumObserver.OnLocalAudioSpectrum(ProcessAudioSpectrumData(irisAudioSpectrumData.audioSpectrumData, irisAudioSpectrumData.dataLength));
            }

            if (!AgoraRtcAudioSpectrumObserverDic.ContainsKey(playerId)) return false;
            var irisMediaPlayerAudioSpectrumData = (IrisAudioSpectrumData)Marshal.PtrToStructure(data, typeof(IrisAudioSpectrumData));
            return AgoraRtcAudioSpectrumObserverDic[playerId].OnLocalAudioSpectrum(ProcessAudioSpectrumData(irisMediaPlayerAudioSpectrumData.audioSpectrumData, irisMediaPlayerAudioSpectrumData.dataLength));
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_RemoteAudioSpectrum_Native))]
#endif
        internal static bool OnRemoteAudioSpectrum(int playerId, IntPtr dataspectrums, uint spectrumNumber)
        {
            if (playerId == 0)
            {
                if (AgoraRtcAudioSpectrumObserver == null) return true;
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

            if (!AgoraRtcAudioSpectrumObserverDic.ContainsKey(playerId)) return false;
            UserAudioSpectrumInfo[] MediaPlayerSpectrumInfos = new UserAudioSpectrumInfo[spectrumNumber];
            for (int i = 0; i < spectrumNumber; i++)
            {
                IntPtr p = new IntPtr(dataspectrums.ToInt64() + Marshal.SizeOf(typeof(IrisUserAudioSpectrumInfo)) * i);
                var dataspectrum = (IrisUserAudioSpectrumInfo)Marshal.PtrToStructure(p, typeof(IrisUserAudioSpectrumInfo));
                MediaPlayerSpectrumInfos[i].uid = dataspectrum.uid;
                MediaPlayerSpectrumInfos[i].spectrumData = ProcessAudioSpectrumData(dataspectrum.spectrumData.audioSpectrumData, dataspectrum.spectrumData.dataLength);
            }
            return AgoraRtcAudioSpectrumObserverDic[playerId].OnRemoteAudioSpectrum(MediaPlayerSpectrumInfos, spectrumNumber);
        }
    }
}
