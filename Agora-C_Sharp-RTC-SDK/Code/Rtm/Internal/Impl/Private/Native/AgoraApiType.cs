namespace Agora.Rtm.Internal
{
    internal static class AgoraApiType
    {
        #region IStreamChannel start
        internal const string FUNC_STREAMCHANNEL_JOIN = "StreamChannel_join";
        internal const string FUNC_STREAMCHANNEL_RENEWTOKEN = "StreamChannel_renewToken";
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

        #region RtmMetadata start
        internal const string FUNC_METADATA_SETMAJORREVISION = "Metadata_setMajorRevision";
        internal const string FUNC_METADATA_SETMETADATAITEM = "Metadata_setMetadataItem";
        internal const string FUNC_METADATA_GETMETADATAITEMS = "Metadata_getMetadataItems";
        internal const string FUNC_METADATA_CLEARMETADATA = "Metadata_clearMetadata";
        internal const string FUNC_METADATA_RELEASE = "Metadata_release";
        #endregion

        #region IRtmStorage start
        internal const string FUNC_RTMSTORAGE_CREATEMETADATA = "RtmStorage_createMetadata";
        internal const string FUNC_RTMSTORAGE_SETCHANNELMETADATA = "RtmStorage_setChannelMetadata";
        internal const string FUNC_RTMSTORAGE_UPDATECHANNELMETADATA = "RtmStorage_updateChannelMetadata";
        internal const string FUNC_RTMSTORAGE_REMOVECHANNELMETADATA = "RtmStorage_removeChannelMetadata";
        internal const string FUNC_RTMSTORAGE_GETCHANNELMETADATA = "RtmStorage_getChannelMetadata";
        internal const string FUNC_RTMSTORAGE_SETUSERMETADATA = "RtmStorage_setUserMetadata";
        internal const string FUNC_RTMSTORAGE_UPDATEUSERMETADATA = "RtmStorage_updateUserMetadata";
        internal const string FUNC_RTMSTORAGE_REMOVEUSERMETADATA = "RtmStorage_removeUserMetadata";
        internal const string FUNC_RTMSTORAGE_GETUSERMETADATA = "RtmStorage_getUserMetadata";
        internal const string FUNC_RTMSTORAGE_SUBSCRIBEUSERMETADATA = "RtmStorage_subscribeUserMetadata";
        internal const string FUNC_RTMSTORAGE_UNSUBSCRIBEUSERMETADATA = "RtmStorage_unsubscribeUserMetadata";
        #endregion

        #region IRtmLock start
        internal const string FUNC_RTMLOCK_SETLOCK = "RtmLock_setLock";
        internal const string FUNC_RTMLOCK_GETLOCKS = "RtmLock_getLocks";
        internal const string FUNC_RTMLOCK_REMOVELOCK = "RtmLock_removeLock";
        internal const string FUNC_RTMLOCK_ACQUIRELOCK = "RtmLock_acquireLock";
        internal const string FUNC_RTMLOCK_RELEASELOCK = "RtmLock_releaseLock";
        internal const string FUNC_RTMLOCK_REVOKELOCK = "RtmLock_revokeLock";
        #endregion

        #region IRtmClient start
        internal const string FUNC_RTMCLIENT_INITIALIZE = "RtmClient_initialize";
        internal const string FUNC_RTMCLIENT_RELEASE = "RtmClient_release";
        internal const string FUNC_RTMCLIENT_LOGIN = "RtmClient_login";
        internal const string FUNC_RTMCLIENT_LOGOUT = "RtmClient_logout";
        internal const string FUNC_RTMCLIENT_GETSTORAGE = "RtmClient_getStorage";
        internal const string FUNC_RTMCLIENT_GETLOCK = "RtmClient_getLock";
        internal const string FUNC_RTMCLIENT_GETPRESENCE = "RtmClient_getPresence";
        internal const string FUNC_RTMCLIENT_RENEWTOKEN = "RtmClient_renewToken";
        internal const string FUNC_RTMCLIENT_PUBLISH = "RtmClient_publish";
        internal const string FUNC_RTMCLIENT_SUBSCRIBE = "RtmClient_subscribe";
        internal const string FUNC_RTMCLIENT_UNSUBSCRIBE = "RtmClient_unsubscribe";
        internal const string FUNC_RTMCLIENT_CREATESTREAMCHANNEL = "RtmClient_createStreamChannel";
        internal const string FUNC_RTMCLIENT_SETPARAMETERS = "RtmClient_setParameters";
        internal const string FUNC_RTMCLIENT_SETLOGFILE = "RtmClient_setLogFile";
        internal const string FUNC_RTMCLIENT_SETLOGLEVEL = "RtmClient_setLogLevel";
        internal const string FUNC_RTMCLIENT_SETLOGFILESIZE = "RtmClient_setLogFileSize";
        #endregion

        #region IRtmPresence start
        internal const string FUNC_RTMPRESENCE_WHONOW = "RtmPresence_whoNow";
        internal const string FUNC_RTMPRESENCE_WHERENOW = "RtmPresence_whereNow";
        internal const string FUNC_RTMPRESENCE_SETSTATE = "RtmPresence_setState";
        internal const string FUNC_RTMPRESENCE_REMOVESTATE = "RtmPresence_removeState";
        internal const string FUNC_RTMPRESENCE_GETSTATE = "RtmPresence_getState";
        internal const string FUNC_RTMPRESENCE_GETONLINEUSERS = "RtmPresence_getOnlineUsers";
        internal const string FUNC_RTMPRESENCE_GETUSERCHANNELS = "RtmPresence_getUserChannels";
        #endregion
    }
}