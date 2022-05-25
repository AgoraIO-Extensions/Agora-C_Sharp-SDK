using System;

namespace agora.rtc
{
    public abstract class IMediaPlayerSourceObserver
    {
        public virtual void OnPlayerSourceStateChanged(int playerId, MEDIA_PLAYER_STATE state, MEDIA_PLAYER_ERROR ec) { }

        public virtual void OnPositionChanged(int playerId, Int64 position) { }

        public virtual void OnPlayerEvent(int playerId, MEDIA_PLAYER_EVENT @event, Int64 elapsedTime, string message) { }

        public virtual void OnMetaData(int playerId, byte[] data, int length) { }

        public virtual void OnPlayBufferUpdated(int playerId, Int64 playCachedBuffer) { }

        public virtual void OnCompleted(int playerId) { }

        public virtual void OnAgoraCDNTokenWillExpire(int playerId) { }

        public virtual void OnPlayerSrcInfoChanged(int playerId, SrcInfo from, SrcInfo to) { }

        public virtual void OnPlayerInfoUpdated(PlayerUpdatedInfo info) { }

        public virtual void OnAudioVolumeIndication(int playerId, int volume) { }
    }
}