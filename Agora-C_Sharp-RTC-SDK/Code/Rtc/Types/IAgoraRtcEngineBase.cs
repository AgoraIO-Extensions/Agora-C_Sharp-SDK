using System;
using view_t = System.UInt64;
using video_track_id_t = System.UInt32;
using Agora.Rtc.LitJson;

namespace Agora.Rtc
{
    #region IAgoraRtcEngine.h

    ///
    /// <summary>
    /// Media device types.
    /// </summary>
    ///
    public enum MEDIA_DEVICE_TYPE
    {
        ///
        /// <summary>
        /// -1: Unknown device type.
        /// </summary>
        ///
        UNKNOWN_AUDIO_DEVICE = -1,

        ///
        /// <summary>
        /// 0: Audio playback device.
        /// </summary>
        ///
        AUDIO_PLAYOUT_DEVICE = 0,

        ///
        /// <summary>
        /// 1: Audio capturing device.
        /// </summary>
        ///
        AUDIO_RECORDING_DEVICE = 1,

        ///
        /// <summary>
        /// 2: Video rendering device.
        /// </summary>
        ///
        VIDEO_RENDER_DEVICE = 2,

        ///
        /// <summary>
        /// 3: Video capturing device.
        /// </summary>
        ///
        VIDEO_CAPTURE_DEVICE = 3,

        ///
        /// <summary>
        /// 4: Audio playback device for an app.
        /// </summary>
        ///
        AUDIO_APPLICATION_PLAYOUT_DEVICE = 4,
    };

    ///
    /// <summary>
    /// The playback state of the music file.
    /// </summary>
    ///
    public enum AUDIO_MIXING_STATE_TYPE
    {
        ///
        /// <summary>
        /// 710: The music file is playing.
        /// </summary>
        ///
        AUDIO_MIXING_STATE_PLAYING = 710,

        ///
        /// <summary>
        /// 711: The music file pauses playing.
        /// </summary>
        ///
        AUDIO_MIXING_STATE_PAUSED = 711,

        ///
        /// <summary>
        /// 713: The music file stops playing.The possible reasons include:AUDIO_MIXING_REASON_ALL_LOOPS_COMPLETED(723)AUDIO_MIXING_REASON_STOPPED_BY_USER(724)
        /// </summary>
        ///
        AUDIO_MIXING_STATE_STOPPED = 713,

        ///
        /// <summary>
        /// 714: An error occurs during the playback of the audio mixing file.The possible reasons include:AUDIO_MIXING_REASON_CAN_NOT_OPEN(701)AUDIO_MIXING_REASON_TOO_FREQUENT_CALL(702)AUDIO_MIXING_REASON_INTERRUPTED_EOF(703)
        /// </summary>
        ///
        AUDIO_MIXING_STATE_FAILED = 714,
    };

    ///
    /// <summary>
    /// The reason why the playback state of the music file changes. Reported in the OnAudioMixingStateChanged callback.
    /// </summary>
    ///
    public enum AUDIO_MIXING_REASON_TYPE
    {
        ///
        /// <summary>
        /// 701: The SDK cannot open the music file. For example, the local music file does not exist, the SDK does not support the file format, or the the SDK cannot access the music file URL.
        /// </summary>
        ///
        AUDIO_MIXING_REASON_CAN_NOT_OPEN = 701,

        ///
        /// <summary>
        /// 702: The SDK opens the music file too frequently. If you need to call startAudioMixing multiple times, ensure that the call interval is more than 500 ms.
        /// </summary>
        ///
        AUDIO_MIXING_REASON_TOO_FREQUENT_CALL = 702,

        ///
        /// <summary>
        /// 703: The music file playback is interrupted.
        /// </summary>
        ///
        AUDIO_MIXING_REASON_INTERRUPTED_EOF = 703,

        ///
        /// <summary>
        /// 721: The music file completes a loop playback.
        /// </summary>
        ///
        AUDIO_MIXING_REASON_ONE_LOOP_COMPLETED = 721,

        ///
        /// <summary>
        /// 723: The music file completes all loop playback.
        /// </summary>
        ///
        AUDIO_MIXING_REASON_ALL_LOOPS_COMPLETED = 723,

        ///
        /// <summary>
        /// 724: Successfully call StopAudioMixing to stop playing the music file.
        /// </summary>
        ///
        AUDIO_MIXING_REASON_STOPPED_BY_USER = 724,

        ///
        /// <summary>
        /// 0: The SDK opens music file successfully.
        /// </summary>
        ///
        AUDIO_MIXING_REASON_OK = 0,
    };

    ///
    /// @ignore
    ///
    public enum INJECT_STREAM_STATUS
    {
        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_START_SUCCESS = 0,

        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_START_ALREADY_EXISTS = 1,

        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_START_UNAUTHORIZED = 2,

        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_START_TIMEDOUT = 3,

        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_START_FAILED = 4,

        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_STOP_SUCCESS = 5,

        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_STOP_NOT_FOUND = 6,

        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_STOP_UNAUTHORIZED = 7,

        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_STOP_TIMEDOUT = 8,

        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_STOP_FAILED = 9,

        ///
        /// @ignore
        ///
        INJECT_STREAM_STATUS_BROKEN = 10,
    };

    ///
    /// <summary>
    /// The midrange frequency for audio equalization.
    /// </summary>
    ///
    public enum AUDIO_EQUALIZATION_BAND_FREQUENCY
    {
        ///
        /// <summary>
        /// 0: 31 Hz
        /// </summary>
        ///
        AUDIO_EQUALIZATION_BAND_31 = 0,

        ///
        /// <summary>
        /// 1: 62 Hz
        /// </summary>
        ///
        AUDIO_EQUALIZATION_BAND_62 = 1,

        ///
        /// <summary>
        /// 2: 125 Hz
        /// </summary>
        ///
        AUDIO_EQUALIZATION_BAND_125 = 2,

        ///
        /// <summary>
        /// 3: 250 Hz
        /// </summary>
        ///
        AUDIO_EQUALIZATION_BAND_250 = 3,

        ///
        /// <summary>
        /// 4: 500 Hz
        /// </summary>
        ///
        AUDIO_EQUALIZATION_BAND_500 = 4,

        ///
        /// <summary>
        /// 5: 1 kHz
        /// </summary>
        ///
        AUDIO_EQUALIZATION_BAND_1K = 5,

        ///
        /// <summary>
        /// 6: 2 kHz
        /// </summary>
        ///
        AUDIO_EQUALIZATION_BAND_2K = 6,

        ///
        /// <summary>
        /// 7: 4 kHz
        /// </summary>
        ///
        AUDIO_EQUALIZATION_BAND_4K = 7,

        ///
        /// <summary>
        /// 8: 8 kHz
        /// </summary>
        ///
        AUDIO_EQUALIZATION_BAND_8K = 8,

        ///
        /// <summary>
        /// 9: 16 kHz
        /// </summary>
        ///
        AUDIO_EQUALIZATION_BAND_16K = 9,
    };

    ///
    /// <summary>
    /// Audio reverberation types.
    /// </summary>
    ///
    public enum AUDIO_REVERB_TYPE
    {
        ///
        /// <summary>
        /// 0: The level of the dry signal (dB). The value is between -20 and 10.
        /// </summary>
        ///
        AUDIO_REVERB_DRY_LEVEL = 0,

        ///
        /// <summary>
        /// 1: The level of the early reflection signal (wet signal) (dB). The value is between -20 and 10.
        /// </summary>
        ///
        AUDIO_REVERB_WET_LEVEL = 1,

        ///
        /// <summary>
        /// 2: The room size of the reflection. The value is between 0 and 100.
        /// </summary>
        ///
        AUDIO_REVERB_ROOM_SIZE = 2,

