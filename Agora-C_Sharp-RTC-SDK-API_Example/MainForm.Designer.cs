
namespace C_Sharp_API_Example
{
    partial class MainForm
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
            this.status_tips = new System.Windows.Forms.TextBox();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.joinChannelVideoTab = new System.Windows.Forms.TabPage();
            this.joinChannelVideoView = new C_Sharp_API_Example.JoinChannelVideoView();
            this.joinChannelAudioTab = new System.Windows.Forms.TabPage();
            this.joinChannelAudioView = new C_Sharp_API_Example.JoinChannelAudioView();
            this.screenShareTab = new System.Windows.Forms.TabPage();
            this.screenShareView = new C_Sharp_API_Example.ScreenShareView();
            this.joinMultipleChannelTab = new System.Windows.Forms.TabPage();
            this.joinMultipleChannelView = new C_Sharp_API_Example.JoinMultipleChannelView();
            this.processRawDataTab = new System.Windows.Forms.TabPage();
            this.processRawDataView = new C_Sharp_API_Example.ProcessRawDataView();
            this.virtualBackgroundTab = new System.Windows.Forms.TabPage();
            this.virtualBackgroundView = new C_Sharp_API_Example.VirtualBackgroundView();
            this.customRenderTab = new System.Windows.Forms.TabPage();
            this.customRenderView = new C_Sharp_API_Example.CustomRenderView();
            this.leave_channel_btn = new System.Windows.Forms.Button();
            this.join_channel_btn = new System.Windows.Forms.Button();
            this.appId_label = new System.Windows.Forms.Label();
            this.channelName_label = new System.Windows.Forms.Label();
            this.appId_textBox = new System.Windows.Forms.TextBox();
            this.channelId_textBox = new System.Windows.Forms.TextBox();
            this.updateBtn = new System.Windows.Forms.Button();
            this.faq_linkLabel = new System.Windows.Forms.LinkLabel();
            this.eg_linkLabel = new System.Windows.Forms.LinkLabel();
            this.reg_linkLabel = new System.Windows.Forms.LinkLabel();
            this.api_ref = new System.Windows.Forms.LinkLabel();
            this.sdk_version = new System.Windows.Forms.Label();
            this.clear_msg_btn = new System.Windows.Forms.Button();
            this.tabCtrl.SuspendLayout();
            this.joinChannelVideoTab.SuspendLayout();
            this.joinChannelAudioTab.SuspendLayout();
            this.screenShareTab.SuspendLayout();
            this.joinMultipleChannelTab.SuspendLayout();
            this.processRawDataTab.SuspendLayout();
            this.virtualBackgroundTab.SuspendLayout();
            this.customRenderTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // status_tips
            // 
            this.status_tips.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.status_tips.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.status_tips.Location = new System.Drawing.Point(18, 219);
            this.status_tips.Margin = new System.Windows.Forms.Padding(13, 4, 3, 4);
            this.status_tips.Multiline = true;
            this.status_tips.Name = "status_tips";
            this.status_tips.ReadOnly = true;
            this.status_tips.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.status_tips.Size = new System.Drawing.Size(603, 718);
            this.status_tips.TabIndex = 2;
            // 
            // tabCtrl
            // 
            this.tabCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCtrl.Controls.Add(this.joinChannelVideoTab);
            this.tabCtrl.Controls.Add(this.joinChannelAudioTab);
            this.tabCtrl.Controls.Add(this.screenShareTab);
            this.tabCtrl.Controls.Add(this.joinMultipleChannelTab);
            this.tabCtrl.Controls.Add(this.processRawDataTab);
            this.tabCtrl.Controls.Add(this.virtualBackgroundTab);
            this.tabCtrl.Controls.Add(this.customRenderTab);
            this.tabCtrl.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabCtrl.Location = new System.Drawing.Point(638, 21);
            this.tabCtrl.Margin = new System.Windows.Forms.Padding(4);
            this.tabCtrl.Multiline = true;
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(1214, 916);
            this.tabCtrl.TabIndex = 3;
            this.tabCtrl.SelectedIndexChanged += new System.EventHandler(this.OnSceneChanged);
            // 
            // joinChannelVideoTab
            // 
            this.joinChannelVideoTab.Controls.Add(this.joinChannelVideoView);
            this.joinChannelVideoTab.Location = new System.Drawing.Point(4, 33);
            this.joinChannelVideoTab.Name = "joinChannelVideoTab";
            this.joinChannelVideoTab.Padding = new System.Windows.Forms.Padding(3);
            this.joinChannelVideoTab.Size = new System.Drawing.Size(1206, 879);
            this.joinChannelVideoTab.TabIndex = 0;
            this.joinChannelVideoTab.Text = "Video Calling";
            this.joinChannelVideoTab.UseVisualStyleBackColor = true;
            // 
            // joinChannelVideoView
            // 
            this.joinChannelVideoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.joinChannelVideoView.Location = new System.Drawing.Point(3, 3);
            this.joinChannelVideoView.Margin = new System.Windows.Forms.Padding(0);
            this.joinChannelVideoView.Name = "joinChannelVideoView";
            this.joinChannelVideoView.Size = new System.Drawing.Size(1200, 873);
            this.joinChannelVideoView.TabIndex = 0;
            // 
            // joinChannelAudioTab
            // 
            this.joinChannelAudioTab.Controls.Add(this.joinChannelAudioView);
            this.joinChannelAudioTab.Location = new System.Drawing.Point(4, 33);
            this.joinChannelAudioTab.Name = "joinChannelAudioTab";
            this.joinChannelAudioTab.Padding = new System.Windows.Forms.Padding(3);
            this.joinChannelAudioTab.Size = new System.Drawing.Size(1206, 879);
            this.joinChannelAudioTab.TabIndex = 1;
            this.joinChannelAudioTab.Text = "Voice Calling";
            this.joinChannelAudioTab.UseVisualStyleBackColor = true;
            // 
            // joinChannelAudioView
            // 
            this.joinChannelAudioView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.joinChannelAudioView.Location = new System.Drawing.Point(3, 3);
            this.joinChannelAudioView.Margin = new System.Windows.Forms.Padding(0);
            this.joinChannelAudioView.Name = "joinChannelAudioView";
            this.joinChannelAudioView.Size = new System.Drawing.Size(1200, 873);
            this.joinChannelAudioView.TabIndex = 0;
            // 
            // screenShareTab
            // 
            this.screenShareTab.Controls.Add(this.screenShareView);
            this.screenShareTab.Location = new System.Drawing.Point(4, 33);
            this.screenShareTab.Name = "screenShareTab";
            this.screenShareTab.Padding = new System.Windows.Forms.Padding(3);
            this.screenShareTab.Size = new System.Drawing.Size(1206, 879);
            this.screenShareTab.TabIndex = 2;
            this.screenShareTab.Text = "ScreenShare";
            this.screenShareTab.UseVisualStyleBackColor = true;
            // 
            // screenShareView
            // 
            this.screenShareView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenShareView.Location = new System.Drawing.Point(3, 3);
            this.screenShareView.Margin = new System.Windows.Forms.Padding(0);
            this.screenShareView.Name = "screenShareView";
            this.screenShareView.Size = new System.Drawing.Size(1200, 873);
            this.screenShareView.TabIndex = 0;
            // 
            // joinMultipleChannelTab
            // 
            this.joinMultipleChannelTab.Controls.Add(this.joinMultipleChannelView);
            this.joinMultipleChannelTab.Location = new System.Drawing.Point(4, 33);
            this.joinMultipleChannelTab.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.joinMultipleChannelTab.Name = "joinMultipleChannelTab";
            this.joinMultipleChannelTab.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.joinMultipleChannelTab.Size = new System.Drawing.Size(1206, 879);
            this.joinMultipleChannelTab.TabIndex = 3;
            this.joinMultipleChannelTab.Text = "MultipleChannels";
            this.joinMultipleChannelTab.UseVisualStyleBackColor = true;
            // 
            // joinMultipleChannelView
            // 
            this.joinMultipleChannelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.joinMultipleChannelView.Location = new System.Drawing.Point(2, 3);
            this.joinMultipleChannelView.Margin = new System.Windows.Forms.Padding(0);
            this.joinMultipleChannelView.Name = "joinMultipleChannelView";
            this.joinMultipleChannelView.Size = new System.Drawing.Size(1202, 873);
            this.joinMultipleChannelView.TabIndex = 0;
            // 
            // processRawDataTab
            // 
            this.processRawDataTab.Controls.Add(this.processRawDataView);
            this.processRawDataTab.Location = new System.Drawing.Point(4, 33);
            this.processRawDataTab.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.processRawDataTab.Name = "processRawDataTab";
            this.processRawDataTab.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.processRawDataTab.Size = new System.Drawing.Size(1206, 879);
            this.processRawDataTab.TabIndex = 5;
            this.processRawDataTab.Text = "Raw Data";
            this.processRawDataTab.UseVisualStyleBackColor = true;
            // 
            // processRawDataView
            // 
            this.processRawDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processRawDataView.Location = new System.Drawing.Point(2, 3);
            this.processRawDataView.Margin = new System.Windows.Forms.Padding(0);
            this.processRawDataView.Name = "processRawDataView";
            this.processRawDataView.Size = new System.Drawing.Size(1202, 873);
            this.processRawDataView.TabIndex = 1;
            // 
            // virtualBackgroundTab
            // 
            this.virtualBackgroundTab.Controls.Add(this.virtualBackgroundView);
            this.virtualBackgroundTab.Location = new System.Drawing.Point(4, 33);
            this.virtualBackgroundTab.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.virtualBackgroundTab.Name = "virtualBackgroundTab";
            this.virtualBackgroundTab.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.virtualBackgroundTab.Size = new System.Drawing.Size(1206, 879);
            this.virtualBackgroundTab.TabIndex = 6;
            this.virtualBackgroundTab.Text = "Virtual Background";
            this.virtualBackgroundTab.UseVisualStyleBackColor = true;
            // 
            // virtualBackgroundView
            // 
            this.virtualBackgroundView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.virtualBackgroundView.Location = new System.Drawing.Point(2, 3);
            this.virtualBackgroundView.Margin = new System.Windows.Forms.Padding(0);
            this.virtualBackgroundView.Name = "virtualBackgroundView";
            this.virtualBackgroundView.Size = new System.Drawing.Size(1202, 873);
            this.virtualBackgroundView.TabIndex = 0;
            // 
            // customRenderTab
            // 
            this.customRenderTab.Controls.Add(this.customRenderView);
            this.customRenderTab.ForeColor = System.Drawing.Color.Transparent;
            this.customRenderTab.Location = new System.Drawing.Point(4, 33);
            this.customRenderTab.Name = "customRenderTab";
            this.customRenderTab.Size = new System.Drawing.Size(1206, 879);
            this.customRenderTab.TabIndex = 7;
            this.customRenderTab.Text = "CustomRender";
            this.customRenderTab.UseVisualStyleBackColor = true;
            // 
            // customRenderView
            // 
            this.customRenderView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customRenderView.Location = new System.Drawing.Point(0, 0);
            this.customRenderView.Margin = new System.Windows.Forms.Padding(0);
            this.customRenderView.Name = "customRenderView";
            this.customRenderView.Size = new System.Drawing.Size(1206, 879);
            this.customRenderView.TabIndex = 0;
            // 
            // leave_channel_btn
            // 
            this.leave_channel_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.leave_channel_btn.AutoSize = true;
            this.leave_channel_btn.Cursor = System.Windows.Forms.Cursors.Default;
            this.leave_channel_btn.Location = new System.Drawing.Point(1247, 957);
            this.leave_channel_btn.Margin = new System.Windows.Forms.Padding(3, 1, 3, 5);
            this.leave_channel_btn.Name = "leave_channel_btn";
            this.leave_channel_btn.Size = new System.Drawing.Size(603, 59);
            this.leave_channel_btn.TabIndex = 7;
            this.leave_channel_btn.Text = "leaveChannel";
            this.leave_channel_btn.UseVisualStyleBackColor = true;
            this.leave_channel_btn.Click += new System.EventHandler(this.LeaveChannelClicked);
            // 
            // join_channel_btn
            // 
            this.join_channel_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.join_channel_btn.AutoSize = true;
            this.join_channel_btn.Cursor = System.Windows.Forms.Cursors.Default;
            this.join_channel_btn.Location = new System.Drawing.Point(638, 957);
            this.join_channel_btn.Margin = new System.Windows.Forms.Padding(3, 1, 3, 5);
            this.join_channel_btn.Name = "join_channel_btn";
            this.join_channel_btn.Size = new System.Drawing.Size(603, 59);
            this.join_channel_btn.TabIndex = 7;
            this.join_channel_btn.Text = "joinChannel";
            this.join_channel_btn.UseVisualStyleBackColor = true;
            this.join_channel_btn.Click += new System.EventHandler(this.JoinChannelClicked);
            // 
            // appId_label
            // 
            this.appId_label.AutoSize = true;
            this.appId_label.Location = new System.Drawing.Point(30, 65);
            this.appId_label.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.appId_label.Name = "appId_label";
            this.appId_label.Size = new System.Drawing.Size(77, 24);
            this.appId_label.TabIndex = 4;
            this.appId_label.Text = "AppId *";
            // 
            // channelName_label
            // 
            this.channelName_label.AutoSize = true;
            this.channelName_label.Location = new System.Drawing.Point(30, 120);
            this.channelName_label.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.channelName_label.Name = "channelName_label";
            this.channelName_label.Size = new System.Drawing.Size(110, 24);
            this.channelName_label.TabIndex = 4;
            this.channelName_label.Text = "ChannelId *";
            // 
            // appId_textBox
            // 
            this.appId_textBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.appId_textBox.Location = new System.Drawing.Point(163, 61);
            this.appId_textBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.appId_textBox.Name = "appId_textBox";
            this.appId_textBox.Size = new System.Drawing.Size(281, 30);
            this.appId_textBox.TabIndex = 5;
            // 
            // channelId_textBox
            // 
            this.channelId_textBox.Location = new System.Drawing.Point(163, 112);
            this.channelId_textBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.channelId_textBox.Name = "channelId_textBox";
            this.channelId_textBox.PlaceholderText = "separate with \';\', e.g. ch1;ch2";
            this.channelId_textBox.Size = new System.Drawing.Size(281, 30);
            this.channelId_textBox.TabIndex = 6;
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(465, 110);
            this.updateBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(96, 35);
            this.updateBtn.TabIndex = 13;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.OnIdUpdate);
            // 
            // faq_linkLabel
            // 
            this.faq_linkLabel.AutoSize = true;
            this.faq_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.faq_linkLabel.Location = new System.Drawing.Point(424, 168);
            this.faq_linkLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.faq_linkLabel.Name = "faq_linkLabel";
            this.faq_linkLabel.Size = new System.Drawing.Size(48, 24);
            this.faq_linkLabel.TabIndex = 12;
            this.faq_linkLabel.TabStop = true;
            this.faq_linkLabel.Text = "FAQ";
            this.faq_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkBtnClicked);
            // 
            // eg_linkLabel
            // 
            this.eg_linkLabel.AutoSize = true;
            this.eg_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.eg_linkLabel.Location = new System.Drawing.Point(313, 168);
            this.eg_linkLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.eg_linkLabel.Name = "eg_linkLabel";
            this.eg_linkLabel.Size = new System.Drawing.Size(82, 24);
            this.eg_linkLabel.TabIndex = 11;
            this.eg_linkLabel.TabStop = true;
            this.eg_linkLabel.Text = "Samples";
            this.eg_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkBtnClicked);
            // 
            // reg_linkLabel
            // 
            this.reg_linkLabel.AutoSize = true;
            this.reg_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.reg_linkLabel.Location = new System.Drawing.Point(206, 168);
            this.reg_linkLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.reg_linkLabel.Name = "reg_linkLabel";
            this.reg_linkLabel.Size = new System.Drawing.Size(78, 24);
            this.reg_linkLabel.TabIndex = 10;
            this.reg_linkLabel.TabStop = true;
            this.reg_linkLabel.Text = "Sign Up";
            this.reg_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkBtnClicked);
            // 
            // api_ref
            // 
            this.api_ref.AutoSize = true;
            this.api_ref.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.api_ref.LinkVisited = true;
            this.api_ref.Location = new System.Drawing.Point(69, 168);
            this.api_ref.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.api_ref.Name = "api_ref";
            this.api_ref.Size = new System.Drawing.Size(108, 24);
            this.api_ref.TabIndex = 9;
            this.api_ref.TabStop = true;
            this.api_ref.Text = "Documents";
            this.api_ref.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkBtnClicked);
            // 
            // sdk_version
            // 
            this.sdk_version.AutoSize = true;
            this.sdk_version.Location = new System.Drawing.Point(110, 21);
            this.sdk_version.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.sdk_version.Name = "sdk_version";
            this.sdk_version.Size = new System.Drawing.Size(0, 24);
            this.sdk_version.TabIndex = 7;
            // 
            // clear_msg_btn
            // 
            this.clear_msg_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clear_msg_btn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.clear_msg_btn.Location = new System.Drawing.Point(18, 957);
            this.clear_msg_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clear_msg_btn.Name = "clear_msg_btn";
            this.clear_msg_btn.Size = new System.Drawing.Size(603, 59);
            this.clear_msg_btn.TabIndex = 3;
            this.clear_msg_btn.Text = "Clear";
            this.clear_msg_btn.UseVisualStyleBackColor = true;
            this.clear_msg_btn.Click += new System.EventHandler(this.OnClearBtnClicked);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1861, 1024);
            this.Controls.Add(this.join_channel_btn);
            this.Controls.Add(this.leave_channel_btn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.faq_linkLabel);
            this.Controls.Add(this.eg_linkLabel);
            this.Controls.Add(this.reg_linkLabel);
            this.Controls.Add(this.api_ref);
            this.Controls.Add(this.sdk_version);
            this.Controls.Add(this.appId_label);
            this.Controls.Add(this.appId_textBox);
            this.Controls.Add(this.channelId_textBox);
            this.Controls.Add(this.channelName_label);
            this.Controls.Add(this.clear_msg_btn);
            this.Controls.Add(this.status_tips);
            this.Controls.Add(this.tabCtrl);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Opacity = 0.99D;
            this.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Text = "CSharpForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.tabCtrl.ResumeLayout(false);
            this.joinChannelVideoTab.ResumeLayout(false);
            this.joinChannelAudioTab.ResumeLayout(false);
            this.screenShareTab.ResumeLayout(false);
            this.joinMultipleChannelTab.ResumeLayout(false);
            this.processRawDataTab.ResumeLayout(false);
            this.virtualBackgroundTab.ResumeLayout(false);
            this.customRenderTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage joinChannelVideoTab;
        private System.Windows.Forms.TabPage joinChannelAudioTab;
        private System.Windows.Forms.TabPage screenShareTab;
        private System.Windows.Forms.Label appId_label;
        private System.Windows.Forms.Label channelName_label;
        private System.Windows.Forms.TextBox appId_textBox;
        private System.Windows.Forms.TextBox channelId_textBox;
        private System.Windows.Forms.Button leave_channel_btn;
        private System.Windows.Forms.Button join_channel_btn;
        private System.Windows.Forms.Label sdk_version;
        private System.Windows.Forms.LinkLabel api_ref;
        private System.Windows.Forms.LinkLabel reg_linkLabel;
        private System.Windows.Forms.LinkLabel eg_linkLabel;
        private System.Windows.Forms.LinkLabel faq_linkLabel;
        public System.Windows.Forms.TextBox status_tips;
        private System.Windows.Forms.Button clear_msg_btn;
        private System.Windows.Forms.TabPage joinMultipleChannelTab;
        private JoinChannelVideoView joinChannelVideoView;
        private JoinChannelAudioView joinChannelAudioView;
        private ScreenShareView screenShareView;
        private JoinMultipleChannelView joinMultipleChannelView;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.TabPage processRawDataTab;
        private ProcessRawDataView processRawDataView;
        private System.Windows.Forms.TabPage virtualBackgroundTab;
        private VirtualBackgroundView virtualBackgroundView;
        private System.Windows.Forms.TabPage customRenderTab;
        private CustomRenderView customRenderView;
    }
}

