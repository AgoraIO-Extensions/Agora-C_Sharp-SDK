using System;

namespace Agora.Rtc
{
    using int64_t = Int64;

    #region AgoraMediaPlayerTypes.h
    public enum MEDIA_PLAYER_STATE
    {
        /** Default state.
         */
        PLAYER_STATE_IDLE = 0,
        /** Opening the media file.
         */
        PLAYER_STATE_OPENING,
        /** The media file is opened successfully.
         */
        PLAYER_STATE_OPEN_COMPLETED,
        /** Playing the media file.
         */
        PLAYER_STATE_PLAYING,
        /** The playback is paused.
         */
        PLAYER_STATE_PAUSED,
        /** The playback is completed.
         */
        PLAYER_STATE_PLAYBACK_COMPLETED,
        /** All loops are completed.
         */
        PLAYER_STATE_PLAYBACK_ALL_LOOPS_COMPLETED,
        /** The playback is stopped.
         */
        PLAYER_STATE_STOPPED,
        /** Player pausing (internal)
         */
        PLAYER_STATE_PAUSING_INTERNAL = 50,
        /** Player stopping (internal)
         */
        PLAYER_STATE_STOPPING_INTERNAL,
        /** Player seeking state (internal)
         */
        PLAYER_STATE_SEEKING_INTERNAL,
        /** Player getting state (internal)
         */
        PLAYER_STATE_GETTING_INTERNAL,
        /** None state for state machine (internal)
         */
        PLAYER_STATE_NONE_INTERNAL,
        /** Do nothing state for state machine (internal)
         */
        PLAYER_STATE_DO_NOTHING_INTERNAL,
        /** Player set track state (internal)
         */
        PLAYER_STATE_SET_TRACK_INTERNAL,
        /** The playback fails.
         */
        PLAYER_STATE_FAILED = 100,
    };

    /**
        * @brief Player error code
        *
*/
    public enum MEDIA_PLAYER_ERROR
    {
        /** No error.
         */
        PLAYER_ERROR_NONE = 0,
        /** The parameter is invalid.
         */
        PLAYER_ERROR_INVALID_ARGUMENTS = -1,
        /** Internel error.
         */
        PLAYER_ERROR_INTERNAL = -2,
        /** No resource.
         */
        PLAYER_ERROR_NO_RESOURCE = -3,
        /** Invalid media source.
         */
        PLAYER_ERROR_INVALID_MEDIA_SOURCE = -4,
        /** The type of the media stream is unknown.
         */
        PLAYER_ERROR_UNKNOWN_STREAM_TYPE = -5,
        /** The object is not initialized.
         */
        PLAYER_ERROR_OBJ_NOT_INITIALIZED = -6,
        /** The codec is not supported.
         */
        PLAYER_ERROR_CODEC_NOT_SUPPORTED = -7,
        /** Invalid renderer.
         */
        PLAYER_ERROR_VIDEO_RENDER_FAILED = -8,
        /** An error occurs in the internal state of the player.
         */
        PLAYER_ERROR_INVALID_STATE = -9,
        /** The URL of the media file cannot be found.
         */
        PLAYER_ERROR_URL_NOT_FOUND = -10,
        /** Invalid connection between the player and the Agora server.
         */
        PLAYER_ERROR_INVALID_CONNECTION_STATE = -11,
        /** The playback buffer is insufficient.
         */
        PLAYER_ERROR_SRC_BUFFER_UNDERFLOW = -12,
        /** The audio mixing file playback is interrupted.
         */
        PLAYER_ERROR_INTERRUPTED = -13,
        /** The SDK does not support this function.
         */
        PLAYER_ERROR_NOT_SUPPORTED = -14,
        /** The token has expired.
         */
        PLAYER_ERROR_TOKEN_EXPIRED = -15,
        /** The ip has expired.
         */
        PLAYER_ERROR_IP_EXPIRED = -16,
        /** An unknown error occurs.
         */
        PLAYER_ERROR_UNKNOWN = -17,
    };

    /**
  * @brief The type of the media stream.
  *
*/
    public enum MEDIA_STREAM_TYPE
    {
        /** The type is unknown.
           */
        STREAM_TYPE_UNKNOWN = 0,
        /** The video stream.
           */
        STREAM_TYPE_VIDEO = 1,
        /** The audio stream.
           */
        STREAM_TYPE_AUDIO = 2,
        /** The subtitle stream.
           */
        STREAM_TYPE_SUBTITLE = 3,
    };

