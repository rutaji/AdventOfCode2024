using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCope2024._02b
{
    internal class Program
    {
        static int minDefference = 1;
        static int maxDefference = 3;
        static void Main(string[] args) 
        {
            IEnumerable<string> list = Input.ReadAllLines(2);
            int safeReports = 0;
            
            
            foreach (string line in list)
            {
                int[] numbers = Array.ConvertAll(line.Split(' ',StringSplitOptions.RemoveEmptyEntries),x => int.Parse(x));
                HashSet<int> errors = new HashSet<int>();
                if (IsSafe(numbers,errors)) { safeReports++; } 
                else
                {
                    foreach(int error in errors) 
                    {
                        if (IsSafe(CopyWithoutIndex(numbers, error).ToArray()))
                        {
                            safeReports++; break; 
                        }
                    }
                }


            }
            Console.WriteLine(safeReports);
                
        }
        static bool IsSafe(int[] numbers, HashSet<int> errors) 
        {
            bool ascending = numbers[1] > numbers[0];
            errors.Add(0);//In case first is wrong => my assumption about ascending is wrong
            bool safe = true;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int diff = Math.Abs(numbers[i] - numbers[i + 1]);
                if (!(diff >= minDefference && diff <= maxDefference))
                {
                    safe = false;
                    errors.Add(i);
                    errors.Add(i + 1);
                    continue;
                }
                if (!(ascending && numbers[i + 1] > numbers[i] || !ascending && numbers[i + 1] < numbers[i]))
                {
                    safe = false;
                    errors.Add(i);
                    errors.Add(i + 1);
                    continue;

                }

            }
            return safe;
        }
        static bool IsSafe(int[] numbers)
        {
            bool ascending = numbers[1] > numbers[0];
            bool safe = true;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int diff = Math.Abs(numbers[i] - numbers[i + 1]);
                if (!(diff >= minDefference && diff <= maxDefference))
                {
                    safe = false;
                    continue;
                }
                if (!(ascending && numbers[i + 1] > numbers[i] || !ascending && numbers[i + 1] < numbers[i]))
                {
                    safe = false;
                    continue;

                }

            }
            return safe;
        }
        static IEnumerable<int> CopyWithoutIndex(int[] numbers, int index)
        {

            for (int i = 0; i < numbers.Length; i++)
            {
                if (index != i)
                {
                    yield return numbers[i];
                }
            }
        }

    }
    
}
