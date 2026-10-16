using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Agora.Rtc;
using LitJson;

class Program
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate int IntGetter();
    class Observer : IAudioTrackObserver
    {
        public int Calls;
        public uint TrackId;
        public AudioTrackVolumeInfo Info;
        public override void OnAudioTrackVolumeIndication(uint trackId, AudioTrackVolumeInfo volumeInfo)
        {
            Calls++;
            TrackId = trackId;
            Info = volumeInfo;
        }
    }

    static void Check(bool condition, string message)
    {
        if (!condition) throw new Exception(message);
    }

    static void Main()
    {
        var shimPath = Environment.GetEnvironmentVariable("AGORA_TEST_SHIM_PATH");
        Check(!string.IsNullOrEmpty(shimPath), "set AGORA_TEST_SHIM_PATH to the test-only Iris transport");
        var shim = NativeLibrary.Load(shimPath);
        NativeLibrary.SetDllImportResolver(typeof(IRtcEngine).Assembly, (name, assembly, path) => shim);
        var legacyFrame = new ExternalVideoFrame(default(VIDEO_BUFFER_TYPE), default(VIDEO_PIXEL_FORMAT), default(byte[]), default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(long), default(IntPtr), default(EGL_CONTEXT_TYPE), default(int), default(long), default(float[]), default(byte[]), default(int), default(byte[]), default(bool), default(ALPHA_STITCH_MODE), default(IntPtr), default(int), default(Hdr10MetadataInfo), default(ColorSpace));
        var legacyOptions = new ChannelMediaOptions(default(Optional<bool>), default(Optional<bool>), default(Optional<bool>), default(Optional<bool>), default(Optional<bool>), default(Optional<bool>), default(Optional<bool>), default(Optional<bool>), default(Optional<bool>), default(Optional<bool>), default(Optional<bool>), default(Optional<bool>), default(Optional<int>), default(Optional<bool>), default(Optional<bool>), default(Optional<bool>), default(Optional<bool>), default(Optional<bool>), default(Optional<bool>), default(Optional<bool>), default(Optional<bool>), default(Optional<bool>), default(Optional<bool>), default(Optional<int>), default(Optional<CLIENT_ROLE_TYPE>), default(Optional<AUDIENCE_LATENCY_LEVEL_TYPE>), default(Optional<VIDEO_STREAM_TYPE>), default(Optional<CHANNEL_PROFILE_TYPE>), default(Optional<int>), default(Optional<int>), default(Optional<string>), default(Optional<bool>), default(Optional<bool>), default(Optional<bool>), default(Optional<uint>), default(Optional<bool>), default(Optional<string>), default(Optional<bool>), default(Optional<MultipathMode>), default(Optional<MultipathMode>), default(Optional<MultipathType>));
        Check(legacyFrame.pixelBuffer == IntPtr.Zero, "legacy frame constructor pointer default");
        Check(!legacyOptions.publishLoopbackAudioTrack.HasValue() && !legacyOptions.publishLoopbackAudioTrackIds.HasValue() && !legacyOptions.customUserInfo.HasValue(), "legacy media constructor optional defaults");
        var tracks = new AudioTrackIdList(new uint[] { 7, 19 }, 2);
        var encoded = JsonMapper.ToJson(tracks);
        var decoded = JsonMapper.ToObject<AudioTrackIdList>(encoded);
        Check(decoded.trackCount == 2 && decoded.trackIds[1] == 19, "track ID array round-trip");
        Check(new ExternalVideoFrame().pixelBuffer == IntPtr.Zero, "pixel buffer pointer default");
        Check(new LoopbackAudioTrackConfig().processId == uint.MaxValue, "unsigned process sentinel");

        var assembly = typeof(IRtcEngine).Assembly;
        var bridge = assembly.GetType("Agora.Rtc.AudioTrackObserverNative", true);
        var setObserver = bridge.GetMethod("SetAudioTrackObserver", BindingFlags.Static | BindingFlags.NonPublic);
        var dispatch = bridge.GetMethod("OnEvent", BindingFlags.Static | BindingFlags.NonPublic);
        var payloadType = assembly.GetType("Agora.Rtc.IrisRtcCEventParam", true);
        var payload = Activator.CreateInstance(payloadType);
        const string json = "{\"observerId\":17,\"trackId\":7,\"volumeInfo\":{\"channelCount\":2,\"levels\":[13,27,0,0,0,0,0,0]}}";
        payloadType.GetField("event", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(payload, "AudioTrackObserver_onAudioTrackVolumeIndication_9bd73f7");
        payloadType.GetField("data", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(payload, json);
        payloadType.GetField("data_size", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(payload, (uint)json.Length);
        var pointer = Marshal.AllocHGlobal(Marshal.SizeOf(payloadType));
        var observer = new Observer();
        var secondObserver = new Observer();
        try
        {
            Marshal.StructureToPtr(payload, pointer, false);
            setObserver.Invoke(null, new object[] { new IntPtr(17), observer });
            setObserver.Invoke(null, new object[] { new IntPtr(18), secondObserver });
            dispatch.Invoke(null, new object[] { pointer });
            Check(observer.Calls == 1 && observer.TrackId == 7, "observer callback routing");
            Check(observer.Info.channelCount == 2 && observer.Info.levels.Length == 8 && observer.Info.levels[1] == 27, "volume channel array decoding");
            Check(secondObserver.Calls == 0, "observer identity prevents cross-delivery on the same track");
            payloadType.GetField("data", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(payload, json.Replace("\"observerId\":17", "\"observerId\":18"));
            Marshal.StructureToPtr(payload, pointer, true);
            dispatch.Invoke(null, new object[] { pointer });
            Check(secondObserver.Calls == 1 && observer.Calls == 1, "independent observer callback routing");
            payloadType.GetField("data", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(payload, json);
            Marshal.StructureToPtr(payload, pointer, true);
            setObserver.Invoke(null, new object[] { new IntPtr(17), null });
            dispatch.Invoke(null, new object[] { pointer });
            Check(observer.Calls == 1, "cleared observers must not receive callbacks");
        }
        finally
        {
            setObserver.Invoke(null, new object[] { new IntPtr(17), null });
            setObserver.Invoke(null, new object[] { new IntPtr(18), null });
            Marshal.DestroyStructure(pointer, payloadType);
            Marshal.FreeHGlobal(pointer);
        }

        // Validate guards without loading a Native library or initializing a live RTC engine.
        var impl = (RtcEngineImpl)RuntimeHelpers.GetUninitializedObject(typeof(RtcEngineImpl));
        var fields = BindingFlags.Instance | BindingFlags.NonPublic;
        typeof(RtcEngineImpl).GetField("_disposed", fields).SetValue(impl, true);
        Check(impl.RegisterAudioTrackObserver(7, null) == -(int)ERROR_CODE_TYPE.ERR_INVALID_ARGUMENT, "null observer registration");
        var registrations = typeof(RtcEngineImpl).GetField("_audioTrackRegistrations", fields);
        registrations.SetValue(impl, Activator.CreateInstance(registrations.FieldType));
        typeof(RtcEngineImpl).GetField("_param", fields).SetValue(impl, new Dictionary<string, object>());
        var apiField = typeof(RtcEngineImpl).GetField("_apiParam", fields);
        var api = Activator.CreateInstance(apiField.FieldType);
        apiField.FieldType.GetMethod("AllocResult", fields).Invoke(api, null);
        apiField.SetValue(impl, api);
        Check(impl.RegisterAudioTrackObserver(7, observer) == 0, "first track registration");
        Check(impl.RegisterAudioTrackObserver(8, observer) == 0, "same observer on two tracks");
        Check(impl.RegisterAudioTrackObserver(7, observer) == -(int)ERROR_CODE_TYPE.ERR_ALREADY_IN_USE, "duplicate same track registration");
        Check(impl.RegisterAudioTrackObserver(99, observer) == -2, "failed additional registration preserves existing tracks");
        Check(impl.RegisterAudioTrackObserver(99, new Observer()) == -2, "failed first registration frees its handle");
        Check(impl.UnregisterAudioTrackObserver(9, observer) == -(int)ERROR_CODE_TYPE.ERR_INVALID_ARGUMENT, "wrong track unregistration");
        Check(impl.UnregisterAudioTrackObserver(7, new Observer()) == -(int)ERROR_CODE_TYPE.ERR_INVALID_ARGUMENT, "wrong observer unregistration");
        Check(impl.UnregisterAudioTrackObserver(7, observer) == 0, "unregister first track only");
        Check(impl.RegisterAudioTrackObserver(8, observer) == -(int)ERROR_CODE_TYPE.ERR_ALREADY_IN_USE, "second track remains registered");
        var other = new Observer();
        Check(impl.RegisterAudioTrackObserver(8, other) == 0, "different observer on same track");
        Check(impl.UnregisterAudioTrackObserver(8, observer) == 0, "unregister last track for first observer");
        Check(impl.UnregisterAudioTrackObserver(8, other) == 0, "unregister independent observer");
        api = apiField.GetValue(impl);
        apiField.FieldType.GetMethod("FreeResult", fields).Invoke(api, null);
        var handles = Marshal.GetDelegateForFunctionPointer<IntGetter>(NativeLibrary.GetExport(shim, "TestLiveHandles"));
        Check(handles() == 0, "all callback handles released");
        Console.WriteLine("RTC generation regressions passed: arrays, defaults, callback dispatch, clearing and registration guards.");
    }
}
