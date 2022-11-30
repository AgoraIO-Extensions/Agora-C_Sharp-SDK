using System;
using view_t = System.UInt64;
using video_track_id_t = System.UInt32;
using Agora.Rtc.LitJson;

namespace Agora.Rtc
{
    #region IAgoraRtcEngine.h

    public enum MEDIA_DEVICE_TYPE
    {
        UNKNOWN_AUDIO_DEVICE = -1,

        AUDIO_PLAYOUT_DEVICE = 0,

        AUDIO_RECORDING_DEVICE = 1,

        VIDEO_RENDER_DEVICE = 2,

        VIDEO_CAPTURE_DEVICE = 3,

        AUDIO_APPLICATION_PLAYOUT_DEVICE = 4,
    };

    public enum AUDIO_MIXING_STATE_TYPE
    {
        AUDIO_MIXING_STATE_PLAYING = 710,

        AUDIO_MIXING_STATE_PAUSED = 711,

        AUDIO_MIXING_STATE_STOPPED = 713,

        AUDIO_MIXING_STATE_FAILED = 714,
    };

    public enum AUDIO_MIXING_REASON_TYPE
    {
        AUDIO_MIXING_REASON_CAN_NOT_OPEN = 701,

        AUDIO_MIXING_REASON_TOO_FREQUENT_CALL = 702,

        AUDIO_MIXING_REASON_INTERRUPTED_EOF = 703,

        AUDIO_MIXING_REASON_ONE_LOOP_COMPLETED = 721,

        AUDIO_MIXING_REASON_ALL_LOOPS_COMPLETED = 723,

        AUDIO_MIXING_REASON_STOPPED_BY_USER = 724,

        AUDIO_MIXING_REASON_OK = 0,
    };

    public enum INJECT_STREAM_STATUS
    {
        INJECT_STREAM_STATUS_START_SUCCESS = 0,

        INJECT_STREAM_STATUS_START_ALREADY_EXISTS = 1,

        INJECT_STREAM_STATUS_START_UNAUTHORIZED = 2,

        INJECT_STREAM_STATUS_START_TIMEDOUT = 3,

        INJECT_STREAM_STATUS_START_FAILED = 4,

        INJECT_STREAM_STATUS_STOP_SUCCESS = 5,

        INJECT_STREAM_STATUS_STOP_NOT_FOUND = 6,

        INJECT_STREAM_STATUS_STOP_UNAUTHORIZED = 7,

        INJECT_STREAM_STATUS_STOP_TIMEDOUT = 8,

        INJECT_STREAM_STATUS_STOP_FAILED = 9,

        INJECT_STREAM_STATUS_BROKEN = 10,
    };

    public enum AUDIO_EQUALIZATION_BAND_FREQUENCY
    {
        AUDIO_EQUALIZATION_BAND_31 = 0,

        AUDIO_EQUALIZATION_BAND_62 = 1,

        AUDIO_EQUALIZATION_BAND_125 = 2,

        AUDIO_EQUALIZATION_BAND_250 = 3,

        AUDIO_EQUALIZATION_BAND_500 = 4,

        AUDIO_EQUALIZATION_BAND_1K = 5,

        AUDIO_EQUALIZATION_BAND_2K = 6,

        AUDIO_EQUALIZATION_BAND_4K = 7,

        AUDIO_EQUALIZATION_BAND_8K = 8,

        AUDIO_EQUALIZATION_BAND_16K = 9,
    };

    public enum AUDIO_REVERB_TYPE
    {
        AUDIO_REVERB_DRY_LEVEL = 0,

        AUDIO_REVERB_WET_LEVEL = 1,

        AUDIO_REVERB_ROOM_SIZE = 2,

        AUDIO_REVERB_WET_DELAY = 3,

        AUDIO_REVERB_STRENGTH = 4,
    };

    public enum STREAM_FALLBACK_OPTIONS
    {
        STREAM_FALLBACK_OPTION_DISABLED = 0,

        STREAM_FALLBACK_OPTION_VIDEO_STREAM_LOW = 1,

        STREAM_FALLBACK_OPTION_AUDIO_ONLY = 2,
    };

    public enum PRIORITY_TYPE
    {
        PRIORITY_HIGH = 50,

        PRIORITY_NORMAL = 100,
    };

    public class LocalVideoStats
    {
        public LocalVideoStats()
        {
        }

        public uint uid { set; get; }

        public int sentBitrate { set; get; }

        public int sentFrameRate { set; get; }

        public int captureFrameRate { set; get; }

        public int captureFrameWidth { set; get; }

        public int captureFrameHeight { set; get; }

        public int regulatedCaptureFrameRate { set; get; }

        public int regulatedCaptureFrameWidth { set; get; }

        public int regulatedCaptureFrameHeight { set; get; }

        public int encoderOutputFrameRate { set; get; }

        public int encodedFrameWidth { set; get; }

        public int encodedFrameHeight { set; get; }

        public int rendererOutputFrameRate { set; get; }

        public int targetBitrate { set; get; }

        public int targetFrameRate { set; get; }

        public QUALITY_ADAPT_INDICATION qualityAdaptIndication { set; get; }

        public int encodedBitrate { set; get; }

        public int encodedFrameCount { set; get; }

