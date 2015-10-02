using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace duckhunt.Model
{
    class DuckMedium : Unit
    {
        public DuckMedium(MoveContainer moveContainer, DrawContainer drawContainer, BehaviourFactory behaviourFactory)
            : base(moveContainer, drawContainer, behaviourFactory)
        {            
            Width = Properties.Settings.Default.MediumDuckWidth;
            Height = Properties.Settings.Default.MediumDuckHeight;

            Random rnd = new Random();
            X = rnd.Next(Width, Properties.Settings.Default.ScreenWidth - Width);
            Y = rnd.Next(Height, Properties.Settings.Default.ScreenHeight - Height);

            Vx = Properties.Settings.Default.MediumDuckvX;
            Vy = Properties.Settings.Default.MediumDuckvY;
        }
    }
}
