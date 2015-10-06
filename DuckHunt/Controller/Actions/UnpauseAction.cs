using DuckHunt.Model.GameState;

namespace DuckHunt.Controller.Actions
{
	public class UnpauseAction : ControllerAction
	{
		public UnpauseAction(GameState gameState)
		{
			this.GameState = gameState;
		}

		public override void execute()
		{
			this.GameState.GSM.popGameState();
		}
	}
}
