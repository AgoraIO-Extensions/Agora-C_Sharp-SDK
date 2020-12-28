using System;
using System.Linq;
using System.Windows.Forms;
using agorartc;

namespace OneToOneVideo
{
    public partial class OneToOneVideoDemo : Form
    {
        internal static AgoraRtcEngine Rtc;
        internal static IntPtr LocalWinId;
        internal static IntPtr RemoteWinId;

        public OneToOneVideoDemo()
        {
            InitializeComponent();
            Rtc = AgoraRtcEngine.CreateRtcEngine();
            Rtc.InitEventHandler(new MyEventHandler());
            
            LocalWinId = localVideo.Handle;
            RemoteWinId = remoteVideo.Handle;
        }

        private void JoinChannel_Click(object sender, EventArgs e)
        {
            if (appIdBox.TextLength == 0)
            {
                MessageBox.Show(@"Please input your App ID.", @"Message", MessageBoxButtons.OK);
                return;
            }

            if (channelNameBox.TextLength == 0)
            {
                MessageBox.Show(@"Please input your Channel Name.", @"Message", MessageBoxButtons.OK);
                return;
            }

            if (channelNameBox.TextLength > 64)
            {
                MessageBox.Show(@"The length of the channel name must be less than 64.", @"Message",
                    MessageBoxButtons.OK);
                return;
            }

            if (!CheckChannelName())
            {
                MessageBox.Show(@"The channel name contains illegal character.", @"Message", MessageBoxButtons.OK);
                return;
            }

            Rtc.Initialize(appIdBox.Text, AREA_CODE.AREA_CODE_GLOBAL);
            Rtc.EnableVideo();
            Rtc.JoinChannel("", channelNameBox.Text, "", 0);
            var ret = new VideoCanvas(LocalWinId);
            Rtc.SetupLocalVideo(ret);
            Rtc.StartPreview();
        }

        private void LeaveChannel_Click(object sender, EventArgs e)
        {
            Rtc.LeaveChannel();
        }

        private bool CheckChannelName()
        {
            var channelNameChar = channelNameBox.Text.ToCharArray();
            return !(from nameChar in channelNameChar
                where nameChar < 'a' || nameChar > 'z'
                where nameChar < 'A' || nameChar > 'Z'
                where nameChar < '0' || nameChar > '9'
                let temp = new[]
                {
                    '!', '#', '$', '%', '&', '(', ')', '+', '-', ':', ';', '<', '=', '.', '>', '?', '@', '[', ']', '^',
                    '_', '{', '}', '|', '~', ',', (char) 32
                }
                where Array.IndexOf(temp, nameChar) < 0
                select nameChar).Any();
        }
    }

    internal class MyEventHandler : IRtcEngineEventHandlerBase
    {
        public override void OnJoinChannelSuccess(string namelessParameter1, uint uid, int elapsed)
        {
            Console.WriteLine("OnJoinChannelSuccess");
        }

        public override void OnReJoinChannelSuccess(string namelessParameter1, uint uid, int elapsed)
        {
            Console.WriteLine("OnReJoinChannelSuccess");
        }

        public override void OnConnectionLost()
        {
            Console.WriteLine("OnConnectionLost");
        }

        public override void OnConnectionInterrupted()
        {
            Console.WriteLine("OnConnectionInterrupted");
        }

        public override void OnLeaveChannel(uint duration, uint txBytes, uint rxBytes, uint txAudioBytes,
            uint txVideoBytes, uint rxAudioBytes, uint rxVideoBytes, ushort txKBitRate, ushort rxKBitRate,
            ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate, ushort txVideoKBitRate,
            ushort lastmileDelay, ushort txPacketLossRate, ushort rxPacketLossRate, uint userCount,
            double cpuAppUsage,
            double cpuTotalUsage, int gatewayRtt, double memoryAppUsageRatio, double memoryTotalUsageRatio,
            int memoryAppUsageInKbytes)
        {
            Console.WriteLine("OnLeaveChannel");
        }

