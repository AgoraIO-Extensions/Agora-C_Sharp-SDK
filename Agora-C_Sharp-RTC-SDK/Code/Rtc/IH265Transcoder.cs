using System;
namespace Agora.Rtc
{
    public abstract class IH265Transcoder : IH265TranscoderBase
    {

        #region terra IH265Transcoder


        public abstract int EnableTranscode(string token, string channel, uint uid);


        public abstract int QueryChannel(string token, string channel, uint uid);


        public abstract int TriggerTranscode(string token, string channel, uint uid);
        #endregion terra IH265Transcoder
    }
}
