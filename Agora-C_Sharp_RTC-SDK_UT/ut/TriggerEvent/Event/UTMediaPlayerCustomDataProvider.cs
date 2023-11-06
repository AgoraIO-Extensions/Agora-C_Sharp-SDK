using System;
using Agora.Rtc;

namespace Agora.Rtc
{
    public class UTMediaPlayerCustomDataProvider : IMediaPlayerCustomDataProvider
    {

        #region terra IMediaPlayerCustomDataProvider
        public bool OnReadData_be_trigger = false;
        public IntPtr OnReadData_buffer;
        public int OnReadData_bufferSize;

        public override int OnReadData(IntPtr buffer, int bufferSize)
        {
            OnReadData_be_trigger = true;
            OnReadData_buffer = buffer;
            OnReadData_bufferSize = bufferSize;
            return 0;

        }

        public bool OnReadDataPassed(IntPtr buffer, int bufferSize)
        {

            if (OnReadData_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<IntPtr>(OnReadData_buffer, buffer) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnReadData_bufferSize, bufferSize) == false)
                return false;

            return true;
        }

        /////////////////////////////////

        public bool OnSeek_be_trigger = false;
        public long OnSeek_offset;
        public int OnSeek_whence;

        public override long OnSeek(long offset, int whence)
        {
            OnSeek_be_trigger = true;
            OnSeek_offset = offset;
            OnSeek_whence = whence;
            return 0;

        }

        public bool OnSeekPassed(long offset, int whence)
        {

            if (OnSeek_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<long>(OnSeek_offset, offset) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnSeek_whence, whence) == false)
                return false;

            return true;
        }

        /////////////////////////////////
        #endregion terra IMediaPlayerCustomDataProvider
    }
}
