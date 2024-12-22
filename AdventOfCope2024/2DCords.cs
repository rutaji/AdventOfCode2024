using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCope2024
{
    public class Cords2D //used for 2d arrays
    {
        public int x;
        public int y;//higher y => goes down
        public int distance;

        //static variables
        public static readonly Cords2D UP = new Cords2D(0, -1);
        public static readonly Cords2D DOWN = new Cords2D(0, 1);
        public static readonly Cords2D LEFT = new Cords2D(-1, 0);
        public static readonly Cords2D RIGHT = new Cords2D(1, 0);

        //methods
        public Cords2D((int,int) tuple) 
        {
            x = tuple.Item1;
            y = tuple.Item2;
        }
        public Cords2D(Cords2D c)
        {
            x = c.x;
            y = c.y;
            
        }
        public Cords2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void Add(Cords2D cords2D) 
        {
            this.x += cords2D.x;
            this.y += cords2D.y;
        }
        public (int,int) ToTuple() 
        {
            return (x,y);
        }

        internal void turnClockvise()
        {
            int x = this.x;
            this.x = -y;
            this.y = x;
        }

        public static Cords2D operator +(Cords2D a, Cords2D b) 
        {
            return new Cords2D(a.x + b.x, a.y + b.y);
        }
        public static Cords2D operator *(Cords2D a, int skalar)
        {
            return new Cords2D(a.x *skalar, a.y * skalar);
        }
        public static Cords2D operator *(int skalar,Cords2D a)
        {
            return new Cords2D(a.x * skalar, a.y * skalar);
        }
        public static Cords2D operator -(Cords2D a, Cords2D b)
        {
            return new Cords2D(a.x - b.x, a.y - b.y);
        }
        public override bool Equals(object? obj)
        {
            var item = obj as Cords2D;
            if (item == null) {  return false; }
            return item.x == x && item.y == y;
        }
        public override int GetHashCode()
        {
            return x.GetHashCode() + 2*y.GetHashCode();
        }
        public IEnumerable<Cords2D> generateLineWithDistance(Cords2D direction,int maxX,int maxY)
        {
            int i = 1;
            while (true) {
                Cords2D cords2D = (this + direction);
                cords2D.distance = i;
                if (cords2D.IsOutOfBounds(maxX,maxY)) { break; }
                i++;
                yield return cords2D; 
            
            }
            i = 1;
            while (true)
            {
                Cords2D cords2D = (this - direction);
                cords2D.distance = i;
                if (cords2D.IsOutOfBounds(maxX, maxY)) { break; }
                i++;
                yield return cords2D;

            }
        }
        public bool IsOutOfBounds(int maxX, int maxY)
        {
            return !(x >= 0 && y >= 0 && y < maxY && x < maxX);
        }



    }
}
