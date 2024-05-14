using System;
using System.Collections.Generic;
namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;

    internal class VideoDeviceManagerImpl
    {
        private bool _disposed = false;
        private IrisApiEnginePtr _irisApiEngine;
        private IrisRtcCApiParam _apiParam;
        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

        internal VideoDeviceManagerImpl(IrisApiEnginePtr irisApiEngine)
        {
            _apiParam = new IrisRtcCApiParam();
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
            if (_disposed)
                return;

            if (disposing)
            {
            }

            _irisApiEngine = IntPtr.Zero;
            _apiParam.FreeResult();
            _disposed = true;
        }

        public DeviceInfo[] EnumerateVideoDevices()
        {
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                                                          AgoraApiType.FUNC_VIDEODEVICEMANAGER_ENUMERATEVIDEODEVICES,
                                                          "", 0, IntPtr.Zero, 0, ref _apiParam);
            if (nRet != 0)
            {
                return new DeviceInfo[0];
            }
            return AgoraJson.JsonToStructArray<DeviceInfo>(_apiParam.Result, "result");
        }

        #region terra IVideoDeviceManager
        public int SetDevice(string deviceIdUTF8)
        {
            _param.Clear();
            _param.Add("deviceIdUTF8", deviceIdUTF8);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_VIDEODEVICEMANAGER_SETDEVICE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetDevice(ref string deviceIdUTF8)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_VIDEODEVICEMANAGER_GETDEVICE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                deviceIdUTF8 = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceIdUTF8");
            }
            return result;
        }

        public int NumberOfCapabilities(string deviceIdUTF8)
        {
            _param.Clear();
            _param.Add("deviceIdUTF8", deviceIdUTF8);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_VIDEODEVICEMANAGER_NUMBEROFCAPABILITIES,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetCapability(string deviceIdUTF8, uint deviceCapabilityNumber, ref VideoFormat capability)
        {
            _param.Clear();
            _param.Add("deviceIdUTF8", deviceIdUTF8);
            _param.Add("deviceCapabilityNumber", deviceCapabilityNumber);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_VIDEODEVICEMANAGER_GETCAPABILITY,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                capability = AgoraJson.JsonToStruct<VideoFormat>(_apiParam.Result, "capability");
            }
            return result;
        }

        public int StartDeviceTest(IntPtr hwnd)
        {
            _param.Clear();
            _param.Add("hwnd", hwnd);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_VIDEODEVICEMANAGER_STARTDEVICETEST,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopDeviceTest()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_VIDEODEVICEMANAGER_STOPDEVICETEST,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }


        #endregion terra IVideoDeviceManager
    }
}
