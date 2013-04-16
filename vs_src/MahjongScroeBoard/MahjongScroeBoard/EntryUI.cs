using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace MahjongScroeBoard
{
    public partial class EntryUI : Form
    {
        public EntryUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ViewManager.entryUI = this;
            ViewManager.manualScroeBoardUI = new ManualScoreBoard();
            ViewManager.scoreBoardUI = new ScoreBoard();
        }
        
        private void fightBtn_Click(object sender, EventArgs e)
        {
            if (dongName.Text.Trim().Length == 0)
            {
                entryInfo.Text = "东家姓名为空";
                return;
            }
            if (nanName.Text.Trim().Length == 0)
            {
                entryInfo.Text = "南家姓名为空";
                return;
            }
            if (xiName.Text.Trim().Length == 0)
            {
                entryInfo.Text = "西家姓名为空";
                return;
            }
            if (beiName.Text.Trim().Length == 0)
            {
                entryInfo.Text = "北家姓名为空";
                return;
            }
            if (dongName.Text.Trim() == nanName.Text.Trim() ||
                dongName.Text.Trim() == xiName.Text.Trim() ||
                dongName.Text.Trim() == beiName.Text.Trim() ||
                nanName.Text.Trim() == xiName.Text.Trim() ||
                nanName.Text.Trim() == beiName.Text.Trim() ||
                xiName.Text.Trim() == beiName.Text.Trim())
            {
                entryInfo.Text = "姓名重复";
                return;
            }
            Game.getInstance().init();
            Game.getInstance().dong = dongName.Text.Trim();
            Game.getInstance().nan = nanName.Text.Trim();
            Game.getInstance().xi = xiName.Text.Trim();
            Game.getInstance().bei = beiName.Text.Trim();
            entryInfo.Text = "";
            ViewManager.entryUI.fade();
            ViewManager.manualScroeBoardUI.refreshDataSet();
            ViewManager.scoreBoardUI.resetAndDisplay();

        }
        public void fade()
        {
            this.Visible = false;
            
        }

        public void resetAndDisplay()
        {
            Game.getInstance().init();
            dongName.Text = "";
            nanName.Text = "";
            xiName.Text = "";
            beiName.Text = "";
            this.Visible = true;
        }

        private void EntryUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        


    }
}
