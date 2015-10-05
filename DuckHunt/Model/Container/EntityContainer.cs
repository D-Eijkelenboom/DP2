using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt.Model.Container
{
	public abstract class EntityContainer : List<Entity.Entity>
	{
		public abstract void update(double dt);
	}
}
