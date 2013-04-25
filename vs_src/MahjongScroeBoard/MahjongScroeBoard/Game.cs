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
        private int getNameSpace(int stringLength)
        {
            return (stringLength / 5) * 5 + 10;
        }
        private String[] dnxbString = { "东", "南", "西", "北" };
        public string getScoreTable()
        {
            int firstLeng = 10;
            int dongLeng = getNameSpace(Game.getInstance().dong.Length);
            int nanLeng = getNameSpace(Game.getInstance().nan.Length);
            int xiLeng = getNameSpace(Game.getInstance().xi.Length);
            int beiLeng = getNameSpace(Game.getInstance().bei.Length);
            int[] lengs = { dongLeng, nanLeng, xiLeng, beiLeng };
            StringBuilder sb = new StringBuilder();
            sb.Append(fillString("", firstLeng, ' '));
            sb.Append(fillString(Game.getInstance().dong, dongLeng, ' '));
            sb.Append(fillString(Game.getInstance().nan, nanLeng, ' '));
            sb.Append(fillString(Game.getInstance().xi, xiLeng, ' '));
            sb.Append(fillString(Game.getInstance().bei, beiLeng, ' '));
            sb.Append("\r\n");
            int[] totals = { 0, 0, 0, 0 };
            for (int i = 0; i < 16; i++)
            {
                if (i % 4 == 0)
                {
                    sb.Append(fillString(dnxbString[i / 4], firstLeng, ' '));
                }
                else
                {
                    sb.Append(fillString("", firstLeng, ' '));
                }
                for (int j = 0; j < 4; j++)
                {
                    sb.Append(fillString(Game.getInstance().gameInfo[i, j] + "", lengs[j], ' '));
                    totals[j] += Game.getInstance().gameInfo[i, j];
                }
                sb.Append("\r\n");
            }
            sb.Append(fillString("", firstLeng + dongLeng + nanLeng + xiLeng + beiLeng, '-'));
            sb.Append("\r\n");
            sb.Append(fillString("总计", firstLeng, ' '));
            for (int i = 0; i < 4; i++)
            {
                sb.Append(fillString(totals[i] + "", lengs[i], ' '));
            }
            return sb.ToString();
        }

        private String fillString(String source, int length, char withChar)
        {
            int sourceLength = source.Length;
            if (sourceLength > length)
            {
                return source.Substring(0, length);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                int dt = length - sourceLength;
                sb.Append(source);
                for (int i = 0; i < dt; i++)
                {
                    sb.Append(withChar);
                }
                return sb.ToString();
            }
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

        public void save()
        {
            this.saved = true;
            if (File.Exists(roundPath + "score.txt"))
            {
                File.Delete(roundPath + "score.txt");
            }
            FileStream fs = new FileStream(roundPath + "score.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(fs);
            writer.Write(getScoreTable());
            writer.Flush();
            writer.Close();
            fs.Close();

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
