//  AgoraRtcVideoDeviceManager.cs
//
//  Created by YuGuo Chen on October 5, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;

namespace agora.rtc
{
    using LitJson;
    using IrisApiEnginePtr = IntPtr;
    using view_t = IntPtr;
    public sealed class AgoraRtcVideoDeviceManager : IAgoraRtcVideoDeviceManager
    {
        private bool _disposed = false;
        private IrisApiEnginePtr _irisApiEngine;
        private CharAssistant _result;

        internal AgoraRtcVideoDeviceManager(IrisApiEnginePtr irisApiEngine)
        {
            _result = new CharAssistant();
            _irisApiEngine = irisApiEngine;
        }

        ~AgoraRtcVideoDeviceManager()
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

        public override DeviceInfo[] EnumerateVideoDevices()
        {
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_VIDEODEVICEMANAGER_ENUMERATEVIDEODEVICES,
                "", 0, null, 0, out _result) != 0
                ? new DeviceInfo[0]
                : AgoraJson.JsonToStructArray<DeviceInfo>(_result.Result);
        }

        public override int SetDevice(string deviceIdUTF8)
        {
            var param = new
            {
                deviceIdUTF8
            };
            string jsonParam = JsonMapper.ToJson(param);
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_VIDEODEVICEMANAGER_SETDEVICE,
                jsonParam, jsonParam.Length, null, 0, out _result);
        }

        public override string GetDevice()
        {
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_VIDEODEVICEMANAGER_GETDEVICE,
                "", 0, null, 0, out _result) != 0
                ? null
                : ((_result.Result.Length == 0) ? null : _result.Result);
        }

        public override int StartDeviceTest(view_t hwnd)
        {
            var param = new
            {
                hwnd = (ulong) hwnd
            };
            string jsonParam = JsonMapper.ToJson(param);
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_VIDEODEVICEMANAGER_STARTDEVICETEST,
                jsonParam, jsonParam.Length, null, 0, out _result);
        }

        public override int StopDeviceTest()
        {
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_VIDEODEVICEMANAGER_STOPDEVICETEST,
                "", 0, null, 0, out _result);
        }
    }
}
