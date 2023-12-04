using NUnit.Framework;
using Agora.Rtc;

namespace Agora.Rtc
{
    using uid_t = System.UInt32;
    [TestFixture]
    class UnitTest_IRtcEngineEx
    {

        public IRtcEngineEx RtcEngineEx;

        [SetUp]
        public void Setup()
        {
            RtcEngineEx = Rtc.RtcEngine.CreateAgoraRtcEngineEx(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = RtcEngineEx.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
        }

        [TearDown]
        public void TearDown() { RtcEngineEx.Dispose(); }

        #region terra IRtcEngineEx
        [Test]
        public void Test_JoinChannelEx()
        {
            string token = ParamsHelper.CreateParam<string>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            ChannelMediaOptions options = ParamsHelper.CreateParam<ChannelMediaOptions>();

            var nRet = RtcEngineEx.JoinChannelEx(token, connection, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_LeaveChannelEx()
        {
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.LeaveChannelEx(connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_LeaveChannelEx2()
        {
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            LeaveChannelOptions options = ParamsHelper.CreateParam<LeaveChannelOptions>();

            var nRet = RtcEngineEx.LeaveChannelEx(connection, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateChannelMediaOptionsEx()
        {
            ChannelMediaOptions options = ParamsHelper.CreateParam<ChannelMediaOptions>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.UpdateChannelMediaOptionsEx(options, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetVideoEncoderConfigurationEx()
        {
            VideoEncoderConfiguration config = ParamsHelper.CreateParam<VideoEncoderConfiguration>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.SetVideoEncoderConfigurationEx(config, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetupRemoteVideoEx()
        {
            VideoCanvas canvas = ParamsHelper.CreateParam<VideoCanvas>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.SetupRemoteVideoEx(canvas, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteRemoteAudioStreamEx()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            bool mute = ParamsHelper.CreateParam<bool>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.MuteRemoteAudioStreamEx(uid, mute, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteRemoteVideoStreamEx()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            bool mute = ParamsHelper.CreateParam<bool>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.MuteRemoteVideoStreamEx(uid, mute, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteVideoStreamTypeEx()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            VIDEO_STREAM_TYPE streamType = ParamsHelper.CreateParam<VIDEO_STREAM_TYPE>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.SetRemoteVideoStreamTypeEx(uid, streamType, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteLocalAudioStreamEx()
        {
            bool mute = ParamsHelper.CreateParam<bool>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.MuteLocalAudioStreamEx(mute, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteLocalVideoStreamEx()
        {
            bool mute = ParamsHelper.CreateParam<bool>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.MuteLocalVideoStreamEx(mute, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteAllRemoteAudioStreamsEx()
        {
            bool mute = ParamsHelper.CreateParam<bool>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.MuteAllRemoteAudioStreamsEx(mute, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteAllRemoteVideoStreamsEx()
        {
            bool mute = ParamsHelper.CreateParam<bool>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.MuteAllRemoteVideoStreamsEx(mute, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSubscribeAudioBlocklistEx()
        {
            uint[] uidList = ParamsHelper.CreateParam<uint[]>();
            int uidNumber = ParamsHelper.CreateParam<int>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.SetSubscribeAudioBlocklistEx(uidList, uidNumber, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSubscribeAudioAllowlistEx()
        {
            uint[] uidList = ParamsHelper.CreateParam<uint[]>();
            int uidNumber = ParamsHelper.CreateParam<int>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.SetSubscribeAudioAllowlistEx(uidList, uidNumber, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSubscribeVideoBlocklistEx()
        {
            uint[] uidList = ParamsHelper.CreateParam<uint[]>();
            int uidNumber = ParamsHelper.CreateParam<int>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.SetSubscribeVideoBlocklistEx(uidList, uidNumber, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSubscribeVideoAllowlistEx()
        {
            uint[] uidList = ParamsHelper.CreateParam<uint[]>();
            int uidNumber = ParamsHelper.CreateParam<int>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.SetSubscribeVideoAllowlistEx(uidList, uidNumber, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteVideoSubscriptionOptionsEx()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            VideoSubscriptionOptions options = ParamsHelper.CreateParam<VideoSubscriptionOptions>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.SetRemoteVideoSubscriptionOptionsEx(uid, options, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteVoicePositionEx()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            double pan = ParamsHelper.CreateParam<double>();
            double gain = ParamsHelper.CreateParam<double>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.SetRemoteVoicePositionEx(uid, pan, gain, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteUserSpatialAudioParamsEx()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            SpatialAudioParams @params = ParamsHelper.CreateParam<SpatialAudioParams>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.SetRemoteUserSpatialAudioParamsEx(uid, @params, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteRenderModeEx()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            RENDER_MODE_TYPE renderMode = ParamsHelper.CreateParam<RENDER_MODE_TYPE>();
            VIDEO_MIRROR_MODE_TYPE mirrorMode = ParamsHelper.CreateParam<VIDEO_MIRROR_MODE_TYPE>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.SetRemoteRenderModeEx(uid, renderMode, mirrorMode, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableLoopbackRecordingEx()
        {
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            bool enabled = ParamsHelper.CreateParam<bool>();
            string deviceName = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngineEx.EnableLoopbackRecordingEx(connection, enabled, deviceName);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustRecordingSignalVolumeEx()
        {
            int volume = ParamsHelper.CreateParam<int>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.AdjustRecordingSignalVolumeEx(volume, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteRecordingSignalEx()
        {
            bool mute = ParamsHelper.CreateParam<bool>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.MuteRecordingSignalEx(mute, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustUserPlaybackSignalVolumeEx()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            int volume = ParamsHelper.CreateParam<int>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.AdjustUserPlaybackSignalVolumeEx(uid, volume, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_IRtcEngineEx_GetConnectionStateEx()
        {
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.GetConnectionStateEx(connection);
            Assert.AreEqual(CONNECTION_STATE_TYPE.CONNECTION_STATE_DISCONNECTED, nRet);
        }

        [Test]
        public void Test_IRtcEngineEx_EnableEncryptionEx()
        {
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            bool enabled = ParamsHelper.CreateParam<bool>();
            EncryptionConfig config = ParamsHelper.CreateParam<EncryptionConfig>();

            config.encryptionKdfSalt = new byte[32];
            var nRet = RtcEngineEx.EnableEncryptionEx(connection, enabled, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_CreateDataStreamEx()
        {
            int streamId = ParamsHelper.CreateParam<int>();
            bool reliable = ParamsHelper.CreateParam<bool>();
            bool ordered = ParamsHelper.CreateParam<bool>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.CreateDataStreamEx(ref streamId, reliable, ordered, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_CreateDataStreamEx2()
        {
            int streamId = ParamsHelper.CreateParam<int>();
            DataStreamConfig config = ParamsHelper.CreateParam<DataStreamConfig>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.CreateDataStreamEx(ref streamId, config, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SendStreamMessageEx()
        {
            int streamId = ParamsHelper.CreateParam<int>();
            byte[] data = ParamsHelper.CreateParam<byte[]>();
            uint length = ParamsHelper.CreateParam<uint>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.SendStreamMessageEx(streamId, data, length, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AddVideoWatermarkEx()
        {
            string watermarkUrl = ParamsHelper.CreateParam<string>();
            WatermarkOptions options = ParamsHelper.CreateParam<WatermarkOptions>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.AddVideoWatermarkEx(watermarkUrl, options, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ClearVideoWatermarkEx()
        {
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.ClearVideoWatermarkEx(connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SendCustomReportMessageEx()
        {
            string id = ParamsHelper.CreateParam<string>();
            string category = ParamsHelper.CreateParam<string>();
            string @event = ParamsHelper.CreateParam<string>();
            string label = ParamsHelper.CreateParam<string>();
            int value = ParamsHelper.CreateParam<int>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.SendCustomReportMessageEx(id, category, @event, label, value, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableAudioVolumeIndicationEx()
        {
            int interval = ParamsHelper.CreateParam<int>();
            int smooth = ParamsHelper.CreateParam<int>();
            bool reportVad = ParamsHelper.CreateParam<bool>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.EnableAudioVolumeIndicationEx(interval, smooth, reportVad, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartRtmpStreamWithoutTranscodingEx()
        {
            string url = ParamsHelper.CreateParam<string>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.StartRtmpStreamWithoutTranscodingEx(url, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartRtmpStreamWithTranscodingEx()
        {
            string url = ParamsHelper.CreateParam<string>();
            LiveTranscoding transcoding = ParamsHelper.CreateParam<LiveTranscoding>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.StartRtmpStreamWithTranscodingEx(url, transcoding, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateRtmpTranscodingEx()
        {
            LiveTranscoding transcoding = ParamsHelper.CreateParam<LiveTranscoding>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.UpdateRtmpTranscodingEx(transcoding, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopRtmpStreamEx()
        {
            string url = ParamsHelper.CreateParam<string>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.StopRtmpStreamEx(url, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartOrUpdateChannelMediaRelayEx()
        {
            ChannelMediaRelayConfiguration configuration = ParamsHelper.CreateParam<ChannelMediaRelayConfiguration>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.StartOrUpdateChannelMediaRelayEx(configuration, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopChannelMediaRelayEx()
        {
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.StopChannelMediaRelayEx(connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PauseAllChannelMediaRelayEx()
        {
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.PauseAllChannelMediaRelayEx(connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ResumeAllChannelMediaRelayEx()
        {
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.ResumeAllChannelMediaRelayEx(connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetUserInfoByUserAccountEx()
        {
            string userAccount = ParamsHelper.CreateParam<string>();
            UserInfo userInfo = ParamsHelper.CreateParam<UserInfo>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.GetUserInfoByUserAccountEx(userAccount, ref userInfo, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetUserInfoByUidEx()
        {
            uint uid = ParamsHelper.CreateParam<uint>();
            UserInfo userInfo = ParamsHelper.CreateParam<UserInfo>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.GetUserInfoByUidEx(uid, ref userInfo, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableDualStreamModeEx()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            SimulcastStreamConfig streamConfig = ParamsHelper.CreateParam<SimulcastStreamConfig>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.EnableDualStreamModeEx(enabled, streamConfig, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetDualStreamModeEx()
        {
            SIMULCAST_STREAM_MODE mode = ParamsHelper.CreateParam<SIMULCAST_STREAM_MODE>();
            SimulcastStreamConfig streamConfig = ParamsHelper.CreateParam<SimulcastStreamConfig>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.SetDualStreamModeEx(mode, streamConfig, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetHighPriorityUserListEx()
        {
            uint[] uidList = ParamsHelper.CreateParam<uint[]>();
            int uidNum = ParamsHelper.CreateParam<int>();
            STREAM_FALLBACK_OPTIONS option = ParamsHelper.CreateParam<STREAM_FALLBACK_OPTIONS>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.SetHighPriorityUserListEx(uidList, uidNum, option, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_TakeSnapshotEx()
        {
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            uint uid = ParamsHelper.CreateParam<uint>();
            string filePath = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngineEx.TakeSnapshotEx(connection, uid, filePath);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableContentInspectEx()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            ContentInspectConfig config = ParamsHelper.CreateParam<ContentInspectConfig>();
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.EnableContentInspectEx(enabled, config, connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartMediaRenderingTracingEx()
        {
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();

            var nRet = RtcEngineEx.StartMediaRenderingTracingEx(connection);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetParametersEx()
        {
            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            string parameters = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngineEx.SetParametersEx(connection, parameters);
            Assert.AreEqual(0, nRet);
        }
        #endregion terra IRtcEngineEx
    }

}