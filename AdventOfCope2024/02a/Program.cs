using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCope2024._02a
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            IEnumerable<string> list = Input.ReadAllLines(2);
            int safeReports = 0;
            bool ascending;
            int minDefference = 1;
            int maxDefference = 3;
            foreach (string line in list)
            {
                int[] numbers = Array.ConvertAll(line.Split(' ',StringSplitOptions.RemoveEmptyEntries),x => int.Parse(x));
                ascending = numbers[1] > numbers[0];
                bool safe = true;
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    int diff = Math.Abs(numbers[i] - numbers[i + 1]);
                    if (!( diff >= minDefference && diff <= maxDefference))
                    {
                        safe = false;
                       break;
                    }
                    if (!(ascending && numbers[i + 1] > numbers[i] || !ascending && numbers[i + 1] < numbers[i]))
                    {
                        safe = false;
                        break ;
                    }
                    
                }
                if (safe) { safeReports++; }


            }
            Console.WriteLine(safeReports);
                
        }
    }
}