        ///
        /// <summary>
        /// 3: The length of the initial delay of the wet signal (ms). The value is between 0 and 200.
        /// </summary>
        ///
        AUDIO_REVERB_WET_DELAY = 3,

        ///
        /// <summary>
        /// 4: The reverberation strength. The value is between 0 and 100.
        /// </summary>
        ///
        AUDIO_REVERB_STRENGTH = 4,
    };

    ///
    /// @ignore
    ///
    public enum STREAM_FALLBACK_OPTIONS
    {
        ///
        /// @ignore
        ///
        STREAM_FALLBACK_OPTION_DISABLED = 0,

        ///
        /// @ignore
        ///
        STREAM_FALLBACK_OPTION_VIDEO_STREAM_LOW = 1,

        ///
        /// @ignore
        ///
        STREAM_FALLBACK_OPTION_AUDIO_ONLY = 2,
    };

    ///
    /// @ignore
    ///
    public enum PRIORITY_TYPE
    {
        ///
        /// @ignore
        ///
        PRIORITY_HIGH = 50,

        ///
        /// @ignore
        ///
        PRIORITY_NORMAL = 100,
    };

    ///
    /// <summary>
    /// The statistics of the local video stream.
    /// </summary>
    ///
    public class LocalVideoStats
    {
        public LocalVideoStats()
        {
        }

        ///
        /// <summary>
        /// The user ID of the local user.
        /// </summary>
        ///
        public uint uid;

        ///
        /// <summary>
        /// The actual bitrate (Kbps) while sending the local video stream.This value does not include the bitrate for resending the video after packet loss.
        /// </summary>
        ///
        public int sentBitrate;

        ///
        /// <summary>
        /// The actual frame rate (fps) while sending the local video stream.This value does not include the frame rate for resending the video after packet loss.
        /// </summary>
        ///
        public int sentFrameRate;

        ///
        /// <summary>
        /// The frame rate (fps) for capturing the local video stream.
        /// </summary>
        ///
        public int captureFrameRate;

        ///
        /// <summary>
        /// The width (px) for capturing the local video stream.
        /// </summary>
        ///
        public int captureFrameWidth;

        ///
        /// <summary>
        /// The height (px) for capturing the local video stream.
        /// </summary>
        ///
        public int captureFrameHeight;

        ///
        /// <summary>
        /// The frame rate (fps) adjusted by the built-in video capture adapter (regulator) of the SDK for capturing the local video stream. The regulator adjusts the frame rate of the video captured by the camera according to the video encoding configuration.
        /// </summary>
        ///
        public int regulatedCaptureFrameRate;

        ///
        /// <summary>
        /// The width (px) adjusted by the built-in video capture adapter (regulator) of the SDK for capturing the local video stream. The regulator adjusts the height and width of the video captured by the camera according to the video encoding configuration.
        /// </summary>
        ///
        public int regulatedCaptureFrameWidth;

        ///
        /// <summary>
        /// The height (px) adjusted by the built-in video capture adapter (regulator) of the SDK for capturing the local video stream. The regulator adjusts the height and width of the video captured by the camera according to the video encoding configuration.
        /// </summary>
        ///
        public int regulatedCaptureFrameHeight;

        ///
        /// <summary>
        /// The output frame rate (fps) of the local video encoder.
        /// </summary>
        ///
        public int encoderOutputFrameRate;

        ///
        /// <summary>
        /// The width of the encoded video (px).
        /// </summary>
        ///
        public int encodedFrameWidth;

        ///
        /// <summary>
        /// The height of the encoded video (px).
        /// </summary>
        ///
        public int encodedFrameHeight;

        ///
        /// <summary>
        /// The output frame rate (fps) of the local video renderer.
        /// </summary>
        ///
        public int rendererOutputFrameRate;

        ///
        /// <summary>
        /// The target bitrate (Kbps) of the current encoder. This is an estimate made by the SDK based on the current network conditions.
        /// </summary>
        ///
        public int targetBitrate;

        ///
        /// <summary>
        /// The target frame rate (fps) of the current encoder.
        /// </summary>
        ///
        public int targetFrameRate;

        ///
        /// <summary>
        /// The quality adaptation of the local video stream in the reported interval (based on the target frame rate and target bitrate). See QUALITY_ADAPT_INDICATION .
        /// </summary>
        ///
        public QUALITY_ADAPT_INDICATION qualityAdaptIndication;

        ///
        /// <summary>
        /// The bitrate (Kbps) while encoding the local video stream.This value does not include the bitrate for resending the video after packet loss.
        /// </summary>
        ///
        public int encodedBitrate;

        ///
        /// <summary>
        /// The number of the sent video frames, represented by an aggregate value.
        /// </summary>
        ///
        public int encodedFrameCount;

        ///
        /// <summary>
        /// The codec type of the local video. See VIDEO_CODEC_TYPE .
        /// </summary>
        ///
        public VIDEO_CODEC_TYPE codecType;

        ///
        /// <summary>
        /// The video packet loss rate (%) from the local client to the Agora server before applying the anti-packet loss strategies.
        /// </summary>
        ///
        public ushort txPacketLossRate;

        ///
        /// <summary>
        /// The brightness level of the video image captured by the local camera. See CAPTURE_BRIGHTNESS_LEVEL_TYPE .
        /// </summary>
        ///
        public CAPTURE_BRIGHTNESS_LEVEL_TYPE captureBrightnessLevel;

        ///
        /// @ignore
        ///
        public bool dualStreamEnabled;

        ///
        /// <summary>
        /// The local video encoding acceleration type. 0: Software encoding is applied without acceleration.1: Hardware encoding is applied for acceleration.
        /// </summary>
        ///
        public int hwEncoderAccelerating;
    };

    ///
    /// <summary>
    /// Statistics of the remote video stream.
    /// </summary>
    ///
    public class RemoteVideoStats
    {
        ///
        /// <summary>
        /// The user ID of the remote user sending the video stream.
        /// </summary>
        ///
        public uint uid;

        [Obsolete]
        ///
        /// <summary>
        /// Deprecated:In scenarios where audio and video are synchronized, you can get the video delay data from networkTransportDelay and jitterBufferDelay in RemoteAudioStats .The video delay (ms).
        /// </summary>
        ///
        public int delay;

        ///
        /// <summary>
        /// The width (pixels) of the video.
        /// </summary>
        ///
        public int width;

        ///
        /// <summary>
        /// The height (pixels) of the video.
        /// </summary>
        ///
        public int height;

        ///
        /// <summary>
        /// The bitrate (Kbps) of the remote video received since the last count.
        /// </summary>
        ///
        public int receivedBitrate;

        ///
        /// <summary>
        /// The frame rate (fps) of decoding the remote video.
        /// </summary>
        ///
        public int decoderOutputFrameRate;

        ///
        /// <summary>
        /// The frame rate (fps) of rendering the remote video.
        /// </summary>
        ///
        public int rendererOutputFrameRate;

        ///
        /// <summary>
        /// The packet loss rate (%) of the remote video.
        /// </summary>
        ///
        public int frameLossRate;

        ///
        /// <summary>
        /// The packet loss rate (%) of the remote video after using the anti-packet-loss technology.
        /// </summary>
        ///
        public int packetLossRate;

        ///
        /// <summary>
        /// The type of the video stream. See VIDEO_STREAM_TYPE .
        /// </summary>
        ///
        public VIDEO_STREAM_TYPE rxStreamType;

        ///
        /// <summary>
        /// The total freeze time (ms) of the remote video stream after the remote user joins the channel. In a video session where the frame rate is set to no less than 5 fps, video freeze occurs when the time interval between two adjacent renderable video frames is more than 500 ms.
        /// </summary>
        ///
        public int totalFrozenTime;

