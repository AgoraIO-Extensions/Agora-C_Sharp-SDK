using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    internal sealed partial class BusinessApiView
    {
        private readonly TextBox musicToken = Input(220, "曲库独立Token", true), songInfo = new TextBox { Width = 700, Height = 65, Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical };
        private readonly NumericUpDown musicUid = Number(long.MaxValue, 1001), songCode = Number(long.MaxValue, 1), cacheSize = Number(10000, 10, 1);
        private readonly ComboBox musicMode = Enums<MusicPlayMode>(), channelProfile = Enums<CHANNEL_PROFILE_TYPE>(), logLevel = Enums<LOG_LEVEL>();
        private readonly Label musicProgress = Label("曲库未初始化，预加载结果会在此显示");
        private readonly TextBox logPath = Input(300, "SDK日志文件绝对路径"), parameterKey = Input(240, "业务确认的高级参数名"), parameterValue = Input(160, "整数/布尔值/文本");
        private readonly NumericUpDown logSize = Number(102400, 2048, 1), diagnosticCode = Number(int.MaxValue, -2, int.MinValue), reportValue = Number(int.MaxValue, 1, int.MinValue);
        private readonly TextBox reportId = Input(90, "id"), reportCategory = Input(90, "category"), reportEvent = Input(90, "event"), reportLabel = Input(90, "label");
        private bool IsMusicPlayer => playerList.SelectedItem is PlayerChoice choice && choice.Music;
        private sealed class PlayerChoice
        {
            internal int Id; internal bool Music;
            public override string ToString() => Id + (Music ? " 曲库" : " 普通");
        }
        private void DestroySelectedPlayer()
        {
            if (IsMusicPlayer) Call("IMusicContentCenter.DestroyMusicPlayer", new { music_player = (object)null });
            else Call("IRtcEngine.DestroyMediaPlayer", new { media_player = (object)null });
        }
        private Control MusicScene()
        {
            var initMusic = ActionButton("连接并初始化曲库", () =>
            {
                Call("IRtcEngine.GetMusicContentCenter", new { });
                Call("IMusicContentCenter.Initialize", new { configuration = new MusicContentCenterConfiguration(AppId, musicToken.Text.Trim(), (long)musicUid.Value, (int)cacheSize.Value) });
                musicProgress.Text = "曲库初始化请求已返回；请继续查询/预加载歌曲并检查真实回调。";
            });
            bindings.Add(("IRtcEngine.GetMusicContentCenter", initMusic, null)); bindings.Add(("IMusicContentCenter.Initialize", initMusic, null));
            return Page("曲库需要独立授权与Token，不是只填RTC AppId就可使用。初始化、歌曲信息、预加载和曲库播放器各有操作；技术预览/不支持会保留真实错误。",
                Row(musicToken, Label("曲库UID"), musicUid, Label("缓存"), cacheSize, initMusic),
                Row(Bind("重挂曲库事件", "IMusicContentCenter.RegisterEventHandler", () => new { eventHandler = (object)null }),
                    Bind("曲库Token续期", "IMusicContentCenter.RenewToken", () => new { token = musicToken.Text.Trim() }),
                    Label("歌曲ID"), songCode, Bind("查询歌曲信息", "IMusicContentCenter.GetSongSimpleInfo", () => new { requestId = "", songCode = (long)songCode.Value })),
                Row(Bind("预加载歌曲", "IMusicContentCenter.Preload", () => new { requestId = "", songCode = (long)songCode.Value }),
                    Bind("查询预加载", "IMusicContentCenter.IsPreloaded", () => new { songCode = (long)songCode.Value }, r => musicProgress.Text = "IsPreloaded实际返回：" + r.Value), musicProgress),
                songInfo,
                Row(Bind("创建曲库播放器", "IMusicContentCenter.CreateMusicPlayer"), Bind("打开这首歌曲", "IMusicPlayer.Open", () => new { songCode = (long)songCode.Value, startPos = (long)startPosition.Value }),
                    musicMode, Bind("应用原唱/伴唱模式", "IMusicPlayer.SetPlayMode", () => new { mode = (MusicPlayMode)musicMode.SelectedItem }),
                    Bind("销毁曲库播放器", "IMusicContentCenter.DestroyMusicPlayer", () => new { music_player = (object)null })),
                Label("播放/暂停/继续/跳转在伴奏与播放器页操作；顶部播放器ID在各场景共享。以下为连接与诊断设置。"),
                Row(channelProfile, Bind("设置频道场景", "IRtcEngine.SetChannelProfile", () => new { profile = (CHANNEL_PROFILE_TYPE)channelProfile.SelectedItem }),
                    Bind("应用单频道角色", "IRtcEngine.SetClientRole", () => new { role = role.SelectedIndex == 1 ? CLIENT_ROLE_TYPE.CLIENT_ROLE_AUDIENCE : CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER }),
                    Bind("查询连接", "IRtcEngine.GetConnectionState", after: r => state.Text = "连接状态：" + r.Value),
                    Bind("续期RTC Token", "IRtcEngine.RenewToken", () => new { token = Token })),
                Row(Bind("重挂引擎事件", "IRtcEngine.InitEventHandler", () => new { engineEventHandler = (object)null }),
                    Bind("查询SDK版本", "IRtcEngine.GetVersion", () => new { build = 0 }, r => state.Text = "版本：" + r.Value + " build=" + Out<int>(r, "build")),
                    Label("错误码"), diagnosticCode, Bind("解释错误码", "IRtcEngine.GetErrorDescription", () => new { code = (int)diagnosticCode.Value }, r => state.Text = Convert.ToString(r.Value))),
                Row(logPath, ActionButton("选择日志文件", () => { using var d = new SaveFileDialog { Filter = "日志|*.log" }; if (d.ShowDialog(this) == DialogResult.OK) logPath.Text = d.FileName; }),
                    Bind("设置SDK日志路径", "IRtcEngine.SetLogFile", () => new { filePath = Path.GetFullPath(logPath.Text) })),
                Row(logLevel, Bind("设置日志等级", "IRtcEngine.SetLogLevel", () => new { level = (LOG_LEVEL)logLevel.SelectedItem }),
                    Label("大小KiB"), logSize, Bind("设置旧版日志大小", "IRtcEngine.SetLogFileSize", () => new { fileSizeInKBytes = (uint)logSize.Value })),
                Row(parameterKey, parameterValue, Bind("应用业务高级参数", "IRtcEngine.SetParameters", () =>
                {
                    if (string.IsNullOrWhiteSpace(parameterKey.Text)) throw new InvalidOperationException("请输入业务已确认的参数名。");
                    object value = parameterValue.Text;
                    if (long.TryParse(parameterValue.Text, out var number)) value = number;
                    else if (bool.TryParse(parameterValue.Text, out var boolean)) value = boolean;
                    return new { parameters = JsonSerializer.Serialize(new System.Collections.Generic.Dictionary<string, object> { [parameterKey.Text] = value }) };
                })),
                Row(reportId, reportCategory, reportEvent, reportLabel, reportValue,
                    Bind("上报自定义诊断", "IRtcEngine.SendCustomReportMessage", () => new { id = reportId.Text, category = reportCategory.Text, @event = reportEvent.Text, label = reportLabel.Text, value = (int)reportValue.Value })));
        }
    }
}
