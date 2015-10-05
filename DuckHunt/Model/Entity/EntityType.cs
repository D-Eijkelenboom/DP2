using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt.Model.Entity
{
	public enum EntityType
	{
		[EntityInfoAttribute(typeof(Chicken))]
		Chicken,
		[EntityInfoAttribute(typeof(Balloon))]
		Balloon,
		[EntityInfoAttribute(typeof(Bullet))]
		Bullet,
	}
}
