using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Event
{
    [TestFixture]
    public class UnitTest_IAudioPcmFrameSinkS
    {

        public IRtcEngineExS Engine;
        public IMediaPlayer MediaPlayer;
        public UTIAudioPcmFrameSink EventHandler;
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

            MediaPlayer = Engine.CreateMediaPlayer();
            EventHandler = new UTIAudioPcmFrameSink();
            nRet = MediaPlayer.RegisterAudioFrameObserver(EventHandler);
            Assert.AreEqual(0, nRet);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = Engine.InitEventHandler(null);
            Assert.AreEqual(0, ret);
            Engine.Dispose();
            ApiParam.FreeResult();
        }

        #region terra IAudioPcmFrameSink
        [Test]
        public void Test_OnFrame()
        {
            ApiParam.@event = AgoraEventType.EVENT_AUDIOPCMFRAMESINK_ONFRAME;

            jsonObj.Clear();

            AudioPcmFrame frame = ParamsHelper.CreateParam<AudioPcmFrame>();
            jsonObj.Add("frame", frame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, EventHandler.OnFramePassed(frame));
        }
        #endregion terra IAudioPcmFrameSink
    }
}