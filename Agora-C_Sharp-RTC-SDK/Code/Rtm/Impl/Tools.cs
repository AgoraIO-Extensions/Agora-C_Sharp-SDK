using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Agora.Rtm
{

    internal class Tools
    {
        internal static Dictionary<int, string> ErrorCode2Reason = new Dictionary<int, string>();

        internal static RtmStatus GenerateStatus(int errorCode, string operation, Internal.IRtmClient rtmClient)
        {
            RtmStatus status = new RtmStatus();
            status.Error = errorCode != 0;
            status.ErrorCode = errorCode;
            status.Operation = operation;

            if (ErrorCode2Reason.ContainsKey(errorCode))
            {
                status.Reason = ErrorCode2Reason[errorCode];
            }
            else
            {
                IntPtr reasonPtr = Internal.AgoraRtmNative.GetIrisRtmErrorReason(errorCode);
                string reason = Marshal.PtrToStringAnsi(reasonPtr);
                status.Reason = reason;
                ErrorCode2Reason.Add(errorCode, reason);
            }
            return status;
        }
    }
}
