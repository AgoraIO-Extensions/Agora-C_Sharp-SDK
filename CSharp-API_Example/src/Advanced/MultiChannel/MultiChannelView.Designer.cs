
namespace CSharp_API_Example
{
    partial class MultiChannelView
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
            this.channelOneVideoView = new System.Windows.Forms.PictureBox();
            this.channelTwoVideoView = new System.Windows.Forms.PictureBox();
            this.localVideoView = new System.Windows.Forms.PictureBox();
            this.channelOneLabel = new System.Windows.Forms.Label();
            this.channelTwoLabel = new System.Windows.Forms.Label();
            this.pushToLabel = new System.Windows.Forms.Label();
            this.channelSelComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.channelOneVideoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.channelTwoVideoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localVideoView)).BeginInit();
            this.SuspendLayout();
            // 
            // channelOneVideoView
            // 
            this.channelOneVideoView.Location = new System.Drawing.Point(130, 30);
            this.channelOneVideoView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.channelOneVideoView.Name = "channelOneVideoView";
            this.channelOneVideoView.Size = new System.Drawing.Size(180, 180);
            this.channelOneVideoView.TabIndex = 2;
            this.channelOneVideoView.TabStop = false;
            // 
            // channelTwoVideoView
            // 
            this.channelTwoVideoView.Location = new System.Drawing.Point(450, 30);
            this.channelTwoVideoView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.channelTwoVideoView.Name = "channelTwoVideoView";
            this.channelTwoVideoView.Size = new System.Drawing.Size(180, 180);
            this.channelTwoVideoView.TabIndex = 3;
            this.channelTwoVideoView.TabStop = false;
            // 
            // localVideoView
            // 
            this.localVideoView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.localVideoView.Cursor = System.Windows.Forms.Cursors.Default;
            this.localVideoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.localVideoView.Location = new System.Drawing.Point(0, 0);
            this.localVideoView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.localVideoView.Name = "localVideoView";
            this.localVideoView.Size = new System.Drawing.Size(749, 583);
            this.localVideoView.TabIndex = 4;
            this.localVideoView.TabStop = false;
            // 
            // channelOneLabel
            // 
            this.channelOneLabel.AutoSize = true;
            this.channelOneLabel.Location = new System.Drawing.Point(56, 51);
            this.channelOneLabel.Name = "channelOneLabel";
            this.channelOneLabel.Size = new System.Drawing.Size(48, 20);
            this.channelOneLabel.TabIndex = 5;
            this.channelOneLabel.Text = "频道1";
            // 
            // channelTwoLabel
            // 
            this.channelTwoLabel.AutoSize = true;
            this.channelTwoLabel.Location = new System.Drawing.Point(651, 51);
            this.channelTwoLabel.Name = "channelTwoLabel";
            this.channelTwoLabel.Size = new System.Drawing.Size(48, 20);
            this.channelTwoLabel.TabIndex = 6;
            this.channelTwoLabel.Text = "频道2";
            // 
            // pushToLabel
            // 
            this.pushToLabel.AutoSize = true;
            this.pushToLabel.Location = new System.Drawing.Point(262, 514);
            this.pushToLabel.Name = "pushToLabel";
            this.pushToLabel.Size = new System.Drawing.Size(54, 20);
            this.pushToLabel.TabIndex = 7;
            this.pushToLabel.Text = "推流至";
            // 
            // channelSelComboBox
            // 
            this.channelSelComboBox.FormattingEnabled = true;
            this.channelSelComboBox.Items.AddRange(new object[] {
            "ch1",
            "ch2"});
            this.channelSelComboBox.Location = new System.Drawing.Point(322, 511);
            this.channelSelComboBox.Name = "channelSelComboBox";
            this.channelSelComboBox.Size = new System.Drawing.Size(106, 28);
            this.channelSelComboBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "开发阶段";
            // 
            // MultiChannelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.channelSelComboBox);
            this.Controls.Add(this.pushToLabel);
            this.Controls.Add(this.channelTwoLabel);
            this.Controls.Add(this.channelOneLabel);
            this.Controls.Add(this.channelOneVideoView);
            this.Controls.Add(this.channelTwoVideoView);
            this.Controls.Add(this.localVideoView);
            this.Name = "MultiChannelView";
            this.Size = new System.Drawing.Size(749, 583);
            ((System.ComponentModel.ISupportInitialize)(this.channelOneVideoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.channelTwoVideoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localVideoView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox channelOneVideoView;
        public System.Windows.Forms.PictureBox channelTwoVideoView;
        public System.Windows.Forms.PictureBox localVideoView;
        private System.Windows.Forms.Label channelOneLabel;
        private System.Windows.Forms.Label channelTwoLabel;
        private System.Windows.Forms.Label pushToLabel;
        public System.Windows.Forms.ComboBox channelSelComboBox;
        private System.Windows.Forms.Label label1;
    }
}
