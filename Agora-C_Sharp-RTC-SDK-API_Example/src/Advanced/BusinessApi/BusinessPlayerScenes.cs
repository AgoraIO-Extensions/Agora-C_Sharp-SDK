using System;
using System.Linq;
using System.Windows.Forms;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    internal sealed partial class BusinessApiView
    {
        private readonly TextBox mediaPath = Input(370, "选择媒体文件或填写URL");
        private readonly CheckBox mixingLocalOnly = new CheckBox { Text = "伴奏仅本地播放", AutoSize = true };
        private readonly NumericUpDown loops = Number(100000, 1, -1), startPosition = Number(int.MaxValue), seekPosition = Number(int.MaxValue);
        private readonly NumericUpDown mixingVolume = Number(100, 100), publishVolume = Number(100, 100), playerVolume = Number(400, 100);
        private readonly ComboBox playerList = new ComboBox { Width = 100, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly CheckBox playerMute = new CheckBox { Text = "播放器本地静音", AutoSize = true };
        private readonly Label playerState = Label("播放器尚未打开"), playerProgress = Label("播放位置尚未报告"), mixingState = Label("伴奏尚未开始");
        private readonly NumericUpDown effectId = Number(int.MaxValue, 1), effectGain = Number(100, 100);
        private readonly CheckBox effectPublish = new CheckBox { Text = "音效发布到远端", AutoSize = true }, loopback = new CheckBox { Text = "采集系统声音", AutoSize = true };
        private void PickMedia()
        { using var d = new OpenFileDialog { Filter = "媒体文件|*.*" }; if (d.ShowDialog(this) == DialogResult.OK) mediaPath.Text = d.FileName; }
        private Action<BusinessApiResult> PlayerResult(string title) => r => playerProgress.Text = title + "：" + BusinessApiJson.Result(r.Outputs.Count > 0 ? r.Outputs : r.Value);
        internal void PlayerRemoved(int id)
        {
            var item = playerList.Items.Cast<PlayerChoice>().FirstOrDefault(p => p.Id == id);
            if (item != null) playerList.Items.Remove(item);
            if (playerList.Items.Count > 0) playerList.SelectedIndex = 0;
            if (leadStart?.PlayerId == id) CancelLead();
            playerState.Text = "播放器已销毁：" + id;
        }
        private Control PlayerScene() => Page(
            "AudioMixing与MediaPlayer分别演示。先打开音源，观察播放器就绪回调，再播放。播放/暂停/seek/停止各自有按钮；多个播放器用ID区分。",
            Row(mediaPath, ActionButton("选择文件", PickMedia), Label("起始ms"), startPosition, Label("循环（-1无限）"), loops),
            Row(mixingLocalOnly, Bind("开始伴奏", "IRtcEngine.StartAudioMixing", () => new { filePath = mediaPath.Text, loopback = mixingLocalOnly.Checked, cycle = (int)loops.Value, startPos = (int)startPosition.Value }),
                Bind("暂停伴奏", "IRtcEngine.PauseAudioMixing"), Bind("继续伴奏", "IRtcEngine.ResumeAudioMixing"), Bind("停止伴奏", "IRtcEngine.StopAudioMixing")),
            Row(Label("跳转ms"), seekPosition, Bind("伴奏跳转", "IRtcEngine.SetAudioMixingPosition", () => new { pos = (int)seekPosition.Value }),
                Bind("伴奏进度", "IRtcEngine.GetAudioMixingCurrentPosition", after: PlayerResult("伴奏进度ms")),
                Bind("伴奏时长", "IRtcEngine.GetAudioMixingDuration", after: PlayerResult("伴奏时长ms")), mixingState),
            Row(Label("伴奏播放音量"), mixingVolume, Bind("设置播放音量", "IRtcEngine.AdjustAudioMixingPlayoutVolume", () => new { volume = (int)mixingVolume.Value }),
                Bind("查询播放音量", "IRtcEngine.GetAudioMixingPlayoutVolume", after: PlayerResult("伴奏播放音量")),
                Label("伴奏发布音量"), publishVolume, Bind("设置发布音量", "IRtcEngine.AdjustAudioMixingPublishVolume", () => new { volume = (int)publishVolume.Value })),
            Row(Bind("创建播放器", "IRtcEngine.CreateMediaPlayer"), Label("播放器ID在顶部选择"),
                Bind("重挂播放器回调", "IMediaPlayer.InitEventHandler", () => new { engineEventHandler = (object)null }),
                Bind("销毁普通播放器", "IRtcEngine.DestroyMediaPlayer", () => new { media_player = (object)null })),
            Row(Bind("打开音源", "IMediaPlayer.Open", () => new { url = mediaPath.Text, startPos = (long)startPosition.Value }),
                Bind("播放", "IMediaPlayer.Play"), Bind("暂停", "IMediaPlayer.Pause"), Bind("继续", "IMediaPlayer.Resume"), Bind("停止", "IMediaPlayer.Stop"),
                Bind("播放器跳转", "IMediaPlayer.Seek", () => new { newPos = (long)seekPosition.Value }), Bind("设置循环", "IMediaPlayer.SetLoopCount", () => new { loopCount = (int)loops.Value })),
            Row(Bind("查询状态", "IMediaPlayer.GetState", after: r => playerState.Text = "查询状态：" + r.Value),
                Bind("查询位置", "IMediaPlayer.GetPlayPosition", () => new { pos = 0L }, PlayerResult("播放器位置ms")),
                Bind("查询时长", "IMediaPlayer.GetDuration", () => new { duration = 0L }, PlayerResult("播放器时长ms")),
                Bind("查询ID", "IMediaPlayer.GetId", after: PlayerResult("播放器ID")), playerState, playerProgress),
            Row(playerMute, Bind("应用播放器静音", "IMediaPlayer.Mute", () => new { muted = playerMute.Checked }),
                playerVolume, Bind("播放器音量", "IMediaPlayer.AdjustPlayoutVolume", () => new { volume = (int)playerVolume.Value }),
                Bind("查询播放器音量", "IMediaPlayer.GetPlayoutVolume", () => new { volume = 0 }, PlayerResult("播放器音量")),
                Bind("播放器发布音量", "IMediaPlayer.AdjustPublishSignalVolume", () => new { volume = (int)playerVolume.Value })),
            Row(Label("音效ID"), effectId, Label("增益"), effectGain, effectPublish,
                Bind("播放音效", "IRtcEngine.PlayEffect", () => new { soundId = (int)effectId.Value, filePath = mediaPath.Text, loopCount = (int)loops.Value, pitch = 1.0, pan = 0.0, gain = (int)effectGain.Value, publish = effectPublish.Checked, startPos = (int)startPosition.Value })),
            Row(loopback, Bind("应用系统声音采集", "IRtcEngine.EnableLoopbackRecording", () => new { enabled = loopback.Checked, deviceName = "" })));
    }
}
