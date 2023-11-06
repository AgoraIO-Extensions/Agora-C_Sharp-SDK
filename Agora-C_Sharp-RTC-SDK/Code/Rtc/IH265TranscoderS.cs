using System;
namespace Agora.Rtc
{
    public abstract class IH265TranscoderS : IH265TranscoderBase
    {

        #region terra IH265TranscoderS

        public abstract int EnableTranscode(string token, string channel, string userAccount);


        public abstract int QueryChannel(string token, string channel, string userAccount);


        public abstract int TriggerTranscode(string token, string channel, string userAccount);
        #endregion terra IH265TranscoderS
    }
}
