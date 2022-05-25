/// <summary>
/// [Voice Changer]Key Step：
/// 1. Create Engine and Initialize：（CreateAgoraRtcEngine、Initialize、[SetLogFile]、[InitEventHandler]）
/// 
/// 2. Join Channel：（[EnableAudio]、SetVoiceBeautifierPreset  SetAudioEffectPreset 、JoinChannel）
/// 
/// 3. SetVoiceBeautifierParameters、SetAudioEffectParameters
/// 
/// 4. Leave Channel：（StopVoiceChanger、LeaveChannel）
/// 
/// 5. Exit：（Dispose）
/// <summary>
using System;
using agora.rtc;

namespace CSharp_API_Example
{
    public class VoiceChanger : IEngine
    {
        private string app_id_ = "";
        private string channel_id_ = "";
        private string filePath = "";
        private readonly string VoiceChanger_TAG = "[VoiceChanger] ";
        private readonly string agora_sdk_log_file_path_ = "agorasdk.log";
        private IAgoraRtcEngine rtc_engine_ = null;
        private IAgoraRtcEngineEventHandler event_handler_ = null;
        bool voiceChanger = true;
        private VOICE_BEAUTIFIER_PRESET[] voice_beautifier_preset = {
            VOICE_BEAUTIFIER_PRESET.VOICE_BEAUTIFIER_OFF,
            VOICE_BEAUTIFIER_PRESET.CHAT_BEAUTIFIER_MAGNETIC,
            VOICE_BEAUTIFIER_PRESET.CHAT_BEAUTIFIER_FRESH,
            VOICE_BEAUTIFIER_PRESET.CHAT_BEAUTIFIER_VITALITY,
            VOICE_BEAUTIFIER_PRESET.SINGING_BEAUTIFIER,
            VOICE_BEAUTIFIER_PRESET.TIMBRE_TRANSFORMATION_VIGOROUS,
            VOICE_BEAUTIFIER_PRESET.TIMBRE_TRANSFORMATION_DEEP,
            VOICE_BEAUTIFIER_PRESET.TIMBRE_TRANSFORMATION_MELLOW,
            VOICE_BEAUTIFIER_PRESET.TIMBRE_TRANSFORMATION_FALSETTO,
            VOICE_BEAUTIFIER_PRESET.TIMBRE_TRANSFORMATION_FULL,
            VOICE_BEAUTIFIER_PRESET.TIMBRE_TRANSFORMATION_CLEAR,
            VOICE_BEAUTIFIER_PRESET.TIMBRE_TRANSFORMATION_RESOUNDING,
            VOICE_BEAUTIFIER_PRESET.TIMBRE_TRANSFORMATION_RINGING
        };
        private AUDIO_EFFECT_PRESET[] audio_effect_preset = {
            AUDIO_EFFECT_PRESET.AUDIO_EFFECT_OFF,
            AUDIO_EFFECT_PRESET.ROOM_ACOUSTICS_KTV,
            AUDIO_EFFECT_PRESET.ROOM_ACOUSTICS_VOCAL_CONCERT,
            AUDIO_EFFECT_PRESET.ROOM_ACOUSTICS_STUDIO ,
            AUDIO_EFFECT_PRESET.ROOM_ACOUSTICS_PHONOGRAPH ,
            AUDIO_EFFECT_PRESET.ROOM_ACOUSTICS_VIRTUAL_STEREO,
            AUDIO_EFFECT_PRESET.ROOM_ACOUSTICS_SPACIAL,
            AUDIO_EFFECT_PRESET.ROOM_ACOUSTICS_ETHEREAL ,
            AUDIO_EFFECT_PRESET. ROOM_ACOUSTICS_3D_VOICE,
            AUDIO_EFFECT_PRESET.VOICE_CHANGER_EFFECT_UNCLE ,
            AUDIO_EFFECT_PRESET.VOICE_CHANGER_EFFECT_OLDMAN ,
            AUDIO_EFFECT_PRESET.VOICE_CHANGER_EFFECT_BOY ,
            AUDIO_EFFECT_PRESET.VOICE_CHANGER_EFFECT_SISTER,
            AUDIO_EFFECT_PRESET.VOICE_CHANGER_EFFECT_GIRL,
            AUDIO_EFFECT_PRESET.VOICE_CHANGER_EFFECT_PIGKING,
            AUDIO_EFFECT_PRESET.VOICE_CHANGER_EFFECT_HULK,
            AUDIO_EFFECT_PRESET.STYLE_TRANSFORMATION_RNB ,
            AUDIO_EFFECT_PRESET.STYLE_TRANSFORMATION_POPULAR,
            AUDIO_EFFECT_PRESET.PITCH_CORRECTION
        };
        int vbp_index = 0;
        int voiceBeautyParam1 = 1;
        int voiceBeautyParam2 = 1;

