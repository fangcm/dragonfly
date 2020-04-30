using System;

namespace Dragonfly.Plugin.GridTrading.Utils.Win32
{
    public sealed class ProcessHandle : IDisposable
    {
        IntPtr handle = IntPtr.Zero;

        internal ProcessHandle(IntPtr hwnd)
        {
            uint processId;

            if (hwnd != IntPtr.Zero)
            {
                UnsafeNativeMethods.GetWindowThreadProcessId(hwnd, out processId);
            }
            else
            {
                processId = UnsafeNativeMethods.GetCurrentProcessId();
            }

            if (processId == 0)
            {
                return;
            }

            // handle might be used to query for Wow64 information (_QUERY_), or to do cross-process allocs (VM_*)
            handle = UnsafeNativeMethods.OpenProcess(NativeMethods.PROCESS_QUERY_INFORMATION | NativeMethods.PROCESS_VM_OPERATION |
                            NativeMethods.PROCESS_VM_READ | NativeMethods.PROCESS_VM_WRITE, false, processId);

        }

        internal IntPtr Handle
        {
            get
            {
                return handle;
            }
        }


        public void Dispose()
        {
            UnsafeNativeMethods.CloseHandle(handle);
        }
    }
}
