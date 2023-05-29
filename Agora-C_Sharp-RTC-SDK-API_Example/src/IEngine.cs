using System;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    // convenient to use
    public abstract class IEngine
    {
        internal abstract int Init(string appId, string channelId);
        internal abstract int UnInit();
        internal abstract int JoinChannel();
        internal abstract int LeaveChannel();

        // not necessary
        internal abstract string GetSDKVersion();
        internal abstract IRtcEngine GetEngine();
    }
}
