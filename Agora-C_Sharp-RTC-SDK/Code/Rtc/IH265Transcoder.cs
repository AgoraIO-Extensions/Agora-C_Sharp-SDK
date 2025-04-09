#region Generated by `terra/node/src/rtc/interface/renderers.ts`. DO NOT MODIFY BY HAND.
#endregion

#define AGORA_RTC
#define AGORA_RTM
using System;
using view_t = System.UInt64;

namespace Agora.Rtc
{
    ///
    /// @ignore
    ///
    public abstract class IH265Transcoder
    {
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

    }
}