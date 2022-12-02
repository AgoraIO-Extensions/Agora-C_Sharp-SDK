using System;
using System.Runtime.InteropServices;
using Agora.Rtc;
namespace Agora.Rtc
{
    [StructLayout(LayoutKind.Sequential)]
    public struct IrisCApiParam2
    {

        public string Result
        {
            get
            {
                var re = Marshal.PtrToStringAnsi(result);
                return re;
            }
        }

        public void AllocResult()
        {
            if (result == IntPtr.Zero)
            {
                result = Marshal.AllocHGlobal(65536);
            }
        }

        public void FreeResult()
        {
            if (result != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(result);
                result = IntPtr.Zero;
            }
        }


        public string @event;
        public string data;
        public uint data_size;

        public IntPtr result;

        public IntPtr buffer;
        public IntPtr length;
        public uint buffer_count;
    }


    public class ParamsHelper
    {

        #region init
        public static void InitParam(out string param)
        {
            param = "10";
        }


        public static void InitParam(out uint param)
        {
            param = 10;
        }

        public static void InitParam(out int param)
        {
            param = 10;
        }

        public static void InitParam(out float param)
        {
            param = 10.22f;
        }

        public static void InitParam(out bool param)
        {
            param = true;
        }

        public static void InitParam(out RtcEngineContext param)
        {
            string appId = "asdsdsdasda";
            UInt64 context = 0;

            CHANNEL_PROFILE_TYPE channelProfile = CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_COMMUNICATION;
            string license = "sdsd";
            AUDIO_SCENARIO_TYPE audioScenario = AUDIO_SCENARIO_TYPE.AUDIO_SCENARIO_CHATROOM;
            AREA_CODE areaCode = AREA_CODE.AREA_CODE_CN;
            LogConfig logConfig = new LogConfig("/Users/xiayangqun/Documents/agoraSpace/ut.log");

            param = new RtcEngineContext(appId, context, channelProfile, audioScenario, areaCode, logConfig);
        }

        public static void InitParam(out ChannelMediaOptions param)
        {
            param = new ChannelMediaOptions();
            param.publishCameraTrack.SetValue(true);
            param.publishCustomAudioSourceId.SetValue(1);
        }

        public static void InitParam(out LeaveChannelOptions param)
        {
            param = new LeaveChannelOptions();
            param.stopAllEffect = true;
        }


        public static void InitParam(out CLIENT_ROLE_TYPE param)
        {
            param = CLIENT_ROLE_TYPE.CLIENT_ROLE_AUDIENCE;
        }


        public static void InitParam(out EchoTestConfiguration param)
        {
            param = new EchoTestConfiguration();
            param.channelId = "1232";
        }


        public static void InitParam(out CameraCapturerConfiguration param)
        {
            param = new CameraCapturerConfiguration();
            param.cameraDirection = CAMERA_DIRECTION.CAMERA_FRONT;
        }


        public static void InitParam(out VIDEO_SOURCE_TYPE param)
        {
            param = VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA;
        }

        public static void InitParam(out LastmileProbeConfig param)
        {
            param = new LastmileProbeConfig();
            param.probeDownlink = false;
        }

        public static void InitParam(out BeautyOptions param)
        {
            param = new BeautyOptions();
            param.rednessLevel = 0.5f;
        }

        public static void InitParam(out MEDIA_SOURCE_TYPE param)
        {
            param = MEDIA_SOURCE_TYPE.AUDIO_PLAYOUT_SOURCE;
        }

        public static void InitParam(out VirtualBackgroundSource param)
        {
            param = new VirtualBackgroundSource();
            param.background_source_type = BACKGROUND_SOURCE_TYPE.BACKGROUND_BLUR;
        }



        public static void InitParam(out CHANNEL_PROFILE_TYPE param)
        {
            param = CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_COMMUNICATION;
        }
        public static void InitParam(out ClientRoleOptions param)
        {
            param = new ClientRoleOptions();
            param.audienceLatencyLevel = AUDIENCE_LATENCY_LEVEL_TYPE.AUDIENCE_LATENCY_LEVEL_LOW_LATENCY;
        }
        public static void InitParam(out VideoEncoderConfiguration param)
        {
            param = new VideoEncoderConfiguration();
        }

        public static void InitParam(out LowlightEnhanceOptions param)
        {
            param = new LowlightEnhanceOptions();
        }
        public static void InitParam(out VideoDenoiserOptions param)
        {
            param = new VideoDenoiserOptions();
        }
        public static void InitParam(out ColorEnhanceOptions param)
        {
            param = new ColorEnhanceOptions();
        }
        public static void InitParam(out SegmentationProperty param)
        {
            param = new SegmentationProperty();
        }
        public static void InitParam(out VideoCanvas param)
        {
            param = new VideoCanvas();
        }
        public static void InitParam(out AUDIO_SCENARIO_TYPE param)
        {
            param = AUDIO_SCENARIO_TYPE.AUDIO_SCENARIO_CHATROOM;
        }
        public static void InitParam(out AUDIO_PROFILE_TYPE param)
        {
            param = AUDIO_PROFILE_TYPE.AUDIO_PROFILE_DEFAULT;
        }
        public static void InitParam(out VideoSubscriptionOptions param)
        {
            param = new VideoSubscriptionOptions();
        }
        public static void InitParam(out AUDIO_RECORDING_QUALITY_TYPE param)
        {
            param = AUDIO_RECORDING_QUALITY_TYPE.AUDIO_RECORDING_QUALITY_HIGH;
        }
        public static void InitParam(out AudioRecordingConfiguration param)
        {
            param = new AudioRecordingConfiguration();
        }
        public static void InitParam(out AudioEncodedFrameObserverConfig param)
        {
            param = new AudioEncodedFrameObserverConfig();
        }
        public static void InitParam(out IAudioEncodedFrameObserver param)
        {
            param = new UTAudioEncodedFrameObserver();
        }
        public static void InitParam(out AUDIO_MIXING_DUAL_MONO_MODE param)
        {
            param = AUDIO_MIXING_DUAL_MONO_MODE.AUDIO_MIXING_DUAL_MONO_AUTO;
        }
        public static void InitParam(out double param)
        {
            param = 23232.123;
        }
        public static void InitParam(out SpatialAudioParams param)
        {
            param = new SpatialAudioParams();
            param.enable_air_absorb.SetValue(true);
        }
        public static void InitParam(out VOICE_BEAUTIFIER_PRESET param)
        {
            param = VOICE_BEAUTIFIER_PRESET.CHAT_BEAUTIFIER_FRESH;
        }
        public static void InitParam(out AUDIO_EFFECT_PRESET param)
        {
            param = AUDIO_EFFECT_PRESET.AUDIO_EFFECT_OFF;
        }
        public static void InitParam(out VOICE_CONVERSION_PRESET param)
        {
            param = VOICE_CONVERSION_PRESET.VOICE_CHANGER_BASS;
        }
        public static void InitParam(out AUDIO_EQUALIZATION_BAND_FREQUENCY param)
        {
            param = AUDIO_EQUALIZATION_BAND_FREQUENCY.AUDIO_EQUALIZATION_BAND_125;
        }
        public static void InitParam(out AUDIO_REVERB_TYPE param)
        {
            param = AUDIO_REVERB_TYPE.AUDIO_REVERB_DRY_LEVEL;
        }
        public static void InitParam(out HEADPHONE_EQUALIZER_PRESET param)
        {
            param = HEADPHONE_EQUALIZER_PRESET.HEADPHONE_EQUALIZER_INEAR;
        }
        public static void InitParam(out LOG_LEVEL param)
        {
            param = LOG_LEVEL.LOG_LEVEL_ERROR;
        }
        public static void InitParam(out RENDER_MODE_TYPE param)
        {
            param = RENDER_MODE_TYPE.RENDER_MODE_FIT;
        }
        public static void InitParam(out VIDEO_MIRROR_MODE_TYPE param)
        {
            param = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_DISABLED;
        }
        public static void InitParam(out SimulcastStreamConfig param)
        {
            param = new SimulcastStreamConfig();
        }
        public static void InitParam(out SIMULCAST_STREAM_MODE param)
        {
            param = SIMULCAST_STREAM_MODE.AUTO_SIMULCAST_STREAM;
        }
        public static void InitParam(out AudioTrackConfig param)
        {
            param = new AudioTrackConfig();
        }
        public static void InitParam(out RAW_AUDIO_FRAME_OP_MODE_TYPE param)
        {
            param = RAW_AUDIO_FRAME_OP_MODE_TYPE.RAW_AUDIO_FRAME_OP_MODE_READ_WRITE;
        }
        public static void InitParam(out IAudioSpectrumObserver param)
        {
            param = new UTIAudioSpectrumObserver();
        }
        public static void InitParam(out ExtensionInfo param)
        {
            param = new ExtensionInfo();
        }
        public static void InitParam(out SenderOptions param)
        {
            param = new SenderOptions();
        }
        public static void InitParam(out AUDIO_SESSION_OPERATION_RESTRICTION param)
        {
            param = AUDIO_SESSION_OPERATION_RESTRICTION.AUDIO_SESSION_OPERATION_RESTRICTION_CONFIGURE_SESSION;
        }
        public static void InitParam(out Rectangle param)
        {
            param = new Rectangle(0, 0, 640, 360);
        }
        public static void InitParam(out ScreenCaptureParameters param)
        {
            param = new ScreenCaptureParameters();
        }
        public static void InitParam(out DeviceInfo param)
        {
            param = new DeviceInfo();
        }
        public static void InitParam(out VIDEO_CONTENT_HINT param)
        {
            param = VIDEO_CONTENT_HINT.CONTENT_HINT_MOTION;
        }
        public static void InitParam(out SCREEN_SCENARIO_TYPE param)
        {
            param = SCREEN_SCENARIO_TYPE.SCREEN_SCENARIO_GAMING;
        }
        public static void InitParam(out ScreenCaptureParameters2 param)
        {
            param = new ScreenCaptureParameters2();
        }
        public static void InitParam(out LiveTranscoding param)
        {
            param = new LiveTranscoding();
        }
        public static void InitParam(out LocalTranscoderConfiguration param)
        {
            param = new LocalTranscoderConfiguration();
        }
        public static void InitParam(out VIDEO_ORIENTATION param)
        {
            param = VIDEO_ORIENTATION.VIDEO_ORIENTATION_180;
        }
        public static void InitParam(out ScreenCaptureConfiguration param)
        {
            param = new ScreenCaptureConfiguration();
        }
        public static void InitParam(out IRtcEngineEventHandler param)
        {
            param = new UTRtcEngineEventHandler();
        }
        public static void InitParam(out PRIORITY_TYPE param)
        {
            param = PRIORITY_TYPE.PRIORITY_NORMAL;
        }
        public static void InitParam(out EncryptionConfig param)
        {
            param = new EncryptionConfig();
        }
        public static void InitParam(out byte[] param)
        {
            param = new byte[10];
        }
        public static void InitParam(out ulong param)
        {
            param = 10;
        }
        public static void InitParam(out RtcImage param)
        {
            param = new RtcImage();
        }
        public static void InitParam(out WatermarkOptions param)
        {
            param = new WatermarkOptions();
        }

        public static void InitParam(out STREAM_FALLBACK_OPTIONS param)
        {
            param = STREAM_FALLBACK_OPTIONS.STREAM_FALLBACK_OPTION_DISABLED;
        }
        public static void InitParam(out SIZE param)
        {
            param = new SIZE();
        }
        public static void InitParam(out IMetadataObserver param)
        {
            param = new UTMetadataObserver();
        }
        public static void InitParam(out METADATA_TYPE param)
        {
            param = METADATA_TYPE.VIDEO_METADATA;
        }
        public static void InitParam(out long param)
        {
            param = 10;
        }
        public static void InitParam(out UserInfo param)
        {
            param = new UserInfo();
        }
        public static void InitParam(out ChannelMediaRelayConfiguration param)
        {
            param = new ChannelMediaRelayConfiguration();
        }
        public static void InitParam(out DirectCdnStreamingMediaOptions param)
        {
            param = new DirectCdnStreamingMediaOptions();
        }
        public static void InitParam(out AgoraRhythmPlayerConfig param)
        {
            param = new AgoraRhythmPlayerConfig();
        }
        public static void InitParam(out ContentInspectConfig param)
        {
            param = new ContentInspectConfig();
            param.modules = new ContentInspectModule[3];
            param.moduleCount = param.modules.Length;
        }
        public static void InitParam(out CLOUD_PROXY_TYPE param)
        {
            param = CLOUD_PROXY_TYPE.TCP_PROXY;
        }
        public static void InitParam(out LocalAccessPointConfiguration param)
        {
            param = new LocalAccessPointConfiguration();
            param.advancedConfig.logUploadServer.serverPath = "serverPath";
            param.advancedConfig.logUploadServer.serverDomain = "serverDomain";

        }
        public static void InitParam(out AdvancedAudioOptions param)
        {
            param = new AdvancedAudioOptions();
        }
        public static void InitParam(out ImageTrackOptions param)
        {
            param = new ImageTrackOptions();
        }

        public static void InitParam(out DataStreamConfig param)
        {
            param = new DataStreamConfig();
        }
        public static void InitParam(out VIDEO_STREAM_TYPE param)
        {
            param = VIDEO_STREAM_TYPE.VIDEO_STREAM_HIGH;
        }
        public static void InitParam(out uint[] param)
        {
            param = new uint[10];
        }
        public static void InitParam(out RtcConnection param)
        {
            param = new RtcConnection();
            param.channelId = "unity";
            param.localUid = 123;
        }
        public static void InitParam(out MediaSource param)
        {
            param = new MediaSource();

        }
        public static void InitParam(out PlayerStreamInfo param)
        {
            param = new PlayerStreamInfo();
        }
        public static void InitParam(out IMediaPlayerCustomDataProvider param)
        {
            param = new UTMediaPlayerCustomDataProvider();
        }
        public static void InitParam(out IMediaPlayerSourceObserver param)
        {
            param = new UTMediaPlayerSourceObserver();
        }
        public static void InitParam(out IMediaPlayerAudioFrameObserver param)
        {
            param = new UTMediaPlayerAudioFrameObserver();
        }
        public static void InitParam(out AUDIO_DUAL_MONO_MODE param)
        {
            param = AUDIO_DUAL_MONO_MODE.AUDIO_DUAL_MONO_MIX;
        }
        public static void InitParam(out MusicContentCenterConfiguration param)
        {
            param = new MusicContentCenterConfiguration();
            param.appId = "223231231";
            param.token = "dsadadasdasd";
            param.mccUid = 123;
        }
        public static void InitParam(out IMusicContentCenterEventHandler param)
        {
            param = new UTMusicContentCenterEventHandler();
        }
        public static void InitParam(out VideoFormat param)
        {
            param = new VideoFormat();
        }
        public static void InitParam(out IntPtr param)
        {
            UInt64 number = 10086;
            param = (IntPtr)(number);
        }
        public static void InitParam(out IMediaRecorderObserver param)
        {
            param = new UTMediaRecorderObserver();
        }
        public static void InitParam(out MediaRecorderConfiguration param)
        {
            param = new MediaRecorderConfiguration();
            param.storagePath = "/xiayangqun";
        }
        public static void InitParam(out float[] param)
        {
            param = new float[3];
            param[0] = 2.3f;
            param[1] = 2.45f;
            param[2] = 3.44f;
        }
        public static void InitParam(out RemoteVoicePositionInfo param)
        {
            float[] pos = new float[3];
            pos[0] = 2.3f;
            pos[1] = 3.23f;
            pos[2] = 2.213f;

            float[] forward = new float[3];
            forward[0] = 2.34f;
            forward[1] = 3.44f;
            forward[2] = 22.3f;

            param = new RemoteVoicePositionInfo(pos, forward);
        }
        public static void InitParam(out SpatialAudioZone[] param)
        {
            param = new SpatialAudioZone[10];
            for (var i = 0; i < 10; i++)
            {
                var spatialAudioZone = new SpatialAudioZone();
                spatialAudioZone.zoneSetId = i;
                spatialAudioZone.position = new float[] { 1, 2, 3 };

                spatialAudioZone.forward = new float[] { 1, 2, 3 };

                spatialAudioZone.right = new float[] { 1, 2, 3 };

                spatialAudioZone.up = new float[] { 1, 2, 3 };

                spatialAudioZone.forwardLength = 3;

                spatialAudioZone.rightLength = 3;

                spatialAudioZone.upLength = 3;
                spatialAudioZone.audioAttenuation = i;
            }
        }
        public static void InitParam(out STREAM_PUBLISH_STATE param)
        {
            param = STREAM_PUBLISH_STATE.PUB_STATE_IDLE;
        }
        public static void InitParam(out STREAM_SUBSCRIBE_STATE param)
        {
            param = STREAM_SUBSCRIBE_STATE.SUB_STATE_IDLE;
        }
        public static void InitParam(out UPLOAD_ERROR_REASON param)
        {
            param = UPLOAD_ERROR_REASON.UPLOAD_SUCCESS;
        }
        public static void InitParam(out PERMISSION_TYPE param)
        {
            param = PERMISSION_TYPE.RECORD_AUDIO;
        }
        public static void InitParam(out RTMP_STREAMING_EVENT param)
        {
            param = RTMP_STREAMING_EVENT.RTMP_STREAMING_EVENT_FAILED_LOAD_IMAGE;
        }
        public static void InitParam(out RTMP_STREAM_PUBLISH_STATE param)
        {
            param = RTMP_STREAM_PUBLISH_STATE.RTMP_STREAM_PUBLISH_STATE_IDLE;
        }
        public static void InitParam(out RTMP_STREAM_PUBLISH_ERROR_TYPE param)
        {
            param = RTMP_STREAM_PUBLISH_ERROR_TYPE.RTMP_STREAM_PUBLISH_ERROR_OK;
        }
        public static void InitParam(out MEDIA_DEVICE_TYPE param)
        {
            param = MEDIA_DEVICE_TYPE.UNKNOWN_AUDIO_DEVICE;
        }
        public static void InitParam(out CONTENT_INSPECT_RESULT param)
        {
            param = CONTENT_INSPECT_RESULT.CONTENT_INSPECT_NEUTRAL;
        }
        public static void InitParam(out RHYTHM_PLAYER_STATE_TYPE param)
        {
            param = RHYTHM_PLAYER_STATE_TYPE.RHYTHM_PLAYER_STATE_IDLE;
        }
        public static void InitParam(out RHYTHM_PLAYER_ERROR_TYPE param)
        {
            param = RHYTHM_PLAYER_ERROR_TYPE.RHYTHM_PLAYER_ERROR_OK;
        }
        public static void InitParam(out AUDIO_MIXING_STATE_TYPE param)
        {
            param = AUDIO_MIXING_STATE_TYPE.AUDIO_MIXING_STATE_PLAYING;
        }
        public static void InitParam(out AUDIO_MIXING_REASON_TYPE param)
        {
            param = AUDIO_MIXING_REASON_TYPE.AUDIO_MIXING_REASON_CAN_NOT_OPEN;
        }
        public static void InitParam(out int[] param)
        {
            param = new int[10];
            for (var i = 0; i < param.Length; i++)
            {
                param[i] = 10;
            }
        }
        public static void InitParam(out DownlinkNetworkInfo param)
        {
            var info = new PeerDownlinkInfo[10];
            for (int i = 0; i < info.Length; i++)
            {
                InitParam(out info[i]);
            }

            param = new DownlinkNetworkInfo(10, 10, 10, info, 10);
        }

