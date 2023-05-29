
namespace C_Sharp_API_Example
{
    partial class CSharpForm
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
            this.leave_channel_btn = new System.Windows.Forms.Button();
            this.join_channel_btn = new System.Windows.Forms.Button();
            this.appId_label = new System.Windows.Forms.Label();
            this.channelName_label = new System.Windows.Forms.Label();
            this.appId_textBox = new System.Windows.Forms.TextBox();
            this.channelId_textBox = new System.Windows.Forms.TextBox();
            this.splitContainer_left_part = new System.Windows.Forms.SplitContainer();
            this.updateBtn = new System.Windows.Forms.Button();
            this.faq_linkLabel = new System.Windows.Forms.LinkLabel();
            this.eg_linkLabel = new System.Windows.Forms.LinkLabel();
            this.reg_linkLabel = new System.Windows.Forms.LinkLabel();
            this.api_ref = new System.Windows.Forms.LinkLabel();
            this.sdk_version = new System.Windows.Forms.Label();
            this.clear_msg_btn = new System.Windows.Forms.Button();
            this.splitContainer_horizon_all = new System.Windows.Forms.SplitContainer();
            this.splitContainer_right_Vertical = new System.Windows.Forms.SplitContainer();
            this.btn_splitContainer = new System.Windows.Forms.SplitContainer();
            this.tabCtrl.SuspendLayout();
            this.joinChannelVideoTab.SuspendLayout();
            this.joinChannelAudioTab.SuspendLayout();
            this.screenShareTab.SuspendLayout();
            this.joinMultipleChannelTab.SuspendLayout();
            this.processRawDataTab.SuspendLayout();
            this.virtualBackgroundTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_left_part)).BeginInit();
            this.splitContainer_left_part.Panel1.SuspendLayout();
            this.splitContainer_left_part.Panel2.SuspendLayout();
            this.splitContainer_left_part.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_horizon_all)).BeginInit();
            this.splitContainer_horizon_all.Panel1.SuspendLayout();
            this.splitContainer_horizon_all.Panel2.SuspendLayout();
            this.splitContainer_horizon_all.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_right_Vertical)).BeginInit();
            this.splitContainer_right_Vertical.Panel1.SuspendLayout();
            this.splitContainer_right_Vertical.Panel2.SuspendLayout();
            this.splitContainer_right_Vertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_splitContainer)).BeginInit();
            this.btn_splitContainer.Panel1.SuspendLayout();
            this.btn_splitContainer.Panel2.SuspendLayout();
            this.btn_splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // status_tips
            // 
            this.status_tips.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.status_tips.Dock = System.Windows.Forms.DockStyle.Top;
            this.status_tips.Location = new System.Drawing.Point(0, 0);
            this.status_tips.Margin = new System.Windows.Forms.Padding(8, 3, 2, 3);
            this.status_tips.Multiline = true;
            this.status_tips.Name = "status_tips";
            this.status_tips.ReadOnly = true;
            this.status_tips.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.status_tips.Size = new System.Drawing.Size(384, 506);
            this.status_tips.TabIndex = 2;
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.joinChannelVideoTab);
            this.tabCtrl.Controls.Add(this.joinChannelAudioTab);
            this.tabCtrl.Controls.Add(this.screenShareTab);
            this.tabCtrl.Controls.Add(this.joinMultipleChannelTab);
            this.tabCtrl.Controls.Add(this.processRawDataTab);
            this.tabCtrl.Controls.Add(this.virtualBackgroundTab);
            this.tabCtrl.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrl.Location = new System.Drawing.Point(0, 0);
            this.tabCtrl.Margin = new System.Windows.Forms.Padding(4);
            this.tabCtrl.Multiline = true;
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(790, 673);
            this.tabCtrl.TabIndex = 3;
            this.tabCtrl.SelectedIndexChanged += new System.EventHandler(this.OnSceneChanged);
            // 
            // joinChannelVideoTab
            // 
            this.joinChannelVideoTab.Controls.Add(this.joinChannelVideoView);
            this.joinChannelVideoTab.Location = new System.Drawing.Point(4, 26);
            this.joinChannelVideoTab.Name = "joinChannelVideoTab";
            this.joinChannelVideoTab.Padding = new System.Windows.Forms.Padding(3);
            this.joinChannelVideoTab.Size = new System.Drawing.Size(782, 643);
            this.joinChannelVideoTab.TabIndex = 0;
            this.joinChannelVideoTab.Text = "Video Calling";
            this.joinChannelVideoTab.UseVisualStyleBackColor = true;
            // 
            // joinChannelVideoView
            // 
            this.joinChannelVideoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.joinChannelVideoView.Location = new System.Drawing.Point(3, 3);
            this.joinChannelVideoView.Margin = new System.Windows.Forms.Padding(2, 1, 2, 5);
            this.joinChannelVideoView.Name = "joinChannelVideoView";
            this.joinChannelVideoView.Size = new System.Drawing.Size(776, 637);
            this.joinChannelVideoView.TabIndex = 0;
            // 
            // joinChannelAudioTab
            // 
            this.joinChannelAudioTab.Controls.Add(this.joinChannelAudioView);
            this.joinChannelAudioTab.Location = new System.Drawing.Point(4, 26);
            this.joinChannelAudioTab.Name = "joinChannelAudioTab";
            this.joinChannelAudioTab.Padding = new System.Windows.Forms.Padding(3);
            this.joinChannelAudioTab.Size = new System.Drawing.Size(782, 643);
            this.joinChannelAudioTab.TabIndex = 1;
            this.joinChannelAudioTab.Text = "Voice Calling";
            this.joinChannelAudioTab.UseVisualStyleBackColor = true;
            // 
            // joinChannelAudioView
            // 
            this.joinChannelAudioView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.joinChannelAudioView.Location = new System.Drawing.Point(3, 3);
            this.joinChannelAudioView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.joinChannelAudioView.Name = "joinChannelAudioView";
            this.joinChannelAudioView.Size = new System.Drawing.Size(776, 637);
            this.joinChannelAudioView.TabIndex = 0;
            // 
            // screenShareTab
            // 
            this.screenShareTab.Controls.Add(this.screenShareView);
            this.screenShareTab.Location = new System.Drawing.Point(4, 26);
            this.screenShareTab.Name = "screenShareTab";
            this.screenShareTab.Padding = new System.Windows.Forms.Padding(3);
            this.screenShareTab.Size = new System.Drawing.Size(782, 643);
            this.screenShareTab.TabIndex = 2;
            this.screenShareTab.Text = "ScreenShare";
            this.screenShareTab.UseVisualStyleBackColor = true;
            // 
            // screenShareView
            // 
            this.screenShareView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenShareView.Location = new System.Drawing.Point(3, 3);
            this.screenShareView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.screenShareView.Name = "screenShareView";
            this.screenShareView.Size = new System.Drawing.Size(776, 637);
            this.screenShareView.TabIndex = 0;
            // 
            // joinMultipleChannelTab
            // 
            this.joinMultipleChannelTab.Controls.Add(this.joinMultipleChannelView);
            this.joinMultipleChannelTab.Location = new System.Drawing.Point(4, 26);
            this.joinMultipleChannelTab.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.joinMultipleChannelTab.Name = "joinMultipleChannelTab";
            this.joinMultipleChannelTab.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.joinMultipleChannelTab.Size = new System.Drawing.Size(782, 643);
            this.joinMultipleChannelTab.TabIndex = 3;
            this.joinMultipleChannelTab.Text = "MultipleChannels";
            this.joinMultipleChannelTab.UseVisualStyleBackColor = true;
            // 
            // joinMultipleChannelView
            // 
            this.joinMultipleChannelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.joinMultipleChannelView.Location = new System.Drawing.Point(2, 3);
            this.joinMultipleChannelView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.joinMultipleChannelView.Name = "joinMultipleChannelView";
            this.joinMultipleChannelView.Size = new System.Drawing.Size(778, 637);
            this.joinMultipleChannelView.TabIndex = 0;
            // 
            // processRawDataTab
            // 
            this.processRawDataTab.Controls.Add(this.processRawDataView);
            this.processRawDataTab.Location = new System.Drawing.Point(4, 26);
            this.processRawDataTab.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.processRawDataTab.Name = "processRawDataTab";
            this.processRawDataTab.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.processRawDataTab.Size = new System.Drawing.Size(782, 643);
            this.processRawDataTab.TabIndex = 5;
            this.processRawDataTab.Text = "Raw Data";
            this.processRawDataTab.UseVisualStyleBackColor = true;
            // 
            // processRawDataView
            // 
            this.processRawDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processRawDataView.Location = new System.Drawing.Point(2, 3);
            this.processRawDataView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.processRawDataView.Name = "processRawDataView";
            this.processRawDataView.Size = new System.Drawing.Size(778, 637);
            this.processRawDataView.TabIndex = 1;
            // 
            // virtualBackgroundTab
            // 
            this.virtualBackgroundTab.Controls.Add(this.virtualBackgroundView);
            this.virtualBackgroundTab.Location = new System.Drawing.Point(4, 26);
            this.virtualBackgroundTab.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.virtualBackgroundTab.Name = "virtualBackgroundTab";
            this.virtualBackgroundTab.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.virtualBackgroundTab.Size = new System.Drawing.Size(782, 643);
            this.virtualBackgroundTab.TabIndex = 6;
            this.virtualBackgroundTab.Text = "Virtual Background";
            this.virtualBackgroundTab.UseVisualStyleBackColor = true;
            // 
            // virtualBackgroundView
            // 
            this.virtualBackgroundView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.virtualBackgroundView.Location = new System.Drawing.Point(2, 3);
            this.virtualBackgroundView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.virtualBackgroundView.Name = "virtualBackgroundView";
            this.virtualBackgroundView.Size = new System.Drawing.Size(778, 637);
            this.virtualBackgroundView.TabIndex = 0;
            // 
            // leave_channel_btn
            // 
            this.leave_channel_btn.AutoSize = true;
            this.leave_channel_btn.Cursor = System.Windows.Forms.Cursors.Default;
            this.leave_channel_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leave_channel_btn.Location = new System.Drawing.Point(0, 0);
            this.leave_channel_btn.Margin = new System.Windows.Forms.Padding(3, 1, 3, 5);
            this.leave_channel_btn.Name = "leave_channel_btn";
            this.leave_channel_btn.Size = new System.Drawing.Size(395, 44);
            this.leave_channel_btn.TabIndex = 7;
            this.leave_channel_btn.Text = "leaveChannel";
            this.leave_channel_btn.UseVisualStyleBackColor = true;
            this.leave_channel_btn.Click += new System.EventHandler(this.LeaveChannelClicked);
            // 
            // join_channel_btn
            // 
            this.join_channel_btn.AutoSize = true;
            this.join_channel_btn.Cursor = System.Windows.Forms.Cursors.Default;
            this.join_channel_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.join_channel_btn.Location = new System.Drawing.Point(0, 0);
            this.join_channel_btn.Margin = new System.Windows.Forms.Padding(3, 1, 3, 5);
            this.join_channel_btn.Name = "join_channel_btn";
            this.join_channel_btn.Size = new System.Drawing.Size(393, 44);
            this.join_channel_btn.TabIndex = 7;
            this.join_channel_btn.Text = "joinChannel";
            this.join_channel_btn.UseVisualStyleBackColor = true;
            this.join_channel_btn.Click += new System.EventHandler(this.JoinChannelClicked);
            // 
            // appId_label
            // 
            this.appId_label.AutoSize = true;
            this.appId_label.Location = new System.Drawing.Point(19, 46);
            this.appId_label.Name = "appId_label";
            this.appId_label.Size = new System.Drawing.Size(53, 17);
            this.appId_label.TabIndex = 4;
            this.appId_label.Text = "AppId *";
            // 
            // channelName_label
            // 
            this.channelName_label.AutoSize = true;
            this.channelName_label.Location = new System.Drawing.Point(19, 85);
            this.channelName_label.Name = "channelName_label";
            this.channelName_label.Size = new System.Drawing.Size(75, 17);
            this.channelName_label.TabIndex = 4;
            this.channelName_label.Text = "ChannelId *";
            // 
            // appId_textBox
            // 
            this.appId_textBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.appId_textBox.Location = new System.Drawing.Point(104, 43);
            this.appId_textBox.Name = "appId_textBox";
            this.appId_textBox.Size = new System.Drawing.Size(180, 23);
            this.appId_textBox.TabIndex = 5;
            // 
            // channelId_textBox
            // 
            this.channelId_textBox.Location = new System.Drawing.Point(104, 79);
            this.channelId_textBox.Name = "channelId_textBox";
            this.channelId_textBox.PlaceholderText = "separate with \';\', e.g. ch1;ch2";
            this.channelId_textBox.Size = new System.Drawing.Size(180, 23);
            this.channelId_textBox.TabIndex = 6;
            // 
            // splitContainer_left_part
            // 
            this.splitContainer_left_part.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer_left_part.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_left_part.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_left_part.Name = "splitContainer_left_part";
            this.splitContainer_left_part.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_left_part.Panel1
            // 
            this.splitContainer_left_part.Panel1.Controls.Add(this.updateBtn);
            this.splitContainer_left_part.Panel1.Controls.Add(this.faq_linkLabel);
            this.splitContainer_left_part.Panel1.Controls.Add(this.eg_linkLabel);
            this.splitContainer_left_part.Panel1.Controls.Add(this.reg_linkLabel);
            this.splitContainer_left_part.Panel1.Controls.Add(this.api_ref);
            this.splitContainer_left_part.Panel1.Controls.Add(this.sdk_version);
            this.splitContainer_left_part.Panel1.Controls.Add(this.appId_label);
            this.splitContainer_left_part.Panel1.Controls.Add(this.appId_textBox);
            this.splitContainer_left_part.Panel1.Controls.Add(this.channelId_textBox);
            this.splitContainer_left_part.Panel1.Controls.Add(this.channelName_label);
            this.splitContainer_left_part.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // splitContainer_left_part.Panel2
            // 
            this.splitContainer_left_part.Panel2.Controls.Add(this.clear_msg_btn);
            this.splitContainer_left_part.Panel2.Controls.Add(this.status_tips);
            this.splitContainer_left_part.Size = new System.Drawing.Size(384, 719);
            this.splitContainer_left_part.SplitterDistance = 163;
            this.splitContainer_left_part.TabIndex = 7;
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(296, 78);
            this.updateBtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(61, 25);
            this.updateBtn.TabIndex = 13;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.OnIdUpdate);
            // 
            // faq_linkLabel
            // 
            this.faq_linkLabel.AutoSize = true;
            this.faq_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.faq_linkLabel.Location = new System.Drawing.Point(270, 119);
            this.faq_linkLabel.Name = "faq_linkLabel";
            this.faq_linkLabel.Size = new System.Drawing.Size(32, 17);
            this.faq_linkLabel.TabIndex = 12;
            this.faq_linkLabel.TabStop = true;
            this.faq_linkLabel.Text = "FAQ";
            this.faq_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkBtnClicked);
            // 
            // eg_linkLabel
            // 
            this.eg_linkLabel.AutoSize = true;
            this.eg_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.eg_linkLabel.Location = new System.Drawing.Point(199, 119);
            this.eg_linkLabel.Name = "eg_linkLabel";
            this.eg_linkLabel.Size = new System.Drawing.Size(57, 17);
            this.eg_linkLabel.TabIndex = 11;
            this.eg_linkLabel.TabStop = true;
            this.eg_linkLabel.Text = "Samples";
            this.eg_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkBtnClicked);
            // 
            // reg_linkLabel
            // 
            this.reg_linkLabel.AutoSize = true;
            this.reg_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.reg_linkLabel.Location = new System.Drawing.Point(131, 119);
            this.reg_linkLabel.Name = "reg_linkLabel";
            this.reg_linkLabel.Size = new System.Drawing.Size(54, 17);
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
            this.api_ref.Location = new System.Drawing.Point(44, 119);
            this.api_ref.Name = "api_ref";
            this.api_ref.Size = new System.Drawing.Size(73, 17);
            this.api_ref.TabIndex = 9;
            this.api_ref.TabStop = true;
            this.api_ref.Text = "Documents";
            this.api_ref.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkBtnClicked);
            // 
            // sdk_version
            // 
            this.sdk_version.AutoSize = true;
            this.sdk_version.Location = new System.Drawing.Point(70, 15);
            this.sdk_version.Name = "sdk_version";
            this.sdk_version.Size = new System.Drawing.Size(0, 17);
            this.sdk_version.TabIndex = 7;
            // 
            // clear_msg_btn
            // 
            this.clear_msg_btn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.clear_msg_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.clear_msg_btn.Location = new System.Drawing.Point(0, 510);
            this.clear_msg_btn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.clear_msg_btn.Name = "clear_msg_btn";
            this.clear_msg_btn.Size = new System.Drawing.Size(384, 42);
            this.clear_msg_btn.TabIndex = 3;
            this.clear_msg_btn.Text = "Clear";
            this.clear_msg_btn.UseVisualStyleBackColor = true;
            this.clear_msg_btn.Click += new System.EventHandler(this.OnClearBtnClicked);
            // 
            // splitContainer_horizon_all
            // 
            this.splitContainer_horizon_all.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer_horizon_all.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_horizon_all.Location = new System.Drawing.Point(3, 3);
            this.splitContainer_horizon_all.Name = "splitContainer_horizon_all";
            // 
            // splitContainer_horizon_all.Panel1
            // 
            this.splitContainer_horizon_all.Panel1.Controls.Add(this.splitContainer_left_part);
            // 
            // splitContainer_horizon_all.Panel2
            // 
            this.splitContainer_horizon_all.Panel2.Controls.Add(this.splitContainer_right_Vertical);
            this.splitContainer_horizon_all.Size = new System.Drawing.Size(1178, 719);
            this.splitContainer_horizon_all.SplitterDistance = 384;
            this.splitContainer_horizon_all.TabIndex = 8;
            // 
            // splitContainer_right_Vertical
            // 
            this.splitContainer_right_Vertical.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer_right_Vertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_right_Vertical.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_right_Vertical.Name = "splitContainer_right_Vertical";
            this.splitContainer_right_Vertical.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_right_Vertical.Panel1
            // 
            this.splitContainer_right_Vertical.Panel1.Controls.Add(this.tabCtrl);
            // 
            // splitContainer_right_Vertical.Panel2
            // 
            this.splitContainer_right_Vertical.Panel2.Controls.Add(this.btn_splitContainer);
            this.splitContainer_right_Vertical.Size = new System.Drawing.Size(790, 719);
            this.splitContainer_right_Vertical.SplitterDistance = 673;
            this.splitContainer_right_Vertical.SplitterWidth = 2;
            this.splitContainer_right_Vertical.TabIndex = 9;
            // 
            // btn_splitContainer
            // 
            this.btn_splitContainer.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.btn_splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_splitContainer.Location = new System.Drawing.Point(0, 0);
            this.btn_splitContainer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_splitContainer.Name = "btn_splitContainer";
            // 
            // btn_splitContainer.Panel1
            // 
            this.btn_splitContainer.Panel1.Controls.Add(this.join_channel_btn);
            // 
            // btn_splitContainer.Panel2
            // 
            this.btn_splitContainer.Panel2.Controls.Add(this.leave_channel_btn);
            this.btn_splitContainer.Size = new System.Drawing.Size(790, 44);
            this.btn_splitContainer.SplitterDistance = 393;
            this.btn_splitContainer.SplitterWidth = 2;
            this.btn_splitContainer.TabIndex = 8;
            // 
            // CSharpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 725);
            this.Controls.Add(this.splitContainer_horizon_all);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CSharpForm";
            this.Opacity = 0.99D;
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "CSharpForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.tabCtrl.ResumeLayout(false);
            this.joinChannelVideoTab.ResumeLayout(false);
            this.joinChannelAudioTab.ResumeLayout(false);
            this.screenShareTab.ResumeLayout(false);
            this.joinMultipleChannelTab.ResumeLayout(false);
            this.processRawDataTab.ResumeLayout(false);
            this.virtualBackgroundTab.ResumeLayout(false);
            this.splitContainer_left_part.Panel1.ResumeLayout(false);
            this.splitContainer_left_part.Panel1.PerformLayout();
            this.splitContainer_left_part.Panel2.ResumeLayout(false);
            this.splitContainer_left_part.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_left_part)).EndInit();
            this.splitContainer_left_part.ResumeLayout(false);
            this.splitContainer_horizon_all.Panel1.ResumeLayout(false);
            this.splitContainer_horizon_all.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_horizon_all)).EndInit();
            this.splitContainer_horizon_all.ResumeLayout(false);
            this.splitContainer_right_Vertical.Panel1.ResumeLayout(false);
            this.splitContainer_right_Vertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_right_Vertical)).EndInit();
            this.splitContainer_right_Vertical.ResumeLayout(false);
            this.btn_splitContainer.Panel1.ResumeLayout(false);
            this.btn_splitContainer.Panel1.PerformLayout();
            this.btn_splitContainer.Panel2.ResumeLayout(false);
            this.btn_splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_splitContainer)).EndInit();
            this.btn_splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.SplitContainer splitContainer_left_part;
        private System.Windows.Forms.SplitContainer splitContainer_horizon_all;
        private System.Windows.Forms.Button leave_channel_btn;
        private System.Windows.Forms.Button join_channel_btn;
        private System.Windows.Forms.Label sdk_version;
        private System.Windows.Forms.LinkLabel api_ref;
        private System.Windows.Forms.LinkLabel reg_linkLabel;
        private System.Windows.Forms.LinkLabel eg_linkLabel;
        private System.Windows.Forms.LinkLabel faq_linkLabel;
        public System.Windows.Forms.TextBox status_tips;
        private System.Windows.Forms.SplitContainer btn_splitContainer;
        private System.Windows.Forms.SplitContainer splitContainer_right_Vertical;
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
    }
}

