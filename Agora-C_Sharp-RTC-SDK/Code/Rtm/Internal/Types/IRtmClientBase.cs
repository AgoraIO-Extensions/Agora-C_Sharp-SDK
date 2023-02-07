using System;
namespace Agora.Rtm.Internal
{
    public class RtmConfig
    {
        public RtmConfig()
        {
            appId = "";
            userId = "";
            areaCode = AREA_CODE.AREA_CODE_GLOB;
            presenceTimeout = 300;
            useStringUserId = true;
            eventHandler = null;
            logConfig = new LogConfig();
            proxyConfig = new RtmProxyConfig();
            encryptionConfig = new RtmEncryptionConfig();
        }

        public RtmConfig(string appId, string userId, AREA_CODE areaCode, IRtmEventHandler eventHandler, LogConfig logConfig, RtmProxyConfig proxyConfig, RtmEncryptionConfig encryptionConfig)
        {
            this.appId = appId;
            this.userId = userId;
            this.areaCode = areaCode;
            this.eventHandler = eventHandler;
            this.logConfig = logConfig;
            this.proxyConfig = proxyConfig;
            this.encryptionConfig = encryptionConfig;
        }

        public RtmConfig(Rtm.RtmConfig config, IRtmEventHandler eventHandler)
        {
            this.appId = config.appId;
            this.userId = config.userId;
            this.areaCode = config.areaCode;
            this.presenceTimeout = config.presenceTimeout;
            this.useStringUserId = config.useStringUserId;
            this.eventHandler = eventHandler;
            this.logConfig = config.logConfig;
            this.proxyConfig = config.proxyConfig;
            this.encryptionConfig = config.encryptionConfig;
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

        public AREA_CODE areaCode;

        public UInt32 presenceTimeout;

        public bool useStringUserId;

        private IRtmEventHandler eventHandler;

        public LogConfig logConfig;

        public RtmProxyConfig proxyConfig;

        public RtmEncryptionConfig encryptionConfig;
    };
}
