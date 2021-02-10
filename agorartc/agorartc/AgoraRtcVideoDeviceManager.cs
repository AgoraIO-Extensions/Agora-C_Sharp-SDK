using System;
using System.Text.Json;

namespace agorartc
{
    using IrisDeviceManagerPtr = IntPtr;
    using view_t = IntPtr;

    public class AgoraVideoDeviceManager : IDisposable
    {
        private IrisDeviceManagerPtr _videoDeviceHandler;
        private bool _disposed = false;
        private char[] result = new char[2048];

        public AgoraVideoDeviceManager(IrisDeviceManagerPtr handler)
        {
            _videoDeviceHandler = handler;
        }

        public void Dispose()
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

            ReleaseVideoDeviceManager();
            _disposed = true;
        }

        public ERROR_CODE StartDeviceTest(view_t hwnd)
        {
            var para = new
            {
                hwnd
            };
            return (ERROR_CODE) (AgorartcNative.CallVideoDeviceApi(_videoDeviceHandler,
                CApiTypeVideoDeviceManager.kStartVideoDeviceTest, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StopDeviceTest()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallVideoDeviceApi(_videoDeviceHandler,
                CApiTypeVideoDeviceManager.kStopVideoDeviceTest, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE SetCurrentDevice(string deviceId)
        {
            var para = new
            {
                deviceId
            };
            return (ERROR_CODE) (AgorartcNative.CallVideoDeviceApi(_videoDeviceHandler,
                CApiTypeVideoDeviceManager.kSetCurrentVideoDeviceId, JsonSerializer.Serialize(para), result) * -1);
        }

        public string GetCurrentDevice()
        {
            var para = new { };

            return AgorartcNative.CallVideoDeviceApi(_videoDeviceHandler,
                CApiTypeVideoDeviceManager.kGetCurrentVideoDeviceId, JsonSerializer.Serialize(para), result) != 0
                ? "GetDevice Failed."
                : new string(result[..Array.IndexOf(result, '\0')]);
        }
        
        public ERROR_CODE GetDeviceInfoByIndex(int index, char[] deviceName, char[] deviceId)
        {
            var para = new
            {
                index
            };
            var ret = (ERROR_CODE) (AgorartcNative.CallVideoDeviceApi(_videoDeviceHandler,
                CApiTypeVideoDeviceManager.kGetVideoDeviceInfoByIndex, JsonSerializer.Serialize(para), result) * -1);
            deviceName = ((string) AgoraUtil.GetData<string>(result, "deviceName")).ToCharArray();
            deviceId = ((string) AgoraUtil.GetData<string>(result, "deviceId")).ToCharArray();
            return ret;
        }

        public int GetDeviceCount()
        {
            var para = new { };
            return AgorartcNative.CallVideoDeviceApi(_videoDeviceHandler,
                CApiTypeVideoDeviceManager.kGetVideoDeviceCount, JsonSerializer.Serialize(para), result);
        }


        private void ReleaseVideoDeviceManager()
        {
            AgoraRtcEngine.CreateRtcEngine().ReleaseAgoraVideoDeviceManager();
            _videoDeviceHandler = IntPtr.Zero;
        }

        ~AgoraVideoDeviceManager()
        {
            Dispose(false);
        }
    }
}