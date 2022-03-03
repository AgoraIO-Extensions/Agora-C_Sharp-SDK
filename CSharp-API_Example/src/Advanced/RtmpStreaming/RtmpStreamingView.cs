using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharp_API_Example
{
    public partial class RtmpStreamingView : UserControl
    {
        public RtmpStreamingView()
        {
            InitializeComponent();
        }

        public string GetRtmpUrl()
        {
            return rtmpURLTextBox.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (rtmpURLTextBox.Text == "")
                return;
            int ret = CSharpForm.usr_engine_.AddPublishStreamUrl(rtmpURLTextBox.Text);
            if(ret == 0)
            {
                cmbUrl.Items.Add(rtmpURLTextBox.Text);
                if (cmbUrl.Items.Count == 1)
                    cmbUrl.SelectedIndex = 0;
                rtmpURLTextBox.Text = "";
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (cmbUrl.Items.Count == 0)
                return;
            int ret = CSharpForm.usr_engine_.RemovePublishStreamUrl(cmbUrl.Text);
            if (ret == 0)
            {
                cmbUrl.Items.RemoveAt(cmbUrl.SelectedIndex);
                if (cmbUrl.Items.Count == 1)
                    cmbUrl.SelectedIndex = 0;
            }
        }
    }
}
