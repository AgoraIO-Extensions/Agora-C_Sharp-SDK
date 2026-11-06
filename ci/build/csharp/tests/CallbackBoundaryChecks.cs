using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Agora.Rtc;

internal static class CallbackBoundaryChecks
{
    private static readonly Assembly Sdk = typeof(IRtcEngine).Assembly;
    private const BindingFlags Flags = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;
    [StructLayout(LayoutKind.Sequential)]
    private struct Header
    {
        public IntPtr Name, Data;
        public uint Size;
        public IntPtr Result, Buffer, Length;
        public uint Count;
    }
    private sealed class Packet : IDisposable
    {
        private const int Capacity = 1024;
        private readonly IntPtr name, data, result;
        internal readonly IntPtr Pointer;
        internal Packet(string eventName, byte[] bytes = null)
        {
            name = Marshal.StringToHGlobalAnsi(eventName);
            data = bytes == null ? IntPtr.Zero : Marshal.AllocHGlobal(bytes.Length + 1);
            if (bytes != null) { Marshal.Copy(bytes, 0, data, bytes.Length); Marshal.WriteByte(data, bytes.Length, 0); }
            result = Marshal.AllocHGlobal(Capacity + 16);
            Marshal.Copy(new byte[Capacity], 0, result, Capacity);
            for (int i = Capacity; i < Capacity + 16; i++) Marshal.WriteByte(result, i, 0x7e);
            Pointer = Marshal.AllocHGlobal(Marshal.SizeOf<Header>());
            Marshal.StructureToPtr(new Header { Name = name, Data = data, Size = (uint)(bytes?.Length ?? 0), Result = result }, Pointer, false);
        }
        internal string Result
        {
            get
            {
                int count = 0; while (count < Capacity && Marshal.ReadByte(result, count) != 0) count++;
                if (count == Capacity) throw new Exception("Result was not NUL-terminated");
                var bytes = new byte[count]; Marshal.Copy(result, bytes, 0, count); return Encoding.UTF8.GetString(bytes);
            }
        }
        internal void Seed() { for (int i = 0; i < Capacity; i++) Marshal.WriteByte(result, i, 0x5a); }
        internal bool Untouched => Marshal.ReadByte(result) == 0x5a;
        internal bool GuardIntact => Enumerable.Range(Capacity, 16).All(i => Marshal.ReadByte(result, i) == 0x7e);
        public void Dispose() { Marshal.FreeHGlobal(Pointer); Marshal.FreeHGlobal(result); if (data != IntPtr.Zero) Marshal.FreeHGlobal(data); Marshal.FreeHGlobal(name); }
    }
    private static Type Bridge(string name) => Sdk.GetType("Agora.Rtc." + name, true);
    private static void Invoke(string type, string method, params object[] args) => Bridge(type).GetMethod(method, Flags).Invoke(null, args);
    private static string Event(string constant) => (string)Bridge("AgoraApiType").GetField(constant, Flags).GetRawConstantValue();
    private static string Json(object data) => JsonSerializer.Serialize(data, new JsonSerializerOptions { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping }); // Native wire fixture only.
    private static string Dispatch(string bridge, string constant, string json)
    {
        using var packet = new Packet(Event(constant), json == null ? null : Encoding.UTF8.GetBytes(json));
        Invoke(bridge, "OnEvent", packet.Pointer); return packet.Result;
    }
    private class Rtc : IRtcEngineEventHandler { internal int Calls; internal bool Throw; internal string Text; public override void OnError(int err, string msg) { Interlocked.Increment(ref Calls); Text = msg; if (Throw) throw new InvalidOperationException("private-observer-text"); } }
    private class Player : IMediaPlayerSourceObserver { internal int Calls; internal bool Throw; internal string Text; public override void OnPlayerEvent(MEDIA_PLAYER_EVENT e, long time, string message) { Calls++; Text = message; if (Throw) throw new InvalidOperationException("private-observer-text"); } }
    private class Recorder : IMediaRecorderObserver { internal int Calls; internal bool Throw; internal string Text; public override void OnRecorderStateChanged(string channelId, uint uid, RecorderState state, RecorderReasonCode reason) { Calls++; Text = channelId; if (Throw) throw new InvalidOperationException("private-observer-text"); } }
    private class Track : IAudioTrackObserver { public override void OnAudioTrackVolumeIndication(uint id, AudioTrackVolumeInfo info) { throw new InvalidOperationException("private-observer-text"); } }
    private class Face : IFaceInfoObserver { internal bool Throw; internal string Text; public override bool OnFaceInfo(string text) { Text = text; if (Throw) throw new InvalidOperationException("private-observer-text"); return true; } }
    private class MetadataHandler : IMetadataObserver { internal bool Throw; public override int GetMaxMetadataSize() { if (Throw) throw new InvalidOperationException("private-observer-text"); return 321; } public override bool OnReadyToSendMetadata(ref Metadata metadata, VIDEO_SOURCE_TYPE source) { metadata.size = 1; metadata.buffer = new IntPtr(123); throw new InvalidOperationException("private-observer-text"); } }
    private class Provider : IMediaPlayerCustomDataProvider { internal int Reads, Seeks; public override int OnReadData(IntPtr buffer, int size) { Reads++; if (size > 0) Marshal.WriteByte(buffer, 0x33); throw new InvalidOperationException("private-observer-text"); } public override long OnSeek(long offset, int whence) { Seeks++; throw new InvalidOperationException("private-observer-text"); } }
    private class ExtMusic : IMusicContentCenterEventHandler
    {
        internal string Request, Option, Response; internal int Calls; internal bool Throw;
        public override void OnMusicChartsResult(string id, MusicChartInfo[] data, MusicContentCenterStateReason reason) { }
        public override void OnMusicCollectionResult(string id, MusicCollection data, MusicContentCenterStateReason reason) { }
        public override void OnLyricResult(string id, long code, string url, MusicContentCenterStateReason reason) { }
        public override void OnSongSimpleInfoResult(string id, long code, string data, MusicContentCenterStateReason reason) { }
        public override void OnPreLoadEvent(string id, long code, int percent, string url, PreloadState state, MusicContentCenterStateReason reason) { }
        public override void OnExtResponse(string id, string option, int httpCode, string response)
        { Calls++; Request = id; Option = option; Response = response; if (Throw) throw new InvalidOperationException("private-observer-text"); }
    }
    private class AudioFrames : IAudioFrameObserver { }
    private class AudioEncoded : IAudioEncodedFrameObserver { }
    private class Pcm : IAudioPcmFrameSink { }
    private class Spectrum : IAudioSpectrumObserver { }
    private class H265 : IH265TranscoderObserver { public override void OnEnableTranscode(H265_TRANSCODE_RESULT result) { } public override void OnQueryChannel(H265_TRANSCODE_RESULT result, string channel, string token) { } public override void OnTriggerTranscode(H265_TRANSCODE_RESULT result) { } }
    private class VideoEncoded : IVideoEncodedFrameObserver { }
    private class VideoFrames : IVideoFrameObserver { }

