using System;

namespace Agora.Rtc
{
    public abstract class IMediaPlayerSourceObserver
    {

#region terra IMediaPlayerSourceObserver

        public virtual void OnPlayerSourceStateChanged(MEDIA_PLAYER_STATE state, MEDIA_PLAYER_ERROR ec)
        {
        }

        public virtual void OnPositionChanged(long position_ms)
        {
        }

        public virtual void OnPlayerEvent(MEDIA_PLAYER_EVENT eventCode, long elapsedTime, string message)
        {
        }

        public virtual void OnMetaData(byte[] data, int length)
        {
        }

        public virtual void OnPlayBufferUpdated(long playCachedBuffer)
        {
        }

        public virtual void OnPreloadEvent(string src, PLAYER_PRELOAD_EVENT @event)
        {
        }

        public virtual void OnCompleted()
        {
        }

        public virtual void OnAgoraCDNTokenWillExpire()
        {
        }

        public virtual void OnPlayerSrcInfoChanged(SrcInfo from, SrcInfo to)
        {
        }

        public virtual void OnPlayerInfoUpdated(PlayerUpdatedInfo info)
        {
        }

        public virtual void OnAudioVolumeIndication(int volume)
        {
        }
#endregion terra IMediaPlayerSourceObserver
    }
}