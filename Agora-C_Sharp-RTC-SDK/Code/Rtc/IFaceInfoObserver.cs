using System;
namespace Agora.Rtc
{
    ///
    /// @ignore
    ///
    public abstract class IFaceInfoObserver
    {
        ///
        /// @ignore
        ///
        public virtual bool OnFaceInfo(string outFaceInfo)
        {
            return true;
        }
    }
}
