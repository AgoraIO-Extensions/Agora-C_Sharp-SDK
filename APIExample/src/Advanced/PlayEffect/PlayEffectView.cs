using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharp_API_Example
{
    public partial class PlayEffectView : UserControl
    {
        private string filePath = "";
        int soundId = 0;
        public PlayEffectView()
        {
            filePath = System.Windows.Forms.Application.StartupPath + "./audioEffect.mp3";
            InitializeComponent();
        }

        private void btnPlayEffect_Click(object sender, EventArgs e)
        {
            if(btnPlayEffect.Text.CompareTo("PlayEffect")== 0)
            {
                if (CSharpForm.usr_engine_.PlayEffect(soundId, filePath, 100, 0) == 0)
                {
                    btnPlayEffect.Text = "StopEffect";
                }
            }
            else
            {
                if (CSharpForm.usr_engine_.StopEffect(soundId) == 0)
                {
                    btnPlayEffect.Text = "PlayEffect";
                }
            }
           
        }
        private void btnPauseEffect_Click(object sender, EventArgs e)
        {
            if (btnPauseEffect.Text.CompareTo("PauseEffect") == 0)
            {
                if (CSharpForm.usr_engine_.PauseEffect(soundId) == 0)
                {
                    btnPauseEffect.Text = "ResumeEffect";
                }
            }
            else
            {
                if (CSharpForm.usr_engine_.ResumeEffect(soundId) == 0)
                {
                    btnPauseEffect.Text = "PauseEffect";
                }
            }
        }
    }
}
