using System;
using view_t = System.Int64;
using Agora.Rtc.LitJson;

namespace Agora.Rtc
{
#region terra IAgoraRtcEngine.h

    /* enum_mediadevicetype */
    public enum MEDIA_DEVICE_TYPE
    {
        /* enum_mediadevicetype_UNKNOWN_AUDIO_DEVICE */
        UNKNOWN_AUDIO_DEVICE = -1,

        /* enum_mediadevicetype_AUDIO_PLAYOUT_DEVICE */
        AUDIO_PLAYOUT_DEVICE = 0,

        /* enum_mediadevicetype_AUDIO_RECORDING_DEVICE */
        AUDIO_RECORDING_DEVICE = 1,

        /* enum_mediadevicetype_VIDEO_RENDER_DEVICE */
        VIDEO_RENDER_DEVICE = 2,

        /* enum_mediadevicetype_VIDEO_CAPTURE_DEVICE */
        VIDEO_CAPTURE_DEVICE = 3,

        /* enum_mediadevicetype_AUDIO_APPLICATION_PLAYOUT_DEVICE */
        AUDIO_APPLICATION_PLAYOUT_DEVICE = 4,

        /* enum_mediadevicetype_AUDIO_VIRTUAL_PLAYOUT_DEVICE */
        AUDIO_VIRTUAL_PLAYOUT_DEVICE = 5,

        /* enum_mediadevicetype_AUDIO_VIRTUAL_RECORDING_DEVICE */
        AUDIO_VIRTUAL_RECORDING_DEVICE = 6,
    }

    /* enum_audiomixingstatetype */
    public enum AUDIO_MIXING_STATE_TYPE
    {
        /* enum_audiomixingstatetype_AUDIO_MIXING_STATE_PLAYING */
        AUDIO_MIXING_STATE_PLAYING = 710,

        /* enum_audiomixingstatetype_AUDIO_MIXING_STATE_PAUSED */
        AUDIO_MIXING_STATE_PAUSED = 711,

        /* enum_audiomixingstatetype_AUDIO_MIXING_STATE_STOPPED */
        AUDIO_MIXING_STATE_STOPPED = 713,

        /* enum_audiomixingstatetype_AUDIO_MIXING_STATE_FAILED */
        AUDIO_MIXING_STATE_FAILED = 714,
    }

    /* enum_audiomixingreasontype */
    public enum AUDIO_MIXING_REASON_TYPE
    {
        /* enum_audiomixingreasontype_AUDIO_MIXING_REASON_CAN_NOT_OPEN */
        AUDIO_MIXING_REASON_CAN_NOT_OPEN = 701,

        /* enum_audiomixingreasontype_AUDIO_MIXING_REASON_TOO_FREQUENT_CALL */
        AUDIO_MIXING_REASON_TOO_FREQUENT_CALL = 702,

        /* enum_audiomixingreasontype_AUDIO_MIXING_REASON_INTERRUPTED_EOF */
        AUDIO_MIXING_REASON_INTERRUPTED_EOF = 703,

        /* enum_audiomixingreasontype_AUDIO_MIXING_REASON_ONE_LOOP_COMPLETED */
        AUDIO_MIXING_REASON_ONE_LOOP_COMPLETED = 721,

        /* enum_audiomixingreasontype_AUDIO_MIXING_REASON_ALL_LOOPS_COMPLETED */
        AUDIO_MIXING_REASON_ALL_LOOPS_COMPLETED = 723,

        /* enum_audiomixingreasontype_AUDIO_MIXING_REASON_STOPPED_BY_USER */
        AUDIO_MIXING_REASON_STOPPED_BY_USER = 724,

        /* enum_audiomixingreasontype_AUDIO_MIXING_REASON_OK */
        AUDIO_MIXING_REASON_OK = 0,
    }

    /* enum_injectstreamstatus */
    public enum INJECT_STREAM_STATUS
    {
        /* enum_injectstreamstatus_INJECT_STREAM_STATUS_START_SUCCESS */
        INJECT_STREAM_STATUS_START_SUCCESS = 0,

        /* enum_injectstreamstatus_INJECT_STREAM_STATUS_START_ALREADY_EXISTS */
        INJECT_STREAM_STATUS_START_ALREADY_EXISTS = 1,

        /* enum_injectstreamstatus_INJECT_STREAM_STATUS_START_UNAUTHORIZED */
        INJECT_STREAM_STATUS_START_UNAUTHORIZED = 2,

        /* enum_injectstreamstatus_INJECT_STREAM_STATUS_START_TIMEDOUT */
        INJECT_STREAM_STATUS_START_TIMEDOUT = 3,

        /* enum_injectstreamstatus_INJECT_STREAM_STATUS_START_FAILED */
        INJECT_STREAM_STATUS_START_FAILED = 4,

        /* enum_injectstreamstatus_INJECT_STREAM_STATUS_STOP_SUCCESS */
        INJECT_STREAM_STATUS_STOP_SUCCESS = 5,

        /* enum_injectstreamstatus_INJECT_STREAM_STATUS_STOP_NOT_FOUND */
        INJECT_STREAM_STATUS_STOP_NOT_FOUND = 6,

        /* enum_injectstreamstatus_INJECT_STREAM_STATUS_STOP_UNAUTHORIZED */
        INJECT_STREAM_STATUS_STOP_UNAUTHORIZED = 7,

        /* enum_injectstreamstatus_INJECT_STREAM_STATUS_STOP_TIMEDOUT */
        INJECT_STREAM_STATUS_STOP_TIMEDOUT = 8,

        /* enum_injectstreamstatus_INJECT_STREAM_STATUS_STOP_FAILED */
        INJECT_STREAM_STATUS_STOP_FAILED = 9,

        /* enum_injectstreamstatus_INJECT_STREAM_STATUS_BROKEN */
        INJECT_STREAM_STATUS_BROKEN = 10,
    }

