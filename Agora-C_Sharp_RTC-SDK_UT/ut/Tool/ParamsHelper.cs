using System;
using Agora.Rtc;
namespace ut
{
    public class ParamsHelper
    {

        #region init
        public static void InitParam(out string param)
        {
            param = "xiayangqun";
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
            LogConfig logConfig = null;

            param = new RtcEngineContext(appId, context, channelProfile, license, audioScenario, areaCode, logConfig);
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
            param.rtmToken = "dsadadasdasd";
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

        #endregion

    }



}
