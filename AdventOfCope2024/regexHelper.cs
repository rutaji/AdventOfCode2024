using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCope2024
{
    internal class regexHelper
    {
        public static IEnumerable<ulong> GetNumbers(string input) 
        {
            Regex regex = new Regex(@"\d+");
            foreach (Match item in regex.Matches(input))
            {
               yield return ulong.Parse(item.Value);
            }
        } 
    }
}
