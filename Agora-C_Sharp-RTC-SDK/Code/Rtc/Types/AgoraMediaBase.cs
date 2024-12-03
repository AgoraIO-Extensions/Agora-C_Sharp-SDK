using System;
namespace Agora.Rtc
{
    using uint8_t = Byte;
    using int16_t = Int16;

    ///
    /// <summary>
    /// Configurations of the video frame.
    /// 
    /// Note that the buffer provides a pointer to a pointer. This interface cannot modify the pointer of the buffer, but it can modify the content of the buffer.
    /// </summary>
    ///
    public class VideoFrame
    {
        #region terra VideoFrame_Member_List
        ///
        /// <summary>
        /// The pixel format. See VIDEO_PIXEL_FORMAT.
        /// </summary>
        ///
        public VIDEO_PIXEL_FORMAT type;

        ///
        /// <summary>
        /// The width of the video, in pixels.
        /// </summary>
        ///
        public int width;

        ///
        /// <summary>
        /// The height of the video, in pixels.
        /// </summary>
        ///
        public int height;

        ///
        /// <summary>
        /// For YUV data, the line span of the Y buffer; for RGBA data, the total data length. When dealing with video data, it is necessary to process the offset between each line of pixel data based on this parameter, otherwise it may result in image distortion.
        /// </summary>
        ///
        public int yStride;

        ///
        /// <summary>
        /// For YUV data, the line span of the U buffer; for RGBA data, the value is 0. When dealing with video data, it is necessary to process the offset between each line of pixel data based on this parameter, otherwise it may result in image distortion.
        /// </summary>
        ///
        public int uStride;

        ///
        /// <summary>
        /// For YUV data, the line span of the V buffer; for RGBA data, the value is 0. When dealing with video data, it is necessary to process the offset between each line of pixel data based on this parameter, otherwise it may result in image distortion.
        /// </summary>
        ///
        public int vStride;

        ///
        /// <summary>
        /// For YUV data, the pointer to the Y buffer; for RGBA data, the data buffer.
        /// </summary>
        ///
        public byte[] yBuffer;

        ///
        /// @ignore
        ///
        public IntPtr yBufferPtr;

        ///
        /// <summary>
        /// For YUV data, the pointer to the U buffer; for RGBA data, the value is 0.
        /// </summary>
        ///
        public byte[] uBuffer;

        ///
        /// @ignore
        ///
        public IntPtr uBufferPtr;

        ///
        /// <summary>
        /// For YUV data, the pointer to the V buffer; for RGBA data, the value is 0.
        /// </summary>
        ///
        public byte[] vBuffer;

        ///
        /// @ignore
        ///
        public IntPtr vBufferPtr;

        ///
        /// <summary>
        /// The clockwise rotation of the video frame before rendering. Supported values include 0, 90, 180, and 270 degrees.
        /// </summary>
        ///
        public int rotation;

        ///
        /// <summary>
        /// The Unix timestamp (ms) when the video frame is rendered. This timestamp can be used to guide the rendering of the video frame. This parameter is required.
        /// </summary>
        ///
        public long renderTimeMs;

        ///
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        ///
        public int avsync_type;

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. The MetaData buffer. The default value is NULL.
        /// </summary>
        ///
        public IntPtr metadata_buffer;

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. The MetaData size. The default value is 0.
        /// </summary>
        ///
        public int metadata_size;

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. EGL Context.
        /// </summary>
        ///
        public IntPtr sharedContext;

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. Texture ID.
        /// </summary>
        ///
        public int textureId;

        ///
        /// <summary>
        /// This parameter only applies to video data in Windows Texture format. It represents a pointer to an object of type ID3D11Texture2D, which is used by a video frame.
        /// </summary>
        ///
        public IntPtr d3d11Texture2d;

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. Incoming 4 × 4 transformational matrix. The typical value is a unit matrix.
        /// </summary>
        ///
        public float[] matrix;

        ///
        /// <summary>
        /// The alpha channel data output by using portrait segmentation algorithm. This data matches the size of the video frame, with each pixel value ranging from [0,255], where 0 represents the background and 255 represents the foreground (portrait). By setting this parameter, you can render the video background into various effects, such as transparent, solid color, image, video, etc.
        ///  In custom video rendering scenarios, ensure that both the video frame and alphaBuffer are of the Full Range type; other types may cause abnormal alpha data rendering.
        ///  Make sure that alphaBuffer is exactly the same size as the video frame (width × height), otherwise it may cause the app to crash.
        /// </summary>
        ///
        public byte[] alphaBuffer;

        ///
        /// @ignore
        ///
        public IntPtr alphaBufferPtr;

        ///
        /// <summary>
        /// When the video frame contains alpha channel data, it represents the relative position of alphaBuffer and the video frame. See ALPHA_STITCH_MODE.
        /// </summary>
        ///
        public ALPHA_STITCH_MODE alphaStitchMode;

        ///
        /// <summary>
        /// The meta information in the video frame. To use this parameter, contact.
        /// </summary>
        ///
        public IVideoFrameMetaInfo metaInfo;

        ///
        /// @ignore
        ///
        public Hdr10MetadataInfo hdr10MetadataInfo;

        ///
        /// <summary>
        /// By default, the color space properties of video frames will apply the Full Range and BT.709 standard configurations. You can configure the settings according your needs for custom video capturing and rendering.
        /// </summary>
        ///
        public ColorSpace colorSpace;
        #endregion terra VideoFrame_Member_List

        #region terra VideoFrame_Constructor

        public VideoFrame()
        {
            this.type = VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_DEFAULT;
            this.width = 0;
            this.height = 0;
            this.yStride = 0;
            this.uStride = 0;
            this.vStride = 0;
            this.yBuffer = new byte[0];
            this.yBufferPtr = IntPtr.Zero;
            this.uBuffer = new byte[0];
            this.uBufferPtr = IntPtr.Zero;
            this.vBuffer = new byte[0];
            this.vBufferPtr = IntPtr.Zero;
            this.rotation = 0;
            this.renderTimeMs = 0;
            this.avsync_type = 0;
            this.metadata_buffer = IntPtr.Zero;
            this.metadata_size = 0;
            this.sharedContext = IntPtr.Zero;
            this.textureId = 0;
            this.d3d11Texture2d = IntPtr.Zero;
            this.alphaBuffer = new byte[0];
            this.alphaBufferPtr = IntPtr.Zero;
            this.alphaStitchMode = ALPHA_STITCH_MODE.NO_ALPHA_STITCH;
            this.metaInfo = null;
            this.matrix = new float[16];
        }

        #endregion terra VideoFrame_Constructor
    }

    ///
    /// <summary>
    /// Raw audio data.
    /// </summary>
    ///
    public class AudioFrame
    {
        #region terra AudioFrame_Member_List
        ///
        /// <summary>
        /// The type of the audio frame. See AUDIO_FRAME_TYPE.
        /// </summary>
        ///
        public AUDIO_FRAME_TYPE type;

        ///
        /// <summary>
        /// The number of samples per channel in the audio frame.
        /// </summary>
        ///
        public int samplesPerChannel;

        ///
        /// <summary>
        /// The number of bytes per sample. For PCM, this parameter is generally set to 16 bits (2 bytes).
        /// </summary>
        ///
        public BYTES_PER_SAMPLE bytesPerSample;

        ///
        /// <summary>
        /// The number of audio channels (the data are interleaved if it is stereo).
        ///  1: Mono.
        ///  2: Stereo.
        /// </summary>
        ///
        public int channels;

        ///
        /// <summary>
        /// The number of samples per channel in the audio frame.
        /// </summary>
        ///
        public int samplesPerSec;

        ///
        /// @ignore
        ///
        public IntPtr buffer;

        ///
        /// <summary>
        /// The timestamp (ms) of the external audio frame. You can use this timestamp to restore the order of the captured audio frame, and synchronize audio and video frames in video scenarios, including scenarios where external video sources are used.
        /// </summary>
        ///
        public long renderTimeMs;

        ///
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        ///
        public int avsync_type;

        ///
        /// @ignore
        ///
        public long presentationMs;

        ///
        /// @ignore
        ///
        public int audioTrackNumber;

        ///
        /// @ignore
        ///
        public uint rtpTimestamp;
        #endregion terra AudioFrame_Member_List

