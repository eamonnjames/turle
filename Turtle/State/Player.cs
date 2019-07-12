using System;
using System.Collections.Generic;
using System.Text;
using Turtle.Model;
using Turtle.Settings;

namespace Turtle.State
{
    class Player
    {
        private State _state;

        // Constructor

        public Player()
        {
            var startingpos = GameSettings.GameSettingGetStartingPosition("Starting Position","Settings");
            //Starting point
            var p1 = new Point();
            p1.x = startingpos.x;
            p1.y = startingpos.y;

            this._state = new Normal(this,p1);
        }

        // Properties       

        public Point Point
        {
            get { return _state.Point; }
        }

        public State State
        {
            get { return _state; }
            set { _state = value; }
        }

        public void Move(Point point)
        {
            _state.Move(point);
            Console.WriteLine(point.x + "," + point.y);
        }       
    }
}
