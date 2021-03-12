//
//  Created by Yiqing Huang on 2020/12/15.
//  Copyright © 2020 Agora. All rights reserved.
//

using System;
using System.Text.Json;
using Newtonsoft.Json;

namespace agorartc
{
    public class AgoraUtil
    {
        internal static object GetData<T>(string data, string key)
        {
            var jData = JsonDocument.Parse(data).RootElement;
            var jValue = jData.GetProperty(key);
            return typeof(T).Name switch
            {
                "Boolean" => jValue.GetBoolean(),
                "Byte" => jValue.GetByte(),
                "Decimal" => jValue.GetDecimal(),
                "Double" => jValue.GetDouble(),
                "Int16" => jValue.GetInt16(),
                "Int32" => jValue.GetInt32(),
                "Int64" => jValue.GetInt64(),
                "SByte" => jValue.GetSByte(),
                "Single" => jValue.GetSingle(),
                "String" => jValue.GetString(),
                "UInt16" => jValue.GetUInt16(),
                "UInt32" => jValue.GetUInt32(),
                "UInt64" => jValue.GetUInt64(),
                _ => jValue.ToString()
            };
        }

        internal static object GetData<T>(char[] data, string key)
        {
            var jData = JsonDocument.Parse(new string(data[..Array.IndexOf(data, '\0')])).RootElement;
            var jValue = jData.GetProperty(key);
            return typeof(T).Name switch
            {
                "Boolean" => jValue.GetBoolean(),
                "Byte" => jValue.GetByte(),
                "Decimal" => jValue.GetDecimal(),
                "Double" => jValue.GetDouble(),
                "Int16" => jValue.GetInt16(),
                "Int32" => jValue.GetInt32(),
                "Int64" => jValue.GetInt64(),
                "SByte" => jValue.GetSByte(),
                "Single" => jValue.GetSingle(),
                "String" => jValue.GetString(),
                "UInt16" => jValue.GetUInt16(),
                "UInt32" => jValue.GetUInt32(),
                "UInt64" => jValue.GetUInt64(),
                _ => jValue.ToString()
            };
        }

        internal static T JsonToStruct<T>(char[] data)
        {
            var jValue = JsonDocument.Parse(new string(data[..Array.IndexOf(data, '\0')])).RootElement.ToString();
            return JsonConvert.DeserializeObject<T>(jValue);
        }

        internal static T JsonToStruct<T>(char[] data, string key)
        {
            var jValue = GetData<T>(data, key) as string;
            return JsonConvert.DeserializeObject<T>(jValue ?? string.Empty);
        }

        internal static T[] JsonToStructArray<T>(char[] data, string key, uint length)
        {
            var jValueArray = JsonDocument.Parse(new string(data[..Array.IndexOf(data, '\0')])).RootElement
                .GetProperty(key);
            var ret = new T[length];
            for (var i = 0; i < length; i++)
            {
                ret[i] = JsonConvert.DeserializeObject<T>(jValueArray[i].ToString());
            }

            return ret;
        }

        internal static T JsonToStruct<T>(string data)
        {
            var jValue = JsonDocument.Parse(data).RootElement.ToString();
            return JsonConvert.DeserializeObject<T>(jValue);
        }

        internal static T JsonToStruct<T>(string data, string key)
        {
            var jValue = GetData<T>(data, key) as string;
            return JsonConvert.DeserializeObject<T>(jValue ?? string.Empty);
        }

        internal static T[] JsonToStructArray<T>(string data, string key, uint length)
        {
            var jValueArray = JsonDocument.Parse(data).RootElement.GetProperty(key);
            var ret = new T[length];
            for (var i = 0; i < length; i++)
            {
                ret[i] = JsonConvert.DeserializeObject<T>(jValueArray[i].ToString());
            }

            return ret;
        }
    }
}