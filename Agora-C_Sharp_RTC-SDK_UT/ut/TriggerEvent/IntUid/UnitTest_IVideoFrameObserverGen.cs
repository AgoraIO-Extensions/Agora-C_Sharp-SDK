#region Generated by `terra/node/src/rtc/ut/renderers.ts`. DO NOT MODIFY BY HAND.
#endregion

using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
namespace Agora.Rtc.Ut.Event
{
    public partial class UnitTest_IVideoFrameObserver
    {
        [Test]
        public void Test_IVideoFrameObserver_OnCaptureVideoFrame_1673590()
        {
            ApiParam.@event = AgoraApiType.IVIDEOFRAMEOBSERVER_ONCAPTUREVIDEOFRAME_1673590;

            jsonObj.Clear();

            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            jsonObj.Add("sourceType", sourceType);

            VideoFrame videoFrame = ParamsHelper.CreateParam<VideoFrame>();
            jsonObj.Add("videoFrame", videoFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, callback.OnCaptureVideoFramePassed(sourceType, videoFrame));
        }

        [Test]
        public void Test_IVideoFrameObserver_OnPreEncodeVideoFrame_1673590()
        {
            ApiParam.@event = AgoraApiType.IVIDEOFRAMEOBSERVER_ONPREENCODEVIDEOFRAME_1673590;

            jsonObj.Clear();

            VIDEO_SOURCE_TYPE sourceType = ParamsHelper.CreateParam<VIDEO_SOURCE_TYPE>();
            jsonObj.Add("sourceType", sourceType);

            VideoFrame videoFrame = ParamsHelper.CreateParam<VideoFrame>();
            jsonObj.Add("videoFrame", videoFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, callback.OnPreEncodeVideoFramePassed(sourceType, videoFrame));
        }

        [Test]
        public void Test_IVideoFrameObserver_OnMediaPlayerVideoFrame_e648e2c()
        {
            ApiParam.@event = AgoraApiType.IVIDEOFRAMEOBSERVER_ONMEDIAPLAYERVIDEOFRAME_e648e2c;

            jsonObj.Clear();

            VideoFrame videoFrame = ParamsHelper.CreateParam<VideoFrame>();
            jsonObj.Add("videoFrame", videoFrame);

            int mediaPlayerId = ParamsHelper.CreateParam<int>();
            jsonObj.Add("mediaPlayerId", mediaPlayerId);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, callback.OnMediaPlayerVideoFramePassed(videoFrame, mediaPlayerId));
        }

        [Test]
        public void Test_IVideoFrameObserver_OnRenderVideoFrame_43dcf82()
        {
            ApiParam.@event = AgoraApiType.IVIDEOFRAMEOBSERVER_ONRENDERVIDEOFRAME_43dcf82;

            jsonObj.Clear();

            string channelId = ParamsHelper.CreateParam<string>();
            jsonObj.Add("channelId", channelId);

            uint remoteUid = ParamsHelper.CreateParam<uint>();
            jsonObj.Add("remoteUid", remoteUid);

            VideoFrame videoFrame = ParamsHelper.CreateParam<VideoFrame>();
            jsonObj.Add("videoFrame", videoFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, callback.OnRenderVideoFramePassed(channelId, remoteUid, videoFrame));
        }

        [Test]
        public void Test_IVideoFrameObserver_OnTranscodedVideoFrame_27754d8()
        {
            ApiParam.@event = AgoraApiType.IVIDEOFRAMEOBSERVER_ONTRANSCODEDVIDEOFRAME_27754d8;

            jsonObj.Clear();

            VideoFrame videoFrame = ParamsHelper.CreateParam<VideoFrame>();
            jsonObj.Add("videoFrame", videoFrame);

            var jsonString = LitJson.JsonMapper.ToJson(jsonObj);
            ApiParam.data = jsonString;
            ApiParam.data_size = (uint)jsonString.Length;

            int ret = DLLHelper.TriggerEventWithFakeRtcEngine(FakeRtcEnginePtr, ref ApiParam);
            Assert.AreEqual(0, ret);
            Assert.AreEqual(true, callback.OnTranscodedVideoFramePassed(videoFrame));
        }

    }
}