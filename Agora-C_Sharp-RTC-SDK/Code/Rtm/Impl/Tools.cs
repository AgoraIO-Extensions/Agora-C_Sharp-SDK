using System;
using System.Collections.Generic;

namespace Agora.Rtm
{

    internal class Tools
    {


        internal static RtmStatus GenerateStatus(int errorCode, string operation, Internal.IRtmClient rtmClient)
        {
            RtmStatus status = new RtmStatus();
            status.Error = errorCode != 0;
            status.ErrorCode = errorCode;
            status.Operation = operation;
            //todo replace true reason
            status.Reason = errorCode == 0 ? "Sucess" : "unknow";
            return status;
        }

    }
}
