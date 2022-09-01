using System;

namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;
    using view_t = IntPtr;

    internal class VideoDeviceManagerImpl
    {
        private bool _disposed = false;
        private IrisApiEnginePtr _irisApiEngine;
        private CharAssistant _result;

        internal VideoDeviceManagerImpl(IrisApiEnginePtr irisApiEngine)
        {
            _result = new CharAssistant();
            _irisApiEngine = irisApiEngine;
        }

        ~VideoDeviceManagerImpl()
        {
            Dispose(false);
        }

        internal void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
            }

            _irisApiEngine = IntPtr.Zero;
            _result = new CharAssistant();
            _disposed = true;
        }

        public DeviceInfo[] EnumerateVideoDevices()
        {
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_VIDEODEVICEMANAGER_ENUMERATEVIDEODEVICES,
                "", 0, IntPtr.Zero, 0, out _result) != 0
                ? new DeviceInfo[0]
                : AgoraJson.JsonToStructArray<DeviceInfo>(_result.Result, "result");
        }

        public int SetDevice(string deviceIdUTF8)
        {
            var param = new
            {
                deviceIdUTF8
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_VIDEODEVICEMANAGER_SETDEVICE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetDevice(ref string deviceIdUTF8)
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_VIDEODEVICEMANAGER_GETDEVICE,
                "", 0, IntPtr.Zero, 0, out _result);

            if (ret == 0)
            {
                deviceIdUTF8 = (string)AgoraJson.GetData<string>(_result.Result, "deviceIdUTF8");
            }
            else
            {
                deviceIdUTF8 = "";
            }

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int StartDeviceTest(view_t hwnd)
        {
            var param = new
            {
                hwnd = (ulong)hwnd
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_VIDEODEVICEMANAGER_STARTDEVICETEST,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int StopDeviceTest()
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_VIDEODEVICEMANAGER_STOPDEVICETEST,
                "", 0, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetCapability(string deviceIdUTF8, uint deviceCapabilityNumber, out VideoFormat capability)
        {
            var param = new
            {
                deviceIdUTF8,
                deviceCapabilityNumber
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
               AgoraApiType.FUNC_VIDEODEVICEMANAGER_GETCAPABILITY,
               jsonParam, 0, IntPtr.Zero, 0, out _result);


            if (ret == 0)
            {
                capability = AgoraJson.JsonToStruct<VideoFormat>(_result.Result, "capability");
            }
            else
            {
                capability = new VideoFormat();
            }

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int NumberOfCapabilities(string deviceIdUTF8)
        {
            var param = new
            {
                deviceIdUTF8,
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
               AgoraApiType.FUNC_VIDEODEVICEMANAGER_NUMBEROFCAPABILITIES,
               jsonParam, 0, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }
    }
}
