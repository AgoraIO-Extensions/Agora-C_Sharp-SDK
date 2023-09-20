using System;
namespace Agora.Rtc
{
    /* class_imediaplayercachemanager */
    public abstract class IMediaPlayerCacheManager
    {
#region terra IMediaPlayerCacheManager

        /* api_imediaplayercachemanager_removeallcaches */
        public abstract int RemoveAllCaches();

        /* api_imediaplayercachemanager_removeoldcache */
        public abstract int RemoveOldCache();

        /* api_imediaplayercachemanager_removecachebyuri */
        public abstract int RemoveCacheByUri(string uri);

        /* api_imediaplayercachemanager_setcachedir */
        public abstract int SetCacheDir(string path);

        /* api_imediaplayercachemanager_setmaxcachefilecount */
        public abstract int SetMaxCacheFileCount(int count);

        /* api_imediaplayercachemanager_setmaxcachefilesize */
        public abstract int SetMaxCacheFileSize(long cacheSize);

        /* api_imediaplayercachemanager_enableautoremovecache */
        public abstract int EnableAutoRemoveCache(bool enable);

        /* api_imediaplayercachemanager_getcachedir */
        public abstract int GetCacheDir(ref string path, int length);

        /* api_imediaplayercachemanager_getmaxcachefilecount */
        public abstract int GetMaxCacheFileCount();

        /* api_imediaplayercachemanager_getmaxcachefilesize */
        public abstract long GetMaxCacheFileSize();

        /* api_imediaplayercachemanager_getcachefilecount */
        public abstract int GetCacheFileCount();
#endregion terra IMediaPlayerCacheManager
    };
}