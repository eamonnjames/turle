﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Turtle.State
{
    class MineHit : State
    {
        public MineHit(Player player, Point point)
        {
            this.player = player;
            this.point = point;

        }

        public override void Move(Point point)
        {
            throw new NotImplementedException();
        }      

    }

}
