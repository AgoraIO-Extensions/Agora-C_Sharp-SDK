using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharp_API_Example
{
    public partial class MultiChannelView : UserControl
    {
        public MultiChannelView()
        {
            InitializeComponent();
            channelSelComboBox.SelectedIndex = channelSelComboBox.Items.IndexOf("ch1");
        }
    }
}
