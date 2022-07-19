using System;
namespace Agora.Rtc
{
    public sealed class MusicContentCenter : IMusicContentCenter
    {
        private IRtcEngine _rtcEngineInstance = null;
        private MusicContentCenterImpl _musicContentCenterImpl = null;
        private const string ErrorMsgLog = "[MusicContentCenter]:IRtcEngine has not been created yet!";
        private const int ErrorCode = -1;

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
                AgoraLog.LogError(ErrorMsgLog);
                return null;
            }
            return _musicContentCenterImpl.CreateMusicPlayer();
        }

        public override int GetLyric(string requestId, long songCode, int LyricType = 0)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _musicContentCenterImpl.GetLyric(requestId, songCode, LyricType);
        }

        public override int GetMusicChart(string requestId, int musicChartType, int page, int pageSize, string jsonOption = "")
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _musicContentCenterImpl.GetMusicChart(requestId, musicChartType, page, pageSize, jsonOption);
        }

        public override int GetMusicCharts(string requestId)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _musicContentCenterImpl.GetMusicCharts(requestId);
        }

        public override int Initialize(AgoraMusicContentCenterConfiguration configuration)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _musicContentCenterImpl.Initialize(configuration);
        }

        public override int IsPreloaded(long songCode, AgoraMediaType type, string resolution)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _musicContentCenterImpl.IsPreloaded(songCode, type, resolution);
        }

        public override int Preload(long songCode, AgoraMediaType type, string resolution)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _musicContentCenterImpl.Preload(songCode, type, resolution);
        }

        public override int RegisterEventHandler(IAgoraMusicContentCenterEventHandler eventHandler)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _musicContentCenterImpl.RegisterEventHandler(eventHandler);
        }

        public override int SearchSong(string requestId, string keyWord, int page, int pageSize, string jsonOption = "")
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _musicContentCenterImpl.SearchSong(requestId, keyWord, page, pageSize, jsonOption);
        }

        public override int UnregisterEventHandler()
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                AgoraLog.LogError(ErrorMsgLog);
                return ErrorCode;
            }
            return _musicContentCenterImpl.UnregisterEventHandler();
        }
    }
}
