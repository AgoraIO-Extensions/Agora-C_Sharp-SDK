using System;

namespace Agora.Rtc
{
    public sealed class MusicContentCenter : IMusicContentCenter
    {
        private IRtcEngine _rtcEngineInstance = null;
        private MusicContentCenterImpl _musicContentCenterImpl = null;
        private const int ErrorCode = -(int)ERROR_CODE_TYPE.ERR_NOT_INITIALIZED;

        public MusicContentCenter(IRtcEngine rtcEngine, MusicContentCenterImpl impl)
        {
            _rtcEngineInstance = rtcEngine;
            _musicContentCenterImpl = impl;
        }

        ~MusicContentCenter()
        {
            _rtcEngineInstance = null;
        }

        private static IMusicContentCenter instance = null;
        internal static IMusicContentCenter GetInstance(IRtcEngine rtcEngine, MusicContentCenterImpl impl)
        {
            return instance ?? (instance = new MusicContentCenter(rtcEngine, impl));
        }

        internal static void ReleaseInstance()
        {
            instance = null;
        }

        #region terra IMusicContentCenter
        public override int Initialize(MusicContentCenterConfiguration configuration)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.Initialize(configuration);
        }

        public override int RenewToken(string token)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.RenewToken(token);
        }

        public override int RegisterEventHandler(IMusicContentCenterEventHandler eventHandler)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.RegisterEventHandler(eventHandler);
        }

        public override int UnregisterEventHandler()
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.UnregisterEventHandler();
        }

        public override IMusicPlayer CreateMusicPlayer()
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return null;
            }
            return _musicContentCenterImpl.CreateMusicPlayer();
        }

        public override int DestroyMusicPlayer(IMusicPlayer music_player)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.DestroyMusicPlayer(music_player);
        }

        public override int GetMusicCharts(ref string requestId)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.GetMusicCharts(ref requestId);
        }

        public override int GetMusicCollectionByMusicChartId(ref string requestId, int musicChartId, int page, int pageSize, string jsonOption = "")
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.GetMusicCollectionByMusicChartId(ref requestId, musicChartId, page, pageSize, jsonOption);
        }

        public override int SearchMusic(ref string requestId, string keyWord, int page, int pageSize, string jsonOption = "")
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.SearchMusic(ref requestId, keyWord, page, pageSize, jsonOption);
        }

        [Obsolete("This method is deprecated. Use preload(int64_t songCode) instead.")]
        public override int Preload(long songCode, string jsonOption)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.Preload(songCode, jsonOption);
        }

        public override int Preload(ref string requestId, long songCode)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.Preload(ref requestId, songCode);
        }

        public override int RemoveCache(long songCode)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.RemoveCache(songCode);
        }

        public override int GetCaches(ref MusicCacheInfo[] cacheInfo, ref int cacheInfoSize)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.GetCaches(ref cacheInfo, ref cacheInfoSize);
        }

        public override int IsPreloaded(long songCode)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.IsPreloaded(songCode);
        }

        public override int GetLyric(ref string requestId, long songCode, int lyricType = 0)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.GetLyric(ref requestId, songCode, lyricType);
        }

        public override int GetSongSimpleInfo(ref string requestId, long songCode)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.GetSongSimpleInfo(ref requestId, songCode);
        }

        public override int GetInternalSongCode(long songCode, string jsonOption, ref long internalSongCode)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.GetInternalSongCode(songCode, jsonOption, ref internalSongCode);
        }
        #endregion terra IMusicContentCenter
    }
}