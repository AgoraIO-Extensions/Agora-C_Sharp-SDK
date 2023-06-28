using NUnit.Framework;
using Agora.Rtc;
using uid_t = System.UInt32;
namespace Agora.Rtc
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
        public void TearDown() { Engine.Dispose(); }

#region custom

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
            maxCount = 128;
            var nRet = LocalSpatialAudioEngine.SetMaxAudioRecvCount(maxCount);
            Assert.AreEqual(0, nRet);
            maxCount = 64;
            nRet = LocalSpatialAudioEngine.SetMaxAudioRecvCount(maxCount);
            Assert.AreEqual(0, nRet);
            maxCount = int.MaxValue;
            nRet = LocalSpatialAudioEngine.SetMaxAudioRecvCount(maxCount);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetAudioRecvRange()
        {
            float range;
            range = 12.34f;
            var nRet = LocalSpatialAudioEngine.SetAudioRecvRange(range);
            Assert.AreEqual(0, nRet);
            range = 18032;
            nRet = LocalSpatialAudioEngine.SetAudioRecvRange(range);
            Assert.AreEqual(0, nRet);
            range = 192.23f;
            nRet = LocalSpatialAudioEngine.SetAudioRecvRange(range);
            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetDistanceUnit()
        {
            float unit;
            unit = 19.3f;
            var nRet = LocalSpatialAudioEngine.SetDistanceUnit(unit);
            Assert.AreEqual(0, nRet);

            unit = 289.232f;
            nRet = LocalSpatialAudioEngine.SetDistanceUnit(unit);
            Assert.AreEqual(0, nRet);

            unit = 89.22f;
            nRet = LocalSpatialAudioEngine.SetDistanceUnit(unit);
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
           
            var nRet = LocalSpatialAudioEngine.UpdateSelfPosition(position, axisForward, axisRight, axisUp);

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

            RtcConnection connection = new RtcConnection("hello", 238);

            var nRet = LocalSpatialAudioEngine.UpdateSelfPositionEx(position, axisForward, axisRight, axisUp, connection);

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
            SpatialAudioZone[] zones = new SpatialAudioZone[5];
            float baseParam = 292.232f;
            for (int i = 0; i < zones.Length; i++) {
                zones[i] = new SpatialAudioZone();
                zones[i].position = new float[3];
                zones[i].position[0] = baseParam + 0;
                zones[i].position[1] = baseParam + 1;
                zones[i].position[2] = baseParam + 2;
                zones[i].forward = new float[3];
                zones[i].forward[0] = baseParam + 3;
                zones[i].forward[1] = baseParam + 4;
                zones[i].forward[2] = baseParam + 5;

                zones[i].right = new float[3];
                zones[i].right[0] = baseParam + 6;
                zones[i].right[1] = baseParam + 7;
                zones[i].right[2] = baseParam + 8;
                zones[i].up = new float[3];
                zones[i].up[0] = baseParam + 9;
                zones[i].up[1] = baseParam + 10;
                zones[i].up[2] = baseParam + 11;

                zones[i].forwardLength = baseParam + 12;
                zones[i].rightLength = baseParam + 13;
                zones[i].upLength = baseParam + 14;

                zones[i].audioAttenuation = baseParam + 15;
            }

          
            uint zoneCount = (uint)zones.Length;
          
            var nRet = LocalSpatialAudioEngine.SetZones(zones, zoneCount);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetPlayerAttenuation()
        {
            int playerId = 12923;

            double attenuation = double.MaxValue;

            bool forceSet = true;

            var nRet = LocalSpatialAudioEngine.SetPlayerAttenuation(playerId, attenuation, forceSet);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_MuteRemoteAudioStream()
        {
            uid_t uid = 12009;
          
            bool mute = false;
           
            var nRet = LocalSpatialAudioEngine.MuteRemoteAudioStream(uid, mute);

            Assert.AreEqual(0, nRet);
        }
        [Test]
        public void Test_UpdateRemotePosition()
        {
            uid_t uid;
            ParamsHelper.InitParam(out uid);

            float[] position = new float[3];
            position[0] = 26632;
            position[1] = -32332f;
            position[2] = 93283.2f;

            float[] forward = new float[3];
            forward[0] = 33.2f;
            forward[1] = -343.2f;
            forward[2] = 1937.232f;
            RemoteVoicePositionInfo positionInfo = new RemoteVoicePositionInfo(position, forward);

            var nRet = LocalSpatialAudioEngine.UpdateRemotePosition(uid, positionInfo);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_UpdateRemotePositionEx()
        {
            uid_t uid = uint.MaxValue;
          
            RemoteVoicePositionInfo posInfo;
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
           
            var nRet = LocalSpatialAudioEngine.UpdateRemotePositionEx(uid, positionInfo, connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RemoveRemotePosition()
        {
            uid_t uid = 982;
            var nRet = LocalSpatialAudioEngine.RemoveRemotePosition(uid);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_RemoveRemotePositionEx()
        {
            uid_t uid = 83;

            RtcConnection connection = new RtcConnection("s2dfskds", 923);
          
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
            RtcConnection connection = new RtcConnection("dasd", 982);
         
            var nRet = LocalSpatialAudioEngine.ClearRemotePositionsEx(connection);

            Assert.AreEqual(0, nRet);
        }

        [Test]
        public void Test_SetRemoteAudioAttenuation()
        {
            uid_t uid = 232;
    
            double attenuation = -983.2;
        
            bool forceSet = false;

            var nRet = LocalSpatialAudioEngine.SetRemoteAudioAttenuation(uid, attenuation, forceSet);

            Assert.AreEqual(0, nRet);
        }

#endregion
    }
}