        ///
        /// <summary>
        /// The data buffer of the audio frame. When the audio frame uses a stereo channel, the data buffer is interleaved. The size of the data buffer is as follows: buffer = samples × channels × bytesPerSample.
        /// </summary>
        ///
        public byte[] RawBuffer;

        #region terra AudioFrame_Constructor

        public AudioFrame()
        {
            this.type = AUDIO_FRAME_TYPE.FRAME_TYPE_PCM16;
            this.samplesPerChannel = 0;
            this.bytesPerSample = BYTES_PER_SAMPLE.TWO_BYTES_PER_SAMPLE;
            this.channels = 0;
            this.samplesPerSec = 0;
            this.buffer = IntPtr.Zero;
            this.renderTimeMs = 0;
            this.avsync_type = 0;
            this.presentationMs = 0;
            this.audioTrackNumber = 0;
            this.rtpTimestamp = 0;
            this.RawBuffer = new byte[0];
        }

        public AudioFrame(AUDIO_FRAME_TYPE type, int samplesPerChannel, BYTES_PER_SAMPLE bytesPerSample, int channels, int samplesPerSec, IntPtr buffer, long renderTimeMs, int avsync_type, long presentationMs, int audioTrackNumber, uint rtpTimestamp)
        {
            this.type = type;
            this.samplesPerChannel = samplesPerChannel;
            this.bytesPerSample = bytesPerSample;
            this.channels = channels;
            this.samplesPerSec = samplesPerSec;
            this.buffer = buffer;
            this.renderTimeMs = renderTimeMs;
            this.avsync_type = avsync_type;
            this.presentationMs = presentationMs;
            this.audioTrackNumber = audioTrackNumber;
            this.rtpTimestamp = rtpTimestamp;
        }

        #endregion terra AudioFrame_Constructor
    }

    #region terra AgoraMediaBase.h
    ///
    /// <summary>
    /// The context information of the extension.
    /// </summary>
    ///
    public class ExtensionContext
    {
        ///
        /// <summary>
        /// Whether the uid in ExtensionContext is valid: true : The uid is valid. false : The uid is invalid.
        /// </summary>
        ///
        public bool isValid;

        ///
        /// <summary>
        /// The user ID. 0 represents a local user, while greater than 0 represents a remote user.
        /// </summary>
        ///
        public uint uid;

        ///
        /// <summary>
        /// The name of the extension provider.
        /// </summary>
        ///
        public string providerName;

        ///
        /// <summary>
        /// The name of the extension.
        /// </summary>
        ///
        public string extensionName;

        public ExtensionContext()
        {
            this.isValid = false;
            this.uid = 0;
            this.providerName = "";
            this.extensionName = "";
        }

        public ExtensionContext(bool isValid, uint uid, string providerName, string extensionName)
        {
            this.isValid = isValid;
            this.uid = uid;
            this.providerName = providerName;
            this.extensionName = extensionName;
        }
    }

    ///
    /// <summary>
    /// The type of the video source.
    /// </summary>
    ///
    public enum VIDEO_SOURCE_TYPE
    {
        ///
        /// <summary>
        /// 0: (Default) The primary camera.
        /// </summary>
        ///
        VIDEO_SOURCE_CAMERA_PRIMARY = 0,

        ///
        /// <summary>
        /// 0: (Default) The primary camera.
        /// </summary>
        ///
        VIDEO_SOURCE_CAMERA = VIDEO_SOURCE_CAMERA_PRIMARY,

        ///
        /// <summary>
        /// 1: The secondary camera.
        /// </summary>
        ///
        VIDEO_SOURCE_CAMERA_SECONDARY = 1,

        ///
        /// <summary>
        /// 2: The primary screen.
        /// </summary>
        ///
        VIDEO_SOURCE_SCREEN_PRIMARY = 2,

        ///
        /// <summary>
        /// 2: The primary screen.
        /// </summary>
        ///
        VIDEO_SOURCE_SCREEN = VIDEO_SOURCE_SCREEN_PRIMARY,

        ///
        /// <summary>
        /// 3: The secondary screen.
        /// </summary>
        ///
        VIDEO_SOURCE_SCREEN_SECONDARY = 3,

        ///
        /// <summary>
        /// 4: A custom video source.
        /// </summary>
        ///
        VIDEO_SOURCE_CUSTOM = 4,

        ///
        /// <summary>
        /// 5: The media player.
        /// </summary>
        ///
        VIDEO_SOURCE_MEDIA_PLAYER = 5,

        ///
        /// <summary>
        /// 6: One PNG image.
        /// </summary>
        ///
        VIDEO_SOURCE_RTC_IMAGE_PNG = 6,

        ///
        /// <summary>
        /// 7: One JPEG image.
        /// </summary>
        ///
        VIDEO_SOURCE_RTC_IMAGE_JPEG = 7,

        ///
        /// <summary>
        /// 8: One GIF image.
        /// </summary>
        ///
        VIDEO_SOURCE_RTC_IMAGE_GIF = 8,

        ///
        /// <summary>
        /// 9: One remote video acquired by the network.
        /// </summary>
        ///
        VIDEO_SOURCE_REMOTE = 9,

        ///
        /// <summary>
        /// 10: One transcoded video source.
        /// </summary>
        ///
        VIDEO_SOURCE_TRANSCODED = 10,

        ///
        /// <summary>
        /// 11: (For Android, Windows, and macOS only) The third camera.
        /// </summary>
        ///
        VIDEO_SOURCE_CAMERA_THIRD = 11,

        ///
        /// <summary>
        /// 12: (For Android, Windows, and macOS only) The fourth camera.
        /// </summary>
        ///
        VIDEO_SOURCE_CAMERA_FOURTH = 12,

        ///
        /// <summary>
        /// 13: (For Windows and macOS only) The third screen.
        /// </summary>
        ///
        VIDEO_SOURCE_SCREEN_THIRD = 13,

        ///
        /// <summary>
        /// 14: (For Windows and macOS only) The fourth screen.
        /// </summary>
        ///
        VIDEO_SOURCE_SCREEN_FOURTH = 14,

        ///
        /// @ignore
        ///
        VIDEO_SOURCE_SPEECH_DRIVEN = 15,

        ///
        /// <summary>
        /// 100: An unknown video source.
        /// </summary>
        ///
        VIDEO_SOURCE_UNKNOWN = 100,
    }

    ///
    /// <summary>
    /// The audio source type.
    /// </summary>
    ///
    public enum AUDIO_SOURCE_TYPE
    {
        ///
        /// <summary>
        /// 0: (Default) Microphone.
        /// </summary>
        ///
        AUDIO_SOURCE_MICROPHONE = 0,

        ///
        /// <summary>
        /// 1: Custom audio stream.
        /// </summary>
        ///
        AUDIO_SOURCE_CUSTOM = 1,

        ///
        /// <summary>
        /// 2: Media player.
        /// </summary>
        ///
        AUDIO_SOURCE_MEDIA_PLAYER = 2,

        ///
        /// <summary>
        /// 3: System audio stream captured during screen sharing.
        /// </summary>
        ///
        AUDIO_SOURCE_LOOPBACK_RECORDING = 3,

        ///
        /// @ignore
        ///
        AUDIO_SOURCE_MIXED_STREAM = 4,

        ///
        /// <summary>
        /// 5: Audio stream from a specified remote user.
        /// </summary>
        ///
        AUDIO_SOURCE_REMOTE_USER = 5,

        ///
        /// <summary>
        /// 6: Mixed audio streams from all users in the current channel.
        /// </summary>
        ///
        AUDIO_SOURCE_REMOTE_CHANNEL = 6,

        ///
        /// <summary>
        /// 100: An unknown audio source.
        /// </summary>
        ///
        AUDIO_SOURCE_UNKNOWN = 100,
    }

    ///
    /// <summary>
    /// The type of the audio route.
    /// </summary>
    ///
    public enum AudioRoute
    {
        ///
        /// <summary>
        /// -1: The default audio route.
        /// </summary>
        ///
        ROUTE_DEFAULT = -1,

        ///
        /// <summary>
        /// 0: Audio output routing is a headset with microphone.
        /// </summary>
        ///
        ROUTE_HEADSET = 0,

