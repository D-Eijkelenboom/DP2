using DuckHunt.Model.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt.Model.Entity.EntiyStates
{
	interface EntityState
	{
		GameStateManager GSM { get; set; }

		void init(GameStateManager gsm);

		void update(double dt);

		void move(double dt);
	}
}
