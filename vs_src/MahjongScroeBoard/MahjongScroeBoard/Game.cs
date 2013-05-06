using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

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
        public String[] fans = new String[16];
        public int currentRound = 0;
        public String judgerName = "";
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
            sb.Append('\t');
            sb.Append(Game.getInstance().dong);
            sb.Append('\t');
            sb.Append(Game.getInstance().nan);
            sb.Append('\t');
            sb.Append(Game.getInstance().xi);
            sb.Append('\t');
            sb.Append(Game.getInstance().bei);
            sb.Append('\t');
           // sb.Append(TextUtils.fillString("", firstLeng, ' '));
           // sb.Append(TextUtils.fillString(Game.getInstance().dong, dongLeng, ' '));
           // sb.Append(TextUtils.fillString(Game.getInstance().nan, nanLeng, ' '));
           // sb.Append(TextUtils.fillString(Game.getInstance().xi, xiLeng, ' '));
           // sb.Append(TextUtils.fillString(Game.getInstance().bei, beiLeng, ' '));
            sb.Append("\r\n");
            int[] totals = { 0, 0, 0, 0 };
            for (int i = 0; i < 16; i++)
            {
                if (i % 4 == 0)
                {
                   // sb.Append(TextUtils.fillString(dnxbString[i / 4], firstLeng, ' '));
                    sb.Append(dnxbString[i / 4]);
                    sb.Append('\t');
                }
                else
                {
                    sb.Append('\t');
                   // sb.Append(TextUtils.fillString("", firstLeng, ' '));
                }
                for (int j = 0; j < 4; j++)
                {
                    //sb.Append(TextUtils.fillString(Game.getInstance().gameInfo[i, j] + "", lengs[j], ' '));
                    sb.Append(Game.getInstance().gameInfo[i, j]);
                    sb.Append('\t');
                    totals[j] += Game.getInstance().gameInfo[i, j];
                }
                sb.Append(fans[i]);
                sb.Append("\r\n");
            }
            //sb.Append('\t');
            sb.Append(TextUtils.fillString("", firstLeng + dongLeng + nanLeng + xiLeng + beiLeng, '-'));
            sb.Append("\r\n");
            sb.Append("总分\t");
            //sb.Append(TextUtils.fillString("总分", firstLeng, ' '));
            for (int i = 0; i < 4; i++)
            {
                sb.Append(totals[i]);
                sb.Append('\t');
                //sb.Append(TextUtils.fillString(totals[i] + "", lengs[i], ' '));
            }
            sb.Append("\r\n");
            sb.Append(TextUtils.fillString("", firstLeng + dongLeng + nanLeng + xiLeng + beiLeng, '-'));
            sb.Append("\r\n");
            double[] bigScore = getBigScore(totals);

            sb.Append("总计\t");
            //sb.Append(TextUtils.fillString("总计", firstLeng, ' '));
            for (int i = 0; i < 4; i++)
            {
                sb.Append(bigScore[i]);
                sb.Append('\t');
                //sb.Append(TextUtils.fillString(bigScore[i] + "", lengs[i], ' '));
            }
            sb.Append("裁判: ");
            sb.Append(judgerName);
            sb.Append("\r\n");

                return sb.ToString();
        }

        public double[] getBigScore(int[] totals)
        {
            double[] bigScore = { 0, 0, 0, 0 };
            int bigest = totals[0];
            int bigestCount = 1;
            int wait = 4;
            for (int i = 1; i < 4; i++)
            {
                if (totals[i] > bigest)
                {
                    bigest = totals[i];
                    bigestCount = 1;
                }
                else if (totals[i] == bigest)
                {
                    bigestCount++;
                }

            }
            if (bigestCount == 1)
            {
                int secondBigest = -100000;
                int secondBigestCount = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (totals[j] == bigest)
                    {
                        bigScore[j] = 4;
                    }
                    else
                    {
                        if (totals[j] > secondBigest)
                        {
                            secondBigest = totals[j];
                            secondBigestCount = 1;
                        }else if(totals[j] == secondBigest){
                            secondBigestCount++;
                        }
                    }
                }
                if (secondBigestCount == 1)
                {

                    int left1Index = -1;
                    int left1Value = -1000000;
                    int left2Index = -1;
                    int left2Value = -1000000;
                    for (int k = 0; k < 4; k++)
                    {
                        if (totals[k] != bigest)
                        {
                            if (totals[k] == secondBigest)
                            {
                                bigScore[k] = 2;
                            }
                            else
                            {
                                if (left1Index == -1)
                                {
                                    left1Index = k;
                                    left1Value = totals[k];
                                }
                                else
                                {
                                    left2Index = k;
                                    left2Value = totals[k];
                                }
                            }
                        }
                        
                    }
                    if (left1Value > left2Value)
                    {
                        bigScore[left1Index] = 1;
                        bigScore[left2Index] = 0;
                    }
                    else if (left1Value == left2Value)
                    {
                        bigScore[left1Index] = 0.5;
                        bigScore[left2Index] = 0.5;
                    }
                    else
                    {

                        bigScore[left1Index] = 0;
                        bigScore[left2Index] = 1;
                    }

                }
                else if (secondBigestCount == 2)
                {
                    for(int k = 0;k<4;k++){
                        if(totals[k] != bigest){
                            if (totals[k] == secondBigest)
                            {
                                bigScore[k] = 1.5;
                            }
                            else
                            {
                                bigScore[k] = 0;
                            }
                        }
                        
                    }
                }else{
                    for(int k = 0;k<4;k++){
                        if(totals[k] != bigest){
                            bigScore[k] = 1;
                        }
                    }
                }

            }
            else if (bigestCount == 2)
            {
                int left1Index = -1;
                int left1Value = -1000000;
                int left2Index = -1;
                int left2Value = -1000000;
                for (int j = 0; j < 4; j++)
                {
                    if (totals[j] != bigest)
                    {
                        if (left1Index == -1)
                        {
                            left1Index = j;
                            left1Value = totals[j];
                        }
                        else
                        {
                            left2Index = j;
                            left2Value = totals[j];
                        }
                    }
                    else
                    {
                        bigScore[j] = 3;
                    }
                }
                if (left1Value > left2Value)
                {
                    bigScore[left1Index] = 1;
                    bigScore[left2Index] = 0;
                }
                else if (left1Value == left2Value)
                {
                    bigScore[left1Index] = 0.5;
                    bigScore[left2Index] = 0.5;
                }
                else
                {
                    bigScore[left1Index] = 0;
                    bigScore[left2Index] = 1;
                }
            }
            else if (bigestCount == 3)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (totals[j] == bigest)
                    {
                        bigScore[j] = 2.33;
                    }
                    else
                    {
                        bigScore[j] = 0;
                    }
                }
            }
            else
            {
                bigScore[0] = bigScore[1] = bigScore[2] = bigScore[3] = 1.75;
            }
            return bigScore;
        }

       
        public void init()
        {
            roundPath = "scores\\"+generateID()+"\\";
            Directory.CreateDirectory(roundPath);
            this.currentRound = 0;
            dong = "";
            nan = "";
            xi = "";
            bei = "";
            this.judgerName = "";
            saved = false;
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    gameInfo[i, j] = 0;
                }
                fans[i] = "";
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
            saveXML();

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

        public void saveXML()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlElement root = doc.CreateElement("game");
                doc.AppendChild(root);
                XmlAttribute dongAttr = doc.CreateAttribute("dong");
                dongAttr.Value = dong;
                XmlAttribute nanAttr = doc.CreateAttribute("nan");
                nanAttr.Value = nan;
                XmlAttribute xiAttr = doc.CreateAttribute("xi");
                xiAttr.Value = xi;
                XmlAttribute beiAttr = doc.CreateAttribute("bei");
                beiAttr.Value = bei;
                XmlAttribute refereeAttr = doc.CreateAttribute("referee");
                refereeAttr.Value = judgerName;
                root.Attributes.Append(dongAttr);
                root.Attributes.Append(nanAttr);
                root.Attributes.Append(xiAttr);
                root.Attributes.Append(beiAttr);
                root.Attributes.Append(refereeAttr);
                for (int i = 0; i < 16; i++)
                {
                    XmlElement scoreNode = doc.CreateElement("round");
                    XmlAttribute dongScore = doc.CreateAttribute("dong");
                    dongScore.Value = "" + gameInfo[i, 0];
                    XmlAttribute nanScore = doc.CreateAttribute("nan");
                    nanScore.Value = "" + gameInfo[i, 1];
                    XmlAttribute xiScore = doc.CreateAttribute("xi");
                    xiScore.Value = "" + gameInfo[i, 2];
                    XmlAttribute beiScore = doc.CreateAttribute("bei");
                    beiScore.Value = "" + gameInfo[i, 3];
                    XmlAttribute fan = doc.CreateAttribute("fan");
                    fan.Value = fans[i];
                    scoreNode.Attributes.Append(dongScore);
                    scoreNode.Attributes.Append(nanScore);
                    scoreNode.Attributes.Append(xiScore);
                    scoreNode.Attributes.Append(beiScore);
                    scoreNode.Attributes.Append(fan);
                    root.AppendChild(scoreNode);
                }
                doc.Save(roundPath + "score.xml");
            }
            catch (Exception e)
            {

            }
        }

    }
}