        public static void InitParam(out PeerDownlinkInfo param)
        {
            param = new PeerDownlinkInfo();
            param.current_downscale_level = REMOTE_VIDEO_DOWNSCALE_LEVEL.REMOTE_VIDEO_DOWNSCALE_LEVEL_NONE;
            param.uid = "10";
            param.stream_type = VIDEO_STREAM_TYPE.VIDEO_STREAM_HIGH;
            param.expected_bitrate_bps = 10;
        }



        public static void InitParam(out UplinkNetworkInfo param)
        {
            param = new UplinkNetworkInfo(10);
        }
        public static void InitParam(out MEDIA_DEVICE_STATE_TYPE param)
        {
            param = MEDIA_DEVICE_STATE_TYPE.MEDIA_DEVICE_STATE_IDLE;
        }
        public static void InitParam(out LastmileProbeResult param)
        {
            param = new LastmileProbeResult();

        }
        public static void InitParam(out PROXY_TYPE param)
        {
            param = PROXY_TYPE.NONE_PROXY_TYPE;
        }
        public static void InitParam(out ENCRYPTION_ERROR_TYPE param)
        {
            param = ENCRYPTION_ERROR_TYPE.ENCRYPTION_ERROR_INTERNAL_FAILURE;
        }
        public static void InitParam(out NETWORK_TYPE param)
        {
            param = NETWORK_TYPE.NETWORK_TYPE_UNKNOWN;
        }
        public static void InitParam(out WlAccStats param)
        {
            param = new WlAccStats();
        }
        public static void InitParam(out WLACC_MESSAGE_REASON param)
        {
            param = WLACC_MESSAGE_REASON.WLACC_MESSAGE_REASON_WEAK_SIGNAL;
        }
        public static void InitParam(out WLACC_SUGGEST_ACTION param)
        {
            param = WLACC_SUGGEST_ACTION.WLACC_SUGGEST_ACTION_CLOSE_TO_WIFI;
        }
        public static void InitParam(out CONNECTION_STATE_TYPE param)
        {
            param = CONNECTION_STATE_TYPE.CONNECTION_STATE_DISCONNECTED;
        }
        public static void InitParam(out CONNECTION_CHANGED_REASON_TYPE param)
        {
            param = CONNECTION_CHANGED_REASON_TYPE.CONNECTION_CHANGED_CONNECTING;
        }
        public static void InitParam(out UInt16 param)
        {
            param = 10;
        }
        public static void InitParam(out CLIENT_ROLE_CHANGE_FAILED_REASON param)
        {
            param = CLIENT_ROLE_CHANGE_FAILED_REASON.CLIENT_ROLE_CHANGE_FAILED_TOO_MANY_BROADCASTERS;
        }
        public static void InitParam(out REMOTE_AUDIO_STATE param)
        {
            param = REMOTE_AUDIO_STATE.REMOTE_AUDIO_STATE_STOPPED;
        }
        public static void InitParam(out REMOTE_AUDIO_STATE_REASON param)
        {
            param = REMOTE_AUDIO_STATE_REASON.REMOTE_AUDIO_REASON_INTERNAL;
        }
        public static void InitParam(out LOCAL_AUDIO_STREAM_STATE param)
        {
            param = LOCAL_AUDIO_STREAM_STATE.LOCAL_AUDIO_STREAM_STATE_STOPPED;
        }
        public static void InitParam(out LOCAL_AUDIO_STREAM_ERROR param)
        {
            param = LOCAL_AUDIO_STREAM_ERROR.LOCAL_AUDIO_STREAM_ERROR_OK;
        }
        public static void InitParam(out LICENSE_ERROR_TYPE param)
        {
            param = LICENSE_ERROR_TYPE.LICENSE_ERR_INVALID;
        }
        public static void InitParam(out RemoteVideoStats param)
        {
            param = new RemoteVideoStats();
        }
        public static void InitParam(out LocalVideoStats param)
        {
            param = new LocalVideoStats();
        }
        public static void InitParam(out RemoteAudioStats param)
        {
            param = new RemoteAudioStats();
        }
        public static void InitParam(out LocalAudioStats param)
        {
            param = new LocalAudioStats();
        }
        public static void InitParam(out USER_OFFLINE_REASON_TYPE param)
        {
            param = USER_OFFLINE_REASON_TYPE.USER_OFFLINE_QUIT;
        }
        public static void InitParam(out REMOTE_VIDEO_STATE param)
        {
            param = REMOTE_VIDEO_STATE.REMOTE_VIDEO_STATE_STOPPED;
        }
        public static void InitParam(out REMOTE_VIDEO_STATE_REASON param)
        {
            param = REMOTE_VIDEO_STATE_REASON.REMOTE_VIDEO_STATE_REASON_INTERNAL;
        }
        public static void InitParam(out LOCAL_VIDEO_STREAM_STATE param)
        {
            param = LOCAL_VIDEO_STREAM_STATE.LOCAL_VIDEO_STREAM_STATE_STOPPED;
        }
        public static void InitParam(out LOCAL_VIDEO_STREAM_ERROR param)
        {
            param = LOCAL_VIDEO_STREAM_ERROR.LOCAL_VIDEO_STREAM_ERROR_OK;
        }
        public static void InitParam(out RtcStats param)
        {
            param = new RtcStats();
        }
        public static void InitParam(out AudioVolumeInfo[] param)
        {
            param = new AudioVolumeInfo[10];
            for (int i = 0; i < param.Length; i++)
            {
                param[i] = new AudioVolumeInfo();
            }
        }
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        //public static void InitParam(out VirtualBackgroundSource param)
        //{
        //    param =
        //}
        #endregion


        #region compare
        public static bool compareRtcConnection(RtcConnection selfParam, RtcConnection outParam)
        {
            if (compareUint(selfParam.localUid, outParam.localUid) == false)
                return false;

            if (compareString(selfParam.channelId, outParam.channelId) == false)
                return false;

            return true;
        }

        public static bool compareUint(uint selfParam, uint outParam)
        {
            return selfParam == 10;
        }

        public static bool compareUlong(ulong selfParam, ulong outParam)
        {
            return selfParam == 10;
        }

        public static bool compareInt(int selfParam, int outParam)
        {
            return selfParam == 10;
        }

        public static bool compareRHYTHM_PLAYER_STATE_TYPE(RHYTHM_PLAYER_STATE_TYPE selfParam, RHYTHM_PLAYER_STATE_TYPE outParam)
        {
            return selfParam == RHYTHM_PLAYER_STATE_TYPE.RHYTHM_PLAYER_STATE_IDLE;
        }

        public static bool compareRHYTHM_PLAYER_ERROR_TYPE(RHYTHM_PLAYER_ERROR_TYPE selfParam, RHYTHM_PLAYER_ERROR_TYPE outParam)
        {
            return selfParam == RHYTHM_PLAYER_ERROR_TYPE.RHYTHM_PLAYER_ERROR_OK;
        }

        public static bool compareIntArray(int[] selfParam, int[] outParam)
        {
            if (selfParam.Length != 10)
                return false;

            foreach (var e in selfParam)
            {
                if (e != 10)
                    return false;
            }

            return true;
        }

        public static bool compareString(string selfParam, string outParam)
        {
            return selfParam == "10";
        }

        public static bool compareCHANNEL_PROFILE_TYPE(CHANNEL_PROFILE_TYPE selfParam, CHANNEL_PROFILE_TYPE outParam)
        {
            return selfParam == CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_COMMUNICATION;
        }

        public static bool compareWARN_CODE_TYPE(WARN_CODE_TYPE selfParam, WARN_CODE_TYPE outParam)
        {
            return selfParam == WARN_CODE_TYPE.WARN_INVALID_VIEW;
        }

        public static bool compareERROR_CODE_TYPE(ERROR_CODE_TYPE selfParam, ERROR_CODE_TYPE outParam)
        {
            return selfParam == ERROR_CODE_TYPE.ERR_OK;
        }

        public static bool compareLICENSE_ERROR_TYPE(LICENSE_ERROR_TYPE selfParam, LICENSE_ERROR_TYPE outParam)
        {
            return selfParam == LICENSE_ERROR_TYPE.LICENSE_ERR_INVALID;
        }

        public static bool compareAUDIO_SESSION_OPERATION_RESTRICTION(AUDIO_SESSION_OPERATION_RESTRICTION selfParam, AUDIO_SESSION_OPERATION_RESTRICTION outParam)
        {
            return selfParam == AUDIO_SESSION_OPERATION_RESTRICTION.AUDIO_SESSION_OPERATION_RESTRICTION_NONE;
        }

        public static bool compareBool(bool selfParam, bool outParam)
        {
            return true;
        }

        public static bool compareUserInfo(UserInfo selfParam, UserInfo outParam)
        {
            if (compareString(selfParam.userAccount, outParam.userAccount) == false)
                return false;
            if (compareUint(selfParam.uid, outParam.uid) == false)
                return false;
            return true;
        }

        public static bool compareUSER_OFFLINE_REASON_TYPE(USER_OFFLINE_REASON_TYPE selfParam, USER_OFFLINE_REASON_TYPE outParam)
        {
            return selfParam == USER_OFFLINE_REASON_TYPE.USER_OFFLINE_QUIT;
        }


        public static bool compareQUALITY_TYPE(QUALITY_TYPE selfParam, QUALITY_TYPE outParam)
        {
            return selfParam == QUALITY_TYPE.QUALITY_UNKNOWN;
        }

        public static bool compareFIT_MODE_TYPE(FIT_MODE_TYPE selfParam, FIT_MODE_TYPE outParam)
        {
            return selfParam == FIT_MODE_TYPE.MODE_COVER;
        }

        public static bool compareVIDEO_ORIENTATION(VIDEO_ORIENTATION selfParam, VIDEO_ORIENTATION outParam)
        {
            return selfParam == VIDEO_ORIENTATION.VIDEO_ORIENTATION_0;
        }

        public static bool compareFRAME_RATE(FRAME_RATE selfParam, FRAME_RATE outParam)
        {
            return selfParam == FRAME_RATE.FRAME_RATE_FPS_1;
        }

        public static bool compareFRAME_WIDTH(FRAME_WIDTH selfParam, FRAME_WIDTH outParam)
        {
            return selfParam == FRAME_WIDTH.FRAME_WIDTH_640;
        }

        public static bool compareFRAME_HEIGHT(FRAME_HEIGHT selfParam, FRAME_HEIGHT outParam)
        {
            return selfParam == FRAME_HEIGHT.FRAME_HEIGHT_360;
        }

        public static bool compareVIDEO_FRAME_TYPE(VIDEO_FRAME_TYPE selfParam, VIDEO_FRAME_TYPE outParam)
        {
            return selfParam == VIDEO_FRAME_TYPE.VIDEO_FRAME_TYPE_BLANK_FRAME;
        }

        public static bool compareORIENTATION_MODE(ORIENTATION_MODE selfParam, ORIENTATION_MODE outParam)
        {
            return selfParam == ORIENTATION_MODE.ORIENTATION_MODE_ADAPTIVE;
        }

        public static bool compareDEGRADATION_PREFERENCE(DEGRADATION_PREFERENCE selfParam, DEGRADATION_PREFERENCE outParam)
        {
            return selfParam == DEGRADATION_PREFERENCE.MAINTAIN_QUALITY;
        }

        public static bool compareVideoDimensions(VideoDimensions selfParam, VideoDimensions outParam)
        {
            if (compareInt(selfParam.width, outParam.width) == false)
                return false;
            if (compareInt(selfParam.height, outParam.height) == false)
                return false;
            return true;
        }

        public static bool compareVIDEO_CODEC_TYPE(VIDEO_CODEC_TYPE selfParam, VIDEO_CODEC_TYPE outParam)
        {
            return selfParam == VIDEO_CODEC_TYPE.VIDEO_CODEC_NONE;
        }

        public static bool compareTCcMode(TCcMode selfParam, TCcMode outParam)
        {
            return selfParam == TCcMode.CC_ENABLED;
        }

        public static bool compareSenderOptions(SenderOptions selfParam, SenderOptions outParam)
        {
            if (compareTCcMode(selfParam.ccMode, outParam.ccMode) == false)
                return false;
            if (compareVIDEO_CODEC_TYPE(selfParam.codecType, outParam.codecType) == false)
                return false;
            if (compareInt(selfParam.targetBitrate, outParam.targetBitrate) == false)
                return false;
            return true;
        }

        public static bool compareAUDIO_CODEC_TYPE(AUDIO_CODEC_TYPE selfParam, AUDIO_CODEC_TYPE outParam)
        {
            return selfParam == AUDIO_CODEC_TYPE.AUDIO_CODEC_OPUS;
        }

        public static bool compareAUDIO_ENCODING_TYPE(AUDIO_ENCODING_TYPE selfParam, AUDIO_ENCODING_TYPE outParam)
        {
            return selfParam == AUDIO_ENCODING_TYPE.AUDIO_ENCODING_TYPE_AAC_16000_LOW;
        }

        public static bool compareWATERMARK_FIT_MODE(WATERMARK_FIT_MODE selfParam, WATERMARK_FIT_MODE outParam)
        {
            return selfParam == WATERMARK_FIT_MODE.FIT_MODE_COVER_POSITION;
        }

        public static bool compareEncodedAudioFrameAdvancedSettings(EncodedAudioFrameAdvancedSettings selfParam, EncodedAudioFrameAdvancedSettings outParam)
        {
            if (compareBool(selfParam.speech, outParam.speech) == false)
                return false;
            if (compareBool(selfParam.sendEvenIfEmpty, outParam.sendEvenIfEmpty) == false)
                return false;
            return true;
        }

