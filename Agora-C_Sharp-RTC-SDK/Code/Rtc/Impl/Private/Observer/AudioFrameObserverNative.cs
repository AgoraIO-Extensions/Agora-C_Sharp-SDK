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
        private static IAudioFrameObserver audioFrameObserver;

        internal static void SetAudioFrameObserverAndMode(IAudioFrameObserver observer, OBSERVER_MODE md)
        {
            lock (observerLock)
            {
                audioFrameObserver = observer;
                mode = md;
            }
        }

        //private static class LocalAudioFrames
        //{
        //    internal static AudioFrame RecordAudioFrame = new AudioFrame();
        //    internal static AudioFrame PlaybackAudioFrame = new AudioFrame();
        //    internal static AudioFrame MixedAudioFrame = new AudioFrame();
        //    internal static Dictionary<string, Dictionary<uint, AudioFrame>> AudioFrameBeforeMixingEx =
        //        new Dictionary<string, Dictionary<uint, AudioFrame>>();

        //    internal static Dictionary<string, Dictionary<string, AudioFrame>> AudioFrameBeforeMixingEx2 =
        //      new Dictionary<string, Dictionary<string, AudioFrame>>();

        //    internal static IrisAudioParams irisAudioParams = new IrisAudioParams();
        //}

        //private static AudioFrame ProcessAudioFrameReceived(IntPtr audioFramePtr, string channelId, uint uid)
        //{
        //    var audioFrame = (IrisAudioFrame)(Marshal.PtrToStructure(audioFramePtr, typeof(IrisAudioFrame)) ??
        //                                            new IrisAudioFrame());
        //    AudioFrame localAudioFrame = null;

        //    if (channelId == "")
        //    {
        //        switch (uid)
        //        {
        //            //Local Audio Frame
        //            case 0:
        //                localAudioFrame = LocalAudioFrames.RecordAudioFrame;
        //                break;
        //            case 1:
        //                localAudioFrame = LocalAudioFrames.PlaybackAudioFrame;
        //                break;
        //            case 2:
        //                localAudioFrame = LocalAudioFrames.MixedAudioFrame;
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        //Remote Audio Frame
        //        if (!LocalAudioFrames.AudioFrameBeforeMixingEx.ContainsKey(channelId))
        //        {
        //            LocalAudioFrames.AudioFrameBeforeMixingEx[channelId] = new Dictionary<uint, AudioFrame>();
        //            LocalAudioFrames.AudioFrameBeforeMixingEx[channelId][uid] = new AudioFrame();
        //        }
        //        else if (!LocalAudioFrames.AudioFrameBeforeMixingEx[channelId].ContainsKey(uid))
        //        {
        //            LocalAudioFrames.AudioFrameBeforeMixingEx[channelId][uid] = new AudioFrame();
        //        }

        //        localAudioFrame = LocalAudioFrames.AudioFrameBeforeMixingEx[channelId][uid];
        //    }

        //    if (mode == OBSERVER_MODE.RAW_DATA)
        //    {
        //        if (localAudioFrame.channels != audioFrame.channels ||
        //        localAudioFrame.samplesPerChannel != audioFrame.samples ||
        //        localAudioFrame.bytesPerSample != (BYTES_PER_SAMPLE)audioFrame.bytes_per_sample)
        //        {
        //            localAudioFrame.RawBuffer = new byte[audioFrame.buffer_length];
        //        }

        //        if (audioFrame.buffer != IntPtr.Zero)
        //            Marshal.Copy(audioFrame.buffer, localAudioFrame.RawBuffer, 0, (int)audioFrame.buffer_length);
        //    }

        //    localAudioFrame.type = audioFrame.type;
        //    localAudioFrame.samplesPerChannel = audioFrame.samples;
        //    localAudioFrame.bufferPtr = audioFrame.buffer;
        //    localAudioFrame.bytesPerSample = (BYTES_PER_SAMPLE)audioFrame.bytes_per_sample;
        //    localAudioFrame.channels = audioFrame.channels;
        //    localAudioFrame.samplesPerSec = audioFrame.samples_per_sec;
        //    localAudioFrame.renderTimeMs = audioFrame.render_time_ms;
        //    localAudioFrame.avsync_type = audioFrame.av_sync_type;

        //    return localAudioFrame;
        //}

        //private static AudioFrame ProcessAudioFrameReceived(IntPtr audioFramePtr, string channelId, string uid)
        //{
        //    var audioFrame = (IrisAudioFrame)(Marshal.PtrToStructure(audioFramePtr, typeof(IrisAudioFrame)) ??
        //                                            new IrisAudioFrame());
        //    AudioFrame localAudioFrame = null;

        //    //Remote Audio Frame
        //    if (!LocalAudioFrames.AudioFrameBeforeMixingEx2.ContainsKey(channelId))
        //    {
        //        LocalAudioFrames.AudioFrameBeforeMixingEx2[channelId] = new Dictionary<string, AudioFrame>();
        //        LocalAudioFrames.AudioFrameBeforeMixingEx2[channelId][uid] = new AudioFrame();
        //    }
        //    else if (!LocalAudioFrames.AudioFrameBeforeMixingEx2[channelId].ContainsKey(uid))
        //    {
        //        LocalAudioFrames.AudioFrameBeforeMixingEx2[channelId][uid] = new AudioFrame();
        //    }

        //    localAudioFrame = LocalAudioFrames.AudioFrameBeforeMixingEx2[channelId][uid];


        //    if (mode == OBSERVER_MODE.RAW_DATA)
        //    {
        //        if (localAudioFrame.channels != audioFrame.channels ||
        //        localAudioFrame.samplesPerChannel != audioFrame.samples ||
        //        localAudioFrame.bytesPerSample != (BYTES_PER_SAMPLE)audioFrame.bytes_per_sample)
        //        {
        //            localAudioFrame.RawBuffer = new byte[audioFrame.buffer_length];
        //        }

        //        if (audioFrame.buffer != IntPtr.Zero)
        //            Marshal.Copy(audioFrame.buffer, localAudioFrame.RawBuffer, 0, (int)audioFrame.buffer_length);
        //    }

        //    localAudioFrame.type = audioFrame.type;
        //    localAudioFrame.samplesPerChannel = audioFrame.samples;
        //    localAudioFrame.bufferPtr = audioFrame.buffer;
        //    localAudioFrame.bytesPerSample = (BYTES_PER_SAMPLE)audioFrame.bytes_per_sample;
        //    localAudioFrame.channels = audioFrame.channels;
        //    localAudioFrame.samplesPerSec = audioFrame.samples_per_sec;
        //    localAudioFrame.renderTimeMs = audioFrame.render_time_ms;
        //    localAudioFrame.avsync_type = audioFrame.av_sync_type;

        //    return localAudioFrame;
        //}

        //private static IrisAudioParams ProcessAudioParams(AudioParams audioParams)
        //{
        //    LocalAudioFrames.irisAudioParams.sample_rate = audioParams.sample_rate;
        //    LocalAudioFrames.irisAudioParams.channels = audioParams.channels;
        //    LocalAudioFrames.irisAudioParams.mode = (IRIS_RAW_AUDIO_FRAME_OP_MODE_TYPE)audioParams.mode;
        //    LocalAudioFrames.irisAudioParams.samples_per_call = audioParams.samples_per_call;
        //    return LocalAudioFrames.irisAudioParams;
        //}

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
        [MonoPInvokeCallback(typeof(Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
            lock (observerLock)
            {
                IrisCEventParam eventParam = (IrisCEventParam)Marshal.PtrToStructure(param, typeof(IrisCEventParam));

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
                    case "AudioFrameObserver_onRecordAudioFrame":
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
                    case "AudioFrameObserver_onPlaybackAudioFrame":
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
                    case "AudioFrameObserver_onMixedAudioFrame":
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
                    case "AudioFrameObserver_onEarMonitoringAudioFrame":
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
                    case "AudioFrameObserver_getObservedAudioFramePosition":
                        {
                            int result = audioFrameObserver.GetObservedAudioFramePosition();
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case "AudioFrameObserver_getPlaybackAudioParams":
                        {
                            var result = audioFrameObserver.GetPlaybackAudioParams();
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case "AudioFrameObserver_getRecordAudioParams":
                        {
                            var result = audioFrameObserver.GetRecordAudioParams();
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case "AudioFrameObserver_getMixedAudioParams":
                        {
                            var result = audioFrameObserver.GetMixedAudioParams();
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case "AudioFrameObserver_getEarMonitoringAudioParams":
                        {
                            var result = audioFrameObserver.GetEarMonitoringAudioParams();
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case "AudioFrameObserver_onPlaybackAudioFrameBeforeMixing":
                        {
                            AudioFrame audioFrame = GetAudioFrameFromJsonData(ref jsonData, "audioFrame", lengthArray != null ? lengthArray[0] : 0);
                            string channelId = (string)AgoraJson.GetData<string>(jsonData, "channelId");
                            uint uid = (uint)AgoraJson.GetData<uint>(jsonData, "uid");
                            var result = audioFrameObserver.OnPlaybackAudioFrameBeforeMixing(channelId, uid, audioFrame);
                            Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                            p.Add("result", result);
                            string json = AgoraJson.ToJson(p);
                            var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                            IntPtr resultPtr = eventParam.result;
                            Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                        }
                        break;
                    case "AudioFrameObserver_onPlaybackAudioFrameBeforeMixing2":
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
                case "AudioFrameObserver_onRecordAudioFrame":
                case "AudioFrameObserver_onPlaybackAudioFrame":
                case "AudioFrameObserver_onMixedAudioFrame":
                case "AudioFrameObserver_onEarMonitoringAudioFrame":
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
                case "AudioFrameObserver_getObservedAudioFramePosition":
                    {
                        int result = (int)(AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_PLAYBACK
                                          | AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_RECORD
                                          | AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_MIXED
                                          | AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_BEFORE_MIXING);
                        Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                        p.Add("result", result);
                        string json = AgoraJson.ToJson(p);
                        var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                        IntPtr resultPtr = eventParam.result;
                        Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                    }
                    break;
                case "AudioFrameObserver_getPlaybackAudioParams":
                case "AudioFrameObserver_getRecordAudioParams":
                case "AudioFrameObserver_getMixedAudioParams":
                case "AudioFrameObserver_getEarMonitoringAudioParams":
                    {
                        var result = new AudioParams();
                        Dictionary<string, System.Object> p = new Dictionary<string, System.Object>();
                        p.Add("result", result);
                        string json = AgoraJson.ToJson(p);
                        var jsonByte = System.Text.Encoding.Default.GetBytes(json);
                        IntPtr resultPtr = eventParam.result;
                        Marshal.Copy(jsonByte, 0, resultPtr, (int)jsonByte.Length);
                    }
                    break;
                case "AudioFrameObserver_onPlaybackAudioFrameBeforeMixing":
                case "AudioFrameObserver_onPlaybackAudioFrameBeforeMixing2":
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