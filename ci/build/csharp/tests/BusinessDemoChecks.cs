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
        string sceneDirectory = System.IO.Path.Combine(Environment.CurrentDirectory, "Agora-C_Sharp-RTC-SDK-API_Example", "src", "Advanced", "BusinessApi");
        foreach (var file in System.IO.Directory.GetFiles(sceneDirectory, "Business*Scenes.cs"))
        {
            foreach (System.Text.RegularExpressions.Match match in System.Text.RegularExpressions.Regex.Matches(
                System.IO.File.ReadAllText(file), "\"((?:IRtcEngine(?:Ex)?|IAudioDeviceManager|IMediaPlayer|IMusicPlayer|IMusicContentCenter)\\.\\w+)\""))
                Check(operations.Any(o => o.Api == match.Groups[1].Value), "unbound scene API: " + match.Groups[1].Value);
        }
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
        // QA regression: joined business-b/1100122 must relay to 123, not 123 -> 123.
        var relay = new BusinessRelayRequest(new RtcConnection("business-b", 1100122), "source-relay", "123", 7777, "target-relay");
        Check(relay.Connection.channelId == "business-b" && relay.Connection.localUid == 1100122, "relay lost selected Ex connection");
        Check(relay.Configuration.srcInfo.channelName == "business-b" && relay.Configuration.srcInfo.uid == 0, "relay reused join UID");
        Check(relay.Configuration.srcInfo.token == "source-relay" && relay.Configuration.destInfos[0].token == "target-relay", "relay credentials mixed");
        var startRelay = operations.Single(o => o.Api == "IRtcEngineEx.StartOrUpdateChannelMediaRelayEx");
        var relayArgs = BusinessApiJson.ReadArguments(startRelay, JsonSerializer.Serialize(relay.Arguments, BusinessApiJson.Options));
        Check(((RtcConnection)relayArgs[1]).localUid == 1100122, "Ex relay serialized wrong source");
        Check(operations.Any(o => o.Api == "IRtcEngineEx.StopChannelMediaRelayEx"), "Ex relay stop missing");
        Reject(() => new BusinessRelayRequest(connection, "", connection.channelId, 7777, ""), "same-channel relay accepted");
        Reject(() => new BusinessRelayRequest(connection, "", " ", 7777, ""), "empty target accepted");
        var source = new RtcConnection("source-a", 1001);
        relay = new BusinessRelayRequest(source, "", "target-b", 7777, "");
        source.channelId = "edited"; source.localUid = 999;
        Check(relay.Connection.channelId == "source-a" && relay.Connection.localUid == 1001, "editing source mutated captured relay connection");
        Check(BusinessLogSettings.Levels[0] == LOG_LEVEL.LOG_LEVEL_INFO, "default log level must be INFO");
        Check(!BusinessLogSettings.Levels.Contains(LOG_LEVEL.LOG_LEVEL_DEBUG) && !BusinessLogSettings.Levels.Contains(LOG_LEVEL.LOG_LEVEL_API_CALL), "internal log levels exposed");
        var logConfig = BusinessLogSettings.Create("", 2048, LOG_LEVEL.LOG_LEVEL_INFO);
        Check(logConfig.filePath == "" && logConfig.level == LOG_LEVEL.LOG_LEVEL_INFO, "SDK default log path lost");
        var logPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "qa-sdk.log");
        Check(BusinessLogSettings.Create(logPath, 5000, LOG_LEVEL.LOG_LEVEL_WARN).filePath == logPath, "explicit log path changed");
        Reject(() => BusinessLogSettings.Create(logPath, 2048, LOG_LEVEL.LOG_LEVEL_DEBUG), "QA filter-zero regression accepted");
        Reject(() => BusinessLogSettings.Create("relative.log", 2048, LOG_LEVEL.LOG_LEVEL_INFO), "relative log path accepted");
        Reject(() => BusinessLogSettings.Create(System.IO.Path.GetTempPath(), 2048, LOG_LEVEL.LOG_LEVEL_INFO), "directory used as log file");
        Reject(() => BusinessLogSettings.Create("", 1, LOG_LEVEL.LOG_LEVEL_INFO), "invalid log size accepted");
        var chinese = System.Text.Encoding.UTF8.GetBytes("回魂中文\n引号\"");
        events.OnAudioMetadataReceived(connection, 2001, chinese, (ulong)chinese.Length);
        Check(callbacks.Last().Contains("回魂中文") && !callbacks.Last().Contains("\\u56DE"), "Chinese callback display escaped");
        Check(callbacks.Last().Contains(Convert.ToHexString(chinese)), "display fix changed payload bytes");
        string protectedDisplay = BusinessApiJson.Result(new { text = "中文<script>\n\"", token = "secret-value", appId = "secret-app" });
        using (var displayDoc = JsonDocument.Parse(protectedDisplay))
            Check(displayDoc.RootElement.GetProperty("text").GetString() == "中文<script>\n\"", "display escaping changed text");
        Check(!protectedDisplay.Contains("<script>") && !protectedDisplay.Contains("secret-"), "display fix weakened redaction/HTML escaping");
        var calls = new List<string>();
        string activeRecording = "mic-current", activePlayback = "speaker-current";
        bool failSet = false;
        CONNECTION_STATE_TYPE fakeState = CONNECTION_STATE_TYPE.CONNECTION_STATE_CONNECTED;
        var audio = new BusinessAudioControl((api, args) =>
        {
            calls.Add(api);
            var input = JsonSerializer.SerializeToElement(args, BusinessApiJson.Options);
            if (failSet && api.EndsWith("DeviceVolume") && api.Contains(".Set")) throw new InvalidOperationException("native failure");
            if (api == "IRtcEngine.GetConnectionState") return new BusinessApiResult(fakeState);
            if (api == "IAudioDeviceManager.SetRecordingDevice") activeRecording = input.GetProperty("deviceId").GetString();
            if (api == "IAudioDeviceManager.SetPlaybackDevice") activePlayback = input.GetProperty("deviceId").GetString();
            if (api == "IAudioDeviceManager.GetRecordingDevice") return new BusinessApiResult(0, new Dictionary<string, object> { ["deviceId"] = activeRecording });
            if (api == "IAudioDeviceManager.GetPlaybackDevice") return new BusinessApiResult(0, new Dictionary<string, object> { ["deviceId"] = activePlayback });
            if (api.EndsWith("DeviceVolume") && api.Contains(".Get")) return new BusinessApiResult(0, new Dictionary<string, object> { ["volume"] = 66 });
            return new BusinessApiResult(0);
        });
        var roleOptions = new ChannelMediaOptions(); roleOptions.clientRoleType.SetValue(CLIENT_ROLE_TYPE.CLIENT_ROLE_AUDIENCE); roleOptions.publishMicrophoneTrack.SetValue(false);
        audio.ApplyRole(CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING, CLIENT_ROLE_TYPE.CLIENT_ROLE_AUDIENCE, roleOptions);
        Check(calls.SequenceEqual(new[] { "IRtcEngine.GetConnectionState", "IRtcEngine.SetClientRole", "IRtcEngine.UpdateChannelMediaOptions" }), "in-channel role did not update SDK and publish options");
        calls.Clear(); fakeState = CONNECTION_STATE_TYPE.CONNECTION_STATE_DISCONNECTED;
        audio.ApplyRole(CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING, CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER, new ChannelMediaOptions());
        Check(!calls.Contains("IRtcEngine.UpdateChannelMediaOptions"), "pre-join role attempted live media update");
        calls.Clear();
        var measured = audio.SetVolume(true, "mic-selected", 67);
        Check(activeRecording == "mic-selected" && measured.Volume == 66 && measured.DeviceId == "mic-selected", "volume must target selected device and return actual readback");
        Check(calls.SequenceEqual(new[] { "IAudioDeviceManager.SetRecordingDevice", "IAudioDeviceManager.SetRecordingDeviceVolume", "IAudioDeviceManager.GetRecordingDevice", "IAudioDeviceManager.GetRecordingDeviceVolume" }), "recording volume call sequence wrong");
        calls.Clear(); audio.SetVolume(false, "speaker-selected", 67);
        Check(activePlayback == "speaker-selected" && !calls.Any(c => c.Contains("Recording")), "playback control used microphone API");
        calls.Clear(); failSet = true;
        try { audio.SetVolume(true, "mic-selected", 67); throw new Exception("native failure swallowed"); } catch (InvalidOperationException) { checks++; }
        Check(!calls.Any(c => c.Contains(".Get")), "readback executed after rejected setter");
        failSet = false; calls.Clear();
        try { audio.SetEarVolume(100); throw new Exception("ear prerequisite ignored"); } catch (InvalidOperationException) { checks++; }
        Check(calls.Count == 0, "ear volume called before enable");
        audio.ApplyEar(true, 400);
        Check(calls.SequenceEqual(new[] { "IRtcEngine.EnableLocalAudio", "IRtcEngine.EnableInEarMonitoring", "IRtcEngine.SetInEarMonitoringVolume" }), "ear enable/capture/volume sequence wrong");
        Check(audio.EarRequested == true, "ear request state absent");
        Reject(() => audio.SetEarVolume(401), "ear upper limit accepted");
        Reject(() => audio.SetVolume(true, "mic", 256), "device volume upper limit accepted");
        audio.Reset(); Check(audio.EarRequested == null, "ear request state survived release");
        events.OnClientRoleChanged(connection, CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER, CLIENT_ROLE_TYPE.CLIENT_ROLE_AUDIENCE, new ClientRoleOptions());
        Check(callbacks.Last().Contains("OnClientRoleChanged"), "role callback not observable");
        Console.WriteLine($"PASS: {checks} offline checks; {operations.Count} typed overloads. No native SDK calls or network operations.");
    }
}
