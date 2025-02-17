using System;
using Agora.Rtc;
namespace Agora.Rtc.Ut
{
    public class UTScoreEventHandler : IScoreEventHandler
    {

        #region terra IScoreEventHandler
        public bool OnPitch_be_trigger = false;
        public long OnPitch_songCode;
        public RawScoreData OnPitch_rawScoreData;

        public override void OnPitch(long songCode, RawScoreData rawScoreData)
        {
            OnPitch_be_trigger = true;
            OnPitch_songCode = songCode;
            OnPitch_rawScoreData = rawScoreData;

        }

        public bool OnPitchPassed(long songCode, RawScoreData rawScoreData)
        {

            if (OnPitch_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<long>(OnPitch_songCode, songCode) == false)
                return false;
            if (ParamsHelper.Compare<RawScoreData>(OnPitch_rawScoreData, rawScoreData) == false)
                return false;

            return true;
        }

        /////////////////////////////////

        public bool OnLineScore_be_trigger = false;
        public long OnLineScore_songCode;
        public LineScoreData OnLineScore_lineScoreData;

        public override void OnLineScore(long songCode, LineScoreData lineScoreData)
        {
            OnLineScore_be_trigger = true;
            OnLineScore_songCode = songCode;
            OnLineScore_lineScoreData = lineScoreData;

        }

        public bool OnLineScorePassed(long songCode, LineScoreData lineScoreData)
        {

            if (OnLineScore_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<long>(OnLineScore_songCode, songCode) == false)
                return false;
            if (ParamsHelper.Compare<LineScoreData>(OnLineScore_lineScoreData, lineScoreData) == false)
                return false;

            return true;
        }

        /////////////////////////////////
        #endregion terra IScoreEventHandler
    }
}
