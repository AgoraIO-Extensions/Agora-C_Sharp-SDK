
namespace OneToOneVideo
{
    partial class OneToOneVideoDemo
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.appId = new System.Windows.Forms.Label();
            this.channelName = new System.Windows.Forms.Label();
            this.appIdBox = new System.Windows.Forms.TextBox();
            this.channelNameBox = new System.Windows.Forms.TextBox();
            this.joinChannel = new System.Windows.Forms.Button();
            this.leaveChannel = new System.Windows.Forms.Button();
            this.remoteVideo = new System.Windows.Forms.PictureBox();
            this.localVideo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.remoteVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // appId
            // 
            this.appId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.appId.AutoSize = true;
            this.appId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.appId.Location = new System.Drawing.Point(475, 79);
            this.appId.Name = "appId";
            this.appId.Size = new System.Drawing.Size(46, 19);
            this.appId.TabIndex = 0;
            this.appId.Text = "AppId";
            this.appId.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // channelName
            // 
            this.channelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.channelName.AutoSize = true;
            this.channelName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.channelName.Location = new System.Drawing.Point(475, 130);
            this.channelName.Name = "channelName";
            this.channelName.Size = new System.Drawing.Size(99, 19);
            this.channelName.TabIndex = 1;
            this.channelName.Text = "Channel Name";
            this.channelName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // appIdBox
            // 
            this.appIdBox.Location = new System.Drawing.Point(582, 78);
            this.appIdBox.Name = "appIdBox";
            this.appIdBox.Size = new System.Drawing.Size(180, 23);
            this.appIdBox.TabIndex = 2;
            // 
            // channelNameBox
            // 
            this.channelNameBox.Location = new System.Drawing.Point(582, 128);
            this.channelNameBox.Name = "channelNameBox";
            this.channelNameBox.Size = new System.Drawing.Size(180, 23);
            this.channelNameBox.TabIndex = 3;
            // 
            // joinChannel
            // 
            this.joinChannel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.joinChannel.Location = new System.Drawing.Point(541, 186);
            this.joinChannel.Name = "joinChannel";
            this.joinChannel.Size = new System.Drawing.Size(70, 25);
            this.joinChannel.TabIndex = 4;
            this.joinChannel.Text = "Join";
            this.joinChannel.UseVisualStyleBackColor = true;
            this.joinChannel.Click += new System.EventHandler(this.JoinChannel_Click);
            // 
            // leaveChannel
            // 
            this.leaveChannel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.leaveChannel.Location = new System.Drawing.Point(651, 186);
            this.leaveChannel.Name = "leaveChannel";
            this.leaveChannel.Size = new System.Drawing.Size(70, 25);
            this.leaveChannel.TabIndex = 5;
            this.leaveChannel.Text = "Leave";
            this.leaveChannel.UseVisualStyleBackColor = true;
            this.leaveChannel.Click += new System.EventHandler(this.LeaveChannel_Click);
            // 
            // remoteVideo
            // 
            this.remoteVideo.AccessibleName = "remoteVideoPic";
            this.remoteVideo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.remoteVideo.Location = new System.Drawing.Point(12, 12);
            this.remoteVideo.Name = "remoteVideo";
            this.remoteVideo.Size = new System.Drawing.Size(441, 372);
            this.remoteVideo.TabIndex = 6;
            this.remoteVideo.TabStop = false;
            this.remoteVideo.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // localVideo
            // 
            this.localVideo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.localVideo.Location = new System.Drawing.Point(541, 248);
            this.localVideo.Name = "localVideo";
            this.localVideo.Size = new System.Drawing.Size(221, 136);
            this.localVideo.TabIndex = 7;
            this.localVideo.TabStop = false;
            // 
            // OneToOneVideoDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.localVideo);
            this.Controls.Add(this.remoteVideo);
            this.Controls.Add(this.leaveChannel);
            this.Controls.Add(this.joinChannel);
            this.Controls.Add(this.channelNameBox);
            this.Controls.Add(this.appIdBox);
            this.Controls.Add(this.channelName);
            this.Controls.Add(this.appId);
            this.Name = "OneToOneVideoDemo";
            this.Text = "One to One Video Demo";
            ((System.ComponentModel.ISupportInitialize)(this.remoteVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label appId;
        private System.Windows.Forms.Label channelName;
        private System.Windows.Forms.TextBox appIdBox;
        private System.Windows.Forms.TextBox channelNameBox;
        private System.Windows.Forms.Button joinChannel;
        private System.Windows.Forms.Button leaveChannel;
        private System.Windows.Forms.PictureBox remoteVideo;
        private System.Windows.Forms.PictureBox localVideo;
    }
}

