using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Agora.Rtc
{
    using LitJson;

    public class AgoraJson
    {
        private const string ErrorTag = "AgoraJsonError";
        internal static object GetData<T>(string data, string key)
        {
            string jValue = "";
            try
            {
                var jData = JsonMapper.ToObject(data);
                if (jData[key] == null) return null;
                jValue = jData[key].ToString();
            }
            catch (System.Exception)
            {
                AgoraLog.LogError(ErrorTag + data);
            }

            switch (typeof(T).Name)
            {
                case "Boolean":
                    return bool.Parse(jValue);
                case "Byte":
                    return byte.Parse(jValue);
                case "Decimal":
                    return decimal.Parse(jValue);
                case "Double":
                    return double.Parse(jValue);
                case "Int16":
                    return short.Parse(jValue);
                case "Int32":
                    return int.Parse(jValue);
                case "Int64":
                    return long.Parse(jValue);
                case "SByte":
                    return sbyte.Parse(jValue);
                case "Single":
                    return float.Parse(jValue);
                case "String":
                    return jValue;
                case "UInt16":
                    return ushort.Parse(jValue);
                case "UInt32":
                    return uint.Parse(jValue);
                case "UInt64":
                    return ulong.Parse(jValue);
                default:
                    return jValue;
            }
        }

        internal static object GetData<T>(char[] data, string key)
        {
            var str = new string(data, 0, Array.IndexOf(data, '\0'));
            return AgoraJson.GetData<T>(str, key);
        }

        internal static object GetData<T>(JsonData data, string key)
        {
            var jValue = data[key].ToString();

            switch (typeof(T).Name)
            {
                case "Boolean":
                    return bool.Parse(jValue);
                case "Byte":
                    return byte.Parse(jValue);
                case "Decimal":
                    return decimal.Parse(jValue);
                case "Double":
                    return double.Parse(jValue);
                case "Int16":
                    return short.Parse(jValue);
                case "Int32":
                    return int.Parse(jValue);
                case "Int64":
                    return long.Parse(jValue);
                case "SByte":
                    return sbyte.Parse(jValue);
                case "Single":
                    return float.Parse(jValue);
                case "String":
                    return jValue;
                case "UInt16":
                    return ushort.Parse(jValue);
                case "UInt32":
                    return uint.Parse(jValue);
                case "UInt64":
                    return ulong.Parse(jValue);
                default:
                    return jValue;
            }
        }

        internal static T JsonToStruct<T>(char[] data) where T : new()
        {
            var str = new string(data, 0, Array.IndexOf(data, '\0'));
            return AgoraJson.JsonToStruct<T>(str);
        }

        internal static T JsonToStruct<T>(char[] data, string key) where T : new()
        {
            var str = new string(data, 0, Array.IndexOf(data, '\0'));
            return AgoraJson.JsonToStruct<T>(str, key);

            //var jValue = AgoraJson.ToJson(JsonMapper.ToObject(new string(data, 0, Array.IndexOf(data, '\0')))[key]);
            //return JsonMapper.ToObject<T>(jValue ?? string.Empty);
        }



        internal static T[] JsonToStructArray<T>(char[] data, string key = null, uint length = 0) where T : new()
        {
            var str = new string(data, 0, Array.IndexOf(data, '\0'));
            return AgoraJson.JsonToStructArray<T>(str, key, length);

            //var jValueArray = key == null
            //    ? JsonMapper.ToObject(new string(data, 0, Array.IndexOf(data, '\0')))
            //    : JsonMapper.ToObject(new string(data, 0, Array.IndexOf(data, '\0')))[key];
            //length = length != 0 ? length : (uint)jValueArray.Count;
            //var ret = new T[length];
            //for (var i = 0; i < length; i++)
            //{
            //    ret[i] = JsonMapper.ToObject<T>(jValueArray[i].ToJson());
            //}

            //return ret;
        }

        internal static T JsonToStruct<T>(string data) where T : new()
        {
            return JsonMapper.ToObject<T>(data);
        }

        internal static T JsonToStruct<T>(string data, string key) where T : new()
        {
            var jValue = AgoraJson.ToJson(JsonMapper.ToObject(data)[key]);
            return AgoraJson.JsonToStruct<T>(jValue ?? string.Empty);
        }

        internal static T JsonToStruct<T>(JsonData data, string key) where T : new()
        {
            var jValue = AgoraJson.ToJson(data[key]);
            return AgoraJson.JsonToStruct<T>(jValue ?? string.Empty);
        }

        internal static T[] JsonToStructArray<T>(string data, string key = null, uint length = 0) where T : new()
        {
            var jValueArray = key == null ? JsonMapper.ToObject(data) : JsonMapper.ToObject(data)[key];
            if (jValueArray == null)
                return new T[0];
            length = length != 0 ? length : (uint)jValueArray.Count;
            var ret = new T[length];
            for (var i = 0; i < length; i++)
            {
                ret[i] = AgoraJson.JsonToStruct<T>(jValueArray[i].ToJson());
            }

            return ret;
        }

        internal static T[] JsonToStructArray<T>(JsonData data, string key = null, uint length = 0) where T : new()
        {
            var jValueArray = key == null ? data : data[key];
            if (jValueArray == null)
                return new T[0];
            length = length != 0 ? length : (uint)jValueArray.Count;
            var ret = new T[length];
            for (var i = 0; i < length; i++)
            {
                ret[i] = AgoraJson.JsonToStruct<T>(jValueArray[i].ToJson());
            }

            return ret;
        }

        internal static string ToJson<T>(T param)
        {
            return LitJson.JsonMapper.ToJson(param);
        }

        internal static JsonData ToObject(string data)
        {
            return JsonMapper.ToObject(data);
        }

    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CharAssistant
    {
        internal CharAssistant(int param = 0) {
            resultChar = new byte[65536];
        }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65536)]
        private byte[] resultChar;

        public string Result
        {
            get
            {
                var re = Encoding.UTF8.GetString(resultChar);
                var index = re.IndexOf('\0');
                return re.Substring(0, index);
            }
        }
    }
}