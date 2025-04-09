using System;

namespace Agora.Rtc
{
    public partial class LocalSpatialAudioEngine
    {
        private IRtcEngine _rtcEngineInstance = null;
        private LocalSpatialAudioEngineImpl _impl = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;

        private LocalSpatialAudioEngine(IRtcEngine rtcEngine, LocalSpatialAudioEngineImpl impl)
        {
            _rtcEngineInstance = rtcEngine;
            _impl = impl;
        }

        ~LocalSpatialAudioEngine()
        {
            _rtcEngineInstance = null;
            _impl = null;
        }

        private static ILocalSpatialAudioEngine instance = null;
        public static ILocalSpatialAudioEngine Instance
        {
            get
            {
                return instance;
            }
        }

        internal static ILocalSpatialAudioEngine GetInstance(IRtcEngine rtcEngine, LocalSpatialAudioEngineImpl impl)
        {
            return instance ?? (instance = new LocalSpatialAudioEngine(rtcEngine, impl));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }

        public override void Dispose()
        {
            if (_rtcEngineInstance == null || _impl == null)
            {
                return;
            }
            _impl.Dispose();
        }
    }
}