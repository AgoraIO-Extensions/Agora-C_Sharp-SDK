using System;
using System.Collections.Generic;

namespace Agora.Rtm
{

    internal class Tools
    {
        internal static RtmStatus GenerateSucceedStatus(string operation)
        {
            RtmStatus status = new RtmStatus();
            status.Error = false;
            status.ErrorCode = 0;
            status.Operation = operation;
            status.Reason = "Success";
            return status;
        }

        internal static RtmStatus GenerateFailedStatus(int errorCode, string operation)
        {
            RtmStatus status = new RtmStatus();
            status.Error = true;
            status.ErrorCode = errorCode;
            status.Operation = operation;
            //todo replace true reason
            status.Reason = "Unknow"; 
            return status;
        }


    }
}
