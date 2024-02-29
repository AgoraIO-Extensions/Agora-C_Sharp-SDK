using System;
namespace Agora.Rtc
{
    ///
    /// @ignore
    ///
    public abstract class IH265Transcoder
    {

        #region terra IH265Transcoder
        ///
        /// @ignore
        ///
        public abstract int EnableTranscode(string token, string channel, uint uid);

        ///
        /// @ignore
        ///
        public abstract int QueryChannel(string token, string channel, uint uid);

        ///
        /// @ignore
        ///
        public abstract int TriggerTranscode(string token, string channel, uint uid);

        ///
        /// @ignore
        ///
        public abstract int RegisterTranscoderObserver(IH265TranscoderObserver observer);

        ///
        /// @ignore
        ///
        public abstract int UnregisterTranscoderObserver();
        #endregion terra IH265Transcoder
    }
}
