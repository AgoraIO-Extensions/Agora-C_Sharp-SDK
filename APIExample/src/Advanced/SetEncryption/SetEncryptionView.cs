using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharp_API_Example
{
    public partial class SetEncryptionView : UserControl
    {
        public SetEncryptionView()
        {
            InitializeComponent();
            cmbMode.SelectedIndex = 0;
        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != CSharpForm.usr_engine_)
                CSharpForm.usr_engine_.EnableEncryption((agora.rtc.ENCRYPTION_MODE)(cmbMode.SelectedIndex + 1));
        }
    }
}
