﻿using DuckHunt.Model.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt.Model.Entity.EntiyStates
{
	public abstract class EntityState
	{
		private EntityStateManager esm;
		EntityStateManager ESM
		{
			get { return esm; }
			set { esm = value; }
		}

		public virtual void init(EntityStateManager _ESM)
		{
			this.ESM = _ESM;
		}

		public virtual void cleanup()
		{
			this.ESM = null;
		}

		public virtual Boolean isHit()
		{
			return true;
		}
	}
}
