using System;
namespace Agora.Rtc
{
    public class UTVideoEncodedFrameObserver : IVideoEncodedFrameObserver
    {

        #region terra IVideoEncodedFrameObserver

        public bool OnEncodedVideoFrameReceived_be_trigger = false;
        public uint OnEncodedVideoFrameReceived_uid;
        public IntPtr OnEncodedVideoFrameReceived_imageBuffer;
        public ulong OnEncodedVideoFrameReceived_length;
        public EncodedVideoFrameInfo OnEncodedVideoFrameReceived_videoEncodedFrameInfo;

        public override bool OnEncodedVideoFrameReceived(uint uid, IntPtr imageBuffer, ulong length, EncodedVideoFrameInfo videoEncodedFrameInfo)
        {
            OnEncodedVideoFrameReceived_be_trigger = true;
            OnEncodedVideoFrameReceived_uid = uid;
            OnEncodedVideoFrameReceived_imageBuffer = imageBuffer;
            OnEncodedVideoFrameReceived_length = length;
            OnEncodedVideoFrameReceived_videoEncodedFrameInfo = videoEncodedFrameInfo;
            return true;
        }

        public bool OnEncodedVideoFrameReceivedPassed(uint uid, IntPtr imageBuffer, ulong length, EncodedVideoFrameInfo videoEncodedFrameInfo)
        {

            if (OnEncodedVideoFrameReceived_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<uint>(OnEncodedVideoFrameReceived_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<IntPtr>(OnEncodedVideoFrameReceived_imageBuffer, imageBuffer) == false)
                return false;
            if (ParamsHelper.Compare<ulong>(OnEncodedVideoFrameReceived_length, length) == false)
                return false;
            if (ParamsHelper.Compare<EncodedVideoFrameInfo>(OnEncodedVideoFrameReceived_videoEncodedFrameInfo, videoEncodedFrameInfo) == false)
                return false;

            return true;
        }

        /////////////////////////////////
        #endregion terra IVideoEncodedFrameObserver
    }
}
