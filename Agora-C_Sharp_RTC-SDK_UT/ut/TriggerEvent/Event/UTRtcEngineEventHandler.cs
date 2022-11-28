using System;
namespace Agora.Rtc
{
    public class UTRtcEngineEventHandler : IRtcEngineEventHandler
    {

        public bool OnJoinChannelSuccess_be_trigger = false;
        public RtcConnection OnJoinChannelSuccess_connection = null;
        public int OnJoinChannelSuccess_elapsed = 0;

        public override void OnJoinChannelSuccess(RtcConnection connection, int elapsed)
        {
            OnJoinChannelSuccess_be_trigger = true;
            OnJoinChannelSuccess_connection = connection;
            OnJoinChannelSuccess_elapsed = elapsed;
        }

        public bool OnJoinChannelSuccessPassed(RtcConnection connection, int elapsed)
        {
            if (OnJoinChannelSuccess_be_trigger == false)
                return false;

            if (ParamsHelper.compareRtcConnection(OnJoinChannelSuccess_connection, connection) == false)
                return false;

            if (ParamsHelper.compareInt(OnJoinChannelSuccess_elapsed, elapsed) == false)
                return false;

            return true;
        }




    }
}
