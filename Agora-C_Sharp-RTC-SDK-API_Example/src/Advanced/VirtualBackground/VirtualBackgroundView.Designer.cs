
namespace C_Sharp_API_Example
{
    partial class VirtualBackgroundView
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
            this.remoteVideoView = new System.Windows.Forms.PictureBox();
            this.localVideoView = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.remoteVideoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localVideoView)).BeginInit();
            this.SuspendLayout();
            // 
            // remoteVideoView
            // 
            this.remoteVideoView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.remoteVideoView.Location = new System.Drawing.Point(2, 3);
            this.remoteVideoView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.remoteVideoView.Name = "remoteVideoView";
            this.remoteVideoView.Size = new System.Drawing.Size(120, 100);
            this.remoteVideoView.TabIndex = 2;
            this.remoteVideoView.TabStop = false;
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
            // VirtualBackgroundView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.remoteVideoView);
            this.Controls.Add(this.localVideoView);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "VirtualBackgroundView";
            this.Size = new System.Drawing.Size(591, 510);
            ((System.ComponentModel.ISupportInitialize)(this.remoteVideoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localVideoView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.PictureBox remoteVideoView;
        public System.Windows.Forms.PictureBox localVideoView;
    }
}
