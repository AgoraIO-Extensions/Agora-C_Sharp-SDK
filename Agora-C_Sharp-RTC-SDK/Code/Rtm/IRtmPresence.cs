using System;
using System.Threading.Tasks;
namespace Agora.Rtm
{
    public interface IRtmPresence
    {
        Task<RtmResult<WhoNowResult>> WhoNowAsync(string channelName, RTM_CHANNEL_TYPE channelType, PresenceOptions options);

        Task<RtmResult<WhereNowResult>> WhereNowAsync(string userId);

        Task<RtmResult<SetStateResult>> SetStateAsync(string channelName, RTM_CHANNEL_TYPE channelType, StateItem[] items);

        Task<RtmResult<RemoveStateResult>> RemoveStateAsync(string channelName, RTM_CHANNEL_TYPE channelType, string[] keys);

        Task<RtmResult<GetStateResult>> GetStateAsync(string channelName, RTM_CHANNEL_TYPE channelType, string userId);
    }
}
