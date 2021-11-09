//  AgoraLog.cs
//
//  Created by YuGuo Chen on October 6, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using UnityEngine;
#elif NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
using System.Diagnostics;
#endif

#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
namespace agora.rtc
{
    internal class AgoraLog
    {
        private const string AgoraMsgTag = "[Agora]:";

        internal static void Log(string msg)
        {
            Debug.LogFormat("{0} {1}\n", AgoraMsgTag, msg);
        }

        internal static void LogWarning(string warningMsg)
        {
            Debug.LogWarningFormat("{0} {1}\n", AgoraMsgTag, warningMsg);
        }

        internal static void LogError(string errorMsg)
        {
            Debug.LogErrorFormat("{0} {1}\n", AgoraMsgTag, errorMsg);
        }
    }
}
#endif

#if NET40_OR_GREATER || NETCOREAPP2_0_OR_GREATER
namespace agora.rtc
{
    internal class AgoraLog
    {
        private const string AgoraMsgTag = "[Agora]:";

        internal static void Log(string msg)
        {
            Debug.WriteLine("[Agora Log] {0} {1}\n", AgoraMsgTag, msg);
        }

        internal static void LogWarning(string warningMsg)
        {
            Debug.WriteLine("[Agora Warning] {0} {1}\n", AgoraMsgTag, warningMsg);
        }

        internal static void LogError(string errorMsg)
        {
            Debug.WriteLine("[Agora Error] {0} {1}\n", AgoraMsgTag, errorMsg);
        }
    }
}
#endif