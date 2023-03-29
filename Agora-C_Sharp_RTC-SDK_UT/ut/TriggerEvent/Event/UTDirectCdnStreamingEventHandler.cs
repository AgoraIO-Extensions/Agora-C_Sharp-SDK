﻿using System;
using Agora.Rtc;

namespace Agora.Rtc
{
    public class UTDirectCdnStreamingEventHandler : IRtcEngineEventHandler
    {


        public bool OnDirectCdnStreamingStateChanged_be_trigger = false;
        public DIRECT_CDN_STREAMING_STATE OnDirectCdnStreamingStateChanged_state;
        public DIRECT_CDN_STREAMING_ERROR OnDirectCdnStreamingStateChanged_error;
        public string OnDirectCdnStreamingStateChanged_message = null;

        public override void OnDirectCdnStreamingStateChanged(DIRECT_CDN_STREAMING_STATE state, DIRECT_CDN_STREAMING_ERROR error, string message)
        {
            OnDirectCdnStreamingStateChanged_be_trigger = true;
            OnDirectCdnStreamingStateChanged_state = state;
            OnDirectCdnStreamingStateChanged_error = error;
            OnDirectCdnStreamingStateChanged_message = message;
        }

        public bool OnDirectCdnStreamingStateChangedPassed(DIRECT_CDN_STREAMING_STATE state, DIRECT_CDN_STREAMING_ERROR error, string message)
        {
            if (OnDirectCdnStreamingStateChanged_be_trigger == false)
                return false;

            if (ParamsHelper.compareDIRECT_CDN_STREAMING_STATE(OnDirectCdnStreamingStateChanged_state, state) == false)
                return false;
            if (ParamsHelper.compareDIRECT_CDN_STREAMING_ERROR(OnDirectCdnStreamingStateChanged_error, error) == false)
                return false;
            if (ParamsHelper.compareString(OnDirectCdnStreamingStateChanged_message, message) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

        public bool OnDirectCdnStreamingStats_be_trigger = false;
        public DirectCdnStreamingStats OnDirectCdnStreamingStats_stats = null;

        public override void OnDirectCdnStreamingStats(DirectCdnStreamingStats stats)
        {
            OnDirectCdnStreamingStats_be_trigger = true;
            OnDirectCdnStreamingStats_stats = stats;
        }

        public bool OnDirectCdnStreamingStatsPassed(DirectCdnStreamingStats stats)
        {
            if (OnDirectCdnStreamingStats_be_trigger == false)
                return false;

            if (ParamsHelper.compareDirectCdnStreamingStats(OnDirectCdnStreamingStats_stats, stats) == false)
                return false;

            return true;
        }

        ///////////////////////////////////

    }
}