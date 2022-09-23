using System;
using System.Runtime.InteropServices;
using Agora.Rtc;

namespace Agora.Rtm
{
    using IrisApiRtmEnginePtr = IntPtr;
    using IrisEventHandlerHandle = IntPtr;
    using IrisCEventHandler = IntPtr;

    internal static class AgoraRtmNative
    {
        #region DllImport

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        private const string AgoraRtmLibName = "AgoraRtmWrapper";
#elif UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
        private const string AgoraRtmLibName = "AgoraRtmWrapperUnity";
#elif UNITY_IPHONE
		private const string AgoraRtmLibName = "__Internal";
#else
        private const string AgoraRtmLibName = "AgoraRtmWrapper";
#endif

        [DllImport(AgoraRtmLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisApiRtmEnginePtr CreateIrisRtmEngine(IntPtr engine);

        [DllImport(AgoraRtmLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyIrisRtmEngine(IrisApiRtmEnginePtr engine);

        [DllImport(AgoraRtmLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisRtmApi(IrisApiRtmEnginePtr engine_ptr, ref IrisCApiParam @param);

        internal static int CallIrisApiWithArgs(IrisApiRtmEnginePtr engine_ptr, string func_name,
            string @params, UInt32 paramLength, IntPtr buffer, uint buffer_count, ref IrisCApiParam apiParam,
            uint buffer0Length = 0, uint buffer1Length = 0, uint buffer2Length = 0)
        {
            apiParam.@event = func_name;
            apiParam.data = @params;
            apiParam.data_size = paramLength;
            apiParam.buffer = buffer;
            apiParam.buffer_count = buffer_count;

            IntPtr lengthPtr = IntPtr.Zero;
            if (buffer_count > 0)
            {
                int[] lengths = new int[3];
                lengths[0] = (int)buffer0Length;
                lengths[1] = (int)buffer1Length;
                lengths[2] = (int)buffer2Length;
                lengthPtr = Marshal.AllocHGlobal(lengths.Length * sizeof(int));
                Marshal.Copy(lengths, 0, lengthPtr, (int)lengths.Length);
            }
            apiParam.length = lengthPtr;
            int retval = CallIrisRtmApi(engine_ptr, ref apiParam);

            if (lengthPtr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(lengthPtr);
            }

            return retval;
        }

        [DllImport(AgoraRtmLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisEventHandlerHandle CreateIrisEventHandler(IrisCEventHandler event_handler);

        [DllImport(AgoraRtmLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyIrisEventHandler(IrisEventHandlerHandle handler);

        #endregion
    }
}