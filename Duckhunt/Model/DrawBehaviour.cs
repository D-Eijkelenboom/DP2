using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace duckhunt.Model
{
    class DrawBehaviour
    {
        public DrawBehaviour(Form1 canvas, Unit unit)
        {
            Canvas = canvas;
            Unit = unit;
        }

        public virtual void Draw()
        {
            if (Canvas != null && Unit != null)
            {
                if (Canvas.InvokeRequired)
                {
                    Canvas.Invoke(new Action(() => Draw()));
                }
                else
                {
                    Graphics g = Canvas.CreateGraphics();
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.Clear(Canvas.BackColor);                    
                    g.FillEllipse(Brushes.Blue, Unit.X, Unit.Y, Unit.Width, Unit.Height);
                    g.DrawEllipse(Pens.Black, Unit.X, Unit.Y, Unit.Width, Unit.Height);
                }                
            }            
        }

        public Form1 Canvas { get; set; }

        public Unit Unit { get; set; }
    }
}
