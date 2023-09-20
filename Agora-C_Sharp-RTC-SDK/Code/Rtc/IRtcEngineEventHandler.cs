using System;

namespace Agora.Rtc
{
    /* class_irtcengineeventhandler */
    public abstract class IRtcEngineEventHandler
    {

#region terra IRtcEngineEventHandler

        /* callback_irtcengineeventhandler_onjoinchannelsuccess */
        public virtual void OnJoinChannelSuccess(RtcConnection connection, int elapsed)
        {
        }

        /* callback_irtcengineeventhandler_onrejoinchannelsuccess */
        public virtual void OnRejoinChannelSuccess(RtcConnection connection, int elapsed)
        {
        }

        /* callback_irtcengineeventhandler_onproxyconnected */
        public virtual void OnProxyConnected(string channel, uint uid, PROXY_TYPE proxyType, string localProxyIp, int elapsed)
        {
        }

        /* callback_irtcengineeventhandler_onerror */
        public virtual void OnError(int err, string msg)
        {
        }

        /* callback_irtcengineeventhandler_onaudioquality */
        public virtual void OnAudioQuality(RtcConnection connection, uint remoteUid, int quality, ushort delay, ushort lost)
        {
        }

        /* callback_irtcengineeventhandler_onlastmileproberesult */
        public virtual void OnLastmileProbeResult(LastmileProbeResult result)
        {
        }

        /* callback_irtcengineeventhandler_onaudiovolumeindication */
        public virtual void OnAudioVolumeIndication(RtcConnection connection, AudioVolumeInfo[] speakers, uint speakerNumber, int totalVolume)
        {
        }

        /* callback_irtcengineeventhandler_onleavechannel */
        public virtual void OnLeaveChannel(RtcConnection connection, RtcStats stats)
        {
        }

        /* callback_irtcengineeventhandler_onrtcstats */
        public virtual void OnRtcStats(RtcConnection connection, RtcStats stats)
        {
        }

        /* callback_irtcengineeventhandler_onaudiodevicestatechanged */
        public virtual void OnAudioDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
        }

        /* callback_irtcengineeventhandler_onaudiomixingpositionchanged */
        public virtual void OnAudioMixingPositionChanged(long position)
        {
        }

        /* callback_irtcengineeventhandler_onaudiomixingfinished */
        public virtual void OnAudioMixingFinished()
        {
        }

        /* callback_irtcengineeventhandler_onaudioeffectfinished */
        public virtual void OnAudioEffectFinished(int soundId)
        {
        }

        /* callback_irtcengineeventhandler_onvideodevicestatechanged */
        public virtual void OnVideoDeviceStateChanged(string deviceId, MEDIA_DEVICE_TYPE deviceType, MEDIA_DEVICE_STATE_TYPE deviceState)
        {
        }

        /* callback_irtcengineeventhandler_onnetworkquality */
        public virtual void OnNetworkQuality(RtcConnection connection, uint remoteUid, int txQuality, int rxQuality)
        {
        }

        /* callback_irtcengineeventhandler_onintrarequestreceived */
        public virtual void OnIntraRequestReceived(RtcConnection connection)
        {
        }

        /* callback_irtcengineeventhandler_onuplinknetworkinfoupdated */
        public virtual void OnUplinkNetworkInfoUpdated(UplinkNetworkInfo info)
        {
        }

        /* callback_irtcengineeventhandler_ondownlinknetworkinfoupdated */
        public virtual void OnDownlinkNetworkInfoUpdated(DownlinkNetworkInfo info)
        {
        }

        /* callback_irtcengineeventhandler_onlastmilequality */
        public virtual void OnLastmileQuality(int quality)
        {
        }

        /* callback_irtcengineeventhandler_onfirstlocalvideoframe */
        public virtual void OnFirstLocalVideoFrame(VIDEO_SOURCE_TYPE source, int width, int height, int elapsed)
        {
        }

        /* callback_irtcengineeventhandler_onfirstlocalvideoframepublished */
        public virtual void OnFirstLocalVideoFramePublished(RtcConnection connection, int elapsed)
        {
        }

        /* callback_irtcengineeventhandler_onfirstremotevideodecoded */
        public virtual void OnFirstRemoteVideoDecoded(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
        }

        /* callback_irtcengineeventhandler_onvideosizechanged */
        public virtual void OnVideoSizeChanged(RtcConnection connection, VIDEO_SOURCE_TYPE sourceType, uint uid, int width, int height, int rotation)
        {
        }

        /* callback_irtcengineeventhandler_onlocalvideostatechanged */
        public virtual void OnLocalVideoStateChanged(VIDEO_SOURCE_TYPE source, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR error)
        {
        }

