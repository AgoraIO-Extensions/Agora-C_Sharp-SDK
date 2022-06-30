/// <summary>
/// [Raw data callback] Key Step ：
/// 1. Create Engine and initialize, override IAgoraRtcVideoFrameObserver and IAgoraRtcAudioFrameObserver, the register obsevers：
/// （CreateAgoraRtcEngine、Initialize、[SetLogFile]、[InitEventHandler]、[RegisterVideoFrameObserver]）
/// 
/// 2. Join Channel：（[EnableAudio]、EnableVideo、JoinChannel）
/// 
/// 3. Leave Channel：（LeaveChannel）
/// 
/// 4. Exit：（Dispose）
/// <summary>

using System;
using System.Threading;
using agora.rtc;

namespace CSharp_API_Example
{
    public class ProcessRawData : IEngine
    {
        private string app_id_ = "";
        private string channel_id_ = "";
        private readonly string ProcessRawData_TAG = "[ProcessRawData] ";
        private readonly string agora_sdk_log_file_path_ = "agorasdk.log";
        private IAgoraRtcEngine rtc_engine_ = null;
        private IAgoraRtcEngineEventHandler event_handler_ = null;
        private IAgoraRtcVideoFrameObserver video_frame_observer = null;
        private IAgoraRtcAudioFrameObserver audio_frame_observer = null;
        private IntPtr local_win_id_ = IntPtr.Zero;
        private IntPtr remote_win_id_ = IntPtr.Zero;

        public ProcessRawData(IntPtr localWindowId, IntPtr remoteWindowId)
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

            event_handler_ = new ProcessRawDataEventHandler(this);
            rtc_engine_.InitEventHandler(event_handler_);

            LogConfig log_config = new LogConfig(agora_sdk_log_file_path_);
            RtcEngineContext rtc_engine_ctx = new RtcEngineContext(app_id_, AREA_CODE.AREA_CODE_GLOB, log_config);
            ret = rtc_engine_.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler_(ProcessRawData_TAG + "Initialize", ret);

            audio_frame_observer = new ProcessRawDataAudioFrameObserver();
            rtc_engine_.RegisterAudioFrameObserver(audio_frame_observer);

            video_frame_observer = new ProcessRawDataVideoFrameObserver();
            rtc_engine_.RegisterVideoFrameObserver(video_frame_observer);

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(ProcessRawData_TAG + "LeaveChannel", ret);

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
                CSharpForm.dump_handler_(ProcessRawData_TAG + "EnableAudio", ret);

                ret = rtc_engine_.EnableVideo();
                CSharpForm.dump_handler_(ProcessRawData_TAG + "EnableVideo", ret);

                ret = rtc_engine_.JoinChannel("", channel_id_, "info");
                CSharpForm.dump_handler_(ProcessRawData_TAG + "JoinChannel", ret);
            }
            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(ProcessRawData_TAG + "LeaveChannel", ret);
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
    internal class ProcessRawDataAudioFrameObserver : IAgoraRtcAudioFrameObserver
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
    internal class ProcessRawDataVideoFrameObserver : IAgoraRtcVideoFrameObserver
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
    internal class ProcessRawDataEventHandler : IAgoraRtcEngineEventHandler
    {
        private ProcessRawData processRawData_inst_ = null;

        public ProcessRawDataEventHandler(ProcessRawData _processRawData) {
            processRawData_inst_ = _processRawData;
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
            VideoCanvas vs = new VideoCanvas((ulong)processRawData_inst_.GetLocalWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, channel);
            int ret = processRawData_inst_.GetEngine().SetupLocalVideo(vs);
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
            if (processRawData_inst_.GetRemoteWinId() == IntPtr.Zero) return;
            var vc = new VideoCanvas((ulong)processRawData_inst_.GetRemoteWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, processRawData_inst_.GetChannelId(), uid);
            int ret = processRawData_inst_.GetEngine().SetupRemoteVideo(vc);
            Console.WriteLine("----->SetupRemoteVideo, ret={0}", ret);
        }

        public override void OnUserOffline(uint uid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline reason={0}", reason);
        }
    }
}
