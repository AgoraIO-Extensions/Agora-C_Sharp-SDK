using System;

namespace Agora.Rtc
{
    public partial class H265Transcoder
    {
        private IRtcEngine _rtcEngineInstance = null;
        private H265TranscoderImpl _impl = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;

        internal H265Transcoder(IRtcEngine rtcEngine, H265TranscoderImpl impl)
        {
            _rtcEngineInstance = rtcEngine;
            _impl = impl;
        }

        ~H265Transcoder()
        {
            _impl = null;
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
    }
}