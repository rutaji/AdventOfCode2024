using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCope2024._09b
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string input = Input.ReadAll(9);
            List<int> decoded = new List<int>();
            int id = 0;
            bool isfile = true;
            int toWrite;
            foreach (char inputChar in input)
            {
                int size = inputChar - '0';
                if (isfile)
                {
                    toWrite = id++;
                    decoded.AddRange(Enumerable.Repeat(toWrite, size));
                }
                else
                {
                    decoded.Add(inputChar*-1);
                }
                
                
                isfile = !isfile;
            }
            //ArrayHelper.Print(decoded);

            //compacting
            int freePointer = 0;
            int endPointer = decoded.Count - 1;
            while (freePointer < endPointer)
            {
                if (decoded[endPointer] == -1) { endPointer--; continue; }
                if (decoded[freePointer] == -1)//found free space
                {
                    decoded[freePointer] = decoded[endPointer];
                    decoded[endPointer] = -1;
                    endPointer--;
                }
                freePointer++;
            }
            //ArrayHelper.Print(decoded);

            //calculating sum
            long sum = 0;
            for (int i = 0; true; i++)
            {
                if (decoded[i] == -1) { break; }
                sum += decoded[i] * i;
            }
            Console.WriteLine(sum);



        }

    }
}
