using System;
using System.Collections.Generic;
using System.Text;
using Turtle.Model;

namespace Turtle.State
{
    abstract class State
    {
        protected Player player;
        protected Point point;
        protected string direction;

        // Properties

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }
       
        public Point Point
        {
            get { return point; }
            set { point = value; }
        }

        public string Direction
        {
            get { return direction; }
            set { direction = value; }
        }
       
        public abstract void Move(Point point);
    }
}
