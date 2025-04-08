using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Agora.Rtc.Ut.Event
{
    [TestFixture]
    public partial class UnitTest_IMediaPlayerSourceObserver
    {

        public IRtcEngineEx Engine;
        public IMediaPlayer MediaPlayer;
        public UTMediaPlayerSourceObserver callback;
        public IntPtr FakeRtcEnginePtr;
        public IrisCApiParam2 ApiParam;
        public Dictionary<string, System.Object> jsonObj = new Dictionary<string, object>();

        [SetUp]
        public void Setup()
        {
            FakeRtcEnginePtr = DLLHelper.CreateFakeRtcEngine();
            Engine = RtcEngine.CreateAgoraRtcEngineEx(FakeRtcEnginePtr);
            RtcEngineContext rtcEngineContext;
            ParamsHelper.InitParam(out rtcEngineContext);
            int nRet = Engine.Initialize(rtcEngineContext);
            Assert.AreEqual(0, nRet);
            ApiParam.AllocResult();

            MediaPlayer = Engine.CreateMediaPlayer();
            callback = new UTMediaPlayerSourceObserver();
            int ret = MediaPlayer.InitEventHandler(callback);
            Assert.AreEqual(0, ret);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = Engine.InitEventHandler(null);
            Assert.AreEqual(0, ret);
            Engine.Dispose();
            ApiParam.FreeResult();
        }

        [Test]
        public void Test_IMediaPlayerSourceObserver_OnMetaData()
        {
            ApiParam.@event = AgoraApiType.IMEDIAPLAYERSOURCEOBSERVER_ONMETADATA_469a01b;

            jsonObj.Clear();

            byte[] data = ParamsHelper.CreateParam<byte[]>();
            jsonObj.Add("data", Marshal.UnsafeAddrOfPinnedArrayElement(data, 0));

            int length = ParamsHelper.CreateParam<int>();
            jsonObj.Add("length", length);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, callback.OnMetaDataPassed(data, length));
        }
    }
}