        public override void OnRequestToken()
        {
            Console.WriteLine("OnRequestToken");
        }

        public override void OnUserJoined(uint uid, int elapsed)
        {
            Console.WriteLine("OnUserJoined");
            if (OneToOneVideoDemo.RemoteWinId == IntPtr.Zero) return;
            var ret = new VideoCanvas(OneToOneVideoDemo.RemoteWinId, uid);
            OneToOneVideoDemo.Rtc.SetupRemoteVideo(ret);
        }

        public override void OnUserOffline(uint uid, int offLineReason)
        {
            Console.WriteLine("OnUserOffline");
        }

        public override void OnAudioVolumeIndication(int[] uid, int[] volume, int[] vad, int speakerNumber,
            int totalVolume)
        {
            Console.WriteLine("OnAudioVolumeIndication");
        }

        public override void OnUserMuteAudio(uint uid, int muted)
        {
            Console.WriteLine("OnUserMuteAudio");
        }

        public override void OnWarning(int warn, string msg)
        {
            Console.WriteLine("OnWarning");
        }

        public override void OnError(int error, string msg)
        {
            Console.WriteLine("OnError");
        }

        public override void OnRtcStats(uint duration, uint txBytes, uint rxBytes, uint txAudioBytes, uint txVideoBytes, uint rxAudioBytes,
            uint rxVideoBytes, ushort txKBitRate, ushort rxKBitRate, ushort rxAudioKBitRate, ushort txAudioKBitRate,
            ushort rxVideoKBitRate, ushort txVideoKBitRate, ushort lastmileDelay, ushort txPacketLossRate,
            ushort rxPacketLossRate, uint userCount, double cpuAppUsage, double cpuTotalUsage, int gatewayRtt,
            double memoryAppUsageRatio, double memoryTotalUsageRatio, int memoryAppUsageInKbytes)
        {
            Console.WriteLine("OnRtcStats");
        }

        public override void OnAudioMixingFinished()
        {
            Console.WriteLine("OnAudioMixingFinished");
        }

        public override void OnAudioRouteChanged(int route)
        {
            Console.WriteLine("OnAudioRouteChanged");
        }

        public override void OnFirstRemoteVideoDecoded(uint uid, int width, int height, int elapsed)
        {
            Console.WriteLine("OnFirstRemoteVideoDecoded");
        }

        public override void OnVideoSizeChanged(uint uid, int width, int height, int elapsed)
        {
            Console.WriteLine("OnVideoSizeChanged");
        }

        public override void OnClientRoleChanged(int oldRole, int newRole)
        {
            Console.WriteLine("OnClientRoleChanged");
        }

        public override void OnUserMuteVideo(uint uid, int muted)
        {
            Console.WriteLine("OnUserMuteVideo");
        }

        public override void OnMicrophoneEnabled(int isEnabled)
        {
            Console.WriteLine("OnMicrophoneEnabled");
        }

        public override void OnApiExecuted(int err, string api, string result)
        {
            Console.WriteLine("OnApiExecuted");
        }

        public override void OnFirstLocalAudioFrame(int elapsed)
        {
            Console.WriteLine("OnFirstLocalAudioFrame");
        }

        public override void OnFirstRemoteAudioFrame(uint userId, int elapsed)
        {
            Console.WriteLine("OnFirstRemoteAudioFrame");
        }

        public override void OnLastmileQuality(int quality)
        {
            Console.WriteLine("OnLastmileQuality");
        }

        public override void OnAudioQuality(uint userId, int quality, ushort delay, ushort lost)
        {
            Console.WriteLine("OnAudioQuality");
        }

        public override void OnStreamInjectedStatus(string url, uint userId, int status)
        {
            Console.WriteLine("OnStreamInjectedStatus");
        }

        public override void OnStreamUnpublished(string url)
        {
            Console.WriteLine("OnStreamUnpublished");
        }

        public override void OnStreamPublished(string url, int error)
        {
            Console.WriteLine("OnStreamPublished");
        }

