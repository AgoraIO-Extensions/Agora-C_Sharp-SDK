using System;

namespace Agora.Rtc
{
    ///
    /// <summary>
    /// Receives encoded video images.
    /// </summary>
    ///
    public abstract class IVideoEncodedFrameObserverS
    {
        #region terra IVideoEncodedFrameObserverS


        public virtual bool OnEncodedVideoFrameReceived(string userAccount, IntPtr imageBuffer, ulong length, EncodedVideoFrameInfoS videoEncodedFrameInfoS)
        {
            return true;
        }
        #endregion terra IVideoEncodedFrameObserverS
    }
}