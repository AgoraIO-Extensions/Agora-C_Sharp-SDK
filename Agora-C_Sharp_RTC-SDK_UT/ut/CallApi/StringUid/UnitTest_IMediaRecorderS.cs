using System;
using Agora.Rtc;
using NUnit.Framework;
namespace Agora.Rtc
{
    public class UnitTest_IMediaRecorderS
    {
        public IRtcEngineS EngineS;
        public IMediaRecorderS MediaRecorderS;

        [SetUp]
        public void Setup()
        {
            EngineS = RtcEngineS.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngineS());
            RtcEngineContextS rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = EngineS.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            MediaRecorderS = EngineS.CreateMediaRecorder(new RecorderStreamInfoS("10", "10"));
        }

        [TearDown]
        public void TearDown()
        {
            EngineS.DestroyMediaRecorder(MediaRecorderS);
            EngineS.Dispose();
        }

        #region terra IMediaRecorderS
        [Test]
        public void Test_StartRecording()
        {
            MediaRecorderConfiguration config = ParamsHelper.CreateParam<MediaRecorderConfiguration>();

            var nRet = MediaRecorderS.StartRecording(config);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopRecording()
        {


            var nRet = MediaRecorderS.StopRecording();
            Assert.AreEqual(0, nRet);
        }
        #endregion terra IMediaRecorderS
    }
}
