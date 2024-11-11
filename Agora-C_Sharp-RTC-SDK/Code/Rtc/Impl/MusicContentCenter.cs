using System;

namespace Agora.Rtc
{
    public sealed class MusicContentCenter : IMusicContentCenter
    {
        private IRtcEngine _rtcEngineInstance = null;
        private MusicContentCenterImpl _musicContentCenterImpl = null;
        private const int ErrorCode = -7;
        private static System.Object rtcLock = new System.Object();

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
            lock (rtcLock)
            {
                return instance ?? (instance = new MusicContentCenter(rtcEngine, impl));
            }
        }

        internal static void ReleaseInstance()
        {
            lock (rtcLock)
            {
                instance = null;
            }
        }

        public override IMusicPlayer CreateMusicPlayer()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
                {
                    return null;
                }
                return _musicContentCenterImpl.CreateMusicPlayer();
            }
        }

        public override int GetLyric(ref string requestId, long songCode, int LyricType = 0)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
                {
                    return ErrorCode;
                }
                return _musicContentCenterImpl.GetLyric(ref requestId, songCode, LyricType);
            }
        }

        public override int GetMusicCollectionByMusicChartId(ref string requestId, int musicChartType, int page, int pageSize, string jsonOption = "")
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
                {
                    return ErrorCode;
                }
                return _musicContentCenterImpl.GetMusicCollectionByMusicChartId(ref requestId, musicChartType, page, pageSize, jsonOption);
            }
        }

        public override int GetMusicCharts(ref string requestId)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
                {
                    return ErrorCode;
                }
                return _musicContentCenterImpl.GetMusicCharts(ref requestId);
            }
        }

        public override int Initialize(MusicContentCenterConfiguration configuration)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
                {
                    return ErrorCode;
                }
                return _musicContentCenterImpl.Initialize(configuration);
            }
        }

        public override int IsPreloaded(long songCode)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
                {
                    return ErrorCode;
                }
                return _musicContentCenterImpl.IsPreloaded(songCode);
            }
        }

        public override int Preload(long songCode, string jsonOption = "")
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
                {
                    return ErrorCode;
                }
                return _musicContentCenterImpl.Preload(songCode, jsonOption);
            }
        }

        public override int Preload(ref string requestId, Int64 songCode)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
                {
                    return ErrorCode;
                }
                return _musicContentCenterImpl.Preload(ref requestId, songCode);
            }
        }

        public override int RemoveCache(Int64 songCode)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
                {
                    return ErrorCode;
                }
                return _musicContentCenterImpl.RemoveCache(songCode);
            }
        }

        public override int GetCaches(ref MusicCacheInfo[] cacheInfo, ref int cacheInfoSize)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
                {
                    return ErrorCode;
                }
                return _musicContentCenterImpl.GetCaches(ref cacheInfo, ref cacheInfoSize);
            }
        }


        public override int RegisterEventHandler(IMusicContentCenterEventHandler eventHandler)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
                {
                    return ErrorCode;
                }
                return _musicContentCenterImpl.RegisterEventHandler(eventHandler);
            }
        }

        public override int SearchMusic(ref string requestId, string keyWord, int page, int pageSize, string jsonOption = "")
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
                {
                    return ErrorCode;
                }
                return _musicContentCenterImpl.SearchMusic(ref requestId, keyWord, page, pageSize, jsonOption);
            }
        }

        public override int UnregisterEventHandler()
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
                {
                    return ErrorCode;
                }
                return _musicContentCenterImpl.UnregisterEventHandler();
            }
        }

        public override int DestroyMusicPlayer(IMusicPlayer player)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
                {
                    return ErrorCode;
                }
                return _musicContentCenterImpl.DestroyMusicPlayer(player);
            }
        }

        public override int RenewToken(string token)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
                {
                    return ErrorCode;
                }
                return _musicContentCenterImpl.RenewToken(token);
            }
        }

        public override int GetSongSimpleInfo(ref string requestId, Int64 songCode)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
                {
                    return ErrorCode;
                }
                return _musicContentCenterImpl.GetSongSimpleInfo(ref requestId, songCode);
            }
        }

        public override int GetInternalSongCode(Int64 songCode, string jsonOption, ref Int64 internalSongCode)
        {
            lock (rtcLock)
            {
                if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
                {
                    return ErrorCode;
                }
                return _musicContentCenterImpl.GetInternalSongCode(songCode, jsonOption, ref internalSongCode);
            }
        }
    }
}