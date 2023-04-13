
namespace C_Sharp_API_Example
{
    partial class VideoGroupView
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
            this.fistUserVideoView = new System.Windows.Forms.PictureBox();
            this.secondUserVideoView = new System.Windows.Forms.PictureBox();
            this.localVideoView = new System.Windows.Forms.PictureBox();
            this.usrOneLabel = new System.Windows.Forms.Label();
            this.userTwoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fistUserVideoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondUserVideoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localVideoView)).BeginInit();
            this.SuspendLayout();
            // 
            // fistUserVideoView
            // 
            this.fistUserVideoView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fistUserVideoView.Location = new System.Drawing.Point(22, 48);
            this.fistUserVideoView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.fistUserVideoView.Name = "fistUserVideoView";
            this.fistUserVideoView.Size = new System.Drawing.Size(240, 220);
            this.fistUserVideoView.TabIndex = 2;
            this.fistUserVideoView.TabStop = false;
            // 
            // secondUserVideoView
            // 
            this.secondUserVideoView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.secondUserVideoView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondUserVideoView.Location = new System.Drawing.Point(319, 48);
            this.secondUserVideoView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.secondUserVideoView.Name = "secondUserVideoView";
            this.secondUserVideoView.Size = new System.Drawing.Size(240, 220);
            this.secondUserVideoView.TabIndex = 3;
            this.secondUserVideoView.TabStop = false;
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
            // usrOneLabel
            // 
            this.usrOneLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrOneLabel.AutoSize = true;
            this.usrOneLabel.Location = new System.Drawing.Point(121, 28);
            this.usrOneLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usrOneLabel.Name = "usrOneLabel";
            this.usrOneLabel.Size = new System.Drawing.Size(42, 17);
            this.usrOneLabel.TabIndex = 5;
            this.usrOneLabel.Text = "User1";
            // 
            // userTwoLabel
            // 
            this.userTwoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userTwoLabel.AutoSize = true;
            this.userTwoLabel.Location = new System.Drawing.Point(418, 28);
            this.userTwoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.userTwoLabel.Name = "userTwoLabel";
            this.userTwoLabel.Size = new System.Drawing.Size(42, 17);
            this.userTwoLabel.TabIndex = 6;
            this.userTwoLabel.Text = "User2";
            // 
            // VideoGroupView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userTwoLabel);
            this.Controls.Add(this.usrOneLabel);
            this.Controls.Add(this.fistUserVideoView);
            this.Controls.Add(this.secondUserVideoView);
            this.Controls.Add(this.localVideoView);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "VideoGroupView";
            this.Size = new System.Drawing.Size(591, 510);
            ((System.ComponentModel.ISupportInitialize)(this.fistUserVideoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondUserVideoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localVideoView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox fistUserVideoView;
        public System.Windows.Forms.PictureBox secondUserVideoView;
        public System.Windows.Forms.PictureBox localVideoView;
        private System.Windows.Forms.Label usrOneLabel;
        private System.Windows.Forms.Label userTwoLabel;
    }
}
