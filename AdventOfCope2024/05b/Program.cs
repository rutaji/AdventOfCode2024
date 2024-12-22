using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCope2024._05b
{
    internal class Program
    {
        static int sum = 0;
        public static void Main(string[] args)
        {
            string[] input = Input.ReadAllLines(5).ToArray();
            List<Rules> rules = new List<Rules>();
            int i = 0;
            for (; true; i++)
            {
                if (input[i] == "") { i++; break; }
                rules.Add(new Rules(input[i].Split('|')));
            }
            List<int[]> rows = new List<int[]>();
            while (i < input.Length)
            {
                string[] splits = input[i].Split(",");
                int[] currentA = new int[splits.Length];
                for (int j = 0; j < splits.Length; j++)
                {
                    currentA[j] = int.Parse(splits[j]);
                }
                rows.Add(currentA);
                i++;
            }


            foreach (int[] row in rows)
            {
                bool changed = false;
                for(int r = 0;r < rules.Count; r++ )
                {
                    bool containsOtherOne = false;
                    int secondIndex = -1;
                    for (int rowIndex = 0; rowIndex < row.Length; rowIndex++)
                    {
                        if (row[rowIndex] == rules[r].first)
                        {
                            if (containsOtherOne)//rule is broken
                            {
                                row[rowIndex] = rules[r].second;
                                row[secondIndex] = rules[r].first;
                                changed = true;
                                r = 0;
                                break;
                            }
                            containsOtherOne = true;
                        }
                        if (row[rowIndex] == rules[r].second)
                        {
                            secondIndex = rowIndex;
                            if (containsOtherOne)// rule is ok
                            {
                                break;
                            }
                            containsOtherOne = true;
                        }
                    }
                    
                }
                int middleOne = row[row.Length / 2];
                if (changed) { sum += middleOne; }
            }
            Console.WriteLine(sum);

        }
        class Rules
        {
            public int first;
            public int second;
            public Rules(string[] array)
            {
                this.first = int.Parse(array[0]);
                this.second = int.Parse(array[1]);
            }
        }
    }
}
