
namespace C_Sharp_API_Example
{
    partial class JoinMultipleChannelView
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
            this.firstChannelVideoView = new System.Windows.Forms.PictureBox();
            this.secondChannelVideoView = new System.Windows.Forms.PictureBox();
            this.localVideoView = new System.Windows.Forms.PictureBox();
            this.channelOneLabel = new System.Windows.Forms.Label();
            this.channelTwoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.firstChannelVideoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondChannelVideoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localVideoView)).BeginInit();
            this.SuspendLayout();
            // 
            // firstChannelVideoView
            // 
            this.firstChannelVideoView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.firstChannelVideoView.Location = new System.Drawing.Point(101, 47);
            this.firstChannelVideoView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.firstChannelVideoView.Name = "firstChannelVideoView";
            this.firstChannelVideoView.Size = new System.Drawing.Size(140, 153);
            this.firstChannelVideoView.TabIndex = 2;
            this.firstChannelVideoView.TabStop = false;
            // 
            // secondChannelVideoView
            // 
            this.secondChannelVideoView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.secondChannelVideoView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondChannelVideoView.Location = new System.Drawing.Point(350, 47);
            this.secondChannelVideoView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.secondChannelVideoView.Name = "secondChannelVideoView";
            this.secondChannelVideoView.Size = new System.Drawing.Size(140, 153);
            this.secondChannelVideoView.TabIndex = 3;
            this.secondChannelVideoView.TabStop = false;
            // 
            // localVideoView
            // 
            this.localVideoView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.localVideoView.Cursor = System.Windows.Forms.Cursors.Default;
            this.localVideoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.localVideoView.Location = new System.Drawing.Point(0, 0);
            this.localVideoView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.localVideoView.Name = "localVideoView";
            this.localVideoView.Size = new System.Drawing.Size(591, 510);
            this.localVideoView.TabIndex = 4;
            this.localVideoView.TabStop = false;
            // 
            // channelOneLabel
            // 
            this.channelOneLabel.AutoSize = true;
            this.channelOneLabel.Location = new System.Drawing.Point(157, 27);
            this.channelOneLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.channelOneLabel.Name = "channelOneLabel";
            this.channelOneLabel.Size = new System.Drawing.Size(28, 17);
            this.channelOneLabel.TabIndex = 5;
            this.channelOneLabel.Text = "ch1";
            // 
            // channelTwoLabel
            // 
            this.channelTwoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.channelTwoLabel.AutoSize = true;
            this.channelTwoLabel.Location = new System.Drawing.Point(406, 27);
            this.channelTwoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.channelTwoLabel.Name = "channelTwoLabel";
            this.channelTwoLabel.Size = new System.Drawing.Size(28, 17);
            this.channelTwoLabel.TabIndex = 6;
            this.channelTwoLabel.Text = "ch2";
            // 
            // JoinMultipleChannelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.secondChannelVideoView);
            this.Controls.Add(this.firstChannelVideoView);
            this.Controls.Add(this.channelTwoLabel);
            this.Controls.Add(this.channelOneLabel);
            this.Controls.Add(this.localVideoView);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "JoinMultipleChannelView";
            this.Size = new System.Drawing.Size(591, 510);
            ((System.ComponentModel.ISupportInitialize)(this.firstChannelVideoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondChannelVideoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localVideoView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox firstChannelVideoView;
        public System.Windows.Forms.PictureBox secondChannelVideoView;
        public System.Windows.Forms.PictureBox localVideoView;
        private System.Windows.Forms.Label channelOneLabel;
        private System.Windows.Forms.Label channelTwoLabel;
    }
}
