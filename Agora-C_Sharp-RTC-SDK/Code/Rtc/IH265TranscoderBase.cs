using System;
namespace Agora.Rtc
{
    public abstract class IH265TranscoderBase
    {

        #region terra IH265TranscoderBase
        public abstract int RegisterTranscoderObserver(IH265TranscoderObserver observer);

        public abstract int UnregisterTranscoderObserver();
        #endregion terra IH265TranscoderBase
    }
}
