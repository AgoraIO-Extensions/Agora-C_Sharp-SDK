using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Event
{
    [TestFixture]
    public class UnitTest_IH265TranscoderObserverS
    {

        public IRtcEngineExS Engine;
        public IH265TranscoderS H265Transcoder;
        public UTH265TranscoderObserver EventHandler;
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
            H265Transcoder = Engine.GetH265Transcoder();
            EventHandler = new UTH265TranscoderObserver();
            int ret = H265Transcoder.RegisterTranscoderObserver(EventHandler);
            Assert.AreEqual(0, ret);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = H265Transcoder.UnregisterTranscoderObserver();
            Assert.AreEqual(0, ret);
            Engine.Dispose();
            ApiParam.FreeResult();
        }

        #region terra IH265TranscoderObserver

        [Test]
        public void Test_OnEnableTranscode()
        {
            ApiParam.@event = AgoraEventType.EVENT_H265TRANSCODEROBSERVER_ONENABLETRANSCODE;

            jsonObj.Clear();

            H265_TRANSCODE_RESULT result = ParamsHelper.CreateParam<H265_TRANSCODE_RESULT>();
            jsonObj.Add("result", result);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnEnableTranscodePassed(result));
        }

        [Test]
        public void Test_OnQueryChannel()
        {
            ApiParam.@event = AgoraEventType.EVENT_H265TRANSCODEROBSERVER_ONQUERYCHANNEL;

            jsonObj.Clear();

            H265_TRANSCODE_RESULT result = ParamsHelper.CreateParam<H265_TRANSCODE_RESULT>();
            jsonObj.Add("result", result);

            string originChannel = ParamsHelper.CreateParam<string>();
            jsonObj.Add("originChannel", originChannel);

            string transcodeChannel = ParamsHelper.CreateParam<string>();
            jsonObj.Add("transcodeChannel", transcodeChannel);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnQueryChannelPassed(result, originChannel, transcodeChannel));
        }

        [Test]
        public void Test_OnTriggerTranscode()
        {
            ApiParam.@event = AgoraEventType.EVENT_H265TRANSCODEROBSERVER_ONTRIGGERTRANSCODE;

            jsonObj.Clear();

            H265_TRANSCODE_RESULT result = ParamsHelper.CreateParam<H265_TRANSCODE_RESULT>();
            jsonObj.Add("result", result);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnTriggerTranscodePassed(result));
        }
        #endregion terra IH265TranscoderObserver
    }
}
