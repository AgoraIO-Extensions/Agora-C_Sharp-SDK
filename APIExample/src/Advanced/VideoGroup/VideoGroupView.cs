using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharp_API_Example
{
    public partial class VideoGroupView : UserControl
    {
        public VideoGroupView()
        {
            InitializeComponent();
        }

        public void SetUIText(ConfigHelper config)
        {
            this.usrOneLabel.Text = config.GetUIValue("General", "VideoGroup.User1");
            this.userTwoLabel.Text = config.GetUIValue("General", "VideoGroup.User2");
            this.tipsLabel.Text = config.GetUIValue("General", "VideoGroup");
        }
    }
}
