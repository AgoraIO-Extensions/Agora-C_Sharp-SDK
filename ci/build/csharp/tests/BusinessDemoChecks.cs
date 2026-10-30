using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Agora.Rtc;
using C_Sharp_API_Example;

internal static class BusinessDemoChecks
{
    private static int checks;
    private static void Check(bool value, string name)
    { if (!value) throw new InvalidOperationException(name); checks++; }
    private static void Reject(Action action, string name)
    { try { action(); } catch (ArgumentException) { checks++; return; } catch (JsonException) { checks++; return; } throw new InvalidOperationException(name); }
    private static void Main()
    {
        var operations = BusinessApiOperation.Create();
        Check(operations.Select(o => o.Api).Distinct().Count() >= 100, "business allowlist incomplete");
        Check(!operations.Any(o => o.Method.Name == "SetEnableSpeakerphone"), "mobile API leaked into Windows catalog");
        var connection = new RtcConnection("offline-test", 1001);
        foreach (var op in operations)
        {
            var text = BusinessApiJson.Template(op, connection, "$token");
            var args = BusinessApiJson.ReadArguments(op, text);
            Check(args.Length == op.Method.GetParameters().Length, "argument count " + op);
            if (op.Api == "IMusicContentCenter.Initialize")
                Check(op.Method.GetParameters()[0].ParameterType == typeof(MusicContentCenterConfiguration), "wrong Initialize receiver");
            if (op.Api == "IMediaPlayer.InitEventHandler")
                Check(op.Method.GetParameters()[0].ParameterType == typeof(IMediaPlayerSourceObserver), "wrong event receiver");
        }
        var media = JsonSerializer.Deserialize<ChannelMediaOptions>("{\"publishMicrophoneTrack\":false,\"token\":null,\"audioDelayMs\":15}", BusinessApiJson.Options);
        Check(media.publishMicrophoneTrack.HasValue() && !media.publishMicrophoneTrack.GetValue(), "explicit false lost");
        Check(media.token != null && !media.token.HasValue(), "null Optional must stay empty, not null reference");
        Check(media.audioDelayMs.HasValue() && media.audioDelayMs.GetValue() == 15, "Optional int lost");
        Reject(() => JsonSerializer.Deserialize<ChannelMediaOptions>("{\"publishMicrophoneTrak\":true}", BusinessApiJson.Options), "unknown SDK field accepted");
        var metadata = operations.First(o => o.Api == "IRtcEngineEx.SendAudioMetadataEx");
        string send = "{\"connection\":{\"channelId\":\"test\",\"localUid\":1001},\"metadata\":[0,255,128],\"length\":3}";
        var sent = BusinessApiJson.ReadArguments(metadata, send);
        Check(((byte[])sent[1]).SequenceEqual(new byte[] { 0, 255, 128 }), "binary payload changed");
        Reject(() => BusinessApiJson.ReadArguments(metadata, send.Replace("\"length\":3", "\"length\":4")), "oversized buffer accepted");
        Reject(() => BusinessApiJson.ReadArguments(metadata, send.Replace("\"length\":3", "\"length\":0")), "zero-length pointer accepted");
        Reject(() => BusinessApiJson.ReadArguments(metadata, send.Replace("[0,255,128]", "[]")), "empty buffer accepted");
        Reject(() => BusinessApiJson.ReadArguments(metadata, send.Replace("[0,255,128]", "null")), "null buffer replaced with sample bytes");
        var tooLong = new Dictionary<string, object> { ["connection"] = connection, ["metadata"] = new byte[256], ["length"] = 256 };
        Reject(() => BusinessApiJson.ReadArguments(metadata, JsonSerializer.Serialize(tooLong, BusinessApiJson.Options)), "256-byte metadata accepted");
        var good = new Dictionary<string, object> { ["connection"] = connection, ["metadata"] = new byte[255], ["length"] = 255 };
        Check(((byte[])BusinessApiJson.ReadArguments(metadata, JsonSerializer.Serialize(good, BusinessApiJson.Options))[1]).Length == 255, "255-byte metadata rejected");
        Reject(() => BusinessApiJson.ReadArguments(metadata, send.Replace("\"length\":3", "\"length\":3,\"length\":2")), "duplicate arguments accepted");
        var frame = (AudioFrame)BusinessApiJson.Default(typeof(AudioFrame));
        BusinessApiJson.ValidateFrame(frame); checks++;
        frame.RawBuffer = new byte[1]; Reject(() => BusinessApiJson.ValidateFrame(frame), "short PCM buffer accepted");
        frame = (AudioFrame)BusinessApiJson.Default(typeof(AudioFrame)); frame.buffer = new IntPtr(123);
        Reject(() => BusinessApiJson.ValidateFrame(frame), "arbitrary native pointer accepted");
        var callbacks = new List<string>();
        var events = new BusinessRtcEvents((name, value) => callbacks.Add(name + " " + BusinessApiJson.Result(value)));
        events.OnAudioMetadataReceived(connection, 2001, new byte[] { 0, 255, 128 }, 3);
        events.OnStreamMessage(connection, 2001, 1, new byte[] { 0, 255, 128 }, 3, 99);
        events.OnJoinChannelSuccess(connection, 1);
        events.OnLeaveChannel(connection, new RtcStats());
        events.OnTokenPrivilegeWillExpire(connection, "private-test-token");
        Check(callbacks[0].Contains("00FF80") && callbacks[1].Contains("00FF80"), "receive bytes not observable");
        Check(callbacks.Any(s => s.Contains("OnJoinChannelSuccess")), "join callback absent");
        Check(callbacks.Any(s => s.Contains("OnLeaveChannel")), "leave callback absent");
        Check(callbacks.All(s => !s.Contains("private-test-token")), "token leaked to callback log");
        Check(!BusinessApiJson.Result(new { token = "private-test-token", appId = "private-app" }).Contains("private-"), "credential fields not redacted");
        Check(!BusinessApiJson.Result(BusinessApiJson.DiagnosticInfo("{\"url\":\"https://example.invalid/song?token=private-url\",\"token\":\"private-value\"}")).Contains("private-"), "signed URL/token leaked");
        var lead = new BusinessLeadStart(7, 4, connection);
        Check(!lead.Joined(7, connection), "lead played before source ready");
        Check(!lead.Opened(7, 5, true, false), "wrong player advanced lead");
        Check(lead.Opened(7, 4, true, false), "source ready did not advance lead");
        Check(!lead.Joined(7, new RtcConnection("other", 1001)), "wrong channel started lead");
        Check(!lead.Joined(7, new RtcConnection("offline-test", 2002)), "wrong uid started lead");
        Check(lead.Joined(7, connection), "correct join did not start lead");
        Check(!lead.Joined(7, connection), "duplicate join replayed play");
        lead = new BusinessLeadStart(7, 4, connection); lead.Cancel();
        Check(!lead.Opened(7, 4, true, false) && !lead.Joined(7, connection), "cancelled lead advanced");
        lead = new BusinessLeadStart(7, 4, connection);
        Check(!lead.Opened(8, 4, true, false) && !lead.Joined(7, connection), "stale session advanced lead");
        lead = new BusinessLeadStart(7, 4, connection);
        Check(!lead.Opened(7, 4, false, true) && !lead.Joined(7, connection), "failed source advanced lead");
        Console.WriteLine($"PASS: {checks} offline checks; {operations.Count} typed overloads. No native SDK calls or network operations.");
    }
}
