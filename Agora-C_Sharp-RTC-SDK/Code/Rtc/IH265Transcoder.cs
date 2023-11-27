using System;
namespace Agora.Rtc
{
    public abstract class IH265Transcoder
    {

        #region terra IH265Transcoder
        public abstract int EnableTranscode(string token, string channel, uint uid);

        public abstract int QueryChannel(string token, string channel, uint uid);

        public abstract int TriggerTranscode(string token, string channel, uint uid);

        public abstract int RegisterTranscoderObserver(IH265TranscoderObserver observer);

        public abstract int UnregisterTranscoderObserver(IH265TranscoderObserver observer);
        #endregion terra IH265Transcoder
    }
}
