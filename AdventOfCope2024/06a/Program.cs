using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCope2024._06a
{
    internal class Program
    {
        public static long sum = 0;
        
        public static void Main(string[] args)
        {
            char[,] input = Input.ReadArray(6);
            Cords2D startingPos = ArrayHelper.indexOf('^', input);
            Cords2D current = startingPos;
            Cords2D direction = Cords2D.UP;
            FindPath(input, ref current, direction);
            Console.WriteLine(sum);
            ArrayHelper.print(input);


            

        }
        static void FindPath(char[,] input, ref Cords2D current, Cords2D direction)
        {
            Cords2D futureCords;
            while (true)
            {
                if (input[current.x, current.y] != 'X')
                {
                    input[current.x, current.y] = 'X';
                    sum++;
                }
                while (true)
                {
                    futureCords = current + direction;
                    if (ArrayHelper.IsOutOfBounds(futureCords, input.GetLength(0), input.GetLength(1))) 
                    { return; }
                    if (input[futureCords.x, futureCords.y] == '#')
                    {
                        direction.turnClockvise();
                    }
                    else { break; }
                }
                current = futureCords;
            }
        }
    }
}