        public VIDEO_CODEC_TYPE codecType { set; get; }

        public ushort txPacketLossRate { set; get; }

        public CAPTURE_BRIGHTNESS_LEVEL_TYPE captureBrightnessLevel { set; get; }

        public bool dualStreamEnabled { set; get; }

        public int hwEncoderAccelerating { set; get; }
    };

    public class RemoteVideoStats
    {
        public uint uid { set; get; }

        [Obsolete]
        public int delay { set; get; }

        public int width { set; get; }

        public int height { set; get; }

        public int receivedBitrate { set; get; }

        public int decoderOutputFrameRate { set; get; }

        public int rendererOutputFrameRate { set; get; }

        public int frameLossRate { set; get; }

        public int packetLossRate { set; get; }

        public VIDEO_STREAM_TYPE rxStreamType { set; get; }

        public int totalFrozenTime { set; get; }

        public int frozenRate { set; get; }

        public int avSyncTimeMs { set; get; }

        public int totalActiveTime { set; get; }

        public int publishDuration { set; get; }

        public int superResolutionType { set; get; }

        public int mosValue { set; get; }
    };

    public class Region
    {
        public uint uid { set; get; }

        public double x { set; get; }

        public double y { set; get; }

        public double width { set; get; }

        public double height { set; get; }

        public int zOrder { set; get; }

        public double alpha { set; get; }

        public RENDER_MODE_TYPE renderMode { set; get; }

        public Region()
        {
            uid = 0;
            x = 0;
            y = 0;
            width = 0;
            height = 0;
            zOrder = 0;
            alpha = 1.0;
            renderMode = RENDER_MODE_TYPE.RENDER_MODE_HIDDEN;
        }
    };

    public class VideoCompositingLayout
    {
        public int canvasWidth { set; get; }

        public int canvasHeight { set; get; }

        public string backgroundColor { set; get; }

        public Region[] regions { set; get; }

        public int regionCount { set; get; }

        public string appData { set; get; }

        public int appDataLength { set; get; }

        public VideoCompositingLayout()
        {
            canvasWidth = 0;
            canvasHeight = 0;
            backgroundColor = "";
            regions = new Region[0];
            regionCount = 0;
            appData = "";
            appDataLength = 0;
        }
    };

    public class InjectStreamConfig
    {
        public InjectStreamConfig()
        {
            width = 0;
            height = 0;
            videoGop = 30;
            videoFramerate = 15;
            videoBitrate = 400;
            audioSampleRate = AUDIO_SAMPLE_RATE_TYPE.AUDIO_SAMPLE_RATE_48000;
            audioBitrate = 48;
            audioChannels = 1;
        }

        public InjectStreamConfig(int width, int height, int videoGop, int videoFramerate, int videoBitrate,
            AUDIO_SAMPLE_RATE_TYPE audioSampleRate, int audioBitrate, int audioChannels)
        {
            this.width = width;
            this.height = height;
            this.videoGop = videoGop;
            this.videoFramerate = videoFramerate;
            this.videoBitrate = videoBitrate;
            this.audioSampleRate = audioSampleRate;
            this.audioBitrate = audioBitrate;
            this.audioChannels = audioChannels;
        }

        public int width { set; get; }

        public int height { set; get; }

        public int videoGop { set; get; }

        public int videoFramerate { set; get; }

        public int videoBitrate { set; get; }

        public AUDIO_SAMPLE_RATE_TYPE audioSampleRate { set; get; }

        public int audioBitrate { set; get; }

        public int audioChannels { set; get; }
    };

    public enum RTMP_STREAM_LIFE_CYCLE_TYPE
    {
        RTMP_STREAM_LIFE_CYCLE_BIND2CHANNEL = 1,

        RTMP_STREAM_LIFE_CYCLE_BIND2OWNER = 2,
    };

    public class PublisherConfiguration
    {
        public int width { set; get; }

        public int height { set; get; }

        public int framerate { set; get; }

        public int bitrate { set; get; }

        public int defaultLayout { set; get; }

        public int lifecycle { set; get; }

        public bool owner { set; get; }

        public int injectStreamWidth { set; get; }

        public int injectStreamHeight { set; get; }

        public string injectStreamUrl { set; get; }

        public string publishUrl { set; get; }

        public string rawStreamUrl { set; get; }

        public string extraInfo { set; get; }

        public PublisherConfiguration()
        {
            width = 640;
            height = 360;
            framerate = 15;
            bitrate = 500;
            defaultLayout = 1;
            lifecycle = (int)RTMP_STREAM_LIFE_CYCLE_TYPE.RTMP_STREAM_LIFE_CYCLE_BIND2CHANNEL;
            owner = true;
            injectStreamWidth = 0;
            injectStreamHeight = 0;
            injectStreamUrl = "";
            publishUrl = "";
            rawStreamUrl = "";
            extraInfo = "";
        }
    };

    public class AudioTrackConfig
    {
        public AudioTrackConfig()
        {
            enableLocalPlayback = true;
        }

        public bool enableLocalPlayback { set; get; }
    };

    public enum CAMERA_DIRECTION
    {
        CAMERA_REAR = 0,

        CAMERA_FRONT = 1,
    };

    public enum CLOUD_PROXY_TYPE
    {
        NONE_PROXY = 0,