        public override void OnStreamMessageError(uint userId, int streamId, int code, int missed, int cached)
        {
            Console.WriteLine("OnStreamMessageError");
        }

        public override void OnStreamMessage(uint userId, int streamId, string data, uint length)
        {
            Console.WriteLine("OnStreamMessage");
        }

        public override void OnConnectionBanned()
        {
            Console.WriteLine("OnConnectionBanned");
        }

        public override void OnRemoteVideoTransportStats(uint uid, ushort delay, ushort lost, ushort rxKBitRate)
        {
            Console.WriteLine("OnRemoteVideoTransportStats");
        }

        public override void OnRemoteAudioTransportStats(uint uid, ushort delay, ushort lost, ushort rxKBitRate)
        {
            Console.WriteLine("OnRemoteAudioTransportStats");
        }

        public override void OnTranscodingUpdated()
        {
            Console.WriteLine("OnTranscodingUpdated");
        }

        public override void OnAudioDeviceVolumeChanged(int deviceType, int volume, int muted)
        {
            Console.WriteLine("OnAudioDeviceVolumeChanged");
        }

        public override void OnActiveSpeaker(uint userId)
        {
            Console.WriteLine("OnActiveSpeaker");
        }

        public override void OnMediaEngineStartCallSuccess()
        {
            Console.WriteLine("OnMediaEngineStartCallSuccess");
        }

        public override void OnMediaEngineLoadSuccess()
        {
            Console.WriteLine("OnMediaEngineLoadSuccess");
        }

        public override void OnVideoStopped()
        {
            Console.WriteLine("OnVideoStopped");
        }

        public override void OnTokenPrivilegeWillExpire(string token)
        {
            Console.WriteLine("OnTokenPrivilegeWillExpire");
        }

        public override void OnNetworkQuality(uint uid, int txQuality, int rxQuality)
        {
            Console.WriteLine("OnNetworkQuality");
        }

        public override void OnLocalVideoStats(int sentBitrate, int sentFrameRate, int encoderOutputFrameRate, int rendererOutputFrameRate,
            int targetBitrate, int targetFrameRate, int qualityAdaptIndication, int encodedBitrate, int encodedFrameWidth,
            int encodedFrameHeight, int encodedFrameCount, int codecType)
        {
            Console.WriteLine("OnLocalVideoStats");
        }

        public override void OnRemoteVideoStats(uint uid, int delay, int width, int height, int receivedBitrate, int decoderOutputFrameRate,
            int rendererOutputFrameRate, int packetLossRate, int rxStreamType, int totalFrozenTime, int frozenRate,
            int totalActiveTime)
        {
            Console.WriteLine("OnRemoteVideoStats");
        }

        public override void OnRemoteAudioStats(uint uid, int quality, int networkTransportDelay, int jitterBufferDelay, int audioLossRate,
            int numChannels, int receivedSampleRate, int receivedBitrate, int totalFrozenTime, int frozenRate,
            int totalActiveTime)
        {
            Console.WriteLine("OnRemoteAudioStats");
        }

        public override void OnLocalAudioStats(int numChannels, int sentSampleRate, int sentBitrate)
        {
            Console.WriteLine("OnLocalAudioStats");
        }

        public override void OnFirstLocalVideoFrame(int width, int height, int elapsed)
        {
            Console.WriteLine("OnFirstLocalVideoFrame");
        }

        public override void OnFirstRemoteVideoFrame(uint uid, int width, int height, int elapsed)
        {
            Console.WriteLine("OnFirstRemoteVideoFrame");
        }

        public override void OnUserEnableVideo(uint uid, int enabled)
        {
            Console.WriteLine("OnUserEnableVideo");
        }

        public override void OnAudioDeviceStateChanged(string deviceId, int deviceType, int deviceState)
        {
            Console.WriteLine("OnAudioDeviceStateChanged");
        }

        public override void OnCameraReady()
        {
            Console.WriteLine("OnCameraReady");
        }

        public override void OnCameraFocusAreaChanged(int x, int y, int width, int height)
        {
            Console.WriteLine("OnCameraFocusAreaChanged");
        }

