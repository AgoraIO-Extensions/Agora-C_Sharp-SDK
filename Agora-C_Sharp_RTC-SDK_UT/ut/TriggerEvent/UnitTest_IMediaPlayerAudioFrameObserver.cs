using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Event
{
    [TestFixture]
    public class UnitTest_IMediaPlayerAudioFrameObserver
    {

        public IRtcEngineEx Engine;
        public IMediaPlayer MediaPlayer;
        public UTMediaPlayerAudioFrameObserver EventHandler;
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
            EventHandler = new UTMediaPlayerAudioFrameObserver();
            MediaPlayer.RegisterAudioFrameObserver(EventHandler);
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
        public void Test_OnFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_MEDIAPLAYERAUDIOFRAMEOBSERVER_ONFRAME;

            AudioPcmFrame frame;
            ParamsHelper.InitParam(out frame);

            jsonObj.Clear();
            jsonObj.Add("frame", frame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);

            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFramePassed(frame));
        }


        ///////////////////////////////////

        #endregion
    }
}