        ///
        /// <summary>
        /// The total video freeze time as a percentage (%) of the total time the video is available. The video is considered available as long as that the remote user neither stops sending the video stream nor disables the video module after joining the channel.
        /// </summary>
        ///
        public int frozenRate;

        ///
        /// <summary>
        /// The amount of time (ms) that the audio is ahead of the video.If this value is negative, the audio is lagging behind the video.
        /// </summary>
        ///
        public int avSyncTimeMs;

        ///
        /// <summary>
        /// The total active time (ms) of the video.As long as the remote user or host neither stops sending the video stream nor disables the video module after joining the channel, the video is available.
        /// </summary>
        ///
        public int totalActiveTime;

        ///
        /// <summary>
        /// The total duration (ms) of the remote video stream.
        /// </summary>
        ///
        public int publishDuration;

        ///
        /// <summary>
        /// The state of super resolution:>0: Super resolution is enabled.=0: Super resolution is not enabled.
        /// </summary>
        ///
        public int superResolutionType;

        ///
        /// @ignore
        ///
        public int mosValue;
    };

    ///
    /// @ignore
    ///
    public class Region
    {
        ///
        /// @ignore
        ///
        public uint uid;

        ///
        /// @ignore
        ///
        public double x;

        ///
        /// @ignore
        ///
        public double y;

        ///
        /// @ignore
        ///
        public double width;

        ///
        /// @ignore
        ///
        public double height;

        ///
        /// @ignore
        ///
        public int zOrder;

        ///
        /// @ignore
        ///
        public double alpha;

        ///
        /// @ignore
        ///
        public RENDER_MODE_TYPE renderMode;

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

    ///
    /// @ignore
    ///
    public class VideoCompositingLayout
    {
        ///
        /// @ignore
        ///
        public int canvasWidth;

        ///
        /// @ignore
        ///
        public int canvasHeight;

        ///
        /// @ignore
        ///
        public string backgroundColor;

        ///
        /// @ignore
        ///
        public Region[] regions;

        ///
        /// @ignore
        ///
        public int regionCount;

        ///
        /// @ignore
        ///
        public string appData;

        ///
        /// @ignore
        ///
        public int appDataLength;

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

    ///
    /// @ignore
    ///
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

        ///
        /// @ignore
        ///
        public int width;

        ///
        /// @ignore
        ///
        public int height;

        ///
        /// @ignore
        ///
        public int videoGop;

        ///
        /// @ignore
        ///
        public int videoFramerate;

        ///
        /// @ignore
        ///
        public int videoBitrate;

        ///
        /// @ignore
        ///
        public AUDIO_SAMPLE_RATE_TYPE audioSampleRate;

        ///
        /// @ignore
        ///
        public int audioBitrate;

        ///
        /// @ignore
        ///
        public int audioChannels;
    };

    ///
    /// <summary>
    /// Lifecycle of the CDN live video stream.
    /// Deprecated
    /// </summary>
    ///
    public enum RTMP_STREAM_LIFE_CYCLE_TYPE
    {
        ///
        /// <summary>
        /// Bind to the channel lifecycle. If all hosts leave the channel, the CDN live streaming stops after 30 seconds.
        /// </summary>
        ///
        RTMP_STREAM_LIFE_CYCLE_BIND2CHANNEL = 1,

        ///
        /// <summary>
        /// Bind to the owner of the RTMP stream. If the owner leaves the channel, the CDN live streaming stops immediately.
        /// </summary>
        ///
        RTMP_STREAM_LIFE_CYCLE_BIND2OWNER = 2,
    };

    ///
    /// @ignore
    ///
    public class PublisherConfiguration
    {
        ///
        /// @ignore
        ///
        public int width;

        ///
        /// @ignore
        ///
        public int height;

        ///
        /// @ignore
        ///
        public int framerate;

        ///
        /// @ignore
        ///
        public int bitrate;

        ///
        /// @ignore
        ///
        public int defaultLayout;

        ///
        /// @ignore
        ///
        public int lifecycle;

        ///
        /// @ignore
        ///
        public bool owner;

        ///
        /// @ignore
        ///
        public int injectStreamWidth;

        ///
        /// @ignore
        ///
        public int injectStreamHeight;

        ///
        /// @ignore
        ///
        public string injectStreamUrl;

        ///
        /// @ignore
        ///
        public string publishUrl;

        ///
        /// @ignore
        ///
        public string rawStreamUrl;

        ///
        /// @ignore
        ///
        public string extraInfo;

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

    ///
    /// @ignore
    ///
    public class AudioTrackConfig
    {
        public AudioTrackConfig()
        {
            enableLocalPlayback = true;
        }

        ///
        /// @ignore
        ///
        public bool enableLocalPlayback;
    };

    ///
    /// <summary>
    /// The camera direction.
    /// </summary>
    ///
    public enum CAMERA_DIRECTION
    {
        ///
        /// <summary>
        /// The rear camera.
        /// </summary>
        ///
        CAMERA_REAR = 0,

        ///
        /// <summary>
        /// The front camera.
        /// </summary>
        ///
        CAMERA_FRONT = 1,
    };

    ///
    /// <summary>
    /// The cloud proxy type.
    /// </summary>
    ///
    public enum CLOUD_PROXY_TYPE
    {
        ///
        /// <summary>
        /// 0: The automatic mode. The SDK has this mode enabled by default. In this mode, the SDK attempts a direct connection to SD-RTN™ and automatically switches to TCP/TLS 443 if the attempt fails. 
        /// </summary>
        ///
        NONE_PROXY = 0,

        ///
        /// <summary>
        /// 1: The cloud proxy for the UDP protocol, that is, the Force UDP cloud proxy mode. In this mode, the SDK always transmits data over UDP.
        /// </summary>
        ///
        UDP_PROXY = 1,

        ///
        /// <summary>
        /// 2: The cloud proxy for the TCP (encryption) protocol, that is, the Force TCP cloud proxy mode. In this mode, the SDK always transmits data over TCP/TLS 443.
        /// </summary>
        ///
        TCP_PROXY = 2,
    };

    ///
    /// <summary>
    /// The camera capturer preference.
    /// </summary>
    ///
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

        ///
        /// <summary>
        /// This method applies to Windows only.The ID of the camera. 
        /// </summary>
        ///
        public string deviceId;

        ///
        /// <summary>
        /// The format of the video frame. See VideoFormat .
        /// </summary>
        ///
        public VideoFormat format;

        ///
        /// <summary>
        /// Whether to follow the video aspect ratio set in SetVideoEncoderConfiguration :true: (Default) Follow the set video aspect ratio. The SDK crops the captured video according to the set video aspect ratio and synchronously changes the local preview screen and the video frame in OnCaptureVideoFrame and OnPreEncodeVideoFrame .false: Do not follow the set video aspect ratio. The SDK does not change the aspect ratio of the captured video frame.
        /// </summary>
        ///
        public bool followEncodeDimensionRatio;

        ///
        /// <summary>
        /// This parameter applies to Android and iOS only.The camera direction. See CAMERA_DIRECTION .
        /// </summary>
        ///
        public CAMERA_DIRECTION cameraDirection;
    }

    ///
    /// <summary>
    /// The configuration of the captured screen.
    /// </summary>
    ///
    public class ScreenCaptureConfiguration
    {
        public ScreenCaptureConfiguration()
        {
            isCaptureWindow = false;
            displayId = 0;
        }

        ///
        /// <summary>
        /// Whether to capture the window on the screen:true: Capture the window.false: (Default) Capture the screen, not the window.
        /// </summary>
        ///
        public bool isCaptureWindow;

