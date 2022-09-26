using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Agora.Rtm
{
    using IrisApiRtmEnginePtr = IntPtr;
    using IrisEventHandlerHandle = IntPtr;
    using IrisEventHandlerMarshal = IntPtr;

    internal static class AgoraRtmNative
    {
        #region DllImport

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        private const string AgoraRtmLibName = "AgoraRtmWrapper";
#elif UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
        private const string AgoraRtmLibName = "AgoraRtmWrapperUnity";
#elif UNITY_IPHONE
		private const string AgoraRtmLibName = "__Internal";
#else
        private const string AgoraRtmLibName = "AgoraRtmWrapper";
#endif

        [DllImport(AgoraRtmLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisApiRtmEnginePtr CreateIrisRtmEngine(IntPtr engine);

        [DllImport(AgoraRtmLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyIrisRtmEngine(IrisApiRtmEnginePtr engine);

        [DllImport(AgoraRtmLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisRtmApi(IrisApiRtmEnginePtr engine_ptr, ref IrisCApiParam @param);

        internal static int CallIrisApiWithArgs(IrisApiRtmEnginePtr engine_ptr, string func_name,
            string @params, UInt32 paramLength, IntPtr buffer, uint buffer_count, ref IrisCApiParam apiParam,
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
            int retval = CallIrisRtmApi(engine_ptr, ref apiParam);

            if (lengthPtr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(lengthPtr);
            }

            return retval;
        }

        [DllImport(AgoraRtmLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisEventHandlerHandle CreateIrisEventHandler(IntPtr event_handler);

        [DllImport(AgoraRtmLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyIrisEventHandler(IrisEventHandlerHandle handler);

        #endregion
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
            eventHandlerHandle.handle = AgoraRtmNative.CreateIrisEventHandler(eventHandlerHandle.marshal);
        }

        internal static void FreeEventHandlerHandle(ref EventHandlerHandle eventHandlerHandle)
        {
            AgoraRtmNative.DestroyIrisEventHandler(eventHandlerHandle.handle);
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

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate void Func_Event_Native(IntPtr param);

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

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisCEventHandlerNative
    {
        internal IntPtr onEvent;
    }

    internal struct IrisCEventHandler
    {
        internal Func_Event_Native OnEvent;
    }

    internal struct EventHandlerHandle
    {
        internal IrisCEventHandler cEvent;
        internal IrisEventHandlerMarshal marshal;
        internal IrisEventHandlerHandle handle;
    }
}