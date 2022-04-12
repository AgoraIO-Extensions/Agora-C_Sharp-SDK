/*
 * 双进程【摄像头 + 屏幕共享】关键步骤：
 * 1. 创建共享摄像头的Engine并初始化：（CreateAgoraRtcEngine、Initialize、[SetLogFile]、[InitEventHandler]）
 *    创建共享屏幕的Engine并初始化：（CreateAgoraRtcEngine(AgoraEngineType.SubProcess)、Initialize、[InitEventHandler]）
 *    
 * 2. 加入频道
 *     摄像头：（[EnableAudio]、[EnableVideo]、[MuteAllRemoteAudioStreams]、JoinChannel）
 *     共享屏幕：（StartScreenCaptureByDisplayId、EnableVideo、JoinChannel）
 *     
 * 3. 离开频道：（LeaveChannel）
 *    共享屏幕：（StopScreenCapture、LeaveChannel）
 *    摄像头：（LeaveChannel）
 *    
 * 4. 退出
 *    共享屏幕：（LeaveChannel、Dispose）
 *    摄像头：（LeaveChannel、Dispose）
 */

using System;
using agora.rtc;
using System.Collections.Generic;
namespace CSharp_API_Example
{
    public class ScreenShare : IEngine
    {
        private string app_id_ = "";
        private string channel_id_ = "";
        private readonly string ScreenShare_TAG = "[ScreenShare] ";
        private readonly string agora_sdk_log_file_path_ = "agorasdk.log";
        private IAgoraRtcEngine rtc_engine_ = null;
        private ScreenShareEventHandler event_handler_ = null;
        private IAgoraRtcEngine screen_share_engine_ = null;
        //private IAgoraRtcEngineEventHandler screen_share_event_handler_ = null;
        private IntPtr local_win_id_ = IntPtr.Zero;
        private IntPtr remote_win_id_ = IntPtr.Zero;

        public ScreenShare(IntPtr localWindowId, IntPtr remoteWindowId)
        {
            local_win_id_ = localWindowId;
            remote_win_id_ = remoteWindowId;
        }

        internal override int Init(string appId, string channelId)
        {
            int ret = -1;
            app_id_ = appId;
            channel_id_ = channelId.Split(';').GetValue(0).ToString();

            if (null == rtc_engine_)
            {
                rtc_engine_ = AgoraRtcEngine.CreateAgoraRtcEngine();
            }
            LogConfig log_config = new LogConfig(agora_sdk_log_file_path_);
            RtcEngineContext rtc_engine_ctx = new RtcEngineContext(app_id_, AREA_CODE.AREA_CODE_GLOB, log_config);
            ret = rtc_engine_.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler_("Initialize", ret);
            event_handler_ = new ScreenShareEventHandler(this);
            rtc_engine_.InitEventHandler(event_handler_);

            if (null == screen_share_engine_)
            {
                screen_share_engine_ = AgoraRtcEngine.CreateAgoraRtcEngine(AgoraEngineType.SubProcess);
            }
            ret = screen_share_engine_.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler_(ScreenShare_TAG + "Initialize", ret);

            //screen_share_event_handler_ = new ScreenShareEventHandler(this);
            //screen_share_engine_.InitEventHandler(screen_share_event_handler_);

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;

            if (null != screen_share_engine_)
            {
                ret = screen_share_engine_.LeaveChannel();
                CSharpForm.dump_handler_(ScreenShare_TAG + "LeaveChannel", ret);

                screen_share_engine_.Dispose();
                screen_share_engine_ = null;
            }

            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_("LeaveChannel", ret);

                rtc_engine_.Dispose();
                rtc_engine_ = null;
            }
            return ret;
        }

        internal override int JoinChannel()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.EnableAudio();
                CSharpForm.dump_handler_("EnableAudio", ret);

                ret = rtc_engine_.EnableVideo();
                CSharpForm.dump_handler_("EnableVideo", ret);

                // disable echo if need
                //ret = rtc_engine.MuteAllRemoteAudioStreams(true);
                //CSharpForm.dump_handler("MuteAllRemoteAudioStreams", ret);

                SIZE thumbSize = new SIZE(100, 100);
                SIZE iconSize = new SIZE(40, 40);
                ScreenCaptureSourceInfo[] info;
                ret = rtc_engine_.GetScreenCaptureSources(thumbSize, iconSize, false, out info);
                for (int i = 0; i < info.Length; ++i)
                {
                    info[i].iconImage.buffer = event_handler_.GetIconImage(info[i].sourceId);
                    info[i].thumbImage.buffer = event_handler_.GetThumbImage(info[i].sourceId);
                }

