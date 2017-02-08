using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Dragonfly.Chalk
{
    internal static class WindowUtils
    {
        public static Size GetScreenSize()
        {
            int width = GetSystemMetrics(ScreenMetrics.SM_CXSCREEN);
            int height = GetSystemMetrics(ScreenMetrics.SM_CYSCREEN);
            return new Size(width, height);
        }

        public static Bitmap CaptureScreen()
        {
            Rectangle rect = new Rectangle(new Point(0, 0), GetScreenSize());

            return CaptureScreen(rect, Cursor.Position);
        }

        public static Bitmap CaptureScreen(Rectangle drawRect, Point drawMousePosition)
        {
            IntPtr hScreenDC = GetDC(IntPtr.Zero);
            Bitmap bitmap = new Bitmap(drawRect.Width, drawRect.Height);
            Graphics g = Graphics.FromImage(bitmap);
            IntPtr hBitmapDC = g.GetHdc();

            BitBlt(hBitmapDC, 0, 0, drawRect.Width, drawRect.Height, hScreenDC, drawRect.X, drawRect.Y, TernaryRasterOperations.SRCCOPY);

            ReleaseDC(IntPtr.Zero, hScreenDC);
            g.ReleaseHdc(hBitmapDC);

            Cursor.Current.Draw(g, new Rectangle(drawMousePosition.X - Cursor.Current.HotSpot.X,
                drawMousePosition.Y - Cursor.Current.HotSpot.Y, Cursor.Current.Size.Width, Cursor.Current.Size.Height));

            g.Dispose();

            return bitmap;
        }

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


        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);


        [DllImport("User32.dll", SetLastError = true)]
        public static extern int GetSystemMetrics(ScreenMetrics sm);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight,
            IntPtr hdcSrc, int nXSrc, int nYSrc, TernaryRasterOperations dwRop);

        public enum ScreenMetrics : int
        {
            SM_CXSCREEN = 0,
            SM_CYSCREEN = 1,
            SM_CXVSCROLL = 2,
            SM_CYHSCROLL = 3,
            SM_CYCAPTION = 4,
            SM_CXBORDER = 5,
            SM_CYBORDER = 6,
            SM_CXDLGFRAME = 7,
            SM_CYDLGFRAME = 8,
            SM_CXICON = 11,
            SM_CYICON = 12,
            // @CESYSGEN IF GWES_ICONCURS
            SM_CXCURSOR = 13,
            SM_CYCURSOR = 14,
            // @CESYSGEN ENDIF
            SM_CYMENU = 15,
            SM_CXFULLSCREEN = 16,
            SM_CYFULLSCREEN = 17,
            SM_MOUSEPRESENT = 19,
            SM_CYVSCROLL = 20,
            SM_CXHSCROLL = 21,
            SM_DEBUG = 22,
            SM_CXDOUBLECLK = 36,
            SM_CYDOUBLECLK = 37,
            SM_CXICONSPACING = 38,
            SM_CYICONSPACING = 39,
            SM_CXEDGE = 45,
            SM_CYEDGE = 46,
            SM_CXSMICON = 49,
            SM_CYSMICON = 50,

            SM_XVIRTUALSCREEN = 76,
            SM_YVIRTUALSCREEN = 77,
            SM_CXVIRTUALSCREEN = 78,
            SM_CYVIRTUALSCREEN = 79,
            SM_CMONITORS = 80,
            SM_SAMEDISPLAYFORMAT = 81,

            SM_CXFIXEDFRAME = SM_CXDLGFRAME,
            SM_CYFIXEDFRAME = SM_CYDLGFRAME
        }

        public enum TernaryRasterOperations : uint
        {
            /* Ternary raster operations */
            SRCCOPY = 0x00CC0020, /* dest = source                   */
            SRCPAINT = 0x00EE0086, /* dest = source OR dest           */
            SRCAND = 0x008800C6, /* dest = source AND dest          */
            SRCINVERT = 0x00660046, /* dest = source XOR dest          */
            SRCERASE = 0x00440328, /* dest = source AND (NOT dest )   */
            NOTSRCCOPY = 0x00330008, /* dest = (NOT source)             */
            NOTSRCERASE = 0x001100A6, /* dest = (NOT src) AND (NOT dest) */
            MERGECOPY = 0x00C000CA, /* dest = (source AND pattern)     */
            MERGEPAINT = 0x00BB0226, /* dest = (NOT source) OR dest     */
            PATCOPY = 0x00F00021, /* dest = pattern                  */
            PATPAINT = 0x00FB0A09, /* dest = DPSnoo                   */
            PATINVERT = 0x005A0049, /* dest = pattern XOR dest         */
            DSTINVERT = 0x00550009, /* dest = (NOT dest)               */
            BLACKNESS = 0x00000042, /* dest = BLACK                    */
            WHITENESS = 0x00FF0062  /* dest = WHITE                    */
        }
    }

}
