using System;
using System.Runtime.InteropServices;

namespace agorartc
{

    using uid_t = UInt32;
    using view_t = IntPtr;
    using IRtcEngineBridge_ptr = IntPtr;
    using IRtcChannelBridge_ptr = IntPtr;
    using IVideoDeviceManager_ptr = IntPtr;
    using IAudioPlaybackDeviceManager_ptr = IntPtr;
    using IAudioRecordingDeviceManager_ptr = IntPtr;
    
    
    interface AgoraDeviceManager
    {
        void OnAgoraDispose();
    }
    
    

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelWarning(string channelId, int warn, string msg);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelError(string channelId, int err, string msg);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelJoinChannelSuccess(string channelId, uint uid, int elapsed);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelReJoinChannelSuccess(string channelId, uint uid, int elapsed);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelLeaveChannel(string channelId, uint duration, uint txBytes, uint rxBytes,
        uint txAudioBytes, uint txVideoBytes, uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate,
        ushort rxKBitRate, ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate,
        ushort txVideoKBitRate, ushort lastmileDelay, ushort txPacketLossRate, ushort rxPacketLossRate, uint userCount,
        double cpuAppUsage, double cpuTotalUsage, int gatewayRtt, double memoryAppUsageRatio,
        double memoryTotalUsageRatio, int memoryAppUsageInKbytes);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelClientRoleChanged(string channelId, int oldRole, int newRole);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelUserJoined(string channelId, uint uid, int elapsed);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelUserOffLine(string channelId, uint uid, int reason);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelConnectionLost(string channelId);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelRequestToken(string channelId);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelTokenPrivilegeWillExpire(string channelId, string token);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelRtcStats(string channelId, uint duration, uint txBytes, uint rxBytes,
        uint txAudioBytes, uint txVideoBytes, uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate,
        ushort rxKBitRate, ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate,
        ushort txVideoKBitRate, ushort lastmileDelay, ushort txPacketLossRate, ushort rxPacketLossRate, uint userCount,
        double cpuAppUsage, double cpuTotalUsage, int gatewayRtt, double memoryAppUsageRatio,
        double memoryTotalUsageRatio, int memoryAppUsageInKbytes);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelNetworkQuality(string channelId, uint uid, int txQuality, int rxQuality);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelRemoteVideoStats(string channelId, uint uid, int delay, int width, int height,
        int receivedBitrate, int decoderOutputFrameRate, int rendererOutputFrameRate, int packetLossRate,
        int rxStreamType, int totalFrozenTime, int frozenRate, int totalActiveTime);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelRemoteAudioStats(string channelId, uint uid, int quality,
        int networkTransportDelay, int jitterBufferDelay, int audioLossRate, int numChannels, int receivedSampleRate,
        int receivedBitrate, int totalFrozenTime, int frozenRate, int totalActiveTime);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelRemoteAudioStateChanged(string channelId, uint uid, int state, int reason,
        int elapsed);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelActiveSpeaker(string channelId, uint uid);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void
        FUNC_OnChannelVideoSizeChanged(string channelId, uint uid, int width, int height, int rotation);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelRemoteVideoStateChanged(string channelId, uint uid, int state, int reason,
        int elapsed);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void
        FUNC_OnChannelStreamMessage(string channelId, uint uid, int streamId, string data, uint length);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelStreamMessageError(string channelId, uint uid, int streamId, int code,
        int missed, int cached);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelMediaRelayStateChanged2(string channelId, int state, int code);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelMediaRelayEvent2(string channelId, int code);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelRtmpStreamingStateChanged(string channelId, string url, int state, int errCode);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelTranscodingUpdated(string channelId);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelStreamInjectedStatus(string channelId, string url, uint uid, int status);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelRemoteSubscribeFallbackToAudioOnly(string channelId, uint uid,
        int isFallbackOrRecover);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelConnectionStateChanged(string channelId, int state, int reason);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnFacePositionChanged(int imageWidth, int imageHeight, int x, int y, int width,
        int height, int vecDistance, int numFaces);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelLocalPublishFallbackToAudioOnly(string channelId, int isFallbackOrRecover);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnChannelMediaRelayStateChanged(int state, int code);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnChannelMediaRelayEvent(int code);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnChannelTestEnd(string channelId);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnJoinChannelSuccess(string NamelessParameter1, uint uid, int elapsed);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnReJoinChannelSuccess(string NamelessParameter1, uint uid, int elapsed);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnConnectionLost();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnConnectionInterrupted();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnLeaveChannel(uint duration, uint txBytes, uint rxBytes, uint txAudioBytes,
        uint txVideoBytes, uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate, ushort rxKBitRate,
        ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate, ushort txVideoKBitRate,
        ushort lastmileDelay, ushort txPacketLossRate, ushort rxPacketLossRate, uint userCount, double cpuAppUsage,
        double cpuTotalUsage, int gatewayRtt, double memoryAppUsageRatio, double memoryTotalUsageRatio,
        int memoryAppUsageInKbytes);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnRequestToken();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnUserJoined(uint uid, int elapsed);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnUserOffline(uint uid, int offLineReason);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnAudioVolumeIndication(IntPtr uid, IntPtr volume, IntPtr vad, string[] channelId,
        int speakerNumber, int totalVolume);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnUserMuteAudio(uint uid, int muted);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnWarning(int warn, string msg);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnError(int error, string msg);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnRtcStats(uint duration, uint txBytes, uint rxBytes, uint txAudioBytes,
        uint txVideoBytes, uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate, ushort rxKBitRate,
        ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate, ushort txVideoKBitRate,
        ushort lastmileDelay, ushort txPacketLossRate, ushort rxPacketLossRate, uint userCount, double cpuAppUsage,
        double cpuTotalUsage, int gatewayRtt, double memoryAppUsageRatio, double memoryTotalUsageRatio,
        int memoryAppUsageInKbytes);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnAudioMixingFinished();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnAudioRouteChanged(int route);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnFirstRemoteVideoDecoded(uint uid, int width, int height, int elapsed);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnVideoSizeChanged(uint uid, int width, int height, int elapsed);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnClientRoleChanged(int oldRole, int newRole);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnUserMuteVideo(uint uid, int muted);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnMicrophoneEnabled(int isEnabled);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnApiExecuted(int err, string api, string result);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnFirstLocalAudioFrame(int elapsed);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnFirstRemoteAudioFrame(uint userId, int elapsed);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnLastmileQuality(int quality);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnAudioQuality(uint userId, int quality, ushort delay, ushort lost);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnStreamInjectedStatus(string url, uint userId, int status);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnStreamUnpublished(string url);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnStreamPublished(string url, int error);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnStreamMessageError(uint userId, int streamId, int code, int missed, int cached);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnStreamMessage(uint userId, int streamId, string data, uint length);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnConnectionBanned();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnRemoteVideoTransportStats(uint uid, ushort delay, ushort lost, ushort rxKBitRate);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnRemoteAudioTransportStats(uint uid, ushort delay, ushort lost, ushort rxKBitRate);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnTranscodingUpdated();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnAudioDeviceVolumeChanged(int deviceType, int volume, int muted);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnActiveSpeaker(uint userId);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnMediaEngineStartCallSuccess();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnMediaEngineLoadSuccess();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnVideoStopped();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnTokenPrivilegeWillExpire(string token);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnNetworkQuality(uint uid, int txQuality, int rxQuality);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnLocalVideoStats(int sentBitrate, int sentFrameRate, int encoderOutputFrameRate,
        int rendererOutputFrameRate, int targetBitrate, int targetFrameRate, int qualityAdaptIndication,
        int encodedBitrate, int encodedFrameWidth, int encodedFrameHeight, int encodedFrameCount, int codecType);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnRemoteVideoStats(uint uid, int delay, int width, int height, int receivedBitrate,
        int decoderOutputFrameRate, int rendererOutputFrameRate, int packetLossRate, int rxStreamType,
        int totalFrozenTime, int frozenRate, int totalActiveTime);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnRemoteAudioStats(uint uid, int quality, int networkTransportDelay,
        int jitterBufferDelay, int audioLossRate, int numChannels, int receivedSampleRate, int receivedBitrate,
        int totalFrozenTime, int frozenRate, int totalActiveTime);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnLocalAudioStats(int numChannels, int sentSampleRate, int sentBitrate);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnFirstLocalVideoFrame(int width, int height, int elapsed);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnFirstRemoteVideoFrame(uint uid, int width, int height, int elapsed);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnUserEnableVideo(uint uid, int enabled);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnAudioDeviceStateChanged(string deviceId, int deviceType, int deviceState);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnCameraReady();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnCameraFocusAreaChanged(int x, int y, int width, int height);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnCameraExposureAreaChanged(int x, int y, int width, int height);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnRemoteAudioMixingBegin();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnRemoteAudioMixingEnd();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnAudioEffectFinished(int soundId);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnVideoDeviceStateChanged(string deviceId, int deviceType, int deviceState);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnRemoteVideoStateChanged(uint uid, int state, int reason, int elapsed);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnUserEnableLocalVideo(uint uid, int enabled);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnLocalPublishFallbackToAudioOnly(int isFallbackOrRecover);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnRemoteSubscribeFallbackToAudioOnly(uint uid, int isFallbackOrRecover);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnConnectionStateChanged(int state, int reason);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnRtmpStreamingStateChanged(string url, int state, int errCode);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnLocalUserRegistered(uint uid, string userAccount);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_OnUserInfoUpdated(uint uid, uint userUid, string userAccount);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnLocalAudioStateChanged(int state, int error);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnRemoteAudioStateChanged(uint uid, int state, int reason, int elapsed);

