using System;
using System.Runtime.InteropServices;

namespace agorartc
{
    using view_t = UInt64;

    /** The uplink or downlink last-mile network probe test result. */
    public struct LastmileProbeOneWayResult
    {
	    /** The packet loss rate (%). */
        public uint packetLossRate { set; get; }

        /** The network jitter (ms). */
        public uint jitter { set; get; }

        /* The estimated available bandwidth (bps). */
        public uint availableBandwidth { set; get; }
    }

    /** The uplink and downlink last-mile network probe test result. */
    public struct LastmileProbeResult
    {
	    /** The state of the probe test. */
        public LASTMILE_PROBE_RESULT_STATE state { set; get; }

        /** The uplink last-mile network probe test result. */
        public LastmileProbeOneWayResult uplinkReport { set; get; }

        /** The downlink last-mile network probe test result. */
        public LastmileProbeOneWayResult downlinkReport { set; get; }

        /** The round-trip delay time (ms). */
        public uint rtt { set; get; }
    }

    /** Configurations of the last-mile network probe test. */
    public struct LastmileProbeConfig
    {
        /** Sets whether or not to test the uplink network. Some users, for example, the audience in a `LIVE_BROADCASTING` channel, do not need such a test:
		 - true: test.
		 - false: do not test. */
        public bool probeUplink { set; get; }

        /** Sets whether or not to test the downlink network:
		 - true: test.
		 - false: do not test. */
        public bool probeDownlink { set; get; }

        /** The expected maximum sending bitrate (bps) of the local user. The value ranges between 100000 and 5000000. We recommend setting this parameter according to the bitrate value set by \ref IRtcEngine::setVideoEncoderConfiguration "setVideoEncoderConfiguration". */
        public uint expectedUplinkBitrate { set; get; }

        /** The expected maximum receiving bitrate (bps) of the local user. The value ranges between 100000 and 5000000. */
        public uint expectedDownlinkBitrate { set; get; }
    }

    /** Properties of the audio volume information.

	 An array containing the user ID and volume information for each speaker.
	 */
    public struct AudioVolumeInfo
    {
        /**
		 User ID of the speaker. The uid of the local user is 0.
		 */
        public uint uid { set; get; }

        /** The volume of the speaker. The volume ranges between 0 (lowest volume) and 255 (highest volume).
		 */
        public uint volume { set; get; }

        /** Voice activity status of the local user.
		 * - 0: The local user is not speaking.
		 * - 1: The local user is speaking.
		 *
		 * @note
		 * - The `vad` parameter cannot report the voice activity status of the remote users. In the remote users' callback, `vad` = 0.
		 * - Ensure that you set `report_vad`(true) in the \ref agora::rtc::IRtcEngine::enableAudioVolumeIndication(int, int, bool) "enableAudioVolumeIndication" method to enable the voice activity detection of the local user.
		 */
        public uint vad { set; get; }


        /** The channel ID, which indicates which channel the speaker is in.
		 */
        public string channelId { set; get; }
    }

    /** Statistics of the channel.
	 */
    public struct RtcStats
    {
        /**
		 Call duration (s), represented by an aggregate value.
		 */
        public uint duration { set; get; }

        /**
		 Total number of bytes transmitted, represented by an aggregate value.
		 */
        public uint txBytes { set; get; }

        /**
		 Total number of bytes received, represented by an aggregate value.
		 */
        public uint rxBytes { set; get; }

        /** Total number of audio bytes sent (bytes), represented
		 * by an aggregate value.
		 */
        public uint txAudioBytes { set; get; }

        /** Total number of video bytes sent (bytes), represented
		 * by an aggregate value.
		 */
        public uint txVideoBytes { set; get; }

        /** Total number of audio bytes received (bytes) before
		 * network countermeasures, represented by an aggregate value.
		 */
        public uint rxAudioBytes { set; get; }

        /** Total number of video bytes received (bytes),
		 * represented by an aggregate value.
		 */
        public uint rxVideoBytes { set; get; }

        /**
		 Transmission bitrate (Kbps), represented by an instantaneous value.
		 */
        public ushort txKBitRate { set; get; }

        /**
		 Receive bitrate (Kbps), represented by an instantaneous value.
		 */
        public ushort rxKBitRate { set; get; }

        /**
		 Audio receive bitrate (Kbps), represented by an instantaneous value.
		 */
        public ushort rxAudioKBitRate { set; get; }

        /**
		 Audio transmission bitrate (Kbps), represented by an instantaneous value.
		 */
        public ushort txAudioKBitRate { set; get; }

        /**
		 Video receive bitrate (Kbps), represented by an instantaneous value.
		 */
        public ushort rxVideoKBitRate { set; get; }

        /**
		 Video transmission bitrate (Kbps), represented by an instantaneous value.
		 */
        public ushort txVideoKBitRate { set; get; }

        /** Client-server latency (ms)
		 */
        public ushort lastmileDelay { set; get; }

        /** The packet loss rate (%) from the local client to Agora's edge server,
		 * before using the anti-packet-loss method.
		 */
        public ushort txPacketLossRate { set; get; }

        /** The packet loss rate (%) from Agora's edge server to the local client,
		 * before using the anti-packet-loss method.
		 */
        public ushort rxPacketLossRate { set; get; }

        /** Number of users in the channel.

		 - `COMMUNICATION` profile: The number of users in the channel.
		 - `LIVE_BROADCASTING` profile:

		     -  If the local user is an audience: The number of users in the channel = The number of hosts in the channel + 1.
		     -  If the user is a host: The number of users in the channel = The number of hosts in the channel.
		 */
        public uint userCount { set; get; }

        /**
		 Application CPU usage (%).
		 */
        public double cpuAppUsage { set; get; }

        /**
		 System CPU usage (%).

		 In the multi-kernel environment, this member represents the average CPU usage.
		 The value **=** 100 **-** System Idle Progress in Task Manager (%).
		 */
        public double cpuTotalUsage { set; get; }

        /** The round-trip time delay from the client to the local router.
		 */
        public int gatewayRtt { set; get; }

        /**
		 The memory usage ratio of the app (%).
		 @note This value is for reference only. Due to system limitations, you may not get the value of this member.
		 */
        public double memoryAppUsageRatio { set; get; }

        /**
		 The memory usage ratio of the system (%).
		 @note This value is for reference only. Due to system limitations, you may not get the value of this member.
		 */
        public double memoryTotalUsageRatio { set; get; }

