using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MahjongScroeBoard
{
    public partial class ManualScoreBoard : Form
    {
        private int targetRow;
        public ManualScoreBoard()
        {
            InitializeComponent();
        }

        public void refreshDataSet()
        {
            this.winnerName.Items.Clear();
            this.winnerName.Items.Add(Game.getInstance().dong);
            this.winnerName.Items.Add(Game.getInstance().nan);
            this.winnerName.Items.Add(Game.getInstance().xi);
            this.winnerName.Items.Add(Game.getInstance().bei);

            this.paoMember.Items.Clear();
            this.paoMember.Items.Add(Game.getInstance().dong);
            this.paoMember.Items.Add(Game.getInstance().nan);
            this.paoMember.Items.Add(Game.getInstance().xi);
            this.paoMember.Items.Add(Game.getInstance().bei);

            this.fanNumber.Items.Clear();
            for (int i = 8; i < 200; i++)
            {
                this.fanNumber.Items.Add("" + i);
            }
        }

        public void resetAndDisplay(int target)
        {

            this.selfMo.Checked = false;
            this.winnerName.SelectedIndex = -1;
            this.paoMember.SelectedIndex = -1;
            this.paoMember.Enabled = true;
            this.targetRow = target;
            this.ManualInfo.Text = "";
            this.ShowDialog(ViewManager.scoreBoardUI);

        }
        public void fade()
        {
            if (this.Visible)
            {
                this.Visible = false;
            }
        }
        private void ManualScoreBoard_Load(object sender, EventArgs e)
        {

            Console.WriteLine("manual score board load");
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            handleClose();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine(winnerName.SelectedIndex);
            Console.WriteLine(winnerName.Text);
            Console.WriteLine(paoMember.SelectedIndex);
            Console.WriteLine(paoMember.Text);
            Console.WriteLine(fanNumber.Text);
            if (winnerName.SelectedIndex == -1)
            {
                ManualInfo.Text = "赢家没有选择";
                return;
            }
            if (paoMember.SelectedIndex == -1 && !selfMo.Checked)
            {
                ManualInfo.Text = "点炮者没有选择";
                return;
            }
            if (winnerName.SelectedIndex == paoMember.SelectedIndex && !selfMo.Checked)
            {
                ManualInfo.Text = "赢家和点炮者不能是同一个人";
                return;
            }
            if (fanNumber.Text.Trim().Length == 0)
            {
                ManualInfo.Text = "番数没有指定";
                return;
            }
            int fan = 0;
            try
            {
               fan = Int32.Parse(fanNumber.Text);
                if (fan < 8)
                {
                    ManualInfo.Text = "输入不是大于7的整数";
                    return;
                }
                if (fan > 332)
                {
                    ManualInfo.Text = "别骗自己了，你胡的出来这么高么";
                    return;
                }
            }
            catch (Exception ex)
            {
                ManualInfo.Text = "输入不是大于7的整数";
                return;
            }
            ManualInfo.Text = "";
            Console.WriteLine("success");


            if (selfMo.Checked)
            {
                Game.getInstance().gameInfo[this.targetRow,winnerName.SelectedIndex] = (fan + 8) * 3;
                for (int i = 0; i < 4; i++)
                {
                    if (i == winnerName.SelectedIndex)
                    {
                    }
                    else
                    {
                        Game.getInstance().gameInfo[this.targetRow, i] = (fan + 8) * -1;
                    }
                }
            }
            else
            {
                Game.getInstance().gameInfo[this.targetRow, winnerName.SelectedIndex] = fan + 24;
                Game.getInstance().gameInfo[this.targetRow, paoMember.SelectedIndex] = (fan + 8) * -1;
                for (int i = 0; i < 4; i++)
                {
                    if (i == winnerName.SelectedIndex || i == paoMember.SelectedIndex)
                    {
                    }
                    else
                    {
                        Game.getInstance().gameInfo[this.targetRow, i] = -8;
                    }
                }
            }
            ViewManager.scoreBoardUI.refreshScore();
            this.fade();
        }

        private void handleClose()
        {
            if (this.Visible)
            {
                this.Visible = false;
            }
        }

        private void ManualScoreBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            handleClose();
        }

        private void selfMo_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine(selfMo.Checked);
            if (selfMo.Checked)
            {

                paoMember.SelectedIndex = -1;
                paoMember.Enabled = false;
            }
            else
            {
                paoMember.Enabled = true;
                paoMember.SelectedIndex = -1;
            }
        }

    }
}