        UDP_PROXY = 1,

        TCP_PROXY = 2,
    };

    public class CameraCapturerConfiguration
    {
        public CameraCapturerConfiguration()
        {
            deviceId = "";
            cameraDirection = CAMERA_DIRECTION.CAMERA_FRONT;
            format = new VideoFormat();
            this.followEncodeDimensionRatio = true;
        }

        public CameraCapturerConfiguration(string deviceId, VideoFormat format,
            CAMERA_DIRECTION cameraDirection, bool followEncodeDimensionRatio)
        {
            this.deviceId = deviceId;
            this.format = format;
            this.cameraDirection = cameraDirection;
            this.followEncodeDimensionRatio = followEncodeDimensionRatio;
        }

        public string deviceId { set; get; }

        public VideoFormat format { set; get; }

        public bool followEncodeDimensionRatio { set; get; }

        public CAMERA_DIRECTION cameraDirection { set; get; }
    }

    public class ScreenCaptureConfiguration
    {
        public ScreenCaptureConfiguration()
        {
            isCaptureWindow = false;
            displayId = 0;
        }

        public bool isCaptureWindow { set; get; }

        public uint displayId { set; get; }

        public Rectangle screenRect { set; get; }

        public uint windowId { set; get; }

        public ScreenCaptureParameters parameters { set; get; }

        public Rectangle regionRect { set; get; }
    }

    public class SIZE
    {
        public int width { set; get; }

        public int height { set; get; }

        public SIZE()
        {
            width = 0;
            height = 0;
        }

        public SIZE(int ww, int hh)
        {
            width = ww;
            height = hh;
        }
    };

    public class ThumbImageBuffer
    {
        public byte[] buffer { set; get; }

        public uint length { set; get; }

        public uint width { set; get; }

        public uint height { set; get; }

        public ThumbImageBuffer()
        {
            buffer = new byte[0];
            length = 0;
            width = 0;
            height = 0;
        }
    };

    public enum ScreenCaptureSourceType
    {
        ScreenCaptureSourceType_Unknown = -1,

        ScreenCaptureSourceType_Window = 0,

        ScreenCaptureSourceType_Screen = 1,

        ScreenCaptureSourceType_Custom = 2,
    };

    public class ScreenCaptureSourceInfo
    {
        public ScreenCaptureSourceType type { set; get; }

        public view_t sourceId { set; get; }

        public string sourceName { set; get; }

        public ThumbImageBuffer thumbImage { set; get; }

        public ThumbImageBuffer iconImage { set; get; }

        public string processPath { set; get; }

        public string sourceTitle { set; get; }

        public bool primaryMonitor { set; get; }

        public bool isOccluded { set; get; }

        public bool minimizeWindow { set; get; }

        public ScreenCaptureSourceInfo()
        {
            type = ScreenCaptureSourceType.ScreenCaptureSourceType_Unknown;
            sourceId = 0;
            sourceName = "";
            processPath = "";
            sourceTitle = "";
            primaryMonitor = false;
            isOccluded = false;
            thumbImage = new ThumbImageBuffer();
            iconImage = new ThumbImageBuffer();
            minimizeWindow = false;
        }
    };

    public class AdvancedAudioOptions : OptionalJsonParse
    {
        public Optional<int> audioProcessingChannels = new Optional<int>();

        public override void ToJson(JsonWriter writer)
        {
            writer.WriteObjectStart();

            if (this.audioProcessingChannels.HasValue())
            {
                writer.WritePropertyName("audioProcessingChannels");
                writer.Write(this.audioProcessingChannels.GetValue());
            }

            writer.WriteObjectEnd();
        }
    };

    public class ImageTrackOptions
    {
        public string imageUrl { set; get; }

        public int fps { set; get; }

        public ImageTrackOptions()
        {
            imageUrl = "";
            fps = 1;
        }
    };


    public class ChannelMediaOptions : OptionalJsonParse
    {
        public Optional<bool> publishCameraTrack = new Optional<bool>();

        public Optional<bool> publishSecondaryCameraTrack = new Optional<bool>();

        public Optional<bool> publishMicrophoneTrack = new Optional<bool>();

        public Optional<bool> publishScreenCaptureVideo = new Optional<bool>();

        public Optional<bool> publishScreenCaptureAudio = new Optional<bool>();

        public Optional<bool> publishScreenTrack = new Optional<bool>();

        public Optional<bool> publishSecondaryScreenTrack = new Optional<bool>();

        public Optional<bool> publishCustomAudioTrack = new Optional<bool>();

        public Optional<int> publishCustomAudioSourceId = new Optional<int>();

        public Optional<bool> publishCustomAudioTrackEnableAec = new Optional<bool>();

        public Optional<bool> publishDirectCustomAudioTrack = new Optional<bool>();

        public Optional<bool> publishCustomAudioTrackAec = new Optional<bool>();

        public Optional<bool> publishCustomVideoTrack = new Optional<bool>();

        public Optional<bool> publishEncodedVideoTrack = new Optional<bool>();

        public Optional<bool> publishMediaPlayerAudioTrack = new Optional<bool>();

        public Optional<bool> publishMediaPlayerVideoTrack = new Optional<bool>();

