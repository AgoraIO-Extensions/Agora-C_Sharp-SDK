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
            if (speakerNumber > 0)
            {
                var uids = new int[speakerNumber];
                var volumes = new int[speakerNumber];
                var vads = new int[speakerNumber];
                Marshal.Copy(uid, uids, 0, speakerNumber);
                Marshal.Copy(volume, volumes, 0, speakerNumber);
                Marshal.Copy(vad, vads, 0, speakerNumber);
                for (int i = 0; i < speakerNumber; i++)
                {
                    Console.WriteLine("onAudioVolumeIndication {0}, {1}, {2}, {3}, {4}", uids[i], volumes[i], vads[i], speakerNumber,totalVolume);
                }
               // Console.WriteLine("uids: {0}  {1}  {2}", uids[0], uids[1], uids[2]);
                // rtc.engineEventHandler.OnAudioVolumeIndication(ref uid, ref volume, ref vad, channelId, speakerNumber,
                //     totalVolume);
            }
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

        public AgoraRtcChannel CreateChannel(string channelId)
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

        public AgoraAudioPlaybackDeviceManager CreateAudioPlaybackDeviceManager()
        {
            var playbackDeviceManager = new AgoraAudioPlaybackDeviceManager(AgorartcNative.createAudioPlaybackDeviceManager(_apiBridge));
            _DeviceManagerList.Add(playbackDeviceManager);
            return playbackDeviceManager;
        }

        public void ReleaseAudioPlaybackDeviceManager(AgoraAudioPlaybackDeviceManager playbackDeviceManager)
        {
            _DeviceManagerList.Remove(playbackDeviceManager);
        }

        public AgoraAudioRecordingDeviceManager CreateAudioRecordingDeviceManager()
        {
            var recordingDeviceManager =
                new AgoraAudioRecordingDeviceManager(AgorartcNative.createAudioRecordingDeviceManager(_apiBridge));
            _DeviceManagerList.Add(recordingDeviceManager);
            return recordingDeviceManager;
        }

        public void ReleaseAudioRecordingDeviceManager(AgoraAudioRecordingDeviceManager recordingDeviceManager)
        {
            _DeviceManagerList.Remove(recordingDeviceManager);
        }

        public AgoraVideoDeviceManager CreateVideoDeviceManager()
        {
            var videoDeviceManager = new AgoraVideoDeviceManager(AgorartcNative.createVideoDeviceManager(_apiBridge));
            _DeviceManagerList.Add(videoDeviceManager);
            return videoDeviceManager;
        }

        public void ReleaseAgoraVideoDeviceManager(AgoraVideoDeviceManager videoDeviceManager)
        {
            _DeviceManagerList.Remove(videoDeviceManager);
        }

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

        public ERROR_CODE SetChannelProfile(CHANNEL_PROFILE_TYPE channelProfileType)
        {
            return AgorartcNative.setChannelProfile(_apiBridge, channelProfileType);
        }

        public ERROR_CODE SetClientRole(CLIENT_ROLE_TYPE role)
        {
            return AgorartcNative.setClientRole(_apiBridge, role);
        }

        public ERROR_CODE JoinChannel(string token, string channelId, string info, uint uid)
        {
            return AgorartcNative.joinChannel(_apiBridge, token, channelId, info, uid);
        }

        public ERROR_CODE SwitchChannel(string token, string channelId)
        {
            return AgorartcNative.switchChannel(_apiBridge, token, channelId);
        }

        public ERROR_CODE LeaveChannel()
        {
            return AgorartcNative.leaveChannel(_apiBridge);
        }

        public ERROR_CODE RenewToken(string token)
        {
            return AgorartcNative.renewToken(_apiBridge, token);
        }

        public ERROR_CODE RegisterLocalUserAccount(string appId, string userAccount)
        {
            return AgorartcNative.registerLocalUserAccount(_apiBridge, appId, userAccount);
        }

        public ERROR_CODE JoinChannelWithUserAccount(string token, string channelId, string userAccount)
        {
            return AgorartcNative.joinChannelWithUserAccount(_apiBridge, token, channelId, userAccount);
        }

        public ERROR_CODE GetUserInfoByUserAccount(string userAccount, ref UserInfo userInfo)
        {
            return AgorartcNative.getUserInfoByUserAccount(_apiBridge, userAccount, ref userInfo);
        }

        public ERROR_CODE GetUserInfoByUid(uid_t uid, ref UserInfo userInfo)
        {
            return AgorartcNative.getUserInfoByUid(_apiBridge, uid, ref userInfo);
        }

        public ERROR_CODE StartEchoTest()
        {
            return AgorartcNative.startEchoTest(_apiBridge);
        }

        public ERROR_CODE StartEchoTest2(int intervalInSeconds)
        {
            return AgorartcNative.startEchoTest2(_apiBridge, intervalInSeconds);
        }

        public ERROR_CODE StopEchoTest()
        {
            return AgorartcNative.stopEchoTest(_apiBridge);
        }

        public ERROR_CODE EnableVideo()
        {
            return AgorartcNative.enableVideo(_apiBridge);
        }

        public ERROR_CODE DisableVideo()
        {
            return AgorartcNative.disableVideo(_apiBridge);
        }

        public ERROR_CODE SetVideoProfile(VIDEO_PROFILE_TYPE profile, bool swapWidthAndHeight)
        {
            return AgorartcNative.setVideoProfile(_apiBridge, profile, swapWidthAndHeight ? 1 : 0);
        }

        public ERROR_CODE SetVideoEncoderConfiguration(VideoEncoderConfiguration config)
        {
            return AgorartcNative.setVideoEncoderConfiguration(_apiBridge, config);
        }

        public ERROR_CODE SetCameraCapturerConfiguration(CameraCapturerConfiguration config)
        {
            return AgorartcNative.setCameraCapturerConfiguration(_apiBridge, config);
        }

        public ERROR_CODE SetupLocalVideo(VideoCanvas canvas)
        {
            return AgorartcNative.setupLocalVideo(_apiBridge, canvas);
        }

        public ERROR_CODE SetupRemoteVideo(VideoCanvas canvas)
        {
            return AgorartcNative.setupRemoteVideo(_apiBridge, canvas);
        }

        public ERROR_CODE StartPreview()
        {
            return AgorartcNative.startPreview(_apiBridge);
        }

        public ERROR_CODE SetRemoteUserPriority(uid_t uid, PRIORITY_TYPE userPriority)
        {
            return AgorartcNative.setRemoteUserPriority(_apiBridge, uid, userPriority);
        }

        public ERROR_CODE StopPreview()
        {
            return AgorartcNative.stopPreview(_apiBridge);
        }

        public ERROR_CODE EnableAudio()
        {
            return AgorartcNative.enableAudio(_apiBridge);
        }

        public ERROR_CODE EnableLocalAudio(bool enabled)
        {
            return AgorartcNative.enableLocalAudio(_apiBridge, enabled ? 1 : 0);
        }

        public ERROR_CODE DisableAudio()
        {
            return AgorartcNative.disableAudio(_apiBridge);
        }

        public ERROR_CODE SetAudioProfile(AUDIO_PROFILE_TYPE profile,
            AUDIO_SCENARIO_TYPE scenario)
        {
            return AgorartcNative.setAudioProfile(_apiBridge, profile, scenario);
        }

        public ERROR_CODE MuteLocalAudioStream(bool mute)
        {
            return AgorartcNative.muteLocalAudioStream(_apiBridge, mute ? 1 : 0);
        }

        public ERROR_CODE MuteAllRemoteAudioStreams(bool mute)
        {
            return AgorartcNative.muteAllRemoteAudioStreams(_apiBridge, mute ? 1 : 0);
        }

        public ERROR_CODE SetDefaultMuteAllRemoteVideoStreams(bool mute)
        {
            return AgorartcNative.setDefaultMuteAllRemoteVideoStreams(_apiBridge, mute ? 1 : 0);
        }

        public ERROR_CODE AdjustUserPlaybackSignalVolume(uid_t uid, int volume)
        {
            return AgorartcNative.adjustUserPlaybackSignalVolume(_apiBridge, uid, volume);
        }

        public ERROR_CODE MuteRemoteAudioStream(uid_t userId, bool mute)
        {
            return AgorartcNative.muteRemoteAudioStream(_apiBridge, userId, mute ? 1 : 0);
        }

        public ERROR_CODE MuteLocalVideoStream(bool mute)
        {
            return AgorartcNative.muteLocalVideoStream(_apiBridge, mute ? 1 : 0);
        }

        public ERROR_CODE EnableLocalVideo(bool enabled)
        {
            return AgorartcNative.enableLocalVideo(_apiBridge, enabled ? 1 : 0);
        }

        public ERROR_CODE MuteAllRemoteVideoStreams(bool mute)
        {
            return AgorartcNative.muteAllRemoteVideoStreams(_apiBridge, mute ? 1 : 0);
        }

        public ERROR_CODE SetDefaultMuteAllRemoteAudioStreams(bool mute)
        {
            return AgorartcNative.setDefaultMuteAllRemoteAudioStreams(_apiBridge, mute ? 1 : 0);
        }

        public ERROR_CODE MuteRemoteVideoStream(uid_t userId, bool mute)
        {
            return AgorartcNative.muteRemoteVideoStream(_apiBridge, userId, mute ? 1 : 0);
        }

        public ERROR_CODE SetRemoteVideoStreamType(uid_t userId, REMOTE_VIDEO_STREAM_TYPE streamType)
        {
            return AgorartcNative.setRemoteVideoStreamType(_apiBridge, userId, streamType);
        }

        public ERROR_CODE SetRemoteDefaultVideoStreamType(REMOTE_VIDEO_STREAM_TYPE streamType)
        {
            return AgorartcNative.setRemoteDefaultVideoStreamType(_apiBridge, streamType);
        }

        public ERROR_CODE EnableAudioVolumeIndication(int interval, int smooth, bool report_vad)
        {
            return AgorartcNative.enableAudioVolumeIndication(_apiBridge, interval, smooth, report_vad ? 1 : 0);
        }

        public ERROR_CODE StartAudioRecording(string filePath, AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            return AgorartcNative.startAudioRecording(_apiBridge, filePath, quality);
        }

        public ERROR_CODE StartAudioRecording2(string filePath, int sampleRate, AUDIO_RECORDING_QUALITY_TYPE quality)
        {
            return AgorartcNative.startAudioRecording2(_apiBridge, filePath, sampleRate, quality);
        }

        public ERROR_CODE StopAudioRecording()
        {
            return AgorartcNative.stopAudioRecording(_apiBridge);
        }

        public ERROR_CODE SetRemoteVoicePosition(uid_t uid, double pan, double gain)
        {
            return AgorartcNative.setRemoteVoicePosition(_apiBridge, uid, pan, gain);
        }

        public ERROR_CODE SetLogFile(string file)
        {
            return AgorartcNative.setLogFile(_apiBridge, file);
        }

        public ERROR_CODE SetLogFilter(uint filter)
        {
            return AgorartcNative.setLogFilter(_apiBridge, filter);
        }

        public ERROR_CODE SetLogFileSize(uint fileSizeInKBytes)
        {
            return AgorartcNative.setLogFileSize(_apiBridge, fileSizeInKBytes);
        }

        public ERROR_CODE SetLocalRenderMode(RENDER_MODE_TYPE renderMode)
        {
            return AgorartcNative.setLocalRenderMode(_apiBridge, renderMode);
        }

        public ERROR_CODE SetLocalRenderMode2(RENDER_MODE_TYPE renderMode, VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            return AgorartcNative.setLocalRenderMode2(_apiBridge, renderMode, mirrorMode);
        }

        public ERROR_CODE SetRemoteRenderMode(uid_t userId, RENDER_MODE_TYPE renderMode)
        {
            return AgorartcNative.setRemoteRenderMode(_apiBridge, userId, renderMode);
        }

        public ERROR_CODE SetRemoteRenderMode2(uid_t userId, RENDER_MODE_TYPE renderMode,
            VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            return AgorartcNative.setRemoteRenderMode2(_apiBridge, userId, renderMode, mirrorMode);
        }

        public ERROR_CODE SetLocalVideoMirrorMode(VIDEO_MIRROR_MODE_TYPE mirrorMode)
        {
            return AgorartcNative.setLocalVideoMirrorMode(_apiBridge, mirrorMode);
        }

        public ERROR_CODE EnableDualStreamMode(bool enabled)
        {
            return AgorartcNative.enableDualStreamMode(_apiBridge, enabled ? 1 : 0);
        }

        public ERROR_CODE AdjustRecordingSignalVolume(int volume)
        {
            return AgorartcNative.adjustRecordingSignalVolume(_apiBridge, volume);
        }

        public ERROR_CODE AdjustPlaybackSignalVolume(int volume)
        {
            return AgorartcNative.adjustPlaybackSignalVolume(_apiBridge, volume);
        }

        public ERROR_CODE EnableWebSdkInteroperability(bool enabled)
        {
            return AgorartcNative.enableWebSdkInteroperability(_apiBridge, enabled ? 1 : 0);
        }

        public ERROR_CODE SetVideoQualityParameters(bool preferFrameRateOverImageQuality)
        {
            return AgorartcNative.setVideoQualityParameters(_apiBridge, preferFrameRateOverImageQuality ? 1 : 0);
        }

        public ERROR_CODE SetLocalPublishFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            return AgorartcNative.setLocalPublishFallbackOption(_apiBridge, option);
        }

        public ERROR_CODE SetRemoteSubscribeFallbackOption(STREAM_FALLBACK_OPTIONS option)
        {
            return AgorartcNative.setRemoteSubscribeFallbackOption(_apiBridge, option);
        }

        public ERROR_CODE EnableLoopbackRecording(bool enabled, string deviceName)
        {
            return AgorartcNative.enableLoopbackRecording(_apiBridge, enabled ? 1 : 0, deviceName);
        }

        public ERROR_CODE StartScreenCaptureByScreenRect(ref Rectangle screenRect, ref Rectangle regionRect,
            ref ScreenCaptureParameters captureParams)
        {
            return AgorartcNative.startScreenCaptureByScreenRect(_apiBridge, ref screenRect, ref regionRect,
                ref captureParams);
        }

        public ERROR_CODE StartScreenCaptureByWindowId(view_t windowId, ref Rectangle regionRect,
            ref ScreenCaptureParameters captureParams)
        {
            return AgorartcNative.startScreenCaptureByWindowId(_apiBridge, windowId, ref regionRect, ref captureParams);
        }

        public ERROR_CODE SetScreenCaptureContentHint(VideoContentHint contentHint)
        {
            return AgorartcNative.setScreenCaptureContentHint(_apiBridge, contentHint);
        }

        public ERROR_CODE UpdateScreenCaptureParameters(ref ScreenCaptureParameters captureParams)
        {
            return AgorartcNative.updateScreenCaptureParameters(_apiBridge, ref captureParams);
        }

        public ERROR_CODE UpdateScreenCaptureRegion(ref Rectangle regionRect)
        {
            return AgorartcNative.updateScreenCaptureRegion(_apiBridge, ref regionRect);
        }

        public ERROR_CODE StopScreenCapture()
        {
            return AgorartcNative.stopScreenCapture(_apiBridge);
        }

        public string GetCallId()
        {
            return AgorartcNative.getCallId(_apiBridge);
        }

        public ERROR_CODE Rate(string callId, int rating, string description)
        {
            return AgorartcNative.rate(_apiBridge, callId, rating, description);
        }

        public ERROR_CODE Complain(string callId, string description)
        {
            return AgorartcNative.complain(_apiBridge, callId, description);
        }

        public string GetVersion()
        {
            return AgorartcNative.getVersion(_apiBridge);
        }

        public ERROR_CODE EnableLastmileTest()
        {
            return AgorartcNative.enableLastmileTest(_apiBridge);
        }

        public ERROR_CODE DisableLastmileTest()
        {
            return AgorartcNative.disableLastmileTest(_apiBridge);
        }

        public ERROR_CODE StartLastmileProbeTest(LastmileProbeConfig config)
        {
            return AgorartcNative.startLastmileProbeTest(_apiBridge, config);
        }

        public ERROR_CODE StopLastmileProbeTest()
        {
            return AgorartcNative.stopLastmileProbeTest(_apiBridge);
        }

        public string GetErrorDescription(int code)
        {
            return AgorartcNative.getErrorDescription(_apiBridge, code);
        }

        public ERROR_CODE SetEncryptionSecret(string secret)
        {
            return AgorartcNative.setEncryptionSecret(_apiBridge, secret);
        }

        public ERROR_CODE SetEncryptionMode(string encryptionMode)
        {
            return AgorartcNative.setEncryptionMode(_apiBridge, encryptionMode);
        }

        public ERROR_CODE CreateDataStream(IntPtr streamId, bool reliable, bool ordered)
        {
            return AgorartcNative.createDataStream(_apiBridge, streamId, reliable ? 1 : 0, ordered ? 1 : 0);
        }

        public ERROR_CODE SendStreamMessage(int streamId, string data, long length)
        {
            return AgorartcNative.sendStreamMessage(_apiBridge, streamId, data, length);
        }

        public ERROR_CODE AddPublishStreamUrl(string url, bool transcodingEnabled)
        {
            return AgorartcNative.addPublishStreamUrl(_apiBridge, url, transcodingEnabled ? 1 : 0);
        }

        public ERROR_CODE RemovePublishStreamUrl(string url)
        {
            return AgorartcNative.removePublishStreamUrl(_apiBridge, url);
        }

        public ERROR_CODE SetLiveTranscoding(ref LiveTranscoding transcoding)
        {
            return AgorartcNative.setLiveTranscoding(_apiBridge, ref transcoding);
        }

        public ERROR_CODE AddVideoWatermark(RtcImage watermark)
        {
            return AgorartcNative.addVideoWatermark(_apiBridge, watermark);
        }

        public ERROR_CODE AddVideoWatermark2(string watermarkUrl, WatermarkOptions options)
        {
            return AgorartcNative.addVideoWatermark2(_apiBridge, watermarkUrl, options);
        }

        public ERROR_CODE ClearVideoWatermarks()
        {
            return AgorartcNative.clearVideoWatermarks(_apiBridge);
        }

        public ERROR_CODE SetBeautyEffectOptions(bool enabled, BeautyOptions options)
        {
            return AgorartcNative.setBeautyEffectOptions(_apiBridge, enabled ? 1 : 0, options);
        }

        public ERROR_CODE AddInjectStreamUrl(string url, InjectStreamConfig config)
        {
            return AgorartcNative.addInjectStreamUrl(_apiBridge, url, config);
        }

        public ERROR_CODE StartChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            return AgorartcNative.startChannelMediaRelay(_apiBridge, configuration);
        }

        public ERROR_CODE UpdateChannelMediaRelay(ChannelMediaRelayConfiguration configuration)
        {
            return AgorartcNative.updateChannelMediaRelay(_apiBridge, configuration);
        }

        public ERROR_CODE StopChannelMediaRelay()
        {
            return AgorartcNative.stopChannelMediaRelay(_apiBridge);
        }

        public ERROR_CODE RemoveInjectStreamUrl(string url)
        {
            return AgorartcNative.removeInjectStreamUrl(_apiBridge, url);
        }

        public CONNECTION_STATE_TYPE GetConnectionState()
        {
            return AgorartcNative.getConnectionState(_apiBridge);
        }

        public ERROR_CODE SetParameters(string parameters)
        {
            return AgorartcNative.setParameters(_apiBridge, parameters);
        }

        public ERROR_CODE SetPlaybackDeviceVolume(int volume)
        {
            return AgorartcNative.setPlaybackDeviceVolume(_apiBridge, volume);
        }

        // API_TYPE_AUDIO_EFFECT

        public ERROR_CODE StartAudioMixing(string filePath, bool loopback, bool replace, int cycle)
        {
            return AgorartcNative.startAudioMixing(_apiBridge, filePath, loopback ? 1 : 0, replace ? 1 : 0, cycle);
        }

        public ERROR_CODE StopAudioMixing()
        {
            return AgorartcNative.stopAudioMixing(_apiBridge);
        }

        public ERROR_CODE PauseAudioMixing()
        {
            return AgorartcNative.pauseAudioMixing(_apiBridge);
        }

        public ERROR_CODE ResumeAudioMixing()
        {
            return AgorartcNative.resumeAudioMixing(_apiBridge);
        }

        public ERROR_CODE SetHighQualityAudioParameters(bool fullband, bool stereo, bool fullBitrate)
        {
            return AgorartcNative.setHighQualityAudioParameters(_apiBridge, fullband ? 1 : 0, stereo ? 1 : 0,
                fullBitrate ? 1 : 0);
        }

        public ERROR_CODE AdjustAudioMixingVolume(int volume)
        {
            return AgorartcNative.adjustAudioMixingVolume(_apiBridge, volume);
        }

        public ERROR_CODE AdjustAudioMixingPlayoutVolume(int volume)
        {
            return AgorartcNative.adjustAudioMixingPlayoutVolume(_apiBridge, volume);
        }

        public ERROR_CODE GetAudioMixingPlayoutVolume()
        {
            return AgorartcNative.getAudioMixingPlayoutVolume(_apiBridge);
        }

        public ERROR_CODE AdjustAudioMixingPublishVolume(int volume)
        {
            return AgorartcNative.adjustAudioMixingPublishVolume(_apiBridge, volume);
        }

        public ERROR_CODE GetAudioMixingPublishVolume()
        {
            return AgorartcNative.getAudioMixingPublishVolume(_apiBridge);
        }

        public ERROR_CODE GetAudioMixingDuration()
        {
            return AgorartcNative.getAudioMixingDuration(_apiBridge);
        }

        public ERROR_CODE GetAudioMixingCurrentPosition()
        {
            return AgorartcNative.getAudioMixingCurrentPosition(_apiBridge);
        }

        public ERROR_CODE SetAudioMixingPosition(int pos /*in ms*/)
        {
            return AgorartcNative.setAudioMixingPosition(_apiBridge, pos);
        }

        public ERROR_CODE SetAudioMixingPitch(int pitch)
        {
            return AgorartcNative.setAudioMixingPitch(_apiBridge, pitch);
        }

        public ERROR_CODE GetEffectsVolume()
        {
            return AgorartcNative.getEffectsVolume(_apiBridge);
        }

        public ERROR_CODE SetEffectsVolume(int volume)
        {
            return AgorartcNative.setEffectsVolume(_apiBridge, volume);
        }

        public ERROR_CODE SetVolumeOfEffect(int soundId, int volume)
        {
            return AgorartcNative.setVolumeOfEffect(_apiBridge, soundId, volume);
        }

        public ERROR_CODE PlayEffect(int soundId, string filePath, int loopCount, double pitch, double pan, int gain,
            bool publish)
        {
            return AgorartcNative.playEffect(_apiBridge, soundId, filePath, loopCount, pitch, pan, gain,
                publish ? 1 : 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="soundId"></param>
        /// <returns></returns>
        public ERROR_CODE StopEffect(int soundId)
        {
            return AgorartcNative.stopEffect(_apiBridge, soundId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ERROR_CODE StopAllEffects()
        {
            return AgorartcNative.stopAllEffects(_apiBridge);
        }

        public ERROR_CODE PreloadEffect(int soundId, string filePath)
        {
            return AgorartcNative.preloadEffect(_apiBridge, soundId, filePath);
        }

        public ERROR_CODE UnloadEffect(int soundId)
        {
            return AgorartcNative.unloadEffect(_apiBridge, soundId);
        }

        public ERROR_CODE PauseEffect(int soundId)
        {
            return AgorartcNative.pauseEffect(_apiBridge, soundId);
        }

        public ERROR_CODE PauseAllEffects()
        {
            return AgorartcNative.pauseAllEffects(_apiBridge);
        }

        public ERROR_CODE ResumeEffect(int soundId)
        {
            return AgorartcNative.resumeEffect(_apiBridge, soundId);
        }

        public ERROR_CODE ResumeAllEffects()
        {
            return AgorartcNative.resumeAllEffects(_apiBridge);
        }

        public ERROR_CODE EnableSoundPositionIndication(bool enabled)
        {
            return AgorartcNative.enableSoundPositionIndication(_apiBridge, enabled ? 1 : 0);
        }

        public ERROR_CODE SetLocalVoicePitch(double pitch)
        {
            return AgorartcNative.setLocalVoicePitch(_apiBridge, pitch);
        }

        public ERROR_CODE SetLocalVoiceEqualization(AUDIO_EQUALIZATION_BAND_FREQUENCY bandFrequency, int bandGain)
        {
            return AgorartcNative.setLocalVoiceEqualization(_apiBridge, bandFrequency, bandGain);
        }

        public ERROR_CODE SetLocalVoiceReverb(AUDIO_REVERB_TYPE reverbKey, int value)
        {
            return AgorartcNative.setLocalVoiceReverb(_apiBridge, reverbKey, value);
        }

        public ERROR_CODE SetLocalVoiceChanger(VOICE_CHANGER_PRESET voiceChanger)
        {
            return AgorartcNative.setLocalVoiceChanger(_apiBridge, voiceChanger);
        }

        public ERROR_CODE SetLocalVoiceReverbPreset(AUDIO_REVERB_PRESET reverbPreset)
        {
            return AgorartcNative.setLocalVoiceReverbPreset(_apiBridge, reverbPreset);
        }

        public ERROR_CODE SetExternalAudioSource(bool enabled, int sampleRate, int channels)
        {
            return AgorartcNative.setExternalAudioSource(_apiBridge, enabled ? 1 : 0, sampleRate, channels);
        }

        public ERROR_CODE SetExternalAudioSink(bool enabled, int sampleRate, int channels)
        {
            return AgorartcNative.setExternalAudioSink(_apiBridge, enabled ? 1 : 0, sampleRate, channels);
        }

        public ERROR_CODE SetRecordingAudioFrameParameters(int sampleRate, int channel,
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            return AgorartcNative.setRecordingAudioFrameParameters(_apiBridge, sampleRate, channel, mode,
                samplesPerCall);
        }

        public ERROR_CODE SetPlaybackAudioFrameParameters(int sampleRate, int channel,
            RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
        {
            return AgorartcNative.setPlaybackAudioFrameParameters(_apiBridge, sampleRate, channel, mode,
                samplesPerCall);
        }

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