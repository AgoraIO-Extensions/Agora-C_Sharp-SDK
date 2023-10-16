#define AGORA_STRING_UID
#define AGORA_NUMBER_UID

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
using AOT;
#endif

namespace Agora.Rtc
{
    internal static class AudioFrameObserverNative
    {
        private static Object observerLock = new Object();
        private static OBSERVER_MODE mode = OBSERVER_MODE.INTPTR;
        private static IAudioFrameObserverBase audioFrameObserver;

        internal static void SetAudioFrameObserverAndMode(IAudioFrameObserverBase observer, OBSERVER_MODE md)
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

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
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
                    case "AudioFrameObserverBase_onRecordAudioFrame":
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
                    case "AudioFrameObserverBase_onPlaybackAudioFrame":
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
                    case "AudioFrameObserverBase_onMixedAudioFrame":
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
                    case "AudioFrameObserverBase_onEarMonitoringAudioFrame":
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
                    case "AudioFrameObserverBase_onPlaybackAudioFrameBeforeMixing":
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
#if  AGORA_NUMBER_UID
                    case "AudioFrameObserver_onPlaybackAudioFrameBeforeMixing":
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
#endif

                    #region terra IAudioFrameObserverBase

                    #endregion terra IAudioFrameObserverBase

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
                case "AudioFrameObserverBase_onRecordAudioFrame":
                case "AudioFrameObserverBase_onPublishAudioFrame":
                case "AudioFrameObserverBase_onPlaybackAudioFrame":
                case "AudioFrameObserverBase_onMixedAudioFrame":
                case "AudioFrameObserverBase_onEarMonitoringAudioFrame":
                    {
                        bool result = true;
                        Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                        p.Add("result", result);
                        string json = AgoraJson.ToJson(p);
                        var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                        IntPtr resultPtr = eventParam.result;
                        Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                    }
                    break;
                case "AudioFrameObserverBase_onPlaybackAudioFrameBeforeMixing":
#if  AGORA_NUMBER_UID
                case "AudioFrameObserver_onPlaybackAudioFrameBeforeMixing":
#endif
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

                #region terra IAudioFrameObserverBase_CreateDefaultReturn

                #endregion terra IAudioFrameObserverBase_CreateDefaultReturn

                #region terra IAudioFrameObserver_CreateDefaultReturn

