﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MahjongScroeBoard
{
    class QQNumberParser
    {
        private static Bitmap[] numbers = {
                                              
                                              new Bitmap("numberdata\\0.bmp"),
        new Bitmap("numberdata\\1.bmp"),
         new Bitmap("numberdata\\2.bmp"),
        new Bitmap("numberdata\\3.bmp"),
         new Bitmap("numberdata\\4.bmp"),
         new Bitmap("numberdata\\5.bmp"),
        new Bitmap("numberdata\\6.bmp"),
         new Bitmap("numberdata\\7.bmp"),
         new Bitmap("numberdata\\8.bmp"),
        new Bitmap("numberdata\\9.bmp")
                                          };

        public static int getNumber(Bitmap source)
        {
            if (source.Height < 5)
            {
                return -1;
            }

            double currentRate = 0;
            int currentNumber = 0;
            for (int i = 0; i < 10; i++)
            {
                double matchRate = ImageUtils.getmatchRate(source, numbers[i]);
                //Console.WriteLine(i+" "+matchRate);
                if (matchRate > 0.95)
                {
                    return i;
                }
                if (matchRate > currentRate)
                {
                    currentRate = matchRate;
                    currentNumber = i;
                }

            }
            if (currentRate < 0.8)
            {
                return 0;
            }
            return currentNumber;
        }
       

    }
}
