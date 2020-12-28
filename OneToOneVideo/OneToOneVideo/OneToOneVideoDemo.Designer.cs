
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
            OneToOneVideoDemo.remoteVideo = new System.Windows.Forms.PictureBox();
            OneToOneVideoDemo.localVideo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(OneToOneVideoDemo.remoteVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(OneToOneVideoDemo.localVideo)).BeginInit();
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
            OneToOneVideoDemo.remoteVideo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            OneToOneVideoDemo.remoteVideo.Location = new System.Drawing.Point(24, 62);
            OneToOneVideoDemo.remoteVideo.Name = "remoteVideo";
            OneToOneVideoDemo.remoteVideo.Size = new System.Drawing.Size(425, 305);
            OneToOneVideoDemo.remoteVideo.TabIndex = 6;
            OneToOneVideoDemo.remoteVideo.TabStop = false;
            // 
            // localVideo
            // 
            OneToOneVideoDemo.localVideo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            OneToOneVideoDemo.localVideo.Location = new System.Drawing.Point(510, 239);
            OneToOneVideoDemo.localVideo.Name = "localVideo";
            OneToOneVideoDemo.localVideo.Size = new System.Drawing.Size(250, 172);
            OneToOneVideoDemo.localVideo.TabIndex = 7;
            OneToOneVideoDemo.localVideo.TabStop = false;
            // 
            // OneToOneVideoDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(OneToOneVideoDemo.localVideo);
            this.Controls.Add(OneToOneVideoDemo.remoteVideo);
            this.Controls.Add(this.leaveChannel);
            this.Controls.Add(this.joinChannel);
            this.Controls.Add(this.channelNameBox);
            this.Controls.Add(this.appIdBox);
            this.Controls.Add(this.channelName);
            this.Controls.Add(this.appId);
            this.Name = "OneToOneVideoDemo";
            this.Text = "One to One Video Demo";
            ((System.ComponentModel.ISupportInitialize)(OneToOneVideoDemo.remoteVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(OneToOneVideoDemo.localVideo)).EndInit();
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
        internal static System.Windows.Forms.PictureBox remoteVideo;
        internal static System.Windows.Forms.PictureBox localVideo;
    }
}

