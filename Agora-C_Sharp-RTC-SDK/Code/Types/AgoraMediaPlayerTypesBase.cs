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
        /// 0: The default state.
        /// The media player returns this state code before you open the media resource or after you stop the playback.
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

        PLAYER_STATE_PAUSING_INTERNAL = 50,

        PLAYER_STATE_STOPPING_INTERNAL = 51,

        PLAYER_STATE_SEEKING_INTERNAL = 52,

        PLAYER_STATE_GETTING_INTERNAL = 53,

        PLAYER_STATE_NONE_INTERNAL = 54,

        PLAYER_STATE_DO_NOTHING_INTERNAL = 55,

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
        /// -5: The type of the media stream is unknown.
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
        /// -10: The URL of the media resource can not be found.
        /// </summary>
        ///
        PLAYER_ERROR_URL_NOT_FOUND = -10,

        ///
        /// <summary>
        /// -11: Invalid connection between the player and Agora's server.
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
        /// -14: The SDK does support the method being called.
        /// </summary>
        ///
        PLAYER_ERROR_NOT_SUPPORTED = -14,

        ///
        /// <summary>
        /// -15: The authentication information of the media resource is expired.
        /// </summary>
        ///
        PLAYER_ERROR_TOKEN_EXPIRED = -15,

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
    };

    ///
    /// <summary>
    /// Events that occur when media resources are preloaded.
    /// </summary>
    ///
    enum PLAYER_PRELOAD_EVENT
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
        public MEDIA_STREAM_TYPE streamType { set; get; }

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
            codecName = null;
            language = null;
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

    public class PlayerUpdatedInfo:OptionalJsonParse
    {
        public Optional<string> playerId = new Optional<string>();

        public Optional<string> deviceId = new Optional<string>();

        public override  void  ToJson(LitJson.JsonWriter writer)
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

            writer.WriteObjectEnd();
        }
    };

    #endregion
}