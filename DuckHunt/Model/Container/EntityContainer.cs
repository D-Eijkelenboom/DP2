using System.Collections.Generic;

namespace DuckHunt.Model.Container
{
	public abstract class EntityContainer : List<Entity.Entity>
	{
		public abstract void update(double dt);
	}
}
