using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCope2024._06b
{
    internal class Program
    {
        public static long sum = 0;

        public static void Main(string[] args)
        {
            char[,] input = Input.ReadArray(6);
            Cords2D startingPos = ArrayHelper.indexOf('^', input);
            Cords2D current = startingPos;
            Cords2D direction = new Cords2D(Cords2D.UP);
            HashSet<Cords2D> route = new HashSet<Cords2D>();
            FindPath(input, ref current, direction,route);
            route.Remove(startingPos);
            Cords2D futureCords;


            foreach (Cords2D newtable in route) 
            {
                direction = new Cords2D(Cords2D.UP);
                current = startingPos;
                testForLoop(input, current, direction, out futureCords,newtable);
                
            }
            Console.WriteLine(sum);
            
            




        }

        private static void testForLoop(char[,] input, Cords2D current, Cords2D direction, out Cords2D futureCords, Cords2D newtable)
        {
            //char[,] Debuginput = Input.ReadArray(6);
            //Debuginput[newtable.x, newtable.y] = 'T';
            Dictionary<Cords2D,int> stations = new Dictionary<Cords2D,int>();//station is place before table where I check if I am in loop
            int steps = 0;
            int laststation = 0;//diference for last location
            int repeatingdiference = 0;
            bool rotated = false; 
            while (true)
            {
                steps++;
                //Debuginput[current.x, current.y] = 'X';

                while (true)//rotating
                {
                    futureCords = current + direction;
                    if (ArrayHelper.IsOutOfBounds(futureCords, input.GetLength(0), input.GetLength(1)))
                    {
                        //ArrayHelper.print(Debuginput);
                        return; 
                    }
                    if (input[futureCords.x, futureCords.y] == '#' || futureCords.Equals(newtable))//hit table
                    {
                        direction.turnClockvise();
                        rotated = true;
                    }
                    else { break; }
                }

                if (rotated)
                {
                    //ArrayHelper.print(Debuginput);
                    if (!stations.ContainsKey(current)) { stations[current] = 0; }
                    int diference = steps - stations[current];//how many steps I done since I was there last time
                    if (diference == laststation)
                    {
                        repeatingdiference++;
                        if (repeatingdiference > 12)
                        {
                            //ArrayHelper.print(Debuginput);
                            sum++;
                            return;
                        }
                    }
                    else { repeatingdiference = 0; }

                    laststation = diference;
                    stations[current] = steps;

                    rotated = false;
                }
                current = futureCords;

            }
        }

        static void FindPath(char[,] input, ref Cords2D current, Cords2D direction, HashSet<Cords2D> route)
        {
            Cords2D futureCords;
            while (true)
            {
                if (input[current.x, current.y] != 'X')
                {
                    input[current.x, current.y] = 'X';
                    route.Add(current);
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
