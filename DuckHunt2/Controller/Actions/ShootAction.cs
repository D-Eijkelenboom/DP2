using DuckHunt2.Model;
using DuckHunt2.Model.Entities;

namespace DuckHunt2.Controller.Actions
{
	class ShootAction : ControllerAction
	{
		protected double x;
		protected double y;
		public double X { get { return x; } set { x = value; } }
		public double Y { get { return y; } set { y = value; } }

		public ShootAction(DuckHunt2.Model.Game game, double x, double y)
		{
			this.game = game;
			this.x = x;
			this.y = y;
		}

		public override void execute()
		{
			//game.Player.SoundLocation = "data\\Sounds\\Small_Gun_Shot.wav";
			//game.Player.Play();

			game.Bullets.Add(EntityFactory.createBullet(X, Y));

			foreach (IShootable e in game.MainContainer[Behaviour.Shootable])
			{
				if (e.IsAlive && e.isHit(X, Y))
				{
					//game.Player.SoundLocation = "data\\Sounds\\Blood_Hit.wav";
					//game.Player.Play();

					e.IsAlive = false;
					game.StatusTracker.increaseScore();
					break;
				}
			}
			game.StatusTracker.decreaseBullets();
		}

	}
}