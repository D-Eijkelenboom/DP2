using DuckHunt.Model.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
