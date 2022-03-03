using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharp_API_Example
{
    public partial class SetVideoEncoderConfigurationView : UserControl
    {
        agora.rtc.VideoDimensions[] dimension;
        agora.rtc.FRAME_RATE[] fps;
        public SetVideoEncoderConfigurationView()
        {
            InitializeComponent();
            dimension = new agora.rtc.VideoDimensions[3];
            dimension[0] = new agora.rtc.VideoDimensions(640, 360);
            dimension[1] = new agora.rtc.VideoDimensions(640, 480);
            dimension[2] = new agora.rtc.VideoDimensions(1280, 720);
            fps = new agora.rtc.FRAME_RATE[3];
            fps[0] = agora.rtc.FRAME_RATE.FRAME_RATE_FPS_15;
            fps[1] = agora.rtc.FRAME_RATE.FRAME_RATE_FPS_24;
            fps[2] = agora.rtc.FRAME_RATE.FRAME_RATE_FPS_30;

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != CSharpForm.usr_engine_)
                CSharpForm.usr_engine_.setVideoEncoderConfiguration(dimension[comboBox1.SelectedIndex], fps[comboBox2.SelectedIndex]);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != CSharpForm.usr_engine_)
                CSharpForm.usr_engine_.setVideoEncoderConfiguration(dimension[comboBox1.SelectedIndex], fps[comboBox2.SelectedIndex]);
        }
    }
}
