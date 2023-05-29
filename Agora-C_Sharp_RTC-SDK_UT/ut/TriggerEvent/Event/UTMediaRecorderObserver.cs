using System;
using Agora.Rtc;
namespace Agora.Rtc
{
    public class UTMediaRecorderObserver : IMediaRecorderObserver
    {


        public bool OnRecorderStateChanged_be_trigger = false;
        public string OnRecorderStateChanged_channelId = null;
        public uint OnRecorderStateChanged_uid = 0;
        public RecorderState OnRecorderStateChanged_state;
        public RecorderErrorCode OnRecorderStateChanged_error;

        public override void OnRecorderStateChanged(string channelId, uint uid, RecorderState state, RecorderErrorCode error)
        {
            OnRecorderStateChanged_be_trigger = true;
            OnRecorderStateChanged_channelId = channelId;
            OnRecorderStateChanged_uid = uid;
            OnRecorderStateChanged_state = state;
            OnRecorderStateChanged_error = error;
        }

        public bool OnRecorderStateChangedPassed(string channelId, uint uid, RecorderState state, RecorderErrorCode error)
        {
            if (OnRecorderStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareString(OnRecorderStateChanged_channelId, channelId) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnRecorderStateChanged_uid, uid) == false)
                return false;
            if (ParamsHelper.compareRecorderState(OnRecorderStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.compareRecorderErrorCode(OnRecorderStateChanged_error, error) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


        public bool OnRecorderInfoUpdated_be_trigger = false;
        public string OnRecorderInfoUpdated_channelId = null;
        public uint OnRecorderInfoUpdated_uid = 0;
        public RecorderInfo OnRecorderInfoUpdated_info = null;

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

            if (ParamsHelper.compareString(OnRecorderInfoUpdated_channelId, channelId) == false)
                return false;
            if (ParamsHelper.compareUid_t(OnRecorderInfoUpdated_uid, uid) == false)
                return false;
            if (ParamsHelper.compareRecorderInfo(OnRecorderInfoUpdated_info, info) == false)
                return false;

            return true;
        }

        ///////////////////////////////////


    }
}
