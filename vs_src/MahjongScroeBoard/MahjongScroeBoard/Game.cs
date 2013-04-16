using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MahjongScroeBoard
{
    class Game
    {
        private static Game game = new Game();
        private String roundPath;
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
            roundPath = "";
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

    }
}
