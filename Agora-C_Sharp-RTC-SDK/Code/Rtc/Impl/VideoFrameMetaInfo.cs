using System;
namespace Agora.Rtc
{
    public class VideoFrameMetaInfo : IVideoFrameMetaInfo
    {
        private IntPtr nativeHandler = IntPtr.Zero;

        public VideoFrameMetaInfo(IntPtr nativeHandler)
        {
            this.nativeHandler = nativeHandler;
        }

        public override string GetMetaInfoStr(META_INFO_KEY key)
        {
            return AgoraRtcNative.GetMetaInfoStr(this.nativeHandler, (int)key);
        }
    }
}
