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
           
            cmbVoiceType.SelectedIndex = 0;
            cmbVoiceBeautyParam1.SelectedIndex = 0;
            cmbVoiceBeautyParam2.SelectedIndex = 0;

            cmbAudioEffect.SelectedIndex = 0;
            cmbAudioEffectParam1.SelectedIndex = 0;
            cmbAudioEffectParam2.SelectedIndex = 0;

            cmbType.SelectedIndex = 0;
        }
        private void cmbVoiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVoiceType.SelectedIndex == 1)
                cmbVoiceBeautyParam1.SelectedIndex = 0;
            else if (cmbVoiceType.SelectedIndex == 2 || cmbVoiceType.SelectedIndex == 3)
                cmbVoiceBeautyParam1.SelectedIndex = 1;

            cmbVoiceBeautyParam1.Enabled = cmbVoiceType.SelectedIndex == 4;
               
         //   cmbVoiceBeautyParam1.Enabled = ();

            //SINGING_BEAUTIFIER and man, SetVoiceBeautifierParameters  param2
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
    }
}