        /**
		 The memory usage of the app (KB).
		 @note This value is for reference only. Due to system limitations, you may not get the value of this member.
		 */
        public int memoryAppUsageInKbytes { set; get; }
    }

    /** Statistics of the local video stream.
	 */
    public struct LocalVideoStats
    {
        /** Bitrate (Kbps) sent in the reported interval, which does not include
		 * the bitrate of the retransmission video after packet loss.
		 */
        public int sentBitrate { set; get; }

        /** Frame rate (fps) sent in the reported interval, which does not include
		 * the frame rate of the retransmission video after packet loss.
		 */
        public int sentFrameRate { set; get; }

        /** The encoder output frame rate (fps) of the local video.
		 */
        public int encoderOutputFrameRate { set; get; }

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

        /** The encoding bitrate (Kbps), which does not include the bitrate of the
		 * re-transmission video after packet loss.
		 */
        public int encodedBitrate { set; get; }

        /** The width of the encoding frame (px).
		 */
        public int encodedFrameWidth { set; get; }

        /** The height of the encoding frame (px).
		 */
        public int encodedFrameHeight { set; get; }

        /** The value of the sent frames, represented by an aggregate value.
		 */
        public int encodedFrameCount { set; get; }

        /** The codec type of the local video:
		 * - VIDEO_CODEC_VP8 = 1: VP8.
		 * - VIDEO_CODEC_H264 = 2: (Default) H.264.
		 */
        public VIDEO_CODEC_TYPE codecType { set; get; }

        /** The video packet loss rate (%) from the local client to the Agora edge server before applying the anti-packet loss strategies.
		 */
        public ushort txPacketLossRate { set; get; }

        /** The capture frame rate (fps) of the local video.
		 */
        public int captureFrameRate { set; get; }
    }

    /** Statistics of the remote video stream.
	 */
    public struct RemoteVideoStats
    {
        /**
		 User ID of the remote user sending the video streams.
		 */
        public uint uid { set; get; }

        /** **DEPRECATED** Time delay (ms).
		 *
		 * In scenarios where audio and video is synchronized, you can use the value of
		 * `networkTransportDelay` and `jitterBufferDelay` in `RemoteAudioStats` to know the delay statistics of the remote video.
		 */
        public int delay { set; get; }

        /** Width (pixels) of the video stream.
		 */
        public int width { set; get; }

        /**
		 Height (pixels) of the video stream.
		 */
        public int height { set; get; }

        /**
		 Bitrate (Kbps) received since the last count.
		 */
        public int receivedBitrate { set; get; }

        /** The decoder output frame rate (fps) of the remote video.
		 */
        public int decoderOutputFrameRate { set; get; }

        /** The render output frame rate (fps) of the remote video.
		 */
        public int rendererOutputFrameRate { set; get; }

        /** Packet loss rate (%) of the remote video stream after using the anti-packet-loss method.
		 */
        public int packetLossRate { set; get; }

        /** The type of the remote video stream: #REMOTE_VIDEO_STREAM_TYPE
		 */
        public REMOTE_VIDEO_STREAM_TYPE rxStreamType { set; get; }

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
		 The total time (ms) when the remote user in the Communication profile or the remote
		 broadcaster in the Live-broadcast profile neither stops sending the video stream nor
		 disables the video module after joining the channel.

		 @since v3.0.1
		*/
        public int totalActiveTime { set; get; }

        /**
		 * The total publish duration (ms) of the remote video stream.
		 */
        public int publishDuration { set; get; }
    }

    /** Audio statistics of the local user */
    public struct LocalAudioStats
    {
        /** The number of channels.
		 */
        public int numChannels { set; get; }

        /** The sample rate (Hz).
		 */
        public int sentSampleRate { set; get; }

        /** The average sending bitrate (Kbps).
		 */
        public int sentBitrate { set; get; }

        /** The audio packet loss rate (%) from the local client to the Agora edge server before applying the anti-packet loss strategies.
		 */
        public ushort txPacketLossRate { set; get; }
    }

    /** Audio statistics of a remote user */
    public struct RemoteAudioStats
    {
        /** User ID of the remote user sending the audio streams.
		 *
		 */
        public uint uid { set; get; }

        /** Audio quality received by the user: #QUALITY_TYPE.
		 */
        public int quality { set; get; }

        /** Network delay (ms) from the sender to the receiver.
		 */
        public int networkTransportDelay { set; get; }

        /** Network delay (ms) from the receiver to the jitter buffer.
		 */
        public int jitterBufferDelay { set; get; }

        /** The audio frame loss rate in the reported interval.
		 */
        public int audioLossRate { set; get; }

        /** The number of channels.
		 */
        public int numChannels { set; get; }

        /** The sample rate (Hz) of the received audio stream in the reported
		 * interval.
		 */
        public int receivedSampleRate { set; get; }

        /** The average bitrate (Kbps) of the received audio stream in the
		 * reported interval. */
        public int receivedBitrate { set; get; }

        /** The total freeze time (ms) of the remote audio stream after the remote user joins the channel. In a session, audio freeze occurs when the audio frame loss rate reaches 4%.
		 */
        public int totalFrozenTime { set; get; }

        /** The total audio freeze time as a percentage (%) of the total time when the audio is available. */
        public int frozenRate { set; get; }

        /** The total time (ms) when the remote user in the `COMMUNICATION` profile or the remote host in
		 the `LIVE_BROADCASTING` profile neither stops sending the audio stream nor disables the audio module after joining the channel.
		 */
        public int totalActiveTime { set; get; }

        /**
		 * The total publish duration (ms) of the remote audio stream.
		 */
        public int publishDuration { set; get; }
    }

    /**
	 * Video dimensions.
	 */
    public struct VideoDimensions
    {
        public VideoDimensions(int width = 640, int height = 480)
        {
            this.width = width;
            this.height = height;
        }

        /** Width (pixels) of the video. */
        public int width { set; get; }

        /** Height (pixels) of the video. */
        public int height { set; get; }
    }

    /** Video encoder configurations.
	 */
    public struct VideoEncoderConfiguration
    {
        public VideoEncoderConfiguration(VideoDimensions dimensions = new VideoDimensions())
        {
            this.dimensions = dimensions;
            frameRate = FRAME_RATE.FRAME_RATE_FPS_15;
            minFrameRate = -1;
            bitrate = (int) BITRATE.STANDARD_BITRATE;
            minBitrate = (int) BITRATE.DEFAULT_MIN_BITRATE;
            orientationMode = ORIENTATION_MODE.ORIENTATION_MODE_ADAPTIVE;
            degradationPreference = DEGRADATION_PREFERENCE.MAINTAIN_QUALITY;
            mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO;
        }

