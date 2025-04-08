using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Agora.Rtc.Ut.Event
{
    [TestFixture]
    public partial class UnitTest_IRtcEngineEventHandler
    {

        public IRtcEngineEx Engine;
        public UTRtcEngineEventHandler callback;
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

            callback = new UTRtcEngineEventHandler();
            Engine.InitEventHandler(callback);
            Engine.SetParameters("rtc.enable_debug_log", true);
            Engine.StartDirectCdnStreaming("url", new DirectCdnStreamingMediaOptions());
        }

        [TearDown]
        public void TearDown()
        {
            Engine.Dispose();
            ApiParam.FreeResult();
        }

        [Test]
        public void Test_IRtcEngineEventHandlerEx_OnAudioMetadataReceived()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONAUDIOMETADATARECEIVED_0d4eb96;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint uid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("uid", uid);

            byte[] metadata = ParamsHelper.CreateParam<byte[]>();
            jsonObj.Add("metadata", Marshal.UnsafeAddrOfPinnedArrayElement(metadata, 0));

            ulong length = ParamsHelper.CreateParam<ulong>();
            jsonObj.Add("length", length);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, callback.OnAudioMetadataReceivedPassed(connection, uid, metadata, length));
        }

        [Test]
        public void Test_IRtcEngineEventHandlerEx_OnStreamMessage()
        {
            ApiParam.@event = AgoraApiType.IRTCENGINEEVENTHANDLER_ONSTREAMMESSAGE_99898cb;

            jsonObj.Clear();

            RtcConnection connection = ParamsHelper.CreateParam<RtcConnection>();
            jsonObj.Add("connection", connection);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            int streamId = ParamsHelper.CreateParam<int>();
            jsonObj.Add("streamId", streamId);

            byte[] data = ParamsHelper.CreateParam<byte[]>();
            jsonObj.Add("data", Marshal.UnsafeAddrOfPinnedArrayElement(data, 0));

            ulong length = ParamsHelper.CreateParam<ulong>();
            jsonObj.Add("length", length);

            ulong sentTs = ParamsHelper.CreateParam<ulong>();
            jsonObj.Add("sentTs", sentTs);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, callback.OnStreamMessagePassed(connection, remoteUid, streamId, data, length, sentTs));
        }
    }
}
