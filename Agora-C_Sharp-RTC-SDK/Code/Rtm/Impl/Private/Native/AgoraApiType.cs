namespace Agora.Rtm
{
    internal static class AgoraApiType
    {
        #region class IStreamChannel 
        internal const string FUNC_STREAMCHANNEL_JOIN = "StreamChannel_join";
        internal const string FUNC_STREAMCHANNEL_LEAVE = "StreamChannel_leave";
        internal const string FUNC_STREAMCHANNEL_GETCHANNELNAME = "StreamChannel_getChannelName";
        internal const string FUNC_STREAMCHANNEL_JOINTOPIC = "StreamChannel_joinTopic";
        internal const string FUNC_STREAMCHANNEL_PUBLISHTOPICMESSAGE = "StreamChannel_publishTopicMessage";
        internal const string FUNC_STREAMCHANNEL_LEAVETOPIC = "StreamChannel_leaveTopic";
        internal const string FUNC_STREAMCHANNEL_SUBSCRIBETOPIC = "StreamChannel_subscribeTopic";
        internal const string FUNC_STREAMCHANNEL_UNSUBSCRIBETOPIC = "StreamChannel_unsubscribeTopic";
        internal const string FUNC_STREAMCHANNEL_GETSUBSCRIBEDUSERLIST = "StreamChannel_getSubscribedUserList";
        internal const string FUNC_STREAMCHANNEL_RELEASE = "StreamChannel_release";
        #endregion

        #region class IRtmClient start
        internal const string FUNC_RTMCLIENT_INITIALIZE = "RtmClient_initialize";
        internal const string FUNC_RTMCLIENT_RELEASE = "RtmClient_release";
        internal const string FUNC_RTMCLIENT_CREATESTREAMCHANNEL = "RtmClient_createStreamChannel";
        #endregion
    }
}