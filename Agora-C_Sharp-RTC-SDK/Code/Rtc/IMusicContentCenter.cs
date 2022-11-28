using System;

namespace Agora.Rtc
{
///
/// @ignore
///
    public abstract class IMusicContentCenter
    {
///
/// <summary>
/// Starts relaying media streams across channels. This method can be used to implement scenarios such as co-host across channels.
/// After a successful method call, the SDK triggers the OnChannelMediaRelayStateChanged and OnChannelMediaRelayEvent callbacks, and these callbacks return the state and events of the media stream relay.If the OnChannelMediaRelayStateChanged callback returns RELAY_STATE_RUNNING (2) and RELAY_OK (0), and the OnChannelMediaRelayEvent callback returns RELAY_EVENT_PACKET_SENT_TO_DEST_CHANNEL (4), it means that the SDK starts relaying media streams between the source channel and the destination channel.If the OnChannelMediaRelayStateChanged callback returnsRELAY_STATE_FAILURE (3), an exception occurs during the media stream relay.Call this method after joining the channel.This method takes effect only when you are a host in a live streaming channel.After a successful method call, if you want to call this method again, ensure that you call the StopChannelMediaRelay method to quit the current relay.The relaying media streams across channels function needs to be enabled.We do not support string user accounts in this API.
/// </summary>
///
/// <param name ="configuration">The configuration of the media stream relay. See ChannelMediaRelayConfiguration .</param>
///
/// <returns>
/// 0: Success.< 0: Failure.-1: A general error occurs (no specified reason).-2: The parameter is invalid.-7: The method call was rejected. It may be because the SDK has not been initialized successfully, or the user role is not an host.-8: Internal state error. Probably because the user is not an audience member.
/// </returns>
///
        public abstract int Initialize(MusicContentCenterConfiguration configuration);

///
/// @ignore
///
        public abstract int RegisterEventHandler(IMusicContentCenterEventHandler eventHandler);

///
/// <summary>
/// Destroys the specified video track.
/// </summary>
///
/// <returns>
/// 0: Success.< 0: Failure.
/// </returns>
///
        public abstract int UnregisterEventHandler();

///
/// <summary>
/// Destroys the specified video track.
/// </summary>
///
/// <returns>
/// 0: Success.< 0: Failure.
/// </returns>
///
        public abstract IMusicPlayer CreateMusicPlayer();

  ///
  /// @ignore
  ///
        public abstract int DestroyMusicPlayer(IMusicPlayer player);

///
/// @ignore
///
        public abstract int GetMusicCharts(ref string requestId);

  ///
  /// @ignore
  ///
        public abstract int GetMusicCollectionByMusicChartId(ref string requestId, int musicChartType, int page, int pageSize, string jsonOption = "");

///
/// @ignore
///
        public abstract int SearchMusic(ref string requestId, string keyWord, int page, int pageSize, string jsonOption = "");

///
/// @ignore
///
        public abstract int Preload(Int64 songCode, string jsonOption = "");

///
/// @ignore
///
        public abstract int IsPreloaded(Int64 songCode);

///
/// @ignore
///
        public abstract int GetLyric(ref string requestId, Int64 songCode, int LyricType = 0);

///
/// @ignore
///
        public abstract int RenewToken(string token);
    }
}