using DuckHunt.Model.GameState;

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
