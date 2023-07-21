#define AGORA_RTC
#define AGORA_RTM
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;

#if AGORA_RTC
using Agora.Rtc;
#elif AGORA_RTM
using Agora.Rtm;
#endif

namespace Agora.Rtm.Internal
{
    using IrisApiRtmEnginePtr = IntPtr;
    using IrisEventHandlerHandle = IntPtr;
    using IrisEventHandlerMarshal = IntPtr;

    internal static class AgoraRtmNative
    {

#if AGORA_RTC
        private const string AgoraRtmLibName = Agora.Rtc.AgoraRtcNative.AgoraRtcLibName;
#elif AGORA_RTM
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        private const string AgoraRtmLibName = "AgoraRtmWrapper";
#elif UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
        private const string AgoraRtmLibName = "AgoraRtmWrapperUnity";
#elif UNITY_IPHONE
		private const string AgoraRtmLibName = "__Internal";
#else
        private const string AgoraRtmLibName = "AgoraRtmWrapper";
#endif

#endif
        [DllImport(AgoraRtmLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr CreateIrisRtmEngine(IntPtr client);

        [DllImport(AgoraRtmLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyIrisRtmEngine(IntPtr handle);

        [DllImport(AgoraRtmLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisRtmApi(IntPtr handle, ref IrisRtmApiParam param);

        [DllImport(AgoraRtmLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisEventHandlerHandle CreateIrisRtmEventHandler(IrisEventHandlerMarshal event_Handler);

        [DllImport(AgoraRtmLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyIrisRtmEventHandler(IrisEventHandlerHandle handle);

        [DllImport(AgoraRtmLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr GetIrisRtmErrorReason(int err_code);

        internal static void AllocEventHandlerHandle(ref RtmEventHandlerHandle eventHandlerHandle, Rtm_Func_Event_Native onEvent)
        {
            eventHandlerHandle.cEvent = new IrisRtmCEventHandler
            {
                OnEvent = onEvent,
            };

            var cEventHandlerNativeLocal = new IrisRtmCEventHandlerNative
            {
                onEvent = Marshal.GetFunctionPointerForDelegate(eventHandlerHandle.cEvent.OnEvent),
            };

            eventHandlerHandle.marshal = Marshal.AllocHGlobal(Marshal.SizeOf(cEventHandlerNativeLocal));
            Marshal.StructureToPtr(cEventHandlerNativeLocal, eventHandlerHandle.marshal, true);
            eventHandlerHandle.handle = AgoraRtmNative.CreateIrisRtmEventHandler(eventHandlerHandle.marshal);
        }

        internal static void FreeEventHandlerHandle(ref RtmEventHandlerHandle eventHandlerHandle)
        {
            AgoraRtmNative.DestroyIrisRtmEventHandler(eventHandlerHandle.handle);
            eventHandlerHandle.handle = IntPtr.Zero;

            Marshal.FreeHGlobal(eventHandlerHandle.marshal);
            eventHandlerHandle.marshal = IntPtr.Zero;
            eventHandlerHandle.cEvent = new IrisRtmCEventHandler();
        }

        internal static int CallIrisRtmApiWithArgs(IrisApiRtmEnginePtr engine_ptr, string func_name,
            string @params, UInt32 paramLength, IntPtr buffer, uint buffer_count, ref IrisRtmApiParam apiParam,
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
            int retval = AgoraRtmNative.CallIrisRtmApi(engine_ptr, ref apiParam);

            if (lengthPtr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(lengthPtr);
            }

            return retval;
        }
    }


    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate void Rtm_Func_Event_Native(IntPtr param);


    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisRtmCEventHandlerNative
    {
        internal IntPtr onEvent;
    }

    internal struct IrisRtmCEventHandler
    {
        internal Rtm_Func_Event_Native OnEvent;
    }

    internal struct RtmEventHandlerHandle
    {
        internal IrisRtmCEventHandler cEvent;
        internal IrisEventHandlerMarshal marshal;
        internal IrisEventHandlerHandle handle;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisCRtmEventParam
    {
        internal string @event;
        internal string data;
        internal uint data_size;
        internal IntPtr result;
        internal uint result_size;
        internal IntPtr buffer;
        internal IntPtr length;
        internal uint buffer_count;
    }

    internal enum IrisLogLevel
    {
        levelTrace = 0,
        levelDebug = 1,
        levelInfo = 2,
        levelWarn = 3,
        levelErr = 4,
    };

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisEngineParam
    {
        internal string log_path;
        internal string log_name;
        internal IrisLogLevel log_level;
    };

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisApiEngineParam
    {
        internal string log_path;
        internal IrisLogLevel log_level;
    };

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisRtmApiParam
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

    //[StructLayout(LayoutKind.Sequential)]
    //internal struct IrisCApiParam
    //{
    //    internal IrisCApiParam(int param = 0)
    //    {
    //        @event = "";
    //        data = "";
    //        data_size = 0;
    //        result = new byte[65536];
    //        buffer = IntPtr.Zero;
    //        length = IntPtr.Zero;
    //        buffer_count = 0;
    //    }

    //    public string Result
    //    {
    //        get
    //        {
    //            var re = Encoding.UTF8.GetString(result);
    //            var index = re.IndexOf('\0');
    //            return re.Substring(0, index);
    //        }
    //    }

    //    internal string @event;
    //    internal string data;
    //    internal uint data_size;
    //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65536)]
    //    internal byte[] result;

    //    internal IntPtr buffer;
    //    internal IntPtr length;
    //    internal uint buffer_count;
    //}

    internal class MessageEventInternal
    {
        public RTM_CHANNEL_TYPE channelType;

        public RTM_MESSAGE_TYPE messageType;

        public string channelName;

        public string channelTopic;

        public UInt64 message;

        public uint messageLength;

        public string publisher;

        public string customType;

        public MessageEvent GenerateMessageEvent()
        {
            MessageEvent messageEvent = new MessageEvent();
            messageEvent.channelType = this.channelType;
            messageEvent.messageType = this.messageType;
            messageEvent.channelName = this.channelName;
            messageEvent.channelTopic = this.channelTopic;
            messageEvent.messageLength = this.messageLength;
            messageEvent.publisher = this.publisher;
            messageEvent.customType = this.customType;
            return messageEvent;
        }
    };

}