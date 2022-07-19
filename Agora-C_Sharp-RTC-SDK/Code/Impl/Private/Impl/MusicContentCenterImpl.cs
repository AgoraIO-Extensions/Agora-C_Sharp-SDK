using System;
namespace Agora.Rtc
{
    using IrisApiEnginePtr = IntPtr;
    using view_t = IntPtr;
    public class MusicContentCenterImpl
    {
        private bool _disposed = false;
        private IrisApiEnginePtr _irisApiEngine;
        private MediaPlayerImpl _mediaPlayerImpl;
        private MusicPlayerImpl _musicPlayerImpl;

        private CharAssistant _result;

        internal MusicContentCenterImpl(IrisApiEnginePtr irisApiEngine, MediaPlayerImpl impl)
        {
            _result = new CharAssistant();
            _irisApiEngine = irisApiEngine;
            _mediaPlayerImpl = impl;
            _musicPlayerImpl = new MusicPlayerImpl(irisApiEngine, _mediaPlayerImpl);
        }

        ~MusicContentCenterImpl()
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


        public IMusicPlayer CreateMusicPlayer()
        {
            var ret = AgoraRtcNative.CallIrisApi(_irisApiEngine,AgoraApiType.XXX,
                "", 0,
                IntPtr.Zero, 0,
                out _result);

            if (ret != 0)
            {
                return null;
            }
            else
            {
                int playId = (int)AgoraJson.GetData<int>(_result.Result, "result");
                var musicPlayer = new MusicPlayer(this._musicPlayerImpl, playId);
                return musicPlayer;
            }
        }

        public int DestroyMusicPlayer(IMusicPlayer player)
        {
            //todo 
            return 0;
        }


        public int GetLyric(string requestId, long songCode, int LyricType = 0)
        {
            var param = new {
                requestId,
                songCode,
                LyricType
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine,AgoraApiType.XXXX,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetMusicChart(string requestId, int musicChartType, int page, int pageSize, string jsonOption = "")
        {
            var param = new
            {
                requestId,
                musicChartType,
                page,
                pageSize,
                jsonOption
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.XXXX,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int GetMusicCharts(string requestId)
        {
            var param = new
            {
                requestId,
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.XXXX,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int Initialize(AgoraMusicContentCenterConfiguration configuration)
        {
            var param = new
            {
                configuration,
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.XXXX,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int IsPreloaded(long songCode, AgoraMediaType type, string resolution)
        {
            var param = new
            {
                songCode,
                type,
                resolution
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.XXXX,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int Preload(long songCode, AgoraMediaType type, string resolution)
        {
            var param = new
            {
                songCode,
                type,
                resolution
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.XXXX,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int RegisterEventHandler(IAgoraMusicContentCenterEventHandler eventHandler)
        {
            //todo 
            //var param = new
            //{
            //    songCode,
            //    type,
            //    resolution
            //};
            //string jsonParam = AgoraJson.ToJson(param);
            //var ret = AgoraRtcNative.CallIrisApi(
            //    _irisApiEngine, AgoraApiType.XXXX,
            //    jsonParam, (UInt32)jsonParam.Length,
            //    IntPtr.Zero, 0, out _result);
            //return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
            return 0;
        }

        public int SearchSong(string requestId, string keyWord, int page, int pageSize, string jsonOption = "")
        {
            var param = new
            {
                requestId,
                keyWord,
                page,
                pageSize,
                jsonOption
            };
            string jsonParam = AgoraJson.ToJson(param);
            var ret = AgoraRtcNative.CallIrisApi(
                _irisApiEngine, AgoraApiType.XXXX,
                jsonParam, (UInt32)jsonParam.Length,
                IntPtr.Zero, 0, out _result);
            return ret != 0 ? ret : (int)AgoraJson.GetData<int>(_result.Result, "result");
        }

        public int UnregisterEventHandler()
        {
            //todo 
            //throw new NotImplementedException();
            return 0;
        }
    }
}
