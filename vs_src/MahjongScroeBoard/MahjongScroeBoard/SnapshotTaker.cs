using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing;

namespace MahjongScroeBoard
{
    class SnapshotTaker
    {
        //system call
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool BRePaint);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC")]
        public static extern IntPtr CreateCompatibleDC(
         IntPtr hdc // handle to DC
         );
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

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

        [DllImport("user32.dll", EntryPoint = "GetWindowRect")]
        private static extern int GetWindowRect(IntPtr hwnd, out   Rectangle lpRect);


        public static Image takeImage()
        {
            IntPtr targetWindow = FindWindow(null, "Windows Task Manager");
            Rectangle rect = new Rectangle();
            GetWindowRect(targetWindow,out rect);
            Image bt = (Image)GetWindow(targetWindow, rect.Width - rect.X, rect.Height - rect.Y);
            bt.Save("test.jpg", ImageFormat.Jpeg);
            return bt;
            //Image 

        }

        public static Bitmap GetWindow(IntPtr hWnd, int width, int height)
        {
            IntPtr hscrdc = GetWindowDC(hWnd);
            IntPtr hbitmap = CreateCompatibleBitmap(hscrdc, width, height);
            IntPtr hmemdc = CreateCompatibleDC(hscrdc);
            SelectObject(hmemdc, hbitmap);
            PrintWindow(hWnd, hmemdc, 0);
            Bitmap bmp = Bitmap.FromHbitmap(hbitmap);
            DeleteDC(hscrdc);
            DeleteDC(hmemdc);
            return bmp;
        }
    }
}
