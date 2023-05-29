using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace C_Sharp_API_Example.src.Advanced.CustomRender
{
    public partial class CustomVideoBox : UserControl
    {
        private BaseRender render_ = null;
        private BaseRender.CustomVideoBoxRenderType type_ = BaseRender.CustomVideoBoxRenderType.kBufferedGraphics;
        private bool rendering_ = false;

        private object obj_ = new object();

        public CustomVideoBox()
        {
            InitializeComponent();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            lock (obj_)
            {
                if (render_ != null)
                {
                    if (render_.NeedInvoke())
                    {
                        this.Invoke(new Action(() =>
                        {
                            render_.UpdateSize(this.Size);
                        }));
                    }
                    else
                    {
                        render_.UpdateSize(this.Size);
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }


        public void SetRenderType(BaseRender.CustomVideoBoxRenderType type)
        {
            if (type_ == type) return;

            type_ = type;

            lock (obj_)
            {
                // only create render when first frame came in case that we do not want draw background by ourself
                // coze we will set style with AllPaintingInWmPaint true...
                if (render_ != null)
                    this.ReInitRender();
            }
        }

        private void ReInitRender()
        {

            if (render_ != null && render_.GetRenderType() == type_)
            {
                return;
            }

            if (render_ != null)
            {
                render_.Dispose();
                render_ = null;
            }

            BaseRender.DataType data_type = BaseRender.DataType.kBGRA;

            switch (type_)
            {
                case BaseRender.CustomVideoBoxRenderType.kBufferedGraphics:
                    this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                    this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                    this.SetStyle(ControlStyles.UserPaint, false);
                    render_ = new BufferedGraphicsRender(this.CreateGraphics());
                    data_type = BaseRender.DataType.kBGRA;
                    break;
                case BaseRender.CustomVideoBoxRenderType.kSharpDX_BGRA:
                    this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                    this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                    this.SetStyle(ControlStyles.UserPaint, false);
                    render_ = new SharpDXRender();
                    data_type = BaseRender.DataType.kBGRA;
                    break;
                case BaseRender.CustomVideoBoxRenderType.kSharpDX_YUV420:
                    this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                    this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                    this.SetStyle(ControlStyles.UserPaint, false);
                    render_ = new SharpDXRender();
                    data_type = BaseRender.DataType.kYUV420;
                    break;
                default:
                    break;
            }

            if (render_ != null && render_.Initialize(this.Handle, this.Size, data_type) != true)
            {
                render_.Dispose();
                render_ = null;
            }
        }

        public void DeliverFrame(Agora.Rtc.VideoFrame videoFrame)
        {
            lock (obj_)
            {
                if (render_ == null)
                {
                    this.Invoke(new Action(() =>
                    {
                        ReInitRender();
                    }));
                }

                if (render_.NeedInvoke())
                {
                    this.Invoke(new Action(() =>
                    {
                        render_.DeliverFrame(videoFrame);
                    }));
                }
                else
                {
                    render_.DeliverFrame(videoFrame);
                }
            }
        }
    }
}
