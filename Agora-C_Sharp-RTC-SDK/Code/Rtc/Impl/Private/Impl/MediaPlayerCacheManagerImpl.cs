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
        private IrisCApiParam _apiParam;
        private Dictionary<string, System.Object> _param = new Dictionary<string, object>();

        internal MediaPlayerCacheManagerImpl(IrisApiEnginePtr irisApiEngine)
        {
            _apiParam = new IrisCApiParam();
            _apiParam.AllocResult();
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
            _apiParam.FreeResult();
            _disposed = true;
        }


        public int RemoveAllCaches()
        {
            _param.Clear();

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_REMOVEALLCACHES,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int RemoveOldCache()
        {
            _param.Clear();

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_REMOVEOLDCACHE,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int RemoveCacheByUri(string uri)
        {
            _param.Clear();
            _param.Add("uri", uri);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_REMOVECACHEBYURI,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetCacheDir(string path)
        {
            _param.Clear();
            _param.Add("path", path);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_SETCACHEDIR,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetMaxCacheFileCount(int count)
        {
            _param.Clear();
            _param.Add("count", count);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_SETMAXCACHEFILECOUNT,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int SetMaxCacheFileSize(long cacheSize)
        {
            _param.Clear();
            _param.Add("cacheSize", cacheSize);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_SETMAXCACHEFILESIZE,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int EnableAutoRemoveCache(bool enable)
        {
            _param.Clear();
            _param.Add("enable", enable);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_ENABLEAUTOREMOVECACHE,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetCacheDir(out string path, int length)
        {
            _param.Clear();
            _param.Add("length", length);

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_GETCACHEDIR,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                ref _apiParam);

            if (ret == 0)
            {
                path = (string)AgoraJson.GetData<string>(_apiParam.Result, "path");
            }
            else
            {
                path = "";
            }

            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public int GetMaxCacheFileCount()
        {
            _param.Clear();

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_GETMAXCACHEFILECOUNT,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

        public long GetMaxCacheFileSize()
        {
            _param.Clear();

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_GETMAXCACHEFILESIZE,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return ret != 0 ? ret : (long)AgoraJson.GetData<long>(_apiParam.Result, "result");
        }

        public int GetCacheFileCount()
        {
            _param.Clear();

            string jsonParam = AgoraJson.ToJson(_param);
            var ret = AgoraRtcNative.CallIrisApiWithArgs(_irisApiEngine, AgoraApiType.FUNC_MEDIAPLAYERCACHEMANAGER_GETCACHEFILECOUNT,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0,
                ref _apiParam);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_apiParam.Result, "result");
        }

    }
}
