using System;
using System.Linq;
using System.Windows.Forms;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    internal sealed partial class BusinessApiView
    {
        private readonly ComboBox recordingDevices = new ComboBox { Width = 260, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly ComboBox playbackDevices = new ComboBox { Width = 260, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly NumericUpDown recordDeviceVolume = Number(255, 100), playDeviceVolume = Number(255, 100);
        private readonly NumericUpDown recordGain = Number(400, 100), playGain = Number(400, 100), remoteGain = Number(400, 100);
        private readonly CheckBox recordMute = new CheckBox { Text = "设备静音", AutoSize = true }, playMute = new CheckBox { Text = "设备静音", AutoSize = true };
        private readonly CheckBox capture = new CheckBox { Text = "麦克风采集", Checked = true, AutoSize = true };
        private readonly CheckBox sendAudio = new CheckBox { Text = "发送本地音频", Checked = true, AutoSize = true };
        private readonly CheckBox receiveAudio = new CheckBox { Text = "接收远端音频", Checked = true, AutoSize = true };
        private readonly CheckBox remoteMute = new CheckBox { Text = "指定远端静音", AutoSize = true };
        private readonly CheckBox followRecord = new CheckBox { Text = "跟随系统麦克风", AutoSize = true }, followPlayback = new CheckBox { Text = "跟随系统扬声器", AutoSize = true };
        private readonly CheckBox ear = new CheckBox { Text = "耳返", AutoSize = true }, vad = new CheckBox { Text = "报告人声检测", AutoSize = true };
        private readonly NumericUpDown earVolume = Number(100, 100), indicationInterval = Number(10000, 300), smooth = Number(10, 3);
        private readonly ComboBox audioProfile = Enums<AUDIO_PROFILE_TYPE>(), audioScenario = Enums<AUDIO_SCENARIO_TYPE>(), voicePreset = Enums<VOICE_CONVERSION_PRESET>();
        private readonly NumericUpDown audioDelay = Number(10000, 0);
        private readonly Label devicesStatus = Label("尚未枚举设备"), audioStatus = Label("音频状态/查询结果在此显示");
        private sealed class DeviceChoice
        {
            internal DeviceInfo Value;
            public override string ToString() => Value.deviceName + " [" + Value.deviceId + "]";
        }
        private string DeviceId(ComboBox list) => list.SelectedItem is DeviceChoice item ? item.Value.deviceId : throw new InvalidOperationException("请先刷新并选择音频设备。");
        private void Devices(ComboBox list, object value)
        {
            list.Items.Clear();
            var devices = value as DeviceInfo[];
            if (devices == null) throw new InvalidOperationException("SDK设备枚举返回null。");
            foreach (var device in devices) list.Items.Add(new DeviceChoice { Value = device });
            if (list.Items.Count > 0) list.SelectedIndex = 0;
            devicesStatus.Text = $"麦克风{recordingDevices.Items.Count}个，播放设备{playbackDevices.Items.Count}个；名称/ID直接显示在下拉项中。";
        }
        private Action<BusinessApiResult> AudioResult(string title) => r => audioStatus.Text = title + "：" + BusinessApiJson.Result(r.Outputs.Count > 0 ? r.Outputs : r.Value);
        private Control AudioScene() => Page(
            "先填写主窗口AppId/频道并初始化。选择真实设备或远端UID，分别控制采集、上行和下行。热插拔后刷新设备；不要将设备静音当作停止发布。",
            Row(Bind("获取设备管理器", "IRtcEngine.GetAudioDeviceManager"),
                Bind("刷新麦克风", "IAudioDeviceManager.EnumerateRecordingDevices", after: r => Devices(recordingDevices, r.Value)),
                Bind("刷新扬声器", "IAudioDeviceManager.EnumeratePlaybackDevices", after: r => Devices(playbackDevices, r.Value)), devicesStatus),
            Row(Label("麦克风"), recordingDevices, Bind("切换麦克风", "IAudioDeviceManager.SetRecordingDevice", () => new { deviceId = DeviceId(recordingDevices) }),
                recordDeviceVolume, Bind("设置设备音量", "IAudioDeviceManager.SetRecordingDeviceVolume", () => new { volume = (int)recordDeviceVolume.Value }),
                Bind("查询设备音量", "IAudioDeviceManager.GetRecordingDeviceVolume", () => new { volume = 0 }, AudioResult("麦克风音量"))),
            Row(recordMute, Bind("应用麦克风静音", "IAudioDeviceManager.SetRecordingDeviceMute", () => new { mute = recordMute.Checked }),
                Bind("查询静音", "IAudioDeviceManager.GetRecordingDeviceMute", () => new { mute = false }, AudioResult("麦克风静音")),
                followRecord, Bind("应用系统跟随", "IAudioDeviceManager.FollowSystemRecordingDevice", () => new { enable = followRecord.Checked })),
            Row(Label("扬声器"), playbackDevices, Bind("切换扬声器", "IAudioDeviceManager.SetPlaybackDevice", () => new { deviceId = DeviceId(playbackDevices) }),
                playDeviceVolume, Bind("设置设备音量", "IAudioDeviceManager.SetPlaybackDeviceVolume", () => new { volume = (int)playDeviceVolume.Value }),
                Bind("查询设备音量", "IAudioDeviceManager.GetPlaybackDeviceVolume", () => new { volume = 0 }, AudioResult("扬声器音量"))),
            Row(playMute, Bind("应用播放设备静音", "IAudioDeviceManager.SetPlaybackDeviceMute", () => new { mute = playMute.Checked }),
                Bind("查询静音", "IAudioDeviceManager.GetPlaybackDeviceMute", () => new { mute = false }, AudioResult("扬声器静音")),
                followPlayback, Bind("应用系统跟随", "IAudioDeviceManager.FollowSystemPlaybackDevice", () => new { enable = followPlayback.Checked })),
            Row(capture, Bind("应用采集", "IRtcEngine.EnableLocalAudio", () => new { enabled = capture.Checked }),
                sendAudio, Bind("应用上行", "IRtcEngine.MuteLocalAudioStream", () => new { mute = !sendAudio.Checked }),
                receiveAudio, Bind("应用下行", "IRtcEngine.MuteAllRemoteAudioStreams", () => new { mute = !receiveAudio.Checked })),
            Row(remoteMute, Bind("应用远端静音", "IRtcEngine.MuteRemoteAudioStream", () => new { uid = (uint)remoteUid.Value, mute = remoteMute.Checked }),
                Bind("屏蔽指定用户", "IRtcEngine.SetSubscribeAudioBlocklist", () => new { uidList = new[] { (uint)remoteUid.Value }, uidNumber = 1 }),
                Bind("清空屏蔽名单", "IRtcEngine.SetSubscribeAudioBlocklist", () => new { uidList = Array.Empty<uint>(), uidNumber = 0 })),
            Row(Label("采集信号0–400"), recordGain, Bind("调整采集", "IRtcEngine.AdjustRecordingSignalVolume", () => new { volume = (int)recordGain.Value }),
                Label("播放信号"), playGain, Bind("调整播放", "IRtcEngine.AdjustPlaybackSignalVolume", () => new { volume = (int)playGain.Value }),
                Label("远端音量"), remoteGain, Bind("调整远端", "IRtcEngine.AdjustUserPlaybackSignalVolume", () => new { uid = (uint)remoteUid.Value, volume = (int)remoteGain.Value })),
            Row(Label("音量回调周期ms（0关闭）"), indicationInterval, Label("平滑"), smooth, vad,
                Bind("应用音量回调", "IRtcEngine.EnableAudioVolumeIndication", () => new { interval = (int)indicationInterval.Value, smooth = (int)smooth.Value, reportVad = vad.Checked })),
            Row(ear, Bind("应用耳返", "IRtcEngine.EnableInEarMonitoring", () => new { enabled = ear.Checked, includeAudioFilters = 0 }),
                earVolume, Bind("设置耳返音量", "IRtcEngine.SetInEarMonitoringVolume", () => new { volume = (int)earVolume.Value })),
            Row(audioProfile, Bind("设置音质", "IRtcEngine.SetAudioProfile", () => new { profile = (AUDIO_PROFILE_TYPE)audioProfile.SelectedItem }),
                audioScenario, Bind("设置音频场景", "IRtcEngine.SetAudioScenario", () => new { scenario = (AUDIO_SCENARIO_TYPE)audioScenario.SelectedItem })),
            Row(voicePreset, Bind("应用变声", "IRtcEngine.SetVoiceConversionPreset", () => new { preset = (VOICE_CONVERSION_PRESET)voicePreset.SelectedItem }),
                Label("音频延迟补偿ms"), audioDelay, Bind("更新频道补偿", "IRtcEngine.UpdateChannelMediaOptions", () => new { options = MediaOptions() })), audioStatus);
    }
}
