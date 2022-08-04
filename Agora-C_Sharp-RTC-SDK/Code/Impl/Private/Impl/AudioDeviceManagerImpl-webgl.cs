#if UNITY_WEBGL

using System;

namespace Agora.Rtc
{
    using IrisApiEnginePtr = System.Int32;

    internal class AudioDeviceManagerImpl
    {
        private bool _disposed = false;
        private IrisApiEnginePtr _irisApiEngine;
        //private CharAssistant _result;

        internal AudioDeviceManagerImpl(IrisApiEnginePtr irisApiEngine)
        {
            //_result = new CharAssistant();
            _irisApiEngine = irisApiEngine;
        }

        ~AudioDeviceManagerImpl()
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

        public DeviceInfo[] EnumeratePlaybackDevices()
        {
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_ENUMERATEPLAYBACKDEVICES,
                "", 0, IntPtr.Zero, 0);

            DeviceInfo[] deviceInfos = AgoraJson.JsonToStructArray<DeviceInfo>(result, "result");

            return deviceInfos;
        }

        public int SetPlaybackDevice(string deviceId)
        {
            var param = new
            {
                deviceId
            };
            string jsonParam = AgoraJson.ToJson(param);

            var result = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETPLAYBACKDEVICE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);

            return (int)AgoraJson.GetData<int>(result, "result");
        }

        public string GetPlaybackDevice()
        {
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICE,
                "", 0, IntPtr.Zero, 0);
            return (string)AgoraJson.GetData<string>(result, "result");
        }

        public DeviceInfo GetPlaybackDeviceInfo()
        {
            var result = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICEINFO,
                "", 0, IntPtr.Zero, 0);

            return (DeviceInfo)AgoraJson.JsonToStruct<DeviceInfo>(result, "result");
        }

        public int SetPlaybackDeviceVolume(int volume)
        {
            var param = new
            {
                volume
            };
            string jsonParam = AgoraJson.ToJson(param);
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETPLAYBACKDEVICEVOLUME,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);

            return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int GetPlaybackDeviceVolume()
        {
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICEVOLUME,
                "", 0, IntPtr.Zero, 0);
            return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int SetPlaybackDeviceMute(bool mute)
        {
            var param = new
            {
                mute
            };
            string jsonParam = AgoraJson.ToJson(param);
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETPLAYBACKDEVICEMUTE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            return (int)AgoraJson.GetData<int>(result, "result");
        }

        public bool GetPlaybackDeviceMute()
        {
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICEMUTE,
                "", 0, IntPtr.Zero, 0);
            return (bool)AgoraJson.GetData<bool>(result, "result");
        }

        public int StartPlaybackDeviceTest(string testAudioFilePath)
        {
            var param = new
            {
                testAudioFilePath
            };
            string jsonParam = AgoraJson.ToJson(param);
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STARTPLAYBACKDEVICETEST,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int StopPlaybackDeviceTest()
        {
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STOPPLAYBACKDEVICETEST,
                "", 0, IntPtr.Zero, 0);
            return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int StartAudioDeviceLoopbackTest(int indicationInterval)
        {
            var param = new
            {
                indicationInterval
            };
            string jsonParam = AgoraJson.ToJson(param);
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STARTAUDIODEVICELOOPBACKTEST,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int StopAudioDeviceLoopbackTest()
        {
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STOPAUDIODEVICELOOPBACKTEST,
                "", 0, IntPtr.Zero, 0);
            return (int)AgoraJson.GetData<int>(result, "result");
        }

        public DeviceInfo[] EnumerateRecordingDevices()
        {

            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_ENUMERATERECORDINGDEVICES,
                "{}", 2, IntPtr.Zero, 0);

            DeviceInfo[] deviceInfos = AgoraJson.JsonToStructArray<DeviceInfo>(result, "result");
            return deviceInfos;
        }

        public int SetRecordingDevice(string deviceId)
        {
            var param = new
            {
                deviceId
            };
            string jsonParam = AgoraJson.ToJson(param);
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETRECORDINGDEVICE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            return (int)AgoraJson.GetData<int>(result, "result");
        }

        public string GetRecordingDevice()
        {
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICE,
                "", 0, IntPtr.Zero, 0);

            return  (string)AgoraJson.GetData<string>(result, "result");
        }

        public DeviceInfo GetRecordingDeviceInfo()
        {
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICEINFO,
                "", 0, IntPtr.Zero, 0);

            DeviceInfo deviceInfo = AgoraJson.JsonToStruct<DeviceInfo>(result, "result");
            return deviceInfo;
        }

        public int SetRecordingDeviceVolume(int volume)
        {
            var param = new
            {
                volume
            };
            string jsonParam = AgoraJson.ToJson(param);
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETRECORDINGDEVICEVOLUME,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int GetRecordingDeviceVolume()
        {
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICEVOLUME,
                "", 0, IntPtr.Zero, 0);
            return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int SetRecordingDeviceMute(bool mute)
        {
            var param = new
            {
                mute
            };
            string jsonParam = AgoraJson.ToJson(param);
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETRECORDINGDEVICEMUTE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            return (int)AgoraJson.GetData<int>(result, "result");
        }

        public bool GetRecordingDeviceMute()
        {
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICEMUTE,
                "", 0, IntPtr.Zero, 0);
            return (bool)AgoraJson.GetData<bool>(result, "result");
        }

        public int StartRecordingDeviceTest(int indicationInterval)
        {
            var param = new
            {
                indicationInterval
            };
            string jsonParam = AgoraJson.ToJson(param);
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STARTRECORDINGDEVICETEST,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0);
            return (int)AgoraJson.GetData<int>(result, "result");
        }

        public int StopRecordingDeviceTest()
        {
            var result = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STOPRECORDINGDEVICETEST,
                "", 0, IntPtr.Zero, 0);
            return (int)AgoraJson.GetData<int>(result, "result");
        }
    }
}

#endif