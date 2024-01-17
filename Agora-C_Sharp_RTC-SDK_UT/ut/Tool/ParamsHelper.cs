using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Agora.Rtc;
using Agora.Rtm;
namespace Agora.Rtc.Ut
{
    [StructLayout(LayoutKind.Sequential)]
    public struct IrisCApiParam2
    {

        public string Result
        {
            get
            {
                var re = Marshal.PtrToStringAnsi(result);
                return re;
            }
        }

        public void AllocResult()
        {
            if (result == IntPtr.Zero)
            {
                result = Marshal.AllocHGlobal(65536);
            }
        }

        public void FreeResult()
        {
            if (result != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(result);
                result = IntPtr.Zero;
            }
        }


        public string @event;
        public string data;
        public uint data_size;

        public IntPtr result;

        public IntPtr buffer;
        public IntPtr length;
        public uint buffer_count;
    }


    public class ParamsHelper
    {

        public static T CreateParam<T>()
        {
            Type type = typeof(T);
            return (T)CreateParam(type);
        }

        private static Object CreateParam(Type instType)
        {
            if (instType.IsArray)
            {
                var elementType = instType.GetElementType();
                int length = 10;
                var array = Array.CreateInstance(elementType, length);
                for (int i = 0; i < length; i++)
                {
                    Object each = CreateParam(elementType);
                    array.SetValue(each, i);
                }
                return array;
            }
            else if (instType.IsEnum)
            {
                Array values = instType.GetEnumValues();
                return values.GetValue(0);
            }
            else if (instType.IsClass)
            {
                if (instType.Name == "String")
                    return "10";

                if (instType.Name.StartsWith("Optional") && instType.IsGenericType)
                    return CreateOptinal(instType);

                Object obj = Activator.CreateInstance(instType);
                FieldInfo[] files = instType.GetFields();
                int length = files.Length;
                for (int i = 0; i < length; i++)
                {
                    var f = files[i];
                    if (f.MemberType != MemberTypes.Field)
                        continue;

                    object field = CreateParam(f.FieldType);
                    f.SetValue(obj, field);

                }
                return obj;
            }
            else
            {
                switch (instType.Name)
                {
                    case "Boolean":
                        return (bool)true;
                    case "Byte":
                        return (Byte)10;
                    case "Decimal":
                        return (Decimal)10;
                    case "Double":
                        return (Double)10;
                    case "Int16":
                        return (Int16)10;
                    case "Int32":
                        return (Int32)10;
                    case "Int64":
                        return (Int64)10;
                    case "SByte":
                        return (SByte)10;
                    case "Single":
                        return (Single)10;
                    case "UInt16":
                        return (UInt16)10;
                    case "UInt32":
                        return (UInt32)10;
                    case "UInt64":
                        return (UInt64)10;
                    case "IntPtr":
                        return IntPtr.Zero;
                    default:
                        Console.Write(instType.Name);
                        return 10;
                }
            }
        }

        private static Object CreateOptinal(Type instType)
        {
            Object obj = Activator.CreateInstance(instType);
            MethodInfo methodInfo = instType.GetMethod("SetValue");
            ParameterInfo[] args = methodInfo.GetParameters();
            if (args.Length == 1)
            {
                ParameterInfo argInfo = args[0];
                Type argType = argInfo.ParameterType;
                methodInfo.Invoke(obj, new object[] { CreateParam(argType) });
            }
            return obj;
        }


        public static bool Compare<T>(object obj1, object obj2)
        {
            Type instType = typeof(T);
            return Compare(instType, obj1, obj2);
        }

        private static bool Compare(Type instType, object obj1, object obj2)
        {
            if (instType.IsArray)
            {
                var elementType = instType.GetElementType();
                int length1 = (obj1 as Array).Length;
                int length2 = (obj2 as Array).Length;
                if (length1 != length2)
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < length1; i++)
                    {
                        object item1 = (obj1 as Array).GetValue(i);
                        object item2 = (obj2 as Array).GetValue(i);
                        if (Compare(elementType, item1, item2) == false)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            else if (instType.IsEnum)
            {
                return obj1.Equals(obj2);
            }
            else if (instType.IsClass)
            {
                if (instType.Name == "String")
                    return obj1.Equals(obj2);

                if (instType.Name.StartsWith("Optional") && instType.IsGenericType)
                    return CompareOptinal(instType, obj1, obj2);

                FieldInfo[] files = instType.GetFields();
                int length = files.Length;
                for (int i = 0; i < length; i++)
                {
                    var f = files[i];
                    object item1 = f.GetValue(obj1);
                    object item2 = f.GetValue(obj2);
                    if (Compare(f.FieldType, item1, item2) == false)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                switch (instType.Name)
                {
                    case "Boolean":
                    case "Byte":
                    case "Decimal":
                    case "Double":
                    case "Int16":
                    case "Int32":
                    case "Int64":
                    case "SByte":
                    case "Single":
                    case "UInt16":
                    case "UInt32":
                    case "UInt64":
                        return obj1.Equals(obj2);
                    case "IntPtr":
                        return obj1.Equals(obj2);
                    default:
                        Console.Write(instType.Name);
                        return true;
                }
            }
        }

        static private bool CompareOptinal(Type instType, object obj1, object obj2)
        {
            MethodInfo methodInfo = instType.GetMethod("HasValue");
            var hasValue1 = (bool)methodInfo.Invoke(obj1, new object[] { });
            var hasValue2 = (bool)methodInfo.Invoke(obj2, new object[] { });

            if (hasValue1 != hasValue2)
            {
                return false;
            }
            else if (hasValue1 == false)
            {
                return true;
            }
            else
            {

                MethodInfo methodInfo2 = instType.GetMethod("GetValue");
                object value1 = methodInfo2.Invoke(obj1, new object[] { });
                object value2 = methodInfo2.Invoke(obj2, new object[] { });
                return Compare(value1.GetType(), value1, value2);
            }
        }

        public static void InitParam(out RtcEngineContext param)
        {
            string appId = "asdsdsdasda";
            UInt64 context = 0;

            CHANNEL_PROFILE_TYPE channelProfile = CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_COMMUNICATION;
            string license = "sdsd";
            AUDIO_SCENARIO_TYPE audioScenario = AUDIO_SCENARIO_TYPE.AUDIO_SCENARIO_CHATROOM;
            AREA_CODE areaCode = AREA_CODE.AREA_CODE_CN;
            LogConfig logConfig = new LogConfig("/Users/xiayangqun/Documents/agoraSpace/ut.log", 1024, LOG_LEVEL.LOG_LEVEL_INFO);

            param = new RtcEngineContext
            {
                appId = appId,
                context = context,
                channelProfile = channelProfile,
                audioScenario = audioScenario,
                areaCode = areaCode,
                logConfig = logConfig
            };

        }

        public static void InitParam(out Rtm.Internal.RtmConfig param)
        {
            param = new Rtm.Internal.RtmConfig();
            param.appId = "123";
            param.logConfig.filePath = "/Users/xiayangqun/Documents/agoraSpace";
        }

        public static void InitParam(out MessageEvent @event)
        {
            @event = new MessageEvent();
        }

    }



}
