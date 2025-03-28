using System;
using NUnit.Framework;
using uid_t = System.UInt32;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Agora.Rtc.Ut.Event
{
    public class FakeVideoFrame
    {
        public VIDEO_PIXEL_FORMAT type;
        public int width;
        public int height;
        public int yStride;
        public int uStride;
        public int vStride;
        public IntPtr yBuffer;
        public IntPtr uBuffer;
        public IntPtr vBuffer;
        public int rotation;
        public long renderTimeMs;
        public int avsync_type;
        public IntPtr metadata_buffer;
        public int metadata_size;
        public IntPtr sharedContext;
        public int textureId;
        public IntPtr d3d11Texture2d;
        public float[] matrix;
        public IntPtr alphaBuffer;
        public Dictionary<string, string> metaInfo;

        public FakeVideoFrame(VideoFrame frame)
        {
            this.type = frame.type;
            this.width = frame.width;
            this.height = frame.height;
            this.yStride = frame.yStride;
            this.uStride = frame.uStride;
            this.vStride = frame.vStride;
            this.yBuffer = Marshal.UnsafeAddrOfPinnedArrayElement(frame.yBuffer, 0);
            this.uBuffer = Marshal.UnsafeAddrOfPinnedArrayElement(frame.uBuffer, 0);
            this.vBuffer = Marshal.UnsafeAddrOfPinnedArrayElement(frame.vBuffer, 0);
            this.rotation = frame.rotation;
            this.renderTimeMs = frame.renderTimeMs;
            this.avsync_type = frame.avsync_type;
            this.metadata_buffer = frame.metadata_buffer;
            this.metadata_size = frame.metadata_size;
            this.sharedContext = frame.sharedContext;
            this.textureId = frame.textureId;
            this.d3d11Texture2d = frame.d3d11Texture2d;
            this.matrix = frame.matrix;
            this.alphaBuffer = Marshal.UnsafeAddrOfPinnedArrayElement(frame.alphaBuffer, 0);
            if (frame.metaInfo != null)
            {
                metaInfo = new Dictionary<string, string>
                {
                    { "KEY_FACE_CAPTURE", frame.metaInfo.GetMetaInfoStr(META_INFO_KEY.KEY_FACE_CAPTURE) }
                };
            }
            else
            {
                metaInfo = null;
            }
        }
    }

    public partial class UnitTest_IVideoFrameObserver
    {
        public IRtcEngineEx Engine;
        public UTVideoFrameObserver callback;
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

            callback = new UTVideoFrameObserver();
            int ret = Engine.RegisterVideoFrameObserver(callback, VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_RGBA,
                                                        VIDEO_MODULE_POSITION.POSITION_POST_CAPTURER | VIDEO_MODULE_POSITION.POSITION_PRE_RENDERER | VIDEO_MODULE_POSITION.POSITION_PRE_ENCODER,
                                                        OBSERVER_MODE.INTPTR);
            Assert.AreEqual(0, ret);
        }

        [TearDown]
        public void TearDown()
        {
            var ret = Engine.UnRegisterVideoFrameObserver();
            Assert.AreEqual(0, ret);
            Engine.Dispose();
            ApiParam.FreeResult();
        }
    }
}
