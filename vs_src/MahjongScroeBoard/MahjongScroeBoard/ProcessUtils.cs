using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace MahjongScroeBoard
{
    class ProcessUtils
    {



        [DllImport("user32.dll")]
        private static extern int EnumWindows(EnumWindowsProc ewp, int lParam);

        public delegate bool EnumWindowsProc(int hWnd, int lParam);
     
        private static IntPtr targetPtr = IntPtr.Zero;
        private static int pid = -1;

        public static IntPtr getHandlerByProcessName(String processName)
        {
            enumProcess(processName);
            return targetPtr;
        }

        private static void enumProcess(String targetName)
        {
            targetPtr = IntPtr.Zero;
            Process[] processes = Process.GetProcesses();
            for (int i = 0; i < processes.Length; i++)
            {
                if (processes[i].ProcessName == targetName)
                {
                    pid = processes[i].Id;
                    Console.WriteLine("pid found: " + pid);
                    break;
                }
            }
            if (pid == -1)
            {
                targetPtr = IntPtr.Zero;
                return;
            }

            EnumWindows(new EnumWindowsProc(ADA_EnumWindowsProc), 0);

        }

        public static bool ADA_EnumWindowsProc(int hWnd, int lParam)
        {
            if (targetPtr != IntPtr.Zero)
            {
                return true;
            }
            if (Native.IsWindowVisible(hWnd) && Native.IsWindow(hWnd))
            {

                uint processId = 0;
                Native.GetWindowThreadProcessId(new IntPtr(hWnd), ref processId);
                //Console.WriteLine(pid + ": " + processId);
                if (processId == pid)
                {
                    targetPtr = new IntPtr(hWnd);
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
    }
}
