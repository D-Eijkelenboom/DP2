using DuckHunt.Model.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt.Controller.Actions
{
	public class PauseAction : ControllerAction
	{
		public PauseAction(GameState gameState)
		{
			this.GameState = gameState;
		}

		public override void execute()
		{
			this.GameState.GSM.pushGameState(GameStateFactory.createGameState(GameStateType.pause));
		}
	}
}
