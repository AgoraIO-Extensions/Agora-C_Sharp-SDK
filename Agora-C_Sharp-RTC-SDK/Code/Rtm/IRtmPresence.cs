using System;
using System.Threading.Tasks;
namespace Agora.Rtm
{
    public interface IRtmPresence
    {
        Task<RtmResult<WhoNowResult>> WhoNow(string channelName, RTM_CHANNEL_TYPE channelType, PresenceOptions options, ref UInt64 requestId);

        Task<RtmResult<WhereNowResult>> WhereNow(string userId, ref UInt64 requestId);

        Task<RtmResult<PresenceSetStateResult>> SetState(string channelName, RTM_CHANNEL_TYPE channelType, StateItem[] items, int count, ref UInt64 requestId);

        Task<RtmResult<PresenceRemoveStateResult>> RemoveState(string channelName, RTM_CHANNEL_TYPE channelType, string[] keys, int count, ref UInt64 requestId);

        Task<RtmResult<PresenceGetStateResult>> GetState(string channelName, RTM_CHANNEL_TYPE channelType, string userId, ref UInt64 requestId);
    }
}
