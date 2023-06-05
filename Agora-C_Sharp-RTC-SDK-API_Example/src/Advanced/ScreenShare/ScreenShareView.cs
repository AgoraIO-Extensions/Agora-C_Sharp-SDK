using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace C_Sharp_API_Example
{
    public partial class ScreenShareView : UserControl
    {
        public delegate Agora.Rtc.ScreenCaptureSourceInfo[] OnRefreshClicked();
        public delegate void OnStartClicked(ScreenCaptureParams parameters);
        public delegate void OnStopClicked();

        public OnRefreshClicked onRefreshClicked = null;
        public OnStartClicked onStartClicked = null;
        public OnStopClicked onStopClicked = null;

        private bool sharing_ = false;
        private Agora.Rtc.ScreenCaptureSourceInfo[] sources_ = null;

        public struct ScreenCaptureParams
        {
            public bool loopback;
            public Agora.Rtc.ScreenCaptureSourceInfo source;
            public Agora.Rtc.ScreenCaptureParameters parameters;
        }

        public ScreenShareView()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (onRefreshClicked == null)
                return;

            AutoRefresh(onRefreshClicked());
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (sharing_ == false && onStartClicked != null)
            {
                onStartClicked(GetScreenCaptureParams());
            }

            if (sharing_ == true && onStopClicked != null)
            {
                onStopClicked();
            }
        }

        private ScreenCaptureParams GetScreenCaptureParams()
        {
            return new ScreenCaptureParams()
            {
                loopback = chkLoopback.Checked,
                source = sources_[comboSources.SelectedIndex],
                parameters = new Agora.Rtc.ScreenCaptureParameters()
                {
                    bitrate = 0,
                    frameRate = 15,
                    enableHighLight = true,
                    windowFocus = true,
                    dimensions = new Agora.Rtc.VideoDimensions(1920, 1080)
                }
            };
        }

        public void OnScreenShareState(bool sharing)
        {
            BeginInvoke(new Action(() =>
            {
                sharing_ = sharing;

                btnStartStop.Text = sharing_ ? "stop" : "start";
            }));
        }

        public void AutoRefresh(Agora.Rtc.ScreenCaptureSourceInfo[] sources)
        {
            BeginInvoke(new Action(() =>
            {
                comboSources.Items.Clear();

                sources_ = sources;

                if (sources_ != null && sources_.Length > 0)
                {
                    foreach (var source in sources_)
                    {
                        comboSources.Items.Add(source.sourceTitle);
                    }
                }

                if (comboSources.Items.Count > 0)
                    comboSources.SelectedIndex = 0;
            }));
        }
    }
}
