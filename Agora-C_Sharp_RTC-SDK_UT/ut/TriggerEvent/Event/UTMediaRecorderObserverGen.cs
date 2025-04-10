#region Generated by `terra/node/src/rtc/ut/renderers.ts`. DO NOT MODIFY BY HAND.
#endregion

using System;
using Agora.Rtc;
namespace Agora.Rtc.Ut
{
    public partial class UTMediaRecorderObserver : IMediaRecorderObserver
    {
        public bool OnRecorderStateChanged_c38849f_be_trigger = false;
        public string OnRecorderStateChanged_c38849f_channelId;
        public uint OnRecorderStateChanged_c38849f_uid;
        public RecorderState OnRecorderStateChanged_c38849f_state;
        public RecorderReasonCode OnRecorderStateChanged_c38849f_reason;

        public override void OnRecorderStateChanged(string channelId, uint uid, RecorderState state, RecorderReasonCode reason)
        {
            OnRecorderStateChanged_c38849f_be_trigger = true;
            OnRecorderStateChanged_c38849f_channelId = channelId;
            OnRecorderStateChanged_c38849f_uid = uid;
            OnRecorderStateChanged_c38849f_state = state;
            OnRecorderStateChanged_c38849f_reason = reason;
        }

        public bool OnRecorderStateChangedPassed(string channelId, uint uid, RecorderState state, RecorderReasonCode reason)
        {
            if (OnRecorderStateChanged_c38849f_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<string>(OnRecorderStateChanged_c38849f_channelId, channelId) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnRecorderStateChanged_c38849f_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<RecorderState>(OnRecorderStateChanged_c38849f_state, state) == false)
                return false;
            if (ParamsHelper.Compare<RecorderReasonCode>(OnRecorderStateChanged_c38849f_reason, reason) == false)
                return false;

            return true;
        }

        /////////////////////////////////

        public bool OnRecorderInfoUpdated_64fa74a_be_trigger = false;
        public string OnRecorderInfoUpdated_64fa74a_channelId;
        public uint OnRecorderInfoUpdated_64fa74a_uid;
        public RecorderInfo OnRecorderInfoUpdated_64fa74a_info;

        public override void OnRecorderInfoUpdated(string channelId, uint uid, RecorderInfo info)
        {
            OnRecorderInfoUpdated_64fa74a_be_trigger = true;
            OnRecorderInfoUpdated_64fa74a_channelId = channelId;
            OnRecorderInfoUpdated_64fa74a_uid = uid;
            OnRecorderInfoUpdated_64fa74a_info = info;
        }

        public bool OnRecorderInfoUpdatedPassed(string channelId, uint uid, RecorderInfo info)
        {
            if (OnRecorderInfoUpdated_64fa74a_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<string>(OnRecorderInfoUpdated_64fa74a_channelId, channelId) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnRecorderInfoUpdated_64fa74a_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<RecorderInfo>(OnRecorderInfoUpdated_64fa74a_info, info) == false)
                return false;

            return true;
        }

        /////////////////////////////////

    }
}