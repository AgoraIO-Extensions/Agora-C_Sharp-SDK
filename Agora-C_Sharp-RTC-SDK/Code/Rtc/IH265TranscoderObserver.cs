using System;
namespace Agora.Rtc
{
    public abstract class IH265TranscoderObserver
    {
        #region terra IH265TranscoderObserver
        public abstract void OnEnableTranscode(H265_TRANSCODE_RESULT result);

        public abstract void OnQueryChannel(H265_TRANSCODE_RESULT result, string originChannel, string transcodeChannel);

        public abstract void OnTriggerTranscode(H265_TRANSCODE_RESULT result);
        #endregion terra IH265TranscoderObserver

    }
}
