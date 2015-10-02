using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace duckhunt.Model
{
    class Level1 : Level
    {
        public Level1()
            : base()
        {
            Difficulty = 1;      
        }
        public override void Create()
        {
            for (int i = 0; i < Properties.Settings.Default.AmountOfUnits; i++ )
            {
                Units.Add(new DuckEasy(MoveContainer, DrawContainer, BehaviourFactory));
                Units.Add(new DuckMedium(MoveContainer, DrawContainer, BehaviourFactory));
            }
            
        }
    }
}
