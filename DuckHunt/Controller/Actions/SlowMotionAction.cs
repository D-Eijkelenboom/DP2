using DuckHunt.Main;
using DuckHunt.Model.Entity;
using DuckHunt.Model.Entity.Interface;
using DuckHunt.Model.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt.Controller.Actions
{
	public class SlowMotionAction : ControllerAction
    {
        public SlowMotionAction(GameState _state)
        {
            this.GameState = _state;
			this.GSM = _state.GSM;
        }

		public override void execute()
		{
			foreach (Entity e in this.GameState.MainContainer[Behaviour.Visible])
			{
				e.slowDown();
			}
		}
    }
}
