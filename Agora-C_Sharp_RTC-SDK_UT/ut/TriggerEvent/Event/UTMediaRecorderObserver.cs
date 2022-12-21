using System;
using Agora.Rtc;
namespace Agora.Rtc
{
    public class UTMediaRecorderObserver : IMediaRecorderObserver
    {


        public bool OnRecorderStateChanged_be_trigger = false;
        public RecorderState OnRecorderStateChanged_state;
        public RecorderErrorCode OnRecorderStateChanged_error;

        public override void OnRecorderStateChanged(RecorderState state, RecorderErrorCode error)
        {
            OnRecorderStateChanged_be_trigger = true;
            OnRecorderStateChanged_state = state;
            OnRecorderStateChanged_error = error;
        }

        public bool OnRecorderStateChangedPassed(RecorderState state, RecorderErrorCode error)
        {
            if (OnRecorderStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareRecorderState(OnRecorderStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.compareRecorderErrorCode(OnRecorderStateChanged_error, error) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnRecorderInfoUpdated_be_trigger = false;
        public RecorderInfo OnRecorderInfoUpdated_info = null;

        public override void OnRecorderInfoUpdated(RecorderInfo info)
        {
            OnRecorderInfoUpdated_be_trigger = true;
            OnRecorderInfoUpdated_info = info;
        }

        public bool OnRecorderInfoUpdatedPassed(RecorderInfo info)
        {
            if (OnRecorderInfoUpdated_be_trigger == false)
                return false;

            if (ParamsHelper.compareRecorderInfo(OnRecorderInfoUpdated_info, info) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

    }
}
