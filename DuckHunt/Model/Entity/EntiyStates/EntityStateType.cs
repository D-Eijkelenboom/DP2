using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt.Model.Entity.EntiyStates
{
	public enum EntityStateType
	{
		[EntityStateInfoAttribute(typeof(EntityStateHealthy))]
		entityStateHealthy,
		[EntityStateInfoAttribute(typeof(EntityStateHurt))]
		entityStateHurt,
		[EntityStateInfoAttribute(typeof(EntityStateDead))]
		entityStateDead,
	}
}
