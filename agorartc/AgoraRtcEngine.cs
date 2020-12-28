using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace agorartc
{
    using uid_t = UInt32;
    using view_t = IntPtr;
    using IRtcEngineBridge_ptr = IntPtr;

    internal static class NativeRtcEventHandler
    {
        internal static AgoraRtcEngine rtc;

        internal static void OnJoinChannelSuccess(string namelessParameter1, uint uid, int elapsed)
        {
            rtc.engineEventHandler.OnJoinChannelSuccess(namelessParameter1, uid, elapsed);
        }

        internal static void OnReJoinChannelSuccess(string namelessParameter1, uint uid, int elapsed)
        {
            rtc.engineEventHandler.OnReJoinChannelSuccess(namelessParameter1, uid, elapsed);
        }

        internal static void OnConnectionLost()
        {
            rtc.engineEventHandler.OnConnectionLost();
        }

        internal static void OnConnectionInterrupted()
        {
            rtc.engineEventHandler.OnConnectionInterrupted();
        }

        internal static void OnLeaveChannel(uint duration, uint txBytes, uint rxBytes, uint txAudioBytes,
            uint txVideoBytes, uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate, ushort rxKBitRate,
            ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate, ushort txVideoKBitRate,
            ushort lastmileDelay, ushort txPacketLossRate, ushort rxPacketLossRate, uint userCount,
            double cpuAppUsage,
            double cpuTotalUsage, int gatewayRtt, double memoryAppUsageRatio, double memoryTotalUsageRatio,
            int memoryAppUsageInKbytes)
        {
            rtc.engineEventHandler.OnLeaveChannel(duration, txBytes, rxBytes, txAudioBytes, txVideoBytes, rxAudioBytes,
                rxVideoBytes, txKBitRate, rxKBitRate, rxAudioKBitRate, txAudioKBitRate, rxVideoKBitRate,
                txVideoKBitRate, lastmileDelay, txPacketLossRate, rxPacketLossRate, userCount, cpuAppUsage,
                cpuTotalUsage, gatewayRtt, memoryAppUsageRatio, memoryTotalUsageRatio, memoryAppUsageInKbytes);
        }

        internal static void OnRequestToken()
        {
            rtc.engineEventHandler.OnRequestToken();
        }

        internal static void OnUserJoined(uint uid, int elapsed)
        {
            rtc.engineEventHandler.OnUserJoined(uid, elapsed);
        }

        internal static void OnUserOffline(uint uid, int offLineReason)
        {
            rtc.engineEventHandler.OnUserOffline(uid, offLineReason);
        }

        internal static void OnAudioVolumeIndication(IntPtr uid, IntPtr volume, IntPtr vad,
            string[] channelId,
            int speakerNumber, int totalVolume)
        {
            if (speakerNumber <= 0) return;
            var uids = new int[speakerNumber];
            var volumes = new int[speakerNumber];
            var vads = new int[speakerNumber];
            Marshal.Copy(uid, uids, 0, speakerNumber);
            Marshal.Copy(volume, volumes, 0, speakerNumber);
            Marshal.Copy(vad, vads, 0, speakerNumber);

            rtc.engineEventHandler.OnAudioVolumeIndication(uids, volumes, vads, speakerNumber, totalVolume);
        }

        internal static void OnUserMuteAudio(uint uid, int muted)
        {
            rtc.engineEventHandler.OnUserMuteAudio(uid, muted);
        }

        internal static void OnWarning(int warn, string msg)
        {
            rtc.engineEventHandler.OnWarning(warn, msg);
        }

        internal static void OnError(int error, string msg)
        {
            rtc.engineEventHandler.OnError(error, msg);
        }

        internal static void OnRtcStats(uint duration, uint txBytes, uint rxBytes, uint txAudioBytes,
            uint txVideoBytes, uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate, ushort rxKBitRate,
            ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate, ushort txVideoKBitRate,
            ushort lastmileDelay, ushort txPacketLossRate, ushort rxPacketLossRate, uint userCount,
            double cpuAppUsage,
            double cpuTotalUsage, int gatewayRtt, double memoryAppUsageRatio, double memoryTotalUsageRatio,
            int memoryAppUsageInKbytes)
        {
            rtc.engineEventHandler.OnRtcStats(duration, txBytes, rxBytes, txAudioBytes, txVideoBytes, rxAudioBytes,
                rxVideoBytes, txKBitRate, rxKBitRate, rxAudioKBitRate, txAudioKBitRate, rxVideoKBitRate,
                txVideoKBitRate, lastmileDelay, txPacketLossRate, rxPacketLossRate, userCount, cpuAppUsage,
                cpuTotalUsage, gatewayRtt, memoryAppUsageRatio, memoryTotalUsageRatio, memoryAppUsageInKbytes);
        }

        internal static void OnAudioMixingFinished()
        {
            rtc.engineEventHandler.OnAudioMixingFinished();
        }

        internal static void OnAudioRouteChanged(int route)
        {
            rtc.engineEventHandler.OnAudioRouteChanged(route);
        }

        internal static void OnFirstRemoteVideoDecoded(uint uid, int width, int height, int elapsed)
        {
            rtc.engineEventHandler.OnFirstRemoteVideoDecoded(uid, width, height, elapsed);
        }

        internal static void OnVideoSizeChanged(uint uid, int width, int height, int elapsed)
        {
            rtc.engineEventHandler.OnVideoSizeChanged(uid, width, height, elapsed);
        }

        internal static void OnClientRoleChanged(int oldRole, int newRole)
        {
            rtc.engineEventHandler.OnClientRoleChanged(oldRole, newRole);
        }

        internal static void OnUserMuteVideo(uint uid, int muted)
        {
            rtc.engineEventHandler.OnUserMuteVideo(uid, muted);
        }

        internal static void OnMicrophoneEnabled(int isEnabled)
        {
            rtc.engineEventHandler.OnMicrophoneEnabled(isEnabled);
        }

        internal static void OnApiExecuted(int err, string api, string result)
        {
            rtc.engineEventHandler.OnApiExecuted(err, api, result);
        }

        internal static void OnFirstLocalAudioFrame(int elapsed)
        {
            rtc.engineEventHandler.OnFirstLocalAudioFrame(elapsed);
        }

        internal static void OnFirstRemoteAudioFrame(uint userId, int elapsed)
        {
            rtc.engineEventHandler.OnFirstRemoteAudioFrame(userId, elapsed);
        }

        internal static void OnLastmileQuality(int quality)
        {
            rtc.engineEventHandler.OnLastmileQuality(quality);
        }

        internal static void OnAudioQuality(uint userId, int quality, ushort delay, ushort lost)
        {
            rtc.engineEventHandler.OnAudioQuality(userId, quality, delay, lost);
        }

        internal static void OnStreamInjectedStatus(string url, uint userId, int status)
        {
            rtc.engineEventHandler.OnStreamInjectedStatus(url, userId, status);
        }

        internal static void OnStreamUnpublished(string url)
        {
            rtc.engineEventHandler.OnStreamUnpublished(url);
        }

        internal static void OnStreamPublished(string url, int error)
        {
            rtc.engineEventHandler.OnStreamPublished(url, error);
        }

        internal static void OnStreamMessageError(uint userId, int streamId, int code, int missed, int cached)
        {
            rtc.engineEventHandler.OnStreamMessageError(userId, streamId, code, missed, cached);
        }

        internal static void OnStreamMessage(uint userId, int streamId, string data, uint length)
        {
            rtc.engineEventHandler.OnStreamMessage(userId, streamId, data, length);
        }

        internal static void OnConnectionBanned()
        {
            rtc.engineEventHandler.OnConnectionBanned();
        }

        internal static void OnRemoteVideoTransportStats(uint uid, ushort delay, ushort lost,
            ushort rxKBitRate)
        {
            rtc.engineEventHandler.OnRemoteVideoTransportStats(uid, delay, lost, rxKBitRate);
        }

        internal static void OnRemoteAudioTransportStats(uint uid, ushort delay, ushort lost,
            ushort rxKBitRate)
        {
            rtc.engineEventHandler.OnRemoteAudioTransportStats(uid, delay, lost, rxKBitRate);
        }

        internal static void OnTranscodingUpdated()
        {
            rtc.engineEventHandler.OnTranscodingUpdated();
        }

        internal static void OnAudioDeviceVolumeChanged(int deviceType, int volume, int muted)
        {
            rtc.engineEventHandler.OnAudioDeviceVolumeChanged(deviceType, volume, muted);
        }

        internal static void OnActiveSpeaker(uint userId)
        {
            rtc.engineEventHandler.OnActiveSpeaker(userId);
        }

        internal static void OnMediaEngineStartCallSuccess()
        {
            rtc.engineEventHandler.OnMediaEngineStartCallSuccess();
        }

        internal static void OnMediaEngineLoadSuccess()
        {
            rtc.engineEventHandler.OnMediaEngineLoadSuccess();
        }

        internal static void OnVideoStopped()
        {
            rtc.engineEventHandler.OnVideoStopped();
        }

        internal static void OnTokenPrivilegeWillExpire(string token)
        {
            rtc.engineEventHandler.OnTokenPrivilegeWillExpire(token);
        }

        internal static void OnNetworkQuality(uint uid, int txQuality, int rxQuality)
        {
            rtc.engineEventHandler.OnNetworkQuality(uid, txQuality, rxQuality);
        }

        internal static void OnLocalVideoStats(int sentBitrate, int sentFrameRate, int encoderOutputFrameRate,
            int rendererOutputFrameRate, int targetBitrate, int targetFrameRate, int qualityAdaptIndication,
            int encodedBitrate, int encodedFrameWidth, int encodedFrameHeight, int encodedFrameCount,
            int codecType)
        {
            rtc.engineEventHandler.OnLocalVideoStats(sentBitrate, sentFrameRate, encoderOutputFrameRate,
                rendererOutputFrameRate, targetBitrate, targetFrameRate, qualityAdaptIndication, encodedBitrate,
                encodedFrameWidth, encodedFrameHeight, encodedFrameCount, codecType);
        }

        internal static void OnRemoteVideoStats(uint uid, int delay, int width, int height,
            int receivedBitrate, int decoderOutputFrameRate, int rendererOutputFrameRate, int packetLossRate,
            int rxStreamType, int totalFrozenTime, int frozenRate, int totalActiveTime)
        {
            rtc.engineEventHandler.OnRemoteVideoStats(uid, delay, width, height, receivedBitrate,
                decoderOutputFrameRate, rendererOutputFrameRate, packetLossRate, rxStreamType, totalFrozenTime,
                frozenRate, totalActiveTime);
        }

        internal static void OnRemoteAudioStats(uint uid, int quality, int networkTransportDelay,
            int jitterBufferDelay, int audioLossRate, int numChannels, int receivedSampleRate, int receivedBitrate,
            int totalFrozenTime, int frozenRate, int totalActiveTime)
        {
            rtc.engineEventHandler.OnRemoteAudioStats(uid, quality, networkTransportDelay, jitterBufferDelay,
                audioLossRate, numChannels, receivedSampleRate, receivedBitrate, totalFrozenTime, frozenRate,
                totalActiveTime);
        }

        internal static void OnLocalAudioStats(int numChannels, int sentSampleRate, int sentBitrate)
        {
            rtc.engineEventHandler.OnLocalAudioStats(numChannels, sentSampleRate, sentBitrate);
        }

        internal static void OnFirstLocalVideoFrame(int width, int height, int elapsed)
        {
            rtc.engineEventHandler.OnFirstLocalVideoFrame(width, height, elapsed);
        }

        internal static void OnFirstRemoteVideoFrame(uint uid, int width, int height, int elapsed)
        {
            rtc.engineEventHandler.OnFirstRemoteVideoFrame(uid, width, height, elapsed);
        }

        internal static void OnUserEnableVideo(uint uid, int enabled)
        {
            rtc.engineEventHandler.OnUserEnableVideo(uid, enabled);
        }

        internal static void OnAudioDeviceStateChanged(string deviceId, int deviceType, int deviceState)
        {
            rtc.engineEventHandler.OnAudioDeviceStateChanged(deviceId, deviceType, deviceState);
        }

        internal static void OnCameraReady()
        {
            rtc.engineEventHandler.OnCameraReady();
        }

        internal static void OnCameraFocusAreaChanged(int x, int y, int width, int height)
        {
            rtc.engineEventHandler.OnCameraFocusAreaChanged(x, y, width, height);
        }

        internal static void OnCameraExposureAreaChanged(int x, int y, int width, int height)
        {
            rtc.engineEventHandler.OnCameraExposureAreaChanged(x, y, width, height);
        }

        internal static void OnRemoteAudioMixingBegin()
        {
            rtc.engineEventHandler.OnRemoteAudioMixingBegin();
        }

        internal static void OnRemoteAudioMixingEnd()
        {
            rtc.engineEventHandler.OnRemoteAudioMixingEnd();
        }

        internal static void OnAudioEffectFinished(int soundId)
        {
            rtc.engineEventHandler.OnAudioEffectFinished(soundId);
        }

        internal static void OnVideoDeviceStateChanged(string deviceId, int deviceType, int deviceState)
        {
            rtc.engineEventHandler.OnVideoDeviceStateChanged(deviceId, deviceType, deviceState);
        }

        internal static void OnRemoteVideoStateChanged(uint uid, int state, int reason, int elapsed)
        {
            rtc.engineEventHandler.OnRemoteVideoStateChanged(uid, state, reason, elapsed);
        }

        internal static void OnUserEnableLocalVideo(uint uid, int enabled)
        {
            rtc.engineEventHandler.OnUserEnableLocalVideo(uid, enabled);
        }

        internal static void OnLocalPublishFallbackToAudioOnly(int isFallbackOrRecover)
        {
            rtc.engineEventHandler.OnLocalPublishFallbackToAudioOnly(isFallbackOrRecover);
        }

        internal static void OnRemoteSubscribeFallbackToAudioOnly(uint uid, int isFallbackOrRecover)
        {
            rtc.engineEventHandler.OnRemoteSubscribeFallbackToAudioOnly(uid, isFallbackOrRecover);
        }

        internal static void OnConnectionStateChanged(int state, int reason)
        {
            rtc.engineEventHandler.OnConnectionStateChanged(state, reason);
        }

        internal static void OnRtmpStreamingStateChanged(string url, int state, int errCode)
        {
            rtc.engineEventHandler.OnRtmpStreamingStateChanged(url, state, errCode);
        }

        internal static void OnLocalUserRegistered(uint uid, string userAccount)
        {
            rtc.engineEventHandler.OnLocalUserRegistered(uid, userAccount);
        }

        internal static void OnUserInfoUpdated(uint uid, uint userUid, string userAccount)
        {
            rtc.engineEventHandler.OnUserInfoUpdated(uid, userUid, userAccount);
        }

        internal static void OnLocalAudioStateChanged(int state, int error)
        {
            rtc.engineEventHandler.OnLocalAudioStateChanged(state, error);
        }

        internal static void OnRemoteAudioStateChanged(uint uid, int state, int reason, int elapsed)
        {
            rtc.engineEventHandler.OnRemoteAudioStateChanged(uid, state, reason, elapsed);
        }

        internal static void OnAudioMixingStateChanged(int audioMixingStateType, int audioMixingErrorType)
        {
            rtc.engineEventHandler.OnAudioMixingStateChanged(audioMixingStateType, audioMixingErrorType);
        }

        internal static void OnFirstRemoteAudioDecoded(uint uid, int elapsed)
        {
            rtc.engineEventHandler.OnFirstRemoteAudioDecoded(uid, elapsed);
        }

        internal static void OnLocalVideoStateChanged(int localVideoState, int error)
        {
            rtc.engineEventHandler.OnLocalVideoStateChanged(localVideoState, error);
        }

        internal static void OnNetworkTypeChanged(int networkType)
        {
            rtc.engineEventHandler.OnNetworkTypeChanged(networkType);
        }

        internal static void OnLastmileProbeResult(int state, uint upLinkPacketLossRate, uint upLinkjitter,
            uint upLinkAvailableBandwidth, uint downLinkPacketLossRate, uint downLinkJitter,
            uint downLinkAvailableBandwidth, uint rtt)
        {
            rtc.engineEventHandler.OnLastmileProbeResult(state, upLinkPacketLossRate, upLinkjitter,
                upLinkAvailableBandwidth, downLinkPacketLossRate, downLinkJitter, downLinkAvailableBandwidth, rtt);
        }

        internal static void OnChannelMediaRelayStateChanged(int state, int code)
        {
            rtc.engineEventHandler.OnChannelMediaRelayStateChanged(state, code);
        }

        internal static void OnChannelMediaRelayEvent(int code)
        {
            rtc.engineEventHandler.OnChannelMediaRelayEvent(code);
        }

        internal static void OnFacePositionChanged(int imageWidth, int imageHeight, int x, int y, int width,
            int height, int vecDistance, int numFaces)
        {
            rtc.engineEventHandler.OnFacePositionChanged(imageWidth, imageHeight, x, y, width, height, vecDistance,
                numFaces);
        }

        internal static void OnTestEnd()
        {
            rtc.engineEventHandler.OnTestEnd();
        }
    }

    public sealed class AgoraRtcEngine
    {
        private bool _disposed = false;
        private static AgoraRtcEngine _instance;
        private IRtcEngineBridge_ptr _apiBridge = IntPtr.Zero;
        private Dictionary<string, AgoraRtcChannel> _channels = new Dictionary<string, AgoraRtcChannel>();
        internal IRtcEngineEventHandlerBase engineEventHandler;
        private List<IDisposable> _DeviceManagerList = new List<IDisposable>();

        /// <summary>
        /// Releases all IRtcEngine resources.
        /// 
        /// Use this method for apps in which users occasionally make voice or video calls. When users do not make calls, you
        /// can free up resources for other operations. Once you call `release` to destroy the created `IRtcEngine` instance,
        /// you cannot use any method or callback in the SDK any more. If you want to use the real-time communication functions
        /// again, you must call \ref createAgoraRtcEngine "createAgoraRtcEngine" and \ref agora::rtc::IRtcEngine::initialize "initialize"
        /// to create a new `IRtcEngine` instance.
        ///
        /// @note If you want to create a new `IRtcEngine` instance after destroying the current one, ensure that you wait
        /// till the `release` method completes executing.
        /// </summary>
        /// <param name="sync">
        /// - true: Synchronous call. Agora suggests calling this method in a sub-thread to avoid congestion in the main thread
        /// because the synchronous call and the app cannot move on to another task until the execution completes.
        /// Besides, you **cannot** call this method in any method or callback of the SDK. Otherwise, the SDK cannot release the
        /// resources occupied by the `IRtcEngine` instance until the callbacks return results, which may result in a deadlock.
        /// The SDK automatically detects the deadlock and converts this method into an asynchronous call, causing the test to
        /// take additional time.
        /// - false: Asynchronous call. Do not immediately uninstall the SDK's dynamic library after the call, or it may cause
        /// a crash due to the SDK clean-up thread not quitting.
        /// </param>
        public void Dispose(bool sync = false)
        {
            Dispose(true, sync);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing, bool sync)
        {
            if (_disposed) return;

            if (disposing)
            {
                foreach (var (_, value) in _channels)
                {
                    value.Dispose();
                }

                foreach (var value in _DeviceManagerList)
                {
                    value.Dispose();
                }
            }

            Remove_C_EventHandler();
            Release();
            _disposed = true;
        }

        /// <summary>
        /// Add event handler to Rtc Engine instance.
        /// </summary>
        /// 
        /// <param name="eventHandlerBase">
        /// @param eventHandlerBase
        /// An instance of IRtcEngineEventHandlerBase that contains all callback functions in Rtc Engine.
        /// Either can you create an IRtcEngineEventHandlerBase instance or you can rewrite some of the function.
        /// </param>
        public void InitEventHandler(IRtcEngineEventHandlerBase eventHandlerBase)
        {
            engineEventHandler = eventHandlerBase;
            NativeRtcEventHandler.rtc = _instance;
            var myHandler = new RtcEventHandler
            {
                onJoinChannelSuccess = NativeRtcEventHandler.OnJoinChannelSuccess,
                onReJoinChannelSuccess = NativeRtcEventHandler.OnReJoinChannelSuccess,
                onLeaveChannel = NativeRtcEventHandler.OnLeaveChannel,
                onConnectionLost = NativeRtcEventHandler.OnConnectionLost,
                onConnectionInterrupted = NativeRtcEventHandler.OnConnectionInterrupted,
                onRequestToken = NativeRtcEventHandler.OnRequestToken,
                onUserJoined = NativeRtcEventHandler.OnUserJoined,
                onUserOffline = NativeRtcEventHandler.OnUserOffline,
                onAudioVolumeIndication = NativeRtcEventHandler.OnAudioVolumeIndication,
                onUserMuteAudio = NativeRtcEventHandler.OnUserMuteAudio,
                onWarning = NativeRtcEventHandler.OnWarning,
                onError = NativeRtcEventHandler.OnError,
                onRtcStats = NativeRtcEventHandler.OnRtcStats,
                onAudioMixingFinished = NativeRtcEventHandler.OnAudioMixingFinished,
                onAudioRouteChanged = NativeRtcEventHandler.OnAudioRouteChanged,
                onFirstRemoteVideoDecoded = NativeRtcEventHandler.OnFirstRemoteVideoDecoded,
                onVideoSizeChanged = NativeRtcEventHandler.OnVideoSizeChanged,
                onClientRoleChanged = NativeRtcEventHandler.OnClientRoleChanged,
                onUserMuteVideo = NativeRtcEventHandler.OnUserMuteVideo,
                onMicrophoneEnabled = NativeRtcEventHandler.OnMicrophoneEnabled,
                onApiCallExecuted = NativeRtcEventHandler.OnApiExecuted,
                onFirstLocalAudioFrame = NativeRtcEventHandler.OnFirstLocalAudioFrame,
                onFirstRemoteAudioFrame = NativeRtcEventHandler.OnFirstRemoteAudioFrame,
                onLastmileQuality = NativeRtcEventHandler.OnLastmileQuality,
                onAudioQuality = NativeRtcEventHandler.OnAudioQuality,
                onStreamInjectedStatus = NativeRtcEventHandler.OnStreamInjectedStatus,
                onStreamUnpublished = NativeRtcEventHandler.OnStreamUnpublished,
                onStreamPublished = NativeRtcEventHandler.OnStreamPublished,
                onStreamMessageError = NativeRtcEventHandler.OnStreamMessageError,
                onStreamMessage = NativeRtcEventHandler.OnStreamMessage,
                onConnectionBanned = NativeRtcEventHandler.OnConnectionBanned,
                onRemoteVideoTransportStats = NativeRtcEventHandler.OnRemoteVideoTransportStats,
                onRemoteAudioTransportStats = NativeRtcEventHandler.OnRemoteAudioTransportStats,
                onTranscodingUpdated = NativeRtcEventHandler.OnTranscodingUpdated,
                onAudioDeviceVolumeChanged = NativeRtcEventHandler.OnAudioDeviceVolumeChanged,
                onActiveSpeaker = NativeRtcEventHandler.OnActiveSpeaker,
                onMediaEngineStartCallSuccess = NativeRtcEventHandler.OnMediaEngineStartCallSuccess,
                onMediaEngineLoadSuccess = NativeRtcEventHandler.OnMediaEngineLoadSuccess,
                onConnectionStateChanged = NativeRtcEventHandler.OnConnectionStateChanged,
                onRemoteSubscribeFallbackToAudioOnly = NativeRtcEventHandler.OnRemoteSubscribeFallbackToAudioOnly,
                onLocalPublishFallbackToAudioOnly = NativeRtcEventHandler.OnLocalPublishFallbackToAudioOnly,
                onUserEnableLocalVideo = NativeRtcEventHandler.OnUserEnableLocalVideo,
                onRemoteVideoStateChanged = NativeRtcEventHandler.OnRemoteVideoStateChanged,
                onVideoDeviceStateChanged = NativeRtcEventHandler.OnVideoDeviceStateChanged,
                onAudioEffectFinished = NativeRtcEventHandler.OnAudioEffectFinished,
                onRemoteAudioMixingEnd = NativeRtcEventHandler.OnRemoteAudioMixingEnd,
                onRemoteAudioMixingBegin = NativeRtcEventHandler.OnRemoteAudioMixingBegin,
                onCameraExposureAreaChanged = NativeRtcEventHandler.OnCameraExposureAreaChanged,
                onCameraFocusAreaChanged = NativeRtcEventHandler.OnCameraFocusAreaChanged,
                onCameraReady = NativeRtcEventHandler.OnCameraReady,
                onAudioDeviceStateChanged = NativeRtcEventHandler.OnAudioDeviceStateChanged,
                onUserEnableVideo = NativeRtcEventHandler.OnUserEnableVideo,
                onFirstRemoteVideoFrame = NativeRtcEventHandler.OnFirstRemoteVideoFrame,
                onFirstLocalVideoFrame = NativeRtcEventHandler.OnFirstLocalVideoFrame,
                onRemoteAudioStats = NativeRtcEventHandler.OnRemoteAudioStats,
                onRemoteVideoStats = NativeRtcEventHandler.OnRemoteVideoStats,
                onLocalVideoStats = NativeRtcEventHandler.OnLocalVideoStats,
                onNetworkQuality = NativeRtcEventHandler.OnNetworkQuality,
                onTokenPrivilegeWillExpire = NativeRtcEventHandler.OnTokenPrivilegeWillExpire,
                onVideoStopped = NativeRtcEventHandler.OnVideoStopped,
                onAudioMixingStateChanged = NativeRtcEventHandler.OnAudioMixingStateChanged,
                onFirstRemoteAudioDecoded = NativeRtcEventHandler.OnFirstRemoteAudioDecoded,
                onLocalVideoStateChanged = NativeRtcEventHandler.OnLocalVideoStateChanged,
                onNetworkTypeChanged = NativeRtcEventHandler.OnNetworkTypeChanged,
                onRtmpStreamingStateChanged = NativeRtcEventHandler.OnRtmpStreamingStateChanged,
                onLastmileProbeResult = NativeRtcEventHandler.OnLastmileProbeResult,
                onLocalUserRegistered = NativeRtcEventHandler.OnLocalUserRegistered,
                onUserInfoUpdated = NativeRtcEventHandler.OnUserInfoUpdated,
                onLocalAudioStateChanged = NativeRtcEventHandler.OnLocalAudioStateChanged,
                onRemoteAudioStateChanged = NativeRtcEventHandler.OnRemoteAudioStateChanged,
                onLocalAudioStats = NativeRtcEventHandler.OnLocalAudioStats,
                onChannelMediaRelayStateChanged = NativeRtcEventHandler.OnChannelMediaRelayStateChanged,
                onChannelMediaRelayEvent = NativeRtcEventHandler.OnChannelMediaRelayEvent,
                onFacePositionChanged = NativeRtcEventHandler.OnFacePositionChanged,
                onTestEnd = NativeRtcEventHandler.OnTestEnd,
            };
            add_C_EventHandler(myHandler);
        }

        /// <summary>
        /// Create and get an AgoraRtcEngine instance.
        /// </summary>
        /// 
        /// <returns>
        /// @return - A pointer to the AgoraRtcEngine instance, if the method call succeeds.
        ///         - An empty pointer, if the method call fails.
        /// </returns>
        public static AgoraRtcEngine CreateRtcEngine()
        {
            return _instance ??= new AgoraRtcEngine
            {
                _apiBridge = AgorartcNative.createRtcBridge()
            };
        }

        private void Release(bool sync = false)
        {
            AgorartcNative.release(_apiBridge, sync ? 1 : 0);
            engineEventHandler = null;
            _apiBridge = IntPtr.Zero;
        }

        /// <summary>
        /// Creates and gets an AgoraRtcChannel instance.
        /// To join more than one channel, call this method multiple times to create as many AgoraRtcChannel objects as
        /// needed, and call the [joinChannelByToken]([AgoraRtcChannel joinChannelByToken:info:uid:options:]) method of
        /// each created AgoraRtcChannel instance.
        /// 
        /// After joining multiple channels, you can simultaneously subscribe to streams of all the channels, but publish
        /// a stream in only one channel at one time.
        /// </summary>
        /// 
        /// <param name="channelId"></param>
        /// @param channelId
        /// The unique channel name for an Agora RTC session. It must be in the string format and not exceed 64 bytes in
        /// length. Supported character scopes are:
        /// - All lowercase English letters: a to z.
        /// - All uppercase English letters: A to Z.
        /// - All numeric characters: 0 to 9.
        /// - The space character.
        /// - Punctuation characters and other symbols, including: "!", "#", "$", "%", "&amp;", "(", ")", "+", "-", ":", ";",
        /// **Note**
        /// - This parameter does not have a default value. You must set it.
        /// - Do not set it as the empty string "". Otherwise, the SDK returns `AgoraErrorCodeRefused`(-5).
        /// 
        /// <returns>
        /// - A pointer to the AgoraRtcChannel instance, if the method call succeeds.
        /// - An empty pointer, if the method call fails.
        /// - `AgoraErrorCodeRefused`(-5), if you set `channel_id` as the empty string "".
        /// </returns>
        public AgoraRtcChannel CreateRtcChannel(string channelId)
        {
            var channel = new AgoraRtcChannel(AgorartcNative.createChannel(_apiBridge, channelId), channelId);
            NativeRtcChannelEventHandler.AddChannel(channelId, channel);
            _channels[channelId] = channel;
            return channel;
        }

        internal void ReleaseChannel(string channelId)
        {
            _channels.Remove(channelId);
        }

        /// <summary>
        /// Creates and gets an AgoraAudioPlaybackDeviceManager instance.
        /// </summary>
        /// 
        /// <returns>
        /// @return - A pointer to the AgoraAudioPlaybackDeviceManager instance, if the method call succeeds.
        ///         - An empty pointer, if the method call fails.
        /// </returns>
        public AgoraAudioPlaybackDeviceManager CreateAudioPlaybackDeviceManager()
        {
            var playbackDeviceManager =
                new AgoraAudioPlaybackDeviceManager(AgorartcNative.createAudioPlaybackDeviceManager(_apiBridge));
            _DeviceManagerList.Add(playbackDeviceManager);
            return playbackDeviceManager;
        }

        internal void ReleaseAudioPlaybackDeviceManager(AgoraAudioPlaybackDeviceManager playbackDeviceManager)
        {
            _DeviceManagerList.Remove(playbackDeviceManager);
        }

        /// <summary>
        /// Creates and gets an AgoraAudioRecordingDeviceManager instance.
        /// </summary>
        /// 
        /// <returns>
        /// @return - A pointer to the AgoraAudioRecordingDeviceManager instance, if the method call succeeds.
        ///         - An empty pointer, if the method call fails.
        /// </returns>
        public AgoraAudioRecordingDeviceManager CreateAudioRecordingDeviceManager()
        {
            var recordingDeviceManager =
                new AgoraAudioRecordingDeviceManager(AgorartcNative.createAudioRecordingDeviceManager(_apiBridge));
            _DeviceManagerList.Add(recordingDeviceManager);
            return recordingDeviceManager;
        }

        internal void ReleaseAudioRecordingDeviceManager(AgoraAudioRecordingDeviceManager recordingDeviceManager)
        {
            _DeviceManagerList.Remove(recordingDeviceManager);
        }

        /// <summary>
        /// Creates and gets an AgoraVideoDeviceManager instance.
        /// </summary>
        /// 
        /// <returns>
        /// @return - A pointer to the AgoraVideoDeviceManager instance, if the method call succeeds.
        ///         - An empty pointer, if the method call fails.
        /// </returns>
        public AgoraVideoDeviceManager CreateVideoDeviceManager()
        {
            var videoDeviceManager = new AgoraVideoDeviceManager(AgorartcNative.createVideoDeviceManager(_apiBridge));
            _DeviceManagerList.Add(videoDeviceManager);
            return videoDeviceManager;
        }

        internal void ReleaseAgoraVideoDeviceManager(AgoraVideoDeviceManager videoDeviceManager)
        {
            _DeviceManagerList.Remove(videoDeviceManager);
        }

        /// <summary>
        /// Initializes the Agora service.
        ///
        /// Unless otherwise specified, all the methods provided by the IRtcEngine class are executed asynchronously.
        /// Agora recommends calling these methods in the same thread.
        ///
        /// @note Ensure that you call the
        /// \ref agora::rtc::IRtcEngine::createAgoraRtcEngine
        /// "createAgoraRtcEngine" and \ref agora::rtc::IRtcEngine::initialize
        /// "initialize" methods before calling any other APIs.
        /// </summary>
        /// 
        /// <param name="appId">
        /// @param appId
        /// The App ID issued to you by Agora. See How to get the App ID. Only users in apps with the same App ID can
        /// join the same channel and communicate with each other. Use an App ID to create only one IRtcEngine instance.
        /// To change your App ID, call release to destroy the current IRtcEngine instance and then
        /// call createAgoraRtcEngine and initialize to create an IRtcEngine instance with the new App ID.
        /// </param>
        /// 
        /// <param name="areaCode">
        /// @param areaCode
        /// The region for connection. This advanced feature applies to scenarios that have regional restrictions.
        /// For the regions that Agora supports, see AREA_CODE enum. After specifying the region, the SDK connects to the
        /// Agora servers within that region.
        ///
        /// @note The SDK supports specify only one region.
        /// </param>
        /// 
        /// <returns>
        /// - 0(ERR_OK): Success.
        /// - &lt;0: Failure.
        /// - -1(ERR_FAILED): A general error occurs (no specified reason).
        /// - -2(ERR_INALID_ARGUMENT): No `IRtcEngineEventHandler` object is specified.
        /// - -7(ERR_NOT_INITIALIZED): The SDK is not initialized. Check whether `context` is properly set.
        /// - -22(ERR_RESOURCE_LIMITED): The resource is limited. The app uses too much of the system resource and fails
        ///    to allocate any resources.
        /// - -101(ERR_INVALID_APP_ID): The App ID is invalid.
        /// </returns>
        public ERROR_CODE Initialize(string appId, AREA_CODE areaCode)
        {
            return AgorartcNative.initialize(_apiBridge, appId, IntPtr.Zero, (uint) areaCode);
        }

        private void add_C_EventHandler(RtcEventHandler handler)
        {
            AgorartcNative.add_C_EventHandler(_apiBridge, handler);
        }

        private void Remove_C_EventHandler()
        {
            AgorartcNative.remove_C_EventHandler(_apiBridge);
        }

        /// <summary>
        /// Sets the channel profile of the Agora IRtcEngine.
        ///
        /// The Agora IRtcEngine differentiates channel profiles and applies optimization algorithms accordingly.
        /// For example, it prioritizes smoothness and low latency for a video call, and prioritizes video quality for
        /// the live interactive video streaming.
        /// - The default audio route and video encoding bitrate are different in different channel profiles. For details, see
        /// \ref IRtcEngine::setDefaultAudioRouteToSpeakerphone "setDefaultAudioRouteToSpeakerphone" and \ref IRtcEngine::setVideoEncoderConfiguration "setVideoEncoderConfiguration".
        ///
        /// @warning
        /// - To ensure the quality of real-time communication, we recommend that all users in a channel use the same channel profile.
        /// - Call this method before calling \ref IRtcEngine::joinChannel "joinChannel" . You cannot set the channel profile once you have joined the channel.
        /// </summary>
        /// 
        /// <param name="channelProfileType">
        /// @param profile The channel profile of the Agora IRtcEngine. See #CHANNEL_PROFILE_TYPE
        /// </param>
        /// 
        /// <returns>
        /// - 0(ERR_OK): Success.
        /// - &lt;0: Failure.
        /// - -2 (ERR_INVALID_ARGUMENT): The parameter is invalid.
        /// - -7(ERR_NOT_INITIALIZED): The SDK is not initialized.
        /// </returns>
        public ERROR_CODE SetChannelProfile(CHANNEL_PROFILE_TYPE channelProfileType)
        {
            return AgorartcNative.setChannelProfile(_apiBridge, channelProfileType);
        }

        /// <summary>
        /// Sets the channel profile of the Agora IRtcEngine.
        /// The Agora IRtcEngine differentiates channel profiles and applies optimization algorithms accordingly.
        /// For example, it prioritizes smoothness and low latency for a video call, and prioritizes video quality for the live interactive video streaming.
        ///
        /// @warning
        /// - To ensure the quality of real-time communication, we recommend that all users in a channel use the same channel profile.
        /// - Call this method before calling \ref IRtcEngine::joinChannel "joinChannel" . You cannot set the channel profile once you have joined the channel.
        /// - The default audio route and video encoding bitrate are different in different channel profiles. For details, see
        /// \ref IRtcEngine::setDefaultAudioRouteToSpeakerphone "setDefaultAudioRouteToSpeakerphone" and \ref IRtcEngine::setVideoEncoderConfiguration "setVideoEncoderConfiguration".
        ///
        /// </summary>
        /// <param name="role">
        /// @param profile The channel profile of the Agora IRtcEngine. See #CHANNEL_PROFILE_TYPE
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0(ERR_OK): Success.
        /// - &lt;0: Failure.
        ///  - -2 (ERR_INVALID_ARGUMENT): The parameter is invalid.
        ///  - -7(ERR_NOT_INITIALIZED): The SDK is not initialized.
        /// </returns>
        public ERROR_CODE SetClientRole(CLIENT_ROLE_TYPE role)
        {
            return AgorartcNative.setClientRole(_apiBridge, role);
        }

        /// <summary>
        /// Joins a channel with the user ID.
        /// Users in the same channel can talk to each other, and multiple users in the same channel can start a group chat.
        /// Users with different App IDs cannot call each other.
        /// 
        /// You must call the \ref IRtcEngine::leaveChannel "leaveChannel" method to exit the current call before entering another channel.
        ///
        /// A successful \ref agora::rtc::IRtcEngine::joinChannel "joinChannel" method call triggers the following callbacks:
        /// - The local client: \ref agora::rtc::IRtcEngineEventHandler::onJoinChannelSuccess "onJoinChannelSuccess"
        /// - The remote client: \ref agora::rtc::IRtcEngineEventHandler::onUserJoined "onUserJoined" , if the user joining the channel is in the `COMMUNICATION` profile, or is a host in the `LIVE_BROADCASTING` profile.
        ///
        /// When the connection between the client and Agora's server is interrupted due to poor network conditions, the SDK tries reconnecting to the server. When the local client successfully rejoins the channel, the SDK triggers the \ref agora::rtc::IRtcEngineEventHandler::onRejoinChannelSuccess "onRejoinChannelSuccess" callback on the local client.
        ///
        /// @note A channel does not accept duplicate uids, such as two users with the same @p uid. If you set @p uid as 0, the system automatically assigns a @p uid. If you want to join a channel from different devices, ensure that each device has a different uid.
        /// @warning Ensure that the App ID used for creating the token is the same App ID used by the \ref IRtcEngine::initialize "initialize" method for initializing the RTC engine. Otherwise, the CDN live streaming may fail.
        /// </summary>
        /// 
        /// <param name="token">
        /// @param token Pointer to the token generated by the application server. In most circumstances, a static App ID suffices. For added security, use a Channel Key.
        /// - If the user uses a static App ID, *token* is optional and can be set as NULL.
        /// - If the user uses a Channel Key, Agora issues an additional App Certificate for you to generate a user key based on the algorithm and App Certificate for user authentication on the server.
        /// </param>
        /// 
        /// <param name="channelId">
        /// @param channelId Pointer to the unique channel name for the Agora RTC session in the string format smaller than 64 bytes. Supported characters:
        /// - All lowercase English letters: a to z.
        /// - All uppercase English letters: A to Z.
        /// - All numeric characters: 0 to 9.
        /// - The space character.
        /// - Punctuation characters and other symbols, including: "!", "#", "$", "%", "&amp;", "(", ")", "+", "-", ":", ";", "&lt;", "=", ".", ">", "?", "@", "[", "]", "^", "_", " {", "}", "|", "~", ",".
        /// </param>
        /// 
        /// <param name="info">
        /// @param info (Optional) Pointer to additional information about the channel. This parameter can be set to NULL or contain channel related information. Other users in the channel will not receive this message.
        /// </param>
        /// 
        /// <param name="uid">
        /// @param uid (Optional) User ID. A 32-bit unsigned integer with a value ranging from 1 to 2<sup>32</sup>-1. The @p uid must be unique. If a @p uid is not assigned (or set to 0), the SDK assigns and returns a @p uid in the \ref IRtcEngineEventHandler::onJoinChannelSuccess "onJoinChannelSuccess" callback. Your application must record and maintain the returned *uid* since the SDK does not do so.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0(ERR_OK): Success.
        /// - &lt;0: Failure.
        ///    - - 2(ERR_INALID_ARGUMENT): The parameter is invalid.
        ///    - - 3(ERR_NOT_READY): The SDK fails to be initialized. You can try re-initializing the SDK.
        ///    - - 5(ERR_REFUSED): The request is rejected. This may be caused by the following:
        ///    - You have created an IChannel object with the same channel name.
        ///    - You have joined and published a stream in a channel created by the IChannel object.
        /// </returns>
        public ERROR_CODE JoinChannel(string token, string channelId, string info, uint uid)
        {
            return AgorartcNative.joinChannel(_apiBridge, token, channelId, info, uid);
        }

        /// <summary>
        /// Switches to a different channel.
        /// 
        ///  This method allows the audience of a `LIVE_BROADCASTING` channel to switch
        ///  to a different channel.
        /// 
        ///  After the user successfully switches to another channel, the
        ///  \ref agora::rtc::IRtcEngineEventHandler::onLeaveChannel "onLeaveChannel"
        ///   and \ref agora::rtc::IRtcEngineEventHandler::onJoinChannelSuccess
        ///  "onJoinChannelSuccess" callbacks are triggered to indicate that the
        ///  user has left the original channel and joined a new one.
        /// 
        ///  @note
        ///  This method applies to the audience role in a `LIVE_BROADCASTING` channel
        ///  only.
        /// </summary>
        /// 
        /// <param name="token">
        /// @param token The token generated at your server:
        ///  - For low-security requirements: You can use the temporary token
        ///  generated in Console. For details, see
        ///  [Get a temporary token](https://docs.agora.io/en/Agora%20Platform/token?platfor%20*%20m=All%20Platforms#get-a-temporary-token).
        ///  - For high-security requirements: Use the token generated at your
        ///  server. For details, see
        ///  [Get a token](https://docs.agora.io/en/Agora%20Platform/token?platfor%20*%20m=All%20Platforms#get-a-token).
        /// </param>
        /// 
        /// <param name="channelId">
        /// @param channelId Unique channel name for the AgoraRTC session in the
        ///  string format. The string length must be less than 64 bytes. Supported
        ///  character scopes are:
        ///  - All lowercase English letters: a to z.
        ///  - All uppercase English letters: A to Z.
        ///  - All numeric characters: 0 to 9.
        ///  - The space character.
        ///  - Punctuation characters and other symbols, including: "!", "#", "$", "%", "&amp;", "(", ")", "+", "-", ":", ";", "&lt;", "=", ".", ">", "?", "@", "[", "]", "^", "_", " {", "}", "|", "~", ",".
        /// </param>
        /// 
        /// <returns>
        /// @return
        ///  - 0(ERR_OK): Success.
        ///  - &lt;0: Failure.
        ///   - -1(ERR_FAILED): A general error occurs (no specified reason).
        ///   - -2(ERR_INALID_ARGUMENT): The parameter is invalid.
        ///   - -5(ERR_REFUSED): The request is rejected, probably because the user is not an audience.
        ///   - -7(ERR_NOT_INITIALIZED): The SDK is not initialized.
        ///   - -102(ERR_INVALID_CHANNEL_NAME): The channel name is invalid.
        ///   - -113(ERR_NOT_IN_CHANNEL): The user is not in the channel.
        /// </returns>
        public ERROR_CODE SwitchChannel(string token, string channelId)
        {
            return AgorartcNative.switchChannel(_apiBridge, token, channelId);
        }

        /// <summary>
        /// Allows a user to leave a channel, such as hanging up or exiting a call.
        /// After joining a channel, the user must call the *leaveChannel* method to end the call before joining another channel.
        /// This method returns 0 if the user leaves the channel and releases all resources related to the call.
        /// This method call is asynchronous, and the user has not left the channel when the method call returns. Once the user leaves the channel, the SDK triggers the \ref IRtcEngineEventHandler::onLeaveChannel "onLeaveChannel" callback.
        /// A successful \ref agora::rtc::IRtcEngine::leaveChannel "leaveChannel" method call triggers the following callbacks:
        /// - The local client: \ref agora::rtc::IRtcEngineEventHandler::onLeaveChannel "onLeaveChannel"
        /// - The remote client: \ref agora::rtc::IRtcEngineEventHandler::onUserOffline "onUserOffline" , if the user leaving the channel is in the `COMMUNICATION` channel, or is a host in the `LIVE_BROADCASTING` profile.
        /// @note
        /// - If you call the \ref IRtcEngine::release "release" method immediately after the *leaveChannel* method, the *leaveChannel* process interrupts, and the \ref IRtcEngineEventHandler::onLeaveChannel "onLeaveChannel" callback is not triggered.
        /// - If you call the *leaveChannel* method during a CDN live streaming, the SDK triggers the \ref IRtcEngine::removePublishStreamUrl "removePublishStreamUrl" method.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0(ERR_OK): Success.
        /// - &lt;0: Failure.
        ///    - -1(ERR_FAILED): A general error occurs (no specified reason).
        ///    - -2(ERR_INALID_ARGUMENT): The parameter is invalid.
        ///    - -7(ERR_NOT_INITIALIZED): The SDK is not initialized.
        /// </returns>
        public ERROR_CODE LeaveChannel()
        {
            return AgorartcNative.leaveChannel(_apiBridge);
        }

        /// <summary>
        /// Gets a new token when the current token expires after a period of time.
        ///
        /// The `token` expires after a period of time once the token schema is enabled when:
        ///
        /// - The SDK triggers the \ref IRtcEngineEventHandler::onTokenPrivilegeWillExpire "onTokenPrivilegeWillExpire" callback, or
        /// - The \ref IRtcEngineEventHandler::onConnectionStateChanged "onConnectionStateChanged" reports CONNECTION_CHANGED_TOKEN_EXPIRED(9).
        ///
        /// The application should call this method to get the new `token`. Failure to do so will result in the SDK disconnecting from the server.
        /// </summary>
        /// 
        /// <param name="token">
        /// @param token Pointer to the new token.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0(ERR_OK): Success.
        /// - &lt;0: Failure.
        ///    - -1(ERR_FAILED): A general error occurs (no specified reason).
        ///    - -2(ERR_INALID_ARGUMENT): The parameter is invalid.
        ///    - -7(ERR_NOT_INITIALIZED): The SDK is not initialized.
        /// </returns>
        public ERROR_CODE RenewToken(string token)
        {
            return AgorartcNative.renewToken(_apiBridge, token);
        }

        /// <summary>
        /// Registers a user account.
        /// Once registered, the user account can be used to identify the local user when the user joins the channel.
        /// After the user successfully registers a user account, the SDK triggers the \ref agora::rtc::IRtcEngineEventHandler::onLocalUserRegistered "onLocalUserRegistered" callback on the local client,
        /// reporting the user ID and user account of the local user.
        ///
        /// To join a channel with a user account, you can choose either of the following:
        ///
        /// - Call the \ref agora::rtc::IRtcEngine::registerLocalUserAccount "registerLocalUserAccount" method to create a user account, and then the \ref agora::rtc::IRtcEngine::joinChannelWithUserAccount "joinChannelWithUserAccount" method to join the channel.
        /// - Call the \ref agora::rtc::IRtcEngine::joinChannelWithUserAccount "joinChannelWithUserAccount" method to join the channel.
        ///
        /// The difference between the two is that for the former, the time elapsed between calling the \ref agora::rtc::IRtcEngine::joinChannelWithUserAccount "joinChannelWithUserAccount" method
        /// and joining the channel is shorter than the latter.
        ///
        /// @note
        /// - Ensure that you set the `userAccount` parameter. Otherwise, this method does not take effect.
        /// - Ensure that the value of the `userAccount` parameter is unique in the channel.
        /// - To ensure smooth communication, use the same parameter type to identify the user. For example, if a user joins the channel with a user ID, then ensure all the other users use the user ID too. The same applies to the user account. If a user joins the channel with the Agora Web SDK, ensure that the uid of the user is set to the same parameter type.
        /// </summary>
        /// 
        /// <param name="appId">
        /// @param appId The App ID of your project.
        /// </param>
        /// 
        /// <param name="userAccount">
        /// @param userAccount The user account. The maximum length of this parameter is 255 bytes. Ensure that you set this parameter and do not set it as null. Supported character scopes are:
        /// - All lowercase English letters: a to z.
        /// - All uppercase English letters: A to Z.
        /// - All numeric characters: 0 to 9.
        /// - The space character.
        /// - Punctuation characters and other symbols, including: "!", "#", "$", "%", "&amp;", "(", ")", "+", "-", ":", ";", "&lt;", "=", ".", ">", "?", "@", "[", "]", "^", "_", " {", "}", "|", "~", ",".
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE RegisterLocalUserAccount(string appId, string userAccount)
        {
            return AgorartcNative.registerLocalUserAccount(_apiBridge, appId, userAccount);
        }

        /// <summary>
        /// Joins the channel with a user account.
        ///
        /// After the user successfully joins the channel, the SDK triggers the following callbacks:
        ///
        /// - The local client: \ref agora::rtc::IRtcEngineEventHandler::onLocalUserRegistered "onLocalUserRegistered" and \ref agora::rtc::IRtcEngineEventHandler::onJoinChannelSuccess "onJoinChannelSuccess" .
        /// The remote client: \ref agora::rtc::IRtcEngineEventHandler::onUserJoined "onUserJoined" and \ref agora::rtc::IRtcEngineEventHandler::onUserInfoUpdated "onUserInfoUpdated" , if the user joining the channel is in the `COMMUNICATION` profile, or is a host in the `LIVE_BROADCASTING` profile.
        ///
        /// @note To ensure smooth communication, use the same parameter type to identify the user. For example, if a user joins the channel with a user ID, then ensure all the other users use the user ID too. The same applies to the user account.
        /// If a user joins the channel with the Agora Web SDK, ensure that the uid of the user is set to the same parameter type.
        /// </summary>
        /// 
        /// <param name="token">
        /// @param token The token generated at your server:
        /// - For low-security requirements: You can use the temporary token generated at Console. For details, see [Get a temporary toke](https://docs.agora.io/en/Voice/token?platform=All%20Platforms#get-a-temporary-token).
        /// - For high-security requirements: Set it as the token generated at your server. For details, see [Get a token](https://docs.agora.io/en/Voice/token?platform=All%20Platforms#get-a-token).
        /// </param>
        /// 
        /// <param name="channelId">
        /// @param channelId The channel name. The maximum length of this parameter is 64 bytes. Supported character scopes are:
        /// - All lowercase English letters: a to z.
        /// - All uppercase English letters: A to Z.
        /// - All numeric characters: 0 to 9.
        /// - The space character.
        /// - Punctuation characters and other symbols, including: "!", "#", "$", "%", "&amp;", "(", ")", "+", "-", ":", ";", "&lt;", "=", ".", ">", "?", "@", "[", "]", "^", "_", " {", "}", "|", "~", ",".
        /// </param>
        /// 
        /// <param name="userAccount">
        /// @param userAccount The user account. The maximum length of this parameter is 255 bytes. Ensure that you set this parameter and do not set it as null. Supported character scopes are:
        /// - All lowercase English letters: a to z.
        /// - All uppercase English letters: A to Z.
        /// - All numeric characters: 0 to 9.
        /// - The space character.
        /// - Punctuation characters and other symbols, including: "!", "#", "$", "%", "&amp;", "(", ")", "+", "-", ":", ";", "&lt;", "=", ".", ">", "?", "@", "[", "]", "^", "_", " {", "}", "|", "~", ",".
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        ///    - #ERR_INVALID_ARGUMENT (-2)
        ///    - #ERR_NOT_READY (-3)
        ///    - #ERR_REFUSED (-5)
        /// </returns>
        public ERROR_CODE JoinChannelWithUserAccount(string token, string channelId, string userAccount)
        {
            return AgorartcNative.joinChannelWithUserAccount(_apiBridge, token, channelId, userAccount);
        }

        /// <summary>
        /// Gets the user information by passing in the user account.
        ///
        /// After a remote user joins the channel, the SDK gets the user ID and user account of the remote user, caches them
        /// in a mapping table object (`userInfo`), and triggers the \ref agora::rtc::IRtcEngineEventHandler::onUserInfoUpdated "onUserInfoUpdated" callback on the local client.
        ///
        /// After receiving the o\ref agora::rtc::IRtcEngineEventHandler::onUserInfoUpdated "onUserInfoUpdated" callback, you can call this method to get the user ID of the
        /// remote user from the `userInfo` object by passing in the user account.
        ///
        /// @param userAccount The user account of the user. Ensure that you set this parameter.
        /// @param [in,out] userInfo  A userInfo object that identifies the user:
        /// - Input: A userInfo object.
        /// - Output: A userInfo object that contains the user account and user ID of the user.
        /// </summary>
        /// 
        /// <param name="userAccount">
        /// @param userAccount The user account of the user. Ensure that you set this parameter.
        /// </param>
        /// 
        /// <param name="userInfo">
        /// @param [in,out] userInfo  A userInfo object that identifies the user:
        /// - Input: A userInfo object.
        /// - Output: A userInfo object that contains the user account and user ID of the user.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE GetUserInfoByUserAccount(string userAccount, ref UserInfo userInfo)
        {
            return AgorartcNative.getUserInfoByUserAccount(_apiBridge, userAccount, ref userInfo);
        }

        /// <summary>
        /// Gets the user information by passing in the user ID.
        ///
        /// After a remote user joins the channel, the SDK gets the user ID and user account of the remote user,
        /// caches them in a mapping table object (`userInfo`), and triggers the \ref agora::rtc::IRtcEngineEventHandler::onUserInfoUpdated "onUserInfoUpdated" callback on the local client.
        ///
        /// After receiving the \ref agora::rtc::IRtcEngineEventHandler::onUserInfoUpdated "onUserInfoUpdated" callback, you can call this method to get the user account of the remote user
        /// from the `userInfo` object by passing in the user ID.
        /// </summary>
        /// 
        /// <param name="uid">
        /// @param uid The user ID of the remote user. Ensure that you set this parameter.
        /// </param>
        /// 
        /// <param name="userInfo">
        /// @param[in,out] userInfo A userInfo object that identifies the user:
        /// - Input: A userInfo object.
        /// - Output: A userInfo object that contains the user account and user ID of the user.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE GetUserInfoByUid(uid_t uid, ref UserInfo userInfo)
        {
            return AgorartcNative.getUserInfoByUid(_apiBridge, uid, ref userInfo);
        }

        /// <summary>
        /// **DEPRECATED** Starts an audio call test.
        ///
        /// This method is deprecated as of v2.4.0.
        ///
        /// This method starts an audio call test to check whether the audio devices (for example, headset and speaker) and the network connection are working properly.
        ///
        /// To conduct the test:
        ///
        /// - The user speaks and the recording is played back within 10 seconds.
        /// - If the user can hear the recording within 10 seconds, the audio devices and network connection are working properly.
        ///
        /// @note
        /// - After calling this method, always call the \ref IRtcEngine::stopEchoTest "stopEchoTest" method to end the test. Otherwise, the application cannot run the next echo test.
        /// - In the `LIVE_BROADCASTING` profile, only the hosts can call this method. If the user switches from the `COMMUNICATION` to`LIVE_BROADCASTING` profile, the user must call the \ref IRtcEngine::setClientRole "setClientRole" method to change the user role from the audience (default) to the host before calling this method.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StartEchoTest()
        {
            return AgorartcNative.startEchoTest(_apiBridge);
        }

        /// <summary>
        /// Starts an audio call test.
        ///
        /// This method starts an audio call test to determine whether the audio devices (for example, headset and speaker) and the network connection are working properly.
        ///
        /// In the audio call test, you record your voice. If the recording plays back within the set time interval, the audio devices and the network connection are working properly.
        ///
        /// @note
        /// - Call this method before joining a channel.
        /// - After calling this method, call the \ref IRtcEngine::stopEchoTest "stopEchoTest" method to end the test. Otherwise, the app cannot run the next echo test, or call the \ref IRtcEngine::joinChannel "joinChannel" method.
        /// - In the `LIVE_BROADCASTING` profile, only a host can call this method.
        /// </summary>
        /// 
        /// <param name="intervalInSeconds">
        /// @param intervalInSeconds The time interval (s) between when you speak and when the recording plays back.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StartEchoTest2(int intervalInSeconds)
        {
            return AgorartcNative.startEchoTest2(_apiBridge, intervalInSeconds);
        }

        /// <summary>
        /// Stops the audio call test.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StopEchoTest()
        {
            return AgorartcNative.stopEchoTest(_apiBridge);
        }

        /// <summary>
        /// Enables the video module.
        ///
        /// Call this method either before joining a channel or during a call. If this method is called before joining a channel, the call starts in the video mode. If this method is called during an audio call, the audio mode switches to the video mode. To disable the video module, call the \ref IRtcEngine::disableVideo "disableVideo" method.
        ///
        /// A successful \ref agora::rtc::IRtcEngine::enableVideo "enableVideo" method call triggers the \ref agora::rtc::IRtcEngineEventHandler::onUserEnableVideo "onUserEnableVideo" (true) callback on the remote client.
        /// @note
        /// - This method affects the internal engine and can be called after the \ref agora::rtc::IRtcEngine::leaveChannel "leaveChannel" method.
        /// - This method resets the internal engine and takes some time to take effect. We recommend using the following API methods to control the video engine modules separately:
        /// - \ref IRtcEngine::enableLocalVideo "enableLocalVideo": Whether to enable the camera to create the local video stream.
        /// - \ref IRtcEngine::muteLocalVideoStream "muteLocalVideoStream": Whether to publish the local video stream.
        /// - \ref IRtcEngine::muteRemoteVideoStream "muteRemoteVideoStream": Whether to subscribe to and play the remote video stream.
        /// - \ref IRtcEngine::muteAllRemoteVideoStreams "muteAllRemoteVideoStreams": Whether to subscribe to and play all remote video streams.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE EnableVideo()
        {
            return AgorartcNative.enableVideo(_apiBridge);
        }

        /// <summary>
        /// Disables the video module.
        ///
        /// This method can be called before joining a channel or during a call. If this method is called before joining a channel, the call starts in audio mode. If this method is called during a video call, the video mode switches to the audio mode. To enable the video module, call the \ref IRtcEngine::enableVideo "enableVideo" method.
        ///
        /// A successful \ref agora::rtc::IRtcEngine::disableVideo "disableVideo" method call triggers the \ref agora::rtc::IRtcEngineEventHandler::onUserEnableVideo "onUserEnableVideo" (false) callback on the remote client.
        /// @note
        /// - This method affects the internal engine and can be called after the \ref agora::rtc::IRtcEngine::leaveChannel "leaveChannel" method.
        /// - This method resets the internal engine and takes some time to take effect. We recommend using the following API methods to control the video engine modules separately:
        ///     - \ref IRtcEngine::enableLocalVideo "enableLocalVideo": Whether to enable the camera to create the local video stream.
        ///     - \ref IRtcEngine::muteLocalVideoStream "muteLocalVideoStream": Whether to publish the local video stream.
        ///     - \ref IRtcEngine::muteRemoteVideoStream "muteRemoteVideoStream": Whether to subscribe to and play the remote video stream.
        ///     - \ref IRtcEngine::muteAllRemoteVideoStreams "muteAllRemoteVideoStreams": Whether to subscribe to and play all remote video streams.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE DisableVideo()
        {
            return AgorartcNative.disableVideo(_apiBridge);
        }

        /// <summary>
        /// **DEPRECATED** Sets the video profile.
        ///
        /// This method is deprecated as of v2.3. Use the \ref IRtcEngine::setVideoEncoderConfiguration "setVideoEncoderConfiguration" method instead.
        ///
        /// Each video profile includes a set of parameters, such as the resolution, frame rate, and bitrate. If the camera device does not support the specified resolution, the SDK automatically chooses a suitable camera resolution, keeping the encoder resolution specified by the *setVideoProfile* method.
        ///
        /// @note
        /// - If you do not need to set the video profile after joining the channel, call this method before the \ref IRtcEngine::enableVideo "enableVideo" method to reduce the render time of the first video frame.
        /// - Always set the video profile before calling the \ref IRtcEngine::joinChannel "joinChannel" or \ref IRtcEngine::startPreview "startPreview" method.
        /// </summary>
        /// 
        /// <param name="profile">
        /// @param profile Sets the video profile. See #VIDEO_PROFILE_TYPE.
        /// </param>
        /// 
        /// <param name="swapWidthAndHeight">
        /// @param swapWidthAndHeight Sets whether to swap the width and height of the video stream:
        /// - true: Swap the width and height.
        /// - false: (Default) Do not swap the width and height.
        /// The width and height of the output video are consistent with the set video profile.
        /// @note Since the landscape or portrait mode of the output video can be decided directly by the video profile, We recommend setting *swapWidthAndHeight* to *false* (default).
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetVideoProfile(VIDEO_PROFILE_TYPE profile, bool swapWidthAndHeight)
        {
            return AgorartcNative.setVideoProfile(_apiBridge, profile, swapWidthAndHeight ? 1 : 0);
        }

        /// <summary>
        /// Sets the video encoder configuration.
        ///
        /// Each video encoder configuration corresponds to a set of video parameters, including the resolution, frame rate, bitrate, and video orientation.
        ///
        /// The parameters specified in this method are the maximum values under ideal network conditions. If the video engine cannot render the video using the specified parameters due to poor network conditions, the parameters further down the list are considered until a successful configuration is found.
        ///
        /// @note If you do not need to set the video encoder configuration after joining the channel, you can call this method before the \ref IRtcEngine::enableVideo "enableVideo" method to reduce the render time of the first video frame.
        /// </summary>
        /// 
        /// <param name="config">
        /// @param config Sets the local video encoder configuration. See VideoEncoderConfiguration.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetVideoEncoderConfiguration(VideoEncoderConfiguration config)
        {
            return AgorartcNative.setVideoEncoderConfiguration(_apiBridge, config);
        }

        /// <summary>
        /// Sets the camera capture configuration.
        ///
        /// For a video call or the live interactive video streaming, generally the SDK controls the camera output parameters. When the default camera capturer settings do not meet special requirements or cause performance problems, we recommend using this method to set the camera capturer configuration:
        ///
        /// - If the resolution or frame rate of the captured raw video data are higher than those set by \ref IRtcEngine::setVideoEncoderConfiguration "setVideoEncoderConfiguration", processing video frames requires extra CPU and RAM usage and degrades performance. We recommend setting config as CAPTURER_OUTPUT_PREFERENCE_PERFORMANCE = 1 to avoid such problems.
        /// - If you do not need local video preview or are willing to sacrifice preview quality, we recommend setting config as CAPTURER_OUTPUT_PREFERENCE_PERFORMANCE = 1 to optimize CPU and RAM usage.
        /// - If you want better quality for the local video preview, we recommend setting config as CAPTURER_OUTPUT_PREFERENCE_PREVIEW = 2.
        ///
        /// @note Call this method before enabling the local camera. That said, you can call this method before calling \ref agora::rtc::IRtcEngine::joinChannel "joinChannel", \ref agora::rtc::IRtcEngine::enableVideo "enableVideo", or \ref IRtcEngine::enableLocalVideo "enableLocalVideo", depending on which method you use to turn on your local camera.
        /// </summary>
        /// 
        /// <param name="config">
        /// @param config Sets the camera capturer configuration. See CameraCapturerConfiguration.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetCameraCapturerConfiguration(CameraCapturerConfiguration config)
        {
            return AgorartcNative.setCameraCapturerConfiguration(_apiBridge, config);
        }

        /// <summary>
        /// Initializes the local video view.
        ///
        /// This method initializes the video view of a local stream on the local device. It affects only the video view that the local user sees, not the published local video stream.
        ///
        /// Call this method to bind the local video stream to a video view and to set the rendering and mirror modes of the video view.
        /// The binding is still valid after the user leaves the channel, which means that the window still displays. To unbind the view, set the *view* in VideoCanvas to NULL.
        ///
        /// @note
        /// - Call this method before joining a channel.
        /// - During a call, you can call this method as many times as necessary to update the display mode of the local video view.
        /// </summary>
        /// 
        /// <param name="canvas">
        /// @param canvas Pointer to the local video view and settings. See VideoCanvas.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetupLocalVideo(VideoCanvas canvas)
        {
            return AgorartcNative.setupLocalVideo(_apiBridge, canvas);
        }

        /// <summary>
        /// Initializes the video view of a remote user.
        ///
        /// This method initializes the video view of a remote stream on the local device. It affects only the video view that the local user sees.
        ///
        /// Call this method to bind the remote video stream to a video view and to set the rendering and mirror modes of the video view.
        ///
        /// The application specifies the uid of the remote video in this method before the remote user joins the channel. If the remote uid is unknown to the application, set it after the application receives the \ref IRtcEngineEventHandler::onUserJoined "onUserJoined" callback.
        /// If the Video Recording function is enabled, the Video Recording Service joins the channel as a dummy client, causing other clients to also receive the \ref IRtcEngineEventHandler::onUserJoined "onUserJoined" callback. Do not bind the dummy client to the application view because the dummy client does not send any video streams. If your application does not recognize the dummy client, bind the remote user to the view when the SDK triggers the \ref IRtcEngineEventHandler::onFirstRemoteVideoDecoded "onFirstRemoteVideoDecoded" callback.
        /// To unbind the remote user from the view, set the view in VideoCanvas to NULL. Once the remote user leaves the channel, the SDK unbinds the remote user.
        ///
        /// @note To update the rendering or mirror mode of the remote video view during a call, use the \ref IRtcEngine::setRemoteRenderMode "setRemoteRenderMode" method.
        /// </summary>
        /// 
        /// <param name="canvas">
        /// @param canvas Pointer to the remote video view and settings. See VideoCanvas.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetupRemoteVideo(VideoCanvas canvas)
        {
            return AgorartcNative.setupRemoteVideo(_apiBridge, canvas);
        }

        /// <summary>
        /// Starts the local video preview before joining the channel.
        ///
        /// Before calling this method, you must:
        ///
        /// - Call the \ref IRtcEngine::setupLocalVideo "setupLocalVideo" method to set up the local preview window and configure the attributes.
        /// - Call the \ref IRtcEngine::enableVideo "enableVideo" method to enable video.
        ///
        /// @note Once the startPreview method is called to start the local video preview, if you leave the channel by calling the \ref IRtcEngine::leaveChannel "leaveChannel" method, the local video preview remains until you call the \ref IRtcEngine::stopPreview "stopPreview" method to disable it.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StartPreview()
        {
            return AgorartcNative.startPreview(_apiBridge);
        }

        /// <summary>
        /// Prioritizes a remote user's stream.
        ///
        /// Use this method with the \ref IRtcEngine::setRemoteSubscribeFallbackOption "setRemoteSubscribeFallbackOption" method. If the fallback function is enabled for a subscribed stream, the SDK ensures the high-priority user gets the best possible stream quality.
        ///
        /// @note The Agora SDK supports setting @p userPriority as high for one user only.
        /// </summary>
        /// 
        /// <param name="uid">
        /// @param  uid  The ID of the remote user.
        /// </param>
        /// 
        /// <param name="userPriority">
        /// @param  userPriority Sets the priority of the remote user. See #PRIORITY_TYPE.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetRemoteUserPriority(uid_t uid, PRIORITY_TYPE userPriority)
        {
            return AgorartcNative.setRemoteUserPriority(_apiBridge, uid, userPriority);
        }

        /// <summary>
        /// Stops the local video preview and disables video.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StopPreview()
        {
            return AgorartcNative.stopPreview(_apiBridge);
        }

        /// <summary>
        /// ///  Enables the audio module.
        ///
        /// The audio mode is enabled by default.
        ///
        /// @note
        /// - This method affects the internal engine and can be called after the \ref agora::rtc::IRtcEngine::leaveChannel "leaveChannel" method. You can call this method either before or after joining a channel.
        /// - This method resets the internal engine and takes some time to take effect. We recommend using the following API methods to control the audio engine modules separately:
        /// - \ref IRtcEngine::enableLocalAudio "enableLocalAudio": Whether to enable the microphone to create the local audio stream.
        /// - \ref IRtcEngine::muteLocalAudioStream "muteLocalAudioStream": Whether to publish the local audio stream.
        /// - \ref IRtcEngine::muteRemoteAudioStream "muteRemoteAudioStream": Whether to subscribe to and play the remote audio stream.
        /// - \ref IRtcEngine::muteAllRemoteAudioStreams "muteAllRemoteAudioStreams": Whether to subscribe to and play all remote audio streams.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE EnableAudio()
        {
            return AgorartcNative.enableAudio(_apiBridge);
        }

        /// <summary>
        /// Disables/Re-enables the local audio function.
        ///
        /// The audio function is enabled by default. This method disables or re-enables the local audio function, that is, to stop or restart local audio capturing.
        ///
        /// This method does not affect receiving or playing the remote audio streams,and enableLocalAudio(false) is applicable to scenarios where the user wants to
        /// receive remote audio streams without sending any audio stream to other users in the channel.
        ///
        /// Once the local audio function is disabled or re-enabled, the SDK triggers the \ref agora::rtc::IRtcEngineEventHandler::onLocalAudioStateChanged "onLocalAudioStateChanged" callback,
        /// which reports `LOCAL_AUDIO_STREAM_STATE_STOPPED(0)` or `LOCAL_AUDIO_STREAM_STATE_RECORDING(1)`.
        ///
        /// @note
        /// This method is different from the \ref agora::rtc::IRtcEngine::muteLocalAudioStream "muteLocalAudioStream" method:
        ///    - \ref agora::rtc::IRtcEngine::enableLocalAudio "enableLocalAudio": Disables/Re-enables the local audio capturing and processing.
        ///    If you disable or re-enable local audio recording using the `enableLocalAudio` method, the local user may hear a pause in the remote audio playback.
        ///    - \ref agora::rtc::IRtcEngine::muteLocalAudioStream "muteLocalAudioStream": Sends/Stops sending the local audio streams.
        /// </summary>
        /// 
        /// <param name="enabled">
        /// @param enabled Sets whether to disable/re-enable the local audio function:
        /// - true: (Default) Re-enable the local audio function, that is, to start the local audio capturing device (for example, the microphone).
        /// - false: Disable the local audio function, that is, to stop local audio capturing.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE EnableLocalAudio(bool enabled)
        {
            return AgorartcNative.enableLocalAudio(_apiBridge, enabled ? 1 : 0);
        }

        /// <summary>
        /// Disables the audio module.
        ///
        /// @note
        /// - This method affects the internal engine and can be called after the \ref agora::rtc::IRtcEngine::leaveChannel "leaveChannel" method. You can call this method either before or after joining a channel.
        /// - This method resets the internal engine and takes some time to take effect. We recommend using the \ref agora::rtc::IRtcEngine::enableLocalAudio "enableLocalAudio" and \ref agora::rtc::IRtcEngine::muteLocalAudioStream "muteLocalAudioStream" methods to capture, process, and send the local audio streams.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE DisableAudio()
        {
            return AgorartcNative.disableAudio(_apiBridge);
        }

        /// <summary>
        /// Sets the audio parameters and application scenarios.
        ///
        /// @note
        /// - The *setAudioProfile* method must be called before the \ref IRtcEngine::joinChannel "joinChannel" method.
        /// - In the `COMMUNICATION` and `LIVE_BROADCASTING` profiles, the bitrate may be different from your settings due to network self-adaptation.
        /// - In scenarios requiring high-quality audio, for example, a music teaching scenario, we recommend setting profile as AUDIO_PROFILE_MUSIC_HIGH_QUALITY (4) and  scenario as AUDIO_SCENARIO_GAME_STREAMING (3).
        /// </summary>
        /// 
        /// <param name="profile">
        /// @param  profile Sets the sample rate, bitrate, encoding mode, and the number of channels. See #AUDIO_PROFILE_TYPE.
        /// </param>
        /// 
        /// <param name="scenario">
        /// @param  scenario Sets the audio application scenario. See #AUDIO_SCENARIO_TYPE.
        /// Under different audio scenarios, the device uses different volume tracks,
        /// i.e. either the in-call volume or the media volume. For details, see
        /// [What is the difference between the in-call volume and the media volume?](https://docs.agora.io/en/faq/system_volume).
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetAudioProfile(AUDIO_PROFILE_TYPE profile,
            AUDIO_SCENARIO_TYPE scenario)
        {
            return AgorartcNative.setAudioProfile(_apiBridge, profile, scenario);
        }

        /// <summary>
        /// tops/Resumes sending the local audio stream.
        ///
        /// A successful \ref agora::rtc::IRtcEngine::muteLocalAudioStream "muteLocalAudioStream" method call triggers the \ref agora::rtc::IRtcEngineEventHandler::onUserMuteAudio "onUserMuteAudio" callback on the remote client.
        /// @note
        /// - When @p mute is set as @p true, this method does not disable the microphone, which does not affect any ongoing recording.
        /// - If you call \ref agora::rtc::IRtcEngine::setChannelProfile "setChannelProfile" after this method, the SDK resets whether or not to mute the local audio according to the channel profile and user role. Therefore, we recommend calling this method after the `setChannelProfile` method.
        /// </summary>
        /// 
        /// <param name="mute">
        /// @param mute Sets whether to send/stop sending the local audio stream:
        /// - true: Stops sending the local audio stream.
        /// - false: (Default) Sends the local audio stream.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE MuteLocalAudioStream(bool mute)
        {
            return AgorartcNative.muteLocalAudioStream(_apiBridge, mute ? 1 : 0);
        }

        /// <summary>
        /// Stops/Resumes receiving all remote users' audio streams.
        /// </summary>
        /// 
        /// <param name="mute">
        /// @param mute Sets whether to receive/stop receiving all remote users' audio streams.
        /// - true: Stops receiving all remote users' audio streams.
        /// - false: (Default) Receives all remote users' audio streams.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE MuteAllRemoteAudioStreams(bool mute)
        {
            return AgorartcNative.muteAllRemoteAudioStreams(_apiBridge, mute ? 1 : 0);
        }

        /// <summary>
        /// Stops/Resumes receiving all remote users' audio streams by default.
        ///
        /// You can call this method either before or after joining a channel. If you call `setDefaultMuteAllRemoteAudioStreams (true)` after joining a channel, the remote audio streams of all subsequent users are not received.
        ///
        /// @note If you want to resume receiving the audio stream, call \ref agora::rtc::IRtcEngine::muteRemoteAudioStream "muteRemoteAudioStream (false)",
        /// and specify the ID of the remote user whose audio stream you want to receive.
        /// To receive the audio streams of multiple remote users, call `muteRemoteAudioStream (false)` as many times.
        /// Calling `setDefaultMuteAllRemoteAudioStreams (false)` resumes receiving the audio streams of subsequent users only.
        /// </summary>
        /// 
        /// <param name="mute">
        /// @param mute Sets whether to receive/stop receiving all remote users' audio streams by default:
        /// - true:  Stops receiving all remote users' audio streams by default.
        /// - false: (Default) Receives all remote users' audio streams by default.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetDefaultMuteAllRemoteVideoStreams(bool mute)
        {
            return AgorartcNative.setDefaultMuteAllRemoteVideoStreams(_apiBridge, mute ? 1 : 0);
        }

        /// <summary>
        /// Adjusts the playback volume of a specified remote user.
        ///
        /// You can call this method as many times as necessary to adjust the playback volume of different remote users, or to repeatedly adjust the playback volume of the same remote user.
        ///
        /// @note
        /// - Call this method after joining a channel.
        /// - The playback volume here refers to the mixed volume of a specified remote user.
        /// - This method can only adjust the playback volume of one specified remote user at a time. To adjust the playback volume of different remote users, call the method as many times, once for each remote user.
        /// </summary>
        /// 
        /// <param name="uid">
        /// @param uid The ID of the remote user.
        /// </param>
        /// 
        /// <param name="volume">
        /// @param volume The playback volume of the specified remote user. The value ranges from 0 to 100:
        /// - 0: Mute.
        /// - 100: Original volume.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE AdjustUserPlaybackSignalVolume(uid_t uid, int volume)
        {
            return AgorartcNative.adjustUserPlaybackSignalVolume(_apiBridge, uid, volume);
        }

        /// <summary>
        /// Stops/Resumes receiving a specified remote user's audio stream.
        ///
        /// @note If you called the \ref agora::rtc::IRtcEngine::muteAllRemoteAudioStreams "muteAllRemoteAudioStreams" method and set @p mute as @p true to stop receiving all remote users' audio streams, call the *muteAllRemoteAudioStreams* method and set @p mute as @p false before calling this method. The *muteAllRemoteAudioStreams* method sets all remote audio streams, while the *muteRemoteAudioStream* method sets a specified remote audio stream.
        /// </summary>
        /// 
        /// <param name="userId">
        /// @param userId User ID of the specified remote user sending the audio.
        /// </param>
        /// 
        /// <param name="mute">
        /// @param mute Sets whether to receive/stop receiving a specified remote user's audio stream:
        /// - true: Stops receiving the specified remote user's audio stream.
        /// - false: (Default) Receives the specified remote user's audio stream.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE MuteRemoteAudioStream(uid_t userId, bool mute)
        {
            return AgorartcNative.muteRemoteAudioStream(_apiBridge, userId, mute ? 1 : 0);
        }

        /// <summary>
        /// Stops/Resumes sending the local video stream.
        ///
        /// A successful \ref agora::rtc::IRtcEngine::muteLocalVideoStream "muteLocalVideoStream" method call triggers the \ref agora::rtc::IRtcEngineEventHandler::onUserMuteVideo "onUserMuteVideo" callback on the remote client.
        ///
        /// @note
        /// - When set to *true*, this method does not disable the camera which does not affect the retrieval of the local video streams. This method executes faster than the \ref agora::rtc::IRtcEngine::enableLocalVideo "enableLocalVideo" method which controls the sending of the local video stream.
        /// - If you call \ref agora::rtc::IRtcEngine::setChannelProfile "setChannelProfile" after this method, the SDK resets whether or not to mute the local video according to the channel profile and user role. Therefore, we recommend calling this method after the `setChannelProfile` method.
        /// </summary>
        /// 
        /// <param name="mute">
        /// @param mute Sets whether to send/stop sending the local video stream:
        /// - true: Stop sending the local video stream.
        /// - false: (Default) Send the local video stream.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE MuteLocalVideoStream(bool mute)
        {
            return AgorartcNative.muteLocalVideoStream(_apiBridge, mute ? 1 : 0);
        }

        /// <summary>
        /// Enables/Disables the local video capture.
        ///
        /// This method disables or re-enables the local video capturer, and does not affect receiving the remote video stream.
        ///
        /// After you call the \ref agora::rtc::IRtcEngine::enableVideo "enableVideo" method, the local video capturer is enabled by default. You can call \ref agora::rtc::IRtcEngine::enableLocalVideo "enableLocalVideo(false)" to disable the local video capturer. If you want to re-enable it, call \ref agora::rtc::IRtcEngine::enableLocalVideo "enableLocalVideo(true)".
        ///
        /// After the local video capturer is successfully disabled or re-enabled, the SDK triggers the \ref agora::rtc::IRtcEngineEventHandler::onUserEnableLocalVideo "onUserEnableLocalVideo" callback on the remote client.
        ///
        /// @note This method affects the internal engine and can be called after the \ref agora::rtc::IRtcEngine::leaveChannel "leaveChannel" method.
        /// </summary>
        /// 
        /// <param name="enabled">
        /// @param enabled Sets whether to disable/re-enable the local video, including the capturer, renderer, and sender:
        /// - true: (Default) Re-enable the local video.
        /// - false: Disable the local video. Once the local video is disabled, the remote users can no longer receive the video stream of this user, while this user can still receive the video streams of the other remote users.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE EnableLocalVideo(bool enabled)
        {
            return AgorartcNative.enableLocalVideo(_apiBridge, enabled ? 1 : 0);
        }

        /// <summary>
        /// Stops/Resumes receiving all video stream from a specified remote user.
        /// </summary>
        /// 
        /// <param name="mute">
        /// @param  mute Sets whether to receive/stop receiving all remote users' video streams:
        /// - true: Stop receiving all remote users' video streams.
        /// - false: (Default) Receive all remote users' video streams.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE MuteAllRemoteVideoStreams(bool mute)
        {
            return AgorartcNative.muteAllRemoteVideoStreams(_apiBridge, mute ? 1 : 0);
        }

        /// <summary>
        /// Stops/Resumes receiving all remote users' video streams by default.
        ///
        /// You can call this method either before or after joining a channel. If you call `setDefaultMuteAllRemoteVideoStreams (true)` after joining a channel, the remote video streams of all subsequent users are not received.
        ///
        /// @note If you want to resume receiving the video stream, call \ref agora::rtc::IRtcEngine::muteRemoteVideoStream "muteRemoteVideoStream (false)", and specify the ID of the remote user whose video stream you want to receive. To receive the video streams of multiple remote users, call `muteRemoteVideoStream (false)` as many times. Calling `setDefaultMuteAllRemoteVideoStreams (false)` resumes receiving the video streams of subsequent users only.
        /// </summary>
        /// 
        /// <param name="mute">
        /// @param mute Sets whether to receive/stop receiving all remote users' video streams by default:
        /// - true: Stop receiving all remote users' video streams by default.
        /// - false: (Default) Receive all remote users' video streams by default.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetDefaultMuteAllRemoteAudioStreams(bool mute)
        {
            return AgorartcNative.setDefaultMuteAllRemoteAudioStreams(_apiBridge, mute ? 1 : 0);
        }

        /// <summary>
        /// Stops/Resumes receiving the video stream from a specified remote user.
        ///
        /// @note If you called the \ref agora::rtc::IRtcEngine::muteAllRemoteVideoStreams "muteAllRemoteVideoStreams" method and set @p mute as @p true to stop receiving all remote video streams, call the *muteAllRemoteVideoStreams* method and set @p mute as @p false before calling this method.
        /// </summary>
        /// 
        /// <param name="userId">
        /// @param userId User ID of the specified remote user.
        /// </param>
        /// 
        /// <param name="mute">
        /// @param mute Sets whether to stop/resume receiving the video stream from a specified remote user:
        /// - true: Stop receiving the specified remote user's video stream.
        /// - false: (Default) Receive the specified remote user's video stream.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE MuteRemoteVideoStream(uid_t userId, bool mute)
        {
            return AgorartcNative.muteRemoteVideoStream(_apiBridge, userId, mute ? 1 : 0);
        }

        /// <summary>
        /// Sets the stream type of the remote video.
        ///
        /// Under limited network conditions, if the publisher has not disabled the dual-stream mode using `enableDualStreamMode(false)`,
        /// the receiver can choose to receive either the high-quality video stream (the high resolution, and high bitrate video stream) or
        /// the low-video stream (the low resolution, and low bitrate video stream).
        ///
        /// By default, users receive the high-quality video stream. Call this method if you want to switch to the low-video stream.
        /// This method allows the app to adjust the corresponding video stream type based on the size of the video window to
        /// reduce the bandwidth and resources.
        ///
        /// The aspect ratio of the low-video stream is the same as the high-quality video stream. Once the resolution of the high-quality video
        /// stream is set, the system automatically sets the resolution, frame rate, and bitrate of the low-video stream.
        ///
        /// The method result returns in the \ref agora::rtc::IRtcEngineEventHandler::onApiCallExecuted "onApiCallExecuted" callback.
        /// </summary>
        /// 
        /// <param name="userId">
        /// @param userId ID of the remote user sending the video stream.
        /// </param>
        /// 
        /// <param name="streamType">
        /// @param streamType  Sets the video-stream type. See #REMOTE_VIDEO_STREAM_TYPE.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetRemoteVideoStreamType(uid_t userId, REMOTE_VIDEO_STREAM_TYPE streamType)
        {
            return AgorartcNative.setRemoteVideoStreamType(_apiBridge, userId, streamType);
        }

        /// <summary>
        /// Sets the default stream type of remote videos.
        ///
        /// Under limited network conditions, if the publisher has not disabled the dual-stream mode using `enableDualStreamMode(false)`,
        /// the receiver can choose to receive either the high-quality video stream (the high resolution, and high bitrate video stream) or
        /// the low-video stream (the low resolution, and low bitrate video stream).
        ///
        /// By default, users receive the high-quality video stream. Call this method if you want to switch to the low-video stream.
        /// This method allows the app to adjust the corresponding video stream type based on the size of the video window to
        /// reduce the bandwidth and resources. The aspect ratio of the low-video stream is the same as the high-quality video stream.
        /// Once the resolution of the high-quality video
        /// stream is set, the system automatically sets the resolution, frame rate, and bitrate of the low-video stream.
        ///
        /// The method result returns in the \ref agora::rtc::IRtcEngineEventHandler::onApiCallExecuted "onApiCallExecuted" callback.
        /// </summary>
        /// 
        /// <param name="streamType">
        /// @param streamType Sets the default video-stream type. See #REMOTE_VIDEO_STREAM_TYPE.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetRemoteDefaultVideoStreamType(REMOTE_VIDEO_STREAM_TYPE streamType)
        {
            return AgorartcNative.setRemoteDefaultVideoStreamType(_apiBridge, streamType);
        }

        /// <summary>
        /// Enables the \ref agora::rtc::IRtcEngineEventHandler::onAudioVolumeIndication "onAudioVolumeIndication" callback at a set time interval to report on which users are speaking and the speakers' volume.
        ///
        /// Once this method is enabled, the SDK returns the volume indication in the \ref agora::rtc::IRtcEngineEventHandler::onAudioVolumeIndication "onAudioVolumeIndication" callback at the set time interval, whether or not any user is speaking in the channel.
        /// </summary>
        /// 
        /// <param name="interval">
        /// @param interval Sets the time interval between two consecutive volume indications:
        /// - &lt;= 0: Disables the volume indication.
        /// - > 0: Time interval (ms) between two consecutive volume indications. We recommend setting @p interval &gt; 200 ms. Do not set @p interval &lt; 10 ms, or the *onAudioVolumeIndication* callback will not be triggered.
        /// </param>
        /// 
        /// <param name="smooth">
        /// @param smooth  Smoothing factor sets the sensitivity of the audio volume indicator. The value ranges between 0 and 10. The greater the value, the more sensitive the indicator. The recommended value is 3.
        /// </param>
        /// 
        /// <param name="report_vad">
        /// @param report_vad
        /// 
        /// - true: Enable the voice activity detection of the local user. Once it is enabled, the `vad` parameter of the `onAudioVolumeIndication` callback reports the voice activity status of the local user.
        /// - false: (Default) Disable the voice activity detection of the local user. Once it is disabled, the `vad` parameter of the `onAudioVolumeIndication` callback does not report the voice activity status of the local user, except for the scenario where the engine automatically detects the voice activity of the local user.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE EnableAudioVolumeIndication(int interval, int smooth, bool report_vad)
        {
            return AgorartcNative.enableAudioVolumeIndication(_apiBridge, interval, smooth, report_vad ? 1 : 0);
        }

        /// <summary>
        /// @deprecated Starts an audio recording.
        ///
        /// Use \ref IRtcEngine::startAudioRecording(const char* filePath, int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality) "startAudioRecording"2 instead.
        ///
        /// The SDK allows recording during a call. Supported formats:
        ///
        /// - .wav: Large file size with high fidelity.
        /// - .aac: Small file size with low fidelity.
        ///
        /// This method has a fixed sample rate of 32 kHz.
        ///
        /// Ensure that the directory to save the recording file exists and is writable.
        /// This method is usually called after the \ref agora::rtc::IRtcEngine::joinChannel "joinChannel" method.
        /// The recording automatically stops when the \ref agora::rtc::IRtcEngine::leaveChannel "leaveChannel" method is called.
        /// </summary>
        /// 
        /// <param name="filePath">
        /// @param filePath Pointer to the absolute file path of the recording file. The string of the file name is in UTF-8.
        /// </param>
        /// 
        /// <param name="quality">
        /// @param quality Sets the audio recording quality. See #AUDIO_RECORDING_QUALITY_TYPE.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StartAudioRecording(string filePath, AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            return AgorartcNative.startAudioRecording(_apiBridge, filePath, quality);
        }

        /// <summary>
        /// Starts an audio recording on the client.
        /// 
        ///  The SDK allows recording during a call. After successfully calling this method, you can record the audio of all the users in the channel and get an audio recording file.
        ///  Supported formats of the recording file are as follows:
        ///  - .wav: Large file size with high fidelity.
        ///  - .aac: Small file size with low fidelity.
        /// 
        ///  @note
        ///  - Ensure that the directory you use to save the recording file exists and is writable.
        ///  - This method is usually called after the `joinChannel` method. The recording automatically stops when you call the `leaveChannel` method.
        ///  - For better recording effects, set quality as #AUDIO_RECORDING_QUALITY_MEDIUM or #AUDIO_RECORDING_QUALITY_HIGH when `sampleRate` is 44.1 kHz or 48 kHz.
        /// </summary>
        /// 
        /// <param name="filePath">
        /// @param filePath Pointer to the absolute file path of the recording file. The string of the file name is in UTF-8, such as c:/music/audio.aac.
        /// </param>
        /// 
        /// <param name="sampleRate">
        /// @param sampleRate Sample rate (kHz) of the recording file. Supported values are as follows:
        ///  - 16
        ///  - (Default) 32
        ///  - 44.1
        ///  - 48
        /// </param>
        /// 
        /// <param name="quality">
        /// @param quality Sets the audio recording quality. See #AUDIO_RECORDING_QUALITY_TYPE.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StartAudioRecording2(string filePath, int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            return AgorartcNative.startAudioRecording2(_apiBridge, filePath, sampleRate, quality);
        }

        /// <summary>
        /// Stops an audio recording on the client.
        ///
        /// You can call this method before calling the \ref agora::rtc::IRtcEngine::leaveChannel "leaveChannel" method else, the recording automatically stops when the \ref agora::rtc::IRtcEngine::leaveChannel "leaveChannel" method is called.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StopAudioRecording()
        {
            return AgorartcNative.stopAudioRecording(_apiBridge);
        }

        /// <summary>
        /// Sets the sound position and gain of a remote user.
        ///
        /// When the local user calls this method to set the sound position of a remote user, the sound difference between the left and right channels allows the local user to track the real-time position of the remote user, creating a real sense of space. This method applies to massively multiplayer online games, such as Battle Royale games.
        ///
        /// @note
        /// - For this method to work, enable stereo panning for remote users by calling the \ref agora::rtc::IRtcEngine::enableSoundPositionIndication "enableSoundPositionIndication" method before joining a channel.
        /// - This method requires hardware support. For the best sound positioning, we recommend using a stereo speaker.
        /// </summary>
        /// 
        /// <param name="uid">
        /// @param uid The ID of the remote user.
        /// </param>
        /// 
        /// <param name="pan">
        /// @param pan The sound position of the remote user. The value ranges from -1.0 to 1.0:
        /// - 0.0: the remote sound comes from the front.
        /// - -1.0: the remote sound comes from the left.
        /// - 1.0: the remote sound comes from the right.
        /// </param>
        /// 
        /// <param name="gain">
        /// @param gain Gain of the remote user. The value ranges from 0.0 to 100.0. The default value is 100.0 (the original gain of the remote user). The smaller the value, the less the gain.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetRemoteVoicePosition(uid_t uid, double pan, double gain)
        {
            return AgorartcNative.setRemoteVoicePosition(_apiBridge, uid, pan, gain);
        }

        /// <summary>
        /// Sets the log files that the SDK outputs.
        /// 
        ///  By default, the SDK outputs five log files, `agorasdk.log`, `agorasdk_1.log`, `agorasdk_2.log`, `agorasdk_3.log`, `agorasdk_4.log`, each with a default size of 1024 KB.
        ///  These log files are encoded in UTF-8. The SDK writes the latest logs in `agorasdk.log`. When `agorasdk.log` is full, the SDK deletes the log file with the earliest
        ///  modification time among the other four, renames `agorasdk.log` to the name of the deleted log file, and create a new `agorasdk.log` to record latest logs.
        /// 
        ///  @note Ensure that you call this method immediately after calling \ref agora::rtc::IRtcEngine::initialize "initialize" , otherwise the output logs may not be complete.
        /// 
        ///  @see \ref IRtcEngine::setLogFileSize "setLogFileSize"
        ///  @see \ref IRtcEngine::setLogFilter "setLogFilter"
        /// </summary>
        /// 
        /// <param name="file">
        /// @param filePath The absolute path of log files. The default file path is `C: \Users\&lt;user_name>\AppData\Local\Agora\&lt;process_name>\agorasdk.log`.
        ///  Ensure that the directory for the log files exists and is writable. You can use this parameter to rename the log files.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetLogFile(string file)
        {
            return AgorartcNative.setLogFile(_apiBridge, file);
        }

        /// <summary>
        /// Sets the output log level of the SDK.
        ///
        /// You can use one or a combination of the log filter levels. The log level follows the sequence of OFF, CRITICAL, ERROR, WARNING, INFO, and DEBUG. Choose a level to see the logs preceding that level.
        ///
        /// If you set the log level to WARNING, you see the logs within levels CRITICAL, ERROR, and WARNING.
        ///
        /// @see \ref IRtcEngine::setLogFile "setLogFile"
        /// @see \ref IRtcEngine::setLogFileSize "setLogFileSize"
        /// </summary>
        /// 
        /// <param name="filter">
        /// @param filter Sets the log filter level. See #LOG_FILTER_TYPE.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetLogFilter(uint filter)
        {
            return AgorartcNative.setLogFilter(_apiBridge, filter);
        }

        /// <summary>
        /// Sets the size of a log file that the SDK outputs.
        /// 
        ///  By default, the SDK outputs five log files, `agorasdk.log`, `agorasdk_1.log`, `agorasdk_2.log`, `agorasdk_3.log`, `agorasdk_4.log`, each with a default size of 1024 KB.
        ///  These log files are encoded in UTF-8. The SDK writes the latest logs in `agorasdk.log`. When `agorasdk.log` is full, the SDK deletes the log file with the earliest
        ///  modification time among the other four, renames `agorasdk.log` to the name of the deleted log file, and create a new `agorasdk.log` to record latest logs.
        /// 
        ///  @see \ref IRtcEngine::setLogFile "setLogFile"
        ///  @see \ref IRtcEngine::setLogFilter "setLogFilter"
        /// </summary>
        /// 
        /// <param name="fileSizeInKBytes">
        /// @param fileSizeInKBytes The size (KB) of a log file. The default value is 1024 KB. If you set `fileSizeInKByte` to 1024 KB,
        ///  the SDK outputs at most 5 MB log files; if you set it to less than 1024 KB, the maximum size of a log file is still 1024 KB.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetLogFileSize(uint fileSizeInKBytes)
        {
            return AgorartcNative.setLogFileSize(_apiBridge, fileSizeInKBytes);
        }

        /// <summary>
        /// @deprecated This method is deprecated, use the \ref IRtcEngine::setLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode) "setLocalRenderMode"2 method instead.
        /// Sets the local video display mode.
        /// This method can be called multiple times during a call to change the display mode.
        /// </summary>
        /// 
        /// <param name="renderMode">
        /// @param renderMode  Sets the local video display mode. See #RENDER_MODE_TYPE.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetLocalRenderMode(RENDER_MODE_TYPE renderMode)
        {
            return AgorartcNative.setLocalRenderMode(_apiBridge, renderMode);
        }

        /// <summary>
        /// Updates the display mode of the local video view.
        ///
        /// @since v3.0.0
        ///
        /// After initializing the local video view, you can call this method to update its rendering and mirror modes. It affects only the video view that the local user sees, not the published local video stream.
        ///
        /// @note
        /// - Ensure that you have called the \ref IRtcEngine::setupLocalVideo "setupLocalVideo" method to initialize the local video view before calling this method.
        /// - During a call, you can call this method as many times as necessary to update the display mode of the local video view.
        /// </summary>
        /// 
        /// <param name="renderMode">
        /// @param renderMode The rendering mode of the local video view. See #RENDER_MODE_TYPE.
        /// </param>
        /// 
        /// <param name="mirrorMode">
        /// @param mirrorMode
        /// - The mirror mode of the local video view. See #VIDEO_MIRROR_MODE_TYPE.
        /// - **Note**: If you use a front camera, the SDK enables the mirror mode by default; if you use a rear camera, the SDK disables the mirror mode by default.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetLocalRenderMode2(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            return AgorartcNative.setLocalRenderMode2(_apiBridge, renderMode, mirrorMode);
        }

        /// <summary>
        /// @deprecated This method is deprecated, use the \ref IRtcEngine::setRemoteRenderMode(uid_t userId, RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode) "setRemoteRenderMode"2 method instead.
        /// Sets the video display mode of a specified remote user.
        ///
        /// This method can be called multiple times during a call to change the display mode.
        /// </summary>
        /// 
        /// <param name="userId">
        /// @param userId ID of the remote user.
        /// </param>
        /// 
        /// <param name="renderMode">
        /// @param renderMode  Sets the video display mode. See #RENDER_MODE_TYPE.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetRemoteRenderMode(uid_t userId, RENDER_MODE_TYPE renderMode)
        {
            return AgorartcNative.setRemoteRenderMode(_apiBridge, userId, renderMode);
        }

        /// <summary>
        /// Updates the display mode of the video view of a remote user.
        ///
        /// @since v3.0.0
        /// After initializing the video view of a remote user, you can call this method to update its rendering and mirror modes. This method affects only the video view that the local user sees.
        ///
        /// @note
        /// - Ensure that you have called the \ref IRtcEngine::setupRemoteVideo "setupRemoteVideo" method to initialize the remote video view before calling this method.
        /// - During a call, you can call this method as many times as necessary to update the display mode of the video view of a remote user.
        /// </summary>
        /// 
        /// <param name="userId">
        /// @param userId The ID of the remote user.
        /// </param>
        /// 
        /// <param name="renderMode">
        /// @param renderMode The rendering mode of the remote video view. See #RENDER_MODE_TYPE.
        /// </param>
        /// 
        /// <param name="mirrorMode">
        /// @param mirrorMode
        /// - The mirror mode of the remote video view. See #VIDEO_MIRROR_MODE_TYPE.
        /// - **Note**: The SDK disables the mirror mode by default.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetRemoteRenderMode2(uid_t userId, RENDER_MODE_TYPE renderMode,
            VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            return AgorartcNative.setRemoteRenderMode2(_apiBridge, userId, renderMode, mirrorMode);
        }

        /// <summary>
        /// @deprecated This method is deprecated, use the \ref IRtcEngine::setupLocalVideo "setupLocalVideo"
        /// or \ref IRtcEngine::setLocalRenderMode(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode) "setLocalRenderMode" method instead.
        ///
        /// Sets the local video mirror mode.
        ///
        /// You must call this method before calling the \ref agora::rtc::IRtcEngine::startPreview "startPreview" method, otherwise the mirror mode will not work.
        ///
        /// @warning
        /// - Call this method after calling the \ref agora::rtc::IRtcEngine::setupLocalVideo "setupLocalVideo" method to initialize the local video view.
        /// - During a call, you can call this method as many times as necessary to update the mirror mode of the local video view.
        /// </summary>
        /// 
        /// <param name="mirrorMode">
        /// @param mirrorMode Sets the local video mirror mode. See #VIDEO_MIRROR_MODE_TYPE.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            return AgorartcNative.setLocalVideoMirrorMode(_apiBridge, mirrorMode);
        }

        /// <summary>
        /// Sets the stream mode to the single-stream (default) or dual-stream mode. (`LIVE_BROADCASTING` only.)
        ///
        /// If the dual-stream mode is enabled, the receiver can choose to receive the high stream (high-resolution and high-bitrate video stream), or the low stream (low-resolution and low-bitrate video stream).
        /// </summary>
        /// 
        /// <param name="enabled">
        /// @param enabled Sets the stream mode:
        /// - true: Dual-stream mode.
        /// - false: Single-stream mode.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE EnableDualStreamMode(bool enabled)
        {
            return AgorartcNative.enableDualStreamMode(_apiBridge, enabled ? 1 : 0);
        }

        /// <summary>
        /// Adjusts the recording volume.
        /// </summary>
        /// 
        /// <param name="volume">
        /// @param volume Recording volume. To avoid echoes and
        /// improve call quality, Agora recommends setting the value of volume between
        /// 0 and 100. If you need to set the value higher than 100, contact
        /// support@agora.io first.
        /// - 0: Mute.
        /// - 100: Original volume.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE AdjustRecordingSignalVolume(int volume)
        {
            return AgorartcNative.adjustRecordingSignalVolume(_apiBridge, volume);
        }

        /// <summary>
        /// Adjusts the playback volume of all remote users.
        ///
        /// @note
        /// - This method adjusts the playback volume that is the mixed volume of all remote users.
        /// - (Since v2.3.2) To mute the local audio playback, call both the `adjustPlaybackSignalVolume` and \ref IRtcEngine::adjustAudioMixingVolume "adjustAudioMixingVolume" methods and set the volume as `0`.
        /// </summary>
        /// 
        /// <param name="volume">
        /// @param volume The playback volume of all remote users. To avoid echoes and
        /// improve call quality, Agora recommends setting the value of volume between
        /// 0 and 100. If you need to set the value higher than 100, contact
        /// support@agora.io first.
        /// - 0: Mute.
        /// - 100: Original volume.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE AdjustPlaybackSignalVolume(int volume)
        {
            return AgorartcNative.adjustPlaybackSignalVolume(_apiBridge, volume);
        }

        /// <summary>
        /// @deprecated This method is deprecated. As of v3.0.0, the Native SDK automatically enables interoperability with the Web SDK, so you no longer need to call this method.
        /// Enables interoperability with the Agora Web SDK.
        ///
        /// @note
        /// - This method applies only to the `LIVE_BROADCASTING` profile. In the `COMMUNICATION` profile, interoperability with the Agora Web SDK is enabled by default.
        /// - If the channel has Web SDK users, ensure that you call this method, or the video of the Native user will be a black screen for the Web user.
        /// </summary>
        /// 
        /// <param name="enabled">
        /// @param enabled Sets whether to enable/disable interoperability with the Agora Web SDK:
        /// - true: Enable.
        /// - false: (Default) Disable.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE EnableWebSdkInteroperability(bool enabled)
        {
            return AgorartcNative.enableWebSdkInteroperability(_apiBridge, enabled ? 1 : 0);
        }

        /// <summary>
        /// only for live broadcast
        /// **DEPRECATED** Sets the preferences for the high-quality video. (`LIVE_BROADCASTING` only).
        ///
        /// This method is deprecated as of v2.4.0.
        /// </summary>
        /// 
        /// <param name="preferFrameRateOverImageQuality">
        /// @param preferFrameRateOverImageQuality Sets the video quality preference:
        /// - true: Frame rate over image quality.
        /// - false: (Default) Image quality over frame rate.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetVideoQualityParameters(bool preferFrameRateOverImageQuality)
        {
            return AgorartcNative.setVideoQualityParameters(_apiBridge, preferFrameRateOverImageQuality ? 1 : 0);
        }

        /// <summary>
        /// Sets the fallback option for the published video stream based on the network conditions.
        ///
        /// If `option` is set as #STREAM_FALLBACK_OPTION_AUDIO_ONLY (2), the SDK will:
        ///
        /// - Disable the upstream video but enable audio only when the network conditions deteriorate and cannot support both video and audio.
        /// - Re-enable the video when the network conditions improve.
        ///
        /// When the published video stream falls back to audio only or when the audio-only stream switches back to the video, the SDK triggers the \ref agora::rtc::IRtcEngineEventHandler::onLocalPublishFallbackToAudioOnly "onLocalPublishFallbackToAudioOnly" callback.
        ///
        /// @note Agora does not recommend using this method for CDN live streaming, because the remote CDN live user will have a noticeable lag when the published video stream falls back to audio only.
        /// </summary>
        /// 
        /// <param name="option">
        /// @param option Sets the fallback option for the published video stream:
        /// - #STREAM_FALLBACK_OPTION_DISABLED (0): (Default) No fallback behavior for the published video stream when the uplink network condition is poor. The stream quality is not guaranteed.
        /// - #STREAM_FALLBACK_OPTION_AUDIO_ONLY (2): The published video stream falls back to audio only when the uplink network condition is poor.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            return AgorartcNative.setLocalPublishFallbackOption(_apiBridge, option);
        }

        /// <summary>
        /// Sets the fallback option for the remotely subscribed video stream based on the network conditions.
        ///
        /// The default setting for `option` is #STREAM_FALLBACK_OPTION_VIDEO_STREAM_LOW (1), where the remotely subscribed video stream falls back to the low-stream video (low resolution and low bitrate) under poor downlink network conditions.
        ///
        /// If `option` is set as #STREAM_FALLBACK_OPTION_AUDIO_ONLY (2), the SDK automatically switches the video from a high-stream to a low-stream, or disables the video when the downlink network conditions cannot support both audio and video to guarantee the quality of the audio. The SDK monitors the network quality and restores the video stream when the network conditions improve.
        ///
        /// When the remotely subscribed video stream falls back to audio only or when the audio-only stream switches back to the video stream, the SDK triggers the \ref agora::rtc::IRtcEngineEventHandler::onRemoteSubscribeFallbackToAudioOnly "onRemoteSubscribeFallbackToAudioOnly" callback.
        /// </summary>
        /// 
        /// <param name="option">
        /// @param  option  Sets the fallback option for the remotely subscribed video stream. See #STREAM_FALLBACK_OPTIONS.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            return AgorartcNative.setRemoteSubscribeFallbackOption(_apiBridge, option);
        }

        /// <summary>
        /// Enables loopback recording.
        ///
        /// If you enable loopback recording, the output of the sound card is mixed into the audio stream sent to the other end.
        ///
        ///  @note
        /// - This method is for macOS and Windows only.
        /// - macOS does not support loopback recording of the default sound card. If you need to use this method, please use a virtual sound card and pass its name to the deviceName parameter. Agora has tested and recommends using soundflower.
        /// </summary>
        /// 
        /// <param name="enabled">
        /// @param enabled Sets whether to enable/disable loopback recording.
        /// - true: Enable loopback recording.
        /// - false: (Default) Disable loopback recording.
        /// </param>
        /// 
        /// <param name="deviceName">
        /// @param deviceName Pointer to the device name of the sound card. The default value is NULL (the default sound card).
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE EnableLoopbackRecording(bool enabled, string deviceName)
        {
            return AgorartcNative.enableLoopbackRecording(_apiBridge, enabled ? 1 : 0, deviceName);
        }

        /// <summary>
        /// Shares the whole or part of a screen by specifying the screen rect.
        /// </summary>
        /// 
        /// <param name="screenRect">
        /// @param  screenRect Sets the relative location of the screen to the virtual screen. For information on how to get screenRect, see the advanced guide *Share Screen*.
        /// </param>
        /// 
        /// <param name="regionRect">
        /// @param  regionRect (Optional) Sets the relative location of the region to the screen. NULL means sharing the whole screen. See Rectangle. If the specified region overruns the screen, the SDK shares only the region within it; if you set width or height as 0, the SDK shares the whole screen.
        /// </param>
        /// 
        /// <param name="captureParams">
        /// @param  captureParams Sets the screen sharing encoding parameters. See ScreenCaptureParameters.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        ///     - #ERR_INVALID_ARGUMENT : the argument is invalid.
        /// </returns>
        public ERROR_CODE StartScreenCaptureByScreenRect(ref Rectangle screenRect, ref Rectangle regionRect,
            ref ScreenCaptureParameters captureParams)
        {
            return AgorartcNative.startScreenCaptureByScreenRect(_apiBridge, ref screenRect, ref regionRect,
                ref captureParams);
        }

        /// <summary>
        /// Shares the whole or part of a window by specifying the window ID.
        ///
        /// Since v3.0.0, this method supports sharing with common Windows platforms. Agora tests the mainstream Windows applications, see details as follows:
        ///
        /// <table>
        ///     <tr>
        ///         <td><b>OS version</b></td>
        ///         <td><b>Software</b></td>
        ///         <td><b>Software name</b></td>
        ///         <td><b>Whether support</b></td>
        ///     </tr>
        ///         <tr>
        ///         <td rowspan="8">win10</td>
        ///         <td >Chrome</td>
        ///         <td>76.0.3809.100</td>
        ///         <td>No</td>
        ///     </tr>
        ///     <tr>
        ///         <td>Office Word</td>
        ///         <td rowspan="3">18.1903.1152.0</td>
        ///         <td>Yes</td>
        ///     </tr>
        ///         <tr>
        ///         <td>Office Excel</td>
        ///         <td>No</td>
        ///     </tr>
        ///     <tr>
        ///         <td>Office PPT</td>
        ///         <td>No</td>
        ///     </tr>
        ///  <tr>
        ///         <td>WPS Word</td>
        ///         <td rowspan="3">11.1.0.9145</td>
        ///         <td rowspan="3">Yes</td>
        ///     </tr>
        ///         <tr>
        ///         <td>WPS Excel</td>
        ///     </tr>
        ///     <tr>
        ///         <td>WPS PPT</td>
        ///     </tr>
        ///         <tr>
        ///         <td>Media Player (come with the system)</td>
        ///         <td>All</td>
        ///         <td>Yes</td>
        ///     </tr>
        ///      <tr>
        ///         <td rowspan="8">win8</td>
        ///         <td >Chrome</td>
        ///         <td>All</td>
        ///         <td>Yes</td>
        ///     </tr>
        ///     <tr>
        ///         <td>Office Word</td>
        ///         <td rowspan="3">All</td>
        ///         <td rowspan="3">Yes</td>
        ///     </tr>
        ///         <tr>
        ///         <td>Office Excel</td>
        ///     </tr>
        ///     <tr>
        ///         <td>Office PPT</td>
        ///     </tr>
        ///  <tr>
        ///         <td>WPS Word</td>
        ///         <td rowspan="3">11.1.0.9098</td>
        ///         <td rowspan="3">Yes</td>
        ///     </tr>
        ///         <tr>
        ///         <td>WPS Excel</td>
        ///     </tr>
        ///     <tr>
        ///         <td>WPS PPT</td>
        ///     </tr>
        ///         <tr>
        ///         <td>Media Player(come with the system)</td>
        ///         <td>All</td>
        ///         <td>Yes</td>
        ///     </tr>
        ///   <tr>
        ///         <td rowspan="8">win7</td>
        ///         <td >Chrome</td>
        ///         <td>73.0.3683.103</td>
        ///         <td>No</td>
        ///     </tr>
        ///     <tr>
        ///         <td>Office Word</td>
        ///         <td rowspan="3">All</td>
        ///         <td rowspan="3">Yes</td>
        ///     </tr>
        ///         <tr>
        ///         <td>Office Excel</td>
        ///     </tr>
        ///     <tr>
        ///         <td>Office PPT</td>
        ///     </tr>
        ///  <tr>
        ///         <td>WPS Word</td>
        ///         <td rowspan="3">11.1.0.9098</td>
        ///         <td rowspan="3">No</td>
        ///     </tr>
        ///         <tr>
        ///         <td>WPS Excel</td>
        ///     </tr>
        ///     <tr>
        ///         <td>WPS PPT</td>
        ///     </tr>
        ///         <tr>
        ///         <td>Media Player(come with the system)</td>
        ///         <td>All</td>
        ///         <td>No</td>
        ///     </tr>
        /// </table>
        /// </summary>
        /// 
        /// <param name="windowId">
        /// @param  windowId The ID of the window to be shared. For information on how to get the windowId, see the advanced guide *Share Screen*.
        /// </param>
        /// 
        /// <param name="regionRect">
        /// @param  regionRect (Optional) The relative location of the region to the window. NULL/NIL means sharing the whole window. See Rectangle. If the specified region overruns the window, the SDK shares only the region within it; if you set width or height as 0, the SDK shares the whole window.
        /// </param>
        /// 
        /// <param name="captureParams">
        /// @param  captureParams Window sharing encoding parameters. See ScreenCaptureParameters.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StartScreenCaptureByWindowId(view_t windowId, ref Rectangle regionRect,
            ref ScreenCaptureParameters captureParams)
        {
            return AgorartcNative.startScreenCaptureByWindowId(_apiBridge, windowId, ref regionRect, ref captureParams);
        }

        /// <summary>
        /// Sets the content hint for screen sharing.
        ///
        /// A content hint suggests the type of the content being shared, so that the SDK applies different optimization algorithm to different types of content.
        /// </summary>
        /// 
        /// <param name="contentHint">
        /// @param  contentHint Sets the content hint for screen sharing. See VideoContentHint.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetScreenCaptureContentHint(VideoContentHint contentHint)
        {
            return AgorartcNative.setScreenCaptureContentHint(_apiBridge, contentHint);
        }

        /// <summary>
        /// Updates the screen sharing parameters.
        /// </summary>
        /// 
        /// <param name="captureParams">
        /// @param  captureParams Sets the screen sharing encoding parameters. See ScreenCaptureParameters.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        ///     - #ERR_NOT_READY: no screen or windows is being shared.
        /// </returns>
        public ERROR_CODE UpdateScreenCaptureParameters(ref ScreenCaptureParameters captureParams)
        {
            return AgorartcNative.updateScreenCaptureParameters(_apiBridge, ref captureParams);
        }

        /// <summary>
        /// Updates the screen sharing region.
        /// </summary>
        /// 
        /// <param name="regionRect">
        /// @param  regionRect Sets the relative location of the region to the screen or window. NULL means sharing the whole screen or window. See Rectangle. If the specified region overruns the screen or window, the SDK shares only the region within it; if you set width or height as 0, the SDK shares the whole screen or window.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        ///     - #ERR_NOT_READY: no screen or windows is being shared.
        /// </returns>
        public ERROR_CODE UpdateScreenCaptureRegion(ref Rectangle regionRect)
        {
            return AgorartcNative.updateScreenCaptureRegion(_apiBridge, ref regionRect);
        }

        /// <summary>
        /// Stop screen sharing.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StopScreenCapture()
        {
            return AgorartcNative.stopScreenCapture(_apiBridge);
        }

        /// <summary>
        /// ///  Retrieves the current call ID.
        ///
        /// When a user joins a channel on a client, a @p callId is generated to identify the call from the client. Feedback methods, such as \ref IRtcEngine::rate "rate" and \ref IRtcEngine::complain "complain", must be called after the call ends to submit feedback to the SDK.
        ///
        /// The \ref IRtcEngine::rate "rate" and \ref IRtcEngine::complain "complain" methods require the @p callId parameter retrieved from the *getCallId* method during a call. @p callId is passed as an argument into the \ref IRtcEngine::rate "rate" and \ref IRtcEngine::complain "complain" methods after the call ends.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public string GetCallId()
        {
            return AgorartcNative.getCallId(_apiBridge);
        }

        /// <summary>
        /// Allows a user to rate a call after the call ends.
        /// </summary>
        /// 
        /// <param name="callId">
        /// @param callId Pointer to the ID of the call, retrieved from the \ref IRtcEngine::getCallId "getCallId" method.
        /// </param>
        /// 
        /// <param name="rating">
        /// @param rating  Rating of the call. The value is between 1 (lowest score) and 5 (highest score). If you set a value out of this range, the #ERR_INVALID_ARGUMENT (2) error returns.
        /// </param>
        /// 
        /// <param name="description">
        /// @param description (Optional) Pointer to the description of the rating, with a string length of less than 800 bytes.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE Rate(string callId, int rating, string description)
        {
            return AgorartcNative.rate(_apiBridge, callId, rating, description);
        }

        /// <summary>
        /// Allows a user to complain about the call quality after a call ends.
        /// </summary>
        /// 
        /// <param name="callId">
        /// @param callId Pointer to the ID of the call, retrieved from the \ref IRtcEngine::getCallId "getCallId" method.
        /// </param>
        /// 
        /// <param name="description">
        /// @param description (Optional) Pointer to the description of the complaint, with a string length of less than 800 bytes.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE Complain(string callId, string description)
        {
            return AgorartcNative.complain(_apiBridge, callId, description);
        }

        /// <summary>
        /// etrieves the SDK version number.
        /// </summary>
        /// 
        /// <returns>
        /// @return The version of the current SDK in the string format. For example, 2.3.1.
        /// </returns>
        public string GetVersion()
        {
            return AgorartcNative.getVersion(_apiBridge);
        }

        /// <summary>
        /// Enables the network connection quality test.
        ///
        /// This method tests the quality of the users' network connections and is disabled by default.
        ///
        /// Before a user joins a channel or before an audience switches to a host, call this method to check the uplink network quality.
        ///
        /// This method consumes additional network traffic, and hence may affect communication quality.
        ///
        /// Call the \ref IRtcEngine::disableLastmileTest "disableLastmileTest" method to disable this test after receiving the \ref IRtcEngineEventHandler::onLastmileQuality "onLastmileQuality" callback, and before joining a channel.
        /// 
        /// @note
        /// - Do not call any other methods before receiving the \ref IRtcEngineEventHandler::onLastmileQuality "onLastmileQuality" callback. Otherwise, the callback may be interrupted by other methods, and hence may not be triggered.
        /// - A host should not call this method after joining a channel (when in a call).
        /// - If you call this method to test the last-mile quality, the SDK consumes the bandwidth of a video stream, whose bitrate corresponds to the bitrate you set in the \ref agora::rtc::IRtcEngine::setVideoEncoderConfiguration "setVideoEncoderConfiguration" method. After you join the channel, whether you have called the `disableLastmileTest` method or not, the SDK automatically stops consuming the bandwidth.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE EnableLastmileTest()
        {
            return AgorartcNative.enableLastmileTest(_apiBridge);
        }

        /// <summary>
        /// Disables the network connection quality test.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE DisableLastmileTest()
        {
            return AgorartcNative.disableLastmileTest(_apiBridge);
        }

        /// <summary>
        /// Starts the last-mile network probe test.
        ///
        /// This method starts the last-mile network probe test before joining a channel to get the uplink and downlink last-mile network statistics, including the bandwidth, packet loss, jitter, and round-trip time (RTT).
        ///
        /// Call this method to check the uplink network quality before users join a channel or before an audience switches to a host.
        /// Once this method is enabled, the SDK returns the following callbacks:
        /// - \ref IRtcEngineEventHandler::onLastmileQuality "onLastmileQuality": the SDK triggers this callback within two seconds depending on the network conditions. This callback rates the network conditions and is more closely linked to the user experience.
        /// - \ref IRtcEngineEventHandler::onLastmileProbeResult "onLastmileProbeResult": the SDK triggers this callback within 30 seconds depending on the network conditions. This callback returns the real-time statistics of the network conditions and is more objective.
        ///
        /// @note
        /// - This method consumes extra network traffic and may affect communication quality. We do not recommend calling this method together with enableLastmileTest.
        /// - Do not call other methods before receiving the \ref IRtcEngineEventHandler::onLastmileQuality "onLastmileQuality" and \ref IRtcEngineEventHandler::onLastmileProbeResult "onLastmileProbeResult" callbacks. Otherwise, the callbacks may be interrupted.
        /// - In the `LIVE_BROADCASTING` profile, a host should not call this method after joining a channel.
        /// </summary>
        /// 
        /// <param name="config">
        /// @param config Sets the configurations of the last-mile network probe test. See LastmileProbeConfig.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StartLastmileProbeTest(LastmileProbeConfig config)
        {
            return AgorartcNative.startLastmileProbeTest(_apiBridge, config);
        }

        /// <summary>
        /// Stops the last-mile network probe test.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StopLastmileProbeTest()
        {
            return AgorartcNative.stopLastmileProbeTest(_apiBridge);
        }

        /// <summary>
        /// Retrieves the warning or error description.
        /// </summary>
        /// 
        /// <param name="code">
        /// @param code Warning code or error code returned in the \ref agora::rtc::IRtcEngineEventHandler::onWarning "onWarning" or \ref agora::rtc::IRtcEngineEventHandler::onError "onError" callback.
        /// </param>
        /// 
        /// <returns>
        /// @return #WARN_CODE_TYPE or #ERROR_CODE_TYPE.
        /// </returns>
        public string GetErrorDescription(int code)
        {
            return AgorartcNative.getErrorDescription(_apiBridge, code);
        }

        /// <summary>
        /// **DEPRECATED** Enables built-in encryption with an encryption password before users join a channel.
        ///
        /// Deprecated as of v3.1.0. Use the \ref agora::rtc::IRtcEngine::enableEncryption "enableEncryption" instead.
        ///
        /// All users in a channel must use the same encryption password. The encryption password is automatically cleared once a user leaves the channel.
        ///
        /// If an encryption password is not specified, the encryption functionality will be disabled.
        ///
        /// @note
        /// - Do not use this method for CDN live streaming.
        /// - For optimal transmission, ensure that the encrypted data size does not exceed the original data size + 16 bytes. 16 bytes is the maximum padding size for AES encryption.
        /// </summary>
        /// 
        /// <param name="secret">
        /// @param secret Pointer to the encryption password.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetEncryptionSecret(string secret)
        {
            return AgorartcNative.setEncryptionSecret(_apiBridge, secret);
        }

        /// <summary>
        /// **DEPRECATED** Sets the built-in encryption mode.
        ///
        /// @deprecated Deprecated as of v3.1.0. Use the \ref agora::rtc::IRtcEngine::enableEncryption "enableEncryption" instead.
        ///
        /// The Agora SDK supports built-in encryption, which is set to the @p aes-128-xts mode by default. Call this method to use other encryption modes.
        ///
        /// All users in the same channel must use the same encryption mode and password.
        ///
        /// Refer to the information related to the AES encryption algorithm on the differences between the encryption modes.
        ///
        /// @note Call the \ref IRtcEngine::setEncryptionSecret "setEncryptionSecret" method to enable the built-in encryption function before calling this method.
        /// </summary>
        /// 
        /// <param name="encryptionMode">
        /// @param encryptionMode Pointer to the set encryption mode:
        /// - "aes-128-xts": (Default) 128-bit AES encryption, XTS mode.
        /// - "aes-128-ecb": 128-bit AES encryption, ECB mode.
        /// - "aes-256-xts": 256-bit AES encryption, XTS mode.
        /// - "": When encryptionMode is set as NULL, the encryption mode is set as "aes-128-xts" by default.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetEncryptionMode(string encryptionMode)
        {
            return AgorartcNative.setEncryptionMode(_apiBridge, encryptionMode);
        }

        /// <summary>
        /// Creates a data stream.
        ///
        /// Each user can create up to five data streams during the lifecycle of the IRtcEngine.
        ///
        /// @note Set both the @p reliable and @p ordered parameters to true or false. Do not set one as true and the other as false.
        /// </summary>
        /// 
        /// <param name="streamId">
        /// @param streamId Pointer to the ID of the created data stream.
        /// </param>
        /// 
        /// <param name="reliable">
        /// @param reliable Sets whether or not the recipients are guaranteed to receive the data stream from the sender within five seconds:
        /// - true: The recipients receive the data stream from the sender within five seconds. If the recipient does not receive the data stream within five seconds, an error is reported to the application.
        /// - false: There is no guarantee that the recipients receive the data stream within five seconds and no error message is reported for any delay or missing data stream.
        /// </param>
        /// 
        /// <param name="ordered">
        /// @param ordered Sets whether or not the recipients receive the data stream in the sent order:
        /// - true: The recipients receive the data stream in the sent order.
        /// - false: The recipients do not receive the data stream in the sent order.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE CreateDataStream(IntPtr streamId, bool reliable, bool ordered)
        {
            return AgorartcNative.createDataStream(_apiBridge, streamId, reliable ? 1 : 0, ordered ? 1 : 0);
        }

        /// <summary>
        /// ///  Sends data stream messages to all users in a channel.
        ///
        /// The SDK has the following restrictions on this method:
        /// - Up to 30 packets can be sent per second in a channel with each packet having a maximum size of 1 kB.
        /// - Each client can send up to 6 kB of data per second.
        /// - Each user can have up to five data streams simultaneously.
        ///
        /// A successful \ref agora::rtc::IRtcEngine::sendStreamMessage "sendStreamMessage" method call triggers the
        /// \ref agora::rtc::IRtcEngineEventHandler::onStreamMessage "onStreamMessage" callback on the remote client, from which the remote user gets the stream message.
        ///
        /// A failed \ref agora::rtc::IRtcEngine::sendStreamMessage "sendStreamMessage" method call triggers the
        ///  \ref agora::rtc::IRtcEngineEventHandler::onStreamMessage "onStreamMessage" callback on the remote client.
        /// @note This method applies only to the `COMMUNICATION` profile or to the hosts in the `LIVE_BROADCASTING` profile. If an audience in the `LIVE_BROADCASTING` profile calls this method, the audience may be switched to a host.
        /// </summary>
        /// 
        /// <param name="streamId">
        /// @param  streamId  ID of the sent data stream, returned in the \ref IRtcEngine::createDataStream "createDataStream" method.
        /// </param>
        /// 
        /// <param name="data">
        /// @param data Pointer to the sent data.
        /// </param>
        /// 
        /// <param name="length">
        /// @param length Length of the sent data.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SendStreamMessage(int streamId, string data, long length)
        {
            return AgorartcNative.sendStreamMessage(_apiBridge, streamId, data, length);
        }

        /// <summary>
        /// Publishes the local stream to a specified CDN live RTMP address.  (CDN live only.)
        ///
        /// The SDK returns the result of this method call in the \ref IRtcEngineEventHandler::onStreamPublished "onStreamPublished" callback.
        ///
        /// The \ref agora::rtc::IRtcEngine::addPublishStreamUrl "addPublishStreamUrl" method call triggers the \ref agora::rtc::IRtcEngineEventHandler::onRtmpStreamingStateChanged "onRtmpStreamingStateChanged" callback on the local client to report the state of adding a local stream to the CDN.
        /// @note
        /// - Ensure that the user joins the channel before calling this method.
        /// - Ensure that you enable the RTMP Converter service before using this function. See  *Prerequisites* in the advanced guide *Push Streams to CDN*.
        /// - This method adds only one stream RTMP URL address each time it is called.
        /// - This method applies to `LIVE_BROADCASTING` only.
        /// </summary>
        /// 
        /// <param name="url">
        /// @param url The CDN streaming URL in the RTMP format. The maximum length of this parameter is 1024 bytes. The RTMP URL address must not contain special characters, such as Chinese language characters.
        /// </param>
        /// 
        /// <param name="transcodingEnabled">
        /// @param  transcodingEnabled Sets whether transcoding is enabled/disabled:
        /// - true: Enable transcoding. To [transcode](https://docs.agora.io/en/Agora%20Platform/terms?platform=All%20Platforms#transcoding) the audio or video streams when publishing them to CDN live, often used for combining the audio and video streams of multiple hosts in CDN live. If you set this parameter as `true`, ensure that you call the \ref IRtcEngine::setLiveTranscoding "setLiveTranscoding" method before this method.
        /// - false: Disable transcoding.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        ///       - #ERR_INVALID_ARGUMENT (2): The RTMP URL address is NULL or has a string length of 0.
        ///       - #ERR_NOT_INITIALIZED (7): You have not initialized the RTC engine when publishing the stream.
        /// </returns>
        public ERROR_CODE AddPublishStreamUrl(string url, bool transcodingEnabled)
        {
            return AgorartcNative.addPublishStreamUrl(_apiBridge, url, transcodingEnabled ? 1 : 0);
        }

        /// <summary>
        /// Removes an RTMP stream from the CDN. (CDN live only.)
        ///
        /// This method removes the RTMP URL address (added by the \ref IRtcEngine::addPublishStreamUrl "addPublishStreamUrl" method) from a CDN live stream. The SDK returns the result of this method call in the \ref IRtcEngineEventHandler::onStreamUnpublished "onStreamUnpublished" callback.
        ///
        /// The \ref agora::rtc::IRtcEngine::removePublishStreamUrl "removePublishStreamUrl" method call triggers the \ref agora::rtc::IRtcEngineEventHandler::onRtmpStreamingStateChanged "onRtmpStreamingStateChanged" callback on the local client to report the state of removing an RTMP stream from the CDN.
        /// @note
        /// - This method removes only one RTMP URL address each time it is called.
        /// - The RTMP URL address must not contain special characters, such as Chinese language characters.
        /// - This method applies to `LIVE_BROADCASTING` only.
        /// </summary>
        /// 
        /// <param name="url">
        /// @param url The RTMP URL address to be removed. The maximum length of this parameter is 1024 bytes.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE RemovePublishStreamUrl(string url)
        {
            return AgorartcNative.removePublishStreamUrl(_apiBridge, url);
        }

        /// <summary>
        /// Sets the video layout and audio settings for CDN live. (CDN live only.)
        ///
        /// The SDK triggers the \ref agora::rtc::IRtcEngineEventHandler::onTranscodingUpdated "onTranscodingUpdated" callback when you call the `setLiveTranscoding` method to update the transcoding setting.
        ///
        /// @note
        /// - This method applies to `LIVE_BROADCASTING` only.
        /// - Ensure that you enable the RTMP Converter service before using this function. See *Prerequisites* in the advanced guide *Push Streams to CDN*.
        /// - If you call the `setLiveTranscoding` method to update the transcoding setting for the first time, the SDK does not trigger the `onTranscodingUpdated` callback.
        /// </summary>
        /// 
        /// <param name="transcoding">
        /// @param transcoding Sets the CDN live audio/video transcoding settings. See LiveTranscoding.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetLiveTranscoding(ref LiveTranscoding transcoding)
        {
            return AgorartcNative.setLiveTranscoding(_apiBridge, ref transcoding);
        }

        /// <summary>
        /// **DEPRECATED** Adds a watermark image to the local video or CDN live stream.
        ///
        /// This method is deprecated from v2.9.1. Use \ref agora::rtc::IRtcEngine::addVideoWatermark(const char* watermarkUrl, const WatermarkOptions& options) "addVideoWatermark"2 instead.
        ///
        /// This method adds a PNG watermark image to the local video stream for the recording device, channel audience, and CDN live audience to view and capture.
        ///
        /// To add the PNG file to the CDN live publishing stream, see the \ref IRtcEngine::setLiveTranscoding "setLiveTranscoding" method.
        /// </summary>
        /// 
        /// <param name="watermark">
        /// @param watermark Pointer to the watermark image to be added to the local video stream. See RtcImage.
        /// @note
        /// - The URL descriptions are different for the local video and CDN live streams:
        ///    - In a local video stream, `url` in RtcImage refers to the absolute path of the added watermark image file in the local video stream.
        ///    - In a CDN live stream, `url` in RtcImage refers to the URL address of the added watermark image in the CDN live streaming.
        /// - The source file of the watermark image must be in the PNG file format. If the width and height of the PNG file differ from your settings in this method, the PNG file will be cropped to conform to your settings.
        /// - The Agora SDK supports adding only one watermark image onto a local video or CDN live stream. The newly added watermark image replaces the previous one.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE AddVideoWatermark(RtcImage watermark)
        {
            return AgorartcNative.addVideoWatermark(_apiBridge, watermark);
        }

        /// <summary>
        /// Adds a watermark image to the local video.
        ///
        /// This method adds a PNG watermark image to the local video in the live streaming. Once the watermark image is added, all the audience in the channel (CDN audience included),
        /// and the recording device can see and capture it. Agora supports adding only one watermark image onto the local video, and the newly watermark image replaces the previous one.
        ///
        /// The watermark position depends on the settings in the \ref IRtcEngine::setVideoEncoderConfiguration "setVideoEncoderConfiguration" method:
        /// - If the orientation mode of the encoding video is #ORIENTATION_MODE_FIXED_LANDSCAPE, or the landscape mode in #ORIENTATION_MODE_ADAPTIVE, the watermark uses the landscape orientation.
        /// - If the orientation mode of the encoding video is #ORIENTATION_MODE_FIXED_PORTRAIT, or the portrait mode in #ORIENTATION_MODE_ADAPTIVE, the watermark uses the portrait orientation.
        /// - When setting the watermark position, the region must be less than the dimensions set in the `setVideoEncoderConfiguration` method. Otherwise, the watermark image will be cropped.
        ///
        /// @note
        /// - Ensure that you have called the \ref agora::rtc::IRtcEngine::enableVideo "enableVideo" method to enable the video module before calling this method.
        /// - If you only want to add a watermark image to the local video for the audience in the CDN live streaming channel to see and capture, you can call this method or the \ref agora::rtc::IRtcEngine::setLiveTranscoding "setLiveTranscoding" method.
        /// - This method supports adding a watermark image in the PNG file format only. Supported pixel formats of the PNG image are RGBA, RGB, Palette, Gray, and Alpha_gray.
        /// - If the dimensions of the PNG image differ from your settings in this method, the image will be cropped or zoomed to conform to your settings.
        /// - If you have enabled the local video preview by calling the \ref agora::rtc::IRtcEngine::startPreview "startPreview" method, you can use the `visibleInPreview` member in the WatermarkOptions class to set whether or not the watermark is visible in preview.
        /// - If you have enabled the mirror mode for the local video, the watermark on the local video is also mirrored. To avoid mirroring the watermark, Agora recommends that you do not use the mirror and watermark functions for the local video at the same time. You can implement the watermark function in your application layer.
        /// </summary>
        /// 
        /// <param name="watermarkUrl">
        /// @param watermarkUrl The local file path of the watermark image to be added. This method supports adding a watermark image from the local absolute or relative file path.
        /// </param>
        /// 
        /// <param name="options">
        /// @param options Pointer to the watermark's options to be added. See WatermarkOptions for more infomation.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE AddVideoWatermark2(string watermarkUrl, WatermarkOptions options)
        {
            return AgorartcNative.addVideoWatermark2(_apiBridge, watermarkUrl, options);
        }

        /// <summary>
        /// Removes the watermark image from the video stream added by the \ref agora::rtc::IRtcEngine::addVideoWatermark(const char* watermarkUrl, const WatermarkOptions& options) "addVideoWatermark" method.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE ClearVideoWatermarks()
        {
            return AgorartcNative.clearVideoWatermarks(_apiBridge);
        }

        /// <summary>
        /// @since v3.0.0
        ///
        /// Enables/Disables image enhancement and sets the options.
        ///
        /// @note
        /// - Call this method after calling the enableVideo method.
        /// - Currently this method does not apply for macOS.
        /// </summary>
        /// 
        /// <param name="enabled">
        /// @param enabled Sets whether or not to enable image enhancement:
        /// - true: enables image enhancement.
        /// - false: disables image enhancement.
        /// </param>
        /// 
        /// <param name="options">
        /// @param options Sets the image enhancement option. See BeautyOptions.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetBeautyEffectOptions(bool enabled, BeautyOptions options)
        {
            return AgorartcNative.setBeautyEffectOptions(_apiBridge, enabled ? 1 : 0, options);
        }

        /// <summary>
        /// Adds a voice or video stream URL address to the live streaming.
        ///
        /// The \ref IRtcEngineEventHandler::onStreamPublished "onStreamPublished" callback returns the inject status. If this method call is successful, the server pulls the voice or video stream and injects it into a live channel. This is applicable to scenarios where all audience members in the channel can watch a live show and interact with each other.
        ///
        /// The \ref agora::rtc::IRtcEngine::addInjectStreamUrl "addInjectStreamUrl" method call triggers the following callbacks:
        /// - The local client:
        ///  - \ref agora::rtc::IRtcEngineEventHandler::onStreamInjectedStatus "onStreamInjectedStatus" , with the state of the injecting the online stream.
        ///  - \ref agora::rtc::IRtcEngineEventHandler::onUserJoined "onUserJoined" (uid: 666), if the method call is successful and the online media stream is injected into the channel.
        /// - The remote client:
        ///  - \ref agora::rtc::IRtcEngineEventHandler::onUserJoined "onUserJoined" (uid: 666), if the method call is successful and the online media stream is injected into the channel.
        ///
        /// @note
        /// - Ensure that you enable the RTMP Converter service before using this function. See *Prerequisites* in the advanced guide *Push Streams to CDN*.
        /// - This method applies to the Native SDK v2.4.1 and later.
        /// - This method applies to the `LIVE_BROADCASTING` profile only.
        /// - You can inject only one media stream into the channel at the same time.
        /// </summary>
        /// 
        /// <param name="url">
        /// @param url Pointer to the URL address to be added to the ongoing streaming. Valid protocols are RTMP, HLS, and HTTP-FLV.
        /// - Supported audio codec type: AAC.
        /// - Supported video codec type: H264 (AVC).
        /// </param>
        /// 
        /// <param name="config">
        /// @param config Pointer to the InjectStreamConfig object that contains the configuration of the added voice or video stream.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        ///    - #ERR_INVALID_ARGUMENT (2): The injected URL does not exist. Call this method again to inject the stream and ensure that the URL is valid.
        ///    - #ERR_NOT_READY (3): The user is not in the channel.
        ///    - #ERR_NOT_SUPPORTED (4): The channel profile is not `LIVE_BROADCASTING`. Call the \ref agora::rtc::IRtcEngine::setChannelProfile "setChannelProfile" method and set the channel profile to `LIVE_BROADCASTING` before calling this method.
        ///    - #ERR_NOT_INITIALIZED (7): The SDK is not initialized. Ensure that the IRtcEngine object is initialized before calling this method.
        /// </returns>
        public ERROR_CODE AddInjectStreamUrl(string url, InjectStreamConfig config)
        {
            return AgorartcNative.addInjectStreamUrl(_apiBridge, url, config);
        }

        /// <summary>
        /// Starts to relay media streams across channels.
        /// 
        ///  After a successful method call, the SDK triggers the
        ///  \ref agora::rtc::IRtcEngineEventHandler::onChannelMediaRelayStateChanged
        ///   "onChannelMediaRelayStateChanged" and
        ///  \ref agora::rtc::IRtcEngineEventHandler::onChannelMediaRelayEvent
        ///  "onChannelMediaRelayEvent" callbacks, and these callbacks return the
        ///  state and events of the media stream relay.
        ///  - If the
        ///  \ref agora::rtc::IRtcEngineEventHandler::onChannelMediaRelayStateChanged
        ///   "onChannelMediaRelayStateChanged" callback returns
        ///  #RELAY_STATE_RUNNING (2) and #RELAY_OK (0), and the
        ///  \ref agora::rtc::IRtcEngineEventHandler::onChannelMediaRelayEvent
        ///  "onChannelMediaRelayEvent" callback returns
        ///  #RELAY_EVENT_PACKET_SENT_TO_DEST_CHANNEL (4), the host starts
        ///  sending data to the destination channel.
        ///  - If the
        ///  \ref agora::rtc::IRtcEngineEventHandler::onChannelMediaRelayStateChanged
        ///   "onChannelMediaRelayStateChanged" callback returns
        ///  #RELAY_STATE_FAILURE (3), an exception occurs during the media stream
        ///  relay.
        /// 
        ///  @note
        ///  - Call this method after the \ref joinChannel() "joinChannel" method.
        ///  - This method takes effect only when you are a host in a
        ///  `LIVE_BROADCASTING` channel.
        ///  - After a successful method call, if you want to call this method
        ///  again, ensure that you call the
        ///  \ref stopChannelMediaRelay() "stopChannelMediaRelay" method to quit the
        ///  current relay.
        ///  - Contact sales-us@agora.io before implementing this function.
        ///  - We do not support string user accounts in this API.
        /// </summary>
        /// 
        /// <param name="configuration">
        ///  @param configuration The configuration of the media stream relay:
        ///  ChannelMediaRelayConfiguration.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            return AgorartcNative.startChannelMediaRelay(_apiBridge, configuration);
        }

        /// <summary>
        ///  Updates the channels for media stream relay. After a successful
        ///  \ref startChannelMediaRelay() "startChannelMediaRelay" method call, if
        ///  you want to relay the media stream to more channels, or leave the
        ///  current relay channel, you can call the
        ///  \ref updateChannelMediaRelay() "updateChannelMediaRelay" method.
        /// 
        ///  After a successful method call, the SDK triggers the
        ///  \ref agora::rtc::IRtcEngineEventHandler::onChannelMediaRelayEvent
        ///   "onChannelMediaRelayEvent" callback with the
        ///  #RELAY_EVENT_PACKET_UPDATE_DEST_CHANNEL (7) state code.
        /// 
        ///  @note
        ///  Call this method after the
        ///  \ref startChannelMediaRelay() "startChannelMediaRelay" method to update
        ///  the destination channel.
        /// </summary>
        /// 
        /// <param name="configuration">
        ///  @param configuration The media stream relay configuration:
        ///  ChannelMediaRelayConfiguration.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            return AgorartcNative.updateChannelMediaRelay(_apiBridge, configuration);
        }

        /// <summary>
        ///  Stops the media stream relay.
        /// 
        ///  Once the relay stops, the host quits all the destination
        ///  channels.
        /// 
        ///  After a successful method call, the SDK triggers the
        ///  \ref agora::rtc::IRtcEngineEventHandler::onChannelMediaRelayStateChanged
        ///   "onChannelMediaRelayStateChanged" callback. If the callback returns
        ///  #RELAY_STATE_IDLE (0) and #RELAY_OK (0), the host successfully
        ///  stops the relay.
        /// 
        ///  @note
        ///  If the method call fails, the SDK triggers the
        ///  \ref agora::rtc::IRtcEngineEventHandler::onChannelMediaRelayStateChanged
        ///   "onChannelMediaRelayStateChanged" callback with the
        ///  #RELAY_ERROR_SERVER_NO_RESPONSE (2) or
        ///  #RELAY_ERROR_SERVER_CONNECTION_LOST (8) state code. You can leave the
        ///  channel by calling the \ref leaveChannel() "leaveChannel" method, and
        ///  the media stream relay automatically stops.
        /// </summary>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StopChannelMediaRelay()
        {
            return AgorartcNative.stopChannelMediaRelay(_apiBridge);
        }

        /// <summary>
        /// Removes the voice or video stream URL address from the live streaming.
        ///
        /// This method removes the URL address (added by the \ref IRtcEngine::addInjectStreamUrl "addInjectStreamUrl" method) from the live streaming.
        ///
        /// @note If this method is called successfully, the SDK triggers the \ref IRtcEngineEventHandler::onUserOffline "onUserOffline" callback and returns a stream uid of 666.
        /// </summary>
        /// 
        /// <param name="url">
        /// @param url Pointer to the URL address of the injected stream to be removed.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE RemoveInjectStreamUrl(string url)
        {
            return AgorartcNative.removeInjectStreamUrl(_apiBridge, url);
        }

        /// <summary>
        /// Gets the current connection state of the SDK.
        /// </summary>
        /// 
        /// <returns>
        /// @return #CONNECTION_STATE_TYPE.
        /// </returns>
        public CONNECTION_STATE_TYPE GetConnectionState()
        {
            return AgorartcNative.getConnectionState(_apiBridge);
        }

        /// <summary>
        /// Provides technical preview functionalities or special customizations by configuring the SDK with JSON options.
        ///
        /// The JSON options are not public by default. Agora is working on making commonly used JSON options public in a standard way.
        /// </summary>
        /// 
        /// <param name="parameters">
        /// @param parameters Sets the parameter as a JSON string in the specified format.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetParameters(string parameters)
        {
            return AgorartcNative.setParameters(_apiBridge, parameters);
        }

        /// <summary>
        /// Sets the volume of the audio playback device.
        /// </summary>
        /// 
        /// <param name="volume">
        /// @param volume Sets the volume of the audio playback device. The value ranges between 0 (lowest volume) and 255 (highest volume).
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE SetPlaybackDeviceVolume(int volume)
        {
            return AgorartcNative.setPlaybackDeviceVolume(_apiBridge, volume);
        }

        // API_TYPE_AUDIO_EFFECT
        /// <summary>
        /// Starts playing and mixing the music file.
        ///
        /// This method mixes the specified local audio file with the audio stream from the microphone, or replaces the microphone's audio stream with the specified local audio file. You can choose whether the other user can hear the local audio playback and specify the number of playback loops. This method also supports online music playback.
        ///
        /// When the audio mixing file playback finishes after calling this method, the SDK triggers the \ref agora::rtc::IRtcEngineEventHandler::onAudioMixingFinished "onAudioMixingFinished" callback.
        ///
        /// A successful \ref agora::rtc::IRtcEngine::startAudioMixing "startAudioMixing" method call triggers the \ref agora::rtc::IRtcEngineEventHandler::onAudioMixingStateChanged "onAudioMixingStateChanged" (PLAY) callback on the local client.
        ///
        /// When the audio mixing file playback finishes, the SDK triggers the \ref agora::rtc::IRtcEngineEventHandler::onAudioMixingStateChanged "onAudioMixingStateChanged" (STOPPED) callback on the local client.
        /// @note
        /// - Call this method after joining a channel, otherwise issues may occur.
        /// - If the local audio mixing file does not exist, or if the SDK does not support the file format or cannot access the music file URL, the SDK returns WARN_AUDIO_MIXING_OPEN_ERROR = 701.
        /// - If you want to play an online music file, ensure that the time interval between calling this method is more than 100 ms, or the AUDIO_MIXING_ERROR_TOO_FREQUENT_CALL(702) error code occurs.
        /// </summary>
        /// 
        /// <param name="filePath">
        /// @param filePath Pointer to the absolute path (including the suffixes of the filename) of the local or online audio file to mix, for example, c:/music/audio.mp4. Supported audio formats: 3GP, ASF, ADTS, AVI, MP3, MP4, MPEG-4, SAMI, and WAVE. For more information, see [Supported Media Formats in Media Foundation](https://docs.microsoft.com/en-us/windows/desktop/medfound/supported-media-formats-in-media-foundation).
        /// </param>
        /// 
        /// <param name="loopback">
        /// @param loopback Sets which user can hear the audio mixing:
        /// - true: Only the local user can hear the audio mixing.
        /// - false: Both users can hear the audio mixing.
        /// </param>
        /// 
        /// <param name="replace">
        /// @param replace Sets the audio mixing content:
        /// - true: Only publish the specified audio file. The audio stream from the microphone is not published.
        /// - false: The local audio file is mixed with the audio stream from the microphone.
        /// </param>
        /// 
        /// <param name="cycle">
        /// @param cycle Sets the number of playback loops:
        /// - Positive integer: Number of playback loops.
        /// - `-1`: Infinite playback loops.
        /// </param>
        /// 
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt;0: Failure.
        /// </returns>
        public ERROR_CODE StartAudioMixing(string filePath, bool loopback, bool replace, int cycle)
        {
            return AgorartcNative.startAudioMixing(_apiBridge, filePath, loopback ? 1 : 0, replace ? 1 : 0, cycle);
        }

        /// <summary>
        /// Stops playing and mixing the music file.
        /// Call this method when you are in a channel.
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE StopAudioMixing()
        {
            return AgorartcNative.stopAudioMixing(_apiBridge);
        }

        /// <summary>
        /// Stops playing and mixing the music file.
        /// Call this method when you are in a channel.
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE PauseAudioMixing()
        {
            return AgorartcNative.pauseAudioMixing(_apiBridge);
        }

        /// <summary>
        /// Resumes playing and mixing the music file.
        /// Call this method when you are in a channel.
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE ResumeAudioMixing()
        {
            return AgorartcNative.resumeAudioMixing(_apiBridge);
        }

        /// <summary>
        /// **DEPRECATED** Agora does not recommend using this method.
        /// Sets the high-quality audio preferences. Call this method and set all parameters before joining a channel.
        /// Do not call this method again after joining a channel.
        /// </summary>
        ///
        /// <param name="fullband">
        /// @param fullband Sets whether to enable/disable full-band codec (48-kHz sample rate). Not compatible with SDK versions before v1.7.4:
        /// - true: Enable full-band codec.
        /// - false: Disable full-band codec.
        /// </param>
        ///
        /// <param name="stereo">
        /// @param  stereo Sets whether to enable/disable stereo codec. Not compatible with SDK versions before v1.7.4:
        /// - true: Enable stereo codec.
        /// - false: Disable stereo codec.
        /// </param>
        ///
        /// <param name="fullBitrate">
        /// @param fullBitrate Sets whether to enable/disable high-bitrate mode. Recommended in voice-only mode:
        /// - true: Enable high-bitrate mode.
        /// - false: Disable high-bitrate mode.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetHighQualityAudioParameters(bool fullband, bool stereo, bool fullBitrate)
        {
            return AgorartcNative.setHighQualityAudioParameters(_apiBridge, fullband ? 1 : 0, stereo ? 1 : 0,
                fullBitrate ? 1 : 0);
        }

        /// <summary>
        /// Adjusts the volume during audio mixing.
        /// Call this method when you are in a channel.
        /// @note Calling this method does not affect the volume of audio effect file playback invoked by the \ref agora::rtc::IRtcEngine::playEffect "playEffect" method.
        /// </summary>
        ///
        /// <param name="volume">
        /// @param volume Audio mixing volume. The value ranges between 0 and 100 (default).
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE AdjustAudioMixingVolume(int volume)
        {
            return AgorartcNative.adjustAudioMixingVolume(_apiBridge, volume);
        }

        /// <summary>
        /// Adjusts the audio mixing volume for local playback.
        /// @note Call this method when you are in a channel.
        /// </summary>
        ///
        /// <param name="volume">
        /// @param volume Audio mixing volume for local playback. The value ranges between 0 and 100 (default).
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE AdjustAudioMixingPlayoutVolume(int volume)
        {
            return AgorartcNative.adjustAudioMixingPlayoutVolume(_apiBridge, volume);
        }

        /// <summary>
        /// Retrieves the audio mixing volume for local playback.
        /// This method helps troubleshoot audio volume related issues.
        /// @note Call this method when you are in a channel.
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - >= 0: The audio mixing volume, if this method call succeeds. The value range is [0,100].
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE GetAudioMixingPlayoutVolume()
        {
            return AgorartcNative.getAudioMixingPlayoutVolume(_apiBridge);
        }

        /// <summary>
        /// Adjusts the audio mixing volume for publishing (for remote users).
        /// @note Call this method when you are in a channel.
        /// </summary>
        ///
        /// <param name="volume">
        /// @param volume Audio mixing volume for publishing. The value ranges between 0 and 100 (default).
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE AdjustAudioMixingPublishVolume(int volume)
        {
            return AgorartcNative.adjustAudioMixingPublishVolume(_apiBridge, volume);
        }

        /// <summary>
        /// Retrieves the audio mixing volume for publishing.
        /// This method helps troubleshoot audio volume related issues.
        /// @note Call this method when you are in a channel.
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - >= 0: The audio mixing volume for publishing, if this method call succeeds. The value range is [0,100].
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE GetAudioMixingPublishVolume()
        {
            return AgorartcNative.getAudioMixingPublishVolume(_apiBridge);
        }

        /// <summary>
        /// Retrieves the duration (ms) of the music file.
        /// Call this method when you are in a channel.
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - >= 0: The audio mixing duration, if this method call succeeds.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE GetAudioMixingDuration()
        {
            return AgorartcNative.getAudioMixingDuration(_apiBridge);
        }

        /// <summary>
        /// Retrieves the duration (ms) of the music file.
        /// Call this method when you are in a channel.
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - >= 0: The audio mixing duration, if this method call succeeds.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE GetAudioMixingCurrentPosition()
        {
            return AgorartcNative.getAudioMixingCurrentPosition(_apiBridge);
        }

        /// <summary>
        /// Sets the playback position of the music file to a different starting position (the default plays from the beginning).
        /// </summary>
        ///
        /// <param name="pos">
        /// @param pos The playback starting position (ms) of the music file.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetAudioMixingPosition(int pos /*in ms*/)
        {
            return AgorartcNative.setAudioMixingPosition(_apiBridge, pos);
        }

        
        public ERROR_CODE SetAudioMixingPitch(int pitch)
        {
            return AgorartcNative.setAudioMixingPitch(_apiBridge, pitch);
        }

        /// <summary>
        /// Retrieves the volume of the audio effects.
        /// The value ranges between 0.0 and 100.0.
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - >= 0: Volume of the audio effects, if this method call succeeds.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE GetEffectsVolume()
        {
            return AgorartcNative.getEffectsVolume(_apiBridge);
        }

        /// <summary>
        /// Retrieves the volume of the audio effects.
        /// The value ranges between 0.0 and 100.0.
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - >= 0: Volume of the audio effects, if this method call succeeds.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetEffectsVolume(int volume)
        {
            return AgorartcNative.setEffectsVolume(_apiBridge, volume);
        }

        /// <summary>
        /// Sets the volume of a specified audio effect.
        /// </summary>
        ///
        /// <param name="soundId">
        /// @param soundId ID of the audio effect. Each audio effect has a unique ID.
        /// </param>
        ///
        /// <param name="volume">
        /// @param volume Sets the volume of the specified audio effect. The value ranges between 0 and 100 (default).
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetVolumeOfEffect(int soundId, int volume)
        {
            return AgorartcNative.setVolumeOfEffect(_apiBridge, soundId, volume);
        }

        /// <summary>
        /// Plays a specified local or online audio effect file.
        /// This method allows you to set the loop count, pitch, pan, and gain of the audio effect file, as well as whether the remote user can hear the audio effect.
        /// To play multiple audio effect files simultaneously, call this method multiple times with different soundIds and filePaths. We recommend playing no more than three audio effect files at the same time.
        /// </summary>
        ///
        /// <param name="soundId">
        /// @param soundId ID of the specified audio effect. Each audio effect has a unique ID.
        /// @note
        /// - If the audio effect is preloaded into the memory through the \ref IRtcEngine::preloadEffect "preloadEffect" method, the value of @p soundID must be the same as that in the *preloadEffect* method.
        /// - Playing multiple online audio effect files simultaneously is not supported on macOS and Windows.
        /// </param>
        ///
        /// <param name="filePath">
        /// @param filePath Specifies the absolute path (including the suffixes of the filename) to the local audio effect file or the URL of the online audio effect file, for example, c:/music/audio.mp4. Supported audio formats: mp3, mp4, m4a, aac, 3gp, mkv and wav.
        /// </param>
        ///
        /// <param name="loopCount">
        /// @param loopCount Sets the number of times the audio effect loops:
        /// - 0: Play the audio effect once.
        /// - 1: Play the audio effect twice.
        /// - -1: Play the audio effect in an indefinite loop until the \ref IRtcEngine::stopEffect "stopEffect" or \ref IRtcEngine::stopAllEffects "stopAllEffects" method is called.
        /// </param>
        ///
        /// <param name="pitch">
        /// @param pitch Sets the pitch of the audio effect. The value ranges between 0.5 and 2. The default value is 1 (no change to the pitch). The lower the value, the lower the pitch.
        /// </param>
        ///
        /// <param name="pan">
        /// @param pan Sets the spatial position of the audio effect. The value ranges between -1.0 and 1.0:
        /// - 0.0: The audio effect displays ahead.
        /// - 1.0: The audio effect displays to the right.
        /// - -1.0: The audio effect displays to the left.
        /// </param>
        ///
        /// <param name="gain">
        /// @param gain  Sets the volume of the audio effect. The value ranges between 0 and 100 (default). The lower the value, the lower the volume of the audio effect.
        /// </param>
        ///
        /// <param name="publish">
        /// @param publish Sets whether or not to publish the specified audio effect to the remote stream:
        /// - true: The locally played audio effect is published to the Agora Cloud and the remote users can hear it.
        /// - false: The locally played audio effect is not published to the Agora Cloud and the remote users cannot hear it.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE PlayEffect(int soundId, string filePath, int loopCount, double pitch, double pan, int gain,
            bool publish)
        {
            return AgorartcNative.playEffect(_apiBridge, soundId, filePath, loopCount, pitch, pan, gain,
                publish ? 1 : 0);
        }

        /// <summary>
        /// Stops playing a specified audio effect.
        /// </summary>
        ///
        /// <param name="soundId">
        /// @param soundId ID of the audio effect to stop playing. Each audio effect has a unique ID.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE StopEffect(int soundId)
        {
            return AgorartcNative.stopEffect(_apiBridge, soundId);
        }

        /// <summary>
        /// Stops playing all audio effects.
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE StopAllEffects()
        {
            return AgorartcNative.stopAllEffects(_apiBridge);
        }

        /// <summary>
        /// Preloads a specified audio effect file into the memory.
        /// @note This method does not support online audio effect files.
        /// To ensure smooth communication, limit the size of the audio effect file. We recommend using this method to preload the audio effect before calling the \ref IRtcEngine::joinChannel "joinChannel" method.
        /// Supported audio formats: mp3, aac, m4a, 3gp, and wav.
        /// </summary>
        ///
        /// <param name="soundId">
        /// @param soundId ID of the audio effect. Each audio effect has a unique ID.
        /// </param>
        ///
        /// <param name="filePath">
        /// @param filePath Pointer to the absolute path of the audio effect file.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE PreloadEffect(int soundId, string filePath)
        {
            return AgorartcNative.preloadEffect(_apiBridge, soundId, filePath);
        }

        /// <summary>
        /// Pauses all audio effects.
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE UnloadEffect(int soundId)
        {
            return AgorartcNative.unloadEffect(_apiBridge, soundId);
        }

        /// <summary>
        /// Pauses a specified audio effect.
        /// </summary>
        ///
        /// <param name="soundId">
        /// @param soundId ID of the audio effect. Each audio effect has a unique ID.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE PauseEffect(int soundId)
        {
            return AgorartcNative.pauseEffect(_apiBridge, soundId);
        }

        /// <summary>
        /// Pauses all audio effects.
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE PauseAllEffects()
        {
            return AgorartcNative.pauseAllEffects(_apiBridge);
        }

        /// <summary>
        /// Resumes playing a specified audio effect.
        /// </summary>
        ///
        /// <param name="soundId">
        /// @param soundId ID of the audio effect. Each audio effect has a unique ID.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE ResumeEffect(int soundId)
        {
            return AgorartcNative.resumeEffect(_apiBridge, soundId);
        }

        /// <summary>
        /// Resumes playing all audio effects.
        /// </summary>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE ResumeAllEffects()
        {
            return AgorartcNative.resumeAllEffects(_apiBridge);
        }

        /// <summary>
        /// Enables/Disables stereo panning for remote users.
        /// Ensure that you call this method before joinChannel to enable stereo panning for remote users so that the local user can track the position of a remote user by calling \ref agora::rtc::IRtcEngine::setRemoteVoicePosition "setRemoteVoicePosition".
        /// </summary>
        ///
        /// <param name="enabled">
        /// @param enabled Sets whether or not to enable stereo panning for remote users:
        /// - true: enables stereo panning.
        /// - false: disables stereo panning.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE EnableSoundPositionIndication(bool enabled)
        {
            return AgorartcNative.enableSoundPositionIndication(_apiBridge, enabled ? 1 : 0);
        }

        /// <summary>
        /// Changes the voice pitch of the local speaker.
        /// </summary>
        ///
        /// <param name="pitch">
        /// @param pitch Sets the voice pitch. The value ranges between 0.5 and 2.0. The lower the value, the lower the voice pitch. The default value is 1.0 (no change to the local voice pitch).
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetLocalVoicePitch(double pitch)
        {
            return AgorartcNative.setLocalVoicePitch(_apiBridge, pitch);
        }

        /// <summary>
        /// Sets the local voice equalization effect.
        /// </summary>
        ///
        /// <param name="bandFrequency">
        /// @param bandFrequency Sets the band frequency. The value ranges between 0 and 9, representing the respective 10-band center frequencies of the voice effects, including 31, 62, 125, 500, 1k, 2k, 4k, 8k, and 16k Hz. See #AUDIO_EQUALIZATION_BAND_FREQUENCY.
        /// </param>
        ///
        /// <param name="bandGain">
        /// @param bandGain  Sets the gain of each band in dB. The value ranges between -15 and 15.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency, int bandGain)
        {
            return AgorartcNative.setLocalVoiceEqualization(_apiBridge, bandFrequency, bandGain);
        }

        /// <summary>
        ///  Sets the local voice reverberation.
        /// v2.4.0 adds the \ref agora::rtc::IRtcEngine::setLocalVoiceReverbPreset "setLocalVoiceReverbPreset" method, a more user-friendly method for setting the local voice reverberation. You can use this method to set the local reverberation effect, such as pop music, R&amp;B, rock music, and hip-hop.
        /// </summary>
        ///
        /// <param name="reverbKey">
        /// @param reverbKey Sets the reverberation key. See #AUDIO_REVERB_TYPE.
        /// </param>
        ///
        /// <param name="value">
        /// @param value Sets the value of the reverberation key.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value)
        {
            return AgorartcNative.setLocalVoiceReverb(_apiBridge, reverbKey, value);
        }

        /// <summary>
        /// Sets the local voice changer option.
        /// This method can be used to set the local voice effect for users in a `COMMUNICATION` channel or hosts in a `LIVE_BROADCASTING` channel.
        /// Voice changer options include the following voice effects:
        /// - `VOICE_CHANGER_XXX`: Changes the local voice to an old man, a little boy, or the Hulk. Applies to the voice talk scenario.
        /// - `VOICE_BEAUTY_XXX`: Beautifies the local voice by making it sound more vigorous, resounding, or adding spacial resonance. Applies to the voice talk and singing scenario.
        /// - `GENERAL_VOICE_BEAUTY_XXX`: Adds gender-based beautification effect to the local voice. Applies to the voice talk scenario.
        /// - For a male voice: Adds magnetism to the voice.
        /// - For a female voice: Adds freshness or vitality to the voice.
        /// @note
        /// - To achieve better voice effect quality, Agora recommends setting the profile parameter in `setAudioProfile` as `AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4)` or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)`.
        /// - This method works best with the human voice, and Agora does not recommend using it for audio containing music and a human voice.
        /// - Do not use this method with `setLocalVoiceReverbPreset`, because the method called later overrides the one called earlier. For detailed considerations, see the advanced guide *Voice Changer and Reverberation*.
        /// </summary>
        ///
        /// <param name="voiceChanger">
        /// @param voiceChanger Sets the local voice changer option. The default value is `VOICE_CHANGER_OFF`, which means the original voice. See details in #VOICE_CHANGER_PRESET.
        /// Gender-based beatification effect works best only when assigned a proper gender:
        /// - For male: `GENERAL_BEAUTY_VOICE_MALE_MAGNETIC`.
        /// - For female: `GENERAL_BEAUTY_VOICE_FEMALE_FRESH` or `GENERAL_BEAUTY_VOICE_FEMALE_VITALITY`.
        /// Failure to do so can lead to voice distortion.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure. Check if the enumeration is properly set.
        /// </returns>
        public ERROR_CODE SetLocalVoiceChanger(VOICE_CHANGER_PRESET voiceChanger)
        {
            return AgorartcNative.setLocalVoiceChanger(_apiBridge, voiceChanger);
        }


        /// <summary>
        /// Sets the local voice reverberation option, including the virtual stereo.
        ///
        /// This method sets the local voice reverberation for users in a `COMMUNICATION` channel or hosts in a `LIVE_BROADCASTING` channel.
        /// After successfully calling this method, all users in the channel can hear the voice with reverberation.
        ///
        /// @note
        /// - When calling this method with enumerations that begin with `AUDIO_REVERB_FX`, ensure that you set profile in `setAudioProfile` as
        /// `AUDIO_PROFILE_MUSIC_HIGH_QUALITY(4)` or `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)`; otherwise, this methods cannot set the corresponding voice reverberation option.
        /// - When calling this method with `AUDIO_VIRTUAL_STEREO`, Agora recommends setting the `profile` parameter in `setAudioProfile` as `AUDIO_PROFILE_MUSIC_HIGH_QUALITY_STEREO(5)`.
        /// - This method works best with the human voice, and Agora does not recommend using it for audio containing music and a human voice.
        /// - Do not use this method with `setLocalVoiceChanger`, because the method called later overrides the one called earlier.
        /// For detailed considerations, see the advanced guide *Voice Changer and Reverberation*.
        /// </summary>
        ///
        /// <param name="reverbPreset">
        /// @param reverbPreset The local voice reverberation option. The default value is `AUDIO_REVERB_OFF`,
        /// which means the original voice.  See #AUDIO_REVERB_PRESET.
        /// To achieve better voice effects, Agora recommends the enumeration whose name begins with `AUDIO_REVERB_FX`.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetLocalVoiceReverbPreset(AUDIO_REVERB_PRESET reverbPreset)
        {
            return AgorartcNative.setLocalVoiceReverbPreset(_apiBridge, reverbPreset);
        }

        /// <summary>
        /// Sets the external audio source. Please call this method before \ref agora::rtc::IRtcEngine::joinChannel "joinChannel".
        /// </summary>
        ///
        /// <param name="enabled">
        /// @param enabled Sets whether to enable/disable the external audio source:
        /// - true: Enables the external audio source.
        /// - false: (Default) Disables the external audio source.
        /// </param>
        ///
        /// <param name="sampleRate">
        /// @param sampleRate Sets the sample rate (Hz) of the external audio source, which can be set as 8000, 16000, 32000, 44100, or 48000 Hz.
        /// </param>
        ///
        /// <param name="channels">
        /// @param channels Sets the number of audio channels of the external audio source:
        /// - 1: Mono.
        /// - 2: Stereo.
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetExternalAudioSource(bool enabled, int sampleRate, int channels)
        {
            return AgorartcNative.setExternalAudioSource(_apiBridge, enabled ? 1 : 0, sampleRate, channels);
        }

        /// <summary>
        /// Sets the external audio sink.
        /// This method applies to scenarios where you want to use external audio
        /// data for playback. After enabling the external audio sink, you can call
        /// the \ref agora::media::IMediaEngine::pullAudioFrame "pullAudioFrame" method to pull the remote audio data, process
        /// it, and play it with the audio effects that you want.
        ///
        /// @note
        /// Once you enable the external audio sink, the app will not retrieve any
        /// audio data from the
        /// \ref agora::media::IAudioFrameObserver::onPlaybackAudioFrame "onPlaybackAudioFrame" callback.
        ///
        /// </summary>
        ///
        /// <param name="enabled">
        /// @param enabled
        /// - true: Enables the external audio sink.
        /// - false: (Default) Disables the external audio sink.
        /// </param>
        ///
        /// <param name="sampleRate">
        /// @param sampleRate Sets the sample rate (Hz) of the external audio sink, which can be set as 16000, 32000, 44100 or 48000.
        /// </param>
        ///
        /// <param name="channels">
        /// @param channels Sets the number of audio channels of the external
        /// audio sink:
        /// - 1: Mono.
        /// - 2: Stereo.
        ///
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetExternalAudioSink(bool enabled, int sampleRate, int channels)
        {
            return AgorartcNative.setExternalAudioSink(_apiBridge, enabled ? 1 : 0, sampleRate, channels);
        }

        /// <summary>
        /// Sets the audio recording format for the \ref agora::media::IAudioFrameObserver::onRecordAudioFrame "onRecordAudioFrame" callback.
        /// </summary>
        ///
        /// <param name="sampleRate">
        /// @param sampleRate Sets the sample rate (@p samplesPerSec) returned in the *onRecordAudioFrame* callback, which can be set as 8000, 16000, 32000, 44100, or 48000 Hz.
        /// </param>
        ///
        /// <param name="channel">
        /// @param channel Sets the number of audio channels (@p channels) returned in the *onRecordAudioFrame* callback:
        /// - 1: Mono
        /// - 2: Stereo
        /// </param>
        ///
        /// <param name="mode">
        /// @param mode Sets the use mode (see #RAW_AUDIO_FRAME_OP_MODE_TYPE) of the *onRecordAudioFrame* callback.
        /// </param>
        ///
        /// <param name="samplesPerCall">
        /// @param samplesPerCall Sets the number of samples returned in the *onRecordAudioFrame* callback. `samplesPerCall` is usually set as 1024 for RTMP streaming.
        /// @note The SDK triggers the `onRecordAudioFrame` callback according to the sample interval. Ensure that the sample interval ≥ 0.01 (s). And, Sample interval (sec) = `samplePerCall`/(`sampleRate` × `channel`).
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetRecordingAudioFrameParameters(int sampleRate, int channel,
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            return AgorartcNative.setRecordingAudioFrameParameters(_apiBridge, sampleRate, channel, mode,
                samplesPerCall);
        }

        /// <summary>
        /// Sets the audio playback format for the \ref agora::media::IAudioFrameObserver::onPlaybackAudioFrame "onPlaybackAudioFrame" callback.
        /// </summary>
        ///
        /// <param name="sampleRate">
        /// @param sampleRate Sets the sample rate (@p samplesPerSec) returned in the *onPlaybackAudioFrame* callback, which can be set as 8000, 16000, 32000, 44100, or 48000 Hz.
        /// </param>
        ///
        /// <param name="channel">
        /// @param channel Sets the number of channels (@p channels) returned in the *onPlaybackAudioFrame* callback:
        /// - 1: Mono
        /// - 2: Stereo
        /// </param>
        ///
        /// <param name="mode">
        /// @param mode Sets the use mode (see #RAW_AUDIO_FRAME_OP_MODE_TYPE) of the *onPlaybackAudioFrame* callback.
        /// </param>
        ///
        /// <param name="samplesPerCall">
        /// @param samplesPerCall Sets the number of samples returned in the *onPlaybackAudioFrame* callback. `samplesPerCall` is usually set as 1024 for RTMP streaming.
        /// @note The SDK triggers the `onPlaybackAudioFrame` callback according to the sample interval. Ensure that the sample interval ≥ 0.01 (s). And, Sample interval (sec) = `samplePerCall`/(`sampleRate` × `channel`).
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetPlaybackAudioFrameParameters(int sampleRate, int channel,
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            return AgorartcNative.setPlaybackAudioFrameParameters(_apiBridge, sampleRate, channel, mode,
                samplesPerCall);
        }

        /// <summary>
        /// Sets the mixed audio format for the \ref agora::media::IAudioFrameObserver::onMixedAudioFrame "onMixedAudioFrame" callback.
        /// </summary>
        ///
        /// <param name="sampleRate">
        /// @param sampleRate Sets the sample rate (@p samplesPerSec) returned in the *onMixedAudioFrame* callback, which can be set as 8000, 16000, 32000, 44100, or 48000 Hz.
        /// </param>
        ///
        /// <param name="samplesPerCall">
        /// @param samplesPerCall Sets the number of samples (`samples`) returned in the *onMixedAudioFrame* callback. `samplesPerCall` is usually set as 1024 for RTMP streaming.
        /// @note The SDK triggers the `onMixedAudioFrame` callback according to the sample interval. Ensure that the sample interval ≥ 0.01 (s). And, Sample interval (sec) = `samplePerCall`/(`sampleRate` × `channels`).
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// </returns>
        public ERROR_CODE SetMixedAudioFrameParameters(int sampleRate, int samplesPerCall)
        {
            return AgorartcNative.setMixedAudioFrameParameters(_apiBridge, sampleRate, samplesPerCall);
        }

        
        public ERROR_CODE PushAudioFrame(MEDIA_SOURCE_TYPE type, ref AudioFrame frame, bool wrap)
        {
            return AgorartcNative.pushAudioFrame(_apiBridge, type, ref frame, wrap ? 1 : 0);
        }

        public ERROR_CODE PushAudioFrame2(ref AudioFrame frame)
        {
            return AgorartcNative.pushAudioFrame2(_apiBridge, ref frame);
        }

        public ERROR_CODE PullAudioFrame(ref AudioFrame frame)
        {
            return AgorartcNative.pullAudioFrame(_apiBridge, ref frame);
        }

        public ERROR_CODE SetExternalVideoSource(bool enable, bool useTexture)
        {
            return AgorartcNative.setExternalVideoSource(_apiBridge, enable ? 1 : 0, useTexture ? 1 : 0);
        }

        public ERROR_CODE PushVideoFrame(ref ExternalVideoFrame frame)
        {
            return AgorartcNative.pushVideoFrame(_apiBridge, ref frame);
        }

        /// <summary>
        /// Enables/Disables the built-in encryption.
        ///
        /// @since v3.1.0
        ///
        /// In scenarios requiring high security, Agora recommends calling this method to enable the built-in encryption before joining a channel.
        ///
        /// All users in the same channel must use the same encryption mode and encryption key. Once all users leave the channel, the encryption key of this channel is automatically cleared.
        ///
        /// @note
        /// - If you enable the built-in encryption, you cannot use the RTMP streaming function.
        /// - Agora supports four encryption modes. If you choose an encryption mode (excepting `SM4_128_ECB` mode), you need to add an external encryption library when integrating the SDK. See the advanced guide *Channel Encryption*.
        ///
        /// </summary>
        ///
        /// <param name="enabled">
        /// @param enabled Whether to enable the built-in encryption:
        /// - true: Enable the built-in encryption.
        /// - false: Disable the built-in encryption.
        /// </param>
        ///
        /// <param name="config">
        /// @param config Configurations of built-in encryption schemas. See EncryptionConfig.
        ///
        /// </param>
        ///
        /// <returns>
        /// @return
        /// - 0: Success.
        /// - &lt; 0: Failure.
        /// - -2(ERR_INVALID_ARGUMENT): An invalid parameter is used. Set the parameter with a valid value.
        /// - -4(ERR_NOT_SUPPORTED): The encryption mode is incorrect or the SDK fails to load the external encryption library. Check the enumeration or reload the external encryption library.
        /// - -7(ERR_NOT_INITIALIZED): The SDK is not initialized. Initialize the `IRtcEngine` instance before calling this method.
        /// </returns>
        public ERROR_CODE EnableEncryption(bool enabled, EncryptionConfig config)
        {
            return AgorartcNative.enableEncryption(_apiBridge, enabled ? 1 : 0, config);
        }

        public ERROR_CODE SendCustomReportMessage(string id, string category, string event1, string label, int value)
        {
            return AgorartcNative.sendCustomReportMessage(_apiBridge, id, category, event1, label, value);
        }

        ~AgoraRtcEngine()
        {
            Dispose(false, false);
        }
    }
}