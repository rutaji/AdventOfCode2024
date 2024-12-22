using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCope2024._08a
{
    internal class Program
    {
        public static int maxX ;
        public static int maxY ;
        public static void Main(string[] args)
        {
            char[,] input = Input.ReadArray(8);
            maxX = input.GetLength(0);
            maxY = input.GetLength(1);
            Dictionary<char,List<Cords2D>> anthennas = ArrayHelper.GetCordsOfAllSymbols(input);
            anthennas.Remove('.');
            HashSet<Cords2D> antinodes = new HashSet<Cords2D>();

            foreach (List<Cords2D> anthenatype in anthennas.Values)
            {
                for (int i = 0; i < anthenatype.Count; i++)
                {
                    for (int j = 0; j < anthenatype.Count; j++)
                    {
                        if(i != j) 
                        {
                            Cords2D antinode = 2*anthenatype[i] - anthenatype[j];
                            if (!antinode.IsOutOfBounds(maxX, maxY)) {antinodes.Add(antinode); }
                        }
                    }
                }
            }
            Console.WriteLine(antinodes.Count);
        }

        

    }
}
