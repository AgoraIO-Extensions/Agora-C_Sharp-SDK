using System;
using System.Collections.Generic;
namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;
    using view_t = IntPtr;

    internal class VideoDeviceManagerImpl
    {
        private bool _disposed = false;
        private IrisApiEnginePtr _irisApiEngine;
        private IrisCApiParam _apiParam;
        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

        internal VideoDeviceManagerImpl(IrisApiEnginePtr irisApiEngine)
        {
            _apiParam = new IrisCApiParam();
            _apiParam.AllocResult();
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
            _apiParam.FreeResult();
            _disposed = true;
        }

        public DeviceInfo[] EnumerateVideoDevices()
        {
            return AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_VIDEODEVICEMANAGER_ENUMERATEVIDEODEVICES,
                "", 0, IntPtr.Zero, 0, ref _apiParam) != 0
                ? new DeviceInfo[0]
                : AgoraJson.JsonToStructArray<DeviceInfo>(_apiParam.Result, "result");
        }

        public int SetDevice(string deviceIdUTF8)
        {
            _param.Clear();
            _param.Add("deviceIdUTF8", deviceIdUTF8);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_VIDEODEVICEMANAGER_SETDEVICE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetDevice(ref string deviceIdUTF8)
        {
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_VIDEODEVICEMANAGER_GETDEVICE,
                "", 0, IntPtr.Zero, 0, ref _apiParam);

            if (ret == 0)
            {
                deviceIdUTF8 = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceIdUTF8");
            }
            else
            {
                deviceIdUTF8 = "";
            }

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartDeviceTest(view_t hwnd)
        {
            _param.Clear();
            _param.Add("hwnd", (ulong)hwnd);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_VIDEODEVICEMANAGER_STARTDEVICETEST,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopDeviceTest()
        {
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_VIDEODEVICEMANAGER_STOPDEVICETEST,
                "", 0, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetCapability(string deviceIdUTF8, uint deviceCapabilityNumber, out VideoFormat capability)
        {
            _param.Clear();
            _param.Add("deviceIdUTF8", deviceIdUTF8);
            _param.Add("deviceCapabilityNumber", deviceCapabilityNumber);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
               AgoraApiType.FUNC_VIDEODEVICEMANAGER_GETCAPABILITY,
               jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);


            if (ret == 0)
            {
                capability = AgoraJson.JsonToStruct<VideoFormat>(_apiParam.Result, "capability");
            }
            else
            {
                capability = new VideoFormat();
            }

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int NumberOfCapabilities(string deviceIdUTF8)
        {
            _param.Clear();
            _param.Add("deviceIdUTF8", deviceIdUTF8);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
               AgoraApiType.FUNC_VIDEODEVICEMANAGER_NUMBEROFCAPABILITIES,
               jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }
    }
}
