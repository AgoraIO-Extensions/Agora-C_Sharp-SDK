using System;
namespace Agora.Rtm.Internal
{

    public enum AppType
    {
        APP_TYPE_NATIVE = 0,
        APP_TYPE_COCOS = 1,
        APP_TYPE_UNITY = 2,
        APP_TYPE_ELECTRON = 3,
        APP_TYPE_FLUTTER = 4,
        APP_TYPE_UNREAL = 5,
        APP_TYPE_XAMARIN = 6,
        APP_TYPE_API_CLOUD = 7,
        APP_TYPE_REACT_NATIVE = 8,
        APP_TYPE_PYTHON = 9,
        APP_TYPE_COCOS_CREATOR = 10,
        APP_TYPE_RUST = 11,
        APP_TYPE_C_SHARP = 12,
        APP_TYPE_CEF = 13,
        APP_TYPE_UNI_APP = 14
    }

    public class PublishOptions
    {
        public RTM_CHANNEL_TYPE channelType;

        public RTM_MESSAGE_TYPE messageType;

        public string customType;

        public PublishOptions()
        {
        }

        public PublishOptions(Agora.Rtm.PublishOptions options, RTM_MESSAGE_TYPE messageType)
        {
            this.messageType = messageType;
            this.channelType = options.channelType;
            this.customType = options.customType;
        }
    };

    public class TopicMessageOptions
    {
        public RTM_MESSAGE_TYPE messageType;

        public UInt64 sendTs;

        public string customType;

        public TopicMessageOptions()
        {

        }

        public TopicMessageOptions(Agora.Rtm.TopicMessageOptions options, RTM_MESSAGE_TYPE messageType)
        {
            this.messageType = messageType;
            this.sendTs = options.sendTs;
            this.customType = options.customType;
        }
    };

    public class UserList
    {
        public UserList()
        {
            users = new string[0];
            userCount = 0;
        }

        public UserList(string[] users, uint userCount)
        {
            this.users = users;
            this.userCount = userCount;
        }

        public string[] users;

        public uint userCount;
    };

    public class Metadata
    {
        ///
        /// <summary>
        /// the major revision of metadata.
        /// </summary>
        ///
        public Int64 majorRevision;
        ///
        /// <summary>
        /// The metadata item array.
        /// </summary>
        ///
        public MetadataItem[] items;

        public ulong itemCount;

        public Metadata(Agora.Rtm.Metadata metadata)
        {
            this.majorRevision = metadata.majorRevision;
            this.items = metadata.items;
            this.itemCount = (ulong)metadata.items.Length;
        }
    }

}