        public static bool compareEncodedAudioFrameInfo(EncodedAudioFrameInfo selfParam, EncodedAudioFrameInfo outParam)
        {
            if (compareAUDIO_CODEC_TYPE(selfParam.codec, outParam.codec) == false)
                return false;
            if (compareInt(selfParam.sampleRateHz, outParam.sampleRateHz) == false)
                return false;
            if (compareInt(selfParam.samplesPerChannel, outParam.samplesPerChannel) == false)
                return false;
            if (compareInt(selfParam.numberOfChannels, outParam.numberOfChannels) == false)
                return false;
            if (compareEncodedAudioFrameAdvancedSettings(selfParam.advancedSettings, outParam.advancedSettings) == false)
                return false;
            if (compareInt64_t(selfParam.captureTimeMs, outParam.captureTimeMs) == false)
                return false;
            return true;
        }

        public static bool compareInt64_t(long selfParam, long outParam)
        {
            return selfParam == 10;
        }

        public static bool compareSize_t(uint selfParam, uint outParam)
        {
            return selfParam == 10;
        }

        public static bool compareInt16_t(short selfParam, short outParam)
        {
            return selfParam == 10;
        }


        public static bool compareAudioPcmDataInfo(AudioPcmDataInfo selfParam, AudioPcmDataInfo outParam)
        {
            if (compareSize_t(selfParam.samplesPerChannel, outParam.samplesPerChannel) == false)
                return false;
            if (compareInt16_t(selfParam.channelNum, outParam.channelNum) == false)
                return false;
            if (compareSize_t(selfParam.samplesOut, outParam.samplesOut) == false)
                return false;
            if (compareInt64_t(selfParam.elapsedTimeMs, outParam.elapsedTimeMs) == false)
                return false;
            if (compareInt64_t(selfParam.ntpTimeMs, outParam.ntpTimeMs) == false)
                return false;
            return true;
        }

        public static bool compareH264PacketizeMode(H264PacketizeMode selfParam, H264PacketizeMode outParam)
        {
            return selfParam == H264PacketizeMode.NonInterleaved;
        }

        public static bool compareVIDEO_STREAM_TYPE(VIDEO_STREAM_TYPE selfParam, VIDEO_STREAM_TYPE outParam)
        {
            return selfParam == VIDEO_STREAM_TYPE.VIDEO_STREAM_HIGH;
        }

        public static bool compareVIDEO_FRAME_TYPE_NATIVE(VIDEO_FRAME_TYPE_NATIVE selfParam, VIDEO_FRAME_TYPE_NATIVE outParam)
        {
            return selfParam == VIDEO_FRAME_TYPE_NATIVE.VIDEO_FRAME_TYPE_BLANK_FRAME;
        }

        public static bool compareEncodedVideoFrameInfo(EncodedVideoFrameInfo selfParam, EncodedVideoFrameInfo outParam)
        {
            if (compareVIDEO_CODEC_TYPE(selfParam.codecType, outParam.codecType) == false)
                return false;
            if (compareInt(selfParam.width, outParam.width) == false)
                return false;
            if (compareInt(selfParam.height, outParam.height) == false)
                return false;
            if (compareInt(selfParam.framesPerSecond, outParam.framesPerSecond) == false)
                return false;
            if (compareVIDEO_FRAME_TYPE_NATIVE(selfParam.frameType, outParam.frameType) == false)
                return false;
            if (compareVIDEO_ORIENTATION(selfParam.rotation, outParam.rotation) == false)
                return false;
            if (compareInt(selfParam.trackId, outParam.trackId) == false)
                return false;
            if (compareInt64_t(selfParam.captureTimeMs, outParam.captureTimeMs) == false)
                return false;
            if (compareInt64_t(selfParam.decodeTimeMs, outParam.decodeTimeMs) == false)
                return false;
            if (compareUid_t(selfParam.uid, outParam.uid) == false)
                return false;
            if (compareVIDEO_STREAM_TYPE(selfParam.streamType, outParam.streamType) == false)
                return false;
            return true;
        }

        public static bool compareUid_t(uint selfParam, uint outParam)
        {
            return selfParam == 10;
        }

        public static bool compareCOMPRESSION_PREFERENCE(COMPRESSION_PREFERENCE selfParam, COMPRESSION_PREFERENCE outParam)
        {
            return selfParam == COMPRESSION_PREFERENCE.PREFER_LOW_LATENCY;
        }

        public static bool compareENCODING_PREFERENCE(ENCODING_PREFERENCE selfParam, ENCODING_PREFERENCE outParam)
        {
            return selfParam == ENCODING_PREFERENCE.PREFER_AUTO;
        }

        public static bool compareAdvanceOptions(AdvanceOptions selfParam, AdvanceOptions outParam)
        {
            if (compareENCODING_PREFERENCE(selfParam.encodingPreference, outParam.encodingPreference) == false)
                return false;
            if (compareCOMPRESSION_PREFERENCE(selfParam.compressionPreference, outParam.compressionPreference) == false)
                return false;
            return true;
        }

        public static bool compareVIDEO_MIRROR_MODE_TYPE(VIDEO_MIRROR_MODE_TYPE selfParam, VIDEO_MIRROR_MODE_TYPE outParam)
        {
            return selfParam == VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO;
        }

        public static bool compareVideoEncoderConfiguration(VideoEncoderConfiguration selfParam, VideoEncoderConfiguration outParam)
        {
            if (compareVIDEO_CODEC_TYPE(selfParam.codecType, outParam.codecType) == false)
                return false;
            if (compareVideoDimensions(selfParam.dimensions, outParam.dimensions) == false)
                return false;
            if (compareInt(selfParam.frameRate, outParam.frameRate) == false)
                return false;
            if (compareInt(selfParam.bitrate, outParam.bitrate) == false)
                return false;
            if (compareInt(selfParam.minBitrate, outParam.minBitrate) == false)
                return false;
            if (compareORIENTATION_MODE(selfParam.orientationMode, outParam.orientationMode) == false)
                return false;
            if (compareDEGRADATION_PREFERENCE(selfParam.degradationPreference, outParam.degradationPreference) == false)
                return false;
            if (compareVIDEO_MIRROR_MODE_TYPE(selfParam.mirrorMode, outParam.mirrorMode) == false)
                return false;
            if (compareAdvanceOptions(selfParam.advanceOptions, outParam.advanceOptions) == false)
                return false;
            return true;
        }

        public static bool compareDataStreamConfig(DataStreamConfig selfParam, DataStreamConfig outParam)
        {
            if (compareBool(selfParam.syncWithAudio, outParam.syncWithAudio) == false)
                return false;
            if (compareBool(selfParam.ordered, outParam.ordered) == false)
                return false;
            return true;
        }

        public static bool compareSIMULCAST_STREAM_MODE(SIMULCAST_STREAM_MODE selfParam, SIMULCAST_STREAM_MODE outParam)
        {
            return selfParam == SIMULCAST_STREAM_MODE.AUTO_SIMULCAST_STREAM;
        }

        public static bool compareSimulcastStreamConfig(SimulcastStreamConfig selfParam, SimulcastStreamConfig outParam)
        {
            if (compareVideoDimensions(selfParam.dimensions, outParam.dimensions) == false)
                return false;
            if (compareInt(selfParam.kBitrate, outParam.kBitrate) == false)
                return false;
            if (compareInt(selfParam.framerate, outParam.framerate) == false)
                return false;
            return true;
        }

        public static bool compareRectangle(Rectangle selfParam, Rectangle outParam)
        {
            if (compareInt(selfParam.x, outParam.x) == false)
                return false;
            if (compareInt(selfParam.y, outParam.y) == false)
                return false;
            if (compareInt(selfParam.width, outParam.width) == false)
                return false;
            if (compareInt(selfParam.height, outParam.height) == false)
                return false;
            return true;
        }

        public static bool compareFloat(float selfParam, float outParam)
        {
            return selfParam == 10;
        }

        public static bool compareWatermarkRatio(WatermarkRatio selfParam, WatermarkRatio outParam)
        {
            if (compareFloat(selfParam.xRatio, outParam.xRatio) == false)
                return false;
            if (compareFloat(selfParam.yRatio, outParam.yRatio) == false)
                return false;
            if (compareFloat(selfParam.widthRatio, outParam.widthRatio) == false)
                return false;
            return true;
        }

        public static bool compareWatermarkOptions(WatermarkOptions selfParam, WatermarkOptions outParam)
        {
            if (compareBool(selfParam.visibleInPreview, outParam.visibleInPreview) == false)
                return false;
            if (compareRectangle(selfParam.positionInLandscapeMode, outParam.positionInLandscapeMode) == false)
                return false;
            if (compareRectangle(selfParam.positionInPortraitMode, outParam.positionInPortraitMode) == false)
                return false;
            if (compareWatermarkRatio(selfParam.watermarkRatio, outParam.watermarkRatio) == false)
                return false;
            if (compareWATERMARK_FIT_MODE(selfParam.mode, outParam.mode) == false)
                return false;
            return true;
        }

        public static bool compareUnsignedInt(uint selfParam, uint outParam)
        {
            return selfParam == 10;
        }

        public static bool compareUnsignedShort(ushort selfParam, ushort outParam)
        {
            return selfParam == 10;
        }

        public static bool compareDouble(double selfParam, double outParam)
        {
            return selfParam == 10;
        }

        public static bool compareRtcStats(RtcStats selfParam, RtcStats outParam)
        {
            if (compareUnsignedInt(selfParam.duration, outParam.duration) == false)
                return false;
            if (compareUnsignedInt(selfParam.txBytes, outParam.txBytes) == false)
                return false;
            if (compareUnsignedInt(selfParam.rxBytes, outParam.rxBytes) == false)
                return false;
            if (compareUnsignedInt(selfParam.txAudioBytes, outParam.txAudioBytes) == false)
                return false;
            if (compareUnsignedInt(selfParam.txVideoBytes, outParam.txVideoBytes) == false)
                return false;
            if (compareUnsignedInt(selfParam.rxAudioBytes, outParam.rxAudioBytes) == false)
                return false;
            if (compareUnsignedInt(selfParam.rxVideoBytes, outParam.rxVideoBytes) == false)
                return false;
            if (compareUnsignedShort(selfParam.txKBitRate, outParam.txKBitRate) == false)
                return false;
            if (compareUnsignedShort(selfParam.rxKBitRate, outParam.rxKBitRate) == false)
                return false;
            if (compareUnsignedShort(selfParam.rxAudioKBitRate, outParam.rxAudioKBitRate) == false)
                return false;
            if (compareUnsignedShort(selfParam.txAudioKBitRate, outParam.txAudioKBitRate) == false)
                return false;
            if (compareUnsignedShort(selfParam.rxVideoKBitRate, outParam.rxVideoKBitRate) == false)
                return false;
            if (compareUnsignedShort(selfParam.txVideoKBitRate, outParam.txVideoKBitRate) == false)
                return false;
            if (compareUnsignedShort(selfParam.lastmileDelay, outParam.lastmileDelay) == false)
                return false;
            if (compareUnsignedInt(selfParam.userCount, outParam.userCount) == false)
                return false;
            if (compareDouble(selfParam.cpuAppUsage, outParam.cpuAppUsage) == false)
                return false;
            if (compareDouble(selfParam.cpuTotalUsage, outParam.cpuTotalUsage) == false)
                return false;
            if (compareInt(selfParam.gatewayRtt, outParam.gatewayRtt) == false)
                return false;
            if (compareDouble(selfParam.memoryAppUsageRatio, outParam.memoryAppUsageRatio) == false)
                return false;
            if (compareDouble(selfParam.memoryTotalUsageRatio, outParam.memoryTotalUsageRatio) == false)
                return false;
            if (compareInt(selfParam.memoryAppUsageInKbytes, outParam.memoryAppUsageInKbytes) == false)
                return false;
            if (compareInt(selfParam.connectTimeMs, outParam.connectTimeMs) == false)
                return false;
            if (compareInt(selfParam.firstAudioPacketDuration, outParam.firstAudioPacketDuration) == false)
                return false;
            if (compareInt(selfParam.firstVideoPacketDuration, outParam.firstVideoPacketDuration) == false)
                return false;
            if (compareInt(selfParam.firstVideoKeyFramePacketDuration, outParam.firstVideoKeyFramePacketDuration) == false)
                return false;
            if (compareInt(selfParam.packetsBeforeFirstKeyFramePacket, outParam.packetsBeforeFirstKeyFramePacket) == false)
                return false;
            if (compareInt(selfParam.firstAudioPacketDurationAfterUnmute, outParam.firstAudioPacketDurationAfterUnmute) == false)
                return false;
            if (compareInt(selfParam.firstVideoPacketDurationAfterUnmute, outParam.firstVideoPacketDurationAfterUnmute) == false)
                return false;
            if (compareInt(selfParam.firstVideoKeyFramePacketDurationAfterUnmute, outParam.firstVideoKeyFramePacketDurationAfterUnmute) == false)
                return false;
            if (compareInt(selfParam.firstVideoKeyFrameDecodedDurationAfterUnmute, outParam.firstVideoKeyFrameDecodedDurationAfterUnmute) == false)
                return false;
            if (compareInt(selfParam.firstVideoKeyFrameRenderedDurationAfterUnmute, outParam.firstVideoKeyFrameRenderedDurationAfterUnmute) == false)
                return false;
            if (compareInt(selfParam.txPacketLossRate, outParam.txPacketLossRate) == false)
                return false;
            if (compareInt(selfParam.rxPacketLossRate, outParam.rxPacketLossRate) == false)
                return false;
            return true;
        }

        //public static bool compareVIDEO_SOURCE_TYPE(VIDEO_SOURCE_TYPE selfParam, VIDEO_SOURCE_TYPE outParam)
        //{
        //    return selfParam == VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
        //}

        public static bool compareCLIENT_ROLE_TYPE(CLIENT_ROLE_TYPE selfParam, CLIENT_ROLE_TYPE outParam)
        {
            return selfParam == CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER;
        }

        public static bool compareQUALITY_ADAPT_INDICATION(QUALITY_ADAPT_INDICATION selfParam, QUALITY_ADAPT_INDICATION outParam)
        {
            return selfParam == QUALITY_ADAPT_INDICATION.ADAPT_NONE;
        }

        public static bool compareAUDIENCE_LATENCY_LEVEL_TYPE(AUDIENCE_LATENCY_LEVEL_TYPE selfParam, AUDIENCE_LATENCY_LEVEL_TYPE outParam)
        {
            return selfParam == AUDIENCE_LATENCY_LEVEL_TYPE.AUDIENCE_LATENCY_LEVEL_LOW_LATENCY;
        }

        public static bool compareClientRoleOptions(ClientRoleOptions selfParam, ClientRoleOptions outParam)
        {
            if (compareAUDIENCE_LATENCY_LEVEL_TYPE(selfParam.audienceLatencyLevel, outParam.audienceLatencyLevel) == false)
                return false;
            return true;
        }

        public static bool compareEXPERIENCE_QUALITY_TYPE(EXPERIENCE_QUALITY_TYPE selfParam, EXPERIENCE_QUALITY_TYPE outParam)
        {
            return selfParam == EXPERIENCE_QUALITY_TYPE.EXPERIENCE_QUALITY_GOOD;
        }

        public static bool compareEXPERIENCE_POOR_REASON(EXPERIENCE_POOR_REASON selfParam, EXPERIENCE_POOR_REASON outParam)
        {
            return selfParam == EXPERIENCE_POOR_REASON.EXPERIENCE_REASON_NONE;
        }

        public static bool compareRemoteAudioStats(RemoteAudioStats selfParam, RemoteAudioStats outParam)
        {
            if (compareUid_t(selfParam.uid, outParam.uid) == false)
                return false;
            if (compareInt(selfParam.quality, outParam.quality) == false)
                return false;
            if (compareInt(selfParam.networkTransportDelay, outParam.networkTransportDelay) == false)
                return false;
            if (compareInt(selfParam.jitterBufferDelay, outParam.jitterBufferDelay) == false)
                return false;
            if (compareInt(selfParam.audioLossRate, outParam.audioLossRate) == false)
                return false;
            if (compareInt(selfParam.numChannels, outParam.numChannels) == false)
                return false;
            if (compareInt(selfParam.receivedSampleRate, outParam.receivedSampleRate) == false)
                return false;
            if (compareInt(selfParam.receivedBitrate, outParam.receivedBitrate) == false)
                return false;
            if (compareInt(selfParam.totalFrozenTime, outParam.totalFrozenTime) == false)
                return false;
            if (compareInt(selfParam.frozenRate, outParam.frozenRate) == false)
                return false;
            if (compareInt(selfParam.mosValue, outParam.mosValue) == false)
                return false;
            if (compareInt(selfParam.totalActiveTime, outParam.totalActiveTime) == false)
                return false;
            if (compareInt(selfParam.publishDuration, outParam.publishDuration) == false)
                return false;
            if (compareInt(selfParam.qoeQuality, outParam.qoeQuality) == false)
                return false;
            if (compareInt(selfParam.qualityChangedReason, outParam.qualityChangedReason) == false)
                return false;
            return true;
        }

