using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuckHunt.Helper;

namespace DuckHunt.Model.Entity.EntiyStates
{
	public class EntityStateFactory
	{
		public static EntityState createGameState(EntityStateType entityState)
		{
			var gameStateAttribute = entityState.GetAttribute<EntityStateInfoAttribute>();

			if (gameStateAttribute == null)
				return null;

			var type = gameStateAttribute.Type;
			EntityState result = Activator.CreateInstance(type) as EntityState;
			return result;
		}
	}
}
