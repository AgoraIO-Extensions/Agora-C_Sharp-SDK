using System;
using view_t = System.UInt64;
using video_track_id_t = System.UInt32;
using Agora.Rtc.LitJson;

namespace Agora.Rtc
{
    #region IAgoraRtcEngine.h
    /**
    * The media device types.
*/
    public enum MEDIA_DEVICE_TYPE
    {
        /**
        * -1: Unknown device type.
        */
        UNKNOWN_AUDIO_DEVICE = -1,
        /**
        * 0: The audio playback device.
        */
        AUDIO_PLAYOUT_DEVICE = 0,
        /**
        * 1: The audio recording device.
        */
        AUDIO_RECORDING_DEVICE = 1,
        /**
        * 2: The video renderer.
        */
        VIDEO_RENDER_DEVICE = 2,
        /**
        * 3: The video capturer.
        */
        VIDEO_CAPTURE_DEVICE = 3,
        /**
        * 4: The audio playback device of the app.
        */
        AUDIO_APPLICATION_PLAYOUT_DEVICE = 4,
    };

    /**
    The states of the local user's audio mixing file.
    */
    public enum AUDIO_MIXING_STATE_TYPE
    {
        /** 710: The audio mixing file is playing. */
        AUDIO_MIXING_STATE_PLAYING = 710,
        /** 711: The audio mixing file pauses playing. */
        AUDIO_MIXING_STATE_PAUSED = 711,
        /** 713: The audio mixing file stops playing. */
        AUDIO_MIXING_STATE_STOPPED = 713,
        /** 714: An exception occurs when playing the audio mixing file.
         See #AUDIO_MIXING_REASON_TYPE.
         */
        AUDIO_MIXING_STATE_FAILED = 714,
    };

    /**
    The reson codes of the local user's audio mixing file.
    */
    public enum AUDIO_MIXING_REASON_TYPE
    {
        /** 701: The SDK cannot open the audio mixing file. */
        AUDIO_MIXING_REASON_CAN_NOT_OPEN = 701,
        /** 702: The SDK opens the audio mixing file too frequently. */
        AUDIO_MIXING_REASON_TOO_FREQUENT_CALL = 702,
        /** 703: The audio mixing file playback is interrupted. */
        AUDIO_MIXING_REASON_INTERRUPTED_EOF = 703,
        /** 715: The audio mixing file is played once. */
        AUDIO_MIXING_REASON_ONE_LOOP_COMPLETED = 721,
        /** 716: The audio mixing file is all played out. */
        AUDIO_MIXING_REASON_ALL_LOOPS_COMPLETED = 723,
        /** 716: The audio mixing file stopped by user */
        AUDIO_MIXING_REASON_STOPPED_BY_USER = 724,
        /** 0: The SDK can open the audio mixing file. */
        AUDIO_MIXING_REASON_OK = 0,
    };


    /**
    * The status of importing an external video stream in a live broadcast.
    */
    public enum INJECT_STREAM_STATUS
    {
        /**
        * 0: The media stream is injected successfully.
        */
        INJECT_STREAM_STATUS_START_SUCCESS = 0,
        /**
        * 1: The media stream already exists.
        */
        INJECT_STREAM_STATUS_START_ALREADY_EXISTS = 1,
        /**
        * 2: The media stream injection is unauthorized.
        */
        INJECT_STREAM_STATUS_START_UNAUTHORIZED = 2,
        /**
        * 3: Timeout occurs when injecting a media stream.
        */
        INJECT_STREAM_STATUS_START_TIMEDOUT = 3,
        /**
        * 4: The media stream injection fails.
        */
        INJECT_STREAM_STATUS_START_FAILED = 4,
        /**
        * 5: The media stream stops being injected successfully.
        */
        INJECT_STREAM_STATUS_STOP_SUCCESS = 5,
        /**
        * 6: The media stream injection that you want to stop is found.
        */
        INJECT_STREAM_STATUS_STOP_NOT_FOUND = 6,
        /**
        * 7: You are not authorized to stop the media stream injection.
        */
        INJECT_STREAM_STATUS_STOP_UNAUTHORIZED = 7,
        /**
        * 8: Timeout occurs when you stop injecting the media stream.
        */
        INJECT_STREAM_STATUS_STOP_TIMEDOUT = 8,
        /**
        * 9: Stopping injecting the media stream fails.
        */
        INJECT_STREAM_STATUS_STOP_FAILED = 9,
        /**
        * 10: The media stream is broken.
        */
        INJECT_STREAM_STATUS_BROKEN = 10,
    };

    /**
    * The audio equalization band frequency.
*/
    public enum AUDIO_EQUALIZATION_BAND_FREQUENCY
    {
        /**
        * 0: 31 Hz.
        */
        AUDIO_EQUALIZATION_BAND_31 = 0,
        /**
        * 1: 62 Hz.
        */
        AUDIO_EQUALIZATION_BAND_62 = 1,
        /**
        * 2: 125 Hz.
        */
        AUDIO_EQUALIZATION_BAND_125 = 2,
        /**
        * 3: 250 Hz.
        */
        AUDIO_EQUALIZATION_BAND_250 = 3,
        /**
        * 4: 500 Hz.
        */
        AUDIO_EQUALIZATION_BAND_500 = 4,
        /**
        * 5: 1 KHz.
        */
        AUDIO_EQUALIZATION_BAND_1K = 5,
        /**
        * 6: 2 KHz.
        */
        AUDIO_EQUALIZATION_BAND_2K = 6,
        /**
        * 7: 4 KHz.
        */
        AUDIO_EQUALIZATION_BAND_4K = 7,
        /**
        * 8: 8 KHz.
        */
        AUDIO_EQUALIZATION_BAND_8K = 8,
        /**
        * 9: 16 KHz.
        */
        AUDIO_EQUALIZATION_BAND_16K = 9,
    };

    /**
    * The audio reverberation type.
*/
    public enum AUDIO_REVERB_TYPE
    {
        /**
        * 0: (-20 to 10 dB), the level of the dry signal.
        */
        AUDIO_REVERB_DRY_LEVEL = 0,
        /**
        * 1: (-20 to 10 dB), the level of the early reflection signal (wet signal).
        */
        AUDIO_REVERB_WET_LEVEL = 1,
        /**
        * 2: (0 to 100 dB), the room size of the reflection.
        */
        AUDIO_REVERB_ROOM_SIZE = 2,
        /**
        * 3: (0 to 200 ms), the length of the initial delay of the wet signal in ms.
        */
        AUDIO_REVERB_WET_DELAY = 3,
        /**
        * 4: (0 to 100), the strength of the late reverberation.
        */
        AUDIO_REVERB_STRENGTH = 4,
    };

    public enum STREAM_FALLBACK_OPTIONS
    {
        /** 0: (Default) No fallback operation for the stream when the network
            condition is poor. The stream quality cannot be guaranteed. */

