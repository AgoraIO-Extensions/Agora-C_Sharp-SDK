using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Agora.Rtc;
using C_Sharp_API_Example;

internal static class LoopbackChecks
{
    internal static void Run(Action<bool, string> check)
    {
        var calls = new List<string>();
        var updates = new List<ChannelMediaOptions>();
        string fail = null;
        uint next = 42;
        var state = CONNECTION_STATE_TYPE.CONNECTION_STATE_CONNECTED;
        LoopbackAudioTrackConfig actual = null;
        var flow = new BusinessLoopbackControl((api, args) =>
        {
            calls.Add(api);
            if (api == fail) throw new InvalidOperationException("native rejected");
            if (api.EndsWith("GetConnectionState")) return new BusinessApiResult(state);
            var json = JsonSerializer.SerializeToElement(args, BusinessApiJson.Options);
            if (api.EndsWith("CreateLoopbackAudioTrack"))
            {
                actual = JsonSerializer.Deserialize<LoopbackAudioTrackConfig>(json.GetProperty("config").GetRawText(), BusinessApiJson.Options);
                return new BusinessApiResult(next++);
            }
            if (api.EndsWith("UpdateChannelMediaOptions")) updates.Add(JsonSerializer.Deserialize<ChannelMediaOptions>(json.GetProperty("options").GetRawText(), BusinessApiJson.Options));
            return new BusinessApiResult(0);
        });
        void Rejected(Action action, string label)
        {
            try { action(); } catch (ArgumentException) { check(true, label); return; }
            catch (InvalidOperationException) { check(true, label); return; }
            throw new Exception(label);
        }
        var config = new LoopbackAudioTrackConfig { excludedProcessIds = new uint[] { 12345 }, excludedProcessCount = 1 };
        flow.SetLegacy(true); check(flow.LegacyEnabled, "legacy enable state");
        calls.Clear(); uint id = flow.Create(config);
        check(calls.SequenceEqual(new[] { "IRtcEngine.EnableLoopbackRecording", "IRtcEngine.CreateLoopbackAudioTrack" }), "new track must stop legacy capture first");
        check(!flow.LegacyEnabled && !flow.Published && flow.TrackId == id, "create is not publication");
        check(actual.excludedProcessCount == 1 && actual.excludedProcessIds.Single() == 12345, "exclude PID/count changed");
        state = CONNECTION_STATE_TYPE.CONNECTION_STATE_DISCONNECTED;
        Rejected(() => flow.Publish(true), "publish without channel accepted");
        check(updates.Count == 0, "prejoin publish reached SDK");
        state = CONNECTION_STATE_TYPE.CONNECTION_STATE_CONNECTED;
        Rejected(() => flow.Publish(false), "audience published loopback");
        flow.Publish(true);
        check(flow.Published && updates.Last().publishLoopbackAudioTrack.GetValue(), "explicit publication missing");
        var ids = updates.Last().publishLoopbackAudioTrackIds.GetValue();
        check(ids.trackCount == 1 && ids.trackIds.Single() == id, "publication used wrong track list");
        check(!updates.Last().publishMicrophoneTrack.HasValue() && !updates.Last().publishMediaPlayerAudioTrack.HasValue(), "loopback update changed other publications");
        fail = "IRtcEngine.UpdateChannelMediaOptions"; calls.Clear();
        Rejected(flow.Destroy, "unpublish failure ignored");
        check(flow.Published && flow.TrackId == id && !calls.Contains("IRtcEngine.DestroyLoopbackAudioTrack"), "failed unpublish destroyed live track");
        fail = null; state = CONNECTION_STATE_TYPE.CONNECTION_STATE_RECONNECTING; calls.Clear();
        Rejected(flow.Destroy, "reconnecting publication treated as gone");
        check(flow.Published && flow.TrackId == id && !calls.Contains("IRtcEngine.DestroyLoopbackAudioTrack"), "transient connection lost track ownership");
        state = CONNECTION_STATE_TYPE.CONNECTION_STATE_CONNECTED; calls.Clear(); flow.SetLegacy(true);
        check(calls.SequenceEqual(new[] { "IRtcEngine.GetConnectionState", "IRtcEngine.UpdateChannelMediaOptions", "IRtcEngine.DestroyLoopbackAudioTrack", "IRtcEngine.EnableLoopbackRecording" }), "switch to legacy must unpublish/destroy before capture");
        check(!updates.Last().publishLoopbackAudioTrack.GetValue() && updates.Last().publishLoopbackAudioTrackIds.GetValue().trackIds.Single() == id, "unpublish did not target old track");
        check(flow.LegacyEnabled && !flow.TrackId.HasValue, "legacy and new track remained active together");
        calls.Clear(); fail = "IRtcEngine.EnableLoopbackRecording";
        Rejected(() => flow.Create(config), "legacy disable failure ignored");
        check(flow.LegacyEnabled && !calls.Contains("IRtcEngine.CreateLoopbackAudioTrack"), "created new track before legacy capture stopped");
        fail = null; flow.Create(config); flow.Publish(true);
        fail = "IRtcEngine.DestroyLoopbackAudioTrack";
        Rejected(() => flow.SetLegacy(true), "destroy failure ignored during legacy switch");
        check(flow.TrackId.HasValue && !flow.Published && !flow.LegacyEnabled, "failed destroy lost retry state or enabled legacy");
        fail = null; calls.Clear(); flow.Destroy();
        check(calls.SequenceEqual(new[] { "IRtcEngine.DestroyLoopbackAudioTrack" }), "retry destroyed/unpublished incorrect resources");
        flow.Create(config); flow.Publish(true); state = CONNECTION_STATE_TYPE.CONNECTION_STATE_DISCONNECTED; calls.Clear(); flow.Destroy();
        check(calls.SequenceEqual(new[] { "IRtcEngine.GetConnectionState", "IRtcEngine.DestroyLoopbackAudioTrack" }), "post-leave cleanup submitted stale publication");
        calls.Clear(); Rejected(() => flow.Create(new LoopbackAudioTrackConfig { excludedProcessCount = 1 }), "mismatched exclusion count accepted");
        check(calls.Count == 0, "invalid config changed live capture");
        flow.Reset(); Rejected(() => flow.SetVolume(100), "volume used missing track");
        check(!flow.Published && !flow.LegacyEnabled && !flow.TrackId.HasValue, "release reset kept stale loopback state");
    }
}
