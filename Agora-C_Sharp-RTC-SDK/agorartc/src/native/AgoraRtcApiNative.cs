//  AgoraFpaApiNative.cs
//
//  Created by YuGuo Chen on September 26, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;
using System.Runtime.InteropServices;

namespace agora.fpa
{
    using IrisFpaProxyServicePtr = IntPtr;
    using IrisEventHandlerHandle = IntPtr;

    internal static class AgoraFpaNative
    {
        #region DllImport

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        private const string AgoraFpaLibName = "AgoraFpaWrapper";
#elif UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
        private const string AgoraFpaLibName = "AgoraFpaWrapperUnity";
#elif UNITY_IPHONE
		private const string AgoraFpaLibName = "__Internal";
#else
        private const string AgoraFpaLibName = "AgoraFpaWrapper";
#endif

// IrisFpaEngine
        [DllImport(AgoraFpaLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisFpaProxyServicePtr CreateIrisFpaProxyService();

        [DllImport(AgoraFpaLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void DestroyIrisFpaProxyService(IrisFpaProxyServicePtr service_ptr);

        [DllImport(AgoraFpaLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IrisEventHandlerHandle SetIrisFpaProxyServiceEventHandler(IrisFpaProxyServicePtr service_ptr,
            IntPtr event_handler);

        [DllImport(AgoraFpaLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void UnsetIrisFpaProxyServiceEventHandler(IrisFpaProxyServicePtr service_ptr,
            IrisEventHandlerHandle handle);

        [DllImport(AgoraFpaLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisFpaProxyServiceApi(IrisFpaProxyServicePtr service_ptr, ApiTypeProxyService api_type,
            string @params, out CharAssistant result);

        [DllImport(AgoraFpaLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CallIrisFpaProxyServiceApiWithBuffer(IrisFpaProxyServicePtr service_ptr, ApiTypeProxyService api_type,
            string @params, byte[] buffer, out CharAssistant result);

        #endregion

    }
}