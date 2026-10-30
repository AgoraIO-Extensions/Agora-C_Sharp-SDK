using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Windows.Forms;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    internal sealed class BusinessApiView : UserControl
    {
        private readonly TextBox appId = new TextBox { Width = 210, UseSystemPasswordChar = true };
        private readonly TextBox channel = new TextBox { Width = 160, Text = "business-test" };
        private readonly NumericUpDown uid = new NumericUpDown { Width = 100, Maximum = uint.MaxValue, Value = 1001 };
        private readonly TextBox token = new TextBox { Width = 240, UseSystemPasswordChar = true };
        private readonly NumericUpDown remoteUid = new NumericUpDown { Width = 100, Maximum = uint.MaxValue, Value = 2001 };
        private readonly NumericUpDown playerId = new NumericUpDown { Width = 75, Maximum = int.MaxValue };
        private readonly ComboBox target = new ComboBox { Width = 175, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly TextBox search = new TextBox { Width = 170, PlaceholderText = "接口名或业务说明" };
        private readonly ComboBox operation = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList, DropDownWidth = 1000 };
        private readonly ComboBox preset = new ComboBox { Width = 190, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly Label description = new Label { Dock = DockStyle.Fill, AutoEllipsis = true };
        private readonly RichTextBox arguments = new RichTextBox { Dock = DockStyle.Fill, Font = new Font("Consolas", 10), WordWrap = false };
        private readonly RichTextBox output = new RichTextBox { Dock = DockStyle.Fill, ReadOnly = true, Font = new Font("Consolas", 10) };
        private readonly TextBox pcmPath = new TextBox { Width = 220, PlaceholderText = "PCM文件；留空发送440Hz测试音" };
        private readonly ComboBox pcmRate = new ComboBox { Width = 80, DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly NumericUpDown pcmChannels = new NumericUpDown { Width = 45, Minimum = 1, Maximum = 2, Value = 1 };
        private readonly NumericUpDown trackId = new NumericUpDown { Width = 85, Maximum = uint.MaxValue };
        private readonly List<BusinessApiOperation> operations = BusinessApiOperation.Create();
        private readonly ConcurrentQueue<string> pending = new ConcurrentQueue<string>();
        private readonly System.Windows.Forms.Timer drain = new System.Windows.Forms.Timer { Interval = 100 };
        private readonly BusinessApiEngine session;
        private bool shuttingDown;
        private int dropped;
        private readonly HashSet<string> credentialsSeen = new HashSet<string>();
        internal string AppId => appId.Text.Trim();
        internal string Token => token.Text.Trim();
        internal uint Uid => (uint)uid.Value;
        internal int PlayerId => (int)playerId.Value;

        internal BusinessApiView(string initialAppId, string initialChannel)
        {
            Dock = DockStyle.Fill;
            appId.Text = initialAppId;
            if (initialAppId.Length >= 8) credentialsSeen.Add(initialAppId);
            appId.TextChanged += (_, __) => RememberCredential(AppId);
            token.TextChanged += (_, __) => RememberCredential(Token);
            if (!string.IsNullOrWhiteSpace(initialChannel)) channel.Text = initialChannel.Split(';')[0];
            session = new BusinessApiEngine(this);
            var layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 8, Padding = new Padding(8) };
            foreach (int h in new[] { 34, 34, 36, 36, 58 }) layout.RowStyles.Add(new RowStyle(SizeType.Absolute, h));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42));
            var credentials = Row();
            credentials.Controls.AddRange(new Control[] { Label("AppId"), appId, Label("Token"), token,
                Button("初始化", () => session.Init(AppId)), Button("释放", () => session.UnInit()) });
            layout.Controls.Add(credentials, 0, 0);
            preset.Items.AddRange(new object[] { "默认：麦克风主播", "主唱：麦克风+播放器", "伴唱：麦克风", "观众：仅订阅" }); preset.SelectedIndex = 0;
            var connection = Row();
            connection.Controls.AddRange(new Control[] { Label("频道"), channel, Label("本地UID"), uid,
                Label("远端UID"), remoteUid, Label("播放器ID"), playerId, preset });
            layout.Controls.Add(connection, 0, 1);
            target.Items.Add("全部对象");
            foreach (var name in operations.Select(o => o.Target).Distinct()) target.Items.Add(name);
            target.SelectedIndex = 0;
            var filters = Row();
            filters.Controls.AddRange(new Control[] { target, search, Button("生成入参", FillArguments),
                Button("填文件路径", PickFile), Button("填UTF8测试消息", FillMessage), Button("执行所选API", Execute) });
            layout.Controls.Add(filters, 0, 2);
            layout.Controls.Add(operation, 0, 3);
            layout.Controls.Add(description, 0, 4);
            var panes = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Vertical };
            panes.Panel1.Controls.Add(arguments); panes.Panel2.Controls.Add(output);
            layout.Controls.Add(panes, 0, 5);
            var pcm = Row();
            pcmRate.Items.AddRange(new object[] { "8000", "16000", "32000", "44100", "48000" }); pcmRate.SelectedItem = "48000";
            pcm.Controls.AddRange(new Control[] { Label("PCM"), pcmPath, pcmRate, Label("声道"), pcmChannels,
                Label("trackId"), trackId, Button("开始推PCM", () => session.StartPcm(pcmPath.Text, int.Parse(pcmRate.Text), (int)pcmChannels.Value, (uint)trackId.Value)),
                Button("停止推PCM", session.StopPcm) });
            layout.Controls.Add(pcm, 0, 6);
            var footer = Row();
            footer.Controls.AddRange(new Control[] { Button("导出当前日志", Export), Button("清空日志", ClearLog),
                new Label { Text = "返回0≠异步完成；byte[]使用数字数组；Optional填值/null；修改连接后重新生成入参。", AutoSize = true, Padding = new Padding(4, 7, 0, 0) } });
            layout.Controls.Add(footer, 0, 7);
            Controls.Add(layout);
            operation.SelectedIndexChanged += (_, __) => FillArguments();
            target.SelectedIndexChanged += (_, __) => Filter();
            search.TextChanged += (_, __) => Filter();
            drain.Tick += (_, __) => Drain(); drain.Start();
            Filter();
            operation.SelectedItem = operations.First(o => o.Api == "IRtcEngine.Initialize");
            Log("就绪：先初始化；选择接口→生成入参→编辑JSON→执行。只记录真实返回值和回调，不自动判为验收通过。");
        }
        private static FlowLayoutPanel Row() => new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false, AutoScroll = true };
        private static Label Label(string text) => new Label { Text = text, AutoSize = true, Padding = new Padding(3, 7, 0, 0) };
        private Button Button(string text, Action action)
        {
            var b = new Button { Text = text, AutoSize = true, Height = 28 };
            b.Click += (_, __) => Guard(action);
            return b;
        }
        private void Guard(Action action)
        {
            try { action(); }
            catch (Exception e) { Log("操作未完成: " + e.GetType().Name + " " + e.Message); }
        }
        private BusinessApiOperation Selected => operation.SelectedItem as BusinessApiOperation;
        private void Filter()
        {
            var selected = operations.Where(o => (target.SelectedIndex == 0 || o.Target == target.Text) &&
                (o.Api + o.Description).Contains(search.Text.Trim(), StringComparison.OrdinalIgnoreCase)).ToArray();
            operation.DataSource = selected;
            if (selected.Length == 0) { description.Text = "未找到接口。移动端扬声器接口和非C#集合方法不在Windows目录中。"; arguments.Clear(); }
        }
        private void FillArguments()
        {
            if (Selected == null) return;
            var op = Selected;
            arguments.Text = BusinessApiJson.Template(op, new RtcConnection(channel.Text.Trim(), Uid), "$token");
            var json = JsonNode.Parse(arguments.Text).AsObject();
            if (json.ContainsKey("uid") && op.Method.Name != "JoinChannel") json["uid"] = (uint)remoteUid.Value;
            if (json.ContainsKey("uidList")) { json["uidList"] = new JsonArray((uint)remoteUid.Value); json["uidNumber"] = 1; }
            foreach (var p in op.Method.GetParameters().Where(p => p.ParameterType == typeof(ChannelMediaOptions)))
            {
                var media = json[p.Name].AsObject();
                media["publishCameraTrack"] = false;
                media["publishMicrophoneTrack"] = preset.SelectedIndex != 3;
                media["autoSubscribeAudio"] = true;
                media["autoSubscribeVideo"] = false;
                media["clientRoleType"] = preset.SelectedIndex == 3 ? "CLIENT_ROLE_AUDIENCE" : "CLIENT_ROLE_BROADCASTER";
                if (preset.SelectedIndex == 1)
                { media["publishMediaPlayerId"] = PlayerId; media["publishMediaPlayerAudioTrack"] = true; }
            }
            arguments.Text = json.ToJsonString(BusinessApiJson.Options);
            var note = op.Api.Contains("Metadata") || op.Target.Contains("Music") || op.Api.EndsWith("GetMusicContentCenter")
                ? "源码含@ignore/技术预览；可验证调用，但不表示稳定支持。" : "";
            if (op.Method.Name.StartsWith("SetLog")) note += " 日志Setter含旧接口；初始化配置优先使用RtcEngineContext.logConfig。";
            if (op.Method.GetParameters().Any(p => p.ParameterType.IsAbstract)) note += " 抽象观察器/播放器参数由面板当前对象提供，勿手填对象。";
            description.Text = $"{op.Description}（原业务表行 {op.SourceRows}）。{note}\n{op}";
        }
        private void Execute()
        {
            if (Selected == null) return;
            Log("执行 " + Selected.Api + "（凭据不写入日志；同步返回与异步回调分开记录）");
            using (var doc = JsonDocument.Parse(arguments.Text)) RememberCredentials(doc.RootElement);
            session.Execute(Selected, arguments.Text);
        }
        private void RememberCredential(string value)
        {
            if (!string.IsNullOrWhiteSpace(value) && value != "$token" && value.Length >= 8) credentialsSeen.Add(value);
        }
        private void RememberCredentials(JsonElement value, string key = "")
        {
            if (value.ValueKind == JsonValueKind.Object)
                foreach (var property in value.EnumerateObject()) RememberCredentials(property.Value, property.Name);
            else if (value.ValueKind == JsonValueKind.Array)
                foreach (var item in value.EnumerateArray()) RememberCredentials(item);
            else if (value.ValueKind == JsonValueKind.String &&
                (key.Contains("token", StringComparison.OrdinalIgnoreCase) || key.Equals("appId", StringComparison.OrdinalIgnoreCase)))
                RememberCredential(value.GetString());
        }
        private void FillMessage()
        {
            if (Selected == null) return;
            var name = Selected.Method.GetParameters().FirstOrDefault(p => p.ParameterType == typeof(byte[]))?.Name;
            if (name == null) throw new InvalidOperationException("先选择元数据或数据流发送接口。");
            var doc = JsonNode.Parse(arguments.Text).AsObject();
            var bytes = Encoding.UTF8.GetBytes("业务测试-" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
            doc[name] = JsonSerializer.SerializeToNode(bytes, BusinessApiJson.Options); doc["length"] = bytes.Length;
            arguments.Text = doc.ToJsonString(BusinessApiJson.Options);
        }
        private void PickFile()
        {
            if (Selected == null) return;
            bool recording = Selected.Method.Name == "StartAudioRecording";
            using FileDialog dialog = recording ? new SaveFileDialog { Filter = "WAV文件|*.wav|所有文件|*.*" } : new OpenFileDialog { Filter = "媒体/测试文件|*.*" };
            if (dialog.ShowDialog(this) != DialogResult.OK) return;
            var doc = JsonNode.Parse(arguments.Text).AsObject();
            var p = Selected.Method.GetParameters().FirstOrDefault(p => new[] { "filePath", "url", "testAudioFilePath" }.Contains(p.Name));
            if (p != null) doc[p.Name] = dialog.FileName;
            else if (Selected.Method.GetParameters().Any(p => p.ParameterType == typeof(AudioRecordingConfiguration)))
            {
                var key = Selected.Method.GetParameters().First(p => p.ParameterType == typeof(AudioRecordingConfiguration)).Name;
                doc[key]["filePath"] = dialog.FileName;
            }
            else throw new InvalidOperationException("当前接口没有可填入的媒体文件参数。");
            arguments.Text = doc.ToJsonString(BusinessApiJson.Options);
        }
        internal int VerifyOfflineUi()
        {
            foreach (var op in operations)
            {
                operation.SelectedItem = op;
                BusinessApiJson.ReadArguments(op, arguments.Text);
                if (description.Text.Length == 0) throw new InvalidOperationException("缺少操作说明。");
            }
            operation.SelectedItem = operations.First(o => o.Api == "IRtcEngineEx.SendAudioMetadataEx");
            if (session.Initialized) throw new InvalidOperationException("离线UI检查不应初始化Native。");
            Log("离线UI检查通过：全部类型化入参编辑器均可解析；未调用Native。");
            Drain();
            return operations.Count;
        }
        internal void SelectPlayer(int id) { playerId.Value = Math.Max(0, id); }
        internal void Log(string message)
        {
            if (shuttingDown || IsDisposed) return;
            if (message.Length > 65536) message = message.Substring(0, 65536) + " [单条日志超过64KiB，已截断；请缩小测试结果]";
            if (pending.Count >= 2000) { System.Threading.Interlocked.Increment(ref dropped); return; }
            pending.Enqueue(DateTimeOffset.Now.ToString("HH:mm:ss.fff zzz ") + message);
        }
        private void Drain(int limit = 200)
        {
            int lost = System.Threading.Interlocked.Exchange(ref dropped, 0);
            if (lost > 0) output.AppendText($"[日志拥塞] 丢弃{lost}条展示记录；减少回调频率后重测。\n");
            for (int i = 0; i < limit && pending.TryDequeue(out var line); i++)
            {
                // Use a snapshot of current credentials only on the UI thread; callbacks never read controls.
                foreach (var secret in credentialsSeen) line = line.Replace(secret, "[已隐藏]");
                output.AppendText(line + Environment.NewLine);
            }
            if (output.TextLength > 1024 * 1024)
            { output.Select(0, output.TextLength / 2); output.SelectedText = "[旧日志已截断；需要完整场景记录时分轮导出]\n"; }
            output.SelectionStart = output.TextLength; output.ScrollToCaret();
        }
        private void ClearLog()
        {
            while (pending.TryDequeue(out _)) { }
            System.Threading.Interlocked.Exchange(ref dropped, 0);
            output.Clear();
        }
        private void Export()
        {
            Drain(2000);
            using var dialog = new SaveFileDialog { Filter = "测试日志|*.log", FileName = "business-api-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".log" };
            if (dialog.ShowDialog(this) == DialogResult.OK) File.WriteAllText(dialog.FileName, output.Text, Encoding.UTF8);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing) Shutdown();
            base.Dispose(disposing);
        }
        internal void Shutdown()
        {
            if (shuttingDown) return;
            Guard(() => session.UnInit());
            Drain(2000); shuttingDown = true; drain.Stop(); drain.Dispose();
        }
    }
}
