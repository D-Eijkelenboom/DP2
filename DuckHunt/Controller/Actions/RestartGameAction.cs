using DuckHunt.Model.GameState;

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
