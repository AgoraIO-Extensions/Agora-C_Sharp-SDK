using System;

namespace Agora.Rtc
{
    public abstract class IVideoFrameMetaInfo
    {
        public abstract String GetMetaInfoStr(META_INFO_KEY key);
    }
}
