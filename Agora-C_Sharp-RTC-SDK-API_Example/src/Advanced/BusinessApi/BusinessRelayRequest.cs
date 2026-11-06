using System;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    // Builds relay credentials independently of the publishing user's join token/UID.
    internal sealed class BusinessRelayRequest
    {
        internal RtcConnection Connection { get; }
        internal ChannelMediaRelayConfiguration Configuration { get; }
        internal BusinessRelayRequest(RtcConnection source, string sourceToken, string targetChannel, uint targetUid, string targetToken)
        {
            if (string.IsNullOrWhiteSpace(source.channelId) || source.localUid == 0)
                throw new ArgumentException("请选择已加入的源连接（频道及非0本地UID）。");
            targetChannel = targetChannel?.Trim();
            if (string.IsNullOrWhiteSpace(targetChannel) || source.channelId == targetChannel)
                throw new ArgumentException("转发目标频道不能为空，也不能与源频道相同。");
            Connection = new RtcConnection(source.channelId, source.localUid);
            Configuration = new ChannelMediaRelayConfiguration
            {
                srcInfo = new ChannelMediaInfo { channelName = source.channelId, uid = 0, token = sourceToken?.Trim() ?? "" },
                destInfos = new[] { new ChannelMediaInfo { channelName = targetChannel, uid = targetUid, token = targetToken?.Trim() ?? "" } },
                destCount = 1
            };
        }
        internal object Arguments => new { configuration = Configuration, connection = Connection };
    }
}
