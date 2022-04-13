
namespace CSharp_API_Example
{
    partial class RtmpStreamingView
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
            this.label1 = new System.Windows.Forms.Label();
            this.rtmpURLTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbUrl = new System.Windows.Forms.ComboBox();
            this.btnRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.remoteVideoView)).BeginInit();
            this.SuspendLayout();
            // 
            // remoteVideoView
            // 
            this.remoteVideoView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.remoteVideoView.Cursor = System.Windows.Forms.Cursors.Default;
            this.remoteVideoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remoteVideoView.Location = new System.Drawing.Point(0, 0);
            this.remoteVideoView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.remoteVideoView.Name = "remoteVideoView";
            this.remoteVideoView.Size = new System.Drawing.Size(591, 510);
            this.remoteVideoView.TabIndex = 4;
            this.remoteVideoView.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Rtmp Streaming";
            // 
            // rtmpURLTextBox
            // 
            this.rtmpURLTextBox.Location = new System.Drawing.Point(75, 437);
            this.rtmpURLTextBox.Name = "rtmpURLTextBox";
            this.rtmpURLTextBox.Size = new System.Drawing.Size(325, 23);
            this.rtmpURLTextBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 440);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Rtmp URL";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(419, 437);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbUrl
            // 
            this.cmbUrl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUrl.FormattingEnabled = true;
            this.cmbUrl.Location = new System.Drawing.Point(75, 466);
            this.cmbUrl.Name = "cmbUrl";
            this.cmbUrl.Size = new System.Drawing.Size(325, 25);
            this.cmbUrl.TabIndex = 13;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(419, 468);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 15;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // RtmpStreamingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.cmbUrl);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtmpURLTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.remoteVideoView);
            this.Name = "RtmpStreamingView";
            this.Size = new System.Drawing.Size(591, 510);
            ((System.ComponentModel.ISupportInitialize)(this.remoteVideoView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox remoteVideoView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rtmpURLTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbUrl;
        private System.Windows.Forms.Button btnRemove;
    }
}
