using System;
using Agora.Rtc;

namespace Agora.Rtc
{
    public class UTDirectCdnStreamingEventHandler : IRtcEngineEventHandler
    {

        #region terra IDirectCdnStreamingEventHandler
        public bool OnDirectCdnStreamingStateChanged_be_trigger = false;
        public DIRECT_CDN_STREAMING_STATE OnDirectCdnStreamingStateChanged_state;
        public DIRECT_CDN_STREAMING_REASON OnDirectCdnStreamingStateChanged_reason;
        public string OnDirectCdnStreamingStateChanged_message;

        public override void OnDirectCdnStreamingStateChanged(DIRECT_CDN_STREAMING_STATE state, DIRECT_CDN_STREAMING_REASON reason, string message)
        {
            OnDirectCdnStreamingStateChanged_be_trigger = true;
            OnDirectCdnStreamingStateChanged_state = state;
            OnDirectCdnStreamingStateChanged_reason = reason;
            OnDirectCdnStreamingStateChanged_message = message;

        }

        public bool OnDirectCdnStreamingStateChangedPassed(DIRECT_CDN_STREAMING_STATE state, DIRECT_CDN_STREAMING_REASON reason, string message)
        {

            if (OnDirectCdnStreamingStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<DIRECT_CDN_STREAMING_STATE>(OnDirectCdnStreamingStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.Compare<DIRECT_CDN_STREAMING_REASON>(OnDirectCdnStreamingStateChanged_reason, reason) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnDirectCdnStreamingStateChanged_message, message) == false)
                return false;

            return true;
        }

        /////////////////////////////////

        public bool OnDirectCdnStreamingStats_be_trigger = false;
        public DirectCdnStreamingStats OnDirectCdnStreamingStats_stats;

        public override void OnDirectCdnStreamingStats(DirectCdnStreamingStats stats)
        {
            OnDirectCdnStreamingStats_be_trigger = true;
            OnDirectCdnStreamingStats_stats = stats;

        }

        public bool OnDirectCdnStreamingStatsPassed(DirectCdnStreamingStats stats)
        {

            if (OnDirectCdnStreamingStats_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<DirectCdnStreamingStats>(OnDirectCdnStreamingStats_stats, stats) == false)
                return false;

            return true;
        }

        /////////////////////////////////
        #endregion terra IDirectCdnStreamingEventHandler
    }
}
