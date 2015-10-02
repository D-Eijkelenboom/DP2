using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;

namespace duckhunt.Model
{
    class Unit
    {
        public Unit(MoveContainer moveContainer, DrawContainer drawContainer, BehaviourFactory behaviourFactory)
        {
            MoveContainer = moveContainer;
            MoveBehaviour moveBehaviour = behaviourFactory.CreateMoveBehaviour(this);
            MoveContainer.Add(moveBehaviour);

            DrawContainer = drawContainer;
            DrawBehaviour drawBehaviour = behaviourFactory.CreateDrawBehaviour(this);
            DrawContainer.Add(drawBehaviour);
        }

        public void Move()
        {
            //moveBehaviour.Move();
        }

        public void Die()
        {
            MoveContainer.Remove(this);
            DrawContainer.Remove(this);
        }

        // Play the boing sound file resource.
        public void Boing()
        {
            using (SoundPlayer player = new SoundPlayer(
                Properties.Resources.boing))
            {
                player.Play();
            }
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Vx { get; set; }

        public int Vy { get; set; }

        public MoveContainer MoveContainer { get; set; }

        public DrawContainer DrawContainer { get; set; }
    }   
}
