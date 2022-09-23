using System;

namespace Agora.Rtc
{
    using int64_t = Int64;

    #region AgoraMediaPlayerTypes.h
    
    ///
    /// <summary>
    /// The playback state.
    /// </summary>
    ///
    public enum MEDIA_PLAYER_STATE
    {
        ///
        /// <summary>
        /// 0: The default state. The media player returns this state code before you open the media resource or after you stop the playback.
        /// </summary>
        ///
        PLAYER_STATE_IDLE = 0,

        ///
        /// <summary>
        /// Opening the media resource.
        /// </summary>
        ///
        PLAYER_STATE_OPENING = 1,

        ///
        /// <summary>
        /// Opens the media resource successfully.
        /// </summary>
        ///
        PLAYER_STATE_OPEN_COMPLETED = 2,

        ///
        /// <summary>
        /// The media resource is playing.
        /// </summary>
        ///
        PLAYER_STATE_PLAYING = 3,

        ///
        /// <summary>
        /// Pauses the playback.
        /// </summary>
        ///
        PLAYER_STATE_PAUSED = 4,

        ///
        /// <summary>
        /// The playback finishes.
        /// </summary>
        ///
        PLAYER_STATE_PLAYBACK_COMPLETED = 5,

        ///
        /// <summary>
        /// The loop finishes.
        /// </summary>
        ///
        PLAYER_STATE_PLAYBACK_ALL_LOOPS_COMPLETED = 6,

        ///
        /// <summary>
        /// The playback stops.
        /// </summary>
        ///
        PLAYER_STATE_STOPPED = 7,

        ///
        /// @ignore
        ///
        PLAYER_STATE_PAUSING_INTERNAL = 50,

        ///
        /// @ignore
        ///
        PLAYER_STATE_STOPPING_INTERNAL = 51,

        ///
        /// @ignore
        ///
        PLAYER_STATE_SEEKING_INTERNAL = 52,

        ///
        /// @ignore
        ///
        PLAYER_STATE_GETTING_INTERNAL = 53,

        ///
        /// @ignore
        ///
        PLAYER_STATE_NONE_INTERNAL = 54,

        ///
        /// @ignore
        ///
        PLAYER_STATE_DO_NOTHING_INTERNAL = 55,

        ///
        /// @ignore
        ///
        PLAYER_STATE_SET_TRACK_INTERNAL = 56,

        ///
        /// <summary>
        /// 100: The media player fails to play the media resource.
        /// </summary>
        ///
        PLAYER_STATE_FAILED = 100,
    };

    ///
    /// <summary>
    /// Error codes of the media player.
    /// </summary>
    ///
    public enum MEDIA_PLAYER_ERROR
    {
        ///
        /// <summary>
        /// 0: No error.
        /// </summary>
        ///
        PLAYER_ERROR_NONE = 0,

        ///
        /// <summary>
        /// -1: Invalid arguments.
        /// </summary>
        ///
        PLAYER_ERROR_INVALID_ARGUMENTS = -1,

        ///
        /// <summary>
        /// -2: Internal error.
        /// </summary>
        ///
        PLAYER_ERROR_INTERNAL = -2,

        ///
        /// <summary>
        /// -3: No resource.
        /// </summary>
        ///
        PLAYER_ERROR_NO_RESOURCE = -3,

        ///
        /// <summary>
        /// -4: Invalid media resource.
        /// </summary>
        ///
        PLAYER_ERROR_INVALID_MEDIA_SOURCE = -4,

        ///
        /// <summary>
        /// -5: The media stream type is unknown.
        /// </summary>
        ///
        PLAYER_ERROR_UNKNOWN_STREAM_TYPE = -5,

        ///
        /// <summary>
        /// -6: The object is not initialized.
        /// </summary>
        ///
        PLAYER_ERROR_OBJ_NOT_INITIALIZED = -6,

        ///
        /// <summary>
        /// -7: The codec is not supported.
        /// </summary>
        ///
        PLAYER_ERROR_CODEC_NOT_SUPPORTED = -7,

        ///
        /// <summary>
        /// -8: Invalid renderer.
        /// </summary>
        ///
        PLAYER_ERROR_VIDEO_RENDER_FAILED = -8,

        ///
        /// <summary>
        /// -9: An error with the internal state of the player occurs.
        /// </summary>
        ///
        PLAYER_ERROR_INVALID_STATE = -9,

