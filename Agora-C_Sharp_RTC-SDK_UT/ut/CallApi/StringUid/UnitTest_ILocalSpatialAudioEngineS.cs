using NUnit.Framework;
using Agora.Rtc;
using uid_t = System.UInt32;
namespace Agora.Rtc
{
    public class UnitTest_ILocalSpatialAudioEngineS
    {
        public IRtcEngineS Engine;
        public ILocalSpatialAudioEngineS LocalSpatialAudioEngineS;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngineS.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngineS());
            RtcEngineContextS rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            rtcEngineContext.logConfig.level = LOG_LEVEL.LOG_LEVEL_API_CALL;
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            LocalSpatialAudioEngineS = Engine.GetLocalSpatialAudioEngine();
            Assert.AreEqual(LocalSpatialAudioEngineS != null, true);
            nRet = LocalSpatialAudioEngineS.Initialize();
            Assert.AreEqual(0, nRet);
        }

        [TearDown]
        public void TearDown() { Engine.Dispose(); }

        [Test]
        public void Test_SetMaxAudioRecvCount()
        {
            int maxCount;
            maxCount = 128;
            var nRet = LocalSpatialAudioEngineS.SetMaxAudioRecvCount(maxCount);
            Assert.AreEqual(0, nRet);
            maxCount = 64;
            nRet = LocalSpatialAudioEngineS.SetMaxAudioRecvCount(maxCount);
            Assert.AreEqual(0, nRet);
            maxCount = int.MaxValue;
            nRet = LocalSpatialAudioEngineS.SetMaxAudioRecvCount(maxCount);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioRecvRange()
        {
            float range;
            range = 12.34f;
            var nRet = LocalSpatialAudioEngineS.SetAudioRecvRange(range);
            Assert.AreEqual(0, nRet);
            range = 18032;
            nRet = LocalSpatialAudioEngineS.SetAudioRecvRange(range);
            Assert.AreEqual(0, nRet);
            range = 192.23f;
            nRet = LocalSpatialAudioEngineS.SetAudioRecvRange(range);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetDistanceUnit()
        {
            float unit;
            unit = 19.3f;
            var nRet = LocalSpatialAudioEngineS.SetDistanceUnit(unit);
            Assert.AreEqual(0, nRet);

            unit = 289.232f;
            nRet = LocalSpatialAudioEngineS.SetDistanceUnit(unit);
            Assert.AreEqual(0, nRet);

            unit = 89.22f;
            nRet = LocalSpatialAudioEngineS.SetDistanceUnit(unit);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateSelfPosition()
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

            var nRet = LocalSpatialAudioEngineS.UpdateSelfPosition(position, axisForward, axisRight, axisUp);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateSelfPositionEx()
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

            RtcConnectionS connection = new RtcConnectionS("hello", "238");

            var nRet = LocalSpatialAudioEngineS.UpdateSelfPositionEx(position, axisForward, axisRight, axisUp, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdatePlayerPositionInfo()
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

            var nRet = LocalSpatialAudioEngineS.UpdatePlayerPositionInfo(playerId, positionInfo);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetZones()
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

            var nRet = LocalSpatialAudioEngineS.SetZones(zones, zoneCount);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetPlayerAttenuation()
        {
            int playerId = 12923;

            double attenuation = double.MaxValue;

            bool forceSet = true;

            var nRet = LocalSpatialAudioEngineS.SetPlayerAttenuation(playerId, attenuation, forceSet);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateRemotePosition()
        {
            string userAccount = ParamsHelper.CreateParam<string>();

            float[] position = new float[3];
            position[0] = 26632;
            position[1] = -32332f;
            position[2] = 93283.2f;

            float[] forward = new float[3];
            forward[0] = 33.2f;
            forward[1] = -343.2f;
            forward[2] = 1937.232f;
            RemoteVoicePositionInfo positionInfo = new RemoteVoicePositionInfo(position, forward);

            var nRet = LocalSpatialAudioEngineS.UpdateRemotePosition(userAccount, positionInfo);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateRemotePositionEx()
        {
            string userAccount = "1234567890";

            float[] position = new float[3];
            position[0] = 26632;
            position[1] = -32332f;
            position[2] = 93283.2f;

            float[] forward = new float[3];
            forward[0] = 33.2f;
            forward[1] = -343.2f;
            forward[2] = 1937.232f;
            RemoteVoicePositionInfo positionInfo = new RemoteVoicePositionInfo(position, forward);
            RtcConnectionS connection = new RtcConnectionS("yanddsad", "123456");

            var nRet = LocalSpatialAudioEngineS.UpdateRemotePositionEx(userAccount, positionInfo, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RemoveRemotePosition()
        {
            string userAccount = "1234567890";
            var nRet = LocalSpatialAudioEngineS.RemoveRemotePosition(userAccount);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RemoveRemotePositionEx()
        {
            string userAccount = ParamsHelper.CreateParam<string>();

            RtcConnectionS connection = new RtcConnectionS("s2dfskds", "1234");

            var nRet = LocalSpatialAudioEngineS.RemoveRemotePositionEx(userAccount, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteAudioAttenuation()
        {
            string userAccount = ParamsHelper.CreateParam<string>();

            double attenuation = -983.2;

            bool forceSet = false;

            var nRet = LocalSpatialAudioEngineS.SetRemoteAudioAttenuation(userAccount, attenuation, forceSet);

            Assert.AreEqual(0, nRet);
        }
        #region terra ILocalSpatialAudioEngine
        [Test]
        public void Test_SetParameters()
        {
            string @params = ParamsHelper.CreateParam<string>();

            var nRet = LocalSpatialAudioEngineS.SetParameters(@params);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteLocalAudioStream()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = LocalSpatialAudioEngineS.MuteLocalAudioStream(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteAllRemoteAudioStreams()
        {
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = LocalSpatialAudioEngineS.MuteAllRemoteAudioStreams(mute);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ClearRemotePositions()
        {


            var nRet = LocalSpatialAudioEngineS.ClearRemotePositions();
            Assert.AreEqual(0, nRet);
        }
        [Test]
        public void Test_Initialize()
        {


            var nRet = LocalSpatialAudioEngineS.Initialize();
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteRemoteAudioStream()
        {
            string userAccount = ParamsHelper.CreateParam<string>();
            bool mute = ParamsHelper.CreateParam<bool>();

            var nRet = LocalSpatialAudioEngineS.MuteRemoteAudioStream(userAccount, mute);
            Assert.AreEqual(0, nRet);
        }


        #endregion terra ILocalSpatialAudioEngine
    }
}
