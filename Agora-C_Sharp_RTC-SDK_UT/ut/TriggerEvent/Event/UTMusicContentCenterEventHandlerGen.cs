#region Generated by `terra/node/src/rtc/ut/renderers.ts`. DO NOT MODIFY BY HAND.
#endregion

using System;
using Agora.Rtc;
namespace Agora.Rtc.Ut
{
    public partial class UTMusicContentCenterEventHandler : IMusicContentCenterEventHandler
    {
        public bool OnMusicChartsResult_fb18135_be_trigger = false;
        public string OnMusicChartsResult_fb18135_requestId;
        public MusicChartInfo[] OnMusicChartsResult_fb18135_result;
        public MusicContentCenterStateReason OnMusicChartsResult_fb18135_reason;

        public override void OnMusicChartsResult(string requestId, MusicChartInfo[] result, MusicContentCenterStateReason reason)
        {
            OnMusicChartsResult_fb18135_be_trigger = true;
            OnMusicChartsResult_fb18135_requestId = requestId;
            OnMusicChartsResult_fb18135_result = result;
            OnMusicChartsResult_fb18135_reason = reason;
        }

        public bool OnMusicChartsResultPassed(string requestId, MusicChartInfo[] result, MusicContentCenterStateReason reason)
        {
            if (OnMusicChartsResult_fb18135_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<string>(OnMusicChartsResult_fb18135_requestId, requestId) == false)
                return false;
            if (ParamsHelper.Compare<MusicChartInfo[]>(OnMusicChartsResult_fb18135_result, result) == false)
                return false;
            if (ParamsHelper.Compare<MusicContentCenterStateReason>(OnMusicChartsResult_fb18135_reason, reason) == false)
                return false;

            return true;
        }

        /////////////////////////////////

        public bool OnMusicCollectionResult_c30c2e6_be_trigger = false;
        public string OnMusicCollectionResult_c30c2e6_requestId;
        public MusicCollection OnMusicCollectionResult_c30c2e6_result;
        public MusicContentCenterStateReason OnMusicCollectionResult_c30c2e6_reason;

        public override void OnMusicCollectionResult(string requestId, MusicCollection result, MusicContentCenterStateReason reason)
        {
            OnMusicCollectionResult_c30c2e6_be_trigger = true;
            OnMusicCollectionResult_c30c2e6_requestId = requestId;
            OnMusicCollectionResult_c30c2e6_result = result;
            OnMusicCollectionResult_c30c2e6_reason = reason;
        }

        public bool OnMusicCollectionResultPassed(string requestId, MusicCollection result, MusicContentCenterStateReason reason)
        {
            if (OnMusicCollectionResult_c30c2e6_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<string>(OnMusicCollectionResult_c30c2e6_requestId, requestId) == false)
                return false;
            if (ParamsHelper.Compare<MusicCollection>(OnMusicCollectionResult_c30c2e6_result, result) == false)
                return false;
            if (ParamsHelper.Compare<MusicContentCenterStateReason>(OnMusicCollectionResult_c30c2e6_reason, reason) == false)
                return false;

            return true;
        }

        /////////////////////////////////

        public bool OnLyricResult_9ad9c90_be_trigger = false;
        public string OnLyricResult_9ad9c90_requestId;
        public long OnLyricResult_9ad9c90_internalSongCode;
        public string OnLyricResult_9ad9c90_payload;
        public MusicContentCenterStateReason OnLyricResult_9ad9c90_reason;

        public override void OnLyricResult(string requestId, long internalSongCode, string payload, MusicContentCenterStateReason reason)
        {
            OnLyricResult_9ad9c90_be_trigger = true;
            OnLyricResult_9ad9c90_requestId = requestId;
            OnLyricResult_9ad9c90_internalSongCode = internalSongCode;
            OnLyricResult_9ad9c90_payload = payload;
            OnLyricResult_9ad9c90_reason = reason;
        }

        public bool OnLyricResultPassed(string requestId, long internalSongCode, string payload, MusicContentCenterStateReason reason)
        {
            if (OnLyricResult_9ad9c90_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<string>(OnLyricResult_9ad9c90_requestId, requestId) == false)
                return false;
            if (ParamsHelper.Compare<long>(OnLyricResult_9ad9c90_internalSongCode, internalSongCode) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnLyricResult_9ad9c90_payload, payload) == false)
                return false;
            if (ParamsHelper.Compare<MusicContentCenterStateReason>(OnLyricResult_9ad9c90_reason, reason) == false)
                return false;

            return true;
        }

        /////////////////////////////////

        public bool OnLyricInfoResult_4725ebf_be_trigger = false;
        public string OnLyricInfoResult_4725ebf_requestId;
        public long OnLyricInfoResult_4725ebf_songCode;
        public ILyricInfo OnLyricInfoResult_4725ebf_lyricInfo;
        public MusicContentCenterStateReason OnLyricInfoResult_4725ebf_reason;

        public override void OnLyricInfoResult(string requestId, long songCode, ILyricInfo lyricInfo, MusicContentCenterStateReason reason)
        {
            OnLyricInfoResult_4725ebf_be_trigger = true;
            OnLyricInfoResult_4725ebf_requestId = requestId;
            OnLyricInfoResult_4725ebf_songCode = songCode;
            OnLyricInfoResult_4725ebf_lyricInfo = lyricInfo;
            OnLyricInfoResult_4725ebf_reason = reason;
        }

