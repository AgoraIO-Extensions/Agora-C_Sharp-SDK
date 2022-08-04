#if UNITY_WEBGL

using System;

namespace Agora.Rtc
{
    using IrisApiEnginePtr = System.Int32;
    using view_t = IntPtr;

    internal class VideoDeviceManagerImpl
    {
        private bool _disposed = false;
        private IrisApiEnginePtr _irisApiEngine;
        //private CharAssistant _result;

        internal VideoDeviceManagerImpl(IrisApiEnginePtr irisApiEngine)
        {
            //_result = new CharAssistant();
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

            _irisApiEngine = 0;
            //_result = new CharAssistant();
            _disposed = true;
        }

        public DeviceInfo[] EnumerateVideoDevices()
        {
            var result = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.FUNC_VIDEODEVICEMANAGER_ENUMERATEVIDEODEVICES,
                "", 0,
                IntPtr.Zero, 0);

            DeviceInfo[] deviceInfos = AgoraJson.JsonToStructArray<DeviceInfo>(result, "result");
            return deviceInfos;
        }

        public int SetDevice(string deviceIdUTF8)
        {
            var param = new
            {
                deviceIdUTF8
            };
            string jsonParam = AgoraJson.ToJson(param);
            var result = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.FUNC_VIDEODEVICEMANAGER_SETDEVICE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);

            return (int)AgoraJson.GetData<int>(result, "result");
        }

        public string GetDevice()
        {
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_VIDEODEVICEMANAGER_GETDEVICE,
                "", 0, IntPtr.Zero, 0);
            return (string)AgoraJson.GetData<string>(result, "result");
        }

        public int StartDeviceTest(view_t hwnd)
        {
            var param = new
            {
                hwnd = (ulong)hwnd
            };
            string jsonParam = AgoraJson.ToJson(param);
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_VIDEODEVICEMANAGER_STARTDEVICETEST,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int StopDeviceTest()
        {
            var param = new
            {

            };
            string jsonParam = AgoraJson.ToJson(param);
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_VIDEODEVICEMANAGER_STOPDEVICETEST,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            return (int)AgoraJson.GetData<int>(result, "result");
        }
    }
}


#endif
