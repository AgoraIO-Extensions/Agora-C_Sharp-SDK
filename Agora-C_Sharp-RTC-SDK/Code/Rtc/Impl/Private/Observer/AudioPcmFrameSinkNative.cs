using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS 
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class AudioPcmFrameSinkNative
    {
        private static Object observerLock = new Object();
        private static Dictionary<int, IAudioPcmFrameSink> mediaPlayerAudioFrameObserverDic = new Dictionary<int, IAudioPcmFrameSink>();

        internal static void AddAudioFrameObserver(int playerId, IAudioPcmFrameSink observer)
        {
            lock (observerLock)
            {
                if (mediaPlayerAudioFrameObserverDic.ContainsKey(playerId) == false)
                    mediaPlayerAudioFrameObserverDic.Add(playerId, observer);
            }
        }

        internal static void RemoveAudioFrameObserver(int playerId)
        {
            lock (observerLock)
            {
                if (mediaPlayerAudioFrameObserverDic.ContainsKey(playerId))
                    mediaPlayerAudioFrameObserverDic.Remove(playerId);
            }
        }


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        [MonoPInvokeCallback(typeof(Rtc_Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
            lock (observerLock)
            {
                IrisRtcCEventParam eventParam = (IrisRtcCEventParam)Marshal.PtrToStructure(param, typeof(IrisRtcCEventParam));

                var data = eventParam.data;

                LitJson.JsonData jsonData = AgoraJson.ToObject(data);
                int playerId = (int)AgoraJson.GetData<int>(jsonData, "playerId");
                if (mediaPlayerAudioFrameObserverDic.ContainsKey(playerId) == false)
                {
                    CreateDefaultReturn(ref eventParam, param);
                    return;
                }

                var audioFrameObserver = mediaPlayerAudioFrameObserverDic[playerId];
                var @event = eventParam.@event;
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

                switch (@event)
                {
                    case AgoraEventType.EVENT_AUDIOPCMFRAMESINK_ONFRAME:
                        {
                            AudioPcmFrame frame = AgoraJson.JsonToStruct<AudioPcmFrame>(jsonData, "frame");
                            IntPtr data_ = bufferArray[0];
                            int dataLength = lengthArray[0];
                            frame.data_ = new Int16[dataLength];
                            Marshal.Copy(data_, frame.data_, 0, dataLength);
                            audioFrameObserver.OnFrame(frame);
                        }
                        break;
                    default:
                        AgoraLog.LogError("unexpected event: " + @event);
                        break;
                }
            }
        }


        private static void CreateDefaultReturn(ref IrisRtcCEventParam eventParam, IntPtr param)
        {
            var @event = eventParam.@event;
            switch (@event)
            {
                case AgoraEventType.EVENT_AUDIOPCMFRAMESINK_ONFRAME:
                    break;
                default:
                    AgoraLog.LogError("unexpected event: " + @event);
                    break;
            }
        }
    }
}