        public bool OnLyricInfoResultPassed(string requestId, long songCode, ILyricInfo lyricInfo, MusicContentCenterStateReason reason)
        {
            if (OnLyricInfoResult_4725ebf_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<string>(OnLyricInfoResult_4725ebf_requestId, requestId) == false)
                return false;
            if (ParamsHelper.Compare<long>(OnLyricInfoResult_4725ebf_songCode, songCode) == false)
                return false;
            if (ParamsHelper.Compare<ILyricInfo>(OnLyricInfoResult_4725ebf_lyricInfo, lyricInfo) == false)
                return false;
            if (ParamsHelper.Compare<MusicContentCenterStateReason>(OnLyricInfoResult_4725ebf_reason, reason) == false)
                return false;

            return true;
        }

        /////////////////////////////////

        public bool OnSongSimpleInfoResult_9ad9c90_be_trigger = false;
        public string OnSongSimpleInfoResult_9ad9c90_requestId;
        public long OnSongSimpleInfoResult_9ad9c90_songCode;
        public string OnSongSimpleInfoResult_9ad9c90_simpleInfo;
        public MusicContentCenterStateReason OnSongSimpleInfoResult_9ad9c90_reason;

        public override void OnSongSimpleInfoResult(string requestId, long songCode, string simpleInfo, MusicContentCenterStateReason reason)
        {
            OnSongSimpleInfoResult_9ad9c90_be_trigger = true;
            OnSongSimpleInfoResult_9ad9c90_requestId = requestId;
            OnSongSimpleInfoResult_9ad9c90_songCode = songCode;
            OnSongSimpleInfoResult_9ad9c90_simpleInfo = simpleInfo;
            OnSongSimpleInfoResult_9ad9c90_reason = reason;
        }

        public bool OnSongSimpleInfoResultPassed(string requestId, long songCode, string simpleInfo, MusicContentCenterStateReason reason)
        {
            if (OnSongSimpleInfoResult_9ad9c90_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<string>(OnSongSimpleInfoResult_9ad9c90_requestId, requestId) == false)
                return false;
            if (ParamsHelper.Compare<long>(OnSongSimpleInfoResult_9ad9c90_songCode, songCode) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnSongSimpleInfoResult_9ad9c90_simpleInfo, simpleInfo) == false)
                return false;
            if (ParamsHelper.Compare<MusicContentCenterStateReason>(OnSongSimpleInfoResult_9ad9c90_reason, reason) == false)
                return false;

            return true;
        }

        /////////////////////////////////

        public bool OnPreLoadEvent_d238b4d_be_trigger = false;
        public string OnPreLoadEvent_d238b4d_requestId;
        public long OnPreLoadEvent_d238b4d_internalSongCode;
        public int OnPreLoadEvent_d238b4d_percent;
        public string OnPreLoadEvent_d238b4d_payload;
        public MusicContentCenterState OnPreLoadEvent_d238b4d_status;
        public MusicContentCenterStateReason OnPreLoadEvent_d238b4d_reason;

        public override void OnPreLoadEvent(string requestId, long internalSongCode, int percent, string payload, MusicContentCenterState status, MusicContentCenterStateReason reason)
        {
            OnPreLoadEvent_d238b4d_be_trigger = true;
            OnPreLoadEvent_d238b4d_requestId = requestId;
            OnPreLoadEvent_d238b4d_internalSongCode = internalSongCode;
            OnPreLoadEvent_d238b4d_percent = percent;
            OnPreLoadEvent_d238b4d_payload = payload;
            OnPreLoadEvent_d238b4d_status = status;
            OnPreLoadEvent_d238b4d_reason = reason;
        }

        public bool OnPreLoadEventPassed(string requestId, long internalSongCode, int percent, string payload, MusicContentCenterState status, MusicContentCenterStateReason reason)
        {
            if (OnPreLoadEvent_d238b4d_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<string>(OnPreLoadEvent_d238b4d_requestId, requestId) == false)
                return false;
            if (ParamsHelper.Compare<long>(OnPreLoadEvent_d238b4d_internalSongCode, internalSongCode) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnPreLoadEvent_d238b4d_percent, percent) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnPreLoadEvent_d238b4d_payload, payload) == false)
                return false;
            if (ParamsHelper.Compare<MusicContentCenterState>(OnPreLoadEvent_d238b4d_status, status) == false)
                return false;
            if (ParamsHelper.Compare<MusicContentCenterStateReason>(OnPreLoadEvent_d238b4d_reason, reason) == false)
                return false;

            return true;
        }

        /////////////////////////////////

        public bool OnStartScoreResult_c579a23_be_trigger = false;
        public long OnStartScoreResult_c579a23_internalSongCode;
        public MusicContentCenterState OnStartScoreResult_c579a23_status;
        public MusicContentCenterStateReason OnStartScoreResult_c579a23_reason;

        public override void OnStartScoreResult(long internalSongCode, MusicContentCenterState status, MusicContentCenterStateReason reason)
        {
            OnStartScoreResult_c579a23_be_trigger = true;
            OnStartScoreResult_c579a23_internalSongCode = internalSongCode;
            OnStartScoreResult_c579a23_status = status;
            OnStartScoreResult_c579a23_reason = reason;
        }

        public bool OnStartScoreResultPassed(long internalSongCode, MusicContentCenterState status, MusicContentCenterStateReason reason)
        {
            if (OnStartScoreResult_c579a23_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<long>(OnStartScoreResult_c579a23_internalSongCode, internalSongCode) == false)
                return false;
            if (ParamsHelper.Compare<MusicContentCenterState>(OnStartScoreResult_c579a23_status, status) == false)
                return false;
            if (ParamsHelper.Compare<MusicContentCenterStateReason>(OnStartScoreResult_c579a23_reason, reason) == false)
                return false;

            return true;
        }

        /////////////////////////////////

    }
}