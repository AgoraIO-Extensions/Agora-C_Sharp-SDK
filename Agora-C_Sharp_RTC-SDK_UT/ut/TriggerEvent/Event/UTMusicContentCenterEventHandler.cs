using System;
using Agora.Rtc;
namespace Agora.Rtc
{
    public class UTMusicContentCenterEventHandler : IMusicContentCenterEventHandler
    {

        #region terra IMusicContentCenterEventHandler
        public bool OnMusicChartsResult_be_trigger = false;
        public string OnMusicChartsResult_requestId;
        public MusicChartInfo[] OnMusicChartsResult_result;
        public MusicContentCenterStateReason OnMusicChartsResult_reason;

        public override void OnMusicChartsResult(string requestId, MusicChartInfo[] result, MusicContentCenterStateReason reason)
        {
            OnMusicChartsResult_be_trigger = true;
            OnMusicChartsResult_requestId = requestId;
            OnMusicChartsResult_result = result;
            OnMusicChartsResult_reason = reason;

        }

        public bool OnMusicChartsResultPassed(string requestId, MusicChartInfo[] result, MusicContentCenterStateReason reason)
        {

            if (OnMusicChartsResult_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<string>(OnMusicChartsResult_requestId, requestId) == false)
            //return false;
            // if (ParamsHelper.Compare<MusicChartInfo[]>(OnMusicChartsResult_result, result) == false)
            //return false;
            // if (ParamsHelper.Compare<MusicContentCenterStateReason>(OnMusicChartsResult_reason, reason) == false)
            //return false;

            return true;
        }

        /////////////////////////////////

        public bool OnMusicCollectionResult_be_trigger = false;
        public string OnMusicCollectionResult_requestId;
        public MusicCollection OnMusicCollectionResult_result;
        public MusicContentCenterStateReason OnMusicCollectionResult_reason;

        public override void OnMusicCollectionResult(string requestId, MusicCollection result, MusicContentCenterStateReason reason)
        {
            OnMusicCollectionResult_be_trigger = true;
            OnMusicCollectionResult_requestId = requestId;
            OnMusicCollectionResult_result = result;
            OnMusicCollectionResult_reason = reason;

        }

        public bool OnMusicCollectionResultPassed(string requestId, MusicCollection result, MusicContentCenterStateReason reason)
        {

            if (OnMusicCollectionResult_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<string>(OnMusicCollectionResult_requestId, requestId) == false)
            //return false;
            // if (ParamsHelper.Compare<MusicCollection>(OnMusicCollectionResult_result, result) == false)
            //return false;
            // if (ParamsHelper.Compare<MusicContentCenterStateReason>(OnMusicCollectionResult_reason, reason) == false)
            //return false;

            return true;
        }

        /////////////////////////////////

        public bool OnLyricResult_be_trigger = false;
        public string OnLyricResult_requestId;
        public long OnLyricResult_songCode;
        public string OnLyricResult_lyricUrl;
        public MusicContentCenterStateReason OnLyricResult_reason;

        public override void OnLyricResult(string requestId, long songCode, string lyricUrl, MusicContentCenterStateReason reason)
        {
            OnLyricResult_be_trigger = true;
            OnLyricResult_requestId = requestId;
            OnLyricResult_songCode = songCode;
            OnLyricResult_lyricUrl = lyricUrl;
            OnLyricResult_reason = reason;

        }

        public bool OnLyricResultPassed(string requestId, long songCode, string lyricUrl, MusicContentCenterStateReason reason)
        {

            if (OnLyricResult_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<string>(OnLyricResult_requestId, requestId) == false)
            //return false;
            // if (ParamsHelper.Compare<long>(OnLyricResult_songCode, songCode) == false)
            //return false;
            // if (ParamsHelper.Compare<string>(OnLyricResult_lyricUrl, lyricUrl) == false)
            //return false;
            // if (ParamsHelper.Compare<MusicContentCenterStateReason>(OnLyricResult_reason, reason) == false)
            //return false;

            return true;
        }

        /////////////////////////////////

        public bool OnSongSimpleInfoResult_be_trigger = false;
        public string OnSongSimpleInfoResult_requestId;
        public long OnSongSimpleInfoResult_songCode;
        public string OnSongSimpleInfoResult_simpleInfo;
        public MusicContentCenterStateReason OnSongSimpleInfoResult_reason;

        public override void OnSongSimpleInfoResult(string requestId, long songCode, string simpleInfo, MusicContentCenterStateReason reason)
        {
            OnSongSimpleInfoResult_be_trigger = true;
            OnSongSimpleInfoResult_requestId = requestId;
            OnSongSimpleInfoResult_songCode = songCode;
            OnSongSimpleInfoResult_simpleInfo = simpleInfo;
            OnSongSimpleInfoResult_reason = reason;

        }

        public bool OnSongSimpleInfoResultPassed(string requestId, long songCode, string simpleInfo, MusicContentCenterStateReason reason)
        {

            if (OnSongSimpleInfoResult_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<string>(OnSongSimpleInfoResult_requestId, requestId) == false)
            //return false;
            // if (ParamsHelper.Compare<long>(OnSongSimpleInfoResult_songCode, songCode) == false)
            //return false;
            // if (ParamsHelper.Compare<string>(OnSongSimpleInfoResult_simpleInfo, simpleInfo) == false)
            //return false;
            // if (ParamsHelper.Compare<MusicContentCenterStateReason>(OnSongSimpleInfoResult_reason, reason) == false)
            //return false;

            return true;
        }

        /////////////////////////////////

        public bool OnPreLoadEvent_be_trigger = false;
        public string OnPreLoadEvent_requestId;
        public long OnPreLoadEvent_songCode;
        public int OnPreLoadEvent_percent;
        public string OnPreLoadEvent_lyricUrl;
        public PreloadState OnPreLoadEvent_state;
        public MusicContentCenterStateReason OnPreLoadEvent_reason;

        public override void OnPreLoadEvent(string requestId, long songCode, int percent, string lyricUrl, PreloadState state, MusicContentCenterStateReason reason)
        {
            OnPreLoadEvent_be_trigger = true;
            OnPreLoadEvent_requestId = requestId;
            OnPreLoadEvent_songCode = songCode;
            OnPreLoadEvent_percent = percent;
            OnPreLoadEvent_lyricUrl = lyricUrl;
            OnPreLoadEvent_state = state;
            OnPreLoadEvent_reason = reason;

        }

        public bool OnPreLoadEventPassed(string requestId, long songCode, int percent, string lyricUrl, PreloadState state, MusicContentCenterStateReason reason)
        {

            if (OnPreLoadEvent_be_trigger == false)
                return false;

            // if (ParamsHelper.Compare<string>(OnPreLoadEvent_requestId, requestId) == false)
            //return false;
            // if (ParamsHelper.Compare<long>(OnPreLoadEvent_songCode, songCode) == false)
            //return false;
            // if (ParamsHelper.Compare<int>(OnPreLoadEvent_percent, percent) == false)
            //return false;
            // if (ParamsHelper.Compare<string>(OnPreLoadEvent_lyricUrl, lyricUrl) == false)
            //return false;
            // if (ParamsHelper.Compare<PreloadState>(OnPreLoadEvent_state, state) == false)
            //return false;
            // if (ParamsHelper.Compare<MusicContentCenterStateReason>(OnPreLoadEvent_reason, reason) == false)
            //return false;

            return true;
        }

        /////////////////////////////////
        #endregion terra IMusicContentCenterEventHandler
    }
}
