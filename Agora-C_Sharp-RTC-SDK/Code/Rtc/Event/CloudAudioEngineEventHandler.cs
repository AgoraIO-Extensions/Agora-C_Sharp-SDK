namespace Agora.Rtc
{
    //public delegate void OnTokenWillExpireHandler();
  
    //public delegate void OnConnectionStateChangeHandler(SAE_CONNECTION_STATE_TYPE state, SAE_CONNECTION_CHANGED_REASON_TYPE reason);

    //public delegate void OnTeammateLeftHandler(uint uid);

    //public delegate void OnTeammateJoinedHandler(uint uid);

    //public class CloudSpatialAudioEventHandler : ICloudSpatialAudioEventHandler
    //{
    //    public event OnTokenWillExpireHandler EventOnTokenWillExpire;
    //    public event OnConnectionStateChangeHandler EventOnConnectionStateChange;
    //    public event OnTeammateLeftHandler EventOnTeammateLeft;
    //    public event OnTeammateJoinedHandler EventOnTeammateJoined;

    //    private static CloudSpatialAudioEventHandler eventInstance = null;

    //    public static CloudSpatialAudioEventHandler GetInstance()
    //    {
    //        return eventInstance ?? (eventInstance = new CloudSpatialAudioEventHandler());
    //    }

    //    public override void OnTokenWillExpire()
    //    {
    //        if (EventOnTokenWillExpire == null) return;
    //        EventOnTokenWillExpire.Invoke();
    //    }
  
    //    public override void OnConnectionStateChange(SAE_CONNECTION_STATE_TYPE state, SAE_CONNECTION_CHANGED_REASON_TYPE reason)
    //    {
    //        if (EventOnConnectionStateChange == null) return;
    //        EventOnConnectionStateChange.Invoke(state, reason);
    //    }

    //    public override void OnTeammateLeft(uint uid)
    //    {
    //        if (EventOnTeammateLeft == null) return;
    //        EventOnTeammateLeft.Invoke(uid);
    //    }

    //    public override void OnTeammateJoined(uint uid)
    //    {
    //        if (EventOnTeammateJoined == null) return;
    //        EventOnTeammateJoined.Invoke(uid);
    //    }
    //}
}