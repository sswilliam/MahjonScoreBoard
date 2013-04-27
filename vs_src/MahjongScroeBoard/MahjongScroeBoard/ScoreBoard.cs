using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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

            try
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
    }
}
