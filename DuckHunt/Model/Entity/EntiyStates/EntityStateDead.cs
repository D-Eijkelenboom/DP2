using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt.Model.Entity.EntiyStates
{
	public class EntityStateDead : EntityState
	{
		private EntityStateManager esm;
		EntityStateManager ESM
		{
			get { return esm; }
			set { esm = value; }
		}

		public EntityStateDead() { }

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
			return false;
		}
	}
}