        public override void OnCameraExposureAreaChanged(int x, int y, int width, int height)
        {
            Console.WriteLine("OnCameraExposureAreaChanged");
        }

        public override void OnRemoteAudioMixingBegin()
        {
            Console.WriteLine("OnRemoteAudioMixingBegin");
        }

        public override void OnRemoteAudioMixingEnd()
        {
            Console.WriteLine("OnRemoteAudioMixingEnd");
        }

        public override void OnAudioEffectFinished(int soundId)
        {
            Console.WriteLine("OnAudioEffectFinished");
        }

        public override void OnVideoDeviceStateChanged(string deviceId, int deviceType, int deviceState)
        {
            Console.WriteLine("OnVideoDeviceStateChanged");
        }

        public override void OnRemoteVideoStateChanged(uint uid, int state, int reason, int elapsed)
        {
            Console.WriteLine("OnRemoteVideoStateChanged");
        }

        public override void OnUserEnableLocalVideo(uint uid, int enabled)
        {
            Console.WriteLine("OnUserEnableLocalVideo");
        }

        public override void OnLocalPublishFallbackToAudioOnly(int isFallbackOrRecover)
        {
            Console.WriteLine("OnLocalPublishFallbackToAudioOnly");
        }

        public override void OnRemoteSubscribeFallbackToAudioOnly(uint uid, int isFallbackOrRecover)
        {
            Console.WriteLine("OnRemoteSubscribeFallbackToAudioOnly");
        }

        public override void OnConnectionStateChanged(int state, int reason)
        {
            Console.WriteLine("OnConnectionStateChanged");
        }

        public override void OnRtmpStreamingStateChanged(string url, int state, int errCode)
        {
            Console.WriteLine("OnRtmpStreamingStateChanged");
        }

        public override void OnLocalUserRegistered(uint uid, string userAccount)
        {
            Console.WriteLine("OnLocalUserRegistered");
        }

        public override void OnUserInfoUpdated(uint uid, uint userUid, string userAccount)
        {
            Console.WriteLine("OnUserInfoUpdated");
        }

        public override void OnLocalAudioStateChanged(int state, int error)
        {
            Console.WriteLine("OnLocalAudioStateChanged");
        }

        public override void OnRemoteAudioStateChanged(uint uid, int state, int reason, int elapsed)
        {
            Console.WriteLine("OnRemoteAudioStateChanged");
        }

        public override void OnAudioMixingStateChanged(int audioMixingStateType, int audioMixingErrorType)
        {
            Console.WriteLine("OnAudioMixingStateChanged");
        }

        public override void OnFirstRemoteAudioDecoded(uint uid, int elapsed)
        {
            Console.WriteLine("OnFirstRemoteAudioDecoded");
        }

        public override void OnLocalVideoStateChanged(int localVideoState, int error)
        {
            Console.WriteLine("OnLocalVideoStateChanged");
        }

        public override void OnNetworkTypeChanged(int networkType)
        {
            Console.WriteLine("OnNetworkTypeChanged");
        }

        public override void OnLastmileProbeResult(int state, uint upLinkPacketLossRate, uint upLinkjitter, uint upLinkAvailableBandwidth,
            uint downLinkPacketLossRate, uint downLinkJitter, uint downLinkAvailableBandwidth, uint rtt)
        {
            Console.WriteLine("OnLastmileProbeResult");
        }

        public override void OnChannelMediaRelayStateChanged(int state, int code)
        {
            Console.WriteLine("OnChannelMediaRelayStateChanged");
        }

        public override void OnChannelMediaRelayEvent(int code)
        {
            Console.WriteLine("OnChannelMediaRelayEvent");
        }

        public override void OnFacePositionChanged(int imageWidth, int imageHeight, int x, int y, int width, int height, int vecDistance,
            int numFaces)
        {
            Console.WriteLine("OnFacePositionChanged");
        }

        public override void OnTestEnd()
        {
            Console.WriteLine("OnTestEnd");
        }
    }
}