        ///
        /// <summary>
        /// -10: The URL of the media resource cannot be found.
        /// </summary>
        ///
        PLAYER_ERROR_URL_NOT_FOUND = -10,

        ///
        /// <summary>
        /// -11: Invalid connection between the player and the Agora Server.
        /// </summary>
        ///
        PLAYER_ERROR_INVALID_CONNECTION_STATE = -11,

        ///
        /// <summary>
        /// -12: The playback buffer is insufficient.
        /// </summary>
        ///
        PLAYER_ERROR_SRC_BUFFER_UNDERFLOW = -12,
        
        ///
        /// <summary>
        /// -13: The playback is interrupted.
        /// </summary>
        ///
        PLAYER_ERROR_INTERRUPTED = -13,

        ///
        /// <summary>
        /// -14: The SDK does not support the method being called.
        /// </summary>
        ///
        PLAYER_ERROR_NOT_SUPPORTED = -14,

        ///
        /// <summary>
        /// -15: The authentication information of the media resource is expired. 
        /// </summary>
        ///
        PLAYER_ERROR_TOKEN_EXPIRED = -15,

        ///
        /// @ignore
        ///
        PLAYER_ERROR_IP_EXPIRED = -16,

        ///
        /// <summary>
        /// -17: An unknown error.
        /// </summary>
        ///
        PLAYER_ERROR_UNKNOWN = -17,
    };

    ///
    /// <summary>
    /// The type of the media stream.
    /// </summary>
    ///
    public enum MEDIA_STREAM_TYPE
    {
        ///
        /// <summary>
        /// 0: The type is unknown.
        /// </summary>
        ///
        STREAM_TYPE_UNKNOWN = 0,

        ///
        /// <summary>
        /// 1: The video stream.
        /// </summary>
        ///
        STREAM_TYPE_VIDEO = 1,

        ///
        /// <summary>
        /// 2: The audio stream. 
        /// </summary>
        ///
        STREAM_TYPE_AUDIO = 2,

        ///
        /// <summary>
        /// 3: The subtitle stream.
        /// </summary>
        ///
        STREAM_TYPE_SUBTITLE = 3,
    };

    ///
    /// <summary>
    /// Media player events.
    /// </summary>
    ///
    public enum MEDIA_PLAYER_EVENT
    {
        ///
        /// <summary>
        /// 0: The player begins to seek to a new playback position.
        /// </summary>
        ///
        PLAYER_EVENT_SEEK_BEGIN = 0,

        ///
        /// <summary>
        /// 1: The player finishes seeking to a new playback position.
        /// </summary>
        ///
        PLAYER_EVENT_SEEK_COMPLETE = 1,

        ///
        /// <summary>
        /// 2: An error occurs when seeking to a new playback position.
        /// </summary>
        ///
        PLAYER_EVENT_SEEK_ERROR = 2,

        ///
        /// <summary>
        /// 5: The audio track used by the player has been changed.
        /// </summary>
        ///
        PLAYER_EVENT_AUDIO_TRACK_CHANGED = 5,

        ///
        /// <summary>
        /// 6: The currently buffered data is not enough to support playback.
        /// </summary>
        ///
        PLAYER_EVENT_BUFFER_LOW = 6,

        ///
        /// <summary>
        /// 7: The currently buffered data is just enough to support playback.
        /// </summary>
        ///
        PLAYER_EVENT_BUFFER_RECOVER = 7,

        ///
        /// <summary>
        /// 8: The audio or video playback freezes.
        /// </summary>
        ///
        PLAYER_EVENT_FREEZE_START = 8,

        ///
        /// <summary>
        /// 9: The audio or video playback resumes without freezing.
        /// </summary>
        ///
        PLAYER_EVENT_FREEZE_STOP = 9,

        ///
        /// <summary>
        /// 10: The player starts switching the media resource.
        /// </summary>
        ///
        PLAYER_EVENT_SWITCH_BEGIN = 10,

        ///
        /// <summary>
        /// 11: Media resource switching is complete.
        /// </summary>
        ///
        PLAYER_EVENT_SWITCH_COMPLETE = 11,

        ///
        /// <summary>
        /// 12: Media resource switching error.
        /// </summary>
        ///
        PLAYER_EVENT_SWITCH_ERROR = 12,

        ///
        /// <summary>
        /// 13: The first video frame is rendered.
        /// </summary>
        ///
        PLAYER_EVENT_FIRST_DISPLAYED = 13,

