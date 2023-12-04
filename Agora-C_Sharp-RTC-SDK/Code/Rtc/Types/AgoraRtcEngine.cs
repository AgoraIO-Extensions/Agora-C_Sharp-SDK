using System;
using view_t = System.Int64;
using Agora.Rtc.LitJson;

namespace Agora.Rtc
{
    #region terra IAgoraRtcEngine.h
    public enum MEDIA_DEVICE_TYPE
    {
        UNKNOWN_AUDIO_DEVICE = -1,

        AUDIO_PLAYOUT_DEVICE = 0,

        AUDIO_RECORDING_DEVICE = 1,

        VIDEO_RENDER_DEVICE = 2,

        VIDEO_CAPTURE_DEVICE = 3,

        AUDIO_APPLICATION_PLAYOUT_DEVICE = 4,

        AUDIO_VIRTUAL_PLAYOUT_DEVICE = 5,

        AUDIO_VIRTUAL_RECORDING_DEVICE = 6,
    }

    public enum AUDIO_MIXING_STATE_TYPE
    {
        AUDIO_MIXING_STATE_PLAYING = 710,

        AUDIO_MIXING_STATE_PAUSED = 711,

        AUDIO_MIXING_STATE_STOPPED = 713,

        AUDIO_MIXING_STATE_FAILED = 714,
    }

    public enum AUDIO_MIXING_REASON_TYPE
    {
        AUDIO_MIXING_REASON_CAN_NOT_OPEN = 701,

        AUDIO_MIXING_REASON_TOO_FREQUENT_CALL = 702,

        AUDIO_MIXING_REASON_INTERRUPTED_EOF = 703,

        AUDIO_MIXING_REASON_ONE_LOOP_COMPLETED = 721,

        AUDIO_MIXING_REASON_ALL_LOOPS_COMPLETED = 723,

        AUDIO_MIXING_REASON_STOPPED_BY_USER = 724,

