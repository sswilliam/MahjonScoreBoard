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
        public SnapshotScoreBoard()
        {
            InitializeComponent();
        }

        public void resetAndDisplay(int targetRow)
        {
            this.targetRow = targetRow;
            //this.cachedImage = (Bitmap)SnapshotTaker.takeImage();
            this.cachedImage = new Bitmap("t"+targetRow+".jpg");
            Console.WriteLine(Game.getInstance().roundPath + (targetRow+1) + ".jpg");
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
            core.Save(Game.getInstance().roundPath + (targetRow + 1) + "s.jpg", ImageFormat.Jpeg);

            for (int i = 0; i < 4; i++)
            {

                ArrayList colors = new ArrayList();
                Rectangle scoreRect = new Rectangle(285, 276+i*20, 50, 20);
                Bitmap score = core.Clone(scoreRect, PixelFormat.Format24bppRgb);
                score.Save(Game.getInstance().roundPath + (targetRow + 1) + "s_" + i + ".jpg", ImageFormat.Jpeg);
               
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
                bwScore.Save(Game.getInstance().roundPath + (targetRow + 1) + "wb_" + i + ".jpg", ImageFormat.Jpeg);
            }

            Console.WriteLine("------------------------------------------------");

            this.ShowDialog(ViewManager.scoreBoardUI);

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

        }

      
        
    }
}
