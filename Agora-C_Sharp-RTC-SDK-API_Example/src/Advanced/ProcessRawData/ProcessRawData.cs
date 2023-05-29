using System;
using System.Threading;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    public class ProcessRawData : IEngine
    {
        private readonly string ProcessRawData_TAG = "[ProcessRawData] ";
        private readonly string log_file_path = ".\\logs\\agora.log";
        private IVideoFrameObserver video_frame_observer = null;
        private IAudioFrameObserver audio_frame_observer = null;
        private ProcessRawDataView view_ = null;

        public ProcessRawData(System.Windows.Forms.UserControl view)
        {
            view_ = (ProcessRawDataView)view;
        }

        internal override int Init(string appId)
        {
            int ret = -1;

            if (null == rtc_engine_)
            {
                rtc_engine_ = RtcEngine.CreateAgoraRtcEngine();
            }

            // Prepare engine context
            RtcEngineContext rtc_engine_ctx = new RtcEngineContext();
            rtc_engine_ctx.appId = appId;
            rtc_engine_ctx.logConfig.filePath = log_file_path;

            // Initialize engine
            ret = rtc_engine_.Initialize(rtc_engine_ctx);
            MainForm.dump_handler_(ProcessRawData_TAG + "Initialize", ret);

            // Register event handler
            ret = rtc_engine_.InitEventHandler(this);
            MainForm.dump_handler_(ProcessRawData_TAG + "InitEventHandler", ret);

            // Register audio frame observer
            audio_frame_observer = new ProcessRawDataAudioFrameObserver();
            ret = rtc_engine_.RegisterAudioFrameObserver(audio_frame_observer);
            MainForm.dump_handler_(ProcessRawData_TAG + "RegisterAudioFrameObserver", ret);

            // Register video frame observer
            video_frame_observer = new ProcessRawDataVideoFrameObserver();
            ret = rtc_engine_.RegisterVideoFrameObserver(video_frame_observer);
            MainForm.dump_handler_(ProcessRawData_TAG + "RegisterVideoFrameObserver", ret);

            // Enable video module
            ret = rtc_engine_.EnableVideo();
            MainForm.dump_handler_(ProcessRawData_TAG + "EnableVideo", ret);

            // Enable local video
            ret = rtc_engine_.EnableLocalVideo(true);
            MainForm.dump_handler_(ProcessRawData_TAG + "EnableLocalVideo", ret);

            // Start preview
            ret = rtc_engine_.StartPreview(VIDEO_SOURCE_TYPE.VIDEO_SOURCE_CAMERA_PRIMARY);
            MainForm.dump_handler_(ProcessRawData_TAG + "StartPreview", ret);

            // Setup local video
            VideoCanvas canvas = new VideoCanvas();
            canvas.view = (long)view_.localVideoView.Handle;
            canvas.renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT;

            ret = rtc_engine_.SetupLocalVideo(canvas);
            MainForm.dump_handler_(ProcessRawData_TAG + "SetupLocalVideo", ret);

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                // Stop preview
                ret = rtc_engine_.StopPreview();
                MainForm.dump_handler_(ProcessRawData_TAG + "StopPreview", ret);

                // Disable video module
                ret = rtc_engine_.DisableVideo();
                MainForm.dump_handler_(ProcessRawData_TAG + "DisableVideo", ret);

                // Leave channel
                ret = rtc_engine_.LeaveChannel();
                MainForm.dump_handler_(ProcessRawData_TAG + "LeaveChannel", ret);

                // Dispose engine
                rtc_engine_.Dispose();
                rtc_engine_ = null;
            }
            return ret;
        }

        internal override int JoinChannel(string channelId)
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ChannelMediaOptions options = new ChannelMediaOptions();
                options.channelProfile.SetValue(CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING);
                options.clientRoleType.SetValue(CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);

                ret = rtc_engine_.JoinChannel("", channelId.Split(';').GetValue(0).ToString(), 0, options);

                MainForm.dump_handler_(ProcessRawData_TAG + "JoinChannel", ret);
            }
            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                MainForm.dump_handler_(ProcessRawData_TAG + "LeaveChannel", ret);
            }
            return ret;
        }

        // override IRtcEngineEventHandler
        public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
        {
            Console.WriteLine("----->OnUserJoined uid={0}", remoteUid);

            VideoCanvas canvas = new VideoCanvas();
            canvas.view = (long)view_.remoteVideoView.Handle;
            canvas.renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT;
            canvas.uid = remoteUid;

            int ret = rtc_engine_.SetupRemoteVideo(canvas);
            Console.WriteLine("----->SetupRemoteVideo, ret={0}", ret);
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
}
