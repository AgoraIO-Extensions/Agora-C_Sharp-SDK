using System;
using System.Collections.Generic;
namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;
    using view_t = IntPtr;

    public class MediaPlayerCacheManagerImpl
    {

        private bool _disposed = false;
        private IrisApiEnginePtr _irisApiEngine;
        private CharAssistant _result;
        Dictionary<string, System.Object> param = new Dictionary<string, System.Object>();

        internal MediaPlayerCacheManagerImpl(IrisApiEnginePtr irisApiEngine)
        {
            _result = new CharAssistant();
            _irisApiEngine = irisApiEngine;
        }

        ~MediaPlayerCacheManagerImpl()
        {
            Dispose(false);
        }

        internal void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
            }

            _irisApiEngine = IntPtr.Zero;
            _result = new CharAssistant();
            _disposed = true;
        }


        public int RemoveAllCaches()
        {
            param.Clear();

            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_REMOVEALLCACHES,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                out _result);

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int RemoveOldCache()
        {
            param.Clear();

            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_REMOVEOLDCACHE,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                out _result);

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int RemoveCacheByUri(string uri)
        {
            param.Clear();
            param.Add("uri", uri);

            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_REMOVECACHEBYURI,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                out _result);

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SetCacheDir(string path)
        {
            param.Clear();
            param.Add("path", path);

            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_SETCACHEDIR,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                out _result);

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SetMaxCacheFileCount(int count)
        {
            param.Clear();
            param.Add("count", count);

            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_SETMAXCACHEFILECOUNT,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                out _result);

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int SetMaxCacheFileSize(long cacheSize)
        {
            param.Clear();
            param.Add("cacheSize", cacheSize);

            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_SETMAXCACHEFILESIZE,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                out _result);

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int EnableAutoRemoveCache(bool enable)
        {
            param.Clear();
            param.Add("enable", enable);

            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_ENABLEAUTOREMOVECACHE,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                out _result);

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetCacheDir(out string path, int length)
        {
            param.Clear();
            param.Add("length", length);

            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_GETCACHEDIR,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                out _result);

            if (ret == 0)
            {
                path = (string)AgoraJson.GetData<string>(_result.Result, "path");
            }
            else
            {
                path = "";
            }

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetMaxCacheFileCount()
        {
            param.Clear();

            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_GETMAXCACHEFILECOUNT,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public long GetMaxCacheFileSize()
        {
            param.Clear();

            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_GETMAXCACHEFILESIZE,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                out _result);
            return ret != 0 ? ret : (long)AgoraJson.GetData<long>(_result.Result, "result");
        }

        public int GetCacheFileCount()
        {
            param.Clear();

            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_GETCACHEFILECOUNT,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

    }
}
