using NUnit.Framework;
using Agora.Rtc;
using System;

namespace Agora.Rtc.Ut
{
    public partial class UnitTest_IVideoEffectObject
    {
        public IRtcEngine Engine;
        public IVideoEffectObject @interface;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);

            string bundlePath = "test_bundle";
            MEDIA_SOURCE_TYPE type = MEDIA_SOURCE_TYPE.PRIMARY_CAMERA_SOURCE;
            @interface = Engine.CreateVideoEffectObject(bundlePath, type);
        }

        [TearDown]
        public void TearDown()
        {
            if (@interface != null)
            {
                Engine.DestroyVideoEffectObject(@interface);
            }
            Engine.Dispose();
        }
    }
}

