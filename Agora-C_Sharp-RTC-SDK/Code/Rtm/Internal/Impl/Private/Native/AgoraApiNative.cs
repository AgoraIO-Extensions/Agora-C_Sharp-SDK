#define AGORA_RTC
#define AGORA_RTM

using System;
using System.Runtime.InteropServices;
using IrisEventHandlerMarshal = System.IntPtr;
using IrisEventHandlerHandle = System.IntPtr;
namespace Agora.Rtm
{

    public class AgoraApiNative
    {

#if AGORA_RTC
        private const string AgoraRtcLibName = Agora.Rtc.AgoraRtcNative.AgoraRtcLibName;
#elif AGORA_RTM
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        private const string AgoraRtcLibName = "AgoraRtmEngine";
#elif UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
        private const string AgoraRtcLibName = "AgoraRtmEngineUnity";
#elif UNITY_IPHONE
		private const string AgoraRtcLibName = "__Internal";
#else
        private const string AgoraRtcLibName = "AgoraRtmEngine";
#endif

#endif


        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int InitializeIrisEngine(ref IrisEngineParam param);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr CreateIrisRtmApiEngine(string name);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyIrisRtmApiEngine(IntPtr handle);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisRtmApi(IntPtr handle, ref IrisRtmApiParam param);
    }


    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate void Func_Event_Native(IntPtr param);


    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisCEventHandlerNative
    {
        internal IntPtr onEvent;
    }

    internal struct IrisCEventHandler
    {
        internal Func_Event_Native OnEvent;
    }

    internal struct EventHandlerHandle
    {
        internal IrisCEventHandler cEvent;
        internal IrisEventHandlerMarshal marshal;
        internal IrisEventHandlerHandle handle;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisCEventParam
    {
        internal string @event;
        internal string data;
        internal uint data_size;
        internal IntPtr result;
        internal uint result_size;
        internal IntPtr buffer;
        internal IntPtr length;
        internal uint buffer_count;
    }

    internal enum IrisLogLevel
    {
        levelTrace = 0,
        levelDebug = 1,
        levelInfo = 2,
        levelWarn = 3,
        levelErr = 4,
    };

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisEngineParam
    {
        internal string log_path;
        internal string log_name;
        internal IrisLogLevel log_level;
    };

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisApiEngineParam
    {
        internal string log_path;
        internal IrisLogLevel log_level;
    };

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisRtmApiParam
    {

        internal string Result
        {
            get
            {
                var re = Marshal.PtrToStringAnsi(result);
                return re;
            }
        }

        internal void AllocResult()
        {
            if (result == IntPtr.Zero)
            {
                result = Marshal.AllocHGlobal(65536);
            }
        }

        internal void FreeResult()
        {
            if (result != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(result);
                result = IntPtr.Zero;
            }
        }


        internal string @event;
        internal string data;
        internal uint data_size;
        internal IntPtr result;
        internal uint result_size;
        internal IntPtr buffer;
        internal IntPtr length;
        internal uint buffer_count;
    }

}
