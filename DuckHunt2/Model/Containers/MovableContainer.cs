using System.Collections.Generic;
using DuckHunt2.Model.Entities;

namespace DuckHunt2.Model.Containers
{
	public class MovableContainer : EntityContainer
	{
		public override void update(double dt)
		{
			foreach (Entity e in this)
			{
				//moveRandomly(e);
			}
			//throw new System.NotImplementedException();
		}
	}
}
