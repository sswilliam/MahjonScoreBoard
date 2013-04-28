using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;

namespace MahjongScroeBoard
{
    class ImageUtils
    {
        public static double getmatchRate(Bitmap source, Bitmap target)
        {
            int minWidth = Math.Min(source.Width, target.Width);
            int minHeight = Math.Min(source.Height, target.Height);
            int matchCount = 0;
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    if (i < minWidth && j < minHeight)
                    {
                        if (source.GetPixel(i, j).ToArgb() == target.GetPixel(i, j).ToArgb())
                        {
                            matchCount++;
                        }
                    }
                    else
                    {
                        matchCount--;
                    }
                    
                }
            }
            
                return (1.0 * matchCount) / (target.Width * target.Height);
        }
        public static ArrayList spiltImage(Bitmap source)
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
                        Bitmap spiteItem = cutBoard(source.Clone(speiteBlock, PixelFormat.Format24bppRgb));
                        //spiteItem.Save(Game.getInstance().roundPath + (targetRow + 1) + "wb_" + i + "(" + spiltedImages.Count + ").bmp", ImageFormat.Bmp);
                        spiltedImages.Add(spiteItem);
                    }
                }
            }
            return spiltedImages;
        }
        private static Bitmap cutBoard(Bitmap source)
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

        public static Bitmap toBinaryImage(Bitmap source)
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
    }
}