        STREAM_FALLBACK_OPTION_DISABLED = 0,
        /** 1: Under poor network conditions, the SDK will send or receive
            agora::rtc::VIDEO_STREAM_LOW. You can only set this option in
            RtcEngineParameters::setRemoteSubscribeFallbackOption. Nothing happens when
            you set this in RtcEngineParameters::setLocalPublishFallbackOption. */
        STREAM_FALLBACK_OPTION_VIDEO_STREAM_LOW = 1,
        /** 2: Under poor network conditions, the SDK may receive
            agora::rtc::VIDEO_STREAM_LOW first, but if the network still does
            not allow displaying the video, the SDK will send or receive audio only. */
        STREAM_FALLBACK_OPTION_AUDIO_ONLY = 2,
    };

    public enum PRIORITY_TYPE
    {
        /** 50: High priority.
        */
        PRIORITY_HIGH = 50,
        /** 100: (Default) normal priority.
        */
        PRIORITY_NORMAL = 100,
    };

    /** Statistics of the local video stream.
     */
    public class LocalVideoStats
    {
        public LocalVideoStats()
        {
        }

        /**
        * ID of the local user.
        */
        public uint uid { set; get; }

        /** Bitrate (Kbps) sent in the reported interval, which does not include
         * the bitrate of the retransmission video after packet loss.
         */
        public int sentBitrate { set; get; }

        /** Frame rate (fps) sent in the reported interval, which does not include
         * the frame rate of the retransmission video after packet loss.
         */
        public int sentFrameRate { set; get; }

        /** The capture frame rate (fps) of the local video.
         */
        public int captureFrameRate { set; get; }

        /** The width of the capture frame (px).
        */
        public int captureFrameWidth { set; get; }
        /** The height of the capture frame (px).
         */
        public int captureFrameHeight { set; get; }

        /**
        * The regulated frame rate of capture frame rate according to video encoder configuration.
        */
        public int regulatedCaptureFrameRate { set; get; }
        /**
         * The regulated frame width (pixel) of capture frame width according to video encoder configuration.
         */
        public int regulatedCaptureFrameWidth { set; get; }
        /**
         * The regulated frame height (pixel) of capture frame height according to video encoder configuration.
         */
        public int regulatedCaptureFrameHeight { set; get; }

        /** The encoder output frame rate (fps) of the local video.
         */
        public int encoderOutputFrameRate { set; get; }

        /** The width of the encoding frame (px).
        */
        public int encodedFrameWidth { set; get; }

        /** The height of the encoding frame (px).
        */
        public int encodedFrameHeight { set; get; }

        /** The render output frame rate (fps) of the local video.
         */
        public int rendererOutputFrameRate { set; get; }

        /** The target bitrate (Kbps) of the current encoder. This value is estimated by the SDK based on the current network conditions.
         */
        public int targetBitrate { set; get; }

        /** The target frame rate (fps) of the current encoder.
         */
        public int targetFrameRate { set; get; }

        /** Quality change of the local video in terms of target frame rate and
        * target bit rate in this reported interval. See #QUALITY_ADAPT_INDICATION.
        */
        public QUALITY_ADAPT_INDICATION qualityAdaptIndication { set; get; }
        public int encodedBitrate { set; get; }


        /** The value of the sent frames, represented by an aggregate value.
         */
        public int encodedFrameCount { set; get; }

        /** The codec type of the local video:
         * - VIDEO_CODEC_VP8 = 1: VP8.
         * - VIDEO_CODEC_H264 = 2: (Default) H.264.
         */
        public VIDEO_CODEC_TYPE codecType { set; get; }

        /**
        * The video packet loss rate (%) from the local client to the Agora edge server before applying the anti-packet loss strategies.
        */
        public ushort txPacketLossRate { set; get; }

        /** The brightness level of the video image captured by the local camera. See #CAPTURE_BRIGHTNESS_LEVEL_TYPE.
        */
        public CAPTURE_BRIGHTNESS_LEVEL_TYPE captureBrightnessLevel { set; get; }
    }

    /** Statistics of the remote video stream.
     */
    public class RemoteVideoStats
    {
        /**
 * ID of the remote user sending the video stream.
 */
        public uint uid { set; get; }
        /**
         * @deprecated Time delay (ms).
         *
         * In scenarios where audio and video is synchronized, you can use the
         * value of `networkTransportDelay` and `jitterBufferDelay` in `RemoteAudioStats`
         * to know the delay statistics of the remote video.
         */
        [Obsolete]
        public int delay { set; get; }
        /**
         * The width (pixels) of the video stream.
         */
        public int width { set; get; }
        /**
         * The height (pixels) of the video stream.
         */
        public int height { set; get; }
        /**
         * Bitrate (Kbps) received since the last count.
         */
        public int receivedBitrate { set; get; }
        /** The decoder output frame rate (fps) of the remote video.
         */
        public int decoderOutputFrameRate { set; get; }
        /** The render output frame rate (fps) of the remote video.
         */
        public int rendererOutputFrameRate { set; get; }
        /** The video frame loss rate (%) of the remote video stream in the reported interval.
         */
        public int frameLossRate { set; get; }
        /** Packet loss rate (%) of the remote video stream after using the anti-packet-loss method.
         */
        public int packetLossRate { set; get; }
        /**
         * The type of the remote video stream: #VIDEO_STREAM_TYPE.
         */
        public VIDEO_STREAM_TYPE rxStreamType { set; get; }
        /**
           The total freeze time (ms) of the remote video stream after the remote user joins the channel.
           In a video session where the frame rate is set to no less than 5 fps, video freeze occurs when
           the time interval between two adjacent renderable video frames is more than 500 ms.
           */
        public int totalFrozenTime { set; get; }
        /**
         The total video freeze time as a percentage (%) of the total time when the video is available.
         */
        public int frozenRate { set; get; }
        /**
         The offset (ms) between audio and video stream. A positive value indicates the audio leads the
         video, and a negative value indicates the audio lags the video.
         */
        public int avSyncTimeMs { set; get; }
        /**
         * The total time (ms) when the remote user neither stops sending the audio
         * stream nor disables the audio module after joining the channel.
         */
        public int totalActiveTime { set; get; }
        /**
         * The total publish duration (ms) of the remote audio stream.
         */
        public int publishDuration { set; get; }
        /**
         * The SuperResolution stats. 0 is not ok. >0 is ok. 
         */
        public int superResolutionType { set; get; }
    }

    public class Region
    {
        /** User ID of the user whose video is to be displayed in the region.
         */
        public uint uid { set; get; }
        /** Horizontal position of the region on the screen.
         */
        public double x { set; get; } // [0,1]
        /** Vertical position of the region on the screen.
         */
        public double y { set; get; }  // [0,1]
        /**
         Actual width of the region.
        */
        public double width { set; get; } // [0,1]
        /** Actual height of the region. */
        public double height { set; get; }  // [0,1]
        /** 0 means the region is at the bottom, and 100 means the region is at the
         * top.
         */
        public int zOrder { set; get; } // optional, [0, 100] //0 (default): bottom most, 100: top most