        AUDIO_MIXING_REASON_OK = 0,
    }

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
    }

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
    }

    public enum AUDIO_REVERB_TYPE
    {
        AUDIO_REVERB_DRY_LEVEL = 0,

        AUDIO_REVERB_WET_LEVEL = 1,

        AUDIO_REVERB_ROOM_SIZE = 2,

        AUDIO_REVERB_WET_DELAY = 3,

        AUDIO_REVERB_STRENGTH = 4,
    }

    public enum STREAM_FALLBACK_OPTIONS
    {
        STREAM_FALLBACK_OPTION_DISABLED = 0,

        STREAM_FALLBACK_OPTION_VIDEO_STREAM_LOW = 1,

        STREAM_FALLBACK_OPTION_AUDIO_ONLY = 2,
    }

    public enum PRIORITY_TYPE
    {
        PRIORITY_HIGH = 50,

        PRIORITY_NORMAL = 100,
    }

    public class LocalVideoStats
    {
        public uint uid;

        public int sentBitrate;

        public int sentFrameRate;

        public int captureFrameRate;

        public int captureFrameWidth;

        public int captureFrameHeight;

        public int regulatedCaptureFrameRate;

        public int regulatedCaptureFrameWidth;

        public int regulatedCaptureFrameHeight;

        public int encoderOutputFrameRate;

        public int encodedFrameWidth;

        public int encodedFrameHeight;

        public int rendererOutputFrameRate;

        public int targetBitrate;

        public int targetFrameRate;

        public QUALITY_ADAPT_INDICATION qualityAdaptIndication;

        public int encodedBitrate;

        public int encodedFrameCount;

        public VIDEO_CODEC_TYPE codecType;

        public ushort txPacketLossRate;

        public CAPTURE_BRIGHTNESS_LEVEL_TYPE captureBrightnessLevel;

        public bool dualStreamEnabled;

        public int hwEncoderAccelerating;

        public LocalVideoStats(uint uid, int sentBitrate, int sentFrameRate, int captureFrameRate, int captureFrameWidth, int captureFrameHeight, int regulatedCaptureFrameRate, int regulatedCaptureFrameWidth, int regulatedCaptureFrameHeight, int encoderOutputFrameRate, int encodedFrameWidth, int encodedFrameHeight, int rendererOutputFrameRate, int targetBitrate, int targetFrameRate, QUALITY_ADAPT_INDICATION qualityAdaptIndication, int encodedBitrate, int encodedFrameCount, VIDEO_CODEC_TYPE codecType, ushort txPacketLossRate, CAPTURE_BRIGHTNESS_LEVEL_TYPE captureBrightnessLevel, bool dualStreamEnabled, int hwEncoderAccelerating)
        {
            this.uid = uid;
            this.sentBitrate = sentBitrate;
            this.sentFrameRate = sentFrameRate;
            this.captureFrameRate = captureFrameRate;
            this.captureFrameWidth = captureFrameWidth;
            this.captureFrameHeight = captureFrameHeight;
            this.regulatedCaptureFrameRate = regulatedCaptureFrameRate;
            this.regulatedCaptureFrameWidth = regulatedCaptureFrameWidth;
            this.regulatedCaptureFrameHeight = regulatedCaptureFrameHeight;
            this.encoderOutputFrameRate = encoderOutputFrameRate;
            this.encodedFrameWidth = encodedFrameWidth;
            this.encodedFrameHeight = encodedFrameHeight;
            this.rendererOutputFrameRate = rendererOutputFrameRate;
            this.targetBitrate = targetBitrate;
            this.targetFrameRate = targetFrameRate;
            this.qualityAdaptIndication = qualityAdaptIndication;
            this.encodedBitrate = encodedBitrate;
            this.encodedFrameCount = encodedFrameCount;
            this.codecType = codecType;
            this.txPacketLossRate = txPacketLossRate;
            this.captureBrightnessLevel = captureBrightnessLevel;
            this.dualStreamEnabled = dualStreamEnabled;
            this.hwEncoderAccelerating = hwEncoderAccelerating;
        }
        public LocalVideoStats()
        {
        }

    }

    public class RemoteAudioStats
    {
        public uint uid;

        public int quality;

        public int networkTransportDelay;

        public int jitterBufferDelay;

        public int audioLossRate;

        public int numChannels;

        public int receivedSampleRate;

        public int receivedBitrate;

        public int totalFrozenTime;

        public int frozenRate;

        public int mosValue;

        public uint frozenRateByCustomPlcCount;

        public uint plcCount;

        public int totalActiveTime;

        public int publishDuration;

        public int qoeQuality;

        public int qualityChangedReason;

        public uint rxAudioBytes;

        public RemoteAudioStats()
        {
            this.uid = 0;
            this.quality = 0;
            this.networkTransportDelay = 0;
            this.jitterBufferDelay = 0;
            this.audioLossRate = 0;
            this.numChannels = 0;
            this.receivedSampleRate = 0;
            this.receivedBitrate = 0;
            this.totalFrozenTime = 0;
            this.frozenRate = 0;
            this.mosValue = 0;
            this.frozenRateByCustomPlcCount = 0;
            this.plcCount = 0;
            this.totalActiveTime = 0;
            this.publishDuration = 0;
            this.qoeQuality = 0;
            this.qualityChangedReason = 0;
            this.rxAudioBytes = 0;
        }

        public RemoteAudioStats(uint uid, int quality, int networkTransportDelay, int jitterBufferDelay, int audioLossRate, int numChannels, int receivedSampleRate, int receivedBitrate, int totalFrozenTime, int frozenRate, int mosValue, uint frozenRateByCustomPlcCount, uint plcCount, int totalActiveTime, int publishDuration, int qoeQuality, int qualityChangedReason, uint rxAudioBytes)
        {
            this.uid = uid;
            this.quality = quality;
            this.networkTransportDelay = networkTransportDelay;
            this.jitterBufferDelay = jitterBufferDelay;
            this.audioLossRate = audioLossRate;
            this.numChannels = numChannels;
            this.receivedSampleRate = receivedSampleRate;
            this.receivedBitrate = receivedBitrate;
            this.totalFrozenTime = totalFrozenTime;
            this.frozenRate = frozenRate;
            this.mosValue = mosValue;
            this.frozenRateByCustomPlcCount = frozenRateByCustomPlcCount;
            this.plcCount = plcCount;
            this.totalActiveTime = totalActiveTime;
            this.publishDuration = publishDuration;
            this.qoeQuality = qoeQuality;
            this.qualityChangedReason = qualityChangedReason;
            this.rxAudioBytes = rxAudioBytes;
        }
    }

    public class RemoteVideoStats
    {
        public uint uid;

        public int delay;

        public int e2eDelay;

        public int width;

        public int height;

        public int receivedBitrate;

        public int decoderOutputFrameRate;

        public int rendererOutputFrameRate;

        public int frameLossRate;

        public int packetLossRate;

        public VIDEO_STREAM_TYPE rxStreamType;

        public int totalFrozenTime;

        public int frozenRate;

        public int avSyncTimeMs;

        public int totalActiveTime;

        public int publishDuration;

        public int mosValue;

        public uint rxVideoBytes;

        public RemoteVideoStats(uint uid, int delay, int e2eDelay, int width, int height, int receivedBitrate, int decoderOutputFrameRate, int rendererOutputFrameRate, int frameLossRate, int packetLossRate, VIDEO_STREAM_TYPE rxStreamType, int totalFrozenTime, int frozenRate, int avSyncTimeMs, int totalActiveTime, int publishDuration, int mosValue, uint rxVideoBytes)
        {
            this.uid = uid;
            this.delay = delay;
            this.e2eDelay = e2eDelay;
            this.width = width;
            this.height = height;
            this.receivedBitrate = receivedBitrate;
            this.decoderOutputFrameRate = decoderOutputFrameRate;
            this.rendererOutputFrameRate = rendererOutputFrameRate;
            this.frameLossRate = frameLossRate;
            this.packetLossRate = packetLossRate;
            this.rxStreamType = rxStreamType;
            this.totalFrozenTime = totalFrozenTime;
            this.frozenRate = frozenRate;
            this.avSyncTimeMs = avSyncTimeMs;
            this.totalActiveTime = totalActiveTime;
            this.publishDuration = publishDuration;
            this.mosValue = mosValue;
            this.rxVideoBytes = rxVideoBytes;
        }
        public RemoteVideoStats()
        {
        }

    }

    public class VideoCompositingLayout
    {
        public int canvasWidth;

        public int canvasHeight;

        public string backgroundColor;

        public Region[] regions;

        public int regionCount;

        public string appData;

        public int appDataLength;

        public VideoCompositingLayout()
        {
            this.canvasWidth = 0;
            this.canvasHeight = 0;
            this.backgroundColor = "";
            this.regions = new Region[0];
            this.regionCount = 0;
            this.appData = "";
            this.appDataLength = 0;
        }

        public VideoCompositingLayout(int canvasWidth, int canvasHeight, string backgroundColor, Region[] regions, int regionCount, string appData, int appDataLength)
        {
            this.canvasWidth = canvasWidth;
            this.canvasHeight = canvasHeight;
            this.backgroundColor = backgroundColor;
            this.regions = regions;
            this.regionCount = regionCount;
            this.appData = appData;
            this.appDataLength = appDataLength;
        }
    }

    public class Region
    {
        public uint uid;

        public double x;

        public double y;

        public double width;

        public double height;

        public int zOrder;

        public double alpha;

        public RENDER_MODE_TYPE renderMode;

        public Region()
        {
            this.uid = 0;
            this.x = 0;
            this.y = 0;
            this.width = 0;
            this.height = 0;
            this.zOrder = 0;
            this.alpha = 1.0;
            this.renderMode = RENDER_MODE_TYPE.RENDER_MODE_HIDDEN;
        }

        public Region(uint uid, double x, double y, double width, double height, int zOrder, double alpha, RENDER_MODE_TYPE renderMode)
        {
            this.uid = uid;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.zOrder = zOrder;
            this.alpha = alpha;
            this.renderMode = renderMode;
        }
    }

    public class InjectStreamConfig
    {
        public int width;

        public int height;

        public int videoGop;

        public int videoFramerate;

        public int videoBitrate;

        public AUDIO_SAMPLE_RATE_TYPE audioSampleRate;

        public int audioBitrate;

        public int audioChannels;

        public InjectStreamConfig()
        {
            this.width = 0;
            this.height = 0;
            this.videoGop = 30;
            this.videoFramerate = 15;
            this.videoBitrate = 400;
            this.audioSampleRate = AUDIO_SAMPLE_RATE_TYPE.AUDIO_SAMPLE_RATE_48000;
            this.audioBitrate = 48;
            this.audioChannels = 1;
        }

        public InjectStreamConfig(int width, int height, int videoGop, int videoFramerate, int videoBitrate, AUDIO_SAMPLE_RATE_TYPE audioSampleRate, int audioBitrate, int audioChannels)
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
    }

    public enum RTMP_STREAM_LIFE_CYCLE_TYPE
    {
        RTMP_STREAM_LIFE_CYCLE_BIND2CHANNEL = 1,

        RTMP_STREAM_LIFE_CYCLE_BIND2OWNER = 2,
    }

    public class PublisherConfiguration
    {
        public int width;

        public int height;

        public int framerate;

        public int bitrate;

        public int defaultLayout;

        public int lifecycle;

        public bool owner;

        public int injectStreamWidth;

        public int injectStreamHeight;

        public string injectStreamUrl;

        public string publishUrl;

        public string rawStreamUrl;

        public string extraInfo;

        public PublisherConfiguration()
        {
            this.width = 640;
            this.height = 360;
            this.framerate = 15;
            this.bitrate = 500;
            this.defaultLayout = 1;
            this.lifecycle = (int)RTMP_STREAM_LIFE_CYCLE_TYPE.RTMP_STREAM_LIFE_CYCLE_BIND2CHANNEL;
            this.owner = true;
            this.injectStreamWidth = 0;
            this.injectStreamHeight = 0;
            this.injectStreamUrl = "";
            this.publishUrl = "";
            this.rawStreamUrl = "";
            this.extraInfo = "";
        }

        public PublisherConfiguration(int width, int height, int framerate, int bitrate, int defaultLayout, int lifecycle, bool owner, int injectStreamWidth, int injectStreamHeight, string injectStreamUrl, string publishUrl, string rawStreamUrl, string extraInfo)
        {
            this.width = width;
            this.height = height;
            this.framerate = framerate;
            this.bitrate = bitrate;
            this.defaultLayout = defaultLayout;
            this.lifecycle = lifecycle;
            this.owner = owner;
            this.injectStreamWidth = injectStreamWidth;
            this.injectStreamHeight = injectStreamHeight;
            this.injectStreamUrl = injectStreamUrl;
            this.publishUrl = publishUrl;
            this.rawStreamUrl = rawStreamUrl;
            this.extraInfo = extraInfo;
        }
    }

    public enum CAMERA_DIRECTION
    {
        CAMERA_REAR = 0,

        CAMERA_FRONT = 1,
    }

    public enum CLOUD_PROXY_TYPE
    {
        NONE_PROXY = 0,

        UDP_PROXY = 1,

        TCP_PROXY = 2,
    }

    public class CameraCapturerConfiguration
    {
        public CAMERA_DIRECTION cameraDirection;

        public string deviceId;

        public VideoFormat format;

        public bool followEncodeDimensionRatio;

        public CameraCapturerConfiguration()
        {
            this.followEncodeDimensionRatio = true;
        }

        public CameraCapturerConfiguration(CAMERA_DIRECTION cameraDirection, string deviceId, VideoFormat format, bool followEncodeDimensionRatio)
        {
            this.cameraDirection = cameraDirection;
            this.deviceId = deviceId;
            this.format = format;
            this.followEncodeDimensionRatio = followEncodeDimensionRatio;
        }
    }

    public class ScreenCaptureConfiguration
    {
        public bool isCaptureWindow;

        public uint displayId;

        public Rectangle screenRect;

        public view_t windowId;

        public ScreenCaptureParameters @params;

        public Rectangle regionRect;

        public ScreenCaptureConfiguration()
        {
            this.isCaptureWindow = false;
            this.displayId = 0;
            this.windowId = 0;
        }

        public ScreenCaptureConfiguration(bool isCaptureWindow, uint displayId, Rectangle screenRect, view_t windowId, ScreenCaptureParameters @params, Rectangle regionRect)
        {
            this.isCaptureWindow = isCaptureWindow;
            this.displayId = displayId;
            this.screenRect = screenRect;
            this.windowId = windowId;
            this.@params = @params;
            this.regionRect = regionRect;
        }
    }

    public class SIZE
    {
        public int width;

        public int height;

        public SIZE()
        {
            this.width = 0;
            this.height = 0;
        }

        public SIZE(int ww, int hh)
        {
            this.width = ww;
            this.height = hh;
        }

    }

    public class ThumbImageBuffer
    {
        public byte[] buffer;

        public uint length;

        public uint width;

        public uint height;

        public ThumbImageBuffer()
        {
            this.buffer = new byte[0];
            this.length = 0;
            this.width = 0;
            this.height = 0;
        }

        public ThumbImageBuffer(byte[] buffer, uint length, uint width, uint height)
        {
            this.buffer = buffer;
            this.length = length;
            this.width = width;
            this.height = height;
        }
    }

    public enum ScreenCaptureSourceType
    {
        ScreenCaptureSourceType_Unknown = -1,

        ScreenCaptureSourceType_Window = 0,

        ScreenCaptureSourceType_Screen = 1,

        ScreenCaptureSourceType_Custom = 2,
    }

    public class ScreenCaptureSourceInfo
    {
        public ScreenCaptureSourceType type;

        public view_t sourceId;

        public string sourceName;

        public ThumbImageBuffer thumbImage;

        public ThumbImageBuffer iconImage;

        public string processPath;

        public string sourceTitle;

        public bool primaryMonitor;

        public bool isOccluded;

        public Rectangle position;

        public bool minimizeWindow;

        public view_t sourceDisplayId;

        public ScreenCaptureSourceInfo()
        {
            this.type = ScreenCaptureSourceType.ScreenCaptureSourceType_Unknown;
            this.sourceId = 0;
            this.sourceName = "";
            this.processPath = "";
            this.sourceTitle = "";
            this.primaryMonitor = false;
            this.isOccluded = false;
            this.minimizeWindow = false;
            this.sourceDisplayId = -2;
        }

        public ScreenCaptureSourceInfo(ScreenCaptureSourceType type, view_t sourceId, string sourceName, ThumbImageBuffer thumbImage, ThumbImageBuffer iconImage, string processPath, string sourceTitle, bool primaryMonitor, bool isOccluded, Rectangle position, bool minimizeWindow, view_t sourceDisplayId)
        {
            this.type = type;
            this.sourceId = sourceId;
            this.sourceName = sourceName;
            this.thumbImage = thumbImage;
            this.iconImage = iconImage;
            this.processPath = processPath;
            this.sourceTitle = sourceTitle;
            this.primaryMonitor = primaryMonitor;
            this.isOccluded = isOccluded;
            this.position = position;
            this.minimizeWindow = minimizeWindow;
            this.sourceDisplayId = sourceDisplayId;
        }
    }

    public class AdvancedAudioOptions : IOptionalJsonParse
    {
        public Optional<int> audioProcessingChannels = new Optional<int>();

        public AdvancedAudioOptions()
        {
        }

        public AdvancedAudioOptions(Optional<int> audioProcessingChannels)
        {
            this.audioProcessingChannels = audioProcessingChannels;
        }

        public virtual void ToJson(JsonWriter writer)
        {
            writer.WriteObjectStart();

            if (this.audioProcessingChannels.HasValue())
            {
                writer.WritePropertyName("audioProcessingChannels");
                writer.Write(this.audioProcessingChannels.GetValue());
            }

            writer.WriteObjectEnd();
        }
    }

    public class ImageTrackOptions
    {
        public string imageUrl;

        public int fps;

        public VIDEO_MIRROR_MODE_TYPE mirrorMode;

        public ImageTrackOptions()
        {
            this.imageUrl = "";
            this.fps = 1;
            this.mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_DISABLED;
        }

        public ImageTrackOptions(string imageUrl, int fps, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            this.imageUrl = imageUrl;
            this.fps = fps;
            this.mirrorMode = mirrorMode;
        }
    }

    public class ChannelMediaOptions : IOptionalJsonParse
    {
        public Optional<bool> publishCameraTrack = new Optional<bool>();

        public Optional<bool> publishSecondaryCameraTrack = new Optional<bool>();

        public Optional<bool> publishThirdCameraTrack = new Optional<bool>();

        public Optional<bool> publishFourthCameraTrack = new Optional<bool>();

        public Optional<bool> publishMicrophoneTrack = new Optional<bool>();

        public Optional<bool> publishScreenCaptureVideo = new Optional<bool>();

        public Optional<bool> publishScreenCaptureAudio = new Optional<bool>();

        public Optional<bool> publishScreenTrack = new Optional<bool>();

        public Optional<bool> publishSecondaryScreenTrack = new Optional<bool>();

        public Optional<bool> publishThirdScreenTrack = new Optional<bool>();

        public Optional<bool> publishFourthScreenTrack = new Optional<bool>();

        public Optional<bool> publishCustomAudioTrack = new Optional<bool>();

        public Optional<int> publishCustomAudioTrackId = new Optional<int>();

        public Optional<bool> publishCustomVideoTrack = new Optional<bool>();

        public Optional<bool> publishEncodedVideoTrack = new Optional<bool>();

        public Optional<bool> publishMediaPlayerAudioTrack = new Optional<bool>();

        public Optional<bool> publishMediaPlayerVideoTrack = new Optional<bool>();

        public Optional<bool> publishTranscodedVideoTrack = new Optional<bool>();

        public Optional<bool> publishMixedAudioTrack = new Optional<bool>();

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

        public Optional<uint> customVideoTrackId = new Optional<uint>();

        public Optional<bool> isAudioFilterable = new Optional<bool>();

        public ChannelMediaOptions()
        {
        }

        public ChannelMediaOptions(Optional<bool> publishCameraTrack, Optional<bool> publishSecondaryCameraTrack, Optional<bool> publishThirdCameraTrack, Optional<bool> publishFourthCameraTrack, Optional<bool> publishMicrophoneTrack, Optional<bool> publishScreenCaptureVideo, Optional<bool> publishScreenCaptureAudio, Optional<bool> publishScreenTrack, Optional<bool> publishSecondaryScreenTrack, Optional<bool> publishThirdScreenTrack, Optional<bool> publishFourthScreenTrack, Optional<bool> publishCustomAudioTrack, Optional<int> publishCustomAudioTrackId, Optional<bool> publishCustomVideoTrack, Optional<bool> publishEncodedVideoTrack, Optional<bool> publishMediaPlayerAudioTrack, Optional<bool> publishMediaPlayerVideoTrack, Optional<bool> publishTranscodedVideoTrack, Optional<bool> publishMixedAudioTrack, Optional<bool> autoSubscribeAudio, Optional<bool> autoSubscribeVideo, Optional<bool> enableAudioRecordingOrPlayout, Optional<int> publishMediaPlayerId, Optional<CLIENT_ROLE_TYPE> clientRoleType, Optional<AUDIENCE_LATENCY_LEVEL_TYPE> audienceLatencyLevel, Optional<VIDEO_STREAM_TYPE> defaultVideoStreamType, Optional<CHANNEL_PROFILE_TYPE> channelProfile, Optional<int> audioDelayMs, Optional<int> mediaPlayerAudioDelayMs, Optional<string> token, Optional<bool> enableBuiltInMediaEncryption, Optional<bool> publishRhythmPlayerTrack, Optional<bool> isInteractiveAudience, Optional<uint> customVideoTrackId, Optional<bool> isAudioFilterable)
        {
            this.publishCameraTrack = publishCameraTrack;
            this.publishSecondaryCameraTrack = publishSecondaryCameraTrack;
            this.publishThirdCameraTrack = publishThirdCameraTrack;
            this.publishFourthCameraTrack = publishFourthCameraTrack;
            this.publishMicrophoneTrack = publishMicrophoneTrack;
            this.publishScreenCaptureVideo = publishScreenCaptureVideo;
            this.publishScreenCaptureAudio = publishScreenCaptureAudio;
            this.publishScreenTrack = publishScreenTrack;
            this.publishSecondaryScreenTrack = publishSecondaryScreenTrack;
            this.publishThirdScreenTrack = publishThirdScreenTrack;
            this.publishFourthScreenTrack = publishFourthScreenTrack;
            this.publishCustomAudioTrack = publishCustomAudioTrack;
            this.publishCustomAudioTrackId = publishCustomAudioTrackId;
            this.publishCustomVideoTrack = publishCustomVideoTrack;
            this.publishEncodedVideoTrack = publishEncodedVideoTrack;
            this.publishMediaPlayerAudioTrack = publishMediaPlayerAudioTrack;
            this.publishMediaPlayerVideoTrack = publishMediaPlayerVideoTrack;
            this.publishTranscodedVideoTrack = publishTranscodedVideoTrack;
            this.publishMixedAudioTrack = publishMixedAudioTrack;
            this.autoSubscribeAudio = autoSubscribeAudio;
            this.autoSubscribeVideo = autoSubscribeVideo;
            this.enableAudioRecordingOrPlayout = enableAudioRecordingOrPlayout;
            this.publishMediaPlayerId = publishMediaPlayerId;
            this.clientRoleType = clientRoleType;
            this.audienceLatencyLevel = audienceLatencyLevel;
            this.defaultVideoStreamType = defaultVideoStreamType;
            this.channelProfile = channelProfile;
            this.audioDelayMs = audioDelayMs;
            this.mediaPlayerAudioDelayMs = mediaPlayerAudioDelayMs;
            this.token = token;
            this.enableBuiltInMediaEncryption = enableBuiltInMediaEncryption;
            this.publishRhythmPlayerTrack = publishRhythmPlayerTrack;
            this.isInteractiveAudience = isInteractiveAudience;
            this.customVideoTrackId = customVideoTrackId;
            this.isAudioFilterable = isAudioFilterable;
        }

        public virtual void ToJson(JsonWriter writer)
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

            if (this.publishThirdCameraTrack.HasValue())
            {
                writer.WritePropertyName("publishThirdCameraTrack");
                writer.Write(this.publishThirdCameraTrack.GetValue());
            }

            if (this.publishFourthCameraTrack.HasValue())
            {
                writer.WritePropertyName("publishFourthCameraTrack");
                writer.Write(this.publishFourthCameraTrack.GetValue());
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

            if (this.publishThirdScreenTrack.HasValue())
            {
                writer.WritePropertyName("publishThirdScreenTrack");
                writer.Write(this.publishThirdScreenTrack.GetValue());
            }

            if (this.publishFourthScreenTrack.HasValue())
            {
                writer.WritePropertyName("publishFourthScreenTrack");
                writer.Write(this.publishFourthScreenTrack.GetValue());
            }

            if (this.publishCustomAudioTrack.HasValue())
            {
                writer.WritePropertyName("publishCustomAudioTrack");
                writer.Write(this.publishCustomAudioTrack.GetValue());
            }

            if (this.publishCustomAudioTrackId.HasValue())
            {
                writer.WritePropertyName("publishCustomAudioTrackId");
                writer.Write(this.publishCustomAudioTrackId.GetValue());
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

            if (this.publishTranscodedVideoTrack.HasValue())
            {
                writer.WritePropertyName("publishTranscodedVideoTrack");
                writer.Write(this.publishTranscodedVideoTrack.GetValue());
            }

            if (this.publishMixedAudioTrack.HasValue())
            {
                writer.WritePropertyName("publishMixedAudioTrack");
                writer.Write(this.publishMixedAudioTrack.GetValue());
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
                AgoraJson.WriteEnum(writer, this.clientRoleType.GetValue());
            }

            if (this.audienceLatencyLevel.HasValue())
            {
                writer.WritePropertyName("audienceLatencyLevel");
                AgoraJson.WriteEnum(writer, this.audienceLatencyLevel.GetValue());
            }

            if (this.defaultVideoStreamType.HasValue())
            {
                writer.WritePropertyName("defaultVideoStreamType");
                AgoraJson.WriteEnum(writer, this.defaultVideoStreamType.GetValue());
            }

            if (this.channelProfile.HasValue())
            {
                writer.WritePropertyName("channelProfile");
                AgoraJson.WriteEnum(writer, this.channelProfile.GetValue());
            }

            if (this.audioDelayMs.HasValue())
            {
                writer.WritePropertyName("audioDelayMs");
                writer.Write(this.audioDelayMs.GetValue());
            }

            if (this.mediaPlayerAudioDelayMs.HasValue())
            {
                writer.WritePropertyName("mediaPlayerAudioDelayMs");
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
    }

    public enum PROXY_TYPE
    {
        NONE_PROXY_TYPE = 0,

        UDP_PROXY_TYPE = 1,

        TCP_PROXY_TYPE = 2,

        LOCAL_PROXY_TYPE = 3,

        TCP_PROXY_AUTO_FALLBACK_TYPE = 4,

        HTTP_PROXY_TYPE = 5,

        HTTPS_PROXY_TYPE = 6,
    }

    public enum FeatureType
    {
        VIDEO_VIRTUAL_BACKGROUND = 1,

        VIDEO_BEAUTY_EFFECT = 2,
    }

    public class LeaveChannelOptions
    {
        public bool stopAudioMixing;

        public bool stopAllEffect;

        public bool stopMicrophoneRecording;

        public LeaveChannelOptions()
        {
            this.stopAudioMixing = true;
            this.stopAllEffect = true;
            this.stopMicrophoneRecording = true;
        }

        public LeaveChannelOptions(bool stopAudioMixing, bool stopAllEffect, bool stopMicrophoneRecording)
        {
            this.stopAudioMixing = stopAudioMixing;
            this.stopAllEffect = stopAllEffect;
            this.stopMicrophoneRecording = stopMicrophoneRecording;
        }
    }

    public class RtcEngineContext : IOptionalJsonParse
    {
        public string appId;

        public ulong context;

        public CHANNEL_PROFILE_TYPE channelProfile;

        public string license;

        public AUDIO_SCENARIO_TYPE audioScenario;

        public AREA_CODE areaCode;

        public LogConfig logConfig;

        public Optional<THREAD_PRIORITY_TYPE> threadPriority = new Optional<THREAD_PRIORITY_TYPE>();

        public bool useExternalEglContext;

        public bool domainLimit;

        public bool autoRegisterAgoraExtensions;

        public RtcEngineContext()
        {
            this.appId = "";
            this.context = 0;
            this.channelProfile = CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING;
            this.license = "";
            this.audioScenario = AUDIO_SCENARIO_TYPE.AUDIO_SCENARIO_DEFAULT;
            this.areaCode = AREA_CODE.AREA_CODE_GLOB;
            this.logConfig = new LogConfig();
            this.useExternalEglContext = false;
            this.domainLimit = false;
            this.autoRegisterAgoraExtensions = true;
        }

        public RtcEngineContext(string appId, ulong context, CHANNEL_PROFILE_TYPE channelProfile, string license, AUDIO_SCENARIO_TYPE audioScenario, AREA_CODE areaCode, LogConfig logConfig, Optional<THREAD_PRIORITY_TYPE> threadPriority, bool useExternalEglContext, bool domainLimit, bool autoRegisterAgoraExtensions)
        {
            this.appId = appId;
            this.context = context;
            this.channelProfile = channelProfile;
            this.license = license;
            this.audioScenario = audioScenario;
            this.areaCode = areaCode;
            this.logConfig = logConfig;
            this.threadPriority = threadPriority;
            this.useExternalEglContext = useExternalEglContext;
            this.domainLimit = domainLimit;
            this.autoRegisterAgoraExtensions = autoRegisterAgoraExtensions;
        }

        public virtual void ToJson(JsonWriter writer)
        {
            writer.WriteObjectStart();

            writer.WritePropertyName("appId");
            writer.Write(this.appId);

            writer.WritePropertyName("context");
            writer.Write(this.context);

            writer.WritePropertyName("channelProfile");
            AgoraJson.WriteEnum(writer, this.channelProfile);

            writer.WritePropertyName("license");
            writer.Write(this.license);

            writer.WritePropertyName("audioScenario");
            AgoraJson.WriteEnum(writer, this.audioScenario);

            writer.WritePropertyName("areaCode");
            AgoraJson.WriteEnum(writer, this.areaCode);

            writer.WritePropertyName("logConfig");
            JsonMapper.WriteValue(this.logConfig, writer, false, 0);

            if (this.threadPriority.HasValue())
            {
                writer.WritePropertyName("threadPriority");
                AgoraJson.WriteEnum(writer, this.threadPriority.GetValue());
            }

            writer.WritePropertyName("useExternalEglContext");
            writer.Write(this.useExternalEglContext);

            writer.WritePropertyName("domainLimit");
            writer.Write(this.domainLimit);

            writer.WritePropertyName("autoRegisterAgoraExtensions");
            writer.Write(this.autoRegisterAgoraExtensions);

            writer.WriteObjectEnd();
        }
    }

    public enum METADATA_TYPE
    {
        UNKNOWN_METADATA = -1,

        VIDEO_METADATA = 0,
    }

    public enum MAX_METADATA_SIZE_TYPE
    {
        INVALID_METADATA_SIZE_IN_BYTE = -1,

        DEFAULT_METADATA_SIZE_IN_BYTE = 512,

        MAX_METADATA_SIZE_IN_BYTE = 1024,
    }

    public class Metadata
    {
        public uint uid;

        public uint size;

        public IntPtr buffer;

        public long timeStampMs;

        public Metadata()
        {
            this.uid = 0;
            this.size = 0;
            this.buffer = IntPtr.Zero;
            this.timeStampMs = 0;
        }

        public Metadata(uint uid, uint size, IntPtr buffer, long timeStampMs)
        {
            this.uid = uid;
            this.size = size;
            this.buffer = buffer;
            this.timeStampMs = timeStampMs;
        }
    }

    public enum DIRECT_CDN_STREAMING_REASON
    {
        DIRECT_CDN_STREAMING_REASON_OK = 0,

        DIRECT_CDN_STREAMING_REASON_FAILED = 1,

        DIRECT_CDN_STREAMING_REASON_AUDIO_PUBLICATION = 2,

        DIRECT_CDN_STREAMING_REASON_VIDEO_PUBLICATION = 3,

        DIRECT_CDN_STREAMING_REASON_NET_CONNECT = 4,

        DIRECT_CDN_STREAMING_REASON_BAD_NAME = 5,
    }

    public enum DIRECT_CDN_STREAMING_STATE
    {
        DIRECT_CDN_STREAMING_STATE_IDLE = 0,

        DIRECT_CDN_STREAMING_STATE_RUNNING = 1,

        DIRECT_CDN_STREAMING_STATE_STOPPED = 2,

        DIRECT_CDN_STREAMING_STATE_FAILED = 3,

        DIRECT_CDN_STREAMING_STATE_RECOVERING = 4,
    }

    public class DirectCdnStreamingStats
    {
        public int videoWidth;

        public int videoHeight;

        public int fps;

        public int videoBitrate;

        public int audioBitrate;

        public DirectCdnStreamingStats(int videoWidth, int videoHeight, int fps, int videoBitrate, int audioBitrate)
        {
            this.videoWidth = videoWidth;
            this.videoHeight = videoHeight;
            this.fps = fps;
            this.videoBitrate = videoBitrate;
            this.audioBitrate = audioBitrate;
        }
        public DirectCdnStreamingStats()
        {
        }

    }

    public class DirectCdnStreamingMediaOptions : IOptionalJsonParse
    {
        public Optional<bool> publishCameraTrack = new Optional<bool>();

        public Optional<bool> publishMicrophoneTrack = new Optional<bool>();

        public Optional<bool> publishCustomAudioTrack = new Optional<bool>();

        public Optional<bool> publishCustomVideoTrack = new Optional<bool>();

        public Optional<bool> publishMediaPlayerAudioTrack = new Optional<bool>();

        public Optional<int> publishMediaPlayerId = new Optional<int>();

        public Optional<uint> customVideoTrackId = new Optional<uint>();

        public DirectCdnStreamingMediaOptions()
        {
        }

        public DirectCdnStreamingMediaOptions(Optional<bool> publishCameraTrack, Optional<bool> publishMicrophoneTrack, Optional<bool> publishCustomAudioTrack, Optional<bool> publishCustomVideoTrack, Optional<bool> publishMediaPlayerAudioTrack, Optional<int> publishMediaPlayerId, Optional<uint> customVideoTrackId)
        {
            this.publishCameraTrack = publishCameraTrack;
            this.publishMicrophoneTrack = publishMicrophoneTrack;
            this.publishCustomAudioTrack = publishCustomAudioTrack;
            this.publishCustomVideoTrack = publishCustomVideoTrack;
            this.publishMediaPlayerAudioTrack = publishMediaPlayerAudioTrack;
            this.publishMediaPlayerId = publishMediaPlayerId;
            this.customVideoTrackId = customVideoTrackId;
        }

        public virtual void ToJson(JsonWriter writer)
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
        public MEDIA_SOURCE_TYPE mediaSourceType;

        public uint remoteUid;

        public string channelId;

        public uint localUid;

        public ExtensionInfo()
        {
            this.mediaSourceType = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE;
            this.remoteUid = 0;
            this.channelId = "";
            this.localUid = 0;
        }

        public ExtensionInfo(MEDIA_SOURCE_TYPE mediaSourceType, uint remoteUid, string channelId, uint localUid)
        {
            this.mediaSourceType = mediaSourceType;
            this.remoteUid = remoteUid;
            this.channelId = channelId;
            this.localUid = localUid;
        }
    }

    public enum QUALITY_REPORT_FORMAT_TYPE
    {
        QUALITY_REPORT_JSON = 0,

        QUALITY_REPORT_HTML = 1,
    }

    public enum MEDIA_DEVICE_STATE_TYPE
    {
        MEDIA_DEVICE_STATE_IDLE = 0,

        MEDIA_DEVICE_STATE_ACTIVE = 1,

        MEDIA_DEVICE_STATE_DISABLED = 2,

        MEDIA_DEVICE_STATE_NOT_PRESENT = 4,

        MEDIA_DEVICE_STATE_UNPLUGGED = 8,
    }

    public enum VIDEO_PROFILE_TYPE
    {
        VIDEO_PROFILE_LANDSCAPE_120P = 0,

        VIDEO_PROFILE_LANDSCAPE_120P_3 = 2,

        VIDEO_PROFILE_LANDSCAPE_180P = 10,

        VIDEO_PROFILE_LANDSCAPE_180P_3 = 12,

        VIDEO_PROFILE_LANDSCAPE_180P_4 = 13,

        VIDEO_PROFILE_LANDSCAPE_240P = 20,

        VIDEO_PROFILE_LANDSCAPE_240P_3 = 22,

        VIDEO_PROFILE_LANDSCAPE_240P_4 = 23,

        VIDEO_PROFILE_LANDSCAPE_360P = 30,

        VIDEO_PROFILE_LANDSCAPE_360P_3 = 32,

        VIDEO_PROFILE_LANDSCAPE_360P_4 = 33,

        VIDEO_PROFILE_LANDSCAPE_360P_6 = 35,

        VIDEO_PROFILE_LANDSCAPE_360P_7 = 36,

        VIDEO_PROFILE_LANDSCAPE_360P_8 = 37,

        VIDEO_PROFILE_LANDSCAPE_360P_9 = 38,

        VIDEO_PROFILE_LANDSCAPE_360P_10 = 39,

        VIDEO_PROFILE_LANDSCAPE_360P_11 = 100,

        VIDEO_PROFILE_LANDSCAPE_480P = 40,

        VIDEO_PROFILE_LANDSCAPE_480P_3 = 42,

        VIDEO_PROFILE_LANDSCAPE_480P_4 = 43,

        VIDEO_PROFILE_LANDSCAPE_480P_6 = 45,

        VIDEO_PROFILE_LANDSCAPE_480P_8 = 47,

        VIDEO_PROFILE_LANDSCAPE_480P_9 = 48,

        VIDEO_PROFILE_LANDSCAPE_480P_10 = 49,

        VIDEO_PROFILE_LANDSCAPE_720P = 50,

        VIDEO_PROFILE_LANDSCAPE_720P_3 = 52,

        VIDEO_PROFILE_LANDSCAPE_720P_5 = 54,

        VIDEO_PROFILE_LANDSCAPE_720P_6 = 55,

        VIDEO_PROFILE_LANDSCAPE_1080P = 60,

        VIDEO_PROFILE_LANDSCAPE_1080P_3 = 62,

        VIDEO_PROFILE_LANDSCAPE_1080P_5 = 64,

        VIDEO_PROFILE_LANDSCAPE_1440P = 66,

        VIDEO_PROFILE_LANDSCAPE_1440P_2 = 67,

        VIDEO_PROFILE_LANDSCAPE_4K = 70,

        VIDEO_PROFILE_LANDSCAPE_4K_3 = 72,

        VIDEO_PROFILE_PORTRAIT_120P = 1000,

        VIDEO_PROFILE_PORTRAIT_120P_3 = 1002,

        VIDEO_PROFILE_PORTRAIT_180P = 1010,

        VIDEO_PROFILE_PORTRAIT_180P_3 = 1012,

        VIDEO_PROFILE_PORTRAIT_180P_4 = 1013,

        VIDEO_PROFILE_PORTRAIT_240P = 1020,

        VIDEO_PROFILE_PORTRAIT_240P_3 = 1022,

        VIDEO_PROFILE_PORTRAIT_240P_4 = 1023,

        VIDEO_PROFILE_PORTRAIT_360P = 1030,

        VIDEO_PROFILE_PORTRAIT_360P_3 = 1032,

        VIDEO_PROFILE_PORTRAIT_360P_4 = 1033,

        VIDEO_PROFILE_PORTRAIT_360P_6 = 1035,

        VIDEO_PROFILE_PORTRAIT_360P_7 = 1036,

        VIDEO_PROFILE_PORTRAIT_360P_8 = 1037,

        VIDEO_PROFILE_PORTRAIT_360P_9 = 1038,

        VIDEO_PROFILE_PORTRAIT_360P_10 = 1039,

        VIDEO_PROFILE_PORTRAIT_360P_11 = 1100,

        VIDEO_PROFILE_PORTRAIT_480P = 1040,

        VIDEO_PROFILE_PORTRAIT_480P_3 = 1042,

        VIDEO_PROFILE_PORTRAIT_480P_4 = 1043,

        VIDEO_PROFILE_PORTRAIT_480P_6 = 1045,

        VIDEO_PROFILE_PORTRAIT_480P_8 = 1047,

        VIDEO_PROFILE_PORTRAIT_480P_9 = 1048,

        VIDEO_PROFILE_PORTRAIT_480P_10 = 1049,

        VIDEO_PROFILE_PORTRAIT_720P = 1050,

        VIDEO_PROFILE_PORTRAIT_720P_3 = 1052,

        VIDEO_PROFILE_PORTRAIT_720P_5 = 1054,

        VIDEO_PROFILE_PORTRAIT_720P_6 = 1055,

        VIDEO_PROFILE_PORTRAIT_1080P = 1060,

        VIDEO_PROFILE_PORTRAIT_1080P_3 = 1062,

        VIDEO_PROFILE_PORTRAIT_1080P_5 = 1064,

        VIDEO_PROFILE_PORTRAIT_1440P = 1066,

        VIDEO_PROFILE_PORTRAIT_1440P_2 = 1067,

        VIDEO_PROFILE_PORTRAIT_4K = 1070,

        VIDEO_PROFILE_PORTRAIT_4K_3 = 1072,

        VIDEO_PROFILE_DEFAULT = VIDEO_PROFILE_LANDSCAPE_360P,
    }


    #endregion terra IAgoraRtcEngine.h
}