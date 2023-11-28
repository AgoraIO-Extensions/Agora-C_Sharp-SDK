using System;

namespace Agora.Rtc
{

    public class MediaPlayerSourceObserver : IMediaPlayerSourceObserver
    {
        #region terra IMediaPlayerSourceObserver
        public event Action<MEDIA_PLAYER_STATE, MEDIA_PLAYER_REASON> EventOnPlayerSourceStateChanged;

        public override void OnPlayerSourceStateChanged(MEDIA_PLAYER_STATE state, MEDIA_PLAYER_REASON reason)
        {
            if (EventOnPlayerSourceStateChanged == null) return;
            EventOnPlayerSourceStateChanged.Invoke(state, reason);
        }

        public event Action<long, long> EventOnPositionChanged;

        public override void OnPositionChanged(long positionMs, long timestampMs)
        {
            if (EventOnPositionChanged == null) return;
            EventOnPositionChanged.Invoke(positionMs, timestampMs);
        }

        public event Action<MEDIA_PLAYER_EVENT, long, string> EventOnPlayerEvent;

        public override void OnPlayerEvent(MEDIA_PLAYER_EVENT eventCode, long elapsedTime, string message)
        {
            if (EventOnPlayerEvent == null) return;
            EventOnPlayerEvent.Invoke(eventCode, elapsedTime, message);
        }

        public event Action<byte[], int> EventOnMetaData;

        public override void OnMetaData(byte[] data, int length)
        {
            if (EventOnMetaData == null) return;
            EventOnMetaData.Invoke(data, length);
        }

        public event Action<long> EventOnPlayBufferUpdated;

        public override void OnPlayBufferUpdated(long playCachedBuffer)
        {
            if (EventOnPlayBufferUpdated == null) return;
            EventOnPlayBufferUpdated.Invoke(playCachedBuffer);
        }

        public event Action<string, PLAYER_PRELOAD_EVENT> EventOnPreloadEvent;

        public override void OnPreloadEvent(string src, PLAYER_PRELOAD_EVENT @event)
        {
            if (EventOnPreloadEvent == null) return;
            EventOnPreloadEvent.Invoke(src, @event);
        }

        public event Action EventOnCompleted;

        public override void OnCompleted()
        {
            if (EventOnCompleted == null) return;
            EventOnCompleted.Invoke();
        }

        public event Action EventOnAgoraCDNTokenWillExpire;

        public override void OnAgoraCDNTokenWillExpire()
        {
            if (EventOnAgoraCDNTokenWillExpire == null) return;
            EventOnAgoraCDNTokenWillExpire.Invoke();
        }

        public event Action<SrcInfo, SrcInfo> EventOnPlayerSrcInfoChanged;

        public override void OnPlayerSrcInfoChanged(SrcInfo from, SrcInfo to)
        {
            if (EventOnPlayerSrcInfoChanged == null) return;
            EventOnPlayerSrcInfoChanged.Invoke(from, to);
        }

        public event Action<PlayerUpdatedInfo> EventOnPlayerInfoUpdated;

        public override void OnPlayerInfoUpdated(PlayerUpdatedInfo info)
        {
            if (EventOnPlayerInfoUpdated == null) return;
            EventOnPlayerInfoUpdated.Invoke(info);
        }

        public event Action<CacheStatistics> EventOnPlayerCacheStats;

        public override void OnPlayerCacheStats(CacheStatistics stats)
        {
            if (EventOnPlayerCacheStats == null) return;
            EventOnPlayerCacheStats.Invoke(stats);
        }

        public event Action<PlayerPlaybackStats> EventOnPlayerPlaybackStats;

        public override void OnPlayerPlaybackStats(PlayerPlaybackStats stats)
        {
            if (EventOnPlayerPlaybackStats == null) return;
            EventOnPlayerPlaybackStats.Invoke(stats);
        }

        public event Action<int> EventOnAudioVolumeIndication;

        public override void OnAudioVolumeIndication(int volume)
        {
            if (EventOnAudioVolumeIndication == null) return;
            EventOnAudioVolumeIndication.Invoke(volume);
        }

        #endregion terra IMediaPlayerSourceObserver
    }
}