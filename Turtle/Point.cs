using System;
using System.Collections.Generic;
using System.Text;

namespace Turtle
{
   public class Point : IComparable
    {
        public int x { get; set; }
        public int y { get; set; }

        public int CompareTo(object obj)
        {
            Point p1 = (Point)obj;

            if(p1.x == x && p1.y == y)
            {
                return 0;
            }

            return 1;
        }
    }
}