    /* enum_audioequalizationbandfrequency */
    public enum AUDIO_EQUALIZATION_BAND_FREQUENCY
    {
        /* enum_audioequalizationbandfrequency_AUDIO_EQUALIZATION_BAND_31 */
        AUDIO_EQUALIZATION_BAND_31 = 0,

        /* enum_audioequalizationbandfrequency_AUDIO_EQUALIZATION_BAND_62 */
        AUDIO_EQUALIZATION_BAND_62 = 1,

        /* enum_audioequalizationbandfrequency_AUDIO_EQUALIZATION_BAND_125 */
        AUDIO_EQUALIZATION_BAND_125 = 2,

        /* enum_audioequalizationbandfrequency_AUDIO_EQUALIZATION_BAND_250 */
        AUDIO_EQUALIZATION_BAND_250 = 3,

        /* enum_audioequalizationbandfrequency_AUDIO_EQUALIZATION_BAND_500 */
        AUDIO_EQUALIZATION_BAND_500 = 4,

        /* enum_audioequalizationbandfrequency_AUDIO_EQUALIZATION_BAND_1K */
        AUDIO_EQUALIZATION_BAND_1K = 5,

        /* enum_audioequalizationbandfrequency_AUDIO_EQUALIZATION_BAND_2K */
        AUDIO_EQUALIZATION_BAND_2K = 6,

        /* enum_audioequalizationbandfrequency_AUDIO_EQUALIZATION_BAND_4K */
        AUDIO_EQUALIZATION_BAND_4K = 7,

        /* enum_audioequalizationbandfrequency_AUDIO_EQUALIZATION_BAND_8K */
        AUDIO_EQUALIZATION_BAND_8K = 8,

        /* enum_audioequalizationbandfrequency_AUDIO_EQUALIZATION_BAND_16K */
        AUDIO_EQUALIZATION_BAND_16K = 9,
    }

    /* enum_audioreverbtype */
    public enum AUDIO_REVERB_TYPE
    {
        /* enum_audioreverbtype_AUDIO_REVERB_DRY_LEVEL */
        AUDIO_REVERB_DRY_LEVEL = 0,

        /* enum_audioreverbtype_AUDIO_REVERB_WET_LEVEL */
        AUDIO_REVERB_WET_LEVEL = 1,

        /* enum_audioreverbtype_AUDIO_REVERB_ROOM_SIZE */
        AUDIO_REVERB_ROOM_SIZE = 2,

        /* enum_audioreverbtype_AUDIO_REVERB_WET_DELAY */
        AUDIO_REVERB_WET_DELAY = 3,

        /* enum_audioreverbtype_AUDIO_REVERB_STRENGTH */
        AUDIO_REVERB_STRENGTH = 4,
    }

    /* enum_streamfallbackoptions */
    public enum STREAM_FALLBACK_OPTIONS
    {
        /* enum_streamfallbackoptions_STREAM_FALLBACK_OPTION_DISABLED */
        STREAM_FALLBACK_OPTION_DISABLED = 0,

        /* enum_streamfallbackoptions_STREAM_FALLBACK_OPTION_VIDEO_STREAM_LOW */
        STREAM_FALLBACK_OPTION_VIDEO_STREAM_LOW = 1,

        /* enum_streamfallbackoptions_STREAM_FALLBACK_OPTION_AUDIO_ONLY */
        STREAM_FALLBACK_OPTION_AUDIO_ONLY = 2,
    }

    /* enum_prioritytype */
    public enum PRIORITY_TYPE
    {
        /* enum_prioritytype_PRIORITY_HIGH */
        PRIORITY_HIGH = 50,

        /* enum_prioritytype_PRIORITY_NORMAL */
        PRIORITY_NORMAL = 100,
    }

    /* class_localvideostats */
    public class LocalVideoStats
    {
        /* class_localvideostats_uid */
        public uint uid;

        /* class_localvideostats_sentBitrate */
        public int sentBitrate;

        /* class_localvideostats_sentFrameRate */
        public int sentFrameRate;

        /* class_localvideostats_captureFrameRate */
        public int captureFrameRate;

        /* class_localvideostats_captureFrameWidth */
        public int captureFrameWidth;

        /* class_localvideostats_captureFrameHeight */
        public int captureFrameHeight;

        /* class_localvideostats_regulatedCaptureFrameRate */
        public int regulatedCaptureFrameRate;

        /* class_localvideostats_regulatedCaptureFrameWidth */
        public int regulatedCaptureFrameWidth;

        /* class_localvideostats_regulatedCaptureFrameHeight */
        public int regulatedCaptureFrameHeight;

        /* class_localvideostats_encoderOutputFrameRate */
        public int encoderOutputFrameRate;

        /* class_localvideostats_encodedFrameWidth */
        public int encodedFrameWidth;

        /* class_localvideostats_encodedFrameHeight */
        public int encodedFrameHeight;

        /* class_localvideostats_rendererOutputFrameRate */
        public int rendererOutputFrameRate;

        /* class_localvideostats_targetBitrate */
        public int targetBitrate;

        /* class_localvideostats_targetFrameRate */
        public int targetFrameRate;

        /* class_localvideostats_qualityAdaptIndication */
        public QUALITY_ADAPT_INDICATION qualityAdaptIndication;

        /* class_localvideostats_encodedBitrate */
        public int encodedBitrate;

        /* class_localvideostats_encodedFrameCount */
        public int encodedFrameCount;

        /* class_localvideostats_codecType */
        public VIDEO_CODEC_TYPE codecType;

        /* class_localvideostats_txPacketLossRate */
        public ushort txPacketLossRate;

        /* class_localvideostats_captureBrightnessLevel */
        public CAPTURE_BRIGHTNESS_LEVEL_TYPE captureBrightnessLevel;

        /* class_localvideostats_dualStreamEnabled */
        public bool dualStreamEnabled;

        /* class_localvideostats_hwEncoderAccelerating */
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

    /* class_remoteaudiostats */
    public class RemoteAudioStats
    {
        /* class_remoteaudiostats_uid */
        public uint uid;

        /* class_remoteaudiostats_quality */
        public int quality;

