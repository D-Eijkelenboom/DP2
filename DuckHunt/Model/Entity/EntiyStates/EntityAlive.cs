using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt.Model.Entity.EntiyStates
{
	public class EntityAlive : EntityState
	{
		public EntityAlive()
		{

		}

		public GameState.GameStateManager GSM
		{
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}

		public void init(GameState.GameStateManager gsm)
		{
			throw new NotImplementedException();
		}

		public void update(double dt)
		{
			throw new NotImplementedException();
		}

		public void move(double dt)
		{
			throw new NotImplementedException();
		}
	}
}
