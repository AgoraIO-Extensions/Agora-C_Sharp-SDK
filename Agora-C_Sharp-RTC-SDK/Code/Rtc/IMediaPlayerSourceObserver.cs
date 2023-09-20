using System;

namespace Agora.Rtc
{
    /* class_imediaplayersourceobserver */
    public abstract class IMediaPlayerSourceObserver
    {

#region terra IMediaPlayerSourceObserver

        /* callback_imediaplayersourceobserver_onplayersourcestatechanged */
        public virtual void OnPlayerSourceStateChanged(MEDIA_PLAYER_STATE state, MEDIA_PLAYER_ERROR ec)
        {
        }

        /* callback_imediaplayersourceobserver_onpositionchanged */
        public virtual void OnPositionChanged(long position_ms)
        {
        }

        /* callback_imediaplayersourceobserver_onplayerevent */
        public virtual void OnPlayerEvent(MEDIA_PLAYER_EVENT eventCode, long elapsedTime, string message)
        {
        }

        /* callback_imediaplayersourceobserver_onmetadata */
        public virtual void OnMetaData(byte[] data, int length)
        {
        }

        /* callback_imediaplayersourceobserver_onplaybufferupdated */
        public virtual void OnPlayBufferUpdated(long playCachedBuffer)
        {
        }

        /* callback_imediaplayersourceobserver_onpreloadevent */
        public virtual void OnPreloadEvent(string src, PLAYER_PRELOAD_EVENT @event)
        {
        }

        /* callback_imediaplayersourceobserver_oncompleted */
        public virtual void OnCompleted()
        {
        }

        /* callback_imediaplayersourceobserver_onagoracdntokenwillexpire */
        public virtual void OnAgoraCDNTokenWillExpire()
        {
        }

        /* callback_imediaplayersourceobserver_onplayersrcinfochanged */
        public virtual void OnPlayerSrcInfoChanged(SrcInfo from, SrcInfo to)
        {
        }

        /* callback_imediaplayersourceobserver_onplayerinfoupdated */
        public virtual void OnPlayerInfoUpdated(PlayerUpdatedInfo info)
        {
        }

        /* callback_imediaplayersourceobserver_onaudiovolumeindication */
        public virtual void OnAudioVolumeIndication(int volume)
        {
        }
#endregion terra IMediaPlayerSourceObserver
    }
}