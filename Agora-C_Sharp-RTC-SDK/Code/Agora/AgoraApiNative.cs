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
        internal static extern int InitializeIrisEngine(ref );

    }


    typedef struct IrisEngineParam
    {
        const char* log_path;
        const char* log_name;
        IrisLogLevel log_level;
    }
    IrisEngineParam;

}
