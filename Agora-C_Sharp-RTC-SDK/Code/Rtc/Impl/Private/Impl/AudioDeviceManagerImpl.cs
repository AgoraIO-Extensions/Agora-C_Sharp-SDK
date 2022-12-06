using System;
using System.Collections.Generic;
namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;

    internal class AudioDeviceManagerImpl
    {
        private bool _disposed = false;
        private IrisApiEnginePtr _irisApiEngine;
        private IrisCApiParam _apiParam;
        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

        internal AudioDeviceManagerImpl(IrisApiEnginePtr irisApiEngine)
        {
            _apiParam = new IrisCApiParam();
            _apiParam.AllocResult();
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
            _apiParam.FreeResult();
            _disposed = true;
        }

        #region PlaybackDevices
        public DeviceInfo[] EnumeratePlaybackDevices()
        {
            return AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_ENUMERATEPLAYBACKDEVICES,
                "", 0, IntPtr.Zero, 0, ref _apiParam) != 0
                ? new DeviceInfo[0]
                : AgoraJson.JsonToStructArray<DeviceInfo>(_apiParam.Result, "result");
        }

        public int SetPlaybackDevice(string deviceId)
        {
            _param.Clear();
            _param.Add("deviceId", deviceId);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETPLAYBACKDEVICE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetPlaybackDevice(ref string deviceId)
        {
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICE,
                "", 0, IntPtr.Zero, 0, ref _apiParam);
            deviceId = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceId");
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetPlaybackDeviceInfo(ref string deviceId, ref string deviceName)
        {
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICEINFO,
                "", 0, IntPtr.Zero, 0, ref _apiParam);
            deviceId = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceId");
            deviceName = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceName");
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetPlaybackDeviceVolume(int volume)
        {
            _param.Clear();
            _param.Add("volume", volume);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETPLAYBACKDEVICEVOLUME,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetPlaybackDeviceVolume(ref int volume)
        {
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICEVOLUME,
                "", 0, IntPtr.Zero, 0, ref _apiParam);
            volume = (int)AgoraJson.GetData<int>(_apiParam.Result, "volume");
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetPlaybackDeviceMute(bool mute)
        {
            _param.Clear();
            _param.Add("mute", mute);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETPLAYBACKDEVICEMUTE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetPlaybackDeviceMute(ref bool mute)
        {
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICEMUTE,
                "", 0, IntPtr.Zero, 0, ref _apiParam);
            mute = (bool)AgoraJson.GetData<bool>(_apiParam.Result, "mute");
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartPlaybackDeviceTest(string testAudioFilePath)
        {
            _param.Clear();
            _param.Add("testAudioFilePath", testAudioFilePath);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STARTPLAYBACKDEVICETEST,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopPlaybackDeviceTest()
        {
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STOPPLAYBACKDEVICETEST,
                "", 0, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int FollowSystemPlaybackDevice(bool enable)
        {
            _param.Clear();
            _param.Add("enable", enable);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_FOLLOWSYSTEMPLAYBACKDEVICE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }
        #endregion



        #region PlaybackDevices
        public DeviceInfo[] EnumerateRecordingDevices()
        {
            return AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_ENUMERATERECORDINGDEVICES,
                "", 0, IntPtr.Zero, 0, ref _apiParam) != 0
                ? new DeviceInfo[0]
                : AgoraJson.JsonToStructArray<DeviceInfo>(_apiParam.Result, "result");
        }

        public int SetRecordingDevice(string deviceId)
        {
            _param.Clear();
            _param.Add("deviceId", deviceId);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETRECORDINGDEVICE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetRecordingDevice(ref string deviceId)
        {
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICE,
                "", 0, IntPtr.Zero, 0, ref _apiParam);
            deviceId = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceId");
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetRecordingDeviceInfo(ref string deviceId, ref string deviceName)
        {
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICEINFO,
                "", 0, IntPtr.Zero, 0, ref _apiParam);
            deviceId = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceId");
            deviceName = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceName");
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetRecordingDeviceVolume(int volume)
        {
            _param.Clear();
            _param.Add("volume", volume);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETRECORDINGDEVICEVOLUME,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetRecordingDeviceVolume(ref int volume)
        {
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICEVOLUME,
                "", 0, IntPtr.Zero, 0, ref _apiParam);
            volume = (int)AgoraJson.GetData<int>(_apiParam.Result, "volume");
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetRecordingDeviceMute(bool mute)
        {
            _param.Clear();
            _param.Add("mute", mute);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETRECORDINGDEVICEMUTE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetRecordingDeviceMute(ref bool mute)
        {
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICEMUTE,
                "", 0, IntPtr.Zero, 0, ref _apiParam);
            mute = (bool)AgoraJson.GetData<bool>(_apiParam.Result, "mute");
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StartRecordingDeviceTest(int indicationInterval)
        {
            _param.Clear();
            _param.Add("indicationInterval", indicationInterval);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STARTRECORDINGDEVICETEST,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopRecordingDeviceTest()
        {
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STOPRECORDINGDEVICETEST,
                "", 0, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int FollowSystemRecordingDevice(bool enable)
        {
            _param.Clear();
            _param.Add("enable", enable);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_FOLLOWSYSTEMRECORDINGDEVICE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }
        #endregion

        #region AudioDevice
        public int StartAudioDeviceLoopbackTest(int indicationInterval)
        {
            _param.Clear();
            _param.Add("indicationInterval", indicationInterval);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STARTAUDIODEVICELOOPBACKTEST,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int StopAudioDeviceLoopbackTest()
        {
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_STOPAUDIODEVICELOOPBACKTEST,
                "", 0, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int SetLoopbackDevice(string deviceId)
        {
            _param.Clear();
            _param.Add("deviceId", deviceId);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETLOOPBACKDEVICE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetLoopbackDevice(ref string deviceId)
        {
            _param.Clear();

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETLOOPBACKDEVICE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);

            deviceId = ret == 0 ? (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceId") : "";
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int FollowSystemLoopbackDevice(bool enable)
        {
            _param.Clear();
            _param.Add("enable", enable);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_FOLLOWSYSTEMLOOPBACKDEVICE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);


            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int GetPlaybackDefaultDevice(ref string deviceId, ref string deviceName)
        {
            _param.Clear();

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEFAULTDEVICE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);

            if (ret == 0)
            {
                deviceId = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceId");
                deviceName = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceName");
            }
            else
            {
                deviceId = "";
                deviceName = "";
            }

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }


        public int GetRecordingDefaultDevice(ref string deviceId, ref string deviceName)
        {
            _param.Clear();

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEAFULTDEVICE,
                jsonParam, (UInt32)jsonParam.Length, IntPtr.Zero, 0, ref _apiParam);

            if (ret == 0)
            {
                deviceId = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceId");
                deviceName = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceName");
            }
            else
            {
                deviceId = "";
                deviceName = "";
            }

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        #endregion
    }
}