                #endregion terra IAudioFrameObserver_CreateDefaultReturn
                default:
                    AgoraLog.LogError("unexpected event: " + @event);
                    break;
            }
        }

        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        //        [MonoPInvokeCallback(typeof(Func_AudioFrameLocal_Native))]
        //#endif
        //        internal static bool OnRecordAudioFrame(string channelId, IntPtr audioFramePtr)
        //        {
        //            if (AudioFrameObserver == null)
        //                return true;

        //            var audioFrame = ProcessAudioFrameReceived(audioFramePtr, "", 0);

        //            try
        //            {
        //                return AudioFrameObserver.OnRecordAudioFrame(channelId, audioFrame);
        //            }
        //            catch (Exception e)
        //            {
        //                AgoraLog.LogError("[Exception] IAudioFrameObserver.OnRecordAudioFrame: " + e);
        //                return true;
        //            }
        //        }

        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        //        [MonoPInvokeCallback(typeof(Func_AudioFrameLocal_Native))]
        //#endif
        //        internal static bool OnPlaybackAudioFrame(string channelId, IntPtr audioFramePtr)
        //        {
        //            if (AudioFrameObserver == null)
        //                return true;

        //            var audioFrame = ProcessAudioFrameReceived(audioFramePtr, "", 1);

        //            try
        //            {
        //                return AudioFrameObserver.OnPlaybackAudioFrame(channelId, audioFrame);
        //            }
        //            catch (Exception e)
        //            {
        //                AgoraLog.LogError("[Exception] IAudioFrameObserver.OnPlaybackAudioFrame: " + e);
        //                return true;
        //            }
        //        }

        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        //        [MonoPInvokeCallback(typeof(Func_AudioFrameLocal_Native))]
        //#endif
        //        internal static bool OnMixedAudioFrame(string channelId, IntPtr audioFramePtr)
        //        {
        //            if (AudioFrameObserver == null)
        //                return true;

        //            var audioFrame = ProcessAudioFrameReceived(audioFramePtr, "", 2);

        //            try
        //            {
        //                return AudioFrameObserver.OnMixedAudioFrame(channelId, audioFrame);
        //            }
        //            catch (Exception e)
        //            {
        //                AgoraLog.LogError("[Exception] IAudioFrameObserver.OnMixedAudioFrame: " + e);
        //                return true;
        //            }
        //        }

        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        //        [MonoPInvokeCallback(typeof(Func_AudioFramePosition_Native))]
        //#endif
        //        internal static int GetObservedAudioFramePosition()
        //        {
        //            if (AudioFrameObserver == null)
        //                return (int)AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_NONE;

        //            try
        //            {
        //                return AudioFrameObserver.GetObservedAudioFramePosition();
        //            }
        //            catch (Exception e)
        //            {
        //                AgoraLog.LogError("[Exception] IAudioFrameObserver.GetObservedAudioFramePosition: " + e);
        //                return (int)AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_NONE;
        //            }
        //        }

        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        //        [MonoPInvokeCallback(typeof(Func_AudioParams_Native))]
        //#endif
        //        internal static IrisAudioParams GetPlaybackAudioParams()
        //        {
        //            if (AudioFrameObserver == null)
        //                return LocalAudioFrames.irisAudioParams;

        //            try
        //            {
        //                return ProcessAudioParams(AudioFrameObserver.GetPlaybackAudioParams());
        //            }
        //            catch (Exception e)
        //            {
        //                AgoraLog.LogError("[Exception] IAudioFrameObserver.GetPlaybackAudioParams: " + e);
        //                return LocalAudioFrames.irisAudioParams;
        //            }
        //        }

        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        //        [MonoPInvokeCallback(typeof(Func_AudioParams_Native))]
        //#endif
        //        internal static IrisAudioParams GetRecordAudioParams()
        //        {
        //            if (AudioFrameObserver == null)
        //                return LocalAudioFrames.irisAudioParams;

        //            try
        //            {
        //                return ProcessAudioParams(AudioFrameObserver.GetRecordAudioParams());
        //            }
        //            catch (Exception e)
        //            {
        //                AgoraLog.LogError("[Exception] IAudioFrameObserver.GetRecordAudioParams: " + e);
        //                return LocalAudioFrames.irisAudioParams;
        //            }
        //        }

        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        //        [MonoPInvokeCallback(typeof(Func_AudioParams_Native))]
        //#endif
        //        internal static IrisAudioParams GetMixedAudioParams()
        //        {
        //            if (AudioFrameObserver == null)
        //                return LocalAudioFrames.irisAudioParams;

        //            try
        //            {
        //                return ProcessAudioParams(AudioFrameObserver.GetMixedAudioParams());
        //            }
        //            catch (Exception e)
        //            {
        //                AgoraLog.LogError("[Exception] IAudioFrameObserver.GetMixedAudioParams: " + e);
        //                return LocalAudioFrames.irisAudioParams;
        //            }
        //        }

        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        //        [MonoPInvokeCallback(typeof(Func_AudioFrameRemote_Native))]
        //#endif
        //        internal static bool OnPlaybackAudioFrameBeforeMixing(string channelId, uint uid, IntPtr audioFramePtr)
        //        {
        //            if (AudioFrameObserver == null)
        //                return true;

        //            var audioFrame = ProcessAudioFrameReceived(audioFramePtr, channelId, uid);

        //            try
        //            {
        //                return AudioFrameObserver.OnPlaybackAudioFrameBeforeMixing(channelId, uid, audioFrame);
        //            }
        //            catch (Exception e)
        //            {
        //                AgoraLog.LogError("[Exception] IAudioFrameObserver.OnPlaybackAudioFrameBeforeMixing: " + e);
        //                return true;
        //            }
        //        }

        //#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        //        [MonoPInvokeCallback(typeof(Func_AudioFrameRemoteStringUid_Native))]
        //#endif
        //        internal static bool OnPlaybackAudioFrameBeforeMixing2(string channelId, string uid, IntPtr audioFramePtr)
        //        {
        //            if (AudioFrameObserver == null)
        //                return true;

        //            var audioFrame = ProcessAudioFrameReceived(audioFramePtr, channelId, uid);

        //            try
        //            {
        //                return AudioFrameObserver.OnPlaybackAudioFrameBeforeMixing(channelId, uid, audioFrame);
        //            }
        //            catch (Exception e)
        //            {
        //                AgoraLog.LogError("[Exception] IAudioFrameObserver.OnPlaybackAudioFrameBeforeMixing2: " + e);
        //                return true;
        //            }
        //        }
        //    }
    }
}