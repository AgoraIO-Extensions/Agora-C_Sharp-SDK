using NUnit.Framework;
using Agora.Rtc;
using System;

namespace Agora.Rtc.Ut
{

    public class UnitTest_AgoraJson
    {

        [SetUp]
        public void Setup()
        {

        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void Test_GetDataArray()
        {
            string json = "{\"numFaces\":2,\"vecDistance\":[60, 40]}";
            LitJson.JsonData jsonData = AgoraJson.ToObject(json);

            var vecDistance = AgoraJson.GetDataArrayInt(jsonData, "vecDistance");
            Assert.AreEqual(2, vecDistance.Length);
            Assert.AreEqual(60, vecDistance[0]);
            Assert.AreEqual(40, vecDistance[1]);
        }

        [Test]
        public void Test_ScreenCaptureConfigurationSourceId()
        {
            string data = "{\"sourceId\": 9223372036854775807,\"sourceDisplayId\":40}";
            ScreenCaptureSourceInfo info = AgoraJson.JsonToStruct<ScreenCaptureSourceInfo>(data);
            Assert.AreEqual(9223372036854775807, info.sourceId);
            Assert.AreEqual(40, info.sourceDisplayId);

            info = new ScreenCaptureSourceInfo();
            Assert.AreEqual(-2, info.sourceDisplayId);
        }
    }
}

