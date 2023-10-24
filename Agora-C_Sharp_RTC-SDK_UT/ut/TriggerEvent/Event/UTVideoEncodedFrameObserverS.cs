using System;
namespace Agora.Rtc
{
    public class UTVideoEncodedFrameObserverS : IVideoEncodedFrameObserverS
    {

        #region terra IVideoEncodedFrameObserverS

        public bool OnEncodedVideoFrameReceived_be_trigger = false;
        public string OnEncodedVideoFrameReceived_userAccount;
        public IntPtr OnEncodedVideoFrameReceived_imageBuffer;
        public ulong OnEncodedVideoFrameReceived_length;
        public EncodedVideoFrameInfoS OnEncodedVideoFrameReceived_videoEncodedFrameInfoS;

        public override bool OnEncodedVideoFrameReceived(string userAccount, IntPtr imageBuffer, ulong length, EncodedVideoFrameInfoS videoEncodedFrameInfoS)
        {
            OnEncodedVideoFrameReceived_be_trigger = true;
            OnEncodedVideoFrameReceived_userAccount = userAccount;
            OnEncodedVideoFrameReceived_imageBuffer = imageBuffer;
            OnEncodedVideoFrameReceived_length = length;
            OnEncodedVideoFrameReceived_videoEncodedFrameInfoS = videoEncodedFrameInfoS;
            return true;

        }

        public bool OnEncodedVideoFrameReceivedPassed(string userAccount, IntPtr imageBuffer, ulong length, EncodedVideoFrameInfoS videoEncodedFrameInfoS)
        {

            if (OnEncodedVideoFrameReceived_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<string>(OnEncodedVideoFrameReceived_userAccount, userAccount) == false)
                return false;
            if (ParamsHelper.Compare<IntPtr>(OnEncodedVideoFrameReceived_imageBuffer, imageBuffer) == false)
                return false;
            if (ParamsHelper.Compare<ulong>(OnEncodedVideoFrameReceived_length, length) == false)
                return false;
            if (ParamsHelper.Compare<EncodedVideoFrameInfoS>(OnEncodedVideoFrameReceived_videoEncodedFrameInfoS, videoEncodedFrameInfoS) == false)
                return false;

            return true;
        }

        /////////////////////////////////
        #endregion terra IVideoEncodedFrameObserverS
    }
}
