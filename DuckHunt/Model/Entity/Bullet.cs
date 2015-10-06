﻿
namespace DuckHunt.Model.Entity
{
	public class Bullet : Entity
	{

		public Bullet(double x, double y)
			: base(x, y)
		{
			this.Height = 30;
			this.Width = 30;
			this.x = x;
			this.y = y;
			this.moveSpeed = 0;
		}

		public override void update(double dt)
		{

		}
	}
}