        public static bool compareAUDIO_PROFILE_TYPE(AUDIO_PROFILE_TYPE selfParam, AUDIO_PROFILE_TYPE outParam)
        {
            return selfParam == AUDIO_PROFILE_TYPE.AUDIO_PROFILE_DEFAULT;
        }

        public static bool compareAUDIO_SCENARIO_TYPE(AUDIO_SCENARIO_TYPE selfParam, AUDIO_SCENARIO_TYPE outParam)
        {
            return selfParam == AUDIO_SCENARIO_TYPE.AUDIO_SCENARIO_DEFAULT;
        }

        public static bool compareVideoFormat(VideoFormat selfParam, VideoFormat outParam)
        {
            if (compareInt(selfParam.width, outParam.width) == false)
                return false;
            if (compareInt(selfParam.height, outParam.height) == false)
                return false;
            if (compareInt(selfParam.fps, outParam.fps) == false)
                return false;
            return true;
        }


        public static bool compareVIDEO_CONTENT_HINT(VIDEO_CONTENT_HINT selfParam, VIDEO_CONTENT_HINT outParam)
        {
            return selfParam == VIDEO_CONTENT_HINT.CONTENT_HINT_NONE;
        }

        public static bool compareSCREEN_SCENARIO_TYPE(SCREEN_SCENARIO_TYPE selfParam, SCREEN_SCENARIO_TYPE outParam)
        {
            return selfParam == SCREEN_SCENARIO_TYPE.SCREEN_SCENARIO_DOCUMENT;
        }

        public static bool compareCAPTURE_BRIGHTNESS_LEVEL_TYPE(CAPTURE_BRIGHTNESS_LEVEL_TYPE selfParam, CAPTURE_BRIGHTNESS_LEVEL_TYPE outParam)
        {
            return selfParam == CAPTURE_BRIGHTNESS_LEVEL_TYPE.CAPTURE_BRIGHTNESS_LEVEL_INVALID;
        }

        public static bool compareLOCAL_AUDIO_STREAM_STATE(LOCAL_AUDIO_STREAM_STATE selfParam, LOCAL_AUDIO_STREAM_STATE outParam)
        {
            return selfParam == LOCAL_AUDIO_STREAM_STATE.LOCAL_AUDIO_STREAM_STATE_STOPPED;
        }

        public static bool compareLOCAL_AUDIO_STREAM_ERROR(LOCAL_AUDIO_STREAM_ERROR selfParam, LOCAL_AUDIO_STREAM_ERROR outParam)
        {
            return selfParam == LOCAL_AUDIO_STREAM_ERROR.LOCAL_AUDIO_STREAM_ERROR_OK;
        }

        public static bool compareLOCAL_VIDEO_STREAM_STATE(LOCAL_VIDEO_STREAM_STATE selfParam, LOCAL_VIDEO_STREAM_STATE outParam)
        {
            return selfParam == LOCAL_VIDEO_STREAM_STATE.LOCAL_VIDEO_STREAM_STATE_STOPPED;
        }

        public static bool compareLOCAL_VIDEO_STREAM_ERROR(LOCAL_VIDEO_STREAM_ERROR selfParam, LOCAL_VIDEO_STREAM_ERROR outParam)
        {
            return selfParam == LOCAL_VIDEO_STREAM_ERROR.LOCAL_VIDEO_STREAM_ERROR_OK;
        }

        public static bool compareREMOTE_AUDIO_STATE(REMOTE_AUDIO_STATE selfParam, REMOTE_AUDIO_STATE outParam)
        {
            return selfParam == REMOTE_AUDIO_STATE.REMOTE_AUDIO_STATE_STOPPED;
        }

        public static bool compareREMOTE_AUDIO_STATE_REASON(REMOTE_AUDIO_STATE_REASON selfParam, REMOTE_AUDIO_STATE_REASON outParam)
        {
            return selfParam == REMOTE_AUDIO_STATE_REASON.REMOTE_AUDIO_REASON_INTERNAL;
        }

        public static bool compareREMOTE_VIDEO_STATE(REMOTE_VIDEO_STATE selfParam, REMOTE_VIDEO_STATE outParam)
        {
            return selfParam == REMOTE_VIDEO_STATE.REMOTE_VIDEO_STATE_STOPPED;
        }

        public static bool compareREMOTE_VIDEO_STATE_REASON(REMOTE_VIDEO_STATE_REASON selfParam, REMOTE_VIDEO_STATE_REASON outParam)
        {
            return selfParam == REMOTE_VIDEO_STATE_REASON.REMOTE_VIDEO_STATE_REASON_INTERNAL;
        }

        public static bool compareREMOTE_USER_STATE(REMOTE_USER_STATE selfParam, REMOTE_USER_STATE outParam)
        {
            return selfParam == REMOTE_USER_STATE.USER_STATE_MUTE_AUDIO;
        }

        public static bool compareTrack_id_t(uint selfParam, uint outParam)
        {
            return selfParam == 10;
        }

        public static bool compareVideoTrackInfo(VideoTrackInfo selfParam, VideoTrackInfo outParam)
        {
            if (compareBool(selfParam.isLocal, outParam.isLocal) == false)
                return false;
            if (compareUid_t(selfParam.ownerUid, outParam.ownerUid) == false)
                return false;
            if (compareTrack_id_t(selfParam.trackId, outParam.trackId) == false)
                return false;
            if (compareString(selfParam.channelId, outParam.channelId) == false)
                return false;
            if (compareVIDEO_STREAM_TYPE(selfParam.streamType, outParam.streamType) == false)
                return false;
            if (compareVIDEO_CODEC_TYPE(selfParam.codecType, outParam.codecType) == false)
                return false;
            if (compareBool(selfParam.encodedFrameOnly, outParam.encodedFrameOnly) == false)
                return false;
            if (compareVIDEO_SOURCE_TYPE(selfParam.sourceType, outParam.sourceType) == false)
                return false;
            if (compareUint(selfParam.observationPosition, outParam.observationPosition) == false)
                return false;
            return true;
        }

        public static bool compareREMOTE_VIDEO_DOWNSCALE_LEVEL(REMOTE_VIDEO_DOWNSCALE_LEVEL selfParam, REMOTE_VIDEO_DOWNSCALE_LEVEL outParam)
        {
            return selfParam == REMOTE_VIDEO_DOWNSCALE_LEVEL.REMOTE_VIDEO_DOWNSCALE_LEVEL_NONE;
        }

        public static bool compareAudioVolumeInfoArray(AudioVolumeInfo[] selfParam, AudioVolumeInfo[] outParam)
        {
            if (selfParam.Length != 10)
                return false;

            for (int i = 0; i < selfParam.Length; i++)
            {
                if (compareAudioVolumeInfo(selfParam[i], outParam[i]) == false)
                    return false;
            }

            return true;
        }

        public static bool compareAudioVolumeInfo(AudioVolumeInfo selfParam, AudioVolumeInfo outParam)
        {
            if (compareUid_t(selfParam.uid, outParam.uid) == false)
                return false;
            if (compareUnsignedInt(selfParam.volume, outParam.volume) == false)
                return false;
            if (compareUnsignedInt(selfParam.vad, outParam.vad) == false)
                return false;
            if (compareDouble(selfParam.voicePitch, outParam.voicePitch) == false)
                return false;
            return true;
        }


        public static bool compareDeviceInfo(DeviceInfo selfParam, DeviceInfo outParam)
        {
            if (compareString(selfParam.deviceId, outParam.deviceId) == false)
                return false;

            if (compareString(selfParam.deviceName, outParam.deviceName) == false)
                return false;
            return true;
        }

        public static bool compareAUDIO_SAMPLE_RATE_TYPE(AUDIO_SAMPLE_RATE_TYPE selfParam, AUDIO_SAMPLE_RATE_TYPE outParam)
        {
            return selfParam == AUDIO_SAMPLE_RATE_TYPE.AUDIO_SAMPLE_RATE_32000;
        }

        public static bool compareVIDEO_CODEC_TYPE_FOR_STREAM(VIDEO_CODEC_TYPE_FOR_STREAM selfParam, VIDEO_CODEC_TYPE_FOR_STREAM outParam)
        {
            return selfParam == VIDEO_CODEC_TYPE_FOR_STREAM.VIDEO_CODEC_H264_FOR_STREAM;
        }

        public static bool compareVIDEO_CODEC_PROFILE_TYPE(VIDEO_CODEC_PROFILE_TYPE selfParam, VIDEO_CODEC_PROFILE_TYPE outParam)
        {
            return selfParam == VIDEO_CODEC_PROFILE_TYPE.VIDEO_CODEC_PROFILE_BASELINE;
        }

        public static bool compareAUDIO_CODEC_PROFILE_TYPE(AUDIO_CODEC_PROFILE_TYPE selfParam, AUDIO_CODEC_PROFILE_TYPE outParam)
        {
            return selfParam == AUDIO_CODEC_PROFILE_TYPE.AUDIO_CODEC_PROFILE_LC_AAC;
        }

        public static bool compareLocalAudioStats(LocalAudioStats selfParam, LocalAudioStats outParam)
        {
            if (compareInt(selfParam.numChannels, outParam.numChannels) == false)
                return false;
            if (compareInt(selfParam.sentSampleRate, outParam.sentSampleRate) == false)
                return false;
            if (compareInt(selfParam.sentBitrate, outParam.sentBitrate) == false)
                return false;
            if (compareInt(selfParam.internalCodec, outParam.internalCodec) == false)
                return false;
            if (compareUnsignedShort(selfParam.txPacketLossRate, outParam.txPacketLossRate) == false)
                return false;
            if (compareInt(selfParam.audioDeviceDelay, outParam.audioDeviceDelay) == false)
                return false;
            return true;
        }

        public static bool compareRTMP_STREAM_PUBLISH_STATE(RTMP_STREAM_PUBLISH_STATE selfParam, RTMP_STREAM_PUBLISH_STATE outParam)
        {
            return selfParam == RTMP_STREAM_PUBLISH_STATE.RTMP_STREAM_PUBLISH_STATE_IDLE;
        }

        public static bool compareRTMP_STREAM_PUBLISH_ERROR_TYPE(RTMP_STREAM_PUBLISH_ERROR_TYPE selfParam, RTMP_STREAM_PUBLISH_ERROR_TYPE outParam)
        {
            return selfParam == RTMP_STREAM_PUBLISH_ERROR_TYPE.RTMP_STREAM_PUBLISH_ERROR_OK;
        }

        public static bool compareRTMP_STREAMING_EVENT(RTMP_STREAMING_EVENT selfParam, RTMP_STREAMING_EVENT outParam)
        {
            return selfParam == RTMP_STREAMING_EVENT.RTMP_STREAMING_EVENT_FAILED_LOAD_IMAGE;
        }

        public static bool compareRtcImage(RtcImage selfParam, RtcImage outParam)
        {
            if (compareString(selfParam.url, outParam.url) == false)
                return false;
            if (compareInt(selfParam.x, outParam.x) == false)
                return false;
            if (compareInt(selfParam.y, outParam.y) == false)
                return false;
            if (compareInt(selfParam.width, outParam.width) == false)
                return false;
            if (compareInt(selfParam.height, outParam.height) == false)
                return false;
            if (compareInt(selfParam.zOrder, outParam.zOrder) == false)
                return false;
            if (compareDouble(selfParam.alpha, outParam.alpha) == false)
                return false;
            return true;
        }

        public static bool compareLiveStreamAdvancedFeature(LiveStreamAdvancedFeature selfParam, LiveStreamAdvancedFeature outParam)
        {
            if (compareString(selfParam.featureName, outParam.featureName) == false)
                return false;
            if (compareBool(selfParam.opened, outParam.opened) == false)
                return false;
            return true;
        }

        public static bool compareCONNECTION_STATE_TYPE(CONNECTION_STATE_TYPE selfParam, CONNECTION_STATE_TYPE outParam)
        {
            return selfParam == CONNECTION_STATE_TYPE.CONNECTION_STATE_DISCONNECTED;
        }

        public static bool compareTranscodingUser(TranscodingUser selfParam, TranscodingUser outParam)
        {
            if (compareUid_t(selfParam.uid, outParam.uid) == false)
                return false;
            if (compareInt(selfParam.x, outParam.x) == false)
                return false;
            if (compareInt(selfParam.y, outParam.y) == false)
                return false;
            if (compareInt(selfParam.width, outParam.width) == false)
                return false;
            if (compareInt(selfParam.height, outParam.height) == false)
                return false;
            if (compareInt(selfParam.zOrder, outParam.zOrder) == false)
                return false;
            if (compareDouble(selfParam.alpha, outParam.alpha) == false)
                return false;
            if (compareInt(selfParam.audioChannel, outParam.audioChannel) == false)
                return false;
            return true;
        }


        public static bool compareTranscodingVideoStream(TranscodingVideoStream selfParam, TranscodingVideoStream outParam)
        {
            if (compareMEDIA_SOURCE_TYPE(selfParam.sourceType, outParam.sourceType) == false)
                return false;
            if (compareUid_t(selfParam.remoteUserUid, outParam.remoteUserUid) == false)
                return false;
            if (compareString(selfParam.imageUrl, outParam.imageUrl) == false)
                return false;
            if (compareInt(selfParam.x, outParam.x) == false)
                return false;
            if (compareInt(selfParam.y, outParam.y) == false)
                return false;
            if (compareInt(selfParam.width, outParam.width) == false)
                return false;
            if (compareInt(selfParam.height, outParam.height) == false)
                return false;
            if (compareInt(selfParam.zOrder, outParam.zOrder) == false)
                return false;
            if (compareDouble(selfParam.alpha, outParam.alpha) == false)
                return false;
            if (compareBool(selfParam.mirror, outParam.mirror) == false)
                return false;
            return true;
        }


        public static bool compareLastmileProbeConfig(LastmileProbeConfig selfParam, LastmileProbeConfig outParam)
        {
            if (compareBool(selfParam.probeUplink, outParam.probeUplink) == false)
                return false;
            if (compareBool(selfParam.probeDownlink, outParam.probeDownlink) == false)
                return false;
            if (compareUnsignedInt(selfParam.expectedUplinkBitrate, outParam.expectedUplinkBitrate) == false)
                return false;
            if (compareUnsignedInt(selfParam.expectedDownlinkBitrate, outParam.expectedDownlinkBitrate) == false)
                return false;
            return true;
        }

        public static bool compareLASTMILE_PROBE_RESULT_STATE(LASTMILE_PROBE_RESULT_STATE selfParam, LASTMILE_PROBE_RESULT_STATE outParam)
        {
            return selfParam == LASTMILE_PROBE_RESULT_STATE.LASTMILE_PROBE_RESULT_COMPLETE;
        }

        public static bool compareLastmileProbeOneWayResult(LastmileProbeOneWayResult selfParam, LastmileProbeOneWayResult outParam)
        {
            if (compareUnsignedInt(selfParam.packetLossRate, outParam.packetLossRate) == false)
                return false;
            if (compareUnsignedInt(selfParam.jitter, outParam.jitter) == false)
                return false;
            if (compareUnsignedInt(selfParam.availableBandwidth, outParam.availableBandwidth) == false)
                return false;
            return true;
        }

        public static bool compareLastmileProbeResult(LastmileProbeResult selfParam, LastmileProbeResult outParam)
        {
            if (compareLASTMILE_PROBE_RESULT_STATE(selfParam.state, outParam.state) == false)
                return false;
            if (compareLastmileProbeOneWayResult(selfParam.uplinkReport, outParam.uplinkReport) == false)
                return false;
            if (compareLastmileProbeOneWayResult(selfParam.downlinkReport, outParam.downlinkReport) == false)
                return false;
            if (compareUnsignedInt(selfParam.rtt, outParam.rtt) == false)
                return false;
            return true;
        }

        public static bool compareCONNECTION_CHANGED_REASON_TYPE(CONNECTION_CHANGED_REASON_TYPE selfParam, CONNECTION_CHANGED_REASON_TYPE outParam)
        {
            return selfParam == CONNECTION_CHANGED_REASON_TYPE.CONNECTION_CHANGED_CONNECTING;
        }

        public static bool compareCLIENT_ROLE_CHANGE_FAILED_REASON(CLIENT_ROLE_CHANGE_FAILED_REASON selfParam, CLIENT_ROLE_CHANGE_FAILED_REASON outParam)
        {
            return selfParam == CLIENT_ROLE_CHANGE_FAILED_REASON.CLIENT_ROLE_CHANGE_FAILED_TOO_MANY_BROADCASTERS;
        }