        ///
        /// <summary>
        /// 14: The cached media files reach the limit in number.
        /// </summary>
        ///
        PLAYER_EVENT_REACH_CACHE_FILE_MAX_COUNT = 14,
        
        ///
        /// <summary>
        /// 15: The cached media files reach the limit in aggregate storage space.
        /// </summary>
        ///
        PLAYER_EVENT_REACH_CACHE_FILE_MAX_SIZE = 15,

        ///
        /// @ignore
        ///
        PLAYER_EVENT_TRY_OPEN_START = 16,

        ///
        /// @ignore
        ///
        PLAYER_EVENT_TRY_OPEN_SUCCEED = 17,

        ///
        /// @ignore
        ///
        PLAYER_EVENT_TRY_OPEN_FAILED = 18,
    };

    ///
    /// <summary>
    /// Events that occur when media resources are preloaded.
    /// </summary>
    ///
    public enum PLAYER_PRELOAD_EVENT
    {
        ///
        /// <summary>
        /// 0: Starts preloading media resources.
        /// </summary>
        ///
        PLAYER_PRELOAD_EVENT_BEGIN = 0,

        ///
        /// <summary>
        /// 1: Preloading media resources is complete.
        /// </summary>
        ///
        PLAYER_PRELOAD_EVENT_COMPLETE = 1,

        ///
        /// <summary>
        /// 2: An error occurs when preloading media resources.
        /// </summary>
        ///
        PLAYER_PRELOAD_EVENT_ERROR = 2,
    };

    ///
    /// <summary>
    /// The detailed information of the media stream.
    /// </summary>
    ///
    public class PlayerStreamInfo
    {
        ///
        /// <summary>
        /// The index of the media stream.
        /// </summary>
        ///
        public int streamIndex { set; get; }

        ///
        /// <summary>
        /// The type of the media stream. See MEDIA_STREAM_TYPE .
        /// </summary>
        ///
        public MEDIA_STREAM_TYPE streamType;

        ///
        /// <summary>
        /// The codec of the media stream.
        /// </summary>
        ///
        public string codecName { set; get; }

        ///
        /// <summary>
        /// The language of the media stream.
        /// </summary>
        ///
        public string language { set; get; }

        ///
        /// <summary>
        /// This parameter only takes effect for video streams, and indicates the video frame rate (fps).
        /// </summary>
        ///
        public int videoFrameRate { set; get; }

        ///
        /// <summary>
        /// This parameter only takes effect for video streams, and indicates the video bitrate (bps).
        /// </summary>
        ///
        public int videoBitRate { set; get; }

        ///
        /// <summary>
        /// This parameter only takes effect for video streams, and indicates the video width (pixel).
        /// </summary>
        ///
        public int videoWidth { set; get; }

        ///
        /// <summary>
        /// This parameter only takes effect for video streams, and indicates the video height (pixel).
        /// </summary>
        ///
        public int videoHeight { set; get; }

        ///
        /// <summary>
        /// This parameter only takes effect for video streams, and indicates the video rotation angle.
        /// </summary>
        ///
        public int videoRotation { set; get; }

        ///
        /// <summary>
        /// This parameter only takes effect for audio streams, and indicates the audio sample rate (Hz).
        /// </summary>
        ///
        public int audioSampleRate { set; get; }

        ///
        /// <summary>
        /// This parameter only takes effect for audio streams, and indicates the audio channel number.
        /// </summary>
        ///
        public int audioChannels { set; get; }

        ///
        /// <summary>
        /// This parameter only takes effect for audio streams, and indicates the bit number of each audio sample.
        /// </summary>
        ///
        public int audioBitsPerSample { set; get; }

        ///
        /// <summary>
        /// The total duration (s) of the media stream.
        /// </summary>
        ///
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

    ///
    /// <summary>
    /// Information about the video bitrate of the media resource being played.
    /// </summary>
    ///
    public class SrcInfo
    {
        ///
        /// <summary>
        /// The video bitrate (Kbps) of the media resource being played.
        /// </summary>
        ///
        public int bitrateInKbps { set; get; }

        ///
        /// <summary>
        /// The name of the media resource.
        /// </summary>
        ///
        public string name { set; get; }
    };

    ///
    /// <summary>
    /// The type of media metadata.
    /// </summary>
    ///
    public enum MEDIA_PLAYER_METADATA_TYPE
    {
        ///
        /// <summary>
        /// 0: The type is unknown.
        /// </summary>
        ///
        PLAYER_METADATA_TYPE_UNKNOWN = 0,

