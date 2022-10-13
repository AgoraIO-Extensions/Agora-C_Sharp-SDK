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
        internal static Dictionary<int, IMediaPlayerAudioFrameObserver> AudioFrameObserverDic = new Dictionary<int, IMediaPlayerAudioFrameObserver>();
        private static class LocalAudioPcmFrames
        {
            internal static readonly AudioPcmFrame AudioPcmFrame = new AudioPcmFrame();
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
        [MonoPInvokeCallback(typeof(Func_AudioOnFrame_Native))]
#endif
        internal static bool OnFrame(IntPtr audioFramePtr, int mediaPlayerId)
        {
            var audioPcmFrame = (IrisAudioPcmFrame) (Marshal.PtrToStructure(audioFramePtr, typeof(IrisAudioPcmFrame)) ??
                                                    new IrisAudioPcmFrame());
            var localAudioPcmFrame = new AudioPcmFrame();

            // todo optimize
            localAudioPcmFrame = LocalAudioPcmFrames.AudioPcmFrame;
            localAudioPcmFrame.data_ = new Int16[3840];
            localAudioPcmFrame.data_ = audioPcmFrame.data_;
            localAudioPcmFrame.num_channels_ = audioPcmFrame.num_channels_;
            localAudioPcmFrame.capture_timestamp = audioPcmFrame.capture_timestamp;
            localAudioPcmFrame.sample_rate_hz_ = audioPcmFrame.sample_rate_hz_;
            localAudioPcmFrame.samples_per_channel_ = audioPcmFrame.samples_per_channel_;

            try
            {
                return AudioFrameObserverDic.ContainsKey(mediaPlayerId) ||
                AudioFrameObserverDic[mediaPlayerId].OnFrame(localAudioPcmFrame);
            }
            catch (Exception e)
            {
                AgoraLog.LogError("[Exception] IMediaPlayerAudioFrameObserver.OnFrame: " + e);
                return true;
            }
        }
    }
}