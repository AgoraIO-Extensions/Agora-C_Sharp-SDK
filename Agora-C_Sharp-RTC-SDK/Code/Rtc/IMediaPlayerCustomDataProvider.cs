using System;

namespace Agora.Rtc
{
    /* class_imediaplayercustomdataprovider */
    public abstract class IMediaPlayerCustomDataProvider
    {
        /* callback_imediaplayercustomdataprovider_onseek */
        public virtual Int64 OnSeek(Int64 offset, int whence)
        {
            return 0;
        }

        /* callback_imediaplayercustomdataprovider_onreaddata */
        public virtual int OnReadData(IntPtr bufferPtr, int bufferSize)
        {
            return 0;
        }
    }
}