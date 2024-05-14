using System;
using Agora.Rtc;
namespace Agora.Rtc.Ut
{
    public class UTMediaRecorderObserver : IMediaRecorderObserver
    {
        #region terra IMediaRecorderObserver
        public bool OnRecorderStateChanged_be_trigger = false;
        public string OnRecorderStateChanged_channelId;
        public uint OnRecorderStateChanged_uid;
        public RecorderState OnRecorderStateChanged_state;
        public RecorderReasonCode OnRecorderStateChanged_reason;

        public override void OnRecorderStateChanged(string channelId, uint uid, RecorderState state, RecorderReasonCode reason)
        {
            OnRecorderStateChanged_be_trigger = true;
            OnRecorderStateChanged_channelId = channelId;
            OnRecorderStateChanged_uid = uid;
            OnRecorderStateChanged_state = state;
            OnRecorderStateChanged_reason = reason;

        }

        public bool OnRecorderStateChangedPassed(string channelId, uint uid, RecorderState state, RecorderReasonCode reason)
        {

            if (OnRecorderStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<string>(OnRecorderStateChanged_channelId, channelId) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnRecorderStateChanged_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<RecorderState>(OnRecorderStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.Compare<RecorderReasonCode>(OnRecorderStateChanged_reason, reason) == false)
                return false;

            return true;
        }

        /////////////////////////////////

        public bool OnRecorderInfoUpdated_be_trigger = false;
        public string OnRecorderInfoUpdated_channelId;
        public uint OnRecorderInfoUpdated_uid;
        public RecorderInfo OnRecorderInfoUpdated_info;

        public override void OnRecorderInfoUpdated(string channelId, uint uid, RecorderInfo info)
        {
            OnRecorderInfoUpdated_be_trigger = true;
            OnRecorderInfoUpdated_channelId = channelId;
            OnRecorderInfoUpdated_uid = uid;
            OnRecorderInfoUpdated_info = info;

        }

        public bool OnRecorderInfoUpdatedPassed(string channelId, uint uid, RecorderInfo info)
        {

            if (OnRecorderInfoUpdated_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<string>(OnRecorderInfoUpdated_channelId, channelId) == false)
                return false;
            if (ParamsHelper.Compare<uint>(OnRecorderInfoUpdated_uid, uid) == false)
                return false;
            if (ParamsHelper.Compare<RecorderInfo>(OnRecorderInfoUpdated_info, info) == false)
                return false;

            return true;
        }

        /////////////////////////////////
        #endregion terra IMediaRecorderObserver
    }
}
