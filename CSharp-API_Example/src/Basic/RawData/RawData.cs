/*
 * 【祼数据回调】关键步骤：
 * 1. 创建Engine并初始化、重写IAgoraRtcVideoFrameObserver的相关接口并注册：
 * （CreateAgoraRtcEngine、Initialize、[SetLogFile]、[InitEventHandler]、[RegisterVideoFrameObserver]）
 * 
 * 2. 加入频道：（[EnableAudio]、EnableVideo、JoinChannel）
 * 
 * 3. 离开频道：（LeaveChannel）
 * 
 * 4. 退出：（Dispose）
 */

using System;
using System.Threading;
using agora.rtc;

namespace CSharp_API_Example
{
    public class RawData : IEngine
    {
        private string app_id_ = "";
        private string channel_id_ = "";
        private readonly string RawData_TAG = "[RawData] ";
        private readonly string log_file_path_ = "CSharp_API_Example.log";
        private IAgoraRtcEngine rtc_engine_ = null;
        private IAgoraRtcEngineEventHandler event_handler_ = null;
        private IAgoraRtcVideoFrameObserver video_frame_observer = null;
        private IAgoraRtcAudioFrameObserver audio_frame_observer = null;
        private IntPtr local_win_id_ = IntPtr.Zero;
        private IntPtr remote_win_id_ = IntPtr.Zero;

        public RawData(IntPtr localWindowId, IntPtr remoteWindowId)
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

            RtcEngineContext rtc_engine_ctx = new RtcEngineContext(app_id_);
            ret = rtc_engine_.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler_(RawData_TAG + "Initialize", ret);
            ret = rtc_engine_.SetLogFile(log_file_path_);
            CSharpForm.dump_handler_(RawData_TAG + "SetLogFile", ret);

            event_handler_ = new RawDataEventHandler(this);
            rtc_engine_.InitEventHandler(event_handler_);

            audio_frame_observer = new RawDataAudioFrameObserver();
            rtc_engine_.RegisterAudioFrameObserver(audio_frame_observer);

            video_frame_observer = new RawDataVideoFrameObserver();
            rtc_engine_.RegisterVideoFrameObserver(video_frame_observer);

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(RawData_TAG + "LeaveChannel", ret);

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
                CSharpForm.dump_handler_(RawData_TAG + "EnableAudio", ret);

                ret = rtc_engine_.EnableVideo();
                CSharpForm.dump_handler_(RawData_TAG + "EnableVideo", ret);

                ret = rtc_engine_.JoinChannel("", channel_id_, "info");
                CSharpForm.dump_handler_(RawData_TAG + "JoinChannel", ret);
            }
            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(RawData_TAG + "LeaveChannel", ret);
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
    internal class RawDataAudioFrameObserver : IAgoraRtcAudioFrameObserver
    {
        public override bool OnMixedAudioFrame(AudioFrame audioFrame)
        {
            Console.WriteLine($"----->OnMixedAudioFrame channels:{audioFrame.channels}");
            return true;
        }

        public override bool OnPlaybackAudioFrame(AudioFrame audioFrame)
        {
            Console.WriteLine($"----->OnPlaybackAudioFrame samples:{audioFrame.samples}");
            return true;
        }

        public override bool OnPlaybackAudioFrameBeforeMixing(uint uid, AudioFrame audioFrame)
        {
            Console.WriteLine($"----->OnPlaybackAudioFrameBeforeMixing uid={uid}");
            return true;
        }

        public override bool OnPlaybackAudioFrameBeforeMixingEx(string channelId, uint uid, AudioFrame audioFrame)
        {
            Console.WriteLine($"----->OnPlaybackAudioFrameBeforeMixingEx channelId:{channelId} uid:{uid}");
            return true;
        }

        public override bool OnRecordAudioFrame(AudioFrame audioFrame)
        {
            Console.WriteLine($"----->OnRecordAudioFrame samplesPerSec:{audioFrame.samplesPerSec}");
            return true;
        }
    }

    // override if need
    internal class RawDataVideoFrameObserver : IAgoraRtcVideoFrameObserver
    {
        public override VIDEO_OBSERVER_POSITION GetObservedFramePosition()
        {
            return VIDEO_OBSERVER_POSITION.POSITION_POST_CAPTURER | VIDEO_OBSERVER_POSITION.POSITION_PRE_RENDERER | VIDEO_OBSERVER_POSITION.POSITION_PRE_ENCODER;
        }

        public override VIDEO_FRAME_TYPE GetVideoFormatPreference()
        {
            return VIDEO_FRAME_TYPE.FRAME_TYPE_YUV420;  // default:FRAME_TYPE_RGBA
        }

        public override bool OnCaptureVideoFrame(VideoFrame videoFrame)
        {
            Console.WriteLine($"----->OnCaptureVideoFrame {Thread.CurrentThread.ManagedThreadId}");
            return true;
        }

        public override bool OnPreEncodeVideoFrame(VideoFrame videoFrame)
        {
            Console.WriteLine($"----->OnPreEncodeVideoFrame {Thread.CurrentThread.ManagedThreadId}");
            return true;
        }

        public override bool OnRenderVideoFrameEx(string channelId, uint uid, VideoFrame videoFrame)
        {
            Console.WriteLine($"----->OnRenderVideoFrameEx {Thread.CurrentThread.ManagedThreadId}");
            return true;
        }
    }

    // override if need
    internal class RawDataEventHandler : IAgoraRtcEngineEventHandler
    {
        private RawData rawData_inst_ = null;

        public RawDataEventHandler(RawData rawdata) {
            rawData_inst_ = rawdata;
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
            Console.WriteLine("----->OnJoinChannelSuccess channel={0} uid={1}", channel, uid);
            VideoCanvas vs = new VideoCanvas((ulong)rawData_inst_.GetLocalWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, channel);
            int ret = rawData_inst_.GetEngine().SetupLocalVideo(vs);
            Console.WriteLine("----->SetupLocalVideo ret={0}", ret);
        }

        public override void OnRejoinChannelSuccess(string channel, uint uid, int elapsed)
        {
            Console.WriteLine("----->OnRejoinChannelSuccess");
        }

        public override void OnLeaveChannel(RtcStats stats)
        {
            Console.WriteLine("----->OnLeaveChannel duration={0}", stats.duration);
        }

        public override void OnUserJoined(uint uid, int elapsed)
        {
            Console.WriteLine("----->OnUserJoined uid={0}", uid);
            if (rawData_inst_.GetRemoteWinId() == IntPtr.Zero) return;
            var vc = new VideoCanvas((ulong)rawData_inst_.GetRemoteWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, rawData_inst_.GetChannelId(), uid);
            int ret = rawData_inst_.GetEngine().SetupRemoteVideo(vc);
            Console.WriteLine("----->SetupRemoteVideo, ret={0}", ret);
        }

        public override void OnUserOffline(uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline reason={0}", reason);
        }
    }
}
