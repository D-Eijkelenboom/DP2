using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace duckhunt.Model
{
    class BehaviourFactory
    {
        public MoveBehaviour CreateMoveBehaviour(Unit unit)
        {
            switch (unit.GetType().ToString())
            {
                case "duckhunt.Model.DuckEasy":
                    return new StraightMoveBehaviour(unit);
                case "duckhunt.Model.DuckMedium":
                    return new StraightMoveBehaviour(unit);
                default:
                    return null;
            }
        }

        public DrawBehaviour CreateDrawBehaviour(Unit unit)
        {
            switch (unit.GetType().ToString())
            {
                case "duckhunt.Model.DuckEasy":
                    return new DrawBehaviour(Canvas, unit);
                case "duckhunt.Model.DuckMedium":
                    return new DrawBehaviour(Canvas, unit);
                default:
                    return null;
            }
        }

        public Form1 Canvas { get; set; }
    }
}
