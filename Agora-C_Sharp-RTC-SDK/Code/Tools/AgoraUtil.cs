#define AGORA_RTC
#define AGORA_RTM
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;

#if AGORA_RTC
namespace Agora.Rtc
#elif AGORA_RTM
namespace Agora.Rtm
#endif
{
    using LitJson;
    using IrisEventHandlerMarshal = IntPtr;
    using IrisEventHandlerHandle = IntPtr;
    using UnityEngine;

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

        public static int[] GetDataArrayInt(JsonData data, string key)
        {
            JsonData jsonData = data[key];
            if (jsonData == null || jsonData.IsArray == false)
            {
                return new int[0];
            }
            else
            {
                var count = jsonData.Count;
                var array = new int[count];
                for (int i = 0; i < count; i++)
                {
                    array[i] = (int)jsonData[i];
                }
                return array;
            }
        }

        public static T JsonToStruct<T>(char[] data) where T : new()
        {
            var str = new string(data, 0, Array.IndexOf(data, '\0'));
            return AgoraJson.JsonToStruct<T>(str);
        }

        public static T JsonToStruct<T>(char[] data, string key) where T : new()
        {
            var str = new string(data, 0, Array.IndexOf(data, '\0'));
            return AgoraJson.JsonToStruct<T>(str, key);

            //var jValue = AgoraJson.ToJson(JsonMapper.ToObject(new string(data, 0, Array.IndexOf(data, '\0')))[key]);
            //return JsonMapper.ToObject<T>(jValue ?? string.Empty);
        }

        public static T[] JsonToStructArray<T>(char[] data, string key = null, uint length = 0) where T : new()
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

        public static T JsonToStruct<T>(string data) where T : new()
        {
            try
            {
                return JsonMapper.ToObject<T>(data);
            }
            catch (Exception e)
            {
                AgoraLog.LogError(e.ToString());
            }
            return new T();
        }

        public static T JsonToStruct<T>(string data, string key) where T : new()
        {
            var jValue = AgoraJson.ToJson(JsonMapper.ToObject(data)[key]);
            return AgoraJson.JsonToStruct<T>(jValue ?? string.Empty);
        }

        public static T JsonToStruct<T>(JsonData data, string key) where T : new()
        {
            var jValue = AgoraJson.ToJson(data[key]);
            return AgoraJson.JsonToStruct<T>(jValue ?? string.Empty);
        }

        public static T[] JsonToStructArray<T>(string data, string key = null, uint length = 0) where T : new()
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

        public static T[] JsonToStructArray<T>(JsonData data, string key = null, uint length = 0) where T : new()
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

        public static string ToJson<T>(T param)
        {
            try
            {
                return JsonMapper.ToJson(param);
            }
            catch (Exception e)
            {
                AgoraLog.LogError(e.ToString());
            }
            return "";
        }

        public static JsonData ToObject(string data)
        {
            try
            {
                return JsonMapper.ToObject(data);
            }
            catch (Exception e)
            {
                AgoraLog.LogError(e.ToString());
            }
            return new JsonData();
        }

        public static void WriteEnum(LitJson.JsonWriter writer, System.Object obj)
        {
            Type obj_type = obj.GetType();
            Type e_type = Enum.GetUnderlyingType(obj_type);

            if (e_type == typeof(long))
                writer.Write((long)obj);
            else if (e_type == typeof(uint))
                writer.Write((uint)obj);
            else if (e_type == typeof(ulong))
                writer.Write((ulong)obj);
            else if (e_type == typeof(ushort))
                writer.Write((ushort)obj);
            else if (e_type == typeof(short))
                writer.Write((short)obj);
            else if (e_type == typeof(byte))
                writer.Write((byte)obj);
            else if (e_type == typeof(sbyte))
                writer.Write((sbyte)obj);
            else
                writer.Write((int)obj);
        }
    }

    internal class AgoraUtil
    {

        internal static string ConvertByteToString(ref byte[] array)
        {
            var re = Encoding.UTF8.GetString(array);
            var index = re.IndexOf('\0');
            return re.Substring(0, index);
        }

        static public UInt64 ConvertNegativeToUInt64(Int64 value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            ulong uNum = BitConverter.ToUInt64(bytes, 0);
            return uNum;
        }

        public static string StringFromNativeUtf8(IntPtr nativeUtf8)
        {
            int len = 0;
            while (Marshal.ReadByte(nativeUtf8, len) != 0) ++len;
            byte[] buffer = new byte[len];
            Marshal.Copy(nativeUtf8, buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }

        internal static List<T> GetDicKeys<T, D>(Dictionary<T, D> dic)
        {
            List<T> list = new List<T>();
            foreach (var e in dic)
            {
                list.Add(e.Key);
            }

            return list;
        }

    }

#if UNITY_OPENHARMONY
    public class AgoraOhosUntil
    {
        /*
        'ohos.permission.INTERNET',
        'ohos.permission.MICROPHONE',
        "ohos.permission.CAMERA",
        "ohos.permission.WRITE_MEDIA",
        "ohos.permission.READ_MEDIA",
        "ohos.permission.CAPTURE_SCREEN"
        */
        public static void RequestOhosPermission(string permission)
        {
            OpenHarmonyJSClass AgoraRtcWrapperNative = new OpenHarmonyJSClass("AgoraRtcWrapperNative");
            AgoraRtcWrapperNative.CallStatic("requestPermission", permission);
        }
    }
#endif
}