        public static bool compareWLACC_MESSAGE_REASON(WLACC_MESSAGE_REASON selfParam, WLACC_MESSAGE_REASON outParam)
        {
            return selfParam == WLACC_MESSAGE_REASON.WLACC_MESSAGE_REASON_WEAK_SIGNAL;
        }

        public static bool compareWLACC_SUGGEST_ACTION(WLACC_SUGGEST_ACTION selfParam, WLACC_SUGGEST_ACTION outParam)
        {
            return selfParam == WLACC_SUGGEST_ACTION.WLACC_SUGGEST_ACTION_CLOSE_TO_WIFI;
        }

        public static bool compareWlAccStats(WlAccStats selfParam, WlAccStats outParam)
        {
            if (compareUnsignedShort(selfParam.e2eDelayPercent, outParam.e2eDelayPercent) == false)
                return false;
            if (compareUnsignedShort(selfParam.frozenRatioPercent, outParam.frozenRatioPercent) == false)
                return false;
            if (compareUnsignedShort(selfParam.lossRatePercent, outParam.lossRatePercent) == false)
                return false;
            return true;
        }

        public static bool compareNETWORK_TYPE(NETWORK_TYPE selfParam, NETWORK_TYPE outParam)
        {
            return selfParam == NETWORK_TYPE.NETWORK_TYPE_UNKNOWN;
        }

        public static bool compareVIDEO_VIEW_SETUP_MODE(VIDEO_VIEW_SETUP_MODE selfParam, VIDEO_VIEW_SETUP_MODE outParam)
        {
            return selfParam == VIDEO_VIEW_SETUP_MODE.VIDEO_VIEW_SETUP_REPLACE;
        }

        public static bool compareView_t(ulong selfParam, ulong outParam)
        {
            return selfParam == 10;
        }

        public static bool compareVideoCanvas(VideoCanvas selfParam, VideoCanvas outParam)
        {
            if (compareView_t(selfParam.view, outParam.view) == false)
                return false;
            if (compareUid_t(selfParam.uid, outParam.uid) == false)
                return false;
            if (compareRENDER_MODE_TYPE(selfParam.renderMode, outParam.renderMode) == false)
                return false;
            if (compareVIDEO_MIRROR_MODE_TYPE(selfParam.mirrorMode, outParam.mirrorMode) == false)
                return false;
            if (compareVIDEO_VIEW_SETUP_MODE(selfParam.setupMode, outParam.setupMode) == false)
                return false;
            if (compareVIDEO_SOURCE_TYPE(selfParam.sourceType, outParam.sourceType) == false)
                return false;
            if (compareInt(selfParam.mediaPlayerId, outParam.mediaPlayerId) == false)
                return false;
            if (compareRectangle(selfParam.cropArea, outParam.cropArea) == false)
                return false;
            return true;
        }

        public static bool compareBeautyOptions(BeautyOptions selfParam, BeautyOptions outParam)
        {
            if (compareLIGHTENING_CONTRAST_LEVEL(selfParam.lighteningContrastLevel, outParam.lighteningContrastLevel) == false)
                return false;
            if (compareFloat(selfParam.lighteningLevel, outParam.lighteningLevel) == false)
                return false;
            if (compareFloat(selfParam.smoothnessLevel, outParam.smoothnessLevel) == false)
                return false;
            if (compareFloat(selfParam.rednessLevel, outParam.rednessLevel) == false)
                return false;
            if (compareFloat(selfParam.sharpnessLevel, outParam.sharpnessLevel) == false)
                return false;
            return true;
        }

        public static bool compareLIGHTENING_CONTRAST_LEVEL(LIGHTENING_CONTRAST_LEVEL selfParam, LIGHTENING_CONTRAST_LEVEL outParam)
        {
            return selfParam == LIGHTENING_CONTRAST_LEVEL.LIGHTENING_CONTRAST_LOW;
        }

        public static bool compareLowlightEnhanceOptions(LowlightEnhanceOptions selfParam, LowlightEnhanceOptions outParam)
        {
            if (compareLOW_LIGHT_ENHANCE_MODE(selfParam.mode, outParam.mode) == false)
                return false;
            if (compareLOW_LIGHT_ENHANCE_LEVEL(selfParam.level, outParam.level) == false)
                return false;
            return true;
        }

        public static bool compareLOW_LIGHT_ENHANCE_MODE(LOW_LIGHT_ENHANCE_MODE selfParam, LOW_LIGHT_ENHANCE_MODE outParam)
        {
            return selfParam == LOW_LIGHT_ENHANCE_MODE.LOW_LIGHT_ENHANCE_AUTO;
        }

        public static bool compareLOW_LIGHT_ENHANCE_LEVEL(LOW_LIGHT_ENHANCE_LEVEL selfParam, LOW_LIGHT_ENHANCE_LEVEL outParam)
        {
            return selfParam == LOW_LIGHT_ENHANCE_LEVEL.LOW_LIGHT_ENHANCE_LEVEL_HIGH_QUALITY;
        }

        public static bool compareVideoDenoiserOptions(VideoDenoiserOptions selfParam, VideoDenoiserOptions outParam)
        {
            if (compareVIDEO_DENOISER_MODE(selfParam.mode, outParam.mode) == false)
                return false;
            if (compareVIDEO_DENOISER_LEVEL(selfParam.level, outParam.level) == false)
                return false;
            return true;
        }

        public static bool compareVIDEO_DENOISER_MODE(VIDEO_DENOISER_MODE selfParam, VIDEO_DENOISER_MODE outParam)
        {
            return selfParam == VIDEO_DENOISER_MODE.VIDEO_DENOISER_AUTO;
        }

        public static bool compareVIDEO_DENOISER_LEVEL(VIDEO_DENOISER_LEVEL selfParam, VIDEO_DENOISER_LEVEL outParam)
        {
            return selfParam == VIDEO_DENOISER_LEVEL.VIDEO_DENOISER_LEVEL_HIGH_QUALITY;
        }

        public static bool compareColorEnhanceOptions(ColorEnhanceOptions selfParam, ColorEnhanceOptions outParam)
        {
            if (compareFloat(selfParam.strengthLevel, outParam.strengthLevel) == false)
                return false;
            if (compareFloat(selfParam.skinProtectLevel, outParam.skinProtectLevel) == false)
                return false;
            return true;
        }

        public static bool compareVirtualBackgroundSource(VirtualBackgroundSource selfParam, VirtualBackgroundSource outParam)
        {
            if (compareBACKGROUND_SOURCE_TYPE(selfParam.background_source_type, outParam.background_source_type) == false)
                return false;
            if (compareUnsignedInt(selfParam.color, outParam.color) == false)
                return false;
            if (compareString(selfParam.source, outParam.source) == false)
                return false;
            if (compareBACKGROUND_BLUR_DEGREE(selfParam.blur_degree, outParam.blur_degree) == false)
                return false;
            return true;
        }

        public static bool compareBACKGROUND_SOURCE_TYPE(BACKGROUND_SOURCE_TYPE selfParam, BACKGROUND_SOURCE_TYPE outParam)
        {
            return selfParam == BACKGROUND_SOURCE_TYPE.BACKGROUND_COLOR;
        }

        public static bool compareBACKGROUND_BLUR_DEGREE(BACKGROUND_BLUR_DEGREE selfParam, BACKGROUND_BLUR_DEGREE outParam)
        {
            return selfParam == BACKGROUND_BLUR_DEGREE.BLUR_DEGREE_LOW;
        }

        public static bool compareSegmentationProperty(SegmentationProperty selfParam, SegmentationProperty outParam)
        {
            if (compareSEG_MODEL_TYPE(selfParam.modelType, outParam.modelType) == false)
                return false;
            if (compareFloat(selfParam.greenCapacity, outParam.greenCapacity) == false)
                return false;
            return true;
        }

        public static bool compareSEG_MODEL_TYPE(SEG_MODEL_TYPE selfParam, SEG_MODEL_TYPE outParam)
        {
            return selfParam == SEG_MODEL_TYPE.SEG_MODEL_AI;
        }

        public static bool compareVOICE_BEAUTIFIER_PRESET(VOICE_BEAUTIFIER_PRESET selfParam, VOICE_BEAUTIFIER_PRESET outParam)
        {
            return selfParam == VOICE_BEAUTIFIER_PRESET.VOICE_BEAUTIFIER_OFF;
        }

        public static bool compareAUDIO_EFFECT_PRESET(AUDIO_EFFECT_PRESET selfParam, AUDIO_EFFECT_PRESET outParam)
        {
            return selfParam == AUDIO_EFFECT_PRESET.AUDIO_EFFECT_OFF;
        }

        public static bool compareVOICE_CONVERSION_PRESET(VOICE_CONVERSION_PRESET selfParam, VOICE_CONVERSION_PRESET outParam)
        {
            return selfParam == VOICE_CONVERSION_PRESET.VOICE_CONVERSION_OFF;
        }

        public static bool compareHEADPHONE_EQUALIZER_PRESET(HEADPHONE_EQUALIZER_PRESET selfParam, HEADPHONE_EQUALIZER_PRESET outParam)
        {
            return selfParam == HEADPHONE_EQUALIZER_PRESET.HEADPHONE_EQUALIZER_OFF;
        }

        public static bool compareView_tArray(ulong[] selfParam, ulong[] outParam)
        {
            if (selfParam.Length != 10)
                return false;

            for (int i = 0; i < selfParam.Length; i++)
            {
                if (selfParam[i] != 10)
                    return false;
            }

            return true;
        }

        public static bool compareScreenCaptureParameters(ScreenCaptureParameters selfParam, ScreenCaptureParameters outParam)
        {
            if (compareVideoDimensions(selfParam.dimensions, outParam.dimensions) == false)
                return false;
            if (compareInt(selfParam.frameRate, outParam.frameRate) == false)
                return false;
            if (compareInt(selfParam.bitrate, outParam.bitrate) == false)
                return false;
            if (compareBool(selfParam.captureMouseCursor, outParam.captureMouseCursor) == false)
                return false;
            if (compareBool(selfParam.windowFocus, outParam.windowFocus) == false)
                return false;
            if (compareView_tArray(selfParam.excludeWindowList, outParam.excludeWindowList) == false)
                return false;
            if (compareInt(selfParam.excludeWindowCount, outParam.excludeWindowCount) == false)
                return false;
            if (compareInt(selfParam.highLightWidth, outParam.highLightWidth) == false)
                return false;
            if (compareUnsignedInt(selfParam.highLightColor, outParam.highLightColor) == false)
                return false;
            if (compareBool(selfParam.enableHighLight, outParam.enableHighLight) == false)
                return false;
            return true;
        }

        public static bool compareAUDIO_RECORDING_QUALITY_TYPE(AUDIO_RECORDING_QUALITY_TYPE selfParam, AUDIO_RECORDING_QUALITY_TYPE outParam)
        {
            return selfParam == AUDIO_RECORDING_QUALITY_TYPE.AUDIO_RECORDING_QUALITY_LOW;
        }

        public static bool compareAUDIO_FILE_RECORDING_TYPE(AUDIO_FILE_RECORDING_TYPE selfParam, AUDIO_FILE_RECORDING_TYPE outParam)
        {
            return selfParam == AUDIO_FILE_RECORDING_TYPE.AUDIO_FILE_RECORDING_MIC;
        }

        public static bool compareAUDIO_ENCODED_FRAME_OBSERVER_POSITION(AUDIO_ENCODED_FRAME_OBSERVER_POSITION selfParam, AUDIO_ENCODED_FRAME_OBSERVER_POSITION outParam)
        {
            return selfParam == AUDIO_ENCODED_FRAME_OBSERVER_POSITION.AUDIO_ENCODED_FRAME_OBSERVER_POSITION_RECORD;
        }

        public static bool compareAudioRecordingConfiguration(AudioRecordingConfiguration selfParam, AudioRecordingConfiguration outParam)
        {
            if (compareString(selfParam.filePath, outParam.filePath) == false)
                return false;
            if (compareBool(selfParam.encode, outParam.encode) == false)
                return false;
            if (compareInt(selfParam.sampleRate, outParam.sampleRate) == false)
                return false;
            if (compareAUDIO_FILE_RECORDING_TYPE(selfParam.fileRecordingType, outParam.fileRecordingType) == false)
                return false;
            if (compareAUDIO_RECORDING_QUALITY_TYPE(selfParam.quality, outParam.quality) == false)
                return false;
            if (compareInt(selfParam.recordingChannel, outParam.recordingChannel) == false)
                return false;
            return true;
        }

        public static bool compareAudioEncodedFrameObserverConfig(AudioEncodedFrameObserverConfig selfParam, AudioEncodedFrameObserverConfig outParam)
        {
            if (compareAUDIO_ENCODED_FRAME_OBSERVER_POSITION(selfParam.postionType, outParam.postionType) == false)
                return false;
            if (compareAUDIO_ENCODING_TYPE(selfParam.encodingType, outParam.encodingType) == false)
                return false;
            return true;
        }

        public static bool compareIAudioEncodedFrameObserver(IAudioEncodedFrameObserver selfParam, IAudioEncodedFrameObserver outParam) { return true; }

        public static bool compareAREA_CODE(AREA_CODE selfParam, AREA_CODE outParam)
        {
            return selfParam == AREA_CODE.AREA_CODE_CN;
        }

        public static bool compareAREA_CODE_EX(AREA_CODE_EX selfParam, AREA_CODE_EX outParam)
        {
            return selfParam == AREA_CODE_EX.AREA_CODE_OC;
        }

        public static bool compareCHANNEL_MEDIA_RELAY_ERROR(CHANNEL_MEDIA_RELAY_ERROR selfParam, CHANNEL_MEDIA_RELAY_ERROR outParam)
        {
            return selfParam == CHANNEL_MEDIA_RELAY_ERROR.RELAY_OK;
        }

        public static bool compareCHANNEL_MEDIA_RELAY_EVENT(CHANNEL_MEDIA_RELAY_EVENT selfParam, CHANNEL_MEDIA_RELAY_EVENT outParam)
        {
            return selfParam == CHANNEL_MEDIA_RELAY_EVENT.RELAY_EVENT_NETWORK_DISCONNECTED;
        }

        public static bool compareCHANNEL_MEDIA_RELAY_STATE(CHANNEL_MEDIA_RELAY_STATE selfParam, CHANNEL_MEDIA_RELAY_STATE outParam)
        {
            return selfParam == CHANNEL_MEDIA_RELAY_STATE.RELAY_STATE_IDLE;
        }

        public static bool compareChannelMediaInfo(ChannelMediaInfo selfParam, ChannelMediaInfo outParam)
        {
            if (compareString(selfParam.channelName, outParam.channelName) == false)
                return false;
            if (compareString(selfParam.token, outParam.token) == false)
                return false;
            if (compareUid_t(selfParam.uid, outParam.uid) == false)
                return false;
            return true;
        }

        public static bool compareUplinkNetworkInfo(UplinkNetworkInfo selfParam, UplinkNetworkInfo outParam)
        {
            if (compareInt(selfParam.video_encoder_target_bitrate_bps, outParam.video_encoder_target_bitrate_bps) == false)
                return false;
            return true;
        }

        public static bool comparePeerDownlinkInfoArray(PeerDownlinkInfo[] selfParam, PeerDownlinkInfo[] outParam)
        {
            if (selfParam.Length != 10)
                return false;

            for (int i = 0; i < selfParam.Length; i++)
            {
                if (comparePeerDownlinkInfo(selfParam[i], outParam[i]) == false)
                    return false;
            }

            return true;
        }


        public static bool compareDownlinkNetworkInfo(DownlinkNetworkInfo selfParam, DownlinkNetworkInfo outParam)
        {
            if (compareInt(selfParam.lastmile_buffer_delay_time_ms, outParam.lastmile_buffer_delay_time_ms) == false)
                return false;
            if (compareInt(selfParam.bandwidth_estimation_bps, outParam.bandwidth_estimation_bps) == false)
                return false;
            if (compareInt(selfParam.total_downscale_level_count, outParam.total_downscale_level_count) == false)
                return false;
            if (comparePeerDownlinkInfoArray(selfParam.peer_downlink_info, outParam.peer_downlink_info) == false)
                return false;
            if (compareInt(selfParam.total_received_video_count, outParam.total_received_video_count) == false)
                return false;
            return true;
        }

        public static bool comparePeerDownlinkInfo(PeerDownlinkInfo selfParam, PeerDownlinkInfo outParam)
        {
            if (compareString(selfParam.uid, outParam.uid) == false)
                return false;
            if (compareVIDEO_STREAM_TYPE(selfParam.stream_type, outParam.stream_type) == false)
                return false;
            if (compareREMOTE_VIDEO_DOWNSCALE_LEVEL(selfParam.current_downscale_level, outParam.current_downscale_level) == false)
                return false;
            if (compareInt(selfParam.expected_bitrate_bps, outParam.expected_bitrate_bps) == false)
                return false;
            return true;
        }

