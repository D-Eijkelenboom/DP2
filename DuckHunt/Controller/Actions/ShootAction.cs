using DuckHunt.Model.Entity;
using DuckHunt.Model.Entity.Interface;
using DuckHunt.Model.GameState;

namespace DuckHunt.Controller.Actions
{
	public class ShootAction : ControllerAction
	{
		public double X { get; set; }
		public double Y { get; set; }

		public ShootAction(GameState gameState, double x, double y)
		{
			this.GameState = gameState;
			this.X = x;
			this.Y = y;
		}

		public override void execute()
		{
			foreach (IShootable e in this.GameState.MainContainer[Behaviour.Shootable])
			{
				if (e.IsAlive && e.isHit(this.X, this.Y))
				{
					this.GameState.MainContainer.removeEntity((Entity)e);
					break;
				}
			}
		}
	}
}
