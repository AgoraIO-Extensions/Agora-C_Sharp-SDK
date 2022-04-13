using System;
using agora.rtc;

namespace CSharp_API_Example
{
    // convenient to use
    public abstract class IEngine
    {
        internal abstract int Init(string appId, string channelId);
        internal abstract int UnInit();
        internal abstract int JoinChannel();
        internal abstract int LeaveChannel();
        //AidoEffect
        public virtual int PlayEffect(int soundId, string filePath, int loopCount, int startPos, double pitch = 1.0,
            double pan = 0.0, int gain = 100, bool publish = false)
        { return -1; }
        public virtual int StopEffect(int soundId) { return 0; }
        public virtual int PauseEffect(int soundId) { return 0; }
        public virtual int ResumeEffect(int soundId) { return 0; }

        //DeviceManager
        public virtual agora.rtc.DeviceInfo[] GetVideoDevices() { return null; }
        public virtual agora.rtc.DeviceInfo[] GetRecordingDevices() { return null; }
        public virtual agora.rtc.DeviceInfo[] GetPlaybackDevices() { return null; }
        public virtual void SetVideoDevice(string id) {  }
        public virtual void SetRecordingDevice(string id) {  }
        public virtual void SetPlaybackDevice(string id) { }
        public virtual void SendStreamMessage(string str) { }

        //RtmpStreaming
        public virtual int AddPublishStreamUrl(string url) { return -1; }
        public virtual int RemovePublishStreamUrl(string url) { return -1; }

        //EnableEncryption
        public virtual int EnableEncryption(ENCRYPTION_MODE mode) { return -1; }
        //SetVideoEncoderConfiguration
        public virtual int setVideoEncoderConfiguration(agora.rtc.VideoDimensions dimension, agora.rtc.FRAME_RATE fps) { return -1; }
        // not necessary
        internal abstract string GetSDKVersion();
        internal abstract IAgoraRtcEngine GetEngine();
    }
}
