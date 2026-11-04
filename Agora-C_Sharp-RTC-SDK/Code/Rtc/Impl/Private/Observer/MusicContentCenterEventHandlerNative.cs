using System;
using System.Runtime.InteropServices;
using System.Text;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
using AOT;
#endif

namespace Agora.Rtc
{
    internal static partial class MusicContentCenterEventHandlerNative
    {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
        private static Object observerLock = new Object();
#endif
        private static IMusicContentCenterEventHandler EventHandler = null;
        internal static void SetMusicContentCenterEventHandler(IMusicContentCenterEventHandler handler)
        {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            lock (observerLock)
            {
#endif
                EventHandler = handler;
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            }
#endif
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Utf8Event
        {
            internal IntPtr name;
            internal IntPtr data;
            internal uint dataSize;
            internal IntPtr result;
            internal IntPtr buffer;
            internal IntPtr length;
            internal uint bufferCount;
        }

        private static IrisRtcCEventParam ReadUtf8Event(IntPtr pointer)
        {
            if (pointer == IntPtr.Zero) throw new ArgumentNullException("pointer");
            var raw = (Utf8Event)Marshal.PtrToStructure(pointer, typeof(Utf8Event));
            if (raw.data == IntPtr.Zero) throw new ArgumentException("Missing callback data.");
            int count = checked((int)raw.dataSize);
            var bytes = new byte[count];
            Marshal.Copy(raw.data, bytes, 0, count);
            // Some transports include the terminating NUL in their byte count.
            if (count > 0 && bytes[count - 1] == 0) count--;
            return new IrisRtcCEventParam
            {
                // Event identifiers are ASCII; response text is always UTF-8.
                @event = Marshal.PtrToStringAnsi(raw.name),
                data = new UTF8Encoding(false, true).GetString(bytes, 0, count),
                data_size = raw.dataSize, result = raw.result, buffer = raw.buffer,
                length = raw.length, buffer_count = raw.bufferCount
            };
        }

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        internal static AgoraCallbackObject CallbackObject = null;
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
        [MonoPInvokeCallback(typeof(Rtc_Func_Event_Native))]
#endif
        internal static void OnEvent(IntPtr param)
        {
#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            lock (observerLock)
            {
#endif
                if (EventHandler == null)
                    return;

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                if (CallbackObject == null || CallbackObject._CallbackQueue == null)
                    return;
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID || UNITY_VISIONOS
                IrisRtcCEventParam eventParam = (IrisRtcCEventParam)Marshal.PtrToStructure(param, typeof(IrisRtcCEventParam));

                string @event = eventParam.@event;
                string data = eventParam.data;

                LitJson.JsonData jsonData = null;
                if (data != null)
                {
                    jsonData = AgoraJson.ToObject(data);
                }

                switch (@event)
                {
                    default:
                        {
                            OnEventGen(ref eventParam, jsonData, @event);
                            break;
                        }
                }
#else
                string eventName = "unknown";
                try
                {
                    // Iris data_size is a UTF-8 byte count, not an ANSI character count.
                    var eventParam = ReadUtf8Event(param);
                    eventName = eventParam.@event;
                    var jsonData = LitJson.JsonMapper.ToObject(eventParam.data);
                    OnEventGen(ref eventParam, jsonData, eventName);
                }
                catch (Exception error)
                {
                    // No managed exception may escape the reverse P/Invoke boundary.
                    // Do not log response bodies: they may contain signed resource URLs.
                    try { Console.Error.WriteLine("MusicContentCenter callback rejected: {0}; event={1}", error.GetType().Name, eventName); }
                    catch (Exception) { /* Diagnostic output must not rethrow into Native. */ }
                }
#endif

#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            }
#endif
        }
    }
}