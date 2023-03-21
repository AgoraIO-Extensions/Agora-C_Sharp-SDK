using System;
using Agora.Rtc;
using NUnit.Framework;
namespace Agora.Rtc
{
    public class UnitTest_IMediaRecorder
    {
        public IRtcEngine Engine;
        public IMediaRecorder MediaRecorder1;
        public IMediaRecorder MediaRecorder2;
        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            MediaRecorder1 = Engine.CreateLocalMediaRecorder(new RtcConnection("10", 10));
            MediaRecorder2 = Engine.CreateRemoteMediaRecorder("10", 10);
        }

        [TearDown]
        public void TearDown()
        {
            Engine.DestroyMediaRecorder(MediaRecorder1);
            Engine.DestroyMediaRecorder(MediaRecorder2);
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
            nRet = MediaRecorder2.SetMediaRecorderObserver(callback);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartRecording()
        {
            MediaRecorderConfiguration config;
            ParamsHelper.InitParam(out config);
            var nRet = MediaRecorder1.StartRecording(config);
            Assert.AreEqual(0, nRet);
            nRet = MediaRecorder2.StartRecording(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopRecording()
        {
            var nRet = MediaRecorder1.StopRecording();
            Assert.AreEqual(0, nRet);
            nRet = MediaRecorder2.StopRecording();
            Assert.AreEqual(0, nRet);
        }

        #endregion
    }
}
