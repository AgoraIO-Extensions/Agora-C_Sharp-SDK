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
    public class Audio1To1 : IEngine
    {
        private IAgoraRtcEngine rtc_engine = null;
        private IAgoraRtcEngineEventHandler event_handler = null;
        private IAgoraRtcAudioFrameObserver video_frame_observer = null;
        // must
        protected string app_id = "";
        protected string channel_id = "";

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

            event_handler = new Audio1To1EventHandler();
            rtc_engine.InitEventHandler(event_handler);

            //// raw data
            video_frame_observer = new Audio1To1AudioFrameObserver();
            rtc_engine.RegisterAudioFrameObserver(video_frame_observer);

            RtcEngineContext rtc_engine_ctx = new RtcEngineContext(app_id);
            ret = rtc_engine.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler("Initialize", ret);

            ret = rtc_engine.EnableAudio();
            CSharpForm.dump_handler("EnableAudio", ret);

            return ret;
        }

        internal override int unInit()
        {
            int ret = -1;
            if (null != rtc_engine)
            {
                ret = rtc_engine.LeaveChannel();
                CSharpForm.dump_handler("LeaveChannel", ret);

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
            if (null != rtc_engine)
            {
                ret = rtc_engine.LeaveChannel();
                CSharpForm.dump_handler("LeaveChannel", ret);
            }
            return ret;
        }
    }

    // override if need
    internal class Audio1To1EventHandler : IAgoraRtcEngineEventHandler
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
            Console.WriteLine("----->OnJoinChannelSuccess channel={0} uid={1}", channel, uid);
        }

        public override void OnRejoinChannelSuccess(string channel, uint uid, int elapsed)
        {
            Console.WriteLine("OnRejoinChannelSuccess");
        }

        public override void OnLeaveChannel(RtcStats stats)
        {
            Console.WriteLine("----->OnLeaveChannel duration={0}", stats.duration);
        }

        public override void OnUserJoined(uint uid, int elapsed)
        {
            Console.WriteLine("----->OnUserJoined uid={0} elapsed={1}", uid, elapsed);
        }

        public override void OnUserOffline(uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline reason={0}", reason);
        }
    }

    // override if need
    internal class Audio1To1AudioFrameObserver : IAgoraRtcAudioFrameObserver
    {
        //public override bool OnMixedAudioFrame(AudioFrame audioFrame)
        //{
        //    Console.WriteLine("----->OnMixedAudioFrame");
        //    return true;
        //}

        //public override bool OnPlaybackAudioFrame(AudioFrame audioFrame)
        //{
        //    Console.WriteLine("----->OnPlaybackAudioFrame");
        //    return true;
        //}

        //public override bool OnPlaybackAudioFrameBeforeMixing(uint uid, AudioFrame audioFrame)
        //{
        //    Console.WriteLine("----->OnPlaybackAudioFrameBeforeMixing uid={0}", uid);
        //    return true;
        //}

        //public override bool OnPlaybackAudioFrameBeforeMixingEx(string channelId, uint uid, AudioFrame audioFrame)
        //{
        //    Console.WriteLine("----->OnPlaybackAudioFrameBeforeMixingEx channedId={0} uid={1}", channelId, uid);
        //    return true;
        //}

        //public override bool OnRecordAudioFrame(AudioFrame audioFrame)
        //{
        //    return true;
        //}
    }
}
