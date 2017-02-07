using System;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Dragonfly.Common.Utils
{
    public static class WindowUtils
    {
        public delegate int EnumWindowsProc(IntPtr hwnd, IntPtr lParam);

        /// <summary>
        /// The EnumWindows function enumerates all top-level windows on the screen by passing the handle to each window, 
        /// in turn, to an application-defined callback function. EnumWindows continues until the last top-level window 
        /// is enumerated or the callback function returns FALSE.
        /// </summary>
        /// <param name="enumWindowsProc">[in] Pointer to an application-defined callback function. For more information, see EnumWindowsProc. </param>
        /// <param name="lParam">[in] Specifies an application-defined value to be passed to the callback function. </param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. 
        /// To get extended error information, call GetLastError. If EnumWindowsProc returns zero, the return value is also zero. 
        /// In this case, the callback function should call SetLastError to obtain a meaningful error code to be returned to the 
        /// caller of EnumWindows.
        /// </returns>
        /// <remarks>
        /// The EnumWindows function does not enumerate child windows, with the exception of a few top-level windows owned 
        /// by the system that have the WS_CHILD style. This function is more reliable than calling the GetWindow function 
        /// in a loop. An application that calls GetWindow to perform this task risks being caught in an infinite loop or 
        /// referencing a handle to a window that has been destroyed. 
        /// </remarks>
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int EnumWindows(IntPtr lpEnumFunc, uint lParam);

        public static int EnumWindows(EnumWindowsProc enumWindowsProc, uint lParam)
        {
            IntPtr callbackDelegatePointer = Marshal.GetFunctionPointerForDelegate(enumWindowsProc);
            return EnumWindows(callbackDelegatePointer, lParam);
        }

        public static int EnumWindows(EnumWindowsProc enumWindowsProc)
        {
            return EnumWindows(enumWindowsProc, 0);
        }

        /// <summary>
        /// The SetForegroundWindow function puts the thread that created the specified window into the foreground and activates 
        /// the window. Keyboard input is directed to the window, and various visual cues are changed for the user. The system 
        /// assigns a slightly higher priority to the thread that created the foreground window than it does to other threads. 
        /// </summary>
        /// <param name="hWnd">[in] Handle to the window that should be activated and brought to the foreground. </param>
        /// <returns>If the window was brought to the foreground, the return value is nonzero. If the window was not brought to the foreground, 
        /// the return value is zero. 
        /// </returns>
        /// <remarks>
        /// The foreground window is the window at the top of the Z-Order. It is the window that the user is working with. In a preemptive 
        /// multitasking environment, you should generally let the user control which window is the foreground window. 
        /// </remarks>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Returns true if the given control contains the handle
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public static bool ContainsHandle(IntPtr handle, Control control)
        {
            if (control.Handle == handle) { return true; }
            else { return ContainsHandle(handle, control.Controls); }
        }

        /// <summary>
        /// Returns true if the control collection contains the given handle
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="controls"></param>
        /// <returns></returns>
        public static bool ContainsHandle(IntPtr handle, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control.Handle == handle) { return true; }
                if (ContainsHandle(handle, control.Controls)) { return true; }
            }

            return false;
        }

        /// <summary>
        /// Returns the Control whose hWnd matches the provided handle and is
        /// within the provided container
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public static Control FindWindow(IntPtr handle, Control container)
        {
            if (handle == container.Handle) { return container; }
            else { return FindWindow(handle, container.Controls); }
        }

        /// <summary>
        /// Returns the Control corresponding to the handle in the provided
        /// control collection
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="controls"></param>
        /// <returns></returns>
        public static Control FindWindow(IntPtr handle, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control.Handle == handle) { return control; }

                Control c = FindWindow(handle, control.Controls);
                if (c != null) { return c; }
            }

            return null;
        }

        /// <summary>
        /// This function retrieves the handle to the top-level window whose class name and window name match the specified strings. 
        /// This function does not search child windows. 
        /// </summary>
        /// <param name="lpClassName">Long pointer to a null-terminated string that specifies the class name or is an atom that
        /// identifies the class-name string. If this parameter is an atom, it must be a global atom 
        /// created by a previous call to the GlobalAddAtom function. The atom, a 16-bit value, must be 
        /// placed in the low-order word of lpClassName; the high-order word must be zero. </param>
        /// <param name="lpWindowName">Long pointer to a null-terminated string that specifies the window name (the window's title).
        /// If this parameter is NULL, all window names match. </param>
        /// <returns>A handle to the window that has the specified class name and window name indicates success. NULL indicates failure. 
        /// To get extended error information, call GetLastError. </returns>
        /// <remarks>
        /// If lpClassName is an atom, it must be an atom returned from RegisterClass. 
        /// </remarks>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// This function retrieves the handle to the top-level window whose window name match the specified strings. 
        /// This function does not search child windows. 
        /// </summary>
        /// <param name="windowTitle"></param>
        /// <returns></returns>
        public static IntPtr FindWindow(string windowTitle)
        {
            return FindWindow(null, windowTitle);
        }

        /// <summary>
        /// This function destroys the specified window. The function sends a WM_DESTROY message to the window to 
        /// deactivate it and removes the keyboard focus from it. The function also destroys the window's menu, 
        /// destroys timers, removes clipboard ownership, and breaks the clipboard viewer chain (if the window 
        /// is at the top of the viewer chain).
        /// 
        /// If the specified window is a parent or owner window, DestroyWindow automatically destroys the associated 
        /// child or owned windows when it destroys the parent or owner window. The function first destroys child or 
        /// owned windows, and then it destroys the parent or owner window.
        /// 
        /// DestroyWindow also destroys modeless dialog boxes created by the CreateDialog function.
        /// </summary>
        /// <param name="hWnd">[in] Handle to the window to be destroyed.</param>
        /// <returns>0 if the window is destroyed, otherwise non-zero</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr DestroyWindow(IntPtr hWnd);

        /// <summary>
        /// This function returns a handle to the desktop window. The desktop window covers the entire screen. The desktop window is 
        /// the area on top of which all icons and other windows are painted. 
        /// </summary>
        /// <returns>The return value is a handle to the desktop window.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDesktopWindow();

        public static void PrintWindowHandles(Control control)
        {
            Debug.WriteLine(String.Format("Name: {0} Type: {1} Handle: {2}", control.Name, control.GetType().FullName, control.Handle));
            PrintWindowHandles(control.Controls);
        }

        public static void PrintWindowHandles(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                Debug.WriteLine(String.Format("Name: {0} Type: {1} Handle: {2}", control.Name, control.GetType().FullName, control.Handle));
                PrintWindowHandles(control.Controls);
            }
        }

        public static void PrintWindowHandles(IntPtr hWnd)
        {
            string s = GetWindowString(hWnd);
            Debug.WriteLine(s);
            IntPtr childHWnd = GetChildWindow(hWnd);
            if (childHWnd != IntPtr.Zero)
            {
                PrintWindowHandles(childHWnd);
            }

            IntPtr nextHWnd = GetWindow(hWnd, GetWindowConstants.GW_HWNDNEXT);
            if (nextHWnd != IntPtr.Zero)
            {
                PrintWindowHandles(nextHWnd);
            }
        }

        private static string GetWindowString(IntPtr hWnd)
        {
            string title = GetWindowText(hWnd);
            string className = GetWindowClassName(hWnd);
            StringBuilder sb = new StringBuilder();
            sb.Append("Handle=");
            sb.Append(string.Format("{0:X2}", hWnd.ToInt32()));
            sb.Append("|Title=");
            sb.Append(title);
            sb.Append("|ClassName=");
            sb.Append(className);
            return sb.ToString();
        }

        public static void FindAndPrintFocusedControl(Control control)
        {
            Control controlFocused = FindFocusedControl(control);
            if (controlFocused == null)
            {
                Debug.WriteLine(
                    String.Format("Could not find any focused controls in Name: {0} Type: {1} Handle: {2} or any of its children",
                        control.Name, control.GetType().FullName, control.Handle));
            }
            else
            {
                Debug.WriteLine(
                    String.Format("Focused control: Name: {0} Type: {1} Handle: {2}",
                        controlFocused.Name, controlFocused.GetType().FullName, controlFocused.Handle));
            }
        }

        public static Control FindFocusedControl(Control control)
        {
            if (control.Focused) { return control; }
            else { return FindFocusedControl(control.Controls); }
        }

        public static Control FindFocusedControl(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control.Focused) { return control; }

                Control c = FindFocusedControl(control.Controls);
                if (c != null) { return c; }
            }
            return null;
        }

        /// <summary>
        /// The GetForegroundWindow function returns a handle to the foreground window (the window with which the user is currently working). 
        /// The system assigns a slightly higher priority to the thread that creates the foreground window than it does to other threads. 
        /// </summary>
        /// <returns>The return value is a handle to the foreground window. The foreground window can be NULL in certain circumstances, 
        /// such as when a window is losing activation. </returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// The GetWindowText function copies the text of the specified window's title bar (if it has one) into a buffer. 
        /// If the specified window is a control, the text of the control is copied. However, GetWindowText cannot retrieve 
        /// the text of a control in another application.
        /// </summary>
        /// <param name="hWnd">[in] Handle to the window or control containing the text.</param>
        /// <param name="lpString">[out] Pointer to the buffer that will receive the text. If the string is as long or longer than the buffer, 
        /// the string is truncated and terminated with a NULL character. </param>
        /// <param name="nMaxCount">[in] Specifies the maximum number of characters to copy to the buffer, including the NULL character. 
        /// If the text exceeds this limit, it is truncated. </param>
        /// <returns>If the function succeeds, the return value is the length, in characters, of the copied string, not including 
        /// the terminating NULL character. If the window has no title bar or text, if the title bar is empty, or if the window 
        /// or control handle is invalid, the return value is zero. To get extended error information, call GetLastError. 
        /// This function cannot retrieve the text of an edit control in another application.
        /// </returns>
        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        public static string GetWindowText(IntPtr hWnd)
        {
            return GetWindowText(hWnd, 1000);
        }

        public static string GetWindowText(IntPtr hWnd, int nMaxCount)
        {
            StringBuilder sb = new StringBuilder(nMaxCount);
            GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        public static string GetWindowClassName(IntPtr hWnd)
        {
            return GetClassName(hWnd, 1000);
        }

        public static string GetClassName(IntPtr hWnd, int nMaxCount)
        {
            StringBuilder sb = new StringBuilder(nMaxCount);
            GetClassName(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
        /// <summary>
        /// The GetWindow function retrieves a handle to a window that has the specified relationship (Z-Order or owner) to the specified window. 
        /// </summary>
        /// <param name="hWnd">[in] Handle to a window. The window handle retrieved is relative to this window, based on the value of the uCmd parameter. </param>
        /// <param name="uCmd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

        public static IntPtr GetChildWindow(IntPtr hWnd)
        {
            return GetWindow(hWnd, GetWindowConstants.GW_CHILD);
        }


        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

        //[DllImport("user32.dll", SetLastError = true)]
        //public static extern int SetWindowLong(IntPtr hWnd, int nIndex, WndProcDelegate newProc);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr newProc);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);


        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <author>Jon Froehlich</author>
    public static class GetWindowConstants
    {
        // Flags for GetWindow() api 
        // found in winuser.h
        public static uint GW_HWNDFIRST = 0;
        public static uint GW_HWNDLAST = 1;
        public static uint GW_HWNDNEXT = 2;
        public static uint GW_HWNDPREV = 3;
        public static uint GW_OWNER = 4;
        public static uint GW_CHILD = 5;
        public static uint GW_MAX = 5;
    }

}
