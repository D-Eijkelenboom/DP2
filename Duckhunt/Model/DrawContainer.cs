using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace duckhunt.Model
{
    class DrawContainer
    {
        private List<DrawBehaviour> behaviours;

        public DrawContainer()
        {
            behaviours = new List<DrawBehaviour>();
        }

        public void Draw()
        {
            foreach (DrawBehaviour behaviour in behaviours)
            {
                behaviour.Draw();
            }
        }

        public void Remove(DrawBehaviour drawBehaviour)
        {
            behaviours.Remove(drawBehaviour);
        }

        public void Remove(Unit unit)
        {
            behaviours = behaviours.Where(b => b.Unit != unit).ToList();
        }

        public void Add(DrawBehaviour drawBehaviour)
        {
            behaviours.Add(drawBehaviour);
        }
    }
}
