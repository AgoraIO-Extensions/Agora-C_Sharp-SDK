using System;
namespace Agora.Rtm
{
    /**
     * rtm message 
     */
    public interface IRtmMessage
    {
        /**
         * Get Data from IRtmMessage
         * 
         * - GetData<string>(): get a string data
         * - GetData<byte[]>(): get a byte[] data
         */
        T GetData<T>();
    }
}
