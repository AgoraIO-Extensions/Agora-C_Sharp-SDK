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
    using IrisRtcDeviceManagerPtr = IntPtr;
    using view_t = IntPtr;
    public sealed class AgoraRtcVideoDeviceManager : IAgoraRtcVideoDeviceManager
    {
        private bool _disposed;
        private IrisRtcDeviceManagerPtr _irisRtcDeviceManager;
        private CharAssistant _result;

        internal AgoraRtcVideoDeviceManager(IrisRtcDeviceManagerPtr irisRtcDeviceManager)
        {
            _result = new CharAssistant();
            _irisRtcDeviceManager = irisRtcDeviceManager;
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

            _irisRtcDeviceManager = IntPtr.Zero;
            _result = new CharAssistant();
            _disposed = true;
        }

        public override DeviceInfo[] EnumerateVideoDevices()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcVideoDeviceManagerApi(_irisRtcDeviceManager,
                ApiTypeVideoDeviceManager.kVDMEnumerateVideoDevices, JsonMapper.ToJson(param),
                out _result) != 0
                ? new DeviceInfo[0]
                : AgoraJson.JsonToStructArray<DeviceInfo>(_result.Result);
        }

        public override int SetDevice(string deviceIdUTF8)
        {
            var param = new
            {
                deviceIdUTF8
            };
            return AgoraRtcNative.CallIrisRtcVideoDeviceManagerApi(_irisRtcDeviceManager,
                ApiTypeVideoDeviceManager.kVDMSetDevice, JsonMapper.ToJson(param),
                out _result);
        }

        public override string GetDevice()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcVideoDeviceManagerApi(_irisRtcDeviceManager,
                            ApiTypeVideoDeviceManager.kVDMGetDevice, JsonMapper.ToJson(param),
                            out _result) != 0
                            ? null
                            : ((_result.Result.Length == 0) ? null : _result.Result);
        }

        public override int StartDeviceTest(view_t hwnd)
        {
            var param = new
            {
                hwnd = (ulong) hwnd
            };
            return AgoraRtcNative.CallIrisRtcVideoDeviceManagerApi(_irisRtcDeviceManager,
                ApiTypeVideoDeviceManager.kVDMStartDeviceTest, JsonMapper.ToJson(param),
                out _result);
        }

        public override int StopDeviceTest()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcVideoDeviceManagerApi(_irisRtcDeviceManager,
                ApiTypeVideoDeviceManager.kVDMStopDeviceTest, JsonMapper.ToJson(param),
                out _result);
        }

        // internal int CallIrisRtcVideoDeviceManagerApi(ApiTypeVideoDeviceManager apiType, string paramJson,
        //     out string result)
        // {
        //     var ret = AgoraRtcNative.CallIrisRtcVideoDeviceManagerApi(_irisRtcDeviceManager, apiType,
        //         paramJson, out _result);
        //     result = _result.Result;
        //     return ret;
        // }
    }
}
