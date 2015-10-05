using DuckHunt2.Model;

namespace DuckHunt2.Controller.Actions
{
	public abstract class ControllerAction
	{
		protected DuckHunt2.Model.Game game;

		public abstract void execute();
	}
}
