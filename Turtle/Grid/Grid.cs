using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Turtle.Grid
{
    class Grid
    {
        public Grid(int width, int length)
        {
            coordinates = new List<Coordinate>();
            for (int i = 0; i < width - 1; i++)
            {
                for (int k = 0; k < length + 1; k++)
                {
                    coordinates.Add(new Coordinate(k, i));
                }
            }
        }
        List<Coordinate> coordinates;
        int width { get; set; }
        int length { get; set; }
        public int accessCoordinate(int x, int y)
        {
            return coordinates.Where(coord => coord.x == x && coord.y == y)
                              .FirstOrDefault().storedValue;
        }
        public void assignValue(int x, int y, int value)
        {
            coordinates.Where(coord => coord.x == x && coord.y == y)
                       .FirstOrDefault().storedValue = value;
        }
    }
}