        public Optional<bool> publishTrancodedVideoTrack = new Optional<bool>();

        public Optional<bool> autoSubscribeAudio = new Optional<bool>();

        public Optional<bool> autoSubscribeVideo = new Optional<bool>();

        public Optional<bool> enableAudioRecordingOrPlayout = new Optional<bool>();

        public Optional<int> publishMediaPlayerId = new Optional<int>();

        public Optional<CLIENT_ROLE_TYPE> clientRoleType = new Optional<CLIENT_ROLE_TYPE>();

        public Optional<AUDIENCE_LATENCY_LEVEL_TYPE> audienceLatencyLevel = new Optional<AUDIENCE_LATENCY_LEVEL_TYPE>();

        public Optional<VIDEO_STREAM_TYPE> defaultVideoStreamType = new Optional<VIDEO_STREAM_TYPE>();

        public Optional<CHANNEL_PROFILE_TYPE> channelProfile = new Optional<CHANNEL_PROFILE_TYPE>();

        public Optional<int> audioDelayMs = new Optional<int>();

        public Optional<int> mediaPlayerAudioDelayMs = new Optional<int>();

        public Optional<string> token = new Optional<string>();

        public Optional<bool> enableBuiltInMediaEncryption = new Optional<bool>();

        public Optional<bool> publishRhythmPlayerTrack = new Optional<bool>();

        public Optional<bool> isInteractiveAudience = new Optional<bool>();

        public Optional<video_track_id_t> customVideoTrackId = new Optional<video_track_id_t>();

        public Optional<bool> isAudioFilterable = new Optional<bool>();

        public ChannelMediaOptions() { }

        public override void ToJson(JsonWriter writer)
        {
            writer.WriteObjectStart();

            if (this.publishCameraTrack.HasValue())
            {
                writer.WritePropertyName("publishCameraTrack");
                writer.Write(this.publishCameraTrack.GetValue());
            }

            if (this.publishSecondaryCameraTrack.HasValue())
            {
                writer.WritePropertyName("publishSecondaryCameraTrack");
                writer.Write(this.publishSecondaryCameraTrack.GetValue());
            }

            if (this.publishMicrophoneTrack.HasValue())
            {
                writer.WritePropertyName("publishMicrophoneTrack");
                writer.Write(this.publishMicrophoneTrack.GetValue());
            }

            if (this.publishScreenCaptureVideo.HasValue())
            {
                writer.WritePropertyName("publishScreenCaptureVideo");
                writer.Write(this.publishScreenCaptureVideo.GetValue());
            }

            if (this.publishScreenCaptureAudio.HasValue())
            {
                writer.WritePropertyName("publishScreenCaptureAudio");
                writer.Write(this.publishScreenCaptureAudio.GetValue());
            }

            if (this.publishScreenTrack.HasValue())
            {
                writer.WritePropertyName("publishScreenTrack");
                writer.Write(this.publishScreenTrack.GetValue());
            }

            if (this.publishSecondaryScreenTrack.HasValue())
            {
                writer.WritePropertyName("publishSecondaryScreenTrack");
                writer.Write(this.publishSecondaryScreenTrack.GetValue());
            }

            if (this.publishCustomAudioTrack.HasValue())
            {
                writer.WritePropertyName("publishCustomAudioTrack");
                writer.Write(this.publishCustomAudioTrack.GetValue());
            }

            if (this.publishCustomAudioSourceId.HasValue())
            {
                writer.WritePropertyName("publishCustomAudioSourceId");
                writer.Write(this.publishCustomAudioSourceId.GetValue());
            }
            if (this.publishCustomAudioTrackEnableAec.HasValue())
            {
                writer.WritePropertyName("publishCustomAudioTrackEnableAec");
                writer.Write(this.publishCustomAudioTrackEnableAec.GetValue());
            }

            if (this.publishDirectCustomAudioTrack.HasValue())
            {
                writer.WritePropertyName("publishDirectCustomAudioTrack");
                writer.Write(this.publishDirectCustomAudioTrack.GetValue());
            }

            if (this.publishCustomAudioTrackAec.HasValue())
            {
                writer.WritePropertyName("publishCustomAudioTrackAec");
                writer.Write(this.publishCustomAudioTrackAec.GetValue());
            }

            if (this.publishCustomVideoTrack.HasValue())
            {
                writer.WritePropertyName("publishCustomVideoTrack");
                writer.Write(this.publishCustomVideoTrack.GetValue());
            }

            if (this.publishEncodedVideoTrack.HasValue())
            {
                writer.WritePropertyName("publishEncodedVideoTrack");
                writer.Write(this.publishEncodedVideoTrack.GetValue());
            }

            if (this.publishMediaPlayerAudioTrack.HasValue())
            {
                writer.WritePropertyName("publishMediaPlayerAudioTrack");
                writer.Write(this.publishMediaPlayerAudioTrack.GetValue());
            }

            if (this.publishMediaPlayerVideoTrack.HasValue())
            {
                writer.WritePropertyName("publishMediaPlayerVideoTrack");
                writer.Write(this.publishMediaPlayerVideoTrack.GetValue());
            }

            if (this.publishTrancodedVideoTrack.HasValue())
            {
                writer.WritePropertyName("publishTrancodedVideoTrack");
                writer.Write(this.publishTrancodedVideoTrack.GetValue());
            }
            if (this.autoSubscribeAudio.HasValue())
            {
                writer.WritePropertyName("autoSubscribeAudio");
                writer.Write(this.autoSubscribeAudio.GetValue());
            }

            if (this.autoSubscribeVideo.HasValue())
            {
                writer.WritePropertyName("autoSubscribeVideo");
                writer.Write(this.autoSubscribeVideo.GetValue());
            }

            if (this.enableAudioRecordingOrPlayout.HasValue())
            {
                writer.WritePropertyName("enableAudioRecordingOrPlayout");
                writer.Write(this.enableAudioRecordingOrPlayout.GetValue());
            }

            if (this.publishMediaPlayerId.HasValue())
            {
                writer.WritePropertyName("publishMediaPlayerId");
                writer.Write(this.publishMediaPlayerId.GetValue());
            }
            if (this.clientRoleType.HasValue())
            {
                writer.WritePropertyName("clientRoleType");
                WriteEnum(writer, this.clientRoleType.GetValue());
            }

            if (this.audienceLatencyLevel.HasValue())
            {
                writer.WritePropertyName("audienceLatencyLevel");
                WriteEnum(writer, this.audienceLatencyLevel.GetValue());
            }

            if (this.defaultVideoStreamType.HasValue())
            {
                writer.WritePropertyName("defaultVideoStreamType");
                WriteEnum(writer, this.defaultVideoStreamType.GetValue());
            }

            if (this.channelProfile.HasValue())
            {
                writer.WritePropertyName("channelProfile");
                WriteEnum(writer, this.channelProfile.GetValue());
            }

            if (this.audioDelayMs.HasValue())
            {
                writer.WritePropertyName("audioDelayMs");
                writer.Write(this.audioDelayMs.GetValue());
            }

            if (this.mediaPlayerAudioDelayMs.HasValue())
            {
                writer.WritePropertyName("xxmediaPlayerAudioDelayMs");
                writer.Write(this.mediaPlayerAudioDelayMs.GetValue());
            }

            if (this.token.HasValue())
            {
                writer.WritePropertyName("token");
                writer.Write(this.token.GetValue());
            }

            if (this.enableBuiltInMediaEncryption.HasValue())
            {
                writer.WritePropertyName("enableBuiltInMediaEncryption");
                writer.Write(this.enableBuiltInMediaEncryption.GetValue());
            }
            if (this.publishRhythmPlayerTrack.HasValue())
            {
                writer.WritePropertyName("publishRhythmPlayerTrack");
                writer.Write(this.publishRhythmPlayerTrack.GetValue());
            }

            if (this.isInteractiveAudience.HasValue())
            {
                writer.WritePropertyName("isInteractiveAudience");
                writer.Write(this.isInteractiveAudience.GetValue());
            }

            if (this.customVideoTrackId.HasValue())
            {
                writer.WritePropertyName("customVideoTrackId");
                writer.Write(this.customVideoTrackId.GetValue());
            }

            if (this.isAudioFilterable.HasValue())
            {
                writer.WritePropertyName("isAudioFilterable");
                writer.Write(this.isAudioFilterable.GetValue());
            }

            writer.WriteObjectEnd();
        }
    };

