using System;
namespace Agora.Rtc
{
    public abstract class IMediaPlayerCacheManager
    {
        public abstract int RemoveAllCaches();
      
        public abstract int RemoveOldCache();
     
        public abstract int RemoveCacheByUri(string uri) ;
      
        public abstract int SetCacheDir(string path) ;
      
        public abstract int SetMaxCacheFileCount(int count);
     
        public abstract int SetMaxCacheFileSize(Int64 cacheSize);
       
        public abstract int EnableAutoRemoveCache(bool enable);
      
        public abstract int GetCacheDir(out string path, int length);
      
        public abstract int GetMaxCacheFileCount();
       
        public abstract Int64 GetMaxCacheFileSize();
       
        public abstract int GetCacheFileCount();
    };

}
