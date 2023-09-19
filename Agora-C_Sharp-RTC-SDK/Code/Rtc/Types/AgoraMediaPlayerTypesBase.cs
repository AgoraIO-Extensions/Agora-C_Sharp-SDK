using System;
namespace Agora.Rtc
{
    using int64_t = Int64;
    using LitJson;

#region terra AgoraMediaPlayerTypes.h

    /* enum_mediaplayerstate */
    public enum MEDIA_PLAYER_STATE
    {
        /* enum_mediaplayerstate_PLAYER_STATE_IDLE */
        PLAYER_STATE_IDLE = 0,

        /* enum_mediaplayerstate_PLAYER_STATE_OPENING */
        PLAYER_STATE_OPENING,

        /* enum_mediaplayerstate_PLAYER_STATE_OPEN_COMPLETED */
        PLAYER_STATE_OPEN_COMPLETED,

        /* enum_mediaplayerstate_PLAYER_STATE_PLAYING */
        PLAYER_STATE_PLAYING,

        /* enum_mediaplayerstate_PLAYER_STATE_PAUSED */
        PLAYER_STATE_PAUSED,

        /* enum_mediaplayerstate_PLAYER_STATE_PLAYBACK_COMPLETED */
        PLAYER_STATE_PLAYBACK_COMPLETED,

        /* enum_mediaplayerstate_PLAYER_STATE_PLAYBACK_ALL_LOOPS_COMPLETED */
        PLAYER_STATE_PLAYBACK_ALL_LOOPS_COMPLETED,

        /* enum_mediaplayerstate_PLAYER_STATE_STOPPED */
        PLAYER_STATE_STOPPED,

        /* enum_mediaplayerstate_PLAYER_STATE_PAUSING_INTERNAL */
        PLAYER_STATE_PAUSING_INTERNAL = 50,

        /* enum_mediaplayerstate_PLAYER_STATE_STOPPING_INTERNAL */
        PLAYER_STATE_STOPPING_INTERNAL,

        /* enum_mediaplayerstate_PLAYER_STATE_SEEKING_INTERNAL */
        PLAYER_STATE_SEEKING_INTERNAL,

        /* enum_mediaplayerstate_PLAYER_STATE_GETTING_INTERNAL */
        PLAYER_STATE_GETTING_INTERNAL,

        /* enum_mediaplayerstate_PLAYER_STATE_NONE_INTERNAL */
        PLAYER_STATE_NONE_INTERNAL,

        /* enum_mediaplayerstate_PLAYER_STATE_DO_NOTHING_INTERNAL */
        PLAYER_STATE_DO_NOTHING_INTERNAL,

        /* enum_mediaplayerstate_PLAYER_STATE_SET_TRACK_INTERNAL */
        PLAYER_STATE_SET_TRACK_INTERNAL,

        /* enum_mediaplayerstate_PLAYER_STATE_FAILED */
        PLAYER_STATE_FAILED = 100,
    }

    /* enum_mediaplayererror */
    public enum MEDIA_PLAYER_ERROR
    {
        /* enum_mediaplayererror_PLAYER_ERROR_NONE */
        PLAYER_ERROR_NONE = 0,

        /* enum_mediaplayererror_PLAYER_ERROR_INVALID_ARGUMENTS */
        PLAYER_ERROR_INVALID_ARGUMENTS = -1,

        /* enum_mediaplayererror_PLAYER_ERROR_INTERNAL */
        PLAYER_ERROR_INTERNAL = -2,

        /* enum_mediaplayererror_PLAYER_ERROR_NO_RESOURCE */
        PLAYER_ERROR_NO_RESOURCE = -3,

        /* enum_mediaplayererror_PLAYER_ERROR_INVALID_MEDIA_SOURCE */
        PLAYER_ERROR_INVALID_MEDIA_SOURCE = -4,

        /* enum_mediaplayererror_PLAYER_ERROR_UNKNOWN_STREAM_TYPE */
        PLAYER_ERROR_UNKNOWN_STREAM_TYPE = -5,

        /* enum_mediaplayererror_PLAYER_ERROR_OBJ_NOT_INITIALIZED */
        PLAYER_ERROR_OBJ_NOT_INITIALIZED = -6,

        /* enum_mediaplayererror_PLAYER_ERROR_CODEC_NOT_SUPPORTED */
        PLAYER_ERROR_CODEC_NOT_SUPPORTED = -7,

