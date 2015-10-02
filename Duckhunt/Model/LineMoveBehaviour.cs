using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace duckhunt.Model
{
    class LineMoveBehaviour : MoveBehaviour
    {
        public LineMoveBehaviour(Unit unit)
        {
            Unit = unit;
        }

        public override void Move()
        {
            Unit.X += Unit.Vx;
            if (Unit.X < 0)
            {
                Unit.Vx = -Unit.Vx;
                Unit.Boing();
            }
            else if (Unit.X + Unit.Width > Properties.Settings.Default.ScreenWidth)
            {
                Unit.Vx = -Unit.Vx;
                Unit.Boing();
            }

            Unit.Y += Unit.Vy;
            if (Unit.Y < 0)
            {
                Unit.Vy = -Unit.Vy;
                Unit.Boing();
            }
            else if (Unit.Y + Unit.Height > Properties.Settings.Default.ScreenHeight)
            {
                Unit.Vy = -Unit.Vy;
                Unit.Boing();
            }
        }

        public override Unit Unit { get; set; }
    }
}
