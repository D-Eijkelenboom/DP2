using DuckHunt.Model.GameState;

namespace DuckHunt.Controller.Actions
{
	public abstract class ControllerAction
	{
		protected GameState GameState { get; set; }
		protected GameStateManager GSM { get; set; }

		public ActionType actionType { get; set; }

		public abstract void execute();
	}
}
