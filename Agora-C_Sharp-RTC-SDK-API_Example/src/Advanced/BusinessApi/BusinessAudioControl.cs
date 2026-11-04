using System;
using System.Collections.Generic;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    internal sealed class BusinessApiResult
    {
        internal object Value { get; }
        internal Dictionary<string, object> Outputs { get; }
        internal BusinessApiResult(object value, Dictionary<string, object> outputs = null)
        { Value = value; Outputs = outputs ?? new Dictionary<string, object>(); }
    }

    // The injected call preserves real SDK errors; this class never treats a request as audio acceptance.
    internal sealed class BusinessAudioControl
    {
        private readonly Func<string, object, BusinessApiResult> call;
        internal bool? EarRequested { get; private set; }
        internal BusinessAudioControl(Func<string, object, BusinessApiResult> call) { this.call = call; }
        internal void Reset() { EarRequested = null; }
        internal string ApplyRole(CHANNEL_PROFILE_TYPE profile, CLIENT_ROLE_TYPE role, ChannelMediaOptions options)
        {
            if (profile != CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING)
                throw new InvalidOperationException("角色切换用于直播频道；请先以直播场景初始化/入会。双连接使用合唱页的A/B媒体更新。");
            var state = (CONNECTION_STATE_TYPE)call("IRtcEngine.GetConnectionState", new { }).Value;
            call("IRtcEngine.SetClientRole", new { role });
            if (state == CONNECTION_STATE_TYPE.CONNECTION_STATE_CONNECTED)
                call("IRtcEngine.UpdateChannelMediaOptions", new { options });
            return state == CONNECTION_STATE_TYPE.CONNECTION_STATE_CONNECTED
                ? "角色/发布选项请求已提交：" + role + "；检查角色变化/失败回调及对端声音。"
                : "入会前角色已预设：" + role + "；入会将使用当前发布选项。";
        }
        internal string CurrentDevice(bool recording) => Convert.ToString(call(
            recording ? "IAudioDeviceManager.GetRecordingDevice" : "IAudioDeviceManager.GetPlaybackDevice",
            new { deviceId = "" }).Outputs["deviceId"]);
        internal (int Volume, string DeviceId) ReadVolume(bool recording)
        {
            string id = CurrentDevice(recording);
            var result = call(recording ? "IAudioDeviceManager.GetRecordingDeviceVolume" : "IAudioDeviceManager.GetPlaybackDeviceVolume", new { volume = 0 });
            return (Convert.ToInt32(result.Outputs["volume"]), id);
        }
        internal (int Volume, string DeviceId) SetVolume(bool recording, string deviceId, int volume)
        {
            if (string.IsNullOrWhiteSpace(deviceId)) throw new ArgumentException("先刷新并选择真实音频设备。");
            if (volume < 0 || volume > 255) throw new ArgumentException("设备音量范围为0–255，不是百分比。");
            call(recording ? "IAudioDeviceManager.SetRecordingDevice" : "IAudioDeviceManager.SetPlaybackDevice", new { deviceId });
            call(recording ? "IAudioDeviceManager.SetRecordingDeviceVolume" : "IAudioDeviceManager.SetPlaybackDeviceVolume", new { volume });
            return ReadVolume(recording);
        }
        internal void ApplyEar(bool enabled, int volume)
        {
            if (volume < 0 || volume > 400) throw new ArgumentException("耳返音量范围为0–400。");
            if (enabled) call("IRtcEngine.EnableLocalAudio", new { enabled = true });
            call("IRtcEngine.EnableInEarMonitoring", new { enabled, includeAudioFilters = 0 });
            EarRequested = enabled;
            if (enabled) SetEarVolume(volume);
        }
        internal void SetEarVolume(int volume)
        {
            if (EarRequested != true) throw new InvalidOperationException("请先勾选耳返并点击应用耳返，确认接口请求成功后再设置音量。");
            if (volume < 0 || volume > 400) throw new ArgumentException("耳返音量范围为0–400。");
            call("IRtcEngine.SetInEarMonitoringVolume", new { volume });
        }
    }
}
