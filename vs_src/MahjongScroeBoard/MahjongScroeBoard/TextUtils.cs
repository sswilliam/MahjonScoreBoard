using System;
using System.Collections.Generic;
using System.Text;

namespace MahjongScroeBoard
{
    class TextUtils
    {
        public static String fillString(String source, int length, char withChar)
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
    }
}
