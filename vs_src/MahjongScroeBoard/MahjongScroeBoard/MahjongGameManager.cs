using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Threading;

namespace MahjongScroeBoard
{
    class MahjongGameManager
    {
        private static MahjongGameManager instance = new MahjongGameManager();
        private IntPtr QQMJPtr = IntPtr.Zero;
        private Boolean usePrintWindow = false;
        private MahjongGameManager()
        {
            Console.WriteLine(Environment.OSVersion.ToString());
            Console.WriteLine(Environment.OSVersion.Version);
            Console.WriteLine(Environment.OSVersion.Platform);
            Console.WriteLine(Environment.OSVersion.Version.Build);
            if (Environment.OSVersion.Version.Build < 7600)
            {
                usePrintWindow = true;
            }
        }
        public static MahjongGameManager getInstance()
        {
            return instance;
        }
        public Boolean syncMJHandler()
        {
            QQMJPtr = ProcessUtils.getHandlerByProcessName("taskmgr");
            if (QQMJPtr == IntPtr.Zero)
            {
                return false;
            }
            return true;
        }
        public Bitmap takeSnapshot()
        {
            takeTime = 0;
            if (usePrintWindow)
            {
                
                return doPrintWindowTakeSnapshot();
            }
            else
            {
                Boolean scoreBoardVisible = ViewManager.scoreBoardUI.Visible;
                Boolean snapshotBoardVisible = ViewManager.snapshotScoreBoardUI.Visible;
                if (ViewManager.scoreBoardUI.Visible)
                {
                    ViewManager.scoreBoardUI.Visible = false;
                }
                if (ViewManager.snapshotScoreBoardUI.Visible)
                {
                    ViewManager.snapshotScoreBoardUI.Visible = false;
                }

                Thread.Sleep(200);
                Bitmap snapshotData = doCShapSnapshot();
                if (scoreBoardVisible)
                {
                    ViewManager.scoreBoardUI.Visible = true;
                }
                if (snapshotBoardVisible)
                {
                    ViewManager.snapshotScoreBoardUI.Visible = true;
                }
                return snapshotData;
            }
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
                Console.WriteLine(e.Message);
                QQMJPtr = IntPtr.Zero;
                return doPrintWindowTakeSnapshot();
            }
        }
        private Bitmap GetWindow(IntPtr hWnd, int width, int height)
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
        private Bitmap copyAreaFromScreen(Rectangle bounds)
        {
            Screen screen = Screen.PrimaryScreen;
            Rectangle rect = screen.Bounds;
            int w = rect.Width;
            int h = rect.Height;
            Bitmap screenData = new Bitmap(w, h);
            Graphics g = Graphics.FromImage(screenData);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(w, h));
            Rectangle actualArea = new Rectangle();
            actualArea.X = bounds.X;
            actualArea.Y = bounds.Y;
            actualArea.Width = bounds.Width - bounds.X;
            actualArea.Height = bounds.Height - bounds.Y;
            screenData.Save("csscreen" + cound + ".jpg", ImageFormat.Jpeg);
            Bitmap appData = screenData.Clone(actualArea, PixelFormat.Format24bppRgb);
            appData.Save("app"+cound+".jpg",ImageFormat.Jpeg);
            return appData;
        }
        int cound = 0;
        private Bitmap doCShapSnapshot()
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

                Rectangle targetRect = new Rectangle();
                Native.GetWindowRect(QQMJPtr, out targetRect);
                //Bitmap bt = GetWindow(QQMJPtr, rect.Width - rect.X, rect.Height - rect.Y);
                Bitmap bt = copyAreaFromScreen(targetRect);
                //bt.Save("test.jpg", ImageFormat.Jpeg);
                return bt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                QQMJPtr = IntPtr.Zero;
                return doCShapSnapshot();
            }
            
        }
    }
}
