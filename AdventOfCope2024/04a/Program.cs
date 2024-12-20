using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCope2024._04a
{
    internal class Program
    {
        static int maxX;
        static int maxY;
        static char[,]? input;
        static int sum = 0;
        static string word = "XMAS"; 
        public static void Main(string[] args)
        {
            input = Input.ReadArray(4);
            maxX = input.GetLength(0);
            maxY = input.GetLength(1);

            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    FoundWord(x, y, (x, y) => (++x, y));
                    FoundWord(x, y, (x, y) => (++x, ++y));
                    FoundWord(x, y, (x, y) => (x, ++y));
                    FoundWord(x, y, (x, y) => (--x, ++y));

                    FoundWord(x, y, (x, y) => (--x, y));
                    FoundWord(x, y, (x, y) => (--x, --y));
                    FoundWord(x, y, (x, y) => (x, --y));
                    FoundWord(x, y, (x, y) => (++x, --y));
                }
            }
            Console.WriteLine(sum);
        }
        
        public delegate (int,int) Increment(int x,int y);

        public static bool FoundWord(int x,int y,Increment increment) 
        {
            int i = 0;
            while (i<word.Length)
            {
                if (ArrayHelper.IsOutOfBounds(x, y, maxX, maxY)) { return false; };
                if(word[i] == input![x, y])
                {
                    i++;
                    var tuple = increment.Invoke(x, y);
                    x = tuple.Item1;
                    y = tuple.Item2;
                }
                else 
                {
                    return false;
                }
            }
            sum++;
            return true;
        }
    }
}

