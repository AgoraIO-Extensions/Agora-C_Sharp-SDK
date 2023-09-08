using System;
using NUnit.Framework;
using Agora.Rtc;

namespace Agora.Rtc
{
    public class UnitTest_ParamHelper
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
        public void Test_GetCapability()
        {
            //RtcEngineContext context = ParamsHelper.CreateParam<RtcEngineContext>();
            Metadata metadata = ParamsHelper.CreateParam<Metadata>();

            Console.Write("Hello World");


        }
    }
}