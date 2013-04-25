using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MahjongScroeBoard
{
    class Alarmer
    {
        public static void Show(String text)
        {
            MessageBox.Show("Error："+text);
        }
    }
}
