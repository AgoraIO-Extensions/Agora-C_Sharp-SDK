using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Agora.Rtc.Ut.Event
{
    [TestFixture]
    public class UnitTest_IRtcEngineEventHandler
    {

        public IRtcEngineEx Engine;
        public UTRtcEngineEventHandler EventHandler;
        public IntPtr FakeRtcEnginePtr;
        public IrisCApiParam2 ApiParam;
        public Dictionary<string, System.Object> jsonObj = new Dictionary<string, object>();

        [SetUp]
        public void Setup()
        {
            FakeRtcEnginePtr = DLLHelper.CreateFakeRtcEngine();
            Engine = RtcEngine.CreateAgoraRtcEngineEx(FakeRtcEnginePtr);
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            ApiParam.AllocResult();

            EventHandler = new UTRtcEngineEventHandler();
            Engine.InitEventHandler(EventHandler);
            Engine.SetParameters("rtc.enable_debug_log", true);
        }

        [TearDown]
        public void TearDown()
        {
            Engine.Dispose();
            ApiParam.FreeResult();
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnAudioMetadataReceived()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONAUDIOMETADATARECEIVED_0d4eb96;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint uid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("uid", uid);

            byte[] metadata = ParamsHelper.CreateParam<byte[]>();
            jsonObj.Add("metadata", Marshal.UnsafeAddrOfPinnedArrayElement(metadata, 0));

            ulong length = ParamsHelper.CreateParam<ulong>();
            jsonObj.Add("length", length);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioMetadataReceivedPassed(connection, uid, metadata, length));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnStreamMessage()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONSTREAMMESSAGE_99898cb;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            int streamId = ParamsHelper.CreateParam<int>();
            jsonObj.Add("streamId", streamId);

            byte[] data = ParamsHelper.CreateParam<byte[]>();
            jsonObj.Add("data", Marshal.UnsafeAddrOfPinnedArrayElement(data, 0));

            ulong length = ParamsHelper.CreateParam<ulong>();
            jsonObj.Add("length", length);

            ulong sentTs = ParamsHelper.CreateParam<ulong>();
            jsonObj.Add("sentTs", sentTs);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnStreamMessagePassed(connection, remoteUid, streamId, data, length, sentTs));
        }

        #region terra IRtcEngineEventHandler
        [Test]
        public void Test_IRtcEngineEventHandler_OnProxyConnected()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONPROXYCONNECTED_9f89fd0;

            jsonObj.Clear();

            string channel = ParamsHelper.CreateParam<string>();
            jsonObj.Add("channel", channel);

            uint uid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("uid", uid);

            PROXY_TYPE proxyType = ParamsHelper.CreateParam<PROXY_TYPE>();
            jsonObj.Add("proxyType", proxyType);

            string localProxyIp = ParamsHelper.CreateParam<string>();
            jsonObj.Add("localProxyIp", localProxyIp);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnProxyConnectedPassed(channel, uid, proxyType, localProxyIp, elapsed));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnError()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONERROR_d26c0fd;

            jsonObj.Clear();

            int err = ParamsHelper.CreateParam<int>();
            jsonObj.Add("err", err);

            string msg = ParamsHelper.CreateParam<string>();
            jsonObj.Add("msg", msg);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnErrorPassed(err, msg));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnLastmileProbeResult()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONLASTMILEPROBERESULT_42b5843;

            jsonObj.Clear();

            LastmileProbeResult result = ParamsHelper.CreateParam<LastmileProbeResult>();
            jsonObj.Add("result", result);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLastmileProbeResultPassed(result));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnAudioDeviceStateChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONAUDIODEVICESTATECHANGED_976d8c3;

            jsonObj.Clear();

            string deviceId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("deviceId", deviceId);

            MEDIA_DEVICE_TYPE deviceType = ParamsHelper.CreateParam<MEDIA_DEVICE_TYPE>();
            jsonObj.Add("deviceType", deviceType);

            MEDIA_DEVICE_STATE_TYPE deviceState = ParamsHelper.CreateParam<MEDIA_DEVICE_STATE_TYPE>();
            jsonObj.Add("deviceState", deviceState);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioDeviceStateChangedPassed(deviceId, deviceType, deviceState));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnAudioMixingPositionChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONAUDIOMIXINGPOSITIONCHANGED_f631116;

            jsonObj.Clear();

            long position = ParamsHelper.CreateParam<long>();
            jsonObj.Add("position", position);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioMixingPositionChangedPassed(position));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnAudioMixingFinished()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONAUDIOMIXINGFINISHED;

            jsonObj.Clear();

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioMixingFinishedPassed());
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnAudioEffectFinished()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONAUDIOEFFECTFINISHED_46f8ab7;

            jsonObj.Clear();

            int soundId = ParamsHelper.CreateParam<int>();
            jsonObj.Add("soundId", soundId);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioEffectFinishedPassed(soundId));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnVideoDeviceStateChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONVIDEODEVICESTATECHANGED_976d8c3;

            jsonObj.Clear();

            string deviceId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("deviceId", deviceId);

            MEDIA_DEVICE_TYPE deviceType = ParamsHelper.CreateParam<MEDIA_DEVICE_TYPE>();
            jsonObj.Add("deviceType", deviceType);

            MEDIA_DEVICE_STATE_TYPE deviceState = ParamsHelper.CreateParam<MEDIA_DEVICE_STATE_TYPE>();
            jsonObj.Add("deviceState", deviceState);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnVideoDeviceStateChangedPassed(deviceId, deviceType, deviceState));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnUplinkNetworkInfoUpdated()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONUPLINKNETWORKINFOUPDATED_cbb1856;

            jsonObj.Clear();

            UplinkNetworkInfo info = ParamsHelper.CreateParam<UplinkNetworkInfo>();
            jsonObj.Add("info", info);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUplinkNetworkInfoUpdatedPassed(info));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnDownlinkNetworkInfoUpdated()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONDOWNLINKNETWORKINFOUPDATED_e9d5bd9;

            jsonObj.Clear();

            DownlinkNetworkInfo info = ParamsHelper.CreateParam<DownlinkNetworkInfo>();
            jsonObj.Add("info", info);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnDownlinkNetworkInfoUpdatedPassed(info));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnLastmileQuality()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONLASTMILEQUALITY_46f8ab7;

            jsonObj.Clear();

            int quality = ParamsHelper.CreateParam<int>();
            jsonObj.Add("quality", quality);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLastmileQualityPassed(quality));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnFirstLocalVideoFrame()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONFIRSTLOCALVIDEOFRAME_ebdfd19;

            jsonObj.Clear();

            VIDEO_SOURCE_TYPE source = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            jsonObj.Add("source", source);

            int width = ParamsHelper.CreateParam<int>();
            jsonObj.Add("width", width);

            int height = ParamsHelper.CreateParam<int>();
            jsonObj.Add("height", height);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFirstLocalVideoFramePassed(source, width, height, elapsed));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnLocalVideoStateChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONLOCALVIDEOSTATECHANGED_a44228a;

            jsonObj.Clear();

            VIDEO_SOURCE_TYPE source = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            jsonObj.Add("source", source);

            LOCAL_VIDEO_STREAM_STATE state = ParamsHelper.CreateParam<LOCAL_VIDEO_STREAM_STATE>();
            jsonObj.Add("state", state);

            LOCAL_VIDEO_STREAM_REASON reason = ParamsHelper.CreateParam<LOCAL_VIDEO_STREAM_REASON>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalVideoStateChangedPassed(source, state, reason));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnCameraReady()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONCAMERAREADY;

            jsonObj.Clear();

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnCameraReadyPassed());
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnCameraFocusAreaChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONCAMERAFOCUSAREACHANGED_41c5354;

            jsonObj.Clear();

            int x = ParamsHelper.CreateParam<int>();
            jsonObj.Add("x", x);

            int y = ParamsHelper.CreateParam<int>();
            jsonObj.Add("y", y);

            int width = ParamsHelper.CreateParam<int>();
            jsonObj.Add("width", width);

            int height = ParamsHelper.CreateParam<int>();
            jsonObj.Add("height", height);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnCameraFocusAreaChangedPassed(x, y, width, height));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnCameraExposureAreaChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONCAMERAEXPOSUREAREACHANGED_41c5354;

            jsonObj.Clear();

            int x = ParamsHelper.CreateParam<int>();
            jsonObj.Add("x", x);

            int y = ParamsHelper.CreateParam<int>();
            jsonObj.Add("y", y);

            int width = ParamsHelper.CreateParam<int>();
            jsonObj.Add("width", width);

            int height = ParamsHelper.CreateParam<int>();
            jsonObj.Add("height", height);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnCameraExposureAreaChangedPassed(x, y, width, height));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnFacePositionChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONFACEPOSITIONCHANGED_197b4a7;

            jsonObj.Clear();

            int imageWidth = ParamsHelper.CreateParam<int>();
            jsonObj.Add("imageWidth", imageWidth);

            int imageHeight = ParamsHelper.CreateParam<int>();
            jsonObj.Add("imageHeight", imageHeight);

            Rectangle[] vecRectangle = ParamsHelper.CreateParam<Rectangle[]>();
            jsonObj.Add("vecRectangle", vecRectangle);

            int[] vecDistance = ParamsHelper.CreateParam<int[]>();
            jsonObj.Add("vecDistance", vecDistance);

            int numFaces = ParamsHelper.CreateParam<int>();
            jsonObj.Add("numFaces", numFaces);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(false, EventHandler.OnFacePositionChangedPassed(imageWidth, imageHeight, vecRectangle, vecDistance, numFaces));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnVideoStopped()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONVIDEOSTOPPED;

            jsonObj.Clear();

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnVideoStoppedPassed());
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnAudioMixingStateChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONAUDIOMIXINGSTATECHANGED_fd2c0a6;

            jsonObj.Clear();

            AUDIO_MIXING_STATE_TYPE state = ParamsHelper.CreateParam<AUDIO_MIXING_STATE_TYPE>();
            jsonObj.Add("state", state);

            AUDIO_MIXING_REASON_TYPE reason = ParamsHelper.CreateParam<AUDIO_MIXING_REASON_TYPE>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioMixingStateChangedPassed(state, reason));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnRhythmPlayerStateChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONRHYTHMPLAYERSTATECHANGED_09360d2;

            jsonObj.Clear();

            RHYTHM_PLAYER_STATE_TYPE state = ParamsHelper.CreateParam<RHYTHM_PLAYER_STATE_TYPE>();
            jsonObj.Add("state", state);

            RHYTHM_PLAYER_REASON reason = ParamsHelper.CreateParam<RHYTHM_PLAYER_REASON>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRhythmPlayerStateChangedPassed(state, reason));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnContentInspectResult()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONCONTENTINSPECTRESULT_ba185c8;

            jsonObj.Clear();

            CONTENT_INSPECT_RESULT result = ParamsHelper.CreateParam<CONTENT_INSPECT_RESULT>();
            jsonObj.Add("result", result);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnContentInspectResultPassed(result));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnAudioDeviceVolumeChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONAUDIODEVICEVOLUMECHANGED_55ab726;

            jsonObj.Clear();

            MEDIA_DEVICE_TYPE deviceType = ParamsHelper.CreateParam<MEDIA_DEVICE_TYPE>();
            jsonObj.Add("deviceType", deviceType);

            int volume = ParamsHelper.CreateParam<int>();
            jsonObj.Add("volume", volume);

            bool muted = ParamsHelper.CreateParam<bool>();
            jsonObj.Add("muted", muted);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioDeviceVolumeChangedPassed(deviceType, volume, muted));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnRtmpStreamingStateChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONRTMPSTREAMINGSTATECHANGED_1f07503;

            jsonObj.Clear();

            string url = ParamsHelper.CreateParam<string>();
            jsonObj.Add("url", url);

            RTMP_STREAM_PUBLISH_STATE state = ParamsHelper.CreateParam<RTMP_STREAM_PUBLISH_STATE>();
            jsonObj.Add("state", state);

            RTMP_STREAM_PUBLISH_REASON reason = ParamsHelper.CreateParam<RTMP_STREAM_PUBLISH_REASON>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRtmpStreamingStateChangedPassed(url, state, reason));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnRtmpStreamingEvent()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONRTMPSTREAMINGEVENT_2e48ef5;

            jsonObj.Clear();

            string url = ParamsHelper.CreateParam<string>();
            jsonObj.Add("url", url);

            RTMP_STREAMING_EVENT eventCode = ParamsHelper.CreateParam<RTMP_STREAMING_EVENT>();
            jsonObj.Add("eventCode", eventCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRtmpStreamingEventPassed(url, eventCode));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnTranscodingUpdated()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONTRANSCODINGUPDATED;

            jsonObj.Clear();

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnTranscodingUpdatedPassed());
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnAudioRoutingChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONAUDIOROUTINGCHANGED_46f8ab7;

            jsonObj.Clear();

            int routing = ParamsHelper.CreateParam<int>();
            jsonObj.Add("routing", routing);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioRoutingChangedPassed(routing));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnChannelMediaRelayStateChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONCHANNELMEDIARELAYSTATECHANGED_4e92b3c;

            jsonObj.Clear();

            int state = ParamsHelper.CreateParam<int>();
            jsonObj.Add("state", state);

            int code = ParamsHelper.CreateParam<int>();
            jsonObj.Add("code", code);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnChannelMediaRelayStateChangedPassed(state, code));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnLocalPublishFallbackToAudioOnly()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONLOCALPUBLISHFALLBACKTOAUDIOONLY_5039d15;

            jsonObj.Clear();

            bool isFallbackOrRecover = ParamsHelper.CreateParam<bool>();
            jsonObj.Add("isFallbackOrRecover", isFallbackOrRecover);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalPublishFallbackToAudioOnlyPassed(isFallbackOrRecover));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnRemoteSubscribeFallbackToAudioOnly()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONREMOTESUBSCRIBEFALLBACKTOAUDIOONLY_dbdc15a;

            jsonObj.Clear();

            uint uid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("uid", uid);

            bool isFallbackOrRecover = ParamsHelper.CreateParam<bool>();
            jsonObj.Add("isFallbackOrRecover", isFallbackOrRecover);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoteSubscribeFallbackToAudioOnlyPassed(uid, isFallbackOrRecover));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnPermissionError()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONPERMISSIONERROR_f37c62b;

            jsonObj.Clear();

            PERMISSION_TYPE permissionType = ParamsHelper.CreateParam<PERMISSION_TYPE>();
            jsonObj.Add("permissionType", permissionType);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPermissionErrorPassed(permissionType));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnLocalUserRegistered()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONLOCALUSERREGISTERED_1922dd1;

            jsonObj.Clear();

            uint uid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("uid", uid);

            string userAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("userAccount", userAccount);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalUserRegisteredPassed(uid, userAccount));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnUserInfoUpdated()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONUSERINFOUPDATED_2120245;

            jsonObj.Clear();

            uint uid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("uid", uid);

            UserInfo info = ParamsHelper.CreateParam<UserInfo>();
            jsonObj.Add("info", info);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserInfoUpdatedPassed(uid, info));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnLocalVideoTranscoderError()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONLOCALVIDEOTRANSCODERERROR_83e3a9c;

            jsonObj.Clear();

            TranscodingVideoStream stream = ParamsHelper.CreateParam<TranscodingVideoStream>();
            jsonObj.Add("stream", stream);

            VIDEO_TRANSCODER_ERROR error = ParamsHelper.CreateParam<VIDEO_TRANSCODER_ERROR>();
            jsonObj.Add("error", error);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalVideoTranscoderErrorPassed(stream, error));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnAudioSubscribeStateChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONAUDIOSUBSCRIBESTATECHANGED_e0ec28e;

            jsonObj.Clear();

            string channel = ParamsHelper.CreateParam<string>();
            jsonObj.Add("channel", channel);

            uint uid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("uid", uid);

            STREAM_SUBSCRIBE_STATE oldState = ParamsHelper.CreateParam<STREAM_SUBSCRIBE_STATE>();
            jsonObj.Add("oldState", oldState);

            STREAM_SUBSCRIBE_STATE newState = ParamsHelper.CreateParam<STREAM_SUBSCRIBE_STATE>();
            jsonObj.Add("newState", newState);

            int elapseSinceLastState = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapseSinceLastState", elapseSinceLastState);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioSubscribeStateChangedPassed(channel, uid, oldState, newState, elapseSinceLastState));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnVideoSubscribeStateChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONVIDEOSUBSCRIBESTATECHANGED_e0ec28e;

            jsonObj.Clear();

            string channel = ParamsHelper.CreateParam<string>();
            jsonObj.Add("channel", channel);

            uint uid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("uid", uid);

            STREAM_SUBSCRIBE_STATE oldState = ParamsHelper.CreateParam<STREAM_SUBSCRIBE_STATE>();
            jsonObj.Add("oldState", oldState);

            STREAM_SUBSCRIBE_STATE newState = ParamsHelper.CreateParam<STREAM_SUBSCRIBE_STATE>();
            jsonObj.Add("newState", newState);

            int elapseSinceLastState = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapseSinceLastState", elapseSinceLastState);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnVideoSubscribeStateChangedPassed(channel, uid, oldState, newState, elapseSinceLastState));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnAudioPublishStateChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONAUDIOPUBLISHSTATECHANGED_2c13a28;

            jsonObj.Clear();

            string channel = ParamsHelper.CreateParam<string>();
            jsonObj.Add("channel", channel);

            STREAM_PUBLISH_STATE oldState = ParamsHelper.CreateParam<STREAM_PUBLISH_STATE>();
            jsonObj.Add("oldState", oldState);

            STREAM_PUBLISH_STATE newState = ParamsHelper.CreateParam<STREAM_PUBLISH_STATE>();
            jsonObj.Add("newState", newState);

            int elapseSinceLastState = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapseSinceLastState", elapseSinceLastState);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioPublishStateChangedPassed(channel, oldState, newState, elapseSinceLastState));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnVideoPublishStateChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONVIDEOPUBLISHSTATECHANGED_5b45b6e;

            jsonObj.Clear();

            VIDEO_SOURCE_TYPE source = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            jsonObj.Add("source", source);

            string channel = ParamsHelper.CreateParam<string>();
            jsonObj.Add("channel", channel);

            STREAM_PUBLISH_STATE oldState = ParamsHelper.CreateParam<STREAM_PUBLISH_STATE>();
            jsonObj.Add("oldState", oldState);

            STREAM_PUBLISH_STATE newState = ParamsHelper.CreateParam<STREAM_PUBLISH_STATE>();
            jsonObj.Add("newState", newState);

            int elapseSinceLastState = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapseSinceLastState", elapseSinceLastState);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnVideoPublishStateChangedPassed(source, channel, oldState, newState, elapseSinceLastState));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnExtensionEventWithContext()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONEXTENSIONEVENTWITHCONTEXT_a5fb27a;

            jsonObj.Clear();

            ExtensionContext context = ParamsHelper.CreateParam<ExtensionContext>();
            jsonObj.Add("context", context);

            string key = ParamsHelper.CreateParam<string>();
            jsonObj.Add("key", key);

            string value = ParamsHelper.CreateParam<string>();
            jsonObj.Add("value", value);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnExtensionEventWithContextPassed(context, key, value));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnExtensionStartedWithContext()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONEXTENSIONSTARTEDWITHCONTEXT_67c38e3;

            jsonObj.Clear();

            ExtensionContext context = ParamsHelper.CreateParam<ExtensionContext>();
            jsonObj.Add("context", context);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnExtensionStartedWithContextPassed(context));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnExtensionStoppedWithContext()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONEXTENSIONSTOPPEDWITHCONTEXT_67c38e3;

            jsonObj.Clear();

            ExtensionContext context = ParamsHelper.CreateParam<ExtensionContext>();
            jsonObj.Add("context", context);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnExtensionStoppedWithContextPassed(context));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnExtensionErrorWithContext()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONEXTENSIONERRORWITHCONTEXT_a452f11;

            jsonObj.Clear();

            ExtensionContext context = ParamsHelper.CreateParam<ExtensionContext>();
            jsonObj.Add("context", context);

            int error = ParamsHelper.CreateParam<int>();
            jsonObj.Add("error", error);

            string message = ParamsHelper.CreateParam<string>();
            jsonObj.Add("message", message);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnExtensionErrorWithContextPassed(context, error, message));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnJoinChannelSuccess()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONJOINCHANNELSUCCESS_263e4cd;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnJoinChannelSuccessPassed(connection, elapsed));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnRejoinChannelSuccess()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONREJOINCHANNELSUCCESS_263e4cd;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRejoinChannelSuccessPassed(connection, elapsed));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnAudioQuality()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONAUDIOQUALITY_5c7294b;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            int quality = ParamsHelper.CreateParam<int>();
            jsonObj.Add("quality", quality);

            ushort delay = ParamsHelper.CreateParam<ushort>();
            jsonObj.Add("delay", delay);

            ushort lost = ParamsHelper.CreateParam<ushort>();
            jsonObj.Add("lost", lost);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioQualityPassed(connection, remoteUid, quality, delay, lost));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnAudioVolumeIndication()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONAUDIOVOLUMEINDICATION_781482a;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            AudioVolumeInfo[] speakers = ParamsHelper.CreateParam<AudioVolumeInfo[]>();
            jsonObj.Add("speakers", speakers);

            uint speakerNumber = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("speakerNumber", speakerNumber);

            int totalVolume = ParamsHelper.CreateParam<int>();
            jsonObj.Add("totalVolume", totalVolume);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioVolumeIndicationPassed(connection, speakers, speakerNumber, totalVolume));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnLeaveChannel()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONLEAVECHANNEL_c8e730d;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            RtcStats stats = ParamsHelper.CreateParam<RtcStats>();
            jsonObj.Add("stats", stats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLeaveChannelPassed(connection, stats));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnRtcStats()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONRTCSTATS_c8e730d;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            RtcStats stats = ParamsHelper.CreateParam<RtcStats>();
            jsonObj.Add("stats", stats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRtcStatsPassed(connection, stats));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnNetworkQuality()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONNETWORKQUALITY_34d8b3c;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            int txQuality = ParamsHelper.CreateParam<int>();
            jsonObj.Add("txQuality", txQuality);

            int rxQuality = ParamsHelper.CreateParam<int>();
            jsonObj.Add("rxQuality", rxQuality);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnNetworkQualityPassed(connection, remoteUid, txQuality, rxQuality));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnIntraRequestReceived()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONINTRAREQUESTRECEIVED_c81e1a4;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnIntraRequestReceivedPassed(connection));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnFirstLocalVideoFramePublished()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONFIRSTLOCALVIDEOFRAMEPUBLISHED_263e4cd;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFirstLocalVideoFramePublishedPassed(connection, elapsed));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnFirstRemoteVideoDecoded()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONFIRSTREMOTEVIDEODECODED_a68170a;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            int width = ParamsHelper.CreateParam<int>();
            jsonObj.Add("width", width);

            int height = ParamsHelper.CreateParam<int>();
            jsonObj.Add("height", height);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFirstRemoteVideoDecodedPassed(connection, remoteUid, width, height, elapsed));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnVideoSizeChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONVIDEOSIZECHANGED_99bf45c;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            jsonObj.Add("sourceType", sourceType);

            uint uid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("uid", uid);

            int width = ParamsHelper.CreateParam<int>();
            jsonObj.Add("width", width);

            int height = ParamsHelper.CreateParam<int>();
            jsonObj.Add("height", height);

            int rotation = ParamsHelper.CreateParam<int>();
            jsonObj.Add("rotation", rotation);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnVideoSizeChangedPassed(connection, sourceType, uid, width, height, rotation));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnRemoteVideoStateChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONREMOTEVIDEOSTATECHANGED_a14e9d1;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            REMOTE_VIDEO_STATE state = ParamsHelper.CreateParam<REMOTE_VIDEO_STATE>();
            jsonObj.Add("state", state);

            REMOTE_VIDEO_STATE_REASON reason = ParamsHelper.CreateParam<REMOTE_VIDEO_STATE_REASON>();
            jsonObj.Add("reason", reason);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoteVideoStateChangedPassed(connection, remoteUid, state, reason, elapsed));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnFirstRemoteVideoFrame()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONFIRSTREMOTEVIDEOFRAME_a68170a;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            int width = ParamsHelper.CreateParam<int>();
            jsonObj.Add("width", width);

            int height = ParamsHelper.CreateParam<int>();
            jsonObj.Add("height", height);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFirstRemoteVideoFramePassed(connection, remoteUid, width, height, elapsed));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnUserJoined()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONUSERJOINED_c5499bd;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserJoinedPassed(connection, remoteUid, elapsed));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnUserOffline()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONUSEROFFLINE_0a32aac;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            USER_OFFLINE_REASON_TYPE reason = ParamsHelper.CreateParam<USER_OFFLINE_REASON_TYPE>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserOfflinePassed(connection, remoteUid, reason));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnUserMuteAudio()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONUSERMUTEAUDIO_0aac2fe;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            bool muted = ParamsHelper.CreateParam<bool>();
            jsonObj.Add("muted", muted);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserMuteAudioPassed(connection, remoteUid, muted));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnUserMuteVideo()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONUSERMUTEVIDEO_0aac2fe;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            bool muted = ParamsHelper.CreateParam<bool>();
            jsonObj.Add("muted", muted);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserMuteVideoPassed(connection, remoteUid, muted));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnUserEnableVideo()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONUSERENABLEVIDEO_0aac2fe;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            bool enabled = ParamsHelper.CreateParam<bool>();
            jsonObj.Add("enabled", enabled);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserEnableVideoPassed(connection, remoteUid, enabled));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnUserEnableLocalVideo()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONUSERENABLELOCALVIDEO_0aac2fe;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            bool enabled = ParamsHelper.CreateParam<bool>();
            jsonObj.Add("enabled", enabled);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserEnableLocalVideoPassed(connection, remoteUid, enabled));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnUserStateChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONUSERSTATECHANGED_65f95a7;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            uint state = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("state", state);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserStateChangedPassed(connection, remoteUid, state));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnLocalAudioStats()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONLOCALAUDIOSTATS_5657f05;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            LocalAudioStats stats = ParamsHelper.CreateParam<LocalAudioStats>();
            jsonObj.Add("stats", stats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalAudioStatsPassed(connection, stats));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnRemoteAudioStats()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONREMOTEAUDIOSTATS_ffbde06;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            RemoteAudioStats stats = ParamsHelper.CreateParam<RemoteAudioStats>();
            jsonObj.Add("stats", stats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoteAudioStatsPassed(connection, stats));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnLocalVideoStats()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONLOCALVIDEOSTATS_3ac0eb4;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            LocalVideoStats stats = ParamsHelper.CreateParam<LocalVideoStats>();
            jsonObj.Add("stats", stats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalVideoStatsPassed(connection, stats));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnRemoteVideoStats()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONREMOTEVIDEOSTATS_2f43a70;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            RemoteVideoStats stats = ParamsHelper.CreateParam<RemoteVideoStats>();
            jsonObj.Add("stats", stats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoteVideoStatsPassed(connection, stats));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnConnectionLost()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONCONNECTIONLOST_c81e1a4;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnConnectionLostPassed(connection));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnConnectionInterrupted()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONCONNECTIONINTERRUPTED_c81e1a4;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnConnectionInterruptedPassed(connection));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnConnectionBanned()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONCONNECTIONBANNED_c81e1a4;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnConnectionBannedPassed(connection));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnStreamMessageError()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONSTREAMMESSAGEERROR_fe302fc;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            int streamId = ParamsHelper.CreateParam<int>();
            jsonObj.Add("streamId", streamId);

            int code = ParamsHelper.CreateParam<int>();
            jsonObj.Add("code", code);

            int missed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("missed", missed);

            int cached = ParamsHelper.CreateParam<int>();
            jsonObj.Add("cached", cached);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnStreamMessageErrorPassed(connection, remoteUid, streamId, code, missed, cached));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnRequestToken()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONREQUESTTOKEN_c81e1a4;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRequestTokenPassed(connection));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnLicenseValidationFailure()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONLICENSEVALIDATIONFAILURE_5dfd95e;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            LICENSE_ERROR_TYPE reason = ParamsHelper.CreateParam<LICENSE_ERROR_TYPE>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLicenseValidationFailurePassed(connection, reason));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnTokenPrivilegeWillExpire()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONTOKENPRIVILEGEWILLEXPIRE_8225ea3;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            string token = ParamsHelper.CreateParam<string>();
            jsonObj.Add("token", token);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnTokenPrivilegeWillExpirePassed(connection, token));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnFirstLocalAudioFramePublished()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONFIRSTLOCALAUDIOFRAMEPUBLISHED_263e4cd;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFirstLocalAudioFramePublishedPassed(connection, elapsed));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnFirstRemoteAudioFrame()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONFIRSTREMOTEAUDIOFRAME_c5499bd;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint userId = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("userId", userId);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFirstRemoteAudioFramePassed(connection, userId, elapsed));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnFirstRemoteAudioDecoded()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONFIRSTREMOTEAUDIODECODED_c5499bd;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint uid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("uid", uid);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFirstRemoteAudioDecodedPassed(connection, uid, elapsed));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnLocalAudioStateChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONLOCALAUDIOSTATECHANGED_13b6c02;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            LOCAL_AUDIO_STREAM_STATE state = ParamsHelper.CreateParam<LOCAL_AUDIO_STREAM_STATE>();
            jsonObj.Add("state", state);

            LOCAL_AUDIO_STREAM_REASON reason = ParamsHelper.CreateParam<LOCAL_AUDIO_STREAM_REASON>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalAudioStateChangedPassed(connection, state, reason));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnRemoteAudioStateChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONREMOTEAUDIOSTATECHANGED_056772e;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            REMOTE_AUDIO_STATE state = ParamsHelper.CreateParam<REMOTE_AUDIO_STATE>();
            jsonObj.Add("state", state);

            REMOTE_AUDIO_STATE_REASON reason = ParamsHelper.CreateParam<REMOTE_AUDIO_STATE_REASON>();
            jsonObj.Add("reason", reason);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoteAudioStateChangedPassed(connection, remoteUid, state, reason, elapsed));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnActiveSpeaker()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONACTIVESPEAKER_dd67adc;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint uid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("uid", uid);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnActiveSpeakerPassed(connection, uid));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnClientRoleChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONCLIENTROLECHANGED_2acaf10;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            CLIENT_ROLE_TYPE oldRole = ParamsHelper.CreateParam<CLIENT_ROLE_TYPE>();
            jsonObj.Add("oldRole", oldRole);

            CLIENT_ROLE_TYPE newRole = ParamsHelper.CreateParam<CLIENT_ROLE_TYPE>();
            jsonObj.Add("newRole", newRole);

            ClientRoleOptions newRoleOptions = ParamsHelper.CreateParam<ClientRoleOptions>();
            jsonObj.Add("newRoleOptions", newRoleOptions);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnClientRoleChangedPassed(connection, oldRole, newRole, newRoleOptions));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnClientRoleChangeFailed()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONCLIENTROLECHANGEFAILED_5a3af5b;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            CLIENT_ROLE_CHANGE_FAILED_REASON reason = ParamsHelper.CreateParam<CLIENT_ROLE_CHANGE_FAILED_REASON>();
            jsonObj.Add("reason", reason);

            CLIENT_ROLE_TYPE currentRole = ParamsHelper.CreateParam<CLIENT_ROLE_TYPE>();
            jsonObj.Add("currentRole", currentRole);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnClientRoleChangeFailedPassed(connection, reason, currentRole));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnRemoteAudioTransportStats()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONREMOTEAUDIOTRANSPORTSTATS_527a345;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            ushort delay = ParamsHelper.CreateParam<ushort>();
            jsonObj.Add("delay", delay);

            ushort lost = ParamsHelper.CreateParam<ushort>();
            jsonObj.Add("lost", lost);

            ushort rxKBitRate = ParamsHelper.CreateParam<ushort>();
            jsonObj.Add("rxKBitRate", rxKBitRate);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoteAudioTransportStatsPassed(connection, remoteUid, delay, lost, rxKBitRate));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnRemoteVideoTransportStats()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONREMOTEVIDEOTRANSPORTSTATS_527a345;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            ushort delay = ParamsHelper.CreateParam<ushort>();
            jsonObj.Add("delay", delay);

            ushort lost = ParamsHelper.CreateParam<ushort>();
            jsonObj.Add("lost", lost);

            ushort rxKBitRate = ParamsHelper.CreateParam<ushort>();
            jsonObj.Add("rxKBitRate", rxKBitRate);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoteVideoTransportStatsPassed(connection, remoteUid, delay, lost, rxKBitRate));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnConnectionStateChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONCONNECTIONSTATECHANGED_4075a9c;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            CONNECTION_STATE_TYPE state = ParamsHelper.CreateParam<CONNECTION_STATE_TYPE>();
            jsonObj.Add("state", state);

            CONNECTION_CHANGED_REASON_TYPE reason = ParamsHelper.CreateParam<CONNECTION_CHANGED_REASON_TYPE>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnConnectionStateChangedPassed(connection, state, reason));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnWlAccMessage()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONWLACCMESSAGE_2b9068e;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            WLACC_MESSAGE_REASON reason = ParamsHelper.CreateParam<WLACC_MESSAGE_REASON>();
            jsonObj.Add("reason", reason);

            WLACC_SUGGEST_ACTION action = ParamsHelper.CreateParam<WLACC_SUGGEST_ACTION>();
            jsonObj.Add("action", action);

            string wlAccMsg = ParamsHelper.CreateParam<string>();
            jsonObj.Add("wlAccMsg", wlAccMsg);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnWlAccMessagePassed(connection, reason, action, wlAccMsg));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnWlAccStats()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONWLACCSTATS_b162607;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            WlAccStats currentStats = ParamsHelper.CreateParam<WlAccStats>();
            jsonObj.Add("currentStats", currentStats);

            WlAccStats averageStats = ParamsHelper.CreateParam<WlAccStats>();
            jsonObj.Add("averageStats", averageStats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnWlAccStatsPassed(connection, currentStats, averageStats));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnNetworkTypeChanged()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONNETWORKTYPECHANGED_388fd6f;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            NETWORK_TYPE type = ParamsHelper.CreateParam<NETWORK_TYPE>();
            jsonObj.Add("type", type);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnNetworkTypeChangedPassed(connection, type));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnEncryptionError()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONENCRYPTIONERROR_e7a65fe;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            ENCRYPTION_ERROR_TYPE errorType = ParamsHelper.CreateParam<ENCRYPTION_ERROR_TYPE>();
            jsonObj.Add("errorType", errorType);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnEncryptionErrorPassed(connection, errorType));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnUploadLogResult()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONUPLOADLOGRESULT_3115804;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            string requestId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("requestId", requestId);

            bool success = ParamsHelper.CreateParam<bool>();
            jsonObj.Add("success", success);

            UPLOAD_ERROR_REASON reason = ParamsHelper.CreateParam<UPLOAD_ERROR_REASON>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUploadLogResultPassed(connection, requestId, success, reason));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnUserAccountUpdated()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONUSERACCOUNTUPDATED_de1c015;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            string remoteUserAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("remoteUserAccount", remoteUserAccount);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserAccountUpdatedPassed(connection, remoteUid, remoteUserAccount));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnSnapshotTaken()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONSNAPSHOTTAKEN_5a6a693;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint uid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("uid", uid);

            string filePath = ParamsHelper.CreateParam<string>();
            jsonObj.Add("filePath", filePath);

            int width = ParamsHelper.CreateParam<int>();
            jsonObj.Add("width", width);

            int height = ParamsHelper.CreateParam<int>();
            jsonObj.Add("height", height);

            int errCode = ParamsHelper.CreateParam<int>();
            jsonObj.Add("errCode", errCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnSnapshotTakenPassed(connection, uid, filePath, width, height, errCode));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnVideoRenderingTracingResult()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONVIDEORENDERINGTRACINGRESULT_813c0f4;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint uid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("uid", uid);

            MEDIA_TRACE_EVENT currentEvent = ParamsHelper.CreateParam<MEDIA_TRACE_EVENT>();
            jsonObj.Add("currentEvent", currentEvent);

            VideoRenderingTracingInfo tracingInfo = ParamsHelper.CreateParam<VideoRenderingTracingInfo>();
            jsonObj.Add("tracingInfo", tracingInfo);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnVideoRenderingTracingResultPassed(connection, uid, currentEvent, tracingInfo));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnSetRtmFlagResult()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONSETRTMFLAGRESULT_263e4cd;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            int code = ParamsHelper.CreateParam<int>();
            jsonObj.Add("code", code);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnSetRtmFlagResultPassed(connection, code));
        }

        [Test]
        public void Test_IRTCENGINEEVENTHANDLER_OnTranscodedStreamLayoutInfo()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONTRANSCODEDSTREAMLAYOUTINFO_48f6419;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint uid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("uid", uid);

            int width = ParamsHelper.CreateParam<int>();
            jsonObj.Add("width", width);

            int height = ParamsHelper.CreateParam<int>();
            jsonObj.Add("height", height);

            int layoutCount = ParamsHelper.CreateParam<int>();
            jsonObj.Add("layoutCount", layoutCount);

            VideoLayout[] layoutlist = ParamsHelper.CreateParam<VideoLayout[]>();
            jsonObj.Add("layoutlist", layoutlist);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnTranscodedStreamLayoutInfoPassed(connection, uid, width, height, layoutCount, layoutlist));
        }
        #endregion terra IRtcEngineEventHandler

    }
}
