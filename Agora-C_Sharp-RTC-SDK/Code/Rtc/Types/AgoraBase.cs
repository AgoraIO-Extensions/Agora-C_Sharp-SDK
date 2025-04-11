using System;
using Agora.Rtc.LitJson;
using view_t = System.UInt64;
namespace Agora.Rtc
{

    internal enum AppType
    {
        APP_TYPE_NATIVE = 0,
        APP_TYPE_COCOS = 1,
        APP_TYPE_UNITY = 2,
        APP_TYPE_ELECTRON = 3,
        APP_TYPE_FLUTTER = 4,
        APP_TYPE_UNREAL = 5,
        APP_TYPE_XAMARIN = 6,
        APP_TYPE_API_CLOUD = 7,
        APP_TYPE_REACT_NATIVE = 8,
        APP_TYPE_PYTHON = 9,
        APP_TYPE_COCOS_CREATOR = 10,
        APP_TYPE_RUST = 11,
        APP_TYPE_C_SHARP = 12,
        APP_TYPE_CEF = 13,
        APP_TYPE_UNI_APP = 14
    }

    ///
    /// <summary>
    /// The information of the user.
    /// </summary>
    ///
    public class UserInfo
    {
        ///
        /// <summary>
        /// The user ID.
        /// </summary>
        ///
        public uint uid;

        ///
        /// <summary>
        /// User account. The maximum data length is MAX_USER_ACCOUNT_LENGTH_TYPE.
        /// </summary>
        ///
        public string userAccount;

        public UserInfo()
        {
            uid = 0;
            userAccount = "";
        }
    }

    ///
    /// <summary>
    /// The encoding bitrate of the video.
    /// </summary>
    ///
    public enum BITRATE
    {
        ///
        /// <summary>
        /// 0: (Recommended) Standard bitrate mode.
        /// </summary>
        ///
        STANDARD_BITRATE = 0,

        ///
        /// <summary>
        /// -1: Adaptive bitrate mode.
        /// </summary>
        ///
        COMPATIBLE_BITRATE = -1,

        ///
        /// @ignore
        ///
        DEFAULT_MIN_BITRATE = -1,

        ///
        /// @ignore
        ///
        DEFAULT_MIN_BITRATE_EQUAL_TO_TARGET_BITRATE = -2,
    }

    ///
    /// @ignore
    ///
    public class DownlinkNetworkInfo
    {
        ///
        /// @ignore
        ///
        public int lastmile_buffer_delay_time_ms;

        ///
        /// @ignore
        ///
        public int bandwidth_estimation_bps;

        ///
        /// @ignore
        ///
        public int total_downscale_level_count;

        ///
        /// @ignore
        ///
        public PeerDownlinkInfo[] peer_downlink_info;

        ///
        /// @ignore
        ///
        public int total_received_video_count;

        public DownlinkNetworkInfo()
        {
            this.lastmile_buffer_delay_time_ms = -1;
            this.bandwidth_estimation_bps = -1;
            this.total_downscale_level_count = -1;
            this.peer_downlink_info = new PeerDownlinkInfo[0];
            this.total_received_video_count = -1;
        }

        public DownlinkNetworkInfo(ref DownlinkNetworkInfo info)
        {
            this.lastmile_buffer_delay_time_ms = info.lastmile_buffer_delay_time_ms;
            this.bandwidth_estimation_bps = info.bandwidth_estimation_bps;
            this.total_downscale_level_count = info.total_downscale_level_count;
            this.total_received_video_count = info.total_received_video_count;

            if (total_received_video_count <= 0)
                return;
            peer_downlink_info = new PeerDownlinkInfo[total_received_video_count];
            for (int i = 0; i < total_received_video_count; i++)
            {
                peer_downlink_info[i] = info.peer_downlink_info[i];
            }
        }

        public DownlinkNetworkInfo(int lastmile_buffer_delay_time_ms, int bandwidth_estimation_bps, int total_downscale_level_count, PeerDownlinkInfo[] peer_downlink_info, int total_received_video_count)
        {
            this.lastmile_buffer_delay_time_ms = lastmile_buffer_delay_time_ms;
            this.bandwidth_estimation_bps = bandwidth_estimation_bps;
            this.total_downscale_level_count = total_downscale_level_count;
            this.peer_downlink_info = peer_downlink_info;
            this.total_received_video_count = total_received_video_count;
        }
    }

