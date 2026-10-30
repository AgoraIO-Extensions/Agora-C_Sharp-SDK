using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    // One shared session is reparented between the business scene tabs in MainForm.
    // These are ordinary demo controls, not a public API/JSON command console.
    internal sealed partial class BusinessApiView : UserControl
    {
        internal static readonly string[] SceneNames = { "音频设备与控制", "伴奏与播放器", "录音与外部音频", "消息与音频元数据", "双频道合唱", "曲库与诊断" };
        private readonly Func<string> readAppId;
        private readonly Func<string> readChannel;
        private readonly TextBox token = Input(200, "本轮RTC Token", true);
        private readonly NumericUpDown uid = Number(uint.MaxValue, 1001);
        private readonly NumericUpDown remoteUid = Number(uint.MaxValue, 2001);
        private readonly ComboBox role = Choice("主播", "观众");
        private readonly RichTextBox output = new RichTextBox { Dock = DockStyle.Fill, ReadOnly = true, Font = new Font("Consolas", 9) };
        private readonly Label state = new Label { Text = "未初始化。AppId和频道使用主窗口左侧输入。", Dock = DockStyle.Fill, AutoEllipsis = true };
        private readonly Panel host = new Panel { Dock = DockStyle.Fill };
        private readonly List<Control> pages = new List<Control>();
        private readonly List<(string Api, Button Button, Func<object> Prepare)> bindings = new List<(string, Button, Func<object>)>();
        private readonly List<BusinessApiOperation> operations = BusinessApiOperation.Create();
        private readonly ConcurrentQueue<string> pending = new ConcurrentQueue<string>();
        private readonly ConcurrentQueue<(int Epoch, string Name, string Json)> pendingEvents = new ConcurrentQueue<(int, string, string)>();
        private readonly HashSet<string> credentialsSeen = new HashSet<string>();
        private readonly System.Windows.Forms.Timer drain = new System.Windows.Forms.Timer { Interval = 100 };
        internal readonly BusinessApiEngine Session;
        private bool shuttingDown;
        private int dropped;
        internal string AppId => readAppId().Trim();
        internal string Token => token.Text.Trim();
        internal uint Uid => (uint)uid.Value;
        internal int PlayerId => playerList.SelectedItem is PlayerChoice player ? player.Id : -1;

        internal BusinessApiView(Func<string> appId, Func<string> channel)
        {
            readAppId = appId; readChannel = channel; Dock = DockStyle.Fill;
            Session = new BusinessApiEngine(this);
            var layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 5, Padding = new Padding(6) };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 170));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
            var header = Row(Label("Token"), token, Label("本地UID"), uid, Label("远端UID"), remoteUid, Label("单频道角色"), role, Label("播放器"), playerList,
                Bind("初始化", "IRtcEngine.Initialize", () => new { context = EngineContext(AppId) }),
                Bind("释放", "IRtcEngine.Dispose", () => new { sync = false }));
            layout.Controls.Add(header, 0, 0); layout.Controls.Add(host, 0, 1);
            layout.Controls.Add(state, 0, 2); layout.Controls.Add(output, 0, 3);
            layout.Controls.Add(Row(ActionButton("导出日志", Export), ActionButton("清空日志", ClearLog),
                Label("同步返回与真实回调分开显示；开始/停止、远端收发及文件结果须分别验收。")), 0, 4);
            Controls.Add(layout);
            channelProfile.SelectedItem = CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING;
            pages.Add(AudioScene()); pages.Add(PlayerScene()); pages.Add(RecordingScene());
            pages.Add(MessageScene()); pages.Add(ChorusScene()); pages.Add(MusicScene());
            drain.Tick += (_, __) => Drain(); drain.Start();
            ShowScene(0);
        }
        internal void ShowScene(int index)
        {
            host.Controls.Clear(); host.Controls.Add(pages[index]);
        }
        private static TextBox Input(int width, string hint = "", bool secret = false) => new TextBox { Width = width, PlaceholderText = hint, UseSystemPasswordChar = secret };
        private static NumericUpDown Number(decimal max, decimal value = 0, decimal min = 0) => new NumericUpDown { Width = 80, Maximum = max, Minimum = min, Value = value };
        private static Label Label(string text) => new Label { Text = text, AutoSize = true, Padding = new Padding(2, 6, 0, 0) };
        private static ComboBox Choice(params string[] items)
        { var c = new ComboBox { Width = 135, DropDownStyle = ComboBoxStyle.DropDownList }; c.Items.AddRange(items); c.SelectedIndex = 0; return c; }
        private static ComboBox Enums<T>() where T : struct, Enum
        { var c = new ComboBox { Width = 230, DropDownStyle = ComboBoxStyle.DropDownList }; foreach (var v in Enum.GetValues<T>().Distinct()) c.Items.Add(v); c.SelectedIndex = 0; return c; }
        private static FlowLayoutPanel Row(params Control[] controls)
        { var p = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, WrapContents = true, Margin = new Padding(0, 2, 0, 4) }; p.Controls.AddRange(controls); return p; }
        private static Control Page(string intro, params Control[] rows)
        {
            var page = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            var table = new TableLayoutPanel { Dock = DockStyle.Top, ColumnCount = 1, AutoSize = true, Padding = new Padding(3) };
            table.Controls.Add(new Label { Text = intro, AutoSize = true, MaximumSize = new Size(800, 0), Margin = new Padding(0, 0, 0, 8) });
            foreach (var row in rows) table.Controls.Add(row);
            page.Controls.Add(table); return page;
        }
        private Button ActionButton(string text, Action action)
        {
            var b = new Button { Text = text, AutoSize = true, MinimumSize = new Size(65, 29) };
            b.Click += (_, __) => Guard(action); return b;
        }
        private Button Bind(string text, string api, Func<object> args = null, Action<BusinessApiResult> after = null)
        {
            Button button = ActionButton(text, () => { var result = Call(api, args?.Invoke() ?? new { }); after?.Invoke(result); });
            bindings.Add((api, button, () => args?.Invoke() ?? new { })); return button;
        }
        private void Guard(Action action)
        { try { action(); } catch (Exception e) { Log("操作未完成：" + e.GetType().Name + " " + e.Message); } }
        private BusinessApiResult Call(string api, object values)
        {
            var json = JsonSerializer.Serialize(values, BusinessApiJson.Options);
            using var doc = JsonDocument.Parse(json);
            RememberCredentials(doc.RootElement); RememberCredential(AppId); RememberCredential(Token);
            var matches = Resolve(api, doc.RootElement);
            var result = Session.Execute(matches, json);
            if (result.Value is int n && n < 0 || result.Value is uint u && u == uint.MaxValue)
                throw new InvalidOperationException(api + "未成功，详见上方SDK返回值；后续步骤未执行。");
            return result;
        }
        private BusinessApiOperation Resolve(string api, JsonElement values)
        {
            var names = values.EnumerateObject().Select(p => p.Name).ToHashSet();
            var matches = operations.Where(o => o.Api == api &&
                names.All(name => o.Method.GetParameters().Any(p => p.Name == name)) &&
                o.Method.GetParameters().All(p => names.Contains(p.Name) || p.HasDefaultValue)).ToArray();
            if (matches.Length != 1) throw new InvalidOperationException("场景绑定的SDK重载不明确：" + api);
            BusinessApiJson.ReadArguments(matches[0], values.GetRawText());
            return matches[0];
        }
        internal void RegisterNavigationButtons(Button join, Button leave)
        {
            bindings.Add(("IRtcEngine.JoinChannel", join, null));
            bindings.Add(("IRtcEngine.LeaveChannel", leave, null));
        }
        private static T Out<T>(BusinessApiResult r, string name) => (T)r.Outputs[name];
        internal RtcEngineContext EngineContext(string appId) => new RtcEngineContext
        { appId = appId, audioScenario = (AUDIO_SCENARIO_TYPE)audioScenario.SelectedItem, channelProfile = (CHANNEL_PROFILE_TYPE)channelProfile.SelectedItem };
        internal ChannelMediaOptions MediaOptions(bool? audience = null, bool publishPlayer = false)
        {
            bool listen = audience ?? role.SelectedIndex == 1;
            var options = new ChannelMediaOptions();
            options.channelProfile.SetValue((CHANNEL_PROFILE_TYPE)channelProfile.SelectedItem);
            options.clientRoleType.SetValue(listen ? CLIENT_ROLE_TYPE.CLIENT_ROLE_AUDIENCE : CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);
            options.publishMicrophoneTrack.SetValue(!listen); options.publishCameraTrack.SetValue(false);
            options.autoSubscribeAudio.SetValue(true); options.autoSubscribeVideo.SetValue(false);
            options.audioDelayMs.SetValue((int)audioDelay.Value);
            if (publishPlayer)
            {
                if (PlayerId < 0) throw new InvalidOperationException("请先在播放器场景创建并选择播放器。");
                options.publishMediaPlayerId.SetValue(PlayerId); options.publishMediaPlayerAudioTrack.SetValue(true);
            }
            return options;
        }
        internal void SelectPlayer(int id, bool music = false)
        {
            var item = playerList.Items.Cast<PlayerChoice>().FirstOrDefault(p => p.Id == id);
            if (item == null) { item = new PlayerChoice { Id = id, Music = music }; playerList.Items.Add(item); }
            playerList.SelectedItem = item;
        }
        internal void SessionReleased()
        { CancelLead(); playerList.Items.Clear(); recordingDevices.Items.Clear(); playbackDevices.Items.Clear(); state.Text = "已释放；重新初始化后再操作。"; }
        internal void NoteEvent(int epoch, string name, object value)
        { if (pendingEvents.Count < 1000) pendingEvents.Enqueue((epoch, name, BusinessApiJson.Result(value))); }
        private void UpdateEvent(string name, string json)
        {
            using var doc = JsonDocument.Parse(json); var value = doc.RootElement;
            LeadEvent(name, value);
            if (name == "OnJoinChannelSuccess" || name == "OnLeaveChannel" || name == "OnConnectionStateChanged") state.Text = name + " " + json;
            if (name == "OnPositionChanged") playerProgress.Text = "播放器 " + value.GetProperty("playerId") + "：" + value.GetProperty("positionMs") + " ms";
            if (name == "OnPlayerSourceStateChanged") playerState.Text = "播放器 " + value.GetProperty("playerId") + "：" + value.GetProperty("state") + " / " + value.GetProperty("reason");
            if (name == "OnAudioMixingStateChanged") mixingState.Text = "伴奏状态：" + json;
            if (name == "OnPreLoadEvent") musicProgress.Text = "预加载：" + json;
            if (name == "OnSongSimpleInfoResult") songInfo.Text = json;
            if (name == "OnStreamMessage" || name == "OnAudioMetadataReceived") received.Text = json;
        }
        internal void Log(string message)
        {
            if (shuttingDown || IsDisposed) return;
            if (message.Length > 65536) message = message.Substring(0, 65536) + " [展示已截断]";
            if (pending.Count >= 2000) { System.Threading.Interlocked.Increment(ref dropped); return; }
            pending.Enqueue(DateTimeOffset.Now.ToString("HH:mm:ss.fff zzz ") + message);
        }
        private void Drain(int limit = 200)
        {
            int lost = System.Threading.Interlocked.Exchange(ref dropped, 0);
            if (lost > 0) output.AppendText($"[日志拥塞] 丢弃{lost}条展示记录，请减少回调频率后重测。\n");
            for (int i = 0; i < limit && pending.TryDequeue(out var line); i++)
            { foreach (var secret in credentialsSeen) line = line.Replace(secret, "[已隐藏]"); output.AppendText(line + Environment.NewLine); }
            for (int i = 0; i < limit && pendingEvents.TryDequeue(out var item); i++)
                if (item.Epoch == Session.Generation) Guard(() => UpdateEvent(item.Name, item.Json));
            if (output.TextLength > 1024 * 1024) { output.Select(0, output.TextLength / 2); output.SelectedText = "[旧日志已截断，请分轮导出]\n"; }
            output.SelectionStart = output.TextLength; output.ScrollToCaret();
        }
        private void RememberCredential(string value)
        { if (!string.IsNullOrWhiteSpace(value) && value != "$token" && value.Length >= 8) credentialsSeen.Add(value); }
        private void RememberCredentials(JsonElement value, string key = "")
        {
            if (value.ValueKind == JsonValueKind.Object) foreach (var p in value.EnumerateObject()) RememberCredentials(p.Value, p.Name);
            else if (value.ValueKind == JsonValueKind.Array) foreach (var v in value.EnumerateArray()) RememberCredentials(v);
            else if (value.ValueKind == JsonValueKind.String && (key.Contains("token", StringComparison.OrdinalIgnoreCase) || key.Equals("appId", StringComparison.OrdinalIgnoreCase))) RememberCredential(value.GetString());
        }
        private void ClearLog() { while (pending.TryDequeue(out _)) { } output.Clear(); }
        private void Export()
        {
            Drain(2000); using var dialog = new SaveFileDialog { Filter = "测试日志|*.log", FileName = "rtc-scenes-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".log" };
            if (dialog.ShowDialog(this) == DialogResult.OK) File.WriteAllText(dialog.FileName, output.Text, Encoding.UTF8);
        }
        internal int VerifyOfflineUi()
        {
            foreach (var op in operations) BusinessApiJson.ReadArguments(op, BusinessApiJson.Template(op, new RtcConnection("ui-smoke", 1001), "$token"));
            recordingDevices.Items.Add(new DeviceChoice { Value = new DeviceInfo { deviceName = "离线检查", deviceId = "ui-smoke" } });
            playbackDevices.Items.Add(new DeviceChoice { Value = new DeviceInfo { deviceName = "离线检查", deviceId = "ui-smoke" } });
            recordingDevices.SelectedIndex = 0; playbackDevices.SelectedIndex = 0;
            recordPath.Text = Path.Combine(Path.GetTempPath(), "scene-check.wav");
            logPath.Text = Path.Combine(Path.GetTempPath(), "scene-check.log");
            parameterKey.Text = "offline.check"; parameterValue.Text = "1";
            try
            {
                foreach (var b in bindings)
                {
                    if (!operations.Any(o => o.Api == b.Api)) throw new InvalidOperationException("无效按钮绑定：" + b.Api);
                    if (b.Prepare != null)
                    {
                        var args = JsonSerializer.SerializeToElement(b.Prepare(), BusinessApiJson.Options);
                        Resolve(b.Api, args);
                    }
                }
            }
            finally { recordingDevices.Items.Clear(); playbackDevices.Items.Clear(); recordPath.Clear(); logPath.Clear(); parameterKey.Clear(); parameterValue.Clear(); }
            if (Session.Initialized || pages.Count != SceneNames.Length || bindings.Count < 80) throw new InvalidOperationException("场景入口不完整。");
            return operations.Count;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing) { Shutdown(); foreach (var page in pages) if (!page.IsDisposed) page.Dispose(); }
            base.Dispose(disposing);
        }
        internal void Shutdown() { if (shuttingDown) return; Guard(() => Session.UnInit()); Drain(2000); shuttingDown = true; drain.Stop(); drain.Dispose(); }
    }
}
