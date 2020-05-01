using System;
using System.Runtime.InteropServices;

namespace Dragonfly.Plugin.GridTrading.Utils.Win32
{
    static class XSendMessage
    {
        // Retrieves a string when the reference to a string is embedded as a field
        // within a structure. The lParam to the message is a reference to the struct
        //
        // The parameters are: a pointer the struct and its size.
        //                     a pointer to the pointer to the string to retrieve.
        //                     the max size for the string.
        // Param "hwnd" the Window Handle
        // Param "uMsg" the Windows Message
        // Param "wParam" the Windows wParam
        // Param "lParam" a pointer to a struct allocated on the stack
        // Param "cbSize" the size of the structure
        // Param "pszText" the address of a pointer to a string located with the structure referenced by the lParam
        // Param "maxLength" the size of the string
        // Param "remoteIsWin32" the 32 bit contained within pszText
        internal static string GetTextWithinStructure(IntPtr hwnd, int uMsg, IntPtr wParam, IntPtr lParam, int cbSize, IntPtr pszText, int maxLength, bool remoteIsWin32)
        {
            return GetTextWithinStructureRemoteBitness(
                    hwnd, uMsg, wParam, lParam, cbSize, pszText, maxLength, remoteIsWin32, false);
        }



        // Retrieves a string when the reference to a string is embedded as a field
        // within a structure. The lParam to the message is a reference to the struct
        //
        // The parameters are: a pointer the struct and its size.
        //                     a pointer to the pointer to the string to retrieve.
        //                     the max size for the string.
        // Param "hwnd" the Window Handle
        // Param "uMsg" the Windows Message
        // Param "wParam" the Windows wParam
        // Param "lParam" a pointer to a struct allocated on the stack
        // Param "cbSize" the size of the structure
        // Param "pszText" the address of a pointer to a string located with the structure referenced by the lParam
        // Param "maxLength" the size of the string
        // Param "remoteIsWin32" the 32 bit contained within pszText
        internal static unsafe string GetTextWithinStructureRemoteBitness(IntPtr hwnd, int uMsg, IntPtr wParam, IntPtr lParam, int cbSize,
            IntPtr pszText, int maxLength, bool remoteIsWin32, bool ignoreSendResult)
        {
            using (ProcessHandle hProcess = new ProcessHandle(hwnd))
            {
                if (hProcess.Handle == IntPtr.Zero)
                {
                    return "";
                }

                using (RemoteMemoryBlock rmem = new RemoteMemoryBlock(cbSize + (maxLength + 1) * sizeof(char), hProcess.Handle))
                {
                    if (rmem.Address == IntPtr.Zero)
                    {
                        return "";
                    }

                    // Force the string to be zero terminated

                    IntPtr remoteTextArea = new IntPtr((byte*)rmem.Address.ToPointer() + cbSize);
                    if (remoteIsWin32)
                    {
                        // When the structure will be sent to a 32-bit process,
                        // pszText points to an int, not an IntPtr.
                        // remoteTextArea should be a 32-bit address.
                        System.Diagnostics.Debug.Assert(remoteTextArea.ToInt32() == remoteTextArea.ToInt64());
                        *(int*)((byte*)pszText.ToPointer()) = rmem.Address.ToInt32() + cbSize;
                    }
                    else
                    {
                        *(IntPtr*)((byte*)pszText.ToPointer()) = remoteTextArea;
                    }

                    // Copy the struct to the remote process...
                    rmem.WriteTo(lParam, new IntPtr(cbSize));

                    // Send the message...
                    IntPtr result = Misc.ProxySendMessage(hwnd, uMsg, wParam, rmem.Address);

                    // Nothing, early exit
                    if (!ignoreSendResult && result == IntPtr.Zero)
                    {
                        return "";
                    }

                    // Allocate the buffer for the string
                    char[] achRes = new char[maxLength + 1];

                    // Force the result string not to go past maxLength
                    achRes[maxLength] = '\0';
                    fixed (char* pchRes = achRes)
                    {
                        // Read the string from the common
                        rmem.ReadFrom(new IntPtr((byte*)rmem.Address.ToPointer() + cbSize), new IntPtr(pchRes), new IntPtr(maxLength * sizeof(char)));

                        // Construct the returned string with an explicit length to avoid
                        // a string with an over-allocated buffer, as would occur
                        // if we simply use new string(achRes).
                        int length = 0;
                        for (; achRes[length] != 0 && length < maxLength; length++)
                        {
                        }
                        return new string(achRes, 0, length);
                    }
                }
            }
        }

        internal static bool XSend(IntPtr hwnd, int uMsg, IntPtr wParam, ref string str, int maxLength)
        {
            using (ProcessHandle hProcess = new ProcessHandle(hwnd))
            {
                if (hProcess.Handle == IntPtr.Zero)
                {
                    // assume that the hwnd was bad
                    return false;
                }

                using (RemoteMemoryBlock rmem = new RemoteMemoryBlock(maxLength * sizeof(char), hProcess.Handle))
                {
                    if (rmem.Address == IntPtr.Zero)
                    {
                        return false;
                    }

                    // Send the message...
                    if (Misc.ProxySendMessage(hwnd, uMsg, wParam, rmem.Address) == IntPtr.Zero)
                    {
                        return false;
                    }

                    // Read the string from the remote buffer
                    return rmem.ReadString(out str, maxLength);
                }
            }
        }

