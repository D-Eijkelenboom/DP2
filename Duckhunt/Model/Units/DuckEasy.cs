using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace duckhunt.Model
{
    class DuckEasy : Unit
    {
        public DuckEasy(MoveContainer moveContainer, DrawContainer drawContainer, BehaviourFactory behaviourFactory)
            : base(moveContainer, drawContainer, behaviourFactory)
        {            
            Width = Properties.Settings.Default.EasyDuckWidth;
            Height = Properties.Settings.Default.EasyDuckHeight;

            Random rnd = new Random();
            X = rnd.Next(Width, Properties.Settings.Default.ScreenWidth - Width);
            Y = rnd.Next(Height, Properties.Settings.Default.ScreenHeight - Height);

            Vx = Properties.Settings.Default.EasyDuckvX;
            Vy = Properties.Settings.Default.EasyDuckvY;
        }
    }
}
