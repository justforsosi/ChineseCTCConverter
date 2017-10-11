using ChineseTTCodeToChinese;
using System;

namespace ChineseTTTranslation
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\Users\li.zhu\Documents\visual studio 2015\Projects\ChineseTTTranslation\dict\ctc2hanzi.json";
            string _TTCode = "ABCD 0001 0001";
            string chinesechar = ChinesTTCodeToChinese.ConvertToChineseCharacter(_TTCode, fileName);
            string pinyin = chinesechar.ToPinYin();
            Console.WriteLine(string.Format("TTCode:{0} Pinyin:{1}", _TTCode, pinyin));
            Console.ReadLine();
        }
    }
}
