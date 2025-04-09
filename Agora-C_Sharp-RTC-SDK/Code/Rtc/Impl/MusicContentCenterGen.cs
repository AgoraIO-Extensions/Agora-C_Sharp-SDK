#region Generated by `terra/node/src/rtc/middle/renderers.ts`. DO NOT MODIFY BY HAND.
#endregion

#define AGORA_RTC
#define AGORA_RTM
using System;
using view_t = System.UInt64;

namespace Agora.Rtc
{
    public partial class MusicContentCenter : IMusicContentCenter
    {

        public override int Initialize(MusicContentCenterConfiguration configuration)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.Initialize(configuration);
        }

        public override int AddVendor(MusicContentCenterVendorID vendorId, string jsonVendorConfig)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.AddVendor(vendorId, jsonVendorConfig);
        }

        public override int RemoveVendor(MusicContentCenterVendorID vendorId)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.RemoveVendor(vendorId);
        }

        public override int RenewToken(MusicContentCenterVendorID vendorID, string token)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.RenewToken(vendorID, token);
        }

        public override int RegisterEventHandler(IMusicContentCenterEventHandler eventHandler)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.RegisterEventHandler(eventHandler);
        }

        public override int UnregisterEventHandler()
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.UnregisterEventHandler();
        }

        public override IMusicPlayer CreateMusicPlayer()
        {
            if (_impl == null)
            {
                return null;
            }
            return _impl.CreateMusicPlayer();
        }

        public override int DestroyMusicPlayer(IMusicPlayer music_player)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.DestroyMusicPlayer(music_player);
        }

        public override int GetMusicCharts(ref string requestId)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.GetMusicCharts(ref requestId);
        }

        public override int GetMusicCollectionByMusicChartId(ref string requestId, int musicChartId, int page, int pageSize, string jsonOption = "")
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.GetMusicCollectionByMusicChartId(ref requestId, musicChartId, page, pageSize, jsonOption);
        }

        public override int SearchMusic(ref string requestId, string keyWord, int page, int pageSize, string jsonOption = "")
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.SearchMusic(ref requestId, keyWord, page, pageSize, jsonOption);
        }

        public override int Preload(ref string requestId, long internalSongCode)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.Preload(ref requestId, internalSongCode);
        }

        public override int RegisterScoreEventHandler(IScoreEventHandler scoreEventHandler)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.RegisterScoreEventHandler(scoreEventHandler);
        }

        public override int UnregisterScoreEventHandler()
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.UnregisterScoreEventHandler();
        }

        public override int SetScoreLevel(ScoreLevel level)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.SetScoreLevel(level);
        }

        public override int StartScore(long internalSongCode)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.StartScore(internalSongCode);
        }

        public override int StopScore()
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.StopScore();
        }

        public override int PauseScore()
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.PauseScore();
        }

        public override int ResumeScore()
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.ResumeScore();
        }

        public override int GetCumulativeScoreData(ref CumulativeScoreData cumulativeScoreData)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.GetCumulativeScoreData(ref cumulativeScoreData);
        }

        public override int RemoveCache(long internalSongCode)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.RemoveCache(internalSongCode);
        }

        public override int GetCaches(ref MusicCacheInfo[] cacheInfo, ref int cacheInfoSize)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.GetCaches(ref cacheInfo, ref cacheInfoSize);
        }

        public override int IsPreloaded(long internalSongCode)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.IsPreloaded(internalSongCode);
        }

        public override int GetLyric(ref string requestId, long internalSongCode, int lyricType = 0)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.GetLyric(ref requestId, internalSongCode, lyricType);
        }

        public override int GetLyricInfo(ref string requestId, long internalSongCode)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.GetLyricInfo(ref requestId, internalSongCode);
        }

        public override int GetSongSimpleInfo(ref string requestId, long internalSongCode)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.GetSongSimpleInfo(ref requestId, internalSongCode);
        }

        public override int GetInternalSongCode(MusicContentCenterVendorID vendorId, string songCode, string jsonOption, ref long internalSongCode)
        {
            if (_impl == null)
            {
                return ErrorCode;
            }
            return _impl.GetInternalSongCode(vendorId, songCode, jsonOption, ref internalSongCode);
        }

    }
}