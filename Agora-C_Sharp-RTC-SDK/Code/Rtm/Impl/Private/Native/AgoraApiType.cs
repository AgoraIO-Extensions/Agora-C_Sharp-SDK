namespace Agora.Rtm
{
    internal static class AgoraApiType
    {
        #region class IStreamChannel 
        internal const string FUNC_STREAMCHANNEL_JOIN = "StreamChannel_join";
        internal const string FUNC_STREAMCHANNEL_LEAVE = "StreamChannel_leave";
        internal const string FUNC_STREAMCHANNEL_CHANNELNAME = "StreamChannel_channelName";
        internal const string FUNC_STREAMCHANNEL_CREATETOPIC = "StreamChannel_createTopic";
        internal const string FUNC_STREAMCHANNEL_PUBLISHTOPIC = "StreamChannel_publishTopic";
        internal const string FUNC_STREAMCHANNEL_DESTROYTOPIC = "StreamChannel_destroyTopic";
        internal const string FUNC_STREAMCHANNEL_SUBSCRIBETOPIC = "StreamChannel_subscribeTopic";
        internal const string FUNC_STREAMCHANNEL_UNSUBSCRIBETOPIC = "StreamChannel_unsubscribeTopic";
        internal const string FUNC_STREAMCHANNEL_GETSUBSCRIBEDUSERLIST = "StreamChannel_getSubscribedUserList";
        #endregion

        #region class IRtmClient start
        internal const string FUNC_RTMCLIENT_INITIALIZE = "RtmClient_initialize";
        internal const string FUNC_RTMCLIENT_RELEASE = "RtmClient_release";
        internal const string FUNC_RTMCLIENT_CREATESTREAMCHANNEL = "RtmClient_createStreamChannel";
        internal const string FUNC_RTMCLIENT_RELEASESTREAMCHANNEL = "RtmClient_releaseStreamChannel";
        internal const string FUNC_RTMCLIENT_SETEVENTHANDLER = "RtmClient_setEventHandler";
        #endregion
    }
}