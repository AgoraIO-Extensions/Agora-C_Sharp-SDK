using System;
using System.IO;
using System.Windows.Forms;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    internal sealed partial class BusinessApiView
    {
        private readonly TextBox recordPath = Input(360, "选择录音输出文件"), pcmPath = Input(320, "16bit裸PCM；留空发送440Hz测试音");
        private readonly ComboBox recordingQuality = Enums<AUDIO_RECORDING_QUALITY_TYPE>(), recordingContent = Enums<AUDIO_FILE_RECORDING_TYPE>();
        private readonly ComboBox recordRate = Choice("32000", "16000", "44100", "48000"), pcmRate = Choice("48000", "44100", "32000", "16000", "8000");
        private readonly NumericUpDown recordChannels = Number(2, 1, 1), pcmChannels = Number(2, 1, 1), trackId = Number(uint.MaxValue);
        private readonly CheckBox encodeRecording = new CheckBox { Text = "AAC编码", AutoSize = true }, localPcm = new CheckBox { Text = "本地播放PCM", Checked = true, AutoSize = true }, processPcm = new CheckBox { Text = "音频处理", AutoSize = true };
        private readonly ComboBox trackType = Enums<AUDIO_TRACK_TYPE>();
        private readonly Label fileStatus = Label("录音文件结果尚未检查");
        private void PickRecord()
        { using var d = new SaveFileDialog { Filter = "WAV|*.wav|AAC|*.aac|所有文件|*.*" }; if (d.ShowDialog(this) == DialogResult.OK) recordPath.Text = d.FileName; }
        private AudioRecordingConfiguration RecordingConfig()
        {
            if (string.IsNullOrWhiteSpace(recordPath.Text)) throw new InvalidOperationException("请选择录音输出文件。");
            return new AudioRecordingConfiguration { filePath = Path.GetFullPath(recordPath.Text), encode = encodeRecording.Checked,
                sampleRate = int.Parse(recordRate.Text), quality = (AUDIO_RECORDING_QUALITY_TYPE)recordingQuality.SelectedItem,
                fileRecordingType = (AUDIO_FILE_RECORDING_TYPE)recordingContent.SelectedItem, recordingChannel = (int)recordChannels.Value };
        }
        private Control RecordingScene() => Page(
            "录音先开始、后停止，再检查文件并回放。外部PCM与原始帧观察分别演示；自定义轨道须在入会前创建。FULL包测试，不在这里裁剪Native模块。",
            Row(recordPath, ActionButton("选择输出文件", PickRecord), encodeRecording, recordRate, Label("声道"), recordChannels),
            Row(recordingQuality, recordingContent,
                Bind("开始录音", "IRtcEngine.StartAudioRecording", () => new { config = RecordingConfig() }),
                Bind("停止录音", "IRtcEngine.StopAudioRecording"), ActionButton("检查录音文件", () =>
                {
                    var file = new FileInfo(recordPath.Text);
                    fileStatus.Text = file.Exists ? $"文件存在，{file.Length}字节。请回放确认音轨、内容与质量。" : "没有找到文件，请检查SDK返回值和路径。";
                }), fileStatus),
            Row(ActionButton("将录音作为播放器音源", () => { mediaPath.Text = recordPath.Text; Log("已设置音源，请切到伴奏与播放器场景，打开并回放。"); })),
            Row(trackType, localPcm, processPcm,
                Bind("创建外部音轨", "IRtcEngine.CreateCustomAudioTrack", () => new { trackType = (AUDIO_TRACK_TYPE)trackType.SelectedItem, config = new AudioTrackConfig(localPcm.Checked, processPcm.Checked) }, r => trackId.Value = (uint)r.Value),
                Label("轨道ID"), trackId, Bind("销毁外部音轨", "IRtcEngine.DestroyCustomAudioTrack", () => new { trackId = (uint)trackId.Value })),
            Row(Bind("在当前频道发布外部音轨", "IRtcEngine.UpdateChannelMediaOptions", () =>
            {
                var options = MediaOptions(); options.publishCustomAudioTrack.SetValue(true);
                options.publishCustomAudioTrackId.SetValue(checked((int)trackId.Value)); options.publishMicrophoneTrack.SetValue(false);
                return new { options };
            }), Label("DIRECT轨道须关闭麦克风发布；未入会时在合唱页配置后加入。")),
            Row(pcmPath, ActionButton("选择PCM文件", () => { using var d = new OpenFileDialog { Filter = "裸PCM|*.pcm|所有文件|*.*" }; if (d.ShowDialog(this) == DialogResult.OK) pcmPath.Text = d.FileName; }),
                pcmRate, pcmChannels, ActionButton("开始推送PCM", () => Session.StartPcm(pcmPath.Text, int.Parse(pcmRate.Text), (int)pcmChannels.Value, (uint)trackId.Value)),
                ActionButton("停止推送PCM", Session.StopPcm)),
            Row(Bind("推送单帧测试音频", "IRtcEngine.PushAudioFrame", () => new { frame = BusinessApiJson.Default(typeof(AudioFrame)), trackId = (uint)trackId.Value }),
                Bind("观察原始音频帧", "IRtcEngine.RegisterAudioFrameObserver", () => new { audioFrameObserver = (object)null,
                    position = AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_RECORD | AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_PLAYBACK | AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_MIXED | AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_BEFORE_MIXING,
                    mode = OBSERVER_MODE.INTPTR }), Bind("停止帧观察", "IRtcEngine.UnRegisterAudioFrameObserver")),
            Label("PCM按20ms帧发送，需对端验证声音；UI计时器不用于精密合唱时延验收。帧回调显示首帧及每100帧摘要。"));
    }
}
