using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Dragonfly.Common.System.Window
{
    /// <summary>
    /// Windows API Functions
    /// </summary>
    public class Win32API
    {
        #region .ctor()
        // No need to construct this object
        private Win32API()
        {
        }
        #endregion

        #region CallBacks
        public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        #endregion

        #region Kernel32.dll functions
        [DllImport("kernel32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetCurrentThreadId();

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(uint desiredAccess, bool isInheritHandle, uint processId);

        /// <summary>
        /// 从指定内存中读取字节集数据
        /// </summary>
        /// <param name="handle">进程句柄</param>
        /// <param name="address">内存地址</param>
        /// <param name="data">数据存储变量</param>
        /// <param name="size">长度</param>
        /// <param name="read">读取长度</param>
        [DllImport("Kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr handle, IntPtr address, IntPtr data, int size, out int read);
        [DllImport("Kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr handle, IntPtr address, StringBuilder data, int size, out int read);

        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref IntPtr lpBuffer, int nSize, out int vNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int nSize, out int vNumberOfBytesRead);

        /// <summary>
        /// VirtualAllocEx 函数的作用是在指定进程的虚拟空间保留或提交内存区域，除非指定MEM_RESET参数，否则将该内存区域置0。
        /// </summary>
        /// <param name="hProcess">申请内存所在的进程句柄。</param>
        /// <param name="address">保留页面的内存地址；一般用NULL自动分配 </param>
        /// <param name="size">欲分配的内存大小，字节单位；注意实际分 配的内存大小是页内存大小的整数倍</param>
        /// <param name="allocationType">
        /// MEM_COMMIT：为特定的页面区域分配内存中或磁盘的页面文件中的物理存储
        /// MEM_PHYSICAL ：分配物理内存（仅用于地址窗口扩展内存）
        /// MEM_RESERVE：保留进程的虚拟地址空间，而不分配任何物理存储。保留页面可通过继续调用VirtualAlloc（）而被占用
        /// MEM_RESET ：指明在内存中由参数lpAddress和dwSize指定的数据无效
        /// MEM_TOP_DOWN：在尽可能高的地址上分配内存（Windows 98忽略此标志）
        /// MEM_WRITE_WATCH：必须与MEM_RESERVE一起指定，使系统跟踪那些被写入分配区域的页面（仅针对Windows 98）
        /// </param>
        /// <param name="protect">
        /// PAGE_READONLY： 该区域为只读。如果应用程序试图访问区域中的页的时候，将会被拒绝访
        /// PAGE_READWRITE 区域可被应用程序读写
        /// PAGE_EXECUTE： 区域包含可被系统执行的代码。试图读写该区域的操作将被拒绝。
        /// PAGE_EXECUTE_READ ：区域包含可执行代码，应用程序可以读该区域。
        /// PAGE_EXECUTE_READWRITE： 区域包含可执行代码，应用程序可以读写该区域。
        /// PAGE_GUARD： 区域第一次被访问时进入一个STATUS_GUARD_PAGE异常，这个标志要和其他保护标志合并使用，表明区域被第一次访问的权限
        /// PAGE_NOACCESS： 任何访问该区域的操作将被拒绝
        /// PAGE_NOCACHE： RAM中的页映射到该区域时将不会被微处理器缓存（cached)
        /// 注:
        /// PAGE_GUARD和PAGE_NOCHACHE标志可以和其他标志合并使用以进一步指定页的特征。
        /// PAGE_GUARD标志指定了一个防护页（guard page），即当一个页被提交时会因第一次被访问而产生一个one-shot异常，
        /// 接着取得指定的访问权限。PAGE_NOCACHE防止当它映射到虚拟页的时候被微处理器缓存。这个标志方便设备驱动使用
        /// 直接内存访问方式（DMA）来共享内存块。</param>
        /// <returns>执行成功就返回分配内存的首地址，不成功就是NULL。</returns>
        [DllImport("Kernel32.dll")]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr address, uint size, uint allocationType,
                                                   uint protect);

        [DllImport("kernel32.dll")]
        public static extern bool VirtualFreeEx(IntPtr process, IntPtr address, uint size, uint freeType);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr handle);

        #endregion

        #region Gdi32.dll functions
        [DllImport("gdi32.dll")]
        public static extern bool StretchBlt(IntPtr hDCDest, int XOriginDest, int YOriginDest, int WidthDest, int HeightDest,
            IntPtr hDCSrc, int XOriginScr, int YOriginSrc, int WidthScr, int HeightScr, uint Rop);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int Width, int Heigth);
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hDCDest, int XOriginDest, int YOriginDest, int WidthDest, int HeightDest,
            IntPtr hDCSrc, int XOriginScr, int YOriginSrc, uint Rop);
        [DllImport("gdi32.dll")]
        public static extern IntPtr DeleteDC(IntPtr hDC);
        [DllImport("gdi32.dll")]
        public static extern bool PatBlt(IntPtr hDC, int XLeft, int YLeft, int Width, int Height, uint Rop);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        [DllImport("gdi32.dll")]
        public static extern uint GetPixel(IntPtr hDC, int XPos, int YPos);
        [DllImport("gdi32.dll")]
        public static extern int SetMapMode(IntPtr hDC, int fnMapMode);
        [DllImport("gdi32.dll")]
        public static extern int GetObjectType(IntPtr handle);
        [DllImport("gdi32")]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO_FLAT bmi,
            int iUsage, ref int ppvBits, IntPtr hSection, int dwOffset);
        [DllImport("gdi32")]
        public static extern int GetDIBits(IntPtr hDC, IntPtr hbm, int StartScan, int ScanLines, int lpBits, BITMAPINFOHEADER bmi, int usage);
        [DllImport("gdi32")]
        public static extern int GetDIBits(IntPtr hdc, IntPtr hbm, int StartScan, int ScanLines, int lpBits, ref BITMAPINFO_FLAT bmi, int usage);
        [DllImport("gdi32")]
        public static extern IntPtr GetPaletteEntries(IntPtr hpal, int iStartIndex, int nEntries, byte[] lppe);
        [DllImport("gdi32")]
        public static extern IntPtr GetSystemPaletteEntries(IntPtr hdc, int iStartIndex, int nEntries, byte[] lppe);
        [DllImport("gdi32")]
        public static extern uint SetDCBrushColor(IntPtr hdc, uint crColor);
        [DllImport("gdi32")]
        public static extern IntPtr CreateSolidBrush(uint crColor);
        [DllImport("gdi32")]
        public static extern int SetBkMode(IntPtr hDC, BackgroundMode mode);
        [DllImport("gdi32")]
        public static extern int SetViewportOrgEx(IntPtr hdc, int x, int y, int param);
        [DllImport("gdi32")]
        public static extern uint SetTextColor(IntPtr hDC, uint colorRef);
        [DllImport("gdi32")]
        public static extern int SetStretchBltMode(IntPtr hDC, int StrechMode);
        #endregion

        #region Uxtheme.dll functions
        [DllImport("uxtheme.dll")]
        public static extern int SetWindowTheme(IntPtr hWnd, string AppID, string ClassID);
        #endregion

        #region User32.dll functions
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);

        //枚举一个父窗口的所有子窗口。IntPtr window窗口句柄
        //WNDENUMPROC lpEnumFunc 回调函数的地址
        //LPARAM lParam 自定义的参数
        //注意：回调函数的返回值将会影响到这个API函数的行为。如果回调函数返回true，则枚举继续直到枚举完成；如果返回false，则将会中止枚举。
        [DllImport("user32.dll", EntryPoint = "EnumChildWindows")]
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lParam);
        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ShowWindow(IntPtr hWnd, short State);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool UpdateWindow(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int Width, int Height, uint flags);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool OpenClipboard(IntPtr hWndNewOwner);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseClipboard();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool EmptyClipboard();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardData(uint Format, IntPtr hData);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetMenuItemRect(IntPtr hWnd, IntPtr hMenu, uint Item, ref RECT rc);
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref RECT lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref POINT lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref TBBUTTON lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref TBBUTTONINFO lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref REBARBANDINFO lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref TVITEM lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref LVITEM lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref HDITEM lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref HD_HITTESTINFO hti);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowsHookEx(int hookid, HookProc pfnhook, IntPtr hinst, int threadid);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhook, int code, IntPtr wparam, IntPtr lparam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetFocus(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static int DrawText(IntPtr hdc, string lpString, int nCount, ref RECT lpRect, int uFormat);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr SetParent(IntPtr hChild, IntPtr hParent);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr GetDlgItem(IntPtr hDlg, int nControlID);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static int GetClientRect(IntPtr hWnd, ref RECT rc);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static int InvalidateRect(IntPtr hWnd, IntPtr rect, int bErase);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool WaitMessage();
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax, uint wFlag);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool TranslateMessage(ref MSG msg);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool DispatchMessage(ref MSG msg);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr LoadCursor(IntPtr hInstance, uint cursor);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetCursor(IntPtr hCursor);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetFocus();
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT pt);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool TrackMouseEvent(ref TRACKMOUSEEVENTS tme);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool redraw);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern ushort GetKeyState(int virtKey);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, out STRINGBUFFER ClassName, int nMaxCount);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hRegion, uint flags);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int FillRect(IntPtr hDC, ref RECT rect, IntPtr hBrush);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT wp);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowText(IntPtr hWnd, string text);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, out STRINGBUFFER text, int maxCount);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetSystemMetrics(int nIndex);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetScrollInfo(IntPtr hwnd, int bar, ref SCROLLINFO si, int fRedraw);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ShowScrollBar(IntPtr hWnd, int bar, int show);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int EnableScrollBar(IntPtr hWnd, uint flags, uint arrows);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int BringWindowToTop(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetScrollInfo(IntPtr hwnd, int bar, ref SCROLLINFO si);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ScrollWindowEx(IntPtr hWnd, int dx, int dy,
            ref RECT rcScroll, ref RECT rcClip, IntPtr UpdateRegion, ref RECT rcInvalidated, uint flags);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int IsWindow(IntPtr hWnd);
        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern int GetKeyboardState(byte[] pbKeyState);
        [DllImport("user32")]
        public static extern int ToAscii(int uVirtKey, //[in] Specifies the virtual-key code to be translated. 
            int uScanCode, // [in] Specifies the hardware scan code of the key to be translated. The high-order bit of this value is set if the key is up (not pressed). 
            byte[] lpbKeyState, // [in] Pointer to a 256-byte array that contains the current keyboard state. Each element (byte) in the array contains the state of one key. If the high-order bit of a byte is set, the key is down (pressed). The low bit, if set, indicates that the key is toggled on. In this function, only the toggle bit of the CAPS LOCK key is relevant. The toggle state of the NUM LOCK and SCROLL LOCK keys is ignored.
            byte[] lpwTransKey, // [out] Pointer to the buffer that receives the translated character or characters. 
            int fuState); // [in] Specifies whether a menu is active. This parameter must be 1 if a menu is active, or 0 otherwise.

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out uint ID);
        #endregion

        #region Common Controls functions
        [DllImport("comctl32.dll")]
        public static extern bool InitCommonControlsEx(INITCOMMONCONTROLSEX icc);
        [DllImport("comctl32.dll")]
        public static extern bool InitCommonControls();
        [DllImport("comctl32.dll", EntryPoint = "DllGetVersion")]
        public extern static int GetCommonControlDLLVersion(ref DLLVERSIONINFO dvi);
        [DllImport("comctl32.dll")]
        public static extern IntPtr ImageList_Create(int width, int height, uint flags, int count, int grow);
        [DllImport("comctl32.dll")]
        public static extern bool ImageList_Destroy(IntPtr handle);
        [DllImport("comctl32.dll")]
        public static extern int ImageList_Add(IntPtr imageHandle, IntPtr hBitmap, IntPtr hMask);
        [DllImport("comctl32.dll")]
        public static extern bool ImageList_Remove(IntPtr imageHandle, int index);
        [DllImport("comctl32.dll")]
        public static extern bool ImageList_BeginDrag(IntPtr imageHandle, int imageIndex, int xHotSpot, int yHotSpot);
        [DllImport("comctl32.dll")]
        public static extern bool ImageList_DragEnter(IntPtr hWndLock, int x, int y);
        [DllImport("comctl32.dll")]
        public static extern bool ImageList_DragMove(int x, int y);
        [DllImport("comctl32.dll")]
        public static extern bool ImageList_DragLeave(IntPtr hWndLock);
        [DllImport("comctl32.dll")]
        public static extern void ImageList_EndDrag();
        #endregion

        #region Win32 Macro-Like helpers
        public static int GET_X_LPARAM(int lParam)
        {
            return (lParam & 0xffff);
        }


        public static int GET_Y_LPARAM(int lParam)
        {
            return (lParam >> 16);
        }

        public static Point GetPointFromLPARAM(int lParam)
        {
            return new Point(GET_X_LPARAM(lParam), GET_Y_LPARAM(lParam));
        }

        public static int LOW_ORDER(int param)
        {
            return (param & 0xffff);
        }

        public static int HIGH_ORDER(int param)
        {
            return (param >> 16);
        }

        #endregion



    }

}
