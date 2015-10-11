using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt.Model.Entity.EntiyStates
{
	public enum EntiyStateType
	{
		[EntityStateInfoAttribute(typeof(EntityAlive))]
		entityAlive,
		[EntityStateInfoAttribute(typeof(EntityDead))]
		entityDead,
	}
}
