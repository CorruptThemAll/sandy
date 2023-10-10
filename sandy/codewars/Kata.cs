using System.Numerics;
using System.Linq;

namespace sandy.codewars
{
    public class Kata
    {
        public static string ToCamelCase(string str)
        {
            bool pastSymbol = false;
            string holStr = "";
            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] == '_')
                    pastSymbol = true;
                else if (str[i] == '-')
                    pastSymbol = true;
                else if (pastSymbol == true)
                {
                    holStr += char.ToUpper(str[i]);
                    pastSymbol = false;
                }
                else
                {
                    holStr += str[i];
                }
            }
            return holStr;
        }

        public static int DescendingOrder(int num)
        {
            string dnums = num.ToString();
            List<char> lnums = new List<char>();
            foreach (var d in dnums)
            {
                lnums.Add(d);
            }
            lnums.Sort();
            var snum = "";
            for (var l = lnums.Count - 1; l >= 0; l--)
            {
                snum += lnums[l].ToString();
            }
            return num = Convert.ToInt32(snum);
        }

        public static string Solution(string str)
        {
            var charr = str.ToArray();

            var newCharr = charr.Reverse();
            string hello = "";
            foreach (var c in newCharr)
                hello += c;

            return hello;
        }
    }
}