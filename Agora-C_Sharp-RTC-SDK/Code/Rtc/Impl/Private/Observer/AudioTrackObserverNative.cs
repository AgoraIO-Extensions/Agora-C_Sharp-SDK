using System;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using AOT;
#endif

namespace Agora.Rtc
{
    internal static partial class AudioTrackObserverNative
    {
        private static readonly object observerLock = new object();
        private static IAudioTrackObserver audioTrackObserver;

        internal static void SetAudioTrackObserver(IAudioTrackObserver observer)
        {
            lock (observerLock) { audioTrackObserver = observer; }
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        internal static AgoraCallbackObject CallbackObject;
        [MonoPInvokeCallback(typeof(Rtc_Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
            lock (observerLock)
            {
                if (audioTrackObserver == null) return;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                if (CallbackObject == null || CallbackObject._CallbackQueue == null) return;
#endif
                var eventParam = (IrisRtcCEventParam)Marshal.PtrToStructure(param, typeof(IrisRtcCEventParam));
                var jsonData = AgoraJson.ToObject(eventParam.data);
                OnEventGen(ref eventParam, jsonData, eventParam.@event);
            }
        }
    }
}
