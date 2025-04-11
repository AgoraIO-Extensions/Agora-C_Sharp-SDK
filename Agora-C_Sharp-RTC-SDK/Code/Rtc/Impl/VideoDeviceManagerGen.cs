#region Generated by `terra/node/src/rtc/middle/renderers.ts`. DO NOT MODIFY BY HAND.
#endregion

#define AGORA_RTC
#define AGORA_RTM
using System;
using view_t = System.UInt64;

namespace Agora.Rtc
{
    public partial class VideoDeviceManager : IVideoDeviceManager
    {

        public override int SetDevice(string deviceIdUTF8)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.SetDevice(deviceIdUTF8);
        }

        public override int GetDevice(ref string deviceIdUTF8)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.GetDevice(ref deviceIdUTF8);
        }

        public override int NumberOfCapabilities(string deviceIdUTF8)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.NumberOfCapabilities(deviceIdUTF8);
        }

        public override int GetCapability(string deviceIdUTF8, uint deviceCapabilityNumber, ref VideoFormat capability)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.GetCapability(deviceIdUTF8, deviceCapabilityNumber, ref capability);
        }

        public override int StartDeviceTest(IntPtr hwnd)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.StartDeviceTest(hwnd);
        }

        public override int StopDeviceTest()
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.StopDeviceTest();
        }

    }
}