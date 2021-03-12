using System;
using System.Text;
using agorartc;

namespace RtcChannelApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var channelApiTest = new AgoraRtcChannelApiTest(
                "C:\\Users\\hyq\\Documents\\cross_platform\\Agora-C_Sharp-SDK\\test\\test_result\\channel_api_test_result.json",
                new MyEventHandler(), AgoraRtcEngine.CreateRtcEngine());
            channelApiTest.BeginApiTestByFile(
                "C:\\Users\\hyq\\Documents\\cross_platform\\Agora-C_Sharp-SDK\\iris\\case\\ChannelApiTest.json");
        }
    }

    internal class MyEventHandler : IRtcChannelEventHandlerBase
    {
        public override void OnChannelApiTest(int apiType, string @params)
        {
            var apiTypeEnum = (CApiTypeChannel) apiType;
            var channel = AgoraRtcEngine.CreateRtcEngine()
                .CreateChannel((string) AgoraUtil.GetData<string>(@params, "channelId"));
            switch (apiTypeEnum)
            {
                case CApiTypeChannel.kChannelCreateChannel:
                    break;
                case CApiTypeChannel.kChannelRelease:
                    break;
                case CApiTypeChannel.kChannelJoinChannel:
                    channel.JoinChannel(
                        (string) AgoraUtil.GetData<string>(@params, "token"),
                        (string) AgoraUtil.GetData<string>(@params, "info"),
                        (uint) AgoraUtil.GetData<uint>(@params, "uid"),
                        AgoraUtil.JsonToStruct<ChannelMediaOptions>(@params, "options"));
                    break;
                case CApiTypeChannel.kChannelJoinChannelWithUserAccount:
                    channel.JoinChannelWithUserAccount(
                        (string) AgoraUtil.GetData<string>(@params, "token"),
                        (string) AgoraUtil.GetData<string>(@params, "userAccount"),
                        AgoraUtil.JsonToStruct<ChannelMediaOptions>(@params, "options"));
                    break;
                case CApiTypeChannel.kChannelLeaveChannel:
                    channel.LeaveChannel();
                    break;
                case CApiTypeChannel.kChannelPublish:
                    channel.Publish();
                    break;
                case CApiTypeChannel.kChannelUnPublish:
                    channel.Unpublish();
                    break;
                case CApiTypeChannel.kChannelChannelId:
                    channel.ChannelId();
                    break;
                case CApiTypeChannel.kChannelGetCallId:
                    channel.GetCallId();
                    break;
                case CApiTypeChannel.kChannelRenewToken:
                    channel.RenewToken(
                        (string) AgoraUtil.GetData<string>(@params, "token"));
                    break;
                case CApiTypeChannel.kChannelSetEncryptionSecret:
                    channel.SetEncryptionSecret(
                        (string) AgoraUtil.GetData<string>(@params, "secret"));
                    break;
                case CApiTypeChannel.kChannelSetEncryptionMode:
                    channel.SetEncryptionMode(
                        (string) AgoraUtil.GetData<string>(@params, "encryptionMode"));
                    break;
                case CApiTypeChannel.kChannelEnableEncryption:
                    channel.EnableEncryption(
                        (bool) AgoraUtil.GetData<bool>(@params, "enabled"),
                        AgoraUtil.JsonToStruct<EncryptionConfig>(@params, "config"));
                    break;
                case CApiTypeChannel.kChannelRegisterPacketObserver:
                    break;
                case CApiTypeChannel.kChannelRegisterMediaMetadataObserver:
                    channel.RegisterMediaMetadataObserver(
                        (METADATA_TYPE) AgoraUtil.GetData<int>(@params, "type"));
                    break;
                case CApiTypeChannel.kChannelUnRegisterMediaMetadataObserver:
                    channel.UnRegisterMediaMetadataObserver(
                        (METADATA_TYPE) AgoraUtil.GetData<int>(@params, "type"));
                    break;
                case CApiTypeChannel.kChannelSetMaxMetadataSize:
                    channel.SetMaxMetadataSize(
                        (int) AgoraUtil.GetData<int>(@params, "size"));
                    break;
                case CApiTypeChannel.kChannelSendMetadata:
                    var metadataJson = (string) AgoraUtil.GetData<object>(@params, "metadata");
                    var metadata = new Metadata();
                    metadata.uid = (uint) AgoraUtil.GetData<uint>(metadataJson, "uid");
                    metadata.size = (uint) AgoraUtil.GetData<uint>(metadataJson, "size");
                    metadata.timeStampMs = (long) AgoraUtil.GetData<long>(metadataJson, "timeStampMs");
                    metadata.buffer = Encoding.ASCII.GetBytes("abc");
                    channel.SendMetadata(metadata);
                    break;
                case CApiTypeChannel.kChannelSetClientRole:
                    channel.SetClientRole(
                        (CLIENT_ROLE_TYPE) AgoraUtil.GetData<int>(@params, "role"));
                    break;
                case CApiTypeChannel.kChannelSetRemoteUserPriority:
                    channel.SetRemoteUserPriority(
                        (uint) AgoraUtil.GetData<uint>(@params, "uid"),
                        (PRIORITY_TYPE) AgoraUtil.GetData<int>(@params, "userPriority"));
                    break;
                case CApiTypeChannel.kChannelSetRemoteVoicePosition:
                    channel.SetRemoteVoicePosition(
                        (uint) AgoraUtil.GetData<uint>(@params, "uid"),
                        (double) AgoraUtil.GetData<double>(@params, "pan"),
                        (double) AgoraUtil.GetData<double>(@params, "gain"));
                    break;
                case CApiTypeChannel.kChannelSetRemoteRenderMode:
                    channel.SetRemoteRenderMode(
                        (uint) AgoraUtil.GetData<uint>(@params, "userId"),
                        (RENDER_MODE_TYPE) AgoraUtil.GetData<int>(@params, "renderMode"),
                        (VIDEO_MIRROR_MODE_TYPE) AgoraUtil.GetData<int>(@params, "mirrorMode"));
                    break;
                case CApiTypeChannel.kChannelSetDefaultMuteAllRemoteAudioStreams:
                    channel.SetDefaultMuteAllRemoteAudioStreams(
                        (bool) AgoraUtil.GetData<bool>(@params, "mute"));
                    break;
                case CApiTypeChannel.kChannelSetDefaultMuteAllRemoteVideoStreams:
                    channel.SetDefaultMuteAllRemoteVideoStreams(
                        (bool) AgoraUtil.GetData<bool>(@params, "mute"));
                    break;
                case CApiTypeChannel.kChannelMuteAllRemoteAudioStreams:
                    channel.MuteAllRemoteAudioStreams(
                        (bool) AgoraUtil.GetData<bool>(@params, "mute"));
                    break;
                case CApiTypeChannel.kChannelAdjustUserPlaybackSignalVolume:
                    channel.AdjustUserPlaybackSignalVolume(
                        (uint) AgoraUtil.GetData<uint>(@params, "userId"),
                        (int) AgoraUtil.GetData<int>(@params, "volume"));
                    break;
                case CApiTypeChannel.kChannelMuteRemoteAudioStream:
                    channel.MuteRemoteAudioStream(
                        (uint) AgoraUtil.GetData<uint>(@params, "userId"),
                        (bool) AgoraUtil.GetData<bool>(@params, "mute"));
                    break;
                case CApiTypeChannel.kChannelMuteAllRemoteVideoStreams:
                    channel.MuteAllRemoteVideoStreams(
                        (bool) AgoraUtil.GetData<bool>(@params, "mute"));
                    break;
                case CApiTypeChannel.kChannelMuteRemoteVideoStream:
                    channel.MuteRemoteVideoStream(
                        (uint) AgoraUtil.GetData<uint>(@params, "userId"),
                        (bool) AgoraUtil.GetData<bool>(@params, "mute"));
                    break;
                case CApiTypeChannel.kChannelSetRemoteVideoStreamType:
                    channel.SetRemoteVideoStreamType(
                        (uint) AgoraUtil.GetData<uint>(@params, "userId"),
                        (REMOTE_VIDEO_STREAM_TYPE) AgoraUtil.GetData<int>(@params, "streamType"));
                    break;
                case CApiTypeChannel.kChannelSetRemoteDefaultVideoStreamType:
                    channel.SetRemoteDefaultVideoStreamType(
                        (REMOTE_VIDEO_STREAM_TYPE) AgoraUtil.GetData<int>(@params, "streamType"));
                    break;
                case CApiTypeChannel.kChannelCreateDataStream:
                    channel.CreateDataStream(
                        out var streamId,
                        (bool) AgoraUtil.GetData<bool>(@params, "reliable"),
                        (bool) AgoraUtil.GetData<bool>(@params, "ordered"));
                    Console.WriteLine(">>> \"CreateDataStream\" streamId: {0}", streamId);
                    break;
                case CApiTypeChannel.kChannelSendStreamMessage:
                    channel.SendStreamMessage(
                        (int) AgoraUtil.GetData<int>(@params, "streamId"),
                        Encoding.ASCII.GetBytes("abc"));
                    break;
                case CApiTypeChannel.kChannelAddPublishStreamUrl:
                    channel.AddPublishStreamUrl(
                        (string) AgoraUtil.GetData<string>(@params, "url"),
                        (bool) AgoraUtil.GetData<bool>(@params, "transcodingEnabled"));
                    break;
                case CApiTypeChannel.kChannelRemovePublishStreamUrl:
                    channel.RemovePublishStreamUrl(
                        (string) AgoraUtil.GetData<string>(@params, "url"));
                    break;
                case CApiTypeChannel.kChannelSetLiveTranscoding:
                    channel.SetLiveTranscoding(
                        AgoraUtil.JsonToStruct<LiveTranscoding>(@params, "transcoding"));
                    break;
                case CApiTypeChannel.kChannelAddInjectStreamUrl:
                    channel.AddInjectStreamUrl(
                        (string) AgoraUtil.GetData<string>(@params, "url"),
                        AgoraUtil.JsonToStruct<InjectStreamConfig>(@params, "config"));
                    break;
                case CApiTypeChannel.kChannelRemoveInjectStreamUrl:
                    channel.RemoveInjectStreamUrl(
                        (string) AgoraUtil.GetData<string>(@params, "url"));
                    break;
                case CApiTypeChannel.kChannelStartChannelMediaRelay:
                    channel.StartChannelMediaRelay(
                        AgoraUtil.JsonToStruct<ChannelMediaRelayConfiguration>(@params, "configuration"));
                    break;
                case CApiTypeChannel.kChannelUpdateChannelMediaRelay:
                    channel.UpdateChannelMediaRelay(
                        AgoraUtil.JsonToStruct<ChannelMediaRelayConfiguration>(@params, "configuration"));
                    break;
                case CApiTypeChannel.kChannelStopChannelMediaRelay:
                    channel.StopChannelMediaRelay();
                    break;
                case CApiTypeChannel.kChannelGetConnectionState:
                    channel.GetConnectionState();
                    break;
                case CApiTypeChannel.kChannelEnableRemoteSuperResolution:
                    channel.EnableRemoteSuperResolution(
                        (uint) AgoraUtil.GetData<uint>(@params, "userId"),
                        (bool) AgoraUtil.GetData<bool>(@params, "enable"));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}