        ///
        /// <summary>
        /// (macOS only) The display ID of the screen.This parameter takes effect only when you want to capture the screen on macOS.
        /// </summary>
        ///
        public uint displayId;

        ///
        /// <summary>
        /// (Windows only) The relative position of the shared screen to the virtual screen.This parameter takes effect only when you want to capture the screen on Windows.
        /// </summary>
        ///
        public Rectangle screenRect;

        ///
        /// <summary>
        /// (For Windows and macOS only) Window ID.This parameter takes effect only when you want to capture the window.
        /// </summary>
        ///
        public uint windowId;

        ///
        /// <summary>
        /// (For Windows and macOS only) The screen capture configuration. See ScreenCaptureParameters .
        /// </summary>
        ///
        public ScreenCaptureParameters parameters;

        ///
        /// <summary>
        /// (For Windows and macOS only) The relative position of the shared region to the whole screen. See Rectangle .If you do not set this parameter, the SDK shares the whole screen. If the region you set exceeds the boundary of the screen, only the region within in the screen is shared. If you setwidth or height in Rectangle as 0, the whole screen is shared.
        /// </summary>
        ///
        public Rectangle regionRect;
    }

    ///
    /// @ignore
    ///
    public class SIZE
    {
        ///
        /// @ignore
        ///
        public int width;

        ///
        /// @ignore
        ///
        public int height;

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

    ///
    /// <summary>
    /// The image content of the thumbnail or icon. Set in ScreenCaptureSourceInfo .
    /// The default image is in the ARGB format. If you need to use another format, you need to convert the image on your own.
    /// </summary>
    ///
    public class ThumbImageBuffer
    {
        ///
        /// <summary>
        /// The buffer of the thumbnail or icon.
        /// </summary>
        ///
        public byte[] buffer;

        ///
        /// <summary>
        /// The buffer length of the thumbnail or icon, in bytes.
        /// </summary>
        ///
        public uint length;

        ///
        /// <summary>
        /// The actual width (px) of the thumbnail or icon.
        /// </summary>
        ///
        public uint width;

        ///
        /// <summary>
        /// The actual height (px) of the thumbnail or icon.
        /// </summary>
        ///
        public uint height;

        public ThumbImageBuffer()
        {
            buffer = new byte[0];
            length = 0;
            width = 0;
            height = 0;
        }
    };

    ///
    /// <summary>
    /// The type of the shared target. Set in ScreenCaptureSourceInfo .
    /// </summary>
    ///
    public enum ScreenCaptureSourceType
    {
        ///
        /// <summary>
        /// -1: Unknown type.
        /// </summary>
        ///
        ScreenCaptureSourceType_Unknown = -1,

        ///
        /// <summary>
        /// 0: The shared target is a window.
        /// </summary>
        ///
        ScreenCaptureSourceType_Window = 0,

        ///
        /// <summary>
        /// 1: The shared target is a screen of a particular monitor.
        /// </summary>
        ///
        ScreenCaptureSourceType_Screen = 1,

        ///
        /// <summary>
        /// 2: Reserved parameter
        /// </summary>
        ///
        ScreenCaptureSourceType_Custom = 2,
    };

    ///
    /// <summary>
    /// The information about the specified shareable window or screen. 
    /// </summary>
    ///
    public class ScreenCaptureSourceInfo
    {
        ///
        /// <summary>
        /// The type of the shared target. See ScreenCaptureSourceType .
        /// </summary>
        ///
        public ScreenCaptureSourceType type;

        ///
        /// <summary>
        /// The window ID for a window or the display ID for a screen.
        /// </summary>
        ///
        public view_t sourceId;

        ///
        /// <summary>
        /// The name of the window or screen. UTF-8 encoding.
        /// </summary>
        ///
        public string sourceName;

        ///
        /// <summary>
        /// The image content of the thumbnail. See ThumbImageBuffer 
        /// </summary>
        ///
        public ThumbImageBuffer thumbImage;

        ///
        /// <summary>
        /// The image content of the icon. See ThumbImageBuffer 
        /// </summary>
        ///
        public ThumbImageBuffer iconImage;

        ///
        /// <summary>
        /// The process to which the window belongs. UTF-8 encoding.
        /// </summary>
        ///
        public string processPath;

        ///
        /// <summary>
        /// The title of the window. UTF-8 encoding.
        /// </summary>
        ///
        public string sourceTitle;

        ///
        /// <summary>
        /// Determines whether the screen is the primary display:true: The screen is the primary display.false: The screen is not the primary display.
        /// </summary>
        ///
        public bool primaryMonitor;

        ///
        /// @ignore
        ///
        public bool isOccluded;

        ///
        /// @ignore
        ///
        public bool minimizeWindow;

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

    ///
    /// <summary>
    /// The advanced options for audio.
    /// </summary>
    ///
    public class AdvancedAudioOptions : OptionalJsonParse
    {
        ///
        /// <summary>
        /// The number of channels for audio preprocessing. See AUDIO_PROCESSING_CHANNELS .
        /// </summary>
        ///
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

    ///
    /// <summary>
    /// Image configurations
    /// </summary>
    ///
    public class ImageTrackOptions
    {
        ///
        /// <summary>
        /// The URL of the image that you want to use to replace the video feeds. The image must be in PNG format. This method supports adding an image from the local absolute or relative file path.
        /// </summary>
        ///
        public string imageUrl;

        ///
        /// <summary>
        /// The frame rate of the video streams being published. The value range is [1,30]. The default value is 1.
        /// </summary>
        ///
        public int fps;

        public ImageTrackOptions()
        {
            imageUrl = "";
            fps = 1;
        }
    };


    ///
    /// <summary>
    /// The channel media options.
    /// Agora supports publishing multiple audio streams and one video stream at the same time and in the same RtcConnection . For example, publishMicrophoneTrack, publishAudioTrack, publishCustomAudioTrack, and publishMediaPlayerAudioTrack can be set as true at the same time, but only one of publishCameraTrack, publishScreenTrack, publishCustomVideoTrack, or publishEncodedVideoTrack can be set as true.
    /// </summary>
    ///
    public class ChannelMediaOptions : OptionalJsonParse
    {
        ///
        /// <summary>
        /// Whether to publish the video captured by the camera:true: (Default) Publish the video captured by the camera.false: Do not publish the video captured by the camera.
        /// </summary>
        ///
        public Optional<bool> publishCameraTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the video captured by the second camera:true: Publish the video captured by the second camera.false: (Default) Do not publish the video captured by the second camera.
        /// </summary>
        ///
        public Optional<bool> publishSecondaryCameraTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the audio captured by the microphone:true: (Default) Publish the audio captured by the microphone.false: Do not publish the audio captured by the microphone.
        /// </summary>
        ///
        public Optional<bool> publishMicrophoneTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the video captured from the screen:true: Publish the video captured from the screen.false: (Default) Do not publish the captured video from the screen.This parameter applies to Android and iOS only.
        /// </summary>
        ///
        public Optional<bool> publishScreenCaptureVideo = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the audio captured from the screen:true: Publish the audio captured from the screen.false: (Default) Do not publish the audio captured from the screen.This parameter applies to Android and iOS only.
        /// </summary>
        ///
        public Optional<bool> publishScreenCaptureAudio = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the video captured from the screen:true: Publish the video captured from the screen.false: (Default) Do not publish the captured video from the screen.
        /// </summary>
        ///
        public Optional<bool> publishScreenTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the video captured from the second screen:true: Publish the captured video from the second screen.false: (Default) Do not publish the video captured from the second screen.
        /// </summary>
        ///
        public Optional<bool> publishSecondaryScreenTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the audio captured from a custom source:true: Publish the captured audio from a custom source.false: (Default) Do not publish the audio captured from the custom source.
        /// </summary>
        ///
        public Optional<bool> publishCustomAudioTrack = new Optional<bool>();

