using System;
using agora.rtc;

namespace APIExample
{
    // convenient to use
    public abstract class IEngine
    {
        internal abstract int Init(string appId, string channelId);
        internal abstract int UnInit();
        internal abstract int JoinChannel();
        internal abstract int LeaveChannel();
        internal virtual void SwitchVideoCanvas() { }
        // not necessary
        internal abstract string GetSDKVersion();
        internal abstract IAgoraRtcEngine GetEngine();
    }
}
