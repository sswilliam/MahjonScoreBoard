using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;

namespace MahjongScroeBoard
{
    public partial class ScoreBoard : Form
    {
        private Button[] snapshots;
        private Button[] manuals;
        private Button[] zeros;
        private TextBox[][] scores;
        public ScoreBoard()
        {
            InitializeComponent();
            snapshots = new Button[] { 
                this.snapshot1, this.snapshot2, this.snapshot3, this.snapshot4, 
                this.snapshot5, this.snapshot6, this.snapshot7, this.snapshot8, 
                this.snapshot9, this.snapshot10, this.snapshot11, this.snapshot12, 
                this.snapshot13, this.snapshot14, this.snapshot15, this.snapshot16 
            };

            manuals = new Button[]{
                this.manual1,this.manual2,this.manual3,this.manual4,
                this.manual5,this.manual6,this.manual7,this.manual8,
                this.manual9,this.manual10,this.manual11,this.manual12,
                this.manual13,this.manual14,this.manual15,this.manual16
            };

            zeros = new Button[]{
                this.zeroBtn1,this.zeroBtn2,this.zeroBtn3,this.zeroBtn4,
                this.zeroBtn5,this.zeroBtn6,this.zeroBtn7,this.zeroBtn8,
                this.zeroBtn9,this.zeroBtn10,this.zeroBtn11,this.zeroBtn12,
                this.zeroBtn13,this.zeroBtn14,this.zeroBtn15,this.zeroBtn16
            };



            for (int i = 0; i < manuals.Length; i++)
            {
                
                manuals[i].Click += new System.EventHandler(this.manual_Click);
                
            }

            for (int i = 0; i < snapshots.Length; i++)
            {
                snapshots[i].Click += new System.EventHandler(this.snapshot_Click);
            }
            for (int i = 0; i < zeros.Length; i++)
            {
                zeros[i].Click += new System.EventHandler(this.zeroBtn_Click);
            }

                scores = new TextBox[][]{
                new TextBox[]{dong1,nan1,xi1,bei1},
                new TextBox[]{dong2,nan2,xi2,bei2},
                new TextBox[]{dong3,nan3,xi3,bei3},
                new TextBox[]{dong4,nan4,xi4,bei4},
                new TextBox[]{dong5,nan5,xi5,bei5},
                new TextBox[]{dong6,nan6,xi6,bei6},
                new TextBox[]{dong7,nan7,xi7,bei7},
                new TextBox[]{dong8,nan8,xi8,bei8},
                new TextBox[]{dong9,nan9,xi9,bei9},
                new TextBox[]{dong10,nan10,xi10,bei10},
                new TextBox[]{dong11,nan11,xi11,bei11},
                new TextBox[]{dong12,nan12,xi12,bei12},
                new TextBox[]{dong13,nan13,xi13,bei13},
                new TextBox[]{dong14,nan14,xi14,bei14},
                new TextBox[]{dong15,nan15,xi15,bei15},
                new TextBox[]{dong16,nan16,xi16,bei16}
            };
            
        }
        
