using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCope2024._07b
{
    internal class Program
    {
        static ulong sum = 0;
        public static void Main(string[] args)
        {
            IEnumerable<string> input = Input.ReadAllLines(7);
            foreach (string line in input)
            {
                ulong[] numbers = regexHelper.GetNumbers(line).ToArray(); //long was too small
                ulong answer = numbers[0];
                List<ulong> options = [numbers[1]];
                if (numbers.Length <= 2) { throw new Exception(); }
                for (int i = 2; i < numbers.Length; i++)
                {
                    List<ulong> newOptions = new List<ulong>();
                    foreach (ulong o in options)
                    {
                        ulong newNumber = o + numbers[i];
                        if (newNumber <= answer && numbers[i] != 0 && newNumber - numbers[i] == o) { newOptions.Add(newNumber); }

                        newNumber = o * numbers[i];
                        if (newNumber <= answer && numbers[i] != 0 && newNumber / numbers[i] == o) { newOptions.Add(newNumber); }

                        string newNumbers = o.ToString() + numbers[i].ToString();
                        try
                        {
                            newNumber = ulong.Parse(newNumbers);
                            if (newNumber <= answer) { newOptions.Add(newNumber); }
                        }
                        catch (OverflowException) { }

                    }
                    options = newOptions;
                }
                if (answer < 0) { throw new Exception(); }
                if (options.Contains(answer))
                {
                    Console.WriteLine(answer);
                    sum += answer;
                    if (sum < 0) { throw new Exception(); }
                }
            }
            Console.WriteLine(sum);
        }
    }
}

