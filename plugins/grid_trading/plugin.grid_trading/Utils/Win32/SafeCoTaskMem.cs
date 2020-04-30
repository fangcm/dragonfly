using System;
using System.Runtime.InteropServices;

namespace Dragonfly.Plugin.GridTrading.Utils.Win32
{
    internal sealed class SafeCoTaskMem : IDisposable
    {
        private IntPtr handle;
        // This constructor is used by the P/Invoke marshaling layer
        // to allocate a SafeHandle instance.  P/Invoke then does the
        // appropriate method call, storing the handle in this class.
        private SafeCoTaskMem() { }

        internal SafeCoTaskMem(int length)
        {
            handle = (Marshal.AllocCoTaskMem(length * sizeof(char)));
        }

        internal string GetStringAuto()
        {
            return Marshal.PtrToStringAuto(handle);
        }

        internal string GetStringUni(int length)
        {
            // Convert the local unmanaged buffer in to a string object
            return Marshal.PtrToStringUni(handle, length);
        }

        public void Dispose()
        {
            Marshal.FreeCoTaskMem(handle);
        }
    }

}
