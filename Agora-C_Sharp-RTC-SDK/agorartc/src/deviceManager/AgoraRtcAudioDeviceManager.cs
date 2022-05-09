//  AgoraRtcAudioDeviceManager.cs
//
//  Created by Yiqing Huang on June 8, 2021.
//  Modified by Yiqing Huang on July 12, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;

namespace agora.rtc
{
    using LitJson;
    using IrisRtcDeviceManagerPtr = IntPtr;

    public sealed class AgoraRtcAudioPlaybackDeviceManager : IAgoraRtcAudioPlaybackDeviceManager
    {
        private bool _disposed;
        private IrisRtcDeviceManagerPtr _irisRtcDeviceManager;
        private CharAssistant _result;

        internal AgoraRtcAudioPlaybackDeviceManager(IrisRtcDeviceManagerPtr irisRtcDeviceManager)
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
            var param = new { };

            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
                ApiTypeAudioDeviceManager.kADMStopPlaybackDeviceTest,
                JsonMapper.ToJson(param), out _result);
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
            var param = new { };

            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
                ApiTypeAudioDeviceManager.kADMGetPlaybackDeviceVolume,
                JsonMapper.ToJson(param), out _result);
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
            var param = new { };

            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
                ApiTypeAudioDeviceManager.kADMGetPlaybackDeviceMute,
                JsonMapper.ToJson(param), out _result) == 1;
        }

        public override string GetPlaybackDevice()
        {
            var param = new { };

            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
                ApiTypeAudioDeviceManager.kADMGetPlaybackDevice,
                JsonMapper.ToJson(param), out _result) != 0
                ? null
                : ((_result.Result.Length == 0) ? null : _result.Result);
        }

        public override DeviceInfo GetPlaybackDeviceInfo()
        {
            var param = new { };

            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
                ApiTypeAudioDeviceManager.kADMGetPlaybackDeviceInfo,
                JsonMapper.ToJson(param), out _result) != 0
                ? new DeviceInfo()
                : AgoraJson.JsonToStruct<DeviceInfo>(_result.Result);
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
            var param = new { };

            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
                ApiTypeAudioDeviceManager.kADMStopAudioDeviceLoopbackTest,
                JsonMapper.ToJson(param), out _result);
        }

        public override int FollowSystemPlaybackDevice(bool enable)
        {
            var param = new { enable };

            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
                ApiTypeAudioDeviceManager.kADMFollowSystemPlaybackDevice,
                JsonMapper.ToJson(param), out _result);
        }

        internal int CallIrisRtcAudioDeviceManagerApi(ApiTypeAudioDeviceManager apiType, string paramJson,
            out string result)
        {
            var ret = AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager, apiType,
                paramJson, out _result);
            result = _result.Result;
            return ret;
        }

        ~AgoraRtcAudioPlaybackDeviceManager()
        {
            Dispose(false);
        }
    }

    public sealed class AgoraRtcAudioRecordingDeviceManager : IAgoraRtcAudioRecordingDeviceManager
    {
        private bool _disposed;
        private IrisRtcDeviceManagerPtr _irisRtcDeviceManager;
        private CharAssistant _result;

        internal AgoraRtcAudioRecordingDeviceManager(IrisRtcDeviceManagerPtr irisRtcDeviceManager)
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
        
        public override DeviceInfo[] EnumerateRecordingDevices()
        {
            var param = new { };

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
            var param = new { };

            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
                ApiTypeAudioDeviceManager.kADMGetRecordingDeviceVolume,
                JsonMapper.ToJson(param), out _result);
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
            var param = new { };

            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
                ApiTypeAudioDeviceManager.kADMGetRecordingDeviceMute,
                JsonMapper.ToJson(param), out _result) == 1;
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
            var param = new { };

            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
                ApiTypeAudioDeviceManager.kADMStopRecordingDeviceTest,
                JsonMapper.ToJson(param), out _result);
        }

        public override string GetRecordingDevice()
        {
            var param = new { };

            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
                ApiTypeAudioDeviceManager.kADMGetRecordingDevice,
                JsonMapper.ToJson(param), out _result) != 0
                ? null
                : ((_result.Result.Length == 0) ? null : _result.Result);
        }

        public override DeviceInfo GetRecordingDeviceInfo()
        {
            var param = new { };

            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
                ApiTypeAudioDeviceManager.kADMGetRecordingDeviceInfo,
                JsonMapper.ToJson(param), out _result) != 0
                ? new DeviceInfo()
                : AgoraJson.JsonToStruct<DeviceInfo>(_result.Result);
        }

        public override int FollowSystemRecordingDevice(bool enable)
        {
            var param = new { enable };

            return AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager,
                ApiTypeAudioDeviceManager.kADMFollowSystemRecordingDevice,
                JsonMapper.ToJson(param), out _result);
        }

        internal int CallIrisRtcAudioDeviceManagerApi(ApiTypeAudioDeviceManager apiType, string paramJson,
            out string result)
        {
            var ret = AgoraRtcNative.CallIrisRtcAudioDeviceManagerApi(_irisRtcDeviceManager, apiType,
                paramJson, out _result);
            result = _result.Result;
            return ret;
        }
        
        ~AgoraRtcAudioRecordingDeviceManager()
        {
            Dispose(false);
        }
    }

    [Obsolete]
    public sealed class AudioPlaybackDeviceManager : IAudioPlaybackDeviceManager
    {
        private bool _disposed;
        private AgoraRtcAudioPlaybackDeviceManager _agoraRtcAudioPlaybackDeviceManager;

        internal AudioPlaybackDeviceManager(AgoraRtcAudioPlaybackDeviceManager agoraRtcAudioPlaybackDeviceManager)
        {
            _agoraRtcAudioPlaybackDeviceManager = agoraRtcAudioPlaybackDeviceManager;
        }

        [Obsolete(ObsoleteMethodWarning.GeneralStructureWarning, true)]
        public override bool CreateAAudioPlaybackDeviceManager()
        {
            return _agoraRtcAudioPlaybackDeviceManager != null;
        }

        [Obsolete(ObsoleteMethodWarning.GeneralStructureWarning, true)]
        public override int ReleaseAAudioPlaybackDeviceManager()
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

            _agoraRtcAudioPlaybackDeviceManager = null;
            _disposed = true;
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int GetAudioPlaybackDeviceCount()
        {
            return _agoraRtcAudioPlaybackDeviceManager.EnumeratePlaybackDevices().Length;
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int GetAudioPlaybackDevice(int index, ref string deviceName, ref string deviceId)
        {
            var audioDevices = _agoraRtcAudioPlaybackDeviceManager.EnumeratePlaybackDevices();
            if (index < 0 || index >= audioDevices.Length)
            {
                return (int) ERROR_CODE_TYPE.ERR_INVALID_ARGUMENT;
            }

            deviceName = audioDevices[index].deviceName;
            deviceId = audioDevices[index].deviceId;
            return (int) ERROR_CODE_TYPE.ERR_OK;
        }

        [Obsolete(ObsoleteMethodWarning.SetAudioPlaybackDeviceWarning, false)]
        public override int SetAudioPlaybackDevice(string deviceId)
        {
            return _agoraRtcAudioPlaybackDeviceManager.SetPlaybackDevice(deviceId);
        }

        [Obsolete(ObsoleteMethodWarning.SetAudioPlaybackDeviceVolumeWarning, false)]
        public override int SetAudioPlaybackDeviceVolume(int volume)
        {
            return _agoraRtcAudioPlaybackDeviceManager.SetPlaybackDeviceVolume(volume);
        }

        [Obsolete(ObsoleteMethodWarning.GetAudioPlaybackDeviceVolumeWarning, false)]
        public override int GetAudioPlaybackDeviceVolume()
        {
            return _agoraRtcAudioPlaybackDeviceManager.GetPlaybackDeviceVolume();
        }

        [Obsolete(ObsoleteMethodWarning.SetAudioPlaybackDeviceMuteWarning, false)]
        public override int SetAudioPlaybackDeviceMute(bool mute)
        {
            return _agoraRtcAudioPlaybackDeviceManager.SetPlaybackDeviceMute(mute);
        }

        [Obsolete(ObsoleteMethodWarning.IsAudioPlaybackDeviceMuteWarning, false)]
        public override bool IsAudioPlaybackDeviceMute()
        {
            return _agoraRtcAudioPlaybackDeviceManager.GetPlaybackDeviceMute();
        }

        [Obsolete(ObsoleteMethodWarning.StartAudioPlaybackDeviceTestWarning, false)]
        public override int StartAudioPlaybackDeviceTest(string testAudioFilePath)
        {
            return _agoraRtcAudioPlaybackDeviceManager.StartPlaybackDeviceTest(testAudioFilePath);
        }

        [Obsolete(ObsoleteMethodWarning.StopAudioPlaybackDeviceTestWarning, false)]
        public override int StopAudioPlaybackDeviceTest()
        {
            return _agoraRtcAudioPlaybackDeviceManager.StopAudioDeviceLoopbackTest();
        }

        [Obsolete(ObsoleteMethodWarning.GetCurrentPlaybackDeviceWarning, false)]
        public override int GetCurrentPlaybackDevice(ref string deviceId)
        {
            var param = new { };
            return _agoraRtcAudioPlaybackDeviceManager.CallIrisRtcAudioDeviceManagerApi(
                ApiTypeAudioDeviceManager.kADMGetPlaybackDevice, JsonMapper.ToJson(param), out deviceId);
        }

        [Obsolete(ObsoleteMethodWarning.GetCurrentPlaybackDeviceInfoWarning, false)]
        public override int GetCurrentPlaybackDeviceInfo(ref string deviceName, ref string deviceId)
        {
            var param = new { };
            string result;
            var ret = _agoraRtcAudioPlaybackDeviceManager.CallIrisRtcAudioDeviceManagerApi(
                ApiTypeAudioDeviceManager.kADMGetPlaybackDeviceInfo, JsonMapper.ToJson(param), out result);
            if (result.Length <= 0) return ret;
            deviceName = (string) AgoraJson.GetData<string>(result, "deviceName");
            deviceId = (string) AgoraJson.GetData<string>(result, "deviceId");
            return ret;
        }

        ~AudioPlaybackDeviceManager()
        {
            Dispose(false);
        }
    }

    [Obsolete]
    public sealed class AudioRecordingDeviceManager : IAudioRecordingDeviceManager
    {
        private bool _disposed;
        private AgoraRtcAudioRecordingDeviceManager _agoraRtcAudioRecordingDeviceManager;

        internal AudioRecordingDeviceManager(AgoraRtcAudioRecordingDeviceManager agoraRtcAudioRecordingDeviceManager)
        {
            _agoraRtcAudioRecordingDeviceManager = agoraRtcAudioRecordingDeviceManager;
        }
        
        [Obsolete(ObsoleteMethodWarning.GeneralStructureWarning, true)]
        public override bool CreateAAudioRecordingDeviceManager()
        {
            return _agoraRtcAudioRecordingDeviceManager != null;
        }

        [Obsolete(ObsoleteMethodWarning.GeneralStructureWarning, true)]
        public override int ReleaseAAudioRecordingDeviceManager()
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

            _agoraRtcAudioRecordingDeviceManager = null;
            _disposed = true;
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int GetAudioRecordingDeviceCount()
        {
            return _agoraRtcAudioRecordingDeviceManager.EnumerateRecordingDevices().Length;
        }

        [Obsolete(ObsoleteMethodWarning.GeneralWarning, false)]
        public override int GetAudioRecordingDevice(int index, ref string audioRecordingDeviceName,
            ref string audioRecordingDeviceId)
        {
            var audioDevices = _agoraRtcAudioRecordingDeviceManager.EnumerateRecordingDevices();
            if (index < 0 || index >= audioDevices.Length)
            {
                return (int) ERROR_CODE_TYPE.ERR_INVALID_ARGUMENT;
            }

            audioRecordingDeviceName = audioDevices[index].deviceName;
            audioRecordingDeviceId = audioDevices[index].deviceId;
            return (int) ERROR_CODE_TYPE.ERR_OK;
        }

        [Obsolete(ObsoleteMethodWarning.SetAudioRecordingDeviceWarning, false)]
        public override int SetAudioRecordingDevice(string deviceId)
        {
            return _agoraRtcAudioRecordingDeviceManager.SetRecordingDevice(deviceId);
        }

        [Obsolete(ObsoleteMethodWarning.StartAudioRecordingDeviceTestWarning, false)]
        public override int StartAudioRecordingDeviceTest(int indicationInterval)
        {
            return _agoraRtcAudioRecordingDeviceManager.StartRecordingDeviceTest(indicationInterval);
        }

        [Obsolete(ObsoleteMethodWarning.StopAudioRecordingDeviceTestWarning, false)]
        public override int StopAudioRecordingDeviceTest()
        {
            return _agoraRtcAudioRecordingDeviceManager.StopRecordingDeviceTest();
        }

        [Obsolete(ObsoleteMethodWarning.GetCurrentRecordingDeviceWarning, false)]
        public override int GetCurrentRecordingDevice(ref string deviceId)
        {
            var param = new { };
            return _agoraRtcAudioRecordingDeviceManager.CallIrisRtcAudioDeviceManagerApi(
                ApiTypeAudioDeviceManager.kADMGetRecordingDevice, JsonMapper.ToJson(param), out deviceId);
        }

        [Obsolete(ObsoleteMethodWarning.SetAudioRecordingDeviceVolumeWarning, false)]
        public override int SetAudioRecordingDeviceVolume(int volume)
        {
            return _agoraRtcAudioRecordingDeviceManager.SetRecordingDeviceVolume(volume);
        }

        [Obsolete(ObsoleteMethodWarning.GetAudioRecordingDeviceVolumeWarning, false)]
        public override int GetAudioRecordingDeviceVolume()
        {
            return _agoraRtcAudioRecordingDeviceManager.GetRecordingDeviceVolume();
        }

        [Obsolete(ObsoleteMethodWarning.SetAudioRecordingDeviceMuteWarning, false)]
        public override int SetAudioRecordingDeviceMute(bool mute)
        {
            return _agoraRtcAudioRecordingDeviceManager.SetRecordingDeviceMute(mute);
        }

        [Obsolete(ObsoleteMethodWarning.IsAudioRecordingDeviceMuteWarning, false)]
        public override bool IsAudioRecordingDeviceMute()
        {
            return _agoraRtcAudioRecordingDeviceManager.GetRecordingDeviceMute();
        }

        [Obsolete(ObsoleteMethodWarning.GetCurrentRecordingDeviceInfoWarning, false)]
        public override int GetCurrentRecordingDeviceInfo(ref string deviceName, ref string deviceId)
        {
            var param = new { };
            string result;
            var ret = _agoraRtcAudioRecordingDeviceManager.CallIrisRtcAudioDeviceManagerApi(
                ApiTypeAudioDeviceManager.kADMGetRecordingDeviceInfo, JsonMapper.ToJson(param), out result);
            if (result.Length <= 0) return ret;
            deviceName = (string) AgoraJson.GetData<string>(result, "deviceName");
            deviceId = (string) AgoraJson.GetData<string>(result, "deviceId");
            return ret;
        }
        
        ~AudioRecordingDeviceManager()
        {
            Dispose(false);
        }
    }
}