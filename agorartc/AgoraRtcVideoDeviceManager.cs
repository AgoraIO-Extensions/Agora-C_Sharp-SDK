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
        
        /// <summary>
        /// Releases all IRtcVideoDeviceManager resources.
        /// </summary>
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

        /// <summary>
        /// Starts the video-capture device test.
        ///
        ///This method tests whether the video-capture device works properly. Before calling this method, ensure that you have already called the \ref IRtcEngine::enableVideo "enableVideo" method, and the window handle (*hwnd*) parameter is valid.
        /// </summary>
        /// 
        /// <param name="hwnd">
        /// @param hwnd The window handle used to display the screen.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StartDeviceTest(view_t hwnd)
        {
            return AgorartcNative.startDeviceTest(_videoDeviceHandler, hwnd);
        }

        /// <summary>
        /// Stops the video-capture device test.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StopDeviceTest()
        {
            return AgorartcNative.stopDeviceTest(_videoDeviceHandler);
        }

        /// <summary>
        /// Sets the device with the device ID.
        /// </summary>
        /// 
        /// <param name="deviceId">
        /// @param deviceId Device ID of the device.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetDevice(string deviceId)
        {
            return AgorartcNative.setDevice(_videoDeviceHandler, deviceId);
        }

        /// <summary>
        /// Retrieves a specified piece of information about an indexed video device.
        /// </summary>
        /// 
        /// <param name="index">
        /// @param index The specified index of the video device that must be less than the return value of \ref IVideoDeviceCollection::getCount "getCount".
        /// </param>
        /// 
        /// <param name="deviceName">
        /// @param deviceName Pointer to the video device name.
        /// </param>
        /// 
        /// <param name="deviceId">
        /// @param deviceId Pointer to the video device ID.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE GetDevice(int index, string deviceName, string deviceId)
        {
            return AgorartcNative.getDevice(_videoDeviceHandler, index, deviceName, deviceId);
        }

        /// <summary>
        /// Get the device id of the current device.
        /// </summary>
        /// 
        /// <param name="deviceId">
        /// OUT Attribute. Return the deviceId here.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE GetCurrentDevice(string deviceId)
        {
            return AgorartcNative.getCurrentDevice(_videoDeviceHandler, deviceId);
        }

        /// <summary>
        /// Retrieves the total number of the indexed video devices in the system.
        /// </summary>
        /// 
        /// <returns>
        /// @return Total number of the indexed video devices:
        /// </returns>
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