        /* class_remoteaudiostats_networkTransportDelay */
        public int networkTransportDelay;

        /* class_remoteaudiostats_jitterBufferDelay */
        public int jitterBufferDelay;

        /* class_remoteaudiostats_audioLossRate */
        public int audioLossRate;

        /* class_remoteaudiostats_numChannels */
        public int numChannels;

        /* class_remoteaudiostats_receivedSampleRate */
        public int receivedSampleRate;

        /* class_remoteaudiostats_receivedBitrate */
        public int receivedBitrate;

        /* class_remoteaudiostats_totalFrozenTime */
        public int totalFrozenTime;

        /* class_remoteaudiostats_frozenRate */
        public int frozenRate;

        /* class_remoteaudiostats_mosValue */
        public int mosValue;

        /* class_remoteaudiostats_frozenRateByCustomPlcCount */
        public uint frozenRateByCustomPlcCount;

        /* class_remoteaudiostats_plcCount */
        public uint plcCount;

        /* class_remoteaudiostats_totalActiveTime */
        public int totalActiveTime;

        /* class_remoteaudiostats_publishDuration */
        public int publishDuration;

        /* class_remoteaudiostats_qoeQuality */
        public int qoeQuality;

        /* class_remoteaudiostats_qualityChangedReason */
        public int qualityChangedReason;

        /* class_remoteaudiostats_rxAudioBytes */
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

    /* class_remotevideostats */
    public class RemoteVideoStats
    {
        /* class_remotevideostats_uid */
        public uint uid;

        /* class_remotevideostats_delay */
        public int delay;

        /* class_remotevideostats_e2eDelay */
        public int e2eDelay;

        /* class_remotevideostats_width */
        public int width;

        /* class_remotevideostats_height */
        public int height;

        /* class_remotevideostats_receivedBitrate */
        public int receivedBitrate;

        /* class_remotevideostats_decoderOutputFrameRate */
        public int decoderOutputFrameRate;

        /* class_remotevideostats_rendererOutputFrameRate */
        public int rendererOutputFrameRate;

        /* class_remotevideostats_frameLossRate */
        public int frameLossRate;

        /* class_remotevideostats_packetLossRate */
        public int packetLossRate;

        /* class_remotevideostats_rxStreamType */
        public VIDEO_STREAM_TYPE rxStreamType;

        /* class_remotevideostats_totalFrozenTime */
        public int totalFrozenTime;

        /* class_remotevideostats_frozenRate */
        public int frozenRate;

        /* class_remotevideostats_avSyncTimeMs */
        public int avSyncTimeMs;

        /* class_remotevideostats_totalActiveTime */
        public int totalActiveTime;

        /* class_remotevideostats_publishDuration */
        public int publishDuration;

        /* class_remotevideostats_mosValue */
        public int mosValue;

        /* class_remotevideostats_rxVideoBytes */
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

    /* class_videocompositinglayout */
    public class VideoCompositingLayout
    {
        /* class_videocompositinglayout_canvasWidth */
        public int canvasWidth;

        /* class_videocompositinglayout_canvasHeight */
        public int canvasHeight;

        /* class_videocompositinglayout_backgroundColor */
        public string backgroundColor;

        public Region[] regions;

        /* class_videocompositinglayout_regionCount */
        public int regionCount;

        /* class_videocompositinglayout_appData */
        public string appData;

        /* class_videocompositinglayout_appDataLength */
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

    /* class_region */
    public class Region
    {
        /* class_region_uid */
        public uint uid;

        /* class_region_x */
        public double x;

        /* class_region_y */
        public double y;

        /* class_region_width */
        public double width;

        /* class_region_height */
        public double height;

        /* class_region_zOrder */
        public int zOrder;

        /* class_region_alpha */
        public double alpha;

        /* class_region_renderMode */
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

    /* class_injectstreamconfig */
    public class InjectStreamConfig
    {
        /* class_injectstreamconfig_width */
        public int width;

        /* class_injectstreamconfig_height */
        public int height;

        /* class_injectstreamconfig_videoGop */
        public int videoGop;

        /* class_injectstreamconfig_videoFramerate */
        public int videoFramerate;

        /* class_injectstreamconfig_videoBitrate */
        public int videoBitrate;

        /* class_injectstreamconfig_audioSampleRate */
        public AUDIO_SAMPLE_RATE_TYPE audioSampleRate;

        /* class_injectstreamconfig_audioBitrate */
        public int audioBitrate;

        /* class_injectstreamconfig_audioChannels */
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

    /* enum_rtmpstreamlifecycletype */
    public enum RTMP_STREAM_LIFE_CYCLE_TYPE
    {
        /* enum_rtmpstreamlifecycletype_RTMP_STREAM_LIFE_CYCLE_BIND2CHANNEL */
        RTMP_STREAM_LIFE_CYCLE_BIND2CHANNEL = 1,

        /* enum_rtmpstreamlifecycletype_RTMP_STREAM_LIFE_CYCLE_BIND2OWNER */
        RTMP_STREAM_LIFE_CYCLE_BIND2OWNER = 2,
    }

    /* class_publisherconfiguration */
    public class PublisherConfiguration
    {
        /* class_publisherconfiguration_width */
        public int width;

        /* class_publisherconfiguration_height */
        public int height;

        /* class_publisherconfiguration_framerate */
        public int framerate;

        /* class_publisherconfiguration_bitrate */
        public int bitrate;

        /* class_publisherconfiguration_defaultLayout */
        public int defaultLayout;

        /* class_publisherconfiguration_lifecycle */
        public int lifecycle;

        /* class_publisherconfiguration_owner */
        public bool owner;

        /* class_publisherconfiguration_injectStreamWidth */
        public int injectStreamWidth;

        /* class_publisherconfiguration_injectStreamHeight */
        public int injectStreamHeight;

        /* class_publisherconfiguration_injectStreamUrl */
        public string injectStreamUrl;

        /* class_publisherconfiguration_publishUrl */
        public string publishUrl;

