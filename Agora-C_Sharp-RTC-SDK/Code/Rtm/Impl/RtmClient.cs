using System.Collections.Generic;

namespace Agora.Rtm
{
    public sealed class RtmClient : IRtmClient
    {
        private RtmClientImpl _rtcClientImpl = null;
        private const int ErrorCode = -7;
        internal Dictionary<string, StreamChannel> _streamChannelDic = new Dictionary<string, StreamChannel>();

        public RtmClient()
        {
            _rtcClientImpl = RtmClientImpl.GetInstance();
        }

        ~RtmClient()
        {
            _rtcClientImpl = null;
        }

        private static IRtmClient instance = null;
        public static IRtmClient Instance
        {
            get
            {
                return instance ?? (instance = new RtmClient());
            }
        }

        public static IRtmClient CreateAgoraRtmClient()
        {
            return instance ?? (instance = new RtmClient());
        }

        public override int Initialize(RtmConfig config)
        {
            if(_rtcClientImpl == null)
            {
                return ErrorCode;
            }
            return _rtcClientImpl.Initialize(config);
        }

        public override int Release()
        {
            if(_rtcClientImpl == null)
            {
                return ErrorCode;
            }
           
            _rtcClientImpl.Dispose();
            _streamChannelDic.Clear();
            _rtcClientImpl = null;
            instance = null;

            return 0;
        }

        public override IStreamChannel CreateStreamChannel(string channelName)
        {
            if(_rtcClientImpl == null)
            {
                return null;
            }

            if(_streamChannelDic.ContainsKey(channelName))
            {
                return _streamChannelDic[channelName];
            }

            int ret = _rtcClientImpl.CreateStreamChannel(channelName);
            if (ret != 0)
            {
                return null;
            }

            StreamChannel streamChannel = new StreamChannel(this, _rtcClientImpl.GetStreamChannel(), channelName);
            _streamChannelDic.Add(channelName, streamChannel);
            return streamChannel;
        }
    }
}