                ret = rtc_engine_.JoinChannel("", channel_id_, "info");
                CSharpForm.dump_handler_("JoinChannel", ret);
            }

            if (null != screen_share_engine_)
            {
                ret = startScreenShare();
                CSharpForm.dump_handler_(ScreenShare_TAG + "startScreenShare", ret);

                ret = screen_share_engine_.EnableVideo();
                CSharpForm.dump_handler_(ScreenShare_TAG + "EnableVideo", ret);

                ret = screen_share_engine_.JoinChannel("", channel_id_, "info");
                CSharpForm.dump_handler_(ScreenShare_TAG + "JoinChannel", ret);
            }

            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;
            if (null != screen_share_engine_)
            {
                ret = stopScreenShare();
                CSharpForm.dump_handler_(ScreenShare_TAG + "stopScreenShare", ret);
            }

            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_("LeaveChannel", ret);
            }
            return ret;
        }

        private int startScreenShare()
        {
            int ret = -1;
            if (null != screen_share_engine_)
            {
                //agora.rtc.Rectangle screenRect = new agora.rtc.Rectangle();
                //screenRect.height = Screen.PrimaryScreen.WorkingArea.Height;
                //screenRect.width = Screen.PrimaryScreen.WorkingArea.Width;
                //screenRect.x = Screen.PrimaryScreen.WorkingArea.X;
                //screenRect.y = Screen.PrimaryScreen.WorkingArea.Y;
                //ret = screen_share_engine.StartScreenCaptureByScreenRect(screenRect, regionRect, screen_para);
                //CSharpForm.dump_handler(ScreenShare_TAG + "StartScreenCaptureByScreenRect", ret);

                agora.rtc.Rectangle regionRect = new agora.rtc.Rectangle(0, 0, 1920, 1080);
                ScreenCaptureParameters screen_para = new ScreenCaptureParameters(new VideoDimensions(1920, 1080), 5, 0, true, false);

                ret = screen_share_engine_.StartScreenCaptureByDisplayId(0, regionRect, screen_para);
                CSharpForm.dump_handler_(ScreenShare_TAG + "StartScreenCaptureByDisplayId", ret);
            }
            return ret;
        }

        private int stopScreenShare()
        {
            int ret = -1;
            if (null != screen_share_engine_)
            {
                ret = screen_share_engine_.StopScreenCapture();
                CSharpForm.dump_handler_(ScreenShare_TAG + "StopScreenCapture", ret);

                ret = screen_share_engine_.LeaveChannel();
                CSharpForm.dump_handler_(ScreenShare_TAG + "LeaveChannel", ret);
            }
            return ret;
        }

        internal override string GetSDKVersion()
        {
            if (null == rtc_engine_)
                return "-" + (ERROR_CODE_TYPE.ERR_NOT_INITIALIZED).ToString();
            return rtc_engine_.GetVersion();
        }

        internal override IAgoraRtcEngine GetEngine()
        {
            return rtc_engine_;
        }

        internal string GetChannelId()
        {
            return channel_id_;
        }

        internal IntPtr GetLocalWinId()
        {
            return local_win_id_;
        }

        internal IntPtr GetRemoteWinId()
        {
            return remote_win_id_;
        }
    }

    // override if need
    internal class ScreenShareEventHandler : IAgoraRtcEngineEventHandler
    {
        private ScreenShare screenShare_inst_ = null;
        private Dictionary<ulong, byte[]> mapIconImage;
        private Dictionary<ulong, byte[]> mapThumbImage;
        public byte[] GetIconImage(ulong sourceId)
        {
            return mapIconImage[sourceId];
        }

        public byte[] GetThumbImage(ulong sourceId)
        {
            return mapThumbImage[sourceId];
        }

        public ScreenShareEventHandler(ScreenShare _screenShare)
        {
            screenShare_inst_ = _screenShare;
            mapIconImage = new Dictionary<ulong, byte[]>();
            mapThumbImage = new Dictionary<ulong, byte[]>();
        }

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
            VideoCanvas vs = new VideoCanvas((ulong)screenShare_inst_.GetLocalWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, channel);
            int ret = screenShare_inst_.GetEngine().SetupLocalVideo(vs);
            Console.WriteLine("----->SetupLocalVideo, ret={0}", ret);
        }

        public override void OnRejoinChannelSuccess(string channel, uint uid, int elapsed)
        {
            Console.WriteLine("----->OnRejoinChannelSuccess");
        }

        public override void OnLeaveChannel(RtcStats stats)
        {
            Console.WriteLine("----->OnLeaveChannel, duration={0}", stats.duration);
        }

        public override void OnUserJoined(uint uid, int elapsed)
        {
            Console.WriteLine("----->OnUserJoined, uid={0}", uid);
            if (screenShare_inst_.GetRemoteWinId() == IntPtr.Zero) return;
            var vc = new VideoCanvas((ulong)screenShare_inst_.GetRemoteWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, screenShare_inst_.GetChannelId(), uid);
            int ret = screenShare_inst_.GetEngine().SetupRemoteVideo(vc);
            Console.WriteLine("----->OnUserJoined, ret={0}", ret);
        }

        public override void OnUserOffline(uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline, reason={0}", reason);
        }

        public override void onScreenCaptureSourceThumbImage(ulong sourceId, byte[] data, uint length)
        {
            byte[] d = new byte[length];
            Buffer.BlockCopy(data, 0, d, 0, (int)length);
            mapThumbImage.Add(sourceId, d);
        }

        public override void onScreenCaptureSourceIconImage(ulong sourceId, byte[] data, uint length)
        {
            byte[] d = new byte[length];
            Buffer.BlockCopy(data, 0, d, 0, (int)length);
            mapIconImage.Add(sourceId, d);
        }
    }
}
