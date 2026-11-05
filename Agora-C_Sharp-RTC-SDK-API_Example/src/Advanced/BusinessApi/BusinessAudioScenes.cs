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
        private readonly ComboBox earFilters = Enums<EAR_MONITORING_FILTER_TYPE>();
        private readonly NumericUpDown earVolume = Number(400, 100), indicationInterval = Number(10000, 300), smooth = Number(10, 3);
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
            string active = audioControl.CurrentDevice(list == recordingDevices);
            list.SelectedIndex = -1;
            for (int i = 0; i < list.Items.Count; i++)
                if (((DeviceChoice)list.Items[i]).Value.deviceId == active) { list.SelectedIndex = i; break; }
            devicesStatus.Text = $"麦克风{recordingDevices.Items.Count}个，播放设备{playbackDevices.Items.Count}个；下拉框匹配SDK当前设备；无匹配时请手动选择并切换设备。";
        }
        private Action<BusinessApiResult> AudioResult(string title) => r => audioStatus.Text = title + "：" + BusinessApiJson.Result(r.Outputs.Count > 0 ? r.Outputs : r.Value);
        private void ShowDeviceVolume(bool recording, bool set)
        {
            var list = recording ? recordingDevices : playbackDevices;
            var input = recording ? recordDeviceVolume : playDeviceVolume;
            string requestedDevice = set ? DeviceId(list) : "";
            int requestedVolume = (int)input.Value;
            var actual = set ? audioControl.SetVolume(recording, requestedDevice, requestedVolume) : audioControl.ReadVolume(recording);
            string mismatch = set && (actual.DeviceId != requestedDevice || actual.Volume != requestedVolume)
                ? "（请求与读回不同，请检查路由/系统量化及驱动）" : "";
            audioStatus.Text = (recording ? "麦克风" : "扬声器") +
                (set ? " 请求设备=" + requestedDevice + "，请求音量=" + requestedVolume + "；" : " ") +
                "SDK当前设备=" + actual.DeviceId + "，读回音量=" + actual.Volume + "/255 " + mismatch + "；实际声音需对端/本机验证。";
            if (!set && actual.Volume >= 0 && actual.Volume <= 255) input.Value = actual.Volume;
        }
        private Button DeviceVolumeButton(bool recording, bool set)
        {
            var button = ActionButton(set ? "设置所选设备音量" : "查询当前设备音量", () => ShowDeviceVolume(recording, set));
            var list = recording ? recordingDevices : playbackDevices;
            if (set)
            {
                bindings.Add((recording ? "IAudioDeviceManager.SetRecordingDevice" : "IAudioDeviceManager.SetPlaybackDevice", button, () => new { deviceId = DeviceId(list) }));
                bindings.Add((recording ? "IAudioDeviceManager.SetRecordingDeviceVolume" : "IAudioDeviceManager.SetPlaybackDeviceVolume", button, () => new { volume = (int)(recording ? recordDeviceVolume.Value : playDeviceVolume.Value) }));
            }
            bindings.Add((recording ? "IAudioDeviceManager.GetRecordingDevice" : "IAudioDeviceManager.GetPlaybackDevice", button, () => new { deviceId = "" }));
            bindings.Add((recording ? "IAudioDeviceManager.GetRecordingDeviceVolume" : "IAudioDeviceManager.GetPlaybackDeviceVolume", button, () => new { volume = 0 }));
            return button;
        }
        private Button EarButton(bool enable)
        {
            var button = ActionButton(enable ? "应用耳返" : "设置耳返音量", () =>
            {
                if (enable)
                {
                    audioControl.ApplyEar(ear.Checked, (int)earVolume.Value, (EAR_MONITORING_FILTER_TYPE)earFilters.SelectedItem);
                    if (ear.Checked) capture.Checked = true;
                }
                else audioControl.SetEarVolume((int)earVolume.Value);
                audioStatus.Text = "耳返请求=" + audioControl.EarRequested + "，音量=" + earVolume.Value +
                    "/400；SDK请求已返回，尚不代表可听见，请检查耳机、采集状态回调和本机声音。";
            });
            if (enable)
            {
                bindings.Add(("IRtcEngine.EnableAudio", button, null));
                bindings.Add(("IRtcEngine.EnableLocalAudio", button, () => new { enabled = true }));
                bindings.Add(("IRtcEngine.EnableInEarMonitoring", button, () => new { enabled = ear.Checked, includeAudioFilters = (int)(EAR_MONITORING_FILTER_TYPE)earFilters.SelectedItem }));
            }
            bindings.Add(("IRtcEngine.SetInEarMonitoringVolume", button, () => new { volume = (int)earVolume.Value }));
            return button;
        }
        private readonly NumericUpDown loopbackFlags = Number(3, 3, 1), loopbackVolume = Number(400, 100);
        private readonly Label loopbackId = Label("新回环：未创建");
        private void RunLoopback(Action action)
        {
            try { action(); }
            finally
            {
                loopback.Checked = loopbackControl.LegacyEnabled;
                loopbackId.Text = "旧采集=" + loopbackControl.LegacyEnabled + "；新音轨=" +
                    (loopbackControl.TrackId?.ToString() ?? "无") + "；发布请求=" + loopbackControl.Published;
            }
        }
        private Control LoopbackControls()
        {
            var create = ActionButton("创建回环（关闭旧采集）", () => RunLoopback(() => loopbackControl.Create(LoopbackConfig())));
            var publish = ActionButton("发布回环音轨", () => RunLoopback(() => loopbackControl.Publish(role.SelectedIndex == 0)));
            var stop = ActionButton("取消回环发布", () => RunLoopback(loopbackControl.Unpublish));
            var destroy = ActionButton("销毁回环音轨", () => RunLoopback(loopbackControl.Destroy));
            var volume = ActionButton("设置回环发布音量", () => RunLoopback(() => loopbackControl.SetVolume((int)loopbackVolume.Value)));
            bindings.Add(("IRtcEngine.CreateLoopbackAudioTrack", create, () => new { config = LoopbackConfig() }));
            bindings.Add(("IRtcEngine.EnableLoopbackRecording", create, () => new { enabled = false, deviceName = "" }));
            bindings.Add(("IRtcEngine.UpdateChannelMediaOptions", publish, () => new { options = BusinessLoopbackControl.Publication(loopbackControl.TrackId ?? 0, true) }));
            bindings.Add(("IRtcEngine.UpdateChannelMediaOptions", stop, () => new { options = BusinessLoopbackControl.Publication(loopbackControl.TrackId ?? 0, false) }));
            bindings.Add(("IRtcEngine.DestroyLoopbackAudioTrack", destroy, () => new { trackId = loopbackControl.TrackId ?? 0 }));
            bindings.Add(("IRtcEngine.AdjustLoopbackAudioPublishVolume", volume, () => new { trackId = loopbackControl.TrackId ?? 0, volume = (int)loopbackVolume.Value }));
            return Row(excludedNames, excludedPids, create, publish, stop, destroy, Label("音量0–400"), loopbackVolume, volume, loopbackId);
        }
        private readonly TextBox excludedNames = Input(220, "排除应用名，逗号分隔"), excludedPids = Input(220, "排除进程ID，逗号分隔");
        private LoopbackAudioTrackConfig LoopbackConfig()
        {
            var names = excludedNames.Text.Split(',').Select(x => x.Trim()).Where(x => x.Length != 0).ToArray();
            var ids = excludedPids.Text.Split(',').Select(x => x.Trim()).Where(x => x.Length != 0).Select(uint.Parse).ToArray();
            return new LoopbackAudioTrackConfig { excludedAppNames = names, excludedAppCount = (uint)names.Length,
                excludedProcessIds = ids, excludedProcessCount = (uint)ids.Length };
        }
        private Control AudioScene() => Page(
            "先填写主窗口AppId/频道并初始化。选择真实设备或远端UID，分别控制采集、上行和下行。热插拔后刷新设备；不要将设备静音当作停止发布。",
            Row(Label("回环源类别：1音频输出 / 2运行应用 / 3全部"), loopbackFlags,
                Bind("枚举回环录音源", "IRtcEngine.GetLoopbackRecordingSources", () => new { options = new LoopbackRecordingSourceOptions((uint)loopbackFlags.Value) }, AudioResult("回环源及进程ID"))),
            LoopbackControls(),
            Label("先入会并切主播，再创建和发布。枚举类别只影响列表；排除项在创建时生效，修改后需重建。Windows仅首项生效，PID优先。旧/新采集互斥。"),
            Row(Label("麦克风"), recordingDevices, Bind("切换麦克风", "IAudioDeviceManager.SetRecordingDevice", () => new { deviceId = DeviceId(recordingDevices) }),
                Label("设备音量0–255"), recordDeviceVolume, DeviceVolumeButton(true, true), DeviceVolumeButton(true, false)),
            Row(recordMute, Bind("应用麦克风静音", "IAudioDeviceManager.SetRecordingDeviceMute", () => new { mute = recordMute.Checked }),
                Bind("查询静音", "IAudioDeviceManager.GetRecordingDeviceMute", () => new { mute = false }, AudioResult("麦克风静音")),
                followRecord, Bind("应用系统跟随", "IAudioDeviceManager.FollowSystemRecordingDevice", () => new { enable = followRecord.Checked })),
            Row(Label("扬声器"), playbackDevices, Bind("切换扬声器", "IAudioDeviceManager.SetPlaybackDevice", () => new { deviceId = DeviceId(playbackDevices) }),
                Label("设备音量0–255"), playDeviceVolume, DeviceVolumeButton(false, true), DeviceVolumeButton(false, false)),
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
            Row(ear, Label("耳返滤波类型"), earFilters, EarButton(true), Label("耳返音量0–400"), earVolume, EarButton(false)),
            Row(audioProfile, Bind("设置音质", "IRtcEngine.SetAudioProfile", () => new { profile = (AUDIO_PROFILE_TYPE)audioProfile.SelectedItem }),
                audioScenario, Bind("设置音频场景", "IRtcEngine.SetAudioScenario", () => new { scenario = (AUDIO_SCENARIO_TYPE)audioScenario.SelectedItem })),
            Row(voicePreset, Bind("应用变声", "IRtcEngine.SetVoiceConversionPreset", () => new { preset = (VOICE_CONVERSION_PRESET)voicePreset.SelectedItem }),
                Label("音频延迟补偿ms"), audioDelay, Bind("更新频道补偿", "IRtcEngine.UpdateChannelMediaOptions", () => new { options = MediaOptions() })), audioStatus);
    }
}
