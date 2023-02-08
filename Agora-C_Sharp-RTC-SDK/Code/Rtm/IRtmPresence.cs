using System;
using System.Threading.Tasks;
namespace Agora.Rtm
{
    public interface IRtmPresence
    {
        Task<RtmResult<WhoNowResult>> WhoNow(string channelName, RTM_CHANNEL_TYPE channelType, PresenceOptions options);

        Task<RtmResult<WhereNowResult>> WhereNow(string userId);

        Task<RtmResult<SetStateResult>> SetState(string channelName, RTM_CHANNEL_TYPE channelType, StateItem[] items, int count);

        Task<RtmResult<RemoveStateResult>> RemoveState(string channelName, RTM_CHANNEL_TYPE channelType, string[] keys, int count);

        Task<RtmResult<GetStateResult>> GetState(string channelName, RTM_CHANNEL_TYPE channelType, string userId);
    }
}
