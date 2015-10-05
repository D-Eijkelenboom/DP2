using DuckHunt.Controller;
using DuckHunt.Controller.Actions;
using DuckHunt.Model.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckHunt.Model.GameState
{
	public class PausedState : GameState
	{
		public GameStateManager GSM { get; set; }
		public PauseController PauseController { get; set; }
		public MainContainer MainContainer { get; set; }
		public ActionContainer ActionContainer { get; set; }

		public void init(GameStateManager gsm)
		{
			this.GSM = gsm;

			this.ActionContainer = new ActionContainer();

			this.MainContainer = new MainContainer();

			this.PauseController = new PauseController(this.GSM.GameWindow, this);
			this.PauseController.init();
		}

		public void cleanup()
		{
			this.PauseController.cleanup();
		}

		public void pause()
		{
			this.PauseController.cleanup();
		}

		public void resume()
		{
			this.PauseController.init();
		}

		public void handleInput()
		{
			ControllerAction action;
			lock (this.ActionContainer)
			{
				while (this.ActionContainer.Count > 0)
				{
					this.ActionContainer.TryDequeue(out action);
					if (action == null)
					{
						continue;
					}
					action.execute();
				}
			}
		}

		public void update(double dt)
		{

		}

		public void draw()
		{
			this.GSM.GameCanvas.drawStatusLabel("Game Paused");
		}
	}
}
