using System;
using Agora.Rtc;
using NUnit.Framework;
namespace Agora.Rtc
{
    public class UnitTest_IMediaRecorder
    {
        public IRtcEngine Engine;
        public IMediaRecorder MediaRecorder1;
  
        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            MediaRecorder1 = Engine.CreateMediaRecorder(new RecorderStreamInfo("10", 10));
        }

        [TearDown]
        public void TearDown()
        {
            Engine.DestroyMediaRecorder(MediaRecorder1);
            Engine.Dispose();
        }

        #region terr
        [Test]
        public void Test_SetMediaRecorderObserver()
        {

            IMediaRecorderObserver callback;
            ParamsHelper.InitParam(out callback);
            var nRet = MediaRecorder1.SetMediaRecorderObserver(callback);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartRecording()
        {
            MediaRecorderConfiguration config;
            ParamsHelper.InitParam(out config);
            var nRet = MediaRecorder1.StartRecording(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopRecording()
        {
            var nRet = MediaRecorder1.StopRecording();
            Assert.AreEqual(0, nRet);
        }

        #endregion
    }
}
