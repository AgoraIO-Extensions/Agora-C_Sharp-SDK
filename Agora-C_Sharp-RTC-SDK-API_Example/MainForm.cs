using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.Linq;

namespace C_Sharp_API_Example
{
    delegate void dumpHandler(string tag, int ret);

    public partial class MainForm : Form
    {
        internal static IEngine engine_ = null;
        internal static dumpHandler dump_handler_ = null;

        private readonly System.Collections.Generic.List<TabPage> businessTabs = new System.Collections.Generic.List<TabPage>();
        private BusinessApiView businessView;
        private ConfigHelper config_helper_ = null;
        private readonly string SECTION = "must";
        private readonly string APPID_KEY = "AppId";
        private readonly string CHANNELID_KEY = "ChannelId";

        public MainForm()
        {
            InitializeComponent();
            InitUI();
            businessView = new BusinessApiView(() => appId_textBox.Text, () => channelId_textBox.Text);
            foreach (var name in BusinessApiView.SceneNames)
            {
                var page = new TabPage(name); businessTabs.Add(page); tabCtrl.TabPages.Add(page);
            }
            businessView.RegisterNavigationButtons(join_channel_btn, leave_channel_btn);
            MaximizeBox = true; MinimizeBox = true; MinimumSize = new Size(1000, 700);
            Resize += (s, e) => LayoutDemo();

            // Register dump handler
            dump_handler_ = new dumpHandler(DumpStatus);

            CheckForIllegalCrossThreadCalls = false;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            ClientSize = new Size(1250, 800);
            LayoutDemo();
            // Select default engine
            this.BeginInvoke(new Action(() =>
            {
                SelectEngine(new JoinChannelVideo(joinChannelVideoView));
            }));
        }

        private void LayoutDemo()
        {
            if (ClientSize.Width < 400 || ClientSize.Height < 400) return;
            const int left = 285;
            appId_label.SetBounds(12, 12, left - 24, 22);
            updateBtn.SetBounds(left - 92, 8, 80, 26);
            appId_textBox.SetBounds(12, 38, left - 24, 28);
            channelName_label.SetBounds(12, 76, left - 24, 22);
            channelId_textBox.SetBounds(12, 102, left - 24, 28);
            join_channel_btn.SetBounds(12, 142, 124, 32);
            leave_channel_btn.SetBounds(146, 142, 124, 32);
            sdk_version.SetBounds(12, 186, left - 24, 40);
            status_tips.SetBounds(12, 236, left - 24, ClientSize.Height - 332);
            clear_msg_btn.SetBounds(12, ClientSize.Height - 86, left - 24, 28);
            api_ref.SetBounds(12, ClientSize.Height - 48, 65, 24);
            reg_linkLabel.SetBounds(80, ClientSize.Height - 48, 65, 24);
            eg_linkLabel.SetBounds(148, ClientSize.Height - 48, 65, 24);
            faq_linkLabel.SetBounds(216, ClientSize.Height - 48, 55, 24);
            tabCtrl.SetBounds(left, 12, ClientSize.Width - left - 12, ClientSize.Height - 24);
        }

        internal void SelectBusinessSceneForCheck(int index)
        {
            appId_textBox.Text = "";
            channelId_textBox.Text = "ui-smoke";
            tabCtrl.SelectedTab = businessTabs[index];
            LayoutDemo();
        }
        internal int VerifyBusinessScenes() => businessView.VerifyOfflineUi();

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
            if (IsAllChannelIdValid(channel_id))
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

            string api_ref_url = @"https://docportal.shengwang.cn/cn/video-call-4.x/API%20Reference/cs_ng/v4.2.0/API/rtc_api_overview_ng.html";
            string reg_url = @"https://console.agora.io/";
            string eg_url = @"https://github.com/AgoraIO-Extensions/Agora-C_Sharp-SDK";
            string faq_url = @"https://docs.agora.io/cn/Video/faq?platform=All Platforms";
            api_ref.Links.Add(0, api_ref_url.Length, api_ref_url);
            reg_linkLabel.Links.Add(0, reg_url.Length, reg_url);
            eg_linkLabel.Links.Add(0, eg_url.Length, eg_url);
            faq_linkLabel.Links.Add(0, faq_url.Length, faq_url);
        }

        private void JoinChannelClicked(object sender, EventArgs e)
        {
            if (null != engine_)
            {
                int ret = -1;
                ret = engine_.Init(appId_textBox.Text);
                DumpStatus("Init", ret);

                if (ret != 0) return;
                if (0 == ret)
                {
                    int build = 0;
                    sdk_version.Text = "SDK Version: " + engine_.GetEngine().GetVersion(ref build);
                    sdk_version.Text += "." + build;
                }

                ret = engine_.JoinChannel(channelId_textBox.Text);
                DumpStatus("joinChannel", ret);
            }
        }

        private void LeaveChannelClicked(object sender, EventArgs e)
        {
            if (null != engine_)
            {
                int ret = engine_.LeaveChannel();
                DumpStatus("LeaveChannel", ret);

                if (!ReferenceEquals(engine_, businessView.Session))
                {
                    ret = engine_.UnInit();
                    DumpStatus("UnInit", ret);
                }
            }
        }

        private void SelectEngine(IEngine engine)
        {
            if (ReferenceEquals(engine_, engine)) return;
            if (null != engine_)
            {
                engine_.LeaveChannel();
                engine_.UnInit();
                engine_ = null;
            }

            engine_ = engine;
        }

        private void OnSceneChanged(object sender, EventArgs e)
        {
            int businessIndex = businessTabs.IndexOf(tabCtrl.SelectedTab);
            join_channel_btn.Enabled = businessIndex != 4;
            leave_channel_btn.Enabled = businessIndex != 4;
            if (businessIndex >= 0)
            {
                SelectEngine(businessView.Session);
                businessView.ShowScene(businessIndex);
                tabCtrl.SelectedTab.Controls.Add(businessView);
            }
            else if (tabCtrl.SelectedTab == joinChannelVideoTab)
            {
                SelectEngine(new JoinChannelVideo(joinChannelVideoView));
            }
            else if (tabCtrl.SelectedTab == joinChannelAudioTab)
            {
                SelectEngine(new JoinChannelAudio());
            }
            else if (tabCtrl.SelectedTab == screenShareTab)
            {
                SelectEngine(new ScreenShare(screenShareView));
            }
            else if (tabCtrl.SelectedTab == joinMultipleChannelTab)
            {
                SelectEngine(new JoinMultipleChannel(joinMultipleChannelView));
            }
            else if (tabCtrl.SelectedTab == processRawDataTab)
            {
                SelectEngine(new ProcessRawData(processRawDataView));
            }
            else if (tabCtrl.SelectedTab == virtualBackgroundTab)
            {
                SelectEngine(new VirtualBackground(virtualBackgroundView));
            }
            else if (tabCtrl.SelectedTab == customRenderTab)
            {
                SelectEngine(new CustomRender(customRenderView));
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (null != engine_)
            {
                engine_.LeaveChannel();
                engine_.UnInit();
                engine_ = null;
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
            Console.WriteLine("**** DumpStatus {0} {1}", tag, ret);
            status_tips.Invoke(new Action(() =>
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
            }));
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
