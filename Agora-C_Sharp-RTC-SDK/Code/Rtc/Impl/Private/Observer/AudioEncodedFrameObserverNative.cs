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
        [MonoPInvokeCallback(typeof(Rtc_Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
            lock (observerLock)
            {

                if (audioEncodedFrameObserver == null) return;

                IrisRtcCEventParam eventParam = (IrisRtcCEventParam)Marshal.PtrToStructure(param, typeof(IrisRtcCEventParam));
                var @event = eventParam.@event;
                var data = eventParam.data;

                EncodedAudioFrameInfo audioEncodedFrameInfo = AgoraJson.JsonToStruct<EncodedAudioFrameInfo>(data, "audioEncodedFrameInfo");
                IntPtr frameBuffer = (IntPtr)(UInt64)AgoraJson.GetData<UInt64>(data, "frameBuffer");
                int frameLength = (int)AgoraJson.GetData<int>(data, "length");
                switch (@event)
                {
                    case "AudioEncodedFrameObserver_onRecordAudioEncodedFrame":
                        audioEncodedFrameObserver.OnRecordAudioEncodedFrame(frameBuffer, frameLength, audioEncodedFrameInfo);
                        break;
                    case "AudioEncodedFrameObserver_onPlaybackAudioEncodedFrame":
                        audioEncodedFrameObserver.OnPlaybackAudioEncodedFrame(frameBuffer, frameLength, audioEncodedFrameInfo);
                        break;
                    case "AudioEncodedFrameObserver_onMixedAudioEncodedFrame":
                        audioEncodedFrameObserver.OnMixedAudioEncodedFrame(frameBuffer, frameLength, audioEncodedFrameInfo);
                        break;
                    default:
                        AgoraLog.LogError("unexpected event name :" + @event);
                        break;
                }

            }
        }
    }
}