        ///
        /// <summary>
        /// The ID of the custom audio source to publish. The default value is 0.If you have set the value of sourceNumber greater than 1 in SetExternalAudioSource , the SDK creates the corresponding number of custom audio tracks and assigns an ID to each audio track starting from 0.
        /// </summary>
        ///
        public Optional<int> publishCustomAudioSourceId = new Optional<int>();

        ///
        /// <summary>
        /// Whether to enable AEC when publishing the audio captured from a custom source:true: Enable AEC when publishing the captured audio from a custom source.false: (Default) Do not enable AEC when publishing the audio captured from the custom source.
        /// </summary>
        ///
        public Optional<bool> publishCustomAudioTrackEnableAec = new Optional<bool>();

        ///
        /// @ignore
        ///
        public Optional<bool> publishDirectCustomAudioTrack = new Optional<bool>();

        ///
        /// @ignore
        ///
        public Optional<bool> publishCustomAudioTrackAec = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the video captured from a custom source:true: Publish the captured video from a custom source.false: (Default) Do not publish the video captured from the custom source.
        /// </summary>
        ///
        public Optional<bool> publishCustomVideoTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the encoded video:true: Publish the encoded video.false: (Default) Do not publish the encoded video.
        /// </summary>
        ///
        public Optional<bool> publishEncodedVideoTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the audio from the media player:true: Publish the audio from the media player.false: (Default) Do not publish the audio from the media player.
        /// </summary>
        ///
        public Optional<bool> publishMediaPlayerAudioTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the video from the media player:true: Publish the video from the media player.false: (Default) Do not publish the video from the media player.
        /// </summary>
        ///
        public Optional<bool> publishMediaPlayerVideoTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the local transcoded video:true: Publish the local transcoded video.false: (Default) Do not publish the local transcoded video.
        /// </summary>
        ///
        public Optional<bool> publishTrancodedVideoTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to automatically subscribe to all remote audio streams when the user joins a channel:true: (Default) Automatically subscribe to all remote audio streams.false: Do not automatically subscribe to any remote audio streams.
        /// </summary>
        ///
        public Optional<bool> autoSubscribeAudio = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to automatically subscribe to all remote video streams when the user joins the channel:true: (Default) Automatically subscribe to all remote video streams.false: Do not automatically subscribe to any remote video streams.
        /// </summary>
        ///
        public Optional<bool> autoSubscribeVideo = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to enable audio capturing or playback:true: (Default) Enable audio capturing or playback.false: Do not enable audio capturing or playback.
        /// </summary>
        ///
        public Optional<bool> enableAudioRecordingOrPlayout = new Optional<bool>();

        ///
        /// <summary>
        /// The ID of the media player to be published. The default value is 0.
        /// </summary>
        ///
        public Optional<int> publishMediaPlayerId = new Optional<int>();

        ///
        /// <summary>
        /// The user role. See CLIENT_ROLE_TYPE .
        /// </summary>
        ///
        public Optional<CLIENT_ROLE_TYPE> clientRoleType = new Optional<CLIENT_ROLE_TYPE>();

        ///
        /// <summary>
        /// The latency level of an audience member in interactive live streaming. See AUDIENCE_LATENCY_LEVEL_TYPE .
        /// </summary>
        ///
        public Optional<AUDIENCE_LATENCY_LEVEL_TYPE> audienceLatencyLevel = new Optional<AUDIENCE_LATENCY_LEVEL_TYPE>();

        ///
        /// <summary>
        /// The default video-stream type. See VIDEO_STREAM_TYPE .
        /// </summary>
        ///
        public Optional<VIDEO_STREAM_TYPE> defaultVideoStreamType = new Optional<VIDEO_STREAM_TYPE>();

        ///
        /// <summary>
        /// The channel profile. See CHANNEL_PROFILE_TYPE .
        /// </summary>
        ///
        public Optional<CHANNEL_PROFILE_TYPE> channelProfile = new Optional<CHANNEL_PROFILE_TYPE>();

        ///
        /// @ignore
        ///
        public Optional<int> audioDelayMs = new Optional<int>();

        ///
        /// @ignore
        ///
        public Optional<int> mediaPlayerAudioDelayMs = new Optional<int>();

        ///
        /// <summary>
        /// (Optional) The token generated on your server for authentication. See This parameter takes effect only when calling UpdateChannelMediaOptions or UpdateChannelMediaOptionsEx .Ensure that the App ID, channel name, and user name used for creating the token are the same as those used by the Initialize method for initializing the RTC engine, and those used by the JoinChannel [2/2] and JoinChannelEx methods for joining the channel.
        /// </summary>
        ///
        public Optional<string> token = new Optional<string>();

        ///
        /// @ignore
        ///
        public Optional<bool> enableBuiltInMediaEncryption = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to publish the sound of a metronome to remote users:true: (Default) Publish the sound of the metronome. Both the local user and remote users can hear the metronome.false: Do not publish the sound of the metronome. Only the local user can hear the metronome.
        /// </summary>
        ///
        public Optional<bool> publishRhythmPlayerTrack = new Optional<bool>();

        ///
        /// <summary>
        /// Whether to enable interactive mode:true: Enable interactive mode. Once this mode is enabled and the user role is set as audience, the user can receive remote video streams with low latency.false: (Default) Do not enable interactive mode. If this mode is disabled, the user receives the remote video streams in default settings.This parameter only applies to scenarios involving cohosting across channels. The cohosts need to call the JoinChannelEx method to join the other host's channel as an audience member, and set isInteractiveAudience to true.This parameter takes effect only when the user role is CLIENT_ROLE_AUDIENCE.
        /// </summary>
        ///
        public Optional<bool> isInteractiveAudience = new Optional<bool>();

        ///
        /// <summary>
        /// The video track ID returned by calling the createCustomVideoTrack method. The default value is 0.
        /// </summary>
        ///
        public Optional<video_track_id_t> customVideoTrackId = new Optional<video_track_id_t>();

        ///
        /// <summary>
        /// Whether the audio stream being published is filtered according to the volume algorithm:true: (Default) The audio stream is filtered. If the audio stream filter is not enabled, this setting does not takes effect.false: The audio stream is not filtered.If you need to enable this function, contact .
        /// </summary>
        ///
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

    ///
    /// @ignore
    ///
    public enum LOCAL_PROXY_MODE
    {
        ///
        /// @ignore
        ///
        kConnectivityFirst = 0,

        ///
        /// @ignore
        ///
        kLocalOnly = 1,
    };

    ///
    /// <summary>
    /// The cloud proxy type.
    /// </summary>
    ///
    public enum PROXY_TYPE
    {
        ///
        /// <summary>
        /// 0: Reserved for future use.
        /// </summary>
        ///
        NONE_PROXY_TYPE = 0,

        ///
        /// <summary>
        /// 1: The cloud proxy for the UDP protocol, that is, the Force UDP cloud proxy mode. In this mode, the SDK always transmits data over UDP.
        /// </summary>
        ///
        UDP_PROXY_TYPE = 1,

        ///
        /// <summary>
        /// 2: The cloud proxy for the TCP (encryption) protocol, that is, the Force TCP cloud proxy mode. In this mode, the SDK always transmits data over TCP/TLS 443.
        /// </summary>
        ///
        TCP_PROXY_TYPE = 2,

        ///
        /// <summary>
        /// 3: Reserved for future use.
        /// </summary>
        ///
        LOCAL_PROXY_TYPE = 3,

