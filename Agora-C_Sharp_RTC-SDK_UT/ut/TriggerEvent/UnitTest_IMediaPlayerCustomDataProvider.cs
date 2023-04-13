using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Event
{
    [TestFixture]
    public class UnitTest_IMediaPlayerCustomDataProvider
    {

        public IRtcEngineEx Engine;
        public IMediaPlayer MediaPlayer;
        public UTMediaPlayerCustomDataProvider EventHandler;
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

            MediaPlayer = Engine.CreateMediaPlayer();
            EventHandler = new UTMediaPlayerCustomDataProvider();
            int ret = MediaPlayer.OpenWithCustomSource(0, EventHandler);
            Assert.AreEqual(0, ret);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = Engine.InitEventHandler(null);
            Assert.AreEqual(0, ret);
            Engine.Dispose();
            ApiParam.FreeResult();
        }

        #region

        [Test]
        public void Test_OnSeek()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIAPLAYERCUSTOMDATAPROVIDER_ONSEEK;

            long offset;
            ParamsHelper.InitParam(out offset);

            int whence;
            ParamsHelper.InitParam(out whence);

            jsonObj.Clear();
            jsonObj.Add("offset", offset);
            jsonObj.Add("whence", whence);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnSeekPassed(offset, whence));
        }

        [Test]
        public void Test_OnReadData()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIAPLAYERCUSTOMDATAPROVIDER_ONREADDATA;

            IntPtr buffer;
            ParamsHelper.InitParam(out buffer);

            int bufferSize;
            ParamsHelper.InitParam(out bufferSize);

            jsonObj.Clear();
            jsonObj.Add("buffer", buffer);
            jsonObj.Add("bufferSize", bufferSize);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnReadDataPassed(buffer, bufferSize));
        }
        #endregion
    }
}