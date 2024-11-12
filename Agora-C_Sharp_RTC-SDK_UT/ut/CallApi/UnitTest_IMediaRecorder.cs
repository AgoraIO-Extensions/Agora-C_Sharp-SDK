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
            MediaRecorder = Engine.GetMediaRecorder();
        }

        [TearDown]
        public void TearDown()
        {
            Engine.PreDispose();
            Engine.Dispose();
        }

        #region terr
        [Test]
        public void Test_SetMediaRecorderObserver()
        {
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            IMediaRecorderObserver callback;
            ParamsHelper.InitParam(out callback);
            var nRet = MediaRecorder.SetMediaRecorderObserver(connection, callback);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StartRecording()
        {
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            MediaRecorderConfiguration config;
            ParamsHelper.InitParam(out config);
            var nRet = MediaRecorder.StartRecording(connection, config);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_StopRecording()
        {
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = MediaRecorder.StopRecording(connection);

            Assert.AreEqual(0, nRet);
        }

        #endregion
    }
}
