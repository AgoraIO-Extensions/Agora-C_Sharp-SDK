
namespace CSharp_API_Example
{
    partial class AudioMixingView
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
            this.audioMxingLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // audioMxingLabel
            // 
            this.audioMxingLabel.AutoSize = true;
            this.audioMxingLabel.Location = new System.Drawing.Point(165, 21);
            this.audioMxingLabel.Name = "audioMxingLabel";
            this.audioMxingLabel.Size = new System.Drawing.Size(39, 20);
            this.audioMxingLabel.TabIndex = 0;
            this.audioMxingLabel.Text = "混音";
            this.audioMxingLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AudioMixingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.audioMxingLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AudioMixingView";
            this.Size = new System.Drawing.Size(501, 367);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label audioMxingLabel;
    }
}