    // raw data callback
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnCaptureVideoFrame(int videoFrameType, int width, int height, int yStride,
        IntPtr yBuffer, int rotation, long renderTimeMs);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnRenderVideoFrame(uint uid, int videoFrameType, int width, int height, int yStride,
        IntPtr yBuffer, int rotation, long renderTimeMs);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnRecordAudioFrame(int type, int samples, int bytesPerSample, int channels,
        int samplesPerSec, IntPtr buffer, long renderTimeMs, int avsync_type);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnPlaybackAudioFrame(int type, int samples, int bytesPerSample, int channels,
        int samplesPerSec, IntPtr buffer, long renderTimeMs, int avsync_type);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnMixedAudioFrame(int type, int samples, int bytesPerSample, int channels,
        int samplesPerSec, IntPtr buffer, long renderTimeMs, int avsync_type);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnPlaybackAudioFrameBeforeMixing(uint uid, int type, int samples, int bytesPerSample,
        int channels, int samplesPerSec, IntPtr buffer, long renderTimeMs, int avsync_type);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnPullAudioFrame(int type, int samples, int bytesPerSample, int channels,
        int samplesPerSec, IntPtr buffer, long renderTimeMs, int avsync_type);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnAudioMixingStateChanged(int audioMixingStateType, int audioMixingErrorType);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnFirstRemoteAudioDecoded(uint uid, int elapsed);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnLocalVideoStateChanged(int localVideoState, int error);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnNetworkTypeChanged(int networkType);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnLastmileProbeResult(int state, uint upLinkPacketLossRate, uint upLinkjitter,
        uint upLinkAvailableBandwidth, uint downLinkPacketLossRate, uint downLinkJitter,
        uint downLinkAvailableBandwidth, uint rtt);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int FUNC_OnSendAudioPacket(byte buffer, IntPtr size);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int FUNC_OnSendVideoPacket(byte buffer, IntPtr size);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int FUNC_OnReceiveAudioPacket(IntPtr buffer, IntPtr size);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int FUNC_OnReceiveVideoPacket(IntPtr buffer, IntPtr size);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int FUNC_OnReadyToSendMetadata();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnMetadataReceived(uint uid, uint size, IntPtr buffer, long timeStampMs);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int FUNC_OnGetMaxMetadataSize();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUNC_OnTestEnd();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FUNC_APICaseHandler(int apiType, string paramter);