        /* enum_mediaplayererror_PLAYER_ERROR_VIDEO_RENDER_FAILED */
        PLAYER_ERROR_VIDEO_RENDER_FAILED = -8,

        /* enum_mediaplayererror_PLAYER_ERROR_INVALID_STATE */
        PLAYER_ERROR_INVALID_STATE = -9,

        /* enum_mediaplayererror_PLAYER_ERROR_URL_NOT_FOUND */
        PLAYER_ERROR_URL_NOT_FOUND = -10,

        /* enum_mediaplayererror_PLAYER_ERROR_INVALID_CONNECTION_STATE */
        PLAYER_ERROR_INVALID_CONNECTION_STATE = -11,

        /* enum_mediaplayererror_PLAYER_ERROR_SRC_BUFFER_UNDERFLOW */
        PLAYER_ERROR_SRC_BUFFER_UNDERFLOW = -12,

        /* enum_mediaplayererror_PLAYER_ERROR_INTERRUPTED */
        PLAYER_ERROR_INTERRUPTED = -13,

        /* enum_mediaplayererror_PLAYER_ERROR_NOT_SUPPORTED */
        PLAYER_ERROR_NOT_SUPPORTED = -14,

        /* enum_mediaplayererror_PLAYER_ERROR_TOKEN_EXPIRED */
        PLAYER_ERROR_TOKEN_EXPIRED = -15,

        /* enum_mediaplayererror_PLAYER_ERROR_IP_EXPIRED */
        PLAYER_ERROR_IP_EXPIRED = -16,

        /* enum_mediaplayererror_PLAYER_ERROR_UNKNOWN */
        PLAYER_ERROR_UNKNOWN = -17,
    }

    /* enum_mediastreamtype */
    public enum MEDIA_STREAM_TYPE
    {
        /* enum_mediastreamtype_STREAM_TYPE_UNKNOWN */
        STREAM_TYPE_UNKNOWN = 0,

        /* enum_mediastreamtype_STREAM_TYPE_VIDEO */
        STREAM_TYPE_VIDEO = 1,

        /* enum_mediastreamtype_STREAM_TYPE_AUDIO */
        STREAM_TYPE_AUDIO = 2,

        /* enum_mediastreamtype_STREAM_TYPE_SUBTITLE */
        STREAM_TYPE_SUBTITLE = 3,
    }

    /* enum_mediaplayerevent */
    public enum MEDIA_PLAYER_EVENT
    {
        /* enum_mediaplayerevent_PLAYER_EVENT_SEEK_BEGIN */
        PLAYER_EVENT_SEEK_BEGIN = 0,

        /* enum_mediaplayerevent_PLAYER_EVENT_SEEK_COMPLETE */
        PLAYER_EVENT_SEEK_COMPLETE = 1,

        /* enum_mediaplayerevent_PLAYER_EVENT_SEEK_ERROR */
        PLAYER_EVENT_SEEK_ERROR = 2,

        /* enum_mediaplayerevent_PLAYER_EVENT_AUDIO_TRACK_CHANGED */
        PLAYER_EVENT_AUDIO_TRACK_CHANGED = 5,

        /* enum_mediaplayerevent_PLAYER_EVENT_BUFFER_LOW */
        PLAYER_EVENT_BUFFER_LOW = 6,

        /* enum_mediaplayerevent_PLAYER_EVENT_BUFFER_RECOVER */
        PLAYER_EVENT_BUFFER_RECOVER = 7,

        /* enum_mediaplayerevent_PLAYER_EVENT_FREEZE_START */
        PLAYER_EVENT_FREEZE_START = 8,

        /* enum_mediaplayerevent_PLAYER_EVENT_FREEZE_STOP */
        PLAYER_EVENT_FREEZE_STOP = 9,

        /* enum_mediaplayerevent_PLAYER_EVENT_SWITCH_BEGIN */
        PLAYER_EVENT_SWITCH_BEGIN = 10,

        /* enum_mediaplayerevent_PLAYER_EVENT_SWITCH_COMPLETE */
        PLAYER_EVENT_SWITCH_COMPLETE = 11,

        /* enum_mediaplayerevent_PLAYER_EVENT_SWITCH_ERROR */
        PLAYER_EVENT_SWITCH_ERROR = 12,

        /* enum_mediaplayerevent_PLAYER_EVENT_FIRST_DISPLAYED */
        PLAYER_EVENT_FIRST_DISPLAYED = 13,

