﻿
namespace DuckHunt.Model.Container
{
	public class ShootableContainer : EntityContainer
	{
		public override void update(double dt)
		{
			foreach (Entity.Entity e in this)
			{
				//e.update(dt);
			}
		}
	}
}
