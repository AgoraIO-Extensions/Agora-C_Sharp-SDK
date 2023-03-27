using System;
namespace Agora.Rtm
{
    public interface IRtmMessage
    {
        T GetData<T>();
    }
}
