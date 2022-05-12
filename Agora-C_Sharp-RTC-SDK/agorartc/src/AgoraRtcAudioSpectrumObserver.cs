
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
#define __UNITY__
#endif

using System;
using System.Runtime.InteropServices;

namespace agora.rtc
{
    public class AgoraRtcAudioSpectrumObserverNative
    {
        public static IAgoraRtcAudioSpectrumObserver AgoraRtcAudioSpectrumObserver;

        internal static AudioSpectrumData IrisAudioSpectrumData2AudioSpectrumData(ref IrisAudioSpectrumData from)
        {
            var to = new AudioSpectrumData();
            to.audioSpectrumData = new float[from.dataLength];
            Marshal.Copy(to.audioSpectrumData, 0, from.audioSpectrumData, from.dataLength);
            to.dataLength = from.dataLength;
            return to;
        }

        internal static UserAudioSpectrumInfo IrisUserAudioSpectrumInfo2UserAudioSpectrumInfo(ref IrisUserAudioSpectrumInfo from)
        {
            UserAudioSpectrumInfo to = new UserAudioSpectrumInfo();
            to.uid = from.uid;
            to.spectrumData = IrisAudioSpectrumData2AudioSpectrumData(ref from.spectrumData);
            return to;
        }

#if __UNITY__
        [MonoPInvokeCallback(typeof(Func_LocalAudioSpectrum_Native))]
#endif
        internal static bool onLocalAudioSpectrum(IntPtr data)
        {
            if (AgoraRtcAudioSpectrumObserver == null) return false;

            var from = Marshal.PtrToStructure<IrisAudioSpectrumData>(data);
            var to = IrisAudioSpectrumData2AudioSpectrumData(ref from);

            return AgoraRtcAudioSpectrumObserver.onLocalAudioSpectrum(to);
        }

#if __UNITY__
        [MonoPInvokeCallback(typeof(Func_RemoteAudioSpectrum_Native))]
#endif
        internal static bool onRemoteAudioSpectrum(IntPtr dataspectrums, uint spectrumNumber)
        {
            if (AgoraRtcAudioSpectrumObserver == null) return false;

            var from = Marshal.PtrToStructure<IrisUserAudioSpectrumInfo>(dataspectrums);
            var to = IrisUserAudioSpectrumInfo2UserAudioSpectrumInfo(ref from);

            return AgoraRtcAudioSpectrumObserver.onRemoteAudioSpectrum(to, spectrumNumber);
        }

    }
}
