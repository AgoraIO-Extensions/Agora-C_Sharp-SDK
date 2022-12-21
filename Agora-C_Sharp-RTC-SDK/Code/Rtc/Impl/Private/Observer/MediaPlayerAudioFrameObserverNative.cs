using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class MediaPlayerAudioFrameObserverNative
    {
        private static Object observerLock = new Object();
        private static Dictionary<int, IMediaPlayerAudioFrameObserver> mediaPlayerAudioFrameObserverDic = new Dictionary<int, IMediaPlayerAudioFrameObserver>();

        internal static void AddAudioFrameObserver(int playerId, IMediaPlayerAudioFrameObserver observer)
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


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
            lock (observerLock)
            {
                IrisCEventParam eventParam = (IrisCEventParam)Marshal.PtrToStructure(param, typeof(IrisCEventParam));

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
                    case "MediaPlayerAudioFrameObserver_onFrame":
                        {
                            AudioPcmFrame frame = AgoraJson.JsonToStruct<AudioPcmFrame>(jsonData, "frame");
                            IntPtr data_ = bufferArray[0];
                            int dataLength = lengthArray[0];
                            frame.data_ = new Int16[dataLength];
                            Marshal.Copy(data_, frame.data_, 0, dataLength);
                            var result = audioFrameObserver.OnFrame(frame);
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    default:
                        AgoraLog.LogError("unexpected event: " + @event);
                        break;
                }
            }
        }


        private static void CreateDefaultReturn(ref IrisCEventParam eventParam, IntPtr param)
        {
            var @event = eventParam.@event;
            switch (@event)
            {
                case "MediaPlayerAudioFrameObserver_onFrame":
                    {
                        var result = true;
                        Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                        p.Add("result", result);
                        string json = AgoraJson.ToJson(p);
                        var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                        IntPtr resultPtr = eventParam.result;
                        Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                    }
                    break;
                default:
                    AgoraLog.LogError("unexpected event: " + @event);
                    break;
            }
        }

        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        //            [MonoPInvokeCallback(typeof(Func_AudioOnFrame_Native))]
        //#endif
        //        internal static bool OnFrame(IntPtr audioFramePtr, int mediaPlayerId)
        //        {
        //            var audioPcmFrame = (IrisAudioPcmFrame) (Marshal.PtrToStructure(audioFramePtr, typeof(IrisAudioPcmFrame)) ??
        //                                                    new IrisAudioPcmFrame());
        //            var localAudioPcmFrame = new AudioPcmFrame();

        //            // todo optimize
        //            localAudioPcmFrame = LocalAudioPcmFrames.AudioPcmFrame;
        //            localAudioPcmFrame.data_ = new Int16[3840];
        //            localAudioPcmFrame.data_ = audioPcmFrame.data_;
        //            localAudioPcmFrame.num_channels_ = audioPcmFrame.num_channels_;
        //            localAudioPcmFrame.capture_timestamp = audioPcmFrame.capture_timestamp;
        //            localAudioPcmFrame.sample_rate_hz_ = audioPcmFrame.sample_rate_hz_;
        //            localAudioPcmFrame.samples_per_channel_ = audioPcmFrame.samples_per_channel_;

        //            try
        //            {
        //                return AudioFrameObserverDic.ContainsKey(mediaPlayerId) ||
        //                AudioFrameObserverDic[mediaPlayerId].OnFrame(localAudioPcmFrame);
        //            }
        //            catch (Exception e)
        //            {
        //                AgoraLog.LogError("[Exception] IMediaPlayerAudioFrameObserver.OnFrame: " + e);
        //                return true;
        //            }
        //        }
    }
}