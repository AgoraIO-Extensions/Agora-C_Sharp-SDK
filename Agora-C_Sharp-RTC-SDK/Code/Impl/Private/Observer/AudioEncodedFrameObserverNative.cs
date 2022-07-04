using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class AudioEncodedFrameObserverNative
    {
        internal static IAudioEncodedFrameObserver AudioEncodedFrameObserver = null;

        internal static EncodedAudioFrameInfo IrisEncodedAudioFrameInfo2EncodedAudioFrameInfo(ref IrisEncodedAudioFrameInfo from)
        {
            EncodedAudioFrameInfo to = new EncodedAudioFrameInfo();
            to.codec = from.codec;
            to.sampleRateHz = from.sampleRateHz;
            to.samplesPerChannel = from.samplesPerChannel;
            to.numberOfChannels = from.numberOfChannels;
            to.advancedSettings = new EncodedAudioFrameAdvancedSettings();
            to.advancedSettings.speech = from.advancedSettings.speech;
            to.advancedSettings.sendEvenIfEmpty = from.advancedSettings.sendEvenIfEmpty;
            return to;
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_RecordAudioEncodedFrame_Native))]
#endif
        internal static void OnRecordAudioEncodedFrame(IntPtr frame_buffer, int length, IntPtr encoded_audio_frame_info)
        {
            if (AudioEncodedFrameObserver == null) return;

            IrisEncodedAudioFrameInfo from = (IrisEncodedAudioFrameInfo)Marshal.PtrToStructure(encoded_audio_frame_info, typeof(IrisEncodedAudioFrameInfo));
            EncodedAudioFrameInfo to = IrisEncodedAudioFrameInfo2EncodedAudioFrameInfo(ref from);

            AudioEncodedFrameObserver.OnRecordAudioEncodedFrame(frame_buffer, length, to);
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_RecordAudioEncodedFrame_Native))]
#endif
        internal static void OnPlaybackAudioEncodedFrame(IntPtr frame_buffer, int length, IntPtr encoded_audio_frame_info)
        {
            if (AudioEncodedFrameObserver == null) return;

            IrisEncodedAudioFrameInfo from = (IrisEncodedAudioFrameInfo)Marshal.PtrToStructure(encoded_audio_frame_info, typeof(IrisEncodedAudioFrameInfo));
            EncodedAudioFrameInfo to = IrisEncodedAudioFrameInfo2EncodedAudioFrameInfo(ref from);

            AudioEncodedFrameObserver.OnPlaybackAudioEncodedFrame(frame_buffer, length, to);
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_RecordAudioEncodedFrame_Native))]
#endif
        internal static void OnMixedAudioEncodedFrame(IntPtr frame_buffer, int length, IntPtr encoded_audio_frame_info)
        {
            if (AudioEncodedFrameObserver == null) return;

            IrisEncodedAudioFrameInfo from = (IrisEncodedAudioFrameInfo)Marshal.PtrToStructure(encoded_audio_frame_info, typeof(IrisEncodedAudioFrameInfo));
            EncodedAudioFrameInfo to = IrisEncodedAudioFrameInfo2EncodedAudioFrameInfo(ref from);

            AudioEncodedFrameObserver.OnMixedAudioEncodedFrame(frame_buffer, length, to);
        }
    }
}
