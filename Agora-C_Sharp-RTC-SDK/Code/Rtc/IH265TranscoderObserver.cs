using System;
namespace Agora.Rtc
{
    ///
    /// @ignore
    ///
    public abstract class IH265TranscoderObserver
    {
        #region terra IH265TranscoderObserver
        ///
        /// @ignore
        ///
        public abstract void OnEnableTranscode(H265_TRANSCODE_RESULT result);

        ///
        /// @ignore
        ///
        public abstract void OnQueryChannel(H265_TRANSCODE_RESULT result, string originChannel, string transcodeChannel);

        ///
        /// @ignore
        ///
        public abstract void OnTriggerTranscode(H265_TRANSCODE_RESULT result);
        #endregion terra IH265TranscoderObserver

    }
}