        public VideoEncoderConfiguration(int width, int height, FRAME_RATE frameRate, int bitrate,
            ORIENTATION_MODE orientationMode,
            VIDEO_MIRROR_MODE_TYPE mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO)
        {
            dimensions = new VideoDimensions(width, height);
            this.frameRate = frameRate;
            minFrameRate = -1;
            this.bitrate = bitrate;
            minBitrate = (int) BITRATE.DEFAULT_MIN_BITRATE;
            this.orientationMode = orientationMode;
            degradationPreference = DEGRADATION_PREFERENCE.MAINTAIN_QUALITY;
            this.mirrorMode = mirrorMode;
        }

        public VideoEncoderConfiguration(VideoDimensions dimensions, FRAME_RATE frameRate, int bitrate,
            ORIENTATION_MODE orientationMode,
            VIDEO_MIRROR_MODE_TYPE mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO)
        {
            this.dimensions = dimensions;
            this.frameRate = frameRate;
            minFrameRate = -1;
            this.bitrate = bitrate;
            minBitrate = (int) BITRATE.DEFAULT_MIN_BITRATE;
            this.orientationMode = orientationMode;
            degradationPreference = DEGRADATION_PREFERENCE.MAINTAIN_QUALITY;
            this.mirrorMode = mirrorMode;
        }

        public VideoEncoderConfiguration(VideoDimensions dimensions, FRAME_RATE frameRate, int minFrameRate, int bitrate,
	        BITRATE minBitrate, ORIENTATION_MODE orientationMode, DEGRADATION_PREFERENCE degradationPreference,
	        VIDEO_MIRROR_MODE_TYPE mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO)
        {
	        this.dimensions = dimensions;
	        this.frameRate = frameRate;
	        this.minFrameRate = minFrameRate;
	        this.bitrate = bitrate;
	        this.minBitrate = (int) minBitrate;
	        this.orientationMode = orientationMode;
	        this.degradationPreference = degradationPreference;
	        this.mirrorMode = mirrorMode;
        }

        /** The video frame dimensions (px) used to specify the video quality and measured by the total number of pixels along a frame's width and height: VideoDimensions. The default value is 640 x 360.
		 */
        public VideoDimensions dimensions { set; get; }

        /** The frame rate of the video: #FRAME_RATE. The default value is 15.

		 Note that we do not recommend setting this to a value greater than 30.
		 */
        public FRAME_RATE frameRate { set; get; }

        /** The minimum frame rate of the video. The default value is -1.
		 */
        public int minFrameRate { set; get; }

        /** The video encoding bitrate (Kbps).

		 Choose one of the following options:

		 - #STANDARD_BITRATE: (Recommended) The standard bitrate.
		    - the `COMMUNICATION` profile: the encoding bitrate equals the base bitrate.
		    - the `LIVE_BROADCASTING` profile: the encoding bitrate is twice the base bitrate.
		 - #COMPATIBLE_BITRATE: The compatible bitrate: the bitrate stays the same regardless of the profile.

		 the `COMMUNICATION` profile prioritizes smoothness, while the `LIVE_BROADCASTING` profile prioritizes video quality (requiring a higher bitrate). We recommend setting the bitrate mode as #STANDARD_BITRATE to address this difference.

		 The following table lists the recommended video encoder configurations, where the base bitrate applies to the `COMMUNICATION` profile. Set your bitrate based on this table. If you set a bitrate beyond the proper range, the SDK automatically sets it to within the range.

		 @note
		 In the following table, **Base Bitrate** applies to the `COMMUNICATION` profile, and **Live Bitrate** applies to the `LIVE_BROADCASTING` profile.

		 | Resolution             | Frame Rate (fps) | Base Bitrate (Kbps)                    | Live Bitrate (Kbps)                    |
		 |------------------------|------------------|----------------------------------------|----------------------------------------|
		 | 160 * 120              | 15               | 65                                     | 130                                    |
		 | 120 * 120              | 15               | 50                                     | 100                                    |
		 | 320 * 180              | 15               | 140                                    | 280                                    |
		 | 180 * 180              | 15               | 100                                    | 200                                    |
		 | 240 * 180              | 15               | 120                                    | 240                                    |
		 | 320 * 240              | 15               | 200                                    | 400                                    |
		 | 240 * 240              | 15               | 140                                    | 280                                    |
		 | 424 * 240              | 15               | 220                                    | 440                                    |
		 | 640 * 360              | 15               | 400                                    | 800                                    |
		 | 360 * 360              | 15               | 260                                    | 520                                    |
		 | 640 * 360              | 30               | 600                                    | 1200                                   |
		 | 360 * 360              | 30               | 400                                    | 800                                    |
		 | 480 * 360              | 15               | 320                                    | 640                                    |
		 | 480 * 360              | 30               | 490                                    | 980                                    |
		 | 640 * 480              | 15               | 500                                    | 1000                                   |
		 | 480 * 480              | 15               | 400                                    | 800                                    |
		 | 640 * 480              | 30               | 750                                    | 1500                                   |
		 | 480 * 480              | 30               | 600                                    | 1200                                   |
		 | 848 * 480              | 15               | 610                                    | 1220                                   |
		 | 848 * 480              | 30               | 930                                    | 1860                                   |
		 | 640 * 480              | 10               | 400                                    | 800                                    |
		 | 1280 * 720             | 15               | 1130                                   | 2260                                   |
		 | 1280 * 720             | 30               | 1710                                   | 3420                                   |
		 | 960 * 720              | 15               | 910                                    | 1820                                   |
		 | 960 * 720              | 30               | 1380                                   | 2760                                   |
		 | 1920 * 1080            | 15               | 2080                                   | 4160                                   |
		 | 1920 * 1080            | 30               | 3150                                   | 6300                                   |
		 | 1920 * 1080            | 60               | 4780                                   | 6500                                   |
		 | 2560 * 1440            | 30               | 4850                                   | 6500                                   |
		 | 2560 * 1440            | 60               | 6500                                   | 6500                                   |
		 | 3840 * 2160            | 30               | 6500                                   | 6500                                   |
		 | 3840 * 2160            | 60               | 6500                                   | 6500                                   |

		 */
        public int bitrate { set; get; }

