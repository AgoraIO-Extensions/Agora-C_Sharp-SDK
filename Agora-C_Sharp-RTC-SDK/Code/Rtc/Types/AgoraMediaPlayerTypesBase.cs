﻿using System;
namespace Agora.Rtc
{
    using int64_t = Int64;
    using LitJson;

#region terra AgoraMediaPlayerTypes.h

    public enum MEDIA_PLAYER_STATE
    {
        PLAYER_STATE_IDLE = 0,

        PLAYER_STATE_OPENING,

        PLAYER_STATE_OPEN_COMPLETED,

        PLAYER_STATE_PLAYING,

        PLAYER_STATE_PAUSED,

        PLAYER_STATE_PLAYBACK_COMPLETED,

        PLAYER_STATE_PLAYBACK_ALL_LOOPS_COMPLETED,

        PLAYER_STATE_STOPPED,

        PLAYER_STATE_PAUSING_INTERNAL = 50,

        PLAYER_STATE_STOPPING_INTERNAL,

        PLAYER_STATE_SEEKING_INTERNAL,

        PLAYER_STATE_GETTING_INTERNAL,

        PLAYER_STATE_NONE_INTERNAL,

        PLAYER_STATE_DO_NOTHING_INTERNAL,

        PLAYER_STATE_SET_TRACK_INTERNAL,

        PLAYER_STATE_FAILED = 100,
    }

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
    }

    public enum MEDIA_STREAM_TYPE
    {
        STREAM_TYPE_UNKNOWN = 0,

        STREAM_TYPE_VIDEO = 1,

        STREAM_TYPE_AUDIO = 2,

        STREAM_TYPE_SUBTITLE = 3,
    }

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
    }

    public enum PLAYER_PRELOAD_EVENT
    {
        PLAYER_PRELOAD_EVENT_BEGIN = 0,

        PLAYER_PRELOAD_EVENT_COMPLETE = 1,

        PLAYER_PRELOAD_EVENT_ERROR = 2,
    }

    public class PlayerStreamInfo
    {
        public int streamIndex;

        public MEDIA_STREAM_TYPE streamType;

        public string codecName;

        public string language;

        public int videoFrameRate;

        public int videoBitRate;

        public int videoWidth;

        public int videoHeight;

        public int videoRotation;

        public int audioSampleRate;

        public int audioChannels;

        public int audioBitsPerSample;

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

    public class SrcInfo
    {
        public int bitrateInKbps;

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

    public enum MEDIA_PLAYER_METADATA_TYPE
    {
        PLAYER_METADATA_TYPE_UNKNOWN = 0,

        PLAYER_METADATA_TYPE_SEI = 1,
    }

    public class CacheStatistics
    {
        public long fileSize;

        public long cacheSize;

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

    public class PlayerUpdatedInfo : OptionalJsonParse
    {
        public Optional<string> playerId = new Optional<string>();

        public Optional<string> deviceId = new Optional<string>();

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

    public class MediaSource : OptionalJsonParse
    {
        public string url;

        public string uri;

        public long startPos;

        public bool autoPlay;

        public bool enableCache;

        public Optional<bool> isAgoraSource = new Optional<bool>();

        public Optional<bool> isLiveSource = new Optional<bool>();

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