        /** 0 means the region is transparent, and 1 means the region is opaque. The
         * default value is 1.0.
         */
        public double alpha { set; get; }

        public RENDER_MODE_TYPE renderMode;  // RENDER_MODE_HIDDEN: Crop, RENDER_MODE_FIT: Zoom to fit

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
        /** Ignore this parameter. The width of the canvas is set by
        agora::rtc::IRtcEngine::configPublisher, and not by
        agora::rtc::VideoCompositingLayout::canvasWidth.
        */
        public int canvasWidth { set; get; }
        /** Ignore this parameter. The height of the canvas is set by
         agora::rtc::IRtcEngine::configPublisher, and not by
         agora::rtc::VideoCompositingLayout::canvasHeight.
        */
        public int canvasHeight { set; get; }
        /** Enter any of the 6-digit symbols defined in RGB.
         */
        public string backgroundColor { set; get; } // e.g. "#C0C0C0" in RGB
        /** Region array. Each host in the channel can have a region to display the
         * video on the screen.
         */
        public Region[] regions { set; get; }
        /** Number of users in the channel.
         */
        public int regionCount { set; get; }
        /** User-defined data.
         */
        public string appData { set; get; }
        /** Length of the user-defined data.
         */
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

    }


    /** Configuration of the injected media stream.
     */
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

        /** Width of the injected stream in the live interactive streaming. The default value is 0 (same width as the original stream).
         */
        public int width { set; get; }

        /** Height of the injected stream in the live interactive streaming. The default value is 0 (same height as the original stream).
         */
        public int height { set; get; }

        /** Video GOP (in frames) of the injected stream in the live interactive streaming. The default value is 30 fps.
         */
        public int videoGop { set; get; }

        /** Video frame rate of the injected stream in the live interactive streaming. The default value is 15 fps.
         */
        public int videoFramerate { set; get; }

        /** Video bitrate of the injected stream in the live interactive streaming. The default value is 400 Kbps.
         @note The setting of the video bitrate is closely linked to the resolution. If the video bitrate you set is beyond a reasonable range, the SDK sets it within a reasonable range.
         */
        public int videoBitrate { set; get; }

        /** Audio-sample rate of the injected stream in the live interactive streaming: #AUDIO_SAMPLE_RATE_TYPE. The default value is 48000 Hz.
         @note We recommend setting the default value.
         */
        public AUDIO_SAMPLE_RATE_TYPE audioSampleRate { set; get; }

        /** Audio bitrate of the injected stream in the live interactive streaming. The default value is 48.
         @note We recommend setting the default value.
         */
        public int audioBitrate { set; get; }