        /* enum_mediaplayerevent_PLAYER_EVENT_REACH_CACHE_FILE_MAX_COUNT */
        PLAYER_EVENT_REACH_CACHE_FILE_MAX_COUNT = 14,

        /* enum_mediaplayerevent_PLAYER_EVENT_REACH_CACHE_FILE_MAX_SIZE */
        PLAYER_EVENT_REACH_CACHE_FILE_MAX_SIZE = 15,

        /* enum_mediaplayerevent_PLAYER_EVENT_TRY_OPEN_START */
        PLAYER_EVENT_TRY_OPEN_START = 16,

        /* enum_mediaplayerevent_PLAYER_EVENT_TRY_OPEN_SUCCEED */
        PLAYER_EVENT_TRY_OPEN_SUCCEED = 17,

        /* enum_mediaplayerevent_PLAYER_EVENT_TRY_OPEN_FAILED */
        PLAYER_EVENT_TRY_OPEN_FAILED = 18,
    }

    /* enum_playerpreloadevent */
    public enum PLAYER_PRELOAD_EVENT
    {
        /* enum_playerpreloadevent_PLAYER_PRELOAD_EVENT_BEGIN */
        PLAYER_PRELOAD_EVENT_BEGIN = 0,

        /* enum_playerpreloadevent_PLAYER_PRELOAD_EVENT_COMPLETE */
        PLAYER_PRELOAD_EVENT_COMPLETE = 1,

        /* enum_playerpreloadevent_PLAYER_PRELOAD_EVENT_ERROR */
        PLAYER_PRELOAD_EVENT_ERROR = 2,
    }

    /* class_playerstreaminfo */
    public class PlayerStreamInfo
    {
        /* class_playerstreaminfo_streamIndex */
        public int streamIndex;

        /* class_playerstreaminfo_streamType */
        public MEDIA_STREAM_TYPE streamType;

        /* class_playerstreaminfo_codecName */
        public string codecName;

        /* class_playerstreaminfo_language */
        public string language;

        /* class_playerstreaminfo_videoFrameRate */
        public int videoFrameRate;

        /* class_playerstreaminfo_videoBitRate */
        public int videoBitRate;

        /* class_playerstreaminfo_videoWidth */
        public int videoWidth;

        /* class_playerstreaminfo_videoHeight */
        public int videoHeight;

        /* class_playerstreaminfo_videoRotation */
        public int videoRotation;

        /* class_playerstreaminfo_audioSampleRate */
        public int audioSampleRate;

        /* class_playerstreaminfo_audioChannels */
        public int audioChannels;

        /* class_playerstreaminfo_audioBitsPerSample */
        public int audioBitsPerSample;

        /* class_playerstreaminfo_duration */
        public long duration;

        public PlayerStreamInfo()
        {
            this.streamIndex = 0;
            this.streamType = MEDIA_STREAM_TYPE.STREAM_TYPE_UNKNOWN;
            this.videoFrameRate = 0;
            this.videoBitRate = 0;
            this.videoWidth = 0;
            this.videoHeight = 0;
            this.videoRotation = 0;
            this.audioSampleRate = 0;
            this.audioChannels = 0;
            this.audioBitsPerSample = 0;
            this.duration = 0;
        }

        public PlayerStreamInfo(int streamIndex, MEDIA_STREAM_TYPE streamType, string codecName, string language, int videoFrameRate, int videoBitRate, int videoWidth, int videoHeight, int videoRotation, int audioSampleRate, int audioChannels, int audioBitsPerSample, long duration)
        {
            this.streamIndex = streamIndex;
            this.streamType = streamType;
            this.codecName = codecName;
            this.language = language;
            this.videoFrameRate = videoFrameRate;
            this.videoBitRate = videoBitRate;
            this.videoWidth = videoWidth;
            this.videoHeight = videoHeight;
            this.videoRotation = videoRotation;
            this.audioSampleRate = audioSampleRate;
            this.audioChannels = audioChannels;
            this.audioBitsPerSample = audioBitsPerSample;
            this.duration = duration;
        }
    }

    /* class_srcinfo */
    public class SrcInfo
    {
        /* class_srcinfo_bitrateInKbps */
        public int bitrateInKbps;

        /* class_srcinfo_name */
        public string name;

        public SrcInfo(int bitrateInKbps, string name)
        {
            this.bitrateInKbps = bitrateInKbps;
            this.name = name;
        }
        public SrcInfo()
        {
        }
    }

