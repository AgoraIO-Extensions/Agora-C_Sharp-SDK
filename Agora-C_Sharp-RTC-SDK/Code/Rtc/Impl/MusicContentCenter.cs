using System;

namespace Agora.Rtc
{
    public sealed class MusicContentCenter : IMusicContentCenter
    {
        private IRtcEngine _rtcEngineInstance = null;
        private MusicContentCenterImpl _musicContentCenterImpl = null;
        private const int ErrorCode = -7;

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

        public override IMusicPlayer CreateMusicPlayer()
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return null;
            }
            return _musicContentCenterImpl.CreateMusicPlayer();
        }

        public override int GetLyric(ref string requestId, long songCode, int LyricType = 0)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.GetLyric(ref requestId, songCode, LyricType);
        }

        public override int GetMusicCollectionByMusicChartId(ref string requestId, int musicChartType, int page, int pageSize, string jsonOption = "")
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.GetMusicCollectionByMusicChartId(ref requestId, musicChartType, page, pageSize, jsonOption);
        }

        public override int GetMusicCharts(ref string requestId)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.GetMusicCharts(ref requestId);
        }

        public override int Initialize(MusicContentCenterConfiguration configuration)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.Initialize(configuration);
        }

        public override int IsPreloaded(long songCode)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.IsPreloaded(songCode);
        }

        public override int Preload(long songCode, string jsonOption = "")
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.Preload(songCode, jsonOption);
        }

        public override int RegisterEventHandler(IMusicContentCenterEventHandler eventHandler)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.RegisterEventHandler(eventHandler);
        }

        public override int SearchMusic(ref string requestId, string keyWord, int page, int pageSize, string jsonOption = "")
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.SearchMusic(ref requestId, keyWord, page, pageSize, jsonOption);
        }

        public override int UnregisterEventHandler()
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.UnregisterEventHandler();
        }

        public override int DestroyMusicPlayer(IMusicPlayer player)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.DestroyMusicPlayer(player);
        }

        public override int RenewToken(string token)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.RenewToken(token);
        }
    }
}