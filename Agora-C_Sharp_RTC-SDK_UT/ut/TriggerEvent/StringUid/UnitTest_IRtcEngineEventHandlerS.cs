using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Event
{
    [TestFixture]
    public class UnitTest_IRtcEngineEventHandlerS
    {

        public IRtcEngineExS Engine;
        public UTRtcEngineEventHandlerS EventHandler;
        public IntPtr FakeRtcEnginePtr;
        public IrisCApiParam2 ApiParam;
        public Dictionary<string, System.Object> jsonObj = new Dictionary<string, object>();

        [SetUp]
        public void Setup()
        {
            FakeRtcEnginePtr = DLLHelper.CreateFakeRtcEngineS();
            Engine = RtcEngineS.CreateAgoraRtcEngineEx(FakeRtcEnginePtr);
            RtcEngineContextS rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            ApiParam.AllocResult();

            EventHandler = new UTRtcEngineEventHandlerS();
            Engine.InitEventHandler(EventHandler);
        }

        [TearDown]
        public void TearDown()
        {
            Engine.Dispose();
            ApiParam.FreeResult();
        }

        #region terra IRtcEngineEventHandlerS

        [Test]
        public void Test_OnError()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONERROR;

            jsonObj.Clear();

            int err = ParamsHelper.CreateParam<int>();
            jsonObj.Add("err", err);

            string msg = ParamsHelper.CreateParam<string>();
            jsonObj.Add("msg", msg);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnErrorPassed(err, msg));
        }

        [Test]
        public void Test_OnLastmileProbeResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONLASTMILEPROBERESULT;

            jsonObj.Clear();

            LastmileProbeResult result = ParamsHelper.CreateParam<LastmileProbeResult>();
            jsonObj.Add("result", result);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLastmileProbeResultPassed(result));
        }

        [Test]
        public void Test_OnAudioDeviceStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONAUDIODEVICESTATECHANGED;

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

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioDeviceStateChangedPassed(deviceId, deviceType, deviceState));
        }

        [Test]
        public void Test_OnAudioMixingPositionChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONAUDIOMIXINGPOSITIONCHANGED;

            jsonObj.Clear();

            long position = ParamsHelper.CreateParam<long>();
            jsonObj.Add("position", position);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioMixingPositionChangedPassed(position));
        }

        [Test]
        public void Test_OnAudioEffectFinished()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONAUDIOEFFECTFINISHED;

            jsonObj.Clear();

            int soundId = ParamsHelper.CreateParam<int>();
            jsonObj.Add("soundId", soundId);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioEffectFinishedPassed(soundId));
        }

        [Test]
        public void Test_OnVideoDeviceStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONVIDEODEVICESTATECHANGED;

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

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnVideoDeviceStateChangedPassed(deviceId, deviceType, deviceState));
        }

        [Test]
        public void Test_OnUplinkNetworkInfoUpdated()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONUPLINKNETWORKINFOUPDATED;

            jsonObj.Clear();

            UplinkNetworkInfo info = ParamsHelper.CreateParam<UplinkNetworkInfo>();
            jsonObj.Add("info", info);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUplinkNetworkInfoUpdatedPassed(info));
        }

        [Test]
        public void Test_OnDownlinkNetworkInfoUpdated()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONDOWNLINKNETWORKINFOUPDATED;

            jsonObj.Clear();

            DownlinkNetworkInfo info = ParamsHelper.CreateParam<DownlinkNetworkInfo>();
            jsonObj.Add("info", info);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnDownlinkNetworkInfoUpdatedPassed(info));
        }

        [Test]
        public void Test_OnLastmileQuality()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONLASTMILEQUALITY;

            jsonObj.Clear();

            int quality = ParamsHelper.CreateParam<int>();
            jsonObj.Add("quality", quality);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLastmileQualityPassed(quality));
        }

        [Test]
        public void Test_OnFirstLocalVideoFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONFIRSTLOCALVIDEOFRAME;

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

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFirstLocalVideoFramePassed(source, width, height, elapsed));
        }

        [Test]
        public void Test_OnLocalVideoStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONLOCALVIDEOSTATECHANGED;

            jsonObj.Clear();

            VIDEO_SOURCE_TYPE source = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            jsonObj.Add("source", source);

            LOCAL_VIDEO_STREAM_STATE state = ParamsHelper.CreateParam<LOCAL_VIDEO_STREAM_STATE>();
            jsonObj.Add("state", state);

            LOCAL_VIDEO_STREAM_ERROR error = ParamsHelper.CreateParam<LOCAL_VIDEO_STREAM_ERROR>();
            jsonObj.Add("error", error);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalVideoStateChangedPassed(source, state, error));
        }

        [Test]
        public void Test_OnCameraFocusAreaChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONCAMERAFOCUSAREACHANGED;

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

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnCameraFocusAreaChangedPassed(x, y, width, height));
        }

        [Test]
        public void Test_OnCameraExposureAreaChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONCAMERAEXPOSUREAREACHANGED;

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

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnCameraExposureAreaChangedPassed(x, y, width, height));
        }

        [Test]
        public void Test_OnFacePositionChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONFACEPOSITIONCHANGED;

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

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFacePositionChangedPassed(imageWidth, imageHeight, vecRectangle, vecDistance, numFaces));
        }

        [Test]
        public void Test_OnAudioMixingStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONAUDIOMIXINGSTATECHANGED;

            jsonObj.Clear();

            AUDIO_MIXING_STATE_TYPE state = ParamsHelper.CreateParam<AUDIO_MIXING_STATE_TYPE>();
            jsonObj.Add("state", state);

            AUDIO_MIXING_REASON_TYPE reason = ParamsHelper.CreateParam<AUDIO_MIXING_REASON_TYPE>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioMixingStateChangedPassed(state, reason));
        }

        [Test]
        public void Test_OnRhythmPlayerStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONRHYTHMPLAYERSTATECHANGED;

            jsonObj.Clear();

            RHYTHM_PLAYER_STATE_TYPE state = ParamsHelper.CreateParam<RHYTHM_PLAYER_STATE_TYPE>();
            jsonObj.Add("state", state);

            RHYTHM_PLAYER_ERROR_TYPE errorCode = ParamsHelper.CreateParam<RHYTHM_PLAYER_ERROR_TYPE>();
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRhythmPlayerStateChangedPassed(state, errorCode));
        }

        [Test]
        public void Test_OnContentInspectResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONCONTENTINSPECTRESULT;

            jsonObj.Clear();

            CONTENT_INSPECT_RESULT result = ParamsHelper.CreateParam<CONTENT_INSPECT_RESULT>();
            jsonObj.Add("result", result);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnContentInspectResultPassed(result));
        }

        [Test]
        public void Test_OnAudioDeviceVolumeChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONAUDIODEVICEVOLUMECHANGED;

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

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioDeviceVolumeChangedPassed(deviceType, volume, muted));
        }

        [Test]
        public void Test_OnRtmpStreamingStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONRTMPSTREAMINGSTATECHANGED;

            jsonObj.Clear();

            string url = ParamsHelper.CreateParam<string>();
            jsonObj.Add("url", url);

            RTMP_STREAM_PUBLISH_STATE state = ParamsHelper.CreateParam<RTMP_STREAM_PUBLISH_STATE>();
            jsonObj.Add("state", state);

            RTMP_STREAM_PUBLISH_ERROR_TYPE errCode = ParamsHelper.CreateParam<RTMP_STREAM_PUBLISH_ERROR_TYPE>();
            jsonObj.Add("errCode", errCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRtmpStreamingStateChangedPassed(url, state, errCode));
        }

        [Test]
        public void Test_OnRtmpStreamingEvent()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONRTMPSTREAMINGEVENT;

            jsonObj.Clear();

            string url = ParamsHelper.CreateParam<string>();
            jsonObj.Add("url", url);

            RTMP_STREAMING_EVENT eventCode = ParamsHelper.CreateParam<RTMP_STREAMING_EVENT>();
            jsonObj.Add("eventCode", eventCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRtmpStreamingEventPassed(url, eventCode));
        }

        [Test]
        public void Test_OnTranscodingUpdated()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONTRANSCODINGUPDATED;

            jsonObj.Clear();

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnTranscodingUpdatedPassed());
        }

        [Test]
        public void Test_OnAudioRoutingChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONAUDIOROUTINGCHANGED;

            jsonObj.Clear();

            int routing = ParamsHelper.CreateParam<int>();
            jsonObj.Add("routing", routing);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioRoutingChangedPassed(routing));
        }

        [Test]
        public void Test_OnChannelMediaRelayStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONCHANNELMEDIARELAYSTATECHANGED;

            jsonObj.Clear();

            int state = ParamsHelper.CreateParam<int>();
            jsonObj.Add("state", state);

            int code = ParamsHelper.CreateParam<int>();
            jsonObj.Add("code", code);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnChannelMediaRelayStateChangedPassed(state, code));
        }

        [Test]
        public void Test_OnLocalPublishFallbackToAudioOnly()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONLOCALPUBLISHFALLBACKTOAUDIOONLY;

            jsonObj.Clear();

            bool isFallbackOrRecover = ParamsHelper.CreateParam<bool>();
            jsonObj.Add("isFallbackOrRecover", isFallbackOrRecover);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalPublishFallbackToAudioOnlyPassed(isFallbackOrRecover));
        }

        [Test]
        public void Test_OnPermissionError()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONPERMISSIONERROR;

            jsonObj.Clear();

            PERMISSION_TYPE permissionType = ParamsHelper.CreateParam<PERMISSION_TYPE>();
            jsonObj.Add("permissionType", permissionType);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnPermissionErrorPassed(permissionType));
        }

        [Test]
        public void Test_OnAudioPublishStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONAUDIOPUBLISHSTATECHANGED;

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

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioPublishStateChangedPassed(channel, oldState, newState, elapseSinceLastState));
        }

        [Test]
        public void Test_OnVideoPublishStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONVIDEOPUBLISHSTATECHANGED;

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

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnVideoPublishStateChangedPassed(source, channel, oldState, newState, elapseSinceLastState));
        }

        [Test]
        public void Test_OnExtensionEvent()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONEXTENSIONEVENT;

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

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnExtensionEventPassed(provider, extension, key, value));
        }

        [Test]
        public void Test_OnExtensionStarted()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONEXTENSIONSTARTED;

            jsonObj.Clear();

            string provider = ParamsHelper.CreateParam<string>();
            jsonObj.Add("provider", provider);

            string extension = ParamsHelper.CreateParam<string>();
            jsonObj.Add("extension", extension);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnExtensionStartedPassed(provider, extension));
        }

        [Test]
        public void Test_OnExtensionStopped()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONEXTENSIONSTOPPED;

            jsonObj.Clear();

            string provider = ParamsHelper.CreateParam<string>();
            jsonObj.Add("provider", provider);

            string extension = ParamsHelper.CreateParam<string>();
            jsonObj.Add("extension", extension);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnExtensionStoppedPassed(provider, extension));
        }

        [Test]
        public void Test_OnExtensionError()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERBASE_ONEXTENSIONERROR;

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

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnExtensionErrorPassed(provider, extension, error, message));
        }

        [Test]
        public void Test_OnProxyConnected()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERS_ONPROXYCONNECTED;

            jsonObj.Clear();

            string channel = ParamsHelper.CreateParam<string>();
            jsonObj.Add("channel", channel);

            string userAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("userAccount", userAccount);

            PROXY_TYPE proxyType = ParamsHelper.CreateParam<PROXY_TYPE>();
            jsonObj.Add("proxyType", proxyType);

            string localProxyIp = ParamsHelper.CreateParam<string>();
            jsonObj.Add("localProxyIp", localProxyIp);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnProxyConnectedPassed(channel, userAccount, proxyType, localProxyIp, elapsed));
        }

        [Test]
        public void Test_OnRemoteSubscribeFallbackToAudioOnly()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERS_ONREMOTESUBSCRIBEFALLBACKTOAUDIOONLY;

            jsonObj.Clear();

            string userAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("userAccount", userAccount);

            bool isFallbackOrRecover = ParamsHelper.CreateParam<bool>();
            jsonObj.Add("isFallbackOrRecover", isFallbackOrRecover);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoteSubscribeFallbackToAudioOnlyPassed(userAccount, isFallbackOrRecover));
        }

        [Test]
        public void Test_OnAudioSubscribeStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERS_ONAUDIOSUBSCRIBESTATECHANGED;

            jsonObj.Clear();

            string channel = ParamsHelper.CreateParam<string>();
            jsonObj.Add("channel", channel);

            string userAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("userAccount", userAccount);

            STREAM_SUBSCRIBE_STATE oldState = ParamsHelper.CreateParam<STREAM_SUBSCRIBE_STATE>();
            jsonObj.Add("oldState", oldState);

            STREAM_SUBSCRIBE_STATE newState = ParamsHelper.CreateParam<STREAM_SUBSCRIBE_STATE>();
            jsonObj.Add("newState", newState);

            int elapseSinceLastState = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapseSinceLastState", elapseSinceLastState);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioSubscribeStateChangedPassed(channel, userAccount, oldState, newState, elapseSinceLastState));
        }

        [Test]
        public void Test_OnVideoSubscribeStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERS_ONVIDEOSUBSCRIBESTATECHANGED;

            jsonObj.Clear();

            string channel = ParamsHelper.CreateParam<string>();
            jsonObj.Add("channel", channel);

            string userAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("userAccount", userAccount);

            STREAM_SUBSCRIBE_STATE oldState = ParamsHelper.CreateParam<STREAM_SUBSCRIBE_STATE>();
            jsonObj.Add("oldState", oldState);

            STREAM_SUBSCRIBE_STATE newState = ParamsHelper.CreateParam<STREAM_SUBSCRIBE_STATE>();
            jsonObj.Add("newState", newState);

            int elapseSinceLastState = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapseSinceLastState", elapseSinceLastState);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnVideoSubscribeStateChangedPassed(channel, userAccount, oldState, newState, elapseSinceLastState));
        }

        [Test]
        public void Test_OnLocalVideoTranscoderError()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLERS_ONLOCALVIDEOTRANSCODERERROR;

            jsonObj.Clear();

            TranscodingVideoStreamS streamS = ParamsHelper.CreateParam<TranscodingVideoStreamS>();
            jsonObj.Add("streamS", streamS);

            VIDEO_TRANSCODER_ERROR error = ParamsHelper.CreateParam<VIDEO_TRANSCODER_ERROR>();
            jsonObj.Add("error", error);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalVideoTranscoderErrorPassed(streamS, error));
        }

        [Test]
        public void Test_OnJoinChannelSuccess()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONJOINCHANNELSUCCESS;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnJoinChannelSuccessPassed(connectionS, elapsed));
        }

        [Test]
        public void Test_OnRejoinChannelSuccess()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONREJOINCHANNELSUCCESS;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRejoinChannelSuccessPassed(connectionS, elapsed));
        }

        [Test]
        public void Test_OnAudioVolumeIndication()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONAUDIOVOLUMEINDICATION;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            AudioVolumeInfoS[] speakersS = ParamsHelper.CreateParam<AudioVolumeInfoS[]>();
            jsonObj.Add("speakersS", speakersS);

            uint speakerNumber = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("speakerNumber", speakerNumber);

            int totalVolume = ParamsHelper.CreateParam<int>();
            jsonObj.Add("totalVolume", totalVolume);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnAudioVolumeIndicationPassed(connectionS, speakersS, speakerNumber, totalVolume));
        }

        [Test]
        public void Test_OnLeaveChannel()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONLEAVECHANNEL;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            RtcStats stats = ParamsHelper.CreateParam<RtcStats>();
            jsonObj.Add("stats", stats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLeaveChannelPassed(connectionS, stats));
        }

        [Test]
        public void Test_OnRtcStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONRTCSTATS;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            RtcStats stats = ParamsHelper.CreateParam<RtcStats>();
            jsonObj.Add("stats", stats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRtcStatsPassed(connectionS, stats));
        }

        [Test]
        public void Test_OnNetworkQuality()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONNETWORKQUALITY;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            string remoteUserAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("remoteUserAccount", remoteUserAccount);

            int txQuality = ParamsHelper.CreateParam<int>();
            jsonObj.Add("txQuality", txQuality);

            int rxQuality = ParamsHelper.CreateParam<int>();
            jsonObj.Add("rxQuality", rxQuality);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnNetworkQualityPassed(connectionS, remoteUserAccount, txQuality, rxQuality));
        }

        [Test]
        public void Test_OnIntraRequestReceived()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONINTRAREQUESTRECEIVED;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnIntraRequestReceivedPassed(connectionS));
        }

        [Test]
        public void Test_OnFirstLocalVideoFramePublished()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONFIRSTLOCALVIDEOFRAMEPUBLISHED;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFirstLocalVideoFramePublishedPassed(connectionS, elapsed));
        }

        [Test]
        public void Test_OnFirstRemoteVideoDecoded()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONFIRSTREMOTEVIDEODECODED;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            string remoteUserAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("remoteUserAccount", remoteUserAccount);

            int width = ParamsHelper.CreateParam<int>();
            jsonObj.Add("width", width);

            int height = ParamsHelper.CreateParam<int>();
            jsonObj.Add("height", height);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFirstRemoteVideoDecodedPassed(connectionS, remoteUserAccount, width, height, elapsed));
        }

        [Test]
        public void Test_OnVideoSizeChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONVIDEOSIZECHANGED;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            jsonObj.Add("sourceType", sourceType);

            string userAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("userAccount", userAccount);

            int width = ParamsHelper.CreateParam<int>();
            jsonObj.Add("width", width);

            int height = ParamsHelper.CreateParam<int>();
            jsonObj.Add("height", height);

            int rotation = ParamsHelper.CreateParam<int>();
            jsonObj.Add("rotation", rotation);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnVideoSizeChangedPassed(connectionS, sourceType, userAccount, width, height, rotation));
        }

        [Test]
        public void Test_OnLocalVideoStateChanged2()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONLOCALVIDEOSTATECHANGED;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            LOCAL_VIDEO_STREAM_STATE state = ParamsHelper.CreateParam<LOCAL_VIDEO_STREAM_STATE>();
            jsonObj.Add("state", state);

            LOCAL_VIDEO_STREAM_ERROR errorCode = ParamsHelper.CreateParam<LOCAL_VIDEO_STREAM_ERROR>();
            jsonObj.Add("errorCode", errorCode);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalVideoStateChanged2Passed(connectionS, state, errorCode));
        }

        [Test]
        public void Test_OnRemoteVideoStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONREMOTEVIDEOSTATECHANGED;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            string userAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("userAccount", userAccount);

            REMOTE_VIDEO_STATE state = ParamsHelper.CreateParam<REMOTE_VIDEO_STATE>();
            jsonObj.Add("state", state);

            REMOTE_VIDEO_STATE_REASON reason = ParamsHelper.CreateParam<REMOTE_VIDEO_STATE_REASON>();
            jsonObj.Add("reason", reason);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoteVideoStateChangedPassed(connectionS, userAccount, state, reason, elapsed));
        }

        [Test]
        public void Test_OnFirstRemoteVideoFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONFIRSTREMOTEVIDEOFRAME;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            string userAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("userAccount", userAccount);

            int width = ParamsHelper.CreateParam<int>();
            jsonObj.Add("width", width);

            int height = ParamsHelper.CreateParam<int>();
            jsonObj.Add("height", height);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFirstRemoteVideoFramePassed(connectionS, userAccount, width, height, elapsed));
        }

        [Test]
        public void Test_OnUserJoined()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONUSERJOINED;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            string userAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("userAccount", userAccount);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserJoinedPassed(connectionS, userAccount, elapsed));
        }

        [Test]
        public void Test_OnUserOffline()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONUSEROFFLINE;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            string userAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("userAccount", userAccount);

            USER_OFFLINE_REASON_TYPE reason = ParamsHelper.CreateParam<USER_OFFLINE_REASON_TYPE>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserOfflinePassed(connectionS, userAccount, reason));
        }

        [Test]
        public void Test_OnUserMuteAudio()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONUSERMUTEAUDIO;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            string remoteUserAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("remoteUserAccount", remoteUserAccount);

            bool muted = ParamsHelper.CreateParam<bool>();
            jsonObj.Add("muted", muted);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserMuteAudioPassed(connectionS, remoteUserAccount, muted));
        }

        [Test]
        public void Test_OnUserMuteVideo()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONUSERMUTEVIDEO;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            string remoteUserAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("remoteUserAccount", remoteUserAccount);

            bool muted = ParamsHelper.CreateParam<bool>();
            jsonObj.Add("muted", muted);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserMuteVideoPassed(connectionS, remoteUserAccount, muted));
        }

        [Test]
        public void Test_OnUserEnableVideo()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONUSERENABLEVIDEO;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            string remoteUserAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("remoteUserAccount", remoteUserAccount);

            bool enabled = ParamsHelper.CreateParam<bool>();
            jsonObj.Add("enabled", enabled);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserEnableVideoPassed(connectionS, remoteUserAccount, enabled));
        }

        [Test]
        public void Test_OnUserStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONUSERSTATECHANGED;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            string remoteUserAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("remoteUserAccount", remoteUserAccount);

            uint state = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("state", state);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUserStateChangedPassed(connectionS, remoteUserAccount, state));
        }

        [Test]
        public void Test_OnLocalAudioStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONLOCALAUDIOSTATS;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            LocalAudioStats stats = ParamsHelper.CreateParam<LocalAudioStats>();
            jsonObj.Add("stats", stats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalAudioStatsPassed(connectionS, stats));
        }

        [Test]
        public void Test_OnRemoteAudioStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONREMOTEAUDIOSTATS;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            RemoteAudioStatsS statsS = ParamsHelper.CreateParam<RemoteAudioStatsS>();
            jsonObj.Add("statsS", statsS);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoteAudioStatsPassed(connectionS, statsS));
        }

        [Test]
        public void Test_OnLocalVideoStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONLOCALVIDEOSTATS;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            LocalVideoStatsS statsS = ParamsHelper.CreateParam<LocalVideoStatsS>();
            jsonObj.Add("statsS", statsS);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalVideoStatsPassed(connectionS, statsS));
        }

        [Test]
        public void Test_OnRemoteVideoStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONREMOTEVIDEOSTATS;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            RemoteVideoStatsS statsS = ParamsHelper.CreateParam<RemoteVideoStatsS>();
            jsonObj.Add("statsS", statsS);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoteVideoStatsPassed(connectionS, statsS));
        }

        [Test]
        public void Test_OnConnectionLost()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONCONNECTIONLOST;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnConnectionLostPassed(connectionS));
        }

        [Test]
        public void Test_OnConnectionBanned()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONCONNECTIONBANNED;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnConnectionBannedPassed(connectionS));
        }

        [Test]
        public void Test_OnStreamMessage()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONSTREAMMESSAGE;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            string remoteUserAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("remoteUserAccount", remoteUserAccount);

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

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnStreamMessagePassed(connectionS, remoteUserAccount, streamId, data, length, sentTs));
        }

        [Test]
        public void Test_OnStreamMessageError()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONSTREAMMESSAGEERROR;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            string remoteUserAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("remoteUserAccount", remoteUserAccount);

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

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnStreamMessageErrorPassed(connectionS, remoteUserAccount, streamId, code, missed, cached));
        }

        [Test]
        public void Test_OnRequestToken()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONREQUESTTOKEN;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRequestTokenPassed(connectionS));
        }

        [Test]
        public void Test_OnLicenseValidationFailure()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONLICENSEVALIDATIONFAILURE;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            LICENSE_ERROR_TYPE reason = ParamsHelper.CreateParam<LICENSE_ERROR_TYPE>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLicenseValidationFailurePassed(connectionS, reason));
        }

        [Test]
        public void Test_OnTokenPrivilegeWillExpire()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONTOKENPRIVILEGEWILLEXPIRE;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            string token = ParamsHelper.CreateParam<string>();
            jsonObj.Add("token", token);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnTokenPrivilegeWillExpirePassed(connectionS, token));
        }

        [Test]
        public void Test_OnFirstLocalAudioFramePublished()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONFIRSTLOCALAUDIOFRAMEPUBLISHED;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFirstLocalAudioFramePublishedPassed(connectionS, elapsed));
        }

        [Test]
        public void Test_OnLocalAudioStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONLOCALAUDIOSTATECHANGED;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            LOCAL_AUDIO_STREAM_STATE state = ParamsHelper.CreateParam<LOCAL_AUDIO_STREAM_STATE>();
            jsonObj.Add("state", state);

            LOCAL_AUDIO_STREAM_ERROR error = ParamsHelper.CreateParam<LOCAL_AUDIO_STREAM_ERROR>();
            jsonObj.Add("error", error);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnLocalAudioStateChangedPassed(connectionS, state, error));
        }

        [Test]
        public void Test_OnRemoteAudioStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONREMOTEAUDIOSTATECHANGED;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            string remoteUserAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("remoteUserAccount", remoteUserAccount);

            REMOTE_AUDIO_STATE state = ParamsHelper.CreateParam<REMOTE_AUDIO_STATE>();
            jsonObj.Add("state", state);

            REMOTE_AUDIO_STATE_REASON reason = ParamsHelper.CreateParam<REMOTE_AUDIO_STATE_REASON>();
            jsonObj.Add("reason", reason);

            int elapsed = ParamsHelper.CreateParam<int>();
            jsonObj.Add("elapsed", elapsed);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnRemoteAudioStateChangedPassed(connectionS, remoteUserAccount, state, reason, elapsed));
        }

        [Test]
        public void Test_OnActiveSpeaker()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONACTIVESPEAKER;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            string userAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("userAccount", userAccount);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnActiveSpeakerPassed(connectionS, userAccount));
        }

        [Test]
        public void Test_OnClientRoleChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONCLIENTROLECHANGED;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            CLIENT_ROLE_TYPE oldRole = ParamsHelper.CreateParam<CLIENT_ROLE_TYPE>();
            jsonObj.Add("oldRole", oldRole);

            CLIENT_ROLE_TYPE newRole = ParamsHelper.CreateParam<CLIENT_ROLE_TYPE>();
            jsonObj.Add("newRole", newRole);

            ClientRoleOptions newRoleOptions = ParamsHelper.CreateParam<ClientRoleOptions>();
            jsonObj.Add("newRoleOptions", newRoleOptions);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnClientRoleChangedPassed(connectionS, oldRole, newRole, newRoleOptions));
        }

        [Test]
        public void Test_OnClientRoleChangeFailed()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONCLIENTROLECHANGEFAILED;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            CLIENT_ROLE_CHANGE_FAILED_REASON reason = ParamsHelper.CreateParam<CLIENT_ROLE_CHANGE_FAILED_REASON>();
            jsonObj.Add("reason", reason);

            CLIENT_ROLE_TYPE currentRole = ParamsHelper.CreateParam<CLIENT_ROLE_TYPE>();
            jsonObj.Add("currentRole", currentRole);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnClientRoleChangeFailedPassed(connectionS, reason, currentRole));
        }

        [Test]
        public void Test_OnConnectionStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONCONNECTIONSTATECHANGED;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            CONNECTION_STATE_TYPE state = ParamsHelper.CreateParam<CONNECTION_STATE_TYPE>();
            jsonObj.Add("state", state);

            CONNECTION_CHANGED_REASON_TYPE reason = ParamsHelper.CreateParam<CONNECTION_CHANGED_REASON_TYPE>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnConnectionStateChangedPassed(connectionS, state, reason));
        }

        [Test]
        public void Test_OnWlAccMessage()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONWLACCMESSAGE;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            WLACC_MESSAGE_REASON reason = ParamsHelper.CreateParam<WLACC_MESSAGE_REASON>();
            jsonObj.Add("reason", reason);

            WLACC_SUGGEST_ACTION action = ParamsHelper.CreateParam<WLACC_SUGGEST_ACTION>();
            jsonObj.Add("action", action);

            string wlAccMsg = ParamsHelper.CreateParam<string>();
            jsonObj.Add("wlAccMsg", wlAccMsg);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnWlAccMessagePassed(connectionS, reason, action, wlAccMsg));
        }

        [Test]
        public void Test_OnWlAccStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONWLACCSTATS;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            WlAccStats currentStats = ParamsHelper.CreateParam<WlAccStats>();
            jsonObj.Add("currentStats", currentStats);

            WlAccStats averageStats = ParamsHelper.CreateParam<WlAccStats>();
            jsonObj.Add("averageStats", averageStats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnWlAccStatsPassed(connectionS, currentStats, averageStats));
        }

        [Test]
        public void Test_OnNetworkTypeChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONNETWORKTYPECHANGED;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            NETWORK_TYPE type = ParamsHelper.CreateParam<NETWORK_TYPE>();
            jsonObj.Add("type", type);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnNetworkTypeChangedPassed(connectionS, type));
        }

        [Test]
        public void Test_OnEncryptionError()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONENCRYPTIONERROR;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            ENCRYPTION_ERROR_TYPE errorType = ParamsHelper.CreateParam<ENCRYPTION_ERROR_TYPE>();
            jsonObj.Add("errorType", errorType);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnEncryptionErrorPassed(connectionS, errorType));
        }

        [Test]
        public void Test_OnUploadLogResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONUPLOADLOGRESULT;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            string requestId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("requestId", requestId);

            bool success = ParamsHelper.CreateParam<bool>();
            jsonObj.Add("success", success);

            UPLOAD_ERROR_REASON reason = ParamsHelper.CreateParam<UPLOAD_ERROR_REASON>();
            jsonObj.Add("reason", reason);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnUploadLogResultPassed(connectionS, requestId, success, reason));
        }

        [Test]
        public void Test_OnSnapshotTaken()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONSNAPSHOTTAKEN;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            string userAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("userAccount", userAccount);

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

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnSnapshotTakenPassed(connectionS, userAccount, filePath, width, height, errCode));
        }

        [Test]
        public void Test_OnVideoRenderingTracingResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONVIDEORENDERINGTRACINGRESULT;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            string userAccount = ParamsHelper.CreateParam<string>();
            jsonObj.Add("userAccount", userAccount);

            MEDIA_TRACE_EVENT currentEvent = ParamsHelper.CreateParam<MEDIA_TRACE_EVENT>();
            jsonObj.Add("currentEvent", currentEvent);

            VideoRenderingTracingInfo tracingInfo = ParamsHelper.CreateParam<VideoRenderingTracingInfo>();
            jsonObj.Add("tracingInfo", tracingInfo);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnVideoRenderingTracingResultPassed(connectionS, userAccount, currentEvent, tracingInfo));
        }

        [Test]
        public void Test_OnSetRtmFlagResult()
        {
            ApiParam.@event = AgoraEventType.EVENT_RTCENGINEEVENTHANDLEREXS_ONSETRTMFLAGRESULT;

            jsonObj.Clear();

            RtcConnectionS connectionS = ParamsHelper.CreateParam<RtcConnectionS>();
            jsonObj.Add("connectionS", connectionS);

            int code = ParamsHelper.CreateParam<int>();
            jsonObj.Add("code", code);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnSetRtmFlagResultPassed(connectionS, code));
        }
        #endregion terra IRtcEngineEventHandlerS

        #region terra IDirectCdnStreamingEventHandler

        [Test]
        public void Test_OnDirectCdnStreamingStateChanged()
        {
            ApiParam.@event = AgoraEventType.EVENT_DIRECTCDNSTREAMINGEVENTHANDLER_ONDIRECTCDNSTREAMINGSTATECHANGED;

            jsonObj.Clear();

            DIRECT_CDN_STREAMING_STATE state = ParamsHelper.CreateParam<DIRECT_CDN_STREAMING_STATE>();
            jsonObj.Add("state", state);

            DIRECT_CDN_STREAMING_ERROR error = ParamsHelper.CreateParam<DIRECT_CDN_STREAMING_ERROR>();
            jsonObj.Add("error", error);

            string message = ParamsHelper.CreateParam<string>();
            jsonObj.Add("message", message);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnDirectCdnStreamingStateChangedPassed(state, error, message));
        }

        [Test]
        public void Test_OnDirectCdnStreamingStats()
        {
            ApiParam.@event = AgoraEventType.EVENT_DIRECTCDNSTREAMINGEVENTHANDLER_ONDIRECTCDNSTREAMINGSTATS;

            jsonObj.Clear();

            DirectCdnStreamingStats stats = ParamsHelper.CreateParam<DirectCdnStreamingStats>();
            jsonObj.Add("stats", stats);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnDirectCdnStreamingStatsPassed(stats));
        }
        #endregion terra IDirectCdnStreamingEventHandler

    }
}
