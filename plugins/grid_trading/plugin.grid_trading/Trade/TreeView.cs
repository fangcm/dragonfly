using System;
using System.Runtime.InteropServices;


namespace Dragonfly.Plugin.GridTrading.Trade
{
    public class TreeView
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessageTVI(IntPtr hWnd, UInt32 Msg, IntPtr wParam, ref TVITEM tvi);

        [DllImport("kernel32.dll")]
        static extern IntPtr LocalAlloc(uint flags, uint cb);

        [DllImport("kernel32.dll")]
        static extern IntPtr LocalFree(IntPtr p);

        private const int TV_FIRST = 0x1100;

        private const int TVGN_ROOT = 0x0;
        private const int TVGN_NEXT = 0x1;
        private const int TVGN_PARENT = 0x3;
        private const int TVGN_CHILD = 0x4;
        private const int TVGN_FIRSTVISIBLE = 0x5;
        private const int TVGN_NEXTVISIBLE = 0x6;
        private const int TVGN_CARET = 0x9;

        private const int TVM_SELECTITEM = (TV_FIRST + 11);
        private const int TVM_GETNEXTITEM = (TV_FIRST + 10);
        private const int TVM_GETITEM = (TV_FIRST + 12);

        private struct TVITEM
        {
            public uint mask;
            public IntPtr hItem;
            public uint state;
            public uint stateMask;
            public IntPtr pszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }

        private const int TVIF_TEXT = 0x1;

        public static string GetItemText(IntPtr hTree, IntPtr hItem)
        {
            TVITEM tvi = new TVITEM();

            const int maxSize = 260;
            IntPtr pszText = LocalAlloc(0x40, maxSize);

            tvi.mask = TVIF_TEXT;
            tvi.hItem = hItem;
            tvi.cchTextMax = 260;
            tvi.pszText = pszText;

            SendMessageTVI(hTree, TVM_GETITEM, IntPtr.Zero, ref tvi);
            string nodeText = Marshal.PtrToStringAnsi(tvi.pszText, maxSize);

            LocalFree(pszText);

            return nodeText?.TrimEnd('\0');
        }

    }
}
