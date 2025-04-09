#region Generated by `terra/node/src/rtc/ut/renderers.ts`. DO NOT MODIFY BY HAND.
#endregion

using System;
using Agora.Rtc;
namespace Agora.Rtc.Ut
{
    public partial class UTScoreEventHandler : IScoreEventHandler
    {
        public bool OnPitch_5b7d529_be_trigger = false;
        public long OnPitch_5b7d529_songCode;
        public RawScoreData OnPitch_5b7d529_rawScoreData;

        public override void OnPitch(long songCode, RawScoreData rawScoreData)
        {
            OnPitch_5b7d529_be_trigger = true;
            OnPitch_5b7d529_songCode = songCode;
            OnPitch_5b7d529_rawScoreData = rawScoreData;
        }

        public bool OnPitchPassed(long songCode, RawScoreData rawScoreData)
        {
            if (OnPitch_5b7d529_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<long>(OnPitch_5b7d529_songCode, songCode) == false)
                return false;
            if (ParamsHelper.Compare<RawScoreData>(OnPitch_5b7d529_rawScoreData, rawScoreData) == false)
                return false;

            return true;
        }

        /////////////////////////////////

        public bool OnLineScore_e4987ce_be_trigger = false;
        public long OnLineScore_e4987ce_songCode;
        public LineScoreData OnLineScore_e4987ce_lineScoreData;

        public override void OnLineScore(long songCode, LineScoreData lineScoreData)
        {
            OnLineScore_e4987ce_be_trigger = true;
            OnLineScore_e4987ce_songCode = songCode;
            OnLineScore_e4987ce_lineScoreData = lineScoreData;
        }

        public bool OnLineScorePassed(long songCode, LineScoreData lineScoreData)
        {
            if (OnLineScore_e4987ce_be_trigger == false)
                return false;

            if (ParamsHelper.Compare<long>(OnLineScore_e4987ce_songCode, songCode) == false)
                return false;
            if (ParamsHelper.Compare<LineScoreData>(OnLineScore_e4987ce_lineScoreData, lineScoreData) == false)
                return false;

            return true;
        }

        /////////////////////////////////

    }
}