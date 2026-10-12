using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Agora.Rtc;
using LitJson;

class Program
{
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
        const string json = "{\"trackId\":7,\"volumeInfo\":{\"channelCount\":2,\"levels\":[13,27,0,0,0,0,0,0]}}";
        payloadType.GetField("event", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(payload, "AudioTrackObserver_onAudioTrackVolumeIndication_9bd73f7");
        payloadType.GetField("data", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(payload, json);
        payloadType.GetField("data_size", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(payload, (uint)json.Length);
        var pointer = Marshal.AllocHGlobal(Marshal.SizeOf(payloadType));
        var observer = new Observer();
        try
        {
            Marshal.StructureToPtr(payload, pointer, false);
            setObserver.Invoke(null, new object[] { observer });
            dispatch.Invoke(null, new object[] { pointer });
            Check(observer.Calls == 1 && observer.TrackId == 7, "observer callback routing");
            Check(observer.Info.channelCount == 2 && observer.Info.levels.Length == 8 && observer.Info.levels[1] == 27, "volume channel array decoding");
            setObserver.Invoke(null, new object[] { null });
            dispatch.Invoke(null, new object[] { pointer });
            Check(observer.Calls == 1, "cleared observers must not receive callbacks");
        }
        finally
        {
            setObserver.Invoke(null, new object[] { null });
            Marshal.DestroyStructure(pointer, payloadType);
            Marshal.FreeHGlobal(pointer);
        }

        // Validate guards without loading a Native library or initializing a live RTC engine.
        var impl = (RtcEngineImpl)RuntimeHelpers.GetUninitializedObject(typeof(RtcEngineImpl));
        var fields = BindingFlags.Instance | BindingFlags.NonPublic;
        typeof(RtcEngineImpl).GetField("_disposed", fields).SetValue(impl, true);
        Check(impl.RegisterAudioTrackObserver(7, null) == -(int)ERROR_CODE_TYPE.ERR_INVALID_ARGUMENT, "null observer registration");
        var handleField = typeof(RtcEngineImpl).GetField("_audioTrackObserverHandle", fields);
        var handle = handleField.GetValue(impl);
        handleField.FieldType.GetField("handle", fields).SetValue(handle, new IntPtr(1));
        handleField.SetValue(impl, handle);
        typeof(RtcEngineImpl).GetField("_audioTrackObserverId", fields).SetValue(impl, (uint)7);
        typeof(RtcEngineImpl).GetField("_registeredAudioTrackObserver", fields).SetValue(impl, observer);
        Check(impl.RegisterAudioTrackObserver(8, new Observer()) == -(int)ERROR_CODE_TYPE.ERR_ALREADY_IN_USE, "duplicate observer registration");
        Check(impl.UnregisterAudioTrackObserver(8, observer) == -(int)ERROR_CODE_TYPE.ERR_INVALID_ARGUMENT, "wrong track unregistration");
        Check(impl.UnregisterAudioTrackObserver(7, new Observer()) == -(int)ERROR_CODE_TYPE.ERR_INVALID_ARGUMENT, "wrong observer unregistration");
        Console.WriteLine("RTC generation regressions passed: arrays, defaults, callback dispatch, clearing and registration guards.");
    }
}
