﻿using NUnit.Framework;
using Agora.Rtc;
using uid_t = System.UInt32;
namespace Agora.Rtc.Ut
{
    public partial class UnitTest_ILocalSpatialAudioEngine
    {
        public IRtcEngine Engine;
        public ILocalSpatialAudioEngine @interface;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            rtcEngineContext.logConfig.level = LOG_LEVEL.LOG_LEVEL_API_CALL;
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            @interface = Engine.GetLocalSpatialAudioEngine();
            Assert.AreEqual(@interface != null, true);
            nRet = @interface.Initialize();
            Assert.AreEqual(0, nRet);
        }

        [TearDown]
        public void TearDown() { Engine.Dispose(); }

        [Test]
        public void Test_SetMaxAudioRecvCount_46f8ab7()
        {
            int maxCount;
            maxCount = 128;
            var nRet = @interface.SetMaxAudioRecvCount(maxCount);
            Assert.AreEqual(0, nRet);
            maxCount = 64;
            nRet = @interface.SetMaxAudioRecvCount(maxCount);
            Assert.AreEqual(0, nRet);
            maxCount = int.MaxValue;
            nRet = @interface.SetMaxAudioRecvCount(maxCount);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioRecvRange_685e803()
        {
            float range;
            range = 12.34f;
            var nRet = @interface.SetAudioRecvRange(range);
            Assert.AreEqual(0, nRet);
            range = 18032;
            nRet = @interface.SetAudioRecvRange(range);
            Assert.AreEqual(0, nRet);
            range = 192.23f;
            nRet = @interface.SetAudioRecvRange(range);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetDistanceUnit_685e803()
        {
            float unit;
            unit = 19.3f;
            var nRet = @interface.SetDistanceUnit(unit);
            Assert.AreEqual(0, nRet);

            unit = 289.232f;
            nRet = @interface.SetDistanceUnit(unit);
            Assert.AreEqual(0, nRet);

            unit = 89.22f;
            nRet = @interface.SetDistanceUnit(unit);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateSelfPosition_9c9930f()
        {
            float[] position = new float[3];
            position[0] = 2932.23f;
            position[1] = 232.232f;
            position[2] = -99.99f;

            float[] axisForward = new float[3];
            axisForward[0] = 12312.3232f;
            axisForward[1] = 98.23f;
            axisForward[2] = -1239.92f;

            float[] axisRight = new float[3];
            axisRight[0] = 23.23f;
            axisRight[1] = 98.23f;
            axisRight[2] = -9823232f;

            float[] axisUp = new float[3];
            axisUp[0] = 98232.9f;
            axisUp[1] = 823.23f;
            axisUp[2] = -2382.232f;

            var nRet = @interface.UpdateSelfPosition(position, axisForward, axisRight, axisUp);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateSelfPositionEx_502183a()
        {
            float[] position = new float[3];
            position[0] = -9232.23f;
            position[1] = 9873.23f;
            position[2] = -198.232f;

            float[] axisForward = new float[3];
            axisForward[0] = -2382f;
            axisForward[1] = -0.11123f;
            axisForward[2] = 1232.92f;

            float[] axisRight = new float[3];
            axisRight[0] = 73434.89f;
            axisRight[1] = -232.23f;
            axisRight[2] = 23232f;

            float[] axisUp = new float[3];
            axisUp[0] = -238232.9f;
            axisUp[1] = 334.23f;
            axisUp[2] = -343.232f;

            RtcConnection connection = new RtcConnection("hello", 238);

            var nRet = @interface.UpdateSelfPositionEx(position, axisForward, axisRight, axisUp, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdatePlayerPositionInfo_b37c59d()
        {
            int playerId;
            playerId = 123;

            float[] position = new float[3];
            position[0] = 232;
            position[1] = 2332f;
            position[2] = -983.2f;

            float[] forward = new float[3];
            forward[0] = 334.2f;
            forward[1] = -32343.2f;
            forward[2] = 9437.232f;
            RemoteVoicePositionInfo positionInfo = new RemoteVoicePositionInfo(position, forward);

            var nRet = @interface.UpdatePlayerPositionInfo(playerId, positionInfo);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetZones_414a27e()
        {
            SpatialAudioZone[] zones = new SpatialAudioZone[5];
            float baseParam = 292.232f;
            for (int i = 0; i < zones.Length; i++)
            {
                zones[i] = new SpatialAudioZone();
                zones[i].zoneSetId = i;
                zones[i].position = new float[3];
                zones[i].position[0] = baseParam + 0 + i * 10;
                zones[i].position[1] = baseParam + 1 + i * 10;
                zones[i].position[2] = baseParam + 2 + i * 10;
                zones[i].forward = new float[3];
                zones[i].forward[0] = baseParam + 3 + i * 10;
                zones[i].forward[1] = baseParam + 4 + i * 10;
                zones[i].forward[2] = baseParam + 5 + i * 10;

                zones[i].right = new float[3];
                zones[i].right[0] = baseParam + 6 + i * 10;
                zones[i].right[1] = baseParam + 7 + i * 10;
                zones[i].right[2] = baseParam + 8 + i * 10;
                zones[i].up = new float[3];
                zones[i].up[0] = baseParam + 9 + i * 10;
                zones[i].up[1] = baseParam + 10 + i * 10;
                zones[i].up[2] = baseParam + 11 + i * 10;

                zones[i].forwardLength = baseParam + 12 + i * 10;
                zones[i].rightLength = baseParam + 13 + i * 10;
                zones[i].upLength = baseParam + 14 + i * 10;

                zones[i].audioAttenuation = baseParam + 15 + i * 10;
            }

            uint zoneCount = (uint)zones.Length;

            var nRet = @interface.SetZones(zones, zoneCount);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetPlayerAttenuation_a15bc51()
        {
            int playerId = 12923;

            double attenuation = double.MaxValue;

            bool forceSet = true;

            var nRet = @interface.SetPlayerAttenuation(playerId, attenuation, forceSet);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateRemotePosition_adc0909()
        {
            uid_t uid = 10;

            float[] position = new float[3];
            position[0] = 26632;
            position[1] = -32332f;
            position[2] = 93283.2f;

            float[] forward = new float[3];
            forward[0] = 33.2f;
            forward[1] = -343.2f;
            forward[2] = 1937.232f;
            RemoteVoicePositionInfo positionInfo = new RemoteVoicePositionInfo(position, forward);

            var nRet = @interface.UpdateRemotePosition(uid, positionInfo);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateRemotePositionEx_f0252d9()
        {
            uid_t uid = uint.MaxValue;


            float[] position = new float[3];
            position[0] = 26632;
            position[1] = -32332f;
            position[2] = 93283.2f;

            float[] forward = new float[3];
            forward[0] = 33.2f;
            forward[1] = -343.2f;
            forward[2] = 1937.232f;
            RemoteVoicePositionInfo positionInfo = new RemoteVoicePositionInfo(position, forward);
            RtcConnection connection = new RtcConnection("yanddsad", 1223);

            var nRet = @interface.UpdateRemotePositionEx(uid, positionInfo, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RemoveRemotePosition_c8d091a()
        {
            uid_t uid = 982;
            var nRet = @interface.RemoveRemotePosition(uid);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RemoveRemotePositionEx_58a9850()
        {
            uid_t uid = 83;

            RtcConnection connection = new RtcConnection("s2dfskds", 923);

            var nRet = @interface.RemoveRemotePositionEx(uid, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteAudioAttenuation_74c3e98()
        {
            uid_t uid = 232;

            double attenuation = -983.2;

            bool forceSet = false;

            var nRet = @interface.SetRemoteAudioAttenuation(uid, attenuation, forceSet);

            Assert.AreEqual(0, nRet);
        }

    }
}
