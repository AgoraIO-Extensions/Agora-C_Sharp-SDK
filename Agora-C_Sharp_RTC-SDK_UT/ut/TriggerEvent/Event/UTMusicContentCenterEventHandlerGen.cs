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
        public long OnLyricResult_9ad9c90_songCode;
        public string OnLyricResult_9ad9c90_lyricUrl;
        public MusicContentCenterStateReason OnLyricResult_9ad9c90_reason;

        public override void OnLyricResult(string requestId, long songCode, string lyricUrl, MusicContentCenterStateReason reason)
        {
            OnLyricResult_9ad9c90_be_trigger = true;
            OnLyricResult_9ad9c90_requestId = requestId;
            OnLyricResult_9ad9c90_songCode = songCode;
            OnLyricResult_9ad9c90_lyricUrl = lyricUrl;
            OnLyricResult_9ad9c90_reason = reason;
        }

        public bool OnLyricResultPassed(string requestId, long songCode, string lyricUrl, MusicContentCenterStateReason reason)
        {
            if (OnLyricResult_9ad9c90_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<string>(OnLyricResult_9ad9c90_requestId, requestId) == false)
                return false;
            if (ParamsHelper.Compare<long>(OnLyricResult_9ad9c90_songCode, songCode) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnLyricResult_9ad9c90_lyricUrl, lyricUrl) == false)
                return false;
            if (ParamsHelper.Compare<MusicContentCenterStateReason>(OnLyricResult_9ad9c90_reason, reason) == false)
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

        public bool OnPreLoadEvent_20170bc_be_trigger = false;
        public string OnPreLoadEvent_20170bc_requestId;
        public long OnPreLoadEvent_20170bc_songCode;
        public int OnPreLoadEvent_20170bc_percent;
        public string OnPreLoadEvent_20170bc_lyricUrl;
        public PreloadState OnPreLoadEvent_20170bc_state;
        public MusicContentCenterStateReason OnPreLoadEvent_20170bc_reason;

        public override void OnPreLoadEvent(string requestId, long songCode, int percent, string lyricUrl, PreloadState state, MusicContentCenterStateReason reason)
        {
            OnPreLoadEvent_20170bc_be_trigger = true;
            OnPreLoadEvent_20170bc_requestId = requestId;
            OnPreLoadEvent_20170bc_songCode = songCode;
            OnPreLoadEvent_20170bc_percent = percent;
            OnPreLoadEvent_20170bc_lyricUrl = lyricUrl;
            OnPreLoadEvent_20170bc_state = state;
            OnPreLoadEvent_20170bc_reason = reason;
        }

        public bool OnPreLoadEventPassed(string requestId, long songCode, int percent, string lyricUrl, PreloadState state, MusicContentCenterStateReason reason)
        {
            if (OnPreLoadEvent_20170bc_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<string>(OnPreLoadEvent_20170bc_requestId, requestId) == false)
                return false;
            if (ParamsHelper.Compare<long>(OnPreLoadEvent_20170bc_songCode, songCode) == false)
                return false;
            if (ParamsHelper.Compare<int>(OnPreLoadEvent_20170bc_percent, percent) == false)
                return false;
            if (ParamsHelper.Compare<string>(OnPreLoadEvent_20170bc_lyricUrl, lyricUrl) == false)
                return false;
            if (ParamsHelper.Compare<PreloadState>(OnPreLoadEvent_20170bc_state, state) == false)
                return false;
            if (ParamsHelper.Compare<MusicContentCenterStateReason>(OnPreLoadEvent_20170bc_reason, reason) == false)
                return false;

            return true;
        }

        /////////////////////////////////

    }
}