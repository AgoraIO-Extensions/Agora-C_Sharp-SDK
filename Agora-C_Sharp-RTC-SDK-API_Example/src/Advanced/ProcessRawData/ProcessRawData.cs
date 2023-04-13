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
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    public class ProcessRawData : IEngine
    {
        private string app_id_ = "";
        private string channel_id_ = "";
        private readonly string ProcessRawData_TAG = "[ProcessRawData] ";
        private readonly string log_file_path = ".\\logs\\agora.log";
        private IRtcEngine rtc_engine_ = null;
        private IRtcEngineEventHandler event_handler_ = null;
        private IVideoFrameObserver video_frame_observer = null;
        private IAudioFrameObserver audio_frame_observer = null;
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
                rtc_engine_ = RtcEngine.CreateAgoraRtcEngine();
            }

            RtcEngineContext rtc_engine_ctx = new RtcEngineContext(app_id_, 0, CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING, AUDIO_SCENARIO_TYPE.AUDIO_SCENARIO_DEFAULT);
            ret = rtc_engine_.Initialize(rtc_engine_ctx);
            CSharpForm.dump_handler_(ProcessRawData_TAG + "Initialize", ret);

            event_handler_ = new ProcessRawDataEventHandler(this);
            rtc_engine_.InitEventHandler(event_handler_);

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
            int build = 0;
            return rtc_engine_.GetVersion(ref build);
        }

        internal override IRtcEngine GetEngine()
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
    internal class ProcessRawDataAudioFrameObserver : IAudioFrameObserver
    {
        public override bool OnRecordAudioFrame(string channelId, AudioFrame audioFrame)
        {
            Console.WriteLine($"----->OnRecordAudioFrame samplesPerSec:{audioFrame.samplesPerSec}");
            return true;
        }

        public override bool OnPlaybackAudioFrame(string channelId, AudioFrame audioFrame)
        {
            Console.WriteLine($"----->OnPlaybackAudioFrame samples:{audioFrame.samplesPerSec}");
            return true;
        }

        public override bool OnMixedAudioFrame(string channelId, AudioFrame audioFrame)
        {
            Console.WriteLine($"----->OnMixedAudioFrame channels:{audioFrame.channels}");
            return true;
        }

        public override bool OnEarMonitoringAudioFrame(AudioFrame audioFrame)
        {
            Console.WriteLine($"----->OnEarMonitoringAudioFrame samples:{audioFrame.samplesPerSec}");
            return true;
        }

        public override bool OnPlaybackAudioFrameBeforeMixing(string channelId, uint uid, AudioFrame audioFrame)
        {
            Console.WriteLine($"----->OnPlaybackAudioFrameBeforeMixing uid={uid}");
            return true;
        }

        public override bool OnPlaybackAudioFrameBeforeMixing(string channel_id,
                                                        string userId,
                                                        AudioFrame audio_frame)
        {
            Console.WriteLine($"----->OnPlaybackAudioFrameBeforeMixing uid={userId}");
            return true;
        }
    }

    // override if need
    internal class ProcessRawDataVideoFrameObserver : IVideoFrameObserver
    {
        public override bool OnCaptureVideoFrame(VIDEO_SOURCE_TYPE sourceType, VideoFrame videoFrame)
        {
            Console.WriteLine($"----->OnCaptureVideoFrame {Thread.CurrentThread.ManagedThreadId} sourceType={sourceType}");
            return true;
        }

        public override bool OnPreEncodeVideoFrame(VIDEO_SOURCE_TYPE sourceType, VideoFrame videoFrame)
        {
            Console.WriteLine($"----->OnPreEncodeVideoFrame {Thread.CurrentThread.ManagedThreadId} sourceType={sourceType}");
            return true;
        }

        public override bool OnMediaPlayerVideoFrame(VideoFrame videoFrame, int mediaPlayerId)
        {
            Console.WriteLine($"----->OnMediaPlayerVideoFrame {Thread.CurrentThread.ManagedThreadId} mediaPlayerId={mediaPlayerId}");
            return true;
        }

        public override bool OnRenderVideoFrame(string channelId, uint remoteUid, VideoFrame videoFrame)
        {
            Console.WriteLine($"----->OnRenderVideoFrame {Thread.CurrentThread.ManagedThreadId} remoteUid={remoteUid}");
            return true;
        }

        public override bool OnTranscodedVideoFrame(VideoFrame videoFrame)
        {
            Console.WriteLine($"----->OnTranscodedVideoFrame {Thread.CurrentThread.ManagedThreadId}");
            return true;
        }

        public override VIDEO_OBSERVER_FRAME_TYPE GetVideoFormatPreference()
        {
            return VIDEO_OBSERVER_FRAME_TYPE.FRAME_TYPE_YUV420;  // default:FRAME_TYPE_RGBA
        }

        public override VIDEO_OBSERVER_POSITION GetObservedFramePosition()
        {
            return VIDEO_OBSERVER_POSITION.POSITION_POST_CAPTURER | VIDEO_OBSERVER_POSITION.POSITION_PRE_RENDERER | VIDEO_OBSERVER_POSITION.POSITION_PRE_ENCODER;
        }
    }

    // override if need
    internal class ProcessRawDataEventHandler : IRtcEngineEventHandler
    {
        private ProcessRawData processRawData_inst_ = null;

        public ProcessRawDataEventHandler(ProcessRawData _processRawData)
        {
            processRawData_inst_ = _processRawData;
        }

        public override void OnError(int error, string msg)
        {
            Console.WriteLine("=====>OnError {0} {1}", error, msg);
        }

        public override void OnJoinChannelSuccess(RtcConnection connection, int elapsed)
        {
            Console.WriteLine("----->OnJoinChannelSuccess channel={0} uid={1}", connection.channelId, connection.localUid);
            VideoCanvas vs = new VideoCanvas((long)processRawData_inst_.GetLocalWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO, 0);
            int ret = processRawData_inst_.GetEngine().SetupLocalVideo(vs);
            Console.WriteLine("----->SetupLocalVideo ret={0}", ret);
        }

        public override void OnLeaveChannel(RtcConnection connection, RtcStats stats)
        {
            Console.WriteLine("----->OnLeaveChannel duration={0}", stats.duration);
        }

        public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
            Console.WriteLine("----->OnUserJoined uid={0}", remoteUid);
            if (processRawData_inst_.GetRemoteWinId() == IntPtr.Zero) return;
            var vc = new VideoCanvas((long)processRawData_inst_.GetRemoteWinId(), RENDER_MODE_TYPE.RENDER_MODE_FIT, VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_AUTO, remoteUid);
            int ret = processRawData_inst_.GetEngine().SetupRemoteVideo(vc);
            Console.WriteLine("----->SetupRemoteVideo, ret={0}", ret);
        }

        public override void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
            Console.WriteLine("----->OnUserOffline, channel={0}, remoteUid={1}, reason={2}", connection.channelId, remoteUid, reason);
        }
    }
}
