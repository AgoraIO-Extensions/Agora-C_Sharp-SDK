using System;
using System.Runtime.InteropServices;

namespace Agora.Rtc
{
    internal class DLLHelper
    {
        private const string DebugLibName = "libName";

        [DllImport(DebugLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateFakeRtcEngine();

        [DllImport(DebugLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateFakeRtcEngineS();

        [DllImport(DebugLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int TriggerEventWithFakeRtcEngine(IntPtr engine_ptr, ref IrisCApiParam2 apiParam);

        [DllImport(DebugLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int TriggerEventWithFakeRtcEngineS(IntPtr engine_ptr, ref IrisCApiParam2 apiParam);

        [DllImport(DebugLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateFakeRtmClient();

        [DllImport(DebugLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int TriggerEventWithFakeRtmClient(IntPtr engine_ptr, ref IrisCApiParam2 apiParam);
    }


}
