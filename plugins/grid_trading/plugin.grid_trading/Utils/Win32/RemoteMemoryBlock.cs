using System;

namespace Dragonfly.Plugin.GridTrading.Utils.Win32
{

    class RemoteMemoryBlock : IDisposable
    {
        private IntPtr _processHandle; // Handle of remote process
        protected IntPtr handle;

        private RemoteMemoryBlock() { }

        internal IntPtr Address
        {
            get
            {
                return handle;
            }
        }

        public void Dispose()
        {
            UnsafeNativeMethods.VirtualFreeEx(_processHandle, handle, UIntPtr.Zero, UnsafeNativeMethods.MEM_RELEASE);
        }

        internal RemoteMemoryBlock(int cbSize, IntPtr processHandle)
        {
            _processHandle = processHandle;
            handle = UnsafeNativeMethods.VirtualAllocEx(_processHandle, IntPtr.Zero, new UIntPtr((uint)cbSize), UnsafeNativeMethods.MEM_COMMIT, UnsafeNativeMethods.PAGE_READWRITE);
        }

        internal IntPtr WriteTo(IntPtr sourceAddress, IntPtr cbSize)
        {
            IntPtr count;
            UnsafeNativeMethods.WriteProcessMemory(_processHandle, handle, sourceAddress, cbSize, out count);
            return count;
        }

        internal IntPtr ReadFrom(IntPtr remoteAddress, IntPtr destAddress, IntPtr cbSize)
        {
            IntPtr count;
            UnsafeNativeMethods.ReadProcessMemory(_processHandle, remoteAddress, destAddress, cbSize, out count);
            return count;
        }

        internal IntPtr ReadFrom(SafeCoTaskMem destAddress, IntPtr cbSize)
        {
            IntPtr count;
            UnsafeNativeMethods.ReadProcessMemory(_processHandle, handle, destAddress, cbSize, out count);
            return count;
        }
        internal IntPtr ReadFrom(IntPtr destAddress, IntPtr cbSize)
        {
            IntPtr count;
            UnsafeNativeMethods.ReadProcessMemory(_processHandle, handle, destAddress, cbSize, out count);
            return count;
        }

        // Helper function to handle common scenario of translating a remote
        // unmanaged char/wchar buffer in to a managed string object.
        internal bool ReadString(out string str, int maxLength)
        {
            // Clear the return string
            str = null;

            // Ensure there is a buffer size
            if (0 >= maxLength)
            {
                return false;
            }

            // Ensure proper allocation
            using (SafeCoTaskMem ptr = new SafeCoTaskMem(maxLength))
            {
                // Copy remote buffer back to local process...
                ReadFrom(ptr, new IntPtr(maxLength * sizeof(char)));

                // Convert the local unmanaged buffer in to a string object
                str = ptr.GetStringUni(maxLength);

                // Note: lots of "old world" strings are null terminated
                // Leaving the null termination in the System.String may lead
                // to some issues when used with the StringBuilder
                int nullTermination = str.IndexOf('\0');

                if (-1 != nullTermination)
                {
                    // We need to strip null terminated char and everything behind it from the str
                    str = str.Remove(nullTermination, maxLength - nullTermination);
                }

                return true;
            }
        }

    }

}
