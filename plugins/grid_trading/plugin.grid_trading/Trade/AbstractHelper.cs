using System;
using System.Text;
using System.Runtime.InteropServices;
using Dragonfly.Common.System.Window;
using System.Diagnostics;


namespace Dragonfly.Plugin.GridTrading.Trade
{
    public abstract class AbstractTrader
    {
        internal void Log(Utils.LoggType type, string msg)
        {
            Utils.LoggerUtil.Log(type, msg);
        }

        protected void ClickTreeViewItem(IntPtr hTree, IntPtr hItem)
        {
            Win32API.SendMessage(hTree, Win32Code.TVM_SELECTITEM, Win32Code.TVGN_CARET, hItem);
        }

        /*
        protected string GetItemText(IntPtr hTree, IntPtr hItem)
        {
            var result = new StringBuilder(1024);

            uint vProcessId;
            Win32API.GetWindowThreadProcessId(hTree, out vProcessId);
            var vProcess = Win32API.OpenProcess(
                Win32Code.PROCESS_VM_OPERATION |
                Win32Code.PROCESS_VM_READ |
                Win32Code.PROCESS_VM_WRITE,
                false,
                vProcessId
                );

            var pStrBufferMemory = Win32API.VirtualAllocEx(vProcess,
                                                              IntPtr.Zero,
                                                              1024,
                                                              Win32Code.MEM_COMMIT,
                                                              Win32Code.PAGE_READWRITE);
            var remoteBuffer = Win32API.VirtualAllocEx(vProcess,
                                                          IntPtr.Zero,
                                                          (uint)Marshal.SizeOf(typeof(TVITEM)),
                                                          Win32Code.MEM_COMMIT,
                                                          Win32Code.PAGE_EXECUTE_READWRITE);

            try
            {
                var tvItem = new TVITEM
                {
                    mask = Win32Code.TVIF_TEXT,
                    hItem = hItem,
                    pszText = pStrBufferMemory,
                    cchTextMax = 1024
                };

                IntPtr localBuffer = Marshal.AllocHGlobal(Marshal.SizeOf(tvItem));
                Marshal.StructureToPtr(tvItem, localBuffer, false);

                int vNumberOfBytesWrite;
                Win32API.WriteProcessMemory(
                    vProcess,
                    remoteBuffer,
                    localBuffer,
                    Marshal.SizeOf(typeof(TVITEM)),
                    out vNumberOfBytesWrite);

                Win32API.SendMessage(hTree, Win32Code.TVM_GETITEMA, 0, remoteBuffer.ToInt32());

                int vNumberOfBytesRead;
                Win32API.ReadProcessMemory(
                    vProcess,
                    pStrBufferMemory,
                    result,
                    1024,
                    out vNumberOfBytesRead
                    );


            }
            finally
            {
                Win32API.VirtualFreeEx(vProcess, pStrBufferMemory, 0, Win32Code.MEM_RELEASE);
                Win32API.VirtualFreeEx(vProcess, remoteBuffer, 0, Win32Code.MEM_RELEASE);
                Win32API.CloseHandle(vProcess);
            }

            return result.ToString();
        }
        */