        /* class_publisherconfiguration_rawStreamUrl */
        public string rawStreamUrl;

        /* class_publisherconfiguration_extraInfo */
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

    /* enum_cameradirection */
    public enum CAMERA_DIRECTION
    {
        /* enum_cameradirection_CAMERA_REAR */
        CAMERA_REAR = 0,

        /* enum_cameradirection_CAMERA_FRONT */
        CAMERA_FRONT = 1,
    }

    /* enum_cloudproxytype */
    public enum CLOUD_PROXY_TYPE
    {
        /* enum_cloudproxytype_NONE_PROXY */
        NONE_PROXY = 0,

        /* enum_cloudproxytype_UDP_PROXY */
        UDP_PROXY = 1,

        /* enum_cloudproxytype_TCP_PROXY */
        TCP_PROXY = 2,
    }

    /* class_cameracapturerconfiguration */
    public class CameraCapturerConfiguration
    {
        /* class_cameracapturerconfiguration_cameraDirection */
        public CAMERA_DIRECTION cameraDirection;

        /* class_cameracapturerconfiguration_deviceId */
        public string deviceId;

        /* class_cameracapturerconfiguration_format */
        public VideoFormat format;

        /* class_cameracapturerconfiguration_followEncodeDimensionRatio */
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

    /* class_screencaptureconfiguration */
    public class ScreenCaptureConfiguration
    {
        /* class_screencaptureconfiguration_isCaptureWindow */
        public bool isCaptureWindow;

        /* class_screencaptureconfiguration_displayId */
        public uint displayId;

        /* class_screencaptureconfiguration_screenRect */
        public Rectangle screenRect;

        /* class_screencaptureconfiguration_windowId */
        public view_t windowId;

        public ScreenCaptureParameters @params;

        /* class_screencaptureconfiguration_regionRect */
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

    /* class_size */
    public class SIZE
    {
        /* class_size_width */
        public int width;

        /* class_size_height */
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

    /* class_thumbimagebuffer */
    public class ThumbImageBuffer
    {
        public byte[] buffer;

        /* class_thumbimagebuffer_length */
        public uint length;

        /* class_thumbimagebuffer_width */
        public uint width;

        /* class_thumbimagebuffer_height */
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

    /* enum_screencapturesourcetype */
    public enum ScreenCaptureSourceType
    {
        /* enum_screencapturesourcetype_ScreenCaptureSourceType_Unknown */
        ScreenCaptureSourceType_Unknown = -1,

        /* enum_screencapturesourcetype_ScreenCaptureSourceType_Window */
        ScreenCaptureSourceType_Window = 0,

        /* enum_screencapturesourcetype_ScreenCaptureSourceType_Screen */
        ScreenCaptureSourceType_Screen = 1,

        /* enum_screencapturesourcetype_ScreenCaptureSourceType_Custom */
        ScreenCaptureSourceType_Custom = 2,
    }

    /* class_screencapturesourceinfo */
    public class ScreenCaptureSourceInfo
    {
        /* class_screencapturesourceinfo_type */
        public ScreenCaptureSourceType type;

        /* class_screencapturesourceinfo_sourceId */
        public view_t sourceId;

        /* class_screencapturesourceinfo_sourceName */
        public string sourceName;

        /* class_screencapturesourceinfo_thumbImage */
        public ThumbImageBuffer thumbImage;

        /* class_screencapturesourceinfo_iconImage */
        public ThumbImageBuffer iconImage;

        /* class_screencapturesourceinfo_processPath */
        public string processPath;

        /* class_screencapturesourceinfo_sourceTitle */
        public string sourceTitle;

        /* class_screencapturesourceinfo_primaryMonitor */
        public bool primaryMonitor;

        /* class_screencapturesourceinfo_isOccluded */
        public bool isOccluded;

        /* class_screencapturesourceinfo_position */
        public Rectangle position;

        /* class_screencapturesourceinfo_minimizeWindow */
        public bool minimizeWindow;

        /* class_screencapturesourceinfo_sourceDisplayId */
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

    /* class_advancedaudiooptions */
    public class AdvancedAudioOptions : OptionalJsonParse
    {
        /* class_advancedaudiooptions_audioProcessingChannels */
        public Optional<int> audioProcessingChannels = new Optional<int>();

        public AdvancedAudioOptions()
        {
        }

        public AdvancedAudioOptions(Optional<int> audioProcessingChannels)
        {
            this.audioProcessingChannels = audioProcessingChannels;
        }

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
    }

    /* class_imagetrackoptions */
    public class ImageTrackOptions
    {
        /* class_imagetrackoptions_imageUrl */
        public string imageUrl;

        /* class_imagetrackoptions_fps */
        public int fps;

        /* class_imagetrackoptions_mirrorMode */
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

    /* class_channelmediaoptions */
    public class ChannelMediaOptions : OptionalJsonParse
    {
        /* class_channelmediaoptions_publishCameraTrack */
        public Optional<bool> publishCameraTrack = new Optional<bool>();

        /* class_channelmediaoptions_publishSecondaryCameraTrack */
        public Optional<bool> publishSecondaryCameraTrack = new Optional<bool>();

        /* class_channelmediaoptions_publishThirdCameraTrack */
        public Optional<bool> publishThirdCameraTrack = new Optional<bool>();

        /* class_channelmediaoptions_publishFourthCameraTrack */
        public Optional<bool> publishFourthCameraTrack = new Optional<bool>();

        /* class_channelmediaoptions_publishMicrophoneTrack */
        public Optional<bool> publishMicrophoneTrack = new Optional<bool>();

        /* class_channelmediaoptions_publishScreenCaptureVideo */
        public Optional<bool> publishScreenCaptureVideo = new Optional<bool>();

        /* class_channelmediaoptions_publishScreenCaptureAudio */
        public Optional<bool> publishScreenCaptureAudio = new Optional<bool>();

        /* class_channelmediaoptions_publishScreenTrack */
        public Optional<bool> publishScreenTrack = new Optional<bool>();

