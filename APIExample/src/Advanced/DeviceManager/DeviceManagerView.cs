using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharp_API_Example
{
    public partial class DeviceManagerView : UserControl
    {
        agora.rtc.DeviceInfo[] videoDevices_ = null;
        agora.rtc.DeviceInfo[] recordingDevices_ = null;
        agora.rtc.DeviceInfo[] playbackDevices_ = null;
        public DeviceManagerView()
        {
            InitializeComponent();
        }

        public void ResetDevices()
        {
            cmbVideoDevice.Items.Clear();
            cmbRecordingDevices.Items.Clear();
            cmbPlayback.Items.Clear();
            videoDevices_ = null;
            recordingDevices_ = null;
            playbackDevices_ = null;
        }
        public void InitDevices()
        {
            videoDevices_ = CSharpForm.usr_engine_.GetVideoDevices();
            playbackDevices_ = CSharpForm.usr_engine_.GetPlaybackDevices();
            recordingDevices_ = CSharpForm.usr_engine_.GetRecordingDevices();
         
            if (videoDevices_ != null)
            {
                foreach (agora.rtc.DeviceInfo info in videoDevices_)
                {
                    cmbVideoDevice.Items.Add(info.deviceName);
                }
                cmbVideoDevice.SelectedIndex = 0;
            }

            if (recordingDevices_ != null)
            {
                foreach (agora.rtc.DeviceInfo info in recordingDevices_)
                {
                    cmbRecordingDevices.Items.Add(info.deviceName);
                }
                cmbRecordingDevices.SelectedIndex = 0;
            }

            if (playbackDevices_ != null)
            {
                foreach (agora.rtc.DeviceInfo info in playbackDevices_)
                {
                    cmbPlayback.Items.Add(info.deviceName);
                }
                cmbPlayback.SelectedIndex = 0;
            }
        }

        private void cmbVideoDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbVideoDevice.SelectedIndex < videoDevices_.Length)
            {
                CSharpForm.usr_engine_.SetVideoDevice(videoDevices_[cmbVideoDevice.SelectedIndex].deviceId);
            }
        }

        private void cmbRecordingDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRecordingDevices.SelectedIndex < recordingDevices_.Length)
            {
                CSharpForm.usr_engine_.SetRecordingDevice(recordingDevices_[cmbRecordingDevices.SelectedIndex].deviceId);
            }
        }

        private void cmbPlayback_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPlayback.SelectedIndex < playbackDevices_.Length)
            {
                CSharpForm.usr_engine_.SetPlaybackDevice(playbackDevices_[cmbPlayback.SelectedIndex].deviceId);
            }
        }
    }
}
