using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MahjongScroeBoard
{
    class Game
    {
        private static Game game = new Game();
        public String roundPath;
        public String dong;
        public String nan;
        public String xi;
        public String bei;
        public Boolean saved = false;
        public int[,] gameInfo = new int[16,4];
        private Game()
        {
        }
        public static Game getInstance()
        {
            return game;
        }
        public void init()
        {
            roundPath = "scores\\"+generateID()+"\\";
            Directory.CreateDirectory(roundPath);
            dong = "";
            nan = "";
            xi = "";
            bei = "";
            saved = false;
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    gameInfo[i, j] = 0;
                }
            }
        }
        public static string generateID()
        {
            StringBuilder sb = new StringBuilder();
            DateTime dt = DateTime.Now;
            sb.Append(dt.Year);
            sb.Append('_');
            sb.Append(dt.Month);
            sb.Append('_');
            sb.Append(dt.Day);
            sb.Append('_');
            sb.Append(dt.Hour);
            sb.Append('_');
            sb.Append(dt.Minute);
            sb.Append('_');
            sb.Append(dt.Second);
            sb.Append('_');
            sb.Append(dt.Millisecond);
            return sb.ToString();
        }

    }
}
