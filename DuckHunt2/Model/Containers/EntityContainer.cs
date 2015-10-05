using DuckHunt2.Model.Entities;
using System.Collections.Generic;

namespace DuckHunt2.Model.Containers
{
	public abstract class EntityContainer : List<Entity>
	{
		public abstract void update(double dt);
	}
}