        ///
        /// <summary>
        /// 1: The type is SEI.
        /// </summary>
        ///
        PLAYER_METADATA_TYPE_SEI = 1,
    };

    ///
    /// <summary>
    /// Statistics about the media files being cached.
    /// </summary>
    ///
    public class CacheStatistics
    {
        ///
        /// <summary>
        /// The size (bytes) of the media file being played.
        /// </summary>
        ///
        public Int64 fileSize { set; get; }

        ///
        /// <summary>
        /// The size (bytes) of the media file that you want to cache.
        /// </summary>
        ///
        public Int64 cacheSize { set; get; }

        ///
        /// <summary>
        /// The size (bytes) of the media file that has been downloaded.
        /// </summary>
        ///
        public Int64 downloadSize { set; get; }
    };

    ///
    /// <summary>
    /// Information related to the media player.
    /// </summary>
    ///
    public class PlayerUpdatedInfo : OptionalJsonParse
    {
        ///
        /// <summary>
        /// The ID of a media player.
        /// </summary>
        ///
        public Optional<string> playerId = new Optional<string>();

        ///
        /// <summary>
        /// The ID of a deivce.
        /// </summary>
        ///
        public Optional<string> deviceId = new Optional<string>();

        ///
        /// <summary>
        /// The statistics about the media file being cached.If you call the OpenWithMediaSource method and set enableCache as true, the statistics about the media file being cached is updated every second after the media file is played. See CacheStatistics .
        /// </summary>
        ///
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
    };

    ///
    /// <summary>
    /// Information related to the media file to be played and the playback scenario configurations.
    /// </summary>
    ///
    public class MediaSource : OptionalJsonParse
    {
        ///
        /// <summary>
        /// The URL of the media file to be played.If you need to open a custom media resource, you do not have to pass in a value to the url.
        /// </summary>
        ///
        public string url { set; get; }

        ///
        /// <summary>
        /// The URI (Uniform Resource Identifier) of the media file.
        /// </summary>
        ///
        public string uri { set; get; }

        ///
        /// <summary>
        /// The starting position (ms) for playback. The default value is 0.
        /// </summary>
        ///
        public int64_t startPos { set; get; }

        ///
        /// <summary>
        /// Whether to enable autoplay once the media file is opened:true: (Default) Enable autoplay.false: Disable autoplay.If autoplay is disabled, you need to call the Play method to play a media file after it is opened.
        /// </summary>
        ///
        public bool autoPlay { set; get; }

        ///
        /// <summary>
        /// Whether to cache the media file when it is being played:true:Enable caching.false: (Default) Disable caching.If you need to enable caching, pass in a value to uri; otherwise, caching is based on the url of the media file.If you enable this function, the Media Player caches part of the media file being played on your local device, and you can play the cached media file without internet connection. The statistics about the media file being cached are updated every second after the media file is played. See CacheStatistics .
        /// </summary>
        ///
        public bool enableCache { set; get; }

        ///
        /// <summary>
        /// Whether the media resource to be opened is a live stream or on-demand video distributed through Media Broadcast service:true: The media resource is a live stream or on-demand video distributed through Media Broadcast service.false: (Default) The media resource is not a live stream or on-demand video distributed through Media Broadcast service.If you need to open a live stream or on-demand video distributed through Broadcast Streaming service, pass in the URL of the media resource to url, and set isAgoraSource as true; otherwise, you don't need to set the isAgoraSource parameter.
        /// </summary>
        ///
        public Optional<bool> isAgoraSource = new Optional<bool>();

        ///
        /// <summary>
        /// Whether the media resource to be opened is a live stream:true: The media resource is a live stream.false: (Default) The media resource is not a live stream.If the media resource you want to open is a live stream, Agora recommends that you set this parameter as true so that the live stream can be loaded more quickly.If the media resource you open is not a live stream, but you set isLiveSource as true, the media resource is not to be loaded more quickly.
        /// </summary>
        ///
        public Optional<bool> isLiveSource = new Optional<bool>();

        ///
        /// <summary>
        /// The callback for custom media resource files. See IMediaPlayerCustomDataProvider .If you need to open a custom media resource, such as an encrypted media file, pass in a value to provider rather than to url.
        /// </summary>
        ///
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

            writer.WriteObjectEnd();
        }
    };

    #endregion
}