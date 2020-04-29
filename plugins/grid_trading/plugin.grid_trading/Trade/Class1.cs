using Dragonfly.Plugin.GridTrading.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Dragonfly.Plugin.GridTrading.Trade
{
    class Class1
    {
        internal const int TV_FIRST = 0x1100;
        internal const int TVM_GETITEMRECT = (TV_FIRST + 4);
        internal const int TVM_GETITEMA = (TV_FIRST + 12);
        internal const int TVM_GETITEMW = (TV_FIRST + 62);
        internal const int TVM_SETITEMA = (TV_FIRST + 13);
        internal const int TVM_SETITEMW = (TV_FIRST + 63);
        internal const int TVM_SELECTITEM = (TV_FIRST + 11);
        internal const int TVM_EDITLABELA = (TV_FIRST + 14);
        internal const int TVM_EDITLABELW = (TV_FIRST + 65);
        internal const int TVM_GETNEXTITEM = (TV_FIRST + 10);
        internal const int TVM_GETEDITCONTROL = (TV_FIRST + 15);
        internal const int TVM_EXPAND = (TV_FIRST + 2);
        internal const int TVM_ENDEDITLABELNOW = (TV_FIRST + 22);
        internal const int TVM_ENSUREVISIBLE = (TV_FIRST + 20);
        internal const int TVE_COLLAPSE = 0x0001;
        internal const int TVE_EXPAND = 0x0002;
        internal const int TVGN_ROOT = 0x0000;
        internal const int TVGN_NEXT = 0x0001;
        internal const int TVGN_PREVIOUS = 0x0002;
        internal const int TVGN_PARENT = 0x0003;
        internal const int TVGN_CHILD = 0x0004;
        internal const int TVGN_CARET = 0x0009;
        internal const int TVN_FIRST = -400;
        internal const int TVN_ITEMEXPANDINGA = (TVN_FIRST - 5);
        internal const int TVN_ITEMEXPANDINGW = (TVN_FIRST - 54);
        internal const int TVN_ITEMEXPANDEDA = (TVN_FIRST - 6);
        internal const int TVN_ITEMEXPANDEDW = (TVN_FIRST - 55);
        internal const int TVN_SELCHANGEDA = (TVN_FIRST - 2);
        internal const int TVN_SELCHANGEDW = (TVN_FIRST - 51);
        internal const int TVN_ENDLABELEDITA = (TVN_FIRST - 11);
        internal const int TVN_ENDLABELEDITW = (TVN_FIRST - 60);
        internal const int TVM_HITTEST = (TV_FIRST + 17);
        internal const int TVN_KEYDOWN = (TVN_FIRST - 12);
        internal const int TVIS_STATEIMAGEMASK = 0xF000;

        [Serializable]
        public class TVITEMEX
        {
            internal TVITEMEX_CORE _core = new TVITEMEX_CORE();
            string _pszText = string.Empty;

            public TVIF mask { get { return (TVIF)_core.mask; } set { _core.mask = (int)value; } }
            public IntPtr hItem { get { return _core.hItem; } set { _core.hItem = value; } }
            public TVIS state { get { return (TVIS)_core.state; } set { _core.state = (int)value; } }
            public TVIS stateMask { get { return (TVIS)_core.stateMask; } set { _core.stateMask = (int)value; } }
            public string pszText { get { return _pszText; } set { _pszText = value; } }
            public int iImage { get { return _core.iImage; } set { _core.iImage = value; } }
            public int iSelectedImage { get { return _core.iSelectedImage; } set { _core.iSelectedImage = value; } }
            public int cChildren { get { return _core.cChildren; } set { _core.cChildren = value; } }
            public IntPtr lParam { get { return _core.lParam; } set { _core.lParam = value; } }
            public int iIntegral { get { return _core.iIntegral; } set { _core.iIntegral = value; } }
            public int uStateEx { get { return _core.uStateEx; } set { _core.uStateEx = value; } }
            public IntPtr hwnd { get { return _core.hwnd; } set { _core.hwnd = value; } }
            public int iExpandedImage { get { return _core.iExpandedImage; } set { _core.iExpandedImage = value; } }
            public int iReserved { get { return _core.iReserved; } set { _core.iReserved = value; } }
            public TVITEMEX_CORE Core { get { return _core; } }
        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        public struct TVITEMEX_CORE
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            public IntPtr pszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
            public int iIntegral;
            public int uStateEx;
            public IntPtr hwnd;
            public int iExpandedImage;
            public int iReserved;
            public void GetTVITEMEX(ref TVITEM item)
            {
                item.mask = mask;
                item.hItem = hItem;
                item.state = state;
                item.stateMask = stateMask;
                item.pszText = pszText;
                item.cchTextMax = cchTextMax;
                item.iImage = iImage;
                item.iSelectedImage = iSelectedImage;
                item.cChildren = cChildren;
                item.lParam = lParam;
            }
        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        public struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            public IntPtr pszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }


        [Flags]
        public enum TVIF : int
        {
            TEXT = 0x0001,
            IMAGE = 0x0002,
            PARAM = 0x0004,
            STATE = 0x0008,
            HANDLE = 0x0010,
            SELECTEDIMAGE = 0x0020,
            CHILDREN = 0x0040,
            INTEGRAL = 0x0080,
            STATEEX = 0x0100,
            EXPANDEDIMAGE = 0x0200,
        }

        [Flags]
        public enum TVIS
        {
            SELECTED = 0x0002,
            CUT = 0x0004,
            DROPHILITED = 0x0008,
            BOLD = 0x0010,
            EXPANDED = 0x0020,
            EXPANDEDONCE = 0x0040,
            EXPANDPARTIAL = 0x0080,
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool IsWindowUnicode(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, ref TVITEMEX_CORE lParam);

        internal static bool GetItemInTarget(IntPtr handle, TVITEMEX item)
        {
            bool isUni = IsWindowUnicode(handle);
            int TVM_GETITEM = isUni ? TVM_GETITEMW : TVM_GETITEMA;

            //文字列取得の場合バッファを確保する。
            if ((item.mask & TVIF.TEXT) == TVIF.TEXT)
            {
                item._core.cchTextMax = 256;
            }

            var pMem = IntPtr.Zero;
            while (true)
            {
                if (0 < item._core.cchTextMax)
                {
                    pMem = Marshal.AllocCoTaskMem((item._core.cchTextMax + 1) * 8);
                    item._core.pszText = pMem;
                }
                try
                {
                    if (SendMessage(handle, TVM_GETITEM, IntPtr.Zero, ref item._core) == IntPtr.Zero)
                    {
                        return false;
                    }

                    //文字列取得がなければ終了。
                    if (item._core.pszText == IntPtr.Zero)
                    {
                        return true;
                    }

                    //文字列に変換。
                    item.pszText = isUni ? Marshal.PtrToStringUni(item._core.pszText) :
                            Marshal.PtrToStringAnsi(item._core.pszText);

                    //サイズが足りていれば終了。
                    if (item.pszText.Length < item._core.cchTextMax - 1)
                    {
                        return true;
                    }

                    //リトライ。
                    item._core.cchTextMax *= 2;
                }
                finally
                {
                    if (pMem != IntPtr.Zero)
                    {
                        Marshal.FreeCoTaskMem(pMem);
                    }
                }
            }
        }
    }
}
