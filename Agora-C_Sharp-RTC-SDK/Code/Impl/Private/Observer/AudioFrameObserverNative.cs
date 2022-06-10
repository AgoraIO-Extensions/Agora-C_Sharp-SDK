using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace agora.rtc
{
    internal static class AudioFrameObserverNative
    {
        internal static OBSERVER_MODE mode = OBSERVER_MODE.INTPTR;
        internal static IAudioFrameObserver AudioFrameObserver;

        private static class LocalAudioFrames
        {
            internal static AudioFrame RecordAudioFrame = new AudioFrame();
            internal static AudioFrame PlaybackAudioFrame = new AudioFrame();
            internal static AudioFrame MixedAudioFrame = new AudioFrame();
            internal static Dictionary<string, Dictionary<uint, AudioFrame>> AudioFrameBeforeMixingEx =
                new Dictionary<string, Dictionary<uint, AudioFrame>>();

            internal static Dictionary<string, Dictionary<string, AudioFrame>> AudioFrameBeforeMixingEx2 =
              new Dictionary<string, Dictionary<string, AudioFrame>>();

            internal static IrisAudioParams irisAudioParams = new IrisAudioParams();
        }

        private static AudioFrame ProcessAudioFrameReceived(IntPtr audioFramePtr, string channelId, uint uid)
        {
            var audioFrame = (IrisAudioFrame)(Marshal.PtrToStructure(audioFramePtr, typeof(IrisAudioFrame)) ??
                                                    new IrisAudioFrame());
            AudioFrame localAudioFrame = null;

            if (channelId == "")
            {
                switch (uid)
                {
                    //Local Audio Frame
                    case 0:
                        localAudioFrame = LocalAudioFrames.RecordAudioFrame;
                        break;
                    case 1:
                        localAudioFrame = LocalAudioFrames.PlaybackAudioFrame;
                        break;
                    case 2:
                        localAudioFrame = LocalAudioFrames.MixedAudioFrame;
                        break;
                }
            }
            else
            {
                //Remote Audio Frame
                if (!LocalAudioFrames.AudioFrameBeforeMixingEx.ContainsKey(channelId))
                {
                    LocalAudioFrames.AudioFrameBeforeMixingEx[channelId] = new Dictionary<uint, AudioFrame>();
                    LocalAudioFrames.AudioFrameBeforeMixingEx[channelId][uid] = new AudioFrame();
                }
                else if (!LocalAudioFrames.AudioFrameBeforeMixingEx[channelId].ContainsKey(uid))
                {
                    LocalAudioFrames.AudioFrameBeforeMixingEx[channelId][uid] = new AudioFrame();
                }

                localAudioFrame = LocalAudioFrames.AudioFrameBeforeMixingEx[channelId][uid];
            }

            if (mode == OBSERVER_MODE.RAW_DATA)
            {
                if (localAudioFrame.channels != audioFrame.channels ||
                localAudioFrame.samplesPerChannel != audioFrame.samples ||
                localAudioFrame.bytesPerSample != audioFrame.bytes_per_sample)
                {
                    localAudioFrame.RawBuffer = new byte[audioFrame.buffer_length];
                }

                if (audioFrame.buffer != IntPtr.Zero)
                    Marshal.Copy(audioFrame.buffer, localAudioFrame.RawBuffer, 0, (int)audioFrame.buffer_length);
            }

            localAudioFrame.type = audioFrame.type;
            localAudioFrame.samplesPerChannel = audioFrame.samples;
            localAudioFrame.bufferPtr = audioFrame.buffer;
            localAudioFrame.bytesPerSample = audioFrame.bytes_per_sample;
            localAudioFrame.channels = audioFrame.channels;
            localAudioFrame.samplesPerSec = audioFrame.samples_per_sec;
            localAudioFrame.renderTimeMs = audioFrame.render_time_ms;
            localAudioFrame.avsync_type = audioFrame.av_sync_type;

            return localAudioFrame;
        }

        private static AudioFrame ProcessAudioFrameReceived(IntPtr audioFramePtr, string channelId, string uid)
        {
            var audioFrame = (IrisAudioFrame)(Marshal.PtrToStructure(audioFramePtr, typeof(IrisAudioFrame)) ??
                                                    new IrisAudioFrame());
            AudioFrame localAudioFrame = null;

            //Remote Audio Frame
            if (!LocalAudioFrames.AudioFrameBeforeMixingEx2.ContainsKey(channelId))
            {
                LocalAudioFrames.AudioFrameBeforeMixingEx2[channelId] = new Dictionary<string, AudioFrame>();
                LocalAudioFrames.AudioFrameBeforeMixingEx2[channelId][uid] = new AudioFrame();
            }
            else if (!LocalAudioFrames.AudioFrameBeforeMixingEx2[channelId].ContainsKey(uid))
            {
                LocalAudioFrames.AudioFrameBeforeMixingEx2[channelId][uid] = new AudioFrame();
            }

            localAudioFrame = LocalAudioFrames.AudioFrameBeforeMixingEx2[channelId][uid];


            if (mode == OBSERVER_MODE.RAW_DATA)
            {
                if (localAudioFrame.channels != audioFrame.channels ||
                localAudioFrame.samplesPerChannel != audioFrame.samples ||
                localAudioFrame.bytesPerSample != audioFrame.bytes_per_sample)
                {
                    localAudioFrame.RawBuffer = new byte[audioFrame.buffer_length];
                }

                if (audioFrame.buffer != IntPtr.Zero)
                    Marshal.Copy(audioFrame.buffer, localAudioFrame.RawBuffer, 0, (int)audioFrame.buffer_length);
            }

            localAudioFrame.type = audioFrame.type;
            localAudioFrame.samplesPerChannel = audioFrame.samples;
            localAudioFrame.bufferPtr = audioFrame.buffer;
            localAudioFrame.bytesPerSample = audioFrame.bytes_per_sample;
            localAudioFrame.channels = audioFrame.channels;
            localAudioFrame.samplesPerSec = audioFrame.samples_per_sec;
            localAudioFrame.renderTimeMs = audioFrame.render_time_ms;
            localAudioFrame.avsync_type = audioFrame.av_sync_type;

            return localAudioFrame;
        }

        private static IrisAudioParams ProcessAudioParams(AudioParams audioParams)
        {
            LocalAudioFrames.irisAudioParams.sample_rate = audioParams.sample_rate;
            LocalAudioFrames.irisAudioParams.channels = audioParams.channels;
            LocalAudioFrames.irisAudioParams.mode = (IRIS_RAW_AUDIO_FRAME_OP_MODE_TYPE)audioParams.mode;
            LocalAudioFrames.irisAudioParams.samples_per_call = audioParams.samples_per_call;
            return LocalAudioFrames.irisAudioParams;
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_AudioFrameLocal_Native))]
#endif
        internal static bool OnRecordAudioFrame(string channelId, IntPtr audioFramePtr)
        {
            if (AudioFrameObserver == null)
                return true;

            var audioFrame = ProcessAudioFrameReceived(audioFramePtr, "", 0);
            return AudioFrameObserver.OnRecordAudioFrame(channelId, audioFrame);
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_AudioFrameLocal_Native))]
#endif
        internal static bool OnPlaybackAudioFrame(string channelId, IntPtr audioFramePtr)
        {
            if (AudioFrameObserver == null)
                return true;

            var audioFrame = ProcessAudioFrameReceived(audioFramePtr, "", 1);
            return AudioFrameObserver.OnPlaybackAudioFrame(channelId, audioFrame);
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_AudioFrameLocal_Native))]
#endif
        internal static bool OnMixedAudioFrame(string channelId, IntPtr audioFramePtr)
        {
            if (AudioFrameObserver == null)
                return true;

            var audioFrame = ProcessAudioFrameReceived(audioFramePtr, "", 2);
            return AudioFrameObserver.OnMixedAudioFrame(channelId, audioFrame);
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_AudioFramePosition_Native))]
#endif
        internal static IRIS_AUDIO_FRAME_POSITION GetObservedAudioFramePosition()
        {
            if (AudioFrameObserver == null)
                return (IRIS_AUDIO_FRAME_POSITION)AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_NONE;

            return (IRIS_AUDIO_FRAME_POSITION)AudioFrameObserver.GetObservedAudioFramePosition();
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_AudioParams_Native))]
#endif
        internal static IrisAudioParams GetPlaybackAudioParams()
        {
            if (AudioFrameObserver == null)
                return LocalAudioFrames.irisAudioParams;

            return ProcessAudioParams(AudioFrameObserver.GetPlaybackAudioParams());
        }


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_AudioParams_Native))]
#endif
        internal static IrisAudioParams GetRecordAudioParams()
        {
            if (AudioFrameObserver == null)
                return LocalAudioFrames.irisAudioParams;

            return ProcessAudioParams(AudioFrameObserver.GetRecordAudioParams());
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_AudioParams_Native))]
#endif
        internal static IrisAudioParams GetMixedAudioParams()
        {
            if (AudioFrameObserver == null)
                return LocalAudioFrames.irisAudioParams;

            return ProcessAudioParams(AudioFrameObserver.GetMixedAudioParams());
        }


#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_AudioFrameRemote_Native))]
#endif
        internal static bool OnPlaybackAudioFrameBeforeMixing(string channelId, uint uid, IntPtr audioFramePtr)
        {
            if (AudioFrameObserver == null)
                return true;

            var audioFrame = ProcessAudioFrameReceived(audioFramePtr, channelId, uid);
            return AudioFrameObserver.OnPlaybackAudioFrameBeforeMixing(channelId, uid, audioFrame);
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
        [MonoPInvokeCallback(typeof(Func_AudioFrameRemoteStringUid_Native))]
#endif
        internal static bool OnPlaybackAudioFrameBeforeMixing2(string channelId, string uid, IntPtr audioFramePtr)
        {
            if (AudioFrameObserver == null)
                return true;

            var audioFrame = ProcessAudioFrameReceived(audioFramePtr, channelId, uid);
            return AudioFrameObserver.OnPlaybackAudioFrameBeforeMixing(channelId, uid, audioFrame);
        }
    }
}