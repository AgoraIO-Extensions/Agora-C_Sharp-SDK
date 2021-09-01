//  AgoraRtcVideoDeviceManager.cs
//
//  Created by Yiqing Huang on June 2, 2021.
//  Modified by Yiqing Huang on July 12, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;


namespace agora.rtc
{
    using LitJson;
    using view_t = IntPtr;
    using IrisRtcDeviceManagerPtr = IntPtr;

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

        internal void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
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

        public override int SetDevice(string deviceId)
        {
            var param = new
            {
                deviceId
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

        internal int CallIrisRtcVideoDeviceManagerApi(ApiTypeVideoDeviceManager apiType, string paramJson,
            out string result)
        {
            var ret = AgoraRtcNative.CallIrisRtcVideoDeviceManagerApi(_irisRtcDeviceManager, apiType,
                paramJson, out _result);
            result = _result.Result;
            return ret;
        }

        ~AgoraRtcVideoDeviceManager()
        {
            Dispose(false);
        }
    }

    [Obsolete]
    public sealed class VideoDeviceManager : IVideoDeviceManager
    {
        private bool _disposed;
        private AgoraRtcVideoDeviceManager _agoraRtcVideoDeviceManager;

        internal VideoDeviceManager(AgoraRtcVideoDeviceManager agoraRtcVideoDeviceManager)
        {
            _agoraRtcVideoDeviceManager = agoraRtcVideoDeviceManager;
        }

        [Obsolete(ObsoleteMethodWarning.GeneralStructureWarning, true)]
        public override bool CreateAVideoDeviceManager()
        {
            return _agoraRtcVideoDeviceManager != null;
        }

        [Obsolete(ObsoleteMethodWarning.GeneralStructureWarning, true)]
        public override int ReleaseAVideoDeviceManager()
        {
            return (int) ERROR_CODE_TYPE.ERR_FAILED;
        }

        internal void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
            }

            _agoraRtcVideoDeviceManager = null;
            _disposed = true;
        }

        [Obsolete(ObsoleteMethodWarning.StartVideoDeviceTestWarning, false)]
        public override int StartVideoDeviceTest(IntPtr hwnd)
        {
            return _agoraRtcVideoDeviceManager.StartDeviceTest(hwnd);
        }

        [Obsolete(ObsoleteMethodWarning.StopVideoDeviceTestWarning, false)]
        public override int StopVideoDeviceTest()
        {
            return _agoraRtcVideoDeviceManager.StopDeviceTest();
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int GetVideoDeviceCount()
        {
            return _agoraRtcVideoDeviceManager.EnumerateVideoDevices().Length;
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int GetVideoDevice(int index, ref string deviceName, ref string deviceId)
        {
            var videoDevices = _agoraRtcVideoDeviceManager.EnumerateVideoDevices();
            if (index < 0 || index >= videoDevices.Length)
            {
                return (int) ERROR_CODE_TYPE.ERR_INVALID_ARGUMENT;
            }

            deviceName = videoDevices[index].deviceName;
            deviceId = videoDevices[index].deviceId;
            return (int) ERROR_CODE_TYPE.ERR_OK;
        }

        [Obsolete(ObsoleteMethodWarning.SetVideoDeviceWarning, false)]
        public override int SetVideoDevice(string deviceId)
        {
            return _agoraRtcVideoDeviceManager.SetDevice(deviceId);
        }

        [Obsolete(ObsoleteMethodWarning.GetCurrentVideoDeviceWarning, false)]
        public override int GetCurrentVideoDevice(ref string deviceId)
        {
            var param = new { };
            return _agoraRtcVideoDeviceManager.CallIrisRtcVideoDeviceManagerApi(
                ApiTypeVideoDeviceManager.kVDMGetDevice, JsonMapper.ToJson(param), out deviceId);
        }

        ~VideoDeviceManager()
        {
            Dispose(false);
        }
    }
}