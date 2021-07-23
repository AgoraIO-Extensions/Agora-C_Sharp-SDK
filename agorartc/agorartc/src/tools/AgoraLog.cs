//  AgoraLog.cs
//
//  Created by Yiqing Huang on June 2, 2021.
//  Modified by Yiqing Huang on June 24, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System.Diagnostics;

namespace agorartc
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