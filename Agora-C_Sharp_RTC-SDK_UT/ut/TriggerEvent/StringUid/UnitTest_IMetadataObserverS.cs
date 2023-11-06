using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Event
{
    [TestFixture]
    public class UnitTest_IMetadataObserverS
    {

        public IRtcEngineExS Engine;
        public IMediaRecorderS MediaRecorder;
        public UTMetadataObserverS EventHandler;
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

            EventHandler = new UTMetadataObserverS();
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

        #region terra IMetadataObserverS

        [Test]
        public void Test_GetMaxMetadataSize()
        {
            ApiParam.@event = AgoraEventType.EVENT_METADATAOBSERVERBASE_GETMAXMETADATASIZE;

            jsonObj.Clear();

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.GetMaxMetadataSizePassed());
        }
        [Test]
        public void Test_OnReadyToSendMetadata()
        {
            ApiParam.@event = AgoraEventType.EVENT_METADATAOBSERVERS_ONREADYTOSENDMETADATA;

            jsonObj.Clear();

            MetadataS metadataS = ParamsHelper.CreateParam<MetadataS>();
            jsonObj.Add("metadataS", metadataS);

            VIDEO_SOURCE_TYPE source_type = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            jsonObj.Add("source_type", source_type);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnReadyToSendMetadataPassed(ref metadataS, source_type));
        }

        [Test]
        public void Test_OnMetadataReceived()
        {
            ApiParam.@event = AgoraEventType.EVENT_METADATAOBSERVERS_ONMETADATARECEIVED;

            jsonObj.Clear();

            MetadataS metadataS = ParamsHelper.CreateParam<MetadataS>();
            jsonObj.Add("metadataS", metadataS);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngineS(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnMetadataReceivedPassed(metadataS));
        }
        #endregion terra IMetadataObserverS
    }
}
