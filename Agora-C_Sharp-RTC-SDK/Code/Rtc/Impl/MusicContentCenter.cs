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

        public override int RegisterAudioFrameObserver(IAudioFrameObserver audioFrameObserver, AUDIO_FRAME_POSITION position, OBSERVER_MODE mode = OBSERVER_MODE.INTPTR)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.RegisterAudioFrameObserver(audioFrameObserver, position, mode);
        }

        public override int UnregisterAudioFrameObserver()
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.UnregisterAudioFrameObserver();
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

        public override int AddVendor(MusicContentCenterVendorID vendorId, string jsonVendorConfig)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.AddVendor(vendorId, jsonVendorConfig);
        }

        public override int RemoveVendor(MusicContentCenterVendorID vendorId)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.RemoveVendor(vendorId);
        }

        public override int RenewToken(MusicContentCenterVendorID vendorID, string token)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.RenewToken(vendorID, token);
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

        public override int Preload(ref string requestId, long internalSongCode)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.Preload(ref requestId, internalSongCode);
        }

        public override int RegisterScoreEventHandler(IScoreEventHandler scoreEventHandler)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.RegisterScoreEventHandler(scoreEventHandler);
        }

        public override int UnregisterScoreEventHandler()
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.UnregisterScoreEventHandler();
        }

        public override int SetScoreLevel(ScoreLevel level)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.SetScoreLevel(level);
        }

        public override int StartScore(long internalSongCode)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.StartScore(internalSongCode);
        }

        public override int StopScore()
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.StopScore();
        }

        public override int PauseScore()
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.PauseScore();
        }

        public override int ResumeScore()
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.ResumeScore();
        }

        public override int GetCumulativeScoreData(ref CumulativeScoreData cumulativeScoreData)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.GetCumulativeScoreData(ref cumulativeScoreData);
        }

        public override int RemoveCache(long internalSongCode)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.RemoveCache(internalSongCode);
        }

        public override int GetCaches(ref MusicCacheInfo[] cacheInfo, ref int cacheInfoSize)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.GetCaches(ref cacheInfo, ref cacheInfoSize);
        }

        public override int IsPreloaded(long internalSongCode)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.IsPreloaded(internalSongCode);
        }

        public override int GetLyric(ref string requestId, long internalSongCode, int lyricType = 0)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.GetLyric(ref requestId, internalSongCode, lyricType);
        }

        public override int GetLyricInfo(ref string requestId, long internalSongCode)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.GetLyricInfo(ref requestId, internalSongCode);
        }

        public override int GetSongSimpleInfo(ref string requestId, long internalSongCode)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.GetSongSimpleInfo(ref requestId, internalSongCode);
        }

        public override int GetInternalSongCode(MusicContentCenterVendorID vendorId, string songCode, string jsonOption, ref long internalSongCode)
        {
            if (_rtcEngineInstance == null || _musicContentCenterImpl == null)
            {
                return ErrorCode;
            }
            return _musicContentCenterImpl.GetInternalSongCode(vendorId, songCode, jsonOption, ref internalSongCode);
        }
        #endregion terra IMusicContentCenter
    }
}