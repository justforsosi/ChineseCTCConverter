using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ChineseTTCodeToChinese
{
    public static class ChinesTTCodeToChinese
    {
        public static string ConvertToChineseCharacter(string _TTCode, string fileName="")
        {
            string _chineseCharacter = string.Empty;
            //JSon source folder
            string _jsonFilePath = string.IsNullOrEmpty(fileName)? Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "\\dict") + @"\ctc2hanzi.json" : fileName;
            Dictionary<string, string> items = LoadJson(_jsonFilePath);
            //split TT code, delimited by space
            string[] _listOfCodes = _TTCode.Split(' ');
            string pattern = @"^[0-9]{4}$";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            foreach (string code in _listOfCodes)
            {
                if (rgx.IsMatch(code))
                    //check if it's exactly 4 digits
                    _chineseCharacter += " " + items[code];
            }
            return _chineseCharacter.Trim();
        }
        public static Dictionary<string, string> LoadJson(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                Dictionary<string,string> items = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                return items;
            }
        }

    }
}
