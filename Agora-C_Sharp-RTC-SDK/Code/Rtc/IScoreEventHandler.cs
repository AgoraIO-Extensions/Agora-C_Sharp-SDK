using System;
using int64_t = System.Int64;
namespace Agora.Rtc
{
    ///
    /// @ignore
    ///
    public abstract class IScoreEventHandler
    {

        #region terra IScoreEventHandler
        ///
        /// @ignore
        ///
        public abstract void OnPitch(long songCode, RawScoreData rawScoreData);

        ///
        /// @ignore
        ///
        public abstract void OnLineScore(long songCode, LineScoreData lineScoreData);
        #endregion terra IScoreEventHandler
    }
}