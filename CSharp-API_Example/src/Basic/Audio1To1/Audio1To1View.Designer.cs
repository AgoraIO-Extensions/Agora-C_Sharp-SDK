﻿
namespace CSharp_API_Example
{
    partial class Audio1To1View
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
            this.audioLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // audioLabel
            // 
            this.audioLabel.AutoSize = true;
            this.audioLabel.Location = new System.Drawing.Point(188, 12);
            this.audioLabel.Name = "audioLabel";
            this.audioLabel.Size = new System.Drawing.Size(114, 20);
            this.audioLabel.TabIndex = 0;
            this.audioLabel.Text = "一对一语音通话";
            this.audioLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Audio1To1View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.audioLabel);
            this.Name = "Audio1To1View";
            this.Size = new System.Drawing.Size(502, 367);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label audioLabel;
    }
}
