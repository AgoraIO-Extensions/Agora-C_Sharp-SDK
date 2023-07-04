using System;
namespace Agora.Rtm
{
    public interface IStreamChannelCreator
    {
        void RemoveStreamChannelIfExist(string channelName);
    }
}