        /** The minimum encoding bitrate (Kbps).

		 The SDK automatically adjusts the encoding bitrate to adapt to the network conditions. Using a value greater than the default value forces the video encoder to output high-quality images but may cause more packet loss and hence sacrifice the smoothness of the video transmission. That said, unless you have special requirements for image quality, Agora does not recommend changing this value.

		 @note This parameter applies only to the `LIVE_BROADCASTING` profile.
		 */
        public int minBitrate { set; get; }

        /** The video orientation mode of the video: #ORIENTATION_MODE.
		 */
        public ORIENTATION_MODE orientationMode { set; get; }

        /** The video encoding degradation preference under limited bandwidth: #DEGRADATION_PREFERENCE.
		 */
        public DEGRADATION_PREFERENCE degradationPreference { set; get; }

        /** Sets the mirror mode of the published local video stream. It only affects the video that the remote user sees. See #VIDEO_MIRROR_MODE_TYPE

		 @note: The SDK disables the mirror mode by default.
		 */
        public VIDEO_MIRROR_MODE_TYPE mirrorMode { set; get; }
    }

    /** The video and audio properties of the user displaying the video in the CDN live. Agora supports a maximum of 17 transcoding users in a CDN streaming channel.
	 */
    public struct TranscodingUser
    {
        public TranscodingUser(uint uid = 0)
        {
            this.uid = uid;
            x = 0;
            y = 0;
            width = 0;
            height = 0;
            zOrder = 0;
            alpha = 1.0;
            audioChannel = 0;
        }

        /** User ID of the user displaying the video in the CDN live.
		 */
        public uint uid { set; get; }

        /** Horizontal position (pixel) of the video frame relative to the top left corner.
		 */
        public int x { set; get; }

        /** Vertical position (pixel) of the video frame relative to the top left corner.
		 */
        public int y { set; get; }

        /** Width (pixel) of the video frame. The default value is 360.
		 */
        public int width { set; get; }

        /** Height (pixel) of the video frame. The default value is 640.
		 */
        public int height { set; get; }

        /** The layer index of the video frame. An integer. The value range is [0, 100].

		 - 0: (Default) Bottom layer.
		 - 100: Top layer.

		 @note
		 - If zOrder is beyond this range, the SDK reports #ERR_INVALID_ARGUMENT.
		 - As of v2.3, the SDK supports zOrder = 0.
		 */
        public int zOrder { set; get; }

        /** The transparency level of the user's video. The value ranges between 0 and 1.0:

		 - 0: Completely transparent
		 - 1.0: (Default) Opaque
		 */
        public double alpha { set; get; }

        /** The audio channel of the sound. The default value is 0:

		 - 0: (Default) Supports dual channels at most, depending on the upstream of the host.
		 - 1: The audio stream of the host uses the FL audio channel. If the upstream of the host uses multiple audio channels, these channels are mixed into mono first.
		 - 2: The audio stream of the host uses the FC audio channel. If the upstream of the host uses multiple audio channels, these channels are mixed into mono first.
		 - 3: The audio stream of the host uses the FR audio channel. If the upstream of the host uses multiple audio channels, these channels are mixed into mono first.
		 - 4: The audio stream of the host uses the BL audio channel. If the upstream of the host uses multiple audio channels, these channels are mixed into mono first.
		 - 5: The audio stream of the host uses the BR audio channel. If the upstream of the host uses multiple audio channels, these channels are mixed into mono first.

		 @note If your setting is not 0, you may need a specialized player.
		 */
        public int audioChannel { set; get; }
    }

    /** Image properties.

	 The properties of the watermark and background images.
	 */
    public struct RtcImage
    {
        /** HTTP/HTTPS URL address of the image on the live video. The maximum length of this parameter is 1024 bytes. */
        public string url { set; get; }

        /** Horizontal position of the image from the upper left of the live video. */
        public int x { set; get; }

        /** Vertical position of the image from the upper left of the live video. */
        public int y { set; get; }

        /** Width of the image on the live video. */
        public int width { set; get; }

        /** Height of the image on the live video. */
        public int height { set; get; }
    }

    /** The configuration for advanced features of the RTMP streaming with transcoding.
	 */
    public struct LiveStreamAdvancedFeature
    {
        public LiveStreamAdvancedFeature(string featureName = "")
        {
            LBHQ = "lbhq";
            VEO = "veo";
            this.featureName = featureName;
            opened = false;
        }

        /** The advanced feature for high-quality video with a lower bitrate. */
        public string LBHQ { set; get; }

        /** The advanced feature for the optimized video encoder. */
        public string VEO { set; get; }

        /** The name of the advanced feature. It contains LBHQ and VEO.
		 */
        public string featureName { set; get; }

        /** Whether to enable the advanced feature:
		 * - true: Enable the advanced feature.
		 * - false: (Default) Disable the advanced feature.
		 */
        public bool opened { set; get; }
    }

    /** A struct for managing CDN live audio/video transcoding settings.
	 */
    public struct LiveTranscoding
    {
        public LiveTranscoding(int w = 360, int h = 640)
        {
            width = w;
            height = h;
            videoBitrate = 400;
            videoFramerate = 15;
            lowLatency = false;
            videoGop = 30;
            videoCodecProfile = VIDEO_CODEC_PROFILE_TYPE.VIDEO_CODEC_PROFILE_HIGH;
            backgroundColor = 0x000000;
            userCount = 0;
            transcodingUsers = null;
            transcodingExtraInfo = "";
            metadata = "";
            watermark = null;
            backgroundImage = null;
            audioSampleRate = AUDIO_SAMPLE_RATE_TYPE.AUDIO_SAMPLE_RATE_48000;
            audioBitrate = 48;
            audioChannels = 1;
            audioCodecProfile = AUDIO_CODEC_PROFILE_TYPE.AUDIO_CODEC_PROFILE_LC_AAC;
            advancedFeatures = null;
            advancedFeatureCount = 0;
        }

        /** The width of the video in pixels. The default value is 360.
		 * - When pushing video streams to the CDN, ensure that `width` is at least 64; otherwise, the Agora server adjusts the value to 64.
		 * - When pushing audio streams to the CDN, set `width` and `height` as 0.
		 */
        public int width { set; get; }

