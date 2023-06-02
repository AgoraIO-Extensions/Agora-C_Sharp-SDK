using System;
using System.Drawing;

// https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bufferedgraphics?view=dotnet-plat-ext-7.0
// https://www.codeproject.com/Articles/409988/Beginners-Starting-a-2D-Game-with-GDIplus

namespace C_Sharp_API_Example.src.Advanced.CustomRender
{
    class BufferedGraphicsRender : BaseRender
    {
        private bool disposing_ = false;

        private BufferedGraphics grafx_ = null;
        private Graphics gra_ = null;

        private Size control_size_ = new Size(0, 0);
        private Size frame_size_ = new Size(0, 0);

        private System.Windows.Forms.Timer timer_ = new System.Windows.Forms.Timer();

        private Object obj_ = new object();
        private Bitmap[] images_ = new Bitmap[2];
        private int present_index_ = 1;
        private int backend_index_ = 0;

        public BufferedGraphicsRender(Graphics gra)
        {
            gra_ = gra;
        }

        #region override BaseRender
        public override void Dispose()
        {
            disposing_ = true;

            timer_.Stop();

            if (grafx_ != null)
            {
                grafx_.Dispose();
                grafx_ = null;
            }

            // Stop fps counter
            StopFpsTimer();
        }

        public override CustomVideoBoxRenderType GetRenderType()
        {
            return CustomVideoBoxRenderType.kBufferedGraphics;
        }

        public override bool Initialize(IntPtr handle, Size size, DataType dataType)
        {
            control_size_ = size;

            AllocatteBufferedGraphics(size);
            if (grafx_ == null)
                return false;

            // Set render timer
            timer_.Tick += OnRenderTimer;
            timer_.Interval = 30;

            if (!timer_.Enabled)
                timer_.Start();

            // Start fps counter
            StartFpsTimer();

            return true;
        }

        public override void UpdateSize(Size size)
        {
            if (control_size_.Width == size.Width && control_size_.Height == size.Height)
                return;


            if (grafx_ != null)
            {
                grafx_.Dispose();
                grafx_ = null;
            }

            // ReAllocate graphics buffer with new size
            AllocatteBufferedGraphics(size);

            control_size_ = size;
        }

        public override void DeliverFrame(Agora.Rtc.VideoFrame videoFrame)
        {
            if (disposing_ == true || videoFrame == null) return;

            // Only accpet frame with VIDEO_PIXEL_BGRA
            if (videoFrame.type != Agora.Rtc.VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_BGRA)
                return;

            frame_size_.Width = videoFrame.width;
            frame_size_.Height = videoFrame.height;

            // Lock backend index to write frame data into backend buffer
            lock (obj_)
            {
                if (images_[backend_index_] == null ||
                    images_[backend_index_].Width != videoFrame.width ||
                    images_[backend_index_].Height != videoFrame.height)
                {
                    images_[backend_index_] = new Bitmap(videoFrame.width,
                        videoFrame.height,
                        videoFrame.yStride,
                        System.Drawing.Imaging.PixelFormat.Format32bppArgb,
                        videoFrame.yBufferPtr);
                }
                else
                {
                    var data = images_[backend_index_].LockBits(new Rectangle(0, 0, images_[backend_index_].Width, images_[backend_index_].Height),
                        System.Drawing.Imaging.ImageLockMode.WriteOnly,
                        images_[backend_index_].PixelFormat);
                    for (int i = 0; i < videoFrame.height; i++)
                    {
                        CopyMemory(data.Scan0 + data.Stride * i, videoFrame.yBufferPtr + videoFrame.yStride * i, videoFrame.yStride);
                    }
                    images_[backend_index_].UnlockBits(data);
                }
            }
        }

        public override bool NeedInvoke()
        {
            return false;
        }

        #endregion // override BaseRender

        #region buffered graphics render logic

        // allocate buffered graphics and set preferences
        private void AllocatteBufferedGraphics(Size size)
        {
            // Allocates a graphics buffer the size of this form
            // using the pixel format of the Graphics created by
            // the Form.CreateGraphics() method, which returns a
            // Graphics object that matches the pixel format of the form.
            grafx_ = BufferedGraphicsManager.Current.Allocate(gra_, new Rectangle(0, 0, size.Width, size.Height));

            // Optimize graphics
            grafx_.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            // this will bring crash when draw fps tips
            // grafx_.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            grafx_.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.AssumeLinear;
            grafx_.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            grafx_.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            grafx_.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
        }

        // swap backend to present with lock(obj_)
        private void SwapIndex()
        {
            lock (obj_)
            {
                int temp = present_index_;
                present_index_ = backend_index_;
                backend_index_ = temp;
            }
        }

        // get present buffered image and draw to buffered graphics
        private void OnRenderTimer(object? sender, EventArgs e)
        {
            if (disposing_ || grafx_ == null)
                return;

            SwapIndex();

            // Return when there is no frame arrivied or cached image size is not equal to current frame size
            if (images_[present_index_] == null || frame_size_.Width != images_[present_index_].Width || frame_size_.Height != images_[present_index_].Height)
                return;

            // Fill background with black
            grafx_.Graphics.FillRectangle(Brushes.Black, new Rectangle(0, 0, control_size_.Width, control_size_.Height));

            // Fill fps area with black background
            string tips_fps = "FPS:" + GetCurrentFps().ToString();
            SizeF tips_fps_size = grafx_.Graphics.MeasureString(tips_fps, SystemFonts.DefaultFont);
            Rectangle tips_fps_rect = new Rectangle(control_size_.Width - 50, 10, (int)tips_fps_size.Width, (int)tips_fps_size.Height);

            // Draw image to calced area
            grafx_.Graphics.DrawImage(images_[present_index_], CalcDestRectangle(images_[present_index_].Size, control_size_), new Rectangle(0, 0, images_[present_index_].Width, images_[present_index_].Height), GraphicsUnit.Pixel);

            // Draw current fps
            grafx_.Graphics.DrawString(tips_fps, SystemFonts.DefaultFont, Brushes.Red, tips_fps_rect.X, tips_fps_rect.Y);

            // Feed one frame into fps counter
            FeedOneFrame();


            // Update to specified graphics obj by handle
            try
            {
                grafx_.Render(gra_);
            }
            catch (Exception exception)
            {
            }
        }

        #endregion // buffered graphics render logic
    }
}
