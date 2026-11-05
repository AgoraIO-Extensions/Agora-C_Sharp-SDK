using System;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    // Own one selected loopback track; legacy capture and explicit track capture are exclusive.
    internal sealed class BusinessLoopbackControl
    {
        private readonly Func<string, object, BusinessApiResult> call;
        internal uint? TrackId { get; private set; }
        internal bool Published { get; private set; }
        internal bool LegacyEnabled { get; private set; }
        internal BusinessLoopbackControl(Func<string, object, BusinessApiResult> call) { this.call = call; }
        internal void Reset() { TrackId = null; Published = false; LegacyEnabled = false; }

        internal void SetLegacy(bool enabled)
        {
            if (enabled) Destroy();
            call("IRtcEngine.EnableLoopbackRecording", new { enabled, deviceName = "" });
            LegacyEnabled = enabled;
        }

        internal uint Create(LoopbackAudioTrackConfig config)
        {
            if (config == null || config.excludedAppCount != (uint)(config.excludedAppNames?.Length ?? 0) ||
                config.excludedProcessCount != (uint)(config.excludedProcessIds?.Length ?? 0))
                throw new ArgumentException("排除项计数必须与数组长度一致。");
            Destroy();
            SetLegacy(false);
            uint id = Convert.ToUInt32(call("IRtcEngine.CreateLoopbackAudioTrack", new { config }).Value);
            if (id == uint.MaxValue) throw new InvalidOperationException("创建回环音轨失败。");
            TrackId = id;
            return id;
        }

        internal void Publish(bool broadcaster)
        {
            uint id = RequireTrack();
            if (!broadcaster) throw new InvalidOperationException("请先切换为主播，再发布回环音轨。");
            if (!Connected()) throw new InvalidOperationException("请先加入频道，再发布回环音轨。");
            Update(id, true);
            Published = true;
        }

        internal void Unpublish()
        {
            if (!Published) return;
            var state = (CONNECTION_STATE_TYPE)call("IRtcEngine.GetConnectionState", new { }).Value;
            if (state == CONNECTION_STATE_TYPE.CONNECTION_STATE_CONNECTED) Update(RequireTrack(), false);
            else if (state != CONNECTION_STATE_TYPE.CONNECTION_STATE_DISCONNECTED && state != CONNECTION_STATE_TYPE.CONNECTION_STATE_FAILED)
                throw new InvalidOperationException("频道连接正在变化，请稍后取消发布或退出频道。");
            Published = false;
        }

        internal void Destroy()
        {
            if (!TrackId.HasValue) return;
            Unpublish();
            call("IRtcEngine.DestroyLoopbackAudioTrack", new { trackId = TrackId.Value });
            TrackId = null;
        }

        internal void SetVolume(int volume)
        {
            if (volume < 0 || volume > 400) throw new ArgumentException("回环发布音量范围为0–400。");
            call("IRtcEngine.AdjustLoopbackAudioPublishVolume", new { trackId = RequireTrack(), volume });
        }

        private uint RequireTrack() => TrackId ?? throw new InvalidOperationException("请先创建回环音轨。");
        private bool Connected() => (CONNECTION_STATE_TYPE)call("IRtcEngine.GetConnectionState", new { }).Value == CONNECTION_STATE_TYPE.CONNECTION_STATE_CONNECTED;
        internal static ChannelMediaOptions Publication(uint id, bool publish)
        {
            var options = new ChannelMediaOptions();
            options.publishLoopbackAudioTrack.SetValue(publish);
            options.publishLoopbackAudioTrackIds.SetValue(new AudioTrackIdList(new[] { id }, 1));
            return options;
        }
        private void Update(uint id, bool publish) => call("IRtcEngine.UpdateChannelMediaOptions", new { options = Publication(id, publish) });
    }
}
