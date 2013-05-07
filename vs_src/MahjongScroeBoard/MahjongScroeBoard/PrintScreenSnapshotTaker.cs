using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing;

namespace MahjongScroeBoard
{
    class PrintScreenSnapshotTaker
    {
        //system call


        public static String processName = "";
        public static int tryTime = 0;

        

        
        private static int takeTime = 0;
        private static Bitmap doTakeImage()
        {
            if (takeTime > 3)
            {
                return null;
            }
            takeTime++;
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
                bt.Save("test.jpg", ImageFormat.Jpeg);
                return bt;
            }
            catch (Exception e)
            {
                return doTakeImage();
            }
        }
        public static Bitmap takeImage()
        {
            takeTime = 0;
            return doTakeImage();
           
            
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
