using System;
using System.Collections.Generic;
namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;

    public partial class AudioDeviceManagerImpl
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
                                                      AgoraApiType.IAUDIODEVICEMANAGER_ENUMERATEPLAYBACKDEVICES,
                                                      "", 0, IntPtr.Zero, 0, ref _apiParam) != 0
                       ? new DeviceInfo[0]
                       : AgoraJson.JsonToStructArray<DeviceInfo>(_apiParam.Result, "result");
        }

        public DeviceInfo[] EnumerateRecordingDevices()
        {
            return AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                                                      AgoraApiType.IAUDIODEVICEMANAGER_ENUMERATERECORDINGDEVICES,
                                                      "", 0, IntPtr.Zero, 0, ref _apiParam) != 0
                       ? new DeviceInfo[0]
                       : AgoraJson.JsonToStructArray<DeviceInfo>(_apiParam.Result, "result");
        }
    }
}