using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Collections;
using System.IO;

namespace MahjongScroeBoard
{
    public partial class SnapshotScoreBoard : Form
    {
        private int targetRow = 0;
        private Bitmap cachedImage;
        private TextBox[] scoreViews;
        private int[] scoresContents = { 0, 0, 0, 0 };
        private ArrayList fanlist = new ArrayList();
        public SnapshotScoreBoard()
        {
            InitializeComponent();
            scoreViews = new TextBox[]{
                dongScore,nanScore,xiScore,beiScore
            };

        }

        private void parsingImage(int targetRow, Bitmap sourceImage)
        {
            this.snapshotInfo.Text = "";
            this.targetRow = targetRow;
            this.cachedImage = sourceImage;
            for (int i = 0; i < 4; i++)
            {
                scoresContents[i] = 0;

            }
            dongScore.Text = scoresContents[0] + "";
            nanScore.Text = scoresContents[1] + "";
            xiScore.Text = scoresContents[2] + "";
            beiScore.Text = scoresContents[3] + "";
            //this.cachedImage = new Bitmap("t"+targetRow+".jpg");
            // Console.WriteLine(Game.getInstance().roundPath + (targetRow+1) + ".jpg");
            this.cachedImage.Save(Game.getInstance().roundPath + (targetRow + 1) + ".jpg", ImageFormat.Jpeg);
            //Bitmap core = new Bitmap(410, 435, PixelFormat.Format24bppRgb);
            int outwidth = this.cachedImage.Width - 190;
            int outHeight = this.cachedImage.Height;
            int startX = (outwidth - 410) / 2 - 4;
            int startY = (outHeight - 435) / 2 - 49;
            Rectangle rg = new Rectangle(startX, startY, 410, 435);
            Bitmap core = this.cachedImage.Clone(rg, PixelFormat.Format24bppRgb);
            //Graphics g = Graphics.FromImage(core);
            //g.DrawImage(this.cachedImage, rg);
            this.snapshotContent.Image = core;
            //core.Save(Game.getInstance().roundPath + (targetRow + 1) + "s.jpg", ImageFormat.Jpeg);

            for (int i = 0; i < 4; i++)
            {

                ArrayList colors = new ArrayList();
                Rectangle scoreRect = new Rectangle(285, 276 + i * 20, 50, 20);
                Bitmap score = core.Clone(scoreRect, PixelFormat.Format24bppRgb);
                // score.Save(Game.getInstance().roundPath + (targetRow + 1) + "s_" + i + ".jpg", ImageFormat.Jpeg);

                Bitmap bwScore = ImageUtils.toBinaryImage(score);
                ArrayList spiltedImages = ImageUtils.spiltImage(bwScore);
                object[] datas = spiltedImages.ToArray();
                if (datas.Length > 1)
                {
                    int first = QQNumberParser.getNumber((Bitmap)datas[0]);
                    int totalNumber;
                    if (first == -1)
                    {
                        totalNumber = -1 * getTotalNumberFromArray(datas, 1);
                    }
                    else
                    {
                        totalNumber = getTotalNumberFromArray(datas, 0);
                    }
                    Console.WriteLine("final score " + totalNumber);
                    scoreViews[i].Text = "" + totalNumber;
                    scoresContents[i] = totalNumber;
                }

                // bwScore.Save(Game.getInstance().roundPath + (targetRow + 1) + "wb_" + i + ".bmp", ImageFormat.Bmp);
            }
            if (scoresContents[0] == 0)
            {

                this.snapshotInfo.Text = "未检测任何结果，疑似荒庄";
            }
            StringBuilder sb = new StringBuilder();
            this.fanbox.Text = "";
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {

                    Rectangle fanRect = new Rectangle(35 + 120 * i, 153 + 25 * j, 120, 25);
                    Bitmap temp = core.Clone(fanRect, PixelFormat.Format24bppRgb);
                    temp.Save("test\\" + (targetRow + 1) + "fan_" + i + j + ".jpg");
                    Bitmap tempBW = ImageUtils.toBinaryImage(temp);
                    tempBW.Save("test\\" + (targetRow + 1) + "fan_" + i + j + "bw.jpg");

                    filterSinglePoints(tempBW);
                    tempBW.Save("test\\" + (targetRow + 1) + "fan_" + i + j + "bwf.jpg");

                    ArrayList names = ImageUtils.spiltImage(tempBW);
                    for (int k = 0; k < names.Count; k++)
                    {
                        ((Bitmap)names[k]).Save("test\\" + targetRow + i + j + k + ".bmp", ImageFormat.Bmp);
                    }
                    if (names.Count > 0)
                    {
                        String fanName = FanNameParser.getInstance().getFan(names);
                        sb.Append(fanName);
                        if (fanName.Length > 3)
                        {
                            sb.Append("\t\t");
                        }
                        else
                        {
                            sb.Append("\t\t\t");
                        }
                        fanlist.Add(fanName);
                        Console.Write(fanlist.Count % 2);
                        if(fanlist.Count % 3 == 0)
                        {
                            sb.Append("\r\n");
                        }
                        
                    }

                }
            }
            this.fanbox.Text = sb.ToString();
            Console.WriteLine("------------------------------------------------");

        }

