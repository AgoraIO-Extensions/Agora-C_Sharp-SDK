#region Generated by `terra/node/src/rtc/ut/renderers.ts`. DO NOT MODIFY BY HAND.
#endregion

using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Ut.Event
{
    public partial class UnitTest_IAudioPcmFrameSink
    {
        [Test]
        public void Test_IAudioPcmFrameSink_OnFrame_95f515a()
        {
            ApiParam.@event = AgoraApiType.IAUDIOPCMFRAMESINK_ONFRAME_95f515a;

            jsonObj.Clear();

            AudioPcmFrame frame = ParamsHelper.CreateParam<AudioPcmFrame>();
            jsonObj.Add("frame", frame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, callback.OnFramePassed(frame));
        }

    }
}