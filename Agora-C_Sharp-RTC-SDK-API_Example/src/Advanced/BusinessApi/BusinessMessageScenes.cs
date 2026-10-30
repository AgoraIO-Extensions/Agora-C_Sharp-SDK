using System;
using System.Text;
using System.Windows.Forms;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    internal sealed partial class BusinessApiView
    {
        private readonly ComboBox messageConnection = Choice("当前单频道", "连接A", "连接B");
        private readonly CheckBox ordered = new CheckBox { Text = "有序", Checked = true, AutoSize = true }, syncAudio = new CheckBox { Text = "与音频同步", AutoSize = true }, hexMessage = new CheckBox { Text = "十六进制字节", AutoSize = true };
        private readonly NumericUpDown streamId = Number(int.MaxValue);
        private readonly TextBox message = Input(500, "填写文字；勾选十六进制后可输入00 FF 80");
        private readonly RichTextBox received = new RichTextBox { ReadOnly = true, Width = 700, Height = 110, WordWrap = true };
        private byte[] MessageBytes() => hexMessage.Checked ? Convert.FromHexString(message.Text.Replace(" ", "")) : Encoding.UTF8.GetBytes(message.Text);
        private RtcConnection SelectedMessageConnection() => Connection(messageConnection.SelectedIndex == 2);
        private void CreateMessageStream()
        {
            var config = new DataStreamConfig { ordered = ordered.Checked, syncWithAudio = syncAudio.Checked };
            var result = messageConnection.SelectedIndex == 0
                ? Call("IRtcEngine.CreateDataStream", new { streamId = 0, config })
                : Call("IRtcEngineEx.CreateDataStreamEx", new { streamId = 0, config, connection = SelectedMessageConnection() });
            streamId.Value = Out<int>(result, "streamId");
        }
        private void SendMessage()
        {
            byte[] data = MessageBytes(); uint length = checked((uint)data.Length);
            if (messageConnection.SelectedIndex == 0) Call("IRtcEngine.SendStreamMessage", new { streamId = (int)streamId.Value, data, length });
            else Call("IRtcEngineEx.SendStreamMessageEx", new { streamId = (int)streamId.Value, data, length, connection = SelectedMessageConnection() });
        }
        private void SendMetadata()
        {
            byte[] metadata = MessageBytes(); ulong length = (ulong)metadata.Length;
            if (messageConnection.SelectedIndex == 0) Call("IRtcEngine.SendAudioMetadata", new { metadata, length });
            else Call("IRtcEngineEx.SendAudioMetadataEx", new { connection = SelectedMessageConnection(), metadata, length });
        }
        private Control MessageScene()
        {
            var create = ActionButton("创建数据流", CreateMessageStream);
            var send = ActionButton("发送数据流消息", SendMessage);
            var metadata = ActionButton("发送音频元数据", SendMetadata);
            bindings.Add(("IRtcEngine.CreateDataStream", create, null)); bindings.Add(("IRtcEngineEx.CreateDataStreamEx", create, null));
            bindings.Add(("IRtcEngine.SendStreamMessage", send, null)); bindings.Add(("IRtcEngineEx.SendStreamMessageEx", send, null));
            bindings.Add(("IRtcEngine.SendAudioMetadata", metadata, null)); bindings.Add(("IRtcEngineEx.SendAudioMetadataEx", metadata, null));
            return Page("两个进程使用不同UID并加入相同频道。直接输入消息发送，对端显示发送者、连接、字节数和内容。音频元数据属于技术预览，需实际音频发布和双端验证。",
                Row(messageConnection, ordered, syncAudio, create, Label("流ID"), streamId),
                Row(message, hexMessage, ActionButton("填测试消息", () => { hexMessage.Checked = false; message.Text = "业务测试-" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(); })),
                Row(send, metadata, ActionButton("填播放器进度消息", () =>
                {
                    long position = Out<long>(Call("IMediaPlayer.GetPlayPosition", new { pos = 0L }), "pos");
                    var time = Call("IRtcEngine.GetNtpWallTimeInMs", new { }).Value;
                    hexMessage.Checked = false; message.Text = $"player={PlayerId};positionMs={position};ntpMs={time}";
                })),
                Label("对端接收内容（数据流/音频元数据）"), received,
                Label("音频元数据1～255字节；长度按实际编码字节计算。发送返回0不等于对端收到，请核对接收区及回调日志。"));
        }
    }
}
