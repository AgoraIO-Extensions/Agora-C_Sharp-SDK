using System;
using System.Windows;
using System.Windows.Controls;

namespace APIExample
{
    delegate void dumpHandler(string tag, int ret);

    public partial class MainWindow : Window
    {
        internal static IEngine usr_engine_ = null;
        internal static dumpHandler dump_handler_ = null;

        private string app_id_ = "";  // cannot be empty!!!
        private string channel_id_ = "123;456"; // 2 channel id for multichannel
        private readonly string app_name_ = "CSharp API Example ";

        public MainWindow()
        {
            InitializeComponent();

            // just for debug
            dump_handler_ = new dumpHandler(DumpStatus);
            usr_engine_ = new JoinChannelVideo(localView.Handle, firstRemoteView.Handle);
        }

        public void SwitchVideoCanvas(object sender, EventArgs e)
        {
            if (tabCtrl.SelectedItem == joinChannelVideoTab) // 一对一视频
            {
                usr_engine_.SwitchVideoCanvas();
            }
        }
        private void onJoinChannel(object sender, RoutedEventArgs e)
        {
            if (null != usr_engine_)
            {
                int ret = -1;
                ret = usr_engine_.Init(app_id_, channel_id_);
                DumpStatus("Init", ret);
                if (0 == ret)
                {
                    var win_title = app_name_ + usr_engine_.GetSDKVersion();
                    Title = win_title;
                }

                ret = usr_engine_.JoinChannel();
                DumpStatus("JoinChannel", ret);
            }
        }

        private void onLeaveChannel(object sender, RoutedEventArgs e)
        {
            if (null != usr_engine_)
            {
                int ret = usr_engine_.LeaveChannel();
                DumpStatus("LeaveChannel", ret);
            }
        }

        private void onSceneChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (null != usr_engine_)
            {
                usr_engine_.UnInit();
                usr_engine_ = null;
            }
            if (tabCtrl.SelectedItem == joinChannelVideoTab) // 一对一视频
            {
                usr_engine_ = new JoinChannelVideo(localView.Handle, firstRemoteView.Handle);
            }
            else if (tabCtrl.SelectedItem == joinChannelAudioTab) // 一对一语音
            {
                usr_engine_ = new JoinChannelAudio();
            }
            else if (tabCtrl.SelectedItem == screenShareTab) // 摄像头 + 屏幕共享
            {
                usr_engine_ = new ScreenShare(firstRemoteView.Handle, localView.Handle);
            }
            else if (tabCtrl.SelectedItem == joinMultipleChannelTab)  // 多频道
            {
                usr_engine_ = new JoinMultipleChannel(localView.Handle,
                   firstRemoteView.Handle, secondRemoteView.Handle);
            }
            else if (tabCtrl.SelectedItem == videoGroupTab) // 多人视频
            {
                usr_engine_ = new VideoGroup(localView.Handle,
                    firstRemoteView.Handle, secondRemoteView.Handle);
            }
            else if (tabCtrl.SelectedItem == processRawDataTab) // 祼数据
            {
                usr_engine_ = new ProcessRawData(localView.Handle, firstRemoteView.Handle);
            }
            else if (tabCtrl.SelectedItem == virtualBackgroundTab) // 虚拟背景
            {
                usr_engine_ = new VirtualBackground(localView.Handle, firstRemoteView.Handle);
            }
            else
            {
                DumpStatus("support in future", -1024);
            }
        }
        private void onClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (null != usr_engine_)
            {
                usr_engine_.UnInit();
                usr_engine_ = null;
            }
        }

        public void DumpStatus(string tag, int ret)
        {
            string tips = tag;
            if (ret != 0)
            {
                tips += " failed, ret =" + ret.ToString();
            }
            else
            {
                tips += " ok";
            }
            statusTips.Text += tips + "\r\n";
        }

        private void onClear(object sender, RoutedEventArgs e)
        {
            statusTips.Text = "";
        }
    }
}
