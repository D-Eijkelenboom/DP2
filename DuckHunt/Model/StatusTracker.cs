using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt.Model
{
	public class StatusTracker
	{
		private double fps;
		public double FPS { get { return fps; } set { fps = value; } }

		private int shots;
		public int Shots
		{
			get { return shots; }
			set { shots = value; }
		}

		private int bullets;
		public int Bullets
		{
			get { return bullets; }
			set { bullets = value; }
		}

		private long gameTime;
		public long GameTime
		{
			get { return gameTime; }
			set { gameTime = value; }
		}

		private long palyTime;
		public long playTime
		{
			get { return playTime; }
			set { playTime = value; }
		}

		public StatusTracker()
		{
			this.gameTime = 0;
			this.shots = 0;
			this.bullets = 0;
		}

		public void increaseShots()
		{
			this.Shots++;
		}

		public void increaseTime(long time)
		{
			this.GameTime += time;
		}

		public void setGameTime(long time)
		{
			this.GameTime = time;
		}

		public void substractBullets()
		{
			this.Bullets--;
		}
	}
}
