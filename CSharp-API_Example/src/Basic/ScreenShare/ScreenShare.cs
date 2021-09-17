using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using agora.rtc;
using System.Diagnostics;
using Microsoft.Win32;

namespace CSharp_API_Example
{
    public class ScreenShare : IEngine
    {
        private IAgoraRtcEngine rtc_engine = null;
        private IAgoraRtcEngineEventHandler event_handler = null;
        private IAgoraRtcVideoFrameObserver video_frame_observer = null;

        private static IAgoraRtcEngine screen_share_engine = null;
        //private static IAgoraRtcEngineEventHandler screen_share_event_handler = null;

        // must
        protected string app_id = "";
        protected string channel_id = "";

        // not necessary
        private string ScreenShare_TAG = "[ScreenShare] ";

        internal override string getSDKVersion()
        {
            if (null == rtc_engine)
            {
                rtc_engine = AgoraRtcEngine.CreateAgoraRtcEngine();
                if (rtc_engine == null)
                {
                    CSharpForm.dump_handler("CreateEngine", -1);
                    return "";
                }
            }
            return rtc_engine.GetVersion();
        }

        internal override IAgoraRtcEngine getEngine()
        {
            if (null == rtc_engine)
            {
                rtc_engine = AgoraRtcEngine.CreateAgoraRtcEngine();
                if (rtc_engine == null)
                    Console.WriteLine("CreateEngine failed!!!");
            }
            return rtc_engine;
        }

        internal override int Init(string appId, string channelId)
        {
            int ret = -1;
            app_id = appId;
            channel_id = channelId;
            if (null == rtc_engine)
            {
                rtc_engine = AgoraRtcEngine.CreateAgoraRtcEngine();
                if (rtc_engine == null)
                {
                    CSharpForm.dump_handler("CreateEngine", -1);
                    return -1;
                }
            }

            event_handler = new ScreenShareEventHandler();
            rtc_engine.InitEventHandler(event_handler);

            //// raw data
            //video_frame_observer = new ScreenShareVideoFrameObserver();
            //rtc_engine.RegisterVideoFrameObserver(video_frame_observer);

            RtcEngineContext rtc_engine_ctx = new RtcEngineContext(app_id);
            ret = rtc_engine.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler("Initialize", ret);

            ret = rtc_engine.EnableVideo();
            CSharpForm.dump_handler("EnableVideo", ret);

            ret = rtc_engine.EnableAudio();
            CSharpForm.dump_handler("EnableAudio", ret);


            // subprocess for screenshare
            screen_share_engine = AgoraRtcEngine.CreateAgoraRtcEngine(AgoraEngineType.SubProcess);
            if (screen_share_engine == null)
                CSharpForm.dump_handler(ScreenShare_TAG + "CreateEngine", -1);
            else
                CSharpForm.dump_handler(ScreenShare_TAG + "CreateEngine", 0);
            //screen_share_event_handler = new ScreenShareEventHandler();
            //screen_share_engine.InitEventHandler(screen_share_event_handler);

            ret = screen_share_engine.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler(ScreenShare_TAG + "Initialize", ret);

            return ret;
        }

        internal override int unInit()
        {
            int ret = -1;

            if (null != screen_share_engine)
            {
                ret = screen_share_engine.StopScreenCapture();
                CSharpForm.dump_handler(ScreenShare_TAG + "StopScreenCapture", ret);

                ret = screen_share_engine.LeaveChannel();
                CSharpForm.dump_handler(ScreenShare_TAG + "LeaveChannel", ret);

                screen_share_engine.Dispose();
                screen_share_engine = null;
            }

            if (null != rtc_engine)
            {
                ret = rtc_engine.LeaveChannel();
                CSharpForm.dump_handler("LeaveChannel", ret);

                //rtc_engine.StopPreview();  // pair with StartPreview
                //if (0 == ret)
                //    Console.WriteLine("StopPreview failed!!!, ret={0}", ret);

                ret = rtc_engine.DisableVideo();   // pair with EnableVideo
                CSharpForm.dump_handler("DisableVideo", ret);

                ret = rtc_engine.DisableAudio();   // pair with EnableAudio
                CSharpForm.dump_handler("DisableAudio", ret);

                rtc_engine.Dispose();
                rtc_engine = null;
            }
            return ret;
        }

        internal override int joinChannel()
        {
            int ret = -1;
            if (null != screen_share_engine)
            {
                ret = startScreenShare();
                CSharpForm.dump_handler(ScreenShare_TAG + "startScreenShare", ret);
            }

            if (null != rtc_engine)
            {
                ret = rtc_engine.JoinChannel("", channel_id, "info");
                CSharpForm.dump_handler("JoinChannel", ret);
            }
            return ret;
        }

        internal override int leaveChannel()
        {
            int ret = -1;
            if (null != screen_share_engine)
            {
                ret = stopScreenShare();
                CSharpForm.dump_handler(ScreenShare_TAG + "stopScreenShare", ret);
            }

            if (null != rtc_engine)
            {
                ret = rtc_engine.LeaveChannel();
                CSharpForm.dump_handler("LeaveChannel", ret);
            }
            return ret;
        }

