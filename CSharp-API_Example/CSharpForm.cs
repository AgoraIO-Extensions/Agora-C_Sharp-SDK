using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using agora.rtc;
using System.Diagnostics;
using Microsoft.Win32;

namespace CSharp_API_Example
{
    delegate void dumpHandler(string tag, int ret);

    public partial class CSharpForm : Form
    {

        internal static IEngine usr_engine = null;

        internal static string app_id = "";  // 不能为空
        internal static string channel_id = "123";  // 不能为空，just for test here
        internal static IntPtr local_win_id;
        internal static IntPtr remote_win_id;

        internal static dumpHandler dump_handler = null;

        public CSharpForm()
        {
            InitializeComponent();
            InitUI();

            // just for debug
            dump_handler = new dumpHandler(dumpStatus);

            local_win_id = video1To1View.localVideoView.Handle;
            remote_win_id = video1To1View.remoteVideoView.Handle;

            usr_engine = new Video1To1();
            //iris_engine.Init(appId_textBox.Text, channelName_textBox.Text);

            sdk_version.Text = "SDK Version: " + usr_engine.getSDKVersion();
        }

        private void InitUI()
        {
            // just for debug here
            appId_textBox.Text = app_id;
            channelName_textBox.Text = channel_id;

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
            if (null != usr_engine)
            {
                int ret = -1;
                ret = usr_engine.Init(appId_textBox.Text, channelName_textBox.Text);
                dumpStatus("Init", ret);

                ret = usr_engine.joinChannel();
                dumpStatus("joinChannel", ret);
            }
        }

        private void leaveChannelClicked(object sender, EventArgs e)
        {
            if (null != usr_engine)
            {
                int ret = usr_engine.leaveChannel();
                dumpStatus("LeaveChannel", ret);
            }
        }

        private void onSceneChanged(object sender, EventArgs e)
        {
            if (null != usr_engine)
            {
                usr_engine.unInit();
                usr_engine = null;
            }

            if (tabCtrl.SelectedTab == video1v1Tab)  // tabCtrl.TabPages["video1v1Tab"]
            {
                local_win_id = video1To1View.localVideoView.Handle;
                remote_win_id = video1To1View.remoteVideoView.Handle;
                usr_engine = new Video1To1();
            }
            else if (tabCtrl.SelectedTab == audio1v1Tab)
            {
                usr_engine = new Audio1To1();
            }
            else if (tabCtrl.SelectedTab == screenShareTab)
            {
                local_win_id = screenShareView.localVideoView.Handle;
                remote_win_id = screenShareView.remoteVideoView.Handle;
                usr_engine = new ScreenShare();
            }
            else if (tabCtrl.SelectedTab == multiChannelTab)
            {
                local_win_id = multiChannelView.localVideoView.Handle;
                remote_win_id = multiChannelView.channelOneVideoView.Handle;
                usr_engine = new MultiChannel();
            }
            else
            {
                dumpStatus("todo", 0);
            }
        }

        private void onClearBtnClicked(object sender, EventArgs e)
        {
            status_tips.Clear();
        }

        private void onFormClosing(object sender, FormClosingEventArgs e)
        {
            if (null != usr_engine)
            {
                usr_engine.unInit();
                usr_engine = null;
            }
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
                dumpStatus(String.Format("{0}", ex.Message), -1);
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

        public void dumpStatus(string tag, int ret)
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
    }
}