    internal static void Run(Action<bool, string> check)
    {
        var rtc = new Rtc(); var player = new Player(); var recorder = new Recorder(); var face = new Face(); var metadata = new MetadataHandler(); var provider = new Provider();
        var errors = new StringWriter(); var oldError = Console.Error; Console.SetError(errors);
        Invoke("RtcEngineEventHandlerNative", "SetEventHandler", rtc);
        Invoke("MediaPlayerSourceObserverNative", "AddSourceObserver", 41, player);
        Invoke("MediaRecorderObserverNative", "AddMediaRecorderObserver", "contract", recorder);
        Invoke("AudioTrackObserverNative", "SetAudioTrackObserver", new IntPtr(41), new Track());
        Invoke("FaceInfoObserverNative", "SetFaceInfoObserver", face);
        Invoke("MetadataObserverNative", "SetMetadataObserver", metadata);
        Invoke("MediaPlayerCustomDataProviderNative", "AddCustomDataProvider", 41, provider);
        Invoke("AudioFrameObserverNative", "SetAudioFrameObserverAndMode", new AudioFrames(), (OBSERVER_MODE)0);
        Invoke("AudioEncodedFrameObserverNative", "SetAudioEncodedFrameObserver", new AudioEncoded());
        Invoke("AudioPcmFrameSinkNative", "AddAudioFrameObserver", 41, new Pcm());
        Invoke("AudioSpectrumObserverNative", "SetAudioSpectrumObserver", new Spectrum());
        Invoke("MediaPlayerAudioSpectrumObserverNative", "AddAudioSpectrumObserver", 41, new Spectrum());
        Invoke("H265TranscoderObserverNative", "SetH265TranscoderObserver", new H265());
        Invoke("VideoEncodedFrameObserverNative", "SetVideoEncodedFrameObserver", new VideoEncoded());
        Invoke("VideoFrameObserverNative", "SetVideoFrameObserverAndMode", new VideoFrames(), (OBSERVER_MODE)0);
        Invoke("MusicContentCenterEventHandlerNative", "SetMusicContentCenterEventHandler", new C_Sharp_API_Example.BusinessMusicEvents((name, value) => { }));
        try
        {
            var routes = new[] {
                ("RtcEngineEventHandlerNative", "IRTCENGINEEVENTHANDLER_ONERROR_d26c0fd"),
                ("MediaPlayerSourceObserverNative", "IMEDIAPLAYERSOURCEOBSERVER_ONPLAYEREVENT_50f16fa"),
                ("MediaRecorderObserverNative", "IMEDIARECORDEROBSERVER_ONRECORDERSTATECHANGED_c38849f"),
                ("AudioTrackObserverNative", "IAUDIOTRACKOBSERVER_ONAUDIOTRACKVOLUMEINDICATION_9bd73f7"),
                ("FaceInfoObserverNative", "IFACEINFOOBSERVER_ONFACEINFO_3a2037f"),
                ("MetadataObserverNative", "IMETADATAOBSERVER_ONREADYTOSENDMETADATA_cbf4b59"),
                ("MediaPlayerCustomDataProviderNative", "IMEDIAPLAYERCUSTOMDATAPROVIDER_ONREADDATA_6e75338"),
                ("AudioFrameObserverNative", "IAUDIOFRAMEOBSERVER_ONRECORDAUDIOFRAME_4c8de15"),
                ("AudioEncodedFrameObserverNative", "IAUDIOENCODEDFRAMEOBSERVER_ONRECORDAUDIOENCODEDFRAME_d930ddc"),
                ("AudioPcmFrameSinkNative", "IAUDIOPCMFRAMESINK_ONFRAME_95f515a"),
                ("AudioSpectrumObserverNative", "IAUDIOSPECTRUMOBSERVER_ONLOCALAUDIOSPECTRUM_5822fed"),
                ("MediaPlayerAudioSpectrumObserverNative", "IAUDIOSPECTRUMOBSERVER_ONLOCALAUDIOSPECTRUM_5822fed"),
                ("H265TranscoderObserverNative", "IH265TRANSCODEROBSERVER_ONENABLETRANSCODE_6ba6646"),
                ("VideoEncodedFrameObserverNative", "IVIDEOENCODEDFRAMEOBSERVER_ONENCODEDVIDEOFRAMERECEIVED_6922697"),
                ("VideoFrameObserverNative", "IVIDEOFRAMEOBSERVER_ONCAPTUREVIDEOFRAME_1673590"),
                ("MusicContentCenterEventHandlerNative", "IMUSICCONTENTCENTEREVENTHANDLER_ONSONGSIMPLEINFORESULT_9ad9c90") };
            foreach (var route in routes)
            {
                foreach (var bytes in new[] { new byte[] { 0xff }, Encoding.UTF8.GetBytes("{\"private-payload\":") })
                {
                    using var packet = new Packet(Event(route.Item2), bytes);
                    Invoke(route.Item1, "OnEvent", packet.Pointer);
                    check(packet.GuardIntact, route.Item1 + " boundary/ABI guard");
                }
            }
            var ext = new ExtMusic();
            Invoke("MusicContentCenterEventHandlerNative", "SetMusicContentCenterEventHandler", ext);
            string extOption = Json(new { vendorId = 2, message = "中文\"请求" });
            string extResponse = Json(new { title = "告五人", data = "中文\n响应" });
            string wire = Json(new { requestId = "ext-4538", jsonOption = extOption, httpCode = 200, response = extResponse });
            const string extEvent = "IMUSICCONTENTCENTEREVENTHANDLER_ONEXTRESPONSE_bd3489b";
            Dispatch("MusicContentCenterEventHandlerNative", extEvent, wire);
            check(ext.Request == "ext-4538" && ext.Option == extOption && ext.Response == extResponse, "4.5.3.8 extension response UTF-8/JSON fidelity");
            ext.Throw = true; Dispatch("MusicContentCenterEventHandlerNative", extEvent, wire); ext.Throw = false;
            Dispatch("MusicContentCenterEventHandlerNative", extEvent, wire); check(ext.Calls == 3, "extension observer failure recovery");
            const string text = "告五人\"中文";
            var r = Json(new { err = 1, msg = text });
            Dispatch("RtcEngineEventHandlerNative", routes[0].Item2, r); check(rtc.Text == text, "RTC UTF-8 text");
            rtc.Throw = true; Dispatch("RtcEngineEventHandlerNative", routes[0].Item2, r); rtc.Throw = false;
            Dispatch("RtcEngineEventHandlerNative", routes[0].Item2, r); check(rtc.Calls == 3, "RTC observer exception recovery");
            var p = Json(new { playerId = 41, eventCode = 0, elapsedTime = 0, message = text });
            Dispatch("MediaPlayerSourceObserverNative", routes[1].Item2, p); check(player.Text == text, "player UTF-8 text");
            player.Throw = true; Dispatch("MediaPlayerSourceObserverNative", routes[1].Item2, p); player.Throw = false;
            Dispatch("MediaPlayerSourceObserverNative", routes[1].Item2, p); check(player.Calls == 3, "player observer recovery");
            var m = Json(new { nativeHandle = "contract", channelId = text, uid = 1001, state = 0, reason = 0 });
            Dispatch("MediaRecorderObserverNative", routes[2].Item2, m); check(recorder.Text == text, "recorder UTF-8 text");
            recorder.Throw = true; Dispatch("MediaRecorderObserverNative", routes[2].Item2, m); recorder.Throw = false;
            Dispatch("MediaRecorderObserverNative", routes[2].Item2, m); check(recorder.Calls == 3, "recorder observer recovery");
            Dispatch("AudioTrackObserverNative", routes[3].Item2, "{\"observerId\":41,\"trackId\":7,\"volumeInfo\":{\"channelCount\":1,\"levels\":[1,0,0,0,0,0,0,0]}}");
            check(JsonDocument.Parse(Dispatch("FaceInfoObserverNative", routes[4].Item2, Json(new { outFaceInfo = text }))).RootElement.GetProperty("result").GetBoolean() && face.Text == text, "face UTF-8 success");
            face.Throw = true;
            check(!JsonDocument.Parse(Dispatch("FaceInfoObserverNative", routes[4].Item2, Json(new { outFaceInfo = text }))).RootElement.GetProperty("result").GetBoolean(), "face exception must report false");
            check(JsonDocument.Parse(Dispatch("MetadataObserverNative", "IMETADATAOBSERVER_GETMAXMETADATASIZE", null)).RootElement.GetProperty("result").GetInt32() == 321, "valid no-data getter");
            metadata.Throw = true;
            check(JsonDocument.Parse(Dispatch("MetadataObserverNative", "IMETADATAOBSERVER_GETMAXMETADATASIZE", null)).RootElement.GetProperty("result").GetInt32() == 0, "metadata maximum failure result");
            var meta = JsonDocument.Parse(Dispatch("MetadataObserverNative", routes[5].Item2, "{\"metadata\":{\"channelId\":\"a\",\"uid\":0,\"size\":0,\"buffer\":0,\"timeStampMs\":0},\"source_type\":0}"));
            check(!meta.RootElement.GetProperty("result").GetBoolean() && meta.RootElement.GetProperty("metadata").GetProperty("size").GetInt32() == 0 && meta.RootElement.GetProperty("metadata").GetProperty("buffer").GetInt64() == 0, "partial metadata was published");
            IntPtr input = Marshal.AllocHGlobal(16);
            try
            {
                for (int i = 0; i < 16; i++) Marshal.WriteByte(input, i, 0x11);
                ulong address = IntPtr.Size == 4 ? unchecked((uint)input.ToInt32()) : unchecked((ulong)input.ToInt64());
                var read = JsonDocument.Parse(Dispatch("MediaPlayerCustomDataProviderNative", routes[6].Item2, Json(new { playerId = 41, buffer = address, bufferSize = 16 })));
                check(provider.Reads == 1 && read.RootElement.GetProperty("result").GetInt32() == 0 && Marshal.ReadByte(input) == 0x33 && Marshal.ReadByte(input, 15) == 0x11, "failed read exposed partial bytes or damaged buffer");
            }
            finally { Marshal.FreeHGlobal(input); }
            var seek = JsonDocument.Parse(Dispatch("MediaPlayerCustomDataProviderNative", "IMEDIAPLAYERCUSTOMDATAPROVIDER_ONSEEK_624d569", "{\"playerId\":41,\"offset\":0,\"whence\":0}"));
            check(provider.Seeks == 1 && seek.RootElement.GetProperty("result").GetInt64() == -1, "failed seek reported success");
            // Exercise all typed failure writebacks, including stale buffer and terminator guards.
            var booleanEvents = new[] { "IAUDIOFRAMEOBSERVER_ONRECORDAUDIOFRAME_4c8de15", "IAUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAME_4c8de15", "IAUDIOFRAMEOBSERVER_ONMIXEDAUDIOFRAME_4c8de15", "IAUDIOFRAMEOBSERVER_ONEARMONITORINGAUDIOFRAME_5405a47", "IAUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAMEBEFOREMIXING_9215cc7", "IAUDIOFRAMEOBSERVER_ONPLAYBACKAUDIOFRAMEBEFOREMIXING_85ec0fc", "IVIDEOFRAMEOBSERVER_ONCAPTUREVIDEOFRAME_1673590", "IVIDEOFRAMEOBSERVER_ONPREENCODEVIDEOFRAME_1673590", "IVIDEOFRAMEOBSERVER_ONMEDIAPLAYERVIDEOFRAME_e648e2c", "IVIDEOFRAMEOBSERVER_ONTRANSCODEDVIDEOFRAME_27754d8", "IVIDEOFRAMEOBSERVER_ONRENDERVIDEOFRAME_43dcf82", "IVIDEOENCODEDFRAMEOBSERVER_ONENCODEDVIDEOFRAMERECEIVED_6922697", "IAUDIOSPECTRUMOBSERVER_ONLOCALAUDIOSPECTRUM_5822fed", "IAUDIOSPECTRUMOBSERVER_ONREMOTEAUDIOSPECTRUM_8ea2cde", "IFACEINFOOBSERVER_ONFACEINFO_3a2037f" };
            foreach (var field in booleanEvents)
            {
                using var packet = new Packet(Event(field)); packet.Seed();
                Invoke("RtcCallbackBoundary", "WriteFailure", packet.Pointer);
                check(!JsonDocument.Parse(packet.Result).RootElement.GetProperty("result").GetBoolean() && packet.GuardIntact, "typed frame/analysis failure " + field);
            }
            using (var packet = new Packet(Event(routes[0].Item2))) { packet.Seed(); Invoke("RtcCallbackBoundary", "WriteFailure", packet.Pointer); check(packet.Untouched && packet.GuardIntact, "void notification wrote a result"); }
            Parallel.For(0, 80, i => { Invoke("RtcEngineEventHandlerNative", "SetEventHandler", i % 2 == 0 ? rtc : null); Dispatch("RtcEngineEventHandlerNative", routes[0].Item2, r); });
            Invoke("RtcEngineEventHandlerNative", "SetEventHandler", rtc); int before = rtc.Calls; Dispatch("RtcEngineEventHandlerNative", routes[0].Item2, r); check(rtc.Calls == before + 1, "RTC teardown/dispatch recovery");
            check(!errors.ToString().Contains("private-observer-text") && !errors.ToString().Contains("private-payload"), "boundary diagnostics leaked message/payload");
        }
        finally
        {
            Invoke("RtcEngineEventHandlerNative", "SetEventHandler", new object[] { null });
            Invoke("MediaPlayerSourceObserverNative", "RemoveSourceObserver", 41);
            Invoke("MediaRecorderObserverNative", "RemoveMediaRecorderObserver", "contract");
            Invoke("AudioTrackObserverNative", "SetAudioTrackObserver", new IntPtr(41), null);
            Invoke("FaceInfoObserverNative", "SetFaceInfoObserver", new object[] { null });
            Invoke("MetadataObserverNative", "SetMetadataObserver", new object[] { null });
            Invoke("MediaPlayerCustomDataProviderNative", "RemoveCustomDataProvider", 41);
            Invoke("AudioFrameObserverNative", "SetAudioFrameObserverAndMode", null, (OBSERVER_MODE)0);
            Invoke("AudioEncodedFrameObserverNative", "SetAudioEncodedFrameObserver", new object[] { null });
            Invoke("AudioPcmFrameSinkNative", "RemoveAudioFrameObserver", 41);
            Invoke("AudioSpectrumObserverNative", "SetAudioSpectrumObserver", new object[] { null });
            Invoke("MediaPlayerAudioSpectrumObserverNative", "RemoveAudioSpectrumObserver", 41);
            Invoke("H265TranscoderObserverNative", "SetH265TranscoderObserver", new object[] { null });
            Invoke("VideoEncodedFrameObserverNative", "SetVideoEncodedFrameObserver", new object[] { null });
            Invoke("VideoFrameObserverNative", "SetVideoFrameObserverAndMode", null, (OBSERVER_MODE)0);
            Invoke("MusicContentCenterEventHandlerNative", "SetMusicContentCenterEventHandler", new object[] { null });
            Console.SetError(oldError);
        }
    }
}
