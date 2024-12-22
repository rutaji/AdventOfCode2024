using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCope2024._05a
{
    internal class Program
    {
        static int sum = 0;
        public static void Main(string[] args)
        {
            string[] input = Input.ReadAllLines(5).ToArray();
            List<Rules> rules = new List<Rules>();
            int i = 0;
            for (; true;i++) 
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
            foreach(int[] row in rows) 
            {
                int middleOne = row[row.Length / 2];
                bool ok = true;
                foreach (Rules rule in rules)
                {
                    bool containsOtherOne = false;
                    foreach (int a in row) 
                    {
                        if(a == rule.first)
                        {
                            if (containsOtherOne) 
                            {
                                ok = false;
                                break;
                            }
                            containsOtherOne = true;
                        }
                        if (a == rule.second)
                        {
                            if (containsOtherOne)
                            {
                                break;
                            }
                            containsOtherOne = true;
                        }
                    }
                    if(ok == false) { break; }
                }
                if (ok) { sum += middleOne; }
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
