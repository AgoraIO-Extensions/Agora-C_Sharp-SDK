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
    }
}