        ///
        /// <summary>
        /// 4: Automatic mode. In this mode, the SDK attempts a direct connection to SD-RTN™ and automatically switches to TCP/TLS 443 if the attempt fails.
        /// </summary>
        ///
        TCP_PROXY_AUTO_FALLBACK_TYPE = 4,
    };

    ///
    /// @ignore
    ///
    public class LogUploadServerInfo
    {

        ///
        /// @ignore
        ///
        public string serverDomain;

        ///
        /// @ignore
        ///
        public string serverPath;

        ///
        /// @ignore
        ///
        public int serverPort;

        ///
        /// @ignore
        ///
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

    ///
    /// @ignore
    ///
    public class AdvancedConfigInfo
    {
        public LogUploadServerInfo logUploadServer = new LogUploadServerInfo();
    };

    ///
    /// @ignore
    ///
    public class LocalAccessPointConfiguration
    {
        ///
        /// @ignore
        ///
        public string[] ipList;

        ///
        /// @ignore
        ///
        public int ipListSize;

        ///
        /// @ignore
        ///
        public string[] domainList;

        ///
        /// @ignore
        ///
        public int domainListSize;

        ///
        /// @ignore
        ///
        public string verifyDomainName;

        ///
        /// @ignore
        ///
        public LOCAL_PROXY_MODE mode;

        ///
        /// @ignore
        ///
        public AdvancedConfigInfo advancedConfig;

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

    ///
    /// <summary>
    /// The options for leaving a channel.
    /// </summary>
    ///
    public class LeaveChannelOptions
    {
        public LeaveChannelOptions()
        {
            stopAudioMixing = true;
            stopAllEffect = true;
            stopMicrophoneRecording = true;
        }

        ///
        /// <summary>
        /// Whether to stop playing and mixing the music file when a user leaves the channel. true: (Default) Stop playing and mixing the music file.false: Do not stop playing and mixing the music file.
        /// </summary>
        ///
        public bool stopAudioMixing;

        ///
        /// <summary>
        /// Whether to stop playing all audio effects when a user leaves the channel. true: (Default) Stop playing all audio effects.false: Do not stop playing any audio effect.
        /// </summary>
        ///
        public bool stopAllEffect;

        ///
        /// <summary>
        /// Whether to stop microphone recording when a user leaves the channel. true: (Default) Stop microphone recording.false: Do not stop microphone recording.
        /// </summary>
        ///
        public bool stopMicrophoneRecording;
    };

    ///
    /// <summary>
    /// Configurations for the RtcEngineContext instance.
    /// </summary>
    ///
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

        ///
        /// <summary>
        /// The App ID issued by Agora for your project. Only users in apps with the same App ID can join the same channel and communicate with each other. An App ID can only be used to create one IRtcEngine instance. To change your App ID, call Dispose to destroy the current IRtcEngine instance, and then create a new one.
        /// </summary>
        ///
        public string appId;

        ///
        /// <summary>
        /// For Windows, it is the window handle of the app. Once set, this parameter enables you to connect or disconnect the video devices while they are powered.For Android, it is the context of Android Activity.
        /// </summary>
        ///
        public UInt64 context;

        ///
        /// <summary>
        /// The channel profile. See CHANNEL_PROFILE_TYPE .
        /// </summary>
        ///
        public CHANNEL_PROFILE_TYPE channelProfile;


        ///
        /// @ignore
        ///
        public string license;
        ///
        /// <summary>
        /// The audio scenarios. See AUDIO_SCENARIO_TYPE . Under different audio scenarios, the device uses different volume types.
        /// </summary>
        ///
        public AUDIO_SCENARIO_TYPE audioScenario;

        ///
        /// <summary>
        /// The region for connection. This is an advanced feature and applies to scenarios that have regional restrictions. For details on supported regions, see AREA_CODE . The area codes support bitwise operation.
        /// </summary>
        ///
        public AREA_CODE areaCode;


        ///
        /// <summary>
        /// The SDK log files are: agorasdk.log, agorasdk.1.log, agorasdk.2.log, agorasdk.3.log, and agorasdk.4.log.
        /// The API call log files are: agoraapi.log, agoraapi.1.log, agoraapi.2.log, agoraapi.3.log, and agoraapi.4.log.
        /// The default size for each SDK log file is 1,024 KB; the default size for each API call log file is 2,048 KB. These log files are encoded in UTF-8.
        /// The SDK writes the latest logs in agorasdk.log or agoraapi.log.
        /// When agorasdk.log is full, the SDK processes the log files in the following order:
        /// Delete the agorasdk.4.log file (if any).
        /// Rename agorasdk.3.log to agorasdk.4.log.
        /// Rename agorasdk.2.log to agorasdk.3.log.
        /// Rename agorasdk.1.log to agorasdk.2.log.
        /// Create a new agorasdk.log file. The overwrite rules for the agoraapi.log file are the same as for agorasdk.log. The log files that the SDK outputs. See LogConfig .By default, the SDK generates five SDK log files and five API call log files with the following rules:
        /// </summary>
        ///
        public LogConfig logConfig;

        ///
        /// @ignore
        ///
        public Optional<THREAD_PRIORITY_TYPE> threadPriority = new Optional<THREAD_PRIORITY_TYPE>();

        ///
        /// @ignore
        ///
        public bool useExternalEglContext;

        ///
        /// <summary>
        /// Whether to enable domain name restriction:true: Enables the domain name restriction. This value is suitable for scenarios where IoT devices use IoT cards for network access. The SDK will only connect to servers in the domain name or IP whitelist that has been reported to the operator.false: (Default) Disables the domain name restriction. This value is suitable for most common scenarios.
        /// </summary>
        ///
        public bool domainLimit;

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

    ///
    /// <summary>
    /// Metadata type of the observer. We only support video metadata for now.
    /// </summary>
    ///
    public enum METADATA_TYPE
    {
        ///
        /// <summary>
        /// The type of metadata is unknown.
        /// </summary>
        ///
        UNKNOWN_METADATA = -1,

        ///
        /// <summary>
        /// The type of metadata is video.
        /// </summary>
        ///
        VIDEO_METADATA = 0,
    };

    ///
    /// <summary>
    /// Media metadata.
    /// </summary>
    ///
    public class Metadata
    {
        ///
        /// <summary>
        /// The user ID.For the recipient:the ID of the remote user who sent the Metadata.Ignore it for sender.
        /// </summary>
        ///
        public uint uid;

        ///
        /// <summary>
        /// Buffer size for received or sent Metadata.
        /// </summary>
        ///
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

        ///
        /// <summary>
        /// The timestamp (ms) of Metadata.
        /// </summary>
        ///
        public long timeStampMs;
    };

    ///
    /// @ignore
    ///
    public enum DIRECT_CDN_STREAMING_ERROR
    {
        ///
        /// @ignore
        ///
        DIRECT_CDN_STREAMING_ERROR_OK = 0,

        ///
        /// @ignore
        ///
        DIRECT_CDN_STREAMING_ERROR_FAILED = 1,

        ///
        /// @ignore
        ///
        DIRECT_CDN_STREAMING_ERROR_AUDIO_PUBLICATION = 2,

        ///
        /// @ignore
        ///
        DIRECT_CDN_STREAMING_ERROR_VIDEO_PUBLICATION = 3,

        ///
        /// @ignore
        ///
        DIRECT_CDN_STREAMING_ERROR_NET_CONNECT = 4,

        ///
        /// @ignore
        ///
        DIRECT_CDN_STREAMING_ERROR_BAD_NAME = 5,
    };

    ///
    /// @ignore
    ///
    public enum DIRECT_CDN_STREAMING_STATE
    {

        ///
        /// @ignore
        ///
        DIRECT_CDN_STREAMING_STATE_IDLE = 0,

