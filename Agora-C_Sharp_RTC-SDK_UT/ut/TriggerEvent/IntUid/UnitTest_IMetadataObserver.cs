using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Event
{
    [TestFixture]
    public class UnitTest_IMetadataObserver
    {

        public IRtcEngineEx Engine;
        public IMediaRecorder MediaRecorder;
        public UTMetadataObserver EventHandler;
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

            EventHandler = new UTMetadataObserver();
            int ret = Engine.RegisterMediaMetadataObserver(EventHandler, METADATA_TYPE.VIDEO_METADATA);
            Assert.AreEqual(0, ret);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = Engine.UnregisterMediaMetadataObserver();
            Assert.AreEqual(0, ret);
            Engine.Dispose();
            ApiParam.FreeResult();
        }

        #region terra IMetadataObserver

        [Test]
        public void Test_GetMaxMetadataSize()
        {
            ApiParam.@event = AgoraEventType.EVENT_METADATAOBSERVERBASE_GETMAXMETADATASIZE;

            jsonObj.Clear();

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.GetMaxMetadataSizePassed());
        }
        [Test]
        public void Test_OnReadyToSendMetadata()
        {
            ApiParam.@event = AgoraEventType.EVENT_METADATAOBSERVER_ONREADYTOSENDMETADATA;

            jsonObj.Clear();

            Metadata metadata = ParamsHelper.CreateParam<Metadata>();
            jsonObj.Add("metadata", metadata);

            VIDEO_SOURCE_TYPE source_type = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            jsonObj.Add("source_type", source_type);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnReadyToSendMetadataPassed(ref metadata, source_type));
        }

        [Test]
        public void Test_OnMetadataReceived()
        {
            ApiParam.@event = AgoraEventType.EVENT_METADATAOBSERVER_ONMETADATARECEIVED;

            jsonObj.Clear();

            Metadata metadata = ParamsHelper.CreateParam<Metadata>();
            jsonObj.Add("metadata", metadata);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnMetadataReceivedPassed(metadata));
        }
        #endregion terra IMetadataObserver
    }
}