    internal class AgorartcNative
    {
        /** (Recommended) The standard bitrate set in the \ref IRtcEngine::setVideoEncoderConfiguration "setVideoEncoderConfiguration" method.
	
		 In this mode, the bitrates differ between the live interactive streaming and communication profiles:
		
		 - `COMMUNICATION` profile: The video bitrate is the same as the base bitrate.
		 - `LIVE_BROADCASTING` profile: The video bitrate is twice the base bitrate.
		
		 */
        internal const int STANDARD_BITRATE = 0;

        /** The compatible bitrate set in the \ref IRtcEngine::setVideoEncoderConfiguration "setVideoEncoderConfiguration" method.
	
		 The bitrate remains the same regardless of the channel profile. If you choose this mode in the `LIVE_BROADCASTING` profile, the video frame rate may be lower than the set value.
		 */
        internal const int COMPATIBLE_BITRATE = -1;

        /** Use the default minimum bitrate.
		 */
        internal const int DEFAULT_MIN_BITRATE = -1;

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IRtcEngineBridge_ptr createRtcBridge();

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void release(IRtcEngineBridge_ptr apiBridge, int sync);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IRtcChannelBridge_ptr createChannel(IRtcEngineBridge_ptr apiBridge, string channelId);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void releaseChannel(IRtcChannelBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IAudioPlaybackDeviceManager_ptr createAudioPlaybackDeviceManager(
            IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void releaseAudioPlaybackDeviceManager(IAudioPlaybackDeviceManager_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IAudioRecordingDeviceManager_ptr createAudioRecordingDeviceManager(
            IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void releaseAudioRecordingDeviceManager(IAudioRecordingDeviceManager_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IVideoDeviceManager_ptr createVideoDeviceManager(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void releaseVideoDeviceManager(IVideoDeviceManager_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE initialize(IRtcEngineBridge_ptr apiBridge, string appId, IntPtr context,
            uint areaCode);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void add_C_EventHandler(IRtcEngineBridge_ptr apiBridge, RtcEventHandler handler);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void remove_C_EventHandler(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setChannelProfile(IRtcEngineBridge_ptr apiBridge,
            CHANNEL_PROFILE_TYPE channel_profile_type);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setClientRole(IRtcEngineBridge_ptr apiBridge, CLIENT_ROLE_TYPE role);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE joinChannel(IRtcEngineBridge_ptr apiBridge, string token, string channelId,
            string info, uid_t uid);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE switchChannel(IRtcEngineBridge_ptr apiBridge, string token, string channelId);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE leaveChannel(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE renewToken(IRtcEngineBridge_ptr apiBridge, string token);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE registerLocalUserAccount(IRtcEngineBridge_ptr apiBridge, string appId,
            string userAccount);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE joinChannelWithUserAccount(IRtcEngineBridge_ptr apiBridge, string token,
            string channelId, string userAccount);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE getUserInfoByUserAccount(IRtcEngineBridge_ptr apiBridge, string userAccount,
            ref UserInfo userInfo);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE getUserInfoByUid(IRtcEngineBridge_ptr apiBridge, uid_t uid,
            ref UserInfo userInfo);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE startEchoTest(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE startEchoTest2(IRtcEngineBridge_ptr apiBridge, int intervalInSeconds);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE stopEchoTest(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE enableVideo(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE disableVideo(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setVideoProfile(IRtcEngineBridge_ptr apiBridge, VIDEO_PROFILE_TYPE profile,
            int swapWidthAndHeight);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setVideoEncoderConfiguration(IRtcEngineBridge_ptr apiBridge,
            VideoEncoderConfiguration config);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setCameraCapturerConfiguration(IRtcEngineBridge_ptr apiBridge,
            CameraCapturerConfiguration config);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setupLocalVideo(IRtcEngineBridge_ptr apiBridge, VideoCanvas canvas);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE
            setupRemoteVideo(IRtcEngineBridge_ptr apiBridge, VideoCanvas canvas);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE startPreview(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setRemoteUserPriority(IRtcEngineBridge_ptr apiBridge, uid_t uid,
            PRIORITY_TYPE userPriority);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE stopPreview(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE enableAudio(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE enableLocalAudio(IRtcEngineBridge_ptr apiBridge, int enabled);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE disableAudio(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setAudioProfile(IRtcEngineBridge_ptr apiBridge, AUDIO_PROFILE_TYPE profile,
            AUDIO_SCENARIO_TYPE scenario);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE muteLocalAudioStream(IRtcEngineBridge_ptr apiBridge, int mute);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE muteAllRemoteAudioStreams(IRtcEngineBridge_ptr apiBridge, int mute);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setDefaultMuteAllRemoteVideoStreams(IRtcEngineBridge_ptr apiBridge, int mute);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE adjustUserPlaybackSignalVolume(IRtcEngineBridge_ptr apiBridge, uid_t uid,
            int volume);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE muteRemoteAudioStream(IRtcEngineBridge_ptr apiBridge, uid_t userId, int mute);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE muteLocalVideoStream(IRtcEngineBridge_ptr apiBridge, int mute);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE enableLocalVideo(IRtcEngineBridge_ptr apiBridge, int enabled);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE muteAllRemoteVideoStreams(IRtcEngineBridge_ptr apiBridge, int mute);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setDefaultMuteAllRemoteAudioStreams(IRtcEngineBridge_ptr apiBridge, int mute);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE muteRemoteVideoStream(IRtcEngineBridge_ptr apiBridge, uid_t userId, int mute);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setRemoteVideoStreamType(IRtcEngineBridge_ptr apiBridge, uid_t userId,
            REMOTE_VIDEO_STREAM_TYPE streamType);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setRemoteDefaultVideoStreamType(IRtcEngineBridge_ptr apiBridge,
            REMOTE_VIDEO_STREAM_TYPE streamType);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE enableAudioVolumeIndication(IRtcEngineBridge_ptr apiBridge, int interval,
            int smooth, int report_vad);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE startAudioRecording(IRtcEngineBridge_ptr apiBridge, string filePath,
            AUDIO_RECORDING_QUALITY_TYPE quality);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE startAudioRecording2(IRtcEngineBridge_ptr apiBridge, string filePath,
            int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE stopAudioRecording(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setRemoteVoicePosition(IRtcEngineBridge_ptr apiBridge, uid_t uid, double pan,
            double gain);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setLogFile(IRtcEngineBridge_ptr apiBridge, string file);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setLogFilter(IRtcEngineBridge_ptr apiBridge, uint filter);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setLogFileSize(IRtcEngineBridge_ptr apiBridge, uint fileSizeInKBytes);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setLocalRenderMode(IRtcEngineBridge_ptr apiBridge,
            RENDER_MODE_TYPE renderMode);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setLocalRenderMode2(IRtcEngineBridge_ptr apiBridge,
            RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setRemoteRenderMode(IRtcEngineBridge_ptr apiBridge, uid_t userId,
            RENDER_MODE_TYPE renderMode);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setRemoteRenderMode2(IRtcEngineBridge_ptr apiBridge, uid_t userId,
            RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setLocalVideoMirrorMode(IRtcEngineBridge_ptr apiBridge,
            VIDEO_MIRROR_MODE_TYPE mirrorMode);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE enableDualStreamMode(IRtcEngineBridge_ptr apiBridge, int enabled);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE adjustRecordingSignalVolume(IRtcEngineBridge_ptr apiBridge, int volume);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE adjustPlaybackSignalVolume(IRtcEngineBridge_ptr apiBridge, int volume);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE enableWebSdkInteroperability(IRtcEngineBridge_ptr apiBridge, int enabled);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setVideoQualityParameters(IRtcEngineBridge_ptr apiBridge,
            int preferFrameRateOverImageQuality);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setLocalPublishFallbackOption(IRtcEngineBridge_ptr apiBridge,
            STREAM_FALLBACK_OPTIONS option);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setRemoteSubscribeFallbackOption(IRtcEngineBridge_ptr apiBridge,
            STREAM_FALLBACK_OPTIONS option);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE enableLoopbackRecording(IRtcEngineBridge_ptr apiBridge, int enabled,
            string deviceName);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE startScreenCaptureByScreenRect(IRtcEngineBridge_ptr apiBridge,
            ref Rectangle screenRect, ref Rectangle regionRect, ref ScreenCaptureParameters captureParams);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE
            startScreenCaptureByWindowId(IRtcEngineBridge_ptr apiBridge, view_t windowId, ref Rectangle regionRect,
                ref ScreenCaptureParameters captureParams);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setScreenCaptureContentHint(IRtcEngineBridge_ptr apiBridge,
            VideoContentHint contentHint);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE updateScreenCaptureParameters(IRtcEngineBridge_ptr apiBridge,
            ref ScreenCaptureParameters captureParams);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE updateScreenCaptureRegion(IRtcEngineBridge_ptr apiBridge,
            ref Rectangle regionRect);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE stopScreenCapture(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern string getCallId(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE rate(IRtcEngineBridge_ptr apiBridge, string callId, int rating,
            string description);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE complain(IRtcEngineBridge_ptr apiBridge, string callId, string description);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern string getVersion(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE enableLastmileTest(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE disableLastmileTest(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE startLastmileProbeTest(IRtcEngineBridge_ptr apiBridge,
            LastmileProbeConfig config);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE stopLastmileProbeTest(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern string getErrorDescription(IRtcEngineBridge_ptr apiBridge, int code);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setEncryptionSecret(IRtcEngineBridge_ptr apiBridge, string secret);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setEncryptionMode(IRtcEngineBridge_ptr apiBridge, string encryptionMode);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE createDataStream(IRtcEngineBridge_ptr apiBridge, IntPtr streamId,
            int reliable, int ordered);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE sendStreamMessage(IRtcEngineBridge_ptr apiBridge, int streamId, string data,
            long length);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE addPublishStreamUrl(IRtcEngineBridge_ptr apiBridge, string url,
            int transcodingEnabled);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE removePublishStreamUrl(IRtcEngineBridge_ptr apiBridge, string url);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setLiveTranscoding(IRtcEngineBridge_ptr apiBridge,
            ref LiveTranscoding transcoding);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE addVideoWatermark(IRtcEngineBridge_ptr apiBridge, RtcImage watermark);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE addVideoWatermark2(IRtcEngineBridge_ptr apiBridge, string watermarkUrl,
            WatermarkOptions options);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE clearVideoWatermarks(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setBeautyEffectOptions(IRtcEngineBridge_ptr apiBridge, int enabled,
            BeautyOptions options);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE addInjectStreamUrl(IRtcEngineBridge_ptr apiBridge, string url,
            InjectStreamConfig config);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE startChannelMediaRelay(IRtcEngineBridge_ptr apiBridge,
            ChannelMediaRelayConfiguration configuration);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE updateChannelMediaRelay(IRtcEngineBridge_ptr apiBridge,
            ChannelMediaRelayConfiguration configuration);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE stopChannelMediaRelay(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE removeInjectStreamUrl(IRtcEngineBridge_ptr apiBridge, string url);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CONNECTION_STATE_TYPE getConnectionState(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setParameters(IRtcEngineBridge_ptr apiBridge, string parameters);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setPlaybackDeviceVolume(IRtcEngineBridge_ptr apiBridge, int volume);

        // API_TYPE_AUDIO_EFFECT
        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE startAudioMixing(IRtcEngineBridge_ptr apiBridge, string filePath,
            int loopback, int replace, int cycle);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE stopAudioMixing(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE pauseAudioMixing(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE resumeAudioMixing(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setHighQualityAudioParameters(IRtcEngineBridge_ptr apiBridge, int fullband,
            int stereo, int fullBitrate);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE adjustAudioMixingVolume(IRtcEngineBridge_ptr apiBridge, int volume);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE adjustAudioMixingPlayoutVolume(IRtcEngineBridge_ptr apiBridge, int volume);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE getAudioMixingPlayoutVolume(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE adjustAudioMixingPublishVolume(IRtcEngineBridge_ptr apiBridge, int volume);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE getAudioMixingPublishVolume(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE getAudioMixingDuration(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE getAudioMixingCurrentPosition(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setAudioMixingPosition(IRtcEngineBridge_ptr apiBridge, int pos /*in ms*/);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setAudioMixingPitch(IRtcEngineBridge_ptr apiBridge, int pitch);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE getEffectsVolume(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setEffectsVolume(IRtcEngineBridge_ptr apiBridge, int volume);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setVolumeOfEffect(IRtcEngineBridge_ptr apiBridge, int soundId, int volume);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE playEffect(IRtcEngineBridge_ptr apiBridge, int soundId, string filePath,
            int loopCount, double pitch, double pan, int gain, int publish);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE stopEffect(IRtcEngineBridge_ptr apiBridge, int soundId);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE stopAllEffects(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE preloadEffect(IRtcEngineBridge_ptr apiBridge, int soundId, string filePath);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE unloadEffect(IRtcEngineBridge_ptr apiBridge, int soundId);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE pauseEffect(IRtcEngineBridge_ptr apiBridge, int soundId);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE pauseAllEffects(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE resumeEffect(IRtcEngineBridge_ptr apiBridge, int soundId);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE resumeAllEffects(IRtcEngineBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE enableSoundPositionIndication(IRtcEngineBridge_ptr apiBridge, int enabled);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setLocalVoicePitch(IRtcEngineBridge_ptr apiBridge, double pitch);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setLocalVoiceEqualization(IRtcEngineBridge_ptr apiBridge,
            AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency, int bandGain);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setLocalVoiceReverb(IRtcEngineBridge_ptr apiBridge,
            AUDIO_REVERB_TYPE reverbKey, int value);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setLocalVoiceChanger(IRtcEngineBridge_ptr apiBridge,
            VOICE_CHANGER_PRESET voiceChanger);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setLocalVoiceReverbPreset(IRtcEngineBridge_ptr apiBridge,
            AUDIO_REVERB_PRESET reverbPreset);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setExternalAudioSource(IRtcEngineBridge_ptr apiBridge, int enabled,
            int sampleRate, int channels);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setExternalAudioSink(IRtcEngineBridge_ptr apiBridge, int enabled,
            int sampleRate, int channels);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setRecordingAudioFrameParameters(IRtcEngineBridge_ptr apiBridge,
            int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setPlaybackAudioFrameParameters(IRtcEngineBridge_ptr apiBridge,
            int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setMixedAudioFrameParameters(IRtcEngineBridge_ptr apiBridge, int sampleRate,
            int samplesPerCall);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE pushAudioFrame(IRtcEngineBridge_ptr apiBridge, MEDIA_SOURCE_TYPE type,
            ref AudioFrame frame, int wrap);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE pushAudioFrame2(IRtcEngineBridge_ptr apiBridge, ref AudioFrame frame);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE pullAudioFrame(IRtcEngineBridge_ptr apiBridge, ref AudioFrame frame);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setExternalVideoSource(IRtcEngineBridge_ptr apiBridge, int enable,
            int useTexture);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE pushVideoFrame(IRtcEngineBridge_ptr apiBridge, ref ExternalVideoFrame frame);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE enableEncryption(IRtcEngineBridge_ptr apiBridge, int enabled,
            EncryptionConfig config);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE sendCustomReportMessage(IRtcEngineBridge_ptr apiBridge, string id,
            string category, string event1, string label, int value);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void channel_add_C_ChannelEventHandler(IRtcChannelBridge_ptr apiBridge,
            ChannelEventHandler channelEventHandler);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void channel_remove_C_ChannelEventHandler(IRtcChannelBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_joinChannel(IRtcChannelBridge_ptr apiBridge, string token,
            string info, uid_t uid, ChannelMediaOptions options);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_joinChannelWithUserAccount(IRtcChannelBridge_ptr apiBridge,
            string token, string userAccount, ChannelMediaOptions options);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_leaveChannel(IRtcChannelBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_publish(IRtcChannelBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_unpublish(IRtcChannelBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern string channel_channelId(IRtcChannelBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern string channel_getCallId(IRtcChannelBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_renewToken(IRtcChannelBridge_ptr apiBridge, string token);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_setEncryptionSecret(IRtcChannelBridge_ptr apiBridge, string secret);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_setEncryptionMode(IRtcChannelBridge_ptr apiBridge,
            string encryptionMode);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_setClientRole(IRtcChannelBridge_ptr apiBridge, CLIENT_ROLE_TYPE role);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_setRemoteUserPriority(IRtcChannelBridge_ptr apiBridge, uid_t uid,
            PRIORITY_TYPE userPriority);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_setRemoteVoicePosition(IRtcChannelBridge_ptr apiBridge, uid_t uid,
            double pan, double gain);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_setRemoteRenderMode(IRtcChannelBridge_ptr apiBridge, uid_t userId,
            RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_setDefaultMuteAllRemoteAudioStreams(IRtcChannelBridge_ptr apiBridge,
            int mute);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_setDefaultMuteAllRemoteVideoStreams(IRtcChannelBridge_ptr apiBridge,
            int mute);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_muteAllRemoteAudioStreams(IRtcChannelBridge_ptr apiBridge, int mute);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_adjustUserPlaybackSignalVolume(IRtcChannelBridge_ptr apiBridge,
            uid_t userId, int volume);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_muteRemoteAudioStream(IRtcChannelBridge_ptr apiBridge, uid_t userId,
            int mute);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_muteAllRemoteVideoStreams(IRtcChannelBridge_ptr apiBridge, int mute);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_muteRemoteVideoStream(IRtcChannelBridge_ptr apiBridge, uid_t userId,
            int mute);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_setRemoteVideoStreamType(IRtcChannelBridge_ptr apiBridge,
            uid_t userId, REMOTE_VIDEO_STREAM_TYPE streamType);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_setRemoteDefaultVideoStreamType(IRtcChannelBridge_ptr apiBridge,
            REMOTE_VIDEO_STREAM_TYPE streamType);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_addPublishStreamUrl(IRtcChannelBridge_ptr apiBridge, string url,
            int transcodingEnabled);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_removePublishStreamUrl(IRtcChannelBridge_ptr apiBridge, string url);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_setLiveTranscoding(IRtcChannelBridge_ptr apiBridge,
            ref LiveTranscoding transcoding);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_addInjectStreamUrl(IRtcChannelBridge_ptr apiBridge, string url,
            InjectStreamConfig config);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_removeInjectStreamUrl(IRtcChannelBridge_ptr apiBridge, string url);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_startChannelMediaRelay(IRtcChannelBridge_ptr apiBridge,
            ChannelMediaRelayConfiguration configuration);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_updateChannelMediaRelay(IRtcChannelBridge_ptr apiBridge,
            ChannelMediaRelayConfiguration configuration);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_stopChannelMediaRelay(IRtcChannelBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_createDataStream(IRtcChannelBridge_ptr apiBridge, IntPtr streamId,
            int reliable, int ordered);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE channel_sendStreamMessage(IRtcChannelBridge_ptr apiBridge, int streamId,
            string data, long length);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CONNECTION_STATE_TYPE channel_getConnectionState(IRtcChannelBridge_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int audio_device_getCount(IntPtr apiBridge, DEVICE_TYPE type);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE audio_device_getDevice(IntPtr apiBridge, DEVICE_TYPE type, int index,
            string deviceName, string deviceId);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE audio_device_getCurrentDevice(IntPtr apiBridge, DEVICE_TYPE type,
            string deviceId);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE audio_device_getCurrentDeviceInfo(IntPtr apiBridge, DEVICE_TYPE type,
            string deviceId, string deviceName);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE audio_device_setDevice(IntPtr apiBridge, DEVICE_TYPE type, string deviceId);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE audio_device_setDeviceVolume(IntPtr apiBridge, DEVICE_TYPE type, int volume);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE audio_device_getDeviceVolume(IntPtr apiBridge, DEVICE_TYPE type,
            IntPtr volume);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE audio_device_setDeviceMute(IntPtr apiBridge, DEVICE_TYPE type, int mute);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE audio_device_getDeviceMute(IntPtr apiBridge, DEVICE_TYPE type, IntPtr mute);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE audio_device_startDeviceTest(IntPtr apiBridge, DEVICE_TYPE type,
            string testAudioFilePath, int indicationInterval);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE audio_device_stopDeviceTest(IntPtr apiBridge, DEVICE_TYPE type);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE audio_device_startAudioDeviceLoopbackTest(IntPtr apiBridge, DEVICE_TYPE type,
            int indicationInterval);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE audio_device_stopAudioDeviceLoopbackTest(IntPtr apiBridge, DEVICE_TYPE type);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE startDeviceTest(IVideoDeviceManager_ptr apiBridge, view_t hwnd);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE stopDeviceTest(IVideoDeviceManager_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE setDevice(IVideoDeviceManager_ptr apiBridge, string deviceId);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE getDevice(IVideoDeviceManager_ptr apiBridge, int index, string deviceName,
            string deviceId);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern ERROR_CODE getCurrentDevice(IVideoDeviceManager_ptr apiBridge, string deviceId);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int getDeviceCount(IVideoDeviceManager_ptr apiBridge);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void begin_api_test(string caseFilePath,
            FUNC_APICaseHandler apiCaseHandler);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void compare_and_dump_api_test_result(string caseFilePath, string dumpFilePath,
            FUNC_APICaseHandler apiCaseHandler);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void begin_rtc_engine_event_test(string caseFilePath, RtcEventHandler eventHandler);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void compare_dump_rtc_engine_event_test_result(string caseFilePath, string dumpFilePath,
            RtcEventHandler eventHandler);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void log_engine_event_case(string eventType, string parameter);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void begin_channel_event_test(string caseFilePath, string channelId,
            ChannelEventHandler eventHandler);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void compare_dump_channel_event_test_result(string caseFilePath, string dumpFilePath,
            string channelId, ChannelEventHandler eventHandler);

        [DllImport("agora_cpp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void log_channel_event_case(string eventType, string parameter);
    }
}