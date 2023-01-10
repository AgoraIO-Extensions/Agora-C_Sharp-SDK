using System;
using System.Runtime.InteropServices;
namespace Agora
{
    public class AgoraApiNative
    {

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        private const string AgoraRtcLibName = "AgoraRtcWrapper";
#elif UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
        private const string AgoraRtcLibName = "AgoraRtcWrapperUnity";
#elif UNITY_IPHONE
		private const string AgoraRtcLibName = "__Internal";
#else
        private const string AgoraRtcLibName = "AgoraRtcWrapper";
#endif

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int InitializeIrisEngine(ref IrisEngineParam param);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr CreateIrisApiEngine(string name);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyIrisApiEngine(IntPtr handle);

        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisApi(IntPtr handle, ref IrisApiParam param);
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
    internal struct IrisApiParam
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

        internal IntPtr buffer;
        internal IntPtr length;
        internal uint buffer_count;
    }

}
