using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Text;
using Turtle.Settings;

namespace Turtle.State
{
    class Normal : State
    {
        public Normal(Player player, Point point)
        {
            this.player = player;
            this.point = point;
        }
       
        public override void Move(Point _point)
        {
            point.x = _point.x;
            point.y = _point.y;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if(IsVaildMove(point) == false)
            {
                player.State = new InVaildMove(this.player,point);
            }

            if(HasTurtleHitMine(point) == true)
            {
                player.State = new MineHit(this.player, point);
            }
            if(HasTurtleFoundExit(point) == true)
            {
                player.State = new FoundExit(this.player, point);
            }
                  
        }       
        private bool IsVaildMove(Point point)
        {
            var boardWidthAndHeight = GameSettings.GameSettingSetBoardSize("Board Size", "Settings");
            var g1 = new Grid.Grid(boardWidthAndHeight.width, boardWidthAndHeight.height);

            try
            {
                g1.accessCoordinate(point.x, point.y);
                return true;
            }catch(Exception e)
            {
                Console.WriteLine("Corrdinate is not present : {0}", e);
                return false;
            }

        }
        private bool HasTurtleHitMine(Point point)
        {
            var mines = GameSettings.GameSettingGetMinesLocation("Mines", "Settings");

            bool MineHit = false;


            for (int i = 0;i < mines.Count;i++)
            {
                object obja = mines[i];
                object objb = point;
                var CheckForMine = Comparer.DefaultInvariant.Compare(obja,objb);

                if (CheckForMine == 0)
                {
                    MineHit = true;
                }

            }

            return MineHit;
        }
        private bool HasTurtleFoundExit(Point point)
        {
            var exit = GameSettings.GameSettingGetStartingPosition("Exit", "Settings");

            bool FoundExit = false;

            object obja = point;
            object objb = exit;

            var CheckForExit = Comparer.DefaultInvariant.Compare(obja, objb);

            if(CheckForExit == 0)
            {
                FoundExit = true;
            }

            return FoundExit;

        }
    }
}