        public static bool compareENCRYPTION_MODE(ENCRYPTION_MODE selfParam, ENCRYPTION_MODE outParam)
        {
            return selfParam == ENCRYPTION_MODE.AES_128_XTS;
        }

        public static bool compareENCRYPTION_ERROR_TYPE(ENCRYPTION_ERROR_TYPE selfParam, ENCRYPTION_ERROR_TYPE outParam)
        {
            return selfParam == ENCRYPTION_ERROR_TYPE.ENCRYPTION_ERROR_INTERNAL_FAILURE;
        }

        public static bool compareUPLOAD_ERROR_REASON(UPLOAD_ERROR_REASON selfParam, UPLOAD_ERROR_REASON outParam)
        {
            return selfParam == UPLOAD_ERROR_REASON.UPLOAD_SUCCESS;
        }

        public static bool comparePERMISSION_TYPE(PERMISSION_TYPE selfParam, PERMISSION_TYPE outParam)
        {
            return selfParam == PERMISSION_TYPE.RECORD_AUDIO;
        }

        public static bool compareMAX_USER_ACCOUNT_LENGTH_TYPE(MAX_USER_ACCOUNT_LENGTH_TYPE selfParam, MAX_USER_ACCOUNT_LENGTH_TYPE outParam)
        {
            return selfParam == MAX_USER_ACCOUNT_LENGTH_TYPE.MAX_USER_ACCOUNT_LENGTH;
        }

        public static bool compareSTREAM_SUBSCRIBE_STATE(STREAM_SUBSCRIBE_STATE selfParam, STREAM_SUBSCRIBE_STATE outParam)
        {
            return selfParam == STREAM_SUBSCRIBE_STATE.SUB_STATE_IDLE;
        }

        public static bool compareSTREAM_PUBLISH_STATE(STREAM_PUBLISH_STATE selfParam, STREAM_PUBLISH_STATE outParam)
        {
            return selfParam == STREAM_PUBLISH_STATE.PUB_STATE_IDLE;
        }

        public static bool compareEchoTestConfiguration(EchoTestConfiguration selfParam, EchoTestConfiguration outParam)
        {
            if (compareView_t(selfParam.view, outParam.view) == false)
                return false;
            if (compareBool(selfParam.enableAudio, outParam.enableAudio) == false)
                return false;
            if (compareBool(selfParam.enableVideo, outParam.enableVideo) == false)
                return false;
            if (compareString(selfParam.token, outParam.token) == false)
                return false;
            if (compareString(selfParam.channelId, outParam.channelId) == false)
                return false;
            return true;
        }

        public static bool compareEAR_MONITORING_FILTER_TYPE(EAR_MONITORING_FILTER_TYPE selfParam, EAR_MONITORING_FILTER_TYPE outParam)
        {
            return selfParam == EAR_MONITORING_FILTER_TYPE.EAR_MONITORING_FILTER_NONE;
        }

        public static bool compareTHREAD_PRIORITY_TYPE(THREAD_PRIORITY_TYPE selfParam, THREAD_PRIORITY_TYPE outParam)
        {
            return selfParam == THREAD_PRIORITY_TYPE.LOWEST;
        }

        public static bool compareScreenVideoParameters(ScreenVideoParameters selfParam, ScreenVideoParameters outParam)
        {
            if (compareVideoDimensions(selfParam.dimensions, outParam.dimensions) == false)
                return false;
            if (compareInt(selfParam.frameRate, outParam.frameRate) == false)
                return false;
            if (compareInt(selfParam.bitrate, outParam.bitrate) == false)
                return false;
            if (compareVIDEO_CONTENT_HINT(selfParam.contentHint, outParam.contentHint) == false)
                return false;
            return true;
        }

        public static bool compareScreenAudioParameters(ScreenAudioParameters selfParam, ScreenAudioParameters outParam)
        {
            if (compareInt(selfParam.sampleRate, outParam.sampleRate) == false)
                return false;
            if (compareInt(selfParam.channels, outParam.channels) == false)
                return false;
            if (compareInt(selfParam.captureSignalVolume, outParam.captureSignalVolume) == false)
                return false;
            return true;
        }

        public static bool compareScreenCaptureParameters2(ScreenCaptureParameters2 selfParam, ScreenCaptureParameters2 outParam)
        {
            if (compareBool(selfParam.captureAudio, outParam.captureAudio) == false)
                return false;
            if (compareScreenAudioParameters(selfParam.audioParams, outParam.audioParams) == false)
                return false;
            if (compareBool(selfParam.captureVideo, outParam.captureVideo) == false)
                return false;
            if (compareScreenVideoParameters(selfParam.videoParams, outParam.videoParams) == false)
                return false;
            return true;
        }

        public static bool compareAudioRoute(AudioRoute selfParam, AudioRoute outParam)
        {
            return selfParam == AudioRoute.ROUTE_DEFAULT;
        }

        public static bool compareBYTES_PER_SAMPLE(BYTES_PER_SAMPLE selfParam, BYTES_PER_SAMPLE outParam) { return selfParam == BYTES_PER_SAMPLE.TWO_BYTES_PER_SAMPLE; }

        public static bool compareAudioParameters(AudioParameters selfParam, AudioParameters outParam)
        {
            if (compareInt(selfParam.sample_rate, outParam.sample_rate) == false)
                return false;
            if (compareSize_t(selfParam.channels, outParam.channels) == false)
                return false;
            if (compareSize_t(selfParam.frames_per_buffer, outParam.frames_per_buffer) == false)
                return false;
            return true;
        }

        public static bool compareRAW_AUDIO_FRAME_OP_MODE_TYPE(RAW_AUDIO_FRAME_OP_MODE_TYPE selfParam, RAW_AUDIO_FRAME_OP_MODE_TYPE outParam)
        {
            return selfParam == RAW_AUDIO_FRAME_OP_MODE_TYPE.RAW_AUDIO_FRAME_OP_MODE_READ_ONLY;
        }

        public static bool compareMEDIA_SOURCE_TYPE(MEDIA_SOURCE_TYPE selfParam, MEDIA_SOURCE_TYPE outParam)
        {
            return selfParam == MEDIA_SOURCE_TYPE.AUDIO_PLAYOUT_SOURCE;
        }

        public static bool compareCONTENT_INSPECT_RESULT(CONTENT_INSPECT_RESULT selfParam, CONTENT_INSPECT_RESULT outParam)
        {
            return selfParam == CONTENT_INSPECT_RESULT.CONTENT_INSPECT_NEUTRAL;
        }

        public static bool compareCONTENT_INSPECT_TYPE(CONTENT_INSPECT_TYPE selfParam, CONTENT_INSPECT_TYPE outParam)
        {
            return selfParam == CONTENT_INSPECT_TYPE.CONTENT_INSPECT_INVALID;
        }

        public static bool compareContentInspectModule(ContentInspectModule selfParam, ContentInspectModule outParam)
        {
            if (compareCONTENT_INSPECT_TYPE(selfParam.type, outParam.type) == false)
                return false;
            if (compareUnsignedInt(selfParam.interval, outParam.interval) == false)
                return false;
            return true;
        }

        public static bool compareUnsignedLong(ulong selfParam, ulong outParam)
        {
            return selfParam == 10;
        }

        public static bool compareLong(long selfParam, long outParam)
        {
            return selfParam == 10;
        }

        public static bool compareAudioEncodedFrameInfo(AudioEncodedFrameInfo selfParam, AudioEncodedFrameInfo outParam)
        {
            if (compareUnsignedLong(selfParam.sendTs, outParam.sendTs) == false)
                return false;
            if (compareInt(selfParam.codec, outParam.codec) == false)
                return false;
            return true;
        }

        public static bool compareAudioPcmFrame(AudioPcmFrame selfParam, AudioPcmFrame outParam)
        {
            if (compareLong(selfParam.capture_timestamp, outParam.capture_timestamp) == false)
                return false;
            if (compareUnsignedLong(selfParam.samples_per_channel_, outParam.samples_per_channel_) == false)
                return false;
            if (compareInt(selfParam.sample_rate_hz_, outParam.sample_rate_hz_) == false)
                return false;
            if (compareUnsignedLong(selfParam.num_channels_, outParam.num_channels_) == false)
                return false;
            if (compareBYTES_PER_SAMPLE(selfParam.bytes_per_sample, outParam.bytes_per_sample) == false)
                return false;
            return true;
        }

        public static bool compareAUDIO_DUAL_MONO_MODE(AUDIO_DUAL_MONO_MODE selfParam, AUDIO_DUAL_MONO_MODE outParam)
        {
            return selfParam == AUDIO_DUAL_MONO_MODE.AUDIO_DUAL_MONO_STEREO;
        }


        public static bool compareVIDEO_PIXEL_FORMAT(VIDEO_PIXEL_FORMAT selfParam, VIDEO_PIXEL_FORMAT outParam)
        {
            return selfParam == VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_DEFAULT;
        }

        public static bool compareRENDER_MODE_TYPE(RENDER_MODE_TYPE selfParam, RENDER_MODE_TYPE outParam)
        {
            return selfParam == RENDER_MODE_TYPE.RENDER_MODE_HIDDEN;
        }

        public static bool compareVIDEO_SOURCE_TYPE(VIDEO_SOURCE_TYPE selfParam, VIDEO_SOURCE_TYPE outParam)
        {
            return selfParam == VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY;
        }

        public static bool compareExternalVideoFrame(ExternalVideoFrame selfParam, ExternalVideoFrame outParam)
        {
            if (compareVIDEO_BUFFER_TYPE(selfParam.type, outParam.type) == false)
                return false;
            if (compareVIDEO_PIXEL_FORMAT(selfParam.format, outParam.format) == false)
                return false;
            if (compareInt(selfParam.stride, outParam.stride) == false)
                return false;
            if (compareInt(selfParam.height, outParam.height) == false)
                return false;
            if (compareInt(selfParam.cropLeft, outParam.cropLeft) == false)
                return false;
            if (compareInt(selfParam.cropTop, outParam.cropTop) == false)
                return false;
            if (compareInt(selfParam.cropRight, outParam.cropRight) == false)
                return false;
            if (compareInt(selfParam.cropBottom, outParam.cropBottom) == false)
                return false;
            if (compareInt(selfParam.rotation, outParam.rotation) == false)
                return false;
            if (compareLong(selfParam.timestamp, outParam.timestamp) == false)
                return false;

            if (compareEGL_CONTEXT_TYPE(selfParam.eglType, outParam.eglType) == false)
                return false;
            if (compareInt(selfParam.textureId, outParam.textureId) == false)
                return false;
            if (compareInt(selfParam.metadata_size, outParam.metadata_size) == false)
                return false;
            return true;
        }

        public static bool compareEGL_CONTEXT_TYPE(EGL_CONTEXT_TYPE selfParam, EGL_CONTEXT_TYPE outParam)
        {
            return selfParam == EGL_CONTEXT_TYPE.EGL_CONTEXT10;
        }

        public static bool compareVIDEO_BUFFER_TYPE(VIDEO_BUFFER_TYPE selfParam, VIDEO_BUFFER_TYPE outParam)
        {
            return selfParam == VIDEO_BUFFER_TYPE.VIDEO_BUFFER_RAW_DATA;
        }

        public static bool compareVideoFrameBufferConfig(VideoFrameBufferConfig selfParam, VideoFrameBufferConfig outParam)
        {
            if (selfParam.type != outParam.type)
                return false;

            if (selfParam.id != outParam.id)
                return false;

            if (selfParam.key != outParam.key)
                return false;

            return true;
        }

        public static bool compareVideoFrame(VideoFrame selfParam, VideoFrame outParam)
        {
            if (compareVIDEO_PIXEL_FORMAT(selfParam.type, outParam.type) == false)
                return false;
            if (compareInt(selfParam.width, outParam.width) == false)
                return false;
            if (compareInt(selfParam.height, outParam.height) == false)
                return false;
            if (compareInt(selfParam.yStride, outParam.yStride) == false)
                return false;
            if (compareInt(selfParam.uStride, outParam.uStride) == false)
                return false;
            if (compareInt(selfParam.vStride, outParam.vStride) == false)
                return false;
            if (compareInt(selfParam.rotation, outParam.rotation) == false)
                return false;
            if (compareLong(selfParam.renderTimeMs, outParam.renderTimeMs) == false)
                return false;
            if (compareInt(selfParam.avsync_type, outParam.avsync_type) == false)
                return false;
            if (compareInt(selfParam.textureId, outParam.textureId) == false)
                return false;
            return true;
        }

        public static bool compareMEDIA_PLAYER_SOURCE_TYPE(MEDIA_PLAYER_SOURCE_TYPE selfParam, MEDIA_PLAYER_SOURCE_TYPE outParam)
        {
            return selfParam == MEDIA_PLAYER_SOURCE_TYPE.MEDIA_PLAYER_SOURCE_DEFAULT;
        }

        public static bool compareVIDEO_MODULE_POSITION(VIDEO_MODULE_POSITION selfParam, VIDEO_MODULE_POSITION outParam)
        {
            return selfParam == VIDEO_MODULE_POSITION.POSITION_POST_CAPTURER;
        }

        public static bool compareAUDIO_FRAME_TYPE(AUDIO_FRAME_TYPE selfParam, AUDIO_FRAME_TYPE outParam)
        {
            return selfParam == AUDIO_FRAME_TYPE.FRAME_TYPE_PCM16;
        }


        public static bool compareAudioFrame(AudioFrame selfParam, AudioFrame outParam)
        {
            if (compareAUDIO_FRAME_TYPE(selfParam.type, outParam.type) == false)
                return false;
            if (compareInt(selfParam.samplesPerChannel, outParam.samplesPerChannel) == false)
                return false;
            if (compareBYTES_PER_SAMPLE(selfParam.bytesPerSample, outParam.bytesPerSample) == false)
                return false;
            if (compareInt(selfParam.channels, outParam.channels) == false)
                return false;
            if (compareInt(selfParam.samplesPerSec, outParam.samplesPerSec) == false)
                return false;
            if (compareLong(selfParam.renderTimeMs, outParam.renderTimeMs) == false)
                return false;
            if (compareInt(selfParam.avsync_type, outParam.avsync_type) == false)
                return false;
            return true;
        }

        public static bool compareAUDIO_FRAME_POSITION(AUDIO_FRAME_POSITION selfParam, AUDIO_FRAME_POSITION outParam)
        {
            return selfParam == AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_NONE;
        }

        public static bool compareAudioParams(AudioParams selfParam, AudioParams outParam)
        {
            if (compareInt(selfParam.sample_rate, outParam.sample_rate) == false)
                return false;
            if (compareInt(selfParam.channels, outParam.channels) == false)
                return false;
            if (compareRAW_AUDIO_FRAME_OP_MODE_TYPE(selfParam.mode, outParam.mode) == false)
                return false;
            if (compareInt(selfParam.samples_per_call, outParam.samples_per_call) == false)
                return false;
            return true;
        }

        public static bool compareAudioSpectrumData(AudioSpectrumData selfParam, AudioSpectrumData outParam)
        {
            if (compareFloatArray(selfParam.audioSpectrumData, outParam.audioSpectrumData) == false)
                return false;
            if (compareInt(selfParam.dataLength, outParam.dataLength) == false)
                return false;
            return true;
        }

        public static bool compareUserAudioSpectrumInfo(UserAudioSpectrumInfo selfParam, UserAudioSpectrumInfo outParam)
        {
            if (compareUid_t(selfParam.uid, outParam.uid) == false)
                return false;
            if (compareAudioSpectrumData(selfParam.spectrumData, outParam.spectrumData) == false)
                return false;
            return true;
        }

        public static bool compareEXTERNAL_VIDEO_SOURCE_TYPE(EXTERNAL_VIDEO_SOURCE_TYPE selfParam, EXTERNAL_VIDEO_SOURCE_TYPE outParam)
        {
            return selfParam == EXTERNAL_VIDEO_SOURCE_TYPE.VIDEO_FRAME;
        }

        public static bool compareMediaRecorderContainerFormat(MediaRecorderContainerFormat selfParam, MediaRecorderContainerFormat outParam)
        {
            return selfParam == MediaRecorderContainerFormat.FORMAT_MP4;
        }

        public static bool compareMediaRecorderStreamType(MediaRecorderStreamType selfParam, MediaRecorderStreamType outParam)
        {
            return selfParam == MediaRecorderStreamType.STREAM_TYPE_AUDIO;
        }