    public enum LOCAL_PROXY_MODE
    {
        kConnectivityFirst = 0,

        kLocalOnly = 1,
    };

    public enum PROXY_TYPE
    {
        NONE_PROXY_TYPE = 0,

        UDP_PROXY_TYPE = 1,

        TCP_PROXY_TYPE = 2,

        LOCAL_PROXY_TYPE = 3,

        TCP_PROXY_AUTO_FALLBACK_TYPE = 4,
    };

    public class LogUploadServerInfo
    {

        public string serverDomain { set; get; }

        public string serverPath { set; get; }

        public int serverPort { set; get; }

        public bool serverHttps;

        public LogUploadServerInfo()
        {
            serverDomain = null;
            serverPath = null;
            serverPort = 0;
            serverHttps = true;
        }

        public LogUploadServerInfo(string domain, string path, int port, bool https)
        {
            serverDomain = domain;
            path = serverPath;
            serverPort = port;
            serverHttps = https;
        }
    };

    public class AdvancedConfigInfo
    {
        public LogUploadServerInfo logUploadServer = new LogUploadServerInfo();
    };

    public class LocalAccessPointConfiguration
    {
        public string[] ipList { set; get; }

        public int ipListSize { set; get; }

        public string[] domainList { set; get; }

        public int domainListSize { set; get; }

        public string verifyDomainName { set; get; }

        public LOCAL_PROXY_MODE mode { set; get; }

        public AdvancedConfigInfo advancedConfig { set; get; }

        public LocalAccessPointConfiguration()
        {
            ipList = new string[0];
            ipListSize = 0;
            domainList = new string[0];
            domainListSize = 0;
            verifyDomainName = "";
            mode = LOCAL_PROXY_MODE.kConnectivityFirst;
            advancedConfig = new AdvancedConfigInfo();
        }
    };

    public class LeaveChannelOptions
    {
        public LeaveChannelOptions()
        {
            stopAudioMixing = true;
            stopAllEffect = true;
            stopMicrophoneRecording = true;
        }

