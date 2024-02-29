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
        ///
        /// <summary>
        /// Deletes all cached media files in the media player.
        /// 
        /// The cached media file currently being played will not be deleted.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure. See MEDIA_PLAYER_REASON.
        /// </returns>
        ///
        public abstract int RemoveAllCaches();

        ///
        /// <summary>
        /// Deletes a cached media file that is the least recently used.
        /// 
        /// You can call this method to delete a cached media file when the storage space for the cached files is about to reach its limit. After you call this method, the SDK deletes the cached media file that is least used. The cached media file currently being played will not be deleted.
        /// </summary>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure. See MEDIA_PLAYER_REASON.
        /// </returns>
        ///
        public abstract int RemoveOldCache();

        ///
        /// <summary>
        /// Deletes a cached media file.
        /// 
        /// The cached media file currently being played will not be deleted.
        /// </summary>
        ///
        /// <param name="uri"> The URI (Uniform Resource Identifier) of the media file to be deleted. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure. See MEDIA_PLAYER_REASON.
        /// </returns>
        ///
        public abstract int RemoveCacheByUri(string uri);

        ///
        /// <summary>
        /// Sets the storage path for the media files that you want to cache.
        /// 
        /// Make sure IRtcEngine is initialized before you call this method.
        /// </summary>
        ///
        /// <param name="path"> The absolute path of the media files to be cached. Ensure that the directory for the media files exists and is writable. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure. See MEDIA_PLAYER_REASON.
        /// </returns>
        ///
        public abstract int SetCacheDir(string path);

        ///
        /// <summary>
        /// Sets the maximum number of media files that can be cached.
        /// </summary>
        ///
        /// <param name="count"> The maximum number of media files that can be cached. The default value is 1,000. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure. See MEDIA_PLAYER_REASON.
        /// </returns>
        ///
        public abstract int SetMaxCacheFileCount(int count);

        ///
        /// <summary>
        /// Sets the maximum size of the aggregate storage space for cached media files.
        /// </summary>
        ///
        /// <param name="cacheSize"> The maximum size (bytes) of the aggregate storage space for cached media files. The default value is 1 GB. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure. See MEDIA_PLAYER_REASON.
        /// </returns>
        ///
        public abstract int SetMaxCacheFileSize(long cacheSize);

        ///
        /// <summary>
        /// Sets whether to delete cached media files automatically.
        /// 
        /// If you enable this function to remove cached media files automatically, when the cached media files exceed either the number or size limit you set, the SDK automatically deletes the least recently used cache file.
        /// </summary>
        ///
        /// <param name="enable"> Whether to enable the SDK to delete cached media files automatically: true : Delete cached media files automatically. false : (Default) Do not delete cached media files automatically. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure. See MEDIA_PLAYER_REASON.
        /// </returns>
        ///
        public abstract int EnableAutoRemoveCache(bool enable);

        ///
        /// <summary>
        /// Gets the storage path of the cached media files.
        /// 
        /// If you have not called the SetCacheDir method to set the storage path for the media files to be cached before calling this method, you get the default storage path used by the SDK.
        /// </summary>
        ///
        /// <param name="path"> An output parameter; the storage path for the media file to be cached. </param>
        ///
        /// <param name="length"> An input parameter; the maximum length of the cache file storage path string. Fill in according to the cache file storage path string you obtained from path. </param>
        ///
        /// <returns>
        /// 0: Success.
        /// &lt; 0: Failure. See MEDIA_PLAYER_REASON.
        /// </returns>
        ///
        public abstract int GetCacheDir(ref string path, int length);

        ///
        /// <summary>
        /// Gets the maximum number of media files that can be cached.
        /// 
        /// By default, the maximum number of media files that can be cached is 1,000.
        /// </summary>
        ///
        /// <returns>
        /// &gt; 0: The call succeeds and returns the maximum number of media files that can be cached.
        /// &lt; 0: Failure. See MEDIA_PLAYER_REASON.
        /// </returns>
        ///
        public abstract int GetMaxCacheFileCount();

        ///
        /// <summary>
        /// Gets the maximum size of the aggregate storage space for cached media files.
        /// 
        /// By default, the maximum size of the aggregate storage space for cached media files is 1 GB. You can call the SetMaxCacheFileSize method to set the limit according to your scenarios.
        /// </summary>
        ///
        /// <returns>
        /// &gt; 0: The call succeeds and returns the maximum size (in bytes) of the aggregate storage space for cached media files.
        /// &lt; 0: Failure. See MEDIA_PLAYER_REASON.
        /// </returns>
        ///
        public abstract long GetMaxCacheFileSize();

        ///
        /// <summary>
        /// Gets the number of media files that are cached.
        /// </summary>
        ///
        /// <returns>
        /// ≥ 0: The call succeeds and returns the number of media files that are cached.
        /// &lt; 0: Failure. See MEDIA_PLAYER_REASON.
        /// </returns>
        ///
        public abstract int GetCacheFileCount();
        #endregion terra IMediaPlayerCacheManager
    };
}