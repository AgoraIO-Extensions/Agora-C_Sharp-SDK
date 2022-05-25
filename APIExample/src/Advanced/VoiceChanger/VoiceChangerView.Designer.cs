
namespace CSharp_API_Example
{
    partial class VoiceChangerView
    {
        /// <summary> 
        /// 
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 
        /// </summary>
        /// <param name="disposing">If release delegate resource, true; or fals</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Componet Designer Generated Code

        /// <summary> 
        /// The method designer supported - don't modify
        /// Modify the code by designer
        /// </summary>
        private void InitializeComponent()
        {
            this.voiceChangerLabel = new System.Windows.Forms.Label();
            this.cmbVoiceType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbVoiceBeautyParam1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbVoiceBeautyParam2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbAudioEffectParam1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbAudioEffect = new System.Windows.Forms.ComboBox();
            this.cmbAudioEffectParam2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // voiceChangerLabel
            // 
            this.voiceChangerLabel.AutoSize = true;
            this.voiceChangerLabel.Location = new System.Drawing.Point(282, 0);
            this.voiceChangerLabel.Name = "voiceChangerLabel";
            this.voiceChangerLabel.Size = new System.Drawing.Size(39, 20);
            this.voiceChangerLabel.TabIndex = 0;
            this.voiceChangerLabel.Text = "变声";
            this.voiceChangerLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbVoiceType
            // 
            this.cmbVoiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoiceType.FormattingEnabled = true;
            this.cmbVoiceType.Items.AddRange(new object[] {
            "关闭美声",
            "磁性（男）",
            "清新（女）",
            "活力（女）",
            "歌唱美声",
            "浑厚 ",
            "低沉",
            "圆润",
            "假音 \t",
            "饱满",
            "清澈",
            "高亢",
            "嘹亮"});
            this.cmbVoiceType.Location = new System.Drawing.Point(113, 539);
            this.cmbVoiceType.Name = "cmbVoiceType";
            this.cmbVoiceType.Size = new System.Drawing.Size(371, 28);
            this.cmbVoiceType.TabIndex = 1;
            this.cmbVoiceType.SelectedIndexChanged += new System.EventHandler(this.cmbVoiceType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 547);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "美声效果";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "美声效果",
            "美声音效"});
            this.cmbType.Location = new System.Drawing.Point(113, 500);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(255, 28);
            this.cmbType.TabIndex = 3;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 496);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(505, 542);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "参数1";
            // 
            // cmbVoiceBeautyParam1
            // 
            this.cmbVoiceBeautyParam1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoiceBeautyParam1.FormattingEnabled = true;
            this.cmbVoiceBeautyParam1.Items.AddRange(new object[] {
            "男声",
            "女声"});
            this.cmbVoiceBeautyParam1.Location = new System.Drawing.Point(570, 539);
            this.cmbVoiceBeautyParam1.Name = "cmbVoiceBeautyParam1";
            this.cmbVoiceBeautyParam1.Size = new System.Drawing.Size(115, 28);
            this.cmbVoiceBeautyParam1.TabIndex = 5;
            this.cmbVoiceBeautyParam1.SelectedIndexChanged += new System.EventHandler(this.cmbVoiceBeautyParam1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(707, 547);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "参数2";
            // 
            // cmbVoiceBeautyParam2
            // 
            this.cmbVoiceBeautyParam2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoiceBeautyParam2.FormattingEnabled = true;
            this.cmbVoiceBeautyParam2.Items.AddRange(new object[] {
            "歌声在小房间的混响效果",
            " 歌声在大房间的混响效果",
            " 歌声在大厅的混响效果"});
            this.cmbVoiceBeautyParam2.Location = new System.Drawing.Point(772, 539);
            this.cmbVoiceBeautyParam2.Name = "cmbVoiceBeautyParam2";
            this.cmbVoiceBeautyParam2.Size = new System.Drawing.Size(144, 28);
            this.cmbVoiceBeautyParam2.TabIndex = 7;
            this.cmbVoiceBeautyParam2.SelectedIndexChanged += new System.EventHandler(this.cmbVoiceBeautyParam2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 503);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "美声类型";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(707, 583);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "参数2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(505, 591);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "参数1";
            // 
            // cmbAudioEffectParam1
            // 
            this.cmbAudioEffectParam1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAudioEffectParam1.FormattingEnabled = true;
            this.cmbAudioEffectParam1.Items.AddRange(new object[] {
            "自然大调",
            "自然小调",
            "和风小调"});
            this.cmbAudioEffectParam1.Location = new System.Drawing.Point(570, 583);
            this.cmbAudioEffectParam1.Name = "cmbAudioEffectParam1";
            this.cmbAudioEffectParam1.Size = new System.Drawing.Size(115, 28);
            this.cmbAudioEffectParam1.TabIndex = 12;
            this.cmbAudioEffectParam1.SelectedIndexChanged += new System.EventHandler(this.cmbAudioEffectParam1_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 591);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "美声音效";
            // 
            // cmbAudioEffect
            // 
            this.cmbAudioEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAudioEffect.FormattingEnabled = true;
            this.cmbAudioEffect.Items.AddRange(new object[] {
            "原声，即关闭人声音效",
            "KTV",
            "演唱会",
            "录音棚",
            "留声机",
            "虚拟立体声",
            "空旷",
            "空灵",
            "3D 人声",
            "大叔",
            "老年男性",
            "男孩",
            "少女",
            "女孩",
            "猪八戒",
            "绿巨人",
            "R&B",
            "流行",
            "电音"});
            this.cmbAudioEffect.Location = new System.Drawing.Point(113, 583);
            this.cmbAudioEffect.Name = "cmbAudioEffect";
            this.cmbAudioEffect.Size = new System.Drawing.Size(371, 28);
            this.cmbAudioEffect.TabIndex = 10;
            this.cmbAudioEffect.SelectedIndexChanged += new System.EventHandler(this.cmbAudioEffect_SelectedIndexChanged);
            // 
            // cmbAudioEffectParam2
            // 
            cmbAudioEffectParam2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbAudioEffectParam2.FormattingEnabled = true;
            cmbAudioEffectParam2.Items.AddRange(new object[] {
            "A",
            "A#",
            "B",
            "(Default) C",
            "C#",
            "D",
            "D#",
            "E",
            "F",
            "F#",
            "G",
            "G#"});
            cmbAudioEffectParam2.Location = new System.Drawing.Point(772, 583);
            cmbAudioEffectParam2.Name = "cmbAudioEffectParam2";
            cmbAudioEffectParam2.Size = new System.Drawing.Size(144, 28);
            cmbAudioEffectParam2.TabIndex = 14;
            cmbAudioEffectParam2.SelectedIndexChanged += new System.EventHandler(this.cmbAudioEffectParam2_SelectedIndexChanged);
            // 
            // VoiceChangerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(cmbAudioEffectParam2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbAudioEffectParam1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbAudioEffect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbVoiceBeautyParam2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbVoiceBeautyParam1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbVoiceType);
            this.Controls.Add(this.voiceChangerLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "VoiceChangerView";
            this.Size = new System.Drawing.Size(946, 637);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label voiceChangerLabel;
        private System.Windows.Forms.ComboBox cmbVoiceType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbVoiceBeautyParam1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbVoiceBeautyParam2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbAudioEffectParam2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbAudioEffectParam1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbAudioEffect;
    }
}
