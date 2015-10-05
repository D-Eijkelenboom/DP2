using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt.Model.Container
{
	public class MovableContainer : EntityContainer
	{
		public override void update(double dt)
		{
			foreach (Entity.Entity e in this)
			{
				//moveRandomly(e);
			}
		}
	}
}