        /* class_channelmediaoptions_publishSecondaryScreenTrack */
        public Optional<bool> publishSecondaryScreenTrack = new Optional<bool>();

        /* class_channelmediaoptions_publishThirdScreenTrack */
        public Optional<bool> publishThirdScreenTrack = new Optional<bool>();

        /* class_channelmediaoptions_publishFourthScreenTrack */
        public Optional<bool> publishFourthScreenTrack = new Optional<bool>();

        /* class_channelmediaoptions_publishCustomAudioTrack */
        public Optional<bool> publishCustomAudioTrack = new Optional<bool>();

        /* class_channelmediaoptions_publishCustomAudioTrackId */
        public Optional<int> publishCustomAudioTrackId = new Optional<int>();

        /* class_channelmediaoptions_publishCustomVideoTrack */
        public Optional<bool> publishCustomVideoTrack = new Optional<bool>();

        /* class_channelmediaoptions_publishEncodedVideoTrack */
        public Optional<bool> publishEncodedVideoTrack = new Optional<bool>();

        /* class_channelmediaoptions_publishMediaPlayerAudioTrack */
        public Optional<bool> publishMediaPlayerAudioTrack = new Optional<bool>();

        /* class_channelmediaoptions_publishMediaPlayerVideoTrack */
        public Optional<bool> publishMediaPlayerVideoTrack = new Optional<bool>();

        /* class_channelmediaoptions_publishTranscodedVideoTrack */
        public Optional<bool> publishTranscodedVideoTrack = new Optional<bool>();

        /* class_channelmediaoptions_autoSubscribeAudio */
        public Optional<bool> autoSubscribeAudio = new Optional<bool>();

        /* class_channelmediaoptions_autoSubscribeVideo */
        public Optional<bool> autoSubscribeVideo = new Optional<bool>();

        /* class_channelmediaoptions_enableAudioRecordingOrPlayout */
        public Optional<bool> enableAudioRecordingOrPlayout = new Optional<bool>();

        /* class_channelmediaoptions_publishMediaPlayerId */
        public Optional<int> publishMediaPlayerId = new Optional<int>();

        /* class_channelmediaoptions_clientRoleType */
        public Optional<CLIENT_ROLE_TYPE> clientRoleType = new Optional<CLIENT_ROLE_TYPE>();

        /* class_channelmediaoptions_audienceLatencyLevel */
        public Optional<AUDIENCE_LATENCY_LEVEL_TYPE> audienceLatencyLevel = new Optional<AUDIENCE_LATENCY_LEVEL_TYPE>();

        /* class_channelmediaoptions_defaultVideoStreamType */
        public Optional<VIDEO_STREAM_TYPE> defaultVideoStreamType = new Optional<VIDEO_STREAM_TYPE>();

        /* class_channelmediaoptions_channelProfile */
        public Optional<CHANNEL_PROFILE_TYPE> channelProfile = new Optional<CHANNEL_PROFILE_TYPE>();

        /* class_channelmediaoptions_audioDelayMs */
        public Optional<int> audioDelayMs = new Optional<int>();

        /* class_channelmediaoptions_mediaPlayerAudioDelayMs */
        public Optional<int> mediaPlayerAudioDelayMs = new Optional<int>();

        /* class_channelmediaoptions_token */
        public Optional<string> token = new Optional<string>();

        /* class_channelmediaoptions_enableBuiltInMediaEncryption */
        public Optional<bool> enableBuiltInMediaEncryption = new Optional<bool>();

        /* class_channelmediaoptions_publishRhythmPlayerTrack */
        public Optional<bool> publishRhythmPlayerTrack = new Optional<bool>();

        /* class_channelmediaoptions_isInteractiveAudience */
        public Optional<bool> isInteractiveAudience = new Optional<bool>();

        /* class_channelmediaoptions_customVideoTrackId */
        public Optional<uint> customVideoTrackId = new Optional<uint>();

        /* class_channelmediaoptions_isAudioFilterable */
        public Optional<bool> isAudioFilterable = new Optional<bool>();

        public ChannelMediaOptions()
        {
        }

        public ChannelMediaOptions(Optional<bool> publishCameraTrack, Optional<bool> publishSecondaryCameraTrack, Optional<bool> publishThirdCameraTrack, Optional<bool> publishFourthCameraTrack, Optional<bool> publishMicrophoneTrack, Optional<bool> publishScreenCaptureVideo, Optional<bool> publishScreenCaptureAudio, Optional<bool> publishScreenTrack, Optional<bool> publishSecondaryScreenTrack, Optional<bool> publishThirdScreenTrack, Optional<bool> publishFourthScreenTrack, Optional<bool> publishCustomAudioTrack, Optional<int> publishCustomAudioTrackId, Optional<bool> publishCustomVideoTrack, Optional<bool> publishEncodedVideoTrack, Optional<bool> publishMediaPlayerAudioTrack, Optional<bool> publishMediaPlayerVideoTrack, Optional<bool> publishTranscodedVideoTrack, Optional<bool> autoSubscribeAudio, Optional<bool> autoSubscribeVideo, Optional<bool> enableAudioRecordingOrPlayout, Optional<int> publishMediaPlayerId, Optional<CLIENT_ROLE_TYPE> clientRoleType, Optional<AUDIENCE_LATENCY_LEVEL_TYPE> audienceLatencyLevel, Optional<VIDEO_STREAM_TYPE> defaultVideoStreamType, Optional<CHANNEL_PROFILE_TYPE> channelProfile, Optional<int> audioDelayMs, Optional<int> mediaPlayerAudioDelayMs, Optional<string> token, Optional<bool> enableBuiltInMediaEncryption, Optional<bool> publishRhythmPlayerTrack, Optional<bool> isInteractiveAudience, Optional<uint> customVideoTrackId, Optional<bool> isAudioFilterable)
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
                this.WriteEnum(writer, this.clientRoleType.GetValue());
            }

            if (this.audienceLatencyLevel.HasValue())
            {
                writer.WritePropertyName("audienceLatencyLevel");
                this.WriteEnum(writer, this.audienceLatencyLevel.GetValue());
            }

