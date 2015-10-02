using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace duckhunt.Model
{
    class Game
    {
        private BackgroundWorker bgWorker;
        private string tbProgress;
        private bool running;
        private Form1 form;
        
        public Game(Form1  form)
        {
            this.form = form;

            bgWorker = new BackgroundWorker();
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.WorkerReportsProgress = true;

            bgWorker.DoWork +=
                new DoWorkEventHandler(bw_DoWork);
            bgWorker.ProgressChanged +=
                new ProgressChangedEventHandler(bw_ProgressChanged);
            bgWorker.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            Start();
        }
        
        public void Start()
        {
            form.Init();
            Level = new Level1();
            Level.BehaviourFactory.Canvas = form;
            Level.Create();

            if (bgWorker.IsBusy != true)
            {
                bgWorker.RunWorkerAsync();
            } 
            running = true;
        }

        private void Step()
        {
            Level.Step();            
            if (form.InvokeRequired)
                form.Invoke(new Action(() => form.Refresh()));
        }

        public void Stop()
        {
            running = false;
        }

        public void Shoot(System.Windows.Forms.MouseEventArgs e)
        {
            Level.Shoot(e);            
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

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.tbProgress = (e.ProgressPercentage.ToString() + "%");
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
                while (running)
                {
                    Step();

                    try
                    {
                        Thread.Sleep(20);
                    }
                    catch (Exception ex)    { }
                }
            }
        }

        public MoveContainer MoveContainer { get; set; }

        public DrawContainer DrawContainer { get; set; }

        public Level Level { get; set; }

        public UnitFactory UnitFactory { get; set; }
    }
}
