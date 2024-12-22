

using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCope2024
{
    class Input 
    {
        public static string ReadAll(int number) 
        {
            return File.ReadAllText(GetPath(number));
        }
        public static IEnumerable<string> ReadAllLines(int number)
        {
            return File.ReadLines(GetPath(number));
        }
        private static string GetPath(int number) 
        {
            return Path.Combine(Environment.CurrentDirectory, @"..\..\..", $"Inputs\\{number}.txt");
        }
        public static int[,] ReadArrayInt(int number)//first is x, second y 
        {
            IEnumerable<string> input = ReadAllLines(number);
            int maxY = input.Count();
            int maxX = input.First().Length;
            int[,] output = new int[maxX,maxY];
            
            for(int y = 0;y < maxY;y++ ) 
            {
                for (int x = 0; x < maxX; x++)
                {
                    output[x, y] = input.ElementAt(y)[x] - '0';
                }
            }
            return output;
        }
        public static char[,] ReadArray(int number)//first is x, second y 
        {
            IEnumerable<string> input = ReadAllLines(number);
            int maxY = input.Count();
            int maxX = input.First().Length;
            char[,] output = new char[maxX, maxY];

            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    output[x, y] = input.ElementAt(y)[x];
                }
            }
            return output;
        }
        
       
    }
}
