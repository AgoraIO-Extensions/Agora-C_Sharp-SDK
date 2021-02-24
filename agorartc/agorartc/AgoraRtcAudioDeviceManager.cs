using System;
using System.Text.Json;

namespace agorartc
{
    using IrisDeviceManagerPtr = IntPtr;

    public class AgoraAudioPlaybackDeviceManager : IDisposable
    {
        private IrisDeviceManagerPtr _audioPlaybackHandler;
        private bool _disposed = false;
        private char[] result = new char[2048];

        internal AgoraAudioPlaybackDeviceManager(IrisDeviceManagerPtr handler)
        {
            _audioPlaybackHandler = handler;
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

            ReleaseAudioPlaybackDeviceManager();
            _disposed = true;
        }

        public int GetDeviceCount()
        {
            var para = new { };
            return AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                CApiTypeAudioDeviceManager.kGetAudioPlaybackDeviceCount, JsonSerializer.Serialize(para), result);
        }

        public ERROR_CODE GetDeviceInfoByIndex(int index, char[] deviceName, char[] deviceId)
        {
            var para = new
            {
                index
            };
            var ret = (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                CApiTypeAudioDeviceManager.kGetAudioPlaybackDeviceInfoByIndex,
                JsonSerializer.Serialize(para), result) * -1);
            deviceName = ((string) AgoraUtil.GetData<string>(result, "deviceName")).ToCharArray();
            deviceId = ((string) AgoraUtil.GetData<string>(result, "deviceId")).ToCharArray();
            return ret;
        }

        public ERROR_CODE SetCurrentDevice(string deviceId)
        {
            var para = new
            {
                deviceId
            };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                CApiTypeAudioDeviceManager.kSetCurrentAudioPlaybackDeviceId,
                JsonSerializer.Serialize(para), result) * -1);
        }

        public string GetCurrentDevice()
        {
            var para = new { };

            return AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                       CApiTypeAudioDeviceManager.kGetCurrentAudioPlaybackDeviceId, JsonSerializer.Serialize(para),
                       result) !=
                   0
                ? "GetDevice Failed."
                : new string(result[..Array.IndexOf(result, '\0')]);
        }

        public ERROR_CODE GetCurrentDeviceInfo(char[] deviceId, char[] deviceName)
        {
            var para = new { };
            var ret = AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                CApiTypeAudioDeviceManager.kGetCurrentAudioPlaybackDeviceInfo, JsonSerializer.Serialize(para), result);
            
            switch (ret)
            {
                case 0:
                    deviceId = ((string) AgoraUtil.GetData<string>(result, "deviceId")).ToCharArray();
                    deviceName = ((string) AgoraUtil.GetData<string>(result, "deviceName")).ToCharArray();
                    break;
            }
            return (ERROR_CODE) (ret * -1);
        }

        public ERROR_CODE SetDeviceVolume(int volume)
        {
            var para = new
            {
                volume
            };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                CApiTypeAudioDeviceManager.kSetAudioPlaybackDeviceVolume, JsonSerializer.Serialize(para), result) * -1);
        }
        
        public int GetDeviceVolume()
        {
            var para = new { };
            return AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                CApiTypeAudioDeviceManager.kGetAudioPlaybackDeviceVolume, JsonSerializer.Serialize(para), result);
        }

        public ERROR_CODE SetDeviceMute(bool mute)
        {
            var para = new
            {
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                CApiTypeAudioDeviceManager.kSetAudioPlaybackDeviceMute, JsonSerializer.Serialize(para), result) * -1);
        }
        
        public bool GetDeviceMute()
        {
            var para = new { };
            return AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                CApiTypeAudioDeviceManager.kGetAudioPlaybackDeviceMute, JsonSerializer.Serialize(para), result) == 1;
        }

        public ERROR_CODE StartDeviceTest(string testAudioFilePath)
        {
            var para = new
            {
                testAudioFilePath
            };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                CApiTypeAudioDeviceManager.kStartAudioPlaybackDeviceTest, JsonSerializer.Serialize(para), result) * -1);
        }
        
        public ERROR_CODE StopDeviceTest()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                CApiTypeAudioDeviceManager.kStopAudioPlaybackDeviceTest, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StartDeviceLoopbackTest(int indicationInterval)
        {
            var para = new
            {
                indicationInterval
            };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                CApiTypeAudioDeviceManager.kStartAudioDeviceLoopbackTest, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StopDeviceLoopbackTest()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioPlaybackHandler,
                CApiTypeAudioDeviceManager.kStopAudioDeviceLoopbackTest, JsonSerializer.Serialize(para), result) * -1);
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
        private char[] result = new char[2048];

        public AgoraAudioRecordingDeviceManager(IrisDeviceManagerPtr handler)
        {
            _audioRecordingHandler = handler;
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

            ReleaseAudioRecordingDeviceManager();
            _disposed = true;
        }

        public int GetDeviceCount()
        {
            var para = new { };
            return AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                CApiTypeAudioDeviceManager.kGetAudioRecordingDeviceCount, JsonSerializer.Serialize(para), result);
        }

        public ERROR_CODE GetDeviceInfoByIndex(int index, char[] deviceName, char[] deviceId)
        {
            var para = new
            {
                index
            };
            var ret = (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                CApiTypeAudioDeviceManager.kGetAudioRecordingDeviceInfoByIndex,
                JsonSerializer.Serialize(para), result) * -1);
            deviceName = ((string) AgoraUtil.GetData<string>(result, "deviceName")).ToCharArray();
            deviceId = ((string) AgoraUtil.GetData<string>(result, "deviceId")).ToCharArray();
            return ret;
        }

        public ERROR_CODE SetCurrentDevice(string deviceId)
        {
            var para = new
            {
                deviceId
            };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                CApiTypeAudioDeviceManager.kSetCurrentAudioRecordingDeviceId,
                JsonSerializer.Serialize(para), result) * -1);
        }

        public string GetCurrentDevice()
        {
            var para = new { };

            return AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                       CApiTypeAudioDeviceManager.kGetCurrentAudioRecordingDeviceId, JsonSerializer.Serialize(para),
                       result) !=
                   0
                ? "GetDevice Failed."
                : new string(result[..Array.IndexOf(result, '\0')]);
        }

        public ERROR_CODE GetCurrentDeviceInfo(char[] deviceId, char[] deviceName)
        {
            var para = new { };
            var ret = AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                CApiTypeAudioDeviceManager.kGetCurrentAudioRecordingDeviceInfo, JsonSerializer.Serialize(para), result);
            
            switch (ret)
            {
                case 0:
                    deviceId = ((string) AgoraUtil.GetData<string>(result, "deviceId")).ToCharArray();
                    deviceName = ((string) AgoraUtil.GetData<string>(result, "deviceName")).ToCharArray();
                    break;
            }
            return (ERROR_CODE) (ret * -1);
        }

        public ERROR_CODE SetDeviceVolume(int volume)
        {
            var para = new
            {
                volume
            };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                CApiTypeAudioDeviceManager.kSetAudioRecordingDeviceVolume, JsonSerializer.Serialize(para), result) * -1);
        }
        
        public int GetDeviceVolume()
        {
            var para = new { };
            return AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                CApiTypeAudioDeviceManager.kGetAudioRecordingDeviceVolume, JsonSerializer.Serialize(para), result);
        }

        public ERROR_CODE SetDeviceMute(bool mute)
        {
            var para = new
            {
                mute
            };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                CApiTypeAudioDeviceManager.kSetAudioRecordingDeviceMute, JsonSerializer.Serialize(para), result) * -1);
        }
        
        public bool GetDeviceMute()
        {
            var para = new { };
            return AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                CApiTypeAudioDeviceManager.kGetAudioRecordingDeviceMute, JsonSerializer.Serialize(para), result) == 1;
        }

        public ERROR_CODE StartDeviceTest(string testAudioFilePath)
        {
            var para = new
            {
                testAudioFilePath
            };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                CApiTypeAudioDeviceManager.kStartAudioRecordingDeviceTest, JsonSerializer.Serialize(para), result) * -1);
        }
        
        public ERROR_CODE StopDeviceTest()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                CApiTypeAudioDeviceManager.kStopAudioRecordingDeviceTest, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StartDeviceLoopbackTest(int indicationInterval)
        {
            var para = new
            {
                indicationInterval
            };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                CApiTypeAudioDeviceManager.kStartAudioDeviceLoopbackTest, JsonSerializer.Serialize(para), result) * -1);
        }

        public ERROR_CODE StopDeviceLoopbackTest()
        {
            var para = new { };
            return (ERROR_CODE) (AgorartcNative.CallAudioDeviceApi(_audioRecordingHandler,
                CApiTypeAudioDeviceManager.kStopAudioDeviceLoopbackTest, JsonSerializer.Serialize(para), result) * -1);
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