    /* enum_mediaplayermetadatatype */
    public enum MEDIA_PLAYER_METADATA_TYPE
    {
        /* enum_mediaplayermetadatatype_PLAYER_METADATA_TYPE_UNKNOWN */
        PLAYER_METADATA_TYPE_UNKNOWN = 0,

        /* enum_mediaplayermetadatatype_PLAYER_METADATA_TYPE_SEI */
        PLAYER_METADATA_TYPE_SEI = 1,
    }

    /* class_cachestatistics */
    public class CacheStatistics
    {
        /* class_cachestatistics_fileSize */
        public long fileSize;

        /* class_cachestatistics_cacheSize */
        public long cacheSize;

        /* class_cachestatistics_downloadSize */
        public long downloadSize;

        public CacheStatistics(long fileSize, long cacheSize, long downloadSize)
        {
            this.fileSize = fileSize;
            this.cacheSize = cacheSize;
            this.downloadSize = downloadSize;
        }
        public CacheStatistics()
        {
        }
    }

    /* class_playerupdatedinfo */
    public class PlayerUpdatedInfo : OptionalJsonParse
    {
        /* class_playerupdatedinfo_playerId */
        public Optional<string> playerId = new Optional<string>();

        /* class_playerupdatedinfo_deviceId */
        public Optional<string> deviceId = new Optional<string>();

        /* class_playerupdatedinfo_cacheStatistics */
        public Optional<CacheStatistics> cacheStatistics = new Optional<CacheStatistics>();

        public PlayerUpdatedInfo(Optional<string> playerId, Optional<string> deviceId, Optional<CacheStatistics> cacheStatistics)
        {
            this.playerId = playerId;
            this.deviceId = deviceId;
            this.cacheStatistics = cacheStatistics;
        }
        public PlayerUpdatedInfo()
        {
        }

        public override void ToJson(JsonWriter writer)
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
                JsonMapper.WriteValue(this.cacheStatistics.GetValue(), writer, false, 0);
            }

            writer.WriteObjectEnd();
        }
    }

    /* class_mediasource */
    public class MediaSource : OptionalJsonParse
    {
        /* class_mediasource_url */
        public string url;

        /* class_mediasource_uri */
        public string uri;

        /* class_mediasource_startPos */
        public long startPos;

        /* class_mediasource_autoPlay */
        public bool autoPlay;

        /* class_mediasource_enableCache */
        public bool enableCache;

        /* class_mediasource_isAgoraSource */
        public Optional<bool> isAgoraSource = new Optional<bool>();

        /* class_mediasource_isLiveSource */
        public Optional<bool> isLiveSource = new Optional<bool>();

        /* class_mediasource_provider */
        public IMediaPlayerCustomDataProvider provider;

        public MediaSource()
        {
            this.url = "";
            this.uri = "";
            this.startPos = 0;
            this.autoPlay = true;
            this.enableCache = false;
            this.provider = null;
        }

        public MediaSource(string url, string uri, long startPos, bool autoPlay, bool enableCache, Optional<bool> isAgoraSource, Optional<bool> isLiveSource, IMediaPlayerCustomDataProvider provider)
        {
            this.url = url;
            this.uri = uri;
            this.startPos = startPos;
            this.autoPlay = autoPlay;
            this.enableCache = enableCache;
            this.isAgoraSource = isAgoraSource;
            this.isLiveSource = isLiveSource;
            this.provider = provider;
        }

        public override void ToJson(JsonWriter writer)
        {
            writer.WriteObjectStart();

            writer.WritePropertyName("url");
            writer.Write(this.url);

            writer.WritePropertyName("uri");
            writer.Write(this.uri);

            writer.WritePropertyName("startPos");
            writer.Write(this.startPos);

            writer.WritePropertyName("autoPlay");
            writer.Write(this.autoPlay);

            writer.WritePropertyName("enableCache");
            writer.Write(this.enableCache);

            if (this.isAgoraSource.HasValue())
            {
                writer.WritePropertyName("isAgoraSource");
                writer.Write(this.isAgoraSource.GetValue());
            }

            if (this.isLiveSource.HasValue())
            {
                writer.WritePropertyName("isLiveSource");
                writer.Write(this.isLiveSource.GetValue());
            }

            writer.WriteObjectEnd();
        }
    }

#endregion terra AgoraMediaPlayerTypes.h
}