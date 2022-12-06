using System;
using Agora.Rtc;

namespace Agora.Rtc
{
    public class UTMediaPlayerCustomDataProvider:IMediaPlayerCustomDataProvider
    {


        public bool OnSeek_be_trigger = false;
        public Int64 OnSeek_offset = 0;
        public int OnSeek_whence = 0;


        public override Int64 OnSeek(Int64 offset, int whence)
        {
            OnSeek_be_trigger = true;
            OnSeek_offset = offset;
            OnSeek_whence = whence;
            return 0;
        }

        public bool OnSeekPassed(Int64 offset, int whence)
        {
            if (OnSeek_be_trigger == false)
                return false;

            if (ParamsHelper.compareInt64_t(OnSeek_offset, offset) == false)
                return false;

            if (ParamsHelper.compareInt(OnSeek_whence, whence) == false)
                return false;

            return true;
        }


        /////////


        public bool OnReadData_be_trigger = false;
        public IntPtr OnReadData_buffer = IntPtr.Zero;
        public int OnReadData_bufferSize = 0;

        public override int OnReadData(IntPtr buffer, int bufferSize)
        {
            OnReadData_be_trigger = true;
            OnReadData_buffer = buffer;
            OnReadData_bufferSize = bufferSize;
            return 10;
        }

        public bool OnReadDataPassed(IntPtr buffer, int bufferSize)
        {
            if (OnReadData_be_trigger == false)
                return false;

            if (ParamsHelper.compareIntPtr(OnReadData_buffer, buffer) == false)
                return false;
            if (ParamsHelper.compareInt(OnReadData_bufferSize, bufferSize) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

    }
}
