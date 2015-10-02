using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace duckhunt.Model
{
    class MoveContainer
    {
        private List<MoveBehaviour> behaviours;

        public MoveContainer()
        {
            behaviours = new List<MoveBehaviour>();
        }

        public void Move()
        {
            foreach (MoveBehaviour behaviour in behaviours)
            {
                behaviour.Move();
            }
        }

        public void Remove(MoveBehaviour moveBehaviour)
        {
            behaviours.Remove(moveBehaviour);
        }

        public void Remove(Unit unit)
        {
            behaviours = behaviours.Where(b => b.Unit != unit).ToList();
        }

        public void Add(MoveBehaviour moveBehaviour)
        {
            behaviours.Add(moveBehaviour);
        }
    }
}
