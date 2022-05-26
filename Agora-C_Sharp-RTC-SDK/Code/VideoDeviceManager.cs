using System;

namespace agora.rtc
{
    public sealed class VideoDeviceManager : IVideoDeviceManager
    {
        private static IVideoDeviceManager instance = null;
        private VideoDeviceManagerImpl _videoDeviecManagerImpl = null;
        private const string ErrorMsgLog = "[VideoDeviceManager]:IVideoDeviceManager has not been created yet!";
        private const int ErrorCode = -1;

        private VideoDeviceManager(VideoDeviceManagerImpl impl)
        {
            _videoDeviecManagerImpl = impl;
        }

        internal static IVideoDeviceManager GetInstance(VideoDeviceManagerImpl impl)
        {
            return instance ?? (instance = new VideoDeviceManager(impl));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }

        public override DeviceInfo[] EnumerateVideoDevices()
        {
            if (_videoDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return null;
            }
            return _videoDeviecManagerImpl.EnumerateVideoDevices();
        }

        public override int SetDevice(string deviceIdUTF8)
        {
            if (_videoDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _videoDeviecManagerImpl.SetDevice(deviceIdUTF8);
        }

        public override string GetDevice()
        {
            if (_videoDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return null;
            }
            return _videoDeviecManagerImpl.GetDevice();
        }

        public override int StartDeviceTest(IntPtr hwnd)
        {
            if (_videoDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _videoDeviecManagerImpl.StartDeviceTest(hwnd);
        }

        public override int StopDeviceTest()
        {
            if (_videoDeviecManagerImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _videoDeviecManagerImpl.StopDeviceTest();
        }
    }
}