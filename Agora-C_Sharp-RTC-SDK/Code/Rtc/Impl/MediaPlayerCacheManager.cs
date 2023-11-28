using System;
namespace Agora.Rtc
{
    public class MediaPlayerCacheManager : IMediaPlayerCacheManager
    {
        private IRtcEngine _rtcEngineInstance = null;
        private MediaPlayerCacheManagerImpl _mediaPlayerCacheManagerImpl = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;

        private MediaPlayerCacheManager(IRtcEngine rtcEngine, MediaPlayerCacheManagerImpl impl)
        {
            _rtcEngineInstance = rtcEngine;
            _mediaPlayerCacheManagerImpl = impl;
        }

        ~MediaPlayerCacheManager()
        {
            _rtcEngineInstance = null;
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

        #region terra IMediaPlayerCacheManager
        public override int RemoveAllCaches()
        {
            if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerCacheManagerImpl.RemoveAllCaches();
        }

        public override int RemoveOldCache()
        {
            if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerCacheManagerImpl.RemoveOldCache();
        }

        public override int RemoveCacheByUri(string uri)
        {
            if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerCacheManagerImpl.RemoveCacheByUri(uri);
        }

        public override int SetCacheDir(string path)
        {
            if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerCacheManagerImpl.SetCacheDir(path);
        }

        public override int SetMaxCacheFileCount(int count)
        {
            if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerCacheManagerImpl.SetMaxCacheFileCount(count);
        }

        public override int SetMaxCacheFileSize(long cacheSize)
        {
            if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerCacheManagerImpl.SetMaxCacheFileSize(cacheSize);
        }

        public override int EnableAutoRemoveCache(bool enable)
        {
            if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerCacheManagerImpl.EnableAutoRemoveCache(enable);
        }

        public override int GetCacheDir(ref string path, int length)
        {
            if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerCacheManagerImpl.GetCacheDir(ref path, length);
        }

        public override int GetMaxCacheFileCount()
        {
            if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerCacheManagerImpl.GetMaxCacheFileCount();
        }

        public override long GetMaxCacheFileSize()
        {
            if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerCacheManagerImpl.GetMaxCacheFileSize();
        }

        public override int GetCacheFileCount()
        {
            if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
            {
                return ErrorCode;
            }
            return _mediaPlayerCacheManagerImpl.GetCacheFileCount();
        }
        #endregion terra IMediaPlayerCacheManager
    }
}
