using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MahjongScroeBoard
{
    class MahjongGameManager
    {
        private static MahjongGameManager instance = new MahjongGameManager();
        private IntPtr QQMJPtr = IntPtr.Zero;
        private MahjongGameManager()
        {
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
        private Bitmap doTakeSnapshot()
        {
            return null;
        }
    }
}
