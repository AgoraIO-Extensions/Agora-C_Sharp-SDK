using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharp_API_Example
{
    public partial class VoiceChangerView : UserControl
    {
       
        public VoiceChangerView()
        {
            InitializeComponent();
           
            
        }
        private void cmbVoiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVoiceType.SelectedIndex == 1)
                cmbVoiceBeautyParam1.SelectedIndex = 0;
            else if (cmbVoiceType.SelectedIndex == 2 || cmbVoiceType.SelectedIndex == 3)
                cmbVoiceBeautyParam1.SelectedIndex = 1;

            cmbVoiceBeautyParam1.Enabled = cmbVoiceType.SelectedIndex == 4;
            cmbVoiceBeautyParam2.Enabled = (cmbVoiceType.SelectedIndex == 4
                && cmbVoiceBeautyParam1.SelectedIndex == 0);
            if (null == CSharpForm.usr_engine_)
                return;

            CSharpForm.usr_engine_.SetVoiceBeautifierPreset(cmbVoiceType.SelectedIndex);
        }
        private void cmbVoiceBeautyParam1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVoiceType.SelectedIndex == 1
                && cmbVoiceBeautyParam1.SelectedIndex == 1)
            {
                CSharpForm.dump_handler_("VoiceChanger" + "MAGNETIC not for women ", -1);
                cmbVoiceBeautyParam1.SelectedIndex = 0;
                return;
            }

            if (cmbVoiceType.SelectedIndex == 2
                && cmbVoiceType.SelectedIndex == 3
                && cmbVoiceBeautyParam1.SelectedIndex == 0)
            {
                CSharpForm.dump_handler_("VoiceChanger" + "FRESH and VITALITY not for men ", -1
                    );
                cmbVoiceBeautyParam1.SelectedIndex = 0;
                return;
            }

            //SINGING_BEAUTIFIER and man, SetVoiceBeautifierParameters  param2
            if (cmbVoiceType.SelectedIndex == 4
                && cmbVoiceBeautyParam1.SelectedIndex == 0)
            {
                cmbVoiceBeautyParam2.Enabled = true;
            }
            else
            {
                cmbVoiceBeautyParam2.Enabled = false;
                return;
            }

            if (null == CSharpForm.usr_engine_)
                return;
            CSharpForm.usr_engine_.SetVoiceBeautifierParameters(cmbVoiceType.SelectedIndex,
               cmbVoiceBeautyParam1.SelectedIndex + 1, cmbVoiceBeautyParam2.SelectedIndex + 2);
        }

        private void cmbVoiceBeautyParam2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null == CSharpForm.usr_engine_)
                return;
            CSharpForm.usr_engine_.SetVoiceBeautifierParameters(cmbVoiceType.SelectedIndex,
               cmbVoiceBeautyParam1.SelectedIndex + 1, cmbVoiceBeautyParam2.SelectedIndex + 2);
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbType.SelectedIndex == 1)
            {
                cmbVoiceType.Enabled = false;
                cmbVoiceBeautyParam1.Enabled = false;
                cmbAudioEffect.Enabled = true;
                cmbAudioEffectParam1.Enabled = true;
                cmbAudioEffectParam2.Enabled = true;
            }
            else
            {
                cmbAudioEffect.Enabled = false;
                cmbAudioEffectParam1.Enabled = false;
                cmbAudioEffectParam2.Enabled = false;
                cmbVoiceType.Enabled = true;
                cmbVoiceBeautyParam1.Enabled = true;
            }
            cmbVoiceBeautyParam2.Enabled = (cmbVoiceType.SelectedIndex == 1
               && cmbVoiceBeautyParam1.SelectedIndex == 1);
        }

        private void cmbAudioEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null == CSharpForm.usr_engine_)
                return;
            CSharpForm.usr_engine_.SetAudioEffectPreset(cmbAudioEffect.SelectedIndex);
        }

        private void cmbAudioEffectParam1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null == CSharpForm.usr_engine_)
                return;
            CSharpForm.usr_engine_.SetAudioEffectParameters(cmbAudioEffect.SelectedIndex,
                cmbAudioEffectParam1.SelectedIndex + 1, cmbAudioEffectParam2.SelectedIndex + 2);
        }

        private void cmbAudioEffectParam2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null == CSharpForm.usr_engine_)
                return;
            CSharpForm.usr_engine_.SetAudioEffectParameters(cmbAudioEffect.SelectedIndex,
               cmbAudioEffectParam1.SelectedIndex + 1, cmbAudioEffectParam2.SelectedIndex + 2);
        }

        public void EnableCmbType(bool enable)
        {
            cmbType.Enabled = enable;
        }
        public void SetUIText(ConfigHelper config)
        {
            this.cmbVoiceType.Items.AddRange(new object[] {
            config.GetUIValue("General", "Beautifier.Off"),
            config.GetUIValue("General", "Beautifier.Magnet"),
            config.GetUIValue("General", "Beautifier.Fresh"),
            config.GetUIValue("General", "Beautifier.Vitality"),
            config.GetUIValue("General", "Beautifier.Singing"),
            config.GetUIValue("General", "Beautifier.Vigorous"),
            config.GetUIValue("General", "Beautifier.Deep"),
            config.GetUIValue("General", "Beautifier.Mellower"),
            config.GetUIValue("General", "Beautifier.Falsetto"),
            config.GetUIValue("General", "Beautifier.Fuller"),
            config.GetUIValue("General", "Beautifier.Cleaner"),
            config.GetUIValue("General", "Beautifier.Resounding"),
            config.GetUIValue("General", "Beautifier.Ringing")});

            this.cmbAudioEffect.Items.AddRange(new object[] {
            config.GetUIValue("General", "Beauty.AudioEffect.Off"),
            config.GetUIValue("General", "Beauty.AudioEffect.KTV"),
            config.GetUIValue("General", "Beauty.AudioEffect.concert"),
            config.GetUIValue("General", "Beauty.AudioEffect.recording"),
            config.GetUIValue("General", "Beauty.AudioEffect.vintage"),
            config.GetUIValue("General", "Beauty.AudioEffect.stereo"),
            config.GetUIValue("General", "Beauty.AudioEffect.spatial"),
             config.GetUIValue("General", "Beauty.AudioEffect.Ethereal"),
            config.GetUIValue("General", "Beauty.AudioEffect.3D"),
            config.GetUIValue("General", "Beauty.AudioEffect.middle-agedman"),
            config.GetUIValue("General", "Beauty.AudioEffect.seniorVoice"),
            config.GetUIValue("General", "Beauty.AudioEffect.boy"),
            config.GetUIValue("General", "Beauty.AudioEffect.girl"),
            config.GetUIValue("General", "Beauty.AudioEffect.pig"),
            config.GetUIValue("General", "Beauty.AudioEffect.RB"),
            config.GetUIValue("General", "Beauty.AudioEffect.popular"),
            config.GetUIValue("General", "Beauty.AudioEffect.CORRECTION")});
            this.cmbVoiceBeautyParam2.Items.AddRange(new object[] {
            });

            this.cmbVoiceBeautyParam2.Items.AddRange(new object[] {
            config.GetUIValue("General", "Beautifer.Param2.Small"),
            config.GetUIValue("General", "Beautifer.Param2.Large"),
            config.GetUIValue("General", "Beautifer.Param2.Hall")});


            this.cmbType.Items.AddRange(new object[] {
            config.GetUIValue("General", "VoiceChanger.BeautyResult"),
            config.GetUIValue("General", "VoiceChanger.BeautyEffect"),});


            this.cmbVoiceBeautyParam1.Items.AddRange(new object[] {
            config.GetUIValue("General", "Beautifer.Param1.Man"),
            config.GetUIValue("General", "Beautifer.Param1.Woman")});

            this.cmbAudioEffectParam1.Items.AddRange(new object[] {
            config.GetUIValue("General", "Beauty.AudioEffect.Param1.Major"),
            config.GetUIValue("General", "Beauty.AudioEffect.Param1.Minor"),
            config.GetUIValue("General", "Beauty.AudioEffect.Param1.pentatonic")});

            this.label1.Text = config.GetUIValue("General", "VoiceChanger.BeautyResult");
            this.label3.Text = config.GetUIValue("General", "VoiceChanger.Param1");
            this.label4.Text = config.GetUIValue("General", "VoiceChanger.Param2");
            this.label5.Text = config.GetUIValue("General", "VoiceChanger.BeautyType");
            this.label6.Text = config.GetUIValue("General", "VoiceChanger.Param2");
            this.label7.Text = config.GetUIValue("General", "VoiceChanger.Param1");
            this.label8.Text = config.GetUIValue("General", "VoiceChanger.BeautyEffect");

            cmbVoiceType.SelectedIndex = 0;
            cmbVoiceBeautyParam1.SelectedIndex = 0;
            cmbVoiceBeautyParam2.SelectedIndex = 0;

            cmbAudioEffect.SelectedIndex = 0;
            cmbAudioEffectParam1.SelectedIndex = 0;
            cmbAudioEffectParam2.SelectedIndex = 0;

            cmbType.SelectedIndex = 0;
            this.voiceChangerLabel.Text = config.GetUIValue("General", "Video1V1.Title");
        }


    }
}
