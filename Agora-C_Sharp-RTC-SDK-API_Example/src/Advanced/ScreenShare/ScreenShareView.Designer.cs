
namespace C_Sharp_API_Example
{
    partial class ScreenShareView
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
            this.localVideoView = new System.Windows.Forms.PictureBox();
            this.remoteVideoView = new System.Windows.Forms.PictureBox();
            this.comboSources = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.chkLoopback = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.localVideoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remoteVideoView)).BeginInit();
            this.SuspendLayout();
            // 
            // localVideoView
            // 
            this.localVideoView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.localVideoView.Location = new System.Drawing.Point(3, 54);
            this.localVideoView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.localVideoView.Name = "localVideoView";
            this.localVideoView.Size = new System.Drawing.Size(180, 170);
            this.localVideoView.TabIndex = 2;
            this.localVideoView.TabStop = false;
            // 
            // remoteVideoView
            // 
            this.remoteVideoView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remoteVideoView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.remoteVideoView.Cursor = System.Windows.Forms.Cursors.Default;
            this.remoteVideoView.Location = new System.Drawing.Point(0, 54);
            this.remoteVideoView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.remoteVideoView.Name = "remoteVideoView";
            this.remoteVideoView.Size = new System.Drawing.Size(672, 456);
            this.remoteVideoView.TabIndex = 4;
            this.remoteVideoView.TabStop = false;
            // 
            // comboSources
            // 
            this.comboSources.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboSources.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSources.FormattingEnabled = true;
            this.comboSources.Location = new System.Drawing.Point(3, 13);
            this.comboSources.Name = "comboSources";
            this.comboSources.Size = new System.Drawing.Size(390, 25);
            this.comboSources.TabIndex = 5;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(399, 13);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 25);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(480, 13);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 25);
            this.btnStartStop.TabIndex = 7;
            this.btnStartStop.Text = "start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // chkLoopback
            // 
            this.chkLoopback.AutoSize = true;
            this.chkLoopback.Location = new System.Drawing.Point(561, 15);
            this.chkLoopback.Name = "chkLoopback";
            this.chkLoopback.Size = new System.Drawing.Size(85, 21);
            this.chkLoopback.TabIndex = 8;
            this.chkLoopback.Text = "Loopback";
            this.chkLoopback.UseVisualStyleBackColor = true;
            // 
            // ScreenShareView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkLoopback);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.comboSources);
            this.Controls.Add(this.localVideoView);
            this.Controls.Add(this.remoteVideoView);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "ScreenShareView";
            this.Size = new System.Drawing.Size(672, 510);
            ((System.ComponentModel.ISupportInitialize)(this.localVideoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remoteVideoView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox localVideoView;
        public System.Windows.Forms.PictureBox remoteVideoView;
        private System.Windows.Forms.ComboBox comboSources;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.CheckBox chkLoopback;
    }
}
