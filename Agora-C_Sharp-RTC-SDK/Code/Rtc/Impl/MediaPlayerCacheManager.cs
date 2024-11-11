using System;
namespace Agora.Rtc
{
    public class MediaPlayerCacheManager : IMediaPlayerCacheManager
    {
        private IRtcEngine _rtcEngineInstance = null;
        private MediaPlayerCacheManagerImpl _mediaPlayerCacheManagerImpl = null;
        private const int ErrorCode = -7;
        private static System.Object rtcLock = new System.Object();

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
                lock (rtcLock)
                {
                    return instance;
                }
            }
        }

        internal static MediaPlayerCacheManager GetInstance(IRtcEngine rtcEngine, MediaPlayerCacheManagerImpl impl)
        {
            lock (rtcLock)
            {
                return instance ?? (instance = new MediaPlayerCacheManager(rtcEngine, impl));
            }
        }

        internal static void ReleaseInstance()
        {
            lock (rtcLock)
            {
                instance = null;
            }
        }

        public override int RemoveAllCaches()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerCacheManagerImpl.RemoveAllCaches();
            }
        }

        public override int RemoveOldCache()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerCacheManagerImpl.RemoveOldCache();
            }
        }

        public override int RemoveCacheByUri(string uri)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerCacheManagerImpl.RemoveCacheByUri(uri);
            }
        }

        public override int SetCacheDir(string path)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerCacheManagerImpl.SetCacheDir(path);
            }
        }

        public override int SetMaxCacheFileCount(int count)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerCacheManagerImpl.SetMaxCacheFileCount(count);
            }
        }

        public override int SetMaxCacheFileSize(long cacheSize)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerCacheManagerImpl.SetMaxCacheFileSize(cacheSize);
            }
        }

        public override int EnableAutoRemoveCache(bool enable)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerCacheManagerImpl.EnableAutoRemoveCache(enable);
            }
        }

        public override int GetCacheDir(out string path, int length)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
                {
                    path = "";
                    return ErrorCode;
                }
                return _mediaPlayerCacheManagerImpl.GetCacheDir(out path, length);
            }
        }

        public override int GetMaxCacheFileCount()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerCacheManagerImpl.GetMaxCacheFileCount();
            }
        }

        public override long GetMaxCacheFileSize()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerCacheManagerImpl.GetMaxCacheFileSize();
            }
        }

        public override int GetCacheFileCount()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _mediaPlayerCacheManagerImpl == null)
                {
                    return ErrorCode;
                }
                return _mediaPlayerCacheManagerImpl.GetCacheFileCount();
            }
        }
    }
}
