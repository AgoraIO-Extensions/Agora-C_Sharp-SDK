using NUnit.Framework;
using Agora.Rtc;
using uid_t = System.UInt32;
namespace ut
{
    public class UnitTest_ILocalSpatialAudioEngine
    {
        public IRtcEngine Engine;
        public ILocalSpatialAudioEngine LocalSpatialAudioEngine;

        [SetUp]
        public void Setup()
        {
            Engine = RtcEngine.CreateAgoraRtcEngine(DLLHelper.CreateFakeRtcEngine());
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            LocalSpatialAudioEngine = Engine.GetLocalSpatialAudioEngine();
            Assert.AreEqual(LocalSpatialAudioEngine != null, true);
            nRet = LocalSpatialAudioEngine.Initialize();
            Assert.AreEqual(0, nRet);
        }

        [TearDown]
        public void TearDown()
        {
            Engine.Dispose();
        }

        #region  custom


        [Test]
        public void Test_Initialize()
        {

            var nRet = LocalSpatialAudioEngine.Initialize();

            Assert.AreEqual(0, nRet);
        }

        #endregion

        #region terr
        [Test]
        public void Test_SetMaxAudioRecvCount()
        {
            int maxCount;
            ParamsHelper.InitParam(out maxCount);
            var nRet = LocalSpatialAudioEngine.SetMaxAudioRecvCount(maxCount);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioRecvRange()
        {
            float range;
            ParamsHelper.InitParam(out range);
            var nRet = LocalSpatialAudioEngine.SetAudioRecvRange(range);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetDistanceUnit()
        {
            float unit;
            ParamsHelper.InitParam(out unit);
            var nRet = LocalSpatialAudioEngine.SetDistanceUnit(unit);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateSelfPosition()
        {
            float[] position;
            ParamsHelper.InitParam(out position);
            float[] axisForward;
            ParamsHelper.InitParam(out axisForward);
            float[] axisRight;
            ParamsHelper.InitParam(out axisRight);
            float[] axisUp;
            ParamsHelper.InitParam(out axisUp);
            var nRet = LocalSpatialAudioEngine.UpdateSelfPosition(position, axisForward, axisRight, axisUp);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateSelfPositionEx()
        {
            float[] position;
            ParamsHelper.InitParam(out position);
            float[] axisForward;
            ParamsHelper.InitParam(out axisForward);
            float[] axisRight;
            ParamsHelper.InitParam(out axisRight);
            float[] axisUp;
            ParamsHelper.InitParam(out axisUp);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = LocalSpatialAudioEngine.UpdateSelfPositionEx(position, axisForward, axisRight, axisUp, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdatePlayerPositionInfo()
        {
            int playerId;
            ParamsHelper.InitParam(out playerId);
            RemoteVoicePositionInfo positionInfo;
            ParamsHelper.InitParam(out positionInfo);
            var nRet = LocalSpatialAudioEngine.UpdatePlayerPositionInfo(playerId, positionInfo);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetParameters()
        {
            string @params;
            ParamsHelper.InitParam(out @params);
            var nRet = LocalSpatialAudioEngine.SetParameters(@params);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteLocalAudioStream()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);
            var nRet = LocalSpatialAudioEngine.MuteLocalAudioStream(mute);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteAllRemoteAudioStreams()
        {
            bool mute;
            ParamsHelper.InitParam(out mute);
            var nRet = LocalSpatialAudioEngine.MuteAllRemoteAudioStreams(mute);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetZones()
        {
            SpatialAudioZone[] zones;
            ParamsHelper.InitParam(out zones);
            uint zoneCount;
            ParamsHelper.InitParam(out zoneCount);
            var nRet = LocalSpatialAudioEngine.SetZones(zones, zoneCount);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetPlayerAttenuation()
        {
            int playerId;
            ParamsHelper.InitParam(out playerId);
            double attenuation;
            ParamsHelper.InitParam(out attenuation);
            bool forceSet;
            ParamsHelper.InitParam(out forceSet);
            var nRet = LocalSpatialAudioEngine.SetPlayerAttenuation(playerId, attenuation, forceSet);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteRemoteAudioStream()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            bool mute;
            ParamsHelper.InitParam(out mute);
            var nRet = LocalSpatialAudioEngine.MuteRemoteAudioStream(uid, mute);

            Assert.AreEqual(0, nRet);
        }
        [Test]
        public void Test_UpdateRemotePosition()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            RemoteVoicePositionInfo posInfo;
            ParamsHelper.InitParam(out posInfo);
            var nRet = LocalSpatialAudioEngine.UpdateRemotePosition(uid, posInfo);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateRemotePositionEx()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            RemoteVoicePositionInfo posInfo;
            ParamsHelper.InitParam(out posInfo);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = LocalSpatialAudioEngine.UpdateRemotePositionEx(uid, posInfo, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RemoveRemotePosition()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            var nRet = LocalSpatialAudioEngine.RemoveRemotePosition(uid);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RemoveRemotePositionEx()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = LocalSpatialAudioEngine.RemoveRemotePositionEx(uid, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ClearRemotePositions()
        {

            var nRet = LocalSpatialAudioEngine.ClearRemotePositions();

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_ClearRemotePositionsEx()
        {
            RtcConnection connection;
            ParamsHelper.InitParam(out connection);
            var nRet = LocalSpatialAudioEngine.ClearRemotePositionsEx(connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteAudioAttenuation()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);
            double attenuation;
            ParamsHelper.InitParam(out attenuation);
            bool forceSet;
            ParamsHelper.InitParam(out forceSet);
            var nRet = LocalSpatialAudioEngine.SetRemoteAudioAttenuation(uid, attenuation, forceSet);

            Assert.AreEqual(0, nRet);
        }

        #endregion

    }
}
