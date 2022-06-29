#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using UnityEngine;
#elif NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
using System.Diagnostics;
#endif


namespace Agora.Rtc
{
    internal class AgoraLog
    {
        private const string AgoraMsgTag = "[Agora]:";

        internal static void Log(string msg)
        {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
            Debug.LogFormat("{0} {1}\n", AgoraMsgTag, msg);
#endif

#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            Debug.WriteLine("[Agora Log] {0} {1}\n", AgoraMsgTag, msg);
#endif
        }

        internal static void LogWarning(string warningMsg)
        {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
           
            Debug.LogWarningFormat("{0} {1}\n", AgoraMsgTag, warningMsg);
#endif

#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            Debug.WriteLine("[Agora Warning] {0} {1}\n", AgoraMsgTag, warningMsg);
#endif
        }

        internal static void LogError(string errorMsg)
        {
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
           
            Debug.LogErrorFormat("{0} {1}\n", AgoraMsgTag, errorMsg);
#endif

#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
            Debug.WriteLine("[Agora Error] {0} {1}\n", AgoraMsgTag, errorMsg);
#endif
        }
    }
}


//#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
//namespace Agora.Rtc
//{
//    internal class AgoraLog
//    {
//        private const string AgoraMsgTag = "[Agora]:";

//        internal static void Log(string msg)
//        {
//            Debug.WriteLine("[Agora Log] {0} {1}\n", AgoraMsgTag, msg);
//        }

//        internal static void LogWarning(string warningMsg)
//        {
//            Debug.WriteLine("[Agora Warning] {0} {1}\n", AgoraMsgTag, warningMsg);
//        }

//        internal static void LogError(string errorMsg)
//        {
//            Debug.WriteLine("[Agora Error] {0} {1}\n", AgoraMsgTag, errorMsg);
//        }
//    }
//}
//#endif