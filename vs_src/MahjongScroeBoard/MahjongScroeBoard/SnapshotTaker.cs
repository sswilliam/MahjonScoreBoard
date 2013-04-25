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

        public static int windowCount = 0;
        [DllImport("user32.dll", EntryPoint = "GetWindowDC")]

        public static extern IntPtr GetWindowDC(

         IntPtr hwnd

         );

        [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, ref uint lpdwProcessId);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(int hWnd);

        [DllImport("user32.dll")]
        private static extern bool IsWindow(int hWnd);


        [DllImport("user32.dll", EntryPoint = "GetWindowRect")]
        private static extern int GetWindowRect(IntPtr hwnd, out   Rectangle lpRect);

        [DllImport("user32.dll")]
        private static extern int EnumWindows(EnumWindowsProc ewp, int lParam);


        [DllImport("user32.dll")]
        private static extern int GetWindowText(int hWnd, StringBuilder title, int size);
        
        [DllImport("user32.dll")]
        private static extern int GetWindowTextLength(int hWnd);

        public static String processName = "";
        public static int tryTime = 0;

        public delegate bool EnumWindowsProc(int hWnd, int lParam);

        public static bool ADA_EnumWindowsProc(int hWnd, int lParam){
            if (QQGamePtr != IntPtr.Zero)
            {
                return true;
            }
            if (IsWindowVisible(hWnd) && IsWindow(hWnd))
            {

                windowCount++;
                uint processId = 0;
                GetWindowThreadProcessId(new IntPtr(hWnd), ref processId);
                Console.WriteLine(pid + ": " + processId);
                if (processId == pid)
                {
                    QQGamePtr = new IntPtr(hWnd);
                    Console.WriteLine("found");
                }
                /*GetWindowThreadProcessId(new IntPtr(hWnd), ref processId);
                int cTxtLen, i;
                String cTitle, strtmp;
                cTxtLen = GetWindowTextLength(hWnd) + 1;
                StringBuilder text = new StringBuilder(cTxtLen);
                GetWindowText(hWnd, text, cTxtLen);
                cTitle = text.ToString();
                Console.WriteLine("enum:"+windowCount+" pid:"+processId+" window name:"+cTitle);*/
            }
            return true;
        }
        private static IntPtr QQGamePtr = IntPtr.Zero;
        private static int pid = -1;
        public static void findQQPtr()
        {
            QQGamePtr = IntPtr.Zero;
            Process[] processes = Process.GetProcesses();
            for (int i = 0; i < processes.Length; i++)
            {
                if (processes[i].ProcessName == "mjrpg")
                {
                    pid = processes[i].Id;
                    Console.WriteLine("pid found: " + pid);
                    break;
                }
            }
            if (pid == -1)
            {
                QQGamePtr = IntPtr.Zero;
                return;
            }

            EnumWindows(new EnumWindowsProc(ADA_EnumWindowsProc), 0);

        }
        public static Bitmap takeImage()
        {
            try
            {
                if (QQGamePtr == IntPtr.Zero)
                {
                    findQQPtr();
                    if (QQGamePtr == IntPtr.Zero)
                    {
                        return null;
                    }
                }

                Rectangle rect = new Rectangle();
                GetWindowRect(QQGamePtr, out rect);
                Bitmap bt = GetWindow(QQGamePtr, rect.Width - rect.X, rect.Height - rect.Y);
                if (bt.Height < 100)
                {
                    return null;
                }
                bt.Save("test.jpg", ImageFormat.Jpeg);
                return bt;
            }
            catch (Exception e)
            {
                findQQPtr();
                if (QQGamePtr == IntPtr.Zero)
                {
                    findQQPtr();
                    if (QQGamePtr == IntPtr.Zero)
                    {
                        return null;
                    }
                }

                Rectangle rect = new Rectangle();
                GetWindowRect(QQGamePtr, out rect);
                Bitmap bt = GetWindow(QQGamePtr, rect.Width - rect.X, rect.Height - rect.Y);
                if (bt.Height < 100)
                {
                    return null;
                }
                bt.Save("test.jpg", ImageFormat.Jpeg);
                return bt;
            }
            
            //Image 

        }

        public static String getMahjongProcessName()
        {
            Console.WriteLine("===============================");
            Process[] processes = Process.GetProcesses();
            for (int i = 0; i < processes.Length; i++)
            {
                Console.WriteLine(processes[i].ProcessName);
            }
            Console.WriteLine("===============================");
            return "QQ麻将";
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
