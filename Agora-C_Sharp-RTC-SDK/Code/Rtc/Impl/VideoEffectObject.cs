using System;

namespace Agora.Rtc
{
    public partial class VideoEffectObject
    {
        private IRtcEngine _rtcEngineInstance = null;
        private VideoEffectObjectImpl _impl = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;
        private int _objectId = 0;

        public VideoEffectObject(IRtcEngine rtcEngine, VideoEffectObjectImpl impl, int objectId)
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

        public override int GetObjectId()
        {
            return _objectId;
        }
    }
}