            if (this.defaultVideoStreamType.HasValue())
            {
                writer.WritePropertyName("defaultVideoStreamType");
                this.WriteEnum(writer, this.defaultVideoStreamType.GetValue());
            }

            if (this.channelProfile.HasValue())
            {
                writer.WritePropertyName("channelProfile");
                this.WriteEnum(writer, this.channelProfile.GetValue());
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

    /* enum_proxytype */
    public enum PROXY_TYPE
    {
        /* enum_proxytype_NONE_PROXY_TYPE */
        NONE_PROXY_TYPE = 0,

        /* enum_proxytype_UDP_PROXY_TYPE */
        UDP_PROXY_TYPE = 1,

        /* enum_proxytype_TCP_PROXY_TYPE */
        TCP_PROXY_TYPE = 2,

        /* enum_proxytype_LOCAL_PROXY_TYPE */
        LOCAL_PROXY_TYPE = 3,

        /* enum_proxytype_TCP_PROXY_AUTO_FALLBACK_TYPE */
        TCP_PROXY_AUTO_FALLBACK_TYPE = 4,

        /* enum_proxytype_HTTP_PROXY_TYPE */
        HTTP_PROXY_TYPE = 5,

        /* enum_proxytype_HTTPS_PROXY_TYPE */
        HTTPS_PROXY_TYPE = 6,
    }

    /* class_leavechanneloptions */
    public class LeaveChannelOptions
    {
        /* class_leavechanneloptions_stopAudioMixing */
        public bool stopAudioMixing;

        /* class_leavechanneloptions_stopAllEffect */
        public bool stopAllEffect;

        /* class_leavechanneloptions_stopMicrophoneRecording */
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

    /* class_rtcenginecontext */
    public class RtcEngineContext : OptionalJsonParse
    {
        /* class_rtcenginecontext_appId */
        public string appId;

        /* class_rtcenginecontext_context */
        public ulong context;

        /* class_rtcenginecontext_channelProfile */
        public CHANNEL_PROFILE_TYPE channelProfile;

        /* class_rtcenginecontext_license */
        public string license;

        /* class_rtcenginecontext_audioScenario */
        public AUDIO_SCENARIO_TYPE audioScenario;

        /* class_rtcenginecontext_areaCode */
        public AREA_CODE areaCode;

        /* class_rtcenginecontext_logConfig */
        public LogConfig logConfig;

        /* class_rtcenginecontext_threadPriority */
        public Optional<THREAD_PRIORITY_TYPE> threadPriority = new Optional<THREAD_PRIORITY_TYPE>();

        /* class_rtcenginecontext_useExternalEglContext */
        public bool useExternalEglContext;

        /* class_rtcenginecontext_domainLimit */
        public bool domainLimit;

        /* class_rtcenginecontext_autoRegisterAgoraExtensions */
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

        public override void ToJson(JsonWriter writer)
        {
            writer.WriteObjectStart();

            writer.WritePropertyName("appId");
            writer.Write(this.appId);

            writer.WritePropertyName("context");
            writer.Write(this.context);

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

            writer.WritePropertyName("domainLimit");
            writer.Write(this.domainLimit);

            writer.WritePropertyName("autoRegisterAgoraExtensions");
            writer.Write(this.autoRegisterAgoraExtensions);

            writer.WriteObjectEnd();
        }
    }

    /* enum_metadatatype */
    public enum METADATA_TYPE
    {
        /* enum_metadatatype_UNKNOWN_METADATA */
        UNKNOWN_METADATA = -1,

        /* enum_metadatatype_VIDEO_METADATA */
        VIDEO_METADATA = 0,
    }

    /* enum_maxmetadatasizetype */
    public enum MAX_METADATA_SIZE_TYPE
    {
        /* enum_maxmetadatasizetype_INVALID_METADATA_SIZE_IN_BYTE */
        INVALID_METADATA_SIZE_IN_BYTE = -1,

        /* enum_maxmetadatasizetype_DEFAULT_METADATA_SIZE_IN_BYTE */
        DEFAULT_METADATA_SIZE_IN_BYTE = 512,

        /* enum_maxmetadatasizetype_MAX_METADATA_SIZE_IN_BYTE */
        MAX_METADATA_SIZE_IN_BYTE = 1024,
    }

    /* class_metadata */
    public class Metadata
    {
        /* class_metadata_uid */
        public uint uid;

        /* class_metadata_size */
        public uint size;

        /* class_metadata_buffer */
        public IntPtr buffer;

        /* class_metadata_timeStampMs */
        public long timeStampMs;

        public Metadata(uint uid, uint size, IntPtr buffer, long timeStampMs)
        {
            this.uid = uid;
            this.size = size;
            this.buffer = buffer;
            this.timeStampMs = timeStampMs;
        }
        public Metadata()
        {
        }
    }

    /* enum_directcdnstreamingerror */
    public enum DIRECT_CDN_STREAMING_ERROR
    {
        /* enum_directcdnstreamingerror_DIRECT_CDN_STREAMING_ERROR_OK */
        DIRECT_CDN_STREAMING_ERROR_OK = 0,

        /* enum_directcdnstreamingerror_DIRECT_CDN_STREAMING_ERROR_FAILED */
        DIRECT_CDN_STREAMING_ERROR_FAILED = 1,

        /* enum_directcdnstreamingerror_DIRECT_CDN_STREAMING_ERROR_AUDIO_PUBLICATION */
        DIRECT_CDN_STREAMING_ERROR_AUDIO_PUBLICATION = 2,

        /* enum_directcdnstreamingerror_DIRECT_CDN_STREAMING_ERROR_VIDEO_PUBLICATION */
        DIRECT_CDN_STREAMING_ERROR_VIDEO_PUBLICATION = 3,

        /* enum_directcdnstreamingerror_DIRECT_CDN_STREAMING_ERROR_NET_CONNECT */
        DIRECT_CDN_STREAMING_ERROR_NET_CONNECT = 4,

        /* enum_directcdnstreamingerror_DIRECT_CDN_STREAMING_ERROR_BAD_NAME */
        DIRECT_CDN_STREAMING_ERROR_BAD_NAME = 5,
    }

    /* enum_directcdnstreamingstate */
    public enum DIRECT_CDN_STREAMING_STATE
    {
        /* enum_directcdnstreamingstate_DIRECT_CDN_STREAMING_STATE_IDLE */
        DIRECT_CDN_STREAMING_STATE_IDLE = 0,

        /* enum_directcdnstreamingstate_DIRECT_CDN_STREAMING_STATE_RUNNING */
        DIRECT_CDN_STREAMING_STATE_RUNNING = 1,

        /* enum_directcdnstreamingstate_DIRECT_CDN_STREAMING_STATE_STOPPED */
        DIRECT_CDN_STREAMING_STATE_STOPPED = 2,

        /* enum_directcdnstreamingstate_DIRECT_CDN_STREAMING_STATE_FAILED */
        DIRECT_CDN_STREAMING_STATE_FAILED = 3,

        /* enum_directcdnstreamingstate_DIRECT_CDN_STREAMING_STATE_RECOVERING */
        DIRECT_CDN_STREAMING_STATE_RECOVERING = 4,
    }

    /* class_directcdnstreamingstats */
    public class DirectCdnStreamingStats
    {
        /* class_directcdnstreamingstats_videoWidth */
        public int videoWidth;

        /* class_directcdnstreamingstats_videoHeight */
        public int videoHeight;

        /* class_directcdnstreamingstats_fps */
        public int fps;

        /* class_directcdnstreamingstats_videoBitrate */
        public int videoBitrate;

        /* class_directcdnstreamingstats_audioBitrate */
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

    /* class_directcdnstreamingmediaoptions */
    public class DirectCdnStreamingMediaOptions : OptionalJsonParse
    {
        /* class_directcdnstreamingmediaoptions_publishCameraTrack */
        public Optional<bool> publishCameraTrack = new Optional<bool>();

        /* class_directcdnstreamingmediaoptions_publishMicrophoneTrack */
        public Optional<bool> publishMicrophoneTrack = new Optional<bool>();

        /* class_directcdnstreamingmediaoptions_publishCustomAudioTrack */
        public Optional<bool> publishCustomAudioTrack = new Optional<bool>();

        /* class_directcdnstreamingmediaoptions_publishCustomVideoTrack */
        public Optional<bool> publishCustomVideoTrack = new Optional<bool>();

        /* class_directcdnstreamingmediaoptions_publishMediaPlayerAudioTrack */
        public Optional<bool> publishMediaPlayerAudioTrack = new Optional<bool>();

        /* class_directcdnstreamingmediaoptions_publishMediaPlayerId */
        public Optional<int> publishMediaPlayerId = new Optional<int>();

        /* class_directcdnstreamingmediaoptions_customVideoTrackId */
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

    /* class_extensioninfo */
    public class ExtensionInfo
    {
        /* class_extensioninfo_mediaSourceType */
        public MEDIA_SOURCE_TYPE mediaSourceType;

        /* class_extensioninfo_remoteUid */
        public uint remoteUid;

        /* class_extensioninfo_channelId */
        public string channelId;

        /* class_extensioninfo_localUid */
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

    /* enum_qualityreportformattype */
    public enum QUALITY_REPORT_FORMAT_TYPE
    {
        /* enum_qualityreportformattype_QUALITY_REPORT_JSON */
        QUALITY_REPORT_JSON = 0,

        /* enum_qualityreportformattype_QUALITY_REPORT_HTML */
        QUALITY_REPORT_HTML = 1,
    }

    /* enum_mediadevicestatetype */
    public enum MEDIA_DEVICE_STATE_TYPE
    {
        /* enum_mediadevicestatetype_MEDIA_DEVICE_STATE_IDLE */
        MEDIA_DEVICE_STATE_IDLE = 0,

        /* enum_mediadevicestatetype_MEDIA_DEVICE_STATE_ACTIVE */
        MEDIA_DEVICE_STATE_ACTIVE = 1,

        /* enum_mediadevicestatetype_MEDIA_DEVICE_STATE_DISABLED */
        MEDIA_DEVICE_STATE_DISABLED = 2,

        /* enum_mediadevicestatetype_MEDIA_DEVICE_STATE_NOT_PRESENT */
        MEDIA_DEVICE_STATE_NOT_PRESENT = 4,

        /* enum_mediadevicestatetype_MEDIA_DEVICE_STATE_UNPLUGGED */
        MEDIA_DEVICE_STATE_UNPLUGGED = 8,
    }

    /* enum_videoprofiletype */
    public enum VIDEO_PROFILE_TYPE
    {
        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_120P */
        VIDEO_PROFILE_LANDSCAPE_120P = 0,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_120P_3 */
        VIDEO_PROFILE_LANDSCAPE_120P_3 = 2,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_180P */
        VIDEO_PROFILE_LANDSCAPE_180P = 10,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_180P_3 */
        VIDEO_PROFILE_LANDSCAPE_180P_3 = 12,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_180P_4 */
        VIDEO_PROFILE_LANDSCAPE_180P_4 = 13,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_240P */
        VIDEO_PROFILE_LANDSCAPE_240P = 20,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_240P_3 */
        VIDEO_PROFILE_LANDSCAPE_240P_3 = 22,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_240P_4 */
        VIDEO_PROFILE_LANDSCAPE_240P_4 = 23,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_360P */
        VIDEO_PROFILE_LANDSCAPE_360P = 30,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_360P_3 */
        VIDEO_PROFILE_LANDSCAPE_360P_3 = 32,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_360P_4 */
        VIDEO_PROFILE_LANDSCAPE_360P_4 = 33,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_360P_6 */
        VIDEO_PROFILE_LANDSCAPE_360P_6 = 35,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_360P_7 */
        VIDEO_PROFILE_LANDSCAPE_360P_7 = 36,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_360P_8 */
        VIDEO_PROFILE_LANDSCAPE_360P_8 = 37,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_360P_9 */
        VIDEO_PROFILE_LANDSCAPE_360P_9 = 38,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_360P_10 */
        VIDEO_PROFILE_LANDSCAPE_360P_10 = 39,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_360P_11 */
        VIDEO_PROFILE_LANDSCAPE_360P_11 = 100,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_480P */
        VIDEO_PROFILE_LANDSCAPE_480P = 40,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_480P_3 */
        VIDEO_PROFILE_LANDSCAPE_480P_3 = 42,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_480P_4 */
        VIDEO_PROFILE_LANDSCAPE_480P_4 = 43,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_480P_6 */
        VIDEO_PROFILE_LANDSCAPE_480P_6 = 45,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_480P_8 */
        VIDEO_PROFILE_LANDSCAPE_480P_8 = 47,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_480P_9 */
        VIDEO_PROFILE_LANDSCAPE_480P_9 = 48,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_480P_10 */
        VIDEO_PROFILE_LANDSCAPE_480P_10 = 49,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_720P */
        VIDEO_PROFILE_LANDSCAPE_720P = 50,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_720P_3 */
        VIDEO_PROFILE_LANDSCAPE_720P_3 = 52,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_720P_5 */
        VIDEO_PROFILE_LANDSCAPE_720P_5 = 54,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_720P_6 */
        VIDEO_PROFILE_LANDSCAPE_720P_6 = 55,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_1080P */
        VIDEO_PROFILE_LANDSCAPE_1080P = 60,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_1080P_3 */
        VIDEO_PROFILE_LANDSCAPE_1080P_3 = 62,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_1080P_5 */
        VIDEO_PROFILE_LANDSCAPE_1080P_5 = 64,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_1440P */
        VIDEO_PROFILE_LANDSCAPE_1440P = 66,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_1440P_2 */
        VIDEO_PROFILE_LANDSCAPE_1440P_2 = 67,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_4K */
        VIDEO_PROFILE_LANDSCAPE_4K = 70,

        /* enum_videoprofiletype_VIDEO_PROFILE_LANDSCAPE_4K_3 */
        VIDEO_PROFILE_LANDSCAPE_4K_3 = 72,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_120P */
        VIDEO_PROFILE_PORTRAIT_120P = 1000,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_120P_3 */
        VIDEO_PROFILE_PORTRAIT_120P_3 = 1002,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_180P */
        VIDEO_PROFILE_PORTRAIT_180P = 1010,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_180P_3 */
        VIDEO_PROFILE_PORTRAIT_180P_3 = 1012,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_180P_4 */
        VIDEO_PROFILE_PORTRAIT_180P_4 = 1013,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_240P */
        VIDEO_PROFILE_PORTRAIT_240P = 1020,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_240P_3 */
        VIDEO_PROFILE_PORTRAIT_240P_3 = 1022,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_240P_4 */
        VIDEO_PROFILE_PORTRAIT_240P_4 = 1023,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_360P */
        VIDEO_PROFILE_PORTRAIT_360P = 1030,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_360P_3 */
        VIDEO_PROFILE_PORTRAIT_360P_3 = 1032,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_360P_4 */
        VIDEO_PROFILE_PORTRAIT_360P_4 = 1033,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_360P_6 */
        VIDEO_PROFILE_PORTRAIT_360P_6 = 1035,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_360P_7 */
        VIDEO_PROFILE_PORTRAIT_360P_7 = 1036,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_360P_8 */
        VIDEO_PROFILE_PORTRAIT_360P_8 = 1037,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_360P_9 */
        VIDEO_PROFILE_PORTRAIT_360P_9 = 1038,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_360P_10 */
        VIDEO_PROFILE_PORTRAIT_360P_10 = 1039,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_360P_11 */
        VIDEO_PROFILE_PORTRAIT_360P_11 = 1100,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_480P */
        VIDEO_PROFILE_PORTRAIT_480P = 1040,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_480P_3 */
        VIDEO_PROFILE_PORTRAIT_480P_3 = 1042,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_480P_4 */
        VIDEO_PROFILE_PORTRAIT_480P_4 = 1043,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_480P_6 */
        VIDEO_PROFILE_PORTRAIT_480P_6 = 1045,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_480P_8 */
        VIDEO_PROFILE_PORTRAIT_480P_8 = 1047,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_480P_9 */
        VIDEO_PROFILE_PORTRAIT_480P_9 = 1048,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_480P_10 */
        VIDEO_PROFILE_PORTRAIT_480P_10 = 1049,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_720P */
        VIDEO_PROFILE_PORTRAIT_720P = 1050,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_720P_3 */
        VIDEO_PROFILE_PORTRAIT_720P_3 = 1052,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_720P_5 */
        VIDEO_PROFILE_PORTRAIT_720P_5 = 1054,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_720P_6 */
        VIDEO_PROFILE_PORTRAIT_720P_6 = 1055,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_1080P */
        VIDEO_PROFILE_PORTRAIT_1080P = 1060,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_1080P_3 */
        VIDEO_PROFILE_PORTRAIT_1080P_3 = 1062,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_1080P_5 */
        VIDEO_PROFILE_PORTRAIT_1080P_5 = 1064,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_1440P */
        VIDEO_PROFILE_PORTRAIT_1440P = 1066,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_1440P_2 */
        VIDEO_PROFILE_PORTRAIT_1440P_2 = 1067,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_4K */
        VIDEO_PROFILE_PORTRAIT_4K = 1070,

        /* enum_videoprofiletype_VIDEO_PROFILE_PORTRAIT_4K_3 */
        VIDEO_PROFILE_PORTRAIT_4K_3 = 1072,

        /* enum_videoprofiletype_VIDEO_PROFILE_DEFAULT */
        VIDEO_PROFILE_DEFAULT = VIDEO_PROFILE_LANDSCAPE_360P,
    }

#endregion terra IAgoraRtcEngine.h
}