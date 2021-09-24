//  AgoraUtil.cs
//
//  Created by Yiqing Huang on Dec 15, 2020.
//  Modified by Yiqing Huang on July 12, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace agora.rtc
{
    using LitJson;

    public class AgoraJson
    {
        internal static object GetData<T>(string data, string key)
        {
            var jData = JsonMapper.ToObject(data);
            if (jData[key] == null) return null;
            var jValue = jData[key].ToString();

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
            var jData = JsonMapper.ToObject(new string(data, 0, Array.IndexOf(data, '\0')));
            if (jData[key] == null) return null;
            var jValue = jData[key].ToJson();

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

        internal static T JsonToStruct<T>(char[] data)
        {
            return JsonMapper.ToObject<T>(new string(data, 0, Array.IndexOf(data, '\0')));
        }

        internal static T JsonToStruct<T>(char[] data, string key)
        {
            var jValue = JsonMapper.ToJson(JsonMapper.ToObject(new string(data, 0, Array.IndexOf(data, '\0')))[key]);
            return JsonMapper.ToObject<T>(jValue ?? string.Empty);
        }

        internal static T[] JsonToStructArray<T>(char[] data, string key = null, uint length = 0)
        {
            var jValueArray = key == null
                ? JsonMapper.ToObject(new string(data, 0, Array.IndexOf(data, '\0')))
                : JsonMapper.ToObject(new string(data, 0, Array.IndexOf(data, '\0')))[key];
            length = length != 0 ? length : (uint) jValueArray.Count;
            var ret = new T[length];
            for (var i = 0; i < length; i++)
            {
                ret[i] = JsonMapper.ToObject<T>(jValueArray[i].ToJson());
            }

            return ret;
        }

        internal static T JsonToStruct<T>(string data)
        {
            return JsonMapper.ToObject<T>(data);
        }

        internal static T JsonToStruct<T>(string data, string key)
        {
            var jValue = JsonMapper.ToJson(JsonMapper.ToObject(data)[key]);
            return JsonMapper.ToObject<T>(jValue ?? string.Empty);
        }

        internal static T[] JsonToStructArray<T>(string data, string key = null, uint length = 0)
        {
            var jValueArray = key == null ? JsonMapper.ToObject(data) : JsonMapper.ToObject(data)[key];
            if (jValueArray == null)
                return new T[0];
            length = length != 0 ? length : (uint) jValueArray.Count;
            var ret = new T[length];
            for (var i = 0; i < length; i++)
            {
                ret[i] = JsonMapper.ToObject<T>(jValueArray[i].ToJson());
            }

            return ret;
        }
    }


    [StructLayout(LayoutKind.Sequential)]
    internal struct CharAssistant
    {
        internal CharAssistant(int param = 0) {
            resultChar = new byte[2048];
        }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048)]
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