
namespace CSharp_API_Example
{
    partial class JoinMultipleChannelView
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
            this.firstChannelVideoView = new System.Windows.Forms.PictureBox();
            this.secondChannelVideoView = new System.Windows.Forms.PictureBox();
            this.localVideoView = new System.Windows.Forms.PictureBox();
            this.channelOneLabel = new System.Windows.Forms.Label();
            this.channelTwoLabel = new System.Windows.Forms.Label();
            this.pushToLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.firstChannelVideoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondChannelVideoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localVideoView)).BeginInit();
            this.SuspendLayout();
            // 
            // firstChannelVideoView
            // 
            this.firstChannelVideoView.Location = new System.Drawing.Point(130, 55);
            this.firstChannelVideoView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.firstChannelVideoView.Name = "firstChannelVideoView";
            this.firstChannelVideoView.Size = new System.Drawing.Size(180, 180);
            this.firstChannelVideoView.TabIndex = 2;
            this.firstChannelVideoView.TabStop = false;
            // 
            // secondChannelVideoView
            // 
            this.secondChannelVideoView.Location = new System.Drawing.Point(450, 55);
            this.secondChannelVideoView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.secondChannelVideoView.Name = "secondChannelVideoView";
            this.secondChannelVideoView.Size = new System.Drawing.Size(180, 180);
            this.secondChannelVideoView.TabIndex = 3;
            this.secondChannelVideoView.TabStop = false;
            // 
            // localVideoView
            // 
            this.localVideoView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.localVideoView.Cursor = System.Windows.Forms.Cursors.Default;
            this.localVideoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.localVideoView.Location = new System.Drawing.Point(0, 0);
            this.localVideoView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.localVideoView.Name = "localVideoView";
            this.localVideoView.Size = new System.Drawing.Size(760, 600);
            this.localVideoView.TabIndex = 4;
            this.localVideoView.TabStop = false;
            // 
            // channelOneLabel
            // 
            this.channelOneLabel.AutoSize = true;
            this.channelOneLabel.Location = new System.Drawing.Point(56, 76);
            this.channelOneLabel.Name = "channelOneLabel";
            this.channelOneLabel.Size = new System.Drawing.Size(48, 20);
            this.channelOneLabel.TabIndex = 5;
            this.channelOneLabel.Text = "频道1";
            // 
            // channelTwoLabel
            // 
            this.channelTwoLabel.AutoSize = true;
            this.channelTwoLabel.Location = new System.Drawing.Point(651, 76);
            this.channelTwoLabel.Name = "channelTwoLabel";
            this.channelTwoLabel.Size = new System.Drawing.Size(48, 20);
            this.channelTwoLabel.TabIndex = 6;
            this.channelTwoLabel.Text = "频道2";
            // 
            // pushToLabel
            // 
            this.pushToLabel.AutoSize = true;
            this.pushToLabel.Location = new System.Drawing.Point(246, 16);
            this.pushToLabel.Name = "pushToLabel";
            this.pushToLabel.Size = new System.Drawing.Size(309, 20);
            this.pushToLabel.TabIndex = 7;
            this.pushToLabel.Text = "加入到不同频道（同一时刻只能发布一路流）";
            // 
            // MultiChannelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.secondChannelVideoView);
            this.Controls.Add(this.firstChannelVideoView);
            this.Controls.Add(this.pushToLabel);
            this.Controls.Add(this.channelTwoLabel);
            this.Controls.Add(this.channelOneLabel);
            this.Controls.Add(this.localVideoView);
            this.Name = "MultiChannelView";
            this.Size = new System.Drawing.Size(760, 600);
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
        private System.Windows.Forms.Label pushToLabel;
    }
}
