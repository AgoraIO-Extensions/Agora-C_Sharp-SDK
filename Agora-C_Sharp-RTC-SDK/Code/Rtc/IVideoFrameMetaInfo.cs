using System;
namespace Agora.Rtc
{
    public abstract class IVideoFrameMetaInfo
    {
        public abstract string GetMetaInfoStr(META_INFO_KEY key);
    }
}

