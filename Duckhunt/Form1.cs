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
        private BackgroundWorker bgWorker;
        private ArrayList units;

        public Form1()
        {
            InitializeComponent();

            bgWorker = new BackgroundWorker();
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.WorkerReportsProgress = true;

            bgWorker.DoWork +=
                new DoWorkEventHandler(bw_DoWork);
            bgWorker.ProgressChanged +=
                new ProgressChangedEventHandler(bw_ProgressChanged);
            bgWorker.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }


        private void Init()
        {
            Random rnd = new Random();
            units = new ArrayList();

            // Create units with a random start position and velocity.
            units.Add(new Model.Unit(rnd.Next(0, ClientSize.Width - 20), rnd.Next(0, ClientSize.Height - 20), rnd.Next(1, 4), rnd.Next(1, 4), 20, 20, ClientSize.Width, ClientSize.Height));
            units.Add(new Model.Unit(rnd.Next(0, ClientSize.Width - 50), rnd.Next(0, ClientSize.Height - 50), rnd.Next(1, 4), rnd.Next(1, 4), 50, 50, ClientSize.Width, ClientSize.Height));
            units.Add(new Model.Unit(rnd.Next(0, ClientSize.Width - 70), rnd.Next(0, ClientSize.Height - 70), rnd.Next(1, 4), rnd.Next(1, 4), 70, 70, ClientSize.Width, ClientSize.Height));
            
            
            // Use double buffering to reduce flicker.
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);
            this.UpdateStyles();
        }

        private void Play()
        {
            Init();
            if (bgWorker.IsBusy != true)
            {
                bgWorker.RunWorkerAsync();
            }            
        }
        
        // Update the ball's position, bouncing if necessary.
        private void Step()
        {
            foreach (Model.Unit unit in units)
            {
                unit.Move();
            }
            if (this.InvokeRequired)
                this.Invoke(new Action(() => Refresh()));
        }

        // Initialize some random stuff.
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        // Draw the ball at its current location.
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(BackColor);
            if (units != null)
            {
                foreach (Model.Unit unit in units)
                {
                    e.Graphics.FillEllipse(Brushes.Blue, unit.X, unit.Y, unit.Width, unit.Height);
                    e.Graphics.DrawEllipse(Pens.Black, unit.X, unit.Y, unit.Width, unit.Height);
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Play();
            }
            if (e.KeyCode == Keys.Escape)
            {
                quit = true;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (units != null)
            {
                foreach (Model.Unit unit in units)
                {
                    if (Enumerable.Range(e.X - unit.Width, e.X + unit.Width).Contains(unit.X) && Enumerable.Range(e.Y - unit.Height, e.Y + unit.Height).Contains(unit.Y))
                    {
                        Console.WriteLine("Bang! Duck is DEAD!!!");
                    }
                }
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if ((worker.CancellationPending == true))
            {
                e.Cancel = true;
            }
            else
            {
                // Perform a time consuming operation and report progress.
                while (!quit)
                {
                    Step();
                    Thread.Sleep(20);
                }                
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.tbProgress = (e.ProgressPercentage.ToString() + "%");
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                this.tbProgress = "Canceled!";
            }

            else if (!(e.Error == null))
            {
                this.tbProgress = ("Error: " + e.Error.Message);
            }

            else
            {
                this.tbProgress = "Done!";
            }
        }
    }
}
