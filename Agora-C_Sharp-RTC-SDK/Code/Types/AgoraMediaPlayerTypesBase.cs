using System;

namespace Agora.Rtc
{
    using int64_t = Int64;

    #region AgoraMediaPlayerTypes.h

    public enum MEDIA_PLAYER_STATE
    {
        PLAYER_STATE_IDLE = 0,

        PLAYER_STATE_OPENING = 1,

        PLAYER_STATE_OPEN_COMPLETED = 2,

        PLAYER_STATE_PLAYING = 3,

        PLAYER_STATE_PAUSED = 4,

        PLAYER_STATE_PLAYBACK_COMPLETED = 5,

        PLAYER_STATE_PLAYBACK_ALL_LOOPS_COMPLETED = 6,

        PLAYER_STATE_STOPPED = 7,

        PLAYER_STATE_PAUSING_INTERNAL = 50,

        PLAYER_STATE_STOPPING_INTERNAL = 51,

        PLAYER_STATE_SEEKING_INTERNAL = 52,

        PLAYER_STATE_GETTING_INTERNAL = 53,

        PLAYER_STATE_NONE_INTERNAL = 54,

        PLAYER_STATE_DO_NOTHING_INTERNAL = 55,

        PLAYER_STATE_SET_TRACK_INTERNAL = 56,

        PLAYER_STATE_FAILED = 100,
    };

    public enum MEDIA_PLAYER_ERROR
    {
        PLAYER_ERROR_NONE = 0,

        PLAYER_ERROR_INVALID_ARGUMENTS = -1,

        PLAYER_ERROR_INTERNAL = -2,
        
        PLAYER_ERROR_NO_RESOURCE = -3,

        PLAYER_ERROR_INVALID_MEDIA_SOURCE = -4,

        PLAYER_ERROR_UNKNOWN_STREAM_TYPE = -5,

        PLAYER_ERROR_OBJ_NOT_INITIALIZED = -6,

        PLAYER_ERROR_CODEC_NOT_SUPPORTED = -7,

        PLAYER_ERROR_VIDEO_RENDER_FAILED = -8,

        PLAYER_ERROR_INVALID_STATE = -9,

        PLAYER_ERROR_URL_NOT_FOUND = -10,

        PLAYER_ERROR_INVALID_CONNECTION_STATE = -11,

        PLAYER_ERROR_SRC_BUFFER_UNDERFLOW = -12,

        PLAYER_ERROR_INTERRUPTED = -13,

        PLAYER_ERROR_NOT_SUPPORTED = -14,

        PLAYER_ERROR_TOKEN_EXPIRED = -15,

        PLAYER_ERROR_IP_EXPIRED = -16,

        PLAYER_ERROR_UNKNOWN = -17,
    };

    public enum MEDIA_STREAM_TYPE
    {
        STREAM_TYPE_UNKNOWN = 0,

        STREAM_TYPE_VIDEO = 1,

        STREAM_TYPE_AUDIO = 2,

        STREAM_TYPE_SUBTITLE = 3,
    };

    public enum MEDIA_PLAYER_EVENT
    {
        PLAYER_EVENT_SEEK_BEGIN = 0,

        PLAYER_EVENT_SEEK_COMPLETE = 1,

        PLAYER_EVENT_SEEK_ERROR = 2,

        PLAYER_EVENT_AUDIO_TRACK_CHANGED = 5,

        PLAYER_EVENT_BUFFER_LOW = 6,

        PLAYER_EVENT_BUFFER_RECOVER = 7,

        PLAYER_EVENT_FREEZE_START = 8,

        PLAYER_EVENT_FREEZE_STOP = 9,

        PLAYER_EVENT_SWITCH_BEGIN = 10,

        PLAYER_EVENT_SWITCH_COMPLETE = 11,

        PLAYER_EVENT_SWITCH_ERROR = 12,

        PLAYER_EVENT_FIRST_DISPLAYED = 13,

        PLAYER_EVENT_REACH_CACHE_FILE_MAX_COUNT = 14,

        PLAYER_EVENT_REACH_CACHE_FILE_MAX_SIZE = 15,

        PLAYER_EVENT_TRY_OPEN_START = 16,

        PLAYER_EVENT_TRY_OPEN_SUCCEED = 17,

        PLAYER_EVENT_TRY_OPEN_FAILED = 18,
    };

    enum PLAYER_PRELOAD_EVENT
    {
        PLAYER_PRELOAD_EVENT_BEGIN = 0,

        PLAYER_PRELOAD_EVENT_COMPLETE = 1,

        PLAYER_PRELOAD_EVENT_ERROR = 2,
    };

    public class PlayerStreamInfo
    {
        public int streamIndex { set; get; }

        public MEDIA_STREAM_TYPE streamType { set; get; }

        public string codecName { set; get; }

        public string language { set; get; }

        public int videoFrameRate { set; get; }

        public int videoBitRate { set; get; }

        public int videoWidth { set; get; }

        public int videoHeight { set; get; }

        public int videoRotation { set; get; }

        public int audioSampleRate { set; get; }

        public int audioChannels { set; get; }

        public int audioBitsPerSample { set; get; }

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

    public class SrcInfo
    {
        public int bitrateInKbps { set; get; }

        public string name { set; get; }
    }

    public enum MEDIA_PLAYER_METADATA_TYPE
    {
        PLAYER_METADATA_TYPE_UNKNOWN = 0,

        PLAYER_METADATA_TYPE_SEI = 1,
    };

    public class CacheStatistics
    {
        public Int64 fileSize { set; get; }

        public Int64 cacheSize { set; get; }

        public Int64 downloadSize { set; get; }
    };

    public class PlayerUpdatedInfo : OptionalJsonParse
    {
        public Optional<string> playerId = new Optional<string>();

        public Optional<string> deviceId = new Optional<string>();

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

    public class MediaSource : OptionalJsonParse
    {
        public string url { set; get; }

        public string uri { set; get; }

        public int64_t startPos { set; get; }

        public bool autoPlay { set; get; }

        public bool enableCache { set; get; }

        public Optional<bool> isAgoraSource = new Optional<bool>();

        public Optional<bool> isLiveSource = new Optional<bool>();

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
