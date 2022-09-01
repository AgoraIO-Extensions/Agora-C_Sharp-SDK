using System;

namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;

    internal class AudioDeviceManagerImpl
    {
        private bool _disposed = false;
        private IrisApiEnginePtr _irisApiEngine;
        private CharAssistant _result;

        internal AudioDeviceManagerImpl(IrisApiEnginePtr irisApiEngine)
        {
            _result = new CharAssistant();
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

            _irisApiEngine = IntPtr.Zero;
            _result = new CharAssistant();
            _disposed = true;
        }

        #region PlaybackDevices
        public DeviceInfo[] EnumeratePlaybackDevices()
        {
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_ENUMERATEPLAYBACKDEVICES,
                "", 0, IntPtr.Zero, 0, out _result) != 0
                ? new DeviceInfo[0]
                : AgoraJson.JsonToStructArray<DeviceInfo>(_result.Result, "result");
        }

        public int SetPlaybackDevice(string deviceId)
        {
            var param = new
            {
                deviceId
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETPLAYBACKDEVICE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetPlaybackDevice(ref string deviceId)
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICE,
                "", 0, IntPtr.Zero, 0, out _result);
            deviceId = (string) AgoraJson.GetData<string>(_result.Result, "deviceId");
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetPlaybackDeviceInfo(ref string deviceId, ref string deviceName)
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICEINFO,
                "", 0, IntPtr.Zero, 0, out _result);
            deviceId = (string) AgoraJson.GetData<string>(_result.Result, "deviceId");
            deviceName = (string) AgoraJson.GetData<string>(_result.Result, "deviceName");
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SetPlaybackDeviceVolume(int volume)
        {
            var param = new 
            {
                volume
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETPLAYBACKDEVICEVOLUME,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetPlaybackDeviceVolume(ref int volume)
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICEVOLUME,
                "", 0, IntPtr.Zero, 0, out _result);
            volume = (int) AgoraJson.GetData<int>(_result.Result, "result");
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SetPlaybackDeviceMute(bool mute)
        {
            var param = new 
            {
                mute
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETPLAYBACKDEVICEMUTE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetPlaybackDeviceMute(ref bool mute)
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICEMUTE,
                "", 0, IntPtr.Zero, 0, out _result);
            mute = (bool) AgoraJson.GetData<bool>(_result.Result, "mute");
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int StartPlaybackDeviceTest(string testAudioFilePath)
        {
            var param = new 
            {
                testAudioFilePath
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STARTPLAYBACKDEVICETEST,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int StopPlaybackDeviceTest()
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STOPPLAYBACKDEVICETEST,
                "", 0, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int FollowSystemPlaybackDevice(bool enable)
        {
            var param = new
            {
                enable
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_FOLLOWSYSTEMPLAYBACKDEVICE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }
        #endregion



        #region PlaybackDevices
        public DeviceInfo[] EnumerateRecordingDevices()
        {
            return AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_ENUMERATERECORDINGDEVICES,
                "", 0, IntPtr.Zero, 0, out _result) != 0
                ? new DeviceInfo[0]
                : AgoraJson.JsonToStructArray<DeviceInfo>(_result.Result, "result");
        }

        public int SetRecordingDevice(string deviceId)
        {
            var param = new
            {
                deviceId
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETRECORDINGDEVICE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetRecordingDevice(ref string deviceId)
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICE,
                "", 0, IntPtr.Zero, 0, out _result);
            deviceId = (string)AgoraJson.GetData<string>(_result.Result, "deviceId");
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetRecordingDeviceInfo(ref string deviceId, ref string deviceName)
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICEINFO,
                "", 0, IntPtr.Zero, 0, out _result);
            deviceId = (string) AgoraJson.GetData<string>(_result.Result, "deviceId");
            deviceName = (string) AgoraJson.GetData<string>(_result.Result, "deviceName");
            return ret != 0 ? ret : (int) AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SetRecordingDeviceVolume(int volume)
        {
            var param = new
            {
                volume
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETRECORDINGDEVICEVOLUME,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetRecordingDeviceVolume(ref int volume)
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICEVOLUME,
                "", 0, IntPtr.Zero, 0, out _result);
            volume = (int) AgoraJson.GetData<int>(_result.Result, "result");
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SetRecordingDeviceMute(bool mute)
        {
            var param = new
            {
                mute
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETRECORDINGDEVICEMUTE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetRecordingDeviceMute(ref bool mute)
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICEMUTE,
                "", 0, IntPtr.Zero, 0, out _result);
            mute = (bool)AgoraJson.GetData<bool>(_result.Result, "mute");
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int StartRecordingDeviceTest(int indicationInterval)
        {
            var param = new
            {
                indicationInterval
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STARTRECORDINGDEVICETEST,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int StopRecordingDeviceTest()
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STOPRECORDINGDEVICETEST,
                "", 0, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int FollowSystemRecordingDevice(bool enable)
        {
            var param = new
            {
                enable
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_FOLLOWSYSTEMRECORDINGDEVICE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }
        #endregion

        #region AudioDevice
        public int StartAudioDeviceLoopbackTest(int indicationInterval)
        {
            var param = new
            {
                indicationInterval
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STARTAUDIODEVICELOOPBACKTEST,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int StopAudioDeviceLoopbackTest()
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STOPAUDIODEVICELOOPBACKTEST,
                "", 0, IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }
        #endregion
    }
}