using System;
using System.Linq;
using Turtle.Settings;

namespace Turtle
{
    class Program
    {
        static void Main(string[] args)
        {
            var getMoves = GameSettings.getMoves("Moves");            
            var p1 = new State.Player();
            var TurtlePoint = new Point();
            var Direction = "North";

            for (int i = 0;i < getMoves.Count; i++)
            {
                if (i == 0)
                {
                    var startingpos = GameSettings.GameSettingGetStartingPosition("Starting Position", "Settings");
                    TurtlePoint.x = startingpos.x;
                    TurtlePoint.y = startingpos.y;                    
                }
                
                if(getMoves[i] == "move")
                {
                    if(Direction == "North")
                    {
                        TurtlePoint.y = TurtlePoint.y - 1;
                        p1.Move(TurtlePoint);
                    }
                    if(Direction == "East")
                    {
                        TurtlePoint.x = TurtlePoint.x + 1;
                        p1.Move(TurtlePoint);
                    }

                    if(Direction == "South")
                    {
                        TurtlePoint.y = TurtlePoint.y + 1;
                        p1.Move(TurtlePoint);
                    }

                    if(Direction == "West")
                    {
                        TurtlePoint.x = TurtlePoint.x - 1;
                        p1.Move(TurtlePoint);
                    }
                    
                }

                if(p1.State.GetType().Name == "MineHit")
                {
                    Console.WriteLine("Player has hit mine Game Over");
                    break;
                }

                if(p1.State.GetType().Name == "InVaildMove")
                {
                    Console.WriteLine("Invaild Move, check moves.txt");
                    break;
                }
                if(p1.State.GetType().Name == "FoundExit")
                {
                    Console.WriteLine("Turtle has found the exit!!!!");
                }

                if (getMoves[i] == "rotate")
                {
                    Direction = GetUpdatedDirection(Direction);
                }
            }
            Console.ReadLine();
        }
        private static string GetUpdatedDirection(string direction)
        {
            switch(direction)
            {
                case "North": return "East";
                case "East": return "South";
                case "South": return "West";
                case "West": return "North";
            }
            return "no value found";
        }
    }
}
