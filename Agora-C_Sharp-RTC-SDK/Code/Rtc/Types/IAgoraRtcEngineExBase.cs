namespace Agora.Rtc
{
    #region IAgoraRtcEngineEx

///
/// <summary>
/// Contains connection information.
/// </summary>
///
    public class RtcConnection
    {
///
/// <summary>
/// Destroys the specified video track.
/// </summary>
///
/// <returns>
/// 0: Success.< 0: Failure.
/// </returns>
///
        public RtcConnection()
        {

        }

  ///
  /// @ignore
  ///
        public RtcConnection(string channelId, uint localUid)
        {
            this.channelId = channelId;
            this.localUid = localUid;
        }

///
/// <summary>
/// The channel name.
/// </summary>
///
        public string channelId { set; get; }
        
///
/// <summary>
/// The ID of the local user.
/// </summary>
///
        public uint localUid { set; get; }
    };

    #endregion
}