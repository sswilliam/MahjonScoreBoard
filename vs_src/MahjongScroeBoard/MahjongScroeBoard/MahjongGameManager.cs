using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace MahjongScroeBoard
{
    class MahjongGameManager
    {
        private static MahjongGameManager instance = new MahjongGameManager();
        private IntPtr QQMJPtr = IntPtr.Zero;
        private MahjongGameManager()
        {
            Console.WriteLine(Environment.OSVersion.ToString());
        }
        public static MahjongGameManager getInstance()
        {
            return instance;
        }
        public Boolean syncMJHandler()
        {
            QQMJPtr = ProcessUtils.getHandlerByProcessName("mjrpg");
            if (QQMJPtr == IntPtr.Zero)
            {
                return false;
            }
            return true;
        }
        public Bitmap takeSnapshot()
        {
            return null;
        }

        private static int takeTime = 0;
        private Bitmap doPrintWindowTakeSnapshot()
        {
            if (takeTime > 3)
            {
                return null;
            }
            takeTime++;
            try
            {
                if (QQMJPtr == IntPtr.Zero)
                {
                    syncMJHandler();
                    if (QQMJPtr == IntPtr.Zero)
                    {
                        return null;
                    }
                }

                Rectangle rect = new Rectangle();
                Native.GetWindowRect(QQMJPtr, out rect);
                Bitmap bt = GetWindow(QQMJPtr, rect.Width - rect.X, rect.Height - rect.Y);
                bt.Save("test.jpg", ImageFormat.Jpeg);
                return bt;
            }
            catch (Exception e)
            {
                return doPrintWindowTakeSnapshot();
            }
        }
        private static Bitmap GetWindow(IntPtr hWnd, int width, int height)
        {
            IntPtr hscrdc = Native.GetWindowDC(hWnd);
            IntPtr hbitmap = Native.CreateCompatibleBitmap(hscrdc, width, height);
            IntPtr hmemdc = Native.CreateCompatibleDC(hscrdc);
            Native.SelectObject(hmemdc, hbitmap);
            Native.PrintWindow(hWnd, hmemdc, 0);
            Bitmap bmp = Bitmap.FromHbitmap(hbitmap);
            Native.DeleteDC(hscrdc);
            Native.DeleteDC(hmemdc);
            return bmp;
        }
    }
}
