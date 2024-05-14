using System;
using System.Collections.Generic;
namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;

    internal class AudioDeviceManagerImpl
    {
        private bool _disposed = false;
        private IrisApiEnginePtr _irisApiEngine;
        private IrisRtcCApiParam _apiParam;
        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

        internal AudioDeviceManagerImpl(IrisApiEnginePtr irisApiEngine)
        {
            _apiParam = new IrisRtcCApiParam();
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
            if (_disposed)
                return;

            if (disposing)
            {
            }

            _irisApiEngine = IntPtr.Zero;
            _apiParam.FreeResult();
            _disposed = true;
        }

        public DeviceInfo[] EnumeratePlaybackDevices()
        {
            return AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                                                      AgoraApiType.FUNC_AUDIODEVICEMANAGER_ENUMERATEPLAYBACKDEVICES,
                                                      "", 0, IntPtr.Zero, 0, ref _apiParam) != 0
                       ? new DeviceInfo[0]
                       : AgoraJson.JsonToStructArray<DeviceInfo>(_apiParam.Result, "result");
        }

        public DeviceInfo[] EnumerateRecordingDevices()
        {
            return AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                                                      AgoraApiType.FUNC_AUDIODEVICEMANAGER_ENUMERATERECORDINGDEVICES,
                                                      "", 0, IntPtr.Zero, 0, ref _apiParam) != 0
                       ? new DeviceInfo[0]
                       : AgoraJson.JsonToStructArray<DeviceInfo>(_apiParam.Result, "result");
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

        public int GetPlaybackDefaultDevice(ref string deviceId, ref string deviceTypeName, ref string deviceName)
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
                deviceTypeName = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceTypeName");
            }
            else
            {
                deviceId = "";
                deviceName = "";
                deviceTypeName = "";
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

        public int GetRecordingDefaultDevice(ref string deviceId, ref string deviceTypeName, ref string deviceName)
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
                deviceTypeName = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceTypeName");
            }
            else
            {
                deviceId = "";
                deviceName = "";
                deviceTypeName = "";
            }

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        #region terra IAudioDeviceManager
        public int SetPlaybackDevice(string deviceId)
        {
            _param.Clear();
            _param.Add("deviceId", deviceId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETPLAYBACKDEVICE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetPlaybackDevice(ref string deviceId)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                deviceId = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceId");
            }
            return result;
        }

        public int GetPlaybackDeviceInfo(ref string deviceId, ref string deviceName)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICEINFO,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                deviceId = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceId");
                deviceName = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceName");
            }
            return result;
        }

        public int GetPlaybackDeviceInfo(ref string deviceId, ref string deviceName, ref string deviceTypeName)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICEINFO2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                deviceId = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceId");
                deviceName = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceName");
                deviceTypeName = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceTypeName");
            }
            return result;
        }

        public int SetPlaybackDeviceVolume(int volume)
        {
            _param.Clear();
            _param.Add("volume", volume);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETPLAYBACKDEVICEVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetPlaybackDeviceVolume(ref int volume)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICEVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                volume = (int)AgoraJson.GetData<int>(_apiParam.Result, "volume");
            }
            return result;
        }

        public int SetRecordingDevice(string deviceId)
        {
            _param.Clear();
            _param.Add("deviceId", deviceId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETRECORDINGDEVICE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetRecordingDevice(ref string deviceId)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                deviceId = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceId");
            }
            return result;
        }

        public int GetRecordingDeviceInfo(ref string deviceId, ref string deviceName)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICEINFO,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                deviceId = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceId");
                deviceName = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceName");
            }
            return result;
        }

        public int GetRecordingDeviceInfo(ref string deviceId, ref string deviceName, ref string deviceTypeName)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICEINFO2,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                deviceId = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceId");
                deviceName = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceName");
                deviceTypeName = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceTypeName");
            }
            return result;
        }

        public int SetRecordingDeviceVolume(int volume)
        {
            _param.Clear();
            _param.Add("volume", volume);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETRECORDINGDEVICEVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetRecordingDeviceVolume(ref int volume)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICEVOLUME,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                volume = (int)AgoraJson.GetData<int>(_apiParam.Result, "volume");
            }
            return result;
        }

        public int SetLoopbackDevice(string deviceId)
        {
            _param.Clear();
            _param.Add("deviceId", deviceId);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETLOOPBACKDEVICE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetLoopbackDevice(ref string deviceId)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETLOOPBACKDEVICE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                deviceId = (string)AgoraJson.GetData<string>(_apiParam.Result, "deviceId");
            }
            return result;
        }

        public int SetPlaybackDeviceMute(bool mute)
        {
            _param.Clear();
            _param.Add("mute", mute);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETPLAYBACKDEVICEMUTE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetPlaybackDeviceMute(ref bool mute)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETPLAYBACKDEVICEMUTE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                mute = (bool)AgoraJson.GetData<bool>(_apiParam.Result, "mute");
            }
            return result;
        }

        public int SetRecordingDeviceMute(bool mute)
        {
            _param.Clear();
            _param.Add("mute", mute);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_SETRECORDINGDEVICEMUTE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int GetRecordingDeviceMute(ref bool mute)
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_GETRECORDINGDEVICEMUTE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
            if (nRet == 0)
            {
                mute = (bool)AgoraJson.GetData<bool>(_apiParam.Result, "mute");
            }
            return result;
        }

        public int StartPlaybackDeviceTest(string testAudioFilePath)
        {
            _param.Clear();
            _param.Add("testAudioFilePath", testAudioFilePath);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_STARTPLAYBACKDEVICETEST,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopPlaybackDeviceTest()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_STOPPLAYBACKDEVICETEST,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartRecordingDeviceTest(int indicationInterval)
        {
            _param.Clear();
            _param.Add("indicationInterval", indicationInterval);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_STARTRECORDINGDEVICETEST,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopRecordingDeviceTest()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_STOPRECORDINGDEVICETEST,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StartAudioDeviceLoopbackTest(int indicationInterval)
        {
            _param.Clear();
            _param.Add("indicationInterval", indicationInterval);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_STARTAUDIODEVICELOOPBACKTEST,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int StopAudioDeviceLoopbackTest()
        {
            _param.Clear();

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_STOPAUDIODEVICELOOPBACKTEST,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int FollowSystemPlaybackDevice(bool enable)
        {
            _param.Clear();
            _param.Add("enable", enable);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_FOLLOWSYSTEMPLAYBACKDEVICE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int FollowSystemRecordingDevice(bool enable)
        {
            _param.Clear();
            _param.Add("enable", enable);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_FOLLOWSYSTEMRECORDINGDEVICE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }

        public int FollowSystemLoopbackDevice(bool enable)
        {
            _param.Clear();
            _param.Add("enable", enable);

            var json = AgoraJson.ToJson(_param);
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_AUDIODEVICEMANAGER_FOLLOWSYSTEMLOOPBACKDEVICE,
                json, (UInt32)json.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            var result = nRet != 0 ? nRet : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");

            return result;
        }


        #endregion terra IAudioDeviceManager
    }
}