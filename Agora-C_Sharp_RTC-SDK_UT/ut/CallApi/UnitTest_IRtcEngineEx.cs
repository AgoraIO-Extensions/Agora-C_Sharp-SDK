using NUnit.Framework;
using Agora.Rtc;

namespace Agora.Rtc
{
    using uid_t = System.UInt32;
    [TestFixture]
    class UnitTest_IRtcEngineEx
    {

        public IRtcEngineEx EngineEx;

        [SetUp]
        public void Setup()
        {
            EngineEx = RtcEngine.CreateAgoraRtcEngineEx(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = EngineEx.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
        }

        [TearDown]
        public void TearDown() { EngineEx.Dispose(); }

        #region custom
        [Test]
        public void Test_JoinChannelEx()
        {
            string token;
            ParamsHelper.InitParam(out token);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            ChannelMediaOptions options;
            ParamsHelper.InitParam(out options);

            var nRet = EngineEx.JoinChannelEx(token, connection, options);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_CreateDataStreamEx()
        {
            int streamId;
            ParamsHelper.InitParam(out streamId);
            bool reliable;
            ParamsHelper.InitParam(out reliable);
            bool ordered;
            ParamsHelper.InitParam(out ordered);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.CreateDataStreamEx(ref streamId, reliable, ordered, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_CreateDataStreamEx2()
        {
            int streamId;
            ParamsHelper.InitParam(out streamId);
            DataStreamConfig config;
            ParamsHelper.InitParam(out config);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.CreateDataStreamEx(ref streamId, config, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetUserInfoByUserAccountEx()
        {
            string userAccount;
            ParamsHelper.InitParam(out userAccount);
            UserInfo userInfo;
            ParamsHelper.InitParam(out userInfo);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.GetUserInfoByUserAccountEx(userAccount, ref userInfo, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetUserInfoByUidEx()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            UserInfo userInfo;
            ParamsHelper.InitParam(out userInfo);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.GetUserInfoByUidEx(uid, ref userInfo, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetConnectionStateEx()
        {
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.GetConnectionStateEx(connection);

            Assert.AreEqual(CONNECTION_STATE_TYPE.CONNECTION_STATE_DISCONNECTED, nRet);
        }
        #endregion

        #region terr

        [Test]
        public void Test_LeaveChannelEx()
        {
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.LeaveChannelEx(connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_LeaveChannelEx2()
        {
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            LeaveChannelOptions options;
            ParamsHelper.InitParam(out options);
            var nRet = EngineEx.LeaveChannelEx(connection, options);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateChannelMediaOptionsEx()
        {
            ChannelMediaOptions options;
            ParamsHelper.InitParam(out options);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.UpdateChannelMediaOptionsEx(options, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetVideoEncoderConfigurationEx()
        {
            VideoEncoderConfiguration config;
            ParamsHelper.InitParam(out config);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.SetVideoEncoderConfigurationEx(config, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetupRemoteVideoEx()
        {
            VideoCanvas canvas;
            ParamsHelper.InitParam(out canvas);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.SetupRemoteVideoEx(canvas, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteRemoteAudioStreamEx()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            bool mute;
            ParamsHelper.InitParam(out mute);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.MuteRemoteAudioStreamEx(uid, mute, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteRemoteVideoStreamEx()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            bool mute;
            ParamsHelper.InitParam(out mute);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.MuteRemoteVideoStreamEx(uid, mute, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteVideoStreamTypeEx()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            VIDEO_STREAM_TYPE streamType;
            ParamsHelper.InitParam(out streamType);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.SetRemoteVideoStreamTypeEx(uid, streamType, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteLocalAudioStreamEx()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.MuteLocalAudioStreamEx(mute, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteLocalVideoStreamEx()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.MuteLocalVideoStreamEx(mute, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteAllRemoteAudioStreamsEx()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.MuteAllRemoteAudioStreamsEx(mute, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteAllRemoteVideoStreamsEx()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.MuteAllRemoteVideoStreamsEx(mute, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSubscribeAudioBlocklistEx()
        {

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            uint[] uidList;
            ParamsHelper.InitParam(out uidList);
            int uidNumber = uidList.Length;
            var nRet = EngineEx.SetSubscribeAudioBlocklistEx(uidList, uidNumber, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSubscribeAudioAllowlistEx()
        {

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            uint[] uidList;
            ParamsHelper.InitParam(out uidList);
            int uidNumber = uidList.Length;
            var nRet = EngineEx.SetSubscribeAudioAllowlistEx(uidList, uidNumber, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSubscribeVideoBlocklistEx()
        {

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            uint[] uidList;
            ParamsHelper.InitParam(out uidList);
            int uidNumber = uidList.Length;
            var nRet = EngineEx.SetSubscribeVideoBlocklistEx(uidList, uidNumber, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSubscribeVideoAllowlistEx()
        {

            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            uint[] uidList;
            ParamsHelper.InitParam(out uidList);
            int uidNumber = uidList.Length;
            var nRet = EngineEx.SetSubscribeVideoAllowlistEx(uidList, uidNumber, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteVideoSubscriptionOptionsEx()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            VideoSubscriptionOptions options;
            ParamsHelper.InitParam(out options);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.SetRemoteVideoSubscriptionOptionsEx(uid, options, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteVoicePositionEx()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            double pan;
            ParamsHelper.InitParam(out pan);
            double gain;
            ParamsHelper.InitParam(out gain);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.SetRemoteVoicePositionEx(uid, pan, gain, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteUserSpatialAudioParamsEx()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            SpatialAudioParams @params;
            ParamsHelper.InitParam(out @params);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.SetRemoteUserSpatialAudioParamsEx(uid, @params, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteRenderModeEx()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            RENDER_MODE_TYPE renderMode;
            ParamsHelper.InitParam(out renderMode);
            VIDEO_MIRROR_MODE_TYPE mirrorMode;
            ParamsHelper.InitParam(out mirrorMode);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.SetRemoteRenderModeEx(uid, renderMode, mirrorMode, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableLoopbackRecordingEx()
        {
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            string deviceName;
            ParamsHelper.InitParam(out deviceName);
            var nRet = EngineEx.EnableLoopbackRecordingEx(connection, enabled, deviceName);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustRecordingSignalVolumeEx()
        {
            int volume;
            ParamsHelper.InitParam(out volume);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.AdjustRecordingSignalVolumeEx(volume, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteRecordingSignalEx()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.MuteRecordingSignalEx(mute, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustUserPlaybackSignalVolumeEx()
        {
            uint uid;
            ParamsHelper.InitParam(out uid);
            int volume;
            ParamsHelper.InitParam(out volume);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.AdjustUserPlaybackSignalVolumeEx(uid, volume, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableEncryptionEx()
        {
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            EncryptionConfig config;
            ParamsHelper.InitParam(out config);
            var nRet = EngineEx.EnableEncryptionEx(connection, enabled, config);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SendStreamMessageEx()
        {
            int streamId;
            ParamsHelper.InitParam(out streamId);
            byte[] data;
            ParamsHelper.InitParam(out data);
            uint length;
            ParamsHelper.InitParam(out length);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.SendStreamMessageEx(streamId, data, length, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AddVideoWatermarkEx()
        {
            string watermarkUrl;
            ParamsHelper.InitParam(out watermarkUrl);
            WatermarkOptions options;
            ParamsHelper.InitParam(out options);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.AddVideoWatermarkEx(watermarkUrl, options, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ClearVideoWatermarkEx()
        {
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.ClearVideoWatermarkEx(connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SendCustomReportMessageEx()
        {
            string id;
            ParamsHelper.InitParam(out id);
            string category;
            ParamsHelper.InitParam(out category);
            string @event;
            ParamsHelper.InitParam(out @event);
            string label;
            ParamsHelper.InitParam(out label);
            int value;
            ParamsHelper.InitParam(out value);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.SendCustomReportMessageEx(id, category, @event, label, value, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableAudioVolumeIndicationEx()
        {
            int interval;
            ParamsHelper.InitParam(out interval);
            int smooth;
            ParamsHelper.InitParam(out smooth);
            bool reportVad;
            ParamsHelper.InitParam(out reportVad);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.EnableAudioVolumeIndicationEx(interval, smooth, reportVad, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartRtmpStreamWithoutTranscodingEx()
        {
            string url;
            ParamsHelper.InitParam(out url);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.StartRtmpStreamWithoutTranscodingEx(url, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartRtmpStreamWithTranscodingEx()
        {
            string url;
            ParamsHelper.InitParam(out url);
            LiveTranscoding transcoding;
            ParamsHelper.InitParam(out transcoding);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.StartRtmpStreamWithTranscodingEx(url, transcoding, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateRtmpTranscodingEx()
        {
            LiveTranscoding transcoding;
            ParamsHelper.InitParam(out transcoding);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.UpdateRtmpTranscodingEx(transcoding, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopRtmpStreamEx()
        {
            string url;
            ParamsHelper.InitParam(out url);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.StopRtmpStreamEx(url, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartChannelMediaRelayEx()
        {
            ChannelMediaRelayConfiguration configuration;
            ParamsHelper.InitParam(out configuration);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.StartChannelMediaRelayEx(configuration, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateChannelMediaRelayEx()
        {
            ChannelMediaRelayConfiguration configuration;
            ParamsHelper.InitParam(out configuration);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.UpdateChannelMediaRelayEx(configuration, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopChannelMediaRelayEx()
        {
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.StopChannelMediaRelayEx(connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PauseAllChannelMediaRelayEx()
        {
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.PauseAllChannelMediaRelayEx(connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ResumeAllChannelMediaRelayEx()
        {
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.ResumeAllChannelMediaRelayEx(connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetVideoProfileEx()
        {
            int width;
            ParamsHelper.InitParam(out width);
            int height;
            ParamsHelper.InitParam(out height);
            int frameRate;
            ParamsHelper.InitParam(out frameRate);
            int bitrate;
            ParamsHelper.InitParam(out bitrate);
            var nRet = EngineEx.SetVideoProfileEx(width, height, frameRate, bitrate);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableDualStreamModeEx()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            SimulcastStreamConfig streamConfig;
            ParamsHelper.InitParam(out streamConfig);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.EnableDualStreamModeEx(enabled, streamConfig, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetDualStreamModeEx()
        {
            SIMULCAST_STREAM_MODE mode;
            ParamsHelper.InitParam(out mode);
            SimulcastStreamConfig streamConfig;
            ParamsHelper.InitParam(out streamConfig);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.SetDualStreamModeEx(mode, streamConfig, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableWirelessAccelerate()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            var nRet = EngineEx.EnableWirelessAccelerate(enabled);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_TakeSnapshotEx()
        {
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            string filePath;
            ParamsHelper.InitParam(out filePath);
            var nRet = EngineEx.TakeSnapshotEx(connection, uid, filePath);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableContentInspectEx()
        {
            bool enabled;
            ParamsHelper.InitParam(out enabled);
            ContentInspectConfig config;
            ParamsHelper.InitParam(out config);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.EnableContentInspectEx(enabled, config, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartMediaRenderingTracingEx()
        {
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = EngineEx.StartMediaRenderingTracingEx(connection);

            Assert.AreEqual(0, nRet);
        }

        #endregion
    }

}