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
        public static int maxX = 0;
        public static int maxY = 0;
        public static void Main(string[] args)
        {
            char[,] input = Input.ReadArray(8);

            for(int x = 0; x < input.GetLength(0); x++) 
            {
                for (int y = 0; y < input.GetLength(1);y++) //for every anthena
                {
                    if (input[x,y] == '.') { continue; } ///////////////!!!!!!!!!!!!!!!!!! all of this wont work !! and didnt understand the rules
                    Cords2D current = new Cords2D(x,y);
                    //for one direction
                    Dictionary<char,List<int>> distances = new Dictionary<char,List<int>>();
                    foreach(Cords2D cords in current.generateLineWithDistance(Cords2D.UP, maxX, maxY))
                    {
                        if (input[cords.x, cords.y] == '.') { continue; }
                        char symbol = input[cords.x, cords.y];
                        if (!distances.ContainsKey(symbol)) {distances[symbol] = new List<int>();}
                        distances[symbol].Add(cords.distance);

                    }
                    

                }
            }
        }

        
    }
}
