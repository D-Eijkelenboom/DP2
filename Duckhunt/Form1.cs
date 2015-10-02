using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Collections;

namespace duckhunt
{
    public partial class Form1 : Form
    {
        // Some drawing parameters.
        private bool quit;
        private string tbProgress;
        private Model.Game game;

        public Form1()
        {
            game = new Model.Game(this);
            InitializeComponent();
            Init();
            this.Size = new Size(Properties.Settings.Default.ScreenWidth, Properties.Settings.Default.ScreenHeight);
        }


        public void Init()
        {
            // Use double buffering to reduce flicker.
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);
            this.UpdateStyles();
        }
        
        // Initialize some random stuff.
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        // Draw the ball at its current location.
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(BackColor);
            ////if (units != null)
            ////{
            ////    foreach (Model.Unit unit in units)
            ////    {
            ////        e.Graphics.FillEllipse(Brushes.Blue, unit.X, unit.Y, unit.Width, unit.Height);
            ////        e.Graphics.DrawEllipse(Pens.Black, unit.X, unit.Y, unit.Width, unit.Height);
            ////    }
            ////}
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                game.Start();
            }
            if (e.KeyCode == Keys.Escape)
            {
                game.Stop();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            game.Shoot(e);            
        }        
    }
}
