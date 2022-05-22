using System;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID 
using AOT;
#endif

namespace agora.rtc
{
    public delegate void OnPlayerSourceStateChangedHandler(int playerId, MEDIA_PLAYER_STATE state, MEDIA_PLAYER_ERROR ec);

    public delegate void OnPositionChangedHandler(int playerId, Int64 position);

    public delegate void OnPlayerEventHandler(int playerId, MEDIA_PLAYER_EVENT @event, Int64 elapsedTime, string message);

    public delegate void OnMetaDataHandler(int playerId, byte[] data, int length);

    public delegate void OnPlayBufferUpdatedHandler(int playerId, Int64 playCachedBuffer);

    public delegate void OnCompletedHandler(int playerId);

    public delegate void OnAgoraCDNTokenWillExpireHandler(int playerId);

    public delegate void OnPlayerSrcInfoChangedHandler(int playerId, SrcInfo from, SrcInfo to);

    public delegate void OnPlayerInfoUpdatedHandler(PlayerUpdatedInfo info);

    public delegate void MediaPlayerOnAudioVolumeIndicationHandler(int playerId, int volume);
    
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

        private static MediaPlayerSourceObserver eventInstance = null;

        public static MediaPlayerSourceObserver GetInstance()
        {
            return eventInstance ?? (eventInstance = new MediaPlayerSourceObserver());
        }

        public override void OnPlayerSourceStateChanged(int playerId, MEDIA_PLAYER_STATE state, MEDIA_PLAYER_ERROR ec)
        {
            if (EventOnPlayerSourceStateChanged == null) return;
            EventOnPlayerSourceStateChanged.Invoke(playerId, state, ec);
        }

        public override void OnPositionChanged(int playerId, Int64 position)
        {
            if (EventOnPositionChanged == null) return;
            EventOnPositionChanged.Invoke(playerId, position);
        }

        public override void OnPlayerEvent(int playerId, MEDIA_PLAYER_EVENT @event, Int64 elapsedTime, string message)
        {
            if (EventOnPlayerEvent == null) return;
            EventOnPlayerEvent.Invoke(playerId, @event, elapsedTime, message);
        }

        public override void OnMetaData(int playerId, byte[] data, int length)
        {
            if (EventOnMetaData == null) return;
            EventOnMetaData.Invoke(playerId, data, length);
        }

        public override void OnPlayBufferUpdated(int playerId, Int64 playCachedBuffer)
        {
            if (EventOnPlayBufferUpdated == null) return;
            EventOnPlayBufferUpdated.Invoke(playerId, playCachedBuffer);
        }

        public override void OnCompleted(int playerId)
        {
            if (EventOnCompleted == null) return;
            EventOnCompleted.Invoke(playerId);
        }

        public override void OnAgoraCDNTokenWillExpire(int playerId)
        {
            if (EventOnAgoraCDNTokenWillExpire == null) return;
            EventOnAgoraCDNTokenWillExpire.Invoke(playerId);
        }

        public override void OnPlayerSrcInfoChanged(int playerId, SrcInfo from, SrcInfo to)
        {
            if (EventOnPlayerSrcInfoChanged == null) return;
            EventOnPlayerSrcInfoChanged.Invoke(playerId, from, to);
        }

        public override void OnPlayerInfoUpdated(PlayerUpdatedInfo info)
        {
            if (EventOnPlayerInfoUpdated == null) return;
            EventOnPlayerInfoUpdated.Invoke(info);
        }

        public override void OnAudioVolumeIndication(int playerId, int volume)
        {
            if (EventOnAudioVolumeIndication == null) return;
            EventOnAudioVolumeIndication.Invoke(playerId, volume);
        }
    }
}