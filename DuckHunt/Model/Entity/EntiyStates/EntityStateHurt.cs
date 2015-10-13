using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt.Model.Entity.EntiyStates
{
	public class EntityStateHurt : EntityState
	{
		EntityStateManager ESM { get; set; }

		public EntityStateHurt() { }

		public override void init(EntityStateManager _ESM)
		{
			this.ESM = _ESM;
		}

		public override void cleanup()
		{
			this.ESM = null;
		}

		public override Boolean isHit()
		{
			ESM.changeEntityState(EntityStateFactory.createGameState(EntityStateType.entityStateDead));
			return false;
		}		
	}
}
