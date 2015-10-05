using System.Diagnostics;

namespace DuckHunt2.Helper
{
	class Timer
	{
		private Stopwatch stopWatch;

		public long ElapsedMilliSeconds
		{
			get { return stopWatch.ElapsedMilliseconds; }
		}

		public long ElapsedTicks
		{
			get { return stopWatch.ElapsedTicks; }
		}

		public Timer()
		{
			stopWatch = new Stopwatch();
			stopWatch.Reset();
		}

		public void Start()
		{
			if (!stopWatch.IsRunning)
			{
				stopWatch.Reset();
				stopWatch.Restart();
			}
		}

		public void Stop()
		{
			stopWatch.Stop();
		}
	}
}
