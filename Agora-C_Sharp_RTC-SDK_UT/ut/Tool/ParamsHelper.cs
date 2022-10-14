using System;
using Agora.Rtc;
namespace ut
{
    public class ParamsHelper
    {

        public static void InitParam(out string param)
        {
            param = "xiayangqun";
        }


        public static void InitParam(out uint param)
        {
            param = 10086;
        }

        public static void InitParam(out int param)
        {
            param = 10086;
        }

        public static void InitParam(out float param)
        {
            param = 10.233f;
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

    }



}
