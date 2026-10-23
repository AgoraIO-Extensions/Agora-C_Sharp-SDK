using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Agora.Rtm;
using Internal = Agora.Rtm.Internal;

internal static class RtmReleaseRegression
{
    static void Check(bool value, string message)
    {
        if (!value) throw new Exception(message);
    }

    static void Callback(ulong requestId, string status, int error)
    {
        Event(Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONGETUSERONLINESTATUSRESULT,
              "{\"requestId\":" + requestId + ",\"status\":" + status + ",\"errorCode\":" + error + "}");
    }

    static void Event(string name, string json)
    {
        var payload = new Internal.IrisCRtmEventParam {
            @event = name,
            data = json
        };
        var ptr = Marshal.AllocHGlobal(Marshal.SizeOf(payload));
        try {
            Marshal.StructureToPtr(payload, ptr, false);
            Internal.RtmEventHandlerNative.OnEvent(ptr);
        } finally {
            Marshal.DestroyStructure<Internal.IrisCRtmEventParam>(ptr);
            Marshal.FreeHGlobal(ptr);
        }
    }

    static void Main()
    {
        var config = new RtmConfig { parameters = "{\"test\":true}", reconnectTimeout = 30, ispPolicyEnabled = true };
        var mapped = new Internal.RtmConfig(config, null);
        var json = Agora.Rtm.AgoraJson.ToJson(mapped);
        Check(mapped.parameters == config.parameters && mapped.reconnectTimeout == 30 && mapped.ispPolicyEnabled,
              "Native config forwarding lost 2.3.1 fields");
        Check(json.Contains("reconnectTimeout") && json.Contains("parameters"), "Config JSON omitted new fields");
        Check(new Internal.PresenceEvent { totalOccupancy = 123 }.GeneratePresenceEvent().totalOccupancy == 123,
              "Presence conversion lost totalOccupancy");

        // Test public Task correlation through the actual JSON callback decoder,
        // without constructing a live SDK or contacting RTM services.
        Tools.ErrorCode2Reason[0] = "OK";
        Tools.ErrorCode2Reason[-7] = "test failure";
        var client = (RtmClient)RuntimeHelpers.GetUninitializedObject(typeof(RtmClient));
        var handler = new RtmEventHandler(client);
        var backend = new PresenceBackend();
        var facade = new RtmPresence(backend, handler, null);
        Internal.RtmEventHandlerNative.SetEventHandler(handler);
        TokenEvent tokenEvent = null;
        client.OnTokenEvent += e => tokenEvent = e;
        Event(Internal.AgoraApiType.FUNC_RTMEVENTHANDLER_ONTOKENEVENT,
              "{\"event\":{\"eventType\":2,\"reason\":\"revoked\",\"timestamp\":123,\"affectedResources\":{\"messageChannels\":{\"channels\":[\"channel-a\"],\"count\":1}}}}");
        Check(tokenEvent != null && tokenEvent.eventType == RTM_TOKEN_EVENT_TYPE.READ_PERMISSION_REVOKED
              && tokenEvent.affectedResources.messageChannels.channels[0] == "channel-a",
              "Token event dispatch lost affected resources");
        foreach (var online in new[] { true, false }) {
            var task = facade.GetUserOnlineStatusAsync("alice");
            Check(!task.IsCompleted, "Query completed before callback");
            Callback(backend.LastRequest, "{\"userId\":\"alice\",\"online\":" + online.ToString().ToLowerInvariant() + "}", 0);
            Check(task.IsCompleted && !task.Result.Status.Error && task.Result.Response.Status.online == online
                  && task.Result.Response.Status.userId == "alice", "Online/offline result correlation failed");
        }
        var failure = facade.GetUserOnlineStatusAsync("alice");
        Callback(backend.LastRequest, "null", -7);
        Check(failure.IsCompleted && failure.Result.Status.Error && failure.Result.Response.Status == null,
              "Failed callback must preserve null status");
        backend.Error = -7;
        var immediate = facade.GetUserOnlineStatusAsync("alice");
        Check(immediate.IsCompleted && immediate.Result.Status.Error && immediate.Result.Response == null,
              "Immediate native failure must not wait for a callback");
        Internal.RtmEventHandlerNative.SetEventHandler(null);
        var nativePath = Environment.GetEnvironmentVariable("AGORA_RTM_NATIVE_SMOKE");
        if (!string.IsNullOrEmpty(nativePath)) {
            var library = NativeLibrary.Load(nativePath);
            NativeLibrary.SetDllImportResolver(typeof(Internal.AgoraRtmNative).Assembly,
                (name, assembly, searchPath) => name == "AgoraRtmWrapper" ? library : IntPtr.Zero);
            var version = Marshal.PtrToStringAnsi(Internal.AgoraRtmNative.GetIrisRtmVersion());
            Check(!string.IsNullOrEmpty(version), "Actual Native SDK version was empty");
            var engine = Internal.AgoraRtmNative.CreateIrisRtmEngine(IntPtr.Zero);
            Check(engine != IntPtr.Zero, "Actual Iris engine creation failed");
            Internal.AgoraRtmNative.DestroyIrisRtmEngine(engine);
            Console.WriteLine("Actual Iris load/version/create/destroy smoke passed: " + version);
        }
        Console.WriteLine("RTM config, presence conversion and online/offline/error callback regressions passed");
    }

    sealed class PresenceBackend : Internal.IRtmPresence
    {
        public ulong LastRequest;
        public int Error;
        public override int GetUserOnlineStatus(string userId, ref ulong id) { id = ++LastRequest; return Error; }
        public override int WhoNow(string c, RTM_CHANNEL_TYPE t, PresenceOptions o, ref ulong id) => throw new NotSupportedException();
        public override int WhereNow(string u, ref ulong id) => throw new NotSupportedException();
        public override int GetOnlineUsers(string c, RTM_CHANNEL_TYPE t, GetOnlineUsersOptions o, ref ulong id) => throw new NotSupportedException();
        public override int GetUserChannels(string u, ref ulong id) => throw new NotSupportedException();
        public override int SetState(string c, RTM_CHANNEL_TYPE t, StateItem[] s, int n, ref ulong id) => throw new NotSupportedException();
        public override int RemoveState(string c, RTM_CHANNEL_TYPE t, string[] s, int n, ref ulong id) => throw new NotSupportedException();
        public override int GetState(string c, RTM_CHANNEL_TYPE t, string u, ref ulong id) => throw new NotSupportedException();
    }
}
