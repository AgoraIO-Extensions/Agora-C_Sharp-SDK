using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharp_API_Example
{
    public partial class RTTView : UserControl
    {
        public RTTView()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (null == CSharpForm.usr_engine_)
                return;

            CSharpForm.usr_engine_.SendStreamMessage(sendTextBox.Text);
        }

        public void SetUIText(ConfigHelper config)
        {
            label1.Text = config.GetUIValue("General", "SendStreamMessage");
            label2.Text = config.GetUIValue("General", "SendStreamMessage.SendMessage");
            btnSend.Text = config.GetUIValue("General", "SendStreamMessage.Send");
        }
    }
}