        public static bool compareRecorderState(RecorderState selfParam, RecorderState outParam)
        {
            return selfParam == RecorderState.RECORDER_STATE_ERROR;
        }

        public static bool compareRecorderErrorCode(RecorderErrorCode selfParam, RecorderErrorCode outParam)
        {
            return selfParam == RecorderErrorCode.RECORDER_ERROR_NONE;
        }

        public static bool compareMediaRecorderConfiguration(MediaRecorderConfiguration selfParam, MediaRecorderConfiguration outParam)
        {
            if (compareString(selfParam.storagePath, outParam.storagePath) == false)
                return false;
            if (compareMediaRecorderContainerFormat(selfParam.containerFormat, outParam.containerFormat) == false)
                return false;
            if (compareMediaRecorderStreamType(selfParam.streamType, outParam.streamType) == false)
                return false;
            if (compareInt(selfParam.maxDurationMs, outParam.maxDurationMs) == false)
                return false;
            if (compareInt(selfParam.recorderInfoUpdateInterval, outParam.recorderInfoUpdateInterval) == false)
                return false;
            return true;
        }

        public static bool compareRecorderInfo(RecorderInfo selfParam, RecorderInfo outParam)
        {
            if (compareString(selfParam.fileName, outParam.fileName) == false)
                return false;
            if (compareUnsignedInt(selfParam.durationMs, outParam.durationMs) == false)
                return false;
            if (compareUnsignedInt(selfParam.fileSize, outParam.fileSize) == false)
                return false;
            return true;
        }


        public static bool compareMEDIA_PLAYER_STATE(MEDIA_PLAYER_STATE selfParam, MEDIA_PLAYER_STATE outParam)
        {
            return selfParam == MEDIA_PLAYER_STATE.PLAYER_STATE_IDLE;
        }

        public static bool compareMEDIA_PLAYER_ERROR(MEDIA_PLAYER_ERROR selfParam, MEDIA_PLAYER_ERROR outParam)
        {
            return selfParam == MEDIA_PLAYER_ERROR.PLAYER_ERROR_NONE;
        }

        public static bool compareMEDIA_STREAM_TYPE(MEDIA_STREAM_TYPE selfParam, MEDIA_STREAM_TYPE outParam)
        {
            return selfParam == MEDIA_STREAM_TYPE.STREAM_TYPE_UNKNOWN;
        }

        public static bool compareMEDIA_PLAYER_EVENT(MEDIA_PLAYER_EVENT selfParam, MEDIA_PLAYER_EVENT outParam)
        {
            return selfParam == MEDIA_PLAYER_EVENT.PLAYER_EVENT_SEEK_BEGIN;
        }

        public static bool comparePLAYER_PRELOAD_EVENT(PLAYER_PRELOAD_EVENT selfParam, PLAYER_PRELOAD_EVENT outParam)
        {
            return selfParam == PLAYER_PRELOAD_EVENT.PLAYER_PRELOAD_EVENT_BEGIN;
        }

        public static bool comparePlayerStreamInfo(PlayerStreamInfo selfParam, PlayerStreamInfo outParam)
        {
            if (compareInt(selfParam.streamIndex, outParam.streamIndex) == false)
                return false;
            if (compareMEDIA_STREAM_TYPE(selfParam.streamType, outParam.streamType) == false)
                return false;
            if (compareString(selfParam.codecName, outParam.codecName) == false)
                return false;
            if (compareString(selfParam.language, outParam.language) == false)
                return false;
            if (compareInt(selfParam.videoFrameRate, outParam.videoFrameRate) == false)
                return false;
            if (compareInt(selfParam.videoBitRate, outParam.videoBitRate) == false)
                return false;
            if (compareInt(selfParam.videoWidth, outParam.videoWidth) == false)
                return false;
            if (compareInt(selfParam.videoHeight, outParam.videoHeight) == false)
                return false;
            if (compareInt(selfParam.videoRotation, outParam.videoRotation) == false)
                return false;
            if (compareInt(selfParam.audioSampleRate, outParam.audioSampleRate) == false)
                return false;
            if (compareInt(selfParam.audioChannels, outParam.audioChannels) == false)
                return false;
            if (compareInt(selfParam.audioBitsPerSample, outParam.audioBitsPerSample) == false)
                return false;
            if (compareLong(selfParam.duration, outParam.duration) == false)
                return false;
            return true;
        }

        public static bool compareSrcInfo(SrcInfo selfParam, SrcInfo outParam)
        {
            if (compareInt(selfParam.bitrateInKbps, outParam.bitrateInKbps) == false)
                return false;
            if (compareString(selfParam.name, outParam.name) == false)
                return false;
            return true;
        }

        public static bool compareMEDIA_PLAYER_METADATA_TYPE(MEDIA_PLAYER_METADATA_TYPE selfParam, MEDIA_PLAYER_METADATA_TYPE outParam)
        {
            return selfParam == MEDIA_PLAYER_METADATA_TYPE.PLAYER_METADATA_TYPE_UNKNOWN;
        }

        public static bool compareCacheStatistics(CacheStatistics selfParam, CacheStatistics outParam)
        {
            if (compareLong(selfParam.fileSize, outParam.fileSize) == false)
                return false;
            if (compareLong(selfParam.cacheSize, outParam.cacheSize) == false)
                return false;
            if (compareLong(selfParam.downloadSize, outParam.downloadSize) == false)
                return false;
            return true;
        }

        public static bool compareAUDIO_MIXING_DUAL_MONO_MODE(AUDIO_MIXING_DUAL_MONO_MODE selfParam, AUDIO_MIXING_DUAL_MONO_MODE outParam)
        {
            return selfParam == AUDIO_MIXING_DUAL_MONO_MODE.AUDIO_MIXING_DUAL_MONO_AUTO;
        }


        public static bool compareMvProperty(MvProperty selfParam, MvProperty outParam)
        {
            if (compareString(selfParam.resolution, outParam.resolution) == false)
                return false;
            if (compareString(selfParam.bandWidth, outParam.bandWidth) == false)
                return false;
            return true;
        }

        public static bool compareClimaxSegment(ClimaxSegment selfParam, ClimaxSegment outParam)
        {
            if (compareInt(selfParam.startTimeMs, outParam.startTimeMs) == false)
                return false;
            if (compareInt(selfParam.endTimeMs, outParam.endTimeMs) == false)
                return false;
            return true;
        }

        public static bool comparePreloadStatusCode(PreloadStatusCode selfParam, PreloadStatusCode outParam)
        {
            return selfParam == PreloadStatusCode.kPreloadStatusCompleted;
        }

        public static bool compareMusicArray(Music[] selfParam, Music[] outParam)
        {
            if (selfParam.Length != 10)
                return false;

            for (var i = 0; i < selfParam.Length; i++)
            {
                if (compareMusic(selfParam[i], outParam[i]) == false)
                    return false;
            }

            return true;
        }

        public static bool compareMusic(Music selfParam, Music outParam)
        {
            if (compareInt64_t(selfParam.songCode, outParam.songCode) == false)
                return false;
            if (compareString(selfParam.name, outParam.name) == false)
                return false;
            if (compareString(selfParam.singer, outParam.singer) == false)
                return false;
            if (compareString(selfParam.poster, outParam.poster) == false)
                return false;
            if (compareString(selfParam.releaseTime, outParam.releaseTime) == false)
                return false;
            if (compareInt(selfParam.durationS, outParam.durationS) == false)
                return false;
            if (compareInt(selfParam.type, outParam.type) == false)
                return false;
            if (compareInt(selfParam.pitchType, outParam.pitchType) == false)
                return false;
            if (compareInt(selfParam.lyricCount, outParam.lyricCount) == false)
                return false;

            if (compareInt(selfParam.climaxSegmentCount, outParam.climaxSegmentCount) == false)
                return false;
            if (compareInt(selfParam.mvPropertyCount, outParam.mvPropertyCount) == false)
                return false;

            return true;
        }

        public static bool compareMusicCollection(MusicCollection selfParam, MusicCollection outParam)
        {
            if (compareInt(selfParam.count, outParam.count) == false)
                return false;
            if (compareInt(selfParam.total, outParam.total) == false)
                return false;
            if (compareInt(selfParam.page, outParam.page) == false)
                return false;
            if (compareInt(selfParam.pageSize, outParam.pageSize) == false)
                return false;

            if (compareMusicArray(selfParam.music, outParam.music) == false)
                return false;

            return true;
        }


        public static bool compareMEDIA_DEVICE_TYPE(MEDIA_DEVICE_TYPE selfParam, MEDIA_DEVICE_TYPE outParam)
        {
            return selfParam == MEDIA_DEVICE_TYPE.UNKNOWN_AUDIO_DEVICE;
        }

        public static bool compareAUDIO_MIXING_STATE_TYPE(AUDIO_MIXING_STATE_TYPE selfParam, AUDIO_MIXING_STATE_TYPE outParam)
        {
            return selfParam == AUDIO_MIXING_STATE_TYPE.AUDIO_MIXING_STATE_PLAYING;
        }

        public static bool compareAUDIO_MIXING_REASON_TYPE(AUDIO_MIXING_REASON_TYPE selfParam, AUDIO_MIXING_REASON_TYPE outParam)
        {
            return selfParam == AUDIO_MIXING_REASON_TYPE.AUDIO_MIXING_REASON_CAN_NOT_OPEN;
        }

        public static bool compareINJECT_STREAM_STATUS(INJECT_STREAM_STATUS selfParam, INJECT_STREAM_STATUS outParam)
        {
            return selfParam == INJECT_STREAM_STATUS.INJECT_STREAM_STATUS_START_SUCCESS;
        }

        public static bool compareAUDIO_EQUALIZATION_BAND_FREQUENCY(AUDIO_EQUALIZATION_BAND_FREQUENCY selfParam, AUDIO_EQUALIZATION_BAND_FREQUENCY outParam)
        {
            return selfParam == AUDIO_EQUALIZATION_BAND_FREQUENCY.AUDIO_EQUALIZATION_BAND_31;
        }

        public static bool compareAUDIO_REVERB_TYPE(AUDIO_REVERB_TYPE selfParam, AUDIO_REVERB_TYPE outParam)
        {
            return selfParam == AUDIO_REVERB_TYPE.AUDIO_REVERB_DRY_LEVEL;
        }

        public static bool compareSTREAM_FALLBACK_OPTIONS(STREAM_FALLBACK_OPTIONS selfParam, STREAM_FALLBACK_OPTIONS outParam)
        {
            return selfParam == STREAM_FALLBACK_OPTIONS.STREAM_FALLBACK_OPTION_DISABLED;
        }

        public static bool comparePRIORITY_TYPE(PRIORITY_TYPE selfParam, PRIORITY_TYPE outParam)
        {
            return selfParam == PRIORITY_TYPE.PRIORITY_HIGH;
        }

        public static bool compareLocalVideoStats(LocalVideoStats selfParam, LocalVideoStats outParam)
        {
            if (compareUid_t(selfParam.uid, outParam.uid) == false)
                return false;
            if (compareInt(selfParam.sentBitrate, outParam.sentBitrate) == false)
                return false;
            if (compareInt(selfParam.sentFrameRate, outParam.sentFrameRate) == false)
                return false;
            if (compareInt(selfParam.captureFrameRate, outParam.captureFrameRate) == false)
                return false;
            if (compareInt(selfParam.captureFrameWidth, outParam.captureFrameWidth) == false)
                return false;
            if (compareInt(selfParam.captureFrameHeight, outParam.captureFrameHeight) == false)
                return false;
            if (compareInt(selfParam.regulatedCaptureFrameRate, outParam.regulatedCaptureFrameRate) == false)
                return false;
            if (compareInt(selfParam.regulatedCaptureFrameWidth, outParam.regulatedCaptureFrameWidth) == false)
                return false;
            if (compareInt(selfParam.regulatedCaptureFrameHeight, outParam.regulatedCaptureFrameHeight) == false)
                return false;
            if (compareInt(selfParam.encoderOutputFrameRate, outParam.encoderOutputFrameRate) == false)
                return false;
            if (compareInt(selfParam.encodedFrameWidth, outParam.encodedFrameWidth) == false)
                return false;
            if (compareInt(selfParam.encodedFrameHeight, outParam.encodedFrameHeight) == false)
                return false;
            if (compareInt(selfParam.rendererOutputFrameRate, outParam.rendererOutputFrameRate) == false)
                return false;
            if (compareInt(selfParam.targetBitrate, outParam.targetBitrate) == false)
                return false;
            if (compareInt(selfParam.targetFrameRate, outParam.targetFrameRate) == false)
                return false;
            if (compareQUALITY_ADAPT_INDICATION(selfParam.qualityAdaptIndication, outParam.qualityAdaptIndication) == false)
                return false;
            if (compareInt(selfParam.encodedBitrate, outParam.encodedBitrate) == false)
                return false;
            if (compareInt(selfParam.encodedFrameCount, outParam.encodedFrameCount) == false)
                return false;
            if (compareVIDEO_CODEC_TYPE(selfParam.codecType, outParam.codecType) == false)
                return false;
            if (compareUnsignedShort(selfParam.txPacketLossRate, outParam.txPacketLossRate) == false)
                return false;
            if (compareCAPTURE_BRIGHTNESS_LEVEL_TYPE(selfParam.captureBrightnessLevel, outParam.captureBrightnessLevel) == false)
                return false;
            if (compareBool(selfParam.dualStreamEnabled, outParam.dualStreamEnabled) == false)
                return false;
            if (compareInt(selfParam.hwEncoderAccelerating, outParam.hwEncoderAccelerating) == false)
                return false;
            return true;
        }

        public static bool compareRemoteVideoStats(RemoteVideoStats selfParam, RemoteVideoStats outParam)
        {
            if (compareUid_t(selfParam.uid, outParam.uid) == false)
                return false;
            if (compareInt(selfParam.delay, outParam.delay) == false)
                return false;
            if (compareInt(selfParam.width, outParam.width) == false)
                return false;
            if (compareInt(selfParam.height, outParam.height) == false)
                return false;
            if (compareInt(selfParam.receivedBitrate, outParam.receivedBitrate) == false)
                return false;
            if (compareInt(selfParam.decoderOutputFrameRate, outParam.decoderOutputFrameRate) == false)
                return false;
            if (compareInt(selfParam.rendererOutputFrameRate, outParam.rendererOutputFrameRate) == false)
                return false;
            if (compareInt(selfParam.frameLossRate, outParam.frameLossRate) == false)
                return false;
            if (compareInt(selfParam.packetLossRate, outParam.packetLossRate) == false)
                return false;
            if (compareVIDEO_STREAM_TYPE(selfParam.rxStreamType, outParam.rxStreamType) == false)
                return false;
            if (compareInt(selfParam.totalFrozenTime, outParam.totalFrozenTime) == false)
                return false;
            if (compareInt(selfParam.frozenRate, outParam.frozenRate) == false)
                return false;
            if (compareInt(selfParam.avSyncTimeMs, outParam.avSyncTimeMs) == false)
                return false;
            if (compareInt(selfParam.totalActiveTime, outParam.totalActiveTime) == false)
                return false;
            if (compareInt(selfParam.publishDuration, outParam.publishDuration) == false)
                return false;
            if (compareInt(selfParam.superResolutionType, outParam.superResolutionType) == false)
                return false;
            if (compareInt(selfParam.mosValue, outParam.mosValue) == false)
                return false;
            return true;
        }

        public static bool compareVideoCompositingLayout(VideoCompositingLayout selfParam, VideoCompositingLayout outParam)
        {
            if (compareInt(selfParam.canvasWidth, outParam.canvasWidth) == false)
                return false;
            if (compareInt(selfParam.canvasHeight, outParam.canvasHeight) == false)
                return false;
            if (compareString(selfParam.backgroundColor, outParam.backgroundColor) == false)
                return false;
            if (compareInt(selfParam.regionCount, outParam.regionCount) == false)
                return false;
            if (compareString(selfParam.appData, outParam.appData) == false)
                return false;
            if (compareInt(selfParam.appDataLength, outParam.appDataLength) == false)
                return false;
            return true;
        }

        public static bool compareRegion(Region selfParam, Region outParam)
        {
            if (compareUid_t(selfParam.uid, outParam.uid) == false)
                return false;
            if (compareDouble(selfParam.x, outParam.x) == false)
                return false;
            if (compareDouble(selfParam.y, outParam.y) == false)
                return false;
            if (compareDouble(selfParam.width, outParam.width) == false)
                return false;
            if (compareDouble(selfParam.height, outParam.height) == false)
                return false;
            if (compareInt(selfParam.zOrder, outParam.zOrder) == false)
                return false;
            if (compareDouble(selfParam.alpha, outParam.alpha) == false)
                return false;
            if (compareRENDER_MODE_TYPE(selfParam.renderMode, outParam.renderMode) == false)
                return false;
            return true;
        }

