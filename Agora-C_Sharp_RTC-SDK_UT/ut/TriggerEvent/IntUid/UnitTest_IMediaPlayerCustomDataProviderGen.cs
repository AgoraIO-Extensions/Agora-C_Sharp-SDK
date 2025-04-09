#region Generated by `terra/node/src/rtc/ut/renderers.ts`. DO NOT MODIFY BY HAND.
#endregion

using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Ut.Event
{
    public partial class UnitTest_IMediaPlayerCustomDataProvider
    {
        [Test]
        public void Test_IMediaPlayerCustomDataProvider_OnReadData_6e75338()
        {
            ApiParam.@event = AgoraApiType.IMEDIAPLAYERCUSTOMDATAPROVIDER_ONREADDATA_6e75338;

            jsonObj.Clear();

            IntPtr buffer = ParamsHelper.CreateParam<IntPtr>();
            jsonObj.Add("buffer", buffer);

            int bufferSize = ParamsHelper.CreateParam<int>();
            jsonObj.Add("bufferSize", bufferSize);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, callback.OnReadDataPassed(buffer, bufferSize));
        }

        [Test]
        public void Test_IMediaPlayerCustomDataProvider_OnSeek_624d569()
        {
            ApiParam.@event = AgoraApiType.IMEDIAPLAYERCUSTOMDATAPROVIDER_ONSEEK_624d569;

            jsonObj.Clear();

            long offset = ParamsHelper.CreateParam<long>();
            jsonObj.Add("offset", offset);

            int whence = ParamsHelper.CreateParam<int>();
            jsonObj.Add("whence", whence);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, callback.OnSeekPassed(offset, whence));
        }

    }
}