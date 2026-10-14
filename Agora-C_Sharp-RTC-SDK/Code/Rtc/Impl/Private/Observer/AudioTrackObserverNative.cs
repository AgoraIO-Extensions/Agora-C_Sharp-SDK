using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using AOT;
#endif

namespace Agora.Rtc
{
    internal static partial class AudioTrackObserverNative
    {
        private static readonly object observerLock = new object();
        private static readonly Dictionary<ulong, IAudioTrackObserver> observers = new Dictionary<ulong, IAudioTrackObserver>();

        internal static void SetAudioTrackObserver(IntPtr handle, IAudioTrackObserver observer)
        {
            lock (observerLock)
            {
                var key = IntPtr.Size == 4 ? unchecked((uint)handle.ToInt32()) : unchecked((ulong)handle.ToInt64());
                if (observer == null) observers.Remove(key);
                else observers[key] = observer;
            }
        }

        internal static IAudioTrackObserver GetAudioTrackObserver(LitJson.JsonData jsonData)
        {
            lock (observerLock)
            {
                // Older Iris builds support one observer and do not attach its identity.
                if (!jsonData.ContainsKey("observerId"))
                {
                    if (observers.Count != 1) return null;
                    foreach (var value in observers.Values) return value;
                    return null;
                }
                IAudioTrackObserver observer;
                return observers.TryGetValue((ulong)AgoraJson.GetData<ulong>(jsonData, "observerId"), out observer) ? observer : null;
            }
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        internal static AgoraCallbackObject CallbackObject;
        [MonoPInvokeCallback(typeof(Rtc_Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
            lock (observerLock)
            {
                if (observers.Count == 0) return;
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