        int aep_index = 0;
        int audioEffectParam1 = 1;
        int audioEffectParam2 = 1;
        internal override int Init(string appId, string channelId)
        {
            filePath = System.Windows.Forms.Application.StartupPath + "./audioEffect.mp3";
            int ret = -1;

            app_id_ = appId;
            channel_id_ = channelId.Split(';').GetValue(0).ToString();

            if (null == rtc_engine_)
            {
                rtc_engine_ = AgoraRtcEngine.CreateAgoraRtcEngine();
            }

            LogConfig log_config = new LogConfig(agora_sdk_log_file_path_);
            RtcEngineContext rtc_engine_ctx = new RtcEngineContext(app_id_, AREA_CODE.AREA_CODE_GLOB, log_config);
            ret = rtc_engine_.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler_(VoiceChanger_TAG + "Initialize", ret);

            event_handler_ = new VoiceChangerEventHandler();
            rtc_engine_.InitEventHandler(event_handler_);
            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(VoiceChanger_TAG + "LeaveChannel", ret);

                rtc_engine_.Dispose();
                rtc_engine_ = null;
            }
            return ret;
        }

        internal override int JoinChannel()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.EnableAudio();
                CSharpForm.dump_handler_(VoiceChanger_TAG + "EnableAudio", ret);
                ret = rtc_engine_.SetAudioProfile(
              AUDIO_PROFILE_TYPE.AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO
              , AUDIO_SCENARIO_TYPE.AUDIO_SCENARIO_GAME_STREAMING);

                CSharpForm.dump_handler_(VoiceChanger_TAG + "SetAudioProfile", ret);

                if (voiceChanger)
                {
                    ret = rtc_engine_.SetVoiceBeautifierPreset(voice_beautifier_preset[vbp_index]);
                    CSharpForm.dump_handler_(VoiceChanger_TAG + "SetVoiceBeautifierPreset", ret);
                }
              
                else
                {
                    ret = rtc_engine_.SetAudioEffectPreset(audio_effect_preset[vbp_index]);
                    CSharpForm.dump_handler_(VoiceChanger_TAG + "SetAudioEffectPreset", ret);
                }

                ret = rtc_engine_.JoinChannel("", channel_id_, "info");
                CSharpForm.dump_handler_(VoiceChanger_TAG + "JoinChannel", ret);
            }
            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(VoiceChanger_TAG + "LeaveChannel", ret);
            }
            return ret;
        }
        internal override string GetSDKVersion()
        {
            if (null == rtc_engine_)
                return "-" + (ERROR_CODE_TYPE.ERR_NOT_INITIALIZED).ToString(); 

            return rtc_engine_.GetVersion();
        }

        internal override IAgoraRtcEngine GetEngine()
        {
            return rtc_engine_;
        }

        public override int SetVoiceBeautifierPreset(int index)
        {
            voiceChanger = true;
            vbp_index = index;
            if (null == rtc_engine_)
                return 0;
            int ret = rtc_engine_.SetVoiceBeautifierPreset(voice_beautifier_preset[index]);
            CSharpForm.dump_handler_(VoiceChanger_TAG + "SetVoiceBeautifierPreset", ret);
            return ret;
        }

        public override int SetVoiceBeautifierParameters(int index, int param1, int param2)
        {
            vbp_index = index;
            voiceBeautyParam1 = param1;
            voiceBeautyParam2 = param2;
            if (null == rtc_engine_)
                return 0;
           
            int ret = rtc_engine_.SetVoiceBeautifierParameters(voice_beautifier_preset[index], param1, param2);
            CSharpForm.dump_handler_(VoiceChanger_TAG + "SetVoiceBeautifierParameters", ret);
            return ret;
        }

        public override int SetAudioEffectPreset(int index)
        {
            voiceChanger = false;
            vbp_index = index;
            if (null == rtc_engine_)
                return 0;
            int ret = rtc_engine_.SetAudioEffectPreset(audio_effect_preset[index]);
            CSharpForm.dump_handler_(VoiceChanger_TAG + "SetAudioEffectPreset", ret);
            return ret;
        }

        public override int SetAudioEffectParameters(int index, int param1, int param2)
        {
            aep_index = index;
            audioEffectParam1 = param1;
            audioEffectParam2 = param2;
            if (null == rtc_engine_)
                return 0;

            int ret = rtc_engine_.SetAudioEffectParameters(audio_effect_preset[index], param1, param2);
            CSharpForm.dump_handler_(VoiceChanger_TAG + "SetAudioEffectParameters", ret);
            return ret;
        }
    }

    // override if need
    internal class VoiceChangerEventHandler : IAgoraRtcEngineEventHandler
    {
        public override void OnWarning(int warn, string msg)
        {
            Console.WriteLine("=====>OnWarning {0} {1}", warn, msg);
        }

        public override void OnError(int error, string msg)
        {
            Console.WriteLine("=====>OnError {0} {1}", error, msg);
        }

        public override void OnJoinChannelSuccess(string channel, uint uid, int elapsed)
        {
            Console.WriteLine("----->OnJoinChannelSuccess channel={0} uid={1}", channel, uid);
        }

        public override void OnRejoinChannelSuccess(string channel, uint uid, int elapsed)
        {
            Console.WriteLine("----->OnRejoinChannelSuccess");
        }

        public override void OnLeaveChannel(RtcStats stats)
        {
            Console.WriteLine("----->OnLeaveChannel duration={0}", stats.duration);
        }

        public override void OnUserJoined(uint uid, int elapsed)
        {
            Console.WriteLine("----->OnUserJoined uid={0} elapsed={1}", uid, elapsed);
        }

        public override void OnUserOffline(uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline reason={0}", reason);
        }
    }
}