        ///
        /// <summary>
        /// 1: The audio route is an earpiece.
        /// </summary>
        ///
        ROUTE_EARPIECE = 1,

        ///
        /// <summary>
        /// 2: The audio route is a headset without a microphone.
        /// </summary>
        ///
        ROUTE_HEADSETNOMIC = 2,

        ///
        /// <summary>
        /// 3: The audio route is the speaker that comes with the device.
        /// </summary>
        ///
        ROUTE_SPEAKERPHONE = 3,

        ///
        /// <summary>
        /// 4: The audio route is an external speaker. (iOS and macOS only)
        /// </summary>
        ///
        ROUTE_LOUDSPEAKER = 4,

        ///
        /// <summary>
        /// 5: The audio route is a Bluetooth device using the HFP protocol.
        /// </summary>
        ///
        ROUTE_BLUETOOTH_DEVICE_HFP = 5,

        ///
        /// <summary>
        /// 6: The audio route is a USB peripheral device. (For macOS only)
        /// </summary>
        ///
        ROUTE_USB = 6,

        ///
        /// <summary>
        /// 7: The audio route is an HDMI peripheral device. (For macOS only)
        /// </summary>
        ///
        ROUTE_HDMI = 7,

        ///
        /// <summary>
        /// 8: The audio route is a DisplayPort peripheral device. (For macOS only)
        /// </summary>
        ///
        ROUTE_DISPLAYPORT = 8,

        ///
        /// <summary>
        /// 9: The audio route is Apple AirPlay. (For macOS only)
        /// </summary>
        ///
        ROUTE_AIRPLAY = 9,

        ///
        /// <summary>
        /// 10: The audio route is a Bluetooth device using the A2DP protocol.
        /// </summary>
        ///
        ROUTE_BLUETOOTH_DEVICE_A2DP = 10,
    }

    ///
    /// @ignore
    ///
    public enum BYTES_PER_SAMPLE
    {
        ///
        /// @ignore
        ///
        TWO_BYTES_PER_SAMPLE = 2,
    }

    ///
    /// @ignore
    ///
    public class AudioParameters
    {
        ///
        /// @ignore
        ///
        public int sample_rate;

        ///
        /// @ignore
        ///
        public ulong channels;

        ///
        /// @ignore
        ///
        public ulong frames_per_buffer;

        public AudioParameters()
        {
            this.sample_rate = 0;
            this.channels = 0;
            this.frames_per_buffer = 0;
        }

        public AudioParameters(int sample_rate, ulong channels, ulong frames_per_buffer)
        {
            this.sample_rate = sample_rate;
            this.channels = channels;
            this.frames_per_buffer = frames_per_buffer;
        }
    }

    ///
    /// <summary>
    /// The use mode of the audio data.
    /// </summary>
    ///
    public enum RAW_AUDIO_FRAME_OP_MODE_TYPE
    {
        ///
        /// <summary>
        /// 0: Read-only mode, For example, when users acquire the data with the Agora SDK, then start the media push.
        /// </summary>
        ///
        RAW_AUDIO_FRAME_OP_MODE_READ_ONLY = 0,

        ///
        /// <summary>
        /// 2: Read and write mode, For example, when users have their own audio-effect processing module and perform some voice preprocessing, such as a voice change.
        /// </summary>
        ///
        RAW_AUDIO_FRAME_OP_MODE_READ_WRITE = 2,
    }

    ///
    /// <summary>
    /// Media source type.
    /// </summary>
    ///
    public enum MEDIA_SOURCE_TYPE
    {
        ///
        /// <summary>
        /// 0: Audio playback device.
        /// </summary>
        ///
        AUDIO_PLAYOUT_SOURCE = 0,

        ///
        /// <summary>
        /// 1: Audio capturing device.
        /// </summary>
        ///
        AUDIO_RECORDING_SOURCE = 1,

        ///
        /// <summary>
        /// 2: The primary camera.
        /// </summary>
        ///
        PRIMARY_CAMERA_SOURCE = 2,

        ///
        /// <summary>
        /// 3: A secondary camera.
        /// </summary>
        ///
        SECONDARY_CAMERA_SOURCE = 3,

        ///
        /// @ignore
        ///
        PRIMARY_SCREEN_SOURCE = 4,

        ///
        /// @ignore
        ///
        SECONDARY_SCREEN_SOURCE = 5,

        ///
        /// <summary>
        /// 6: Custom video source.
        /// </summary>
        ///
        CUSTOM_VIDEO_SOURCE = 6,

        ///
        /// @ignore
        ///
        MEDIA_PLAYER_SOURCE = 7,

        ///
        /// @ignore
        ///
        RTC_IMAGE_PNG_SOURCE = 8,

        ///
        /// @ignore
        ///
        RTC_IMAGE_JPEG_SOURCE = 9,

        ///
        /// @ignore
        ///
        RTC_IMAGE_GIF_SOURCE = 10,

        ///
        /// @ignore
        ///
        REMOTE_VIDEO_SOURCE = 11,

        ///
        /// @ignore
        ///
        TRANSCODED_VIDEO_SOURCE = 12,

        ///
        /// @ignore
        ///
        SPEECH_DRIVEN_VIDEO_SOURCE = 13,

        ///
        /// <summary>
        /// 100: Unknown media source.
        /// </summary>
        ///
        UNKNOWN_MEDIA_SOURCE = 100,
    }

    ///
    /// @ignore
    ///
    public enum CONTENT_INSPECT_RESULT
    {
        ///
        /// @ignore
        ///
        CONTENT_INSPECT_NEUTRAL = 1,

        ///
        /// @ignore
        ///
        CONTENT_INSPECT_SEXY = 2,

        ///
        /// @ignore
        ///
        CONTENT_INSPECT_PORN = 3,
    }

    ///
    /// <summary>
    /// The type of video content moderation module.
    /// </summary>
    ///
    public enum CONTENT_INSPECT_TYPE
    {
        ///
        /// <summary>
        /// 0: (Default) This module has no actual function. Do not set type to this value.
        /// </summary>
        ///
        CONTENT_INSPECT_INVALID = 0,

        ///
        /// @ignore
        ///
        [Obsolete("")]
        CONTENT_INSPECT_MODERATION = 1,

        ///
        /// <summary>
        /// 2: Video screenshot and upload via Agora self-developed extension. SDK takes screenshots of the video stream in the channel and uploads them.
        /// </summary>
        ///
        CONTENT_INSPECT_SUPERVISION = 2,

        ///
        /// <summary>
        /// 3: Video screenshot and upload via extensions from Agora Extensions Marketplace. SDK uses video moderation extensions from Agora Extensions Marketplace to take screenshots of the video stream in the channel and uploads them.
        /// </summary>
        ///
        CONTENT_INSPECT_IMAGE_MODERATION = 3,
    }

    ///
    /// <summary>
    /// ContentInspectModule A structure used to configure the frequency of video screenshot and upload.
    /// </summary>
    ///
    public class ContentInspectModule
    {
        ///
        /// <summary>
        /// Types of functional module. See CONTENT_INSPECT_TYPE.
        /// </summary>
        ///
        public CONTENT_INSPECT_TYPE type;

        ///
        /// <summary>
        /// The frequency (s) of video screenshot and upload. The value should be set as larger than 0. The default value is 0, the SDK does not take screenshots. Agora recommends that you set the value as 10; you can also adjust it according to your business needs.
        /// </summary>
        ///
        public uint interval;

        public ContentInspectModule()
        {
        }

        public ContentInspectModule(CONTENT_INSPECT_TYPE type, uint interval)
        {
            this.type = type;
            this.interval = interval;
        }
    }

    ///
    /// <summary>
    /// Screenshot and upload configuration.
    /// </summary>
    ///
    public class ContentInspectConfig
    {
        ///
        /// <summary>
        /// Additional information on the video content (maximum length: 1024 Bytes). The SDK sends the screenshots and additional information on the video content to the Agora server. Once the video screenshot and upload process is completed, the Agora server sends the additional information and the callback notification to your server.
        /// </summary>
        ///
        public string extraInfo;

        ///
        /// <summary>
        /// (Optional) Server configuration related to uploading video screenshots via extensions from Agora Extensions Marketplace. This parameter only takes effect when type in ContentInspectModule is set to CONTENT_INSPECT_IMAGE_MODERATION. If you want to use it, contact.
        /// </summary>
        ///
        public string serverConfig;

