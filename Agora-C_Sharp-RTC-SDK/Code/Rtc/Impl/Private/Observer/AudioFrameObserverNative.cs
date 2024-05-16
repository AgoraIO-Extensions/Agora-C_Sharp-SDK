using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class AudioFrameObserverNative
    {
        private static Object observerLock = new Object();
        private static OBSERVER_MODE mode = OBSERVER_MODE.INTPTR;
        private static IAudioFrameObserver audioFrameObserver;

        internal static void SetAudioFrameObserverAndMode(IAudioFrameObserver observer, OBSERVER_MODE md)
        {
            lock (observerLock)
            {
                audioFrameObserver = observer;
                mode = md;
            }
        }

        private static AudioFrame GetAudioFrameFromJsonData(ref LitJson.JsonData jsonData, string key, int bufferLength)
        {
            AudioFrame audioFrame = AgoraJson.JsonToStruct<AudioFrame>(jsonData, key);
            if (mode == OBSERVER_MODE.RAW_DATA && audioFrame.buffer != IntPtr.Zero)
            {
                audioFrame.RawBuffer = new byte[bufferLength];
                Marshal.Copy(audioFrame.buffer, audioFrame.RawBuffer, 0, bufferLength);
            }

            return audioFrame;
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        [MonoPInvokeCallback(typeof(Rtc_Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
            lock (observerLock)
            {
                IrisRtcCEventParam eventParam = (IrisRtcCEventParam)Marshal.PtrToStructure(param, typeof(IrisRtcCEventParam));

                if (audioFrameObserver == null)
                {
                    CreateDefaultReturn(ref eventParam, param);
                    return;
                }

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

                LitJson.JsonData jsonData = AgoraJson.ToObject(data);

                switch (@event)
                {
                    case AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_ONRECORDAUDIOFRAME:
                        {
                            AudioFrame audioFrame = GetAudioFrameFromJsonData(ref jsonData, "audioFrame", lengthArray != null ? lengthArray[0] : 0);
                            string channelId = (string)AgoraJson.GetData<string>(jsonData, "channelId");
                            bool result = audioFrameObserver.OnRecordAudioFrame(channelId, audioFrame);
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAME:
                        {
                            AudioFrame audioFrame = GetAudioFrameFromJsonData(ref jsonData, "audioFrame", lengthArray != null ? lengthArray[0] : 0);
                            string channelId = (string)AgoraJson.GetData<string>(jsonData, "channelId");
                            bool result = audioFrameObserver.OnPlaybackAudioFrame(channelId, audioFrame);
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_ONMIXEDAUDIOFRAME:
                        {
                            AudioFrame audioFrame = GetAudioFrameFromJsonData(ref jsonData, "audioFrame", lengthArray != null ? lengthArray[0] : 0);
                            string channelId = (string)AgoraJson.GetData<string>(jsonData, "channelId");
                            bool result = audioFrameObserver.OnMixedAudioFrame(channelId, audioFrame);
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_ONEARMONITORINGAUDIOFRAME:
                        {
                            AudioFrame audioFrame = GetAudioFrameFromJsonData(ref jsonData, "audioFrame", lengthArray != null ? lengthArray[0] : 0);
                            bool result = audioFrameObserver.OnEarMonitoringAudioFrame(audioFrame);
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAMEBEFOREMIXING:
                        {
                            AudioFrame audioFrame = GetAudioFrameFromJsonData(ref jsonData, "audioFrame", lengthArray != null ? lengthArray[0] : 0);
                            string channelId = (string)AgoraJson.GetData<string>(jsonData, "channelId");
                            string userId = (string)AgoraJson.GetData<string>(jsonData, "userId");
                            var result = audioFrameObserver.OnPlaybackAudioFrameBeforeMixing(channelId, userId, audioFrame);
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAMEBEFOREMIXING2:
                        {
                            AudioFrame audioFrame = GetAudioFrameFromJsonData(ref jsonData, "audioFrame", lengthArray != null ? lengthArray[0] : 0);
                            string channelId = (string)AgoraJson.GetData<string>(jsonData, "channelId");
                            uint uid = (uint)AgoraJson.GetData<uint>(jsonData, "uid");
                            var result = ((IAudioFrameObserver)audioFrameObserver).OnPlaybackAudioFrameBeforeMixing(channelId, uid, audioFrame);
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;

                    #region terra IAudioFrameObserver

                    #endregion terra IAudioFrameObserver

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
                case AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_ONRECORDAUDIOFRAME:
                case AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAME:
                case AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_ONMIXEDAUDIOFRAME:
                case AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_ONEARMONITORINGAUDIOFRAME:
                case AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAMEBEFOREMIXING:
                case AgoraEventType.EVENT_AUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAMEBEFOREMIXING2:
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

                #region terra IAudioFrameObserver_CreateDefaultReturn

                #endregion terra IAudioFrameObserver_CreateDefaultReturn
                default:
                    AgoraLog.LogError("unexpected event: " + @event);
                    break;
            }
        }
    }
}