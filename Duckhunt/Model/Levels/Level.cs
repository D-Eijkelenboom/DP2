using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace duckhunt.Model
{
    class Level
    {
        public Level()
        {
            Units = new List<Unit>();
            BehaviourFactory = new BehaviourFactory();
            MoveContainer = new MoveContainer();
            DrawContainer = new DrawContainer();
            Difficulty = 0;
        }
        public virtual List<Unit> Units { get; set; }

        public virtual BehaviourFactory BehaviourFactory { get; set; }

        public virtual MoveContainer MoveContainer { get; set; }

        public virtual DrawContainer DrawContainer { get; set; }

        public virtual int Difficulty { get; set; }

        public virtual void Create()
        { 
        
        }

        public virtual void Step()
        {
            MoveContainer.Move();
            DrawContainer.Draw();
        }

        public virtual void Shoot(System.Windows.Forms.MouseEventArgs e)
        {
            if (Units != null)
            {
                foreach (Model.Unit unit in Units)
                {
                    if (Enumerable.Range(e.X - unit.Width, e.X + unit.Width).Contains(unit.X) && Enumerable.Range(e.Y - unit.Height, e.Y + unit.Height).Contains(unit.Y))
                    {
                        unit.Die();
                    }
                }
            }
        }
    }
}
