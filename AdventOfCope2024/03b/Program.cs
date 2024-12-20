using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCope2024._03b
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            string input = Input.ReadAll(3);
            string pattern = @"don't\(\).*?do\(\)|don't\(\).*?\z";
            Regex regex = new Regex(pattern, RegexOptions.Singleline);
            input = regex.Replace(input,"");

            //03a
            pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
            regex = new Regex(pattern);

            var matches = regex.Matches(input);
            int sum = 0;
            foreach (Match match in matches)
            {
                sum += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
            }
            Console.WriteLine(sum);
        }
    }
}
