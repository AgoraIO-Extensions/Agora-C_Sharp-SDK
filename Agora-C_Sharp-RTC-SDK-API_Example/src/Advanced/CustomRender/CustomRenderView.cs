using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C_Sharp_API_Example.src.Advanced.CustomRender;

namespace C_Sharp_API_Example
{
    public partial class CustomRenderView : UserControl
    {
        public BaseRender.CustomVideoBoxRenderType type_ = BaseRender.CustomVideoBoxRenderType.kBufferedGraphics;

        private readonly Dictionary<BaseRender.CustomVideoBoxRenderType, string> RenderTypes = new Dictionary<BaseRender.CustomVideoBoxRenderType, string> {
            { BaseRender.CustomVideoBoxRenderType.kBufferedGraphics,"BufferedGraphics"} ,
            { BaseRender.CustomVideoBoxRenderType.kSharpDX_BGRA,"kSharpDX_BGRA"},
            { BaseRender.CustomVideoBoxRenderType.kSharpDX_YUV420,"kSharpDX_YUV420"}
        };

        public CustomRenderView()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, false);

            foreach (var render in RenderTypes)
            {
                comboRenderType.Items.Add(render.Value);
                if (type_ == render.Key)
                    comboRenderType.SelectedItem = render.Value;
            }
        }

        private void comboRenderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var render in RenderTypes)
            {
                if (render.Value.Equals(this.comboRenderType.SelectedItem.ToString()) && type_ != render.Key)
                {
                    type_ = render.Key;

                    localVideoView.SetRenderType(type_);
                    remoteVideoView.SetRenderType(type_);
                }
            }
        }
    }
}