    /**
    * @brief The playback event.
    *
    */
    public enum MEDIA_PLAYER_EVENT
    {
        /** The player begins to seek to the new playback position.
        */
        PLAYER_EVENT_SEEK_BEGIN = 0,
        /** The seek operation completes.
         */
        PLAYER_EVENT_SEEK_COMPLETE = 1,
        /** An error occurs during the seek operation.
         */
        PLAYER_EVENT_SEEK_ERROR = 2,
        /** The player changes the audio track for playback.
         */
        PLAYER_EVENT_AUDIO_TRACK_CHANGED = 5,
        /** player buffer low
         */
        PLAYER_EVENT_BUFFER_LOW = 6,
        /** player buffer recover
       */
        PLAYER_EVENT_BUFFER_RECOVER = 7,
        /** The video or audio is interrupted
         */
        PLAYER_EVENT_FREEZE_START = 8,
        /** Interrupt at the end of the video or audio
         */
        PLAYER_EVENT_FREEZE_STOP = 9,
        /** switch source begin
        */
        PLAYER_EVENT_SWITCH_BEGIN = 10,
        /** switch source complete
        */
        PLAYER_EVENT_SWITCH_COMPLETE = 11,
        /** switch source error
        */
        PLAYER_EVENT_SWITCH_ERROR = 12,
        /** An application can render the video to less than a second
         */
        PLAYER_EVENT_FIRST_DISPLAYED = 13,
        /** cache resources exceed the maximum file count
         */
        PLAYER_EVENT_REACH_CACHE_FILE_MAX_COUNT = 14,
        /** cache resources exceed the maximum file size
         */
        PLAYER_EVENT_REACH_CACHE_FILE_MAX_SIZE = 15,
        /** Triggered when a retry is required to open the media
         */
        PLAYER_EVENT_TRY_OPEN_START = 16,
        /** Triggered when the retry to open the media is successful
         */
        PLAYER_EVENT_TRY_OPEN_SUCCEED = 17,
        /** Triggered when retrying to open media fails
         */
        PLAYER_EVENT_TRY_OPEN_FAILED = 18,
    };

    /**
 * @brief The play preload another source event.
 *
 */
    enum PLAYER_PRELOAD_EVENT
    {
        /** preload source begin
        */
        PLAYER_PRELOAD_EVENT_BEGIN = 0,
        /** preload source complete
        */
        PLAYER_PRELOAD_EVENT_COMPLETE = 1,
        /** preload source error
        */
        PLAYER_PRELOAD_EVENT_ERROR = 2,
    };

    /**
     * @brief The information of the media stream object.
     *
     */
    public class PlayerStreamInfo
    {
        /** The index of the media stream. */
        public int streamIndex { set; get; }

        /** The type of the media stream. See {@link MEDIA_STREAM_TYPE}. */
        public MEDIA_STREAM_TYPE streamType;

        /** The codec of the media stream. */
        public string codecName { set; get; }

        /** The language of the media stream. */
        public string language { set; get; }

        /** The frame rate (fps) if the stream is video. */
        public int videoFrameRate { set; get; }

        /** The video bitrate (bps) if the stream is video. */
        public int videoBitRate { set; get; }

        /** The video width (pixel) if the stream is video. */
        public int videoWidth { set; get; }

        /** The video height (pixel) if the stream is video. */
        public int videoHeight { set; get; }

        /** The rotation angle if the steam is video. */
        public int videoRotation { set; get; }

        /** The sample rate if the stream is audio. */
        public int audioSampleRate { set; get; }

        /** The number of audio channels if the stream is audio. */
        public int audioChannels { set; get; }

        /** The number of bits per sample if the stream is audio. */
        public int audioBitsPerSample { set; get; }

        /** The total duration (second) of the media stream. */
        public int64_t duration { set; get; }

        public PlayerStreamInfo()
        {
            streamIndex = 0;
            streamType = MEDIA_STREAM_TYPE.STREAM_TYPE_UNKNOWN;
            videoFrameRate = 0;
            videoBitRate = 0;
            videoWidth = 0;
            videoHeight = 0;
            videoRotation = 0;
            audioSampleRate = 0;
            audioChannels = 0;
            audioBitsPerSample = 0;
            duration = 0;
            codecName = "";
            language = "";
        }
    };

