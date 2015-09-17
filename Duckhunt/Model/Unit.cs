using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;

namespace duckhunt.Model
{
    class Unit
    {
        private int screenWidth;
        private int screenHeight;

        public Unit(int x, int y)
        { 
            
        }

        public Unit(int x, int y, int vx, int vy, int width, int height, int screenWidth, int screenHeight)
        {
            X = x;
            Y = y;
            Vx = vx;
            Vy = vy;
            Width = width;
            Height = height;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

        }

        public void Move()
        {

            X += Vx;
            if (X < 0)
            {
                Vx = -Vx;
                Boing();
            }
            else if (X + Width > screenWidth)
            {
                Vx = -Vx;
                Boing();
            }

            Y += Vy;
            if (Y < 0)
            {
                Vy = -Vy;
                Boing();
            }
            else if (Y + Height > screenHeight)
            {
                Vy = -Vy;
                Boing();
            }
        }

        // Play the boing sound file resource.
        private void Boing()
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
    }
}
