﻿using System;

namespace Agora.Rtc
{
    ///
    /// <summary>
    /// Provides callbacks for media players.
    /// </summary>
    ///
    public abstract class IMediaPlayerSourceObserver
    {

        #region terra IMediaPlayerSourceObserver

        ///
        /// <summary>
        /// Reports the changes of playback state.
        ///
        /// When the state of the media player changes, the SDK triggers this callback to report the current playback state.
        /// </summary>
        ///
        /// <param name="state"> The playback state. See MEDIA_PLAYER_STATE. </param>
        ///
        /// <param name="ec"> The error code. See MEDIA_PLAYER_ERROR. </param>
        ///
        public virtual void OnPlayerSourceStateChanged(MEDIA_PLAYER_STATE state, MEDIA_PLAYER_ERROR ec)
        {
        }

        ///
        /// <summary>
        /// Reports current playback progress.
        ///
        /// When playing media files, the SDK triggers this callback every two second to report current playback progress.
        /// </summary>
        ///
        /// <param name="position_ms"> The playback position (ms) of media files. </param>
        ///
        public virtual void OnPositionChanged(long position_ms)
        {
        }

        ///
        /// <summary>
        /// Reports the player events.
        ///
        /// After calling the Seek method, the SDK triggers the callback to report the results of the seek operation.
        /// </summary>
        ///
        /// <param name="eventCode"> The player events. See MEDIA_PLAYER_EVENT. </param>
        ///
        /// <param name="elapsedTime"> The time (ms) when the event occurs. </param>
        ///
        /// <param name="message"> Information about the event. </param>
        ///
        public virtual void OnPlayerEvent(MEDIA_PLAYER_EVENT eventCode, long elapsedTime, string message)
        {
        }

        ///
        /// <summary>
        /// Occurs when the media metadata is received.
        ///
        /// The callback occurs when the player receives the media metadata and reports the detailed information of the media metadata.
        /// </summary>
        ///
        /// <param name="data"> The detailed data of the media metadata. </param>
        ///
        /// <param name="length"> The data length (bytes). </param>
        ///
        public virtual void OnMetaData(byte[] data, int length)
        {
        }

        ///
        /// <summary>
        /// Reports the playback duration that the buffered data can support.
        ///
        /// When playing online media resources, the SDK triggers this callback every two seconds to report the playback duration that the currently buffered data can support.
        /// When the playback duration supported by the buffered data is less than the threshold (0 by default), the SDK returns PLAYER_EVENT_BUFFER_LOW.
        /// When the playback duration supported by the buffered data is greater than the threshold (0 by default), the SDK returns PLAYER_EVENT_BUFFER_RECOVER.
        /// </summary>
        ///
        /// <param name="playCachedBuffer"> The playback duration (ms) that the buffered data can support. </param>
        ///
        public virtual void OnPlayBufferUpdated(long playCachedBuffer)
        {
        }

        ///
        /// <summary>
        /// Reports the events of preloaded media resources.
        /// </summary>
        ///
        /// <param name="src"> The URL of the media resource. </param>
        ///
        /// <param name="@event"> Events that occur when media resources are preloaded. See PLAYER_PRELOAD_EVENT. </param>
        ///
        public virtual void OnPreloadEvent(string src, PLAYER_PRELOAD_EVENT @event)
        {
        }

        ///
        /// @ignore
        ///
        public virtual void OnCompleted()
        {
        }

        ///
        /// @ignore
        ///
        public virtual void OnAgoraCDNTokenWillExpire()
        {
        }

        ///
        /// <summary>
        /// Occurs when the video bitrate of the media resource changes.
        /// </summary>
        ///
        /// <param name="from"> Information about the video bitrate of the media resource being played. See SrcInfo. </param>
        ///
        /// <param name="to"> Information about the changed video bitrate of media resource being played. See SrcInfo. </param>
        ///
        public virtual void OnPlayerSrcInfoChanged(SrcInfo from, SrcInfo to)
        {
        }

        ///
        /// <summary>
        /// Occurs when information related to the media player changes.
        ///
        /// When the information about the media player changes, the SDK triggers this callback. You can use this callback for troubleshooting.
        /// </summary>
        ///
        /// <param name="info"> Information related to the media player. See PlayerUpdatedInfo. </param>
        ///
        public virtual void OnPlayerInfoUpdated(PlayerUpdatedInfo info)
        {
        }

        ///
        /// <summary>
        /// Reports the volume of the media player.
        ///
        /// The SDK triggers this callback every 200 milliseconds to report the current volume of the media player.
        /// </summary>
        ///
        /// <param name="volume"> The volume of the media player. The value ranges from 0 to 255. </param>
        ///
        public virtual void OnAudioVolumeIndication(int volume)
        {
        }
        #endregion terra IMediaPlayerSourceObserver
    }
}