using System;
namespace Agora.Rtc
{
    public abstract class IFaceInfoObserver
    {
        public virtual bool OnFaceInfo(string outFaceInfo)
        {
            return true;
        }
    }
}

