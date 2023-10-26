using System;

namespace Agora.Rtc
{
    using view_t = Int64;
    public sealed class H265TranscoderS : IH265TranscoderS
    {
        private IRtcEngineBase _rtcEngineInstance = null;
        private H265TranscoderImplS _h265TranscoderImpl = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;

        internal H265TranscoderS(IRtcEngineBase rtcEngine, H265TranscoderImplS impl)
        {
            _rtcEngineInstance = rtcEngine;
            _h265TranscoderImpl = impl;
        }

        ~H265TranscoderS()
        {
            _h265TranscoderImpl = null;
            _rtcEngineInstance = null;
        }

        private static H265TranscoderS instance = null;
        public static H265TranscoderS Instance
        {
            get
            {
                return instance;
            }
        }

        internal static H265TranscoderS GetInstance(IRtcEngineBase rtcEngine, H265TranscoderImplS impl)
        {
            return instance ?? (instance = new H265TranscoderS(rtcEngine, impl));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }

        #region terra IH265TranscoderS


        public override int RegisterTranscoderObserver(IH265TranscoderObserver observer)
        {
            if (_rtcEngineInstance == null || _h265TranscoderImpl == null)
            {
                return ErrorCode;
            }
            return _h265TranscoderImpl.RegisterTranscoderObserver(observer);
        }

        public override int UnregisterTranscoderObserver()
        {
            if (_rtcEngineInstance == null || _h265TranscoderImpl == null)
            {
                return ErrorCode;
            }
            return _h265TranscoderImpl.UnregisterTranscoderObserver();
        }

        public override int EnableTranscode(string token, string channel, string userAccount)
        {
            if (_rtcEngineInstance == null || _h265TranscoderImpl == null)
            {
                return ErrorCode;
            }
            return _h265TranscoderImpl.EnableTranscode(token, channel, userAccount);
        }

        public override int QueryChannel(string token, string channel, string userAccount)
        {
            if (_rtcEngineInstance == null || _h265TranscoderImpl == null)
            {
                return ErrorCode;
            }
            return _h265TranscoderImpl.QueryChannel(token, channel, userAccount);
        }

        public override int TriggerTranscode(string token, string channel, string userAccount)
        {
            if (_rtcEngineInstance == null || _h265TranscoderImpl == null)
            {
                return ErrorCode;
            }
            return _h265TranscoderImpl.TriggerTranscode(token, channel, userAccount);
        }
        #endregion terra IH265TranscoderS
    }
}