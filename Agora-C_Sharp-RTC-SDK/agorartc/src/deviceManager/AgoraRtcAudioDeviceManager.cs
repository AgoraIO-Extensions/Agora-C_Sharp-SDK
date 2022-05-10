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
        private bool _disposed = false;
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
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_ENUMERATEPLAYBACKDEVICES,
                "", 0, null, 0, out _result) != 0
                ? new DeviceInfo[0]
                : AgoraJson.JsonToStructArray<DeviceInfo>(_result.Result);
        }

        public override int SetPlaybackDevice(string deviceId)
        {
            var param = new
            {
                deviceId
            };
            string jsonParam = JsonMapper.ToJson(param);
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETPLAYBACKDEVICE,
                jsonParam, jsonParam.Length, null, 0, out _result);
        }

        public override string GetPlaybackDevice()
        {
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICE,
                "", 0, null, 0, out _result) != 0
                ? null
                : ((_result.Result.Length == 0) ? null : _result.Result);
        }

        public override DeviceInfo GetPlaybackDeviceInfo()
        {
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICEINFO,
                "", 0, null, 0, out _result) != 0
                ? new DeviceInfo()
                : AgoraJson.JsonToStruct<DeviceInfo>(_result.Result);
        }

        public override int SetPlaybackDeviceVolume(int volume)
        {
            var param = new 
            {
                volume
            };
            string jsonParam = JsonMapper.ToJson(param);
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETPLAYBACKDEVICEVOLUME,
                jsonParam, jsonParam.Length, null, 0, out _result);
        }

        public override int GetPlaybackDeviceVolume()
        {
            //TODO CHECK
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICEVOLUME,
                jsonParam, jsonParam.Length, null, 0, out _result);
            if (ret != 0)
            {
                return ret;
            }
            return Convert.ToInt32(_result.Result);
        }

        public override int SetPlaybackDeviceMute(bool mute)
        {
            var param = new 
            {
                mute
            };
            string jsonParam = JsonMapper.ToJson(param);
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETPLAYBACKDEVICEMUTE,
                jsonParam, jsonParam.Length, null, 0, out _result);
        }

        public override bool GetPlaybackDeviceMute()
        {
            //TODO CHECK
            AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICEMUTE,
                jsonParam, jsonParam.Length, null, 0, out _result);
            return Convert.ToBoolean(_result.Result);
        }

        public override int StartPlaybackDeviceTest(string testAudioFilePath)
        {
            var param = new 
            {
                testAudioFilePath
            };
            string jsonParam = JsonMapper.ToJson(param);
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STARTPLAYBACKDEVICETEST,
                jsonParam, jsonParam.Length, null, 0, out _result);
        }

        public override int StopPlaybackDeviceTest()
        {
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STOPPLAYBACKDEVICETEST,
                "", 0, null, 0, out _result);
        }

        public override int StartAudioDeviceLoopbackTest(int indicationInterval)
        {
            var param = new 
            {
                indicationInterval
            };
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STARTAUDIODEVICELOOPBACKTEST,
                jsonParam, jsonParam.Length, null, 0, out _result);
        }

        public override int StopAudioDeviceLoopbackTest()
        {
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STOPAUDIODEVICELOOPBACKTEST,
                "", 0, null, 0, out _result);
        }
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
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_ENUMERATERECORDINGDEVICES,
                "", 0, null, 0, out _result) != 0
                ? new DeviceInfo[0]
                : AgoraJson.JsonToStructArray<DeviceInfo>(_result.Result);
        }

        public override int SetRecordingDevice(string deviceId)
        {
            var param = new 
            {
                deviceId
            };
            string jsonParam = JsonMapper.ToJson(param);
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETRECORDINGDEVICE,
                jsonParam, jsonParam.Length, null, 0, out _result);
        }

        public override string GetRecordingDevice()
        {
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICE,
                "", 0, null, 0, out _result) != 0
                ? null
                : ((_result.Result.Length == 0) ? null : _result.Result);
        }

        public override DeviceInfo GetRecordingDeviceInfo()
        {
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICEINFO,
                "", 0, null, 0, out _result) != 0
                ? new DeviceInfo()
                : AgoraJson.JsonToStruct<DeviceInfo>(_result.Result);
        }

        public override int SetRecordingDeviceVolume(int volume)
        {
            var param = new 
            {
                volume
            };
            string jsonParam = JsonMapper.ToJson(param);
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETRECORDINGDEVICEVOLUME,
                jsonParam, jsonParam.Length, null, 0, out _result);
        }

        public override int GetRecordingDeviceVolume()
        {
            //TODO CHECK
            AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICEVOLUME,
                "", 0, null, 0, out _result);
            return Convert.ToInt32(_result.Result);
        }

        public override int SetRecordingDeviceMute(bool mute)
        {
            var param = new 
            {
                mute
            };
            string jsonParam = JsonMapper.ToJson(param);
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETRECORDINGDEVICEMUTE,
                jsonParam, jsonParam.Length, null, 0, out _result);
        }

        public override bool GetRecordingDeviceMute()
        {
            //TODO CHECK
            AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICEMUTE,
                "", 0, null, 0, out _result);
            return Convert.ToBoolean(_result.Result);
        }

        public override int StartRecordingDeviceTest(int indicationInterval)
        {
            var param = new 
            {
                indicationInterval
            };
            string jsonParam = JsonMapper.ToJson(param);
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STARTRECORDINGDEVICETEST,
                jsonParam, jsonParam.Length, null, 0, out _result);
        }

        public override int StopRecordingDeviceTest()
        {
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STOPRECORDINGDEVICETEST,
                "", 0, null, 0, out _result);
        }
    }
}