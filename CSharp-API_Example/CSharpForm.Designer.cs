
namespace CSharp_API_Example
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
            this.video1v1Tab = new System.Windows.Forms.TabPage();
            this.video1To1View = new CSharp_API_Example.Video1To1View();
            this.audio1v1Tab = new System.Windows.Forms.TabPage();
            this.audio1To1View = new CSharp_API_Example.Audio1To1View();
            this.screenShareTab = new System.Windows.Forms.TabPage();
            this.screenShareView = new CSharp_API_Example.ScreenShareView();
            this.multiChannelTab = new System.Windows.Forms.TabPage();
            this.multiChannelView = new CSharp_API_Example.MultiChannelView();
            this.videoGroupTab = new System.Windows.Forms.TabPage();
            this.videoGroupView = new CSharp_API_Example.VideoGroupView();
            this.rawDataTab = new System.Windows.Forms.TabPage();
            this.rawDataView = new CSharp_API_Example.RawDataView();
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
            this.virtualBackgroundTab = new System.Windows.Forms.TabPage();
            this.virtualBackgroundView = new CSharp_API_Example.VirtualBackgroundView();
            this.tabCtrl.SuspendLayout();
            this.video1v1Tab.SuspendLayout();
            this.audio1v1Tab.SuspendLayout();
            this.screenShareTab.SuspendLayout();
            this.multiChannelTab.SuspendLayout();
            this.videoGroupTab.SuspendLayout();
            this.rawDataTab.SuspendLayout();
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
            this.virtualBackgroundTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // status_tips
            // 
            this.status_tips.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.status_tips.Dock = System.Windows.Forms.DockStyle.Top;
            this.status_tips.Location = new System.Drawing.Point(0, 0);
            this.status_tips.Margin = new System.Windows.Forms.Padding(10, 4, 3, 4);
            this.status_tips.Multiline = true;
            this.status_tips.Name = "status_tips";
            this.status_tips.ReadOnly = true;
            this.status_tips.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.status_tips.Size = new System.Drawing.Size(494, 595);
            this.status_tips.TabIndex = 2;
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.video1v1Tab);
            this.tabCtrl.Controls.Add(this.audio1v1Tab);
            this.tabCtrl.Controls.Add(this.screenShareTab);
            this.tabCtrl.Controls.Add(this.multiChannelTab);
            this.tabCtrl.Controls.Add(this.videoGroupTab);
            this.tabCtrl.Controls.Add(this.rawDataTab);
            this.tabCtrl.Controls.Add(this.virtualBackgroundTab);
            this.tabCtrl.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrl.Location = new System.Drawing.Point(0, 0);
            this.tabCtrl.Margin = new System.Windows.Forms.Padding(5);
            this.tabCtrl.Multiline = true;
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(1015, 792);
            this.tabCtrl.TabIndex = 3;
            this.tabCtrl.SelectedIndexChanged += new System.EventHandler(this.OnSceneChanged);
            // 
            // video1v1Tab
            // 
            this.video1v1Tab.Controls.Add(this.video1To1View);
            this.video1v1Tab.Location = new System.Drawing.Point(4, 29);
            this.video1v1Tab.Margin = new System.Windows.Forms.Padding(4);
            this.video1v1Tab.Name = "video1v1Tab";
            this.video1v1Tab.Padding = new System.Windows.Forms.Padding(4);
            this.video1v1Tab.Size = new System.Drawing.Size(1007, 759);
            this.video1v1Tab.TabIndex = 0;
            this.video1v1Tab.Text = "视频1v1";
            this.video1v1Tab.UseVisualStyleBackColor = true;
            // 
            // video1To1View
            // 
            this.video1To1View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.video1To1View.Location = new System.Drawing.Point(4, 4);
            this.video1To1View.Margin = new System.Windows.Forms.Padding(3, 1, 3, 6);
            this.video1To1View.Name = "video1To1View";
            this.video1To1View.Size = new System.Drawing.Size(999, 751);
            this.video1To1View.TabIndex = 0;
            // 
            // audio1v1Tab
            // 
            this.audio1v1Tab.Controls.Add(this.audio1To1View);
            this.audio1v1Tab.Location = new System.Drawing.Point(4, 29);
            this.audio1v1Tab.Margin = new System.Windows.Forms.Padding(4);
            this.audio1v1Tab.Name = "audio1v1Tab";
            this.audio1v1Tab.Padding = new System.Windows.Forms.Padding(4);
            this.audio1v1Tab.Size = new System.Drawing.Size(1007, 759);
            this.audio1v1Tab.TabIndex = 1;
            this.audio1v1Tab.Text = "音频1v1";
            this.audio1v1Tab.UseVisualStyleBackColor = true;
            // 
            // audio1To1View
            // 
            this.audio1To1View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.audio1To1View.Location = new System.Drawing.Point(4, 4);
            this.audio1To1View.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.audio1To1View.Name = "audio1To1View";
            this.audio1To1View.Size = new System.Drawing.Size(999, 751);
            this.audio1To1View.TabIndex = 0;
            // 
            // screenShareTab
            // 
            this.screenShareTab.Controls.Add(this.screenShareView);
            this.screenShareTab.Location = new System.Drawing.Point(4, 29);
            this.screenShareTab.Margin = new System.Windows.Forms.Padding(4);
            this.screenShareTab.Name = "screenShareTab";
            this.screenShareTab.Padding = new System.Windows.Forms.Padding(4);
            this.screenShareTab.Size = new System.Drawing.Size(1007, 759);
            this.screenShareTab.TabIndex = 2;
            this.screenShareTab.Text = "屏幕共享";
            this.screenShareTab.UseVisualStyleBackColor = true;
            // 
            // screenShareView
            // 
            this.screenShareView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenShareView.Location = new System.Drawing.Point(4, 4);
            this.screenShareView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.screenShareView.Name = "screenShareView";
            this.screenShareView.Size = new System.Drawing.Size(999, 751);
            this.screenShareView.TabIndex = 0;
            // 
            // multiChannelTab
            // 
            this.multiChannelTab.Controls.Add(this.multiChannelView);
            this.multiChannelTab.Location = new System.Drawing.Point(4, 29);
            this.multiChannelTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.multiChannelTab.Name = "multiChannelTab";
            this.multiChannelTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.multiChannelTab.Size = new System.Drawing.Size(1007, 759);
            this.multiChannelTab.TabIndex = 3;
            this.multiChannelTab.Text = "多频道";
            this.multiChannelTab.UseVisualStyleBackColor = true;
            // 
            // multiChannelView
            // 
            this.multiChannelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiChannelView.Location = new System.Drawing.Point(3, 4);
            this.multiChannelView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.multiChannelView.Name = "multiChannelView";
            this.multiChannelView.Size = new System.Drawing.Size(1001, 751);
            this.multiChannelView.TabIndex = 0;
            // 
            // videoGroupTab
            // 
            this.videoGroupTab.Controls.Add(this.videoGroupView);
            this.videoGroupTab.Location = new System.Drawing.Point(4, 29);
            this.videoGroupTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.videoGroupTab.Name = "videoGroupTab";
            this.videoGroupTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.videoGroupTab.Size = new System.Drawing.Size(1007, 759);
            this.videoGroupTab.TabIndex = 4;
            this.videoGroupTab.Text = "多人视频";
            this.videoGroupTab.UseVisualStyleBackColor = true;
            // 
            // videoGroupView
            // 
            this.videoGroupView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoGroupView.Location = new System.Drawing.Point(3, 4);
            this.videoGroupView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.videoGroupView.Name = "videoGroupView";
            this.videoGroupView.Size = new System.Drawing.Size(1001, 751);
            this.videoGroupView.TabIndex = 0;
            // 
            // rawDataTab
            // 
            this.rawDataTab.Controls.Add(this.rawDataView);
            this.rawDataTab.Location = new System.Drawing.Point(4, 29);
            this.rawDataTab.Name = "rawDataTab";
            this.rawDataTab.Padding = new System.Windows.Forms.Padding(3);
            this.rawDataTab.Size = new System.Drawing.Size(1007, 759);
            this.rawDataTab.TabIndex = 5;
            this.rawDataTab.Text = "裸数据";
            this.rawDataTab.UseVisualStyleBackColor = true;
            // 
            // rawDataView
            // 
            this.rawDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rawDataView.Location = new System.Drawing.Point(3, 3);
            this.rawDataView.Name = "rawDataView";
            this.rawDataView.Size = new System.Drawing.Size(1001, 753);
            this.rawDataView.TabIndex = 1;
            // 
            // leave_channel_btn
            // 
            this.leave_channel_btn.AutoSize = true;
            this.leave_channel_btn.Cursor = System.Windows.Forms.Cursors.Default;
            this.leave_channel_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leave_channel_btn.Location = new System.Drawing.Point(0, 0);
            this.leave_channel_btn.Margin = new System.Windows.Forms.Padding(4, 1, 4, 6);
            this.leave_channel_btn.Name = "leave_channel_btn";
            this.leave_channel_btn.Size = new System.Drawing.Size(507, 51);
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
            this.join_channel_btn.Margin = new System.Windows.Forms.Padding(4, 1, 4, 6);
            this.join_channel_btn.Name = "join_channel_btn";
            this.join_channel_btn.Size = new System.Drawing.Size(505, 51);
            this.join_channel_btn.TabIndex = 7;
            this.join_channel_btn.Text = "joinChannel";
            this.join_channel_btn.UseVisualStyleBackColor = true;
            this.join_channel_btn.Click += new System.EventHandler(this.JoinChannelClicked);
            // 
            // appId_label
            // 
            this.appId_label.AutoSize = true;
            this.appId_label.Location = new System.Drawing.Point(24, 54);
            this.appId_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.appId_label.Name = "appId_label";
            this.appId_label.Size = new System.Drawing.Size(54, 20);
            this.appId_label.TabIndex = 4;
            this.appId_label.Text = "AppId";
            // 
            // channelName_label
            // 
            this.channelName_label.AutoSize = true;
            this.channelName_label.Location = new System.Drawing.Point(24, 100);
            this.channelName_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.channelName_label.Name = "channelName_label";
            this.channelName_label.Size = new System.Drawing.Size(81, 20);
            this.channelName_label.TabIndex = 4;
            this.channelName_label.Text = "ChannelId";
            // 
            // appId_textBox
            // 
            this.appId_textBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.appId_textBox.Location = new System.Drawing.Point(90, 51);
            this.appId_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.appId_textBox.Name = "appId_textBox";
            this.appId_textBox.PlaceholderText = "通过“注册账号”获取，不能为空";
            this.appId_textBox.Size = new System.Drawing.Size(368, 27);
            this.appId_textBox.TabIndex = 5;
            // 
            // channelId_textBox
            // 
            this.channelId_textBox.Location = new System.Drawing.Point(111, 93);
            this.channelId_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.channelId_textBox.Name = "channelId_textBox";
            this.channelId_textBox.PlaceholderText = "多个频道Id以;分隔，但要都有效";
            this.channelId_textBox.Size = new System.Drawing.Size(253, 27);
            this.channelId_textBox.TabIndex = 6;
            // 
            // splitContainer_left_part
            // 
            this.splitContainer_left_part.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer_left_part.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_left_part.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_left_part.Margin = new System.Windows.Forms.Padding(4);
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
            this.splitContainer_left_part.Size = new System.Drawing.Size(494, 845);
            this.splitContainer_left_part.SplitterDistance = 192;
            this.splitContainer_left_part.SplitterWidth = 5;
            this.splitContainer_left_part.TabIndex = 7;
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(381, 92);
            this.updateBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(78, 29);
            this.updateBtn.TabIndex = 13;
            this.updateBtn.Text = "更新Id";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.OnIdUpdate);
            // 
            // faq_linkLabel
            // 
            this.faq_linkLabel.AutoSize = true;
            this.faq_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.faq_linkLabel.Location = new System.Drawing.Point(288, 140);
            this.faq_linkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.faq_linkLabel.Name = "faq_linkLabel";
            this.faq_linkLabel.Size = new System.Drawing.Size(69, 20);
            this.faq_linkLabel.TabIndex = 12;
            this.faq_linkLabel.TabStop = true;
            this.faq_linkLabel.Text = "常见问题";
            this.faq_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkBtnClicked);
            // 
            // eg_linkLabel
            // 
            this.eg_linkLabel.AutoSize = true;
            this.eg_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.eg_linkLabel.Location = new System.Drawing.Point(198, 140);
            this.eg_linkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.eg_linkLabel.Name = "eg_linkLabel";
            this.eg_linkLabel.Size = new System.Drawing.Size(69, 20);
            this.eg_linkLabel.TabIndex = 11;
            this.eg_linkLabel.TabStop = true;
            this.eg_linkLabel.Text = "示例代码";
            this.eg_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkBtnClicked);
            // 
            // reg_linkLabel
            // 
            this.reg_linkLabel.AutoSize = true;
            this.reg_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.reg_linkLabel.Location = new System.Drawing.Point(114, 140);
            this.reg_linkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.reg_linkLabel.Name = "reg_linkLabel";
            this.reg_linkLabel.Size = new System.Drawing.Size(69, 20);
            this.reg_linkLabel.TabIndex = 10;
            this.reg_linkLabel.TabStop = true;
            this.reg_linkLabel.Text = "注册账号";
            this.reg_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkBtnClicked);
            // 
            // api_ref
            // 
            this.api_ref.AutoSize = true;
            this.api_ref.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.api_ref.LinkVisited = true;
            this.api_ref.Location = new System.Drawing.Point(32, 140);
            this.api_ref.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.api_ref.Name = "api_ref";
            this.api_ref.Size = new System.Drawing.Size(63, 20);
            this.api_ref.TabIndex = 9;
            this.api_ref.TabStop = true;
            this.api_ref.Text = "API手册";
            this.api_ref.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkBtnClicked);
            // 
            // sdk_version
            // 
            this.sdk_version.AutoSize = true;
            this.sdk_version.Location = new System.Drawing.Point(90, 18);
            this.sdk_version.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sdk_version.Name = "sdk_version";
            this.sdk_version.Size = new System.Drawing.Size(0, 20);
            this.sdk_version.TabIndex = 7;
            // 
            // clear_msg_btn
            // 
            this.clear_msg_btn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.clear_msg_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.clear_msg_btn.Location = new System.Drawing.Point(0, 599);
            this.clear_msg_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clear_msg_btn.Name = "clear_msg_btn";
            this.clear_msg_btn.Size = new System.Drawing.Size(494, 49);
            this.clear_msg_btn.TabIndex = 3;
            this.clear_msg_btn.Text = "清空";
            this.clear_msg_btn.UseVisualStyleBackColor = true;
            this.clear_msg_btn.Click += new System.EventHandler(this.OnClearBtnClicked);
            // 
            // splitContainer_horizon_all
            // 
            this.splitContainer_horizon_all.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer_horizon_all.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_horizon_all.Location = new System.Drawing.Point(4, 4);
            this.splitContainer_horizon_all.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer_horizon_all.Name = "splitContainer_horizon_all";
            // 
            // splitContainer_horizon_all.Panel1
            // 
            this.splitContainer_horizon_all.Panel1.Controls.Add(this.splitContainer_left_part);
            // 
            // splitContainer_horizon_all.Panel2
            // 
            this.splitContainer_horizon_all.Panel2.Controls.Add(this.splitContainer_right_Vertical);
            this.splitContainer_horizon_all.Size = new System.Drawing.Size(1514, 845);
            this.splitContainer_horizon_all.SplitterDistance = 494;
            this.splitContainer_horizon_all.SplitterWidth = 5;
            this.splitContainer_horizon_all.TabIndex = 8;
            // 
            // splitContainer_right_Vertical
            // 
            this.splitContainer_right_Vertical.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer_right_Vertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_right_Vertical.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_right_Vertical.Margin = new System.Windows.Forms.Padding(4);
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
            this.splitContainer_right_Vertical.Size = new System.Drawing.Size(1015, 845);
            this.splitContainer_right_Vertical.SplitterDistance = 792;
            this.splitContainer_right_Vertical.SplitterWidth = 2;
            this.splitContainer_right_Vertical.TabIndex = 9;
            // 
            // btn_splitContainer
            // 
            this.btn_splitContainer.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.btn_splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_splitContainer.Location = new System.Drawing.Point(0, 0);
            this.btn_splitContainer.Name = "btn_splitContainer";
            // 
            // btn_splitContainer.Panel1
            // 
            this.btn_splitContainer.Panel1.Controls.Add(this.join_channel_btn);
            // 
            // btn_splitContainer.Panel2
            // 
            this.btn_splitContainer.Panel2.Controls.Add(this.leave_channel_btn);
            this.btn_splitContainer.Size = new System.Drawing.Size(1015, 51);
            this.btn_splitContainer.SplitterDistance = 505;
            this.btn_splitContainer.SplitterWidth = 3;
            this.btn_splitContainer.TabIndex = 8;
            // 
            // virtualBackgroundTab
            // 
            this.virtualBackgroundTab.Controls.Add(this.virtualBackgroundView);
            this.virtualBackgroundTab.Location = new System.Drawing.Point(4, 29);
            this.virtualBackgroundTab.Name = "virtualBackgroundTab";
            this.virtualBackgroundTab.Padding = new System.Windows.Forms.Padding(3);
            this.virtualBackgroundTab.Size = new System.Drawing.Size(1007, 759);
            this.virtualBackgroundTab.TabIndex = 6;
            this.virtualBackgroundTab.Text = "虚拟背景";
            this.virtualBackgroundTab.UseVisualStyleBackColor = true;
            // 
            // virtualBackgroundView
            // 
            this.virtualBackgroundView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.virtualBackgroundView.Location = new System.Drawing.Point(3, 3);
            this.virtualBackgroundView.Name = "virtualBackgroundView";
            this.virtualBackgroundView.Size = new System.Drawing.Size(1001, 753);
            this.virtualBackgroundView.TabIndex = 0;
            // 
            // CSharpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1522, 853);
            this.Controls.Add(this.splitContainer_horizon_all);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CSharpForm";
            this.Opacity = 0.99D;
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "CSharpForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.tabCtrl.ResumeLayout(false);
            this.video1v1Tab.ResumeLayout(false);
            this.audio1v1Tab.ResumeLayout(false);
            this.screenShareTab.ResumeLayout(false);
            this.multiChannelTab.ResumeLayout(false);
            this.videoGroupTab.ResumeLayout(false);
            this.rawDataTab.ResumeLayout(false);
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
            this.virtualBackgroundTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage video1v1Tab;
        private System.Windows.Forms.TabPage audio1v1Tab;
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
        private System.Windows.Forms.TabPage multiChannelTab;
        private Video1To1View video1To1View;
        private Audio1To1View audio1To1View;
        private ScreenShareView screenShareView;
        private MultiChannelView multiChannelView;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.TabPage videoGroupTab;
        private VideoGroupView videoGroupView;
        private System.Windows.Forms.TabPage rawDataTab;
        private RawDataView rawDataView;
        private System.Windows.Forms.TabPage virtualBackgroundTab;
        private VirtualBackgroundView virtualBackgroundView;
    }
}

