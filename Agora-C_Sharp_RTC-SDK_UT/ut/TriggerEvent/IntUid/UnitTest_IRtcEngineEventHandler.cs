using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
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
        }

        [TearDown]
        public void TearDown()
        {
            Engine.Dispose();
            ApiParam.FreeResult();
        }

        #region terra IRtcEngineEventHandler
        [Test]
        public void Test_IRtcEngineEventHandler_OnProxyConnected()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONPROXYCONNECTED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONERROR;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONLASTMILEPROBERESULT;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIODEVICESTATECHANGED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIOMIXINGPOSITIONCHANGED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIOMIXINGFINISHED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIOEFFECTFINISHED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONVIDEODEVICESTATECHANGED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONUPLINKNETWORKINFOUPDATED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONDOWNLINKNETWORKINFOUPDATED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONLASTMILEQUALITY;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONFIRSTLOCALVIDEOFRAME;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONLOCALVIDEOSTATECHANGED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONCAMERAREADY;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONCAMERAFOCUSAREACHANGED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONCAMERAEXPOSUREAREACHANGED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONFACEPOSITIONCHANGED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONVIDEOSTOPPED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIOMIXINGSTATECHANGED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONRHYTHMPLAYERSTATECHANGED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONCONTENTINSPECTRESULT;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIODEVICEVOLUMECHANGED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONRTMPSTREAMINGSTATECHANGED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONRTMPSTREAMINGEVENT;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONTRANSCODINGUPDATED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIOROUTINGCHANGED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONCHANNELMEDIARELAYSTATECHANGED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONLOCALPUBLISHFALLBACKTOAUDIOONLY;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONREMOTESUBSCRIBEFALLBACKTOAUDIOONLY;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONPERMISSIONERROR;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONLOCALUSERREGISTERED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONUSERINFOUPDATED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONLOCALVIDEOTRANSCODERERROR;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIOSUBSCRIBESTATECHANGED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONVIDEOSUBSCRIBESTATECHANGED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONAUDIOPUBLISHSTATECHANGED;

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
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONVIDEOPUBLISHSTATECHANGED;

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
        public void Test_IRtcEngineEventHandler_OnExtensionEvent()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONEXTENSIONEVENT;

            jsonObj.Clear();

            string provider = ParamsHelper.CreateParam<string>();
            jsonObj.Add("provider", provider);

            string extension = ParamsHelper.CreateParam<string>();
            jsonObj.Add("extension", extension);

            string key = ParamsHelper.CreateParam<string>();
            jsonObj.Add("key", key);

            string value = ParamsHelper.CreateParam<string>();
            jsonObj.Add("value", value);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnExtensionEventPassed(provider, extension, key, value));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnExtensionStarted()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONEXTENSIONSTARTED;

            jsonObj.Clear();

            string provider = ParamsHelper.CreateParam<string>();
            jsonObj.Add("provider", provider);

            string extension = ParamsHelper.CreateParam<string>();
            jsonObj.Add("extension", extension);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnExtensionStartedPassed(provider, extension));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnExtensionStopped()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONEXTENSIONSTOPPED;

            jsonObj.Clear();

            string provider = ParamsHelper.CreateParam<string>();
            jsonObj.Add("provider", provider);

            string extension = ParamsHelper.CreateParam<string>();
            jsonObj.Add("extension", extension);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnExtensionStoppedPassed(provider, extension));
        }

        [Test]
        public void Test_IRtcEngineEventHandler_OnExtensionError()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLER_ONEXTENSIONERROR;

            jsonObj.Clear();

            string provider = ParamsHelper.CreateParam<string>();
            jsonObj.Add("provider", provider);

            string extension = ParamsHelper.CreateParam<string>();
            jsonObj.Add("extension", extension);

            int error = ParamsHelper.CreateParam<int>();
            jsonObj.Add("error", error);

            string message = ParamsHelper.CreateParam<string>();
            jsonObj.Add("message", message);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnExtensionErrorPassed(provider, extension, error, message));
        }

        [Test]
        public void Test_IRtcEngineEventHandlerEx_OnJoinChannelSuccess()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONJOINCHANNELSUCCESS;

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
        public void Test_IRtcEngineEventHandlerEx_OnRejoinChannelSuccess()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREJOINCHANNELSUCCESS;

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
        public void Test_IRtcEngineEventHandlerEx_OnAudioQuality()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONAUDIOQUALITY;

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
        public void Test_IRtcEngineEventHandlerEx_OnAudioVolumeIndication()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONAUDIOVOLUMEINDICATION;

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
        public void Test_IRtcEngineEventHandlerEx_OnLeaveChannel()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONLEAVECHANNEL;

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
        public void Test_IRtcEngineEventHandlerEx_OnRtcStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONRTCSTATS;

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
        public void Test_IRtcEngineEventHandlerEx_OnNetworkQuality()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONNETWORKQUALITY;

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
        public void Test_IRtcEngineEventHandlerEx_OnIntraRequestReceived()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONINTRAREQUESTRECEIVED;

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
        public void Test_IRtcEngineEventHandlerEx_OnFirstLocalVideoFramePublished()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTLOCALVIDEOFRAMEPUBLISHED;

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
        public void Test_IRtcEngineEventHandlerEx_OnFirstRemoteVideoDecoded()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTREMOTEVIDEODECODED;

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
        public void Test_IRtcEngineEventHandlerEx_OnVideoSizeChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONVIDEOSIZECHANGED;

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
        public void Test_IRtcEngineEventHandlerEx_OnLocalVideoStateChanged2()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONLOCALVIDEOSTATECHANGED;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            LOCAL_VIDEO_STREAM_STATE state = ParamsHelper.CreateParam<LOCAL_VIDEO_STREAM_STATE>();
            jsonObj.Add("state", state);

            LOCAL_VIDEO_STREAM_REASON reason = ParamsHelper.CreateParam<LOCAL_VIDEO_STREAM_REASON>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalVideoStateChanged2Passed(connection, state, reason));
        }

        [Test]
        public void Test_IRtcEngineEventHandlerEx_OnRemoteVideoStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEVIDEOSTATECHANGED;

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
        public void Test_IRtcEngineEventHandlerEx_OnFirstRemoteVideoFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTREMOTEVIDEOFRAME;

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
        public void Test_IRtcEngineEventHandlerEx_OnUserJoined()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSERJOINED;

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
        public void Test_IRtcEngineEventHandlerEx_OnUserOffline()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSEROFFLINE;

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
        public void Test_IRtcEngineEventHandlerEx_OnUserMuteAudio()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSERMUTEAUDIO;

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
        public void Test_IRtcEngineEventHandlerEx_OnUserMuteVideo()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSERMUTEVIDEO;

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
        public void Test_IRtcEngineEventHandlerEx_OnUserEnableVideo()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSERENABLEVIDEO;

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
        public void Test_IRtcEngineEventHandlerEx_OnUserEnableLocalVideo()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSERENABLELOCALVIDEO;

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
        public void Test_IRtcEngineEventHandlerEx_OnUserStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSERSTATECHANGED;

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
        public void Test_IRtcEngineEventHandlerEx_OnLocalAudioStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONLOCALAUDIOSTATS;

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
        public void Test_IRtcEngineEventHandlerEx_OnRemoteAudioStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEAUDIOSTATS;

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
        public void Test_IRtcEngineEventHandlerEx_OnLocalVideoStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONLOCALVIDEOSTATS;

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
        public void Test_IRtcEngineEventHandlerEx_OnRemoteVideoStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEVIDEOSTATS;

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
        public void Test_IRtcEngineEventHandlerEx_OnConnectionLost()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONCONNECTIONLOST;

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
        public void Test_IRtcEngineEventHandlerEx_OnConnectionInterrupted()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONCONNECTIONINTERRUPTED;

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
        public void Test_IRtcEngineEventHandlerEx_OnConnectionBanned()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONCONNECTIONBANNED;

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
        public void Test_IRtcEngineEventHandlerEx_OnStreamMessage()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONSTREAMMESSAGE;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            int streamId = ParamsHelper.CreateParam<int>();
            jsonObj.Add("streamId", streamId);

            byte[] data = ParamsHelper.CreateParam<byte[]>();
            jsonObj.Add("data", data);

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

        [Test]
        public void Test_IRtcEngineEventHandlerEx_OnStreamMessageError()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONSTREAMMESSAGEERROR;

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
        public void Test_IRtcEngineEventHandlerEx_OnRequestToken()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREQUESTTOKEN;

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
        public void Test_IRtcEngineEventHandlerEx_OnLicenseValidationFailure()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONLICENSEVALIDATIONFAILURE;

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
        public void Test_IRtcEngineEventHandlerEx_OnTokenPrivilegeWillExpire()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONTOKENPRIVILEGEWILLEXPIRE;

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
        public void Test_IRtcEngineEventHandlerEx_OnFirstLocalAudioFramePublished()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTLOCALAUDIOFRAMEPUBLISHED;

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
        public void Test_IRtcEngineEventHandlerEx_OnFirstRemoteAudioFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTREMOTEAUDIOFRAME;

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
        public void Test_IRtcEngineEventHandlerEx_OnFirstRemoteAudioDecoded()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONFIRSTREMOTEAUDIODECODED;

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
        public void Test_IRtcEngineEventHandlerEx_OnLocalAudioStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONLOCALAUDIOSTATECHANGED;

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
        public void Test_IRtcEngineEventHandlerEx_OnRemoteAudioStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEAUDIOSTATECHANGED;

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
        public void Test_IRtcEngineEventHandlerEx_OnActiveSpeaker()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONACTIVESPEAKER;

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
        public void Test_IRtcEngineEventHandlerEx_OnClientRoleChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONCLIENTROLECHANGED;

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
        public void Test_IRtcEngineEventHandlerEx_OnClientRoleChangeFailed()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONCLIENTROLECHANGEFAILED;

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
        public void Test_IRtcEngineEventHandlerEx_OnRemoteAudioTransportStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEAUDIOTRANSPORTSTATS;

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
        public void Test_IRtcEngineEventHandlerEx_OnRemoteVideoTransportStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONREMOTEVIDEOTRANSPORTSTATS;

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
        public void Test_IRtcEngineEventHandlerEx_OnConnectionStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONCONNECTIONSTATECHANGED;

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
        public void Test_IRtcEngineEventHandlerEx_OnWlAccMessage()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONWLACCMESSAGE;

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
        public void Test_IRtcEngineEventHandlerEx_OnWlAccStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONWLACCSTATS;

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
        public void Test_IRtcEngineEventHandlerEx_OnNetworkTypeChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONNETWORKTYPECHANGED;

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
        public void Test_IRtcEngineEventHandlerEx_OnEncryptionError()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONENCRYPTIONERROR;

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
        public void Test_IRtcEngineEventHandlerEx_OnUploadLogResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUPLOADLOGRESULT;

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
        public void Test_IRtcEngineEventHandlerEx_OnUserAccountUpdated()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONUSERACCOUNTUPDATED;

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
        public void Test_IRtcEngineEventHandlerEx_OnSnapshotTaken()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONSNAPSHOTTAKEN;

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
        public void Test_IRtcEngineEventHandlerEx_OnVideoRenderingTracingResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONVIDEORENDERINGTRACINGRESULT;

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
        public void Test_IRtcEngineEventHandlerEx_OnSetRtmFlagResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONSETRTMFLAGRESULT;

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
        public void Test_IRtcEngineEventHandlerEx_OnTranscodedStreamLayoutInfo()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONTRANSCODEDSTREAMLAYOUTINFO;

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

        [Test]
        public void Test_IRtcEngineEventHandlerEx_OnAudioMetadataReceived()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREX_ONAUDIOMETADATARECEIVED;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint uid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("uid", uid);

            string metadata = ParamsHelper.CreateParam<string>();
            jsonObj.Add("metadata", metadata);

            ulong length = ParamsHelper.CreateParam<ulong>();
            jsonObj.Add("length", length);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioMetadataReceivedPassed(connection, uid, metadata, length));
        }
        #endregion terra IRtcEngineEventHandler

    }
}
