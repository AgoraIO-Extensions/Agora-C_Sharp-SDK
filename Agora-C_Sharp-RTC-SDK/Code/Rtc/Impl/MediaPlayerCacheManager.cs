using System;
namespace Agora.Rtc
{
    public partial class MediaPlayerCacheManager
    {
        private IRtcEngine _rtcEngineInstance = null;
        private MediaPlayerCacheManagerImpl _impl = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;

        private MediaPlayerCacheManager(IRtcEngine rtcEngine, MediaPlayerCacheManagerImpl impl)
        {
            _rtcEngineInstance = rtcEngine;
            _impl = impl;
        }

        ~MediaPlayerCacheManager()
        {
            _rtcEngineInstance = null;
            _impl = null;
        }

        private static MediaPlayerCacheManager instance = null;
        public static MediaPlayerCacheManager Instance
        {
            get
            {
                return instance;
            }
        }

        internal static MediaPlayerCacheManager GetInstance(IRtcEngine rtcEngine, MediaPlayerCacheManagerImpl impl)
        {
            return instance ?? (instance = new MediaPlayerCacheManager(rtcEngine, impl));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }
    }
}