        ///
        /// <summary>
        /// Functional module. See ContentInspectModule. A maximum of 32 ContentInspectModule instances can be configured, and the value range of MAX_CONTENT_INSPECT_MODULE_COUNT is an integer in [1,32]. A function module can only be configured with one instance at most. Currently only the video screenshot and upload function is supported.
        /// </summary>
        ///
        public ContentInspectModule[] modules;

        ///
        /// <summary>
        /// The number of functional modules, that is,the number of configured ContentInspectModule instances, must be the same as the number of instances configured in modules. The maximum number is 32.
        /// </summary>
        ///
        public int moduleCount;

        public ContentInspectConfig()
        {
            this.extraInfo = "";
            this.serverConfig = "";
            this.moduleCount = 0;
        }

        public ContentInspectConfig(string extraInfo, string serverConfig, ContentInspectModule[] modules, int moduleCount)
        {
            this.extraInfo = extraInfo;
            this.serverConfig = serverConfig;
            this.modules = modules;
            this.moduleCount = moduleCount;
        }
    }

    ///
    /// @ignore
    ///
    public class PacketOptions
    {
        ///
        /// @ignore
        ///
        public uint timestamp;

        ///
        /// @ignore
        ///
        public uint8_t audioLevelIndication;

        public PacketOptions()
        {
            this.timestamp = 0;
            this.audioLevelIndication = 127;
        }

        public PacketOptions(uint timestamp, uint8_t audioLevelIndication)
        {
            this.timestamp = timestamp;
            this.audioLevelIndication = audioLevelIndication;
        }
    }

    ///
    /// @ignore
    ///
    public class AudioEncodedFrameInfo
    {
        ///
        /// @ignore
        ///
        public ulong sendTs;

        ///
        /// @ignore
        ///
        public uint8_t codec;

        public AudioEncodedFrameInfo()
        {
            this.sendTs = 0;
            this.codec = 0;
        }

        public AudioEncodedFrameInfo(ulong sendTs, uint8_t codec)
        {
            this.sendTs = sendTs;
            this.codec = codec;
        }
    }

    ///
    /// <summary>
    /// The parameters of the audio frame in PCM format.
    /// </summary>
    ///
    public class AudioPcmFrame
    {
        ///
        /// <summary>
        /// The timestamp (ms) of the audio frame.
        /// </summary>
        ///
        public long capture_timestamp;

        ///
        /// <summary>
        /// The number of samples per channel in the audio frame.
        /// </summary>
        ///
        public ulong samples_per_channel_;

        ///
        /// <summary>
        /// Audio sample rate (Hz).
        /// </summary>
        ///
        public int sample_rate_hz_;

        ///
        /// <summary>
        /// The number of audio channels.
        /// </summary>
        ///
        public ulong num_channels_;

        ///
        /// <summary>
        /// The number of bytes per sample.
        /// </summary>
        ///
        public BYTES_PER_SAMPLE bytes_per_sample;

        ///
        /// <summary>
        /// The audio frame.
        /// </summary>
        ///
        public int16_t[] data_;

        ///
        /// @ignore
        ///
        public bool is_stereo_;

        public AudioPcmFrame()
        {
            this.capture_timestamp = 0;
            this.samples_per_channel_ = 0;
            this.sample_rate_hz_ = 0;
            this.num_channels_ = 0;
            this.bytes_per_sample = BYTES_PER_SAMPLE.TWO_BYTES_PER_SAMPLE;
            this.is_stereo_ = false;
        }

        public AudioPcmFrame(AudioPcmFrame src)
        {
            this.capture_timestamp = src.capture_timestamp;
            this.samples_per_channel_ = src.samples_per_channel_;
            this.sample_rate_hz_ = src.sample_rate_hz_;
            this.num_channels_ = src.num_channels_;
            this.bytes_per_sample = src.bytes_per_sample;
            this.is_stereo_ = src.is_stereo_;
        }

        public AudioPcmFrame(long capture_timestamp, ulong samples_per_channel_, int sample_rate_hz_, ulong num_channels_, BYTES_PER_SAMPLE bytes_per_sample, int16_t[] data_, bool is_stereo_)
        {
            this.capture_timestamp = capture_timestamp;
            this.samples_per_channel_ = samples_per_channel_;
            this.sample_rate_hz_ = sample_rate_hz_;
            this.num_channels_ = num_channels_;
            this.bytes_per_sample = bytes_per_sample;
            this.data_ = data_;
            this.is_stereo_ = is_stereo_;
        }
    }

    ///
    /// <summary>
    /// The channel mode.
    /// </summary>
    ///
    public enum AUDIO_DUAL_MONO_MODE
    {
        ///
        /// <summary>
        /// 0: Original mode.
        /// </summary>
        ///
        AUDIO_DUAL_MONO_STEREO = 0,

        ///
        /// <summary>
        /// 1: Left channel mode. This mode replaces the audio of the right channel with the audio of the left channel, which means the user can only hear the audio of the left channel.
        /// </summary>
        ///
        AUDIO_DUAL_MONO_L = 1,

        ///
        /// <summary>
        /// 2: Right channel mode. This mode replaces the audio of the left channel with the audio of the right channel, which means the user can only hear the audio of the right channel.
        /// </summary>
        ///
        AUDIO_DUAL_MONO_R = 2,

        ///
        /// <summary>
        /// 3: Mixed channel mode. This mode mixes the audio of the left channel and the right channel, which means the user can hear the audio of the left channel and the right channel at the same time.
        /// </summary>
        ///
        AUDIO_DUAL_MONO_MIX = 3,
    }

    ///
    /// <summary>
    /// The video pixel format.
    /// </summary>
    ///
    public enum VIDEO_PIXEL_FORMAT
    {
        ///
        /// <summary>
        /// 0: Raw video pixel format.
        /// </summary>
        ///
        VIDEO_PIXEL_DEFAULT = 0,

        ///
        /// <summary>
        /// 1: The format is I420.
        /// </summary>
        ///
        VIDEO_PIXEL_I420 = 1,

        ///
        /// @ignore
        ///
        VIDEO_PIXEL_BGRA = 2,

        ///
        /// @ignore
        ///
        VIDEO_PIXEL_NV21 = 3,

        ///
        /// <summary>
        /// 4: The format is RGBA.
        /// </summary>
        ///
        VIDEO_PIXEL_RGBA = 4,

        ///
        /// @ignore
        ///
        VIDEO_PIXEL_NV12 = 8,

        ///
        /// @ignore
        ///
        VIDEO_TEXTURE_2D = 10,

        ///
        /// @ignore
        ///
        VIDEO_TEXTURE_OES = 11,

        ///
        /// @ignore
        ///
        VIDEO_CVPIXEL_NV12 = 12,

        ///
        /// @ignore
        ///
        VIDEO_CVPIXEL_I420 = 13,

        ///
        /// @ignore
        ///
        VIDEO_CVPIXEL_BGRA = 14,

        ///
        /// @ignore
        ///
        VIDEO_CVPIXEL_P010 = 15,

        ///
        /// <summary>
        /// 16: The format is I422.
        /// </summary>
        ///
        VIDEO_PIXEL_I422 = 16,

        ///
        /// <summary>
        /// 17: The ID3D11TEXTURE2D format. Currently supported types are DXGI_FORMAT_B8G8R8A8_UNORM, DXGI_FORMAT_B8G8R8A8_TYPELESS and DXGI_FORMAT_NV12.
        /// </summary>
        ///
        VIDEO_TEXTURE_ID3D11TEXTURE2D = 17,

        ///
        /// @ignore
        ///
        VIDEO_PIXEL_I010 = 18,
    }

    ///
    /// <summary>
    /// Video display modes.
    /// </summary>
    ///
    public enum RENDER_MODE_TYPE
    {
        ///
        /// <summary>
        /// 1: Hidden mode. The priority is to fill the window. Any excess video that does not match the window size will be cropped.
        /// </summary>
        ///
        RENDER_MODE_HIDDEN = 1,

        ///
        /// <summary>
        /// 2: Fit mode. The priority is to ensure that all video content is displayed. Any areas of the window that are not filled due to the mismatch between video size and window size will be filled with black.
        /// </summary>
        ///
        RENDER_MODE_FIT = 2,

