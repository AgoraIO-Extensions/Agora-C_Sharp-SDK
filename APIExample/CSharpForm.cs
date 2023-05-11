/// <summary>
/// Knowlege：
/// 1. Input AppId and ChannelId, click update button. 
///    Avoid restart appliction because you need to input appid again.
/// 2. You need to pass window parameter to every scene to show Video.
/// 3. API call sequence is different in difference cases.
/// 
/// Note：Multiple channel id is seperated by ';', every channel id must be valid. If only use one channel, the case will use first channel id.
/// For example, you input '123;456;789' in channel id edit. For one channel case, only use 123 as channel id. For multiple channels, 123 is channel id 1, 456 is channel id 2 and 789 is channel id 3.
/// <summary>

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
            usr_engine_ = new JoinChannelVideo(joinChannelVideoView.localVideoView.Handle, joinChannelVideoView.remoteVideoView.Handle);
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
            this.updateBtn.Text = config_helper_.GetUIValue("General", "UpdateAppid.Info");
            this.clear_msg_btn.Text = config_helper_.GetUIValue("General", "Clear.Info");
            this.api_ref.Text = config_helper_.GetUIValue("General", "APIManual.Info");
            this.reg_linkLabel.Text = config_helper_.GetUIValue("General", "RegisterUrl");
            this.eg_linkLabel.Text = config_helper_.GetUIValue("General", "Example.Info");
            this.faq_linkLabel.Text= config_helper_.GetUIValue("General", "Question");

            this.joinChannelVideoTab.Text = config_helper_.GetUIValue("General", "Video1V1");
            this.joinChannelAudioTab.Text = config_helper_.GetUIValue("General", "Audio1V1");
            this.screenShareTab.Text = config_helper_.GetUIValue("General", "ScreenShare");
            this.joinMultipleChannelTab.Text = config_helper_.GetUIValue("General", "MultipleChannel");
            this.videoGroupTab.Text = config_helper_.GetUIValue("General", "VideoGroup");
            this.processRawDataTab.Text = config_helper_.GetUIValue("General", "RawData");
            this.virtualBackgroundTab.Text = config_helper_.GetUIValue("General", "VirtualBackground");
            this.customCaptureVideoTab.Text = config_helper_.GetUIValue("General", "CustomVideoDevice");
            this.AudioMixingTag.Text = config_helper_.GetUIValue("General", "AudioMixing");
            this.PlayEffectTag.Text = config_helper_.GetUIValue("General", "AudioEffect");
            this.DeviceManagerTag.Text = config_helper_.GetUIValue("General", "DeviceManager");
            this.RtmpStreamingTag.Text = config_helper_.GetUIValue("General", "RtmpStreaming");
            this.SetLiveTranscodingTag.Text = config_helper_.GetUIValue("General", "RtmpLiveTranscoding");
            this.SetEncryptionTag.Text = config_helper_.GetUIValue("General", "Encrypt");
            this.SetVideoEncoderConfigurationTag.Text = config_helper_.GetUIValue("General", "VideoEncoder");
            this.VoiceChangerTag.Text = config_helper_.GetUIValue("General", "VoiceChanger");
            this.ChannelMediaRelayTag.Text = config_helper_.GetUIValue("General", "MediaRelay");
            this.SendStreamMessageTag.Text = config_helper_.GetUIValue("General", "SendStreamMessage.SendMessage");
            this.StringUidTag.Text = config_helper_.GetUIValue("General", "StringUid");

            joinChannelVideoView.SetUIText(config_helper_);
            joinChannelAudioView.SetUIText(config_helper_);
            screenShareView.SetUIText(config_helper_);
            setEncryptionView.SetUIText(config_helper_);
            joinMultipleChannelView.SetUIText(config_helper_);
            videoGroupView.SetUIText(config_helper_);
            processRawDataView.SetUIText(config_helper_);
            virtualBackgroundView.SetUIText(config_helper_);
            customCaptureVideoView.SetUIText(config_helper_);
            audioMixingView.SetUIText(config_helper_);
            playEffectView.SetUIText(config_helper_);
            deviceManagerView.SetUIText(config_helper_);

            rtmpStreamingView.SetUIText(config_helper_);
            setLiveTranscodingView.SetUIText(config_helper_);
            channelMediaRelayView.SetUIText(config_helper_);
            sendStreamMessageView.SetUIText(config_helper_);
            setVideoEncoderConfigurationView.SetUIText(config_helper_);
            stringUidView.SetUIText(config_helper_);
            voiceChangerView.SetUIText(config_helper_);
            // 
        }

        private void InitSceneControl()
        {
            if (tabCtrl.SelectedTab == DeviceManagerTag)
            {
                deviceManagerView.InitDevices();
            }
            else if (tabCtrl.SelectedTab == ChannelMediaRelayTag)
            {
                channelMediaRelayView.SetEnabled(true);
            }
            else if (tabCtrl.SelectedTab == VoiceChangerTag)
            {
                voiceChangerView.EnableCmbType(false);
            }
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
                InitSceneControl();
                ret = usr_engine_.JoinChannel();
                DumpStatus("joinChannel", ret);
            }
        }

        private void LeaveChannelClicked(object sender, EventArgs e)
        {
            if (null != usr_engine_)
            {
                if (tabCtrl.SelectedTab == VoiceChangerTag)
                {
                    voiceChangerView.EnableCmbType(true);
                }
                else if (tabCtrl.SelectedTab == RtmpStreamingTag)
                {
                    rtmpStreamingView.RemoveAllStreamUrl();
                }
                else if (tabCtrl.SelectedTab == SetLiveTranscodingTag)
                {
                    setLiveTranscodingView.RemoveAllStreamUrl();
                }
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

            if (tabCtrl.SelectedTab == joinChannelVideoTab) // 1v1 Video
            {
                usr_engine_ = new JoinChannelVideo(joinChannelVideoView.localVideoView.Handle, joinChannelVideoView.remoteVideoView.Handle);
            }
            else if (tabCtrl.SelectedTab == joinChannelAudioTab) // 1v1 Audio
            {
                usr_engine_ = new JoinChannelAudio();
            }
            else if (tabCtrl.SelectedTab == screenShareTab) // camera + screen share
            {
                usr_engine_ = new ScreenShare(screenShareView.localVideoView.Handle, screenShareView.remoteVideoView.Handle);
            }
            else if (tabCtrl.SelectedTab == joinMultipleChannelTab)  // multiple channel
            {
                usr_engine_ = new JoinMultipleChannel(joinMultipleChannelView.localVideoView.Handle, 
                    joinMultipleChannelView.firstChannelVideoView.Handle, joinMultipleChannelView.secondChannelVideoView.Handle);
            }
            else if (tabCtrl.SelectedTab == videoGroupTab) // Multiple people
            {
                usr_engine_ = new VideoGroup(videoGroupView.localVideoView.Handle,
                    videoGroupView.fistUserVideoView.Handle, videoGroupView.secondUserVideoView.Handle);
            }
            else if (tabCtrl.SelectedTab == processRawDataTab) // Raw Data
            {
                usr_engine_ = new ProcessRawData(processRawDataView.localVideoView.Handle, processRawDataView.remoteVideoView.Handle);
            }
            else if (tabCtrl.SelectedTab == virtualBackgroundTab) // Virtual Background
            {
                usr_engine_ = new VirtualBackground(virtualBackgroundView.localVideoView.Handle, virtualBackgroundView.remoteVideoView.Handle);
            }

            else if (tabCtrl.SelectedTab == customCaptureVideoTab) // Custom Render and Capture
            {
                usr_engine_ = new CustomCaptureVideo(customCaptureVideoView.localVideoView.Handle, customCaptureVideoView.remoteVideoView.Handle, customCaptureVideoView.localVideoView);
            }
            else if (tabCtrl.SelectedTab == AudioMixingTag) // AudioMixing
            {
                usr_engine_ = new AudioMixing();
            }
            else if (tabCtrl.SelectedTab == PlayEffectTag) // PlayEffect
            {
                usr_engine_ = new AudioEffect();
            }
            else if (tabCtrl.SelectedTab == DeviceManagerTag) // DeviceManager
            {
                usr_engine_ = new DeviceManager(deviceManagerView.localVideoView.Handle, deviceManagerView.remoteVideoView.Handle);
            }
            else if (tabCtrl.SelectedTab == RtmpStreamingTag) // RtmpStreaming
            {
                usr_engine_ = new RtmpStreaming( rtmpStreamingView.remoteVideoView.Handle);
            }
            else if (tabCtrl.SelectedTab == SetLiveTranscodingTag) // SetLiveTranscoding
            {
                usr_engine_ = new SetLiveTranscoding(setLiveTranscodingView.localVideoView.Handle, setLiveTranscodingView.remoteVideoView.Handle);
            }
            else if (tabCtrl.SelectedTab == SetEncryptionTag) // SetEncryption
            {
                usr_engine_ = new SetEncryption(setEncryptionView.localVideoView.Handle, setEncryptionView.remoteVideoView.Handle);
            }
            else if (tabCtrl.SelectedTab == SetVideoEncoderConfigurationTag) // SetVideoEncoderConfiguration
            {
                usr_engine_ = new SetVideoEncoderConfiguration(setVideoEncoderConfigurationView.localVideoView.Handle, setVideoEncoderConfigurationView.remoteVideoView.Handle);

            }
            else if (tabCtrl.SelectedTab == VoiceChangerTag) // VoiceChanger
            {
                usr_engine_ = new VoiceChanger();
                 
            }
            else if (tabCtrl.SelectedTab == ChannelMediaRelayTag) // ChannelMediaRelay
            {
                usr_engine_ = new ChannelMediaRelay(channelMediaRelayView.localVideoView.Handle, channelMediaRelayView.remoteVideoView.Handle);

            }
            else if (tabCtrl.SelectedTab == SendStreamMessageTag) // SendStreamMessage
            {
                usr_engine_ = new StreamMessage(sendStreamMessageView.localVideoView.Handle, sendStreamMessageView.remoteVideoView.Handle);
            }
            else if (tabCtrl.SelectedTab == StringUidTag) // stringUid
            {
                usr_engine_ = new StringUid(stringUidView.localVideoView.Handle, stringUidView.remoteVideoView.Handle);
            }
            else if(tabCtrl.SelectedTab == tabRTT)
            {
                usr_engine_ = new RTT(rttView.localVideoView.Handle, rttView.remoteVideoView.Handle, rttView);
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

            if (!status_tips.InvokeRequired)
            {
                status_tips.Text += tips + "\r\n";
            }
            else
            {
                status_tips.Invoke(new Action(() =>
                {
                    status_tips.Text += tips + "\r\n";
                }));
            }
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
