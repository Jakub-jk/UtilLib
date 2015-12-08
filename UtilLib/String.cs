using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilLib
{
    public class StringUtil
    {
        public static string CutFromLastToEnd(string ToCut, char CutFrom)
        {
            if (!ToCut.Contains(CutFrom))
                return "Given string doesn't contain given char!";
            List<char> lc = new List<char>();
            for (int i = 0; i < ToCut.LastIndexOf(CutFrom); i++)
                lc.Add(ToCut[i]);
            return StringFromChars(lc);
        }

        public static string CutToLength(string ToCut, int Length)
        {
            if (ToCut.Length < Length)
                return "Given string is shorter than given length!";
            List<char> lc = new List<char>();
            for (int i = 0; i < Length; i++)
                lc.Add(ToCut[i]);
            return StringFromChars(lc);
        }

        public static string StringFromChars(char[] chars)
        {
            string tmp = "";
            foreach (char c in chars)
                tmp += c;
            return tmp;
        }

        public static string StringFromChars(List<char> chars)
        {
            string tmp = "";
            foreach (char c in chars)
                tmp += c;
            return tmp;
        }
    }
}
