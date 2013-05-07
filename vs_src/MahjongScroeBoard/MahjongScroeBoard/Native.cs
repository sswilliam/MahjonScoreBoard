using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing;

namespace MahjongScroeBoard
{
    class Native
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool BRePaint);

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll", EntryPoint = "PrintWindow")]
        public static extern bool PrintWindow(

         IntPtr hwnd,               // Window to copy,Handle to the window that will be copied. 

         IntPtr hdcBlt,             // HDC to print into,Handle to the device context. 

         UInt32 nFlags              // Optional flags,Specifies the drawing options. It can be one of the following values. 

         );

        [DllImport("user32.dll", EntryPoint = "GetWindowDC")]
        public static extern IntPtr GetWindowDC(

         IntPtr hwnd

         );


        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(int hWnd);

        [DllImport("user32.dll")]
        public static extern bool IsWindow(int hWnd);


        [DllImport("user32.dll", EntryPoint = "GetWindowRect")]
        public static extern int GetWindowRect(IntPtr hwnd, out   Rectangle lpRect);



        [DllImport("user32.dll")]
        public static extern int GetWindowText(int hWnd, StringBuilder title, int size);

        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(int hWnd);


        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap")]
        public static extern IntPtr CreateCompatibleBitmap(

         IntPtr hdc,        // handle to DC

         int nWidth,     // width of bitmap, in pixels

         int nHeight     // height of bitmap, in pixels

         );
        [DllImport("gdi32.dll", EntryPoint = "SelectObject")]

        public static extern IntPtr SelectObject(

         IntPtr hdc,          // handle to DC

         IntPtr hgdiobj   // handle to object

         );

        [DllImport("gdi32.dll", EntryPoint = "DeleteDC")]
        public static extern int DeleteDC(

         IntPtr hdc          // handle to DC

         );

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC")]
        public static extern IntPtr CreateCompatibleDC(
         IntPtr hdc // handle to DC
         );





        [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, ref uint lpdwProcessId);
    }
}
