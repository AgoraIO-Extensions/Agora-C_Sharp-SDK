using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharp_API_Example
{
    public partial class StringUidView : UserControl
    {
        public StringUidView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        public void SetUIText(ConfigHelper config)
        {
            label1.Text = config.GetUIValue("General", "StringUid");
        }
    }
}
