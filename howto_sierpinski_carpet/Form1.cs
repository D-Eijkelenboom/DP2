using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

namespace howto_sierpinski_carpet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int Level = 3;

        private void Form1_Load(object sender, EventArgs e)
        {
            DrawGasket();
        }
        private void btnDraw_Click(object sender, EventArgs e)
        {
            DrawGasket();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            DrawGasket();
        }

        // Draw the carpet.
        private void DrawGasket()
        {
            Level = int.Parse(txtLevel.Text);

            Bitmap bm = new Bitmap(
                picGasket.ClientSize.Width,
                picGasket.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.White);
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // Draw the top-level carpet.
                const float margin = 10;
                RectangleF rect = new RectangleF(
                    margin, margin,
                    picGasket.ClientSize.Width - 2 * margin,
                    picGasket.ClientSize.Height - 2 * margin);
                DrawRectangle(gr, Level, rect);
            }

            // Display the result.
            picGasket.Image = bm;

            // Save the bitmap into a file.
            bm.Save("Carpet " + Level + ".bmp");
        }

        // Draw a carpet in the rectangle.
        private void DrawRectangle(Graphics gr, int level, RectangleF rect)
        {
            // See if we should stop.
            if (level == 0)
            {
                // Fill the rectangle.
                gr.FillRectangle(Brushes.Blue, rect);
            }
            else
            {
                // Divide the rectangle into 9 pieces.
                float wid = rect.Width / 3f;
                float x0 = rect.Left;
                float x1 = x0 + wid;
                float x2 = x0 + wid * 2f;

                float hgt = rect.Height / 3f;
                float y0 = rect.Top;
                float y1 = y0 + hgt;
                float y2 = y0 + hgt * 2f;

                // Recursively draw smaller carpets.
                DrawRectangle(gr, level - 1, new RectangleF(x0, y0, wid, hgt));
                DrawRectangle(gr, level - 1, new RectangleF(x1, y0, wid, hgt));
                DrawRectangle(gr, level - 1, new RectangleF(x2, y0, wid, hgt));
                DrawRectangle(gr, level - 1, new RectangleF(x0, y1, wid, hgt));
                DrawRectangle(gr, level - 1, new RectangleF(x2, y1, wid, hgt));
                DrawRectangle(gr, level - 1, new RectangleF(x0, y2, wid, hgt));
                DrawRectangle(gr, level - 1, new RectangleF(x1, y2, wid, hgt));
                DrawRectangle(gr, level - 1, new RectangleF(x2, y2, wid, hgt));
            }
        }
    }
}
