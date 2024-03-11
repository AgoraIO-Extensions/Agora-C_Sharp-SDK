using System;
using Agora.Rtc.Ut;

namespace Agora.Rtc
{
    public class UTFaceInfoObserver : IFaceInfoObserver
    {
        public bool OnFaceInfo_be_trigger = false;
        public string OnFaceInfo_outFaceInfo = null;

        public override bool OnFaceInfo(string outFaceInfo)
        {
            OnFaceInfo_be_trigger = true;
            OnFaceInfo_outFaceInfo = outFaceInfo;
            return true;
        }

        public bool OnFaceInfoPassed(string outFaceInfo)
        {
            if (OnFaceInfo_be_trigger == false)
                return false;
            //if (ParamsHelper.Compare<string>(OnFaceInfo_outFaceInfo, outFaceInfo) == false)
            //    return false;

            return true;
        }
    }

}

