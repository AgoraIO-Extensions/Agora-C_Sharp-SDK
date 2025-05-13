using System;
using System.Runtime.InteropServices;

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

        public bool storeInHistory;

        public PublishOptions()
        {
        }

        public PublishOptions(Agora.Rtm.PublishOptions options, RTM_MESSAGE_TYPE messageType)
        {
            this.messageType = messageType;
            this.channelType = options.channelType;
            this.customType = options.customType;
            this.storeInHistory = options.storeInHistory;
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

        public Metadata()
        {

        }

        public Metadata(Agora.Rtm.Metadata metadata)
        {
            this.majorRevision = metadata.majorRevision;
            this.items = metadata.items;
            this.itemCount = (ulong)metadata.items.Length;
        }
    }

    public class MessageEvent
    {
        public RTM_CHANNEL_TYPE channelType;

        public RTM_MESSAGE_TYPE messageType;

        public string channelName;

        public string channelTopic;

        public IntPtr message;

        public uint messageLength;

        public string publisher;

        public string customType;

        public MessageEvent()
        {
            channelType = RTM_CHANNEL_TYPE.NONE;
            messageType = RTM_MESSAGE_TYPE.STRING;
            channelName = "";
            channelTopic = "";
            message = IntPtr.Zero;
            messageLength = 0;
            publisher = "";
            customType = "";
        }


        public Rtm.MessageEvent GenerateMessageEvent()
        {
            Rtm.MessageEvent messageEvent = new Rtm.MessageEvent();
            messageEvent.channelType = this.channelType;
            messageEvent.messageType = this.messageType;
            messageEvent.channelName = this.channelName;
            messageEvent.channelTopic = this.channelTopic;

            var byteData = new byte[this.messageLength];
            if (this.messageLength != 0)
            {
                Marshal.Copy((IntPtr)this.message, byteData, 0, (int)this.messageLength);
            }
            messageEvent.message = new RtmMessage(byteData);
            messageEvent.publisher = this.publisher;
            messageEvent.customType = this.customType;
            return messageEvent;
        }
    };

    public class HistoryMessage
    {

        public RTM_MESSAGE_TYPE messageType;
        ///
        /// <summary>
        /// The publisher
        /// </summary>
        ///
        public string publisher;
        ///
        /// <summary>
        /// The payload
        /// </summary>
        ///
        public IntPtr message;
        ///
        /// <summary>
        /// The payload length
        /// </summary>
        ///
        public UInt64 messageLength;
        ///
        /// <summary>
        /// The custom type of the message
        /// </summary>
        ///
        public string customType;
        ///
        /// <summary>
        /// Timestamp of the message received by rtm server
        /// </summary>
        ///
        public UInt64 timestamp;


        public HistoryMessage()
        {
            messageType = RTM_MESSAGE_TYPE.STRING;
            publisher = "";
            message = IntPtr.Zero;
            messageLength = 0;
            customType = "";
            timestamp = 0;
        }


        public Rtm.HistoryMessage GenerateHistoryMessage()
        {
            Rtm.HistoryMessage historyMessage = new Rtm.HistoryMessage();
            historyMessage.messageType = this.messageType;
            var byteData = new byte[this.messageLength];
            if (this.messageLength != 0)
            {
                Marshal.Copy((IntPtr)this.message, byteData, 0, (int)this.messageLength);
            }
            historyMessage.message = new RtmMessage(byteData);
            historyMessage.publisher = this.publisher;
            historyMessage.customType = this.customType;
            historyMessage.timestamp = this.timestamp;
            return historyMessage;
        }

    };

}