        ///
        /// @ignore
        ///
        DIRECT_CDN_STREAMING_STATE_RUNNING = 1,

        ///
        /// @ignore
        ///
        DIRECT_CDN_STREAMING_STATE_STOPPED = 2,

        ///
        /// @ignore
        ///
        DIRECT_CDN_STREAMING_STATE_FAILED = 3,

        ///
        /// @ignore
        ///
        DIRECT_CDN_STREAMING_STATE_RECOVERING = 4,
    };

    ///
    /// @ignore
    ///
    public class DirectCdnStreamingStats
    {
        ///
        /// @ignore
        ///
        public int videoWidth;

        ///
        /// @ignore
        ///
        public int videoHeight;

        ///
        /// @ignore
        ///
        public int fps;

        ///
        /// @ignore
        ///
        public int videoBitrate;

        ///
        /// @ignore
        ///
        public int audioBitrate;
    };

    ///
    /// @ignore
    ///
    public class DirectCdnStreamingMediaOptions : OptionalJsonParse
    {
        ///
        /// @ignore
        ///
        public Optional<bool> publishCameraTrack = new Optional<bool>();

        ///
        /// @ignore
        ///
        public Optional<bool> publishMicrophoneTrack = new Optional<bool>();

        ///
        /// @ignore
        ///
        public Optional<bool> publishCustomAudioTrack = new Optional<bool>();

        ///
        /// @ignore
        ///
        public Optional<bool> publishCustomVideoTrack = new Optional<bool>();

        ///
        /// @ignore
        ///
        public Optional<bool> publishMediaPlayerAudioTrack = new Optional<bool>();

        ///
        /// @ignore
        ///
        public Optional<int> publishMediaPlayerId = new Optional<int>();

        ///
        /// @ignore
        ///
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

    ///
    /// @ignore
    ///
    public class ExtensionInfo
    {
        ///
        /// @ignore
        ///
        public MEDIA_SOURCE_TYPE mediaSourceType;

        ///
        /// @ignore
        ///
        public uint remoteUid;

        ///
        /// @ignore
        ///
        public string channelId;

        ///
        /// @ignore
        ///
        public uint localUid;

        public ExtensionInfo()
        {
            mediaSourceType = MEDIA_SOURCE_TYPE.UNKNOWN_MEDIA_SOURCE;
            remoteUid = 0;
            channelId = "";
            localUid = 0;
        }
    };


    ///
    /// @ignore
    ///
    public enum QUALITY_REPORT_FORMAT_TYPE
    {
        ///
        /// @ignore
        ///
        QUALITY_REPORT_JSON = 0,

        ///
        /// @ignore
        ///
        QUALITY_REPORT_HTML = 1,
    };

    ///
    /// <summary>
    /// Media device states.
    /// </summary>
    ///
    public enum MEDIA_DEVICE_STATE_TYPE
    {
        ///
        /// <summary>
        /// 0: The device is ready for use.
        /// </summary>
        ///
        MEDIA_DEVICE_STATE_IDLE = 0,

        ///
        /// <summary>
        /// 1: The device is in use.
        /// </summary>
        ///
        MEDIA_DEVICE_STATE_ACTIVE = 1,

        ///
        /// <summary>
        /// 2: The device is disabled.
        /// </summary>
        ///
        MEDIA_DEVICE_STATE_DISABLED = 2,

        ///
        /// <summary>
        /// 4: The device is not found.
        /// </summary>
        ///
        MEDIA_DEVICE_STATE_NOT_PRESENT = 4,

        ///
        /// <summary>
        /// 8: The device is unplugged.
        /// </summary>
        ///
        MEDIA_DEVICE_STATE_UNPLUGGED = 8
    };

    ///
    /// <summary>
    /// Video profile.
    /// </summary>
    ///
    public enum VIDEO_PROFILE_TYPE
    {
        ///
        /// <summary>
        /// 0: 160 × 120, frame rate 15 fps, bitrate 65 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_120P = 0,  // 160x120   15

        ///
        /// <summary>
        /// 2: 120 × 120, frame rate 15 fps, bitrate 50 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_120P_3 = 2,   // 120x120   15

        ///
        /// <summary>
        /// 10: 320 × 180, frame rate 15 fps, bitrate 140 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_180P = 10,    // 320x180   15

        ///
        /// <summary>
        /// 12: 180 × 180, frame rate 15 fps, bitrate 100 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_180P_3 = 12,  // 180x180   15

        ///
        /// <summary>
        /// 13: 240 × 180, frame rate 15 fps, bitrate 120 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_180P_4 = 13,  // 240x180   15

        ///
        /// <summary>
        /// 20: 320 × 240, frame rate 15 fps, bitrate 200 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_240P = 20,    // 320x240   15

        ///
        /// <summary>
        /// 22: 240 × 240, frame rate 15 fps, bitrate 140 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_240P_3 = 22,  // 240x240   15

        ///
        /// <summary>
        /// 23: 424 × 240, frame rate 15 fps, bitrate 220 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_240P_4 = 23,  // 424x240   15

        ///
        /// <summary>
        /// 30: 640 × 360, frame rate 15 fps, bitrate 400 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_360P = 30,  // 640x360   15

        ///
        /// <summary>
        /// 32: 360 × 360, frame rate 15 fps, bitrate 260 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_360P_3 = 32,  // 360x360   15

        ///
        /// <summary>
        /// 33: 640 × 360, frame rate 30 fps, bitrate 600 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_360P_4 = 33,  // 640x360   30

        ///
        /// <summary>
        /// 35: 360 × 360, frame rate 30 fps, bitrate 400 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_360P_6 = 35,  // 360x360   30

        ///
        /// <summary>
        /// 36: 480 × 360, frame rate 15 fps, bitrate 320 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_360P_7 = 36,  // 480x360   15

        ///
        /// <summary>
        /// 37: 480 × 360, frame rate 30 fps, bitrate 490 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_360P_8 = 37,  // 480x360   30

        ///
        /// <summary>
        /// 38: 640 × 360, frame rate 15 fps, bitrate 800 Kbps.This profile applies only to the live streaming channel profile.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_360P_9 = 38,   // 640x360   15

        ///
        /// <summary>
        /// 39: 640 × 360, frame rate 24 fps, bitrate 800 Kbps.This profile applies only to the live streaming channel profile.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_360P_10 = 39,  // 640x360   24

        ///
        /// <summary>
        /// 100: 640 × 360, frame rate 24 fps, bitrate 1000 Kbps.This profile applies only to the live streaming channel profile.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_360P_11 = 100,  // 640x360   24

        ///
        /// <summary>
        /// 40: 640 × 480, frame rate 15 fps, bitrate 500 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_480P = 40,  // 640x480   15

        ///
        /// <summary>
        /// 42: 480 × 480, frame rate 15 fps, bitrate 400 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_480P_3 = 42,  // 480x480   15

        ///
        /// <summary>
        /// 43: 640 × 480, frame rate 30 fps, bitrate 750 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_480P_4 = 43,  // 640x480   30

        ///
        /// <summary>
        /// 45: 480 × 480, frame rate 30 fps, bitrate 600 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_480P_6 = 45,  // 480x480   30

        ///
        /// <summary>
        /// 47: 848 × 480, frame rate 15 fps, bitrate 610 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_480P_8 = 47,  // 848x480   15

        ///
        /// <summary>
        /// 48: 848 × 480, frame rate 30 fps, bitrate 930 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_480P_9 = 48,  // 848x480   30

        ///
        /// <summary>
        /// 49: 640 × 480, frame rate 10 fps, bitrate 400 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_480P_10 = 49,  // 640x480   10

