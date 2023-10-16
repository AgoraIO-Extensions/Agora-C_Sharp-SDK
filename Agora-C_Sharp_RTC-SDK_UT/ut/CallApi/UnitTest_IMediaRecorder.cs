using System;
using Agora.Rtc;
using NUnit.Framework;
namespace Agora.Rtc
{
    public class UnitTest_IMediaRecorder
    {
        public IRtcEngine Engine;
        public IMediaRecorder MediaRecorder;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            MediaRecorder = Engine.CreateMediaRecorder(new RecorderStreamInfo("10", 10));
        }

        [TearDown]
        public void TearDown()
        {
            Engine.DestroyMediaRecorder(MediaRecorder);
            Engine.Dispose();
        }

        #region terra IMediaRecorder

        [Test]
        public void Test_SetMediaRecorderObserver()
        {
            IMediaRecorderObserver callback = ParamsHelper.CreateParam<IMediaRecorderObserver>();

            var nRet = MediaRecorder.SetMediaRecorderObserver(callback);
            Assert.AreEqual(0, nRet);
        }
        #endregion terra IMediaRecorder
    }
}
