using System;
namespace Agora.Rtm.Internal
{
    public interface IStreamChannelCreator
    {
        void RemoveStreamChannelIfExist(string channelName);
    }
}
