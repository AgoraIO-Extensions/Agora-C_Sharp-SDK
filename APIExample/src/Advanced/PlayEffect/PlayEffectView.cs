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
        string playText = "";
        string stopText = "";
        string pauseText = "";
        string resumeText = "";
        public PlayEffectView()
        {
            filePath = System.Windows.Forms.Application.StartupPath + "./audioEffect.mp3";
            InitializeComponent();
        }

        private void btnPlayEffect_Click(object sender, EventArgs e)
        {
            if (btnPlayEffect.Text.CompareTo(playText)== 0)
            {
                if (CSharpForm.usr_engine_.PlayEffect(soundId, filePath, 100, 0) == 0)
                {
                    btnPlayEffect.Text = stopText;
                }
            }
            else
            {
                if (CSharpForm.usr_engine_.StopEffect(soundId) == 0)
                {
                    btnPlayEffect.Text = playText;
                }
            }
           
        }
        private void btnPauseEffect_Click(object sender, EventArgs e)
        {
            if (btnPauseEffect.Text.CompareTo(pauseText) == 0)
            {
                if (CSharpForm.usr_engine_.PauseEffect(soundId) == 0)
                {
                    btnPauseEffect.Text = resumeText;
                }
            }
            else
            {
                if (CSharpForm.usr_engine_.ResumeEffect(soundId) == 0)
                {
                    btnPauseEffect.Text = pauseText;
                }
            }
        }

        public void SetUIText(ConfigHelper config)
        {
            this.playEffectLabel.Text = config.GetUIValue("General", "AudioEffect");
            btnPauseEffect.Text = pauseText = config.GetUIValue("General", "AudioEffect.Pause");
            btnPlayEffect.Text = playText = config.GetUIValue("General", "AudioEffect.Play");
            stopText = config.GetUIValue("General", "AudioEffect.Stop");
            resumeText = config.GetUIValue("General", "AudioEffect.Resume");
        }
    }
}
