using System;

namespace Agora.Rtc
{
    public partial class VideoEffectObject
    {
        private IRtcEngine _rtcEngineInstance = null;
        private VideoEffectObjectImpl _impl = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;

        private VideoEffectObject(IRtcEngine rtcEngine, VideoEffectObjectImpl impl)
        {
            _rtcEngineInstance = rtcEngine;
            _impl = impl;
        }

        ~VideoEffectObject()
        {
            _rtcEngineInstance = null;
            _impl = null;
        }

        private static IVideoEffectObject instance = null;
        public static IVideoEffectObject Instance
        {
            get
            {
                return instance;
            }
        }

        internal static IVideoEffectObject GetInstance(IRtcEngine rtcEngine, VideoEffectObjectImpl impl)
        {
            return instance ?? (instance = new VideoEffectObject(rtcEngine, impl));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }
    }
}