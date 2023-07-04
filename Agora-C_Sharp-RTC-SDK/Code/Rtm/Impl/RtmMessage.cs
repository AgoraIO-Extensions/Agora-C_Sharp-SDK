using System;
namespace Agora.Rtm
{
    public class RtmMessage : IRtmMessage
    {
        private byte[] binaryMessage;
        private string stringMessage;

        public RtmMessage(byte[] binaryMessage)
        {
            this.binaryMessage = binaryMessage;
            this.stringMessage = null;
        }


        public T GetData<T>()
        {
            Type t = typeof(T);
            if (t == typeof(byte[]))
            {
                return (T)(System.Object)this.binaryMessage;
            }
            else if (t == typeof(string))
            {
                //Convert only when a string is needed. to save performance
                if (this.stringMessage == null && this.binaryMessage != null && this.binaryMessage.Length > 0)
                {
                    this.stringMessage = System.Text.Encoding.UTF8.GetString(this.binaryMessage);
                }
                return (T)(System.Object)this.stringMessage;
            }
            else
            {
                return default(T);
            }
        }
    }
}
