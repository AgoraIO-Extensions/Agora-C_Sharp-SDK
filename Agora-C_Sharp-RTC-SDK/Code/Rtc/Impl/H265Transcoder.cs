using System;

namespace Agora.Rtc
{
    public sealed class H265Transcoder : IH265Transcoder
    {
        private IRtcEngine _rtcEngineInstance = null;
        private H265TranscoderImpl _h265TranscoderImpl = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;

        internal H265Transcoder(IRtcEngine rtcEngine, H265TranscoderImpl impl)
        {
            _rtcEngineInstance = rtcEngine;
            _h265TranscoderImpl = impl;
        }

        ~H265Transcoder()
        {
            _h265TranscoderImpl = null;
            _rtcEngineInstance = null;
        }

        private static H265Transcoder instance = null;
        public static H265Transcoder Instance
        {
            get
            {
                return instance;
            }
        }

        internal static H265Transcoder GetInstance(IRtcEngine rtcEngine, H265TranscoderImpl impl)
        {
            return instance ?? (instance = new H265Transcoder(rtcEngine, impl));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }

        #region terra IH265Transcoder
        public override int EnableTranscode(string token, string channel, uint uid)
        {
            if (_rtcEngineInstance == null || _h265TranscoderImpl == null)
            {
                return ErrorCode;
            }
            return _h265TranscoderImpl.EnableTranscode(token, channel, uid);
        }

        public override int QueryChannel(string token, string channel, uint uid)
        {
            if (_rtcEngineInstance == null || _h265TranscoderImpl == null)
            {
                return ErrorCode;
            }
            return _h265TranscoderImpl.QueryChannel(token, channel, uid);
        }

        public override int TriggerTranscode(string token, string channel, uint uid)
        {
            if (_rtcEngineInstance == null || _h265TranscoderImpl == null)
            {
                return ErrorCode;
            }
            return _h265TranscoderImpl.TriggerTranscode(token, channel, uid);
        }

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
        #endregion terra IH265Transcoder
    }
}