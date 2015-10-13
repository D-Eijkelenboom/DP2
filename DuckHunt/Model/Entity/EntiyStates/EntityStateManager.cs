using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt.Model.Entity.EntiyStates
{
	public class EntityStateManager
	{
		private Stack<EntityState> entityStates;
		public Stack<EntityState> EntityStates
		{
			get { return entityStates; }
			set { entityStates = value; }
		}
		public EntityStateManager()
		{
			entityStates = new Stack<EntityState>();
			this.changeEntityState(EntityStateFactory.createGameState(EntityStateType.entityStateHealthy));
		}

		public void changeEntityState(EntityState entityState)
		{
			if (!(EntityStates.Count < 1))
			{
				EntityStates.Peek().cleanup();
				EntityStates.Pop();
			}

			EntityStates.Push(entityState);
			EntityStates.Peek().init(this);
		}

		public bool isHit()
		{
			return EntityStates.Peek().isHit();
		}
	}
}