        /** Audio channels in the live interactive streaming.
         - 1: (Default) Mono
         - 2: Two-channel stereo
         @note We recommend setting the default value.
         */
        public int audioChannels { set; get; }
    }

    /** The video stream lifecycle of CDN Live.
 */
    public enum RTMP_STREAM_LIFE_CYCLE_TYPE
    {
        /** Bound to the channel lifecycle.
        */
        RTMP_STREAM_LIFE_CYCLE_BIND2CHANNEL = 1,
        /** Bound to the owner identity of the RTMP stream.
        */
        RTMP_STREAM_LIFE_CYCLE_BIND2OWNER = 2,
    };

    /** The definition of PublisherConfiguration.
*/
    public class PublisherConfiguration
    {
        /** Width of the output data stream set for CDN Live. The default value is
        360.
        */
        public int width { set; get; }
        /** Height of the output data stream set for CDN Live. The default value is
        640.
        */
        public int height { set; get; }
        /** Frame rate of the output data stream set for CDN Live. The default value
        is 15 fps.
        */
        public int framerate { set; get; }
        /** Bitrate of the output data stream set for CDN Live. The default value is
        500 Kbps.
        */
        public int bitrate { set; get; }
        /** The default layout:
        - 0: Tile horizontally
        - 1: Layered windows
        - 2: Tile vertically
        */
        public int defaultLayout { set; get; }
        /** The video stream lifecycle of CDN Live: RTMP_STREAM_LIFE_CYCLE_TYPE
        */
        public int lifecycle { set; get; }
        /** Whether the current user is the owner of the RTMP stream:
        - True: Yes (default). The push-stream configuration takes effect.
        - False: No. The push-stream configuration will not work.
        */
        public bool owner { set; get; }
        /** Width of the stream to be injected. Set it as 0.
        */
        public int injectStreamWidth { set; get; }
        /** Height of the stream to be injected. Set it as 0.
        */
        public int injectStreamHeight { set; get; }
        /** URL address of the stream to be injected to the channel.
        */
        public string injectStreamUrl { set; get; }
        /** Push-stream URL address for the picture-in-picture layouts. The default
        value is NULL.
        */
        public string publishUrl { set; get; }
        /** Push-stream URL address of the original stream which does not require
         picture-blending. The default value is NULL.
         */
        public string rawStreamUrl { set; get; }
        /** Reserved field. The default value is NULL.
        */
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
        /** The rear camera. */
        CAMERA_REAR = 0,
        /** The front camera. */
        CAMERA_FRONT = 1,
    };

    /** The cloud proxy type.
    *
    * @since v3.3.0
    */
    public enum CLOUD_PROXY_TYPE
    {
        /** 0: Do not use the cloud proxy.
        */
        NONE_PROXY = 0,
        /** 1: The cloud proxy for the UDP protocol.
        */
        UDP_PROXY = 1,
        /// @cond
        /** 2: The cloud proxy for the TCP (encrypted) protocol.
        */
        TCP_PROXY = 2,
        /// @endcond
    };

    /** Camera capturer configuration.
     */
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

        /** Camera direction settings (for Android/iOS only). See: #CAMERA_DIRECTION. */
        public CAMERA_DIRECTION cameraDirection { set; get; }
    }

    public class ScreenCaptureConfiguration
    {
        public ScreenCaptureConfiguration()
        {
            isCaptureWindow = false;
            displayId = 0;
        }

        public bool isCaptureWindow { set; get; } // true - capture window, false - capture display
        public uint displayId { set; get; } // MacOS only
        public Rectangle screenRect { set; get; } //Windows only
        public uint windowId { set; get; }
        public ScreenCaptureParameters parameters { set; get; }
        public Rectangle regionRect { set; get; }
    }

    public class SIZE
    {
        /** The width of the screen shot.
         */
        public int width { set; get; }
        /** The width of the screen shot.
         */
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
        /** in Mac: pointer to NSNumber */
        public view_t sourceId { set; get; }
        public string sourceName { set; get; }
        public ThumbImageBuffer thumbImage { set; get; }
        public ThumbImageBuffer iconImage { set; get; }

        public string processPath { set; get; }
        public string sourceTitle { set; get; }
        public bool primaryMonitor { set; get; }
        public bool isOccluded { set; get; }

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
        }
    };

    public class IScreenCaptureSourceList
    {
        public uint getCount() { return 0; }
        public ScreenCaptureSourceInfo getSourceInfo(uint index) { return null; }
        public void release() { }
    };

    public class AdvancedAudioOptions : OptionalJsonParse
    {
        /**
         * Audio processing channels, only support 1 or 2.
         */
        public Optional<int> audioProcessingChannels = new Optional<int>();

        public override void ToJson(JsonWriter writer)
        {
            if (this.audioProcessingChannels.HasValue())
            {
                writer.WritePropertyName("audioProcessingChannels");
                writer.Write(this.audioProcessingChannels.GetValue());
            }
        }

    }
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


    /**
    * The channel media options.
    */
    public class ChannelMediaOptions : OptionalJsonParse
    {
        /**
         * Determines whether to publish the video of the camera track.
         * - true: Publish the video track of the camera capturer.
         * - false: (Default) Do not publish the video track of the camera capturer.
         */
        public Optional<bool> publishCameraTrack = new Optional<bool>();

        /**
         * Determines whether to publish the video of the secondary camera track.
         * - true: Publish the video track of the secondary camera capturer.
         * - false: (Default) Do not publish the video track of the secondary camera capturer.
         */
        public Optional<bool> publishSecondaryCameraTrack = new Optional<bool>();

        /**
        * Determines whether to publish the recorded audio.
        * - true: Publish the recorded audio.
        * - false: (Default) Do not publish the recorded audio.
        */
        public Optional<bool> publishMicrophoneTrack = new Optional<bool>();

        /**
        * Determines whether to publish the video track of the screen capturer.
        * - true: Publish the video track of the screen capturer.
        * - false: (Default) Do not publish the video track of the screen capturer.
        *   only in android or iPhone
         */

        public Optional<bool> publishScreenCaptureVideo = new Optional<bool>();

        /**
        * Determines whether to publish the audio track of the screen capturer.
        * - true: Publish the video audio of the screen capturer.
        * - false: (Default) Do not publish the audio track of the screen capturer.
        *   only in android or iPhone
        */
        public Optional<bool> publishScreenCaptureAudio = new Optional<bool>();


        /**
         * Determines whether to publish the video of the screen track.
        * - true: Publish the video track of the screen capturer.
        * - false: (Default) Do not publish the video track of the screen capturer.
        *   only not in android or iPhone
        */
        public Optional<bool> publishScreenTrack = new Optional<bool>();

        /**
        * Determines whether to publish the video of the secondary screen track.
        * - true: Publish the video track of the secondary screen capturer.
        * - false: (Default) Do not publish the video track of the secondary screen capturer.
        *  only not in android or iPhone
        */
        public Optional<bool> publishSecondaryScreenTrack = new Optional<bool>();


        /**
        * Determines whether to publish the audio of the custom audio track.
        * - true: Publish the audio of the custom audio track.
        * - false: (Default) Do not publish the audio of the custom audio track.
        */
        public Optional<bool> publishCustomAudioTrack = new Optional<bool>();

        /**
        * Determines the source id of the custom audio, default is 0.
        */
        public Optional<int> publishCustomAudioSourceId = new Optional<int>();

        /**
         * Determines whether to enable AEC when publish custom audio track.
         * - true: Enable AEC.
         * - false: (Default) Do not enable AEC.
         */
        public Optional<bool> publishCustomAudioTrackEnableAec = new Optional<bool>();

        /**
       * Determines whether to publish direct custom audio track.
       * - true: publish.
       * - false: (Default) Do not publish.
       */
        public Optional<bool> publishDirectCustomAudioTrack = new Optional<bool>();

        /**
        * Determines whether to publish AEC custom audio track.
        * - true: Publish AEC track.
        * - false: (Default) Do not publish AEC track.
        */
        public Optional<bool> publishCustomAudioTrackAec = new Optional<bool>();

        /**
         * Determines whether to publish the video of the custom video track.
         * - true: Publish the video of the custom video track.
         * - false: (Default) Do not publish the video of the custom video track.
         */
        public Optional<bool> publishCustomVideoTrack = new Optional<bool>();

        /**
         * Determines whether to publish the video of the encoded video track.
         * - true: Publish the video of the encoded video track.
         * - false: (default) Do not publish the video of the encoded video track.
         */
        public Optional<bool> publishEncodedVideoTrack = new Optional<bool>();

        /**
        * Determines whether to publish the audio track of media player source.
        * - true: Publish the audio track of media player source.
        * - false: (default) Do not publish the audio track of media player source.
        */
        public Optional<bool> publishMediaPlayerAudioTrack = new Optional<bool>();

        /**
        * Determines whether to publish the video track of media player source.
        * - true: Publish the video track of media player source.
        * - false: (default) Do not publish the video track of media player source.
        */
        public Optional<bool> publishMediaPlayerVideoTrack = new Optional<bool>();

        /**
        * Determines whether to publish the local transcoded video track.
        * - true: Publish the video track of local transcoded video track.
        * - false: (default) Do not publish the local transcoded video track.
        */
        public Optional<bool> publishTrancodedVideoTrack = new Optional<bool>();

        /**
         * Determines whether to subscribe to all audio streams automatically. It can replace calling \ref IRtcEngine::setDefaultMuteAllRemoteAudioStreams
         * "setDefaultMuteAllRemoteAudioStreams" before joining a channel.
         * - true: Subscribe to all audio streams automatically.
         * - false: (Default) Do not subscribe to any audio stream automatically.
         */
        public Optional<bool> autoSubscribeAudio = new Optional<bool>();

        /**
         * Determines whether to subscribe to all video streams automatically. It can replace calling \ref IRtcEngine::setDefaultMuteAllRemoteVideoStreams
         * "setDefaultMuteAllRemoteVideoStreams" before joining a channel.
         * - true: Subscribe to all video streams automatically.
         * - false: (Default) do not subscribe to any video stream automatically.
         */
        public Optional<bool> autoSubscribeVideo = new Optional<bool>();

        /**
         * Determines whether to enable audio recording or playout.
         * - true: It's used to publish audio and mix microphone, or subscribe audio and playout
         * - false: It's used to publish extenal audio frame only without mixing microphone, or no need audio device to playout audio either
         */
        public Optional<bool> enableAudioRecordingOrPlayout = new Optional<bool>();

        /**
        * Determines which media player source should be published.
        * - DEFAULT_PLAYER_ID(0) is default.
        */
        public Optional<int> publishMediaPlayerId = new Optional<int>();

        /**
         * The client role type: #CLIENT_ROLE_TYPE.
         */
        public Optional<CLIENT_ROLE_TYPE> clientRoleType = new Optional<CLIENT_ROLE_TYPE>();

        /**
         * The audience latency level type. See \ref agora::rtc::AUDIENCE_LATENCY_LEVEL_TYPE "AUDIENCE_LATENCY_LEVEL_TYPE"
         */
        public Optional<AUDIENCE_LATENCY_LEVEL_TYPE> audienceLatencyLevel = new Optional<AUDIENCE_LATENCY_LEVEL_TYPE>();

        /**
         * The default video stream type: #VIDEO_STREAM_TYPE.
         */
        public Optional<VIDEO_STREAM_TYPE> defaultVideoStreamType = new Optional<VIDEO_STREAM_TYPE>();

        /**
         * The channel profile: #CHANNEL_PROFILE_TYPE.
         */
        public Optional<CHANNEL_PROFILE_TYPE> channelProfile = new Optional<CHANNEL_PROFILE_TYPE>();

        /**
         * The delay in ms for sending audio frames. This is used for explicit control of A/V sync.
         * To switch off the delay, set the value to zero.
         */
        public Optional<int> audioDelayMs = new Optional<int>();

        /**
         * The delay in ms for sending media player audio frames. This is used for explicit control of A/V sync.
         * To switch off the delay, set the value to zero.
         */
        public Optional<int> mediaPlayerAudioDelayMs = new Optional<int>();

        /**
         * The token
         */
        public Optional<string> token = new Optional<string>();

        /**
         * Enable media packet encryption.
         * This parameter is ignored when calling function updateChannelMediaOptions()
         * - false is default.
         */
        public Optional<bool> enableBuiltInMediaEncryption = new Optional<bool>();

        /**
         * Determines whether to publish the sound of the rhythm player to remote users.
         * - true: (Default) Publish the sound of the rhythm player.
         * - false: Do not publish the sound of the rhythm player.
         */
        public Optional<bool> publishRhythmPlayerTrack = new Optional<bool>();

        /**
        * This mode is only used for audience. In PK mode, client might join one
        * channel as broadcaster, and join another channel as interactive audience to
        * achieve low lentancy and smooth video from remote user.
        * - true: Enable low lentancy and smooth video when joining as an audience.
        * - false: (Default) Use default settings for audience role.
        */
        public Optional<bool> isInteractiveAudience = new Optional<bool>();


        /**
        * The custom video track id which will used to publish or preview
        */
        public Optional<video_track_id_t> customVideoTrackId = new Optional<video_track_id_t>();

        /**
        * Determines whether local audio stream can be filtered .
        * - true: (Default) Can be filtered when audio level is low.
        * - false: Do not Filter this audio stream.
        */
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

    }

    /** The local  proxy mode type. */
    public enum LOCAL_PROXY_MODE
    {
        /** 0: Connect local proxy with high priority, if not connected to local proxy, fallback to sdrtn.
        */
        kConnectivityFirst = 0,
        /** 1: Only connect local proxy
        */
        kLocalOnly = 1,
    };

    public enum PROXY_TYPE
    {
        /** 0: Do not use the cloud proxy.
         */
        NONE_PROXY_TYPE = 0,
        /** 1: The cloud proxy for the UDP protocol.
         */
        UDP_PROXY_TYPE = 1,
        /// @cond
        /** 2: The cloud proxy for the TCP (encrypted) protocol.
         */
        TCP_PROXY_TYPE = 2,
        /// @endcond
        /** 3: The local proxy.
         */
        LOCAL_PROXY_TYPE = 3,
        /// @endcond
        /** 4: auto fallback to tcp cloud proxy
         */
        TCP_PROXY_AUTO_FALLBACK_TYPE = 4,
    };

    public class LocalAccessPointConfiguration
    {
        /** local access point ip address list.
        */
        public string[] ipList { set; get; }
        /** the number of local access point ip address.
        */
        public int ipListSize { set; get; }
        /** local access point domain list.
        */
        public string[] domainList { set; get; }
        /** the number of local access point domain.
        */
        public int domainListSize { set; get; }
        /** certificate domain name installed on specific local access point. pass "" means using sni domain on specific local access point
        */
        public string verifyDomainName { set; get; }
        /** local proxy connection mode, connectivity first or local only.
        */
        public LOCAL_PROXY_MODE mode { set; get; }

        public LocalAccessPointConfiguration()
        {
            ipList = new string[0];
            ipListSize = 0;
            domainList = new string[0];
            domainListSize = 0;
            verifyDomainName = "";
            mode = LOCAL_PROXY_MODE.kConnectivityFirst;
        }
    };

    /**
    * The leave channel options.
    */
    public class LeaveChannelOptions
    {
        public LeaveChannelOptions()
        {
            stopAudioMixing = true;
            stopAllEffect = true;
            stopMicrophoneRecording = true;
        }

        /**
        * Determines whether to stop playing and mixing the music file when leave channel.
        * - true: (Default) Stop playing and mixing the music file.
        * - false: Do not stop playing and mixing the music file.
        */
        public bool stopAudioMixing { set; get; }
        /**
        * Determines whether to stop all music effects when leave channel.
        * - true: (Default) Stop all music effects.
        * - false: Do not stop the music effect.
        */
        public bool stopAllEffect { set; get; }
        /**
        * Determines whether to stop microphone recording when leave channel.
        * - true: (Default) Stop microphone recording.
        * - false: Do not stop microphone recording.
        */
        public bool stopMicrophoneRecording { set; get; }
    };


    //useless in C#
    /**
    * The IVideoDeviceCollection class.
    */
    //public class IVideoDeviceCollection
    //{

    //    /**
    //     * Gets the total number of the indexed video capture devices in the system.
    //     *
    //     * @return The total number of the indexed video capture devices.
    //     */
    //    public virtual int getCount() { return 0; }

    //    /**
    //     * Specifies a device with the device ID.
    //     *
    //     * @param deviceIdUTF8 The device ID.
    //     * @return
    //     * - 0: Success.
    //     * - < 0: Failure.
    //     */
    //    public virtual int setDevice(string deviceIdUTF8) { return 0; }

    //    /**
    //     * Gets the information of a specified video capture device.
    //     *
    //     * @param index An input parameter that specifies the device. It is a specified
    //     * index and must be smaller than the return value of \ref getCount "getCount".
    //     * @param deviceNameUTF8 An output parameter that indicates the device name.
    //     * @param deviceIdUTF8 An output parameter that indicates the device ID.
    //     * @return
    //     * - 0: Success.
    //     * - < 0: Failure.
    //     */
    //    public virtual int getDevice(int index, string deviceNameUTF8, string deviceIdUTF8) { return 0; }

    //    /**
    //     * Releases all IVideoDeviceCollection resources.
    //     */
    //    public virtual void release() { }
    //};
    /** Definition of RtcEngineContext.
   */
    public class RtcEngineContext : OptionalJsonParse
    {
        public RtcEngineContext()
        {
            eventHandler = null;
            appId = "";
            context = 0;

            channelProfile = CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING;
            audioScenario = AUDIO_SCENARIO_TYPE.AUDIO_SCENARIO_DEFAULT;
            areaCode = AREA_CODE.AREA_CODE_GLOB;
            logConfig = new LogConfig();
            useExternalEglContext = false;
        }


        public RtcEngineContext(string appId, UInt64 context,
            CHANNEL_PROFILE_TYPE channelProfile, AUDIO_SCENARIO_TYPE audioScenario,
            AREA_CODE areaCode = AREA_CODE.AREA_CODE_CN,
            LogConfig logConfig = null)
        {
            this.appId = appId;
            this.context = context;
            this.channelProfile = channelProfile;
            this.audioScenario = audioScenario;
            this.areaCode = areaCode;
            this.logConfig = logConfig ?? new LogConfig();
        }

        /**
        * The event handler for IRtcEngine.
        */
        private IRtcEngineEventHandler eventHandler = null;
        /**
         * The App ID issued to you by Agora. See [How to get the App ID](https://docs.agora.io/en/Agora%20Platform/token#get-an-app-id).
         * Only users in apps with the same App ID can join the same channel and communicate with each other. Use an App ID to create only
         * one `IRtcEngine` instance. To change your App ID, call `release` to destroy the current `IRtcEngine` instance and then call `createAgoraRtcEngine`
         * and `initialize` to create an `IRtcEngine` instance with the new App ID.
         */
        public string appId { set; get; }

        /**
        * - For Android, it is the context of Activity or Application.
        * - For Windows, it is the window handle of app. Once set, this parameter enables you to plug
        * or unplug the video devices while they are powered.
        */
        public UInt64 context { set; get; }


        /**
        * The channel profile. See #CHANNEL_PROFILE_TYPE.
        */
        public CHANNEL_PROFILE_TYPE channelProfile { set; get; }

        /**
        * The audio application scenario. See #AUDIO_SCENARIO_TYPE.
        *
        * @note Agora recommends the following scenarios:
        * - `AUDIO_SCENARIO_DEFAULT(0)`
        * - `AUDIO_SCENARIO_GAME_STREAMING(3)`
        * - `AUDIO_SCENARIO_HIGH_DEFINITION(6)`
        */
        public AUDIO_SCENARIO_TYPE audioScenario { set; get; }


        /**
        * The region for connection. This advanced feature applies to scenarios that
        * have regional restrictions.
        *
        * For the regions that Agora supports, see #AREA_CODE.
        *
        * After specifying the region, the SDK connects to the Agora servers within
        * that region.
        */
        public AREA_CODE areaCode { set; get; }

        /**
        * The region for connection. This advanced feature applies to scenarios that have regional restrictions.
        *
        * For the regions that Agora supports, see #AREA_CODE. After specifying the region, the SDK connects to the Agora servers within that region.
        *
        * @note The SDK supports specify only one region.
        */
        //private uint _areaCode;

        public LogConfig logConfig { set; get; }


        public Optional<THREAD_PRIORITY_TYPE> threadPriority = new Optional<THREAD_PRIORITY_TYPE>();

        /**
         * Whether use egl context in current thread as sdk‘s root egl context 
         * which shared by all egl related modules. eg. camera capture, video renderer.
         * 
         * @note
         * This property applies to Android only.
         */
        public bool useExternalEglContext { set; get; }


        public override void ToJson(JsonWriter writer)
        {
            writer.WriteObjectStart();

            writer.WritePropertyName("appId");
            writer.Write(this.appId);

            writer.WritePropertyName("context");
            writer.Write((UInt64)this.context);

            writer.WritePropertyName("channelProfile");
            this.WriteEnum(writer, this.channelProfile);

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

    }
    public enum METADATA_TYPE
    {
        UNKNOWN_METADATA = -1,
        VIDEO_METADATA = 0,
    };

    public enum MAX_METADATA_SIZE_TYPE
    {
        MAX_METADATA_SIZE_IN_BYTE = 1024
    };

    /** Metadata.
       */
    public class Metadata
    {
        /** The User ID that sent the metadata.
            * For the receiver: the remote track User ID.
            * For the sender: ignore it.
            */
        public uint uid;
        /** The metadata size.
            */
        public uint size;
        /** The metadata buffer.
            */
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
        /** The NTP timestamp (ms) that the metadata sends.
            *
            * @note If the metadata receiver is audience, this parameter does not work.
            */
        public long timeStampMs;
    };

    // The error codes for media streaming
    // GENERATED_JAVA_ENUM_PACKAGE: io.agora.streaming
    public enum DIRECT_CDN_STREAMING_ERROR
    {
        // No error occurs.
        DIRECT_CDN_STREAMING_ERROR_OK = 0,
        // A general error occurs (no specified reason).
        DIRECT_CDN_STREAMING_ERROR_FAILED = 1,
        // Audio publication error.
        DIRECT_CDN_STREAMING_ERROR_AUDIO_PUBLICATION = 2,
        // Video publication error.
        DIRECT_CDN_STREAMING_ERROR_VIDEO_PUBLICATION = 3,

        DIRECT_CDN_STREAMING_ERROR_NET_CONNECT = 4,
        // Already exist stream name.
        DIRECT_CDN_STREAMING_ERROR_BAD_NAME = 5,
    };


    // The connection state of media streaming
    // GENERATED_JAVA_ENUM_PACKAGE: io.agora.streaming
    public enum DIRECT_CDN_STREAMING_STATE
    {

        DIRECT_CDN_STREAMING_STATE_IDLE = 0,

        DIRECT_CDN_STREAMING_STATE_RUNNING = 1,

        DIRECT_CDN_STREAMING_STATE_STOPPED = 2,

        DIRECT_CDN_STREAMING_STATE_FAILED = 3,

        DIRECT_CDN_STREAMING_STATE_RECOVERING = 4,
    };


    /**
 * The statistics of the Direct Cdn Streams.
 */
    public class DirectCdnStreamingStats
    {
        /**
         * Width of the video pushed by rtmp.
         */
        public int videoWidth { set; get; }

        /**
         * Height of the video pushed by rtmp.
         */
        public int videoHeight { set; get; }

        /**
         * The frame rate of the video pushed by rtmp.
         */
        public int fps { set; get; }

        /**
         * Real-time bit rate of the video streamed by rtmp.
         */
        public int videoBitrate { set; get; }

        /**
         * Real-time bit rate of the audio pushed by rtmp.
         */
        public int audioBitrate { set; get; }
    };


    public class DirectCdnStreamingMediaOptions : OptionalJsonParse
    {
        /**
         * Determines whether to publish the video of the camera track.
         * - true: Publish the video track of the camera capturer.
         * - false: (Default) Do not publish the video track of the camera capturer.
         */
        public Optional<bool> publishCameraTrack = new Optional<bool>();
        /**
         * Determines whether to publish the recorded audio.
         * - true: Publish the recorded audio.
         * - false: (Default) Do not publish the recorded audio.
         */
        public Optional<bool> publishMicrophoneTrack = new Optional<bool>();
        /**
         * Determines whether to publish the audio of the custom audio track.
         * - true: Publish the audio of the custom audio track.
         * - false: (Default) Do not publish the audio of the custom audio track.
         */
        public Optional<bool> publishCustomAudioTrack = new Optional<bool>();
        /**
         * Determines whether to publish the video of the custom video track.
         * - true: Publish the video of the custom video track.
         * - false: (Default) Do not publish the video of the custom video track.
         */
        public Optional<bool> publishCustomVideoTrack = new Optional<bool>();
        /**
        * Determines whether to publish the audio track of media player source.
        * - true: Publish the audio track of media player source.
        * - false: (default) Do not publish the audio track of media player source.
        */
        public Optional<bool> publishMediaPlayerAudioTrack = new Optional<bool>();
        /**
        * Determines which media player source should be published.
        * - DEFAULT_PLAYER_ID(0) is default.
        */
        public Optional<int> publishMediaPlayerId = new Optional<int>();

        /**
        * The custom video track id which will used to publish
        */
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

    // The following types are either deprecated or not implmented yet.
    public enum QUALITY_REPORT_FORMAT_TYPE
    {
        /** 0: The quality report in JSON format,
         */
        QUALITY_REPORT_JSON = 0,
        /** 1: The quality report in HTML format.
         */
        QUALITY_REPORT_HTML = 1,
    };

    /** Media device states. */
    public enum MEDIA_DEVICE_STATE_TYPE
    {
        /** 0: The device is available
         */
        MEDIA_DEVICE_STATE_IDLE = 0,
        /** 1: The device is active.
         */
        MEDIA_DEVICE_STATE_ACTIVE = 1,
        /** 2: The device is disabled.
         */
        MEDIA_DEVICE_STATE_DISABLED = 2,
        /** 4: The device is not present.
         */
        MEDIA_DEVICE_STATE_NOT_PRESENT = 4,
        /** 8: The device is unplugged.
         */
        MEDIA_DEVICE_STATE_UNPLUGGED = 8
    };

    public enum VIDEO_PROFILE_TYPE
    {
        /** 0: 160 x 120  @ 15 fps */      // res       fps
        VIDEO_PROFILE_LANDSCAPE_120P = 0,  // 160x120   15
        /** 2: 120 x 120 @ 15 fps */
        VIDEO_PROFILE_LANDSCAPE_120P_3 = 2,   // 120x120   15
        /** 10: 320 x 180 @ 15 fps */
        VIDEO_PROFILE_LANDSCAPE_180P = 10,    // 320x180   15
        /** 12: 180 x 180  @ 15 fps */
        VIDEO_PROFILE_LANDSCAPE_180P_3 = 12,  // 180x180   15
        /** 13: 240 x 180 @ 15 fps */
        VIDEO_PROFILE_LANDSCAPE_180P_4 = 13,  // 240x180   15
        /** 20: 320 x 240 @ 15 fps */
        VIDEO_PROFILE_LANDSCAPE_240P = 20,    // 320x240   15
        /** 22: 240 x 240 @ 15 fps */
        VIDEO_PROFILE_LANDSCAPE_240P_3 = 22,  // 240x240   15
        /** 23: 424 x 240 @ 15 fps */
        VIDEO_PROFILE_LANDSCAPE_240P_4 = 23,  // 424x240   15
        /** 30: 640 x 360 @ 15 fps */
        VIDEO_PROFILE_LANDSCAPE_360P = 30,  // 640x360   15
        /** 32: 360 x 360 @ 15 fps */
        VIDEO_PROFILE_LANDSCAPE_360P_3 = 32,  // 360x360   15
        /** 33: 640 x 360 @ 30 fps */
        VIDEO_PROFILE_LANDSCAPE_360P_4 = 33,  // 640x360   30
        /** 35: 360 x 360 @ 30 fps */
        VIDEO_PROFILE_LANDSCAPE_360P_6 = 35,  // 360x360   30
        /** 36: 480 x 360 @ 15 fps */
        VIDEO_PROFILE_LANDSCAPE_360P_7 = 36,  // 480x360   15
        /** 37: 480 x 360 @ 30 fps */
        VIDEO_PROFILE_LANDSCAPE_360P_8 = 37,  // 480x360   30
        /** 38: 640 x 360 @ 15 fps */
        VIDEO_PROFILE_LANDSCAPE_360P_9 = 38,   // 640x360   15
        /** 39: 640 x 360 @ 24 fps */
        VIDEO_PROFILE_LANDSCAPE_360P_10 = 39,  // 640x360   24
        /** 100: 640 x 360 @ 24 fps */
        VIDEO_PROFILE_LANDSCAPE_360P_11 = 100,  // 640x360   24
        /** 40: 640 x 480 @ 15 fps */
        VIDEO_PROFILE_LANDSCAPE_480P = 40,  // 640x480   15
        /** 42: 480 x 480 @ 15 fps */
        VIDEO_PROFILE_LANDSCAPE_480P_3 = 42,  // 480x480   15
        /** 43: 640 x 480 @ 30 fps */
        VIDEO_PROFILE_LANDSCAPE_480P_4 = 43,  // 640x480   30
        /** 45: 480 x 480 @ 30 fps */
        VIDEO_PROFILE_LANDSCAPE_480P_6 = 45,  // 480x480   30
        /** 47: 848 x 480 @ 15 fps */
        VIDEO_PROFILE_LANDSCAPE_480P_8 = 47,  // 848x480   15
        /** 48: 848 x 480 @ 30 fps */
        VIDEO_PROFILE_LANDSCAPE_480P_9 = 48,  // 848x480   30
        /** 49: 640 x 480 @ 10 fps */
        VIDEO_PROFILE_LANDSCAPE_480P_10 = 49,  // 640x480   10
        /** 50: 1280 x 720 @ 15 fps */
        VIDEO_PROFILE_LANDSCAPE_720P = 50,  // 1280x720  15
        /** 52: 1280 x 720 @ 30 fps */
        VIDEO_PROFILE_LANDSCAPE_720P_3 = 52,  // 1280x720  30
        /** 54: 960 x 720 @ 15 fps */
        VIDEO_PROFILE_LANDSCAPE_720P_5 = 54,  // 960x720   15
        /** 55: 960 x 720 @ 30 fps */
        VIDEO_PROFILE_LANDSCAPE_720P_6 = 55,  // 960x720   30
        /** 60: 1920 x 1080 @ 15 fps */
        VIDEO_PROFILE_LANDSCAPE_1080P = 60,  // 1920x1080 15
        /** 62: 1920 x 1080 @ 30 fps */
        VIDEO_PROFILE_LANDSCAPE_1080P_3 = 62,  // 1920x1080 30
        /** 64: 1920 x 1080 @ 60 fps */
        VIDEO_PROFILE_LANDSCAPE_1080P_5 = 64,  // 1920x1080 60
        /** 66: 2560 x 1440 @ 30 fps */
        VIDEO_PROFILE_LANDSCAPE_1440P = 66,  // 2560x1440 30
        /** 67: 2560 x 1440 @ 60 fps */
        VIDEO_PROFILE_LANDSCAPE_1440P_2 = 67,  // 2560x1440 60
        /** 70: 3840 x 2160 @ 30 fps */
        VIDEO_PROFILE_LANDSCAPE_4K = 70,  // 3840x2160 30
        /** 72: 3840 x 2160 @ 60 fps */
        VIDEO_PROFILE_LANDSCAPE_4K_3 = 72,     // 3840x2160 60
        /** 1000: 120 x 160 @ 15 fps */
        VIDEO_PROFILE_PORTRAIT_120P = 1000,    // 120x160   15
        /** 1002: 120 x 120 @ 15 fps */
        VIDEO_PROFILE_PORTRAIT_120P_3 = 1002,  // 120x120   15
        /** 1010: 180 x 320 @ 15 fps */
        VIDEO_PROFILE_PORTRAIT_180P = 1010,    // 180x320   15
        /** 1012: 180 x 180 @ 15 fps */
        VIDEO_PROFILE_PORTRAIT_180P_3 = 1012,  // 180x180   15
        /** 1013: 180 x 240 @ 15 fps */
        VIDEO_PROFILE_PORTRAIT_180P_4 = 1013,  // 180x240   15
        /** 1020: 240 x 320 @ 15 fps */
        VIDEO_PROFILE_PORTRAIT_240P = 1020,  // 240x320   15
        /** 1022: 240 x 240 @ 15 fps */
        VIDEO_PROFILE_PORTRAIT_240P_3 = 1022,  // 240x240   15
        /** 1023: 240 x 424 @ 15 fps */
        VIDEO_PROFILE_PORTRAIT_240P_4 = 1023,  // 240x424   15
        /** 1030: 360 x 640 @ 15 fps */
        VIDEO_PROFILE_PORTRAIT_360P = 1030,  // 360x640   15
        /** 1032: 360 x 360 @ 15 fps */
        VIDEO_PROFILE_PORTRAIT_360P_3 = 1032,  // 360x360   15
        /** 1033: 360 x 640 @ 30 fps */
        VIDEO_PROFILE_PORTRAIT_360P_4 = 1033,  // 360x640   30
        /** 1035: 360 x 360 @ 30 fps */
        VIDEO_PROFILE_PORTRAIT_360P_6 = 1035,  // 360x360   30
        /** 1036: 360 x 480 @ 15 fps */
        VIDEO_PROFILE_PORTRAIT_360P_7 = 1036,  // 360x480   15
        /** 1037: 360 x 480 @ 30 fps */
        VIDEO_PROFILE_PORTRAIT_360P_8 = 1037,  // 360x480   30
        /** 1038: 360 x 640 @ 15 fps */
        VIDEO_PROFILE_PORTRAIT_360P_9 = 1038,  // 360x640   15
        /** 1039: 360 x 640 @ 24 fps */
        VIDEO_PROFILE_PORTRAIT_360P_10 = 1039,  // 360x640   24
        /** 1100: 360 x 640 @ 24 fps */
        VIDEO_PROFILE_PORTRAIT_360P_11 = 1100,  // 360x640   24
        /** 1040: 480 x 640 @ 15 fps */
        VIDEO_PROFILE_PORTRAIT_480P = 1040,  // 480x640   15
        /** 1042: 480 x 480 @ 15 fps */
        VIDEO_PROFILE_PORTRAIT_480P_3 = 1042,  // 480x480   15
        /** 1043: 480 x 640 @ 30 fps */
        VIDEO_PROFILE_PORTRAIT_480P_4 = 1043,  // 480x640   30
        /** 1045: 480 x 480 @ 30 fps */
        VIDEO_PROFILE_PORTRAIT_480P_6 = 1045,  // 480x480   30
        /** 1047: 480 x 848 @ 15 fps */
        VIDEO_PROFILE_PORTRAIT_480P_8 = 1047,  // 480x848   15
        /** 1048: 480 x 848 @ 30 fps */
        VIDEO_PROFILE_PORTRAIT_480P_9 = 1048,  // 480x848   30
        /** 1049: 480 x 640 @ 10 fps */
        VIDEO_PROFILE_PORTRAIT_480P_10 = 1049,  // 480x640   10
        /** 1050: 720 x 1280 @ 15 fps */
        VIDEO_PROFILE_PORTRAIT_720P = 1050,  // 720x1280  15
        /** 1052: 720 x 1280 @ 30 fps */
        VIDEO_PROFILE_PORTRAIT_720P_3 = 1052,  // 720x1280  30
        /** 1054: 720 x 960 @ 15 fps */
        VIDEO_PROFILE_PORTRAIT_720P_5 = 1054,  // 720x960   15
        /** 1055: 720 x 960 @ 30 fps */
        VIDEO_PROFILE_PORTRAIT_720P_6 = 1055,  // 720x960   30
        /** 1060: 1080 x 1920 @ 15 fps */
        VIDEO_PROFILE_PORTRAIT_1080P = 1060,    // 1080x1920 15
        /** 1062: 1080 x 1920 @ 30 fps */
        VIDEO_PROFILE_PORTRAIT_1080P_3 = 1062,  // 1080x1920 30
        /** 1064: 1080 x 1920 @ 60 fps */
        VIDEO_PROFILE_PORTRAIT_1080P_5 = 1064,  // 1080x1920 60
        /** 1066: 1440 x 2560 @ 30 fps */
        VIDEO_PROFILE_PORTRAIT_1440P = 1066,  // 1440x2560 30
        /** 1067: 1440 x 2560 @ 60 fps */
        VIDEO_PROFILE_PORTRAIT_1440P_2 = 1067,  // 1440x2560 60
        /** 1070: 2160 x 3840 @ 30 fps */
        VIDEO_PROFILE_PORTRAIT_4K = 1070,       // 2160x3840 30
        /** 1072: 2160 x 3840 @ 60 fps */
        VIDEO_PROFILE_PORTRAIT_4K_3 = 1072,  // 2160x3840 60
        /** Default 640 x 360 @ 15 fps */
        VIDEO_PROFILE_DEFAULT = VIDEO_PROFILE_LANDSCAPE_360P,
    };
    #endregion

}
