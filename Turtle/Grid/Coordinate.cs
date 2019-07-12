using System;
using System.Collections.Generic;
using System.Text;

namespace Turtle.Grid
{
    class Coordinate
    {
        public Coordinate(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        public int x { get; set; }
        public int y { get; set; }
        public int storedValue { get; set; }
    }
}
