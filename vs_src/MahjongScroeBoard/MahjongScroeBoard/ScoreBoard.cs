using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MahjongScroeBoard
{
    public partial class ScoreBoard : Form
    {
        private Button[] snapshots;
        private Button[] manuals;
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

            for (int i = 0; i < manuals.Length; i++)
            {
                
                manuals[i].Click += new System.EventHandler(this.manual_Click);
                
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
                if (!Game.getInstance().saved)
                {
                    DialogResult result = MessageBox.Show("比赛结果尚未保存,确定要退出么？", "关闭", MessageBoxButtons.OKCancel);
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

        private String[] dnxbString = { "东","南","西","北"};

        private void copyBtn_Click(object sender, EventArgs e)
        {
            int firstLeng = 10;
            int dongLeng = getNameSpace(Game.getInstance().dong.Length);
            int nanLeng = getNameSpace(Game.getInstance().nan.Length);
            int xiLeng = getNameSpace(Game.getInstance().xi.Length);
            int beiLeng = getNameSpace(Game.getInstance().bei.Length);
            int[] lengs = {dongLeng, nanLeng, xiLeng, beiLeng};
            StringBuilder sb = new StringBuilder();
            sb.Append(fillString("", firstLeng, ' '));
            sb.Append(fillString(Game.getInstance().dong, dongLeng, ' '));
            sb.Append(fillString(Game.getInstance().nan, nanLeng, ' '));
            sb.Append(fillString(Game.getInstance().xi, xiLeng, ' '));
            sb.Append(fillString(Game.getInstance().bei, beiLeng, ' '));
            sb.Append('\n');
            int[] totals = { 0, 0, 0, 0 };
            for (int i = 0; i < 16; i++)
            {
                if (i % 4 == 0)
                {
                    sb.Append(fillString(dnxbString[i/4],firstLeng,' '));
                }else{
                    sb.Append(fillString("",firstLeng,' '));
                }
                for(int j = 0;j<4;j++){
                    sb.Append(fillString(Game.getInstance().gameInfo[i, j] + "", lengs[j], ' '));
                    totals[j] += Game.getInstance().gameInfo[i, j];
                }
                sb.Append('\n');
            }
            sb.Append(fillString("",firstLeng+dongLeng+nanLeng+xiLeng+beiLeng,'-'));
            sb.Append('\n');
            sb.Append(fillString("总计", firstLeng, ' '));
            for (int i = 0; i < 4; i++)
            {
                sb.Append(fillString(totals[i] + "", lengs[i], ' '));
            }
            Console.WriteLine(sb.ToString());
            Clipboard.SetDataObject(sb.ToString());
            //String result =  
        }

        private int getNameSpace(int stringLength)
        {
            return (stringLength / 5) * 5 + 10;
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

     

        private void manual_Click(object sender, EventArgs e)
        {
            Button target = (Button)sender;
            String number = target.Name.Substring(6);
            int index = Int32.Parse(number);
            Console.WriteLine("curent "+(index - 1));
            ViewManager.manualScroeBoardUI.resetAndDisplay(index - 1);
        }

        
    }
}