        public bool stopAudioMixing { set; get; }

        public bool stopAllEffect { set; get; }

        public bool stopMicrophoneRecording { set; get; }
    };

    public class RtcEngineContext : OptionalJsonParse
    {
        public RtcEngineContext()
        {
            eventHandler = null;
            appId = "";
            context = 0;

            channelProfile = CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING;
            license = "";
            audioScenario = AUDIO_SCENARIO_TYPE.AUDIO_SCENARIO_DEFAULT;
            areaCode = AREA_CODE.AREA_CODE_GLOB;
            logConfig = new LogConfig();
            useExternalEglContext = false;
            domainLimit = false;
        }

        public RtcEngineContext(string appId, UInt64 context,
            CHANNEL_PROFILE_TYPE channelProfile, AUDIO_SCENARIO_TYPE audioScenario,
            AREA_CODE areaCode = AREA_CODE.AREA_CODE_GLOB,
            LogConfig logConfig = null, string license = "")
        {
            this.appId = appId;
            this.context = context;
            this.channelProfile = channelProfile;
            this.license = license;
            this.audioScenario = audioScenario;
            this.areaCode = areaCode;
            this.logConfig = logConfig ?? new LogConfig();
        }

        private IRtcEngineEventHandler eventHandler = null;

        public string appId { set; get; }

        public UInt64 context { set; get; }

        public CHANNEL_PROFILE_TYPE channelProfile { set; get; }


        public string license { set; get; }
        public AUDIO_SCENARIO_TYPE audioScenario { set; get; }

        public AREA_CODE areaCode { set; get; }


        public LogConfig logConfig { set; get; }

        public Optional<THREAD_PRIORITY_TYPE> threadPriority = new Optional<THREAD_PRIORITY_TYPE>();

        public bool useExternalEglContext { set; get; }

        public bool domainLimit { set; get; }

        public override void ToJson(JsonWriter writer)
        {
            writer.WriteObjectStart();

            writer.WritePropertyName("appId");
            writer.Write(this.appId);

            writer.WritePropertyName("context");
            writer.Write((UInt64)this.context);

            writer.WritePropertyName("channelProfile");
            this.WriteEnum(writer, this.channelProfile);

            writer.WritePropertyName("license");
            writer.Write(this.license);

            writer.WritePropertyName("audioScenario");
            this.WriteEnum(writer, this.audioScenario);

            writer.WritePropertyName("areaCode");
            this.WriteEnum(writer, this.areaCode);

            writer.WritePropertyName("logConfig");
            JsonMapper.WriteValue(this.logConfig, writer, false, 0);


            if (this.threadPriority.HasValue())
            {
                writer.WritePropertyName("threadPriority");
                this.WriteEnum(writer, this.threadPriority.GetValue());
            }

            writer.WritePropertyName("useExternalEglContext");
            writer.Write(this.useExternalEglContext);

            writer.WriteObjectEnd();
        }
    };

    public enum METADATA_TYPE
    {
        UNKNOWN_METADATA = -1,

        VIDEO_METADATA = 0,
    };

    public class Metadata
    {
        public uint uid;

        public uint size;

        public IntPtr buffer
        {
            set
            {
                _buffer = (UInt64)value;
            }
            get
            {
                return (IntPtr)_buffer;
            }
        }

        private UInt64 _buffer;

        public long timeStampMs;
    };

    public enum DIRECT_CDN_STREAMING_ERROR
    {
        DIRECT_CDN_STREAMING_ERROR_OK = 0,

        DIRECT_CDN_STREAMING_ERROR_FAILED = 1,

        DIRECT_CDN_STREAMING_ERROR_AUDIO_PUBLICATION = 2,

        DIRECT_CDN_STREAMING_ERROR_VIDEO_PUBLICATION = 3,

        DIRECT_CDN_STREAMING_ERROR_NET_CONNECT = 4,

        DIRECT_CDN_STREAMING_ERROR_BAD_NAME = 5,
    };

    public enum DIRECT_CDN_STREAMING_STATE
    {

        DIRECT_CDN_STREAMING_STATE_IDLE = 0,

        DIRECT_CDN_STREAMING_STATE_RUNNING = 1,

        DIRECT_CDN_STREAMING_STATE_STOPPED = 2,

        DIRECT_CDN_STREAMING_STATE_FAILED = 3,

        DIRECT_CDN_STREAMING_STATE_RECOVERING = 4,
    };

    public class DirectCdnStreamingStats
    {
        public int videoWidth { set; get; }

        public int videoHeight { set; get; }

        public int fps { set; get; }

        public int videoBitrate { set; get; }

        public int audioBitrate { set; get; }
    };

    public class DirectCdnStreamingMediaOptions : OptionalJsonParse
    {
        public Optional<bool> publishCameraTrack = new Optional<bool>();

        public Optional<bool> publishMicrophoneTrack = new Optional<bool>();

        public Optional<bool> publishCustomAudioTrack = new Optional<bool>();

        public Optional<bool> publishCustomVideoTrack = new Optional<bool>();

        public Optional<bool> publishMediaPlayerAudioTrack = new Optional<bool>();

        public Optional<int> publishMediaPlayerId = new Optional<int>();

