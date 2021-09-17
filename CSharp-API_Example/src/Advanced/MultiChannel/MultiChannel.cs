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
    public class MultiChannel : IEngine
    {
        private IAgoraRtcEngine rtc_engine = null;
        private IAgoraRtcEngineEventHandler event_handler = null;
        private IAgoraRtcVideoFrameObserver video_frame_observer = null;

        internal static IAgoraRtcChannel channel1 = null;
        internal static IAgoraRtcChannel channel2 = null;

        // must
        protected string app_id = "";
        protected string channel_id = "";

        // not necessary
        private readonly string SCENE_TAG = "[MultiChannel] ";

        internal override string getSDKVersion()
        {
            if (null == rtc_engine)
            {
                rtc_engine = AgoraRtcEngine.CreateAgoraRtcEngine();
                if (rtc_engine == null)
                    CSharpForm.dump_handler(SCENE_TAG + "getSDKVersion CreateEngine", -1);
            }
            return rtc_engine.GetVersion();
        }

        internal override IAgoraRtcEngine getEngine()
        {
            if (null == rtc_engine)
            {
                rtc_engine = AgoraRtcEngine.CreateAgoraRtcEngine();
                if (rtc_engine == null)
                    CSharpForm.dump_handler(SCENE_TAG + "getEngine CreateEngine", -1);
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
                    CSharpForm.dump_handler(SCENE_TAG + "CreateEngine", -1);
                    return -1;
                }
            }

            event_handler = new MultiChannelEventHandler();
            rtc_engine.InitEventHandler(event_handler);

            //// raw data
            //video_frame_observer = new MultiChannelVideoFrameObserver();
            //rtc_engine.RegisterVideoFrameObserver(video_frame_observer);

            RtcEngineContext rtc_engine_ctx = new RtcEngineContext(app_id);
            ret = rtc_engine.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler(SCENE_TAG + "Initialize", ret);

            ret = rtc_engine.EnableVideo();
            CSharpForm.dump_handler(SCENE_TAG + "EnableVideo", ret);

            ret = rtc_engine.EnableAudio();
            CSharpForm.dump_handler(SCENE_TAG + "EnableAudio", ret);

            channel1 = rtc_engine.CreateChannel(channelId);
            ret = channel1.SetClientRole(CLIENT_ROLE_TYPE.CLIENT_ROLE_AUDIENCE, new ClientRoleOptions());
            CSharpForm.dump_handler(SCENE_TAG + "SetClientRole(ch1)", ret);

            //channel2 = rtc_engine.CreateChannel(channelId);
            //ret = channel2.SetClientRole(CLIENT_ROLE_TYPE.CLIENT_ROLE_AUDIENCE);
            //CSharpForm.dump_handler(SCENE_TAG + "SetClientRole(ch2)", ret);

            return ret;
        }

        internal override int unInit()
        {
            int ret = -1;

            if (null != rtc_engine)
            {
                ret = rtc_engine.LeaveChannel();
                CSharpForm.dump_handler(SCENE_TAG + "LeaveChannel", ret);

                //rtc_engine.StopPreview();  // pair with StartPreview
                //if (0 == ret)
                //    Console.WriteLine("StopPreview failed!!!, ret={0}", ret);

                ret = rtc_engine.DisableVideo();   // pair with EnableVideo
                CSharpForm.dump_handler(SCENE_TAG + "DisableVideo", ret);

                ret = rtc_engine.DisableAudio();   // pair with EnableAudio
                CSharpForm.dump_handler(SCENE_TAG + "DisableAudio", ret);

                rtc_engine.Dispose();
                rtc_engine = null;
            }
            return ret;
        }

        internal override int joinChannel()
        {
            int ret = -1;

            if (null != rtc_engine)
            {
                ret = rtc_engine.JoinChannel("", channel_id, "info");
                CSharpForm.dump_handler(SCENE_TAG + "JoinChannel", ret);
            }
            return ret;
        }

        internal override int leaveChannel()
        {
            int ret = -1;

            if (null != rtc_engine)
            {
                ret = rtc_engine.LeaveChannel();
                CSharpForm.dump_handler(SCENE_TAG + "LeaveChannel", ret);
            }

            if (null != channel1)
            {
                ret = channel1.MuteLocalAudioStream(true);
                CSharpForm.dump_handler(SCENE_TAG + "MuteLocalAudioStream", ret);
                ret = channel1.MuteLocalVideoStream(true);
                CSharpForm.dump_handler(SCENE_TAG + "MuteLocalVideoStream", ret);
            }


            return ret;
        }
    }

    // override if need
    internal class MultiChannelEventHandler : IAgoraRtcEngineEventHandler
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

            if (null != MultiChannel.channel1)
            {
                ret = MultiChannel.channel1.MuteLocalAudioStream(false);
                Console.WriteLine("----->MuteLocalAudioStream, ret={0}", ret);
                //CSharpForm.dump_handler(SCENE_TAG + "MuteLocalAudioStream", ret);
                ret = MultiChannel.channel1.MuteLocalVideoStream(false);
                Console.WriteLine("----->MuteLocalVideoStream, ret={0}", ret);
                //CSharpForm.dump_handler(SCENE_TAG + "MuteLocalVideoStream", ret);
            }

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

        //public override void OnAudioMixingStateChanged(AUDIO_MIXING_STATE_TYPE state, AUDIO_MIXING_REASON_TYPE reason)
        //{
        //    Console.WriteLine("----->OnAudioMixingStateChanged, state={0} reason={1}", state, reason);
        //}

        public override void OnRemoteVideoStats(RemoteVideoStats stats)
        {
            Console.WriteLine("----->OnRemoteVideoStats, stats={0}", stats);
        }

        public override void OnRemoteAudioStats(RemoteAudioStats stats)
        {
            Console.WriteLine("----->OnRemoteAudioStats, stats={0}", stats);
        }
    }

    // override if need
    internal class MultiChannelVideoFrameObserver : IAgoraRtcVideoFrameObserver
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