        private int startScreenShare()
        {
            agora.rtc.Rectangle screenRect = new agora.rtc.Rectangle();
            screenRect.height = Screen.PrimaryScreen.WorkingArea.Height;
            screenRect.width = Screen.PrimaryScreen.WorkingArea.Width;
            screenRect.x = Screen.PrimaryScreen.WorkingArea.X;
            screenRect.y = Screen.PrimaryScreen.WorkingArea.Y;
            agora.rtc.Rectangle regionRect = new agora.rtc.Rectangle(0, 0, 1920, 1080);
            ScreenCaptureParameters screen_para = new ScreenCaptureParameters(new VideoDimensions(1920, 1080), 5, 0, true, false);
            int ret = -1;

            //ret = screen_share_engine.StartScreenCaptureByScreenRect(screenRect, regionRect, screen_para);
            //CSharpForm.dump_handler(ScreenShare_TAG + "StartScreenCaptureByScreenRect", ret);

            ret = screen_share_engine.StartScreenCaptureByDisplayId(0, regionRect, screen_para);
            CSharpForm.dump_handler(ScreenShare_TAG + "StartScreenCaptureByDisplayId", ret);

            ret = screen_share_engine.EnableVideo();
            CSharpForm.dump_handler(ScreenShare_TAG + "EnableVideo", ret);

            ret = screen_share_engine.JoinChannel("", channel_id, "info");
            CSharpForm.dump_handler(ScreenShare_TAG + "JoinChannel", ret);

            return ret;
        }

        private int stopScreenShare()
        {
            int ret = screen_share_engine.StopScreenCapture();
            CSharpForm.dump_handler(ScreenShare_TAG + "StopScreenCapture", ret);

            ret = screen_share_engine.LeaveChannel();
            CSharpForm.dump_handler(ScreenShare_TAG + "LeaveChannel", ret);

            return ret;
        }

    }

    // override if need
    internal class ScreenShareEventHandler : IAgoraRtcEngineEventHandler
    {
        public override void OnWarning(int warn, string msg)
        {
            Console.WriteLine("=====>OnWarning {0} {1}", warn, msg);
        }

        public override void OnError(int error, string msg)
        {
            Console.WriteLine("=====>OnError {0} {1}", error, msg);
        }

        public override void OnJoinChannelSuccess(string channel, uint uid, int elapsed)
        {
            Console.WriteLine("----->OnJoinChannelSuccess, channel={0}, uid={1}", channel, uid);
            VideoCanvas vs = new VideoCanvas((ulong)CSharpForm.local_win_id, RENDER_MODE_TYPE.RENDER_MODE_FIT, channel);
            int ret = CSharpForm.usr_engine.getEngine().SetupLocalVideo(vs);
            Console.WriteLine("----->SetupLocalVideo, ret={0}", ret);
        }

        public override void OnRejoinChannelSuccess(string channel, uint uid, int elapsed)
        {
            Console.WriteLine("OnRejoinChannelSuccess");
        }

        public override void OnLeaveChannel(RtcStats stats)
        {
            Console.WriteLine("----->OnLeaveChannel, duration={0}", stats.duration);
        }

        public override void OnUserJoined(uint uid, int elapsed)
        {
            if (CSharpForm.remote_win_id == IntPtr.Zero) return;
            var vc = new VideoCanvas((ulong)CSharpForm.remote_win_id, RENDER_MODE_TYPE.RENDER_MODE_FIT, CSharpForm.channel_id, uid);
            int ret = CSharpForm.usr_engine.getEngine().SetupRemoteVideo(vc);
            if (ret != 0)
            {
                Console.WriteLine("----->OnUserJoined, ret={0}", ret);
            }
            Console.WriteLine("----->OnUserJoined, uid={0}", uid);
        }

        public override void OnUserOffline(uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline, reason={0}", reason);
        }
    }

    // override if need
    internal class ScreenShareVideoFrameObserver : IAgoraRtcVideoFrameObserver
    {
        public override VIDEO_OBSERVER_POSITION GetObservedFramePosition()
        {
            return VIDEO_OBSERVER_POSITION.POSITION_POST_CAPTURER | VIDEO_OBSERVER_POSITION.POSITION_PRE_RENDERER | VIDEO_OBSERVER_POSITION.POSITION_PRE_ENCODER;
        }

        public override VIDEO_FRAME_TYPE GetVideoFormatPreference()
        {
            return VIDEO_FRAME_TYPE.FRAME_TYPE_YUV420;
        }

        public override bool OnCaptureVideoFrame(VideoFrame videoFrame)
        {
            //Console.WriteLine("----->OnCaptureVideoFrame");
            return true;
        }

        public override bool OnPreEncodeVideoFrame(VideoFrame videoFrame)
        {
            //Console.WriteLine("----->OnPreEncodeVideoFrame");
            return true;
        }

        public override bool OnRenderVideoFrame(uint uid, VideoFrame videoFrame)
        {
            //Console.WriteLine("----->OnRenderVideoFrame");
            return true;
        }

        public override bool OnRenderVideoFrameEx(string channelId, uint uid, VideoFrame videoFrame)
        {
            //Console.WriteLine("----->OnRenderVideoFrameEx, channelId={0}, uid={1}, wxh={2}x{3} ", channelId, uid, videoFrame.width, videoFrame.height);
            return true;
        }
    }
}
