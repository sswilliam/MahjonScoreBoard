using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MahjongScroeBoard
{
    class ImageMatirxUtils
    {

        public static void toFile(Bitmap source, string path)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    if (source.GetPixel(i, j).ToArgb() == Color.White.ToArgb())
                    {
                        sb.Append('1');
                    }
                    else
                    {
                        sb.Append('0');
                    }
                }
                sb.Append('\n');
            }
        }
        public int[,] getMatirxFromFile(string path)
        {
            return null;
        }
    }
}
