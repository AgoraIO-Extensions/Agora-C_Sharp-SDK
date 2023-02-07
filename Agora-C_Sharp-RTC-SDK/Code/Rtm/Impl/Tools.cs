using System;
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

        internal static RtmStatus GenerateFailedStatus(int errorCode, string operation) {
            RtmStatus status = new RtmStatus();
            status.Error = true;
            status.ErrorCode = errorCode;
            status.Operation = operation;
            status.Reason = "Success"; //todo 翻译
            return status;
        }


    }
}
