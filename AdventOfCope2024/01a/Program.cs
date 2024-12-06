
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace AdventOfCope2024._01a
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> input = Input.ReadAllLines(1);
            int numberOfROws = input.First().Split(' ', (StringSplitOptions)1).Length;
            List<List<int>> columns = new List<List<int>>();
            for (int i = 0; i < numberOfROws; i++)
            {
                columns.Add(new List<int>(1000));
            }
            foreach(string line in input)
            {
                string[] numbers = line.Split(' ', (StringSplitOptions)1);
                for (int i = 0; i < numberOfROws; i++)
                {
                    columns[i].Add(int.Parse(numbers[i]));
                }
            }
            foreach(List<int> column in columns)
            {
                column.Sort();
            }
            int sum = 0;
            for (int i = 0;i < columns.First().Count; i++)
            {
                sum += Math.Abs(columns[0][i] - columns[1][i]);
            }
            Console.WriteLine(sum);

        }

    }
}
