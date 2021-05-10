//
//  Created by Yiqing Huang on 2020/12/15.
//  Copyright © 2020 Agora. All rights reserved.
//

using System;
using Newtonsoft.Json;

namespace agorartc
{
    using IrisDeviceManagerPtr = IntPtr;
    using view_t = UInt64;

    public class AgoraVideoDeviceManager : IDisposable
    {
        private IrisDeviceManagerPtr _videoDeviceHandler;
        private bool _disposed = false;
        private CharArrayAssistant result;

        public AgoraVideoDeviceManager(IrisDeviceManagerPtr handler)
        {
            result = new CharArrayAssistant();
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
            var para = new
            {
                hwnd
            };
            return (ERROR_CODE) (AgorartcNative.CallVideoDeviceApi(_videoDeviceHandler,
                CApiTypeVideoDeviceManager.kStartVideoDeviceTest, JsonConvert.SerializeObject(para), out result) * -1);
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
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallVideoDeviceApi(_videoDeviceHandler,
                CApiTypeVideoDeviceManager.kStopVideoDeviceTest, JsonConvert.SerializeObject(para), out result) * -1);
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
        public ERROR_CODE SetCurrentDevice(string deviceId)
        {
            var para = new
            {
                deviceId
            };
            return (ERROR_CODE) (AgorartcNative.CallVideoDeviceApi(_videoDeviceHandler,
                CApiTypeVideoDeviceManager.kSetCurrentVideoDeviceId, JsonConvert.SerializeObject(para), out result) * -1);
        }

        /// <summary>
        /// Get the device id of the current device.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - The device id of the current device.
        /// </returns>
        public string GetCurrentDevice()
        {
            var para = new { };

            return AgorartcNative.CallVideoDeviceApi(_videoDeviceHandler,
                CApiTypeVideoDeviceManager.kGetCurrentVideoDeviceId, JsonConvert.SerializeObject(para), out result) != 0
                ? "GetDevice Failed."
                : result.result;
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
        public ERROR_CODE GetDeviceInfoByIndex(int index, out string deviceName, out string deviceId)
        {
            var para = new
            {
                index
            };
            var ret = (ERROR_CODE) (AgorartcNative.CallVideoDeviceApi(_videoDeviceHandler,
                CApiTypeVideoDeviceManager.kGetVideoDeviceInfoByIndex, JsonConvert.SerializeObject(para), out result) * -1);
            if (result.result.Length > 0)
            {
                deviceName = (string) AgoraUtil.GetData<string>(result.result, "deviceName");
                deviceId = (string) AgoraUtil.GetData<string>(result.result, "deviceId");
            }
            else
            {
                deviceName = "";
                deviceId = "";
            }
            
            return ret;
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
            var para = new { };
            return AgorartcNative.CallVideoDeviceApi(_videoDeviceHandler,
                CApiTypeVideoDeviceManager.kGetVideoDeviceCount, JsonConvert.SerializeObject(para), out result);
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