        public void refreshScore()
        {
            int[] score = { 0, 0, 0, 0 };
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    scores[i][j].Text = Game.getInstance().gameInfo[i, j]+"";
                    score[j] += Game.getInstance().gameInfo[i, j];
                }
            }
            dongScore.Text = "("+score[0] + ")";
            nanScore.Text = "(" + score[1] + ")";
            xiScore.Text = "(" + score[2] + ")";
            beiScore.Text = "(" + score[3] + ")";
        }
        private void ScoreBoard_Load(object sender, EventArgs e)
        {
            Console.WriteLine("scoreboard load");
        }
        public void resetAndDisplay()
        {
            this.Visible = true;
            dongName.Text = Game.getInstance().dong;
            nanName.Text = Game.getInstance().nan;
            xiName.Text = Game.getInstance().xi;
            beiName.Text = Game.getInstance().bei;
            this.gotoRound(Game.getInstance().currentRound);
            refreshScore();
        }
        public void fade()
        {
            this.Visible = false;
        }

        private void ScoreBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            handleClose();
        }

        private void handleClose()
        {
            if (this.Visible)
            {
                if (Game.getInstance().currentRound != 16)
                {
                    DialogResult result = MessageBox.Show("比赛尚未结束,确定要退出么？", "关闭", MessageBoxButtons.OKCancel);
                    Console.WriteLine(result);
                    if (result == DialogResult.OK)
                    {
                        ViewManager.scoreBoardUI.fade();
                        ViewManager.entryUI.resetAndDisplay();
                    }
                }
                else
                {
                    ViewManager.scoreBoardUI.fade();
                    ViewManager.entryUI.resetAndDisplay();
                }
            }
           
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {

            
            handleClose();
            return;
            //DirectoryInfo root = new DirectoryInfo("testdata");
            //findFiles(root);
        }
        int imageCount = 0;
        private void findFiles(DirectoryInfo root)
        {
            FileInfo[] files = root.GetFiles();
            DirectoryInfo[] folders = root.GetDirectories();
            for (int k = 0; k < files.Length; k++)
            {
                //Console.Write(files[i].Name);
                if (files[k].Name.EndsWith(".jpg"))
                {
                    //Console.WriteLine(files[k].FullName);
                    Bitmap source = new Bitmap(files[k].FullName);
                    source.Save("result\\img_" + imageCount + ".jpg");
                    int outwidth = source.Width - 190;
                    int outHeight = source.Height;
                    int startX = (outwidth - 410) / 2 - 4;
                    int startY = (outHeight - 435) / 2 - 49;
                    Rectangle rg = new Rectangle(startX, startY, 410, 435);
                    Bitmap core = source.Clone(rg, PixelFormat.Format24bppRgb);

                  

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {

                            Rectangle fanRect = new Rectangle(35 + 120 * i, 153 + 25 * j, 120, 25);
                            Bitmap temp = core.Clone(fanRect, PixelFormat.Format24bppRgb);
                            Bitmap tempBW = getBWImage(temp);

                            filterSinglePoints(tempBW);

                            ArrayList names = seperateBlocks(tempBW);
                            
                            for (int m = 0; m < names.Count; m++)
                            {
                                ((Bitmap)names[m]).Save("result\\img_" + imageCount + "s_"+i + "_" + j + "_"+m+".bmp", ImageFormat.Bmp);
                            }
                            if (names.Count > 0)
                            {

                                tempBW.Save("result\\img_" + imageCount + "s_" + i + "_" + j + ".jpg");
                            }
                        }
                    }
                    imageCount++;

                }
            }
            for (int i = 0; i < folders.Length; i++)
            {
                findFiles(folders[i]);
            }
        }


        private void copyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(Game.getInstance().getScoreTable());
            }
            catch (Exception ex)
            {
                Alarmer.Show("Error when copy: " + ex.Message);
            }
            //String result =  
        }

       
     

     

        private void manual_Click(object sender, EventArgs e)
        {
            try
            {
                Button target = (Button)sender;
                String number = target.Name.Substring(6);
                int index = Int32.Parse(number);
                Console.WriteLine("curent " + (index - 1));
                ViewManager.manualScroeBoardUI.resetAndDisplay(index - 1);
            }
            catch (Exception ex)
            {
                Alarmer.Show("Error when open manual score borad: " + ex.Message);
            }

            
        }

        private void snapshot_Click(object sender, EventArgs e)
        {
            Button target = (Button)sender;
            String number = target.Name.Substring(8);
            int index = Int32.Parse(number);
            Console.WriteLine("curent " + (index - 1));
            //Bitmap sourceImage = SnapshotTaker.takeImage();
            Bitmap sourceImage = new Bitmap("t" + (index - 1) + ".jpg");
            if (sourceImage == null)
            {
                MessageBox.Show("检测QQ麻将游戏失败，请确定已开启游戏或联系开发者");
                return;
            }
            else
            {
                if (sourceImage.Height < 100)
                {
                    MessageBox.Show("QQ麻将游戏被最小化，请确保麻将已经打开");
                    return;
                }
                else
                {
                    ViewManager.snapshotScoreBoardUI.resetAndDisplay(index - 1, sourceImage);
                }
            }
            try
            {
               
            }
            catch (Exception ex)
            {
                Alarmer.Show("Error when open snapshot score borad: " + ex.StackTrace);
            }


           
        }

        private void zeroBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Button target = (Button)sender;
                String number = target.Name.Substring(7);
                int index = Int32.Parse(number);
                Console.WriteLine("curent " + (index - 1));
                for(int i = 0;i<4;i++){

                    Game.getInstance().gameInfo[index-1, i] = 0;
                }
                if (Game.getInstance().currentRound < 16)
                {
                    Game.getInstance().currentRound++;
                    this.gotoRound(Game.getInstance().currentRound);
                }
                
            }
            catch (Exception ex)
            {
                Alarmer.Show("Error when open snapshot score borad: " + ex.StackTrace);
            }
        }

        public void gotoRound(int round)
        {
            for (int i = 0; i < 16; i++)
            {
                if (i == round)
                {
                    snapshots[i].Enabled = true;
                    zeros[i].Enabled = true;
                }
                else
                {
                    snapshots[i].Enabled = false;
                    zeros[i].Enabled = false;
                }
            }
        }

        private void historyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine(System.AppDomain.CurrentDomain.BaseDirectory + "scores");
                
                System.Diagnostics.Process.Start("Explorer.exe", System.AppDomain.CurrentDomain.BaseDirectory+"scores");
                 
            }
            catch (Exception ex)
            {

                Alarmer.Show("Error when open folder: " + ex.Message);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Game.getInstance().save();

            }
            catch (Exception ex)
            {
                Alarmer.Show("Error when save score: " + ex.Message);

            }
        }






        public Bitmap getBWImage(Bitmap source)
        {
            Bitmap bwScore = new Bitmap(source.Width, source.Height, PixelFormat.Format24bppRgb);

            for (int w = 0; w < source.Width; w++)
            {
                for (int h = 0; h < source.Height; h++)
                {
                    Color color = source.GetPixel(w, h);
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
            return bwScore;
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
                        Boolean b = testIsGroup(new Point(i, j), source, 5, 0, traveledPoint);
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
                        if (notInList(tx, ty, traveledPoint) && tx > -1 && ty > -1 && tx < source.Width + 1 && ty < source.Height + 1)
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
        private ArrayList seperateBlocks(Bitmap source)
        {
            ArrayList spiltedImages = new ArrayList();
            Boolean isBlack = true;
            int beginX = 0;
            for (int w = 0; w < source.Width; w++)
            {
                Boolean hasWhite = false;
                for (int h = 0; h < source.Height; h++)
                {
                    Color currentPoint = source.GetPixel(w, h);
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
                        Rectangle speiteBlock = new Rectangle(beginX, 0, w - beginX, source.Height);
                        Bitmap spiteItem = cutBlackHeadAndTail(source.Clone(speiteBlock, PixelFormat.Format24bppRgb));
                        //spiteItem.Save(Game.getInstance().roundPath + (targetRow + 1) + "wb_" + i + "(" + spiltedImages.Count + ").bmp", ImageFormat.Bmp);
                        spiltedImages.Add(spiteItem);
                    }
                }
            }
            return spiltedImages;
        }
        private Bitmap cutBlackHeadAndTail(Bitmap source)
        {
            int startY = 0;
            for (int i = 0; i < source.Height; i++)
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
                    endY = i + 1;
                    break;
                }
            }

            return source.Clone(new Rectangle(0, startY, source.Width, endY - startY), PixelFormat.Format24bppRgb);
        }
    }
}
