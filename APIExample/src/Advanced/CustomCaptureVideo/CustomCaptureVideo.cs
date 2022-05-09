/*
 * 【自采集自渲染】关键步骤：
 * 1. 创建Engine并初始化
 * （CreateAgoraRtcEngine、Initialize、[SetLogFile]、[InitEventHandler]）
 * 
 * 2. 加入频道：（EnableVideo、SetExternalVideoSource、JoinChannel）
 * 
 * 3. 将视频帧传给SDK：（PushVideoFrame）
 * 
 * 4. 离开频道：（LeaveChannel）
 * 
 * 5. 退出：（Dispose）
 */

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Timers;
using agora.rtc;

namespace CSharp_API_Example
{
    public class CustomCaptureVideo : IEngine
    {
        private string app_id_ = "";
        private string channel_id_ = "";
        private readonly string CustomCaptureVideo_TAG = "[CustomCaptureVideo] ";
        private readonly string agora_sdk_log_file_path_ = "agorasdk.log";
        private IAgoraRtcEngine rtc_engine_ = null;
        private IAgoraRtcEngineEventHandler event_handler_ = null;
        private IntPtr local_win_id_ = IntPtr.Zero;
        private IntPtr remote_win_id_ = IntPtr.Zero;
        private CameraHelper camera_ = null;
        private ElapsedEventHandler render_handler_ = null;
        private Timer timer_ = null;
        private System.Windows.Forms.PictureBox local_video_view_;
        private int fps_ = 25;

        public CustomCaptureVideo(IntPtr localWindowId, IntPtr remoteWindowId, System.Windows.Forms.PictureBox localVideoView)
        {
            local_win_id_ = localWindowId;
            remote_win_id_ = remoteWindowId;
            local_video_view_ = localVideoView;
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
            CSharpForm.dump_handler_(CustomCaptureVideo_TAG + "Initialize", ret);

            event_handler_ = new CustomCaptureVideoEventHandler(this);
            rtc_engine_.InitEventHandler(event_handler_);

            return ret;
        }

        internal override int UnInit()
        {
            int ret = -1;
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(CustomCaptureVideo_TAG + "LeaveChannel", ret);

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
                InitCamera();

                ret = rtc_engine_.EnableVideo();
                CSharpForm.dump_handler_(CustomCaptureVideo_TAG + "EnableVideo", ret);

                ret = rtc_engine_.SetExternalVideoSource(true, false);
                CSharpForm.dump_handler_(CustomCaptureVideo_TAG + "SetExternalVideoSource", ret);

                ret = rtc_engine_.JoinChannel("", channel_id_, "info");
                CSharpForm.dump_handler_(CustomCaptureVideo_TAG + "JoinChannel", ret);

                InitTimer();
            }
            return ret;
        }

        internal override int LeaveChannel()
        {
            int ret = -1;

            if (null != timer_)
            {
                timer_.Stop();
            }
            if(null != camera_)
            {
                camera_.Stop();
            }
            if (null != rtc_engine_)
            {
                ret = rtc_engine_.LeaveChannel();
                CSharpForm.dump_handler_(CustomCaptureVideo_TAG + "LeaveChannel", ret);
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

        private void InitCamera()
        {
            string[] devices = CameraHelper.EnumDevices();
            int cameraIndex = 0;
            if (devices.Length > 0)
            {
                Console.WriteLine("camera [{0}]:{1}", cameraIndex, devices[cameraIndex]);
                CameraHelper.VideoFormat[] formats = CameraHelper.GetVideoFormat(cameraIndex);

                if (formats.Length > 0)
                {
                    Console.WriteLine("current format[0]:{0}", formats[0]);
                    camera_ = new CameraHelper(cameraIndex, formats[0]);
                    camera_.Start();
                    render_handler_ = new ElapsedEventHandler(VideoFrameProcess);
                }
            }
        }

        private void InitTimer()
        {
            if (null == timer_)
            {
                timer_ = new Timer(1000 / fps_);
                timer_.Elapsed += render_handler_;
                timer_.AutoReset = true;  // false:执行一次, true:一直执行
                timer_.Enabled = true;  // 是否执行System.Timers.Timer.Elapsed事件
            }
            else
            {
                timer_.Start();
            }
        }

        private void VideoFrameProcess(object sender, ElapsedEventArgs e)
        {
            if (null == rtc_engine_ || null == camera_ || null == timer_ || null == render_handler_)
                return;
            timer_.Elapsed -= render_handler_;

            Bitmap image;
            PushVideoFrameInternal(out image);
            SetupLocalVideoInternal(ref image);

            GC.Collect();
            timer_.Elapsed += render_handler_;
        }

        private void PushVideoFrameInternal(out Bitmap image)
        {
            var dst_w = local_video_view_.Size.Width;
            var dst_h = local_video_view_.Size.Height;

            Bitmap src_image = camera_.GetBitmap();
            var brush = new SolidBrush(Color.Black);

            image = new Bitmap(dst_w, dst_h);
            var graphics = Graphics.FromImage(image);
            // just for higher quality output
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            float scale = Math.Min((float)dst_w / src_image.Width, (float)dst_h / src_image.Height);
            var scale_w = (int)(src_image.Width * scale);
            var scale_h = (int)(src_image.Height * scale);

            graphics.FillRectangle(brush, new RectangleF(0, 0, dst_w, dst_h));
            if (src_image != null)
                graphics.DrawImage(src_image, (dst_w - scale_w) / 2, (dst_h - scale_h) / 2, scale_w, scale_h);

            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, image.Width, image.Height);
            System.Drawing.Imaging.BitmapData bmp_data = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, image.PixelFormat);
            // Get the address of the first line.
            IntPtr ptr = bmp_data.Scan0;
            // Declare an array to hold the bytes of the bitmap.
            int bytes = bmp_data.Stride * image.Height;
            byte[] rgb_values = new byte[bytes];
            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgb_values, 0, bytes);

            VIDEO_PIXEL_FORMAT pix_fmt = VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_BGRA;
            var video_frame = new ExternalVideoFrame() { type = VIDEO_BUFFER_TYPE.VIDEO_BUFFER_RAW_DATA, buffer = rgb_values, format = pix_fmt, height = image.Height, stride = image.Width, timestamp = System.DateTime.Now.Ticks / 10000 };
            if (null != rtc_engine_)
            {
                int ret = rtc_engine_.PushVideoFrame(video_frame);
                Console.WriteLine("----->PushVideoFrame ret={0}", ret);
            }
            image.UnlockBits(bmp_data);

            graphics.Dispose();
            brush.Dispose();
            src_image.Dispose();
        }

        private void SetupLocalVideoInternal(ref Bitmap image)
        {
            local_video_view_.Image = image;
        }
    }

    // override if need
    internal class CustomCaptureVideoEventHandler : IAgoraRtcEngineEventHandler
    {
        private CustomCaptureVideo processRawData_inst_ = null;

        public CustomCaptureVideoEventHandler(CustomCaptureVideo _processRawData) {
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
