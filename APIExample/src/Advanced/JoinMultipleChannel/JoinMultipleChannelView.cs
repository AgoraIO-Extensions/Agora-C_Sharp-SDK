using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharp_API_Example
{
    public partial class JoinMultipleChannelView : UserControl
    {
        public JoinMultipleChannelView()
        {
            InitializeComponent();
            //channelSelComboBox.SelectedIndex = channelSelComboBox.Items.IndexOf("ch1");
        }
        public void SetUIText(ConfigHelper config)
        {
            this.pushToLabel.Text = config.GetUIValue("General", "MultipleChannel.Title");
            this.channelTwoLabel.Text = config.GetUIValue("General", "VideoGroup.Channel2");
            this.channelOneLabel.Text = config.GetUIValue("General", "VideoGroup.Channel1");
        }
    }
}
