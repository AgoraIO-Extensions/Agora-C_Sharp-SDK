﻿using System;
namespace Agora.Rtm.Internal
{
    public class RtmConfig
    {
        public RtmConfig()
        {
            appId = "";
            userId = "";
            areaCode = RTM_AREA_CODE.GLOB;
            presenceTimeout = 300;
            useStringUserId = true;
            eventHandler = null;
            logConfig = new RtmLogConfig();
            proxyConfig = new RtmProxyConfig();
            encryptionConfig = new RtmEncryptionConfig();
        }

        public RtmConfig(Rtm.RtmConfig config, IRtmEventHandler eventHandler)
        {
            this.appId = config.appId;
            this.userId = config.userId;
            this.areaCode = config.areaCode;
            this.protocolType = config.protocolType;
            this.presenceTimeout = config.presenceTimeout;
            this.heartbeatInterval = config.heartbeatInterval;
            this.useStringUserId = config.useStringUserId;
            this.multipath = config.multipath;
            this.eventHandler = eventHandler;
            this.logConfig = config.logConfig;
            this.proxyConfig = config.proxyConfig;
            this.encryptionConfig = config.encryptionConfig;
            this.privateConfig = config.privateConfig;
        }

        public void setEventHandler(IRtmEventHandler eventHandler)
        {
            this.eventHandler = eventHandler;
        }

        public IRtmEventHandler getEventHandler()
        {
            return eventHandler;
        }

        public string appId;

        public string userId;

        public RTM_AREA_CODE areaCode;

        public RTM_PROTOCOL_TYPE protocolType;

        public UInt32 presenceTimeout;

        public UInt32 heartbeatInterval;

        public bool useStringUserId;

        public bool multipath;

        private IRtmEventHandler eventHandler;

        public RtmLogConfig logConfig;

        public RtmProxyConfig proxyConfig;

        public RtmEncryptionConfig encryptionConfig;

        public RtmPrivateConfig privateConfig;
    };

    public class IntervalInfo
    {
        public UserList joinUserList;

        public UserList leaveUserList;

        public UserList timeoutUserList;

        public UserState[] userStateList;

        public IntervalInfo()
        {
            userStateList = new UserState[0];
        }

        public Rtm.IntervalInfo GenerateIntervalInfo()
        {
            Rtm.IntervalInfo intervalInfo = new Rtm.IntervalInfo();
            intervalInfo.joinUserList = this.joinUserList.users;
            intervalInfo.leaveUserList = this.leaveUserList.users;
            intervalInfo.timeoutUserList = this.timeoutUserList.users;
            intervalInfo.userStateList = this.userStateList;
            return intervalInfo;
        }
    };

    public class PresenceEvent
    {
        public PresenceEvent()
        {
            type = RTM_PRESENCE_EVENT_TYPE.NONE;
            channelType = RTM_CHANNEL_TYPE.NONE;
            channelName = "";
            publisher = "";
            stateItems = new StateItem[0];
            interval = new IntervalInfo();
            snapshot = new SnapshotInfo();
        }
        public RTM_PRESENCE_EVENT_TYPE type;

        public RTM_CHANNEL_TYPE channelType;

        public string channelName;

        public string publisher;

        public StateItem[] stateItems;

        public Internal.IntervalInfo interval;

        public SnapshotInfo snapshot;

        public UInt64 timestamp;

        public Rtm.PresenceEvent GeneratePresenceEvent()
        {
            Rtm.PresenceEvent presenceEvent = new Rtm.PresenceEvent();
            presenceEvent.type = this.type;
            presenceEvent.channelType = this.channelType;
            presenceEvent.channelName = this.channelName;
            presenceEvent.publisher = this.publisher;
            presenceEvent.stateItems = this.stateItems;
            presenceEvent.interval = this.interval.GenerateIntervalInfo();
            presenceEvent.snapshot = this.snapshot;
            presenceEvent.timestamp = this.timestamp;
            return presenceEvent;
        }
    };
}
