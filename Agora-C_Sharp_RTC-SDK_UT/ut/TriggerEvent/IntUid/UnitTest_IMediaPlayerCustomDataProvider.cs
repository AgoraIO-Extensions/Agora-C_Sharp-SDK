using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Ut.Event
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
            MediaSource mediaSource = new MediaSource();
            mediaSource.provider = EventHandler;
            int ret = MediaPlayer.OpenWithMediaSource(mediaSource);
            Assert.AreEqual(0, ret);
        }

        [TearDown]
        public void TearDown()
        {
            MediaPlayer.Dispose();
            var ret = Engine.InitEventHandler(null);
            Assert.AreEqual(0, ret);
            Engine.Dispose();
            ApiParam.FreeResult();
        }

        #region terra IMediaPlayerCustomDataProvider
        [Test]
        public void Test_IMediaPlayerCustomDataProvider_OnReadData()
        {
            ApiParam.@event = AgoraApiType.IMEDIAPLAYERCUSTOMDATAPROVIDER_ONREADDATA_6e75338;

            jsonObj.Clear();

            IntPtr buffer = ParamsHelper.CreateParam<IntPtr>();
            jsonObj.Add("buffer", buffer);

            int bufferSize = ParamsHelper.CreateParam<int>();
            jsonObj.Add("bufferSize", bufferSize);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnReadDataPassed(buffer, bufferSize));
        }

        [Test]
        public void Test_IMediaPlayerCustomDataProvider_OnSeek()
        {
            ApiParam.@event = AgoraApiType.IMEDIAPLAYERCUSTOMDATAPROVIDER_ONSEEK_624d569;

            jsonObj.Clear();

            long offset = ParamsHelper.CreateParam<long>();
            jsonObj.Add("offset", offset);

            int whence = ParamsHelper.CreateParam<int>();
            jsonObj.Add("whence", whence);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnSeekPassed(offset, whence));
        }
        #endregion terra IMediaPlayerCustomDataProvider
    }
}
