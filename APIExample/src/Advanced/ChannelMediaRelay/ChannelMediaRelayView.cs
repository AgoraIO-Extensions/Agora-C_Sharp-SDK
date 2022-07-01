using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharp_API_Example
{
  
    public partial class ChannelMediaRelayView : UserControl
    {
        private bool relay = false;

        private string startText = "";
        private string stopText = "";
        public ChannelMediaRelayView()
        {                             
            InitializeComponent();
            SetEnabled(false);
        }

        public void SetEnabled(bool enable)
        {
            textBoxMediaRelay.Enabled = enable;
            btnStart.Enabled = enable;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (CSharpForm.usr_engine_ == null
                || textBoxMediaRelay.Text.Length == 0)
                return;
            if (relay)
            {
                CSharpForm.usr_engine_.StopMediaRelay();
                btnStart.Text = startText;
            }
            else
            {
                CSharpForm.usr_engine_.StartMediaRelay(textBoxMediaRelay.Text);
                btnStart.Text = stopText;
            }
            relay = !relay;
        }

        public void SetUIText(ConfigHelper config)
        {
            label1.Text = config.GetUIValue("General", "MediaRelay");
            label2.Text = config.GetUIValue("General", "MediaRelay.Channel");
            btnStart.Text = startText = config.GetUIValue("General", "MediaRelay.Start");
            stopText = config.GetUIValue("General", "MediaRelay.Stop");
        }
    }
}
