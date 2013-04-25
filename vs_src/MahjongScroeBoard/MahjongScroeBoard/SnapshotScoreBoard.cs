using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing;
using System.Collections;

namespace MahjongScroeBoard
{
    public partial class SnapshotScoreBoard : Form
    {
        private int targetRow = 0;
        private Bitmap cachedImage;
        private TextBox[] scoreViews;
        private int[] scoresContents = { 0, 0, 0, 0 };
        public SnapshotScoreBoard()
        {
            InitializeComponent();
            scoreViews = new TextBox[]{
                dongScore,nanScore,xiScore,beiScore
            };

        }

        public void resetAndDisplay(int targetRow,Bitmap sourceImage)
        {
            this.targetRow = targetRow;
            this.cachedImage = sourceImage;
            //this.cachedImage = new Bitmap("t"+targetRow+".jpg");
           // Console.WriteLine(Game.getInstance().roundPath + (targetRow+1) + ".jpg");
            this.cachedImage.Save(Game.getInstance().roundPath + (targetRow + 1) + ".jpg", ImageFormat.Jpeg);
            //Bitmap core = new Bitmap(410, 435, PixelFormat.Format24bppRgb);
            int outwidth = this.cachedImage.Width - 190;
            int outHeight = this.cachedImage.Height;
            int startX = (outwidth - 410) / 2-4;
            int startY = (outHeight - 435) / 2-49;
            Rectangle rg = new Rectangle(startX, startY, 410, 435);
            Bitmap core = this.cachedImage.Clone(rg, PixelFormat.Format24bppRgb);
            //Graphics g = Graphics.FromImage(core);
            //g.DrawImage(this.cachedImage, rg);
            this.snapshotContent.Image = core;
            //core.Save(Game.getInstance().roundPath + (targetRow + 1) + "s.jpg", ImageFormat.Jpeg);

            for (int i = 0; i < 4; i++)
            {

                ArrayList colors = new ArrayList();
                Rectangle scoreRect = new Rectangle(285, 276+i*20, 50, 20);
                Bitmap score = core.Clone(scoreRect, PixelFormat.Format24bppRgb);
               // score.Save(Game.getInstance().roundPath + (targetRow + 1) + "s_" + i + ".jpg", ImageFormat.Jpeg);
               
                Bitmap bwScore = new Bitmap(50, 20, PixelFormat.Format24bppRgb);
                
                for (int w = 0; w < 50; w++)
                {
                    for (int h = 0; h < 20; h++)
                    {
                        Color color = score.GetPixel(w, h);
                        if (color.R > 180 && color.G > 180 && color.B > 180)
                        {
                            bwScore.SetPixel(w, h, Color.White);
                        }
                        else
                        {
                            bwScore.SetPixel(w, h, Color.Black);
                        }
                       
                    }

                    //Console.Write("\n");
                }
                ArrayList spiltedImages = new ArrayList();
                Boolean isBlack = true;
                int beginX = 0;
                for (int w = 0; w < 50; w++)
                {
                    Boolean hasWhite = false;
                    for (int h = 0; h < 20; h++)
                    {
                        Color currentPoint = bwScore.GetPixel(w, h);
                        if (currentPoint.R == 255 && currentPoint.G == 255 && currentPoint.B == 255)
                        {
                            hasWhite = true;
                            break;
                        }
                    }
                    if (hasWhite)
                    {
                        if (isBlack)
                        {
                            beginX = w;
                            isBlack = false;
                        }
                    }
                    else
                    {
                        if (!isBlack)
                        {
                            isBlack = true;
                            Rectangle speiteBlock = new Rectangle(beginX,0,w - beginX,20);
                            Bitmap spiteItem = cutBlackHeadAndTail(bwScore.Clone(speiteBlock, PixelFormat.Format24bppRgb));
                            //spiteItem.Save(Game.getInstance().roundPath + (targetRow + 1) + "wb_" + i + "(" + spiltedImages.Count + ").bmp", ImageFormat.Bmp);
                            spiltedImages.Add(spiteItem);
                        }
                    }
                }

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
                    scoreViews[i].Text = ""+totalNumber;
                    scoresContents[i] = totalNumber;
                }
                    
               // bwScore.Save(Game.getInstance().roundPath + (targetRow + 1) + "wb_" + i + ".bmp", ImageFormat.Bmp);
            }

            Console.WriteLine("------------------------------------------------");

            this.ShowDialog(ViewManager.scoreBoardUI);

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

        private Bitmap cutBlackHeadAndTail(Bitmap source)
        {
            int startY = 0;
            for (int i = 0; i < source.Height; i++)
            {
                Boolean hasWhite = false;
                
                for (int j = 0; j < source.Width; j++)
                {
                    Color currentPoint = source.GetPixel(j,i);
                    if (currentPoint.R == 255 && currentPoint.G == 255 && currentPoint.B == 255)
                    {
                        hasWhite = true;
                        break;
                    }
                }
                if (hasWhite)
                {
                    startY = i;
                    break;
                }
            }
            int endY = source.Height - 1;
            for (int i = source.Height - 1; i > -1; i--)
            {
                Boolean hasWhite = false;

                for (int j = 0; j < source.Width; j++)
                {
                    Color currentPoint = source.GetPixel(j, i);
                    if (currentPoint.R == 255 && currentPoint.G == 255 && currentPoint.B == 255)
                    {
                        hasWhite = true;
                        break;
                    }
                }
                if (hasWhite)
                {
                    endY = i+1;
                    break;
                }
            }

            return source.Clone(new Rectangle(0, startY, source.Width, endY - startY),PixelFormat.Format24bppRgb);
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
                    for(int i =0;i<4;i++){

                        Game.getInstance().gameInfo[this.targetRow, i] = this.scoresContents[i];
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

        
      
        
    }
}
