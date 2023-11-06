using NUnit.Framework;
using Agora.Rtc;

namespace Agora.Rtc
{
    using uid_t = System.UInt32;
    [TestFixture]
    class UnitTest_IRtcEngineExS
    {

        public IRtcEngineExS RtcEngineExS;

        [SetUp]
        public void Setup()
        {
            RtcEngineExS = Rtc.RtcEngineS.CreateAgoraRtcEngineEx(DLLHelper.CreateFakeRtcEngineS());
            RtcEngineContextS rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = RtcEngineExS.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
        }

        [TearDown]
        public void TearDown() { RtcEngineExS.Dispose(); }

        #region terra IRtcEngineExS
        [Test]
        public void Test_JoinChannelEx()
        {
            string token = ParamsHelper.CreateParam<string>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            ChannelMediaOptions options = ParamsHelper.CreateParam<ChannelMediaOptions>();

            var nRet = RtcEngineExS.JoinChannelEx(token, connectionS, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_LeaveChannelEx()
        {
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.LeaveChannelEx(connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_LeaveChannelEx2()
        {
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            LeaveChannelOptions options = ParamsHelper.CreateParam<LeaveChannelOptions>();

            var nRet = RtcEngineExS.LeaveChannelEx(connectionS, options);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateChannelMediaOptionsEx()
        {
            ChannelMediaOptions options = ParamsHelper.CreateParam<ChannelMediaOptions>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.UpdateChannelMediaOptionsEx(options, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetVideoEncoderConfigurationEx()
        {
            VideoEncoderConfiguration config = ParamsHelper.CreateParam<VideoEncoderConfiguration>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.SetVideoEncoderConfigurationEx(config, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetupRemoteVideoEx()
        {
            VideoCanvasS canvas = ParamsHelper.CreateParam<VideoCanvasS>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.SetupRemoteVideoEx(canvas, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteRemoteAudioStreamEx()
        {
            string userAccount = ParamsHelper.CreateParam<string>();
            bool mute = ParamsHelper.CreateParam<bool>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.MuteRemoteAudioStreamEx(userAccount, mute, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteRemoteVideoStreamEx()
        {
            string userAccount = ParamsHelper.CreateParam<string>();
            bool mute = ParamsHelper.CreateParam<bool>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.MuteRemoteVideoStreamEx(userAccount, mute, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteVideoStreamTypeEx()
        {
            string userAccount = ParamsHelper.CreateParam<string>();
            VIDEO_STREAM_TYPE streamType = ParamsHelper.CreateParam<VIDEO_STREAM_TYPE>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.SetRemoteVideoStreamTypeEx(userAccount, streamType, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteLocalAudioStreamEx()
        {
            bool mute = ParamsHelper.CreateParam<bool>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.MuteLocalAudioStreamEx(mute, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteLocalVideoStreamEx()
        {
            bool mute = ParamsHelper.CreateParam<bool>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.MuteLocalVideoStreamEx(mute, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteAllRemoteAudioStreamsEx()
        {
            bool mute = ParamsHelper.CreateParam<bool>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.MuteAllRemoteAudioStreamsEx(mute, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteAllRemoteVideoStreamsEx()
        {
            bool mute = ParamsHelper.CreateParam<bool>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.MuteAllRemoteVideoStreamsEx(mute, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSubscribeAudioBlocklistEx()
        {
            string[] userAccountList = ParamsHelper.CreateParam<string[]>();
            int userAccountNumber = ParamsHelper.CreateParam<int>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.SetSubscribeAudioBlocklistEx(userAccountList, userAccountNumber, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSubscribeAudioAllowlistEx()
        {
            string[] userAccountList = ParamsHelper.CreateParam<string[]>();
            int userAccountNumber = ParamsHelper.CreateParam<int>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.SetSubscribeAudioAllowlistEx(userAccountList, userAccountNumber, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSubscribeVideoBlocklistEx()
        {
            string[] userAccountList = ParamsHelper.CreateParam<string[]>();
            int userAccountNumber = ParamsHelper.CreateParam<int>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.SetSubscribeVideoBlocklistEx(userAccountList, userAccountNumber, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetSubscribeVideoAllowlistEx()
        {
            string[] userAccountList = ParamsHelper.CreateParam<string[]>();
            int userAccountNumber = ParamsHelper.CreateParam<int>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.SetSubscribeVideoAllowlistEx(userAccountList, userAccountNumber, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteVideoSubscriptionOptionsEx()
        {
            string userAccount = ParamsHelper.CreateParam<string>();
            VideoSubscriptionOptions options = ParamsHelper.CreateParam<VideoSubscriptionOptions>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.SetRemoteVideoSubscriptionOptionsEx(userAccount, options, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteVoicePositionEx()
        {
            string userAccount = ParamsHelper.CreateParam<string>();
            double pan = ParamsHelper.CreateParam<double>();
            double gain = ParamsHelper.CreateParam<double>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.SetRemoteVoicePositionEx(userAccount, pan, gain, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteUserSpatialAudioParamsEx()
        {
            string userAccount = ParamsHelper.CreateParam<string>();
            SpatialAudioParams @params = ParamsHelper.CreateParam<SpatialAudioParams>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.SetRemoteUserSpatialAudioParamsEx(userAccount, @params, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteRenderModeEx()
        {
            string userAccount = ParamsHelper.CreateParam<string>();
            RENDER_MODE_TYPE renderMode = ParamsHelper.CreateParam<RENDER_MODE_TYPE>();
            VIDEO_MIRROR_MODE_TYPE mirrorMode = ParamsHelper.CreateParam<VIDEO_MIRROR_MODE_TYPE>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.SetRemoteRenderModeEx(userAccount, renderMode, mirrorMode, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableLoopbackRecordingEx()
        {
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            bool enabled = ParamsHelper.CreateParam<bool>();
            string deviceName = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngineExS.EnableLoopbackRecordingEx(connectionS, enabled, deviceName);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustRecordingSignalVolumeEx()
        {
            int volume = ParamsHelper.CreateParam<int>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.AdjustRecordingSignalVolumeEx(volume, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteRecordingSignalEx()
        {
            bool mute = ParamsHelper.CreateParam<bool>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.MuteRecordingSignalEx(mute, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AdjustUserPlaybackSignalVolumeEx()
        {
            string userAccount = ParamsHelper.CreateParam<string>();
            int volume = ParamsHelper.CreateParam<int>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.AdjustUserPlaybackSignalVolumeEx(userAccount, volume, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetConnectionStateEx()
        {
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.GetConnectionStateEx(connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableEncryptionEx()
        {
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            bool enabled = ParamsHelper.CreateParam<bool>();
            EncryptionConfig config = ParamsHelper.CreateParam<EncryptionConfig>();

            var nRet = RtcEngineExS.EnableEncryptionEx(connectionS, enabled, config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_CreateDataStreamEx()
        {
            int streamId = ParamsHelper.CreateParam<int>();
            bool reliable = ParamsHelper.CreateParam<bool>();
            bool ordered = ParamsHelper.CreateParam<bool>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.CreateDataStreamEx(ref streamId, reliable, ordered, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_CreateDataStreamEx2()
        {
            int streamId = ParamsHelper.CreateParam<int>();
            DataStreamConfig config = ParamsHelper.CreateParam<DataStreamConfig>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.CreateDataStreamEx(ref streamId, config, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SendStreamMessageEx()
        {
            int streamId = ParamsHelper.CreateParam<int>();
            byte[] data = ParamsHelper.CreateParam<byte[]>();
            uint length = ParamsHelper.CreateParam<uint>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.SendStreamMessageEx(streamId, data, length, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_AddVideoWatermarkEx()
        {
            string watermarkUrl = ParamsHelper.CreateParam<string>();
            WatermarkOptions options = ParamsHelper.CreateParam<WatermarkOptions>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.AddVideoWatermarkEx(watermarkUrl, options, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ClearVideoWatermarkEx()
        {
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.ClearVideoWatermarkEx(connectionS);
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
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.SendCustomReportMessageEx(id, category, @event, label, value, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableAudioVolumeIndicationEx()
        {
            int interval = ParamsHelper.CreateParam<int>();
            int smooth = ParamsHelper.CreateParam<int>();
            bool reportVad = ParamsHelper.CreateParam<bool>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.EnableAudioVolumeIndicationEx(interval, smooth, reportVad, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartRtmpStreamWithoutTranscodingEx()
        {
            string url = ParamsHelper.CreateParam<string>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.StartRtmpStreamWithoutTranscodingEx(url, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartRtmpStreamWithTranscodingEx()
        {
            string url = ParamsHelper.CreateParam<string>();
            LiveTranscodingS transcodingS = ParamsHelper.CreateParam<LiveTranscodingS>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.StartRtmpStreamWithTranscodingEx(url, transcodingS, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateRtmpTranscodingEx()
        {
            LiveTranscodingS transcodingS = ParamsHelper.CreateParam<LiveTranscodingS>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.UpdateRtmpTranscodingEx(transcodingS, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopRtmpStreamEx()
        {
            string url = ParamsHelper.CreateParam<string>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.StopRtmpStreamEx(url, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartOrUpdateChannelMediaRelayEx()
        {
            ChannelMediaRelayConfigurationS configurationS = ParamsHelper.CreateParam<ChannelMediaRelayConfigurationS>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.StartOrUpdateChannelMediaRelayEx(configurationS, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopChannelMediaRelayEx()
        {
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.StopChannelMediaRelayEx(connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_PauseAllChannelMediaRelayEx()
        {
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.PauseAllChannelMediaRelayEx(connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ResumeAllChannelMediaRelayEx()
        {
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.ResumeAllChannelMediaRelayEx(connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_EnableDualStreamModeEx()
        {
            bool enabled = ParamsHelper.CreateParam<bool>();
            SimulcastStreamConfig streamConfig = ParamsHelper.CreateParam<SimulcastStreamConfig>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.EnableDualStreamModeEx(enabled, streamConfig, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetDualStreamModeEx()
        {
            SIMULCAST_STREAM_MODE mode = ParamsHelper.CreateParam<SIMULCAST_STREAM_MODE>();
            SimulcastStreamConfig streamConfig = ParamsHelper.CreateParam<SimulcastStreamConfig>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.SetDualStreamModeEx(mode, streamConfig, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetHighPriorityUserListEx()
        {
            string[] userAccountList = ParamsHelper.CreateParam<string[]>();
            int uidNum = ParamsHelper.CreateParam<int>();
            STREAM_FALLBACK_OPTIONS option = ParamsHelper.CreateParam<STREAM_FALLBACK_OPTIONS>();
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.SetHighPriorityUserListEx(userAccountList, uidNum, option, connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_TakeSnapshotEx()
        {
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            string userAccount = ParamsHelper.CreateParam<string>();
            string filePath = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngineExS.TakeSnapshotEx(connectionS, userAccount, filePath);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartMediaRenderingTracingEx()
        {
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();

            var nRet = RtcEngineExS.StartMediaRenderingTracingEx(connectionS);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetParametersEx()
        {
            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            string parameters = ParamsHelper.CreateParam<string>();

            var nRet = RtcEngineExS.SetParametersEx(connectionS, parameters);
            Assert.AreEqual(0, nRet);
        }
        #endregion terra IRtcEngineExS
    }

}