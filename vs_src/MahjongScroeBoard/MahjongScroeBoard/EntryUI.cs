﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            ViewManager.snapshotScoreBoardUI = new SnapshotScoreBoard();
            this.dongRadio.Checked = true;
            this.thridPartyCheck.Checked = false;
            syncJudgement();
            FanNameParser.getInstance().init();

           /* printArrays(new int[] { 4, 4, 4, 4 });
            printArrays(new int[] { 4, 3, 2, 1 });
            printArrays(new int[] { 1, 4, 3, 2 });
            printArrays(new int[] { 2, 1, 4, 3 });
            printArrays(new int[] { 3, 2, 1, 4 });
            printArrays(new int[] { 1, 2, 3, 4 });
            printArrays(new int[] { 4, 1, 2,3 });
            printArrays(new int[] { 3, 4, 1, 2});
            printArrays(new int[] { 2, 3, 4, 1 });


            printArrays(new int[] { 4, 4, 4, 1 });
            printArrays(new int[] { 4, 4, 1, 4 });
            printArrays(new int[] { 4, 1, 4, 4 });
            printArrays(new int[] { 1, 4, 4, 4 });


            printArrays(new int[] { 4, 4, 2, 2 });
            printArrays(new int[] { 4, 2, 4, 2 });
            printArrays(new int[] { 2, 4, 4, 2 });
            printArrays(new int[] { 2, 4, 2, 4 });
            printArrays(new int[] { 2, 2, 4, 4 });
            printArrays(new int[] { 4, 2, 2, 4 });


            printArrays(new int[] { 4, 4, 2, 1 });
            printArrays(new int[] { 4, 2, 4, 1 });
            printArrays(new int[] { 2, 4, 4, 1 });
            printArrays(new int[] { 1, 4, 2, 4 });
            printArrays(new int[] { 1, 2, 4, 4 });
            printArrays(new int[] { 4, 1, 2, 4 });


            printArrays(new int[] { 4, 4, 1, 2 });
            printArrays(new int[] { 4, 1, 4, 2 });
            printArrays(new int[] { 1, 4, 4, 2 });
            printArrays(new int[] { 2, 4, 1, 4 });
            printArrays(new int[] { 2, 1, 4, 4 });
            printArrays(new int[] { 4, 2, 1, 4 });

            printArrays(new int[] { 1, 4, 2, 2 });
            printArrays(new int[] { 1, 2, 4, 2 });
            printArrays(new int[] { 2, 1, 4, 2 });
            printArrays(new int[] { 2, 1, 2, 4 });
            printArrays(new int[] { 2, 2, 1, 4 });
            printArrays(new int[] { 1, 2, 2, 4 });

            printArrays(new int[] { 4, 1, 2, 2 });
            printArrays(new int[] { 4, 2, 1, 2 });
            printArrays(new int[] { 2, 4, 1, 2 });
            printArrays(new int[] { 2, 4, 2, 1 });
            printArrays(new int[] { 2, 2, 4, 1 });
            printArrays(new int[] { 4, 2, 2, 1 });


            printArrays(new int[] { 4, 1, 1, 1 });
            printArrays(new int[] { 1, 2, 1, 1 });
            printArrays(new int[] { 1, 1, 3, 1 });
            printArrays(new int[] { 1, 1, 1, 4 });*/
        }
        private void printArrays(int[] source)
        {
            Console.Write('<');
            for (int i = 0; i < 4; i++)
            {
                Console.Write(source[i]);
                Console.Write(',');
            }

            Console.Write("> is <");
            double[] target = Game.getInstance().getBigScore(source);
            for (int i = 0; i < 4; i++)
            {
                Console.Write(target[i]);
                Console.Write(',');
            }
            Console.WriteLine('>');
        }
        
        private void fightBtn_Click(object sender, EventArgs e)
        {
            //SnapshotTaker.takeImage();
            //return;
            try
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
                if (thridPartyCheck.Checked)
                {
                    if (thirdPartyName.Text.Trim().Length == 0)
                    {
                        entryInfo.Text = "第三方裁判名为空";
                        return;

                    }
                    else
                    {
                        Game.getInstance().judgerName = thirdPartyName.Text.Trim();
                    }
                }
                else
                {
                    if (dongRadio.Checked)
                    {
                        Game.getInstance().judgerName = dongName.Text.Trim();
                    }
                    if (nanRadio.Checked)
                    {
                        Game.getInstance().judgerName = nanName.Text.Trim();
                    }
                    if (xiRadio.Checked)
                    {
                        Game.getInstance().judgerName = xiName.Text.Trim();
                    }
                    if (beiRadio.Checked)
                    {
                        Game.getInstance().judgerName = beiName.Text.Trim();
                    }
                }
                entryInfo.Text = "";
                ViewManager.entryUI.fade();
                ViewManager.manualScroeBoardUI.refreshDataSet();
                ViewManager.snapshotScoreBoardUI.refreshDataSet();
                ViewManager.scoreBoardUI.resetAndDisplay();
            }
            catch (Exception ex)
            {
                Alarmer.Show(ex.Message);
            }
           // SnapshotTaker.windowCount = 0;
            //SnapshotTaker.takeImage();
           // return;
           

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
            this.dongRadio.Checked = true;
            this.thridPartyCheck.Checked = false;
            syncJudgement();
            this.Visible = true;
        }

        private void EntryUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void thridPartyCheck_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("changed");
            syncJudgement();
        }

        public void syncJudgement()
        {
            if (this.thridPartyCheck.Checked)
            {
                this.dongRadio.Enabled = false;
                this.nanRadio.Enabled = false;
                this.xiRadio.Enabled = false;
                this.beiRadio.Enabled = false;
                this.thirdPartyName.Enabled = true;
            }
            else
            {
                this.dongRadio.Enabled = true;
                this.nanRadio.Enabled = true;
                this.xiRadio.Enabled = true;
                this.beiRadio.Enabled = true;
                this.thirdPartyName.Enabled = false;
            }
        }


    }
}