        public void resetAndDisplay(int targetRow,Bitmap sourceImage)
        {
            this.retakeIndex = 0;
            this.fanlist.Clear();
            this.parsingImage(targetRow, sourceImage);
            this.ShowDialog(ViewManager.scoreBoardUI);

        }

       
        private void filterSinglePoints(Bitmap source)
        {
            for (int i = 60; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    if (isWhite(source.GetPixel(i, j)))
                    {
                        ArrayList traveledPoint = new ArrayList();
                        traveledPoint.Add(new Point(i, j));
                        Boolean b = testIsGroup(new Point(i, j), source, 8, 0, traveledPoint);
                        if (!b) 
                        {
                            source.SetPixel(i, j, Color.Black);
                        }
                    }
                }
            }

        }
        private Boolean isWhite(Color c)
        {
            if (c.R == 255 && c.G == 255 && c.B == 255)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean testIsGroup(Point pt, Bitmap source, int Count, int level, ArrayList traveledPoint)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i != 1 || j != 1)
                    {
                        int tx = pt.X + i - 1;
                        int ty = pt.Y + j - 1;
                        
                        //Console.Write("{" + tx + ":" + ty + "},");
                        if (notInList(tx, ty, traveledPoint) && tx > -1 && ty > -1 && tx < source.Width  && ty < source.Height)
                        {
                            Color targetColor = source.GetPixel(tx, ty);
                            if (isWhite(targetColor))
                            {
                                if (level == Count)
                                {
                                    return true;
                                }
                                else
                                {
                                    traveledPoint.Add(new Point(tx, ty));
                                    Boolean b = testIsGroup(new Point(tx, ty), source, Count, level + 1, traveledPoint);
                                    if (b)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        traveledPoint.RemoveAt(traveledPoint.Count - 1);
                                    }
                                }
                            }
                        }
                        else
                        {
                            //Console.wr
                        }
                    }

                }
            }
            return false;
        }
        public Boolean notInList(int tx, int ty, ArrayList points)
        {
            if (points == null)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < points.Count; i++)
                {
                    if (tx == ((Point)points[i]).X && ty == ((Point)points[i]).Y)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        

        public int getTotalNumberFromArray(object[] source, int first)
        {
            int total = 0;
            for (int i = source.Length - 1; i > first - 1; i--)
            {
                total += QQNumberParser.getNumber((Bitmap)source[i]) * ((int)Math.Pow(10, source.Length - 1 - i));
            }
            return total;
        }

       

        private void saveBtn_Click(object sender, EventArgs e)
        {

            this.snapshotInfo.Text = "";

           


            try
            {
                int number1 = Int32.Parse(this.dongScore.Text);
                int number2 = Int32.Parse(this.nanScore.Text);
                int number3 = Int32.Parse(this.xiScore.Text);
                int number4 = Int32.Parse(this.beiScore.Text);
                scoresContents[0] = number1;
                scoresContents[1] = number2;
                scoresContents[2] = number3;
                scoresContents[3] = number4;
                Boolean dataTrue = validateNumbers();
                if (dataTrue)
                {
                    for (int i = 0; i < 4; i++)
                    {

                        Game.getInstance().gameInfo[this.targetRow, i] = this.scoresContents[i];
                    }
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < this.fanlist.Count; i++)
                    {
                        sb.Append(fanlist[i]);
                        sb.Append(',');

                    }
                    String fanContent = sb.ToString();
                    Console.WriteLine(fanContent);
                    if (fanContent.Length > 0)
                    {
                        Game.getInstance().fans[this.targetRow] = fanContent.Substring(0, fanContent.Length - 1);
                    }
                    else
                    {
                        Game.getInstance().fans[this.targetRow] = "识别失败";
                    }
                    if (Game.getInstance().currentRound < 16)
                    {
                        Game.getInstance().currentRound++;
                        ViewManager.scoreBoardUI.gotoRound(Game.getInstance().currentRound);
                    }
                    ViewManager.scoreBoardUI.refreshScore();
                    this.fade();
                }

            }
            catch (Exception ex)
            {

                this.snapshotInfo.Text = "请输入整数";
            }
        }
        public void fade()
        {
            this.Visible = false;
        }
        public Boolean validateNumbers()
        {
            int win = 0;
            int lose1 = 0;
            int lose2 = 0;
            int lose3 = 0;
            int positiveNumber = 0;
            int negitaveNumber = 0;
            int negitage8cont = 0;
            if(scoresContents[0] == 0 && scoresContents[1]==0 && scoresContents[2] == 0 && scoresContents[3] == 0){
                this.snapshotInfo.Text = "未检测到任何数字，请确认是荒庄";
                return true;
            }

            for (int i = 0; i < 4; i++)
            {
                if (scoresContents[i] >31)
                {
                    positiveNumber++;
                    win = scoresContents[i];
                }
                if (scoresContents[i] < -7)
                {
                    negitaveNumber++;
                    if(scoresContents[i] == -8){
                        negitage8cont ++;
                    }
                }
            }
            if (positiveNumber != 1)
            {
                this.snapshotInfo.Text = "未检测到获胜番数";
                return false;
            }
            if (negitaveNumber != 3)
            {
                this.snapshotInfo.Text = "未检测到三家失败";
                return false;
            }
            if (negitage8cont != 2 && negitage8cont != 0)
            {

                this.snapshotInfo.Text = "不是自摸也不是点炮";
                return false;
            }
            int dianScore = 0; ;
            if (negitage8cont == 2)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (scoresContents[i] < -8)
                    {
                        dianScore = scoresContents[i];
                        break;
                    }
                }
                if (win - 8 - 8 + dianScore == 0)
                {
                    return true;
                }
                else
                {

                    this.snapshotInfo.Text = "输赢只和不为0";
                    return false;
                }
            }
            if (negitage8cont == 0)
            {
                int zimolose = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (scoresContents[i] < -15)
                    {
                        if (zimolose == 0)
                        {
                            zimolose = scoresContents[i];
                        }
                        else
                        {
                            if (scoresContents[i] != zimolose)
                            {

                                this.snapshotInfo.Text = "自摸的番数不等";
                                return false;
                            }
                        }
                    }
                }
                if (win + zimolose + zimolose + zimolose == 0)
                {

                    return true;
                }
                else
                {

                    this.snapshotInfo.Text = "输赢只和不为0";
                    return false;
                }
            }
            

                return false;
        }

        public void refreshDataSet()
        {
            dongName.Text = Game.getInstance().dong;
            nanName.Text = Game.getInstance().nan;
            xiName.Text = Game.getInstance().xi;
            beiName.Text = Game.getInstance().bei;

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.fade();
        }

        private void SnapshotScoreBoard_FormClosing(object sender, FormClosingEventArgs e)
        {

            e.Cancel = true;
            this.fade();
        }

        private int retakeIndex = 0;

        private ArrayList snapshots = new ArrayList();
        private void retakeBtn_Click(object sender, EventArgs e)
        {
            //if (snapshots.Count == 0)
           // {
            //    addSnapshot(new DirectoryInfo("testdata"));
           //     Console.WriteLine(snapshots.Count);
           // }
           // if(retakeIndex < snapshots.Count){
            //    this.snapshotInfo.Text = retakeIndex+"/"+snapshots.Count;
           //     Bitmap data = new Bitmap((String)snapshots[this.retakeIndex]);
            //    this.parsingImage(this.targetRow, data);
            //    this.snapshotInfo.Text = retakeIndex + "/" + snapshots.Count + " : " + this.snapshots[retakeIndex].ToString().Substring(40);
            //    retakeIndex++;
           // }
            Bitmap retakeData = MahjongGameManager.getInstance().takeSnapshot();
            this.parsingImage(this.targetRow, retakeData);
        }

        private void addSnapshot(DirectoryInfo root){
            DirectoryInfo[] dirs = root.GetDirectories();
            FileInfo[] files = root.GetFiles();
            for(int i = 0;i<files.Length;i++){
                if(files[i].Name.EndsWith(".jpg")){
                    snapshots.Add(files[i].FullName);
                }
            }
            for (int i = 0; i < dirs.Length; i++)
            {
                addSnapshot(dirs[i]);
            }
        }

        
      
        
    }
}
