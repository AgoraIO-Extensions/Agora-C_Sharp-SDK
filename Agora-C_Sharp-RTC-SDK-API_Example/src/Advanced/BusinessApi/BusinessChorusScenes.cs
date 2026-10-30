using System;
using System.Linq;
using System.Windows.Forms;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    internal sealed partial class BusinessApiView
    {
        private readonly TextBox secondChannel = Input(170, "连接B频道"), secondToken = Input(200, "连接B Token", true), chorusMedia = Input(350, "主唱示例伴奏文件/URL");
        private readonly NumericUpDown secondUid = Number(uint.MaxValue, 1002);
        private readonly ComboBox chorusRole = Choice("主唱", "伴唱", "观众");
        private readonly CheckBox publishPlayer = new CheckBox { Text = "发布顶部所选播放器的伴奏", AutoSize = true }, publishExternal = new CheckBox { Text = "发布外部PCM（关闭麦克风）", AutoSize = true };
        private readonly Label chorusState = Label("尚未开始。A使用主窗口频道和本地UID，B使用下方配置。");
        private readonly TextBox relayChannel = Input(170, "转发目标频道"), relayToken = Input(200, "转发目标Token", true);
        private readonly NumericUpDown relayUid = Number(uint.MaxValue, 3001);
        private BusinessLeadStart leadStart;
        private RtcConnection Connection(bool second)
        {
            var value = second ? new RtcConnection(secondChannel.Text.Trim(), (uint)secondUid.Value)
                : new RtcConnection(readChannel().Split(';')[0].Trim(), Uid);
            if (value.localUid == 0 || string.IsNullOrWhiteSpace(value.channelId))
                throw new InvalidOperationException("双连接请填写频道和明确的非0 UID，以便区分回调与Token。");
            return value;
        }
        private ChannelMediaOptions ChorusOptions()
        {
            var options = MediaOptions(chorusRole.SelectedIndex == 2, publishPlayer.Checked);
            if (publishExternal.Checked)
            {
                options.publishMicrophoneTrack.SetValue(false); options.publishCustomAudioTrack.SetValue(true);
                options.publishCustomAudioTrackId.SetValue(checked((int)trackId.Value));
            }
            return options;
        }
        private void StartLead()
        {
            if (string.IsNullOrWhiteSpace(chorusMedia.Text)) throw new InvalidOperationException("请选择主唱示例的伴奏文件或URL。");
            if (!Session.Initialized && Session.Init(AppId) < 0) return;
            CancelLead();
            int id = (int)Call("IRtcEngine.CreateMediaPlayer", new { }).Value;
            leadStart = new BusinessLeadStart(Session.Generation, id, Connection(false));
            mediaPath.Text = chorusMedia.Text;
            try { Call("IMediaPlayer.Open", new { url = chorusMedia.Text, startPos = (long)startPosition.Value }); }
            catch { CancelLead(); throw; }
            chorusState.Text = "正在打开伴奏；收到播放器就绪后加入A，收到入会成功后才播放。";
        }
        private void CancelLead() { leadStart?.Cancel(); leadStart = null; }
        private void LeadEvent(string name, System.Text.Json.JsonElement value)
        {
            var plan = leadStart;
            if (plan == null) return;
            if (name == "OnPlayerSourceStateChanged")
            {
                int id = value.GetProperty("playerId").GetInt32();
                string playerStateValue = value.GetProperty("state").GetString();
                bool failed = playerStateValue == nameof(MEDIA_PLAYER_STATE.PLAYER_STATE_FAILED);
                if (plan.Opened(Session.Generation, id, playerStateValue == nameof(MEDIA_PLAYER_STATE.PLAYER_STATE_OPEN_COMPLETED), failed))
                {
                    SelectPlayer(plan.PlayerId);
                    try { Call("IRtcEngineEx.JoinChannelEx", new { token = Token, connection = plan.Connection, options = MediaOptions(false, true) }); }
                    catch { CancelLead(); throw; }
                    chorusState.Text = "伴奏已就绪，正在加入连接A；尚未开始播放。";
                }
                else if (id == plan.PlayerId && failed)
                { CancelLead(); chorusState.Text = "伴奏打开/播放失败，自动流程已取消，请检查真实回调。"; }
            }
            if (name == "OnJoinChannelSuccess")
            {
                var connection = value.GetProperty("connection");
                if (!plan.Joined(Session.Generation, new RtcConnection(connection.GetProperty("channelId").GetString(), connection.GetProperty("localUid").GetUInt32()))) return;
                SelectPlayer(plan.PlayerId);
                try { Call("IMediaPlayer.SetLoopCount", new { loopCount = (int)loops.Value }); Call("IMediaPlayer.Play", new { }); }
                catch { CancelLead(); throw; }
                chorusState.Text = "已收到连接A入会成功，播放请求已提交；仍需检查播放回调及对端伴奏。";
            }
        }
        private void StopChorus()
        {
            int leadId = leadStart?.PlayerId ?? PlayerId;
            CancelLead(); Session.StopPcm();
            if (leadId >= 0 && playerList.Items.Cast<PlayerChoice>().Any(p => p.Id == leadId)) SelectPlayer(leadId);
            if (PlayerId >= 0)
            {
                Guard(() => Call("IMediaPlayer.Stop", new { }));
                Guard(() => Call(IsMusicPlayer ? "IMusicContentCenter.DestroyMusicPlayer" : "IRtcEngine.DestroyMediaPlayer",
                    IsMusicPlayer ? (object)new { music_player = (object)null } : new { media_player = (object)null }));
            }
            Guard(() => Call("IRtcEngineEx.LeaveChannelEx", new { connection = Connection(false) }));
            Guard(() => Call("IRtcEngineEx.LeaveChannelEx", new { connection = Connection(true) }));
            chorusState.Text = "停止/退出请求已逐项提交；以各播放器和连接的真实回调为准。";
        }
        private Control ChorusScene()
        {
            Button begin = ActionButton("开始主唱示例", StartLead), end = ActionButton("停止并退出合唱", StopChorus);
            foreach (var api in new[] { "IRtcEngine.CreateMediaPlayer", "IMediaPlayer.Open", "IRtcEngineEx.JoinChannelEx", "IMediaPlayer.Play", "IMediaPlayer.SetLoopCount" }) bindings.Add((api, begin, null));
            foreach (var api in new[] { "IMediaPlayer.Stop", "IRtcEngine.DestroyMediaPlayer", "IMusicContentCenter.DestroyMusicPlayer", "IRtcEngineEx.LeaveChannelEx" }) bindings.Add((api, end, null));
            return Page("同一Demo、同一引擎演示主唱/伴唱/观众和两条连接。主唱示例会等待播放器就绪与入会回调后播放；双端同步精度仍须真机验收。左侧单频道按钮在此页暂停使用。",
                Row(chorusMedia, ActionButton("选择伴奏", () => { using var d = new OpenFileDialog { Filter = "伴奏文件|*.*" }; if (d.ShowDialog(this) == DialogResult.OK) chorusMedia.Text = d.FileName; }), begin, end), chorusState,
                Row(Label("连接B频道"), secondChannel, Label("B UID"), secondUid, secondToken),
                Row(Label("合唱角色"), chorusRole, publishPlayer, publishExternal),
                Row(Bind("加入连接A", "IRtcEngineEx.JoinChannelEx", () => new { token = Token, connection = Connection(false), options = ChorusOptions() }),
                    Bind("更新A媒体发布", "IRtcEngineEx.UpdateChannelMediaOptionsEx", () => new { options = ChorusOptions(), connection = Connection(false) }),
                    Bind("退出A", "IRtcEngineEx.LeaveChannelEx", () => new { connection = Connection(false) })),
                Row(Bind("加入连接B", "IRtcEngineEx.JoinChannelEx", () => new { token = secondToken.Text.Trim(), connection = Connection(true), options = ChorusOptions() }),
                    Bind("更新B媒体发布", "IRtcEngineEx.UpdateChannelMediaOptionsEx", () => new { options = ChorusOptions(), connection = Connection(true) }),
                    Bind("退出B", "IRtcEngineEx.LeaveChannelEx", () => new { connection = Connection(true) })),
                Row(Bind("续期A Token", "IRtcEngineEx.UpdateChannelMediaOptionsEx", () => { var options = new ChannelMediaOptions(); options.token.SetValue(Token); return new { options, connection = Connection(false) }; }),
                    Bind("续期B Token", "IRtcEngineEx.UpdateChannelMediaOptionsEx", () => { var options = new ChannelMediaOptions(); options.token.SetValue(secondToken.Text.Trim()); return new { options, connection = Connection(true) }; }),
                    Bind("查询NTP时钟", "IRtcEngine.GetNtpWallTimeInMs", after: r => chorusState.Text = "SDK NTP墙钟毫秒：" + r.Value)),
                Label("要验证进度同步：切到消息场景，选择A/B，填播放器进度消息后发送；切业务页不退出当前连接。"),
                Row(Label("跨房转发目标"), relayChannel, relayToken, Label("目标UID"), relayUid,
                    Bind("开始/更新转发", "IRtcEngine.StartOrUpdateChannelMediaRelay", () => new { configuration = new ChannelMediaRelayConfiguration
                    { srcInfo = new ChannelMediaInfo { channelName = readChannel().Split(';')[0], uid = Uid, token = Token }, destInfos = new[] { new ChannelMediaInfo { channelName = relayChannel.Text.Trim(), uid = (uint)relayUid.Value, token = relayToken.Text.Trim() } }, destCount = 1 } }),
                    Bind("停止转发", "IRtcEngine.StopChannelMediaRelay")));
        }
    }
}