        public string GetTvItemTextEx(IntPtr hTree, IntPtr hItem)
        {
            const int TVIF_TEXT = 0x0001;
            const int MAX_TVITEMTEXT = 512;

            var result = new StringBuilder(1024);

            uint vProcessId;
            Win32API.GetWindowThreadProcessId(hTree, out vProcessId);
            var vProcess = Win32API.OpenProcess(
                Win32Code.PROCESS_VM_OPERATION |
                Win32Code.PROCESS_VM_READ |
                Win32Code.PROCESS_VM_WRITE,
                false,
                vProcessId
                );

 


            var localBuffer = Marshal.AllocHGlobal(512);
            // set address to remote buffer immediately following the tvItem
            var remoteBuffer = Win32API.VirtualAllocEx(vProcess, IntPtr.Zero, 512, Win32Code.MEM_COMMIT, Win32Code.PAGE_READWRITE);
            var nRemoteBufferPtr = remoteBuffer.ToInt64() + Marshal.SizeOf(typeof(TVITEM));

            var tvi = new TVITEM
            {
                mask = TVIF_TEXT,
                hItem = hItem,
                cchTextMax = MAX_TVITEMTEXT,
                pszText = (IntPtr)nRemoteBufferPtr
            };


            int b;
            // copy local tvItem to remote buffer
            var success = Win32API.WriteProcessMemory(vProcess, remoteBuffer, tvi, Marshal.SizeOf(typeof(TVITEM)), out b);
            if (!success)
                throw new SystemException("Failed to write to process memory");

            if (Win32API.SendMessage(hTree,Win32Code.TVM_GETITEMW, IntPtr.Zero, remoteBuffer) == 0)
                // This can occur if the remote process is using an architecture thats incompatible with this process
                return null;

            int a;
            // copy tvItem back into local buffer (copy whole buffer because we don't yet know how big the string is)
            success = Win32API.ReadProcessMemory(vProcess, remoteBuffer, localBuffer,    512, out a);
            if (!success)
                throw new SystemException("Failed to read from process memory");

            var nLocalBufferPtr = localBuffer.ToInt64() + Marshal.SizeOf(typeof(TVITEM));

            return Marshal.PtrToStringUni((IntPtr)nLocalBufferPtr);
        }


        /*

        public string GetTvItemTextEx111(IntPtr hTree, IntPtr hItem)
        {
            const int TVIF_TEXT = 0x0001;
            const int MAX_TVITEMTEXT = 512;

            var result = new StringBuilder(1024);

            uint vProcessId;
            Win32API.GetWindowThreadProcessId(hTree, out vProcessId);
            var vProcess = Win32API.OpenProcess(
                Win32Code.PROCESS_VM_OPERATION |
                Win32Code.PROCESS_VM_READ |
                Win32Code.PROCESS_VM_WRITE,
                false,
                vProcessId
                );

            var pStrBufferMemory = Win32API.VirtualAllocEx(vProcess,
                                                              IntPtr.Zero,
                                                              1024,
                                                              Win32Code.MEM_COMMIT,
                                                              Win32Code.PAGE_READWRITE);
            var remoteBuffer = Win32API.VirtualAllocEx(vProcess,
                                                          IntPtr.Zero,
                                                          (uint)Marshal.SizeOf(typeof(TVITEM)),
                                                          Win32Code.MEM_COMMIT,
                                                          Win32Code.PAGE_EXECUTE_READWRITE);

            try
            {
                var tvItem = new TVITEM
                {
                    mask = Win32Code.TVIF_TEXT,
                    hItem = hItem,
                    pszText = pStrBufferMemory,
                    cchTextMax = 1024
                };

                IntPtr localBuffer = Marshal.AllocHGlobal(Marshal.SizeOf(tvItem));
                Marshal.StructureToPtr(tvItem, localBuffer, false);

                int vNumberOfBytesWrite;
                Win32API.WriteProcessMemory(
                    vProcess,
                    remoteBuffer,
                    localBuffer,
                    Marshal.SizeOf(typeof(TVITEM)),
                    out vNumberOfBytesWrite);

                Win32API.SendMessage(hTree, Win32Code.TVM_GETITEMA, 0, remoteBuffer.ToInt32());

                int vNumberOfBytesRead;
                Win32API.ReadProcessMemory(
                    vProcess,
                    pStrBufferMemory,
                    result,
                    1024,
                    out vNumberOfBytesRead
                    );


            }
            finally
            {
                Win32API.VirtualFreeEx(vProcess, pStrBufferMemory, 0, Win32Code.MEM_RELEASE);
                Win32API.VirtualFreeEx(vProcess, remoteBuffer, 0, Win32Code.MEM_RELEASE);
                Win32API.CloseHandle(vProcess);
            }

            return result.ToString();
        }
        */
        }
}
