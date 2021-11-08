//  AgoraRtcAudioFrameObserver.cs
//
//  Created by Yiqing Huang on June 9, 2021.
//  Modified by Yiqing Huang on July 21, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace agora.rtc
{
    internal static class RtcAudioFrameObserverNative
    {
        internal static IAgoraRtcAudioFrameObserver AudioFrameObserver;

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
            var audioFrame = (IrisRtcAudioFrame) (Marshal.PtrToStructure(audioFramePtr, typeof(IrisRtcAudioFrame)) ??
                                                        new IrisRtcAudioFrame());
            var localAudioFrame = new AudioFrame();

            if (channelId == "")
            {
                // Local Audio Frame
                switch (uid)
                {
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
                // Remote Audio Frame
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

            if (localAudioFrame.channels != audioFrame.channels ||
                localAudioFrame.samples != audioFrame.samples ||
                localAudioFrame.bytesPerSample != audioFrame.bytes_per_sample)
            {
                localAudioFrame.buffer = new byte[audioFrame.buffer_length];
            }

            if (audioFrame.buffer != IntPtr.Zero)
                Marshal.Copy(audioFrame.buffer, localAudioFrame.buffer, 0, (int) audioFrame.buffer_length);
            localAudioFrame.type = audioFrame.type;
            localAudioFrame.samples = audioFrame.samples;
            localAudioFrame.bufferPtr = audioFrame.buffer;
            localAudioFrame.bytesPerSample = audioFrame.bytes_per_sample;
            localAudioFrame.channels = audioFrame.channels;
            localAudioFrame.samplesPerSec = audioFrame.samples_per_sec;
            localAudioFrame.renderTimeMs = audioFrame.render_time_ms;
            localAudioFrame.avsync_type = audioFrame.av_sync_type;

            return localAudioFrame;
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_AudioFrameLocal_Native))]
#endif
        internal static bool OnRecordAudioFrame(IntPtr audioFramePtr)
        {
            return AudioFrameObserver == null ||
                   AudioFrameObserver.OnRecordAudioFrame(ProcessAudioFrameReceived(audioFramePtr, "", 0));
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_AudioFrameLocal_Native))]
#endif
        internal static bool OnPlaybackAudioFrame(IntPtr audioFramePtr)
        {
            return AudioFrameObserver == null ||
                   AudioFrameObserver.OnPlaybackAudioFrame(ProcessAudioFrameReceived(audioFramePtr, "", 1));
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_AudioFrameLocal_Native))]
#endif
        internal static bool OnMixedAudioFrame(IntPtr audioFramePtr)
        {
            return AudioFrameObserver == null ||
                   AudioFrameObserver.OnMixedAudioFrame(ProcessAudioFrameReceived(audioFramePtr, "", 2));
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_AudioFrameRemote_Native))]
#endif
        internal static bool OnPlaybackAudioFrameBeforeMixing(uint uid, IntPtr audioFramePtr)
        {
            return true;
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_Bool_Natvie))]
#endif
        internal static bool IsMultipleChannelFrameWanted()
        {
            return AudioFrameObserver == null || AudioFrameObserver.IsMultipleChannelFrameWanted();
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