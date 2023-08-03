using System;
using Agora.Rtc;
namespace Agora.Rtc
{
    public class UTAudioFrameObserver : IAudioFrameObserver
    {

        public bool OnRecordAudioFrame_be_trigger = false;
        public string OnRecordAudioFrame_channelId = null;
        public AudioFrame OnRecordAudioFrame_audioFrame = null;

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

            if (ParamsHelper.compareString(OnRecordAudioFrame_channelId, channelId) == false)
                return false;
            if (ParamsHelper.compareAudioFrame(OnRecordAudioFrame_audioFrame, audioFrame) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnPlaybackAudioFrame_be_trigger = false;
        public string OnPlaybackAudioFrame_channelId = null;
        public AudioFrame OnPlaybackAudioFrame_audioFrame = null;

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

            if (ParamsHelper.compareString(OnPlaybackAudioFrame_channelId, channelId) == false)
                return false;
            if (ParamsHelper.compareAudioFrame(OnPlaybackAudioFrame_audioFrame, audioFrame) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnMixedAudioFrame_be_trigger = false;
        public string OnMixedAudioFrame_channelId = null;
        public AudioFrame OnMixedAudioFrame_audioFrame = null;

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

            if (ParamsHelper.compareString(OnMixedAudioFrame_channelId, channelId) == false)
                return false;
            if (ParamsHelper.compareAudioFrame(OnMixedAudioFrame_audioFrame, audioFrame) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnEarMonitoringAudioFrame_be_trigger = false;
        public AudioFrame OnEarMonitoringAudioFrame_audioFrame = null;

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

            if (ParamsHelper.compareAudioFrame(OnEarMonitoringAudioFrame_audioFrame, audioFrame) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnPlaybackAudioFrameBeforeMixing_be_trigger2 = false;
        public string OnPlaybackAudioFrameBeforeMixing_channelId2 = null;
        public string OnPlaybackAudioFrameBeforeMixing_userId2 = null;
        public AudioFrame OnPlaybackAudioFrameBeforeMixing_audioFrame2 = null;

        public override bool OnPlaybackAudioFrameBeforeMixing(string channelId, string userId, AudioFrame audioFrame)
        {
            OnPlaybackAudioFrameBeforeMixing_be_trigger2 = true;
            OnPlaybackAudioFrameBeforeMixing_channelId2 = channelId;
            OnPlaybackAudioFrameBeforeMixing_userId2 = userId;
            OnPlaybackAudioFrameBeforeMixing_audioFrame2 = audioFrame;
            return true;
        }

        public bool OnPlaybackAudioFrameBeforeMixingPassed2(string channelId, string userId, AudioFrame audioFrame)
        {
            if (OnPlaybackAudioFrameBeforeMixing_be_trigger2 == false)
                return false;

            if (ParamsHelper.compareString(OnPlaybackAudioFrameBeforeMixing_channelId2, channelId) == false)
                return false;
            if (ParamsHelper.compareString(OnPlaybackAudioFrameBeforeMixing_userId2, userId) == false)
                return false;
            if (ParamsHelper.compareAudioFrame(OnPlaybackAudioFrameBeforeMixing_audioFrame2, audioFrame) == false)
                return false;

            return true;
        }

        ///////////////////////////////////,
        public bool OnPlaybackAudioFrameBeforeMixing_be_trigger = false;
        public string OnPlaybackAudioFrameBeforeMixing_channelId = null;
        public uint OnPlaybackAudioFrameBeforeMixing_uid = 0;
        public AudioFrame OnPlaybackAudioFrameBeforeMixing_audioFrame = null;

        public override bool OnPlaybackAudioFrameBeforeMixing(string channelId, uint uid, AudioFrame audioFrame)
        {
            OnPlaybackAudioFrameBeforeMixing_be_trigger = true;
            OnPlaybackAudioFrameBeforeMixing_channelId = channelId;
            OnPlaybackAudioFrameBeforeMixing_uid = uid;
            OnPlaybackAudioFrameBeforeMixing_audioFrame = audioFrame;
            return true;
        }

        public bool OnPlaybackAudioFrameBeforeMixingPassed(string channelId, uint uid, AudioFrame audioFrame)
        {
            if (OnPlaybackAudioFrameBeforeMixing_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnPlaybackAudioFrameBeforeMixing_channelId, channelId) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnPlaybackAudioFrameBeforeMixing_uid, uid) == false)
                return false;
            if (ParamsHelper.compareAudioFrame(OnPlaybackAudioFrameBeforeMixing_audioFrame, audioFrame) == false)
                return false;

            return true;
        }

        ///////////////////////////////////




    }
}
