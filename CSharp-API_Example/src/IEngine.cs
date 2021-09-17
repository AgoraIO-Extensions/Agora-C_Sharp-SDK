using System;
using agora.rtc;

namespace CSharp_API_Example
{

    // convenient to use
    public abstract class IEngine
    {
        //protected IAgoraRtcEngine rtc_engine = null;
        //protected IAgoraRtcEngineEventHandler event_handler = null;

        //// must
        //protected string app_id = "";
        //protected string channel_id = "";

        internal abstract int Init(string appId, string channelId);
        internal abstract int unInit();
        internal abstract int joinChannel();
        internal abstract int leaveChannel();

        // not necessary
        internal abstract string getSDKVersion();
        internal abstract IAgoraRtcEngine getEngine();
    }
}
