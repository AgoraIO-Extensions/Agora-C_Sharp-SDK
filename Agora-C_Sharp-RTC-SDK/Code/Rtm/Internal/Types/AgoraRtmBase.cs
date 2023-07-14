using System;
namespace Agora.Rtm.Internal
{
    public class PublishOptions
    {
        public RTM_MESSAGE_TYPE type;

        public UInt64 sendTs;

        public string customType;

        public PublishOptions()
        {
        }

        public PublishOptions(Agora.Rtm.PublishOptions options, RTM_MESSAGE_TYPE type)
        {
            this.type = type;
            this.sendTs = options.sendTs;
            this.customType = options.customType;
        }
    };
}
