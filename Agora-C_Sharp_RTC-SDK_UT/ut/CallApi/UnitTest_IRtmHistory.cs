using System;
using Agora.Rtc.Ut;
using NUnit.Framework;
namespace Agora.Rtm.Ut
{
    public class UnitTest_IRtmHistory
    {
        public Internal.IRtmClient RtmClient;
        public Internal.IRtmHistory RtmHistory;

        [SetUp]
        public void Setup()
        {
            Internal.RtmConfig config;
            ParamsHelper.InitParam(out config);
            int errorCode = 0;
            RtmClient = Internal.RtmClient.CreateAgoraRtmClient(DLLHelper.CreateFakeRtmClient());
            Assert.AreEqual(0, errorCode);

            RtmHistory = RtmClient.GetHistory();
        }

        [TearDown]
        public void TearDown()
        {
            RtmClient.Dispose();
        }

        #region terr
        [Test]
        public void Test_GetMessages()
        {
            string channelName = ParamsHelper.CreateParam<string>();
            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();
            GetHistoryMessagesOptions options = ParamsHelper.CreateParam<GetHistoryMessagesOptions>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmHistory.GetMessages(channelName, channelType, options, ref requestId);

            Assert.AreEqual(0, nRet);
        }
        #endregion
    }
}
