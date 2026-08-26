using Agora.Rtc;
using NUnit.Framework;

namespace Agora.Rtc.Ut
{
    public class UnitTest_ConstructorCompatibility
    {
        [Test]
        public void RtcEngineContext_OldFullConstructor_UsesEmptyParameters()
        {
            var context = new RtcEngineContext(
                appId: "app-id",
                context: 0,
                channelProfile: CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING,
                license: string.Empty,
                audioScenario: AUDIO_SCENARIO_TYPE.AUDIO_SCENARIO_DEFAULT,
                areaCode: AREA_CODE.AREA_CODE_GLOB,
                logConfig: new LogConfig(),
                threadPriority: new Optional<THREAD_PRIORITY_TYPE>(),
                useExternalEglContext: false,
                domainLimit: false,
                autoRegisterAgoraExtensions: true);

            Assert.AreEqual(string.Empty, context.parameters);
        }
    }
}