        public Optional<video_track_id_t> customVideoTrackId = new Optional<video_track_id_t>();

        public DirectCdnStreamingMediaOptions()
        {

        }

        void SetAll(ref DirectCdnStreamingMediaOptions change)
        {
            this.publishCameraTrack = change.publishCameraTrack;
            this.publishMicrophoneTrack = change.publishMicrophoneTrack;
            this.publishCustomAudioTrack = change.publishCustomAudioTrack;
            this.publishCustomVideoTrack = change.publishCustomVideoTrack;
            this.publishMediaPlayerAudioTrack = change.publishMediaPlayerAudioTrack;
            this.publishMediaPlayerId = change.publishMediaPlayerId;
            this.customVideoTrackId = change.customVideoTrackId;
        }

        public override void ToJson(JsonWriter writer)
        {
            writer.WriteObjectStart();

            if (this.publishCameraTrack.HasValue())
            {
                writer.WritePropertyName("publishCameraTrack");
                writer.Write(this.publishCameraTrack.GetValue());
            }

            if (this.publishMicrophoneTrack.HasValue())
            {
                writer.WritePropertyName("publishMicrophoneTrack");
                writer.Write(this.publishMicrophoneTrack.GetValue());
            }

            if (this.publishCustomAudioTrack.HasValue())
            {
                writer.WritePropertyName("publishCustomAudioTrack");
                writer.Write(this.publishCustomAudioTrack.GetValue());
            }

            if (this.publishCustomVideoTrack.HasValue())
            {
                writer.WritePropertyName("publishCustomVideoTrack");
                writer.Write(this.publishCustomVideoTrack.GetValue());
            }

            if (this.publishMediaPlayerAudioTrack.HasValue())
            {
                writer.WritePropertyName("publishMediaPlayerAudioTrack");
                writer.Write(this.publishMediaPlayerAudioTrack.GetValue());
            }

            if (this.publishMediaPlayerId.HasValue())
            {
                writer.WritePropertyName("publishMediaPlayerId");
                writer.Write(this.publishMediaPlayerId.GetValue());
            }

            if (this.customVideoTrackId.HasValue())
            {
                writer.WritePropertyName("customVideoTrackId");
                writer.Write(this.customVideoTrackId.GetValue());
            }

            writer.WriteObjectEnd();
        }
    }

    public class ExtensionInfo
    {
        public MEDIA_SOURCE_TYPE mediaSourceType { set; get; }

        public uint remoteUid { set; get; }

        public string channelId { set; get; }

        public uint localUid { set; get; }

        public ExtensionInfo()
        {
            mediaSourceType = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE;
            remoteUid = 0;
            channelId = "";
            localUid = 0;
        }
    };


    public enum QUALITY_REPORT_FORMAT_TYPE
    {
        QUALITY_REPORT_JSON = 0,

        QUALITY_REPORT_HTML = 1,
    };

    public enum MEDIA_DEVICE_STATE_TYPE
    {
        MEDIA_DEVICE_STATE_IDLE = 0,

        MEDIA_DEVICE_STATE_ACTIVE = 1,

        MEDIA_DEVICE_STATE_DISABLED = 2,

        MEDIA_DEVICE_STATE_NOT_PRESENT = 4,

        MEDIA_DEVICE_STATE_UNPLUGGED = 8
    };

    public enum VIDEO_PROFILE_TYPE
    {
        VIDEO_PROFILE_LANDSCAPE_120P = 0,  // 160x120   15

        VIDEO_PROFILE_LANDSCAPE_120P_3 = 2,   // 120x120   15

        VIDEO_PROFILE_LANDSCAPE_180P = 10,    // 320x180   15

        VIDEO_PROFILE_LANDSCAPE_180P_3 = 12,  // 180x180   15

        VIDEO_PROFILE_LANDSCAPE_180P_4 = 13,  // 240x180   15

        VIDEO_PROFILE_LANDSCAPE_240P = 20,    // 320x240   15

        VIDEO_PROFILE_LANDSCAPE_240P_3 = 22,  // 240x240   15

        VIDEO_PROFILE_LANDSCAPE_240P_4 = 23,  // 424x240   15

        VIDEO_PROFILE_LANDSCAPE_360P = 30,  // 640x360   15

        VIDEO_PROFILE_LANDSCAPE_360P_3 = 32,  // 360x360   15

        VIDEO_PROFILE_LANDSCAPE_360P_4 = 33,  // 640x360   30

        VIDEO_PROFILE_LANDSCAPE_360P_6 = 35,  // 360x360   30

        VIDEO_PROFILE_LANDSCAPE_360P_7 = 36,  // 480x360   15

        VIDEO_PROFILE_LANDSCAPE_360P_8 = 37,  // 480x360   30

        VIDEO_PROFILE_LANDSCAPE_360P_9 = 38,   // 640x360   15

        VIDEO_PROFILE_LANDSCAPE_360P_10 = 39,  // 640x360   24

        VIDEO_PROFILE_LANDSCAPE_360P_11 = 100,  // 640x360   24

        VIDEO_PROFILE_LANDSCAPE_480P = 40,  // 640x480   15

        VIDEO_PROFILE_LANDSCAPE_480P_3 = 42,  // 480x480   15

