using System;

namespace Agora.Rtc
{
    public sealed class VideoDeviceManager : IVideoDeviceManager
    {
        private IRtcEngine _rtcEngineInstance = null;
        private VideoDeviceManagerImpl _videoDeviecManagerImpl = null;
        private const int ErrorCode = -7;

        private VideoDeviceManager(IRtcEngine rtcEngine, VideoDeviceManagerImpl impl)
        {
            _rtcEngineInstance = rtcEngine;
            _videoDeviecManagerImpl = impl;
        }

        ~VideoDeviceManager()
        {
            _rtcEngineInstance = null;
        }

        private static IVideoDeviceManager instance = null;
        public static IVideoDeviceManager Instance
        {
            get
            {
                return instance;
            }
        }

        public override DeviceInfo[] EnumerateVideoDevices()
        {
            if (_rtcEngineInstance == null || _videoDeviecManagerImpl == null)
            {
                return null;
            }
            return _videoDeviecManagerImpl.EnumerateVideoDevices();
        }

        public override int SetDevice(string deviceIdUTF8)
        {
            if (_rtcEngineInstance == null || _videoDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _videoDeviecManagerImpl.SetDevice(deviceIdUTF8);
        }

        public override int GetDevice(ref string deviceIdUTF8)
        {
            if (_rtcEngineInstance == null || _videoDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _videoDeviecManagerImpl.GetDevice(ref deviceIdUTF8);
        }

        public override int StartDeviceTest(IntPtr hwnd)
        {
            if (_rtcEngineInstance == null || _videoDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _videoDeviecManagerImpl.StartDeviceTest(hwnd);
        }

        public override int StopDeviceTest()
        {
            if (_rtcEngineInstance == null || _videoDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _videoDeviecManagerImpl.StopDeviceTest();
        }

        public override int GetCapability(string deviceIdUTF8, uint deviceCapabilityNumber, out VideoFormat capability)
        {
            if (_rtcEngineInstance == null || _videoDeviecManagerImpl == null)
            {
                capability = new VideoFormat();
                return ErrorCode;
            }
            return _videoDeviecManagerImpl.GetCapability(deviceIdUTF8, deviceCapabilityNumber, out capability);
        }

        public override int NumberOfCapabilities(string deviceIdUTF8)
        {
            if (_rtcEngineInstance == null || _videoDeviecManagerImpl == null)
            {
                return ErrorCode;
            }
            return _videoDeviecManagerImpl.NumberOfCapabilities(deviceIdUTF8);
        }

        internal static IVideoDeviceManager GetInstance(IRtcEngine rtcEngine, VideoDeviceManagerImpl impl)
        {
            return instance ?? (instance = new VideoDeviceManager(rtcEngine, impl));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }
    }
}