        /* callback_irtcengineeventhandler_onlocalvideostatechanged2 */
        public virtual void OnLocalVideoStateChanged(RtcConnection connection, LOCAL_VIDEO_STREAM_STATE state, LOCAL_VIDEO_STREAM_ERROR errorCode)
        {
        }

        /* callback_irtcengineeventhandler_onremotevideostatechanged */
        public virtual void OnRemoteVideoStateChanged(RtcConnection connection, uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
        }

        /* callback_irtcengineeventhandler_onfirstremotevideoframe */
        public virtual void OnFirstRemoteVideoFrame(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
        {
        }

        /* callback_irtcengineeventhandler_onuserjoined */
        public virtual void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
        }

        /* callback_irtcengineeventhandler_onuseroffline */
        public virtual void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
        }

        /* callback_irtcengineeventhandler_onusermuteaudio */
        public virtual void OnUserMuteAudio(RtcConnection connection, uint remoteUid, bool muted)
        {
        }

        /* callback_irtcengineeventhandler_onusermutevideo */
        public virtual void OnUserMuteVideo(RtcConnection connection, uint remoteUid, bool muted)
        {
        }

        /* callback_irtcengineeventhandler_onuserenablevideo */
        public virtual void OnUserEnableVideo(RtcConnection connection, uint remoteUid, bool enabled)
        {
        }

        /* callback_irtcengineeventhandler_onuserstatechanged */
        public virtual void OnUserStateChanged(RtcConnection connection, uint remoteUid, uint state)
        {
        }

        /* callback_irtcengineeventhandler_onuserenablelocalvideo */
        public virtual void OnUserEnableLocalVideo(RtcConnection connection, uint remoteUid, bool enabled)
        {
        }

        /* callback_irtcengineeventhandler_onlocalaudiostats */
        public virtual void OnLocalAudioStats(RtcConnection connection, LocalAudioStats stats)
        {
        }

        /* callback_irtcengineeventhandler_onremoteaudiostats */
        public virtual void OnRemoteAudioStats(RtcConnection connection, RemoteAudioStats stats)
        {
        }

        /* callback_irtcengineeventhandler_onlocalvideostats */
        public virtual void OnLocalVideoStats(RtcConnection connection, LocalVideoStats stats)
        {
        }

        /* callback_irtcengineeventhandler_onremotevideostats */
        public virtual void OnRemoteVideoStats(RtcConnection connection, RemoteVideoStats stats)
        {
        }

        /* callback_irtcengineeventhandler_oncameraready */
        public virtual void OnCameraReady()
        {
        }

        /* callback_irtcengineeventhandler_oncamerafocusareachanged */
        public virtual void OnCameraFocusAreaChanged(int x, int y, int width, int height)
        {
        }

        /* callback_irtcengineeventhandler_oncameraexposureareachanged */
        public virtual void OnCameraExposureAreaChanged(int x, int y, int width, int height)
        {
        }

        /* callback_irtcengineeventhandler_onfacepositionchanged */
        public virtual void OnFacePositionChanged(int imageWidth, int imageHeight, Rectangle[] vecRectangle, int[] vecDistance, int numFaces)
        {
        }

        /* callback_irtcengineeventhandler_onvideostopped */
        public virtual void OnVideoStopped()
        {
        }

        /* callback_irtcengineeventhandler_onaudiomixingstatechanged */
        public virtual void OnAudioMixingStateChanged(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_REASON_TYPE reason)
        {
        }

        /* callback_irtcengineeventhandler_onrhythmplayerstatechanged */
        public virtual void OnRhythmPlayerStateChanged(RHYTHM_PLAYER_STATE_TYPE state, RHYTHM_PLAYER_ERROR_TYPE errorCode)
        {
        }

        /* callback_irtcengineeventhandler_onconnectionlost */
        public virtual void OnConnectionLost(RtcConnection connection)
        {
        }

        /* callback_irtcengineeventhandler_onconnectioninterrupted */
        public virtual void OnConnectionInterrupted(RtcConnection connection)
        {
        }

        /* callback_irtcengineeventhandler_onconnectionbanned */
        public virtual void OnConnectionBanned(RtcConnection connection)
        {
        }

        /* callback_irtcengineeventhandler_onstreammessage */
        public virtual void OnStreamMessage(RtcConnection connection, uint remoteUid, int streamId, byte[] data, ulong length, ulong sentTs)
        {
        }

        /* callback_irtcengineeventhandler_onstreammessageerror */
        public virtual void OnStreamMessageError(RtcConnection connection, uint remoteUid, int streamId, int code, int missed, int cached)
        {
        }

        /* callback_irtcengineeventhandler_onrequesttoken */
        public virtual void OnRequestToken(RtcConnection connection)
        {
        }

        /* callback_irtcengineeventhandler_ontokenprivilegewillexpire */
        public virtual void OnTokenPrivilegeWillExpire(RtcConnection connection, string token)
        {
        }

        /* callback_irtcengineeventhandler_onlicensevalidationfailure */
        public virtual void OnLicenseValidationFailure(RtcConnection connection, LICENSE_ERROR_TYPE reason)
        {
        }

        /* callback_irtcengineeventhandler_onfirstlocalaudioframepublished */
        public virtual void OnFirstLocalAudioFramePublished(RtcConnection connection, int elapsed)
        {
        }

        /* callback_irtcengineeventhandler_onfirstremoteaudioframe */
        public virtual void OnFirstRemoteAudioFrame(RtcConnection connection, uint userId, int elapsed)
        {
        }

        /* callback_irtcengineeventhandler_onfirstremoteaudiodecoded */
        public virtual void OnFirstRemoteAudioDecoded(RtcConnection connection, uint uid, int elapsed)
        {
        }

        /* callback_irtcengineeventhandler_onlocalaudiostatechanged */
        public virtual void OnLocalAudioStateChanged(RtcConnection connection, LOCAL_AUDIO_STREAM_STATE state, LOCAL_AUDIO_STREAM_ERROR error)
        {
        }

        /* callback_irtcengineeventhandler_onremoteaudiostatechanged */
        public virtual void OnRemoteAudioStateChanged(RtcConnection connection, uint remoteUid, REMOTE_AUDIO_STATE state, REMOTE_AUDIO_STATE_REASON reason, int elapsed)
        {
        }

        /* callback_irtcengineeventhandler_onactivespeaker */
        public virtual void OnActiveSpeaker(RtcConnection connection, uint uid)
        {
        }

        /* callback_irtcengineeventhandler_oncontentinspectresult */
        public virtual void OnContentInspectResult(CONTENT_INSPECT_RESULT result)
        {
        }

        /* callback_irtcengineeventhandler_onsnapshottaken */
        public virtual void OnSnapshotTaken(RtcConnection connection, uint uid, string filePath, int width, int height, int errCode)
        {
        }

        /* callback_irtcengineeventhandler_onclientrolechanged */
        public virtual void OnClientRoleChanged(RtcConnection connection, CLIENT_ROLE_TYPE oldRole, CLIENT_ROLE_TYPE newRole, ClientRoleOptions newRoleOptions)
        {
        }

        /* callback_irtcengineeventhandler_onclientrolechangefailed */
        public virtual void OnClientRoleChangeFailed(RtcConnection connection, CLIENT_ROLE_CHANGE_FAILED_REASON reason, CLIENT_ROLE_TYPE currentRole)
        {
        }

        /* callback_irtcengineeventhandler_onaudiodevicevolumechanged */
        public virtual void OnAudioDeviceVolumeChanged(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted)
        {
        }

        /* callback_irtcengineeventhandler_onrtmpstreamingstatechanged */
        public virtual void OnRtmpStreamingStateChanged(string url, RTMP_STREAM_PUBLISH_STATE state, RTMP_STREAM_PUBLISH_ERROR_TYPE errCode)
        {
        }

        /* callback_irtcengineeventhandler_onrtmpstreamingevent */
        public virtual void OnRtmpStreamingEvent(string url, RTMP_STREAMING_EVENT eventCode)
        {
        }

        /* callback_irtcengineeventhandler_ontranscodingupdated */
        public virtual void OnTranscodingUpdated()
        {
        }

        /* callback_irtcengineeventhandler_onaudioroutingchanged */
        public virtual void OnAudioRoutingChanged(int routing)
        {
        }

        /* callback_irtcengineeventhandler_onchannelmediarelaystatechanged */
        public virtual void OnChannelMediaRelayStateChanged(int state, int code)
        {
        }

        /* callback_irtcengineeventhandler_onchannelmediarelayevent */
        public virtual void OnChannelMediaRelayEvent(int code)
        {
        }

        /* callback_irtcengineeventhandler_onlocalpublishfallbacktoaudioonly */
        public virtual void OnLocalPublishFallbackToAudioOnly(bool isFallbackOrRecover)
        {
        }

        /* callback_irtcengineeventhandler_onremotesubscribefallbacktoaudioonly */
        public virtual void OnRemoteSubscribeFallbackToAudioOnly(uint uid, bool isFallbackOrRecover)
        {
        }

        /* callback_irtcengineeventhandler_onremoteaudiotransportstats */
        public virtual void OnRemoteAudioTransportStats(RtcConnection connection, uint remoteUid, ushort delay, ushort lost, ushort rxKBitRate)
        {
        }

        /* callback_irtcengineeventhandler_onremotevideotransportstats */
        public virtual void OnRemoteVideoTransportStats(RtcConnection connection, uint remoteUid, ushort delay, ushort lost, ushort rxKBitRate)
        {
        }

        /* callback_irtcengineeventhandler_onconnectionstatechanged */
        public virtual void OnConnectionStateChanged(RtcConnection connection, CONNECTION_STATE_TYPE state, CONNECTION_CHANGED_REASON_TYPE reason)
        {
        }

        /* callback_irtcengineeventhandler_onwlaccmessage */
        public virtual void OnWlAccMessage(RtcConnection connection, WLACC_MESSAGE_REASON reason, WLACC_SUGGEST_ACTION action, string wlAccMsg)
        {
        }

        /* callback_irtcengineeventhandler_onwlaccstats */
        public virtual void OnWlAccStats(RtcConnection connection, WlAccStats currentStats, WlAccStats averageStats)
        {
        }

        /* callback_irtcengineeventhandler_onnetworktypechanged */
        public virtual void OnNetworkTypeChanged(RtcConnection connection, NETWORK_TYPE type)
        {
        }

        /* callback_irtcengineeventhandler_onencryptionerror */
        public virtual void OnEncryptionError(RtcConnection connection, ENCRYPTION_ERROR_TYPE errorType)
        {
        }

        /* callback_irtcengineeventhandler_onpermissionerror */
        public virtual void OnPermissionError(PERMISSION_TYPE permissionType)
        {
        }

        /* callback_irtcengineeventhandler_onlocaluserregistered */
        public virtual void OnLocalUserRegistered(uint uid, string userAccount)
        {
        }

        /* callback_irtcengineeventhandler_onuserinfoupdated */
        public virtual void OnUserInfoUpdated(uint uid, UserInfo info)
        {
        }

        /* callback_irtcengineeventhandler_onuploadlogresult */
        public virtual void OnUploadLogResult(RtcConnection connection, string requestId, bool success, UPLOAD_ERROR_REASON reason)
        {
        }

        /* callback_irtcengineeventhandler_onaudiosubscribestatechanged */
        public virtual void OnAudioSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        /* callback_irtcengineeventhandler_onvideosubscribestatechanged */
        public virtual void OnVideoSubscribeStateChanged(string channel, uint uid, STREAM_SUBSCRIBE_STATE oldState, STREAM_SUBSCRIBE_STATE newState, int elapseSinceLastState)
        {
        }

        /* callback_irtcengineeventhandler_onaudiopublishstatechanged */
        public virtual void OnAudioPublishStateChanged(string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        /* callback_irtcengineeventhandler_onvideopublishstatechanged */
        public virtual void OnVideoPublishStateChanged(VIDEO_SOURCE_TYPE source, string channel, STREAM_PUBLISH_STATE oldState, STREAM_PUBLISH_STATE newState, int elapseSinceLastState)
        {
        }

        /* callback_irtcengineeventhandler_onextensionevent */
        public virtual void OnExtensionEvent(string provider, string extension, string key, string value)
        {
        }

        /* callback_irtcengineeventhandler_onextensionstarted */
        public virtual void OnExtensionStarted(string provider, string extension)
        {
        }

        /* callback_irtcengineeventhandler_onextensionstopped */
        public virtual void OnExtensionStopped(string provider, string extension)
        {
        }

        /* callback_irtcengineeventhandler_onextensionerror */
        public virtual void OnExtensionError(string provider, string extension, int error, string message)
        {
        }

        /* callback_irtcengineeventhandler_onuseraccountupdated */
        public virtual void OnUserAccountUpdated(RtcConnection connection, uint remoteUid, string userAccount)
        {
        }

        /* callback_irtcengineeventhandler_onlocalvideotranscodererror */
        public virtual void OnLocalVideoTranscoderError(TranscodingVideoStream stream, VIDEO_TRANSCODER_ERROR error)
        {
        }

        /* callback_irtcengineeventhandler_onvideorenderingtracingresult */
        public virtual void OnVideoRenderingTracingResult(RtcConnection connection, uint uid, MEDIA_TRACE_EVENT currentEvent, VideoRenderingTracingInfo tracingInfo)
        {
        }
#endregion terra IRtcEngineEventHandler

#region terra IDirectCdnStreamingEventHandler

        /* callback_irtcengineeventhandler_ondirectcdnstreamingstatechanged */
        public virtual void OnDirectCdnStreamingStateChanged(DIRECT_CDN_STREAMING_STATE state, DIRECT_CDN_STREAMING_ERROR error, string message)
        {
        }

        /* callback_irtcengineeventhandler_ondirectcdnstreamingstats */
        public virtual void OnDirectCdnStreamingStats(DirectCdnStreamingStats stats)
        {
        }
#endregion terra IDirectCdnStreamingEventHandler
    };
}