using System;

namespace DuckHunt.Model.Entity.Interface
{
	public interface IShootable
	{
		Boolean IsAlive { get; set; }
		Boolean isHit(double x, double y);
	}
}
