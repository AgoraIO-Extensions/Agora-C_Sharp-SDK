/*
 * 须知：
 * 1. 准备好AppId、ChannelId，并通过界面设置（点更新ID按钮），避免应用程序重启重复输入
 * 2. 根据实际需要，准备好一定数量的“窗口”，用于显示，构造时传给各场景。
 * 3. 各场景APIs调用流程略有不同，具体请参考各场景的示例
 * 
 * 注意：多个频道Id请以“;”分隔，但都必须有效，此时，如果是单频道场景，则仅使用第一个频道Id。
 * 如输入了“123;456;789”，对于单频道场景，仅使用123；对于多频道场景，则频道1 Id为123，频道2 Id为456，频道3 Id为789。
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.Linq;

namespace CSharp_API_Example
{
    delegate void dumpHandler(string tag, int ret);

    public partial class CSharpForm : Form
    {
        internal static IEngine usr_engine_ = null;
        internal static dumpHandler dump_handler_ = null;
        // config
        private ConfigHelper config_helper_ = null;
        private readonly string SECTION = "must";
        private readonly string APPID_KEY = "AppId";
        private readonly string CHANNELID_KEY = "ChannelId";

        public CSharpForm()
        {
            InitializeComponent();
            InitUI();

            // just for debug
            dump_handler_ = new dumpHandler(DumpStatus);

            // local_win_id, remote_win_id
            usr_engine_ = new Video1To1(video1To1View.localVideoView.Handle, video1To1View.remoteVideoView.Handle);
        }

        private void CheckId()
        {
            string app_id = appId_textBox.Text;
            if (app_id.Length < 10)
            {
                appId_textBox.BackColor = Color.OrangeRed;
            }
            else
            {
                appId_textBox.BackColor = Color.White;
            }

            string channel_id = channelId_textBox.Text;
            if(IsAllChannelIdValid(channel_id))
            {
                channelId_textBox.BackColor = Color.White;
            }
            else
            {
                channelId_textBox.BackColor = Color.OrangeRed;
            }
        }

        private void InitUI()
        {
            config_helper_ = new ConfigHelper();
            appId_textBox.Text = config_helper_.GetValue(SECTION, APPID_KEY);
            channelId_textBox.Text = config_helper_.GetValue(SECTION, CHANNELID_KEY);
            CheckId();

            string api_ref_url = @"https://docs.agora.io/cn/Video/API Reference/cpp/index.html";
            string reg_url = @"https://console.agora.io/";
            string eg_url = @"https://github.com/AgoraIO/API-Examples";
            string faq_url = @"https://docs.agora.io/cn/Video/faq?platform=All Platforms";
            api_ref.Links.Add(0, api_ref_url.Length, api_ref_url);
            reg_linkLabel.Links.Add(0, reg_url.Length, reg_url);
            eg_linkLabel.Links.Add(0, eg_url.Length, eg_url);
            faq_linkLabel.Links.Add(0, faq_url.Length, faq_url);
        }

        private void JoinChannelClicked(object sender, EventArgs e)
        {
            if (null != usr_engine_)
            {
                int ret = -1;
                ret = usr_engine_.Init(appId_textBox.Text, channelId_textBox.Text);
                DumpStatus("Init", ret);
                if(0 == ret) {
                    sdk_version.Text = "SDK Version: " + usr_engine_.GetSDKVersion();
                }

                ret = usr_engine_.JoinChannel();
                DumpStatus("joinChannel", ret);
            }
        }

        private void LeaveChannelClicked(object sender, EventArgs e)
        {
            if (null != usr_engine_)
            {
                int ret = usr_engine_.LeaveChannel();
                DumpStatus("LeaveChannel", ret);
            }
        }

        private void OnSceneChanged(object sender, EventArgs e)
        {
            if (null != usr_engine_)
            {
                usr_engine_.UnInit();
                usr_engine_ = null;
            }

            if (tabCtrl.SelectedTab == video1v1Tab) // 一对一视频
            {
                usr_engine_ = new Video1To1(video1To1View.localVideoView.Handle, video1To1View.remoteVideoView.Handle);
            }
            else if (tabCtrl.SelectedTab == audio1v1Tab) // 一对一语音
            {
                usr_engine_ = new Audio1To1();
            }
            else if (tabCtrl.SelectedTab == screenShareTab) // 摄像头 + 屏幕共享
            {
                usr_engine_ = new ScreenShare(screenShareView.localVideoView.Handle, screenShareView.remoteVideoView.Handle);
            }
            else if (tabCtrl.SelectedTab == multiChannelTab)  // 多频道
            {
                usr_engine_ = new MultiChannel(multiChannelView.localVideoView.Handle, 
                    multiChannelView.firstChannelVideoView.Handle, multiChannelView.secondChannelVideoView.Handle);
            }
            else if (tabCtrl.SelectedTab == videoGroupTab) // 多人视频
            {
                usr_engine_ = new VideoGroup(videoGroupView.localVideoView.Handle,
                    videoGroupView.fistUserVideoView.Handle, videoGroupView.secondUserVideoView.Handle);
            }
            else
            {
                DumpStatus("todo", 0);
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (null != usr_engine_)
            {
                usr_engine_.UnInit();
                usr_engine_ = null;
            }
        }

        private void OnClearBtnClicked(object sender, EventArgs e)
        {
            status_tips.Clear();
        }

        private void OnIdUpdate(object sender, EventArgs e)
        {
            config_helper_.SetValue(SECTION, APPID_KEY, appId_textBox.Text);
            config_helper_.SetValue(SECTION, CHANNELID_KEY, channelId_textBox.Text);
            CheckId();
        }

        private void LinkBtnClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string file_name = e.Link.LinkData as string;
            OpenUrl(file_name);
        }

        private void OpenUrl(string url)
        {
            string def_browser = GetSystemDefaultBrowser();

            if (!string.IsNullOrEmpty(def_browser))
            {
                Process.Start(def_browser, url);
            }
            else
            {
                Process.Start(url);
            }
        }

        private string GetSystemDefaultBrowser()
        {
            string name = string.Empty;
            RegistryKey regKey = null;

            try
            {
                var reg_def = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.htm\\UserChoice", false);
                var str_def = reg_def.GetValue("ProgId");

                regKey = Registry.ClassesRoot.OpenSubKey(str_def + "\\shell\\open\\command", false);
                name = regKey.GetValue(null).ToString().ToLower().Replace("" + (char)34, "");

                if (!name.EndsWith("exe"))
                {
                    name = name.Substring(0, name.LastIndexOf(".exe") + 4);
                }
            }
            catch (Exception ex)
            {
                DumpStatus(String.Format("{0}", ex.Message), -1);
            }
            finally
            {
                if (regKey != null)
                {
                    regKey.Close();
                }
            }
            return name;
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
            status_tips.Text += tips + "\r\n";
        }

        private bool IsAllChannelIdValid(string channel_ids)
        {
            bool ret = false;
            string[] channel_id_array = channel_ids.Trim(';').Split(';');

            foreach (string id in channel_id_array)
            {
                if (IsChannelIdValid(id))
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                    break;
                }
            }
            return ret;
        }

        // check rules: https://docs.agora.io/cn/Video/API%20Reference/cpp/classagora_1_1rtc_1_1_i_rtc_engine.html#adc937172e59bd2695ea171553a88188c
        private bool IsChannelIdValid(string channel_id)
        {
            if (channel_id.Length > 64 || 0 == channel_id.Length)
                return false;

            var channelIdChar = channel_id.ToCharArray();
            return !(from nameChar in channelIdChar
                     where nameChar < 'a' || nameChar > 'z'
                     where nameChar < 'A' || nameChar > 'Z'
                     where nameChar < '0' || nameChar > '9'
                     let temp = new[]
                     {
                    '!', '#', '$', '%', '&', '(', ')', '+', '-', ':', ';', '<', '=', '.', '>', '?', '@', '[', ']', '^',
                    '_', '{', '}', '|', '~', ',', (char)32
                     }
                     where Array.IndexOf(temp, nameChar) < 0
                     select nameChar).Any();
        }
    }
}