    /**
    * @brief The information of the media stream object.
    *
    */
    public class SrcInfo
    {
        /** The bitrate of the media stream. The unit of the number is kbps.
         *
         */
        public int bitrateInKbps { set; get; }

        /** The name of the media stream.
         *
        */
        public string name { set; get; }

    }

    /**
 * @brief The type of the media metadata.
 *
 */
    public enum MEDIA_PLAYER_METADATA_TYPE
    {
        /** The type is unknown.
         */
        PLAYER_METADATA_TYPE_UNKNOWN = 0,
        /** The type is SEI.
         */
        PLAYER_METADATA_TYPE_SEI = 1,
    };

    public class CacheStatistics
    {
        /**  total data size of uri
         */
        public Int64 fileSize { set; get; }
        /**  data of uri has cached
         */
        public Int64 cacheSize { set; get; }
        /**  data of uri has downloaded
         */
        public Int64 downloadSize { set; get; }
    };

    /** Values when user trigger interface of opening
*/
    public class PlayerUpdatedInfo : OptionalJsonParse
    {
        /** player_id has value when user trigger interface of opening
        */
        public Optional<string> playerId = new Optional<string>();

        /** device_id has value when user trigger interface of opening
        */
        public Optional<string> deviceId = new Optional<string>();

        /** cacheStatistics exist if you enable cache, triggered 1s at a time after openning url
        */
        public Optional<CacheStatistics> cacheStatistics = new Optional<CacheStatistics>();

        public override void ToJson(LitJson.JsonWriter writer)
        {

            writer.WriteObjectStart();

            if (this.playerId.HasValue())
            {
                writer.WritePropertyName("playerId");
                writer.Write(this.playerId.GetValue());
            }

            if (this.deviceId.HasValue())
            {
                writer.WritePropertyName("deviceId");
                writer.Write(this.deviceId.GetValue());
            }

            if (this.cacheStatistics.HasValue())
            {
                writer.WritePropertyName("cacheStatistics");
                LitJson.JsonMapper.WriteValue(this.cacheStatistics.GetValue(), writer, false, 0);
            }

            writer.WriteObjectEnd();
        }
    }

    public class MediaSource : OptionalJsonParse
    {
        /**
         * The URL of the media file that you want to play.
         */
        public string url { set; get; }
        /**
         * The URI of the media file
         *
         * When caching is enabled, if the url cannot distinguish the cache file name,
         * the uri must be able to ensure that the cache file name corresponding to the url is unique.
         */
        public string uri { set; get; }
        /**
         * Set the starting position for playback, in ms.
         */
        public int64_t startPos { set; get; }
        /**
        * Autoplay when media source is opened
        *
        */
        public bool autoPlay { set; get; }
        /**
         * Enable caching.
         */
        public bool enableCache { set; get; }
        /**
         * if the value is true, it means playing agora URL. 
         * The default value is false
         */
        public Optional<bool> isAgoraSource = new Optional<bool>();
        /**
         * If it is set to true, it means that the live stream will be optimized for quick start. 
         * The default value is false
         */
        public Optional<bool> isLiveSource = new Optional<bool>();
        /**
         * External custom data source object
         */
        public IMediaPlayerCustomDataProvider provider { set; get; }

        public MediaSource()
        {
            url = "";
            uri = "";
            startPos = 0;
            autoPlay = true;
            enableCache = false;
            provider = null;
        }


        public override void ToJson(LitJson.JsonWriter writer)
        {
            writer.WriteObjectStart();

            writer.WritePropertyName("url");
            writer.Write(url);

            writer.WritePropertyName("uri");
            writer.Write(uri);

            writer.WritePropertyName("startPos");
            writer.Write(startPos);

            writer.WritePropertyName("autoPlay");
            writer.Write(autoPlay);

            writer.WritePropertyName("enableCache");
            writer.Write(enableCache);

            if (isAgoraSource.HasValue())
            {
                writer.WritePropertyName("isAgoraSource");
                writer.Write(isAgoraSource.GetValue());
            }

            if (isLiveSource.HasValue())
            {
                writer.WritePropertyName("isLiveSource");
                writer.Write(isLiveSource.GetValue());
            }


            //todo provider need special

            writer.WriteObjectEnd();
        }

    };






    #endregion




}
