using System;

namespace agorartc
{
    using IVideoDeviceManager_ptr = IntPtr;
    using view_t = IntPtr;
    
    public class AgoraVideoDeviceManager: IDisposable
    {
        private IVideoDeviceManager_ptr _videoDeviceHandler;
        private bool _disposed = false;

        public AgoraVideoDeviceManager(IVideoDeviceManager_ptr handler)
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
            return AgorartcNative.startDeviceTest(_videoDeviceHandler, hwnd);
        }

        public ERROR_CODE StopDeviceTest()
        {
            return AgorartcNative.stopDeviceTest(_videoDeviceHandler);
        }

        public ERROR_CODE SetDevice(string deviceId)
        {
            return AgorartcNative.setDevice(_videoDeviceHandler, deviceId);
        }

        public ERROR_CODE GetDevice(int index, string deviceName, string deviceId)
        {
            return AgorartcNative.getDevice(_videoDeviceHandler, index, deviceName, deviceId);
        }

        public ERROR_CODE GetCurrentDevice(string deviceId)
        {
            return AgorartcNative.getCurrentDevice(_videoDeviceHandler, deviceId);
        }

        public int GetDeviceCount()
        {
            return AgorartcNative.getDeviceCount(_videoDeviceHandler);
        }


        private void ReleaseVideoDeviceManager()
        {
            AgorartcNative.releaseVideoDeviceManager(_videoDeviceHandler);
            AgoraRtcEngine.CreateRtcEngine().ReleaseAgoraVideoDeviceManager(this);
            _videoDeviceHandler = IntPtr.Zero;
        }

        ~AgoraVideoDeviceManager()
        {
            Dispose(false);
        }
    }
}