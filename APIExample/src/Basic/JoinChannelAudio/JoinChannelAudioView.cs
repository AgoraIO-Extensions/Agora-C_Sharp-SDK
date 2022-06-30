using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharp_API_Example
{
    public partial class JoinChannelAudioView : UserControl
    {
        public JoinChannelAudioView()
        {
            InitializeComponent();
        }

        public void SetUIText(ConfigHelper config)
        {
            this.audioLabel.Text = config.GetUIValue("General", "Audio1V1.Title");
        }
    }
}
