using System;
namespace Agora.Rtc
{
    public class UTVideoEncodedFrameObserver : IVideoEncodedFrameObserver
    {


        public bool OnEncodedVideoFrameReceived_be_trigger = false;
        public uint OnEncodedVideoFrameReceived_uid = 0;
        public IntPtr OnEncodedVideoFrameReceived_imageBuffer = IntPtr.Zero;
        public ulong OnEncodedVideoFrameReceived_length = 0;
        public EncodedVideoFrameInfo OnEncodedVideoFrameReceived_videoEncodedFrameInfo = null;

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

            if (ParamsHelper.compareUid_t(OnEncodedVideoFrameReceived_uid, uid) == false)
                return false;
            if (ParamsHelper.compareIntPtr(OnEncodedVideoFrameReceived_imageBuffer, imageBuffer) == false)
                return false;
            if (ParamsHelper.compareUlong(OnEncodedVideoFrameReceived_length, length) == false)
                return false;
            if (ParamsHelper.compareEncodedVideoFrameInfo(OnEncodedVideoFrameReceived_videoEncodedFrameInfo, videoEncodedFrameInfo) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

    }
}
