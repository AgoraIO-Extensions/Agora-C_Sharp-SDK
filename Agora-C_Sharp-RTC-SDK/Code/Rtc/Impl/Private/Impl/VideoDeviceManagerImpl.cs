using System;
using System.Collections.Generic;
namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;

    public partial class VideoDeviceManagerImpl
    {
        private bool _disposed = false;
        private IrisApiEnginePtr _irisApiEngine;
        private IrisRtcCApiParam _apiParam;
        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

        internal VideoDeviceManagerImpl(IrisApiEnginePtr irisApiEngine)
        {
            _apiParam = new IrisRtcCApiParam();
            _apiParam.AllocResult();
            _irisApiEngine = irisApiEngine;
        }

        ~VideoDeviceManagerImpl()
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

        public DeviceInfo[] EnumerateVideoDevices()
        {
            var nRet = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine,
                                                          AgoraApiType.IVIDEODEVICEMANAGER_ENUMERATEVIDEODEVICES,
                                                          "", 0, IntPtr.Zero, 0, ref _apiParam);
            if (nRet != 0)
            {
                return new DeviceInfo[0];
            }
            return AgoraJson.JsonToStructArray<DeviceInfo>(_apiParam.Result, "result");
        }
    }
}
