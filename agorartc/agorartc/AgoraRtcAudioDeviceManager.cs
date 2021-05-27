//
//  Created by Yiqing Huang on 2020/12/15.
//  Copyright © 2020 Agora. All rights reserved.
//

using System;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

namespace agorartc
{
    using IrisDeviceManagerPtr = IntPtr;

    public class AgoraAudioPlaybackDeviceManager : IDisposable
    {
        private IrisDeviceManagerPtr _audioPlaybackHandler;
        private bool _disposed = false;
        private CharArrayAssistant _result;

        internal AgoraAudioPlaybackDeviceManager(IrisDeviceManagerPtr handler)
        {
            _audioPlaybackHandler = handler;
            _result = new CharArrayAssistant();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all IRtcAudioPlaybackDeviceManager resources.
        /// </summary>
        private void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
            }

            ReleaseAudioPlaybackDeviceManager();
            _disposed = true;
        }

        /// <summary>
        /// Retrieves the total number of audio playback or audio recording devices.
        ///
        ///@note You must first call the \ref IAudioDeviceManager::enumeratePlaybackDevices "enumeratePlaybackDevices" method before calling this method to return the number of audio playback devices.
        /// </summary>
        /// 
        /// <returns>
        /// @return Number of audio playback devices.
        /// </returns>
        public int GetDeviceCount()
        {
            var para = new { };
            return AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                CApiTypeAudioDeviceManager.kGetAudioPlaybackDeviceCount, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)), out _result);
        }

        /// <summary>
        /// Retrieves a specified piece of information about an indexed audio device.
        /// </summary>
        /// 
        /// <param name="index">
        /// @param index The specified index that must be less than the return value of \ref IAudioDeviceCollection::getCount "getCount".
        /// </param>
        /// 
        /// <param name="deviceName">
        /// @param deviceName Pointer to the audio device name.
        /// </param>
        /// 
        /// <param name="deviceId">
        /// @param deviceId Pointer to the audio device ID.
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
            var ret = (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                CApiTypeAudioDeviceManager.kGetAudioPlaybackDeviceInfoByIndex,
                Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)), out _result) * -1);
            if (_result.result.Length > 0)
            {
                deviceName = (string) AgoraUtil.GetData<string>(_result.result, "deviceName");
                deviceId = (string) AgoraUtil.GetData<string>(_result.result, "deviceId");
            }
            else
            {
                deviceName = "";
                deviceId = "";
            }

            return ret;
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
        public ERROR_CODE SetCurrentDevice(string deviceId)
        {
            var para = new
            {
                deviceId
            };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                CApiTypeAudioDeviceManager.kSetCurrentAudioPlaybackDeviceId,
                Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)), out _result) * -1);
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

            return AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                       CApiTypeAudioDeviceManager.kGetCurrentAudioPlaybackDeviceId, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)),
                       out _result) !=
                   0
                ? "GetDevice Failed."
                : _result.result;
        }

        public ERROR_CODE GetCurrentDeviceInfo(out string deviceId, out string deviceName)
        {
            var para = new { };
            var ret = AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                CApiTypeAudioDeviceManager.kGetCurrentAudioPlaybackDeviceInfo, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)),
                out _result);

            if (_result.result.Length > 0)
            {
                deviceName = (string) AgoraUtil.GetData<string>(_result.result, "deviceName");
                deviceId = (string) AgoraUtil.GetData<string>(_result.result, "deviceId");
            }
            else
            {
                deviceName = "";
                deviceId = "";
            }

            return (ERROR_CODE) (ret * -1);
        }

        /// <summary>
        /// Sets the volume of the device.
        /// </summary>
        /// 
        /// <param name="volume">
        /// @param volume Device volume. The value ranges between 0 (lowest volume) and 255 (highest volume).
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetDeviceVolume(int volume)
        {
            var para = new
            {
                volume
            };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                                     CApiTypeAudioDeviceManager.kSetAudioPlaybackDeviceVolume,
                                     Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)), out _result) *
                                 -1);
        }

        /// <summary>
        /// Retrieves the volume of the device.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - >=0: Device volume.
        /// - &lt;0: Failure.
        /// </returns>
        public int GetDeviceVolume()
        {
            var para = new { };
            return AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                CApiTypeAudioDeviceManager.kGetAudioPlaybackDeviceVolume, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)),
                out _result);
        }

        /// <summary>
        /// Mutes the device.
        /// </summary>
        /// 
        /// <param name="mute">
        /// @param mute Sets whether to mute/unmute the application:
        ///- true: Mute the application.
        ///- false: Unmute the application.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetDeviceMute(bool mute)
        {
            var para = new
            {
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                                     CApiTypeAudioDeviceManager.kSetAudioPlaybackDeviceMute,
                                     Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)), out _result) *
                                 -1);
        }

        /// <summary>
        /// Gets the mute state of the application.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// The mute state.
        /// </returns>
        public bool GetDeviceMute()
        {
            var para = new { };
            return AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                CApiTypeAudioDeviceManager.kGetAudioPlaybackDeviceMute, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)),
                out _result) == 1;
        }

        /// <summary>
        /// Starts the audio device test.
        ///
        ///This method tests if the playback device works properly. In the test, the SDK plays an audio file specified by the user. If the user can hear the audio, the playback device works properly.
        /// </summary>
        /// 
        /// <param name="testAudioFilePath">
        /// @param testAudioFilePath Pointer to the path of the audio file for the audio playback device test in UTF-8:
        /// - Supported file formats: wav, mp3, m4a, and aac.
        /// - Supported file sample rates: 8000, 16000, 32000, 44100, and 48000 Hz.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success, and you can hear the sound of the specified audio file.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StartDeviceTest(string testAudioFilePath)
        {
            var para = new
            {
                testAudioFilePath
            };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                                     CApiTypeAudioDeviceManager.kStartAudioPlaybackDeviceTest,
                                     Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)), out _result) *
                                 -1);
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
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                                     CApiTypeAudioDeviceManager.kStopAudioPlaybackDeviceTest,
                                     Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)), out _result) *
                                 -1);
        }

        /// <summary>
        /// /// Starts the audio device loopback test.
        ///
        /// This method tests whether the local audio devices are working properly. After calling this method, the microphone captures the local audio and plays it through the speaker. The \ref IRtcEngineEventHandler::onAudioVolumeIndication "onAudioVolumeIndication" callback returns the local audio volume information at the set interval.
        ///
        /// @note This method tests the local audio devices and does not report the network conditions.
        /// </summary>
        /// 
        /// <param name="indicationInterval">
        /// @param indicationInterval The time interval (ms) at which the \ref IRtcEngineEventHandler::onAudioVolumeIndication "onAudioVolumeIndication" callback returns.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StartDeviceLoopbackTest(int indicationInterval)
        {
            var para = new
            {
                indicationInterval
            };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                                     CApiTypeAudioDeviceManager.kStartAudioDeviceLoopbackTest,
                                     Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)), out _result) *
                                 -1);
        }

        /// <summary>
        /// Stops the audio device loopback test.
        ///
        ///@note Ensure that you call this method to stop the loopback test after calling the \ref IAudioDeviceManager::startAudioDeviceLoopbackTest "startAudioDeviceLoopbackTest" method.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StopDeviceLoopbackTest()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                                     CApiTypeAudioDeviceManager.kStopAudioDeviceLoopbackTest,
                                     Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)), out _result) *
                                 -1);
        }

        private void ReleaseAudioPlaybackDeviceManager()
        {
            AgoraRtcEngine.CreateRtcEngine().ReleaseAudioPlaybackDeviceManager();
            _audioPlaybackHandler = IntPtr.Zero;
        }

        ~AgoraAudioPlaybackDeviceManager()
        {
            Dispose(false);
        }
    }

    public class AgoraAudioRecordingDeviceManager : IDisposable
    {
        private IrisDeviceManagerPtr _audioRecordingHandler;
        private bool _disposed = false;
        private CharArrayAssistant _result;

        public AgoraAudioRecordingDeviceManager(IrisDeviceManagerPtr handler)
        {
            _audioRecordingHandler = handler;
            _result = new CharArrayAssistant();
        }

        /// <summary>
        /// Releases all IRtcAudioRecordingDeviceManager resources.
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

            ReleaseAudioRecordingDeviceManager();
            _disposed = true;
        }

        /// <summary>
        /// Retrieves the total number of audio recording devices.
        ///
        ///@note You must first call the \ref IAudioDeviceManager::enumerateRecordingDevices "enumerateRecordingDevices" method before calling this method to return the number of  audio playback or audio recording devices.
        /// </summary>
        /// 
        /// <returns>
        /// @return Number of audio recording devices.
        /// </returns>
        public int GetDeviceCount()
        {
            var para = new { };
            return AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                CApiTypeAudioDeviceManager.kGetAudioRecordingDeviceCount, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)),
                out _result);
        }

        /// <summary>
        /// Retrieves a specified piece of information about an indexed audio device.
        /// </summary>
        /// 
        /// <param name="index">
        /// @param index The specified index that must be less than the return value of \ref IAudioDeviceCollection::getCount "getCount".
        /// </param>
        /// 
        /// <param name="deviceName">
        /// @param deviceName Pointer to the audio device name.
        /// </param>
        /// 
        /// <param name="deviceId">
        /// @param deviceId Pointer to the audio device ID.
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
            var ret = (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                CApiTypeAudioDeviceManager.kGetAudioRecordingDeviceInfoByIndex,
                Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)), out _result) * -1);
            if (_result.result.Length > 0)
            {
                deviceName = (string) AgoraUtil.GetData<string>(_result.result, "deviceName");
                deviceId = (string) AgoraUtil.GetData<string>(_result.result, "deviceId");
            }
            else
            {
                deviceName = "";
                deviceId = "";
            }

            return ret;
        }

        /// <summary>
        /// Specifies a device with the device ID.
        /// </summary>
        /// 
        /// <param name="deviceId">
        /// @param deviceId Pointer to the device ID of the device.
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
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                CApiTypeAudioDeviceManager.kSetCurrentAudioRecordingDeviceId,
                Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)), out _result) * -1);
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

            return AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                       CApiTypeAudioDeviceManager.kGetCurrentAudioRecordingDeviceId, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)),
                       out _result) !=
                   0
                ? "GetDevice Failed."
                : _result.result;
        }

        public ERROR_CODE GetCurrentDeviceInfo(out string deviceId, out string deviceName)
        {
            var para = new { };
            var ret = AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                CApiTypeAudioDeviceManager.kGetCurrentAudioRecordingDeviceInfo, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)),
                out _result);

            if (_result.result.Length > 0)
            {
                deviceName = (string) AgoraUtil.GetData<string>(_result.result, "deviceName");
                deviceId = (string) AgoraUtil.GetData<string>(_result.result, "deviceId");
            }
            else
            {
                deviceName = "";
                deviceId = "";
            }

            return (ERROR_CODE) (ret * -1);
        }

        /// <summary>
        /// Sets the volume of the device.
        /// </summary>
        /// 
        /// <param name="volume">
        /// @param volume Device volume. The value ranges between 0 (lowest volume) and 255 (highest volume).
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetDeviceVolume(int volume)
        {
            var para = new
            {
                volume
            };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                                     CApiTypeAudioDeviceManager.kSetAudioRecordingDeviceVolume,
                                     Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)), out _result) *
                                 -1);
        }

        /// <summary>
        /// Retrieves the volume of the device.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - >=0: Device volume.
        /// - &lt;0: Failure.
        /// </returns>
        public int GetDeviceVolume()
        {
            var para = new { };
            return AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                CApiTypeAudioDeviceManager.kGetAudioRecordingDeviceVolume, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)),
                out _result);
        }

        /// <summary>
        /// Mutes the device.
        /// </summary>
        /// 
        /// <param name="mute">
        /// @param mute Sets whether to mute/unmute the application:
        ///- true: Mute the application.
        ///- false: Unmute the application.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetDeviceMute(bool mute)
        {
            var para = new
            {
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                                     CApiTypeAudioDeviceManager.kSetAudioRecordingDeviceMute,
                                     Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)), out _result) *
                                 -1);
        }

        /// <summary>
        /// Gets the mute state of the application.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// The mute state.
        /// </returns>
        public bool GetDeviceMute()
        {
            var para = new { };
            return AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                       CApiTypeAudioDeviceManager.kGetAudioRecordingDeviceMute, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)),
                       out _result) ==
                   1;
        }

        /// <summary>
        /// Starts the audio device test.
        ///
        ///This method tests if the recording device works properly. In the test, the SDK plays an audio file specified by the user.
        /// </summary>
        /// 
        /// <param name="testAudioFilePath">
        /// @param testAudioFilePath Pointer to the path of the audio file for the audio recording device test in UTF-8:
        /// - Supported file formats: wav, mp3, m4a, and aac.
        /// - Supported file sample rates: 8000, 16000, 32000, 44100, and 48000 Hz.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StartDeviceTest(string testAudioFilePath)
        {
            var para = new
            {
                testAudioFilePath
            };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                                     CApiTypeAudioDeviceManager.kStartAudioRecordingDeviceTest,
                                     Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)), out _result) *
                                 -1);
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
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                                     CApiTypeAudioDeviceManager.kStopAudioRecordingDeviceTest,
                                     Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)), out _result) *
                                 -1);
        }

        /// <summary>
        /// /// Starts the audio device loopback test.
        ///
        /// This method tests whether the local audio devices are working properly. After calling this method, the microphone captures the local audio and plays it through the speaker. The \ref IRtcEngineEventHandler::onAudioVolumeIndication "onAudioVolumeIndication" callback returns the local audio volume information at the set interval.
        ///
        /// @note This method tests the local audio devices and does not report the network conditions.
        /// </summary>
        /// 
        /// <param name="indicationInterval">
        /// @param indicationInterval The time interval (ms) at which the \ref IRtcEngineEventHandler::onAudioVolumeIndication "onAudioVolumeIndication" callback returns.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StartDeviceLoopbackTest(int indicationInterval)
        {
            var para = new
            {
                indicationInterval
            };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                                     CApiTypeAudioDeviceManager.kStartAudioDeviceLoopbackTest,
                                     Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)), out _result) *
                                 -1);
        }

        /// <summary>
        /// Stops the audio device loopback test.
        ///
        ///@note Ensure that you call this method to stop the loopback test after calling the \ref IAudioDeviceManager::startAudioDeviceLoopbackTest "startAudioDeviceLoopbackTest" method.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StopDeviceLoopbackTest()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                                     CApiTypeAudioDeviceManager.kStopAudioDeviceLoopbackTest,
                                     Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(para)), out _result) *
                                 -1);
        }

        private void ReleaseAudioRecordingDeviceManager()
        {
            AgoraRtcEngine.CreateRtcEngine().ReleaseAudioRecordingDeviceManager();
            _audioRecordingHandler = IntPtr.Zero;
        }

        ~AgoraAudioRecordingDeviceManager()
        {
            Dispose(false);
        }
    }
}