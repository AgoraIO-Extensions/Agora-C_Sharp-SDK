using System;

namespace Agora.Rtc
{
    public delegate void OnPlayerSourceStateChangedHandler(MEDIA_PLAYER_STATE state, MEDIA_PLAYER_ERROR ec);

    public delegate void OnPositionChangedHandler(Int64 position_ms);

    public delegate void OnPlayerEventHandler(MEDIA_PLAYER_EVENT eventCode, Int64 elapsedTime, string message);

    public delegate void OnMetaDataHandler(byte[] data, int length);

    public delegate void OnPlayBufferUpdatedHandler(Int64 playCachedBuffer);

    public delegate void OnCompletedHandler();

    public delegate void OnAgoraCDNTokenWillExpireHandler();

    public delegate void OnPlayerSrcInfoChangedHandler(SrcInfo from, SrcInfo to);

    public delegate void OnPlayerInfoUpdatedHandler(PlayerUpdatedInfo info);

    public delegate void MediaPlayerOnAudioVolumeIndicationHandler(int volume);
    
    public class MediaPlayerSourceObserver : IMediaPlayerSourceObserver
    {
        public event OnPlayerSourceStateChangedHandler EventOnPlayerSourceStateChanged;
        public event OnPositionChangedHandler EventOnPositionChanged;
        public event OnPlayerEventHandler EventOnPlayerEvent;
        public event OnMetaDataHandler EventOnMetaData;
        public event OnPlayBufferUpdatedHandler EventOnPlayBufferUpdated;
        public event OnCompletedHandler EventOnCompleted;
        public event OnAgoraCDNTokenWillExpireHandler EventOnAgoraCDNTokenWillExpire;
        public event OnPlayerSrcInfoChangedHandler EventOnPlayerSrcInfoChanged;
        public event OnPlayerInfoUpdatedHandler EventOnPlayerInfoUpdated;
        public event MediaPlayerOnAudioVolumeIndicationHandler EventOnAudioVolumeIndication;

        public override void OnPlayerSourceStateChanged(MEDIA_PLAYER_STATE state, MEDIA_PLAYER_ERROR ec)
        {
            if (EventOnPlayerSourceStateChanged == null) return;
            EventOnPlayerSourceStateChanged.Invoke(state, ec);
        }

        public override void OnPositionChanged(Int64 position_ms)
        {
            if (EventOnPositionChanged == null) return;
            EventOnPositionChanged.Invoke(position_ms);
        }

        public override void OnPlayerEvent(MEDIA_PLAYER_EVENT eventCode, Int64 elapsedTime, string message)
        {
            if (EventOnPlayerEvent == null) return;
            EventOnPlayerEvent.Invoke(eventCode, elapsedTime, message);
        }

        public override void OnMetaData(byte[] data, int length)
        {
            if (EventOnMetaData == null) return;
            EventOnMetaData.Invoke(data, length);
        }

        public override void OnPlayBufferUpdated(Int64 playCachedBuffer)
        {
            if (EventOnPlayBufferUpdated == null) return;
            EventOnPlayBufferUpdated.Invoke(playCachedBuffer);
        }

        public override void OnCompleted()
        {
            if (EventOnCompleted == null) return;
            EventOnCompleted.Invoke();
        }

        public override void OnAgoraCDNTokenWillExpire()
        {
            if (EventOnAgoraCDNTokenWillExpire == null) return;
            EventOnAgoraCDNTokenWillExpire.Invoke();
        }

        public override void OnPlayerSrcInfoChanged(SrcInfo from, SrcInfo to)
        {
            if (EventOnPlayerSrcInfoChanged == null) return;
            EventOnPlayerSrcInfoChanged.Invoke(from, to);
        }

        public override void OnPlayerInfoUpdated(PlayerUpdatedInfo info)
        {
            if (EventOnPlayerInfoUpdated == null) return;
            EventOnPlayerInfoUpdated.Invoke(info);
        }

        public override void OnAudioVolumeIndication(int volume)
        {
            if (EventOnAudioVolumeIndication == null) return;
            EventOnAudioVolumeIndication.Invoke(volume);
        }
    }
}