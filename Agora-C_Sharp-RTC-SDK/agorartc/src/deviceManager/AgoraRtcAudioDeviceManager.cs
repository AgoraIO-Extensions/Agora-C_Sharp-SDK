//  AgoraRtcAudioDeviceManager.cs
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
    public sealed class AgoraRtcAudioPlaybackDeviceManager : IAgoraRtcAudioPlaybackDeviceManager
    {
        private bool _disposed;
        private IrisApiEnginePtr _irisApiEngine;
        private CharAssistant _result;

        internal AgoraRtcAudioPlaybackDeviceManager(IrisApiEnginePtr irisApiEngine)
        {
            _result = new CharAssistant();
            _irisApiEngine = irisApiEngine;
        }

        ~AgoraRtcAudioPlaybackDeviceManager()
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

        public override DeviceInfo[] EnumeratePlaybackDevices()
        {
            var param = new { };
            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
                ApiTypeAudioDeviceManager.kADMEnumeratePlaybackDevices,
                JsonMapper.ToJson(param), out _result) != 0
                ? new DeviceInfo[0]
                : AgoraJson.JsonToStructArray<DeviceInfo>(_result.Result);
        }

        public override int SetPlaybackDevice(string deviceId)
        {
            var param = new
            {
                deviceId
            };
            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
            ApiTypeAudioDeviceManager.kADMSetPlaybackDevice,
            JsonMapper.ToJson(param), out _result);
        }

        public override string GetPlaybackDevice()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
            ApiTypeAudioDeviceManager.kADMGetPlaybackDevice,
            JsonMapper.ToJson(param), out _result) != 0
            ? null
            : ((_result.Result.Length == 0) ? null : _result.Result);
        }

        public override DeviceInfo GetPlaybackDeviceInfo()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
            ApiTypeAudioDeviceManager.kADMGetPlaybackDeviceInfo,
            JsonMapper.ToJson(param), out _result) != 0
            ? new DeviceInfo()
            : AgoraJson.JsonToStruct<DeviceInfo>(_result.Result);
        }

        public override int SetPlaybackDeviceVolume(int volume)
        {
            var param = new 
            {
                volume
            };
            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
            ApiTypeAudioDeviceManager.kADMSetPlaybackDeviceVolume,
            JsonMapper.ToJson(param), out _result);
        }

        public override int GetPlaybackDeviceVolume()
        {
            var param = new {};
            AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
            ApiTypeAudioDeviceManager.kADMGetPlaybackDeviceVolume,
            JsonMapper.ToJson(param), out _result);
            return Convert.ToInt32(_result.Result);
        }

        public override int SetPlaybackDeviceMute(bool mute)
        {
            var param = new 
            {
                mute
            };
            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
            ApiTypeAudioDeviceManager.kADMSetPlaybackDeviceMute,
            JsonMapper.ToJson(param), out _result);
        }

        public override bool GetPlaybackDeviceMute()
        {
            var param = new {};
            AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
            ApiTypeAudioDeviceManager.kADMGetPlaybackDeviceMute,
            JsonMapper.ToJson(param), out _result);
            return Convert.ToBoolean(_result.Result);
        }

        public override int StartPlaybackDeviceTest(string testAudioFilePath)
        {
            var param = new 
            {
                testAudioFilePath
            };
            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
            ApiTypeAudioDeviceManager.kADMStartPlaybackDeviceTest,
            JsonMapper.ToJson(param), out _result);
        }

        public override int StopPlaybackDeviceTest()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
            ApiTypeAudioDeviceManager.kADMStopPlaybackDeviceTest,
            JsonMapper.ToJson(param), out _result);
        }

        public override int StartAudioDeviceLoopbackTest(int indicationInterval)
        {
            var param = new 
            {
                indicationInterval
            };
            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
            ApiTypeAudioDeviceManager.kADMStartAudioDeviceLoopbackTest,
            JsonMapper.ToJson(param), out _result);
        }

        public override int StopAudioDeviceLoopbackTest()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
            ApiTypeAudioDeviceManager.kADMStopAudioDeviceLoopbackTest, 
            JsonMapper.ToJson(param), out _result);
        }

        // internal int CallIrisRtcAudioDeviceManagerApi(ApiTypeAudioDeviceManager apiType, string paramJson,
        //     out string result)
        // {
        //     var ret = AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager, apiType,
        //         paramJson, out _result);
        //     result = _result.Result;
        //     return ret;
        // }
    }

    public sealed class AgoraRtcAudioRecordingDeviceManager : IAgoraRtcAudioRecordingDeviceManager
    {
        private bool _disposed;
        private IrisApiEnginePtr _irisApiEngine;
        private CharAssistant _result;

        internal AgoraRtcAudioRecordingDeviceManager(IrisApiEnginePtr irisApiEngine)
        {
            _result = new CharAssistant();
            _irisApiEngine = irisApiEngine;
        }

        ~AgoraRtcAudioRecordingDeviceManager()
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

        public override DeviceInfo[] EnumerateRecordingDevices()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
            ApiTypeAudioDeviceManager.kADMEnumerateRecordingDevices,
            JsonMapper.ToJson(param), out _result) != 0
                ? new DeviceInfo[0]
                : AgoraJson.JsonToStructArray<DeviceInfo>(_result.Result);
        }

        public override int SetRecordingDevice(string deviceId)
        {
            var param = new 
            {
                deviceId
            };
            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
            ApiTypeAudioDeviceManager.kADMSetRecordingDevice,
            JsonMapper.ToJson(param), out _result);
        }

        public override string GetRecordingDevice()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
            ApiTypeAudioDeviceManager.kADMGetRecordingDevice,
            JsonMapper.ToJson(param), out _result) != 0
            ? null
            : ((_result.Result.Length == 0) ? null : _result.Result);
        }

        public override DeviceInfo GetRecordingDeviceInfo()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
            ApiTypeAudioDeviceManager.kADMGetRecordingDeviceInfo,
            JsonMapper.ToJson(param), out _result) != 0
            ? new DeviceInfo()
            : AgoraJson.JsonToStruct<DeviceInfo>(_result.Result);
        }

        public override int SetRecordingDeviceVolume(int volume)
        {
            var param = new 
            {
                volume
            };
            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
            ApiTypeAudioDeviceManager.kADMSetRecordingDeviceVolume,
            JsonMapper.ToJson(param), out _result);
        }

        public override int GetRecordingDeviceVolume()
        {
            var param = new {};
            AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
            ApiTypeAudioDeviceManager.kADMGetRecordingDeviceVolume,
            JsonMapper.ToJson(param), out _result);
            return Convert.ToInt32(_result.Result);
        }

        public override int SetRecordingDeviceMute(bool mute)
        {
            var param = new 
            {
                mute
            };
            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
            ApiTypeAudioDeviceManager.kADMSetRecordingDeviceMute,
            JsonMapper.ToJson(param), out _result);
        }

        public override bool GetRecordingDeviceMute()
        {
            var param = new {};
            AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
            ApiTypeAudioDeviceManager.kADMGetRecordingDeviceMute,
            JsonMapper.ToJson(param), out _result);
            return Convert.ToBoolean(_result.Result);
        }

        public override int StartRecordingDeviceTest(int indicationInterval)
        {
            var param = new 
            {
                indicationInterval
            };
            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
            ApiTypeAudioDeviceManager.kADMStartRecordingDeviceTest,
            JsonMapper.ToJson(param), out _result);
        }

        public override int StopRecordingDeviceTest()
        {
            var param = new {};
            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
            ApiTypeAudioDeviceManager.kADMStopRecordingDeviceTest,
            JsonMapper.ToJson(param), out _result);
        }

        // public override int startAudioDeviceLoopbackTest(int indicationInterval)
        // {
        //     var param = new 
        //     {
        //         indicationInterval
        //     };
        //     return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
        //     ApiTypeAudioDeviceManager.kADMStartAudioDeviceLoopbackTest,
        //     JsonMapper.ToJson(param), out _result);
        // }

        // public override int stopAudioDeviceLoopbackTest()
        // {
        //     var param = new {};
        //     return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
        //     ApiTypeAudioDeviceManager.kADMStopAudioDeviceLoopbackTest,
        //     JsonMapper.ToJson(param), out _result);
        // }

        // internal int CallIrisRtcAudioDeviceManagerApi(ApiTypeAudioDeviceManager apiType, string paramJson,
        //     out string result)
        // {
        //     var ret = AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager, apiType,
        //         paramJson, out _result);
        //     result = _result.Result;
        //     return ret;
        // }
    }
}