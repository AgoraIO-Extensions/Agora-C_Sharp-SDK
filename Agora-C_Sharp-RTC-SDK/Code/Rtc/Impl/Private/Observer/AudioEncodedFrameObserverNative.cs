using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class AudioEncodedFrameObserverNative
    {
        private static Object observerLock = new Object();
        private static IAudioEncodedFrameObserver audioEncodedFrameObserver = null;

        internal static void SetAudioEncodedFrameObserver(IAudioEncodedFrameObserver observer)
        {
            lock (observerLock)
            {
                audioEncodedFrameObserver = observer;
            }
        }


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
            lock (observerLock)
            {

                if (audioEncodedFrameObserver == null) return;

                IrisCEventParam eventParam = (IrisCEventParam)Marshal.PtrToStructure(param, typeof(IrisCEventParam));
                var @event = eventParam.@event;
                var data = eventParam.data;
                var buffer = eventParam.buffer;
                var length = eventParam.length;
                var buffer_count = eventParam.buffer_count;

                EncodedAudioFrameInfo audioEncodedFrameInfo = AgoraJson.JsonToStruct<EncodedAudioFrameInfo>(data, "audioEncodedFrameInfo");
                IntPtr frameBuffer = (IntPtr)(UInt64)AgoraJson.GetData<UInt64>(data, "frameBuffer");
                int frameLength = (int)AgoraJson.GetData<int>(data, "length");
                switch (@event)
                {
                    case "AudioEncodedFrameObserver_OnRecordAudioEncodedFrame":
                        audioEncodedFrameObserver.OnRecordAudioEncodedFrame(frameBuffer, frameLength, audioEncodedFrameInfo);
                        break;
                    case "AudioEncodedFrameObserver_OnPlaybackAudioEncodedFrame":
                        audioEncodedFrameObserver.OnPlaybackAudioEncodedFrame(frameBuffer, frameLength, audioEncodedFrameInfo);
                        break;
                    case "AudioEncodedFrameObserver_OnMixedAudioEncodedFrame":
                        audioEncodedFrameObserver.OnMixedAudioEncodedFrame(frameBuffer, frameLength, audioEncodedFrameInfo);
                        break;
                    default:
                        AgoraLog.LogError("unexpected event name :" + @event);
                        break;
                }

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
