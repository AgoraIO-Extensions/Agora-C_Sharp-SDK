using System;

namespace Agora.Rtc
{
    public partial class VideoEffectObject
    {
        private IRtcEngine _rtcEngineInstance = null;
        private VideoEffectObjectImpl _impl = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;
        private int _objectId = 0;

        private VideoEffectObject(IRtcEngine rtcEngine, VideoEffectObjectImpl impl, int objectId)
        {
            _rtcEngineInstance = rtcEngine;
            _impl = impl;
            _objectId = objectId;
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

        internal static IVideoEffectObject GetInstance(IRtcEngine rtcEngine, VideoEffectObjectImpl impl, int objectId)
        {
            return instance ?? (instance = new VideoEffectObject(rtcEngine, impl, objectId));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }
    }
}