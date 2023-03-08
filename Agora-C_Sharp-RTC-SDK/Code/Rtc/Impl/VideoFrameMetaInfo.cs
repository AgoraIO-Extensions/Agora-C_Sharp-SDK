using System;
using System.Runtime.InteropServices;

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
            IntPtr intPtr = AgoraRtcNative.GetMetaInfoStr(this.nativeHandler, (int)key);
            return Marshal.PtrToStringAnsi(intPtr);
        }
    }
}