        ///
        /// <summary>
        /// 3: Adaptive mode. Deprecated: This enumerator is deprecated and not recommended for use.
        /// </summary>
        ///
        [Obsolete("")]
        RENDER_MODE_ADAPTIVE = 3,
    }

    ///
    /// @ignore
    ///
    public enum CAMERA_VIDEO_SOURCE_TYPE
    {
        ///
        /// @ignore
        ///
        CAMERA_SOURCE_FRONT = 0,

        ///
        /// @ignore
        ///
        CAMERA_SOURCE_BACK = 1,

        ///
        /// @ignore
        ///
        VIDEO_SOURCE_UNSPECIFIED = 2,
    }

    ///
    /// @ignore
    ///
    public enum META_INFO_KEY
    {
        ///
        /// @ignore
        ///
        KEY_FACE_CAPTURE = 0,
    }

    ///
    /// @ignore
    ///
    public class ColorSpace
    {
        ///
        /// @ignore
        ///
        public PrimaryID primaries;

        ///
        /// @ignore
        ///
        public TransferID transfer;

        ///
        /// @ignore
        ///
        public MatrixID matrix;

        ///
        /// @ignore
        ///
        public RangeID range;

        public ColorSpace()
        {
            this.primaries = PrimaryID.PRIMARYID_UNSPECIFIED;
            this.transfer = TransferID.TRANSFERID_UNSPECIFIED;
            this.matrix = MatrixID.MATRIXID_UNSPECIFIED;
            this.range = RangeID.RANGEID_INVALID;
        }

        public ColorSpace(PrimaryID primaries, TransferID transfer, MatrixID matrix, RangeID range)
        {
            this.primaries = primaries;
            this.transfer = transfer;
            this.matrix = matrix;
            this.range = range;
        }
    }

    ///
    /// @ignore
    ///
    public enum PrimaryID
    {
        ///
        /// @ignore
        ///
        PRIMARYID_BT709 = 1,

        ///
        /// @ignore
        ///
        PRIMARYID_UNSPECIFIED = 2,

        ///
        /// @ignore
        ///
        PRIMARYID_BT470M = 4,

        ///
        /// @ignore
        ///
        PRIMARYID_BT470BG = 5,

        ///
        /// @ignore
        ///
        PRIMARYID_SMPTE170M = 6,

        ///
        /// @ignore
        ///
        PRIMARYID_SMPTE240M = 7,

        ///
        /// @ignore
        ///
        PRIMARYID_FILM = 8,

        ///
        /// @ignore
        ///
        PRIMARYID_BT2020 = 9,

        ///
        /// @ignore
        ///
        PRIMARYID_SMPTEST428 = 10,

        ///
        /// @ignore
        ///
        PRIMARYID_SMPTEST431 = 11,

        ///
        /// @ignore
        ///
        PRIMARYID_SMPTEST432 = 12,

        ///
        /// @ignore
        ///
        PRIMARYID_JEDECP22 = 22,
    }

    ///
    /// @ignore
    ///
    public enum RangeID
    {
        ///
        /// @ignore
        ///
        RANGEID_INVALID = 0,

        ///
        /// @ignore
        ///
        RANGEID_LIMITED = 1,

        ///
        /// @ignore
        ///
        RANGEID_FULL = 2,

        ///
        /// @ignore
        ///
        RANGEID_DERIVED = 3,
    }

    ///
    /// @ignore
    ///
    public enum MatrixID
    {
        ///
        /// @ignore
        ///
        MATRIXID_RGB = 0,

        ///
        /// @ignore
        ///
        MATRIXID_BT709 = 1,

        ///
        /// @ignore
        ///
        MATRIXID_UNSPECIFIED = 2,

        ///
        /// @ignore
        ///
        MATRIXID_FCC = 4,

        ///
        /// @ignore
        ///
        MATRIXID_BT470BG = 5,

        ///
        /// @ignore
        ///
        MATRIXID_SMPTE170M = 6,

        ///
        /// @ignore
        ///
        MATRIXID_SMPTE240M = 7,

        ///
        /// @ignore
        ///
        MATRIXID_YCOCG = 8,

        ///
        /// @ignore
        ///
        MATRIXID_BT2020_NCL = 9,

        ///
        /// @ignore
        ///
        MATRIXID_BT2020_CL = 10,

        ///
        /// @ignore
        ///
        MATRIXID_SMPTE2085 = 11,

        ///
        /// @ignore
        ///
        MATRIXID_CDNCLS = 12,

        ///
        /// @ignore
        ///
        MATRIXID_CDCLS = 13,

        ///
        /// @ignore
        ///
        MATRIXID_BT2100_ICTCP = 14,
    }

    ///
    /// @ignore
    ///
    public enum TransferID
    {
        ///
        /// @ignore
        ///
        TRANSFERID_BT709 = 1,

        ///
        /// @ignore
        ///
        TRANSFERID_UNSPECIFIED = 2,

        ///
        /// @ignore
        ///
        TRANSFERID_GAMMA22 = 4,

        ///
        /// @ignore
        ///
        TRANSFERID_GAMMA28 = 5,

        ///
        /// @ignore
        ///
        TRANSFERID_SMPTE170M = 6,

        ///
        /// @ignore
        ///
        TRANSFERID_SMPTE240M = 7,

        ///
        /// @ignore
        ///
        TRANSFERID_LINEAR = 8,

        ///
        /// @ignore
        ///
        TRANSFERID_LOG = 9,

        ///
        /// @ignore
        ///
        TRANSFERID_LOG_SQRT = 10,

        ///
        /// @ignore
        ///
        TRANSFERID_IEC61966_2_4 = 11,

        ///
        /// @ignore
        ///
        TRANSFERID_BT1361_ECG = 12,

        ///
        /// @ignore
        ///
        TRANSFERID_IEC61966_2_1 = 13,

        ///
        /// @ignore
        ///
        TRANSFERID_BT2020_10 = 14,

        ///
        /// @ignore
        ///
        TRANSFERID_BT2020_12 = 15,

        ///
        /// @ignore
        ///
        TRANSFERID_SMPTEST2084 = 16,

        ///
        /// @ignore
        ///
        TRANSFERID_SMPTEST428 = 17,

        ///
        /// @ignore
        ///
        TRANSFERID_ARIB_STD_B67 = 18,
    }

    ///
    /// @ignore
    ///
    public class Hdr10MetadataInfo
    {
        ///
        /// @ignore
        ///
        public ushort redPrimaryX;

        ///
        /// @ignore
        ///
        public ushort redPrimaryY;

        ///
        /// @ignore
        ///
        public ushort greenPrimaryX;

        ///
        /// @ignore
        ///
        public ushort greenPrimaryY;

        ///
        /// @ignore
        ///
        public ushort bluePrimaryX;

        ///
        /// @ignore
        ///
        public ushort bluePrimaryY;

        ///
        /// @ignore
        ///
        public ushort whitePointX;

        ///
        /// @ignore
        ///
        public ushort whitePointY;

        ///
        /// @ignore
        ///
        public uint maxMasteringLuminance;

        ///
        /// @ignore
        ///
        public uint minMasteringLuminance;

        ///
        /// @ignore
        ///
        public ushort maxContentLightLevel;

        ///
        /// @ignore
        ///
        public ushort maxFrameAverageLightLevel;

        public Hdr10MetadataInfo()
        {
            this.redPrimaryX = 0;
            this.redPrimaryY = 0;
            this.greenPrimaryX = 0;
            this.greenPrimaryY = 0;
            this.bluePrimaryX = 0;
            this.bluePrimaryY = 0;
            this.whitePointX = 0;
            this.whitePointY = 0;
            this.maxMasteringLuminance = 0;
            this.minMasteringLuminance = 0;
            this.maxContentLightLevel = 0;
            this.maxFrameAverageLightLevel = 0;
        }

