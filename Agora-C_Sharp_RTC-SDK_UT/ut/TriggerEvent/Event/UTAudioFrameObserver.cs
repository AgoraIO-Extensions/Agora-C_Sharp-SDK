using System;
using Agora.Rtc;
namespace Agora.Rtc
{
    public class UTAudioFrameObserver : IAudioFrameObserver
    {

        #region terra IAudioFrameObserver
        public bool OnRecordAudioFrame_be_trigger = false;
        public string OnRecordAudioFrame_channelId;
        public AudioFrame OnRecordAudioFrame_audioFrame;

        public override bool OnRecordAudioFrame(string channelId, AudioFrame audioFrame)
        {
            OnRecordAudioFrame_be_trigger = true;
            OnRecordAudioFrame_channelId = channelId;
            OnRecordAudioFrame_audioFrame = audioFrame;
            return true;

        }

        public bool OnRecordAudioFramePassed(string channelId, AudioFrame audioFrame)
        {

            if (OnRecordAudioFrame_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<string>(OnRecordAudioFrame_channelId, channelId) == false)
            //return false;
            // if (ParamsHelper.Compare<AudioFrame>(OnRecordAudioFrame_audioFrame, audioFrame) == false)
            //return false;

            return true;
        }

        /////////////////////////////////

        public bool OnPlaybackAudioFrame_be_trigger = false;
        public string OnPlaybackAudioFrame_channelId;
        public AudioFrame OnPlaybackAudioFrame_audioFrame;

        public override bool OnPlaybackAudioFrame(string channelId, AudioFrame audioFrame)
        {
            OnPlaybackAudioFrame_be_trigger = true;
            OnPlaybackAudioFrame_channelId = channelId;
            OnPlaybackAudioFrame_audioFrame = audioFrame;
            return true;

        }

        public bool OnPlaybackAudioFramePassed(string channelId, AudioFrame audioFrame)
        {

            if (OnPlaybackAudioFrame_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<string>(OnPlaybackAudioFrame_channelId, channelId) == false)
            //return false;
            // if (ParamsHelper.Compare<AudioFrame>(OnPlaybackAudioFrame_audioFrame, audioFrame) == false)
            //return false;

            return true;
        }

        /////////////////////////////////

        public bool OnMixedAudioFrame_be_trigger = false;
        public string OnMixedAudioFrame_channelId;
        public AudioFrame OnMixedAudioFrame_audioFrame;

        public override bool OnMixedAudioFrame(string channelId, AudioFrame audioFrame)
        {
            OnMixedAudioFrame_be_trigger = true;
            OnMixedAudioFrame_channelId = channelId;
            OnMixedAudioFrame_audioFrame = audioFrame;
            return true;

        }

        public bool OnMixedAudioFramePassed(string channelId, AudioFrame audioFrame)
        {

            if (OnMixedAudioFrame_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<string>(OnMixedAudioFrame_channelId, channelId) == false)
            //return false;
            // if (ParamsHelper.Compare<AudioFrame>(OnMixedAudioFrame_audioFrame, audioFrame) == false)
            //return false;

            return true;
        }

        /////////////////////////////////

        public bool OnEarMonitoringAudioFrame_be_trigger = false;
        public AudioFrame OnEarMonitoringAudioFrame_audioFrame;

        public override bool OnEarMonitoringAudioFrame(AudioFrame audioFrame)
        {
            OnEarMonitoringAudioFrame_be_trigger = true;
            OnEarMonitoringAudioFrame_audioFrame = audioFrame;
            return true;

        }

        public bool OnEarMonitoringAudioFramePassed(AudioFrame audioFrame)
        {

            if (OnEarMonitoringAudioFrame_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<AudioFrame>(OnEarMonitoringAudioFrame_audioFrame, audioFrame) == false)
            //return false;

            return true;
        }

        /////////////////////////////////

        public bool OnPlaybackAudioFrameBeforeMixing_be_trigger = false;
        public string OnPlaybackAudioFrameBeforeMixing_channelId;
        public string OnPlaybackAudioFrameBeforeMixing_userId;
        public AudioFrame OnPlaybackAudioFrameBeforeMixing_audioFrame;

        public override bool OnPlaybackAudioFrameBeforeMixing(string channelId, string userId, AudioFrame audioFrame)
        {
            OnPlaybackAudioFrameBeforeMixing_be_trigger = true;
            OnPlaybackAudioFrameBeforeMixing_channelId = channelId;
            OnPlaybackAudioFrameBeforeMixing_userId = userId;
            OnPlaybackAudioFrameBeforeMixing_audioFrame = audioFrame;
            return true;

        }

        public bool OnPlaybackAudioFrameBeforeMixingPassed(string channelId, string userId, AudioFrame audioFrame)
        {

            if (OnPlaybackAudioFrameBeforeMixing_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<string>(OnPlaybackAudioFrameBeforeMixing_channelId, channelId) == false)
            //return false;
            // if (ParamsHelper.Compare<string>(OnPlaybackAudioFrameBeforeMixing_userId, userId) == false)
            //return false;
            // if (ParamsHelper.Compare<AudioFrame>(OnPlaybackAudioFrameBeforeMixing_audioFrame, audioFrame) == false)
            //return false;

            return true;
        }

        /////////////////////////////////


        public bool OnPlaybackAudioFrameBeforeMixing2_be_trigger = false;
        public string OnPlaybackAudioFrameBeforeMixing2_channelId;
        public uint OnPlaybackAudioFrameBeforeMixing2_uid;
        public AudioFrame OnPlaybackAudioFrameBeforeMixing2_audioFrame;

        public override bool OnPlaybackAudioFrameBeforeMixing(string channelId, uint uid, AudioFrame audioFrame)
        {
            OnPlaybackAudioFrameBeforeMixing2_be_trigger = true;
            OnPlaybackAudioFrameBeforeMixing2_channelId = channelId;
            OnPlaybackAudioFrameBeforeMixing2_uid = uid;
            OnPlaybackAudioFrameBeforeMixing2_audioFrame = audioFrame;
            return true;

        }

        public bool OnPlaybackAudioFrameBeforeMixing2Passed(string channelId, uint uid, AudioFrame audioFrame)
        {

            if (OnPlaybackAudioFrameBeforeMixing2_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<string>(OnPlaybackAudioFrameBeforeMixing2_channelId, channelId) == false)
            //return false;
            // if (ParamsHelper.Compare<uint>(OnPlaybackAudioFrameBeforeMixing2_uid, uid) == false)
            //return false;
            // if (ParamsHelper.Compare<AudioFrame>(OnPlaybackAudioFrameBeforeMixing2_audioFrame, audioFrame) == false)
            //return false;

            return true;
        }

        /////////////////////////////////
        #endregion terra IAudioFrameObserver
    }
}
