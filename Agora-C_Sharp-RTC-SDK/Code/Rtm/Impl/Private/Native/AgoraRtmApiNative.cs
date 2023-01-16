using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;

namespace Agora.Rtm
{
    using IrisApiRtmEnginePtr = IntPtr;
    using IrisEventHandlerHandle = IntPtr;

    internal static class AgoraRtmNative
    {
        internal static IrisApiRtmEnginePtr CreateIrisRtmEngine(IntPtr engine)
        {
            IrisEngineParam irisEngineParam;
            irisEngineParam.log_name = "";
            irisEngineParam.log_path = "";
            irisEngineParam.log_level = IrisLogLevel.levelTrace;
            AgoraApiNative.InitializeIrisEngine(ref irisEngineParam);

            return Agora.AgoraApiNative.CreateIrisApiEngine(Agora.AgoraApiType.IRIS_API_ENGINE_RTM);
        }


        internal static void DestroyIrisRtmEngine(IrisApiRtmEnginePtr engine)
        {
            Agora.AgoraApiNative.DestroyIrisApiEngine(engine);
        }


        internal static int CallIrisApiWithArgs(IrisApiRtmEnginePtr engine_ptr, string func_name,
            string @params, UInt32 paramLength, IntPtr buffer, uint buffer_count, ref IrisApiParam apiParam,
            uint buffer0Length = 0, uint buffer1Length = 0, uint buffer2Length = 0)
        {
            apiParam.@event = func_name;
            apiParam.data = @params;
            apiParam.data_size = paramLength;
            apiParam.buffer = buffer;
            apiParam.buffer_count = buffer_count;

            IntPtr lengthPtr = IntPtr.Zero;
            if (buffer_count > 0)
            {
                int[] lengths = new int[3];
                lengths[0] = (int)buffer0Length;
                lengths[1] = (int)buffer1Length;
                lengths[2] = (int)buffer2Length;
                lengthPtr = Marshal.AllocHGlobal(lengths.Length * sizeof(int));
                Marshal.Copy(lengths, 0, lengthPtr, (int)lengths.Length);
            }
            apiParam.length = lengthPtr;
            int retval = Agora.AgoraApiNative.CallIrisApi(engine_ptr, ref apiParam);

            if (lengthPtr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(lengthPtr);
            }

            return retval;
        }


        internal static IrisEventHandlerHandle CreateIrisRtmEventHandler(IrisApiRtmEnginePtr engine_ptr, IntPtr event_handler)
        {

            IrisApiParam apiParam = new IrisApiParam();
            apiParam.AllocResult();
            Dictionary<string, System.Object> _param = new Dictionary<string, System.Object>();


            _param.Add("cEventHandler", (UInt64)event_handler);
            var json = Agora.Rtc.AgoraJson.ToJson(_param);

            IntPtr[] arrayPtr = new IntPtr[] { event_handler };


            int nRet = CallIrisApiWithArgs(engine_ptr, Agora.AgoraApiType.FUNC_APIENGINE_CREATEEVENTHANDLER,
                     json, (uint)json.Length,
                     Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                     ref apiParam);

            if (nRet == 0)
            {
                IrisEventHandlerHandle eventHandler = (IntPtr)(UInt64)Agora.Rtc.AgoraJson.GetData<UInt64>(apiParam.Result, "eventHandler");
                apiParam.FreeResult();
                return eventHandler;
            }
            else
            {
                apiParam.FreeResult();
                return IntPtr.Zero;
            }
        }


        internal static void DestroyIrisRtmEventHandler(IrisApiRtmEnginePtr engine_ptr, IrisEventHandlerHandle handler)
        {
            IrisApiParam apiParam = new IrisApiParam();
            apiParam.AllocResult();
            Dictionary<string, System.Object> _param = new Dictionary<string, System.Object>();


            _param.Add("eventHandler", (UInt64)handler);
            var json = Agora.Rtc.AgoraJson.ToJson(_param);
            IntPtr[] arrayPtr = new IntPtr[] { handler };


            int nRet = CallIrisApiWithArgs(engine_ptr, Agora.AgoraApiType.FUNC_APIENGINE_DESTROYEVENTHANDLER,
                     json, (uint)json.Length,
                     Marshal.UnsafeAddrOfPinnedArrayElement(arrayPtr, 0), 1,
                     ref apiParam);

            apiParam.FreeResult();
        }
    }

    internal class AgoraUtil
    {

        internal static void AllocEventHandlerHandle(ref EventHandlerHandle eventHandlerHandle, Func_Event_Native onEvent, IntPtr enginePtr)
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
            eventHandlerHandle.handle = AgoraRtmNative.CreateIrisRtmEventHandler(enginePtr, eventHandlerHandle.marshal);
        }

        internal static void FreeEventHandlerHandle(ref EventHandlerHandle eventHandlerHandle, IntPtr enginePtr)
        {
            AgoraRtmNative.DestroyIrisRtmEventHandler(enginePtr, eventHandlerHandle.handle);
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




    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisCApiParam
    {
        internal IrisCApiParam(int param = 0)
        {
            @event = "";
            data = "";
            data_size = 0;
            result = new byte[65536];
            buffer = IntPtr.Zero;
            length = IntPtr.Zero;
            buffer_count = 0;
        }

        public string Result
        {
            get
            {
                var re = Encoding.UTF8.GetString(result);
                var index = re.IndexOf('\0');
                return re.Substring(0, index);
            }
        }

        internal string @event;
        internal string data;
        internal uint data_size;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65536)]
        internal byte[] result;

        internal IntPtr buffer;
        internal IntPtr length;
        internal uint buffer_count;
    }



    internal class JoinTopicOptionsInternal
    {
        public JoinTopicOptionsInternal(JoinTopicOptions joinTopicOptions)
        {
            this.qos = joinTopicOptions.qos;
            this.priority = joinTopicOptions.priority;
            this.metaLength = joinTopicOptions.metaLength;
            this.syncWithMedia = joinTopicOptions.syncWithMedia;
        }


        public RTM_MESSAGE_QOS qos;

        public RTM_MESSAGE_PRIORITY priority;

        //public byte[] meta;

        public UInt64 metaLength;

        public bool syncWithMedia;
    }


    internal class MessageEventInternal
    {
        public RTM_CHANNEL_TYPE channelType;

        public string channelName;

        public string channelTopic;

        public UInt64 message;

        public uint messageLength;

        public string publisher;

        public MessageEvent GenerateMessageEvent()
        {
            MessageEvent messageEvent = new MessageEvent();
            messageEvent.channelType = this.channelType;
            messageEvent.channelName = this.channelName;
            messageEvent.channelTopic = this.channelTopic;
            messageEvent.messageLength = this.messageLength;
            messageEvent.publisher = this.publisher;
            return messageEvent;
        }
    };

}