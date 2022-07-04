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
        internal static OBSERVER_MODE mode = OBSERVER_MODE.INTPTR;
        internal static IAudioFrameObserver AudioFrameObserver;

        private static class LocalAudioFrames
        {
            internal static readonly AudioFrame RecordAudioFrame = new AudioFrame();
            internal static readonly AudioFrame PlaybackAudioFrame = new AudioFrame();
            internal static readonly AudioFrame MixedAudioFrame = new AudioFrame();
            internal static readonly Dictionary<string, Dictionary<uint, AudioFrame>> AudioFrameBeforeMixingEx = 
                new Dictionary<string, Dictionary<uint, AudioFrame>>();
        }

        private static AudioFrame ProcessAudioFrameReceived(IntPtr audioFramePtr, string channelId, uint uid)
        {
            var audioFrame = (IrisAudioFrame)(Marshal.PtrToStructure(audioFramePtr, typeof(IrisAudioFrame)) ??
                new IrisAudioFrame());
            var localAudioFrame = new AudioFrame();

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
                localAudioFrame.bytesPerSample != (BYTES_PER_SAMPLE)audioFrame.bytes_per_sample)
                {
                    localAudioFrame.RawBuffer = new byte[audioFrame.buffer_length];
                }

                if (audioFrame.buffer != IntPtr.Zero)
                    Marshal.Copy(audioFrame.buffer, localAudioFrame.RawBuffer, 0, (int)audioFrame.buffer_length);
            }

            localAudioFrame.type = audioFrame.type;
            localAudioFrame.samplesPerChannel = audioFrame.samples;
            localAudioFrame.bufferPtr = audioFrame.buffer;
            localAudioFrame.bytesPerSample = (BYTES_PER_SAMPLE)audioFrame.bytes_per_sample;
            localAudioFrame.channels = audioFrame.channels;
            localAudioFrame.samplesPerSec = audioFrame.samples_per_sec;
            localAudioFrame.renderTimeMs = audioFrame.render_time_ms;
            localAudioFrame.avsync_type = audioFrame.av_sync_type;

            return localAudioFrame;
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_AudioFrameLocal_Native))]
#endif
        internal static bool OnRecordAudioFrame(string channelId, IntPtr audioFramePtr)
        {
            return AudioFrameObserver == null || 
                AudioFrameObserver.OnRecordAudioFrame(channelId, ProcessAudioFrameReceived(audioFramePtr, "", 0));
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_AudioFrameLocal_Native))]
#endif
        internal static bool OnPlaybackAudioFrame(string channelId, IntPtr audioFramePtr)
        {
            return AudioFrameObserver == null ||
                AudioFrameObserver.OnPlaybackAudioFrame(channelId, ProcessAudioFrameReceived(audioFramePtr, "", 1));
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_AudioFrameLocal_Native))]
#endif
        internal static bool OnMixedAudioFrame(string channelId, IntPtr audioFramePtr)
        {
            return AudioFrameObserver == null ||
                AudioFrameObserver.OnMixedAudioFrame(channelId, ProcessAudioFrameReceived(audioFramePtr, "", 2));
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_AudioFrameRemote_Native))]
#endif
        internal static bool OnPlaybackAudioFrameBeforeMixing(string channelId, uint uid, IntPtr audioFramePtr)
        {
            return true;
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_Bool_Native))]
#endif
        internal static bool IsMultipleChannelFrameWanted()
        { 
            return AudioFrameObserver == null ||
                AudioFrameObserver.IsMultipleChannelFrameWanted();
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_AudioFrameEx_Native))]
#endif
        internal static bool OnPlaybackAudioFrameBeforeMixingEx(string channelId, uint uid, IntPtr audioFramePtr)
        {
            return AudioFrameObserver == null || AudioFrameObserver.OnPlaybackAudioFrameBeforeMixingEx(channelId, uid,
                ProcessAudioFrameReceived(audioFramePtr, channelId, uid));
        }
    }
}