using System;
using Agora.Rtc;
namespace Agora.Rtc
{
    public class UTMediaRecorderObserverS : IMediaRecorderObserverS
    {
        #region terra IMediaRecorderObserverS

        public bool OnRecorderStateChanged_be_trigger = false;
        public string OnRecorderStateChanged_channelId;
        public string OnRecorderStateChanged_userId;
        public RecorderState OnRecorderStateChanged_state;
        public RecorderErrorCode OnRecorderStateChanged_error;

        public override void OnRecorderStateChanged(string channelId, string userId, RecorderState state, RecorderErrorCode error)
        {
            OnRecorderStateChanged_be_trigger = true;
            OnRecorderStateChanged_channelId = channelId;
            OnRecorderStateChanged_userId = userId;
            OnRecorderStateChanged_state = state;
            OnRecorderStateChanged_error = error;

        }

        public bool OnRecorderStateChangedPassed(string channelId, string userId, RecorderState state, RecorderErrorCode error)
        {

            if (OnRecorderStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<string>(OnRecorderStateChanged_channelId, channelId) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnRecorderStateChanged_userId, userId) == false)
                return false;
            if (ParamsHelper.Compare<RecorderState>(OnRecorderStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.Compare<RecorderErrorCode>(OnRecorderStateChanged_error, error) == false)
                return false;

            return true;
        }

        /////////////////////////////////

        public bool OnRecorderInfoUpdated_be_trigger = false;
        public string OnRecorderInfoUpdated_channelId;
        public string OnRecorderInfoUpdated_userId;
        public RecorderInfo OnRecorderInfoUpdated_info;

        public override void OnRecorderInfoUpdated(string channelId, string userId, RecorderInfo info)
        {
            OnRecorderInfoUpdated_be_trigger = true;
            OnRecorderInfoUpdated_channelId = channelId;
            OnRecorderInfoUpdated_userId = userId;
            OnRecorderInfoUpdated_info = info;

        }

        public bool OnRecorderInfoUpdatedPassed(string channelId, string userId, RecorderInfo info)
        {

            if (OnRecorderInfoUpdated_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<string>(OnRecorderInfoUpdated_channelId, channelId) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnRecorderInfoUpdated_userId, userId) == false)
                return false;
            if (ParamsHelper.Compare<RecorderInfo>(OnRecorderInfoUpdated_info, info) == false)
                return false;

            return true;
        }

        /////////////////////////////////
        #endregion terra IMediaRecorderObserverS
    }
}