        public Hdr10MetadataInfo(ushort redPrimaryX, ushort redPrimaryY, ushort greenPrimaryX, ushort greenPrimaryY, ushort bluePrimaryX, ushort bluePrimaryY, ushort whitePointX, ushort whitePointY, uint maxMasteringLuminance, uint minMasteringLuminance, ushort maxContentLightLevel, ushort maxFrameAverageLightLevel)
        {
            this.redPrimaryX = redPrimaryX;
            this.redPrimaryY = redPrimaryY;
            this.greenPrimaryX = greenPrimaryX;
            this.greenPrimaryY = greenPrimaryY;
            this.bluePrimaryX = bluePrimaryX;
            this.bluePrimaryY = bluePrimaryY;
            this.whitePointX = whitePointX;
            this.whitePointY = whitePointY;
            this.maxMasteringLuminance = maxMasteringLuminance;
            this.minMasteringLuminance = minMasteringLuminance;
            this.maxContentLightLevel = maxContentLightLevel;
            this.maxFrameAverageLightLevel = maxFrameAverageLightLevel;
        }
    }

    ///
    /// <summary>
    /// The relative position of alphaBuffer and video frames.
    /// </summary>
    ///
    public enum ALPHA_STITCH_MODE
    {
        ///
        /// <summary>
        /// 0: (Default) Only video frame, that is, alphaBuffer is not stitched with the video frame.
        /// </summary>
        ///
        NO_ALPHA_STITCH = 0,

        ///
        /// <summary>
        /// 1: alphaBuffer is above the video frame.
        /// </summary>
        ///
        ALPHA_STITCH_UP = 1,

        ///
        /// <summary>
        /// 2: alphaBuffer is below the video frame.
        /// </summary>
        ///
        ALPHA_STITCH_BELOW = 2,

        ///
        /// <summary>
        /// 3: alphaBuffer is to the left of the video frame.
        /// </summary>
        ///
        ALPHA_STITCH_LEFT = 3,

        ///
        /// <summary>
        /// 4: alphaBuffer is to the right of the video frame.
        /// </summary>
        ///
        ALPHA_STITCH_RIGHT = 4,
    }

    ///
    /// <summary>
    /// The external video frame.
    /// </summary>
    ///
    public class ExternalVideoFrame
    {
        ///
        /// <summary>
        /// The video type. See VIDEO_BUFFER_TYPE.
        /// </summary>
        ///
        public VIDEO_BUFFER_TYPE type;

        ///
        /// <summary>
        /// The pixel format. See VIDEO_PIXEL_FORMAT.
        /// </summary>
        ///
        public VIDEO_PIXEL_FORMAT format;

        ///
        /// <summary>
        /// Video frame buffer.
        /// </summary>
        ///
        public byte[] buffer;

        ///
        /// <summary>
        /// Line spacing of the incoming video frame, which must be in pixels instead of bytes. For textures, it is the width of the texture.
        /// </summary>
        ///
        public int stride;

        ///
        /// <summary>
        /// Height of the incoming video frame.
        /// </summary>
        ///
        public int height;

        ///
        /// <summary>
        /// Raw data related parameter. The number of pixels trimmed from the left. The default value is 0.
        /// </summary>
        ///
        public int cropLeft;

        ///
        /// <summary>
        /// Raw data related parameter. The number of pixels trimmed from the top. The default value is 0.
        /// </summary>
        ///
        public int cropTop;

        ///
        /// <summary>
        /// Raw data related parameter. The number of pixels trimmed from the right. The default value is 0.
        /// </summary>
        ///
        public int cropRight;

        ///
        /// <summary>
        /// Raw data related parameter. The number of pixels trimmed from the bottom. The default value is 0.
        /// </summary>
        ///
        public int cropBottom;

        ///
        /// <summary>
        /// Raw data related parameter. The clockwise rotation of the video frame. You can set the rotation angle as 0, 90, 180, or 270. The default value is 0.
        /// </summary>
        ///
        public int rotation;

        ///
        /// <summary>
        /// Timestamp (ms) of the incoming video frame. An incorrect timestamp results in frame loss or unsynchronized audio and video.
        /// </summary>
        ///
        public long timestamp;

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format.
        ///  When using the OpenGL interface (javax.microedition.khronos.egl.*) defined by Khronos, set eglContext to this field.
        ///  When using the OpenGL interface (android.opengl.*) defined by Android, set eglContext to this field.
        /// </summary>
        ///
        public IntPtr eglContext;

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. Texture ID of the video frame.
        /// </summary>
        ///
        public EGL_CONTEXT_TYPE eglType;

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. Incoming 4 × 4 transformational matrix. The typical value is a unit matrix.
        /// </summary>
        ///
        public int textureId;

        ///
        /// @ignore
        ///
        public long fenceObject;

        ///
        /// @ignore
        ///
        public float[] matrix;

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. The MetaData buffer. The default value is NULL.
        /// </summary>
        ///
        public byte[] metadataBuffer;

        ///
        /// <summary>
        /// This parameter only applies to video data in Texture format. The MetaData size. The default value is 0.
        /// </summary>
        ///
        public int metadataSize;

        ///
        /// <summary>
        /// The alpha channel data output by using portrait segmentation algorithm. This data matches the size of the video frame, with each pixel value ranging from [0,255], where 0 represents the background and 255 represents the foreground (portrait). By setting this parameter, you can render the video background into various effects, such as transparent, solid color, image, video, etc. In custom video rendering scenarios, ensure that both the video frame and alphaBuffer are of the Full Range type; other types may cause abnormal alpha data rendering.
        /// </summary>
        ///
        public byte[] alphaBuffer;

        ///
        /// <summary>
        /// This parameter only applies to video data in BGRA or RGBA format. Whether to extract the alpha channel data from the video frame and automatically fill it into alphaBuffer : true ：Extract and fill the alpha channel data. false : (Default) Do not extract and fill the Alpha channel data. For video data in BGRA or RGBA format, you can set the Alpha channel data in either of the following ways:
        ///  Automatically by setting this parameter to true.
        ///  Manually through the alphaBuffer parameter.
        /// </summary>
        ///
        public bool fillAlphaBuffer;

        ///
        /// <summary>
        /// When the video frame contains alpha channel data, it represents the relative position of alphaBuffer and the video frame. See ALPHA_STITCH_MODE.
        /// </summary>
        ///
        public ALPHA_STITCH_MODE alphaStitchMode;

        ///
        /// <summary>
        /// This parameter only applies to video data in Windows Texture format. It represents a pointer to an object of type ID3D11Texture2D, which is used by a video frame.
        /// </summary>
        ///
        public IntPtr d3d11Texture2d;

        ///
        /// <summary>
        /// This parameter only applies to video data in Windows Texture format. It represents an index of an ID3D11Texture2D texture object used by the video frame in the ID3D11Texture2D array.
        /// </summary>
        ///
        public int textureSliceIndex;

        ///
        /// @ignore
        ///
        public Hdr10MetadataInfo hdr10MetadataInfo;

        ///
        /// <summary>
        /// By default, the color space properties of video frames will apply the Full Range and BT.709 standard configurations. You can configure the settings according your needs for custom video capturing and rendering.
        /// </summary>
        ///
        public ColorSpace colorSpace;

        public ExternalVideoFrame()
        {
            this.type = VIDEO_BUFFER_TYPE.VIDEO_BUFFER_RAW_DATA;
            this.format = VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_DEFAULT;
            this.buffer = null;
            this.stride = 0;
            this.height = 0;
            this.cropLeft = 0;
            this.cropTop = 0;
            this.cropRight = 0;
            this.cropBottom = 0;
            this.rotation = 0;
            this.timestamp = 0;
            this.eglContext = IntPtr.Zero;
            this.eglType = EGL_CONTEXT_TYPE.EGL_CONTEXT10;
            this.textureId = 0;
            this.fenceObject = 0;
            this.metadataBuffer = null;
            this.metadataSize = 0;
            this.alphaBuffer = null;
            this.fillAlphaBuffer = false;
            this.alphaStitchMode = ALPHA_STITCH_MODE.NO_ALPHA_STITCH;
            this.d3d11Texture2d = IntPtr.Zero;
            this.textureSliceIndex = 0;
        }

