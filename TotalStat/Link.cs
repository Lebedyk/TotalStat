using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TotalStat
{
    public static class Link
    {     
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }                       
        private static POINT mousepoint;       


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref POINT pt);
        [DllImport("user32.dll")]
        static extern IntPtr WindowFromPoint(POINT pt);

        [DllImport("user32.dll")]
        static extern bool SetWindowText(IntPtr hWnd, string lpString);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int cch);
        [DllImport("user32.dll")]
        static extern int GetWindowTextLength(IntPtr hWnd);

        public static IntPtr GetHwnd()
        {            
            GetCursorPos(ref mousepoint);
            IntPtr Hwnd = WindowFromPoint(mousepoint);
            return Hwnd;
        }

        public static string GetText(IntPtr hwnd)
        {            
            int text_length = GetWindowTextLength(hwnd);
            StringBuilder window_text_SB = new StringBuilder("", text_length + 5);
            GetWindowText(hwnd, window_text_SB, text_length + 2);
            string window_text = window_text_SB.ToString();            

            return window_text;
        }
        public static string GetTicker(string window_text)
        {            
            char[] separator = { ',', '-', ' ' };
            List<string> tickers = window_text.Split(separator).ToList();
            string ticker;
            if(tickers.Count>0)
            {
                ticker = tickers[0];
            }
            else
            {
                ticker = "";
            }
            return ticker;
        }
        
    }
}