        // Main method.  It simply copies an unmamaged buffer to the remote process, sends the message, and then
        // copies the remote buffer back to the local unmanaged buffer.
        internal static bool XSend(IntPtr hwnd, int uMsg, IntPtr wParam, IntPtr ptrStructure, int cbSize)
        {
            using (ProcessHandle hProcess = new ProcessHandle(hwnd))
            {
                if (hProcess.Handle == IntPtr.Zero)
                {
                    return false;
                }

                using (RemoteMemoryBlock rmem = new RemoteMemoryBlock(cbSize, hProcess.Handle))
                {
                    // Ensure proper allocation
                    if (rmem.Address == IntPtr.Zero)
                    {
                        return false;
                    }

                    // Copy the struct to the remote process...
                    rmem.WriteTo(ptrStructure, new IntPtr(cbSize));

                    // Send the message...
                    IntPtr res = Misc.ProxySendMessage(hwnd, uMsg, wParam, rmem.Address);
                    if (res == IntPtr.Zero)
                    {
                        return false;
                    }

                    // Copy returned struct back to local process...
                    rmem.ReadFrom(ptrStructure, new IntPtr(cbSize));
                }
            }

            return true;
        }


        // Main method.  It simply copies an unmamaged buffer to the remote process, sends the message, and then
        // copies the remote buffer back to the local unmanaged buffer.
        internal static bool XSend(IntPtr hwnd, int uMsg, IntPtr ptrStructure, int lParam, int cbSize)
        {
            using (ProcessHandle hProcess = new ProcessHandle(hwnd))
            {
                if (hProcess.Handle == IntPtr.Zero)
                {
                    return false;
                }

                using (RemoteMemoryBlock rmem = new RemoteMemoryBlock(cbSize, hProcess.Handle))
                {
                    // Ensure proper allocation
                    if (rmem.Address == IntPtr.Zero)
                    {
                        return false;
                    }

                    // Copy the struct to the remote process...
                    rmem.WriteTo(ptrStructure, new IntPtr(cbSize));

                    // Send the message...
                    IntPtr res = Misc.ProxySendMessage(hwnd, uMsg, rmem.Address, new IntPtr(lParam));

                    // check the result
                    if (res == IntPtr.Zero)
                    {
                        return false;
                    }

                    // Copy returned struct back to local process...
                    rmem.ReadFrom(ptrStructure, new IntPtr(cbSize));
                }
            }

            return true;
        }



        // Main method.  It simply copies an unmamaged buffer to the remote process, sends the message, and then
        // copies the remote buffer back to the local unmanaged buffer.
        internal static bool XSend2(IntPtr hwnd, int uMsg, IntPtr ptrStructure1, IntPtr ptrStructure2, int cbSize1, int cbSize2)
        {
            using (ProcessHandle hProcess = new ProcessHandle(hwnd))
            {
                if (hProcess.Handle == IntPtr.Zero)
                {
                    return false;
                }

                using (RemoteMemoryBlock rmem1 = new RemoteMemoryBlock(cbSize1, hProcess.Handle))
                {
                    // Ensure proper allocation
                    if (rmem1.Address == IntPtr.Zero)
                    {
                        return false;
                    }

                    using (RemoteMemoryBlock rmem2 = new RemoteMemoryBlock(cbSize2, hProcess.Handle))
                    {
                        // Ensure proper allocation
                        if (rmem2.Address == IntPtr.Zero)
                        {
                            return false;
                        }

                        // Copy the struct to the remote process...
                        rmem1.WriteTo(ptrStructure1, new IntPtr(cbSize1));
                        rmem2.WriteTo(ptrStructure2, new IntPtr(cbSize2));

                        // Send the message...
                        IntPtr res = Misc.ProxySendMessage(hwnd, uMsg, rmem1.Address, rmem2.Address);

                        // check the result
                        if (res == IntPtr.Zero)
                        {
                            return false;
                        }

                        // Copy returned struct back to local process...
                        rmem1.ReadFrom(ptrStructure1, new IntPtr(cbSize1));
                        rmem2.ReadFrom(ptrStructure2, new IntPtr(cbSize2));
                    }
                }
            }

            return true;
        }

        // Main method.  It simply copies an unmamaged buffer to the remote process, sends the message, and then
        // copies the remote buffer back to the local unmanaged buffer.
        internal static int XSendGetIndex(IntPtr hwnd, int uMsg, IntPtr wParam, IntPtr ptrStructure, int cbSize)
        {
            using (ProcessHandle hProcess = new ProcessHandle(hwnd))
            {
                if (hProcess.Handle == IntPtr.Zero)
                {
                    return -1;
                }

                using (RemoteMemoryBlock rmem = new RemoteMemoryBlock(cbSize, hProcess.Handle))
                {
                    if (rmem.Address == IntPtr.Zero)
                    {
                        return -1;
                    }

                    // Copy the struct to the remote process...
                    rmem.WriteTo(ptrStructure, new IntPtr(cbSize));

                    // Send the message...
                    int res = Misc.ProxySendMessageInt(hwnd, uMsg, wParam, rmem.Address);

                    // Copy returned struct back to local process...
                    rmem.ReadFrom(ptrStructure, new IntPtr(cbSize));

                    return res;
                }
            }
        }


    }

}

