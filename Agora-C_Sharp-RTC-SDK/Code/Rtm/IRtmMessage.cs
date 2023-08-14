using System;
namespace Agora.Rtm
{
    ///
    /// <summary>
    /// rtm message
    /// </summary>
    ///
    public interface IRtmMessage
    {
        ///
        /// <summary>
        /// Get Data from IRtmMessage
        /// - GetData<string>(): get a string data
        /// - GetData<byte[]>(): get a byte[] data
        /// </summary>
        ///
        T GetData<T>();
    }
}
