using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Agora.Rtc {

    public class TimeConsuming
    {

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        public const string AgoraRtcLibName = "AgoraRtcWrapper";
#elif UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
        public const string AgoraRtcLibName = "AgoraRtcWrapperUnity";
#elif UNITY_IPHONE || UNITY_VISIONOS
		public const string AgoraRtcLibName = "__Internal";
#else
        public const string AgoraRtcLibName = "AgoraRtcWrapper";
#endif


        [DllImport(AgoraRtcLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void IrisLog(string log);

        private static Stopwatch stopwatch = new Stopwatch();
        private static DateTime lastLogTime = DateTime.UtcNow;

        public static void Start()
        {
            stopwatch.Reset();
            stopwatch.Start();
        }

        public static void End(string message)
        {
            stopwatch.Stop();

            DateTime curTime = DateTime.UtcNow;

            long interval = (long)(curTime - lastLogTime).TotalMilliseconds;

            if (interval < 2000)
            {
                return;
            }

            lastLogTime = curTime;

            long duration = stopwatch.ElapsedMilliseconds;

            IrisLog($"[TimeConsuming] C# {message}: {duration} ms");

            stopwatch.Reset();
        }

    }
}