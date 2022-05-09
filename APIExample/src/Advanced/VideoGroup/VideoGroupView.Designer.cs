
namespace CSharp_API_Example
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
            this.tipsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fistUserVideoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondUserVideoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localVideoView)).BeginInit();
            this.SuspendLayout();
            // 
            // fistUserVideoView
            // 
            this.fistUserVideoView.Location = new System.Drawing.Point(130, 56);
            this.fistUserVideoView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fistUserVideoView.Name = "fistUserVideoView";
            this.fistUserVideoView.Size = new System.Drawing.Size(180, 180);
            this.fistUserVideoView.TabIndex = 2;
            this.fistUserVideoView.TabStop = false;
            // 
            // secondUserVideoView
            // 
            this.secondUserVideoView.Location = new System.Drawing.Point(450, 56);
            this.secondUserVideoView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.secondUserVideoView.Name = "secondUserVideoView";
            this.secondUserVideoView.Size = new System.Drawing.Size(180, 180);
            this.secondUserVideoView.TabIndex = 3;
            this.secondUserVideoView.TabStop = false;
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
            // usrOneLabel
            // 
            this.usrOneLabel.AutoSize = true;
            this.usrOneLabel.Location = new System.Drawing.Point(56, 77);
            this.usrOneLabel.Name = "usrOneLabel";
            this.usrOneLabel.Size = new System.Drawing.Size(48, 20);
            this.usrOneLabel.TabIndex = 5;
            this.usrOneLabel.Text = "用户1";
            // 
            // userTwoLabel
            // 
            this.userTwoLabel.AutoSize = true;
            this.userTwoLabel.Location = new System.Drawing.Point(651, 77);
            this.userTwoLabel.Name = "userTwoLabel";
            this.userTwoLabel.Size = new System.Drawing.Size(48, 20);
            this.userTwoLabel.TabIndex = 6;
            this.userTwoLabel.Text = "用户2";
            // 
            // tipsLabel
            // 
            this.tipsLabel.AutoSize = true;
            this.tipsLabel.Location = new System.Drawing.Point(237, 16);
            this.tipsLabel.Name = "tipsLabel";
            this.tipsLabel.Size = new System.Drawing.Size(264, 20);
            this.tipsLabel.TabIndex = 7;
            this.tipsLabel.Text = "多人视频（用户从远端加入相同频道）";
            // 
            // VideoGroupView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tipsLabel);
            this.Controls.Add(this.userTwoLabel);
            this.Controls.Add(this.usrOneLabel);
            this.Controls.Add(this.fistUserVideoView);
            this.Controls.Add(this.secondUserVideoView);
            this.Controls.Add(this.localVideoView);
            this.Name = "VideoGroupView";
            this.Size = new System.Drawing.Size(760, 600);
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
        private System.Windows.Forms.Label tipsLabel;
    }
}
