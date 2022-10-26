using System;
using System.Runtime.InteropServices;

namespace ut
{
    public class DLLHelper
    {
        private const string  DebugLibName = "libName";

        [DllImport(DebugLibName, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr CreateDebugApiEngine();
    }
}