        public ExternalVideoFrame(VIDEO_BUFFER_TYPE type, VIDEO_PIXEL_FORMAT format, byte[] buffer, int stride, int height, int cropLeft, int cropTop, int cropRight, int cropBottom, int rotation, long timestamp, IntPtr eglContext, EGL_CONTEXT_TYPE eglType, int textureId, long fenceObject, float[] matrix, byte[] metadataBuffer, int metadataSize, byte[] alphaBuffer, bool fillAlphaBuffer, ALPHA_STITCH_MODE alphaStitchMode, IntPtr d3d11Texture2d, int textureSliceIndex, Hdr10MetadataInfo hdr10MetadataInfo, ColorSpace colorSpace)
        {
            this.type = type;
            this.format = format;
            this.buffer = buffer;
            this.stride = stride;
            this.height = height;
            this.cropLeft = cropLeft;
            this.cropTop = cropTop;
            this.cropRight = cropRight;
            this.cropBottom = cropBottom;
            this.rotation = rotation;
            this.timestamp = timestamp;
            this.eglContext = eglContext;
            this.eglType = eglType;
            this.textureId = textureId;
            this.fenceObject = fenceObject;
            this.matrix = matrix;
            this.metadataBuffer = metadataBuffer;
            this.metadataSize = metadataSize;
            this.alphaBuffer = alphaBuffer;
            this.fillAlphaBuffer = fillAlphaBuffer;
            this.alphaStitchMode = alphaStitchMode;
            this.d3d11Texture2d = d3d11Texture2d;
            this.textureSliceIndex = textureSliceIndex;
            this.hdr10MetadataInfo = hdr10MetadataInfo;
            this.colorSpace = colorSpace;
        }
    }

    ///
    /// @ignore
    ///
    public enum EGL_CONTEXT_TYPE
    {
        ///
        /// @ignore
        ///
        EGL_CONTEXT10 = 0,

        ///
        /// @ignore
        ///
        EGL_CONTEXT14 = 1,
    }

    ///
    /// <summary>
    /// The video buffer type.
    /// </summary>
    ///
    public enum VIDEO_BUFFER_TYPE
    {
        ///
        /// <summary>
        /// 1: The video buffer in the format of raw data.
        /// </summary>
        ///
        VIDEO_BUFFER_RAW_DATA = 1,

        ///
        /// <summary>
        /// 2: The video buffer in the format of raw data.
        /// </summary>
        ///
        VIDEO_BUFFER_ARRAY = 2,

        ///
        /// <summary>
        /// 3: The video buffer in the format of Texture.
        /// </summary>
        ///
        VIDEO_BUFFER_TEXTURE = 3,
    }

    ///
    /// @ignore
    ///
    public enum MEDIA_PLAYER_SOURCE_TYPE
    {
        ///
        /// @ignore
        ///
        MEDIA_PLAYER_SOURCE_DEFAULT,

        ///
        /// @ignore
        ///
        MEDIA_PLAYER_SOURCE_FULL_FEATURED,

        ///
        /// @ignore
        ///
        MEDIA_PLAYER_SOURCE_SIMPLE,
    }

    ///
    /// <summary>
    /// The frame position of the video observer.
    /// </summary>
    ///
    [Flags]
    public enum VIDEO_MODULE_POSITION
    {
        ///
        /// <summary>
        /// 1: The location of the locally collected video data after preprocessing corresponds to the OnCaptureVideoFrame callback. The observed video here has the effect of video pre-processing, which can be verified by enabling image enhancement, virtual background, or watermark.
        /// </summary>
        ///
        POSITION_POST_CAPTURER = 1 << 0,

        ///
        /// <summary>
        /// 2: The pre-renderer position, which corresponds to the video data in the OnRenderVideoFrame callback.
        /// </summary>
        ///
        POSITION_PRE_RENDERER = 1 << 1,

        ///
        /// <summary>
        /// 4: The pre-encoder position, which corresponds to the video data in the OnPreEncodeVideoFrame callback. The observed video here has the effects of video pre-processing and encoding pre-processing.
        ///  To verify the pre-processing effects of the video, you can enable image enhancement, virtual background, or watermark.
        ///  To verify the pre-encoding processing effect, you can set a lower frame rate (for example, 5 fps).
        /// </summary>
        ///
        POSITION_PRE_ENCODER = 1 << 2,

        ///
        /// <summary>
        /// 8: The position after local video capture and before pre-processing. The observed video here does not have pre-processing effects, which can be verified by enabling image enhancement, virtual background, or watermarks.
        /// </summary>
        ///
        POSITION_POST_CAPTURER_ORIGIN = 1 << 3,
    }

    ///
    /// <summary>
    /// The snapshot configuration.
    /// </summary>
    ///
    public class SnapshotConfig
    {
        ///
        /// <summary>
        /// The local path (including filename extensions) of the snapshot. For example:
        ///  Windows: C:\Users\<user_name>\AppData\Local\Agora\<process_name>\example.jpg
        ///  iOS: /App Sandbox/Library/Caches/example.jpg
        ///  macOS: ～/Library/Logs/example.jpg
        ///  Android: /storage/emulated/0/Android/data/<package name>/files/example.jpg Ensure that the path you specify exists and is writable.
        /// </summary>
        ///
        public string filePath;

        ///
        /// <summary>
        /// The position of the snapshot video frame in the video pipeline. See VIDEO_MODULE_POSITION.
        /// </summary>
        ///
        public VIDEO_MODULE_POSITION position;

        public SnapshotConfig()
        {
            this.filePath = "";
            this.position = VIDEO_MODULE_POSITION.POSITION_PRE_ENCODER;
        }

        public SnapshotConfig(string filePath, VIDEO_MODULE_POSITION position)
        {
            this.filePath = filePath;
            this.position = position;
        }
    }

    ///
    /// <summary>
    /// Audio frame type.
    /// </summary>
    ///
    public enum AUDIO_FRAME_TYPE
    {
        ///
        /// <summary>
        /// 0: PCM 16
        /// </summary>
        ///
        FRAME_TYPE_PCM16 = 0,
    }

    ///
    /// @ignore
    ///
    [Flags]
    public enum AUDIO_FRAME_POSITION
    {
        ///
        /// @ignore
        ///
        AUDIO_FRAME_POSITION_NONE = 0x0000,

        ///
        /// @ignore
        ///
        AUDIO_FRAME_POSITION_PLAYBACK = 0x0001,

        ///
        /// @ignore
        ///
        AUDIO_FRAME_POSITION_RECORD = 0x0002,

        ///
        /// @ignore
        ///
        AUDIO_FRAME_POSITION_MIXED = 0x0004,

        ///
        /// @ignore
        ///
        AUDIO_FRAME_POSITION_BEFORE_MIXING = 0x0008,

        ///
        /// @ignore
        ///
        AUDIO_FRAME_POSITION_EAR_MONITORING = 0x0010,
    }

    ///
    /// <summary>
    /// Audio data format.
    /// 
    /// You can pass the AudioParams object in the following APIs to set the audio data format for the corresponding callback: SetRecordingAudioFrameParameters : Sets the audio data format for the OnRecordAudioFrame callback. SetPlaybackAudioFrameParameters : Sets the audio data format for the OnPlaybackAudioFrame callback. SetMixedAudioFrameParameters : Sets the audio data format for the OnMixedAudioFrame callback. SetEarMonitoringAudioFrameParameters : Sets the audio data format for the OnEarMonitoringAudioFrame callback.
    ///  The SDK calculates the sampling interval through the samplesPerCall, sampleRate, and channel parameters in AudioParams, and triggers the OnRecordAudioFrame, OnPlaybackAudioFrame, OnMixedAudioFrame, and OnEarMonitoringAudioFrame callbacks according to the sampling interval. Sample interval (sec) = samplePerCall /(sampleRate × channel).
    ///  Ensure that the sample interval ≥ 0.01 (s).
    /// </summary>
    ///
    public class AudioParams
    {
        ///
        /// <summary>
        /// The audio sample rate (Hz), which can be set as one of the following values:
        ///  8000.
        ///  (Default) 16000.
        ///  32000.
        ///  44100
        ///  48000
        /// </summary>
        ///
        public int sample_rate;

        ///
        /// <summary>
        /// The number of audio channels, which can be set as either of the following values:
        ///  1: (Default) Mono.
        ///  2: Stereo.
        /// </summary>
        ///
        public int channels;

        ///
        /// <summary>
        /// The use mode of the audio data. See RAW_AUDIO_FRAME_OP_MODE_TYPE.
        /// </summary>
        ///
        public RAW_AUDIO_FRAME_OP_MODE_TYPE mode;