        /** The height of the video in pixels. The default value is 640.
		 * - When pushing video streams to the CDN, ensure that `height` is at least 64; otherwise, the Agora server adjusts the value to 64.
		 * - When pushing audio streams to the CDN, set `width` and `height` as 0.
		 */
        public int height { set; get; }

        /** Bitrate of the CDN live output video stream. The default value is 400 Kbps.

		 Set this parameter according to the Video Bitrate Table. If you set a bitrate beyond the proper range, the SDK automatically adapts it to a value within the range.
		 */
        public int videoBitrate { set; get; }

        /** Frame rate of the output video stream set for the CDN live streaming. The default value is 15 fps, and the value range is (0,30].

		 @note The Agora server adjusts any value over 30 to 30.
		 */
        public int videoFramerate { set; get; }

        /** **DEPRECATED** Latency mode:

		 - true: Low latency with unassured quality.
		 - false: (Default) High latency with assured quality.
		 */
        public bool lowLatency { set; get; }

        /** Video GOP in frames. The default value is 30 fps.
		 */
        public int videoGop { set; get; }

        /** Self-defined video codec profile: #VIDEO_CODEC_PROFILE_TYPE.

		 @note If you set this parameter to other values, Agora adjusts it to the default value of 100.
		 */
        public VIDEO_CODEC_PROFILE_TYPE videoCodecProfile { set; get; }

        /** The background color in RGB hex value. Value only. Do not include a preceeding #. For example, 0xFFB6C1 (light pink). The default value is 0x000000 (black).
		 */
        public uint backgroundColor { set; get; }

        /** The number of users in the live interactive streaming.
		 */
        public uint userCount { set; get; }

        /** TranscodingUser
		 */
        public TranscodingUser[] transcodingUsers { set; get; }

        /** Reserved property. Extra user-defined information to send SEI for the H.264/H.265 video stream to the CDN live client. Maximum length: 4096 Bytes.

		 For more information on SEI frame, see [SEI-related questions](https://docs.agora.io/en/faq/sei).
		 */
        public string transcodingExtraInfo { set; get; }

        /** **DEPRECATED** The metadata sent to the CDN live client defined by the RTMP or HTTP-FLV metadata.
		 */
        public string metadata { set; get; }

        /** The watermark image added to the CDN live publishing stream.

		 Ensure that the format of the image is PNG. Once a watermark image is added, the audience of the CDN live publishing stream can see the watermark image. See RtcImage.
		 */
        public RtcImage? watermark { set; get; }

        /** The background image added to the CDN live publishing stream.

		 Once a background image is added, the audience of the CDN live publishing stream can see the background image. See RtcImage.
		 */
        public RtcImage? backgroundImage { set; get; }

        /** Self-defined audio-sample rate: #AUDIO_SAMPLE_RATE_TYPE.
		 */
        public AUDIO_SAMPLE_RATE_TYPE audioSampleRate { set; get; }

        /** Bitrate of the CDN live audio output stream. The default value is 48 Kbps, and the highest value is 128.
		 */
        public int audioBitrate { set; get; }

        /** The numbder of audio channels for the CDN live stream. Agora recommends choosing 1 (mono), or 2 (stereo) audio channels. Special players are required if you choose option 3, 4, or 5:

		 - 1: (Default) Mono.
		 - 2: Stereo.
		 - 3: Three audio channels.
		 - 4: Four audio channels.
		 - 5: Five audio channels.
		 */
        public int audioChannels { set; get; }

        /** Self-defined audio codec profile: #AUDIO_CODEC_PROFILE_TYPE.
		 */
        public AUDIO_CODEC_PROFILE_TYPE audioCodecProfile { set; get; }

        /** Advanced features of the RTMP streaming with transcoding. See LiveStreamAdvancedFeature.
		 *
		 * @since v3.1.0
		 */
        public LiveStreamAdvancedFeature[] advancedFeatures { set; get; }

        /** The number of enabled advanced features. The default value is 0. */
        public uint advancedFeatureCount { set; get; }
    }

    /** Camera capturer configuration.
	 */
    public struct CameraCapturerConfiguration
    {
        /** Camera capturer preference settings. See: #CAPTURER_OUTPUT_PREFERENCE. */
        public CAPTURER_OUTPUT_PREFERENCE preference { set; get; }
    }

