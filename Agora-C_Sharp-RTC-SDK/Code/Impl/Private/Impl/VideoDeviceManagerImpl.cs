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
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public string GetDevice()
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_VIDEODEVICEMANAGER_GETDEVICE,
                "", 0, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret.ToString() : (string) AgoraJson.GetData<string>(_result.Result, "result");
        }

        public int StartDeviceTest(view_t hwnd)
        {
            var param = new
            {
                hwnd = (ulong) hwnd
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_VIDEODEVICEMANAGER_STARTDEVICETEST,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int StopDeviceTest()
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_VIDEODEVICEMANAGER_STOPDEVICETEST,
                "", 0, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }
    }
}
