using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt.Model.Entity.EntiyStates
{
	public class EntityDaimentMove : EntityState
	{
		public EntityDaimentMove()
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
			move(dt);
		}

		public void move(double dt)
		{
			throw new NotImplementedException();
		}
	}
}
