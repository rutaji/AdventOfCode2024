using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCope2024
{
    internal class ArrayHelper
    {
        public static bool IsOutOfBounds(int x, int y, int maxX, int maxY) 
        {
            return !( x >= 0 && y >= 0 && y < maxY && x < maxX);        
        }
        public static bool IsEdge(int x, int y, int maxX, int maxY)
        {
            return !(x > 0 && y > 0 && y < maxY-1 && x < maxX-1);
        }

    }
}