    ///
    /// <summary>
    /// Built-in encryption configurations.
    /// </summary>
    ///
    public class EncryptionConfig
    {
        ///
        /// <summary>
        /// The built-in encryption mode. See ENCRYPTION_MODE. Agora recommends using AES_128_GCM2 or AES_256_GCM2 encrypted mode. These two modes support the use of salt for higher security.
        /// </summary>
        ///
        public ENCRYPTION_MODE encryptionMode;

        ///
        /// <summary>
        /// Encryption key in string type with unlimited length. Agora recommends using a 32-byte key. If you do not set an encryption key or set it as NULL, you cannot use the built-in encryption, and the SDK returns -2.
        /// </summary>
        ///
        public string encryptionKey;

        ///
        /// <summary>
        /// Salt, 32 bytes in length. Agora recommends that you use OpenSSL to generate salt on the server side. See Media Stream Encryption for details. This parameter takes effect only in AES_128_GCM2 or AES_256_GCM2 encrypted mode. In this case, ensure that this parameter is not 0.
        /// </summary>
        ///
        public byte[] encryptionKdfSalt;

        ///
        /// <summary>
        /// Whether to enable data stream encryption: true : Enable data stream encryption. false : (Default) Disable data stream encryption.
        /// </summary>
        ///
        public bool datastreamEncryptionEnabled;

        public EncryptionConfig()
        {
            this.encryptionMode = ENCRYPTION_MODE.AES_128_GCM2;
            this.encryptionKey = "";
            this.encryptionKdfSalt = new byte[32];
            this.datastreamEncryptionEnabled = false;
        }

        public EncryptionConfig(ENCRYPTION_MODE encryptionMode, string encryptionKey, byte[] encryptionKdfSalt, bool datastreamEncryptionEnabled)
        {
            this.encryptionMode = encryptionMode;
            this.encryptionKey = encryptionKey;
            this.encryptionKdfSalt = encryptionKdfSalt;
            this.datastreamEncryptionEnabled = datastreamEncryptionEnabled;
        }

        public string GetEncryptionString()
        {
            switch (encryptionMode)
            {
                case ENCRYPTION_MODE.AES_128_XTS:
                    return "aes-128-xts";
                case ENCRYPTION_MODE.AES_128_ECB:
                    return "aes-128-ecb";
                case ENCRYPTION_MODE.AES_256_XTS:
                    return "aes-256-xts";
                case ENCRYPTION_MODE.SM4_128_ECB:
                    return "sm4-128-ecb";
                case ENCRYPTION_MODE.AES_128_GCM:
                    return "aes-128-gcm";
                case ENCRYPTION_MODE.AES_256_GCM:
                    return "aes-256-gcm";
                case ENCRYPTION_MODE.AES_128_GCM2:
                    return "aes-128-gcm-2";
                case ENCRYPTION_MODE.AES_256_GCM2:
                    return "aes-256-gcm-2";
                default:
                    return "aes-128-gcm-2";
            }
        }
    }

    ///
    /// <summary>
    /// The audio device information.
    /// 
    /// This class is for Android only.
    /// </summary>
    ///
    public class DeviceInfoMobile
    {
        ///
        /// <summary>
        /// Whether the audio device supports ultra-low-latency capture and playback: true : The device supports ultra-low-latency capture and playback. false : The device does not support ultra-low-latency capture and playback.
        /// </summary>
        ///
        public bool isLowLatencyAudioSupported;

        public DeviceInfoMobile()
        {
            this.isLowLatencyAudioSupported = false;
        }

        public DeviceInfoMobile(bool isLowLatencyAudioSupported)
        {
            this.isLowLatencyAudioSupported = isLowLatencyAudioSupported;
        }
    }

    ///
    /// <summary>
    /// The DeviceInfo class that contains the ID and device name of the video devices.
    /// </summary>
    ///
    public class DeviceInfo
    {
        ///
        /// <summary>
        /// The device name.
        /// </summary>
        ///
        public string deviceName;

        ///
        /// @ignore
        ///
        public string deviceTypeName;

        ///
        /// <summary>
        /// The device ID.
        /// </summary>
        ///
        public string deviceId;
    };
}