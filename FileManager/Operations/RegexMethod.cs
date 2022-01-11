using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileManager.Operations
{
    public class RegexMethod
    {
        public static Regex MakeRegexMaskForSearch(string mask)
        {
            mask = mask.Replace(".", @"\.");
            mask = mask.Replace("?", ".");
            mask = mask.Replace("*", ".*");
            mask = "^" + mask + "$";
            Regex regMask = new(mask, RegexOptions.IgnoreCase);
            return regMask;

        }
    }
}
