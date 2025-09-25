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

        public override int AddOrUpdateVideoEffect(uint nodeId, string templateName)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.AddOrUpdateVideoEffect(nodeId, templateName);
        }

        public override int RemoveVideoEffect(uint nodeId)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.RemoveVideoEffect(nodeId);
        }

        public override int PerformVideoEffectAction(uint nodeId, VIDEO_EFFECT_ACTION actionId)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.PerformVideoEffectAction(nodeId, actionId);
        }

        public override int SetVideoEffectFloatParam(string option, string key, float param)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.SetVideoEffectFloatParam(option, key, param);
        }

        public override int SetVideoEffectIntParam(string option, string key, int param)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.SetVideoEffectIntParam(option, key, param);
        }

        public override int SetVideoEffectBoolParam(string option, string key, bool param)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.SetVideoEffectBoolParam(option, key, param);
        }

        public override float GetVideoEffectFloatParam(string option, string key)
        {
            if (_impl == null)
            {
                return 0;
            }
            return _impl.GetVideoEffectFloatParam(option, key);
        }

        public override int GetVideoEffectIntParam(string option, string key)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.GetVideoEffectIntParam(option, key);
        }

        public override bool GetVideoEffectBoolParam(string option, string key)
        {
            if (_impl == null)
            {
                return false;
            }
            return _impl.GetVideoEffectBoolParam(option, key);
        }
    }
}