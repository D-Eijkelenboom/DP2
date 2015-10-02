using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace duckhunt.Model.Levels
{
    class Level2 : Level
    {
        public Level2()
            : base()
        {
            Difficulty = 2;      
        }
        public override void Create()
        {
            for (int i = 0; i < Properties.Settings.Default.AmountOfUnits; i++ )
            {
                Units.Add(new DuckMedium(MoveContainer, DrawContainer, BehaviourFactory));
            }
            
        }
    }
}
