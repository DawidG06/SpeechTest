using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace speechtester
{
    public static class Extensions
    {
        public static string CutFromLastBackslash(this string word)
        {
            int lastSlash = word.LastIndexOf("\\") + 1;

            if (lastSlash == 0)
                return word;

            word = word.Substring(lastSlash, word.Length - lastSlash);
            return word;
        }
    }
}
