using DuckHunt.Model.Entity;
using DuckHunt.Model.Entity.Interface;
using DuckHunt.Model.GameState;
using System;
using System.IO;

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
			try
			{
				GameState.GSM.Sound.SoundLocation = "..\\..\\Data\\Sounds\\Small_Gun_Shot.wav";
				GameState.GSM.Sound.Play();
			}
			catch (FileNotFoundException e)
			{
				Console.WriteLine(e.Message);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			GameState.GSM.Stats.substractBullets();
			GameState.GSM.Stats.increaseShots();
			foreach (IShootable e in this.GameState.MainContainer[Behaviour.Shootable])
			{
				if (e.isHit(this.X, this.Y))
				{
					try
					{
						GameState.GSM.Sound.SoundLocation = "..\\..\\Data\\Sounds\\Blood_Hit.wav";
						GameState.GSM.Sound.Play();
					}
					catch (FileNotFoundException ex)
					{
						Console.WriteLine(ex.Message);
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
					}

					if(!e.IsAlive)
					{
						this.GameState.MainContainer.removeEntity((Entity)e);
						break;	
					}
				}
			}
		}
	}
}
