using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Agora.Rtc.Ut.Event
{
    public partial class UnitTest_IAudioTrackObserver
    {
        public IRtcEngineEx Engine;
        public UTAudioTrackObserver callback;
        public IntPtr FakeRtcEnginePtr;
        public IrisCApiParam2 ApiParam;
        public Dictionary<string, object> jsonObj = new Dictionary<string, object>();

        [SetUp]
        public void Setup()
        {
            FakeRtcEnginePtr = DLLHelper.CreateFakeRtcEngine();
            Engine = RtcEngine.CreateAgoraRtcEngineEx(FakeRtcEnginePtr);
            RtcEngineContext context;
            ParamsHelper.InitParam(out context);
            Assert.AreEqual(0, Engine.Initialize(context));
            ApiParam.AllocResult();
            callback = new UTAudioTrackObserver();
            Assert.AreEqual(0, Engine.RegisterAudioTrackObserver(7, callback));
        }

        [TearDown]
        public void TearDown()
        {
            Engine.UnregisterAudioTrackObserver(7, callback);
            Engine.Dispose();
            ApiParam.FreeResult();
        }

        [Test]
        public void RejectsNullAndDuplicateObserversWithoutReplacingTheListener()
        {
            Assert.AreEqual(-(int)ERROR_CODE_TYPE.ERR_INVALID_ARGUMENT, Engine.RegisterAudioTrackObserver(7, null));
            Assert.AreEqual(-(int)ERROR_CODE_TYPE.ERR_ALREADY_IN_USE, Engine.RegisterAudioTrackObserver(7, callback));
            Assert.AreEqual(-(int)ERROR_CODE_TYPE.ERR_INVALID_ARGUMENT, Engine.UnregisterAudioTrackObserver(8, callback));
            Assert.AreEqual(0, Engine.RegisterAudioTrackObserver(8, callback));
            Assert.AreEqual(0, Engine.UnregisterAudioTrackObserver(7, callback));
            Assert.AreEqual(0, Engine.UnregisterAudioTrackObserver(8, callback));
        }
    }
}
