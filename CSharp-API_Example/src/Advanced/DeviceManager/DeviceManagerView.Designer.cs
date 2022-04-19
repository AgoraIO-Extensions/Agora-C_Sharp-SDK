
namespace CSharp_API_Example
{
    partial class DeviceManagerView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbVideoDevice = new System.Windows.Forms.ComboBox();
            this.cmbRecordingDevices = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPlayback = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.localVideoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remoteVideoView)).BeginInit();
            this.SuspendLayout();
            // 
            // localVideoView
            // 
            this.localVideoView.Location = new System.Drawing.Point(3, 4);
            this.localVideoView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.localVideoView.Name = "localVideoView";
            this.localVideoView.Size = new System.Drawing.Size(122, 112);
            this.localVideoView.TabIndex = 2;
            this.localVideoView.TabStop = false;
            // 
            // remoteVideoView
            // 
            this.remoteVideoView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.remoteVideoView.Cursor = System.Windows.Forms.Cursors.Default;
            this.remoteVideoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remoteVideoView.Location = new System.Drawing.Point(0, 0);
            this.remoteVideoView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.remoteVideoView.Name = "remoteVideoView";
            this.remoteVideoView.Size = new System.Drawing.Size(760, 600);
            this.remoteVideoView.TabIndex = 4;
            this.remoteVideoView.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "设备管理";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 457);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Video Device";
            // 
            // cmbVideoDevice
            // 
            this.cmbVideoDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVideoDevice.FormattingEnabled = true;
            this.cmbVideoDevice.Location = new System.Drawing.Point(174, 454);
            this.cmbVideoDevice.Name = "cmbVideoDevice";
            this.cmbVideoDevice.Size = new System.Drawing.Size(234, 28);
            this.cmbVideoDevice.TabIndex = 9;
            this.cmbVideoDevice.SelectedIndexChanged += new System.EventHandler(this.cmbVideoDevice_SelectedIndexChanged);
            // 
            // cmbRecordingDevices
            // 
            this.cmbRecordingDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecordingDevices.FormattingEnabled = true;
            this.cmbRecordingDevices.Location = new System.Drawing.Point(174, 501);
            this.cmbRecordingDevices.Name = "cmbRecordingDevices";
            this.cmbRecordingDevices.Size = new System.Drawing.Size(234, 28);
            this.cmbRecordingDevices.TabIndex = 11;
            this.cmbRecordingDevices.SelectedIndexChanged += new System.EventHandler(this.cmbRecordingDevices_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 509);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Recording Device";
            // 
            // cmbPlayback
            // 
            this.cmbPlayback.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlayback.FormattingEnabled = true;
            this.cmbPlayback.Location = new System.Drawing.Point(174, 547);
            this.cmbPlayback.Name = "cmbPlayback";
            this.cmbPlayback.Size = new System.Drawing.Size(234, 28);
            this.cmbPlayback.TabIndex = 13;
            this.cmbPlayback.SelectedIndexChanged += new System.EventHandler(this.cmbPlayback_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 555);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Playback Device";
            // 
            // DeviceManagerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbPlayback);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbRecordingDevices);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbVideoDevice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.localVideoView);
            this.Controls.Add(this.remoteVideoView);
            this.Name = "DeviceManagerView";
            this.Size = new System.Drawing.Size(760, 600);
            ((System.ComponentModel.ISupportInitialize)(this.localVideoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remoteVideoView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox localVideoView;
        public System.Windows.Forms.PictureBox remoteVideoView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbVideoDevice;
        private System.Windows.Forms.ComboBox cmbRecordingDevices;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPlayback;
        private System.Windows.Forms.Label label4;
    }
}
