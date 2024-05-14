using System;
using Agora.Rtc;
namespace Agora.Rtc.Ut
{
    public class UTH265TranscoderObserver : IH265TranscoderObserver
    {

        #region terra IH265TranscoderObserver
        public bool OnEnableTranscode_be_trigger = false;
        public H265_TRANSCODE_RESULT OnEnableTranscode_result;

        public override void OnEnableTranscode(H265_TRANSCODE_RESULT result)
        {
            OnEnableTranscode_be_trigger = true;
            OnEnableTranscode_result = result;

        }

        public bool OnEnableTranscodePassed(H265_TRANSCODE_RESULT result)
        {

            if (OnEnableTranscode_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<H265_TRANSCODE_RESULT>(OnEnableTranscode_result, result) == false)
                return false;

            return true;
        }

        /////////////////////////////////

        public bool OnQueryChannel_be_trigger = false;
        public H265_TRANSCODE_RESULT OnQueryChannel_result;
        public string OnQueryChannel_originChannel;
        public string OnQueryChannel_transcodeChannel;

        public override void OnQueryChannel(H265_TRANSCODE_RESULT result, string originChannel, string transcodeChannel)
        {
            OnQueryChannel_be_trigger = true;
            OnQueryChannel_result = result;
            OnQueryChannel_originChannel = originChannel;
            OnQueryChannel_transcodeChannel = transcodeChannel;

        }

        public bool OnQueryChannelPassed(H265_TRANSCODE_RESULT result, string originChannel, string transcodeChannel)
        {

            if (OnQueryChannel_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<H265_TRANSCODE_RESULT>(OnQueryChannel_result, result) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnQueryChannel_originChannel, originChannel) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnQueryChannel_transcodeChannel, transcodeChannel) == false)
                return false;

            return true;
        }

        /////////////////////////////////

        public bool OnTriggerTranscode_be_trigger = false;
        public H265_TRANSCODE_RESULT OnTriggerTranscode_result;

        public override void OnTriggerTranscode(H265_TRANSCODE_RESULT result)
        {
            OnTriggerTranscode_be_trigger = true;
            OnTriggerTranscode_result = result;

        }

        public bool OnTriggerTranscodePassed(H265_TRANSCODE_RESULT result)
        {

            if (OnTriggerTranscode_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<H265_TRANSCODE_RESULT>(OnTriggerTranscode_result, result) == false)
                return false;

            return true;
        }

        /////////////////////////////////
        #endregion terra IH265TranscoderObserver
    }
}