        public static bool compareInjectStreamConfig(InjectStreamConfig selfParam, InjectStreamConfig outParam)
        {
            if (compareInt(selfParam.width, outParam.width) == false)
                return false;
            if (compareInt(selfParam.height, outParam.height) == false)
                return false;
            if (compareInt(selfParam.videoGop, outParam.videoGop) == false)
                return false;
            if (compareInt(selfParam.videoFramerate, outParam.videoFramerate) == false)
                return false;
            if (compareInt(selfParam.videoBitrate, outParam.videoBitrate) == false)
                return false;
            if (compareAUDIO_SAMPLE_RATE_TYPE(selfParam.audioSampleRate, outParam.audioSampleRate) == false)
                return false;
            if (compareInt(selfParam.audioBitrate, outParam.audioBitrate) == false)
                return false;
            if (compareInt(selfParam.audioChannels, outParam.audioChannels) == false)
                return false;
            return true;
        }

        public static bool compareRTMP_STREAM_LIFE_CYCLE_TYPE(RTMP_STREAM_LIFE_CYCLE_TYPE selfParam, RTMP_STREAM_LIFE_CYCLE_TYPE outParam)
        {
            return selfParam == RTMP_STREAM_LIFE_CYCLE_TYPE.RTMP_STREAM_LIFE_CYCLE_BIND2CHANNEL;
        }

        public static bool comparePublisherConfiguration(PublisherConfiguration selfParam, PublisherConfiguration outParam)
        {
            if (compareInt(selfParam.width, outParam.width) == false)
                return false;
            if (compareInt(selfParam.height, outParam.height) == false)
                return false;
            if (compareInt(selfParam.framerate, outParam.framerate) == false)
                return false;
            if (compareInt(selfParam.bitrate, outParam.bitrate) == false)
                return false;
            if (compareInt(selfParam.defaultLayout, outParam.defaultLayout) == false)
                return false;
            if (compareInt(selfParam.lifecycle, outParam.lifecycle) == false)
                return false;
            if (compareBool(selfParam.owner, outParam.owner) == false)
                return false;
            if (compareInt(selfParam.injectStreamWidth, outParam.injectStreamWidth) == false)
                return false;
            if (compareInt(selfParam.injectStreamHeight, outParam.injectStreamHeight) == false)
                return false;
            if (compareString(selfParam.injectStreamUrl, outParam.injectStreamUrl) == false)
                return false;
            if (compareString(selfParam.publishUrl, outParam.publishUrl) == false)
                return false;
            if (compareString(selfParam.rawStreamUrl, outParam.rawStreamUrl) == false)
                return false;
            if (compareString(selfParam.extraInfo, outParam.extraInfo) == false)
                return false;
            return true;
        }

        public static bool compareAudioTrackConfig(AudioTrackConfig selfParam, AudioTrackConfig outParam)
        {
            if (compareBool(selfParam.enableLocalPlayback, outParam.enableLocalPlayback) == false)
                return false;
            return true;
        }

        public static bool compareCAMERA_DIRECTION(CAMERA_DIRECTION selfParam, CAMERA_DIRECTION outParam)
        {
            return selfParam == CAMERA_DIRECTION.CAMERA_REAR;
        }

        public static bool compareCLOUD_PROXY_TYPE(CLOUD_PROXY_TYPE selfParam, CLOUD_PROXY_TYPE outParam)
        {
            return selfParam == CLOUD_PROXY_TYPE.NONE_PROXY;
        }

        public static bool compareCameraCapturerConfiguration(CameraCapturerConfiguration selfParam, CameraCapturerConfiguration outParam)
        {
            if (compareCAMERA_DIRECTION(selfParam.cameraDirection, outParam.cameraDirection) == false)
                return false;
            if (compareVideoFormat(selfParam.format, outParam.format) == false)
                return false;
            if (compareBool(selfParam.followEncodeDimensionRatio, outParam.followEncodeDimensionRatio) == false)
                return false;
            return true;
        }

        public static bool compareScreenCaptureConfiguration(ScreenCaptureConfiguration selfParam, ScreenCaptureConfiguration outParam)
        {
            if (compareBool(selfParam.isCaptureWindow, outParam.isCaptureWindow) == false)
                return false;
            if (compareUint(selfParam.displayId, outParam.displayId) == false)
                return false;
            if (compareRectangle(selfParam.screenRect, outParam.screenRect) == false)
                return false;
            if (compareView_t(selfParam.windowId, outParam.windowId) == false)
                return false;
            if (compareScreenCaptureParameters(selfParam.parameters, outParam.parameters) == false)
                return false;
            if (compareRectangle(selfParam.regionRect, outParam.regionRect) == false)
                return false;
            return true;
        }

        public static bool compareThumbImageBuffer(ThumbImageBuffer selfParam, ThumbImageBuffer outParam)
        {
            if (compareUnsignedInt(selfParam.length, outParam.length) == false)
                return false;
            if (compareUnsignedInt(selfParam.width, outParam.width) == false)
                return false;
            if (compareUnsignedInt(selfParam.height, outParam.height) == false)
                return false;
            return true;
        }

        public static bool compareScreenCaptureSourceType(ScreenCaptureSourceType selfParam, ScreenCaptureSourceType outParam)
        {
            return selfParam == ScreenCaptureSourceType.ScreenCaptureSourceType_Unknown;
        }

        public static bool compareScreenCaptureSourceInfo(ScreenCaptureSourceInfo selfParam, ScreenCaptureSourceInfo outParam)
        {
            if (compareScreenCaptureSourceType(selfParam.type, outParam.type) == false)
                return false;
            if (compareView_t(selfParam.sourceId, outParam.sourceId) == false)
                return false;
            if (compareString(selfParam.sourceName, outParam.sourceName) == false)
                return false;
            if (compareThumbImageBuffer(selfParam.thumbImage, outParam.thumbImage) == false)
                return false;
            if (compareThumbImageBuffer(selfParam.iconImage, outParam.iconImage) == false)
                return false;
            if (compareString(selfParam.processPath, outParam.processPath) == false)
                return false;
            if (compareString(selfParam.sourceTitle, outParam.sourceTitle) == false)
                return false;
            if (compareBool(selfParam.primaryMonitor, outParam.primaryMonitor) == false)
                return false;
            if (compareBool(selfParam.isOccluded, outParam.isOccluded) == false)
                return false;
            if (compareBool(selfParam.minimizeWindow, outParam.minimizeWindow) == false)
                return false;
            return true;
        }

        public static bool compareImageTrackOptions(ImageTrackOptions selfParam, ImageTrackOptions outParam)
        {
            if (compareString(selfParam.imageUrl, outParam.imageUrl) == false)
                return false;
            if (compareInt(selfParam.fps, outParam.fps) == false)
                return false;
            return true;
        }

        public static bool compareLOCAL_PROXY_MODE(LOCAL_PROXY_MODE selfParam, LOCAL_PROXY_MODE outParam)
        {
            return selfParam == LOCAL_PROXY_MODE.kConnectivityFirst;
        }

        public static bool comparePROXY_TYPE(PROXY_TYPE selfParam, PROXY_TYPE outParam)
        {
            return selfParam == PROXY_TYPE.NONE_PROXY_TYPE;
        }

        public static bool compareLogUploadServerInfo(LogUploadServerInfo selfParam, LogUploadServerInfo outParam)
        {
            if (compareString(selfParam.serverDomain, outParam.serverDomain) == false)
                return false;
            if (compareString(selfParam.serverPath, outParam.serverPath) == false)
                return false;
            if (compareInt(selfParam.serverPort, outParam.serverPort) == false)
                return false;
            if (compareBool(selfParam.serverHttps, outParam.serverHttps) == false)
                return false;
            return true;
        }

        public static bool compareAdvancedConfigInfo(AdvancedConfigInfo selfParam, AdvancedConfigInfo outParam)
        {
            if (compareLogUploadServerInfo(selfParam.logUploadServer, outParam.logUploadServer) == false)
                return false;
            return true;
        }

        public static bool compareLocalAccessPointConfiguration(LocalAccessPointConfiguration selfParam, LocalAccessPointConfiguration outParam)
        {
            if (compareInt(selfParam.ipListSize, outParam.ipListSize) == false)
                return false;
            if (compareInt(selfParam.domainListSize, outParam.domainListSize) == false)
                return false;
            if (compareString(selfParam.verifyDomainName, outParam.verifyDomainName) == false)
                return false;
            if (compareLOCAL_PROXY_MODE(selfParam.mode, outParam.mode) == false)
                return false;
            if (compareAdvancedConfigInfo(selfParam.advancedConfig, outParam.advancedConfig) == false)
                return false;
            return true;
        }

        public static bool compareLeaveChannelOptions(LeaveChannelOptions selfParam, LeaveChannelOptions outParam)
        {
            if (compareBool(selfParam.stopAudioMixing, outParam.stopAudioMixing) == false)
                return false;
            if (compareBool(selfParam.stopAllEffect, outParam.stopAllEffect) == false)
                return false;
            if (compareBool(selfParam.stopMicrophoneRecording, outParam.stopMicrophoneRecording) == false)
                return false;
            return true;
        }



        public static bool compareMETADATA_TYPE(METADATA_TYPE selfParam, METADATA_TYPE outParam)
        {
            return selfParam == METADATA_TYPE.UNKNOWN_METADATA;
        }

        public static bool compareMetadata(Metadata selfParam, Metadata outParam)
        {
            if (compareUnsignedInt(selfParam.uid, outParam.uid) == false)
                return false;
            if (compareUnsignedInt(selfParam.size, outParam.size) == false)
                return false;
            if (compareLong(selfParam.timeStampMs, outParam.timeStampMs) == false)
                return false;
            return true;
        }

        public static bool compareDIRECT_CDN_STREAMING_ERROR(DIRECT_CDN_STREAMING_ERROR selfParam, DIRECT_CDN_STREAMING_ERROR outParam)
        {
            return selfParam == DIRECT_CDN_STREAMING_ERROR.DIRECT_CDN_STREAMING_ERROR_OK;
        }

        public static bool compareDIRECT_CDN_STREAMING_STATE(DIRECT_CDN_STREAMING_STATE selfParam, DIRECT_CDN_STREAMING_STATE outParam)
        {
            return selfParam == DIRECT_CDN_STREAMING_STATE.DIRECT_CDN_STREAMING_STATE_IDLE;
        }

        public static bool compareDirectCdnStreamingStats(DirectCdnStreamingStats selfParam, DirectCdnStreamingStats outParam)
        {
            if (compareInt(selfParam.videoWidth, outParam.videoWidth) == false)
                return false;
            if (compareInt(selfParam.videoHeight, outParam.videoHeight) == false)
                return false;
            if (compareInt(selfParam.fps, outParam.fps) == false)
                return false;
            if (compareInt(selfParam.videoBitrate, outParam.videoBitrate) == false)
                return false;
            if (compareInt(selfParam.audioBitrate, outParam.audioBitrate) == false)
                return false;
            return true;
        }

        public static bool compareExtensionInfo(ExtensionInfo selfParam, ExtensionInfo outParam)
        {
            if (compareMEDIA_SOURCE_TYPE(selfParam.mediaSourceType, outParam.mediaSourceType) == false)
                return false;
            if (compareUid_t(selfParam.remoteUid, outParam.remoteUid) == false)
                return false;
            if (compareString(selfParam.channelId, outParam.channelId) == false)
                return false;
            if (compareUid_t(selfParam.localUid, outParam.localUid) == false)
                return false;
            return true;
        }

        public static bool compareQUALITY_REPORT_FORMAT_TYPE(QUALITY_REPORT_FORMAT_TYPE selfParam, QUALITY_REPORT_FORMAT_TYPE outParam)
        {
            return selfParam == QUALITY_REPORT_FORMAT_TYPE.QUALITY_REPORT_JSON;
        }

        public static bool compareMEDIA_DEVICE_STATE_TYPE(MEDIA_DEVICE_STATE_TYPE selfParam, MEDIA_DEVICE_STATE_TYPE outParam)
        {
            return selfParam == MEDIA_DEVICE_STATE_TYPE.MEDIA_DEVICE_STATE_IDLE;
        }

        public static bool compareVIDEO_PROFILE_TYPE(VIDEO_PROFILE_TYPE selfParam, VIDEO_PROFILE_TYPE outParam)
        {
            return selfParam == VIDEO_PROFILE_TYPE.VIDEO_PROFILE_LANDSCAPE_120P;
        }

        public static bool compareFloatArray(float[] selfParam, float[] outParam)
        {
            int selfLength = selfParam.Length;
            int outLength = outParam.Length;

            if (selfLength != 10 /*outLength*/)
                return false;

            for (int i = 0; i < selfLength; i++)
            {
                if (selfParam[i] != 10/*outParam[i]*/)
                {
                    return false;
                }

            }

            return true;
        }

        public static bool compareRemoteVoicePositionInfo(RemoteVoicePositionInfo selfParam, RemoteVoicePositionInfo outParam)
        {
            if (compareFloatArray(selfParam.position, outParam.position) == false)
                return false;
            if (compareFloatArray(selfParam.forward, outParam.forward) == false)
                return false;
            return true;
        }

        public static bool compareIntPtr(IntPtr selfParam, IntPtr outParam)
        {
            if (selfParam != (IntPtr)10)
                return false;

            return true;
        }

        public static bool compareUserAudioSpectrumInfoArray(UserAudioSpectrumInfo[] selfParam, UserAudioSpectrumInfo[] outParam)
        {
            if (selfParam.Length != 10)
                return false;

            for (var i = 0; i < selfParam.Length; i++)
            {
                if (compareUserAudioSpectrumInfo(selfParam[i], outParam[i]) == false)
                    return false;
            }

            return true;
        }


        public static bool compareByteArray(byte[] selfParam, byte[] outParam)
        {
            if (selfParam.Length != 10)
                return false;

            for (var i = 0; i < selfParam.Length; i++)
            {
                if (compareByte(selfParam[i], outParam[i]) == false)
                    return false;
            }

            return true;
        }

        public static bool compareByte(byte selfParam, byte outParam)
        {
            if (selfParam != 10)
                return false;

            return true;
        }

        public static bool comparePlayerUpdatedInfo(PlayerUpdatedInfo selfParam, PlayerUpdatedInfo outParam)
        {
            if (selfParam.playerId.HasValue() == false || selfParam.playerId.GetValue() != "10")
                return false;


            if (selfParam.deviceId.HasValue() == false || selfParam.deviceId.GetValue() != "10")
                return false;

            if (selfParam.cacheStatistics.HasValue() == false ||
                compareCacheStatistics(selfParam.cacheStatistics.GetValue(), outParam.cacheStatistics.GetValue()) == false)
                return false;


            return true;
        }

        public static bool compareMusicContentCenterStatusCode(MusicContentCenterStatusCode selfParam, MusicContentCenterStatusCode outParam)
        {
            return selfParam == MusicContentCenterStatusCode.kMusicContentCenterStatusOk;
        }


        public static bool compareMusicChartInfoArray(MusicChartInfo[] selfParam, MusicChartInfo[] outParam)
        {
            if (selfParam.Length != 10)
                return false;

            for (var i = 0; i < selfParam.Length; i++)
            {
                if (compareMusicChartInfo(selfParam[i], outParam[i]) == false)
                    return false;
            }

            return true;
        }


        public static bool compareMusicChartInfo(MusicChartInfo selfParam, MusicChartInfo outParam)
        {
            if (compareString(selfParam.chartName, outParam.chartName) == false)
                return false;

            if (compareInt(selfParam.id, outParam.id) == false)
                return false;

            return true;
        }


        public static bool compareSpatialAudioZone(SpatialAudioZone selfParam, SpatialAudioZone outParam)
        {
            if (compareInt(selfParam.zoneSetId, outParam.zoneSetId) == false)
                return false;
            if (compareFloatArray(selfParam.position, outParam.position) == false)
                return false;
            if (compareFloatArray(selfParam.forward, outParam.forward) == false)
                return false;
            if (compareFloatArray(selfParam.right, outParam.right) == false)
                return false;
            if (compareFloatArray(selfParam.up, outParam.up) == false)
                return false;
            if (compareFloat(selfParam.forwardLength, outParam.forwardLength) == false)
                return false;
            if (compareFloat(selfParam.rightLength, outParam.rightLength) == false)
                return false;
            if (compareFloat(selfParam.upLength, outParam.upLength) == false)
                return false;
            if (compareFloat(selfParam.audioAttenuation, outParam.audioAttenuation) == false)
                return false;
            return true;
        }
        #endregion

    }



}