    /** Configuration of the injected media stream.
	 */
    public struct InjectStreamConfig
    {
        public InjectStreamConfig(int width = 0, int height = 0)
        {
            this.width = width;
            this.height = height;
            videoGop = 30;
            videoFramerate = 15;
            videoBitrate = 400;
            audioSampleRate = AUDIO_SAMPLE_RATE_TYPE.AUDIO_SAMPLE_RATE_48000;
            audioBitrate = 48;
            audioChannels = 1;
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

    /** The definition of ChannelMediaInfo.
	 */
    public struct ChannelMediaInfo
    {
        /** The channel name.
		 */
        public string channelName { set; get; }

        /** The token that enables the user to join the channel.
		 */
        public string token { set; get; }

        /** The user ID.
		 */
        public uint uid { set; get; }
    }

    /** The definition of ChannelMediaRelayConfiguration.
	 */
    public struct ChannelMediaRelayConfiguration
    {
        public ChannelMediaRelayConfiguration(int count = 0)
        {
            srcInfo = null;
            destInfos = new ChannelMediaInfo[0];
            destCount = count;
        }

        /** Pointer to the information of the source channel: ChannelMediaInfo. It contains the following members:
		 * - `channelName`: The name of the source channel. The default value is `NULL`, which means the SDK applies the name of the current channel.
		 * - `uid`: ID of the host whose media stream you want to relay. The default value is 0, which means the SDK generates a random UID. You must set it as 0.
		 * - `token`: The token for joining the source channel. It is generated with the `channelName` and `uid` you set in `srcInfo`.
		 *   - If you have not enabled the App Certificate, set this parameter as the default value `NULL`, which means the SDK applies the App ID.
		 *   - If you have enabled the App Certificate, you must use the `token` generated with the `channelName` and `uid`, and the `uid` must be set as 0.
		 */
        public ChannelMediaInfo? srcInfo { set; get; }

        /** Pointer to the information of the destination channel: ChannelMediaInfo. It contains the following members:
		 * - `channelName`: The name of the destination channel.
		 * - `uid`: ID of the host in the destination channel. The value ranges from 0 to (2<sup>32</sup>-1). To avoid UID conflicts, this `uid` must be different from any other UIDs in the destination channel. The default value is 0, which means the SDK generates a random UID.
		 * - `token`: The token for joining the destination channel. It is generated with the `channelName` and `uid` you set in `destInfos`.
		 *   - If you have not enabled the App Certificate, set this parameter as the default value `NULL`, which means the SDK applies the App ID.
		 *   - If you have enabled the App Certificate, you must use the `token` generated with the `channelName` and `uid`.
		 */
        public ChannelMediaInfo[] destInfos { set; get; }

        /** The number of destination channels. The default value is 0, and the
		 * value range is [0,4). Ensure that the value of this parameter
		 * corresponds to the number of ChannelMediaInfo structs you define in
		 * `destInfos`.
		 */
        public int destCount { set; get; }
    }

    /** The relative location of the region to the screen or window.
	 */
    public struct Rectangle
    {
        public Rectangle(int x = 0, int y = 0, int width = 0, int height = 0)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        /** The horizontal offset from the top-left corner.
		 */
        public int x { set; get; }

        /** The vertical offset from the top-left corner.
		 */
        public int y { set; get; }

        /** The width of the region.
		 */
        public int width { set; get; }

        /** The height of the region.
		 */
        public int height { set; get; }
    }

    /**  **DEPRECATED** Definition of the rectangular region. */
    public struct Rect
    {
        public Rect(int top = 0, int left = 0, int bottom = 0, int right = 0)
        {
            this.top = top;
            this.left = left;
            this.bottom = bottom;
            this.right = right;
        }

        /** Y-axis of the top line.
		 */
        public int top { set; get; }

        /** X-axis of the left line.
		 */
        public int left { set; get; }

        /** Y-axis of the bottom line.
		 */
        public int bottom { set; get; }

        /** X-axis of the right line.
		 */
        public int right { set; get; }
    }

    /** The options of the watermark image to be added. */
    public struct WatermarkOptions
    {
        public WatermarkOptions(bool visibleInPreview = true)
        {
            this.visibleInPreview = visibleInPreview;
            positionInLandscapeMode = new Rectangle();
            positionInPortraitMode = new Rectangle();
        }

        /** Sets whether or not the watermark image is visible in the local video preview:
		 * - true: (Default) The watermark image is visible in preview.
		 * - false: The watermark image is not visible in preview.
		 */
        public bool visibleInPreview { set; get; }

        /**
		 * The watermark position in the landscape mode. See Rectangle.
		 * For detailed information on the landscape mode, see the advanced guide *Video Rotation*.
		 */
        public Rectangle positionInLandscapeMode { set; get; }

        /**
		 * The watermark position in the portrait mode. See Rectangle.
		 * For detailed information on the portrait mode, see the advanced guide *Video Rotation*.
		 */
        public Rectangle positionInPortraitMode { set; get; }
    }

    /** Screen sharing encoding parameters.
	 */
    public struct ScreenCaptureParameters
    {
        public ScreenCaptureParameters(int width = 1920, int height = 1080)
        {
            dimensions = new VideoDimensions(width, height);
            frameRate = 5;
            bitrate = (int) BITRATE.STANDARD_BITRATE;
            captureMouseCursor = true;
            windowFocus = false;
            excludeWindowList = 0;
            excludeWindowCount = 0;
        }

        public ScreenCaptureParameters(VideoDimensions dimensions, int frameRate, int bitrate, bool captureMouseCursor,
            bool windowFocus, view_t? excludeWindowList = null, int excludeWindowCount = 0)
        {
            this.dimensions = dimensions;
            this.frameRate = frameRate;
            this.bitrate = bitrate;
            this.captureMouseCursor = captureMouseCursor;
            this.windowFocus = windowFocus;
            this.excludeWindowList = excludeWindowList ?? 0;
            this.excludeWindowCount = excludeWindowCount;
        }

        public ScreenCaptureParameters(int width, int height, int frameRate, int bitrate, bool captureMouseCursor,
            bool windowFocus, view_t? excludeWindowList = null, int excludeWindowCount = 0)
        {
            dimensions = new VideoDimensions(width, height);
            this.frameRate = frameRate;
            this.bitrate = bitrate;
            this.captureMouseCursor = captureMouseCursor;
            this.windowFocus = windowFocus;
            this.excludeWindowList = excludeWindowList ?? 0;
            this.excludeWindowCount = excludeWindowCount;
        }

        /** The maximum encoding dimensions of the shared region in terms of width * height.

		 The default value is 1920 * 1080 pixels, that is, 2073600 pixels. Agora uses the value of this parameter to calculate the charges.

		 If the aspect ratio is different between the encoding dimensions and screen dimensions, Agora applies the following algorithms for encoding. Suppose the encoding dimensions are 1920 x 1080:

		 - If the value of the screen dimensions is lower than that of the encoding dimensions, for example, 1000 * 1000, the SDK uses 1000 * 1000 for encoding.
		 - If the value of the screen dimensions is higher than that of the encoding dimensions, for example, 2000 * 1500, the SDK uses the maximum value under 1920 * 1080 with the aspect ratio of the screen dimension (4:3) for encoding, that is, 1440 * 1080.
		 */
        public VideoDimensions dimensions { set; get; }

        /** The frame rate (fps) of the shared region.

		 The default value is 5. We do not recommend setting this to a value greater than 15.
		 */
        public int frameRate { set; get; }

        /** The bitrate (Kbps) of the shared region.

		 The default value is 0 (the SDK works out a bitrate according to the dimensions of the current screen).
		 */
        public int bitrate { set; get; }

        /** Sets whether or not to capture the mouse for screen sharing:

		 - true: (Default) Capture the mouse.
		 - false: Do not capture the mouse.
		 */
        public bool captureMouseCursor { set; get; }

        /** Whether to bring the window to the front when calling \ref IRtcEngine::startScreenCaptureByWindowId "startScreenCaptureByWindowId" to share the window:
		 * - true: Bring the window to the front.
		 * - false: (Default) Do not bring the window to the front.
		 */
        public bool windowFocus { set; get; }

        /** A list of IDs of windows to be blocked.
		 *
		 * When calling \ref IRtcEngine::startScreenCaptureByScreenRect "startScreenCaptureByScreenRect" to start screen sharing, you can use this parameter to block the specified windows.
		 * When calling \ref IRtcEngine::updateScreenCaptureParameters "updateScreenCaptureParameters" to update the configuration for screen sharing, you can use this parameter to dynamically block the specified windows during screen sharing.
		 */
        public view_t excludeWindowList { set; get; }

        /** The number of windows to be blocked.
		 */
        public int excludeWindowCount { set; get; }
    }

    /** Video display settings of the VideoCanvas class.
	 */
    public struct VideoCanvas
    {
        public VideoCanvas(view_t? view = null)
        {
            this.view = 0;
            renderMode = (int) RENDER_MODE_TYPE.RENDER_MODE_HIDDEN;
            channelId = "";
            uid = 0;
            mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO;
        }

        public VideoCanvas(view_t view, uint uid)
        {
            this.view = view;
            renderMode = (int) RENDER_MODE_TYPE.RENDER_MODE_HIDDEN;
            channelId = "";
            this.uid = uid;
            mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO;
        }

        public VideoCanvas(view_t view, RENDER_MODE_TYPE renderMode, uint uid)
        {
            this.view = view;
            this.renderMode = (int) renderMode;
            channelId = "";
            this.uid = uid;
            mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO;
        }

        public VideoCanvas(view_t view, RENDER_MODE_TYPE renderMode, uint uid, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            this.view = view;
            this.renderMode = (int) renderMode;
            channelId = "";
            this.uid = uid;
            this.mirrorMode = mirrorMode;
        }

        public VideoCanvas(view_t view, uint uid, string channelId = "",
            int renderMode = (int) RENDER_MODE_TYPE.RENDER_MODE_HIDDEN,
            VIDEO_MIRROR_MODE_TYPE mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO)
        {
            this.view = view;
            this.renderMode = renderMode;
            this.channelId = channelId;
            this.uid = uid;
            this.mirrorMode = mirrorMode;
        }

        /** Video display window (view).
		 */
        public view_t view { set; get; }

        /** The rendering mode of the video view. See RENDER_MODE_TYPE
		 */
        public int renderMode { set; get; }

        /** The unique channel name for the AgoraRTC session in the string format. The string length must be less than 64 bytes. Supported character scopes are:
		 - All lowercase English letters: a to z.
		 - All uppercase English letters: A to Z.
		 - All numeric characters: 0 to 9.
		 - The space character.
		 - Punctuation characters and other symbols, including: "!", "#", "$", "%", "&", "(", ")", "+", "-", ":", ";", "<", "=", ".", ">", "?", "@", "[", "]", "^", "_", " {", "}", "|", "~", ",".

		 @note
		 - The default value is the empty string "". Use the default value if the user joins the channel using the \ref IRtcEngine::joinChannel "joinChannel" method in the IRtcEngine class. The `VideoCanvas` struct defines the video canvas of the user in the channel.
		 - If the user joins the channel using the \ref IRtcEngine::joinChannel "joinChannel" method in the IChannel class, set this parameter as the `channelId` of the `IChannel` object. The `VideoCanvas` struct defines the video canvas of the user in the channel with the specified channel ID.
		 */
        public string channelId { set; get; }

        /** The user ID. */
        public uint uid { set; get; }

        /** The mirror mode of the video view. See VIDEO_MIRROR_MODE_TYPE
		 @note
		 - For the mirror mode of the local video view: If you use a front camera, the SDK enables the mirror mode by default; if you use a rear camera, the SDK disables the mirror mode by default.
		 - For the mirror mode of the remote video view: The SDK disables the mirror mode by default.
		*/
        public VIDEO_MIRROR_MODE_TYPE mirrorMode { set; get; }
    }

    /** Image enhancement options.
	 */
    public struct BeautyOptions
    {
        public BeautyOptions(
            LIGHTENING_CONTRAST_LEVEL lighteningContrastLevel = LIGHTENING_CONTRAST_LEVEL.LIGHTENING_CONTRAST_NORMAL)
        {
            lighteningLevel = 0;
            smoothnessLevel = 0;
            rednessLevel = 0;
            this.lighteningContrastLevel = lighteningContrastLevel;
        }
        
        public BeautyOptions(LIGHTENING_CONTRAST_LEVEL lighteningContrastLevel, float lighteningLevel,
            float smoothnessLevel, float rednessLevel)
        {
            this.lighteningLevel = lighteningLevel;
            this.smoothnessLevel = smoothnessLevel;
            this.rednessLevel = rednessLevel;
            this.lighteningContrastLevel = lighteningContrastLevel;
        }

        /** The contrast level, used with the @p lightening parameter.
		 */
        public LIGHTENING_CONTRAST_LEVEL lighteningContrastLevel { set; get; }

        /** The brightness level. The value ranges from 0.0 (original) to 1.0. */
        public float lighteningLevel { set; get; }

        /** The sharpness level. The value ranges between 0 (original) and 1. This parameter is usually used to remove blemishes.
		 */
        public float smoothnessLevel { set; get; }

        /** The redness level. The value ranges between 0 (original) and 1. This parameter adjusts the red saturation level.
		 */
        public float rednessLevel { set; get; }
    }

    /**
	 * The UserInfo struct.
	 */
    public struct UserInfo
    {
        /**
		 * The user ID.
		 */
        public uint uid { set; get; }

        /**
		 * The user account.
		 */
        public string userAccount { set; get; }
    }

    /** Definition of AudioFrame */
    public struct AudioFrame
    {
        /** The type of the audio frame. See #AUDIO_FRAME_TYPE
		 */
        public AUDIO_FRAME_TYPE type { set; get; }

        /** The number of samples per channel in the audio frame.
		 */
        public int samples { set; get; } //number of samples for each channel in this frame

        /**The number of bytes per audio sample, which is usually 16-bit (2-byte).
		 */
        public int bytesPerSample { set; get; } //number of bytes per sample: 2 for PCM16

        /** The number of audio channels.
		 - 1: Mono
		 - 2: Stereo (the data is interleaved)
		 */
        public int channels { set; get; } //number of channels (data are interleaved if stereo)

        /** The sample rate.
		 */
        public int samplesPerSec { set; get; } //sampling rate

        /** The data buffer of the audio frame. When the audio frame uses a stereo channel, the data buffer is interleaved.
		 The size of the data buffer is as follows: `buffer` = `samples` × `channels` × `bytesPerSample`.
		 */
        public byte[] buffer { set; get; } //data buffer

        /** The timestamp of the external audio frame. You can use this parameter for the following purposes:
		 - Restore the order of the captured audio frame.
		 - Synchronize audio and video frames in video-related scenarios, including where external video sources are used.
		 */
        public long renderTimeMs { set; get; }

        /** Reserved parameter.
		 */
        public int avsync_type { set; get; }
    }
    
    internal struct AudioFrameWithoutBuffer
    {
	    /** The type of the audio frame. See #AUDIO_FRAME_TYPE
		 */
	    public AUDIO_FRAME_TYPE type { set; get; }

	    /** The number of samples per channel in the audio frame.
		 */
	    public int samples { set; get; } //number of samples for each channel in this frame

	    /**The number of bytes per audio sample, which is usually 16-bit (2-byte).
		 */
	    public int bytesPerSample { set; get; } //number of bytes per sample: 2 for PCM16

	    /** The number of audio channels.
		 - 1: Mono
		 - 2: Stereo (the data is interleaved)
		 */
	    public int channels { set; get; } //number of channels (data are interleaved if stereo)

	    /** The sample rate.
		 */
	    public int samplesPerSec { set; get; } //sampling rate
	    
	    /** The timestamp of the external audio frame. You can use this parameter for the following purposes:
		 - Restore the order of the captured audio frame.
		 - Synchronize audio and video frames in video-related scenarios, including where external video sources are used.
		 */
	    public long renderTimeMs { set; get; }

	    /** Reserved parameter.
		 */
	    public int avsync_type { set; get; }
    }

    /** The external video frame.
	 */
    public struct ExternalVideoFrame
    {
        /** The buffer type. See #VIDEO_BUFFER_TYPE
		 */
        public VIDEO_BUFFER_TYPE type { set; get; }

        /** The pixel format. See #VIDEO_PIXEL_FORMAT
		 */
        public VIDEO_PIXEL_FORMAT format { set; get; }

        /** The video buffer.
		 */
        public byte[] buffer { set; get; }

        /** Line spacing of the incoming video frame, which must be in pixels instead of bytes. For textures, it is the width of the texture.
		 */
        public int stride { set; get; }

        /** Height of the incoming video frame.
		 */
        public int height { set; get; }

        /** [Raw data related parameter] The number of pixels trimmed from the left. The default value is 0.
		 */
        public int cropLeft { set; get; }

        /** [Raw data related parameter] The number of pixels trimmed from the top. The default value is 0.
		 */
        public int cropTop { set; get; }

        /** [Raw data related parameter] The number of pixels trimmed from the right. The default value is 0.
		 */
        public int cropRight { set; get; }

        /** [Raw data related parameter] The number of pixels trimmed from the bottom. The default value is 0.
		 */
        public int cropBottom { set; get; }

        /** [Raw data related parameter] The clockwise rotation of the video frame. You can set the rotation angle as 0, 90, 180, or 270. The default value is 0.
		 */
        public int rotation { set; get; }

        /** Timestamp of the incoming video frame (ms). An incorrect timestamp results in frame loss or unsynchronized audio and video.
		 */
        public long timestamp { set; get; }
    }

    public struct ChannelMediaOptions
    {
        /** Determines whether to subscribe to audio streams when the user joins the channel:
		 - true: (Default) Subscribe.
		 - false: Do not subscribe.

		 This member serves a similar function to the \ref agora::rtc::IChannel::muteAllRemoteAudioStreams "muteAllRemoteAudioStreams" method. After joining the channel,
		 you can call the `muteAllRemoteAudioStreams` method to set whether to subscribe to audio streams in the channel.
		 */
        public bool autoSubscribeAudio { set; get; }

        /** Determines whether to subscribe to video streams when the user joins the channel:
		 - true: (Default) Subscribe.
		 - false: Do not subscribe.

		 This member serves a similar function to the \ref agora::rtc::IChannel::muteAllRemoteVideoStreams "muteAllRemoteVideoStreams" method. After joining the channel,
		 you can call the `muteAllRemoteVideoStreams` method to set whether to subscribe to video streams in the channel.
		 */
        public bool autoSubscribeVideo { set; get; }
    }

    /** Configurations of built-in encryption schemas. */
    public struct EncryptionConfig
    {
        /**
		 * Encryption mode. The default encryption mode is `AES_128_XTS`. See #ENCRYPTION_MODE.
		 */
        public ENCRYPTION_MODE encryptionMode { set; get; }

        /**
		 * Encryption key in string type.
		 *
		 * @note If you do not set an encryption key or set it as NULL, you cannot use the built-in encryption, and the SDK returns #ERR_INVALID_ARGUMENT (-2).
		 */
        public string encryptionKey { set; get; }
    }
    
    public struct Metadata
    {
	    /** The User ID.

         - For the receiver: the ID of the user who sent the metadata.
         - For the sender: ignore it.
         */
	    public uint uid { set; get; }
	    /** Buffer size of the sent or received Metadata.
         */
	    public uint size { set; get; }
	    /** Buffer address of the sent or received Metadata.
         */
	    public byte[] buffer { set; get; }
	    /** Timestamp (ms) of the frame following the metadata.
         */
	    public long timeStampMs { set; get; }
    };
    
    /** Definition of RtcEngineContext.
	 */
    public struct RtcEngineContext
    {
	    public RtcEngineContext(string appId, AREA_CODE areaCode = AREA_CODE.AREA_CODE_GLOBAL)
	    {
		    this.appId = appId;
		    _areaCode = (uint) areaCode;
	    }
	    /**
		 * The App ID issued to you by Agora. See [How to get the App ID](https://docs.agora.io/en/Agora%20Platform/token#get-an-app-id).
		 * Only users in apps with the same App ID can join the same channel and communicate with each other. Use an App ID to create only
		 * one `IRtcEngine` instance. To change your App ID, call `release` to destroy the current `IRtcEngine` instance and then call `createAgoraRtcEngine`
		 * and `initialize` to create an `IRtcEngine` instance with the new App ID.
		 */
	    public string appId { set; get; }

	    /**
		 * The region for connection. This advanced feature applies to scenarios that have regional restrictions.
		 *
		 * For the regions that Agora supports, see #AREA_CODE. After specifying the region, the SDK connects to the Agora servers within that region.
		 *
		 * @note The SDK supports specify only one region.
		 */
	    private uint _areaCode;
	    public AREA_CODE areaCode
	    {
		    get => (AREA_CODE) _areaCode;
		    set => _areaCode = (uint) areaCode;
	    }
    };
}