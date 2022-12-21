using System;
using System.Runtime.InteropServices;
using System.Text;



namespace Agora.Rtc
{
    using LitJson;
    using IrisEventHandlerMarshal = IntPtr;
    using IrisEventHandlerHandle = IntPtr;
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

        internal static JsonData ToObject(string data)
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

    }

    internal class AgoraUtil
    {

        internal static void AllocEventHandlerHandle(ref EventHandlerHandle eventHandlerHandle, Func_Event_Native onEvent)
        {
            eventHandlerHandle.cEvent = new IrisCEventHandler
            {
                OnEvent = onEvent,
            };

            var cEventHandlerNativeLocal = new IrisCEventHandlerNative
            {
                onEvent = Marshal.GetFunctionPointerForDelegate(eventHandlerHandle.cEvent.OnEvent),
            };

            eventHandlerHandle.marshal = Marshal.AllocHGlobal(Marshal.SizeOf(cEventHandlerNativeLocal));
            Marshal.StructureToPtr(cEventHandlerNativeLocal, eventHandlerHandle.marshal, true);
            eventHandlerHandle.handle = AgoraRtcNative.CreateIrisEventHandler(eventHandlerHandle.marshal);
        }

        internal static void FreeEventHandlerHandle(ref EventHandlerHandle eventHandlerHandle)
        {
            AgoraRtcNative.DestroyIrisEventHandler(eventHandlerHandle.handle);
            eventHandlerHandle.handle = IntPtr.Zero;

            Marshal.FreeHGlobal(eventHandlerHandle.marshal);
            eventHandlerHandle.marshal = IntPtr.Zero;

            eventHandlerHandle.cEvent = new IrisCEventHandler();
        }

        internal static string ConvertByteToString(ref byte[] array)
        {
            var re = Encoding.UTF8.GetString(array);
            var index = re.IndexOf('\0');
            return re.Substring(0, index);
        }

    }

    //event_handler
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate void Func_Event_Native(IntPtr param);

    //[UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    //internal delegate void Func_EventEx_Native(string @event, string data, IntPtr result, IntPtr buffer, IntPtr length, uint buffer_count);


    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisCEventParam
    {
        internal string @event;
        internal string data;
        internal uint data_size;

        internal IntPtr result;

        internal IntPtr buffer;
        internal IntPtr length;
        internal uint buffer_count;
    }

    //[StructLayout(LayoutKind.Sequential)]
    //internal struct IrisCEventParam2
    //{
    //    internal string @event;
    //    internal string data;
    //    internal uint data_size;

    //    //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 65536)]
    //    internal IntPtr result;

    //    internal IntPtr buffer;
    //    internal IntPtr length;
    //    internal uint buffer_count;
    //}

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisCApiParam
    {

        internal string Result
        {
            get
            {
                var re = Marshal.PtrToStringAnsi(result);
                return re;
            }
        }

        internal void AllocResult()
        {
            if (result == IntPtr.Zero)
            {
                result = Marshal.AllocHGlobal(65536);
            }
        }

        internal void FreeResult()
        {
            if (result != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(result);
                result = IntPtr.Zero;
            }
        }


        internal string @event;
        internal string data;
        internal uint data_size;

        internal IntPtr result;

        internal IntPtr buffer;
        internal IntPtr length;
        internal uint buffer_count;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisCEventHandlerNative
    {
        internal IntPtr onEvent;
        //internal IntPtr onEventEx;
    }

    internal struct IrisCEventHandler
    {
        internal Func_Event_Native OnEvent;
        //internal Func_EventEx_Native OnEventEx;
    }


    internal struct EventHandlerHandle
    {
        internal IrisCEventHandler cEvent;
        internal IrisEventHandlerMarshal marshal;
        internal IrisEventHandlerHandle handle;
    }
}