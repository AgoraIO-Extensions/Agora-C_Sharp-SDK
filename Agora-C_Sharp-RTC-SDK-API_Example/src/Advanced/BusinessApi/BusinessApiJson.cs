using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Agora.Rtc;

namespace C_Sharp_API_Example
{
    internal static class BusinessApiJson
    {
        internal static readonly JsonSerializerOptions Options = CreateOptions();
        private static JsonSerializerOptions CreateOptions()
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true, WriteIndented = true, MaxDepth = 24,
                UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow
            };
            options.Converters.Add(new JsonStringEnumConverter());
            options.Converters.Add(new OptionalConverterFactory());
            options.Converters.Add(new BytesConverter());
            options.Converters.Add(new PointerConverter());
            return options;
        }

        internal static string Template(BusinessApiOperation op, RtcConnection connection, string token)
        {
            var values = new Dictionary<string, object>();
            foreach (var p in op.Method.GetParameters())
            {
                var type = p.ParameterType.IsByRef ? p.ParameterType.GetElementType() : p.ParameterType;
                object value = p.HasDefaultValue ? p.DefaultValue : Default(type);
                if (type == typeof(RtcConnection)) value = connection;
                if (p.Name == "token") value = token;
                if (p.Name == "channelId") value = connection.channelId;
                if (p.Name == "uid") value = connection.localUid;
                if (p.Name == "length") value = 2;
                if (p.Name == "volume") value = 100;
                if (p.Name == "position" && type == typeof(AUDIO_FRAME_POSITION))
                    value = AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_RECORD | AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_PLAYBACK |
                        AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_MIXED | AUDIO_FRAME_POSITION.AUDIO_FRAME_POSITION_BEFORE_MIXING;
                if (type == typeof(ChannelMediaOptions))
                {
                    var media = new ChannelMediaOptions();
                    media.channelProfile.SetValue(CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING);
                    media.clientRoleType.SetValue(CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);
                    media.publishMicrophoneTrack.SetValue(true);
                    media.autoSubscribeAudio.SetValue(true);
                    value = media;
                }
                values[p.Name] = value;
            }
            return JsonSerializer.Serialize(values, Options);
        }

        internal static object Default(Type type)
        {
            if (type == typeof(string)) return "";
            if (type == typeof(object)) return 0;
            if (type == typeof(byte[])) return new byte[] { 104, 105 };
            if (type == typeof(AudioFrame)) return new AudioFrame
            { samplesPerSec = 48000, channels = 1, samplesPerChannel = 960, RawBuffer = new byte[1920] };
            if (type.IsArray) return Array.CreateInstance(type.GetElementType(), 0);
            if (type.IsAbstract || type.IsInterface) return null; // Registered by the session, never deserialized.
            return Activator.CreateInstance(type);
        }

        internal static object[] ReadArguments(BusinessApiOperation op, string json)
        {
            if (json.Length > 1024 * 1024) throw new ArgumentException("入参不得超过1MiB。");
            using var doc = JsonDocument.Parse(json, new JsonDocumentOptions { MaxDepth = 24 });
            if (doc.RootElement.ValueKind != JsonValueKind.Object) throw new ArgumentException("入参必须是JSON对象。");
            var parameters = op.Method.GetParameters();
            var known = new HashSet<string>(parameters.Select(p => p.Name));
            var seen = new HashSet<string>();
            foreach (var field in doc.RootElement.EnumerateObject())
            {
                if (!known.Contains(field.Name)) throw new ArgumentException("未知参数: " + field.Name);
                if (!seen.Add(field.Name)) throw new ArgumentException("重复参数: " + field.Name);
            }
            var args = new object[parameters.Length];
            for (int n = 0; n < parameters.Length; n++)
            {
                var p = parameters[n];
                var type = p.ParameterType.IsByRef ? p.ParameterType.GetElementType() : p.ParameterType;
                if (type.IsAbstract || type.IsInterface)
                {
                    if (doc.RootElement.TryGetProperty(p.Name, out var bound) && bound.ValueKind != JsonValueKind.Null)
                        throw new ArgumentException(p.Name + "由面板当前对象提供，请保留null。");
                    continue;
                }
                if (doc.RootElement.TryGetProperty(p.Name, out var field))
                {
                    if (field.ValueKind == JsonValueKind.Null)
                    {
                        if (type != typeof(string) && type != typeof(object) && Nullable.GetUnderlyingType(type) == null)
                            throw new ArgumentException(p.Name + "不接受null，请填写该重载要求的类型化值。");
                        args[n] = null;
                    }
                    else args[n] = type == typeof(object) ? PlainValue(field) : JsonSerializer.Deserialize(field.GetRawText(), type, Options);
                }
                else if (p.IsOut || p.HasDefaultValue) args[n] = p.HasDefaultValue ? p.DefaultValue : Default(type);
                else throw new ArgumentException("缺少参数: " + p.Name);
            }
            ValidateBuffers(op.Method.Name, parameters, args);
            return args;
        }

        private static object PlainValue(JsonElement value) => value.ValueKind switch
        {
            JsonValueKind.Null => null, JsonValueKind.String => value.GetString(),
            JsonValueKind.True => true, JsonValueKind.False => false,
            JsonValueKind.Number => value.TryGetInt64(out var n) ? (object)n : value.GetDouble(),
            JsonValueKind.Array => value.EnumerateArray().Select(PlainValue).ToArray(),
            JsonValueKind.Object => value.EnumerateObject().ToDictionary(p => p.Name, p => PlainValue(p.Value)),
            _ => throw new JsonException("不支持的JSON值。")
        };

        internal static void ValidateBuffers(string method, ParameterInfo[] parameters, object[] args)
        {
            if (method.StartsWith("SendAudioMetadata") || method.StartsWith("SendStreamMessage"))
            {
                int b = Array.FindIndex(parameters, p => p.ParameterType == typeof(byte[]));
                int l = Array.FindIndex(parameters, p => p.Name == "length");
                var bytes = b < 0 ? null : args[b] as byte[];
                ulong length = l < 0 ? 0 : Convert.ToUInt64(args[l]);
                if (bytes == null || length == 0 || length > (ulong)bytes.Length)
                    throw new ArgumentException("发送长度必须大于0，且不能超过实际byte[]长度。");
                if (method.StartsWith("SendAudioMetadata") && length >= 256)
                    throw new ArgumentException("当前Native音频元数据长度限制为1～255字节。");
            }
            int listIndex = Array.FindIndex(parameters, p => p.Name == "uidList");
            int countIndex = Array.FindIndex(parameters, p => p.Name == "uidNumber");
            if (listIndex >= 0 && countIndex >= 0 && (args[listIndex] as Array)?.Length != Convert.ToInt32(args[countIndex]))
                throw new ArgumentException("uidNumber必须等于uidList实际数量。");
            foreach (var relay in args.OfType<ChannelMediaRelayConfiguration>())
                if (relay.destCount < 0 || relay.destCount != (relay.destInfos?.Length ?? 0))
                    throw new ArgumentException("destCount必须等于destInfos实际数量。");
            foreach (var frame in args.OfType<AudioFrame>()) ValidateFrame(frame);
        }

        internal static void ValidateFrame(AudioFrame frame)
        {
            if (frame.samplesPerChannel <= 0 || frame.samplesPerChannel > 48000 ||
                (frame.channels != 1 && frame.channels != 2) || (int)frame.bytesPerSample != 2 ||
                frame.samplesPerSec <= 0 || frame.samplesPerSec > 48000)
                throw new ArgumentException("PCM必须为有效的16bit单/双声道，采样率和帧长须在合理范围内。");
            long required = (long)frame.samplesPerChannel * frame.channels * 2;
            if (frame.RawBuffer == null || frame.RawBuffer.Length != required)
                throw new ArgumentException("RawBuffer字节数必须等于samplesPerChannel × channels × 2。");
            if (frame.buffer != IntPtr.Zero) throw new ArgumentException("仅支持托管RawBuffer，不接受Native指针。");
        }

        internal static object DiagnosticInfo(string json)
        {
            if (string.IsNullOrWhiteSpace(json)) return null;
            try { using var doc = JsonDocument.Parse(json); return doc.RootElement.Clone(); }
            catch (JsonException) { return new { invalidJson = true, length = json?.Length ?? 0 }; }
        }

        // Inputs containing credentials are never written to the UI/export log.
        internal static string Result(object value)
        {
            if (value == null) return "null";
            var text = JsonSerializer.Serialize(value, value.GetType(), Options);
            using var doc = JsonDocument.Parse(text);
            object Redact(JsonElement e, string key = "")
            {
                if (key.Contains("token", StringComparison.OrdinalIgnoreCase) ||
                    key.Equals("appId", StringComparison.OrdinalIgnoreCase)) return "[已隐藏]";
                if (e.ValueKind == JsonValueKind.Object)
                    return e.EnumerateObject().ToDictionary(p => p.Name, p => Redact(p.Value, p.Name));
                if (e.ValueKind == JsonValueKind.Array) return e.EnumerateArray().Select(v => Redact(v)).ToArray();
                if (e.ValueKind == JsonValueKind.String && Uri.TryCreate(e.GetString(), UriKind.Absolute, out var uri) &&
                    (uri.Scheme == "http" || uri.Scheme == "https"))
                    return uri.GetLeftPart(UriPartial.Path); // Do not export signed URL query credentials.
                return e.Clone();
            }
            return JsonSerializer.Serialize(Redact(doc.RootElement));
        }

        private sealed class PointerConverter : JsonConverter<IntPtr>
        {
            public override IntPtr Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.Number || reader.GetInt64() != 0)
                    throw new JsonException("不接受非零Native指针。");
                return IntPtr.Zero;
            }
            public override void Write(Utf8JsonWriter writer, IntPtr value, JsonSerializerOptions options) => writer.WriteNumberValue(0);
        }
        private sealed class BytesConverter : JsonConverter<byte[]>
        {
            public override byte[] Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.String) return reader.GetBytesFromBase64();
                if (reader.TokenType != JsonTokenType.StartArray) throw new JsonException("byte[]使用数字数组或Base64字符串。");
                var bytes = new List<byte>();
                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray) bytes.Add(reader.GetByte());
                return bytes.ToArray();
            }
            public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options)
            {
                writer.WriteStartArray(); foreach (var b in value) writer.WriteNumberValue(b); writer.WriteEndArray();
            }
        }
        private sealed class OptionalConverterFactory : JsonConverterFactory
        {
            public override bool CanConvert(Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Optional<>);
            public override JsonConverter CreateConverter(Type type, JsonSerializerOptions options) =>
                (JsonConverter)Activator.CreateInstance(typeof(OptionalConverter<>).MakeGenericType(type.GetGenericArguments()[0]));
        }
        private sealed class OptionalConverter<T> : JsonConverter<Optional<T>>
        {
            public override bool HandleNull => true;
            public override Optional<T> Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
            {
                var optional = new Optional<T>();
                if (reader.TokenType != JsonTokenType.Null) optional.SetValue(JsonSerializer.Deserialize<T>(ref reader, options));
                return optional;
            }
            public override void Write(Utf8JsonWriter writer, Optional<T> value, JsonSerializerOptions options)
            {
                if (value != null && value.HasValue()) JsonSerializer.Serialize(writer, value.GetValue(), options);
                else writer.WriteNullValue();
            }
        }
    }
}
