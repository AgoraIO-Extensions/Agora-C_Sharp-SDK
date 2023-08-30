using System;
namespace Agora.Rtc
{
    ///
    /// <summary>
    /// This class provides methods to manage cached media files.
    /// </summary>
    ///
    public abstract class IMediaPlayerCacheManager
    {
#region terra IMediaPlayerCacheManager

        public abstract int RemoveAllCaches();

        public abstract int RemoveOldCache();

        public abstract int RemoveCacheByUri(string uri);

        public abstract int SetCacheDir(string path);

        public abstract int SetMaxCacheFileCount(int count);

        public abstract int SetMaxCacheFileSize(long cacheSize);

        public abstract int EnableAutoRemoveCache(bool enable);

        public abstract int GetCacheDir(ref string path, int length);

        public abstract int GetMaxCacheFileCount();

        public abstract long GetMaxCacheFileSize();

        public abstract int GetCacheFileCount();
#endregion terra IMediaPlayerCacheManager
    };
}