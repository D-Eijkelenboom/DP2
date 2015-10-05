using DuckHunt.Model.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt.Controller.Actions
{
	public class RestartGameAction : ControllerAction
	{
		public RestartGameAction(GameState gameState)
		{
			this.GameState = gameState;
		}

		public override void execute()
		{
			this.GameState.GSM.changeGameState(GameStateFactory.createGameState(GameStateType.level1));
		}
	}
}
