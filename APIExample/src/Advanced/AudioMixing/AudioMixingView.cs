﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharp_API_Example
{
    public partial class AudioMixingView : UserControl
    {
       
        public AudioMixingView()
        {
            InitializeComponent();
        }

        public void SetUIText(ConfigHelper config)
        {
            this.audioMxingLabel.Text = config.GetUIValue("General", "AudioMixing");
        }
    }
}