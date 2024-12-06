

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
    }
}
