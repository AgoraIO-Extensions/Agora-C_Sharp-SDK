using System;
using System.Drawing;

using System.Runtime.InteropServices;

namespace C_Sharp_API_Example.src.Advanced.CustomRender
{
    public abstract class BaseRender
    {
        #region interfaces
        public enum CustomVideoBoxRenderType
        {
            kBufferedGraphics,
            kSharpDX_BGRA,
            kSharpDX_YUV420
        }

        public enum DataType
        {
            kBGRA,
            kYUV420
        }

        public abstract void Dispose();

        public abstract CustomVideoBoxRenderType GetRenderType();

        public abstract bool Initialize(IntPtr handle, Size size, DataType dataType);

        public abstract void UpdateSize(Size size);

        public abstract void DeliverFrame(Agora.Rtc.VideoFrame videoFrame);

        public abstract bool NeedInvoke();

        #endregion // interfaces

        #region unmanaged helper
        [DllImport("kernel32.dll", EntryPoint = "RtlMoveMemory")]
        protected static extern void CopyMemory(IntPtr Destination, IntPtr Source, int Length);
        #endregion //unmanaged helper

        #region managed helper
        private int fps_current_ = 0;
        private int fps_frame_count_ = 0;
        private System.Windows.Forms.Timer fps_timer_ = null;

        protected void StartFpsTimer()
        {
            fps_current_ = 0;
            fps_frame_count_ = 0;

            fps_timer_ = new System.Windows.Forms.Timer();
            fps_timer_.Interval = 1000;
            fps_timer_.Tick += OnFpsTimerEvent;
            fps_timer_.Start();
        }

        protected void StopFpsTimer()
        {
            if (fps_timer_ != null)
                fps_timer_.Stop();
        }

        protected void FeedOneFrame()
        {
            fps_frame_count_++;
        }

        protected int GetCurrentFps()
        {
            return fps_current_;
        }

        private void OnFpsTimerEvent(object? sender, EventArgs e)
        {
            int tmp_frame_count = fps_frame_count_;

            if (tmp_frame_count == 0)
                fps_current_ = 0;
            else
                fps_current_ = 1000 / tmp_frame_count;

            fps_frame_count_ = 0;
        }


        protected virtual Rectangle CalcDestRectangle(Size srcSize, Size dstSize)
        {
            float ratio_src = (float)srcSize.Width / (float)srcSize.Height;
            float ratio_dst = (float)dstSize.Width / (float)dstSize.Height;

            Rectangle dest_rectangle;

            if (ratio_src > ratio_dst)
            {
                float scale_ratio = (float)srcSize.Width / (float)dstSize.Width;
                int new_height = (int)((float)srcSize.Height / scale_ratio);

                dest_rectangle = new Rectangle(0, (dstSize.Height - new_height) / 2, dstSize.Width, new_height);
            }
            else
            {
                float scale_ratio = (float)srcSize.Height / (float)dstSize.Height;

                int new_width = (int)((float)srcSize.Width / scale_ratio);

                dest_rectangle = new Rectangle((dstSize.Width - new_width) / 2, 0, new_width, dstSize.Height);
            }

            return dest_rectangle;
        }

        protected virtual int OddRectangleValue(int value)
        {
            if (value % 2 == 0)
                return value;

            if (value > 1)
                return value - 1;
            else
                return value + 1;
        }
        #endregion // managed helper
    }
}
