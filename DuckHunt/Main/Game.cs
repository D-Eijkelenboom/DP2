using DuckHunt.Model.GameState;
using System;
using System.Diagnostics;
using System.Threading;

namespace DuckHunt.Main
{
	public class Game
	{
		private GameStateManager gsm;

		public bool Running { get; set; }
		private Stopwatch stopWatch;
		private Thread gameLoop;

		public Game()
		{
			this.gsm = new GameStateManager(this);

			gameLoop = new Thread(new ThreadStart(run));
			gameLoop.IsBackground = true;
			gameLoop.Start();

		}

		public void run()
		{
			stopWatch = new Stopwatch();


			double TARGET_FPS = 60;
			double OPTIMAL_TIME = 1000 / TARGET_FPS;

			stopWatch.Start();

			long lastLoopTime = stopWatch.ElapsedMilliseconds;

			long lastFpsTime = 0;
			int fps = 0;

			this.Running = true;
			while (this.Running)
			{
				long now = stopWatch.ElapsedMilliseconds;
				long updateLength = now - lastLoopTime;
				lastLoopTime = now;
				double dt = updateLength / OPTIMAL_TIME;

				lastFpsTime += updateLength;
				fps++;

				if (lastFpsTime >= 1000)
				{
					lastFpsTime = 0;
					fps = 0;
				}

				this.gsm.update(dt);
				this.gsm.handleInput();
				this.gsm.draw();

				long timeAfterLoop = stopWatch.ElapsedMilliseconds;


				if (lastLoopTime - timeAfterLoop + OPTIMAL_TIME > 0)
				{
					Thread.Sleep(TimeSpan.FromMilliseconds(lastLoopTime - timeAfterLoop + OPTIMAL_TIME));
				}
			}
		}
	}
}
