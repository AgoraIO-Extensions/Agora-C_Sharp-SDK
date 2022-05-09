
namespace CSharp_API_Example
{
    partial class PlayEffectView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.playEffectLabel = new System.Windows.Forms.Label();
            this.btnPlayEffect = new System.Windows.Forms.Button();
            this.btnPauseEffect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playEffectLabel
            // 
            this.playEffectLabel.AutoSize = true;
            this.playEffectLabel.Location = new System.Drawing.Point(164, 21);
            this.playEffectLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.playEffectLabel.Name = "playEffectLabel";
            this.playEffectLabel.Size = new System.Drawing.Size(39, 20);
            this.playEffectLabel.TabIndex = 0;
            this.playEffectLabel.Text = "音效";
            this.playEffectLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPlayEffect
            // 
            this.btnPlayEffect.Location = new System.Drawing.Point(25, 323);
            this.btnPlayEffect.Name = "btnPlayEffect";
            this.btnPlayEffect.Size = new System.Drawing.Size(94, 29);
            this.btnPlayEffect.TabIndex = 1;
            this.btnPlayEffect.Text = "PlayEffect";
            this.btnPlayEffect.UseVisualStyleBackColor = true;
            this.btnPlayEffect.Click += new System.EventHandler(this.btnPlayEffect_Click);
            // 
            // btnPauseEffect
            // 
            this.btnPauseEffect.Location = new System.Drawing.Point(138, 323);
            this.btnPauseEffect.Name = "btnPauseEffect";
            this.btnPauseEffect.Size = new System.Drawing.Size(100, 29);
            this.btnPauseEffect.TabIndex = 2;
            this.btnPauseEffect.Text = "PauseEffect";
            this.btnPauseEffect.UseVisualStyleBackColor = true;
            this.btnPauseEffect.Click += new System.EventHandler(this.btnPauseEffect_Click);
            // 
            // PlayEffectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPauseEffect);
            this.Controls.Add(this.btnPlayEffect);
            this.Controls.Add(this.playEffectLabel);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "PlayEffectView";
            this.Size = new System.Drawing.Size(502, 367);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label playEffectLabel;
        private System.Windows.Forms.Button btnPlayEffect;
        private System.Windows.Forms.Button btnPauseEffect;
    }
}