        ///
        /// <summary>
        /// 50: 1280 × 720, frame rate 15 fps, bitrate 1130 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_720P = 50,  // 1280x720  15

        ///
        /// <summary>
        /// 52: 1280 × 720, frame rate 30 fps, bitrate 1710 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_720P_3 = 52,  // 1280x720  30

        ///
        /// <summary>
        /// 54: 960 × 720, frame rate 15 fps, bitrate 910 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_720P_5 = 54,  // 960x720   15

        ///
        /// <summary>
        /// 55: 960 × 720, frame rate 30 fps, bitrate 1380 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_720P_6 = 55,  // 960x720   30

        ///
        /// <summary>
        /// 60: 1920 × 1080, frame rate 15 fps, bitrate 2080 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_1080P = 60,  // 1920x1080 15

        ///
        /// <summary>
        /// 60: 1920 × 1080, frame rate 30 fps, bitrate 3150 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_1080P_3 = 62,  // 1920x1080 30

        ///
        /// <summary>
        /// 64: 1920 × 1080, frame rate 60 fps, bitrate 4780 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_LANDSCAPE_1080P_5 = 64,  // 1920x1080 60

        ///
        /// @ignore
        ///
        VIDEO_PROFILE_LANDSCAPE_1440P = 66,  // 2560x1440 30

        ///
        /// @ignore
        ///
        VIDEO_PROFILE_LANDSCAPE_1440P_2 = 67,  // 2560x1440 60

        ///
        /// @ignore
        ///
        VIDEO_PROFILE_LANDSCAPE_4K = 70,  // 3840x2160 30

        ///
        /// @ignore
        ///
        VIDEO_PROFILE_LANDSCAPE_4K_3 = 72,     // 3840x2160 60

        ///
        /// <summary>
        /// 1000: 120 × 160, frame rate 15 fps, bitrate 65 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_120P = 1000,    // 120x160   15

        ///
        /// <summary>
        /// 1002: 120 × 120, frame rate 15 fps, bitrate 50 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_120P_3 = 1002,  // 120x120   15

        ///
        /// <summary>
        /// 1010: 180 × 320, frame rate 15 fps, bitrate 140 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_180P = 1010,    // 180x320   15

        ///
        /// <summary>
        /// 1012: 180 × 180, frame rate 15 fps, bitrate 100 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_180P_3 = 1012,  // 180x180   15

        ///
        /// <summary>
        /// 1013: 180 × 240, frame rate 15 fps, bitrate 120 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_180P_4 = 1013,  // 180x240   15

        ///
        /// <summary>
        /// 1020: 240 × 320, frame rate 15 fps, bitrate 200 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_240P = 1020,  // 240x320   15

        ///
        /// <summary>
        /// 1022: 240 × 240, frame rate 15 fps, bitrate 140 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_240P_3 = 1022,  // 240x240   15

        ///
        /// <summary>
        /// 1023: 240 × 424, frame rate 15 fps, bitrate 220 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_240P_4 = 1023,  // 240x424   15

        ///
        /// <summary>
        /// 1030: 360 × 640, frame rate 15 fps, bitrate 400 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_360P = 1030,  // 360x640   15

        ///
        /// <summary>
        /// 1032: 360 × 360, frame rate 15 fps, bitrate 260 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_360P_3 = 1032,  // 360x360   15

        ///
        /// <summary>
        /// 1033: 360 × 640, frame rate 15 fps, bitrate 600 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_360P_4 = 1033,  // 360x640   30

        ///
        /// <summary>
        /// 1035: 360 × 360, frame rate 30 fps, bitrate 400 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_360P_6 = 1035,  // 360x360   30

        ///
        /// <summary>
        /// 1036: 360 × 480, frame rate 15 fps, bitrate 320 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_360P_7 = 1036,  // 360x480   15

        ///
        /// <summary>
        /// 1037: 360 × 480, frame rate 30 fps, bitrate 490 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_360P_8 = 1037,  // 360x480   30

        ///
        /// <summary>
        /// 1038: 360 × 640, frame rate 15 fps, bitrate 800 Kbps.This profile applies only to the live streaming channel profile.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_360P_9 = 1038,  // 360x640   15

        ///
        /// <summary>
        /// 1039: 360 × 640, frame rate 24 fps, bitrate 800 Kbps.This profile applies only to the live streaming channel profile.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_360P_10 = 1039,  // 360x640   24

        ///
        /// <summary>
        /// 1100: 360 × 640, frame rate 24 fps, bitrate 1000 Kbps.This profile applies only to the live streaming channel profile.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_360P_11 = 1100,  // 360x640   24

        ///
        /// <summary>
        /// 1040: 480 × 640, frame rate 15 fps, bitrate 500 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_480P = 1040,  // 480x640   15

        ///
        /// <summary>
        /// 1042: 480 × 480, frame rate 15 fps, bitrate 400 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_480P_3 = 1042,  // 480x480   15

        ///
        /// <summary>
        /// 1043: 480 × 640, frame rate 30 fps, bitrate 750 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_480P_4 = 1043,  // 480x640   30

        ///
        /// <summary>
        /// 1045: 480 × 480, frame rate 30 fps, bitrate 600 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_480P_6 = 1045,  // 480x480   30

        ///
        /// <summary>
        /// 1047: 480 × 848, frame rate 15 fps, bitrate 610 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_480P_8 = 1047,  // 480x848   15

        ///
        /// <summary>
        /// 1048: 480 × 848, frame rate 30 fps, bitrate 930 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_480P_9 = 1048,  // 480x848   30

        ///
        /// <summary>
        /// 1049: 480 × 640, frame rate 10 fps, bitrate 400 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_480P_10 = 1049,  // 480x640   10

        ///
        /// <summary>
        /// 1050: 720 × 1280, frame rate 15 fps, bitrate 1130 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_720P = 1050,  // 720x1280  15

        ///
        /// <summary>
        /// 1052: 720 × 1280, frame rate 30 fps, bitrate 1710 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_720P_3 = 1052,  // 720x1280  30

        ///
        /// <summary>
        /// 1054: 720 × 960, frame rate 15 fps, bitrate 910 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_720P_5 = 1054,  // 720x960   15

        ///
        /// <summary>
        /// 1055: 720 × 960, frame rate 30 fps, bitrate 1380 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_720P_6 = 1055,  // 720x960   30

        ///
        /// <summary>
        /// 1060: 1080 × 1920, frame rate 15 fps, bitrate 2080 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_1080P = 1060,    // 1080x1920 15

        ///
        /// <summary>
        /// 1062: 1080 × 1920, frame rate 30 fps, bitrate 3150 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_1080P_3 = 1062,  // 1080x1920 30

        ///
        /// <summary>
        /// 1064: 1080 × 1920, frame rate 60 fps, bitrate 4780 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_PORTRAIT_1080P_5 = 1064,  // 1080x1920 60

        ///
        /// @ignore
        ///
        VIDEO_PROFILE_PORTRAIT_1440P = 1066,  // 1440x2560 30

        ///
        /// @ignore
        ///
        VIDEO_PROFILE_PORTRAIT_1440P_2 = 1067,  // 1440x2560 60

        ///
        /// @ignore
        ///
        VIDEO_PROFILE_PORTRAIT_4K = 1070,       // 2160x3840 30

        ///
        /// @ignore
        ///
        VIDEO_PROFILE_PORTRAIT_4K_3 = 1072,  // 2160x3840 60

        ///
        /// <summary>
        /// (Default) 640 × 360, frame rate 15 fps, bitrate 400 Kbps.
        /// </summary>
        ///
        VIDEO_PROFILE_DEFAULT = VIDEO_PROFILE_LANDSCAPE_360P,
    };

    #endregion
}