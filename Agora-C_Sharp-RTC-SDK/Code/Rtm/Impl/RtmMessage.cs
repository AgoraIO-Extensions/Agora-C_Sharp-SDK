using System;
namespace Agora.Rtm
{
    internal class RtmMessage : IRtmMessage
    {
        private byte[] _binaryMessage;
        private string _stringMessage;

        public RtmMessage(byte[] binaryMessage)
        {
            this._binaryMessage = binaryMessage;
            this._stringMessage = null;
        }

        public T GetData<T>()
        {
            Type t = typeof(T);
            if (t == typeof(byte[]))
            {
                return (T)(System.Object)this._binaryMessage;
            }
            else if (t == typeof(string))
            {
                // Convert only when a string is needed. to save performance
                if (this._stringMessage == null && this._binaryMessage != null && this._binaryMessage.Length > 0)
                {
                    this._stringMessage = System.Text.Encoding.UTF8.GetString(this._binaryMessage);
                }
                return (T)(System.Object)this._stringMessage;
            }
            else
            {
                return default(T);
            }
        }
    }
}
