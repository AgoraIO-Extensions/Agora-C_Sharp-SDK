using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.Generic;
namespace Agora.Rtc
{

    public class TimeConsuming
    {

        private class TimeRecord
        {
            public long startTime;
            public long logTime;

            public void Start()
            {
                startTime = GetTimestampMilliseconds();
            }

            public void End(string message)
            {
                var curTime = GetTimestampMilliseconds();
                if (curTime - logTime < 2000)
                {
                    return;
                }

                var duration = curTime - startTime;
                IrisLog($"[TimeConsuming] C# {message}: {duration} ms");
                logTime = curTime;
            }

            public void End(long externalStartTime, string message)
            {
                var curTime = GetTimestampMilliseconds();
                if (curTime - logTime < 2000)
                {
                    return;
                }

                var duration = curTime - externalStartTime;
                IrisLog($"[TimeConsuming] C# {message}:externalStartTime:{externalStartTime}, durtation:{duration} ms");
                logTime = curTime;
            }

            static long GetTimestampMilliseconds()
            {
                DateTime dateTime = DateTime.UtcNow;
                DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                TimeSpan timeSpan = dateTime - epoch;
                return (long)timeSpan.TotalMilliseconds;
            }
        }


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

        private static Dictionary<int, TimeRecord> records = new Dictionary<int, TimeRecord>();

        public static void Start(int index)
        {
            if (!records.ContainsKey(index))
            {
                records.Add(index, new TimeRecord());
            }

            records[index].Start();
        }

        public static void End(int index, string message)
        {
            if (!records.ContainsKey(index))
            {
                records.Add(index, new TimeRecord());
            }
            records[index].End(message);
        }

        public static void End(int index, long externalStartTime, string message)
        {
            if (!records.ContainsKey(index))
            {
                records.Add(index, new TimeRecord());
            }
            records[index].End(externalStartTime, message);
        }

    }
}