        ///
        /// <summary>
        /// The number of samples, such as 1024 for the media push.
        /// </summary>
        ///
        public int samples_per_call;

        public AudioParams()
        {
            this.sample_rate = 0;
            this.channels = 0;
            this.mode = RAW_AUDIO_FRAME_OP_MODE_TYPE.RAW_AUDIO_FRAME_OP_MODE_READ_ONLY;
            this.samples_per_call = 0;
        }

        public AudioParams(int samplerate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE type, int samplesPerCall)
        {
            this.sample_rate = samplerate;
            this.channels = channel;
            this.mode = type;
            this.samples_per_call = samplesPerCall;
        }

    }

    ///
    /// <summary>
    /// The audio spectrum data.
    /// </summary>
    ///
    public class AudioSpectrumData
    {
        ///
        /// <summary>
        /// The audio spectrum data. Agora divides the audio frequency into 256 frequency domains, and reports the energy value of each frequency domain through this parameter. The value range of each energy type is [-300, 1] and the unit is dBFS.
        /// </summary>
        ///
        public float[] audioSpectrumData;

        ///
        /// <summary>
        /// The audio spectrum data length is 256.
        /// </summary>
        ///
        public int dataLength;

        public AudioSpectrumData()
        {
            this.audioSpectrumData = null;
            this.dataLength = 0;
        }

        public AudioSpectrumData(float[] data, int length)
        {
            this.audioSpectrumData = data;
            this.dataLength = length;
        }

    }

    ///
    /// <summary>
    /// Audio spectrum information of the remote user.
    /// </summary>
    ///
    public class UserAudioSpectrumInfo
    {
        ///
        /// <summary>
        /// The user ID of the remote user.
        /// </summary>
        ///
        public uint uid;

        ///
        /// <summary>
        /// Audio spectrum information of the remote user. See AudioSpectrumData.
        /// </summary>
        ///
        public AudioSpectrumData spectrumData;

        public UserAudioSpectrumInfo()
        {
            this.uid = 0;
        }

        public UserAudioSpectrumInfo(uint uid, float[] data, int length)
        {
            this.uid = uid;
            this.spectrumData = new AudioSpectrumData(data, length);
        }

        public UserAudioSpectrumInfo(uint uid, AudioSpectrumData spectrumData)
        {
            this.uid = uid;
            this.spectrumData = spectrumData;
        }
    }

    ///
    /// @ignore
    ///
    public enum VIDEO_FRAME_PROCESS_MODE
    {
        ///
        /// @ignore
        ///
        PROCESS_MODE_READ_ONLY,

        ///
        /// @ignore
        ///
        PROCESS_MODE_READ_WRITE,
    }

    ///
    /// <summary>
    /// The external video frame encoding type.
    /// </summary>
    ///
    public enum EXTERNAL_VIDEO_SOURCE_TYPE
    {
        ///
        /// <summary>
        /// 0: The video frame is not encoded.
        /// </summary>
        ///
        VIDEO_FRAME = 0,

        ///
        /// <summary>
        /// 1: The video frame is encoded.
        /// </summary>
        ///
        ENCODED_VIDEO_FRAME,
    }

    ///
    /// @ignore
    ///
    public enum MediaRecorderContainerFormat
    {
        ///
        /// @ignore
        ///
        FORMAT_MP4 = 1,
    }

    ///
    /// <summary>
    /// The recording content.
    /// </summary>
    ///
    public enum MediaRecorderStreamType
    {
        ///
        /// <summary>
        /// Only audio.
        /// </summary>
        ///
        STREAM_TYPE_AUDIO = 0x01,

        ///
        /// <summary>
        /// Only video.
        /// </summary>
        ///
        STREAM_TYPE_VIDEO = 0x02,

        ///
        /// <summary>
        /// (Default) Audio and video.
        /// </summary>
        ///
        STREAM_TYPE_BOTH = STREAM_TYPE_AUDIO | STREAM_TYPE_VIDEO,
    }

    ///
    /// <summary>
    /// The current recording state.
    /// </summary>
    ///
    public enum RecorderState
    {
        ///
        /// <summary>
        /// -1: An error occurs during the recording. See RecorderReasonCode for the reason.
        /// </summary>
        ///
        RECORDER_STATE_ERROR = -1,

        ///
        /// <summary>
        /// 2: The audio and video recording starts.
        /// </summary>
        ///
        RECORDER_STATE_START = 2,

        ///
        /// <summary>
        /// 3: The audio and video recording stops.
        /// </summary>
        ///
        RECORDER_STATE_STOP = 3,
    }

    ///
    /// <summary>
    /// The reason for the state change.
    /// </summary>
    ///
    public enum RecorderReasonCode
    {
        ///
        /// <summary>
        /// 0: No error.
        /// </summary>
        ///
        RECORDER_REASON_NONE = 0,

        ///
        /// @ignore
        ///
        RECORDER_REASON_WRITE_FAILED = 1,

        ///
        /// @ignore
        ///
        RECORDER_REASON_NO_STREAM = 2,

        ///
        /// @ignore
        ///
        RECORDER_REASON_OVER_MAX_DURATION = 3,

        ///
        /// @ignore
        ///
        RECORDER_REASON_CONFIG_CHANGED = 4,
    }

    ///
    /// @ignore
    ///
    public class MediaRecorderConfiguration
    {
        ///
        /// @ignore
        ///
        public string storagePath;

        ///
        /// @ignore
        ///
        public MediaRecorderContainerFormat containerFormat;

        ///
        /// @ignore
        ///
        public MediaRecorderStreamType streamType;

        ///
        /// @ignore
        ///
        public int maxDurationMs;

        ///
        /// @ignore
        ///
        public int recorderInfoUpdateInterval;

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
        public int fps;

        ///
        /// @ignore
        ///
        public int sample_rate;

        ///
        /// @ignore
        ///
        public int channel_num;

        ///
        /// @ignore
        ///
        public VIDEO_SOURCE_TYPE videoSourceType;

        public MediaRecorderConfiguration()
        {
            this.storagePath = "";
            this.containerFormat = MediaRecorderContainerFormat.FORMAT_MP4;
            this.streamType = MediaRecorderStreamType.STREAM_TYPE_BOTH;
            this.maxDurationMs = 120000;
            this.recorderInfoUpdateInterval = 0;
            this.width = 1280;
            this.height = 720;
            this.fps = 30;
            this.sample_rate = 48000;
            this.channel_num = 1;
            this.videoSourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
        }

        public MediaRecorderConfiguration(string path, MediaRecorderContainerFormat format, MediaRecorderStreamType type, int duration, int interval)
        {
            this.storagePath = path;
            this.containerFormat = format;
            this.streamType = type;
            this.maxDurationMs = duration;
            this.recorderInfoUpdateInterval = interval;
            this.width = 1280;
            this.height = 720;
            this.fps = 30;
            this.sample_rate = 48000;
            this.channel_num = 1;
            this.videoSourceType = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
        }

        public MediaRecorderConfiguration(string storagePath, MediaRecorderContainerFormat containerFormat, MediaRecorderStreamType streamType, int maxDurationMs, int recorderInfoUpdateInterval, int width, int height, int fps, int sample_rate, int channel_num, VIDEO_SOURCE_TYPE videoSourceType)
        {
            this.storagePath = storagePath;
            this.containerFormat = containerFormat;
            this.streamType = streamType;
            this.maxDurationMs = maxDurationMs;
            this.recorderInfoUpdateInterval = recorderInfoUpdateInterval;
            this.width = width;
            this.height = height;
            this.fps = fps;
            this.sample_rate = sample_rate;
            this.channel_num = channel_num;
            this.videoSourceType = videoSourceType;
        }
    }

    ///
    /// @ignore
    ///
    public class RecorderInfo
    {
        ///
        /// @ignore
        ///
        public string fileName;

        ///
        /// @ignore
        ///
        public uint durationMs;

        ///
        /// @ignore
        ///
        public uint fileSize;

        public RecorderInfo()
        {
            this.fileName = "";
            this.durationMs = 0;
            this.fileSize = 0;
        }

        public RecorderInfo(string name, uint dur, uint size)
        {
            this.fileName = name;
            this.durationMs = dur;
            this.fileSize = size;
        }

    }

    #endregion terra AgoraMediaBase.h
}