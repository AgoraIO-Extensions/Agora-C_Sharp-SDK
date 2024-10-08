﻿using System;
using Agora.Rtc.Ut;
using NUnit.Framework;
namespace Agora.Rtm.Ut
{
    public class UnitTest_IRtmPresence
    {
        public Internal.IRtmClient RtmClient;
        public Internal.IRtmPresence RtmPresence;

        [SetUp]
        public void Setup()
        {
            Internal.RtmConfig config;
            ParamsHelper.InitParam(out config);
            int errorCode = 0;
            RtmClient = Internal.RtmClient.CreateAgoraRtmClient(DLLHelper.CreateFakeRtmClient());
            Assert.AreEqual(0, errorCode);

            RtmPresence = RtmClient.GetPresence();
        }

        [TearDown]
        public void TearDown()
        {
            RtmClient.Dispose();
        }

        #region terr
        [Test]
        public void Test_WhoNow()
        {
            string channelName = ParamsHelper.CreateParam<string>();
            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();
            PresenceOptions options = ParamsHelper.CreateParam<PresenceOptions>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmPresence.WhoNow(channelName, channelType, options, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetOnlineUsers()
        {
            string channelName = ParamsHelper.CreateParam<string>();
            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();
            GetOnlineUsersOptions options = ParamsHelper.CreateParam<GetOnlineUsersOptions>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmPresence.GetOnlineUsers(channelName, channelType, options, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_WhereNow()
        {
            string userId = ParamsHelper.CreateParam<string>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmPresence.WhereNow(userId, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetUserChannels()
        {
            string userId = ParamsHelper.CreateParam<string>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmPresence.GetUserChannels(userId, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetState()
        {
            string channelName = ParamsHelper.CreateParam<string>();
            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();
            StateItem[] items = ParamsHelper.CreateParam<StateItem[]>();
            int count = ParamsHelper.CreateParam<int>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmPresence.SetState(channelName, channelType, items, count, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RemoveState()
        {
            string channelName = ParamsHelper.CreateParam<string>();
            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();
            string[] keys = ParamsHelper.CreateParam<string[]>();
            int count = ParamsHelper.CreateParam<int>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmPresence.RemoveState(channelName, channelType, keys, count, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_GetState()
        {
            string channelName = ParamsHelper.CreateParam<string>();
            RTM_CHANNEL_TYPE channelType = ParamsHelper.CreateParam<RTM_CHANNEL_TYPE>();
            string userId = ParamsHelper.CreateParam<string>();
            ulong requestId = ParamsHelper.CreateParam<ulong>();
            var nRet = RtmPresence.GetState(channelName, channelType, userId, ref requestId);

            Assert.AreEqual(0, nRet);
        }

        #endregion
    }
}