        VIDEO_PROFILE_LANDSCAPE_480P_4 = 43,  // 640x480   30

        VIDEO_PROFILE_LANDSCAPE_480P_6 = 45,  // 480x480   30

        VIDEO_PROFILE_LANDSCAPE_480P_8 = 47,  // 848x480   15

        VIDEO_PROFILE_LANDSCAPE_480P_9 = 48,  // 848x480   30

        VIDEO_PROFILE_LANDSCAPE_480P_10 = 49,  // 640x480   10

        VIDEO_PROFILE_LANDSCAPE_720P = 50,  // 1280x720  15

        VIDEO_PROFILE_LANDSCAPE_720P_3 = 52,  // 1280x720  30

        VIDEO_PROFILE_LANDSCAPE_720P_5 = 54,  // 960x720   15

        VIDEO_PROFILE_LANDSCAPE_720P_6 = 55,  // 960x720   30

        VIDEO_PROFILE_LANDSCAPE_1080P = 60,  // 1920x1080 15

        VIDEO_PROFILE_LANDSCAPE_1080P_3 = 62,  // 1920x1080 30

        VIDEO_PROFILE_LANDSCAPE_1080P_5 = 64,  // 1920x1080 60

        VIDEO_PROFILE_LANDSCAPE_1440P = 66,  // 2560x1440 30

        VIDEO_PROFILE_LANDSCAPE_1440P_2 = 67,  // 2560x1440 60

        VIDEO_PROFILE_LANDSCAPE_4K = 70,  // 3840x2160 30

        VIDEO_PROFILE_LANDSCAPE_4K_3 = 72,     // 3840x2160 60

        VIDEO_PROFILE_PORTRAIT_120P = 1000,    // 120x160   15

        VIDEO_PROFILE_PORTRAIT_120P_3 = 1002,  // 120x120   15

        VIDEO_PROFILE_PORTRAIT_180P = 1010,    // 180x320   15

        VIDEO_PROFILE_PORTRAIT_180P_3 = 1012,  // 180x180   15

        VIDEO_PROFILE_PORTRAIT_180P_4 = 1013,  // 180x240   15

        VIDEO_PROFILE_PORTRAIT_240P = 1020,  // 240x320   15

        VIDEO_PROFILE_PORTRAIT_240P_3 = 1022,  // 240x240   15

        VIDEO_PROFILE_PORTRAIT_240P_4 = 1023,  // 240x424   15

        VIDEO_PROFILE_PORTRAIT_360P = 1030,  // 360x640   15

        VIDEO_PROFILE_PORTRAIT_360P_3 = 1032,  // 360x360   15

        VIDEO_PROFILE_PORTRAIT_360P_4 = 1033,  // 360x640   30

        VIDEO_PROFILE_PORTRAIT_360P_6 = 1035,  // 360x360   30

        VIDEO_PROFILE_PORTRAIT_360P_7 = 1036,  // 360x480   15

        VIDEO_PROFILE_PORTRAIT_360P_8 = 1037,  // 360x480   30

        VIDEO_PROFILE_PORTRAIT_360P_9 = 1038,  // 360x640   15

        VIDEO_PROFILE_PORTRAIT_360P_10 = 1039,  // 360x640   24

        VIDEO_PROFILE_PORTRAIT_360P_11 = 1100,  // 360x640   24

        VIDEO_PROFILE_PORTRAIT_480P = 1040,  // 480x640   15

        VIDEO_PROFILE_PORTRAIT_480P_3 = 1042,  // 480x480   15

        VIDEO_PROFILE_PORTRAIT_480P_4 = 1043,  // 480x640   30

        VIDEO_PROFILE_PORTRAIT_480P_6 = 1045,  // 480x480   30

        VIDEO_PROFILE_PORTRAIT_480P_8 = 1047,  // 480x848   15

        VIDEO_PROFILE_PORTRAIT_480P_9 = 1048,  // 480x848   30

        VIDEO_PROFILE_PORTRAIT_480P_10 = 1049,  // 480x640   10

        VIDEO_PROFILE_PORTRAIT_720P = 1050,  // 720x1280  15

        VIDEO_PROFILE_PORTRAIT_720P_3 = 1052,  // 720x1280  30

        VIDEO_PROFILE_PORTRAIT_720P_5 = 1054,  // 720x960   15

        VIDEO_PROFILE_PORTRAIT_720P_6 = 1055,  // 720x960   30

        VIDEO_PROFILE_PORTRAIT_1080P = 1060,    // 1080x1920 15

        VIDEO_PROFILE_PORTRAIT_1080P_3 = 1062,  // 1080x1920 30

        VIDEO_PROFILE_PORTRAIT_1080P_5 = 1064,  // 1080x1920 60

        VIDEO_PROFILE_PORTRAIT_1440P = 1066,  // 1440x2560 30

        VIDEO_PROFILE_PORTRAIT_1440P_2 = 1067,  // 1440x2560 60

        VIDEO_PROFILE_PORTRAIT_4K = 1070,       // 2160x3840 30

        VIDEO_PROFILE_PORTRAIT_4K_3 = 1072,  // 2160x3840 60

        VIDEO_PROFILE_DEFAULT = VIDEO_PROFILE_LANDSCAPE_360P,
    };

    #endregion
}