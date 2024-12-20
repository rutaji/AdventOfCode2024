using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCope2024._04b
{
    internal class Program
    {
        static int maxX;
        static int maxY;
        static char[,]? input;
        static int sum = 0;
        public static void Main(string[] args)
        {
            input = Input.ReadArray(4);
            maxX = input.GetLength(0);
            maxY = input.GetLength(1);

            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    FoundWord(x, y);
                }
            }
            Console.WriteLine(sum);
        }

        public delegate (int, int) Increment(int x, int y);

        public static bool FoundWord(int x, int y)
        {
            if (ArrayHelper.IsEdge(x, y, maxX, maxY)) {  return false; }
            if ('A' == input![x, y])
            {
                int s11 = input[x - 1, y - 1];
                int s21 = input[x + 1, y - 1];
                int s12 = input[x - 1, y + 1];
                int s22 = input[x + 1, y + 1];

                if(s11 == 'M' && s22 == 'S' || s11 == 'S' && s22 == 'M') 
                {
                    if (s21 == 'M' && s12 == 'S' || s21 == 'S' && s12== 'M')
                    {
                        sum++;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
