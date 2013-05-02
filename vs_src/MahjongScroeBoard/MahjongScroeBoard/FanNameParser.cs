using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Drawing;

namespace MahjongScroeBoard
{
    class FanNameParser
    {
        private static FanNameParser instance = new FanNameParser();
        private Hashtable table;
        private Boolean inited = false;
        private ArrayList words;
        private ArrayList snapshorts;
        private FanNameParser()
        {
            
        }
        public static FanNameParser getInstance()
        {
            return instance;
        }
        public String getFan(ArrayList source)
        {
            ArrayList nameList = new ArrayList();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < source.Count; i++)
            {
                String word = getTextFromBitmap((Bitmap)source[i]);
                nameList.Add(word);
                sb.Append(word);
                sb.Append("_");
            }
            sb.Remove(sb.Length - 1, 1);
            Console.WriteLine(sb.ToString());
            String fanName = (String)table[sb.ToString()];
            if (fanName == null || fanName.Length == 0)
            {
                return "未识别番种";
            }
            else
            {
                return fanName;
            }
        }
        public String getTextFromBitmap(Bitmap source)
        {
            if (source.Height < 3)
            {
                return "yi";
            }
            int index = -1;
            double currentMatchRate = 0;
            for (int i = 0; i < snapshorts.Count; i++)
            {
                double matchRate = ImageUtils.getmatchRate(source,(Bitmap)snapshorts[i]);
                if(matchRate > 0.98){
                    currentMatchRate = matchRate;
                    index = i;
                    break;
                }
                if (matchRate > currentMatchRate)
                {
                    index = i;
                    currentMatchRate = matchRate;
                }
            }
            //Console.WriteLine("Match Rate: " + currentMatchRate + (String)words[index]);
            return (String)words[index];
           
        }
        
        public Boolean init()
        {
            if(inited){
                return true;
            }
            try{
                this.table = new Hashtable();
                words = new ArrayList();
                snapshorts = new ArrayList();
                if (!File.Exists("fandata\\fanlist.txt"))
                {
                    return false;
                }
                StreamReader reader = new StreamReader("fandata\\fanlist.txt");
                String line;
                ArrayList lines = new ArrayList();
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
                reader.Close();
                for (int i = 0; i < lines.Count; i++)
                {
                    String tempLine = (String)lines[i];
                    String[] blocks = tempLine.Split('#');
                    if (blocks.Length == 2)
                    {
                        table.Add(blocks[1].ToString(), blocks[0].ToString());
                    }
                }
                Console.WriteLine("===================");
                Console.WriteLine(table["aaa"]);
                Console.WriteLine(table["hu_jue_zhang"]);
                Console.WriteLine("===================");
                DirectoryInfo dir = new DirectoryInfo("fandata");
                FileInfo[] files = dir.GetFiles();
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Name.EndsWith(".bmp"))
                    {
                        snapshorts.Add(new Bitmap(files[i].FullName));
                        words.Add(files[i].Name.Substring(0, files[i].Name.Length - 4));
                    }
                }
                for (int i = 0; i < words.Count; i++)
                {
                    Console.WriteLine(words[i]);
                }
                    return true;
            }catch(Exception e){
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
