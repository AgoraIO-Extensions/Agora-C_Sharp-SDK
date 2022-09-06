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

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
            if (AudioEncodedFrameObserver == null) return;

            IrisCEventParam eventParam = (IrisCEventParam)Marshal.PtrToStructure(param, typeof(IrisCEventParam));
            var @event = eventParam.@event;
            var data = eventParam.data;
            var buffer = eventParam.buffer;
            var length = eventParam.length;
            var buffer_count = eventParam.buffer_count;

            IntPtr[] bufferArray = null;
            int[] lengthArray = null;

            if (buffer_count > 0)
            {
                bufferArray = new IntPtr[buffer_count];
                Marshal.Copy(buffer, bufferArray, 0, (int)buffer_count);
                lengthArray = new int[buffer_count];
                Marshal.Copy(length, lengthArray, 0, (int)buffer_count);
            }

            EncodedAudioFrameInfo audioEncodedFrameInfo = AgoraJson.JsonToStruct<EncodedAudioFrameInfo>(data, "audioEncodedFrameInfo");

            switch (@event)
            {
                case "AuidoEncodedFrameObserver_OnRecordAudioEncodedFrame":
                    AudioEncodedFrameObserver.OnRecordAudioEncodedFrame(bufferArray[0], lengthArray[0], audioEncodedFrameInfo);
                    break;
                case "AuidoEncodedFrameObserver_OnPlaybackAudioEncodedFrame":
                    AudioEncodedFrameObserver.OnPlaybackAudioEncodedFrame(bufferArray[0], lengthArray[0], audioEncodedFrameInfo);
                    break;
                case "AuidoEncodedFrameObserver_OnMixedAudioEncodedFrame":
                    AudioEncodedFrameObserver.OnMixedAudioEncodedFrame(bufferArray[0], lengthArray[0], audioEncodedFrameInfo);
                    break;
                default:
                    AgoraLog.LogError("unexpected event name :" + @event);
                    break;
            }

        }


        //internal static EncodedAudioFrameInfo IrisEncodedAudioFrameInfo2EncodedAudioFrameInfo(ref IrisEncodedAudioFrameInfo from)
        //{
        //    EncodedAudioFrameInfo to = new EncodedAudioFrameInfo();
        //    to.codec = from.codec;
        //    to.sampleRateHz = from.sampleRateHz;
        //    to.samplesPerChannel = from.samplesPerChannel;
        //    to.numberOfChannels = from.numberOfChannels;
        //    to.advancedSettings = new EncodedAudioFrameAdvancedSettings();
        //    to.advancedSettings.speech = from.advancedSettings.speech;
        //    to.advancedSettings.sendEvenIfEmpty = from.advancedSettings.sendEvenIfEmpty;
        //    to.captureTimeMs = from.captureTimeMs;
        //    return to;
        //}


        //internal static void OnRecordAudioEncodedFrame(IntPtr frame_buffer, int length, EncodedAudioFrameInfo audioEncodedFrameInfo)
        //{
        //    if (AudioEncodedFrameObserver == null) return;

        //    try
        //    {
        //        AudioEncodedFrameObserver.OnRecordAudioEncodedFrame(frame_buffer, length, audioEncodedFrameInfo);
        //    }
        //    catch (Exception e)
        //    {
        //        AgoraLog.LogError("[Exception] IAudioEncodedFrameObserver.OnRecordAudioEncodedFrame: " + e);
        //    }
        //}


        //internal static void OnPlaybackAudioEncodedFrame(IntPtr frame_buffer, int length, EncodedAudioFrameInfo audioEncodedFrameInfo)
        //{
        //    if (AudioEncodedFrameObserver == null) return;



        //    try
        //    {
        //        AudioEncodedFrameObserver.OnPlaybackAudioEncodedFrame(frame_buffer, length, audioEncodedFrameInfo);
        //    }
        //    catch (Exception e)
        //    {
        //        AgoraLog.LogError("[Exception] IAudioEncodedFrameObserver.OnPlaybackAudioEncodedFrame: " + e);
        //    }
        //}


        //internal static void OnMixedAudioEncodedFrame(IntPtr frame_buffer, int length, EncodedAudioFrameInfo audioEncodedFrameInfo)
        //{
        //    if (AudioEncodedFrameObserver == null) return;


        //    try
        //    {
        //        AudioEncodedFrameObserver.OnMixedAudioEncodedFrame(frame_buffer, length, audioEncodedFrameInfo);
        //    }
        //    catch (Exception e)
        //    {
        //        AgoraLog.LogError("[Exception] IAudioEncodedFrameObserver.OnMixedAudioEncodedFrame: " + e);
        //    }
        //}
    }
}
