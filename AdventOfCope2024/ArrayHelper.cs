﻿using System;
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
        public static bool IsOutOfBounds(Cords2D cords, int maxX, int maxY)
        {
            return !(cords.x >= 0 && cords.y >= 0 && cords.y < maxY && cords.x < maxX);
        }

        public static bool IsEdge(int x, int y, int maxX, int maxY)
        {
            return !(x > 0 && y > 0 && y < maxY-1 && x < maxX-1);
        }

        public static Cords2D indexOf(char value, char[,] array)
        {
            for(int x = 0; x < array.GetLength(0); x++) 
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    if (array[x, y] == value) return new Cords2D(x,y);
                }
            }
            throw new Exception($"{value} not found");
        }
        public static Cords2D indexOf(int value, int[,] array)
        {
            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    if (array[x, y] == value) return new Cords2D(x, y);
                }
            }
            throw new Exception($"{value} not found");
        }

        public static void print(char[,] array)
        {
            for(int y = 0;y<array.GetLength(1); y++) 
            {
                for(int x = 0; x<array.GetLength(0); x++) 
                {
                    Console.Write(array[x, y]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
           
        }
        public static int GetDistance(int x,int y,int x2,int y2)

    }
}
